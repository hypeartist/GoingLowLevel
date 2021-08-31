using System;
using System.Runtime.CompilerServices;

namespace GoingLowLevel
{
	public static unsafe class UtilityMethods
	{
		public static void JitMethod<T>(string methodName)
		{
			var methodInfo = typeof(T).GetMethod(methodName);
			if (methodInfo == null)
			{
				return;
			}
			RuntimeHelpers.PrepareMethod(methodInfo.MethodHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan<byte> GetAnsiString(void* pointer)
		{
			var bpointer = (byte*)pointer;
			var start = bpointer;
			while (*bpointer++ != 0)
			{
			}
			return new ReadOnlySpan<byte>(start, (int)(bpointer - start - 1));
		}
	}
}