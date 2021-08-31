using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

#pragma warning disable 649
#pragma warning disable 169

namespace GoingLowLevel
{
	public static unsafe class PebHelper
	{
		private readonly struct ListEntry
		{
			public readonly byte* Flink;
			public readonly byte* Blink;
		}

		private readonly struct PebLdrData
		{
			private readonly byte _1;
			private readonly byte _2;
			private readonly byte _3;
			private readonly byte _4;
			private readonly byte _5;
			private readonly byte _6;
			private readonly byte _7;
			private readonly byte _8;
			private readonly IntPtr _9;
			private readonly IntPtr _10;
			private readonly IntPtr _11;
			public readonly ListEntry InMemoryOrderModuleList;
		}

		private readonly struct Peb
		{
			private readonly byte _1;
			private readonly byte _2;
			private readonly byte _3;
			private readonly byte _4;
			private readonly byte _5;
			private readonly IntPtr _6;
			private readonly IntPtr _7;
			public readonly PebLdrData* Ldr;
		}

		private readonly struct UnicodeString
		{
			public readonly ushort Length;
			public readonly ushort MaximumLength;
			public readonly char* Buffer;
		}

		private readonly struct LdrDataTableEntry
		{
			public readonly ListEntry InMemoryOrderLinks;
			public readonly ListEntry InInitializationOrderList;
			public readonly IntPtr DllBase;
			public readonly IntPtr EntryPoint;
			private readonly IntPtr _1;
			public readonly UnicodeString FullDllName;
			public readonly UnicodeString BaseDllName;
		}

		private static Peb* GetPebImpl()
		{
			var currentThread = Thread.CurrentThread;
			var fieldOffset = RuntimeInformation.FrameworkDescription.AsSpan().StartsWith(".NET 6.0") ? 0x5 : 0x6;
			var hThread = *((IntPtr*)*(IntPtr*)Unsafe.AsPointer(ref currentThread) + fieldOffset);
			return (Peb*)(*((IntPtr*) hThread + 0x13) - Environment.SystemPageSize);
		}

		public static void* GetModuleHandle(ReadOnlySpan<char> name)
		{
			if(!name.EndsWith(".dll"))
			{
				Span<char> tmp = stackalloc char[name.Length + 4];
				name.CopyTo(tmp);
				tmp[^4] = '.';
				tmp[^3] = 'd';
				tmp[^2] = 'l';
				tmp[^1] = 'l';
				name = MemoryMarshal.CreateReadOnlySpan(ref tmp[0], tmp.Length);
			}
			var peb = *GetPebImpl();
			var pPebEntry = (LdrDataTableEntry*)peb.Ldr->InMemoryOrderModuleList.Flink;
			var pebEntry = *pPebEntry;
			var pHeadEntry = pPebEntry;
			while (true)
			{
				pPebEntry = (LdrDataTableEntry*)pebEntry.InMemoryOrderLinks.Flink;
				pebEntry = *pPebEntry;
				if (pPebEntry != pHeadEntry && pebEntry.DllBase != IntPtr.Zero)
				{
					if(!new ReadOnlySpan<char>(pebEntry.BaseDllName.Buffer, pebEntry.BaseDllName.Length >> 1).Equals(name, StringComparison.InvariantCultureIgnoreCase)) continue;
					return (void*) pebEntry.DllBase;
				}
				break;
			}

			return null;
		}
	}
}
