using System;
using System.Runtime.CompilerServices;
using System.Text.Unicode;

namespace GoingLowLevel
{
	internal static unsafe class Program
	{
		public static void Main(string[] args)
		{
			ClrJitHelper.HookCompilation(new ClrJitHelper.Callbacks {OnBeforeCompile = &OnBeforeCompile, OnAfterCompile = &OnAfterCompile});
			
			UtilityMethods.JitMethod<Cls>(nameof(Cls.TestMethod));

			ClrJitHelper.UnHookCompilation();

			var res = Cls.TestMethod();
			Console.WriteLine(res);
		}

		private static void OnBeforeCompile(ref ClrJitHelper.CallbackParams cbParams)
		{
			var pMethodName = ((ICorStaticInfo*)*(void**)cbParams.JitInfo)->getMethodName((ICorStaticInfo*)cbParams.JitInfo, cbParams.MethodInfo->ftn, null);
			var methodNameU8 = UtilityMethods.GetAnsiString(pMethodName);
			Span<char> methodNameU16 = stackalloc char[methodNameU8.Length];
			Utf8.ToUtf16(methodNameU8, methodNameU16, out _, out _);
			if (!methodNameU16.SequenceEqual(nameof(Cls.TestMethod))) return;
			
			var ilBytes = new byte[]
			{
				0x1d,	// ldc.i4.7
				0x2a    // ret
			};
			var pilBytes = ilBytes.AsSpan().GetDataPointer();
			cbParams.MethodInfo->ILCode = (byte*)pilBytes;
		}

		private static void OnAfterCompile(ref ClrJitHelper.CallbackParams cbParams)
		{
		}
	}

	public class Cls
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static int TestMethod()
		{
			return 5;
		}
	}
}
