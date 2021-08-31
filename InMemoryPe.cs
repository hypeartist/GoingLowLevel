using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GoingLowLevel
{
	public unsafe class InMemoryPe
	{
		private readonly byte* _data;

		private InMemoryPe(byte* data)
		{
			_data = data;
		}

		public static InMemoryPe Map(byte* src)
		{
			nuint optionalSectionSize;
			nuint lastSectionEnd = 0;
			nuint alignedImageSize;
			nint locationDelta;

			var dosHeader = (ImageDosHeader*) src;
			if (dosHeader->Magic != Signatures.Dos)
			{
				throw new BadImageFormatException("Not a valid executable file.");
			}

			var oldHeader = (ImageNtHeaders*) (src + dosHeader->LfaNew);
			if (oldHeader->Signature != Signatures.Nt)
			{
				throw new BadImageFormatException("Not a valid PE file.");
			}

			if (oldHeader->FileHeader.Machine != (Environment.Is64BitProcess ? MachineType.Amd64 : MachineType.I386))
			{
				throw new BadImageFormatException("Machine type doesn't fit. (i386 vs. AMD64)");
			}

			if ((oldHeader->OptionalHeader.SectionAlignment & 1) > 0)
			{
				throw new BadImageFormatException("Wrong section alignment");
			}

			var section = ImageFirstSection(oldHeader);
			optionalSectionSize = oldHeader->OptionalHeader.SectionAlignment;
			for (var i = 0; i < oldHeader->FileHeader.NumberOfSections; i++, section++)
			{
				nuint endOfSection;
				if (section->SizeOfRawData == 0)
				{
					endOfSection = section->VirtualAddress + optionalSectionSize;
				}
				else
				{
					endOfSection = section->VirtualAddress + section->SizeOfRawData;
				}

				if (endOfSection > lastSectionEnd)
				{
					lastSectionEnd = endOfSection;
				}
			}

			alignedImageSize = AlignValueUp(oldHeader->OptionalHeader.SizeOfImage, (nuint) Environment.SystemPageSize);
			if (alignedImageSize != AlignValueUp(lastSectionEnd, (nuint) Environment.SystemPageSize)) throw new BadImageFormatException("Wrong section alignment.");
			var dst = (byte*) PlatformApi.Kernel32.VirtualAlloc((void*) (Environment.Is64BitProcess ? oldHeader->OptionalHeader.ImageBase64 : oldHeader->OptionalHeader.ImageBase32), oldHeader->OptionalHeader.SizeOfImage, PlatformApi.AllocationType.Reserve | PlatformApi.AllocationType.Commit, PlatformApi.MemoryProtection.ReadWrite);

			if (dst == null)
			{
				dst = (byte*) PlatformApi.Kernel32.VirtualAlloc(null, oldHeader->OptionalHeader.SizeOfImage, PlatformApi.AllocationType.Reserve | PlatformApi.AllocationType.Commit, PlatformApi.MemoryProtection.ReadWrite);
			}

			if (dst == null)
			{
				throw new OutOfMemoryException("Out of Memory");
			}
			if (Environment.Is64BitProcess)
			{
				while ((ulong) dst >> 32 < (ulong) (dst + alignedImageSize) >> 32)
				{
					dst = (byte*) PlatformApi.Kernel32.VirtualAlloc(null, alignedImageSize, PlatformApi.AllocationType.Reserve | PlatformApi.AllocationType.Commit, PlatformApi.MemoryProtection.ReadWrite);

					if (dst == null) throw new OutOfMemoryException("Out of Memory");
				}
			}

			var isDll = (oldHeader->FileHeader.Characteristics & 0x2000 /*IMAGE_FILE_DLL*/) != 0;

			var headers = (byte*) PlatformApi.Kernel32.VirtualAlloc(dst, oldHeader->OptionalHeader.SizeOfHeaders, PlatformApi.AllocationType.Commit, PlatformApi.MemoryProtection.ReadWrite);

			if (headers == null)
			{
				throw new OutOfMemoryException("Out of Memory");
			}

			Unsafe.CopyBlock(headers, src, (uint) (dosHeader->LfaNew + oldHeader->OptionalHeader.SizeOfHeaders));
			var ntHeaders = (ImageNtHeaders*) &headers[dosHeader->LfaNew];

			if (Environment.Is64BitProcess)
			{
				ntHeaders->OptionalHeader.ImageBase64 = (ulong) dst;
			}
			else
			{
				ntHeaders->OptionalHeader.ImageBase32 = (uint) dst;
			}

			CopySections(src, dst, ntHeaders, oldHeader);

			locationDelta = Environment.Is64BitProcess ? (nint) (ntHeaders->OptionalHeader.ImageBase64 - oldHeader->OptionalHeader.ImageBase64) : (nint) (ntHeaders->OptionalHeader.ImageBase32 - oldHeader->OptionalHeader.ImageBase32);
			if (locationDelta != 0)
			{
				PerformBaseRelocation(dst, ntHeaders, locationDelta);
			}

			BuildImportTable(dst, ntHeaders);
			FinalizeSections(ntHeaders);
			ExecuteTlsCallbacks(dst, ntHeaders);

			if (ntHeaders->OptionalHeader.AddressOfEntryPoint == 0) throw new InvalidOperationException("DLL has no entry point");

			if (isDll)
			{
				void* dllEntryPtr = dst + ntHeaders->OptionalHeader.AddressOfEntryPoint;
				if (((delegate*<void*, uint, void*, int>) dllEntryPtr)(dst, 1, null) != 1)
				{
					throw new InvalidOperationException("Can't attach DLL to process.");
				}
			}

			return new InMemoryPe(dst);
		}

		private static void CopySections(byte* src, byte* dst, ImageNtHeaders* ntHeaders, ImageNtHeaders* oldHeader)
		{
			var oldSection = ImageFirstSection(ntHeaders);

			for (var i = 0; i < ntHeaders->FileHeader.NumberOfSections; i++, oldSection++)
			{
				byte* section;
				if (oldSection->SizeOfRawData == 0)
				{
					var size = oldHeader->OptionalHeader.SectionAlignment;
					if (size > 0)
					{
						section = (byte*) PlatformApi.Kernel32.VirtualAlloc(dst + oldSection->VirtualAddress, size, PlatformApi.AllocationType.Commit, PlatformApi.MemoryProtection.ReadWrite);

						if (section == null) throw new OutOfMemoryException("Unable to allocate memory.");

						section = dst + oldSection->VirtualAddress;

						oldSection->PhysicalAddress = (uint) section & 0xffffffff;
						Unsafe.InitBlock(section, 0, size);
					}

					continue;
				}

				section = (byte*) PlatformApi.Kernel32.VirtualAlloc(dst + oldSection->VirtualAddress, oldSection->SizeOfRawData, PlatformApi.AllocationType.Commit, PlatformApi.MemoryProtection.ReadWrite);

				if (section == null)
				{
					throw new OutOfMemoryException("Out of memory.");
				}

				section = dst + oldSection->VirtualAddress;
				Unsafe.CopyBlock(section, src + oldSection->PointerToRawData, oldSection->SizeOfRawData);
				oldSection->PhysicalAddress = (uint) section & 0xffffffff;
			}
		}

		private static bool PerformBaseRelocation(byte* dst, ImageNtHeaders* ntHeaders, nint delta)
		{
			var imageSizeOfBaseRelocation = Unsafe.SizeOf<ImageBaseRelocation>();
			var directory = Environment.Is64BitProcess ? &ntHeaders->OptionalHeader.BaseRelocationTable64 : &ntHeaders->OptionalHeader.BaseRelocationTable32;
			switch (directory->Size)
			{
				case 0:
					return delta == 0;
				case > 0:
				{
					var relocation = (ImageBaseRelocation*) (dst + directory->VirtualAddress);
					while (relocation->VirtualAdress > 0)
					{
						var rel = dst + relocation->VirtualAdress;
						var relInfo = (ushort*) ((byte*) relocation + imageSizeOfBaseRelocation);

						for (var i = 0; i < ((relocation->SizeOfBlock - imageSizeOfBaseRelocation) / 2); i++, relInfo++)
						{
							var type = (BasedRelocationType) (*relInfo >> 12);
							var offset = *relInfo & 0xfff;

							switch (type)
							{
								case BasedRelocationType.Absolute:
									break;
								case BasedRelocationType.HighLow:
									var patchAddrHl = (uint*) (rel + offset);
									*patchAddrHl += (uint) delta;
									break;
								case BasedRelocationType.Dir64:
									var patchAddr64 = (ulong*) (rel + offset);
									*patchAddr64 += (ulong) delta;
									break;
							}
						}

						relocation = (ImageBaseRelocation*) (((byte*) relocation) + relocation->SizeOfBlock);
					}

					break;
				}
			}

			return true;
		}

		private static void BuildImportTable(byte* dst, ImageNtHeaders* ntHeaders)
		{
			var directory = Environment.Is64BitProcess ? &ntHeaders->OptionalHeader.ImportTable64 : &ntHeaders->OptionalHeader.ImportTable32;
			if (directory->Size == 0)
			{
				throw new InvalidOperationException("Invalid import table.");
			}

			var importDesc = (ImageImportDescriptor*) (dst + directory->VirtualAddress);
			for (; importDesc + (nuint) Unsafe.SizeOf<ImageImportDescriptor>() != null && importDesc->Name > 0; importDesc++)
			{
				nuint* thunkRef;
				nint* funcRef;

				var handle = PlatformApi.Kernel32.LoadLibraryA(dst + importDesc->Name);

				if (handle == null)
				{
					throw new InvalidOperationException("Can't load libary ");
				}

				if (importDesc->OriginalFirstThunk > 0)
				{
					thunkRef = (nuint*) (dst + importDesc->OriginalFirstThunk);
					funcRef = (nint*) (dst + importDesc->FirstThunk);
				}
				else
				{
					thunkRef = (nuint*) (dst + importDesc->FirstThunk);
					funcRef = (nint*) (dst + importDesc->FirstThunk);
				}

				for (; *thunkRef > 0; thunkRef++, funcRef++)
				{
					if (ImageSnapByOrdinal(*thunkRef))
					{
						*funcRef = (nint) GetProcAddress(handle, UtilityMethods.GetAnsiString((void*) ImageOrdinal(*thunkRef)));
					}
					else
					{
						var thunkData = (ImageImportByName*) (dst + (*thunkRef));
						*funcRef = (nint) GetProcAddress(handle, UtilityMethods.GetAnsiString(&thunkData->Name));
					}

					if (*funcRef == 0)
					{
						throw new InvalidOperationException("Can't get adress for imported function.");
					}
				}
			}
		}

		private static readonly PlatformApi.PageProtection[,,] ProtectionFlags = {{{PlatformApi.PageProtection.NoAccess, PlatformApi.PageProtection.WriteCopy}, {PlatformApi.PageProtection.ReadOnly, PlatformApi.PageProtection.ReadWrite}}, {{PlatformApi.PageProtection.Execute, PlatformApi.PageProtection.WriteCopy}, {PlatformApi.PageProtection.ExecuteRead, PlatformApi.PageProtection.ExecuteReadWrite}}};

		private class SectionFinalizeData
		{
			public void* Address { get; set; }
			public void* AlignedAddress { get; set; }
			public nuint Size { get; set; }
			public uint Characteristics { get; set; }
			public bool Last { get; set; }
		}

		private static void FinalizeSections(ImageNtHeaders* ntHeaders)
		{
			var section = ImageFirstSection(ntHeaders);

			var imageOffset = Environment.Is64BitProcess ? ((nuint) ntHeaders->OptionalHeader.ImageBase64 & 0xffffffff00000000) : 0;

			var sectionData = new SectionFinalizeData {Address = (void*) (section->PhysicalAddress | imageOffset)};
			sectionData.AlignedAddress = AlignAddressDown(sectionData.Address, (nuint) Environment.SystemPageSize);
			sectionData.Size = GetRealSectionSize(ntHeaders, section);
			sectionData.Characteristics = section->Characteristics;
			sectionData.Last = false;
			section++;

			for (var i = 1; i < ntHeaders->FileHeader.NumberOfSections; i++, section++)
			{
				var sectionAddress = (void*) (section->PhysicalAddress | imageOffset);
				var alignedAddress = AlignAddressDown(sectionAddress, (nuint) Environment.SystemPageSize);
				var sectionSize = GetRealSectionSize(ntHeaders, section);
				if (sectionData.AlignedAddress == alignedAddress || (nuint) sectionData.Address + sectionData.Size > (nuint) alignedAddress)
				{
					if ((section->Characteristics & Discardable) == 0 || (sectionData.Characteristics & Discardable) == 0)
					{
						sectionData.Characteristics = (sectionData.Characteristics | section->Characteristics) & ~Discardable;
					}
					else
					{
						sectionData.Characteristics |= section->Characteristics;
					}

					sectionData.Size = (((nuint) sectionAddress) + (sectionSize)) - (nuint) sectionData.Address;
					continue;
				}

				FinalizeSection(ntHeaders, sectionData);

				sectionData.Address = sectionAddress;
				sectionData.AlignedAddress = alignedAddress;
				sectionData.Size = sectionSize;
				sectionData.Characteristics = section->Characteristics;
			}

			sectionData.Last = true;
			FinalizeSection(ntHeaders, sectionData);
		}

		private static void FinalizeSection(ImageNtHeaders* ntHeaders, SectionFinalizeData sectionData)
		{
			if (sectionData.Size == 0) return;

			if ((sectionData.Characteristics & Discardable) > 0)
			{
				if (sectionData.Address == sectionData.AlignedAddress && (sectionData.Last || ntHeaders->OptionalHeader.SectionAlignment == (nuint) Environment.SystemPageSize || (sectionData.Size % (nuint) Environment.SystemPageSize) == 0))
				{
					PlatformApi.Kernel32.VirtualFree(sectionData.Address, sectionData.Size, PlatformApi.AllocationType.Decommit);
				}

				return;
			}

			var executable = (sectionData.Characteristics & (uint) ImageSectionFlags.Execute) != 0 ? 1 : 0;
			var readable = (sectionData.Characteristics & (uint) ImageSectionFlags.Read) != 0 ? 1 : 0;
			var writeable = (sectionData.Characteristics & (uint) ImageSectionFlags.Write) != 0 ? 1 : 0;
			var protect = (uint) ProtectionFlags[executable, readable, writeable];
			if ((sectionData.Characteristics & NotCached) > 0)
			{
				protect |= PageNoCache;
			}

			uint _ = 0;
			if (!PlatformApi.Kernel32.VirtualProtect(sectionData.Address, sectionData.Size, protect, &_)) throw new InvalidOperationException("Error protecting memory page");
		}

		private static nuint GetRealSectionSize(ImageNtHeaders* ntHeaders, ImageSectionHeader* section)
		{
			var size = section->SizeOfRawData;
			if (size == 0)
			{
				if ((section->Characteristics & InitializedData) > 0)
				{
					size = ntHeaders->OptionalHeader.SizeOfInitializedData;
				}
				else if ((section->Characteristics & UninitializedData) > 0)
				{
					size = ntHeaders->OptionalHeader.SizeOfUninitializedData;
				}
			}

			return size;
		}

		private static void ExecuteTlsCallbacks(byte* dst, ImageNtHeaders* ntHeaders)
		{
			var directory = Environment.Is64BitProcess ? &ntHeaders->OptionalHeader.TLSTable64 : &ntHeaders->OptionalHeader.TLSTable32;
			if (directory->VirtualAddress == 0) return;

			var tlsDir = (ImageTlsDirectory*) (dst + directory->VirtualAddress);
			var callbackPtr = Environment.Is64BitProcess ? (nuint*) tlsDir->AddressOfCallBacks64 : (nuint*) tlsDir->AddressOfCallBacks32;
			if (callbackPtr == null) return;
			for (; *callbackPtr > 0; callbackPtr++)
			{
				((delegate*<void*, nuint, void*, void>) *callbackPtr)(dst, 1, null);
			}
		}

		private static nuint AlignValueUp(nuint value, nuint alignment) => (value + alignment - 1) & ~(alignment - 1);
		
		private static nuint AlignValueDown(nuint value, nuint alignment) => value & ~(alignment - 1);
		
		private static void* AlignAddressDown(void* address, nuint alignment) => (void*) AlignValueDown((nuint) address, alignment);

		private static ImageSectionHeader* ImageFirstSection(ImageNtHeaders* ntheader) => (ImageSectionHeader*) ((nuint) ntheader + (ulong) &ntheader->OptionalHeader - (ulong) ntheader + ntheader->FileHeader.SizeOfOptionalHeader);

		private static ulong ImageOrdinal(ulong ordinal) => ordinal & 0xffff;

		private static bool ImageSnapByOrdinal(ulong ordinal) => Environment.Is64BitProcess ? ((ordinal & 0x8000000000000000) != 0) : ((ordinal & 0x80000000) != 0);

		public void* GetProcAddress(ReadOnlySpan<char> procName)
		{
			return GetProcAddress(_data, procName);
		}

		public static void* GetProcAddress(void* moduleHandle, ReadOnlySpan<char> procName)
		{
			Span<byte> tmp = stackalloc byte[260/*MAX_PATH_LENGTH*/];
			for (var i = 0; i < procName.Length; i++)
			{
				tmp[i] = (byte) procName[i];
			}
			return GetProcAddress(moduleHandle, tmp[.. procName.Length]);
		}

		public static void* GetProcAddress(void* moduleHandle, ReadOnlySpan<byte> procName)
		{
			var module = (byte*)moduleHandle;

			var dosHeader = *(ImageDosHeader*)module;
			var optHeader = ((ImageNtHeaders*) (module + dosHeader.LfaNew))->OptionalHeader;
			var exportTable = Environment.Is64BitProcess ? optHeader.ExportTable64 : optHeader.ExportTable32;

			var exportDirectoryPtr = (ImageExportDirectory*)(module + exportTable.VirtualAddress);
			var exportDirectory = *exportDirectoryPtr;

			var funcTable = (uint*) (module + exportDirectory.AddressOfFunctions);
			var ordTable = (ushort*) (module + exportDirectory.AddressOfNameOrdinals);
			var nameTable = (uint*) (module + exportDirectory.AddressOfNames);
			void* address = default;

			var pProcName = procName.GetDataPointer();
			if ((uint)pProcName>> 16 == 0)
			{
				var ordinal = unchecked((short)(long)pProcName);
				if (ordinal < exportDirectory.Base || ordinal > exportDirectory.Base + exportDirectory.NumberOfFunctions)
				{
					return default;
				}
				address = module + (ushort)(int)funcTable[(int)(ordinal - exportDirectory.Base)];
			}
			else
			{
				for (var i = 0; i < exportDirectory.NumberOfNames; i++)
				{
					var fnName = UtilityMethods.GetAnsiString(module + nameTable[i]);
					if (!procName.SequenceEqual(fnName)) continue;
					address = module + funcTable[ordTable[i]];
					break;
				}
			}

			if (address < exportDirectoryPtr || address >= exportDirectoryPtr + exportTable.Size)
			{
				return address;
			}

			var dllName = UtilityMethods.GetAnsiString((byte*)address);
			var splitAt = dllName.IndexOf((byte)'.');
			var forwardedDllName = dllName[..splitAt];
			Span<byte> tmp = stackalloc byte[dllName.Length + 4];
			forwardedDllName.CopyTo(tmp);
			tmp[^4] = (byte)'.';
			tmp[^3] = (byte)'d';
			tmp[^2] = (byte)'l';
			tmp[^1] = (byte)'l';
			var forwardedModule = PlatformApi.Kernel32.LoadLibraryA((byte*) tmp.GetDataPointer());
			if (forwardedModule != null)
			{
				address = GetProcAddress(forwardedModule, dllName[(splitAt + 1)..]);
			}

			return address;
		}

		private static class Signatures
		{
			public const ushort Dos = 0x5A4D;
			public const uint Nt = 0x00004550;
		}

		private enum MachineType : ushort
		{
			I386 = 0x014c,
			Amd64 = 0x8664
		}

		private enum BasedRelocationType
		{
			Absolute = 0,
			HighLow = 3,
			Dir64 = 10
		}

		private const uint InitializedData = 0x00000040;
		private const uint UninitializedData = 0x00000080;
		private const uint Discardable = 0x02000000;
		private const uint NotCached = 0x04000000;
		private const uint PageNoCache = 0x200;

		private enum ImageSectionFlags : uint
		{
			Execute = 0x20000000,
			Read = 0x40000000,
			Write = 0x80000000
		}

		[StructLayout(LayoutKind.Explicit, Size = 0x40)]
		private readonly struct ImageDosHeader
		{
			[FieldOffset(0x00)]
			public readonly ushort Magic;

			[FieldOffset(0x3c)]
			public readonly int LfaNew;
		}

		[StructLayout(LayoutKind.Explicit)]
		private struct ImageNtHeaders
		{
			[FieldOffset(0x00)]
			public readonly uint Signature;

			[FieldOffset(0x04)]
			public readonly ImageFileHeader FileHeader;

			[FieldOffset(0x18)]
			public ImageOptionalHeader OptionalHeader;
		}

		[StructLayout(LayoutKind.Explicit, Size = 0x14)]
		private readonly struct ImageFileHeader
		{
			[FieldOffset(0x00)]
			public readonly MachineType Machine;

			[FieldOffset(0x02)]
			public readonly ushort NumberOfSections;

			[FieldOffset(0x10)]
			public readonly ushort SizeOfOptionalHeader;

			[FieldOffset(0x12)]
			public readonly ushort Characteristics;
		}

		[StructLayout(LayoutKind.Explicit)]
		private struct ImageOptionalHeader
		{
			[FieldOffset(0x08)]
			public readonly uint SizeOfInitializedData;

			[FieldOffset(0x0c)]
			public readonly uint SizeOfUninitializedData;

			[FieldOffset(0x10)]
			public readonly uint AddressOfEntryPoint;

			[FieldOffset(0x1c)]
			public uint ImageBase32;

			[FieldOffset(0x18)]
			public ulong ImageBase64;

			[FieldOffset(0x20)]
			public readonly uint SectionAlignment;

			[FieldOffset(0x38)]
			public readonly uint SizeOfImage;

			[FieldOffset(0x3c)]
			public readonly uint SizeOfHeaders;

			[FieldOffset(0x60)]
			public readonly ImageDataDirectory ExportTable32;

			[FieldOffset(0x70)]
			public readonly ImageDataDirectory ExportTable64;

			[FieldOffset(0x68)]
			public readonly ImageDataDirectory ImportTable32;

			[FieldOffset(0x78)]
			public readonly ImageDataDirectory ImportTable64;

			[FieldOffset(0xa0)]
			public readonly ImageDataDirectory BaseRelocationTable32;

			[FieldOffset(0xb0)]
			public readonly ImageDataDirectory BaseRelocationTable64;

			[FieldOffset(0xd8)]
			public readonly ImageDataDirectory TLSTable32;

			[FieldOffset(0xe8)]
			public readonly ImageDataDirectory TLSTable64;
		}

		[StructLayout(LayoutKind.Explicit, Size = 0x08)]
		private readonly struct ImageDataDirectory
		{
			[FieldOffset(0x00)]
			public readonly uint VirtualAddress;

			[FieldOffset(0x04)]
			public readonly uint Size;
		}

		[StructLayout(LayoutKind.Explicit, Size = 0x28)]
		private struct ImageSectionHeader
		{
			[FieldOffset(0x08)]
			public uint PhysicalAddress;

			[FieldOffset(0x0c)]
			public readonly uint VirtualAddress;

			[FieldOffset(0x10)]
			public readonly uint SizeOfRawData;

			[FieldOffset(0x14)]
			public readonly uint PointerToRawData;

			[FieldOffset(0x24)]
			public readonly uint Characteristics;
		}

		[StructLayout(LayoutKind.Explicit)]
		private readonly struct ImageImportDescriptor
		{
			[FieldOffset(0x00)]
			public readonly uint OriginalFirstThunk;

			[FieldOffset(0x0c)]
			public readonly uint Name;

			[FieldOffset(0x10)]
			public readonly uint FirstThunk;
		}

		[StructLayout(LayoutKind.Explicit)]
		private readonly struct ImageImportByName
		{
			[FieldOffset(0x02)]
			public readonly FixedArray1<byte> Name;
		}

		[StructLayout(LayoutKind.Explicit)]
		private readonly struct ImageExportDirectory
		{
			[FieldOffset(0x10)]
			public readonly uint Base;

			[FieldOffset(0x14)]
			public readonly uint NumberOfFunctions;

			[FieldOffset(0x18)]
			public readonly uint NumberOfNames;

			[FieldOffset(0x1c)]
			public readonly uint AddressOfFunctions;

			[FieldOffset(0x20)]
			public readonly uint AddressOfNames;

			[FieldOffset(0x24)]
			public readonly uint AddressOfNameOrdinals;
		}

		[StructLayout(LayoutKind.Sequential)]
		private readonly struct ImageBaseRelocation
		{
			public readonly uint VirtualAdress;
			public readonly uint SizeOfBlock;
		}

		[StructLayout(LayoutKind.Explicit)]
		private readonly struct ImageTlsDirectory
		{
			[FieldOffset(0x0c)]
			public readonly ulong AddressOfCallBacks32;

			[FieldOffset(0x18)]
			public readonly ulong AddressOfCallBacks64;
		}
	}
}