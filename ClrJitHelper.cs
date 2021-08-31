using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace GoingLowLevel
{
	public static unsafe class ClrJitHelper
	{
		private readonly struct Data
		{
			public readonly ICorJitCompiler* CorJitCompiler;
			public readonly delegate*<ICorJitCompiler*, ICorJitInfo*, CORINFO_METHOD_INFO*, uint, byte**, uint*, CorJitResult> CompileMethodOriginal;

			public Data(delegate*<void*> getJit)
			{
				CorJitCompiler = *(ICorJitCompiler**) getJit();
				CompileMethodOriginal = CorJitCompiler->compileMethod;
			}
		}
		
		private static readonly Data _;
		private static HookState _state = HookState.Disable;
		private static readonly object Lock = new {};
		private static Callbacks _callbacks;

		static ClrJitHelper()
		{
			var clrjit = PebHelper.GetModuleHandle("clrjit.dll");
			var getJit = (delegate*<void*>) InMemoryPe.GetProcAddress(clrjit, "getJit");
			_ = new Data(getJit);
		}

		public static void HookCompilation(in Callbacks callbacks = default)
		{
			if(_state == HookState.Enable) return;
			_callbacks = callbacks;
			var op = 0u;
			PlatformApi.Kernel32.VirtualProtect(_.CorJitCompiler, (nuint) sizeof(void*), 0x04, &op);
			Api.CompileMethod(default, default, default, default, default, default);
			*(nuint*) ((long) _.CorJitCompiler + (long) &_.CorJitCompiler->compileMethod - (long) _.CorJitCompiler) = (nuint) (delegate*<ICorJitCompiler*, ICorJitInfo*, CORINFO_METHOD_INFO*, uint, byte**, uint*, CorJitResult>) (&Api.CompileMethod);
			PlatformApi.Kernel32.VirtualProtect(_.CorJitCompiler, (nuint) sizeof(void*), op, &op);
			_state = HookState.Enable;
		}

		public static void UnHookCompilation()
		{
			if (_state == HookState.Disable) return;
			_callbacks = default;
			var op = 0u;
			PlatformApi.Kernel32.VirtualProtect(_.CorJitCompiler, (nuint)sizeof(void*), 0x04, &op);
			Api.CompileMethod(default, default, default, default, default, default);
			*(nuint*)((long)_.CorJitCompiler + (long)&_.CorJitCompiler->compileMethod - (long)_.CorJitCompiler) = (nuint)_.CompileMethodOriginal;
			PlatformApi.Kernel32.VirtualProtect(_.CorJitCompiler, (nuint)sizeof(void*), op, &op);
			_state = HookState.Disable;
		}

		public struct CallbackParams
		{
			public ICorJitCompiler* Compiler;
			public ICorJitInfo* JitInfo;
			public CORINFO_METHOD_INFO* MethodInfo;
			public uint Flags;
			public byte** NativeEntry;
			public uint* NativeSizeOfCode;
		}

		public struct Callbacks
		{
			public delegate*<ref CallbackParams, void> OnBeforeCompile { get; set; }

			public delegate*<ref CallbackParams, void> OnAfterCompile { get; set; }
		}

		private struct Api
		{
			[ThreadStatic]
			private static volatile int _reenterGuard;

			public static CorJitResult CompileMethod(ICorJitCompiler* pThis, ICorJitInfo* comp, CORINFO_METHOD_INFO* info, uint flags, byte** nativeEntry, uint* nativeSizeOfCode)
			{
				if (pThis == null)
				{
					return CorJitResult.CORJIT_OK;
				}

				Interlocked.Increment(ref _reenterGuard);
				try
				{
					if (_reenterGuard > 1)
					{
						return _.CompileMethodOriginal(pThis, comp, info, flags, nativeEntry, nativeSizeOfCode);
					}

					if (_callbacks.OnBeforeCompile != null)
					{
						var cbParams = new CallbackParams
						{
							Compiler = pThis,
							JitInfo = comp,
							MethodInfo = info,
							Flags = flags,
							NativeEntry = nativeEntry,
							NativeSizeOfCode = nativeSizeOfCode
						};
						_callbacks.OnBeforeCompile(ref cbParams);
					}

					var result = _.CompileMethodOriginal(pThis, comp, info, flags, nativeEntry, nativeSizeOfCode);

					if (_callbacks.OnAfterCompile != null)
					{
						var cbParams = new CallbackParams
						{
							Compiler = pThis,
							JitInfo = comp,
							MethodInfo = info,
							Flags = flags,
							NativeEntry = nativeEntry,
							NativeSizeOfCode = nativeSizeOfCode
						};
						_callbacks.OnAfterCompile(ref cbParams);
					}

					return result;
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
				finally
				{
					Interlocked.Decrement(ref _reenterGuard);
				}
			}
		}

		public enum HookState
		{
			Enable,
			Disable
		}
	}
}