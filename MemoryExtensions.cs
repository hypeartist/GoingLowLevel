using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GoingLowLevel
{
	internal static unsafe class MemoryExtensions
	{
		public static void* GetDataPointer<T>(this Span<T> span) => Unsafe.AsPointer(ref MemoryMarshal.GetReference(span));
		
		public static void* GetDataPointer<T>(this ReadOnlySpan<T> span) => Unsafe.AsPointer(ref MemoryMarshal.GetReference(span));
	}
}