using System;

namespace GoingLowLevel
{
	public static unsafe class PlatformApi
	{
		[Flags]
		public enum AllocationType : uint
		{
			Commit = 0x1000,
			Reserve = 0x2000,
			Reset = 0x80000,
			LargePages = 0x20000000,
			Physical = 0x400000,
			TopDown = 0x100000,
			WriteWatch = 0x200000,
			Decommit = 0x4000,
			Release = 0x8000
		}

		[Flags]
		public enum MemoryProtection : uint
		{
			Execute = 0x10,
			ExecuteRead = 0x20,
			ExecuteReadWrite = 0x40,
			ExecuteWriteCopy = 0x80,
			NoAccess = 0x01,
			ReadOnly = 0x02,
			ReadWrite = 0x04,
			WriteCopy = 0x08,
			Guard = 0x100,
			NoCache = 0x200,
			WriteCombine = 0x400
		}

		[Flags]
		public enum PageProtection
		{
			NoAccess = 0x01,
			ReadOnly = 0x02,
			ReadWrite = 0x04,
			WriteCopy = 0x08,
			Execute = 0x10,
			ExecuteRead = 0x20,
			ExecuteReadWrite = 0x40,
			ExecuteWriteCopy = 0x80,
			Guard = 0x100,
			NoCache = 0x200,
			WriteCombine = 0x400,
		}
		
		public static class Kernel32
		{
			public static readonly delegate*<void*, void*> LoadLibraryA;
			public static readonly delegate*<void*, void*> LoadLibraryW;
			public static readonly delegate*<void*, nuint, AllocationType, MemoryProtection, void*> VirtualAlloc;
			public static readonly delegate*<void*, nuint, AllocationType, void> VirtualFree;
			public static readonly delegate*<void*, nuint, uint, uint*, bool> VirtualProtect;

			static Kernel32()
			{
				var lib = PebHelper.GetModuleHandle(nameof(Kernel32));

				LoadLibraryA = (delegate*<void*, void*>) InMemoryPe.GetProcAddress(lib, nameof(LoadLibraryA));
				LoadLibraryW = (delegate*<void*, void*>) InMemoryPe.GetProcAddress(lib, nameof(LoadLibraryW));
				VirtualAlloc = (delegate*<void*, nuint, AllocationType, MemoryProtection, void*>) InMemoryPe.GetProcAddress(lib, nameof(VirtualAlloc));
				VirtualFree = (delegate*<void*, nuint, AllocationType, void>) InMemoryPe.GetProcAddress(lib, nameof(VirtualFree));
				VirtualProtect = (delegate*<void*, nuint, uint, uint*, bool>) InMemoryPe.GetProcAddress(lib, nameof(VirtualProtect));
			}
		}
	}
}