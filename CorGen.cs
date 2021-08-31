using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 649

// ReSharper disable UnassignedReadonlyField
// ReSharper disable InconsistentNaming

namespace GoingLowLevel
{
	public readonly struct _EXCEPTION_POINTERS
	{
	}
	public readonly struct _GUID
	{
		public readonly uint Data1;
		public readonly ushort Data2;
		public readonly ushort Data3;
		public readonly FixedArray8<byte> Data4;
	}
	public readonly struct IMAGE_COR_ILMETHOD_SECT_SMALL
	{
		public readonly byte Kind;
		public readonly byte DataSize;
	}
	public readonly struct IMAGE_COR_ILMETHOD_SECT_FAT
	{
		public readonly uint Kind; //: 8
		public readonly uint DataSize; //: 24
	}
	public readonly struct IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_FAT
	{
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_FAT_bdb5c971b5a44c359c239c81f858b50d
		{
			/// <summary>
			/// Use for type-based exception handlers
			/// </summary>
			[FieldOffset(0)]
			public readonly uint ClassToken;
			/// <summary>
			/// Use for filter-based exception handlers (COR_ILEXCEPTION_FILTER is set)
			/// </summary>
			[FieldOffset(0)]
			public readonly uint FilterOffset;
		}
		public readonly CorExceptionFlag Flags;
		public readonly uint TryOffset;
		/// <summary>
		/// Relative to start of try block
		/// </summary>
		public readonly uint TryLength;
		public readonly uint HandlerOffset;
		/// <summary>
		/// Relative to start of handler
		/// </summary>
		public readonly uint HandlerLength;
	}
	public readonly struct IMAGE_COR_ILMETHOD_SECT_EH_FAT
	{
		public readonly IMAGE_COR_ILMETHOD_SECT_FAT SectFat;
		/// <summary>
		/// Actually variable size
		/// </summary>
		public readonly FixedArray1<IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_FAT> Clauses;
	}
	public readonly struct IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL
	{
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL_e0ed3cbc4b034b86aa734ae24e27385e
		{
			[FieldOffset(0)]
			public readonly uint ClassToken;
			[FieldOffset(0)]
			public readonly uint FilterOffset;
		}
		public readonly CorExceptionFlag Flags; //: 16
		public readonly uint TryOffset; //: 16
		/// <summary>
		/// Relative to start of try block
		/// </summary>
		public readonly uint TryLength; //: 8
		public readonly uint HandlerOffset; //: 16
		/// <summary>
		/// Relative to start of handler
		/// </summary>
		public readonly uint HandlerLength; //: 8
	}
	public readonly struct IMAGE_COR_ILMETHOD_SECT_EH_SMALL
	{
		public readonly IMAGE_COR_ILMETHOD_SECT_SMALL SectSmall;
		public readonly ushort Reserved;
		/// <summary>
		/// Actually variable size
		/// </summary>
		public readonly FixedArray1<IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL> Clauses;
	}
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct IMAGE_COR_ILMETHOD_SECT_EH
	{
		[FieldOffset(0)]
		public readonly IMAGE_COR_ILMETHOD_SECT_EH_SMALL Small;
		[FieldOffset(0)]
		public readonly IMAGE_COR_ILMETHOD_SECT_EH_FAT Fat;
	}
	public readonly struct IMAGE_COR_ILMETHOD_TINY
	{
		public readonly byte Flags_CodeSize;
	}
	public readonly struct IMAGE_COR_ILMETHOD_FAT
	{
		/// <summary>
		/// Flags see code:CorILMethodFlags
		/// </summary>
		public readonly uint Flags; //: 12
		/// <summary>
		/// Size in DWords of this structure (currently 3)
		/// </summary>
		public readonly uint Size; //: 4
		/// <summary>
		/// Maximum number of items (I4, I, I8, obj ...), on the operand stack
		/// </summary>
		public readonly uint MaxStack; //: 16
		/// <summary>
		/// Size of the code
		/// </summary>
		public readonly uint CodeSize;
		/// <summary>
		/// Token that indicates the signature of the local vars (0 means none)
		/// </summary>
		public readonly uint LocalVarSigTok;
	}
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct IMAGE_COR_ILMETHOD
	{
		[FieldOffset(0)]
		public readonly IMAGE_COR_ILMETHOD_TINY Tiny;
		[FieldOffset(0)]
		public readonly IMAGE_COR_ILMETHOD_FAT Fat;
	}
	public readonly struct IMAGE_COR_VTABLEFIXUP
	{
		/// <summary>
		/// Offset of v-table array in image.
		/// </summary>
		public readonly uint RVA;
		/// <summary>
		/// How many entries at location.
		/// </summary>
		public readonly ushort Count;
		/// <summary>
		/// COR_VTABLE_xxx type of entries.
		/// </summary>
		public readonly ushort Type;
	}
	public readonly struct COR_FIELD_OFFSET
	{
		public readonly uint ridOfField;
		public readonly uint ulOffset;
	}
	public unsafe readonly struct COR_SECATTR
	{
		/// <summary>
		/// Ref to constructor of security attribute.
		/// </summary>
		public readonly uint tkCtor;
		/// <summary>
		/// Blob describing ctor args and field/property values.
		/// </summary>
		public readonly void* pCustomAttribute;
		/// <summary>
		/// Length of the above blob.
		/// </summary>
		public readonly uint cbCustomAttribute;
	}
	public readonly struct SYSTEMV_AMD64_CORINFO_STRUCT_REG_PASSING_DESCRIPTOR
	{
		/// <summary>
		/// Whether the struct is passable/passed (this includes struct returning) in registers.
		/// </summary>
		public readonly bool passedInRegisters;
		/// <summary>
		/// Number of eightbytes for this struct.
		/// </summary>
		public readonly byte eightByteCount;
		/// <summary>
		/// The eightbytes type classification.
		/// </summary>
		public readonly FixedArray2<SystemVClassificationType> eightByteClassifications;
		/// <summary>
		/// The size of the eightbytes (an eightbyte could include padding. This represents the no padding size of the eightbyte).
		/// </summary>
		public readonly FixedArray2<byte> eightByteSizes;
		/// <summary>
		/// The start offset of the eightbytes (in bytes).
		/// </summary>
		public readonly FixedArray2<byte> eightByteOffsets;
	}
	public readonly struct CORINFO_InstructionSetFlags
	{
		public readonly ulong _flags;
	}
	public readonly struct PatchpointInfo
	{
	}
	public readonly struct CORINFO_ASSEMBLY_STRUCT_
	{
	}
	public readonly struct CORINFO_MODULE_STRUCT_
	{
	}
	public unsafe readonly struct CORINFO_DEPENDENCY_STRUCT_
	{
		public readonly CORINFO_MODULE_STRUCT_* moduleFrom;
		public readonly CORINFO_MODULE_STRUCT_* moduleTo;
	}
	public readonly struct CORINFO_CLASS_STRUCT_
	{
	}
	public readonly struct CORINFO_METHOD_STRUCT_
	{
	}
	public readonly struct CORINFO_FIELD_STRUCT_
	{
	}
	public readonly struct CORINFO_ARG_LIST_STRUCT_
	{
	}
	public readonly struct CORINFO_JUST_MY_CODE_HANDLE_
	{
	}
	public readonly struct CORINFO_PROFILING_STRUCT_
	{
	}
	public readonly struct CORINFO_GENERIC_STRUCT_
	{
	}
	public readonly struct CORINFO_VarArgInfo
	{
		/// <summary>
		/// Number of bytes the arguments take up.
		/// (The CORINFO_VARARGS_HANDLE counts as an arg)
		/// </summary>
		public readonly uint argBytes;
	}
	public readonly struct CORINFO_CONTEXT_STRUCT_
	{
	}
	public readonly struct MethodSignatureInfo
	{
	}
	public unsafe readonly struct CORINFO_SIG_INST
	{
		public readonly uint classInstCount;
		/// <summary>
		/// (representative, not exact) instantiation for class type variables in signature
		/// </summary>
		public readonly CORINFO_CLASS_STRUCT_** classInst;
		public readonly uint methInstCount;
		/// <summary>
		/// (representative, not exact) instantiation for method type variables in signature
		/// </summary>
		public readonly CORINFO_CLASS_STRUCT_** methInst;
	}
	public unsafe readonly struct CORINFO_SIG_INFO
	{
		public readonly CorInfoCallConv callConv;
		/// <summary>
		/// If the return type is a value class, this is its handle (enums are normalized)
		/// </summary>
		public readonly CORINFO_CLASS_STRUCT_* retTypeClass;
		/// <summary>
		/// Returns the value class as it is in the sig (enums are not converted to primitives)
		/// </summary>
		public readonly CORINFO_CLASS_STRUCT_* retTypeSigClass;
		public readonly CorInfoType retType; //: 8
		/// <summary>
		/// Used by IL stubs code
		/// </summary>
		public readonly uint flags; //: 8
		public readonly uint numArgs; //: 16
		/// <summary>
		/// Information about how type variables are being instantiated in generic code
		/// </summary>
		public readonly CORINFO_SIG_INST sigInst;
		public readonly CORINFO_ARG_LIST_STRUCT_* args;
		public readonly byte* pSig;
		public readonly uint cbSig;
		/// <summary>
		/// Used in place of pSig and cbSig to reference a method signature object handle
		/// </summary>
		public readonly MethodSignatureInfo* methodSignature;
		/// <summary>
		/// Passed to getArgClass
		/// </summary>
		public readonly CORINFO_MODULE_STRUCT_* scope;
		public readonly uint token;
	}
	public unsafe struct CORINFO_METHOD_INFO
	{
		public readonly CORINFO_METHOD_STRUCT_* ftn;
		public readonly CORINFO_MODULE_STRUCT_* scope;
		public byte* ILCode;
		public readonly uint ILCodeSize;
		public readonly uint maxStack;
		public readonly uint EHcount;
		public readonly CorInfoOptions options;
		public readonly CorInfoRegionKind regionKind;
		public readonly CORINFO_SIG_INFO args;
		public readonly CORINFO_SIG_INFO locals;
	}
	public unsafe readonly struct CORINFO_CONST_LOOKUP
	{
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct CORINFO_CONST_LOOKUP_47ebdb238e474813a5881478a4ad5b5f
		{
			[FieldOffset(0)]
			public readonly CORINFO_GENERIC_STRUCT_* handle;
			[FieldOffset(0)]
			public readonly void* addr;
		}
		/// <summary>
		/// If the handle is obtained at compile-time, then this handle is the "exact" handle (class, method, or field)
		/// Otherwise, it's a representative...
		/// If accessType is
		/// IAT_VALUE     --> "handle" stores the real handle or "addr " stores the computed address
		/// IAT_PVALUE    --> "addr" stores a pointer to a location which will hold the real handle
		/// IAT_RELPVALUE --> "addr" stores a relative pointer to a location which will hold the real handle
		/// IAT_PPVALUE   --> "addr" stores a double indirection to a location which will hold the real handle
		/// </summary>
		public readonly InfoAccessType accessType;
	}
	public unsafe readonly struct CORINFO_LOOKUP_KIND
	{
		public readonly bool needsRuntimeLookup;
		public readonly CORINFO_RUNTIME_LOOKUP_KIND runtimeLookupKind;
		/// <summary>
		/// The 'runtimeLookupFlags' and 'runtimeLookupArgs' fields
		/// are just for internal VM / ZAP communication, not to be used by the JIT.
		/// </summary>
		public readonly ushort runtimeLookupFlags;
		public readonly void* runtimeLookupArgs;
	}
	public unsafe readonly struct CORINFO_RUNTIME_LOOKUP
	{
		/// <summary>
		/// This is signature you must pass back to the runtime lookup helper
		/// </summary>
		public readonly void* signature;
		/// <summary>
		/// Here is the helper you must call. It is one of CORINFO_HELP_RUNTIMEHANDLE_* helpers.
		/// </summary>
		public readonly CorInfoHelpFunc helper;
		/// <summary>
		/// Number of indirections to get there
		/// CORINFO_USEHELPER = don't know how to get it, so use helper function at run-time instead
		/// 0 = use the this pointer itself (e.g. token is C<!0> inside code in sealed class C)
		/// or method desc itself (e.g. token is method void M::mymeth<!!0>() inside code in M::mymeth)
		/// Otherwise, follow each byte-offset stored in the "offsets[]" array (may be negative)
		/// </summary>
		public readonly ushort indirections;
		/// <summary>
		/// If set, test for null and branch to helper if null
		/// </summary>
		public readonly bool testForNull;
		/// <summary>
		/// If set, test the lowest bit and dereference if set (see code:FixupPointer)
		/// </summary>
		public readonly bool testForFixup;
		public readonly ushort sizeOffset;
		public readonly FixedArray4<ulong> offsets;
		/// <summary>
		/// If set, first offset is indirect.
		/// 0 means that value stored at first offset (offsets[0]) from pointer is next pointer, to which the next offset
		/// (offsets[1]) is added and so on.
		/// 1 means that value stored at first offset (offsets[0]) from pointer is offset1, and the next pointer is
		/// stored at pointer+offsets[0]+offset1.
		/// </summary>
		public readonly bool indirectFirstOffset;
		/// <summary>
		/// If set, second offset is indirect.
		/// 0 means that value stored at second offset (offsets[1]) from pointer is next pointer, to which the next offset
		/// (offsets[2]) is added and so on.
		/// 1 means that value stored at second offset (offsets[1]) from pointer is offset2, and the next pointer is
		/// stored at pointer+offsets[1]+offset2.
		/// </summary>
		public readonly bool indirectSecondOffset;
	}
	public readonly struct CORINFO_LOOKUP
	{
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct CORINFO_LOOKUP_07c55e644ade4490a900d58854469c2b
		{
			/// <summary>
			/// If kind.needsRuntimeLookup then this indicates how to do the lookup
			/// </summary>
			[FieldOffset(0)]
			public readonly CORINFO_RUNTIME_LOOKUP runtimeLookup;
			/// <summary>
			/// If the handle is obtained at compile-time, then this handle is the "exact" handle (class, method, or field)
			/// Otherwise, it's a representative...  If accessType is
			/// IAT_VALUE --> "handle" stores the real handle or "addr " stores the computed address
			/// IAT_PVALUE --> "addr" stores a pointer to a location which will hold the real handle
			/// IAT_RELPVALUE --> "addr" stores a relative pointer to a location which will hold the real handle
			/// IAT_PPVALUE --> "addr" stores a double indirection to a location which will hold the real handle
			/// </summary>
			[FieldOffset(0)]
			public readonly CORINFO_CONST_LOOKUP constLookup;
		}
		public readonly CORINFO_LOOKUP_KIND lookupKind;
	}
	public unsafe readonly struct CORINFO_GENERICHANDLE_RESULT
	{
		public readonly CORINFO_LOOKUP lookup;
		/// <summary>
		/// CompileTimeHandle is guaranteed to be either NULL or a handle that is usable during compile time.
		/// It must not be embedded in the code because it might not be valid at run-time.
		/// </summary>
		public readonly CORINFO_GENERIC_STRUCT_* compileTimeHandle;
		/// <summary>
		/// Type of the result
		/// </summary>
		public readonly CorInfoGenericHandleType handleType;
	}
	public unsafe readonly struct CORINFO_HELPER_ARG
	{
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct CORINFO_HELPER_ARG_7d9e3032b3584fd9b64fe90b023af5bd
		{
			[FieldOffset(0)]
			public readonly CORINFO_FIELD_STRUCT_* fieldHandle;
			[FieldOffset(0)]
			public readonly CORINFO_METHOD_STRUCT_* methodHandle;
			[FieldOffset(0)]
			public readonly CORINFO_CLASS_STRUCT_* classHandle;
			[FieldOffset(0)]
			public readonly CORINFO_MODULE_STRUCT_* moduleHandle;
			[FieldOffset(0)]
			public readonly ulong constant;
		}
		public readonly CorInfoAccessAllowedHelperArgType argType;
	}
	public readonly struct CORINFO_HELPER_DESC
	{
		public readonly CorInfoHelpFunc helperNum;
		public readonly uint numArgs;
		public readonly FixedArray4<CORINFO_HELPER_ARG> args;
	}
	public unsafe readonly struct CORINFO_RESOLVED_TOKEN
	{
		/// <summary>
		/// Context for resolution of generic arguments
		/// </summary>
		public readonly CORINFO_CONTEXT_STRUCT_* tokenContext;
		public readonly CORINFO_MODULE_STRUCT_* tokenScope;
		/// <summary>
		/// The source token
		/// </summary>
		public readonly uint token;
		public readonly CorInfoTokenKind tokenType;
		/// <summary>
		/// // [Out] arguments of resolveToken.
		/// - Type handle is always non-NULL.
		/// - At most one of method and field handles is non-NULL (according to the token type).
		/// - Method handle is an instantiating stub only for generic methods. Type handle
		/// is required to provide the full context for methods in generic types.
		/// 
		/// </summary>
		public readonly CORINFO_CLASS_STRUCT_* hClass;
		public readonly CORINFO_METHOD_STRUCT_* hMethod;
		public readonly CORINFO_FIELD_STRUCT_* hField;
		/// <summary>
		/// // [Out] TypeSpec and MethodSpec signatures for generics. NULL otherwise.
		/// 
		/// </summary>
		public readonly byte* pTypeSpec;
		public readonly uint cbTypeSpec;
		public readonly byte* pMethodSpec;
		public readonly uint cbMethodSpec;
	}
	public unsafe readonly struct CORINFO_CALL_INFO
	{
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct CORINFO_CALL_INFO_cbfab718b9104bdfae04c72821cbf091
		{
			[FieldOffset(0)]
			public readonly CORINFO_LOOKUP stubLookup;
			[FieldOffset(0)]
			public readonly CORINFO_LOOKUP codePointerLookup;
		}
		/// <summary>
		/// Target method handle
		/// </summary>
		public readonly CORINFO_METHOD_STRUCT_* hMethod;
		/// <summary>
		/// Flags for the target method
		/// </summary>
		public readonly uint methodFlags;
		/// <summary>
		/// Flags for CORINFO_RESOLVED_TOKEN::hClass
		/// </summary>
		public readonly uint classFlags;
		public readonly CORINFO_SIG_INFO sig;
		/// <summary>
		/// Flags for CORINFO_RESOLVED_TOKEN::hMethod
		/// </summary>
		public readonly uint verMethodFlags;
		public readonly CORINFO_SIG_INFO verSig;
		/// <summary>
		/// If set to:
		/// - CORINFO_ACCESS_ALLOWED - The access is allowed.
		/// - CORINFO_ACCESS_ILLEGAL - This access cannot be allowed (i.e. it is public calling private).  The
		/// JIT may either insert the callsiteCalloutHelper into the code (as per a verification error) or
		/// call throwExceptionFromHelper on the callsiteCalloutHelper.  In this case callsiteCalloutHelper
		/// is guaranteed not to return.
		/// </summary>
		public readonly CorInfoIsAccessAllowedResult accessAllowed;
		public readonly CORINFO_HELPER_DESC callsiteCalloutHelper;
		/// <summary>
		/// See above section on constraintCalls to understand when these are set to unusual values.
		/// </summary>
		public readonly CORINFO_THIS_TRANSFORM thisTransform;
		public readonly CORINFO_CALL_KIND kind;
		public readonly bool nullInstanceCheck;
		/// <summary>
		/// Context for inlining and hidden arg
		/// </summary>
		public readonly CORINFO_CONTEXT_STRUCT_* contextHandle;
		/// <summary>
		/// Set if contextHandle is approx handle. Runtime lookup is required to get the exact handle.
		/// </summary>
		public readonly bool exactContextNeedsRuntimeLookup;
		/// <summary>
		/// Used by Ready-to-Run
		/// </summary>
		public readonly CORINFO_CONST_LOOKUP instParamLookup;
		public readonly bool wrapperDelegateInvoke;
	}
	public unsafe readonly struct CORINFO_DEVIRTUALIZATION_INFO
	{
		/// <summary>
		/// // [In] arguments of resolveVirtualMethod
		/// 
		/// </summary>
		public readonly CORINFO_METHOD_STRUCT_* virtualMethod;
		public readonly CORINFO_CLASS_STRUCT_* objClass;
		public readonly CORINFO_CONTEXT_STRUCT_* context;
		/// <summary>
		/// // [Out] results of resolveVirtualMethod.
		/// - devirtualizedMethod is set to MethodDesc of devirt'ed method iff we were able to devirtualize.
		/// invariant is `resolveVirtualMethod(...) == (devirtualizedMethod != nullptr)`.
		/// - requiresInstMethodTableArg is set to TRUE if the devirtualized method requires a type handle arg.
		/// - exactContext is set to wrapped CORINFO_CLASS_HANDLE of devirt'ed method table.
		/// - details on the computation done by the jit host
		/// 
		/// </summary>
		public readonly CORINFO_METHOD_STRUCT_* devirtualizedMethod;
		public readonly bool requiresInstMethodTableArg;
		public readonly CORINFO_CONTEXT_STRUCT_* exactContext;
		public readonly CORINFO_DEVIRTUALIZATION_DETAIL detail;
	}
	public unsafe readonly struct CORINFO_FIELD_INFO
	{
		public readonly CORINFO_FIELD_ACCESSOR fieldAccessor;
		public readonly uint fieldFlags;
		/// <summary>
		/// Helper to use if the field access requires it
		/// </summary>
		public readonly CorInfoHelpFunc helper;
		/// <summary>
		/// Field offset if there is one
		/// </summary>
		public readonly uint offset;
		public readonly CorInfoType fieldType;
		/// <summary>
		/// Possibly null
		/// </summary>
		public readonly CORINFO_CLASS_STRUCT_* structType;
		/// <summary>
		/// See CORINFO_CALL_INFO.accessAllowed
		/// </summary>
		public readonly CorInfoIsAccessAllowedResult accessAllowed;
		public readonly CORINFO_HELPER_DESC accessCalloutHelper;
		/// <summary>
		/// Used by Ready-to-Run
		/// </summary>
		public readonly CORINFO_CONST_LOOKUP fieldLookup;
	}
	public readonly struct CORINFO_EH_CLAUSE
	{
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct CORINFO_EH_CLAUSE_1747c10900fc4631983d80441464a277
		{
			/// <summary>
			/// Use for type-based exception handlers
			/// </summary>
			[FieldOffset(0)]
			public readonly uint ClassToken;
			/// <summary>
			/// Use for filter-based exception handlers (COR_ILEXCEPTION_FILTER is set)
			/// </summary>
			[FieldOffset(0)]
			public readonly uint FilterOffset;
		}
		public readonly CORINFO_EH_CLAUSE_FLAGS Flags;
		public readonly uint TryOffset;
		public readonly uint TryLength;
		public readonly uint HandlerOffset;
		public readonly uint HandlerLength;
	}
	public readonly struct CORINFO_CPU
	{
		public readonly uint dwCPUType;
		public readonly uint dwFeatures;
		public readonly uint dwExtendedFeatures;
	}
	public readonly struct CORINFO_EE_INFO
	{
		public readonly struct InlinedCallFrameInfo
		{
			/// <summary>
			/// Size of the Frame structure
			/// </summary>
			public readonly uint size;
			public readonly uint offsetOfGSCookie;
			public readonly uint offsetOfFrameVptr;
			public readonly uint offsetOfFrameLink;
			public readonly uint offsetOfCallSiteSP;
			public readonly uint offsetOfCalleeSavedFP;
			public readonly uint offsetOfCallTarget;
			public readonly uint offsetOfReturnAddress;
			/// <summary>
			/// This offset is used only for ARM
			/// </summary>
			public readonly uint offsetOfSPAfterProlog;
		}
		public readonly InlinedCallFrameInfo inlinedCallFrameInfo;
		/// <summary>
		/// Offset of the current Frame
		/// </summary>
		public readonly uint offsetOfThreadFrame;
		/// <summary>
		/// Offset of the preemptive/cooperative state of the Thread
		/// </summary>
		public readonly uint offsetOfGCState;
		/// <summary>
		/// Delegate offsets
		/// </summary>
		public readonly uint offsetOfDelegateInstance;
		public readonly uint offsetOfDelegateFirstTarget;
		/// <summary>
		/// Wrapper delegate offsets
		/// </summary>
		public readonly uint offsetOfWrapperDelegateIndirectCell;
		/// <summary>
		/// Reverse PInvoke offsets
		/// </summary>
		public readonly uint sizeOfReversePInvokeFrame;
		/// <summary>
		/// OS Page size
		/// </summary>
		public readonly ulong osPageSize;
		/// <summary>
		/// Null object offset
		/// </summary>
		public readonly ulong maxUncheckedOffsetForNullObject;
		/// <summary>
		/// Target ABI. Combined with target architecture and OS to determine
		/// GC, EH, and unwind styles.
		/// </summary>
		public readonly CORINFO_RUNTIME_ABI targetAbi;
		public readonly CORINFO_OS osType;
	}
	public unsafe readonly struct CORINFO_TAILCALL_HELPERS
	{
		public readonly CORINFO_TAILCALL_HELPERS_FLAGS flags;
		public readonly CORINFO_METHOD_STRUCT_* hStoreArgs;
		public readonly CORINFO_METHOD_STRUCT_* hCallTarget;
		public readonly CORINFO_METHOD_STRUCT_* hDispatcher;
	}
	public unsafe readonly struct CORINFO_Object
	{
		/// <summary>
		/// The vtable for the object
		/// </summary>
		public readonly void** methTable;
	}
	public readonly struct CORINFO_String
	{
		private readonly CORINFO_Object _base1;
		public readonly uint stringLen;
		/// <summary>
		/// Actually of variable size
		/// </summary>
		public readonly FixedArray1<ushort> chars;
		public static explicit operator CORINFO_Object(CORINFO_String _) => _._base1;
	}
	public readonly struct CORINFO_Array
	{
		private readonly CORINFO_Object _base1;
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct CORINFO_Array_f66a8811368849d6ae7a4a3c6eed64cf
		{
			/// <summary>
			/// Actually of variable size
			/// </summary>
			[FieldOffset(0)]
			public readonly FixedArray1<sbyte> i1Elems;
			[FieldOffset(0)]
			public readonly FixedArray1<byte> u1Elems;
			[FieldOffset(0)]
			public readonly FixedArray1<short> i2Elems;
			[FieldOffset(0)]
			public readonly FixedArray1<ushort> u2Elems;
			[FieldOffset(0)]
			public readonly FixedArray1<int> i4Elems;
			[FieldOffset(0)]
			public readonly FixedArray1<uint> u4Elems;
			[FieldOffset(0)]
			public readonly FixedArray1<float> r4Elems;
		}
		public readonly uint length;
		public static explicit operator CORINFO_Object(CORINFO_Array _) => _._base1;
	}
	public readonly struct CORINFO_Array8
	{
		private readonly CORINFO_Object _base1;
		[StructLayout(LayoutKind.Explicit)]
		public readonly struct CORINFO_Array8_15199f96ee2b4d34adad48279bcccc22
		{
			[FieldOffset(0)]
			public readonly FixedArray1<double> r8Elems;
			[FieldOffset(0)]
			public readonly FixedArray1<long> i8Elems;
			[FieldOffset(0)]
			public readonly FixedArray1<ulong> u8Elems;
		}
		public readonly uint length;
		public static explicit operator CORINFO_Object(CORINFO_Array8 _) => _._base1;
	}
	public readonly struct CORINFO_RefArray
	{
		private readonly CORINFO_Object _base1;
		public readonly uint length;
		/// <summary>
		/// Actually of variable size;
		/// </summary>
		public readonly FixedArray1<Ptr<CORINFO_Object>> refElems;
		public static explicit operator CORINFO_Object(CORINFO_RefArray _) => _._base1;
	}
	public unsafe readonly struct CORINFO_RefAny
	{
		public readonly void* dataPtr;
		public readonly CORINFO_CLASS_STRUCT_* type;
	}
	public unsafe readonly struct DelegateCtorArgs
	{
		public readonly void* pMethod;
		public readonly void* pArg3;
		public readonly void* pArg4;
		public readonly void* pArg5;
	}
	public unsafe readonly struct ICorDebugInfo
	{
		public readonly struct OffsetMapping
		{
			public readonly uint nativeOffset;
			public readonly uint ilOffset;
			/// <summary>
			/// The debugger needs this so that
			/// we don't put Edit and Continue breakpoints where
			/// the stack isn't empty.  We can put regular breakpoints
			/// there, though, so we need a way to discriminate
			/// between offsets.
			/// </summary>
			public readonly SourceTypes source;
		}
		public readonly struct vlReg
		{
			public readonly RegNum vlrReg;
		}
		public readonly struct vlStk
		{
			public readonly RegNum vlsBaseReg;
			public readonly int vlsOffset;
		}
		public readonly struct vlRegReg
		{
			public readonly RegNum vlrrReg1;
			public readonly RegNum vlrrReg2;
		}
		public readonly struct vlRegStk
		{
			public readonly struct vlRegStk_ce1a2a33fa3d44598c0d36be8f300507
			{
				public readonly RegNum vlrssBaseReg;
				public readonly int vlrssOffset;
			}
			public readonly RegNum vlrsReg;
			public readonly vlRegStk_ce1a2a33fa3d44598c0d36be8f300507 vlrsStk;
		}
		public readonly struct vlStkReg
		{
			public readonly struct vlStkReg_695928c409a042adbafc847e991dfe43
			{
				public readonly RegNum vlsrsBaseReg;
				public readonly int vlsrsOffset;
			}
			public readonly vlStkReg_695928c409a042adbafc847e991dfe43 vlsrStk;
			public readonly RegNum vlsrReg;
		}
		public readonly struct vlStk2
		{
			public readonly RegNum vls2BaseReg;
			public readonly int vls2Offset;
		}
		public readonly struct vlFPstk
		{
			public readonly uint vlfReg;
		}
		public readonly struct vlFixedVarArg
		{
			public readonly uint vlfvOffset;
		}
		public readonly struct vlMemory
		{
			/// <summary>
			/// Pointer to the in-process
			/// </summary>
			public readonly void* rpValue;
		}
		public readonly struct VarLoc
		{
			[StructLayout(LayoutKind.Explicit)]
			public readonly struct VarLoc_b302a2843a9943e780f4627fc3d75fa9
			{
				[FieldOffset(0)]
				public readonly vlReg vlReg;
				[FieldOffset(0)]
				public readonly vlStk vlStk;
				[FieldOffset(0)]
				public readonly vlRegReg vlRegReg;
				[FieldOffset(0)]
				public readonly vlRegStk vlRegStk;
				[FieldOffset(0)]
				public readonly vlStkReg vlStkReg;
				[FieldOffset(0)]
				public readonly vlStk2 vlStk2;
				[FieldOffset(0)]
				public readonly vlFPstk vlFPstk;
				[FieldOffset(0)]
				public readonly vlFixedVarArg vlFixedVarArg;
				[FieldOffset(0)]
				public readonly vlMemory vlMemory;
			}
			public readonly VarLocType vlType;
		}
		public readonly struct ILVarInfo
		{
			public readonly uint startOffset;
			public readonly uint endOffset;
			public readonly uint varNumber;
		}
		public readonly struct NativeVarInfo
		{
			public readonly uint startOffset;
			public readonly uint endOffset;
			public readonly uint varNumber;
			public readonly VarLoc loc;
		}
		public enum MappingTypes
		{
			NO_MAPPING = -1,
			PROLOG = -2,
			EPILOG = -3,
			/// <summary>
			/// Sentinal value. This should be set to the largest magnitude value in the enum
			/// so that the compression routines know the enum's range.
			/// </summary>
			MAX_MAPPING_VALUE = -3
		}
		public enum BoundaryTypes
		{
			/// <summary>
			/// No implicit boundaries
			/// </summary>
			NO_BOUNDARIES = 0,
			/// <summary>
			/// Boundary whenever the IL evaluation stack is empty
			/// </summary>
			STACK_EMPTY_BOUNDARIES = 1,
			/// <summary>
			/// Before every CEE_NOP instruction
			/// </summary>
			NOP_BOUNDARIES = 2,
			/// <summary>
			/// Before every CEE_CALL, CEE_CALLVIRT, etc instruction
			/// </summary>
			CALL_SITE_BOUNDARIES = 4,
			/// <summary>
			/// Set of boundaries that debugger should always reasonably ask the JIT for.
			/// </summary>
			DEFAULT_BOUNDARIES = 7
		}
		public enum SourceTypes
		{
			/// <summary>
			/// To indicate that nothing else applies
			/// </summary>
			SOURCE_TYPE_INVALID = 0,
			/// <summary>
			/// The debugger asked for it.
			/// </summary>
			SEQUENCE_POINT = 1,
			/// <summary>
			/// The stack is empty here
			/// </summary>
			STACK_EMPTY = 2,
			/// <summary>
			/// This is a call site.
			/// </summary>
			CALL_SITE = 4,
			/// <summary>
			/// Indicates a epilog endpoint
			/// </summary>
			NATIVE_END_OFFSET_UNKNOWN = 8,
			/// <summary>
			/// The actual instruction of a call.
			/// </summary>
			CALL_INSTRUCTION = 16
		}
		public enum RegNum
		{
			REGNUM_RAX = 0,
			REGNUM_RCX = 1,
			REGNUM_RDX = 2,
			REGNUM_RBX = 3,
			REGNUM_RSP = 4,
			REGNUM_RBP = 5,
			REGNUM_RSI = 6,
			REGNUM_RDI = 7,
			REGNUM_R8 = 8,
			REGNUM_R9 = 9,
			REGNUM_R10 = 10,
			REGNUM_R11 = 11,
			REGNUM_R12 = 12,
			REGNUM_R13 = 13,
			REGNUM_R14 = 14,
			REGNUM_R15 = 15,
			REGNUM_COUNT = 16,
			/// <summary>
			/// Ambient SP support. Ambient SP is the original SP in the non-BP based frame.
			/// Ambient SP should not change even if there are push/pop operations in the method.
			/// </summary>
			REGNUM_AMBIENT_SP = 17,
			REGNUM_SP = 4
		}
		public enum VarLocType
		{
			/// <summary>
			/// Variable is in a register
			/// </summary>
			VLT_REG = 0,
			/// <summary>
			/// Address of the variable is in a register
			/// </summary>
			VLT_REG_BYREF = 1,
			/// <summary>
			/// Variable is in an fp register
			/// </summary>
			VLT_REG_FP = 2,
			/// <summary>
			/// Variable is on the stack (memory addressed relative to the frame-pointer)
			/// </summary>
			VLT_STK = 3,
			/// <summary>
			/// Address of the variable is on the stack (memory addressed relative to the frame-pointer)
			/// </summary>
			VLT_STK_BYREF = 4,
			/// <summary>
			/// Variable lives in two registers
			/// </summary>
			VLT_REG_REG = 5,
			/// <summary>
			/// Variable lives partly in a register and partly on the stack
			/// </summary>
			VLT_REG_STK = 6,
			/// <summary>
			/// Reverse of VLT_REG_STK
			/// </summary>
			VLT_STK_REG = 7,
			/// <summary>
			/// Variable lives in two slots on the stack
			/// </summary>
			VLT_STK2 = 8,
			/// <summary>
			/// Variable lives on the floating-point stack
			/// </summary>
			VLT_FPSTK = 9,
			/// <summary>
			/// Variable is a fixed argument in a varargs function (relative to VARARGS_HANDLE)
			/// </summary>
			VLT_FIXED_VA = 10,
			VLT_COUNT = 11,
			VLT_INVALID = 12
		}
		public enum ICorDebugInfo_4d20772b4fb5469c9098f5d9242e7020
		{
			/// <summary>
			/// Value for the CORINFO_VARARGS_HANDLE varNumber
			/// </summary>
			VARARGS_HND_ILNUM = -1,
			/// <summary>
			/// Pointer to the return-buffer
			/// </summary>
			RETBUF_ILNUM = -2,
			/// <summary>
			/// ParamTypeArg for CORINFO_GENERICS_CTXT_FROM_PARAMTYPEARG
			/// </summary>
			TYPECTXT_ILNUM = -3,
			/// <summary>
			/// Unknown variable
			/// </summary>
			UNKNOWN_ILNUM = -4,
			/// <summary>
			/// Sentinal value. This should be set to the largest magnitude value in th enum
			/// so that the compression routines know the enum's range.
			/// </summary>
			MAX_ILNUM = -4
		}
	}
	public unsafe readonly struct ICorStaticInfo
	{
		/// <summary>
		/// Quick check whether the method is a jit intrinsic. Returns the same value as getMethodAttribs(ftn) & CORINFO_FLG_JIT_INTRINSIC, except faster.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, bool> isJitIntrinsic;
		/// <summary>
		/// Return flags (a bitfield of CorInfoFlags values)
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint> getMethodAttribs;
		/// <summary>
		/// Sets private JIT flags, which can be, retrieved using getAttrib.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CorInfoMethodRuntimeFlags, void> setMethodAttribs;
		/// <summary>
		/// Given a method descriptor ftnHnd, extract signature information into sigInfo
		/// 
		/// 'memberParent' is typically only set when verifying.  It should be the
		/// result of calling getMemberParent.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_SIG_INFO*, CORINFO_CLASS_STRUCT_*, void> getMethodSig;
		/// <summary>
		/// Return information about a method private to the implementation
		/// returns false if method is not IL, or is otherwise unavailable.
		/// This method is used to fetch data needed to inline functions
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_METHOD_INFO*, bool> getMethodInfo;
		/// <summary>
		/// Decides if you have any limitations for inlining. If everything's OK, it will return
		/// INLINE_PASS and will fill out pRestrictions with a mask of restrictions the caller of this
		/// function must respect. If caller passes pRestrictions = NULL, if there are any restrictions
		/// INLINE_FAIL will be returned
		/// 
		/// The callerHnd must be the immediate caller (i.e. when we have a chain of inlined calls)
		/// 
		/// The inlined method need not be verified
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_METHOD_STRUCT_*, uint*, CorInfoInline> canInline;
		/// <summary>
		/// Reports whether or not a method can be inlined, and why.  canInline is responsible for reporting all
		/// inlining results when it returns INLINE_FAIL and INLINE_NEVER.  All other results are reported by the
		/// JIT.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_METHOD_STRUCT_*, CorInfoInline, sbyte*, void> reportInliningDecision;
		/// <summary>
		/// Returns false if the call is across security boundaries thus we cannot tailcall
		/// 
		/// The callerHnd must be the immediate caller (i.e. when we have a chain of inlined calls)
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_METHOD_STRUCT_*, CORINFO_METHOD_STRUCT_*, bool, bool> canTailCall;
		/// <summary>
		/// Reports whether or not a method can be tail called, and why.
		/// canTailCall is responsible for reporting all results when it returns
		/// false.  All other results are reported by the JIT.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_METHOD_STRUCT_*, bool, CorInfoTailCall, sbyte*, void> reportTailCallDecision;
		/// <summary>
		/// Get individual exception handler
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint, CORINFO_EH_CLAUSE*, void> getEHinfo;
		/// <summary>
		/// Return class it belongs to
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_CLASS_STRUCT_*> getMethodClass;
		/// <summary>
		/// Return module it belongs to
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_MODULE_STRUCT_*> getMethodModule;
		/// <summary>
		/// This function returns the offset of the specified method in the
		/// vtable of it's owning class or interface.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint*, uint*, bool*, void> getMethodVTableOffset;
		/// <summary>
		/// Finds the virtual method in info->objClass that overrides info->virtualMethod,
		/// or the method in info->objClass that implements the interface method
		/// represented by info->virtualMethod.
		/// 
		/// Returns false if devirtualization is not possible.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_DEVIRTUALIZATION_INFO*, bool> resolveVirtualMethod;
		/// <summary>
		/// Get the unboxed entry point for a method, if possible.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, bool*, CORINFO_METHOD_STRUCT_*> getUnboxedEntry;
		/// <summary>
		/// Given T, return the type of the default Comparer<T>.
		/// Returns null if the type can't be determined exactly.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*> getDefaultComparerClass;
		/// <summary>
		/// Given T, return the type of the default EqualityComparer`T.
		/// Returns null if the type can't be determined exactly.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*> getDefaultEqualityComparerClass;
		/// <summary>
		/// Given resolved token that corresponds to an intrinsic classified as
		/// a CORINFO_INTRINSIC_GetRawHandle intrinsic, fetch the handle associated
		/// with the token. If this is not possible at compile-time (because the current method's
		/// code is shared and the token contains generic parameters) then indicate
		/// how the handle should be looked up at runtime.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_GENERICHANDLE_RESULT*, void> expandRawHandleIntrinsic;
		/// <summary>
		/// If a method's attributes have (getMethodAttribs) CORINFO_FLG_INTRINSIC set,
		/// getIntrinsicID() returns the intrinsic ID.
		/// *pMustExpand tells whether or not JIT must expand the intrinsic.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, bool*, CorInfoIntrinsics> getIntrinsicID;
		/// <summary>
		/// Is the given type in System.Private.Corelib and marked with IntrinsicAttribute?
		/// This defaults to false.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, bool> isIntrinsicType;
		/// <summary>
		/// Return the entry point calling convention for any of the following
		/// - a P/Invoke
		/// - a method marked with UnmanagedCallersOnly
		/// - a function pointer with the CORINFO_CALLCONV_UNMANAGED calling convention.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_SIG_INFO*, bool*, CorInfoCallConvExtension> getUnmanagedCallConv;
		/// <summary>
		/// Return if any marshaling is required for PInvoke methods.  Note that
		/// method == 0 => calli.  The call site sig is only needed for the varargs or calli case
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_SIG_INFO*, bool> pInvokeMarshalingRequired;
		/// <summary>
		/// Check constraints on method type arguments (only).
		/// The parent class should be checked separately using satisfiesClassConstraints(parent).
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_METHOD_STRUCT_*, bool> satisfiesMethodConstraints;
		/// <summary>
		/// Given a delegate target class, a target method parent class,  a  target method,
		/// a delegate class, check if the method signature is compatible with the Invoke method of the delegate
		/// (under the typical instantiation of any free type variables in the memberref signatures).
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*, CORINFO_METHOD_STRUCT_*, CORINFO_CLASS_STRUCT_*, bool*, bool> isCompatibleDelegate;
		/// <summary>
		/// Load and restore the method
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, void> methodMustBeLoadedBeforeCodeIsRun;
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_METHOD_STRUCT_*> mapMethodDeclToMethodImpl;
		/// <summary>
		/// Returns the global cookie for the /GS unsafe buffer checks
		/// The cookie might be a constant value (JIT), or a handle to memory location (Ngen)
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, ulong*, ulong**, void> getGSCookie;
		/// <summary>
		/// Provide patchpoint info for the method currently being jitted.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, PatchpointInfo*, void> setPatchpointInfo;
		/// <summary>
		/// Get patchpoint info and il offset for the method currently being jitted.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, uint*, PatchpointInfo*> getOSRInfo;
		/// <summary>
		/// Resolve metadata token into runtime method handles. This function may not
		/// return normally (e.g. it may throw) if it encounters invalid metadata or other
		/// failures during token resolution.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, void> resolveToken;
		/// <summary>
		/// Attempt to resolve a metadata token into a runtime method handle. Returns true
		/// if resolution succeeded and false otherwise (e.g. if it encounters invalid metadata
		/// during token reoslution). This method should be used instead of `resolveToken` in
		/// situations that need to be resilient to invalid metadata.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, bool> tryResolveToken;
		/// <summary>
		/// Signature information about the call sig
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_MODULE_STRUCT_*, uint, CORINFO_CONTEXT_STRUCT_*, CORINFO_SIG_INFO*, void> findSig;
		/// <summary>
		/// For Varargs, the signature at the call site may differ from
		/// the signature at the definition.  Thus we need a way of
		/// fetching the call site information
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_MODULE_STRUCT_*, uint, CORINFO_CONTEXT_STRUCT_*, CORINFO_SIG_INFO*, void> findCallSiteSig;
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_CLASS_STRUCT_*> getTokenTypeAsHandle;
		/// <summary>
		/// Checks if the given metadata token is valid
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_MODULE_STRUCT_*, uint, bool> isValidToken;
		/// <summary>
		/// Checks if the given metadata token is valid StringRef
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_MODULE_STRUCT_*, uint, bool> isValidStringRef;
		/// <summary>
		/// Returns string length and content (can be null for dynamic context)
		/// for given metaTOK and module, length `-1` means input is incorrect
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_MODULE_STRUCT_*, uint, int*, ushort*> getStringLiteral;
		/// <summary>
		/// If the value class 'cls' is isomorphic to a primitive type it will
		/// return that type, otherwise it will return CORINFO_TYPE_VALUECLASS
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoType> asCorInfoType;
		/// <summary>
		/// For completeness
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, sbyte*> getClassName;
		/// <summary>
		/// Return class name as in metadata, or nullptr if there is none.
		/// Suitable for non-debugging use.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, sbyte**, sbyte*> getClassNameFromMetadata;
		/// <summary>
		/// Return the type argument of the instantiated generic class,
		/// which is specified by the index
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, uint, CORINFO_CLASS_STRUCT_*> getTypeInstantiationArgument;
		/// <summary>
		/// Append a (possibly truncated) representation of the type cls to the preallocated buffer ppBuf of length pnBufLen
		/// If fNamespace=TRUE, include the namespace/enclosing classes
		/// If fFullInst=TRUE (regardless of fNamespace and fAssembly), include namespace and assembly for any type parameters
		/// If fAssembly=TRUE, suffix with a comma and the full assembly qualification
		/// return size of representation
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, ushort**, int*, CORINFO_CLASS_STRUCT_*, bool, bool, bool, int> appendClassName;
		/// <summary>
		/// Quick check whether the type is a value class. Returns the same value as getClassAttribs(cls) & CORINFO_FLG_VALUECLASS, except faster.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, bool> isValueClass;
		/// <summary>
		/// Decides how the JIT should do the optimization to inline the check for
		/// GetTypeFromHandle(handle) == obj.GetType() (for CORINFO_INLINE_TYPECHECK_SOURCE_VTABLE)
		/// GetTypeFromHandle(X) == GetTypeFromHandle(Y) (for CORINFO_INLINE_TYPECHECK_SOURCE_TOKEN)
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoInlineTypeCheckSource, CorInfoInlineTypeCheck> canInlineTypeCheck;
		/// <summary>
		/// Return flags (a bitfield of CorInfoFlags values)
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, uint> getClassAttribs;
		/// <summary>
		/// Returns "TRUE" iff "cls" is a struct type such that return buffers used for returning a value
		/// of this type must be stack-allocated.  This will generally be true only if the struct
		/// contains GC pointers, and does not exceed some size limit.  Maintaining this as an invariant allows
		/// an optimization: the JIT may assume that return buffer pointers for return types for which this predicate
		/// returns TRUE are always stack allocated, and thus, that stores to the GC-pointer fields of such return
		/// buffers do not require GC write barriers.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, bool> isStructRequiringStackAllocRetBuf;
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_MODULE_STRUCT_*> getClassModule;
		/// <summary>
		/// Returns the assembly that contains the module "mod".
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_MODULE_STRUCT_*, CORINFO_ASSEMBLY_STRUCT_*> getModuleAssembly;
		/// <summary>
		/// Returns the name of the assembly "assem".
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_ASSEMBLY_STRUCT_*, sbyte*> getAssemblyName;
		/// <summary>
		/// Allocate and delete process-lifetime objects.  Should only be
		/// referred to from static fields, lest a leak occur.
		/// Note that "LongLifetimeFree" does not execute destructors, if "obj"
		/// is an array of a struct type with a destructor.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, ulong, void*> LongLifetimeMalloc;
		public readonly delegate*<ICorStaticInfo*, void*, void> LongLifetimeFree;
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_MODULE_STRUCT_**, void**, ulong> getClassModuleIdForStatics;
		/// <summary>
		/// Return the number of bytes needed by an instance of the class
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, uint> getClassSize;
		/// <summary>
		/// Return the number of bytes needed by an instance of the class allocated on the heap
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, uint> getHeapClassSize;
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, bool> canAllocateOnStack;
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, bool, uint> getClassAlignmentRequirement;
		/// <summary>
		/// This is only called for Value classes.  It returns a boolean array
		/// in representing of 'cls' from a GC perspective.  The class is
		/// assumed to be an array of machine words
		/// (of length // getClassSize(cls) / TARGET_POINTER_SIZE),
		/// 'gcPtrs' is a pointer to an array of uint8_ts of this length.
		/// getClassGClayout fills in this array so that gcPtrs[i] is set
		/// to one of the CorInfoGCType values which is the GC type of
		/// the i-th machine word of an object of type 'cls'
		/// returns the number of GC pointers in the array
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, byte*, uint> getClassGClayout;
		/// <summary>
		/// Returns the number of instance fields in a class
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, uint> getClassNumInstanceFields;
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, int, CORINFO_FIELD_STRUCT_*> getFieldInClass;
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, sbyte*, bool, bool> checkMethodModifier;
		/// <summary>
		/// Returns the "NEW" helper optimized for "newCls."
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_METHOD_STRUCT_*, bool*, CorInfoHelpFunc> getNewHelper;
		/// <summary>
		/// Returns the newArr (1-Dim array) helper optimized for "arrayCls."
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoHelpFunc> getNewArrHelper;
		/// <summary>
		/// Returns the optimized "IsInstanceOf" or "ChkCast" helper
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, bool, CorInfoHelpFunc> getCastingHelper;
		/// <summary>
		/// Returns helper to trigger static constructor
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoHelpFunc> getSharedCCtorHelper;
		/// <summary>
		/// This is not pretty.  Boxing nullable<T> actually returns
		/// a boxed<T> not a boxed Nullable<T>.  This call allows the verifier
		/// to call back to the EE on the 'box' instruction and get the transformed
		/// type to use for verification.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*> getTypeForBox;
		/// <summary>
		/// Returns the correct box helper for a particular class.  Note
		/// that if this returns CORINFO_HELP_BOX, the JIT can assume
		/// 'standard' boxing (allocate object and copy), and optimize
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoHelpFunc> getBoxHelper;
		/// <summary>
		/// Returns the unbox helper.  If 'helperCopies' points to a true
		/// value it means the JIT is requesting a helper that unboxes the
		/// value into a particular location and thus has the signature
		/// void unboxHelper(void* dest, CORINFO_CLASS_HANDLE cls, Object* obj)
		/// Otherwise (it is null or points at a FALSE value) it is requesting
		/// a helper that returns a pointer to the unboxed data
		/// void* unboxHelper(CORINFO_CLASS_HANDLE cls, Object* obj)
		/// The EE has the option of NOT returning the copy style helper
		/// (But must be able to always honor the non-copy style helper)
		/// The EE set 'helperCopies' on return to indicate what kind of
		/// helper has been created.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoHelpFunc> getUnBoxHelper;
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_LOOKUP_KIND*, CorInfoHelpFunc, CORINFO_CONST_LOOKUP*, bool> getReadyToRunHelper;
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_CLASS_STRUCT_*, CORINFO_LOOKUP*, void> getReadyToRunDelegateCtorHelper;
		public readonly delegate*<ICorStaticInfo*, CorInfoHelpFunc, sbyte*> getHelperName;
		/// <summary>
		/// This function tries to initialize the class (run the class constructor).
		/// this function returns whether the JIT must insert helper calls before
		/// accessing static field or method.
		/// 
		/// See code:ICorClassInfo#ClassConstruction.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_FIELD_STRUCT_*, CORINFO_METHOD_STRUCT_*, CORINFO_CONTEXT_STRUCT_*, CorInfoInitClassResult> initClass;
		/// <summary>
		/// This used to be called "loadClass".  This records the fact
		/// that the class must be loaded (including restored if necessary) before we execute the
		/// code that we are currently generating.  When jitting code
		/// the function loads the class immediately.  When zapping code
		/// the zapper will if necessary use the call to record the fact that we have
		/// to do a fixup/restore before running the method currently being generated.
		/// 
		/// This is typically used to ensure value types are loaded before zapped
		/// code that manipulates them is executed, so that the GC can access information
		/// about those value types.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, void> classMustBeLoadedBeforeCodeIsRun;
		/// <summary>
		/// Returns the class handle for the special builtin classes
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CorInfoClassId, CORINFO_CLASS_STRUCT_*> getBuiltinClass;
		/// <summary>
		/// "System.Int32" ==> CORINFO_TYPE_INT..
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoType> getTypeForPrimitiveValueClass;
		/// <summary>
		/// "System.Int32" ==> CORINFO_TYPE_INT..
		/// "System.UInt32" ==> CORINFO_TYPE_UINT..
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoType> getTypeForPrimitiveNumericClass;
		/// <summary>
		/// TRUE if child is a subtype of parent
		/// if parent is an interface, then does child implement / extend parent
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*, bool> canCast;
		/// <summary>
		/// TRUE if cls1 and cls2 are considered equivalent types.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*, bool> areTypesEquivalent;
		/// <summary>
		/// See if a cast from fromClass to toClass will succeed, fail, or needs
		/// to be resolved at runtime.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*, TypeCompareState> compareTypesForCast;
		/// <summary>
		/// See if types represented by cls1 and cls2 compare equal, not
		/// equal, or the comparison needs to be resolved at runtime.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*, TypeCompareState> compareTypesForEquality;
		/// <summary>
		/// Returns the intersection of cls1 and cls2.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*> mergeClasses;
		/// <summary>
		/// Returns true if cls2 is known to be a more specific type
		/// than cls1 (a subtype or more restrictive shared type)
		/// for purposes of jit type tracking. This is a hint to the
		/// jit for optimization; it does not have correctness
		/// implications.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*, bool> isMoreSpecificType;
		/// <summary>
		/// Given a class handle, returns the Parent type.
		/// For COMObjectType, it returns Class Handle of System.Object.
		/// Returns 0 if System.Object is passed in.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_*> getParentType;
		/// <summary>
		/// Returns the CorInfoType of the "child type". If the child type is
		/// not a primitive type, *clsRet will be set.
		/// Given an Array of Type Foo, returns Foo.
		/// Given BYREF Foo, returns Foo
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CORINFO_CLASS_STRUCT_**, CorInfoType> getChildType;
		/// <summary>
		/// Check constraints on type arguments of this class and parent classes
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, bool> satisfiesClassConstraints;
		/// <summary>
		/// Check if this is a single dimensional array type
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, bool> isSDArray;
		/// <summary>
		/// Get the numbmer of dimensions in an array
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, uint> getArrayRank;
		/// <summary>
		/// Get static field data for an array
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_FIELD_STRUCT_*, uint, void*> getArrayInitializationData;
		/// <summary>
		/// Check Visibility rules.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_METHOD_STRUCT_*, CORINFO_HELPER_DESC*, CorInfoIsAccessAllowedResult> canAccessClass;
		/// <summary>
		/// This function is for debugging only.  It returns the field name
		/// and if 'moduleName' is non-null, it sets it to something that will
		/// says which method (a class name, or a module name)
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_FIELD_STRUCT_*, sbyte**, sbyte*> getFieldName;
		/// <summary>
		/// Return class it belongs to
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_FIELD_STRUCT_*, CORINFO_CLASS_STRUCT_*> getFieldClass;
		/// <summary>
		/// Return the field's type, if it is CORINFO_TYPE_VALUECLASS 'structType' is set
		/// the field's value class (if 'structType' == 0, then don't bother
		/// the structure info).
		/// 
		/// 'memberParent' is typically only set when verifying.  It should be the
		/// result of calling getMemberParent.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_FIELD_STRUCT_*, CORINFO_CLASS_STRUCT_**, CORINFO_CLASS_STRUCT_*, CorInfoType> getFieldType;
		/// <summary>
		/// Return the data member's instance offset
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_FIELD_STRUCT_*, uint> getFieldOffset;
		public readonly delegate*<ICorStaticInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_METHOD_STRUCT_*, CORINFO_ACCESS_FLAGS, CORINFO_FIELD_INFO*, void> getFieldInfo;
		/// <summary>
		/// Returns true iff "fldHnd" represents a static field.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_FIELD_STRUCT_*, bool> isFieldStatic;
		/// <summary>
		/// Query the EE to find out where interesting break points
		/// in the code are.  The native compiler will ensure that these places
		/// have a corresponding break point in native code.
		/// 
		/// Note that unless CORJIT_FLAG_DEBUG_CODE is specified, this function will
		/// be used only as a hint and the native compiler should not change its
		/// code generation.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint*, uint**, ICorDebugInfo.BoundaryTypes*, void> getBoundaries;
		/// <summary>
		/// Note that debugger (and profiler) is assuming that all of the
		/// offsets form a contiguous block of memory, and that the
		/// OffsetMapping is sorted in order of increasing native offset.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint, ICorDebugInfo.OffsetMapping*, void> setBoundaries;
		/// <summary>
		/// Query the EE to find out the scope of local varables.
		/// normally the JIT would trash variables after last use, but
		/// under debugging, the JIT needs to keep them live over their
		/// entire scope so that they can be inspected.
		/// 
		/// Note that unless CORJIT_FLAG_DEBUG_CODE is specified, this function will
		/// be used only as a hint and the native compiler should not change its
		/// code generation.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint*, ICorDebugInfo.ILVarInfo**, bool*, void> getVars;
		/// <summary>
		/// Report back to the EE the location of every variable.
		/// note that the JIT might split lifetimes into different
		/// locations etc.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint, ICorDebugInfo.NativeVarInfo*, void> setVars;
		/// <summary>
		/// Used to allocate memory that needs to handed to the EE.
		/// For eg, use this to allocated memory for reporting debug info,
		/// which will be handed to the EE by setVars() and setBoundaries()
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, ulong, void*> allocateArray;
		/// <summary>
		/// JitCompiler will free arrays passed by the EE using this
		/// For eg, The EE returns memory in getVars() and getBoundaries()
		/// to the JitCompiler, which the JitCompiler should release using
		/// freeArray()
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, void*, void> freeArray;
		/// <summary>
		/// Advance the pointer to the argument list.
		/// a ptr of 0, is special and always means the first argument
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_ARG_LIST_STRUCT_*, CORINFO_ARG_LIST_STRUCT_*> getArgNext;
		/// <summary>
		/// Get the type of a particular argument
		/// CORINFO_TYPE_UNDEF is returned when there are no more arguments
		/// If the type returned is a primitive type (or an enum) *vcTypeRet set to NULL
		/// otherwise it is set to the TypeHandle associted with the type
		/// Enumerations will always look their underlying type (probably should fix this)
		/// Otherwise vcTypeRet is the type as would be seen by the IL,
		/// The return value is the type that is used for calling convention purposes
		/// (Thus if the EE wants a value class to be passed like an int, then it will
		/// return CORINFO_TYPE_INT
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_SIG_INFO*, CORINFO_ARG_LIST_STRUCT_*, CORINFO_CLASS_STRUCT_**, CorInfoTypeWithMod> getArgType;
		/// <summary>
		/// If the Arg is a CORINFO_TYPE_CLASS fetch the class handle associated with it
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_SIG_INFO*, CORINFO_ARG_LIST_STRUCT_*, CORINFO_CLASS_STRUCT_*> getArgClass;
		/// <summary>
		/// Returns type of HFA for valuetype
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, CorInfoHFAElemType> getHFAType;
		/// <summary>
		/// Returns the HRESULT of the current exception
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, _EXCEPTION_POINTERS*, int> GetErrorHRESULT;
		/// <summary>
		/// Fetches the message of the current exception
		/// Returns the size of the message (including terminating null). This can be
		/// greater than bufferLength if the buffer is insufficient.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, ushort*, uint, uint> GetErrorMessage;
		/// <summary>
		/// Returns EXCEPTION_EXECUTE_HANDLER if it is OK for the compile to handle the
		/// exception, abort some work (like the inlining) and continue compilation
		/// returns EXCEPTION_CONTINUE_SEARCH if exception must always be handled by the EE
		/// things like ThreadStoppedException ...
		/// returns EXCEPTION_CONTINUE_EXECUTION if exception is fixed up by the EE
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, _EXCEPTION_POINTERS*, int> FilterException;
		/// <summary>
		/// Cleans up internal EE tracking when an exception is caught.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, _EXCEPTION_POINTERS*, void> HandleException;
		public readonly delegate*<ICorStaticInfo*, int, void> ThrowExceptionForJitResult;
		/// <summary>
		/// Throws an exception defined by the given throw helper.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_HELPER_DESC*, void> ThrowExceptionForHelper;
		public readonly delegate*<ICorStaticInfo*, delegate*<void*, void>, void*, bool> runWithErrorTrap;
		/// <summary>
		/// Return details about EE internal data structures
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_EE_INFO*, void> getEEInfo;
		/// <summary>
		/// Returns name of the JIT timer log
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, ushort*> getJitTimeLogFilename;
		/// <summary>
		/// This function is for debugging only. Returns method token.
		/// Returns mdMethodDefNil for dynamic methods.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint> getMethodDefFromMethod;
		/// <summary>
		/// This function is for debugging only.  It returns the method name
		/// and if 'moduleName' is non-null, it sets it to something that will
		/// says which method (a class name, or a module name)
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, sbyte**, sbyte*> getMethodName;
		/// <summary>
		/// Return method name as in metadata, or nullptr if there is none,
		/// and optionally return the class, enclosing class, and namespace names
		/// as in metadata.
		/// Suitable for non-debugging use.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, sbyte**, sbyte**, sbyte**, sbyte*> getMethodNameFromMetadata;
		/// <summary>
		/// This function is for debugging only.  It returns a value that
		/// is will always be the same for a given method.  It is used
		/// to implement the 'jitRange' functionality
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_METHOD_STRUCT_*, uint> getMethodHash;
		/// <summary>
		/// This function is for debugging only.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_MODULE_STRUCT_*, uint, sbyte*, ulong, ulong> findNameOfToken;
		/// <summary>
		/// Returns whether the struct is enregisterable. Only valid on a System V VM. Returns true on success, false on failure.
		/// </summary>
		public readonly delegate*<ICorStaticInfo*, CORINFO_CLASS_STRUCT_*, SYSTEMV_AMD64_CORINFO_STRUCT_REG_PASSING_DESCRIPTOR*, bool> getSystemVAmd64PassStructInRegisterDescriptor;
	}
	public unsafe readonly struct ICorDynamicInfo
	{
		private readonly ICorStaticInfo _base1;
		/// <summary>
		/// Return details about EE internal data structures
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, void**, uint> getThreadTLSIndex;
		public readonly delegate*<ICorDynamicInfo*, void**, void*> getInlinedCallFrameVptr;
		public readonly delegate*<ICorDynamicInfo*, void**, int*> getAddrOfCaptureThreadGlobal;
		/// <summary>
		/// Return the native entry point to an EE helper (see CorInfoHelpFunc)
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CorInfoHelpFunc, void**, void*> getHelperFtn;
		/// <summary>
		/// Return a callable address of the function (native code). This function
		/// may return a different value (depending on whether the method has
		/// been JITed or not.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_CONST_LOOKUP*, CORINFO_ACCESS_FLAGS, void> getFunctionEntryPoint;
		/// <summary>
		/// Return a directly callable address. This can be used similarly to the
		/// value returned by getFunctionEntryPoint() except that it is
		/// guaranteed to be multi callable entrypoint.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_CONST_LOOKUP*, void> getFunctionFixedEntryPoint;
		/// <summary>
		/// Get the synchronization handle that is passed to monXstatic function
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, void**, void*> getMethodSync;
		/// <summary>
		/// Get slow lazy string literal helper to use (CORINFO_HELP_STRCNS*).
		/// Returns CORINFO_HELP_UNDEF if lazy string literal helper cannot be used.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_MODULE_STRUCT_*, CorInfoHelpFunc> getLazyStringLiteralHelper;
		public readonly delegate*<ICorDynamicInfo*, CORINFO_MODULE_STRUCT_*, void**, CORINFO_MODULE_STRUCT_*> embedModuleHandle;
		public readonly delegate*<ICorDynamicInfo*, CORINFO_CLASS_STRUCT_*, void**, CORINFO_CLASS_STRUCT_*> embedClassHandle;
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, void**, CORINFO_METHOD_STRUCT_*> embedMethodHandle;
		public readonly delegate*<ICorDynamicInfo*, CORINFO_FIELD_STRUCT_*, void**, CORINFO_FIELD_STRUCT_*> embedFieldHandle;
		/// <summary>
		/// Given a module scope (module), a method handle (context) and
		/// a metadata token (metaTOK), fetch the handle
		/// (type, field or method) associated with the token.
		/// If this is not possible at compile-time (because the current method's
		/// code is shared and the token contains generic parameters)
		/// then indicate how the handle should be looked up at run-time.
		/// 
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_RESOLVED_TOKEN*, bool, CORINFO_GENERICHANDLE_RESULT*, void> embedGenericHandle;
		/// <summary>
		/// Return information used to locate the exact enclosing type of the current method.
		/// Used only to invoke .cctor method from code shared across generic instantiations
		/// !needsRuntimeLookup       statically known (enclosing type of method itself)
		/// needsRuntimeLookup:
		/// CORINFO_LOOKUP_THISOBJ     use vtable pointer of 'this' param
		/// CORINFO_LOOKUP_CLASSPARAM  use vtable hidden param
		/// CORINFO_LOOKUP_METHODPARAM use enclosing type of method-desc hidden param
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_LOOKUP_KIND*, void> getLocationOfThisType;
		/// <summary>
		/// Return the address of the PInvoke target. May be a fixup area in the
		/// case of late-bound PInvoke calls.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_CONST_LOOKUP*, void> getAddressOfPInvokeTarget;
		/// <summary>
		/// Generate a cookie based on the signature that would needs to be passed
		/// to CORINFO_HELP_PINVOKE_CALLI
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_SIG_INFO*, void**, void*> GetCookieForPInvokeCalliSig;
		/// <summary>
		/// Returns true if a VM cookie can be generated for it (might be false due to cross-module
		/// inlining, in which case the inlining should be aborted)
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_SIG_INFO*, bool> canGetCookieForPInvokeCalliSig;
		/// <summary>
		/// Gets a handle that is checked to see if the current method is
		/// included in "JustMyCode"
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_JUST_MY_CODE_HANDLE_***, CORINFO_JUST_MY_CODE_HANDLE_*> getJustMyCodeHandle;
		/// <summary>
		/// Gets a method handle that can be used to correlate profiling data.
		/// This is the IP of a native method, or the address of the descriptor struct
		/// for IL.  Always guaranteed to be unique per process, and not to move. */
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, bool*, void**, bool*, void> GetProfilingHandle;
		/// <summary>
		/// Returns instructions on how to make the call. See code:CORINFO_CALL_INFO for possible return values.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_RESOLVED_TOKEN*, CORINFO_METHOD_STRUCT_*, CORINFO_CALLINFO_FLAGS, CORINFO_CALL_INFO*, void> getCallInfo;
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_CLASS_STRUCT_*, bool> canAccessFamily;
		/// <summary>
		/// Returns TRUE if the Class Domain ID is the RID of the class (currently true for every class
		/// except reflection emitted classes and generics)
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_CLASS_STRUCT_*, bool> isRIDClassDomainID;
		/// <summary>
		/// Returns the class's domain ID for accessing shared statics
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_CLASS_STRUCT_*, void**, uint> getClassDomainID;
		/// <summary>
		/// Return the data's address (for static fields only)
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_FIELD_STRUCT_*, void**, void*> getFieldAddress;
		/// <summary>
		/// If pIsSpeculative is NULL, return the class handle for the value of ref-class typed
		/// static readonly fields, if there is a unique location for the static and the class
		/// is already initialized.
		/// 
		/// If pIsSpeculative is not NULL, fetch the class handle for the value of all ref-class
		/// typed static fields, if there is a unique location for the static and the field is
		/// not null.
		/// 
		/// Set *pIsSpeculative true if this type may change over time (field is not readonly or
		/// is readonly but class has not yet finished initialization). Set *pIsSpeculative false
		/// if this type will not change.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_FIELD_STRUCT_*, bool*, CORINFO_CLASS_STRUCT_*> getStaticFieldCurrentClass;
		/// <summary>
		/// Registers a vararg sig & returns a VM cookie for it (which can contain other stuff)
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_SIG_INFO*, void**, CORINFO_VarArgInfo*> getVarArgsHandle;
		/// <summary>
		/// Returns true if a VM cookie can be generated for it (might be false due to cross-module
		/// inlining, in which case the inlining should be aborted)
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_SIG_INFO*, bool> canGetVarArgsHandle;
		/// <summary>
		/// Allocate a string literal on the heap and return a handle to it
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_MODULE_STRUCT_*, uint, void**, InfoAccessType> constructStringLiteral;
		public readonly delegate*<ICorDynamicInfo*, void**, InfoAccessType> emptyStringLiteral;
		/// <summary>
		/// (static fields only) given that 'field' refers to thread local store,
		/// return the ID (TLS index), which is used to find the beginning of the
		/// TLS data area for the particular DLL 'field' is associated with.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_FIELD_STRUCT_*, void**, uint> getFieldThreadLocalStoreID;
		/// <summary>
		/// Sets another object to intercept calls to "self" and current method being compiled
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, void> setOverride;
		/// <summary>
		/// Adds an active dependency from the context method's module to the given module
		/// This is internal callback for the EE. JIT should not call it directly.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_MODULE_STRUCT_*, CORINFO_MODULE_STRUCT_*, void> addActiveDependency;
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, CORINFO_CLASS_STRUCT_*, CORINFO_METHOD_STRUCT_*, DelegateCtorArgs*, CORINFO_METHOD_STRUCT_*> GetDelegateCtor;
		public readonly delegate*<ICorDynamicInfo*, CORINFO_METHOD_STRUCT_*, void> MethodCompileComplete;
		/// <summary>
		/// Obtain tailcall help for the specified call site.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_RESOLVED_TOKEN*, CORINFO_SIG_INFO*, CORINFO_GET_TAILCALL_HELPERS_FLAGS, CORINFO_TAILCALL_HELPERS*, bool> getTailCallHelpers;
		/// <summary>
		/// Optionally, convert calli to regular method call. This is for PInvoke argument marshalling.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_RESOLVED_TOKEN*, bool, bool> convertPInvokeCalliToCall;
		/// <summary>
		/// Notify EE about intent to use or not to use instruction set in the method. Returns true if the instruction set is supported unconditionally.
		/// </summary>
		public readonly delegate*<ICorDynamicInfo*, CORINFO_InstructionSet, bool, bool> notifyInstructionSetUsage;
		public static explicit operator ICorStaticInfo(ICorDynamicInfo _) => _._base1;
	}
	public readonly struct CORJIT_FLAGS
	{
		public enum CorJitFlag
		{
			/// <summary>
			/// Indicates that the JIT should retrieve flags in the form of a
			/// pointer to a CORJIT_FLAGS value via ICorJitInfo::getJitFlags().
			/// </summary>
			CORJIT_FLAG_CALL_GETJITFLAGS = -1,
			CORJIT_FLAG_SPEED_OPT = 0,
			CORJIT_FLAG_SIZE_OPT = 1,
			/// <summary>
			/// Generate "debuggable" code (no code-mangling optimizations)
			/// </summary>
			CORJIT_FLAG_DEBUG_CODE = 2,
			/// <summary>
			/// We are in Edit-n-Continue mode
			/// </summary>
			CORJIT_FLAG_DEBUG_EnC = 3,
			/// <summary>
			/// Generate line and local-var info
			/// </summary>
			CORJIT_FLAG_DEBUG_INFO = 4,
			/// <summary>
			/// Disable all jit optimizations (not necesarily debuggable code)
			/// </summary>
			CORJIT_FLAG_MIN_OPT = 5,
			CORJIT_FLAG_UNUSED1 = 6,
			/// <summary>
			/// Calling from multicore JIT background thread, do not call JitComplete
			/// </summary>
			CORJIT_FLAG_MCJIT_BACKGROUND = 7,
			CORJIT_FLAG_UNUSED2 = 8,
			CORJIT_FLAG_UNUSED3 = 9,
			CORJIT_FLAG_UNUSED4 = 10,
			CORJIT_FLAG_UNUSED5 = 11,
			CORJIT_FLAG_UNUSED6 = 12,
			/// <summary>
			/// Generate alternate method for On Stack Replacement
			/// </summary>
			CORJIT_FLAG_OSR = 13,
			/// <summary>
			/// JIT should consider itself an ALT_JIT
			/// </summary>
			CORJIT_FLAG_ALT_JIT = 14,
			CORJIT_FLAG_UNUSED8 = 15,
			CORJIT_FLAG_UNUSED9 = 16,
			CORJIT_FLAG_FEATURE_SIMD = 17,
			/// <summary>
			/// Use the final code generator, i.e., not the interpreter.
			/// </summary>
			CORJIT_FLAG_MAKEFINALCODE = 18,
			/// <summary>
			/// Use version-resilient code generation
			/// </summary>
			CORJIT_FLAG_READYTORUN = 19,
			/// <summary>
			/// Instrument prologues/epilogues
			/// </summary>
			CORJIT_FLAG_PROF_ENTERLEAVE = 20,
			CORJIT_FLAG_UNUSED11 = 21,
			/// <summary>
			/// Disables PInvoke inlining
			/// </summary>
			CORJIT_FLAG_PROF_NO_PINVOKE_INLINE = 22,
			/// <summary>
			/// (lazy) skip verification - determined without doing a full resolve. See comment below
			/// </summary>
			CORJIT_FLAG_SKIP_VERIFICATION = 23,
			/// <summary>
			/// Jit or prejit is the execution engine.
			/// </summary>
			CORJIT_FLAG_PREJIT = 24,
			/// <summary>
			/// Generate relocatable code
			/// </summary>
			CORJIT_FLAG_RELOC = 25,
			/// <summary>
			/// Only import the function
			/// </summary>
			CORJIT_FLAG_IMPORT_ONLY = 26,
			/// <summary>
			/// Method is an IL stub
			/// </summary>
			CORJIT_FLAG_IL_STUB = 27,
			/// <summary>
			/// JIT should separate code into hot and cold sections
			/// </summary>
			CORJIT_FLAG_PROCSPLIT = 28,
			/// <summary>
			/// Collect basic block profile information
			/// </summary>
			CORJIT_FLAG_BBINSTR = 29,
			/// <summary>
			/// Optimize method based on profile information
			/// </summary>
			CORJIT_FLAG_BBOPT = 30,
			/// <summary>
			/// All methods have an EBP frame
			/// </summary>
			CORJIT_FLAG_FRAMED = 31,
			CORJIT_FLAG_UNUSED12 = 32,
			/// <summary>
			/// JIT must place stub secret param into local 0.  (used by IL stubs)
			/// </summary>
			CORJIT_FLAG_PUBLISH_SECRET_PARAM = 33,
			CORJIT_FLAG_UNUSED13 = 34,
			/// <summary>
			/// JIT is being invoked as a result of stack sampling for hot methods in the background
			/// </summary>
			CORJIT_FLAG_SAMPLING_JIT_BACKGROUND = 35,
			/// <summary>
			/// The JIT should use the PINVOKE_{BEGIN,END} helpers instead of emitting inline transitions
			/// </summary>
			CORJIT_FLAG_USE_PINVOKE_HELPERS = 36,
			/// <summary>
			/// The JIT should insert REVERSE_PINVOKE_{ENTER,EXIT} helpers into method prolog/epilog
			/// </summary>
			CORJIT_FLAG_REVERSE_PINVOKE = 37,
			/// <summary>
			/// The JIT should insert the REVERSE_PINVOKE helper variants that track transitions.
			/// </summary>
			CORJIT_FLAG_TRACK_TRANSITIONS = 38,
			/// <summary>
			/// This is the initial tier for tiered compilation which should generate code as quickly as possible
			/// </summary>
			CORJIT_FLAG_TIER0 = 39,
			/// <summary>
			/// This is the final tier (for now) for tiered compilation which should generate high quality code
			/// </summary>
			CORJIT_FLAG_TIER1 = 40,
			CORJIT_FLAG_UNUSED15 = 41,
			/// <summary>
			/// JIT should not inline any called method into this method
			/// </summary>
			CORJIT_FLAG_NO_INLINING = 42,
			CORJIT_FLAG_UNUSED16 = 43,
			CORJIT_FLAG_UNUSED17 = 44,
			CORJIT_FLAG_UNUSED18 = 45,
			CORJIT_FLAG_UNUSED19 = 46,
			CORJIT_FLAG_UNUSED20 = 47,
			CORJIT_FLAG_UNUSED21 = 48,
			CORJIT_FLAG_UNUSED22 = 49,
			CORJIT_FLAG_UNUSED23 = 50,
			CORJIT_FLAG_UNUSED24 = 51,
			CORJIT_FLAG_UNUSED25 = 52,
			CORJIT_FLAG_UNUSED26 = 53,
			CORJIT_FLAG_UNUSED27 = 54,
			CORJIT_FLAG_UNUSED28 = 55,
			CORJIT_FLAG_UNUSED29 = 56,
			CORJIT_FLAG_UNUSED30 = 57,
			CORJIT_FLAG_UNUSED31 = 58,
			CORJIT_FLAG_UNUSED32 = 59,
			CORJIT_FLAG_UNUSED33 = 60,
			CORJIT_FLAG_UNUSED34 = 61,
			CORJIT_FLAG_UNUSED35 = 62,
			CORJIT_FLAG_UNUSED36 = 63
		}
		public readonly ulong corJitFlags;
		public readonly CORINFO_InstructionSetFlags instructionSetFlags;

		public bool IsSet(CorJitFlag flag)
		{
			return (corJitFlags & (1UL << (int)flag)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Span<CorJitFlag> ExtractFlags(in FixedArray64<CorJitFlag> resultBuffer = default)
		{
			var result = resultBuffer.AsStackBlock();
			var j = 0;
			var type = typeof(CorJitFlag);
			var arr = type.GetEnumValues();
			var values = Unsafe.As<Array, CorJitFlag[]>(ref arr);
			for (var i = 0; i < values.Length; i++)
			{
				var value = values[i];
				if (!IsSet(value)) continue;
				result[j++] = value;
			}

			return result[..j];
		}
	}
	public unsafe readonly struct AllocMemArgs
	{
		/// <summary>
		/// Input arguments
		/// </summary>
		public readonly uint hotCodeSize;
		public readonly uint coldCodeSize;
		public readonly uint roDataSize;
		public readonly uint xcptnsCount;
		public readonly CorJitAllocMemFlag flag;
		/// <summary>
		/// Output arguments
		/// </summary>
		public readonly void* hotCodeBlock;
		public readonly void* hotCodeBlockRW;
		public readonly void* coldCodeBlock;
		public readonly void* coldCodeBlockRW;
		public readonly void* roDataBlock;
		public readonly void* roDataBlockRW;
	}
	public unsafe readonly struct ICorJitHost
	{
		/// <summary>
		/// Allocate memory of the given size in bytes.
		/// </summary>
		public readonly delegate*<ICorJitHost*, ulong, void*> allocateMemory;
		/// <summary>
		/// Frees memory previous obtained by a call to `ICorJitHost::allocateMemory`.
		/// </summary>
		public readonly delegate*<ICorJitHost*, void*, void> freeMemory;
		/// <summary>
		/// Return an integer config value for the given key, if any exists.
		/// </summary>
		public readonly delegate*<ICorJitHost*, char*, int, int> getIntConfigValue;
		/// <summary>
		/// Return a string config value for the given key, if any exists.
		/// </summary>
		public readonly delegate*<ICorJitHost*, char*, char*> getStringConfigValue;
		/// <summary>
		/// Free a string ConfigValue returned by the runtime.
		/// JITs using the getStringConfigValue query are required
		/// to return the string values to the runtime for deletion.
		/// This avoids leaking the memory in the JIT.
		/// </summary>
		public readonly delegate*<ICorJitHost*, char*, void> freeStringConfigValue;
		/// <summary>
		/// Allocate memory slab of the given size in bytes. The host is expected to pool
		/// these for a good performance.
		/// </summary>
		public readonly delegate*<ICorJitHost*, ulong, ulong*, void*> allocateSlab;
		/// <summary>
		/// Free memory slab of the given size in bytes.
		/// </summary>
		public readonly delegate*<ICorJitHost*, void*, ulong, void> freeSlab;
	}
	public unsafe readonly struct ICorJitCompiler
	{
		/// <summary>
		/// CompileMethod is the main routine to ask the JIT Compiler to create native code for a method. The
		/// method to be compiled is passed in the 'info' parameter, and the code:ICorJitInfo is used to allow the
		/// JIT to resolve tokens, and make any other callbacks needed to create the code. nativeEntry, and
		/// nativeSizeOfCode are just for convenience because the JIT asks the EE for the memory to emit code into
		/// (see code:ICorJitInfo.allocMem), so really the EE already knows where the method starts and how big
		/// it is (in fact, it could be in more than one chunk).
		/// 
		/// * In the 32 bit jit this is implemented by code:CILJit.compileMethod
		/// * For the 64 bit jit this is implemented by code:PreJit.compileMethod
		/// </summary>
		public readonly delegate*<ICorJitCompiler*, ICorJitInfo*, CORINFO_METHOD_INFO*, uint, byte**, uint*, CorJitResult> compileMethod;
		/// <summary>
		/// Do any appropriate work at process shutdown.  Default impl is to do nothing.
		/// </summary>
		public readonly delegate*<ICorJitCompiler*, ICorStaticInfo*, void> ProcessShutdownWork;
		/// <summary>
		/// The EE asks the JIT for a "version identifier". This represents the version of the JIT/EE interface.
		/// If the JIT doesn't implement the same JIT/EE interface expected by the EE (because the JIT doesn't
		/// return the version identifier that the EE expects), then the EE fails to load the JIT.
		/// 
		/// </summary>
		public readonly delegate*<ICorJitCompiler*, _GUID*, void> getVersionIdentifier;
		/// <summary>
		/// When the EE loads the System.Numerics.Vectors assembly, it asks the JIT what length (in bytes) of
		/// SIMD vector it supports as an intrinsic type.  Zero means that the JIT does not support SIMD
		/// intrinsics, so the EE should use the default size (i.e. the size of the IL implementation).
		/// </summary>
		public readonly delegate*<ICorJitCompiler*, CORJIT_FLAGS, uint> getMaxIntrinsicSIMDVectorLength;
	}
	public unsafe readonly struct ICorJitInfo
	{
		private readonly ICorDynamicInfo _base1;
		public readonly struct BlockCounts
		{
			public readonly uint ILOffset;
			public readonly uint ExecutionCount;
		}
		public readonly struct ClassProfile32
		{
			public enum ClassProfile32_1c155000daa942918fa6a0904b1795ec
			{
				SIZE = 8,
				SAMPLE_INTERVAL = 32,
				CLASS_FLAG = -2147483648,
				INTERFACE_FLAG = 1073741824,
				OFFSET_MASK = 1073741823
			}
			public readonly uint Count;
			public readonly FixedArray8<Ptr<CORINFO_CLASS_STRUCT_>> ClassTable;
		}
		public readonly struct ClassProfile64
		{
			public readonly ulong Count;
			public readonly FixedArray8<Ptr<CORINFO_CLASS_STRUCT_>> ClassTable;
		}
		public readonly struct PgoInstrumentationSchema
		{
			public readonly ulong Offset;
			public readonly PgoInstrumentationKind InstrumentationKind;
			public readonly int ILOffset;
			public readonly int Count;
			public readonly int Other;
		}
		public enum PgoInstrumentationKind
		{
			/// <summary>
			/// Schema data types
			/// </summary>
			None = 0,
			/// <summary>
			/// Schema data types
			/// </summary>
			FourByte = 1,
			/// <summary>
			/// Schema data types
			/// </summary>
			EightByte = 2,
			/// <summary>
			/// Schema data types
			/// </summary>
			TypeHandle = 3,
			/// <summary>
			/// Mask of all schema data types
			/// </summary>
			MarshalMask = 15,
			/// <summary>
			/// ExcessAlignment
			/// </summary>
			Align4Byte = 16,
			/// <summary>
			/// ExcessAlignment
			/// </summary>
			Align8Byte = 32,
			/// <summary>
			/// ExcessAlignment
			/// </summary>
			AlignPointer = 48,
			/// <summary>
			/// Mask of all schema alignment types
			/// </summary>
			AlignMask = 48,
			/// <summary>
			/// Mask of all schema alignment types
			/// </summary>
			DescriptorMin = 64,
			/// <summary>
			/// All instrumentation schemas must end with a record which is "Done"
			/// </summary>
			Done = 0,
			/// <summary>
			/// Basic block counter using unsigned 4 byte int
			/// </summary>
			BasicBlockIntCount = 65,
			/// <summary>
			/// Basic block counter using unsigned 8 byte int
			/// </summary>
			BasicBlockLongCount = 66,
			/// <summary>
			/// 4 byte counter that is part of a type histogram. Aligned to match ClassProfile32's alignment.
			/// </summary>
			TypeHandleHistogramIntCount = 177,
			/// <summary>
			/// 8 byte counter that is part of a type histogram
			/// </summary>
			TypeHandleHistogramLongCount = 130,
			/// <summary>
			/// TypeHandle that is part of a type histogram
			/// </summary>
			TypeHandleHistogramTypeHandle = 195,
			/// <summary>
			/// Version is encoded in the Other field of the schema
			/// </summary>
			Version = 256,
			/// <summary>
			/// Number of runs is encoded in the Other field of the schema
			/// </summary>
			NumRuns = 320,
			/// <summary>
			/// Edge counter using unsigned 4 byte int
			/// </summary>
			EdgeIntCount = 385,
			/// <summary>
			/// Edge counter using unsigned 8 byte int
			/// </summary>
			EdgeLongCount = 386,
			/// <summary>
			/// Compressed get likely class data
			/// </summary>
			GetLikelyClass = 451
		}
		public enum PgoSource
		{
			/// <summary>
			/// PGO data source unknown
			/// </summary>
			Unknown = 0,
			/// <summary>
			/// PGO data comes from embedded R2R profile data
			/// </summary>
			Static = 1,
			/// <summary>
			/// PGO data comes from current run
			/// </summary>
			Dynamic = 2,
			/// <summary>
			/// PGO data comes from blend of prior runs and current run
			/// </summary>
			Blend = 3,
			/// <summary>
			/// PGO data comes from text file
			/// </summary>
			Text = 4,
			/// <summary>
			/// PGO data from classic IBC
			/// </summary>
			IBC = 5,
			/// <summary>
			/// PGO data derived from sampling
			/// </summary>
			Sampling = 6
		}
		/// <summary>
		/// Get a block of memory for the code, readonly data, and read-write data
		/// </summary>
		public readonly delegate*<ICorJitInfo*, AllocMemArgs*, void> allocMem;
		/// <summary>
		/// Reserve memory for the method/funclet's unwind information.
		/// Note that this must be called before allocMem. It should be
		/// called once for the main method, once for every funclet, and
		/// once for every block of cold code for which allocUnwindInfo
		/// will be called.
		/// 
		/// This is necessary because jitted code must allocate all the
		/// memory needed for the unwindInfo at the allocMem call.
		/// For prejitted code we split up the unwinding information into
		/// separate sections .rdata and .pdata.
		/// 
		/// </summary>
		public readonly delegate*<ICorJitInfo*, bool, bool, uint, void> reserveUnwindInfo;
		/// <summary>
		/// Allocate and initialize the .rdata and .pdata for this method or
		/// funclet, and get the block of memory needed for the machine-specific
		/// unwind information (the info for crawling the stack frame).
		/// Note that allocMem must be called first.
		/// 
		/// Parameters:
		/// 
		/// pHotCode        main method code buffer, always filled in
		/// pColdCode       cold code buffer, only filled in if this is cold code,
		/// null otherwise
		/// startOffset     start of code block, relative to appropriate code buffer
		/// (e.g. pColdCode if cold, pHotCode if hot).
		/// endOffset       end of code block, relative to appropriate code buffer
		/// unwindSize      size of unwind info pointed to by pUnwindBlock
		/// pUnwindBlock    pointer to unwind info
		/// funcKind        type of funclet (main method code, handler, filter)
		/// 
		/// </summary>
		public readonly delegate*<ICorJitInfo*, byte*, byte*, uint, uint, uint, byte*, CorJitFuncKind, void> allocUnwindInfo;
		/// <summary>
		/// Get a block of memory needed for the code manager information,
		/// (the info for enumerating the GC pointers while crawling the
		/// stack frame).
		/// Note that allocMem must be called first
		/// </summary>
		public readonly delegate*<ICorJitInfo*, ulong, void*> allocGCInfo;
		/// <summary>
		/// Indicate how many exception handler blocks are to be returned.
		/// This is guaranteed to be called before any 'setEHinfo' call.
		/// Note that allocMem must be called before this method can be called.
		/// </summary>
		public readonly delegate*<ICorJitInfo*, uint, void> setEHcount;
		/// <summary>
		/// Set the values for one particular exception handler block.
		/// 
		/// Handler regions should be lexically contiguous.
		/// This is because FinallyIsUnwinding() uses lexicality to
		/// determine if a "finally" clause is executing.
		/// </summary>
		public readonly delegate*<ICorJitInfo*, uint, CORINFO_EH_CLAUSE*, void> setEHinfo;
		/// <summary>
		/// Level -> fatalError, Level 2 -> Error, Level 3 -> Warning
		/// Level 4 means happens 10 times in a run, level 5 means 100, level 6 means 1000 ...
		/// returns non-zero if the logging succeeded
		/// </summary>
		public readonly delegate*<ICorJitInfo*, uint, sbyte*, sbyte*, bool> logMsg;
		/// <summary>
		/// Do an assert.  will return true if the code should retry (DebugBreak)
		/// returns false, if the assert should be igored.
		/// </summary>
		public readonly delegate*<ICorJitInfo*, sbyte*, int, sbyte*, int> doAssert;
		public readonly delegate*<ICorJitInfo*, CorJitResult, void> reportFatalError;
		/// <summary>
		/// Get profile information to be used for optimizing a current method.  The format
		/// of the buffer is the same as the format the JIT passes to allocPgoInstrumentationBySchema.
		/// </summary>
		public readonly delegate*<ICorJitInfo*, CORINFO_METHOD_STRUCT_*, PgoInstrumentationSchema**, uint*, byte**, PgoSource*, int> getPgoInstrumentationResults;
		/// <summary>
		/// Allocate a profile buffer for use in the current process
		/// The JIT shall call this api with the schema entries other than Offset filled in.
		/// The VM is responsible for allocating the buffer, and computing the various offsets
		/// The offset calculation shall obey the following rules
		/// 1. All data fields shall be naturally aligned.
		/// 2. The first offset may be arbitrarily large.
		/// 3. The JIT may mark a schema item with an alignment flag. This may be used to increase the alignment of a field.
		/// 4. Each data entry shall be laid out without extra padding.
		/// 
		/// The intention here is that it becomes possible to describe a C data structure with the alignment for ease of use with
		/// instrumentation helper functions
		/// </summary>
		public readonly delegate*<ICorJitInfo*, CORINFO_METHOD_STRUCT_*, PgoInstrumentationSchema*, uint, byte**, int> allocPgoInstrumentationBySchema;
		/// <summary>
		/// Associates a native call site, identified by its offset in the native code stream, with
		/// the signature information and method handle the JIT used to lay out the call site. If
		/// the call site has no signature information (e.g. a helper call) or has no method handle
		/// (e.g. a CALLI P/Invoke), then null should be passed instead.
		/// </summary>
		public readonly delegate*<ICorJitInfo*, uint, CORINFO_SIG_INFO*, CORINFO_METHOD_STRUCT_*, void> recordCallSite;
		/// <summary>
		/// A relocation is recorded if we are pre-jitting.
		/// A jump thunk may be inserted if we are jitting
		/// </summary>
		public readonly delegate*<ICorJitInfo*, void*, void*, void*, ushort, ushort, int, void> recordRelocation;
		public readonly delegate*<ICorJitInfo*, void*, ushort> getRelocTypeHint;
		/// <summary>
		/// For what machine does the VM expect the JIT to generate code? The VM
		/// returns one of the IMAGE_FILE_MACHINE_* values. Note that if the VM
		/// is cross-compiling (such as the case for crossgen), it will return a
		/// different value than if it was compiling for the host architecture.
		/// 
		/// </summary>
		public readonly delegate*<ICorJitInfo*, uint> getExpectedTargetArchitecture;
		/// <summary>
		/// Fetches extended flags for a particular compilation instance. Returns
		/// the number of bytes written to the provided buffer.
		/// </summary>
		public readonly delegate*<ICorJitInfo*, CORJIT_FLAGS*, uint, uint> getJitFlags;
		public static explicit operator ICorDynamicInfo(ICorJitInfo _) => _._base1;
	}
	public enum DPI_AWARENESS
	{
		DPI_AWARENESS_INVALID = -1,
		DPI_AWARENESS_UNAWARE = 0,
		DPI_AWARENESS_SYSTEM_AWARE = 1,
		DPI_AWARENESS_PER_MONITOR_AWARE = 2
	}
	public enum DPI_HOSTING_BEHAVIOR
	{
		DPI_HOSTING_BEHAVIOR_INVALID = -1,
		DPI_HOSTING_BEHAVIOR_DEFAULT = 0,
		DPI_HOSTING_BEHAVIOR_MIXED = 1
	}
	public enum ReplacesGeneralNumericDefines
	{
		IMAGE_DIRECTORY_ENTRY_COMHEADER = 14
	}
	public enum CorTypeAttr
	{
		/// <summary>
		/// Use this mask to retrieve the type visibility information.
		/// </summary>
		tdVisibilityMask = 7,
		/// <summary>
		/// Class is not public scope.
		/// </summary>
		tdNotPublic = 0,
		/// <summary>
		/// Class is public scope.
		/// </summary>
		tdPublic = 1,
		/// <summary>
		/// Class is nested with public visibility.
		/// </summary>
		tdNestedPublic = 2,
		/// <summary>
		/// Class is nested with private visibility.
		/// </summary>
		tdNestedPrivate = 3,
		/// <summary>
		/// Class is nested with family visibility.
		/// </summary>
		tdNestedFamily = 4,
		/// <summary>
		/// Class is nested with assembly visibility.
		/// </summary>
		tdNestedAssembly = 5,
		/// <summary>
		/// Class is nested with family and assembly visibility.
		/// </summary>
		tdNestedFamANDAssem = 6,
		/// <summary>
		/// Class is nested with family or assembly visibility.
		/// </summary>
		tdNestedFamORAssem = 7,
		/// <summary>
		/// Use this mask to retrieve class layout information
		/// </summary>
		tdLayoutMask = 24,
		/// <summary>
		/// Class fields are auto-laid out
		/// </summary>
		tdAutoLayout = 0,
		/// <summary>
		/// Class fields are laid out sequentially
		/// </summary>
		tdSequentialLayout = 8,
		/// <summary>
		/// Layout is supplied explicitly
		/// </summary>
		tdExplicitLayout = 16,
		/// <summary>
		/// Use this mask to retrieve class semantics information.
		/// </summary>
		tdClassSemanticsMask = 32,
		/// <summary>
		/// Type is a class.
		/// </summary>
		tdClass = 0,
		/// <summary>
		/// Type is an interface.
		/// </summary>
		tdInterface = 32,
		/// <summary>
		/// Class is abstract
		/// </summary>
		tdAbstract = 128,
		/// <summary>
		/// Class is concrete and may not be extended
		/// </summary>
		tdSealed = 256,
		/// <summary>
		/// Class name is special.  Name describes how.
		/// </summary>
		tdSpecialName = 1024,
		/// <summary>
		/// Class / interface is imported
		/// </summary>
		tdImport = 4096,
		/// <summary>
		/// The class is Serializable.
		/// </summary>
		tdSerializable = 8192,
		/// <summary>
		/// The type is a Windows Runtime type
		/// </summary>
		tdWindowsRuntime = 16384,
		/// <summary>
		/// Use tdStringFormatMask to retrieve string information for native interop
		/// </summary>
		tdStringFormatMask = 196608,
		/// <summary>
		/// LPTSTR is interpreted as ANSI in this class
		/// </summary>
		tdAnsiClass = 0,
		/// <summary>
		/// LPTSTR is interpreted as UNICODE
		/// </summary>
		tdUnicodeClass = 65536,
		/// <summary>
		/// LPTSTR is interpreted automatically
		/// </summary>
		tdAutoClass = 131072,
		/// <summary>
		/// A non-standard encoding specified by CustomFormatMask
		/// </summary>
		tdCustomFormatClass = 196608,
		/// <summary>
		/// Use this mask to retrieve non-standard encoding information for native interop. The meaning of the values of these 2 bits is unspecified.
		/// </summary>
		tdCustomFormatMask = 12582912,
		/// <summary>
		/// Initialize the class any time before first static field access.
		/// </summary>
		tdBeforeFieldInit = 1048576,
		/// <summary>
		/// This ExportedType is a type forwarder.
		/// </summary>
		tdForwarder = 2097152,
		/// <summary>
		/// Flags reserved for runtime use.
		/// </summary>
		tdReservedMask = 264192,
		/// <summary>
		/// Runtime should check name encoding.
		/// </summary>
		tdRTSpecialName = 2048,
		/// <summary>
		/// Class has security associate with it.
		/// </summary>
		tdHasSecurity = 262144
	}
	public enum CorMethodAttr
	{
		/// <summary>
		/// Member access mask - Use this mask to retrieve accessibility information.
		/// </summary>
		mdMemberAccessMask = 7,
		/// <summary>
		/// Member not referenceable.
		/// </summary>
		mdPrivateScope = 0,
		/// <summary>
		/// Accessible only by the parent type.
		/// </summary>
		mdPrivate = 1,
		/// <summary>
		/// Accessible by sub-types only in this Assembly.
		/// </summary>
		mdFamANDAssem = 2,
		/// <summary>
		/// Accessibly by anyone in the Assembly.
		/// </summary>
		mdAssem = 3,
		/// <summary>
		/// Accessible only by type and sub-types.
		/// </summary>
		mdFamily = 4,
		/// <summary>
		/// Accessibly by sub-types anywhere, plus anyone in assembly.
		/// </summary>
		mdFamORAssem = 5,
		/// <summary>
		/// Accessibly by anyone who has visibility to this scope.
		/// </summary>
		mdPublic = 6,
		/// <summary>
		/// Defined on type, else per instance.
		/// </summary>
		mdStatic = 16,
		/// <summary>
		/// Method may not be overridden.
		/// </summary>
		mdFinal = 32,
		/// <summary>
		/// Method virtual.
		/// </summary>
		mdVirtual = 64,
		/// <summary>
		/// Method hides by name+sig, else just by name.
		/// </summary>
		mdHideBySig = 128,
		/// <summary>
		/// Vtable layout mask - Use this mask to retrieve vtable attributes.
		/// </summary>
		mdVtableLayoutMask = 256,
		/// <summary>
		/// The default.
		/// </summary>
		mdReuseSlot = 0,
		/// <summary>
		/// Method always gets a new slot in the vtable.
		/// </summary>
		mdNewSlot = 256,
		/// <summary>
		/// Overridability is the same as the visibility.
		/// </summary>
		mdCheckAccessOnOverride = 512,
		/// <summary>
		/// Method does not provide an implementation.
		/// </summary>
		mdAbstract = 1024,
		/// <summary>
		/// Method is special.  Name describes how.
		/// </summary>
		mdSpecialName = 2048,
		/// <summary>
		/// Implementation is forwarded through pinvoke.
		/// </summary>
		mdPinvokeImpl = 8192,
		/// <summary>
		/// Managed method exported via thunk to unmanaged code.
		/// </summary>
		mdUnmanagedExport = 8,
		/// <summary>
		/// Reserved flags for runtime use only.
		/// </summary>
		mdReservedMask = 53248,
		/// <summary>
		/// Runtime should check name encoding.
		/// </summary>
		mdRTSpecialName = 4096,
		/// <summary>
		/// Method has security associate with it.
		/// </summary>
		mdHasSecurity = 16384,
		/// <summary>
		/// Method calls another method containing security code.
		/// </summary>
		mdRequireSecObject = 32768
	}
	public enum CorFieldAttr
	{
		/// <summary>
		/// Member access mask - Use this mask to retrieve accessibility information.
		/// </summary>
		fdFieldAccessMask = 7,
		/// <summary>
		/// Member not referenceable.
		/// </summary>
		fdPrivateScope = 0,
		/// <summary>
		/// Accessible only by the parent type.
		/// </summary>
		fdPrivate = 1,
		/// <summary>
		/// Accessible by sub-types only in this Assembly.
		/// </summary>
		fdFamANDAssem = 2,
		/// <summary>
		/// Accessibly by anyone in the Assembly.
		/// </summary>
		fdAssembly = 3,
		/// <summary>
		/// Accessible only by type and sub-types.
		/// </summary>
		fdFamily = 4,
		/// <summary>
		/// Accessibly by sub-types anywhere, plus anyone in assembly.
		/// </summary>
		fdFamORAssem = 5,
		/// <summary>
		/// Accessibly by anyone who has visibility to this scope.
		/// </summary>
		fdPublic = 6,
		/// <summary>
		/// Defined on type, else per instance.
		/// </summary>
		fdStatic = 16,
		/// <summary>
		/// Field may only be initialized, not written to after init.
		/// </summary>
		fdInitOnly = 32,
		/// <summary>
		/// Value is compile time constant.
		/// </summary>
		fdLiteral = 64,
		/// <summary>
		/// Field does not have to be serialized when type is remoted.
		/// </summary>
		fdNotSerialized = 128,
		/// <summary>
		/// Field is special.  Name describes how.
		/// </summary>
		fdSpecialName = 512,
		/// <summary>
		/// Implementation is forwarded through pinvoke.
		/// </summary>
		fdPinvokeImpl = 8192,
		/// <summary>
		/// Reserved flags for runtime use only.
		/// </summary>
		fdReservedMask = 38144,
		/// <summary>
		/// Runtime(metadata internal APIs) should check name encoding.
		/// </summary>
		fdRTSpecialName = 1024,
		/// <summary>
		/// Field has marshalling information.
		/// </summary>
		fdHasFieldMarshal = 4096,
		/// <summary>
		/// Field has default.
		/// </summary>
		fdHasDefault = 32768,
		/// <summary>
		/// Field has RVA.
		/// </summary>
		fdHasFieldRVA = 256
	}
	public enum CorParamAttr
	{
		/// <summary>
		/// Param is [In]
		/// </summary>
		pdIn = 1,
		/// <summary>
		/// Param is [out]
		/// </summary>
		pdOut = 2,
		/// <summary>
		/// Param is optional
		/// </summary>
		pdOptional = 16,
		/// <summary>
		/// Reserved flags for Runtime use only.
		/// </summary>
		pdReservedMask = 61440,
		/// <summary>
		/// Param has default value.
		/// </summary>
		pdHasDefault = 4096,
		/// <summary>
		/// Param has FieldMarshal.
		/// </summary>
		pdHasFieldMarshal = 8192,
		pdUnused = 53216
	}
	public enum CorPropertyAttr
	{
		/// <summary>
		/// Property is special.  Name describes how.
		/// </summary>
		prSpecialName = 512,
		/// <summary>
		/// Reserved flags for Runtime use only.
		/// </summary>
		prReservedMask = 62464,
		/// <summary>
		/// Runtime(metadata internal APIs) should check name encoding.
		/// </summary>
		prRTSpecialName = 1024,
		/// <summary>
		/// Property has default
		/// </summary>
		prHasDefault = 4096,
		prUnused = 59903
	}
	public enum CorEventAttr
	{
		/// <summary>
		/// Event is special.  Name describes how.
		/// </summary>
		evSpecialName = 512,
		/// <summary>
		/// Reserved flags for Runtime use only.
		/// </summary>
		evReservedMask = 1024,
		/// <summary>
		/// Runtime(metadata internal APIs) should check name encoding.
		/// </summary>
		evRTSpecialName = 1024
	}
	public enum CorMethodSemanticsAttr
	{
		/// <summary>
		/// Setter for property
		/// </summary>
		msSetter = 1,
		/// <summary>
		/// Getter for property
		/// </summary>
		msGetter = 2,
		/// <summary>
		/// Other method for property or event
		/// </summary>
		msOther = 4,
		/// <summary>
		/// AddOn method for event
		/// </summary>
		msAddOn = 8,
		/// <summary>
		/// RemoveOn method for event
		/// </summary>
		msRemoveOn = 16,
		/// <summary>
		/// Fire method for event
		/// </summary>
		msFire = 32
	}
	public enum CorDeclSecurity
	{
		/// <summary>
		/// Mask allows growth of enum.
		/// </summary>
		dclActionMask = 31,
		dclActionNil = 0,
		dclRequest = 1,
		dclDemand = 2,
		dclAssert = 3,
		dclDeny = 4,
		dclPermitOnly = 5,
		dclLinktimeCheck = 6,
		dclInheritanceCheck = 7,
		dclRequestMinimum = 8,
		dclRequestOptional = 9,
		dclRequestRefuse = 10,
		/// <summary>
		/// Persisted grant set at prejit time
		/// </summary>
		dclPrejitGrant = 11,
		/// <summary>
		/// Persisted denied set at prejit time
		/// </summary>
		dclPrejitDenied = 12,
		dclNonCasDemand = 13,
		dclNonCasLinkDemand = 14,
		dclNonCasInheritance = 15,
		/// <summary>
		/// Maximum legal value
		/// </summary>
		dclMaximumValue = 15
	}
	public enum CorMethodImpl
	{
		/// <summary>
		/// Flags about code type.
		/// </summary>
		miCodeTypeMask = 3,
		/// <summary>
		/// Method impl is IL.
		/// </summary>
		miIL = 0,
		/// <summary>
		/// Method impl is native.
		/// </summary>
		miNative = 1,
		/// <summary>
		/// Method impl is OPTIL
		/// </summary>
		miOPTIL = 2,
		/// <summary>
		/// Method impl is provided by the runtime.
		/// </summary>
		miRuntime = 3,
		/// <summary>
		/// Flags specifying whether the code is managed or unmanaged.
		/// </summary>
		miManagedMask = 4,
		/// <summary>
		/// Method impl is unmanaged, otherwise managed.
		/// </summary>
		miUnmanaged = 4,
		/// <summary>
		/// Method impl is managed.
		/// </summary>
		miManaged = 0,
		/// <summary>
		/// Indicates method is defined; used primarily in merge scenarios.
		/// </summary>
		miForwardRef = 16,
		/// <summary>
		/// Indicates method sig is not to be mangled to do HRESULT conversion.
		/// </summary>
		miPreserveSig = 128,
		/// <summary>
		/// Reserved for internal use.
		/// </summary>
		miInternalCall = 4096,
		/// <summary>
		/// Method is single threaded through the body.
		/// </summary>
		miSynchronized = 32,
		/// <summary>
		/// Method may not be inlined.
		/// </summary>
		miNoInlining = 8,
		/// <summary>
		/// Method should be inlined if possible.
		/// </summary>
		miAggressiveInlining = 256,
		/// <summary>
		/// Method may not be optimized.
		/// </summary>
		miNoOptimization = 64,
		/// <summary>
		/// Method may contain hot code and should be aggressively optimized.
		/// </summary>
		miAggressiveOptimization = 512,
		/// <summary>
		/// These are the flags that are allowed in MethodImplAttribute's Value
		/// property. This should include everything above except the code impl
		/// flags (which are used for MethodImplAttribute's MethodCodeType field).
		/// </summary>
		miUserMask = 5116,
		/// <summary>
		/// Range check value
		/// </summary>
		miMaxMethodImplVal = 65535
	}
	public enum CorPinvokeMap
	{
		/// <summary>
		/// Pinvoke is to use the member name as specified.
		/// </summary>
		pmNoMangle = 1,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmCharSetMask = 6,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmCharSetNotSpec = 0,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmCharSetAnsi = 2,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmCharSetUnicode = 4,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmCharSetAuto = 6,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmBestFitUseAssem = 0,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmBestFitEnabled = 16,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmBestFitDisabled = 32,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmBestFitMask = 48,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmThrowOnUnmappableCharUseAssem = 0,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmThrowOnUnmappableCharEnabled = 4096,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmThrowOnUnmappableCharDisabled = 8192,
		/// <summary>
		/// Use this mask to retrieve the CharSet information.
		/// </summary>
		pmThrowOnUnmappableCharMask = 12288,
		/// <summary>
		/// Information about target function. Not relevant for fields.
		/// </summary>
		pmSupportsLastError = 64,
		/// <summary>
		/// None of the calling convention flags is relevant for fields.
		/// </summary>
		pmCallConvMask = 1792,
		/// <summary>
		/// Pinvoke will use native callconv appropriate to target windows platform.
		/// </summary>
		pmCallConvWinapi = 256,
		pmCallConvCdecl = 512,
		pmCallConvStdcall = 768,
		/// <summary>
		/// In M9, pinvoke will raise exception.
		/// </summary>
		pmCallConvThiscall = 1024,
		pmCallConvFastcall = 1280,
		pmMaxValue = 65535
	}
	public enum CorAssemblyFlags
	{
		/// <summary>
		/// The assembly ref holds the full (unhashed) public key.
		/// </summary>
		afPublicKey = 1,
		/// <summary>
		/// Processor Architecture unspecified
		/// </summary>
		afPA_None = 0,
		/// <summary>
		/// Processor Architecture: neutral (PE32)
		/// </summary>
		afPA_MSIL = 16,
		/// <summary>
		/// Processor Architecture: x86 (PE32)
		/// </summary>
		afPA_x86 = 32,
		/// <summary>
		/// Processor Architecture: Itanium (PE32+)
		/// </summary>
		afPA_IA64 = 48,
		/// <summary>
		/// Processor Architecture: AMD X64 (PE32+)
		/// </summary>
		afPA_AMD64 = 64,
		/// <summary>
		/// Processor Architecture: ARM (PE32)
		/// </summary>
		afPA_ARM = 80,
		/// <summary>
		/// Processor Architecture: ARM64 (PE32+)
		/// </summary>
		afPA_ARM64 = 96,
		/// <summary>
		/// Applies to any platform but cannot run on any (e.g. reference assembly), should not have "specified" set
		/// </summary>
		afPA_NoPlatform = 112,
		/// <summary>
		/// Propagate PA flags to AssemblyRef record
		/// </summary>
		afPA_Specified = 128,
		/// <summary>
		/// Bits describing the processor architecture
		/// </summary>
		afPA_Mask = 112,
		/// <summary>
		/// Bits describing the PA incl. Specified
		/// </summary>
		afPA_FullMask = 240,
		/// <summary>
		/// NOT A FLAG, shift count in PA flags <--> index conversion
		/// </summary>
		afPA_Shift = 4,
		/// <summary>
		/// From "DebuggableAttribute".
		/// </summary>
		afEnableJITcompileTracking = 32768,
		/// <summary>
		/// From "DebuggableAttribute".
		/// </summary>
		afDisableJITcompileOptimizer = 16384,
		afDebuggableAttributeMask = 49152,
		/// <summary>
		/// The assembly can be retargeted (at runtime) to an
		/// assembly from a different publisher.
		/// </summary>
		afRetargetable = 256,
		afContentType_Default = 0,
		afContentType_WindowsRuntime = 512,
		/// <summary>
		/// Bits describing ContentType
		/// </summary>
		afContentType_Mask = 3584
	}
	public enum CorManifestResourceFlags
	{
		mrVisibilityMask = 7,
		/// <summary>
		/// The Resource is exported from the Assembly.
		/// </summary>
		mrPublic = 1,
		/// <summary>
		/// The Resource is private to the Assembly.
		/// </summary>
		mrPrivate = 2
	}
	public enum CorFileFlags
	{
		/// <summary>
		/// This is not a resource file
		/// </summary>
		ffContainsMetaData = 0,
		/// <summary>
		/// This is a resource file or other non-metadata-containing file
		/// </summary>
		ffContainsNoMetaData = 1
	}
	public enum CorPEKind
	{
		/// <summary>
		/// Not a PE file
		/// </summary>
		peNot = 0,
		/// <summary>
		/// Flag IL_ONLY is set in COR header
		/// </summary>
		peILonly = 1,
		/// <summary>
		/// Flag 32BITREQUIRED is set and 32BITPREFERRED is clear in COR header
		/// </summary>
		pe32BitRequired = 2,
		/// <summary>
		/// PE32+ file (64 bit)
		/// </summary>
		pe32Plus = 4,
		/// <summary>
		/// PE32 without COR header
		/// </summary>
		pe32Unmanaged = 8,
		/// <summary>
		/// Flags 32BITREQUIRED and 32BITPREFERRED are set in COR header
		/// </summary>
		pe32BitPreferred = 16
	}
	public enum CorGenericParamAttr
	{
		/// <summary>
		/// Variance of type parameters, only applicable to generic parameters
		/// for generic interfaces and delegates
		/// </summary>
		gpVarianceMask = 3,
		/// <summary>
		/// Variance of type parameters, only applicable to generic parameters
		/// for generic interfaces and delegates
		/// </summary>
		gpNonVariant = 0,
		/// <summary>
		/// Variance of type parameters, only applicable to generic parameters
		/// for generic interfaces and delegates
		/// </summary>
		gpCovariant = 1,
		/// <summary>
		/// Variance of type parameters, only applicable to generic parameters
		/// for generic interfaces and delegates
		/// </summary>
		gpContravariant = 2,
		/// <summary>
		/// Special constraints, applicable to any type parameters
		/// </summary>
		gpSpecialConstraintMask = 28,
		/// <summary>
		/// Special constraints, applicable to any type parameters
		/// </summary>
		gpNoSpecialConstraint = 0,
		/// <summary>
		/// Type argument must be a reference type
		/// </summary>
		gpReferenceTypeConstraint = 4,
		/// <summary>
		/// Type argument must be a value type but not Nullable
		/// </summary>
		gpNotNullableValueTypeConstraint = 8,
		/// <summary>
		/// Type argument must have a public default constructor
		/// </summary>
		gpDefaultConstructorConstraint = 16
	}
	public enum CorElementType
	{
		ELEMENT_TYPE_END = 0,
		ELEMENT_TYPE_VOID = 1,
		ELEMENT_TYPE_BOOLEAN = 2,
		ELEMENT_TYPE_CHAR = 3,
		ELEMENT_TYPE_I1 = 4,
		ELEMENT_TYPE_U1 = 5,
		ELEMENT_TYPE_I2 = 6,
		ELEMENT_TYPE_U2 = 7,
		ELEMENT_TYPE_I4 = 8,
		ELEMENT_TYPE_U4 = 9,
		ELEMENT_TYPE_I8 = 10,
		ELEMENT_TYPE_U8 = 11,
		ELEMENT_TYPE_R4 = 12,
		ELEMENT_TYPE_R8 = 13,
		ELEMENT_TYPE_STRING = 14,
		/// <summary>
		/// PTR <type>
		/// </summary>
		ELEMENT_TYPE_PTR = 15,
		/// <summary>
		/// BYREF <type>
		/// </summary>
		ELEMENT_TYPE_BYREF = 16,
		/// <summary>
		/// VALUETYPE <class Token>
		/// </summary>
		ELEMENT_TYPE_VALUETYPE = 17,
		/// <summary>
		/// CLASS <class Token>
		/// </summary>
		ELEMENT_TYPE_CLASS = 18,
		/// <summary>
		/// A class type variable VAR <number>
		/// </summary>
		ELEMENT_TYPE_VAR = 19,
		/// <summary>
		/// MDARRAY <type> <rank> <bcount> <bound1> ... <lbcount> <lb1> ...
		/// </summary>
		ELEMENT_TYPE_ARRAY = 20,
		/// <summary>
		/// GENERICINST <generic type> <argCnt> <arg1> ... <argn>
		/// </summary>
		ELEMENT_TYPE_GENERICINST = 21,
		/// <summary>
		/// TYPEDREF  (it takes no args) a typed referece to some other type
		/// </summary>
		ELEMENT_TYPE_TYPEDBYREF = 22,
		/// <summary>
		/// Native integer size
		/// </summary>
		ELEMENT_TYPE_I = 24,
		/// <summary>
		/// Native unsigned integer size
		/// </summary>
		ELEMENT_TYPE_U = 25,
		/// <summary>
		/// FNPTR <complete sig for the function including calling convention>
		/// </summary>
		ELEMENT_TYPE_FNPTR = 27,
		/// <summary>
		/// Shortcut for System.Object
		/// </summary>
		ELEMENT_TYPE_OBJECT = 28,
		/// <summary>
		/// Shortcut for single dimension zero lower bound array
		/// SZARRAY <type>
		/// </summary>
		ELEMENT_TYPE_SZARRAY = 29,
		/// <summary>
		/// A method type variable MVAR <number>
		/// </summary>
		ELEMENT_TYPE_MVAR = 30,
		/// <summary>
		/// Required C modifier : E_T_CMOD_REQD <mdTypeRef/mdTypeDef>
		/// </summary>
		ELEMENT_TYPE_CMOD_REQD = 31,
		/// <summary>
		/// Optional C modifier : E_T_CMOD_OPT <mdTypeRef/mdTypeDef>
		/// </summary>
		ELEMENT_TYPE_CMOD_OPT = 32,
		/// <summary>
		/// INTERNAL <typehandle>
		/// </summary>
		ELEMENT_TYPE_INTERNAL = 33,
		/// <summary>
		/// First invalid element type
		/// </summary>
		ELEMENT_TYPE_MAX = 34,
		ELEMENT_TYPE_MODIFIER = 64,
		/// <summary>
		/// Sentinel for varargs
		/// </summary>
		ELEMENT_TYPE_SENTINEL = 65,
		ELEMENT_TYPE_PINNED = 69
	}
	public enum CorSerializationType
	{
		SERIALIZATION_TYPE_UNDEFINED = 0,
		SERIALIZATION_TYPE_BOOLEAN = 2,
		SERIALIZATION_TYPE_CHAR = 3,
		SERIALIZATION_TYPE_I1 = 4,
		SERIALIZATION_TYPE_U1 = 5,
		SERIALIZATION_TYPE_I2 = 6,
		SERIALIZATION_TYPE_U2 = 7,
		SERIALIZATION_TYPE_I4 = 8,
		SERIALIZATION_TYPE_U4 = 9,
		SERIALIZATION_TYPE_I8 = 10,
		SERIALIZATION_TYPE_U8 = 11,
		SERIALIZATION_TYPE_R4 = 12,
		SERIALIZATION_TYPE_R8 = 13,
		SERIALIZATION_TYPE_STRING = 14,
		/// <summary>
		/// Shortcut for single dimension zero lower bound array
		/// </summary>
		SERIALIZATION_TYPE_SZARRAY = 29,
		SERIALIZATION_TYPE_TYPE = 80,
		SERIALIZATION_TYPE_TAGGED_OBJECT = 81,
		SERIALIZATION_TYPE_FIELD = 83,
		SERIALIZATION_TYPE_PROPERTY = 84,
		SERIALIZATION_TYPE_ENUM = 85
	}
	public enum CorUnmanagedCallingConvention
	{
		IMAGE_CEE_UNMANAGED_CALLCONV_C = 1,
		IMAGE_CEE_UNMANAGED_CALLCONV_STDCALL = 2,
		IMAGE_CEE_UNMANAGED_CALLCONV_THISCALL = 3,
		IMAGE_CEE_UNMANAGED_CALLCONV_FASTCALL = 4
	}
	public enum CorCallingConvention
	{
		IMAGE_CEE_CS_CALLCONV_DEFAULT = 0,
		IMAGE_CEE_CS_CALLCONV_C = 1,
		IMAGE_CEE_CS_CALLCONV_STDCALL = 2,
		IMAGE_CEE_CS_CALLCONV_THISCALL = 3,
		IMAGE_CEE_CS_CALLCONV_FASTCALL = 4,
		IMAGE_CEE_CS_CALLCONV_VARARG = 5,
		IMAGE_CEE_CS_CALLCONV_FIELD = 6,
		IMAGE_CEE_CS_CALLCONV_LOCAL_SIG = 7,
		IMAGE_CEE_CS_CALLCONV_PROPERTY = 8,
		/// <summary>
		/// Unmanaged calling convention encoded as modopts
		/// </summary>
		IMAGE_CEE_CS_CALLCONV_UNMANAGED = 9,
		/// <summary>
		/// Generic method instantiation
		/// </summary>
		IMAGE_CEE_CS_CALLCONV_GENERICINST = 10,
		/// <summary>
		/// Used ONLY for 64bit vararg PInvoke calls
		/// </summary>
		IMAGE_CEE_CS_CALLCONV_NATIVEVARARG = 11,
		/// <summary>
		/// First invalid calling convention
		/// </summary>
		IMAGE_CEE_CS_CALLCONV_MAX = 12,
		/// <summary>
		/// Calling convention is bottom 4 bits
		/// </summary>
		IMAGE_CEE_CS_CALLCONV_MASK = 15,
		/// <summary>
		/// Top bit indicates a 'this' parameter
		/// </summary>
		IMAGE_CEE_CS_CALLCONV_HASTHIS = 32,
		/// <summary>
		/// This parameter is explicitly in the signature
		/// </summary>
		IMAGE_CEE_CS_CALLCONV_EXPLICITTHIS = 64,
		/// <summary>
		/// Generic method sig with explicit number of type arguments (precedes ordinary parameter count)
		/// </summary>
		IMAGE_CEE_CS_CALLCONV_GENERIC = 16
	}
	public enum CorArgType
	{
		IMAGE_CEE_CS_END = 0,
		IMAGE_CEE_CS_VOID = 1,
		IMAGE_CEE_CS_I4 = 2,
		IMAGE_CEE_CS_I8 = 3,
		IMAGE_CEE_CS_R4 = 4,
		IMAGE_CEE_CS_R8 = 5,
		IMAGE_CEE_CS_PTR = 6,
		IMAGE_CEE_CS_OBJECT = 7,
		IMAGE_CEE_CS_STRUCT4 = 8,
		IMAGE_CEE_CS_STRUCT32 = 9,
		IMAGE_CEE_CS_BYVALUE = 10
	}
	public enum CorNativeType
	{
		/// <summary>
		/// DEPRECATED
		/// </summary>
		NATIVE_TYPE_END = 0,
		/// <summary>
		/// DEPRECATED
		/// </summary>
		NATIVE_TYPE_VOID = 1,
		/// <summary>
		/// (4 byte boolean value: TRUE = non-zero, FALSE = 0)
		/// </summary>
		NATIVE_TYPE_BOOLEAN = 2,
		NATIVE_TYPE_I1 = 3,
		NATIVE_TYPE_U1 = 4,
		NATIVE_TYPE_I2 = 5,
		NATIVE_TYPE_U2 = 6,
		NATIVE_TYPE_I4 = 7,
		NATIVE_TYPE_U4 = 8,
		NATIVE_TYPE_I8 = 9,
		NATIVE_TYPE_U8 = 10,
		NATIVE_TYPE_R4 = 11,
		NATIVE_TYPE_R8 = 12,
		/// <summary>
		/// DEPRECATED
		/// </summary>
		NATIVE_TYPE_SYSCHAR = 13,
		/// <summary>
		/// DEPRECATED
		/// </summary>
		NATIVE_TYPE_VARIANT = 14,
		NATIVE_TYPE_CURRENCY = 15,
		/// <summary>
		/// DEPRECATED
		/// </summary>
		NATIVE_TYPE_PTR = 16,
		/// <summary>
		/// DEPRECATED
		/// </summary>
		NATIVE_TYPE_DECIMAL = 17,
		/// <summary>
		/// DEPRECATED
		/// </summary>
		NATIVE_TYPE_DATE = 18,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_BSTR = 19,
		NATIVE_TYPE_LPSTR = 20,
		NATIVE_TYPE_LPWSTR = 21,
		NATIVE_TYPE_LPTSTR = 22,
		NATIVE_TYPE_FIXEDSYSSTRING = 23,
		/// <summary>
		/// DEPRECATED
		/// </summary>
		NATIVE_TYPE_OBJECTREF = 24,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_IUNKNOWN = 25,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_IDISPATCH = 26,
		NATIVE_TYPE_STRUCT = 27,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_INTF = 28,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_SAFEARRAY = 29,
		NATIVE_TYPE_FIXEDARRAY = 30,
		NATIVE_TYPE_INT = 31,
		NATIVE_TYPE_UINT = 32,
		/// <summary>
		/// DEPRECATED (use NATIVE_TYPE_STRUCT)
		/// </summary>
		NATIVE_TYPE_NESTEDSTRUCT = 33,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_BYVALSTR = 34,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_ANSIBSTR = 35,
		/// <summary>
		/// Select BSTR or ANSIBSTR depending on platform
		/// </summary>
		NATIVE_TYPE_TBSTR = 36,
		/// <summary>
		/// (2-byte boolean value: TRUE = -1, FALSE = 0)
		/// </summary>
		NATIVE_TYPE_VARIANTBOOL = 37,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_FUNC = 38,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_ASANY = 40,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_ARRAY = 42,
		/// <summary>
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_LPSTRUCT = 43,
		/// <summary>
		/// Custom marshaler native type. This must be followed
		/// by a string of the following format:
		/// "Native type name/0Custom marshaler type name/0Optional cookie/0"
		/// Or
		/// "{Native type GUID}/0Custom marshaler type name/0Optional cookie/0"
		/// </summary>
		NATIVE_TYPE_CUSTOMMARSHALER = 44,
		/// <summary>
		/// This native type coupled with ELEMENT_TYPE_I4 will map to VT_HRESULT
		/// COMINTEROP
		/// </summary>
		NATIVE_TYPE_ERROR = 45,
		NATIVE_TYPE_IINSPECTABLE = 46,
		NATIVE_TYPE_HSTRING = 47,
		/// <summary>
		/// Utf-8 string
		/// </summary>
		NATIVE_TYPE_LPUTF8STR = 48,
		/// <summary>
		/// First invalid element type
		/// </summary>
		NATIVE_TYPE_MAX = 80
	}
	public enum Unknown_94f82e71adac4736ab6f0861b5938bba
	{
		/// <summary>
		/// DESCR group for MethodDefs
		/// </summary>
		DESCR_GROUP_METHODDEF = 0,
		/// <summary>
		/// DESCR group for MethodImpls
		/// </summary>
		DESCR_GROUP_METHODIMPL = 1
	}
	public enum CorILMethodSect
	{
		CorILMethod_Sect_Reserved = 0,
		CorILMethod_Sect_EHTable = 1,
		CorILMethod_Sect_OptILTable = 2,
		/// <summary>
		/// The mask for decoding the type code
		/// </summary>
		CorILMethod_Sect_KindMask = 63,
		/// <summary>
		/// Fat format
		/// </summary>
		CorILMethod_Sect_FatFormat = 64,
		/// <summary>
		/// There is another attribute after this one
		/// </summary>
		CorILMethod_Sect_MoreSects = 128
	}
	public enum CorExceptionFlag
	{
		/// <summary>
		/// This is a typed handler
		/// </summary>
		COR_ILEXCEPTION_CLAUSE_NONE = 0,
		/// <summary>
		/// Deprecated
		/// </summary>
		COR_ILEXCEPTION_CLAUSE_OFFSETLEN = 0,
		/// <summary>
		/// Deprecated
		/// </summary>
		COR_ILEXCEPTION_CLAUSE_DEPRECATED = 0,
		/// <summary>
		/// If this bit is on, then this EH entry is for a filter
		/// </summary>
		COR_ILEXCEPTION_CLAUSE_FILTER = 1,
		/// <summary>
		/// This clause is a finally clause
		/// </summary>
		COR_ILEXCEPTION_CLAUSE_FINALLY = 2,
		/// <summary>
		/// Fault clause (finally that is called on exception only)
		/// </summary>
		COR_ILEXCEPTION_CLAUSE_FAULT = 4,
		/// <summary>
		/// Duplicated clause. This clause was duplicated to a funclet which was pulled out of line
		/// </summary>
		COR_ILEXCEPTION_CLAUSE_DUPLICATED = 8
	}
	public enum CorILMethodFlags
	{
		/// <summary>
		/// Call default constructor on all local vars
		/// </summary>
		CorILMethod_InitLocals = 16,
		/// <summary>
		/// There is another attribute after this one
		/// </summary>
		CorILMethod_MoreSects = 8,
		/// <summary>
		/// Not used.
		/// </summary>
		CorILMethod_CompressedIL = 64,
		/// <summary>
		/// Indicates the format for the COR_ILMETHOD header
		/// </summary>
		CorILMethod_FormatShift = 3,
		/// <summary>
		/// Indicates the format for the COR_ILMETHOD header
		/// </summary>
		CorILMethod_FormatMask = 7,
		/// <summary>
		/// Use this code if the code size is even
		/// </summary>
		CorILMethod_TinyFormat = 2,
		CorILMethod_SmallFormat = 0,
		CorILMethod_FatFormat = 3,
		/// <summary>
		/// Use this code if the code size is odd
		/// </summary>
		CorILMethod_TinyFormat1 = 6
	}
	public enum CorCheckDuplicatesFor
	{
		MDDupAll = -1,
		MDDupENC = -1,
		MDNoDupChecks = 0,
		MDDupTypeDef = 1,
		MDDupInterfaceImpl = 2,
		MDDupMethodDef = 4,
		MDDupTypeRef = 8,
		MDDupMemberRef = 16,
		MDDupCustomAttribute = 32,
		MDDupParamDef = 64,
		MDDupPermission = 128,
		MDDupProperty = 256,
		MDDupEvent = 512,
		MDDupFieldDef = 1024,
		MDDupSignature = 2048,
		MDDupModuleRef = 4096,
		MDDupTypeSpec = 8192,
		MDDupImplMap = 16384,
		MDDupAssemblyRef = 32768,
		MDDupFile = 65536,
		MDDupExportedType = 131072,
		MDDupManifestResource = 262144,
		MDDupGenericParam = 524288,
		MDDupMethodSpec = 1048576,
		MDDupGenericParamConstraint = 2097152,
		/// <summary>
		/// Gap for debug junk
		/// </summary>
		MDDupAssembly = 268435456,
		/// <summary>
		/// This is the default behavior on metadata. It will check duplicates for TypeRef, MemberRef, Signature, TypeSpec and MethodSpec.
		/// </summary>
		MDDupDefault = 1058840
	}
	public enum CorRefToDefCheck
	{
		/// <summary>
		/// Default behavior is to always perform TypeRef to TypeDef and MemberRef to MethodDef/FieldDef optimization
		/// </summary>
		MDRefToDefDefault = 3,
		/// <summary>
		/// Default behavior is to always perform TypeRef to TypeDef and MemberRef to MethodDef/FieldDef optimization
		/// </summary>
		MDRefToDefAll = -1,
		/// <summary>
		/// Default behavior is to always perform TypeRef to TypeDef and MemberRef to MethodDef/FieldDef optimization
		/// </summary>
		MDRefToDefNone = 0,
		/// <summary>
		/// Default behavior is to always perform TypeRef to TypeDef and MemberRef to MethodDef/FieldDef optimization
		/// </summary>
		MDTypeRefToDef = 1,
		/// <summary>
		/// Default behavior is to always perform TypeRef to TypeDef and MemberRef to MethodDef/FieldDef optimization
		/// </summary>
		MDMemberRefToDef = 2
	}
	public enum CorNotificationForTokenMovement
	{
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyDefault = 15,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyAll = -1,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyNone = 0,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyMethodDef = 1,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyMemberRef = 2,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyFieldDef = 4,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyTypeRef = 8,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyTypeDef = 16,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyParamDef = 32,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyInterfaceImpl = 64,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyProperty = 128,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyEvent = 256,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifySignature = 512,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyTypeSpec = 1024,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyCustomAttribute = 2048,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifySecurityValue = 4096,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyPermission = 8192,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyModuleRef = 16384,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyNameSpace = 32768,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyAssemblyRef = 16777216,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyFile = 33554432,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyExportedType = 67108864,
		/// <summary>
		/// Default behavior is to notify TypeRef, MethodDef, MemberRef, and FieldDef token remaps
		/// </summary>
		MDNotifyResource = 134217728
	}
	public enum CorSetENC
	{
		/// <summary>
		/// Deprecated name.
		/// </summary>
		MDSetENCOn = 1,
		/// <summary>
		/// Deprecated name.
		/// </summary>
		MDSetENCOff = 2,
		/// <summary>
		/// ENC mode.  Tokens don't move; can be updated.
		/// </summary>
		MDUpdateENC = 1,
		/// <summary>
		/// "Normal" update mode.
		/// </summary>
		MDUpdateFull = 2,
		/// <summary>
		/// Extension mode.  Tokens don't move, adds only.
		/// </summary>
		MDUpdateExtension = 3,
		/// <summary>
		/// Incremental compilation
		/// </summary>
		MDUpdateIncremental = 4,
		/// <summary>
		/// If ENC on, save only deltas.
		/// </summary>
		MDUpdateDelta = 5,
		MDUpdateMask = 7
	}
	public enum CorErrorIfEmitOutOfOrder
	{
		/// <summary>
		/// Default not to generate any error
		/// </summary>
		MDErrorOutOfOrderDefault = 0,
		/// <summary>
		/// Do not generate error for out of order emit
		/// </summary>
		MDErrorOutOfOrderNone = 0,
		/// <summary>
		/// Generate out of order emit for method, field, param, property, and event
		/// </summary>
		MDErrorOutOfOrderAll = -1,
		/// <summary>
		/// Generate error when methods are emitted out of order
		/// </summary>
		MDMethodOutOfOrder = 1,
		/// <summary>
		/// Generate error when fields are emitted out of order
		/// </summary>
		MDFieldOutOfOrder = 2,
		/// <summary>
		/// Generate error when params are emitted out of order
		/// </summary>
		MDParamOutOfOrder = 4,
		/// <summary>
		/// Generate error when properties are emitted out of order
		/// </summary>
		MDPropertyOutOfOrder = 8,
		/// <summary>
		/// Generate error when events are emitted out of order
		/// </summary>
		MDEventOutOfOrder = 16
	}
	public enum CorImportOptions
	{
		/// <summary>
		/// Default to skip over deleted records
		/// </summary>
		MDImportOptionDefault = 0,
		/// <summary>
		/// Enumerate everything
		/// </summary>
		MDImportOptionAll = -1,
		/// <summary>
		/// All of the typedefs including the deleted typedef
		/// </summary>
		MDImportOptionAllTypeDefs = 1,
		/// <summary>
		/// All of the methoddefs including the deleted ones
		/// </summary>
		MDImportOptionAllMethodDefs = 2,
		/// <summary>
		/// All of the fielddefs including the deleted ones
		/// </summary>
		MDImportOptionAllFieldDefs = 4,
		/// <summary>
		/// All of the properties including the deleted ones
		/// </summary>
		MDImportOptionAllProperties = 8,
		/// <summary>
		/// All of the events including the deleted ones
		/// </summary>
		MDImportOptionAllEvents = 16,
		/// <summary>
		/// All of the custom attributes including the deleted ones
		/// </summary>
		MDImportOptionAllCustomAttributes = 32,
		/// <summary>
		/// All of the ExportedTypes including the deleted ones
		/// </summary>
		MDImportOptionAllExportedTypes = 64
	}
	public enum CorThreadSafetyOptions
	{
		/// <summary>
		/// Default behavior is to have thread safety turn off. This means that MetaData APIs will not take reader/writer
		/// lock. Clients is responsible to make sure the properly thread synchornization when using MetaData APIs.
		/// </summary>
		MDThreadSafetyDefault = 0,
		/// <summary>
		/// Default behavior is to have thread safety turn off. This means that MetaData APIs will not take reader/writer
		/// lock. Clients is responsible to make sure the properly thread synchornization when using MetaData APIs.
		/// </summary>
		MDThreadSafetyOff = 0,
		/// <summary>
		/// Default behavior is to have thread safety turn off. This means that MetaData APIs will not take reader/writer
		/// lock. Clients is responsible to make sure the properly thread synchornization when using MetaData APIs.
		/// </summary>
		MDThreadSafetyOn = 1
	}
	public enum CorLinkerOptions
	{
		/// <summary>
		/// Default behavior is not to keep private types
		/// </summary>
		MDAssembly = 0,
		/// <summary>
		/// Default behavior is not to keep private types
		/// </summary>
		MDNetModule = 1
	}
	public enum MergeFlags
	{
		MergeFlagsNone = 0,
		MergeManifest = 1,
		DropMemberRefCAs = 2,
		NoDupCheck = 4,
		MergeExportedTypes = 8
	}
	public enum CorLocalRefPreservation
	{
		MDPreserveLocalRefsNone = 0,
		MDPreserveLocalTypeRef = 1,
		MDPreserveLocalMemberRef = 2
	}
	public enum CorTokenType
	{
		mdtModule = 0,
		mdtTypeRef = 16777216,
		mdtTypeDef = 33554432,
		mdtFieldDef = 67108864,
		mdtMethodDef = 100663296,
		mdtParamDef = 134217728,
		mdtInterfaceImpl = 150994944,
		mdtMemberRef = 167772160,
		mdtCustomAttribute = 201326592,
		mdtPermission = 234881024,
		mdtSignature = 285212672,
		mdtEvent = 335544320,
		mdtProperty = 385875968,
		mdtMethodImpl = 419430400,
		mdtModuleRef = 436207616,
		mdtTypeSpec = 452984832,
		mdtAssembly = 536870912,
		mdtAssemblyRef = 587202560,
		mdtFile = 637534208,
		mdtExportedType = 654311424,
		mdtManifestResource = 671088640,
		mdtGenericParam = 704643072,
		mdtMethodSpec = 721420288,
		mdtGenericParamConstraint = 738197504,
		mdtString = 1879048192,
		mdtName = 1895825408,
		/// <summary>
		/// Leave this on the high end value. This does not correspond to metadata table
		/// </summary>
		mdtBaseType = 1912602624
	}
	public enum CorOpenFlags
	{
		/// <summary>
		/// Open scope for read
		/// </summary>
		ofRead = 0,
		/// <summary>
		/// Open scope for write.
		/// </summary>
		ofWrite = 1,
		/// <summary>
		/// Mask for read/write bit.
		/// </summary>
		ofReadWriteMask = 1,
		/// <summary>
		/// Open scope with memory. Ask metadata to maintain its own copy of memory.
		/// </summary>
		ofCopyMemory = 2,
		/// <summary>
		/// Open scope for read. Will be unable to QI for a IMetadataEmit* interface
		/// </summary>
		ofReadOnly = 16,
		/// <summary>
		/// The memory was allocated with CoTaskMemAlloc and will be freed by the metadata
		/// </summary>
		ofTakeOwnership = 32,
		/// <summary>
		/// Don't OpenScope on a typelib.
		/// </summary>
		ofNoTypeLib = 128,
		/// <summary>
		/// Disable automatic transforms of .winmd files.
		/// </summary>
		ofNoTransform = 4096,
		/// <summary>
		/// Reserved for internal use.
		/// </summary>
		ofReserved1 = 256,
		/// <summary>
		/// Reserved for internal use.
		/// </summary>
		ofReserved2 = 512,
		/// <summary>
		/// Reserved for internal use.
		/// </summary>
		ofReserved3 = 1024,
		/// <summary>
		/// All the reserved bits.
		/// </summary>
		ofReserved = -4288
	}
	public enum CorFileMapping
	{
		/// <summary>
		/// Flat file mapping - file is mapped as data file (code:SEC_IMAGE flag was not
		/// passed to code:CreateFileMapping).
		/// </summary>
		fmFlat = 0,
		/// <summary>
		/// Executable image file mapping - file is mapped for execution
		/// (either via code:LoadLibrary or code:CreateFileMapping with code:SEC_IMAGE flag).
		/// </summary>
		fmExecutableImage = 1
	}
	public enum CorAttributeTargets
	{
		catAssembly = 1,
		catModule = 2,
		catClass = 4,
		catStruct = 8,
		catEnum = 16,
		catConstructor = 32,
		catMethod = 64,
		catProperty = 128,
		catField = 256,
		catEvent = 512,
		catInterface = 1024,
		catParameter = 2048,
		catDelegate = 4096,
		catGenericParameter = 16384,
		catAll = 24575,
		catClassMembers = 6140
	}
	public enum CompilationRelaxationsEnum
	{
		CompilationRelaxations_NoStringInterning = 8
	}
	public enum NGenHintEnum
	{
		/// <summary>
		/// No preference specified
		/// </summary>
		NGenDefault = 0,
		/// <summary>
		/// NGen at install time
		/// </summary>
		NGenEager = 1,
		/// <summary>
		/// NGen after install time
		/// </summary>
		NGenLazy = 2,
		/// <summary>
		/// Assembly should not be ngened
		/// </summary>
		NGenNever = 3
	}
	public enum LoadHintEnum
	{
		/// <summary>
		/// No preference specified
		/// </summary>
		LoadDefault = 0,
		/// <summary>
		/// Dependency is always loaded
		/// </summary>
		LoadAlways = 1,
		/// <summary>
		/// Dependency is sometimes loaded
		/// </summary>
		LoadSometimes = 2,
		/// <summary>
		/// Dependency is never loaded
		/// </summary>
		LoadNever = 3
	}
	public enum CorSaveSize
	{
		/// <summary>
		/// Find exact save size, accurate but slower.
		/// </summary>
		cssAccurate = 0,
		/// <summary>
		/// Estimate save size, may pad estimate, but faster.
		/// </summary>
		cssQuick = 1,
		/// <summary>
		/// Remove all of the CAs of discardable types
		/// </summary>
		cssDiscardTransientCAs = 2
	}
	public enum NativeTypeArrayFlags
	{
		ntaSizeParamIndexSpecified = 1,
		/// <summary>
		/// All the reserved bits.
		/// </summary>
		ntaReserved = 65534
	}
	public enum CorInfoHFAElemType : uint
	{
		CORINFO_HFA_ELEM_NONE = 0,
		CORINFO_HFA_ELEM_FLOAT = 1,
		CORINFO_HFA_ELEM_DOUBLE = 2,
		CORINFO_HFA_ELEM_VECTOR64 = 3,
		CORINFO_HFA_ELEM_VECTOR128 = 4
	}
	public enum SystemVClassificationType : byte
	{
		SystemVClassificationTypeUnknown = 0,
		SystemVClassificationTypeStruct = 1,
		SystemVClassificationTypeNoClass = 2,
		SystemVClassificationTypeMemory = 3,
		SystemVClassificationTypeInteger = 4,
		SystemVClassificationTypeIntegerReference = 5,
		SystemVClassificationTypeIntegerByRef = 6,
		SystemVClassificationTypeSSE = 7
	}
	public enum ReadyToRunInstructionSet
	{
		READYTORUN_INSTRUCTION_Sse = 1,
		READYTORUN_INSTRUCTION_Sse2 = 2,
		READYTORUN_INSTRUCTION_Sse3 = 3,
		READYTORUN_INSTRUCTION_Ssse3 = 4,
		READYTORUN_INSTRUCTION_Sse41 = 5,
		READYTORUN_INSTRUCTION_Sse42 = 6,
		READYTORUN_INSTRUCTION_Avx = 7,
		READYTORUN_INSTRUCTION_Avx2 = 8,
		READYTORUN_INSTRUCTION_Aes = 9,
		READYTORUN_INSTRUCTION_Bmi1 = 10,
		READYTORUN_INSTRUCTION_Bmi2 = 11,
		READYTORUN_INSTRUCTION_Fma = 12,
		READYTORUN_INSTRUCTION_Lzcnt = 13,
		READYTORUN_INSTRUCTION_Pclmulqdq = 14,
		READYTORUN_INSTRUCTION_Popcnt = 15,
		READYTORUN_INSTRUCTION_ArmBase = 16,
		READYTORUN_INSTRUCTION_AdvSimd = 17,
		READYTORUN_INSTRUCTION_Crc32 = 18,
		READYTORUN_INSTRUCTION_Sha1 = 19,
		READYTORUN_INSTRUCTION_Sha256 = 20,
		READYTORUN_INSTRUCTION_Atomics = 21,
		READYTORUN_INSTRUCTION_X86Base = 22,
		READYTORUN_INSTRUCTION_Dp = 23,
		READYTORUN_INSTRUCTION_Rdm = 24
	}
	public enum CORINFO_InstructionSet
	{
		InstructionSet_ILLEGAL = 0,
		InstructionSet_NONE = 63,
		InstructionSet_X86Base = 1,
		InstructionSet_SSE = 2,
		InstructionSet_SSE2 = 3,
		InstructionSet_SSE3 = 4,
		InstructionSet_SSSE3 = 5,
		InstructionSet_SSE41 = 6,
		InstructionSet_SSE42 = 7,
		InstructionSet_AVX = 8,
		InstructionSet_AVX2 = 9,
		InstructionSet_AES = 10,
		InstructionSet_BMI1 = 11,
		InstructionSet_BMI2 = 12,
		InstructionSet_FMA = 13,
		InstructionSet_LZCNT = 14,
		InstructionSet_PCLMULQDQ = 15,
		InstructionSet_POPCNT = 16,
		InstructionSet_Vector128 = 17,
		InstructionSet_Vector256 = 18,
		InstructionSet_X86Base_X64 = 19,
		InstructionSet_SSE_X64 = 20,
		InstructionSet_SSE2_X64 = 21,
		InstructionSet_SSE3_X64 = 22,
		InstructionSet_SSSE3_X64 = 23,
		InstructionSet_SSE41_X64 = 24,
		InstructionSet_SSE42_X64 = 25,
		InstructionSet_AVX_X64 = 26,
		InstructionSet_AVX2_X64 = 27,
		InstructionSet_AES_X64 = 28,
		InstructionSet_BMI1_X64 = 29,
		InstructionSet_BMI2_X64 = 30,
		InstructionSet_FMA_X64 = 31,
		InstructionSet_LZCNT_X64 = 32,
		InstructionSet_PCLMULQDQ_X64 = 33,
		InstructionSet_POPCNT_X64 = 34
	}
	public enum CorInfoHelpFunc
	{
		/// <summary>
		/// Invalid value. This should never be used
		/// </summary>
		CORINFO_HELP_UNDEF = 0,
		/// <summary>
		/// For the ARM 32-bit integer divide uses a helper call :-(
		/// </summary>
		CORINFO_HELP_DIV = 1,
		CORINFO_HELP_MOD = 2,
		CORINFO_HELP_UDIV = 3,
		CORINFO_HELP_UMOD = 4,
		CORINFO_HELP_LLSH = 5,
		CORINFO_HELP_LRSH = 6,
		CORINFO_HELP_LRSZ = 7,
		CORINFO_HELP_LMUL = 8,
		CORINFO_HELP_LMUL_OVF = 9,
		CORINFO_HELP_ULMUL_OVF = 10,
		CORINFO_HELP_LDIV = 11,
		CORINFO_HELP_LMOD = 12,
		CORINFO_HELP_ULDIV = 13,
		CORINFO_HELP_ULMOD = 14,
		/// <summary>
		/// Convert a signed int64 to a double
		/// </summary>
		CORINFO_HELP_LNG2DBL = 15,
		/// <summary>
		/// Convert a unsigned int64 to a double
		/// </summary>
		CORINFO_HELP_ULNG2DBL = 16,
		CORINFO_HELP_DBL2INT = 17,
		CORINFO_HELP_DBL2INT_OVF = 18,
		CORINFO_HELP_DBL2LNG = 19,
		CORINFO_HELP_DBL2LNG_OVF = 20,
		CORINFO_HELP_DBL2UINT = 21,
		CORINFO_HELP_DBL2UINT_OVF = 22,
		CORINFO_HELP_DBL2ULNG = 23,
		CORINFO_HELP_DBL2ULNG_OVF = 24,
		CORINFO_HELP_FLTREM = 25,
		CORINFO_HELP_DBLREM = 26,
		CORINFO_HELP_FLTROUND = 27,
		CORINFO_HELP_DBLROUND = 28,
		/// <summary>
		/// * Allocating a new object. Always use ICorClassInfo::getNewHelper() to decide
		/// which is the right helper to use to allocate an object of a given type. */
		/// </summary>
		CORINFO_HELP_NEWFAST = 29,
		/// <summary>
		/// Allocator for small, non-finalizer, non-array object
		/// </summary>
		CORINFO_HELP_NEWSFAST = 30,
		/// <summary>
		/// Allocator for small, finalizable, non-array object
		/// </summary>
		CORINFO_HELP_NEWSFAST_FINALIZE = 31,
		/// <summary>
		/// Allocator for small, non-finalizer, non-array object, 8 byte aligned
		/// </summary>
		CORINFO_HELP_NEWSFAST_ALIGN8 = 32,
		/// <summary>
		/// Allocator for small, value class, 8 byte aligned
		/// </summary>
		CORINFO_HELP_NEWSFAST_ALIGN8_VC = 33,
		/// <summary>
		/// Allocator for small, finalizable, non-array object, 8 byte aligned
		/// </summary>
		CORINFO_HELP_NEWSFAST_ALIGN8_FINALIZE = 34,
		/// <summary>
		/// Multi-dim array helper (with or without lower bounds - dimensions passed in as vararg)
		/// </summary>
		CORINFO_HELP_NEW_MDARR = 35,
		/// <summary>
		/// Multi-dim array helper (with or without lower bounds - dimensions passed in as unmanaged array)
		/// </summary>
		CORINFO_HELP_NEW_MDARR_NONVARARG = 36,
		/// <summary>
		/// Helper for any one dimensional array creation
		/// </summary>
		CORINFO_HELP_NEWARR_1_DIRECT = 37,
		/// <summary>
		/// Optimized 1-D object arrays
		/// </summary>
		CORINFO_HELP_NEWARR_1_OBJ = 38,
		/// <summary>
		/// Optimized 1-D value class arrays
		/// </summary>
		CORINFO_HELP_NEWARR_1_VC = 39,
		/// <summary>
		/// Like VC, but aligns the array start
		/// </summary>
		CORINFO_HELP_NEWARR_1_ALIGN8 = 40,
		/// <summary>
		/// Create a new string literal
		/// </summary>
		CORINFO_HELP_STRCNS = 41,
		/// <summary>
		/// Create a new string literal from the current module (used by NGen code)
		/// </summary>
		CORINFO_HELP_STRCNS_CURRENT_MODULE = 42,
		/// <summary>
		/// Initialize class if not already initialized
		/// </summary>
		CORINFO_HELP_INITCLASS = 43,
		/// <summary>
		/// Initialize class for instantiated type
		/// </summary>
		CORINFO_HELP_INITINSTCLASS = 44,
		/// <summary>
		/// Optimized helper for interfaces
		/// </summary>
		CORINFO_HELP_ISINSTANCEOFINTERFACE = 45,
		/// <summary>
		/// Optimized helper for arrays
		/// </summary>
		CORINFO_HELP_ISINSTANCEOFARRAY = 46,
		/// <summary>
		/// Optimized helper for classes
		/// </summary>
		CORINFO_HELP_ISINSTANCEOFCLASS = 47,
		/// <summary>
		/// Slow helper for any type
		/// </summary>
		CORINFO_HELP_ISINSTANCEOFANY = 48,
		CORINFO_HELP_CHKCASTINTERFACE = 49,
		CORINFO_HELP_CHKCASTARRAY = 50,
		CORINFO_HELP_CHKCASTCLASS = 51,
		CORINFO_HELP_CHKCASTANY = 52,
		/// <summary>
		/// Optimized helper for classes. Assumes that the trivial cases
		/// </summary>
		CORINFO_HELP_CHKCASTCLASS_SPECIAL = 53,
		/// <summary>
		/// Has been taken care of by the inlined check
		/// </summary>
		CORINFO_HELP_BOX = 54,
		/// <summary>
		/// Special form of boxing for Nullable<T>
		/// </summary>
		CORINFO_HELP_BOX_NULLABLE = 55,
		CORINFO_HELP_UNBOX = 56,
		/// <summary>
		/// Special form of unboxing for Nullable<T>
		/// </summary>
		CORINFO_HELP_UNBOX_NULLABLE = 57,
		/// <summary>
		/// Extract the byref from a TypedReference, checking that it is the expected type
		/// </summary>
		CORINFO_HELP_GETREFANY = 58,
		/// <summary>
		/// Assign to element of object array with type-checking
		/// </summary>
		CORINFO_HELP_ARRADDR_ST = 59,
		/// <summary>
		/// Does a precise type comparision and returns address
		/// </summary>
		CORINFO_HELP_LDELEMA_REF = 60,
		/// <summary>
		/// Throw an exception object
		/// </summary>
		CORINFO_HELP_THROW = 61,
		/// <summary>
		/// Rethrow the currently active exception
		/// </summary>
		CORINFO_HELP_RETHROW = 62,
		/// <summary>
		/// For a user program to break to the debugger
		/// </summary>
		CORINFO_HELP_USER_BREAKPOINT = 63,
		/// <summary>
		/// Array bounds check failed
		/// </summary>
		CORINFO_HELP_RNGCHKFAIL = 64,
		/// <summary>
		/// Throw an overflow exception
		/// </summary>
		CORINFO_HELP_OVERFLOW = 65,
		/// <summary>
		/// Throw a divide by zero exception
		/// </summary>
		CORINFO_HELP_THROWDIVZERO = 66,
		/// <summary>
		/// Throw a null reference exception
		/// </summary>
		CORINFO_HELP_THROWNULLREF = 67,
		/// <summary>
		/// Throw a VerificationException
		/// </summary>
		CORINFO_HELP_VERIFICATION = 68,
		/// <summary>
		/// Kill the process avoiding any exceptions or stack and data dependencies (use for GuardStack unsafe buffer checks)
		/// </summary>
		CORINFO_HELP_FAIL_FAST = 69,
		/// <summary>
		/// Throw an access exception due to a failed member/class access check.
		/// </summary>
		CORINFO_HELP_METHOD_ACCESS_EXCEPTION = 70,
		CORINFO_HELP_FIELD_ACCESS_EXCEPTION = 71,
		CORINFO_HELP_CLASS_ACCESS_EXCEPTION = 72,
		/// <summary>
		/// Call back into the EE at the end of a catch block
		/// </summary>
		CORINFO_HELP_ENDCATCH = 73,
		/// <summary>
		/// * Synchronization */
		/// </summary>
		CORINFO_HELP_MON_ENTER = 74,
		/// <summary>
		/// * Synchronization */
		/// </summary>
		CORINFO_HELP_MON_EXIT = 75,
		/// <summary>
		/// * Synchronization */
		/// </summary>
		CORINFO_HELP_MON_ENTER_STATIC = 76,
		/// <summary>
		/// * Synchronization */
		/// </summary>
		CORINFO_HELP_MON_EXIT_STATIC = 77,
		/// <summary>
		/// Given a generics method handle, returns a class handle
		/// </summary>
		CORINFO_HELP_GETCLASSFROMMETHODPARAM = 78,
		/// <summary>
		/// Given a generics class handle, returns the sync monitor
		/// in its ManagedClassObject
		/// </summary>
		CORINFO_HELP_GETSYNCFROMCLASSHANDLE = 79,
		/// <summary>
		/// Call GC (force a GC)
		/// </summary>
		CORINFO_HELP_STOP_FOR_GC = 80,
		/// <summary>
		/// Ask GC if it wants to collect
		/// </summary>
		CORINFO_HELP_POLL_GC = 81,
		/// <summary>
		/// Force a GC, but then update the JITTED code to be a noop call
		/// </summary>
		CORINFO_HELP_STRESS_GC = 82,
		/// <summary>
		/// Confirm that ECX is a valid object pointer (debugging only)
		/// </summary>
		CORINFO_HELP_CHECK_OBJ = 83,
		/// <summary>
		/// Universal helpers with F_CALL_CONV calling convention
		/// </summary>
		CORINFO_HELP_ASSIGN_REF = 84,
		CORINFO_HELP_CHECKED_ASSIGN_REF = 85,
		/// <summary>
		/// Do the store, and ensure that the target was not in the heap.
		/// </summary>
		CORINFO_HELP_ASSIGN_REF_ENSURE_NONHEAP = 86,
		CORINFO_HELP_ASSIGN_BYREF = 87,
		CORINFO_HELP_ASSIGN_STRUCT = 88,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELD8 = 89,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_SETFIELD8 = 90,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELD16 = 91,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_SETFIELD16 = 92,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELD32 = 93,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_SETFIELD32 = 94,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELD64 = 95,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_SETFIELD64 = 96,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELDOBJ = 97,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_SETFIELDOBJ = 98,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELDSTRUCT = 99,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_SETFIELDSTRUCT = 100,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELDFLOAT = 101,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_SETFIELDFLOAT = 102,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELDDOUBLE = 103,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_SETFIELDDOUBLE = 104,
		/// <summary>
		/// For COM object support (using COM get/set routines to update object)
		/// and EnC and cross-context support
		/// </summary>
		CORINFO_HELP_GETFIELDADDR = 105,
		/// <summary>
		/// Helper for context-static fields
		/// </summary>
		CORINFO_HELP_GETSTATICFIELDADDR_CONTEXT = 106,
		/// <summary>
		/// Helper for PE TLS fields
		/// </summary>
		CORINFO_HELP_GETSTATICFIELDADDR_TLS = 107,
		/// <summary>
		/// Helpers for regular statics
		/// </summary>
		CORINFO_HELP_GETGENERICS_GCSTATIC_BASE = 108,
		/// <summary>
		/// Helpers for regular statics
		/// </summary>
		CORINFO_HELP_GETGENERICS_NONGCSTATIC_BASE = 109,
		/// <summary>
		/// Helpers for regular statics
		/// </summary>
		CORINFO_HELP_GETSHARED_GCSTATIC_BASE = 110,
		/// <summary>
		/// Helpers for regular statics
		/// </summary>
		CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE = 111,
		/// <summary>
		/// Helpers for regular statics
		/// </summary>
		CORINFO_HELP_GETSHARED_GCSTATIC_BASE_NOCTOR = 112,
		/// <summary>
		/// Helpers for regular statics
		/// </summary>
		CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE_NOCTOR = 113,
		/// <summary>
		/// Helpers for regular statics
		/// </summary>
		CORINFO_HELP_GETSHARED_GCSTATIC_BASE_DYNAMICCLASS = 114,
		/// <summary>
		/// Helpers for regular statics
		/// </summary>
		CORINFO_HELP_GETSHARED_NONGCSTATIC_BASE_DYNAMICCLASS = 115,
		/// <summary>
		/// Helper to class initialize shared generic with dynamicclass, but not get static field address
		/// </summary>
		CORINFO_HELP_CLASSINIT_SHARED_DYNAMICCLASS = 116,
		/// <summary>
		/// Helpers for thread statics
		/// </summary>
		CORINFO_HELP_GETGENERICS_GCTHREADSTATIC_BASE = 117,
		/// <summary>
		/// Helpers for thread statics
		/// </summary>
		CORINFO_HELP_GETGENERICS_NONGCTHREADSTATIC_BASE = 118,
		/// <summary>
		/// Helpers for thread statics
		/// </summary>
		CORINFO_HELP_GETSHARED_GCTHREADSTATIC_BASE = 119,
		/// <summary>
		/// Helpers for thread statics
		/// </summary>
		CORINFO_HELP_GETSHARED_NONGCTHREADSTATIC_BASE = 120,
		/// <summary>
		/// Helpers for thread statics
		/// </summary>
		CORINFO_HELP_GETSHARED_GCTHREADSTATIC_BASE_NOCTOR = 121,
		/// <summary>
		/// Helpers for thread statics
		/// </summary>
		CORINFO_HELP_GETSHARED_NONGCTHREADSTATIC_BASE_NOCTOR = 122,
		/// <summary>
		/// Helpers for thread statics
		/// </summary>
		CORINFO_HELP_GETSHARED_GCTHREADSTATIC_BASE_DYNAMICCLASS = 123,
		/// <summary>
		/// Helpers for thread statics
		/// </summary>
		CORINFO_HELP_GETSHARED_NONGCTHREADSTATIC_BASE_DYNAMICCLASS = 124,
		/// <summary>
		/// Check if this is "JustMyCode" and needs to be stepped through.
		/// </summary>
		CORINFO_HELP_DBG_IS_JUST_MY_CODE = 125,
		/// <summary>
		/// Record the entry to a method (caller)
		/// </summary>
		CORINFO_HELP_PROF_FCN_ENTER = 126,
		/// <summary>
		/// Record the completion of current method (caller)
		/// </summary>
		CORINFO_HELP_PROF_FCN_LEAVE = 127,
		/// <summary>
		/// Record the completion of current method through tailcall (caller)
		/// </summary>
		CORINFO_HELP_PROF_FCN_TAILCALL = 128,
		/// <summary>
		/// Record the entry to a method for collecting Tuning data
		/// </summary>
		CORINFO_HELP_BBT_FCN_ENTER = 129,
		/// <summary>
		/// Indirect pinvoke call
		/// </summary>
		CORINFO_HELP_PINVOKE_CALLI = 130,
		/// <summary>
		/// Perform a tail call
		/// </summary>
		CORINFO_HELP_TAILCALL = 131,
		CORINFO_HELP_GETCURRENTMANAGEDTHREADID = 132,
		/// <summary>
		/// Initialize an inlined PInvoke Frame for the JIT-compiler
		/// </summary>
		CORINFO_HELP_INIT_PINVOKE_FRAME = 133,
		/// <summary>
		/// Init block of memory
		/// </summary>
		CORINFO_HELP_MEMSET = 134,
		/// <summary>
		/// Copy block of memory
		/// </summary>
		CORINFO_HELP_MEMCPY = 135,
		/// <summary>
		/// Determine a type/field/method handle at run-time
		/// </summary>
		CORINFO_HELP_RUNTIMEHANDLE_METHOD = 136,
		/// <summary>
		/// Determine a type/field/method handle at run-time, with IBC logging
		/// </summary>
		CORINFO_HELP_RUNTIMEHANDLE_METHOD_LOG = 137,
		/// <summary>
		/// Determine a type/field/method handle at run-time
		/// </summary>
		CORINFO_HELP_RUNTIMEHANDLE_CLASS = 138,
		/// <summary>
		/// Determine a type/field/method handle at run-time, with IBC logging
		/// </summary>
		CORINFO_HELP_RUNTIMEHANDLE_CLASS_LOG = 139,
		/// <summary>
		/// Convert from a TypeHandle (native structure pointer) to RuntimeType at run-time
		/// </summary>
		CORINFO_HELP_TYPEHANDLE_TO_RUNTIMETYPE = 140,
		/// <summary>
		/// Convert from a TypeHandle (native structure pointer) to RuntimeType at run-time, the type may be null
		/// </summary>
		CORINFO_HELP_TYPEHANDLE_TO_RUNTIMETYPE_MAYBENULL = 141,
		/// <summary>
		/// Convert from a MethodDesc (native structure pointer) to RuntimeMethodHandle at run-time
		/// </summary>
		CORINFO_HELP_METHODDESC_TO_STUBRUNTIMEMETHOD = 142,
		/// <summary>
		/// Convert from a FieldDesc (native structure pointer) to RuntimeFieldHandle at run-time
		/// </summary>
		CORINFO_HELP_FIELDDESC_TO_STUBRUNTIMEFIELD = 143,
		/// <summary>
		/// Convert from a TypeHandle (native structure pointer) to RuntimeTypeHandle at run-time
		/// </summary>
		CORINFO_HELP_TYPEHANDLE_TO_RUNTIMETYPEHANDLE = 144,
		/// <summary>
		/// Convert from a TypeHandle (native structure pointer) to RuntimeTypeHandle at run-time, handle might point to a null type
		/// </summary>
		CORINFO_HELP_TYPEHANDLE_TO_RUNTIMETYPEHANDLE_MAYBENULL = 145,
		/// <summary>
		/// Check whether two TypeHandles (native structure pointers) are equivalent
		/// </summary>
		CORINFO_HELP_ARE_TYPES_EQUIVALENT = 146,
		/// <summary>
		/// Look up a virtual method at run-time
		/// </summary>
		CORINFO_HELP_VIRTUAL_FUNC_PTR = 147,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_NEW = 148,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_NEWARR_1 = 149,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_ISINSTANCEOF = 150,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_CHKCAST = 151,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_STATIC_BASE = 152,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_VIRTUAL_FUNC_PTR = 153,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_GENERIC_HANDLE = 154,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_DELEGATE_CTOR = 155,
		/// <summary>
		/// Not a real helpers. Instead of taking handle arguments, these helpers point to a small stub that loads the handle argument and calls the static helper.
		/// </summary>
		CORINFO_HELP_READYTORUN_GENERIC_STATIC_BASE = 156,
		/// <summary>
		/// Not real JIT helper. Used in native images.
		/// </summary>
		CORINFO_HELP_EE_PRESTUB = 157,
		/// <summary>
		/// Not real JIT helper. Used for Precode fixup in native images.
		/// </summary>
		CORINFO_HELP_EE_PRECODE_FIXUP = 158,
		/// <summary>
		/// Not real JIT helper. Used for PInvoke target fixup in native images.
		/// </summary>
		CORINFO_HELP_EE_PINVOKE_FIXUP = 159,
		/// <summary>
		/// Not real JIT helper. Used for VSD cell fixup in native images.
		/// </summary>
		CORINFO_HELP_EE_VSD_FIXUP = 160,
		/// <summary>
		/// Not real JIT helper. Used for to fixup external method thunks in native images.
		/// </summary>
		CORINFO_HELP_EE_EXTERNAL_FIXUP = 161,
		/// <summary>
		/// Not real JIT helper. Used for inherited vtable slot fixup in native images.
		/// </summary>
		CORINFO_HELP_EE_VTABLE_FIXUP = 162,
		/// <summary>
		/// Not real JIT helper. Used for remoting precode in native images.
		/// </summary>
		CORINFO_HELP_EE_REMOTING_THUNK = 163,
		/// <summary>
		/// Not real JIT helper. Used in native images.
		/// </summary>
		CORINFO_HELP_EE_PERSONALITY_ROUTINE = 164,
		/// <summary>
		/// Not real JIT helper. Used in native images to detect filter funclets.
		/// </summary>
		CORINFO_HELP_EE_PERSONALITY_ROUTINE_FILTER_FUNCLET = 165,
		/// <summary>
		/// EAX holds GC ptr, do a 'mov [EDX], EAX' and inform GC
		/// </summary>
		CORINFO_HELP_ASSIGN_REF_EAX = 166,
		/// <summary>
		/// EBX holds GC ptr, do a 'mov [EDX], EBX' and inform GC
		/// </summary>
		CORINFO_HELP_ASSIGN_REF_EBX = 167,
		/// <summary>
		/// ECX holds GC ptr, do a 'mov [EDX], ECX' and inform GC
		/// </summary>
		CORINFO_HELP_ASSIGN_REF_ECX = 168,
		/// <summary>
		/// ESI holds GC ptr, do a 'mov [EDX], ESI' and inform GC
		/// </summary>
		CORINFO_HELP_ASSIGN_REF_ESI = 169,
		/// <summary>
		/// EDI holds GC ptr, do a 'mov [EDX], EDI' and inform GC
		/// </summary>
		CORINFO_HELP_ASSIGN_REF_EDI = 170,
		/// <summary>
		/// EBP holds GC ptr, do a 'mov [EDX], EBP' and inform GC
		/// </summary>
		CORINFO_HELP_ASSIGN_REF_EBP = 171,
		/// <summary>
		/// These are the same as ASSIGN_REF above ...
		/// </summary>
		CORINFO_HELP_CHECKED_ASSIGN_REF_EAX = 172,
		/// <summary>
		/// ... but also check if EDX points into heap.
		/// </summary>
		CORINFO_HELP_CHECKED_ASSIGN_REF_EBX = 173,
		CORINFO_HELP_CHECKED_ASSIGN_REF_ECX = 174,
		CORINFO_HELP_CHECKED_ASSIGN_REF_ESI = 175,
		CORINFO_HELP_CHECKED_ASSIGN_REF_EDI = 176,
		CORINFO_HELP_CHECKED_ASSIGN_REF_EBP = 177,
		/// <summary>
		/// Return the reference to a counter to decide to take cloned path in debug stress.
		/// </summary>
		CORINFO_HELP_LOOP_CLONE_CHOICE_ADDR = 178,
		/// <summary>
		/// Print a message that a loop cloning optimization has occurred in debug mode.
		/// </summary>
		CORINFO_HELP_DEBUG_LOG_LOOP_CLONING = 179,
		/// <summary>
		/// Throw ArgumentException
		/// </summary>
		CORINFO_HELP_THROW_ARGUMENTEXCEPTION = 180,
		/// <summary>
		/// Throw ArgumentOutOfRangeException
		/// </summary>
		CORINFO_HELP_THROW_ARGUMENTOUTOFRANGEEXCEPTION = 181,
		/// <summary>
		/// Throw NotImplementedException
		/// </summary>
		CORINFO_HELP_THROW_NOT_IMPLEMENTED = 182,
		/// <summary>
		/// Throw PlatformNotSupportedException
		/// </summary>
		CORINFO_HELP_THROW_PLATFORM_NOT_SUPPORTED = 183,
		/// <summary>
		/// Throw TypeNotSupportedException
		/// </summary>
		CORINFO_HELP_THROW_TYPE_NOT_SUPPORTED = 184,
		/// <summary>
		/// Transition to preemptive mode before a P/Invoke, frame is the first argument
		/// </summary>
		CORINFO_HELP_JIT_PINVOKE_BEGIN = 185,
		/// <summary>
		/// Transition to cooperative mode after a P/Invoke, frame is the first argument
		/// </summary>
		CORINFO_HELP_JIT_PINVOKE_END = 186,
		/// <summary>
		/// Transition to cooperative mode in reverse P/Invoke prolog, frame is the first argument
		/// </summary>
		CORINFO_HELP_JIT_REVERSE_PINVOKE_ENTER = 187,
		/// <summary>
		/// Transition to cooperative mode and track transitions in reverse P/Invoke prolog.
		/// </summary>
		CORINFO_HELP_JIT_REVERSE_PINVOKE_ENTER_TRACK_TRANSITIONS = 188,
		/// <summary>
		/// Transition to preemptive mode in reverse P/Invoke epilog, frame is the first argument
		/// </summary>
		CORINFO_HELP_JIT_REVERSE_PINVOKE_EXIT = 189,
		/// <summary>
		/// Transition to preemptive mode and track transitions in reverse P/Invoke prolog.
		/// </summary>
		CORINFO_HELP_JIT_REVERSE_PINVOKE_EXIT_TRACK_TRANSITIONS = 190,
		/// <summary>
		/// Resolve a generic virtual method target from this pointer and runtime method handle
		/// </summary>
		CORINFO_HELP_GVMLOOKUP_FOR_SLOT = 191,
		/// <summary>
		/// Probes each page of the allocated stack frame
		/// </summary>
		CORINFO_HELP_STACK_PROBE = 192,
		/// <summary>
		/// Notify runtime that code has reached a patchpoint
		/// </summary>
		CORINFO_HELP_PATCHPOINT = 193,
		/// <summary>
		/// Update 32-bit class profile for a call site
		/// </summary>
		CORINFO_HELP_CLASSPROFILE32 = 194,
		/// <summary>
		/// Update 64-bit class profile for a call site
		/// </summary>
		CORINFO_HELP_CLASSPROFILE64 = 195,
		CORINFO_HELP_COUNT = 196
	}
	public enum CorInfoHelpSig
	{
		CORINFO_HELP_SIG_UNDEF = 0,
		CORINFO_HELP_SIG_NO_ALIGN_STUB = 1,
		CORINFO_HELP_SIG_NO_UNWIND_STUB = 2,
		CORINFO_HELP_SIG_REG_ONLY = 3,
		CORINFO_HELP_SIG_4_STACK = 4,
		CORINFO_HELP_SIG_8_STACK = 5,
		CORINFO_HELP_SIG_12_STACK = 6,
		CORINFO_HELP_SIG_16_STACK = 7,
		/// <summary>
		/// 2 arguments plus varargs
		/// </summary>
		CORINFO_HELP_SIG_8_VA = 8,
		/// <summary>
		/// Special calling convention that uses EDX and
		/// EBP as arguments
		/// </summary>
		CORINFO_HELP_SIG_EBPCALL = 9,
		CORINFO_HELP_SIG_CANNOT_USE_ALIGN_STUB = 10,
		CORINFO_HELP_SIG_COUNT = 11
	}
	public enum CorInfoType
	{
		CORINFO_TYPE_UNDEF = 0,
		CORINFO_TYPE_VOID = 1,
		CORINFO_TYPE_BOOL = 2,
		CORINFO_TYPE_CHAR = 3,
		CORINFO_TYPE_BYTE = 4,
		CORINFO_TYPE_UBYTE = 5,
		CORINFO_TYPE_SHORT = 6,
		CORINFO_TYPE_USHORT = 7,
		CORINFO_TYPE_INT = 8,
		CORINFO_TYPE_UINT = 9,
		CORINFO_TYPE_LONG = 10,
		CORINFO_TYPE_ULONG = 11,
		CORINFO_TYPE_NATIVEINT = 12,
		CORINFO_TYPE_NATIVEUINT = 13,
		CORINFO_TYPE_FLOAT = 14,
		CORINFO_TYPE_DOUBLE = 15,
		/// <summary>
		/// Not used, should remove
		/// </summary>
		CORINFO_TYPE_STRING = 16,
		CORINFO_TYPE_PTR = 17,
		CORINFO_TYPE_BYREF = 18,
		CORINFO_TYPE_VALUECLASS = 19,
		CORINFO_TYPE_CLASS = 20,
		CORINFO_TYPE_REFANY = 21,
		/// <summary>
		/// CORINFO_TYPE_VAR is for a generic type variable.
		/// Generic type variables only appear when the JIT is doing
		/// verification (not NOT compilation) of generic code
		/// for the EE, in which case we're running
		/// the JIT in "import only" mode.
		/// </summary>
		CORINFO_TYPE_VAR = 22,
		/// <summary>
		/// Number of jit types
		/// </summary>
		CORINFO_TYPE_COUNT = 23
	}
	public enum CorInfoTypeWithMod
	{
		/// <summary>
		/// Lower 6 bits are type mask
		/// </summary>
		CORINFO_TYPE_MASK = 63,
		/// <summary>
		/// Can be applied to CLASS, or BYREF to indicate pinned
		/// </summary>
		CORINFO_TYPE_MOD_PINNED = 64
	}
	public enum CorInfoCallConv
	{
		/// <summary>
		/// These correspond to CorCallingConvention
		/// </summary>
		CORINFO_CALLCONV_DEFAULT = 0,
		/// <summary>
		/// Instead of using the below values, use the CorInfoCallConvExtension enum for unmanaged calling conventions.
		/// CORINFO_CALLCONV_C          = 0x1,
		/// CORINFO_CALLCONV_STDCALL    = 0x2,
		/// CORINFO_CALLCONV_THISCALL   = 0x3,
		/// CORINFO_CALLCONV_FASTCALL   = 0x4,
		/// </summary>
		CORINFO_CALLCONV_VARARG = 5,
		/// <summary>
		/// Instead of using the below values, use the CorInfoCallConvExtension enum for unmanaged calling conventions.
		/// CORINFO_CALLCONV_C          = 0x1,
		/// CORINFO_CALLCONV_STDCALL    = 0x2,
		/// CORINFO_CALLCONV_THISCALL   = 0x3,
		/// CORINFO_CALLCONV_FASTCALL   = 0x4,
		/// </summary>
		CORINFO_CALLCONV_FIELD = 6,
		/// <summary>
		/// Instead of using the below values, use the CorInfoCallConvExtension enum for unmanaged calling conventions.
		/// CORINFO_CALLCONV_C          = 0x1,
		/// CORINFO_CALLCONV_STDCALL    = 0x2,
		/// CORINFO_CALLCONV_THISCALL   = 0x3,
		/// CORINFO_CALLCONV_FASTCALL   = 0x4,
		/// </summary>
		CORINFO_CALLCONV_LOCAL_SIG = 7,
		/// <summary>
		/// Instead of using the below values, use the CorInfoCallConvExtension enum for unmanaged calling conventions.
		/// CORINFO_CALLCONV_C          = 0x1,
		/// CORINFO_CALLCONV_STDCALL    = 0x2,
		/// CORINFO_CALLCONV_THISCALL   = 0x3,
		/// CORINFO_CALLCONV_FASTCALL   = 0x4,
		/// </summary>
		CORINFO_CALLCONV_PROPERTY = 8,
		/// <summary>
		/// Instead of using the below values, use the CorInfoCallConvExtension enum for unmanaged calling conventions.
		/// CORINFO_CALLCONV_C          = 0x1,
		/// CORINFO_CALLCONV_STDCALL    = 0x2,
		/// CORINFO_CALLCONV_THISCALL   = 0x3,
		/// CORINFO_CALLCONV_FASTCALL   = 0x4,
		/// </summary>
		CORINFO_CALLCONV_UNMANAGED = 9,
		/// <summary>
		/// Used ONLY for IL stub PInvoke vararg calls
		/// </summary>
		CORINFO_CALLCONV_NATIVEVARARG = 11,
		/// <summary>
		/// Calling convention is bottom 4 bits
		/// </summary>
		CORINFO_CALLCONV_MASK = 15,
		CORINFO_CALLCONV_GENERIC = 16,
		CORINFO_CALLCONV_HASTHIS = 32,
		CORINFO_CALLCONV_EXPLICITTHIS = 64,
		/// <summary>
		/// Passed last. Same as CORINFO_GENERICS_CTXT_FROM_PARAMTYPEARG
		/// </summary>
		CORINFO_CALLCONV_PARAMTYPE = 128
	}
	public enum CorInfoCallConvExtension
	{
		Managed = 0,
		C = 1,
		Stdcall = 2,
		Thiscall = 3,
		Fastcall = 4,
		/// <summary>
		/// New calling conventions supported with the extensible calling convention encoding go here.
		/// </summary>
		CMemberFunction = 5,
		/// <summary>
		/// New calling conventions supported with the extensible calling convention encoding go here.
		/// </summary>
		StdcallMemberFunction = 6,
		/// <summary>
		/// New calling conventions supported with the extensible calling convention encoding go here.
		/// </summary>
		FastcallMemberFunction = 7
	}
	public enum CorInfoOptions
	{
		/// <summary>
		/// Zero initialize all variables
		/// </summary>
		CORINFO_OPT_INIT_LOCALS = 16,
		/// <summary>
		/// Is this shared generic code that access the generic context from the this pointer?  If so, then if the method has SEH then the 'this' pointer must always be reported and kept alive.
		/// </summary>
		CORINFO_GENERICS_CTXT_FROM_THIS = 32,
		/// <summary>
		/// Is this shared generic code that access the generic context from the ParamTypeArg(that is a MethodDesc)?  If so, then if the method has SEH then the 'ParamTypeArg' must always be reported and kept alive. Same as CORINFO_CALLCONV_PARAMTYPE
		/// </summary>
		CORINFO_GENERICS_CTXT_FROM_METHODDESC = 64,
		/// <summary>
		/// Is this shared generic code that access the generic context from the ParamTypeArg(that is a MethodTable)?  If so, then if the method has SEH then the 'ParamTypeArg' must always be reported and kept alive. Same as CORINFO_CALLCONV_PARAMTYPE
		/// </summary>
		CORINFO_GENERICS_CTXT_FROM_METHODTABLE = 128,
		CORINFO_GENERICS_CTXT_MASK = 224,
		/// <summary>
		/// Keep the generics context alive throughout the method even if there is no explicit use, and report its location to the CLR
		/// </summary>
		CORINFO_GENERICS_CTXT_KEEP_ALIVE = 256
	}
	public enum CorInfoRegionKind
	{
		CORINFO_REGION_NONE = 0,
		CORINFO_REGION_HOT = 1,
		CORINFO_REGION_COLD = 2,
		CORINFO_REGION_JIT = 3
	}
	public enum CorInfoFlag
	{
		/// <summary>
		/// CORINFO_FLG_UNUSED                = 0x00000001,
		/// CORINFO_FLG_UNUSED                = 0x00000002,
		/// </summary>
		CORINFO_FLG_PROTECTED = 4,
		/// <summary>
		/// CORINFO_FLG_UNUSED                = 0x00000001,
		/// CORINFO_FLG_UNUSED                = 0x00000002,
		/// </summary>
		CORINFO_FLG_STATIC = 8,
		/// <summary>
		/// CORINFO_FLG_UNUSED                = 0x00000001,
		/// CORINFO_FLG_UNUSED                = 0x00000002,
		/// </summary>
		CORINFO_FLG_FINAL = 16,
		/// <summary>
		/// CORINFO_FLG_UNUSED                = 0x00000001,
		/// CORINFO_FLG_UNUSED                = 0x00000002,
		/// </summary>
		CORINFO_FLG_SYNCH = 32,
		/// <summary>
		/// CORINFO_FLG_UNUSED                = 0x00000001,
		/// CORINFO_FLG_UNUSED                = 0x00000002,
		/// </summary>
		CORINFO_FLG_VIRTUAL = 64,
		/// <summary>
		/// CORINFO_FLG_UNUSED                = 0x00000080,
		/// </summary>
		CORINFO_FLG_NATIVE = 256,
		/// <summary>
		/// This type is marked by [Intrinsic]
		/// </summary>
		CORINFO_FLG_INTRINSIC_TYPE = 512,
		CORINFO_FLG_ABSTRACT = 1024,
		/// <summary>
		/// Member was added by Edit'n'Continue
		/// </summary>
		CORINFO_FLG_EnC = 2048,
		/// <summary>
		/// The method should be inlined if possible.
		/// </summary>
		CORINFO_FLG_FORCEINLINE = 65536,
		/// <summary>
		/// The code for this method is shared between different generic instantiations (also set on classes/types)
		/// </summary>
		CORINFO_FLG_SHAREDINST = 131072,
		/// <summary>
		/// "Delegate
		/// </summary>
		CORINFO_FLG_DELEGATE_INVOKE = 262144,
		/// <summary>
		/// Is a P/Invoke call
		/// </summary>
		CORINFO_FLG_PINVOKE = 524288,
		/// <summary>
		/// This method is FCALL that has no GC check.  Don't put alone in loops
		/// </summary>
		CORINFO_FLG_NOGCCHECK = 2097152,
		/// <summary>
		/// This method MAY have an intrinsic ID
		/// </summary>
		CORINFO_FLG_INTRINSIC = 4194304,
		/// <summary>
		/// This method is an instance or type initializer
		/// </summary>
		CORINFO_FLG_CONSTRUCTOR = 8388608,
		/// <summary>
		/// The method may contain hot code and should be aggressively optimized if possible
		/// </summary>
		CORINFO_FLG_AGGRESSIVE_OPT = 16777216,
		/// <summary>
		/// Indicates that tier 0 JIT should not be used for a method that contains a loop
		/// </summary>
		CORINFO_FLG_DISABLE_TIER0_FOR_LOOPS = 33554432,
		/// <summary>
		/// The method should not be inlined
		/// </summary>
		CORINFO_FLG_DONT_INLINE = 268435456,
		/// <summary>
		/// The method should not be inlined, nor should its callers. It cannot be tail called.
		/// </summary>
		CORINFO_FLG_DONT_INLINE_CALLER = 536870912,
		/// <summary>
		/// Method is a potential jit intrinsic; verify identity by name check
		/// </summary>
		CORINFO_FLG_JIT_INTRINSIC = 1073741824,
		/// <summary>
		/// Is the class a value class
		/// </summary>
		CORINFO_FLG_VALUECLASS = 65536,
		/// <summary>
		/// The object size varies depending of constructor args
		/// </summary>
		CORINFO_FLG_VAROBJSIZE = 262144,
		/// <summary>
		/// Class is an array class (initialized differently)
		/// </summary>
		CORINFO_FLG_ARRAY = 524288,
		/// <summary>
		/// Struct or class has fields that overlap (aka union)
		/// </summary>
		CORINFO_FLG_OVERLAPPING_FIELDS = 1048576,
		/// <summary>
		/// It is an interface
		/// </summary>
		CORINFO_FLG_INTERFACE = 2097152,
		/// <summary>
		/// Don't try to promote fields (used for types outside of AOT compilation version bubble)
		/// </summary>
		CORINFO_FLG_DONT_PROMOTE = 4194304,
		/// <summary>
		/// Does this struct have custom layout?
		/// </summary>
		CORINFO_FLG_CUSTOMLAYOUT = 8388608,
		/// <summary>
		/// Does the class contain a gc ptr ?
		/// </summary>
		CORINFO_FLG_CONTAINS_GC_PTR = 16777216,
		/// <summary>
		/// Is this a subclass of delegate or multicast delegate ?
		/// </summary>
		CORINFO_FLG_DELEGATE = 33554432,
		/// <summary>
		/// This class has a stack pointer inside it
		/// </summary>
		CORINFO_FLG_CONTAINS_STACK_PTR = 134217728,
		/// <summary>
		/// MethodTable::HasVariance (sealed does *not* mean uncast-able)
		/// </summary>
		CORINFO_FLG_VARIANCE = 268435456,
		/// <summary>
		/// Additional flexibility for when to run .cctor (see code:#ClassConstructionFlags)
		/// </summary>
		CORINFO_FLG_BEFOREFIELDINIT = 536870912,
		/// <summary>
		/// This is really a handle for a variable type
		/// </summary>
		CORINFO_FLG_GENERIC_TYPE_VARIABLE = 1073741824,
		/// <summary>
		/// Unsafe (C++'s /GS) value type
		/// </summary>
		CORINFO_FLG_UNSAFE_VALUECLASS = -2147483648
	}
	public enum CorInfoMethodRuntimeFlags
	{
		/// <summary>
		/// The method is not suitable for inlining
		/// </summary>
		CORINFO_FLG_BAD_INLINEE = 1,
		/// <summary>
		/// The JIT decided to switch to MinOpt for this method, when it was not requested
		/// </summary>
		CORINFO_FLG_SWITCHED_TO_MIN_OPT = 8,
		/// <summary>
		/// The JIT decided to switch to tier 1 for this method, when a different tier was requested
		/// </summary>
		CORINFO_FLG_SWITCHED_TO_OPTIMIZED = 16
	}
	public enum CORINFO_ACCESS_FLAGS
	{
		/// <summary>
		/// Normal access
		/// </summary>
		CORINFO_ACCESS_ANY = 0,
		/// <summary>
		/// Accessed via the this reference
		/// </summary>
		CORINFO_ACCESS_THIS = 1,
		/// <summary>
		/// Instance is guaranteed non-null
		/// </summary>
		CORINFO_ACCESS_NONNULL = 4,
		/// <summary>
		/// Accessed via ldftn
		/// </summary>
		CORINFO_ACCESS_LDFTN = 16,
		/// <summary>
		/// Field get (ldfld)
		/// </summary>
		CORINFO_ACCESS_GET = 256,
		/// <summary>
		/// Field set (stfld)
		/// </summary>
		CORINFO_ACCESS_SET = 512,
		/// <summary>
		/// Field address (ldflda)
		/// </summary>
		CORINFO_ACCESS_ADDRESS = 1024,
		/// <summary>
		/// Field use for InitializeArray
		/// </summary>
		CORINFO_ACCESS_INIT_ARRAY = 2048,
		/// <summary>
		/// Return fieldFlags and fieldAccessor only. Used by JIT64 during inlining.
		/// </summary>
		CORINFO_ACCESS_INLINECHECK = 32768
	}
	public enum CORINFO_EH_CLAUSE_FLAGS
	{
		CORINFO_EH_CLAUSE_NONE = 0,
		/// <summary>
		/// If this bit is on, then this EH entry is for a filter
		/// </summary>
		CORINFO_EH_CLAUSE_FILTER = 1,
		/// <summary>
		/// This clause is a finally clause
		/// </summary>
		CORINFO_EH_CLAUSE_FINALLY = 2,
		/// <summary>
		/// This clause is a fault clause
		/// </summary>
		CORINFO_EH_CLAUSE_FAULT = 4,
		/// <summary>
		/// Duplicated clause. This clause was duplicated to a funclet which was pulled out of line
		/// </summary>
		CORINFO_EH_CLAUSE_DUPLICATE = 8,
		/// <summary>
		/// This clause covers same try block as the previous one. (Used by CoreRT ABI.)
		/// </summary>
		CORINFO_EH_CLAUSE_SAMETRY = 16
	}
	public enum CorInfoException
	{
		CORINFO_NullReferenceException = 0,
		CORINFO_DivideByZeroException = 1,
		CORINFO_InvalidCastException = 2,
		CORINFO_IndexOutOfRangeException = 3,
		CORINFO_OverflowException = 4,
		CORINFO_SynchronizationLockException = 5,
		CORINFO_ArrayTypeMismatchException = 6,
		CORINFO_RankException = 7,
		CORINFO_ArgumentNullException = 8,
		CORINFO_ArgumentException = 9,
		CORINFO_Exception_Count = 10
	}
	public enum CorInfoIntrinsics
	{
		/// <summary>
		/// Get the value of an element in an array
		/// </summary>
		CORINFO_INTRINSIC_Array_Get = 0,
		/// <summary>
		/// Get the address of an element in an array
		/// </summary>
		CORINFO_INTRINSIC_Array_Address = 1,
		/// <summary>
		/// Set the value of an element in an array
		/// </summary>
		CORINFO_INTRINSIC_Array_Set = 2,
		/// <summary>
		/// Initialize an array from static data
		/// </summary>
		CORINFO_INTRINSIC_InitializeArray = 3,
		CORINFO_INTRINSIC_RTH_GetValueInternal = 4,
		CORINFO_INTRINSIC_Object_GetType = 5,
		CORINFO_INTRINSIC_StubHelpers_GetStubContext = 6,
		CORINFO_INTRINSIC_StubHelpers_GetStubContextAddr = 7,
		CORINFO_INTRINSIC_StubHelpers_NextCallReturnAddress = 8,
		CORINFO_INTRINSIC_InterlockedAdd32 = 9,
		CORINFO_INTRINSIC_InterlockedAdd64 = 10,
		CORINFO_INTRINSIC_InterlockedXAdd32 = 11,
		CORINFO_INTRINSIC_InterlockedXAdd64 = 12,
		CORINFO_INTRINSIC_InterlockedXchg32 = 13,
		CORINFO_INTRINSIC_InterlockedXchg64 = 14,
		CORINFO_INTRINSIC_InterlockedCmpXchg32 = 15,
		CORINFO_INTRINSIC_InterlockedCmpXchg64 = 16,
		CORINFO_INTRINSIC_MemoryBarrier = 17,
		CORINFO_INTRINSIC_MemoryBarrierLoad = 18,
		CORINFO_INTRINSIC_ByReference_Ctor = 19,
		CORINFO_INTRINSIC_ByReference_Value = 20,
		CORINFO_INTRINSIC_GetRawHandle = 21,
		CORINFO_INTRINSIC_Count = 22,
		/// <summary>
		/// Not a true intrinsic,
		/// </summary>
		CORINFO_INTRINSIC_Illegal = -1
	}
	public enum InfoAccessType
	{
		/// <summary>
		/// The info value is directly available
		/// </summary>
		IAT_VALUE = 0,
		/// <summary>
		/// The value needs to be accessed via an         indirection
		/// </summary>
		IAT_PVALUE = 1,
		/// <summary>
		/// The value needs to be accessed via a double   indirection
		/// </summary>
		IAT_PPVALUE = 2,
		/// <summary>
		/// The value needs to be accessed via a relative indirection
		/// </summary>
		IAT_RELPVALUE = 3
	}
	public enum CorInfoGCType
	{
		/// <summary>
		/// No embedded objectrefs
		/// </summary>
		TYPE_GC_NONE = 0,
		/// <summary>
		/// Is an object ref
		/// </summary>
		TYPE_GC_REF = 1,
		/// <summary>
		/// Is an interior pointer - promote it but don't scan it
		/// </summary>
		TYPE_GC_BYREF = 2,
		/// <summary>
		/// Requires type-specific treatment
		/// </summary>
		TYPE_GC_OTHER = 3
	}
	public enum CorInfoClassId
	{
		CLASSID_SYSTEM_OBJECT = 0,
		CLASSID_TYPED_BYREF = 1,
		CLASSID_TYPE_HANDLE = 2,
		CLASSID_FIELD_HANDLE = 3,
		CLASSID_METHOD_HANDLE = 4,
		CLASSID_STRING = 5,
		CLASSID_ARGUMENT_HANDLE = 6,
		CLASSID_RUNTIME_TYPE = 7
	}
	public enum CorInfoInline
	{
		/// <summary>
		/// Inlining OK
		/// </summary>
		INLINE_PASS = 0,
		/// <summary>
		/// Inlining not OK for this case only
		/// </summary>
		INLINE_FAIL = -1,
		/// <summary>
		/// This method should never be inlined, regardless of context
		/// </summary>
		INLINE_NEVER = -2
	}
	public enum CorInfoInlineRestrictions
	{
		/// <summary>
		/// You can inline if there are no calls from the method being inlined
		/// </summary>
		INLINE_RESPECT_BOUNDARY = 1,
		/// <summary>
		/// You can inline only if you guarantee that if inlinee does an ldstr
		/// inlinee's module will never see that string (by any means).
		/// This is due to how we implement the NoStringInterningAttribute
		/// (by reusing the fixup table).
		/// </summary>
		INLINE_NO_CALLEE_LDSTR = 2,
		/// <summary>
		/// You can inline only if the callee is on the same this reference as caller
		/// </summary>
		INLINE_SAME_THIS = 4
	}
	public enum CorInfoInlineTypeCheck
	{
		/// <summary>
		/// It's not okay to compare type's vtable with a native type handle
		/// </summary>
		CORINFO_INLINE_TYPECHECK_NONE = 0,
		/// <summary>
		/// It's okay to compare type's vtable with a native type handle
		/// </summary>
		CORINFO_INLINE_TYPECHECK_PASS = 1,
		/// <summary>
		/// Use a specialized helper to compare type's vtable with native type handle
		/// </summary>
		CORINFO_INLINE_TYPECHECK_USE_HELPER = 2
	}
	public enum CorInfoInlineTypeCheckSource
	{
		/// <summary>
		/// Type handle comes from the vtable
		/// </summary>
		CORINFO_INLINE_TYPECHECK_SOURCE_VTABLE = 0,
		/// <summary>
		/// Type handle comes from an ldtoken
		/// </summary>
		CORINFO_INLINE_TYPECHECK_SOURCE_TOKEN = 1
	}
	public enum CorInfoTailCall
	{
		/// <summary>
		/// Optimized tail call (epilog + jmp)
		/// </summary>
		TAILCALL_OPTIMIZED = 0,
		/// <summary>
		/// Optimized into a loop (only when a method tail calls itself)
		/// </summary>
		TAILCALL_RECURSIVE = 1,
		/// <summary>
		/// Helper assisted tail call (call to JIT_TailCall)
		/// </summary>
		TAILCALL_HELPER = 2,
		/// <summary>
		/// Couldn't do a tail call
		/// </summary>
		TAILCALL_FAIL = -1
	}
	public enum CorInfoInitClassResult
	{
		/// <summary>
		/// No class initialization required, but the class is not actually initialized yet
		/// (e.g. we are guaranteed to run the static constructor in method prolog)
		/// </summary>
		CORINFO_INITCLASS_NOT_REQUIRED = 0,
		/// <summary>
		/// Class initialized
		/// </summary>
		CORINFO_INITCLASS_INITIALIZED = 1,
		/// <summary>
		/// The JIT must insert class initialization helper call.
		/// </summary>
		CORINFO_INITCLASS_USE_HELPER = 2,
		/// <summary>
		/// The JIT should not inline the method requesting the class initialization. The class
		/// initialization requires helper class now, but will not require initialization
		/// if the method is compiled standalone. Or the method cannot be inlined due to some
		/// requirement around class initialization such as shared generics.
		/// </summary>
		CORINFO_INITCLASS_DONT_INLINE = 4
	}
	public enum CorInfoIndirectCallReason
	{
		CORINFO_INDIRECT_CALL_UNKNOWN = 0,
		CORINFO_INDIRECT_CALL_EXOTIC = 1,
		CORINFO_INDIRECT_CALL_PINVOKE = 2,
		CORINFO_INDIRECT_CALL_GENERIC = 3,
		CORINFO_INDIRECT_CALL_NO_CODE = 4,
		CORINFO_INDIRECT_CALL_FIXUPS = 5,
		CORINFO_INDIRECT_CALL_STUB = 6,
		CORINFO_INDIRECT_CALL_REMOTING = 7,
		CORINFO_INDIRECT_CALL_CER = 8,
		CORINFO_INDIRECT_CALL_RESTORE_METHOD = 9,
		CORINFO_INDIRECT_CALL_RESTORE_FIRST_CALL = 10,
		CORINFO_INDIRECT_CALL_RESTORE_VALUE_TYPE = 11,
		CORINFO_INDIRECT_CALL_RESTORE = 12,
		CORINFO_INDIRECT_CALL_CANT_PATCH = 13,
		CORINFO_INDIRECT_CALL_PROFILING = 14,
		CORINFO_INDIRECT_CALL_OTHER_LOADER_MODULE = 15,
		CORINFO_INDIRECT_CALL_COUNT = 16
	}
	public enum CorInfoContextFlags
	{
		/// <summary>
		/// CORINFO_CONTEXT_HANDLE is really a CORINFO_METHOD_HANDLE
		/// </summary>
		CORINFO_CONTEXTFLAGS_METHOD = 0,
		/// <summary>
		/// CORINFO_CONTEXT_HANDLE is really a CORINFO_CLASS_HANDLE
		/// </summary>
		CORINFO_CONTEXTFLAGS_CLASS = 1,
		CORINFO_CONTEXTFLAGS_MASK = 1
	}
	public enum CorInfoSigInfoFlags
	{
		CORINFO_SIGFLAG_IS_LOCAL_SIG = 1,
		CORINFO_SIGFLAG_IL_STUB = 2,
		/// <summary>
		/// Unused                              = 0x04,
		/// </summary>
		CORINFO_SIGFLAG_FAT_CALL = 8
	}
	public enum CORINFO_RUNTIME_LOOKUP_KIND
	{
		CORINFO_LOOKUP_THISOBJ = 0,
		CORINFO_LOOKUP_METHODPARAM = 1,
		CORINFO_LOOKUP_CLASSPARAM = 2,
		/// <summary>
		/// Returned for attempts to inline dictionary lookups
		/// </summary>
		CORINFO_LOOKUP_NOT_SUPPORTED = 3
	}
	public enum CorInfoGenericHandleType
	{
		CORINFO_HANDLETYPE_UNKNOWN = 0,
		CORINFO_HANDLETYPE_CLASS = 1,
		CORINFO_HANDLETYPE_METHOD = 2,
		CORINFO_HANDLETYPE_FIELD = 3
	}
	public enum CorInfoAccessAllowedHelperArgType
	{
		CORINFO_HELPER_ARG_TYPE_Invalid = 0,
		CORINFO_HELPER_ARG_TYPE_Field = 1,
		CORINFO_HELPER_ARG_TYPE_Method = 2,
		CORINFO_HELPER_ARG_TYPE_Class = 3,
		CORINFO_HELPER_ARG_TYPE_Module = 4,
		CORINFO_HELPER_ARG_TYPE_Const = 5
	}
	public enum CORINFO_CALL_KIND
	{
		CORINFO_CALL = 0,
		CORINFO_CALL_CODE_POINTER = 1,
		CORINFO_VIRTUALCALL_STUB = 2,
		CORINFO_VIRTUALCALL_LDVIRTFTN = 3,
		CORINFO_VIRTUALCALL_VTABLE = 4
	}
	public enum CORINFO_THIS_TRANSFORM
	{
		CORINFO_NO_THIS_TRANSFORM = 0,
		CORINFO_BOX_THIS = 1,
		CORINFO_DEREF_THIS = 2
	}
	public enum CORINFO_CALLINFO_FLAGS
	{
		CORINFO_CALLINFO_NONE = 0,
		/// <summary>
		/// Can the compiler generate code to pass an instantiation parameters? Simple compilers should not use this flag
		/// </summary>
		CORINFO_CALLINFO_ALLOWINSTPARAM = 1,
		/// <summary>
		/// Is it a virtual call?
		/// </summary>
		CORINFO_CALLINFO_CALLVIRT = 2,
		/// <summary>
		/// This is set to only query the kind of call to perform, without getting any other information
		/// </summary>
		CORINFO_CALLINFO_KINDONLY = 4,
		/// <summary>
		/// Gets extra verification information.
		/// </summary>
		CORINFO_CALLINFO_VERIFICATION = 8,
		/// <summary>
		/// Perform security checks.
		/// </summary>
		CORINFO_CALLINFO_SECURITYCHECKS = 16,
		/// <summary>
		/// Resolving target of LDFTN
		/// </summary>
		CORINFO_CALLINFO_LDFTN = 32
	}
	public enum CorInfoIsAccessAllowedResult
	{
		/// <summary>
		/// Call allowed
		/// </summary>
		CORINFO_ACCESS_ALLOWED = 0,
		/// <summary>
		/// Call not allowed
		/// </summary>
		CORINFO_ACCESS_ILLEGAL = 1
	}
	public enum CorInfoTokenKind
	{
		CORINFO_TOKENKIND_Class = 1,
		CORINFO_TOKENKIND_Method = 2,
		CORINFO_TOKENKIND_Field = 4,
		CORINFO_TOKENKIND_Mask = 7,
		/// <summary>
		/// Token comes from CEE_LDTOKEN
		/// </summary>
		CORINFO_TOKENKIND_Ldtoken = 23,
		/// <summary>
		/// Token comes from CEE_CASTCLASS or CEE_ISINST
		/// </summary>
		CORINFO_TOKENKIND_Casting = 33,
		/// <summary>
		/// Token comes from CEE_NEWARR
		/// </summary>
		CORINFO_TOKENKIND_Newarr = 65,
		/// <summary>
		/// Token comes from CEE_BOX
		/// </summary>
		CORINFO_TOKENKIND_Box = 129,
		/// <summary>
		/// Token comes from CEE_CONSTRAINED
		/// </summary>
		CORINFO_TOKENKIND_Constrained = 257,
		/// <summary>
		/// Token comes from CEE_NEWOBJ
		/// </summary>
		CORINFO_TOKENKIND_NewObj = 514,
		/// <summary>
		/// Token comes from CEE_LDVIRTFTN
		/// </summary>
		CORINFO_TOKENKIND_Ldvirtftn = 1026,
		/// <summary>
		/// Token comes from devirtualizing a method
		/// </summary>
		CORINFO_TOKENKIND_DevirtualizedMethod = 2050
	}
	public enum CORINFO_DEVIRTUALIZATION_DETAIL
	{
		/// <summary>
		/// No details available
		/// </summary>
		CORINFO_DEVIRTUALIZATION_UNKNOWN = 0,
		/// <summary>
		/// Devirtualization was successful
		/// </summary>
		CORINFO_DEVIRTUALIZATION_SUCCESS = 1,
		/// <summary>
		/// Object class was canonical
		/// </summary>
		CORINFO_DEVIRTUALIZATION_FAILED_CANON = 2,
		/// <summary>
		/// Object class was com
		/// </summary>
		CORINFO_DEVIRTUALIZATION_FAILED_COM = 3,
		/// <summary>
		/// Object class could not be cast to interface class
		/// </summary>
		CORINFO_DEVIRTUALIZATION_FAILED_CAST = 4,
		/// <summary>
		/// Interface method could not be found
		/// </summary>
		CORINFO_DEVIRTUALIZATION_FAILED_LOOKUP = 5,
		/// <summary>
		/// Interface method was default interface method
		/// </summary>
		CORINFO_DEVIRTUALIZATION_FAILED_DIM = 6,
		/// <summary>
		/// Object not subclass of base class
		/// </summary>
		CORINFO_DEVIRTUALIZATION_FAILED_SUBCLASS = 7,
		/// <summary>
		/// Virtual method installed via explicit override
		/// </summary>
		CORINFO_DEVIRTUALIZATION_FAILED_SLOT = 8,
		/// <summary>
		/// Devirtualization crossed version bubble
		/// </summary>
		CORINFO_DEVIRTUALIZATION_FAILED_BUBBLE = 9,
		/// <summary>
		/// Sentinel for maximum value
		/// </summary>
		CORINFO_DEVIRTUALIZATION_COUNT = 10
	}
	public enum CORINFO_FIELD_ACCESSOR
	{
		/// <summary>
		/// Regular instance field at given offset from this-ptr
		/// </summary>
		CORINFO_FIELD_INSTANCE = 0,
		/// <summary>
		/// Instance field with base offset (used by Ready-to-Run)
		/// </summary>
		CORINFO_FIELD_INSTANCE_WITH_BASE = 1,
		/// <summary>
		/// Instance field accessed using helper (arguments are this, FieldDesc * and the value)
		/// </summary>
		CORINFO_FIELD_INSTANCE_HELPER = 2,
		/// <summary>
		/// Instance field accessed using address-of helper (arguments are this and FieldDesc *)
		/// </summary>
		CORINFO_FIELD_INSTANCE_ADDR_HELPER = 3,
		/// <summary>
		/// Field at given address
		/// </summary>
		CORINFO_FIELD_STATIC_ADDRESS = 4,
		/// <summary>
		/// RVA field at given address
		/// </summary>
		CORINFO_FIELD_STATIC_RVA_ADDRESS = 5,
		/// <summary>
		/// Static field accessed using the "shared static" helper (arguments are ModuleID + ClassID)
		/// </summary>
		CORINFO_FIELD_STATIC_SHARED_STATIC_HELPER = 6,
		/// <summary>
		/// Static field access using the "generic static" helper (argument is MethodTable *)
		/// </summary>
		CORINFO_FIELD_STATIC_GENERICS_STATIC_HELPER = 7,
		/// <summary>
		/// Static field accessed using address-of helper (argument is FieldDesc *)
		/// </summary>
		CORINFO_FIELD_STATIC_ADDR_HELPER = 8,
		/// <summary>
		/// Unmanaged TLS access
		/// </summary>
		CORINFO_FIELD_STATIC_TLS = 9,
		/// <summary>
		/// Static field access using a runtime lookup helper
		/// </summary>
		CORINFO_FIELD_STATIC_READYTORUN_HELPER = 10,
		/// <summary>
		/// Intrinsic zero (IntPtr.Zero, UIntPtr.Zero)
		/// </summary>
		CORINFO_FIELD_INTRINSIC_ZERO = 11,
		/// <summary>
		/// Intrinsic emptry string (String.Empty)
		/// </summary>
		CORINFO_FIELD_INTRINSIC_EMPTY_STRING = 12,
		/// <summary>
		/// Intrinsic BitConverter.IsLittleEndian
		/// </summary>
		CORINFO_FIELD_INTRINSIC_ISLITTLEENDIAN = 13
	}
	public enum CORINFO_FIELD_FLAGS
	{
		CORINFO_FLG_FIELD_STATIC = 1,
		/// <summary>
		/// RVA field
		/// </summary>
		CORINFO_FLG_FIELD_UNMANAGED = 2,
		CORINFO_FLG_FIELD_FINAL = 4,
		/// <summary>
		/// See code:#StaticFields. This static field is in the GC heap as a boxed object
		/// </summary>
		CORINFO_FLG_FIELD_STATIC_IN_HEAP = 8,
		/// <summary>
		/// Field can be returned safely (has GC heap lifetime)
		/// </summary>
		CORINFO_FLG_FIELD_SAFESTATIC_BYREF_RETURN = 16,
		/// <summary>
		/// InitClass has to be called before accessing the field
		/// </summary>
		CORINFO_FLG_FIELD_INITCLASS = 32,
		CORINFO_FLG_FIELD_PROTECTED = 64
	}
	public enum CORINFO_OS
	{
		CORINFO_WINNT = 0,
		CORINFO_UNIX = 1
	}
	public enum CORINFO_RUNTIME_ABI
	{
		CORINFO_DESKTOP_ABI = 256,
		CORINFO_CORECLR_ABI = 512,
		CORINFO_CORERT_ABI = 768
	}
	public enum CORINFO_GET_TAILCALL_HELPERS_FLAGS
	{
		/// <summary>
		/// The callsite is a callvirt instruction.
		/// </summary>
		CORINFO_TAILCALL_IS_CALLVIRT = 1,
		/// <summary>
		/// The callsite is a callvirt instruction.
		/// </summary>
		CORINFO_TAILCALL_THIS_ARG_IS_BYREF = 2
	}
	public enum CORINFO_TAILCALL_HELPERS_FLAGS
	{
		/// <summary>
		/// The StoreArgs stub needs to be passed the target function pointer as the
		/// first argument.
		/// </summary>
		CORINFO_TAILCALL_STORE_TARGET = 1
	}
	public enum TypeCompareState
	{
		/// <summary>
		/// Types are not equal
		/// </summary>
		MustNot = -1,
		/// <summary>
		/// Types may be equal (must test at runtime)
		/// </summary>
		May = 0,
		/// <summary>
		/// Type are equal
		/// </summary>
		Must = 1
	}
	public enum CorJitResult
	{
		/// <summary>
		/// Note that I dont use FACILITY_NULL for the facility number,
		/// we may want to get a 'real' facility number
		/// </summary>
		CORJIT_OK = 0,
		/// <summary>
		/// Note that I dont use FACILITY_NULL for the facility number,
		/// we may want to get a 'real' facility number
		/// </summary>
		CORJIT_BADCODE = -2147483647,
		/// <summary>
		/// Note that I dont use FACILITY_NULL for the facility number,
		/// we may want to get a 'real' facility number
		/// </summary>
		CORJIT_OUTOFMEM = -2147483646,
		/// <summary>
		/// Note that I dont use FACILITY_NULL for the facility number,
		/// we may want to get a 'real' facility number
		/// </summary>
		CORJIT_INTERNALERROR = -2147483645,
		/// <summary>
		/// Note that I dont use FACILITY_NULL for the facility number,
		/// we may want to get a 'real' facility number
		/// </summary>
		CORJIT_SKIPPED = -2147483644,
		/// <summary>
		/// Note that I dont use FACILITY_NULL for the facility number,
		/// we may want to get a 'real' facility number
		/// </summary>
		CORJIT_RECOVERABLEERROR = -2147483643,
		/// <summary>
		/// Note that I dont use FACILITY_NULL for the facility number,
		/// we may want to get a 'real' facility number
		/// </summary>
		CORJIT_IMPLLIMITATION = -2147483642
	}
	public enum CorJitAllocMemFlag
	{
		/// <summary>
		/// The code will use the normal alignment
		/// </summary>
		CORJIT_ALLOCMEM_DEFAULT_CODE_ALIGN = 0,
		/// <summary>
		/// The code will be 16-byte aligned
		/// </summary>
		CORJIT_ALLOCMEM_FLG_16BYTE_ALIGN = 1,
		/// <summary>
		/// The read-only data will be 16-byte aligned
		/// </summary>
		CORJIT_ALLOCMEM_FLG_RODATA_16BYTE_ALIGN = 2,
		/// <summary>
		/// The code will be 32-byte aligned
		/// </summary>
		CORJIT_ALLOCMEM_FLG_32BYTE_ALIGN = 4,
		/// <summary>
		/// The read-only data will be 32-byte aligned
		/// </summary>
		CORJIT_ALLOCMEM_FLG_RODATA_32BYTE_ALIGN = 8
	}
	public enum CorJitFuncKind
	{
		/// <summary>
		/// The main/root function (always id==0)
		/// </summary>
		CORJIT_FUNC_ROOT = 0,
		/// <summary>
		/// A funclet associated with an EH handler (finally, fault, catch, filter handler)
		/// </summary>
		CORJIT_FUNC_HANDLER = 1,
		/// <summary>
		/// A funclet associated with an EH filter
		/// </summary>
		CORJIT_FUNC_FILTER = 2
	}
	public enum CheckedWriteBarrierKinds
	{
		/// <summary>
		/// Not one of the ones below.
		/// </summary>
		CWBKind_Unclassified = 0,
		/// <summary>
		/// Store through a return buffer pointer argument.
		/// </summary>
		CWBKind_RetBuf = 1,
		/// <summary>
		/// Store through a by-ref argument (not an implicit return buffer).
		/// </summary>
		CWBKind_ByRefArg = 2,
		/// <summary>
		/// Store through a by-ref local variable.
		/// </summary>
		CWBKind_OtherByRefLocal = 3,
		/// <summary>
		/// Store through the address of a local (arguably a bug that this happens at all).
		/// </summary>
		CWBKind_AddrOfLocal = 4
	}

	// 	[NativeStructure]
	// [StructLayout(LayoutKind.Sequential)]
	// public unsafe struct MethodDesc
	// {
	// 	static MethodDesc()
	// 	{
	// 		Global.Clr.LoadImports(typeof(MethodDesc));
	// 	}
	//
	// 	internal MethodClassification Classification =>
	// 		(MethodClassification) ((ushort) Properties & (ushort) MethodProperties.Classification);
	//
	// 	internal ParamFlags Flags3AndTokenRemainder { get; }
	//
	// 	internal byte ChunkIndex { get; }
	//
	// 	internal CodeFlags CodeFlags { get; }
	//
	// 	internal ushort SlotNumber { get; }
	//
	// 	internal MethodProperties Properties { get; }
	//
	// 	/// <summary>
	// 	///     Valid only if the function is non-virtual,
	// 	///     non-abstract, non-generic (size of this <see cref="MethodDesc"/> <c>== 16</c>)
	// 	/// </summary>
	// 	internal void* Function { get; }
	//
	// 	internal bool IsPointingToNativeCode
	// 	{
	// 		get
	// 		{
	// 			fixed (MethodDesc* p = &this) {
	// 				var mt = Func_IsPointingToNativeCode(p);
	// 				return Convert.ToBoolean(mt);
	// 			}
	// 		}
	// 	}
	//
	// 	internal void* NativeCode
	// 	{
	// 		get
	// 		{
	// 			fixed (MethodDesc* p = &this) {
	// 				return Func_GetNativeCode(p);
	// 			}
	// 		}
	// 	}
	//
	// 	internal int Token
	// 	{
	// 		get
	// 		{
	// 			fixed (MethodDesc* p = &this) {
	// 				return Func_GetToken(p);
	// 			}
	// 		}
	// 	}
	//
	// 	
	//
	//
	// 	internal long RVA
	// 	{
	// 		get
	// 		{
	// 			fixed (MethodDesc* p = &this) {
	// 				return Func_GetRVA(p);
	// 			}
	// 		}
	// 	}
	//
	// 	private static int Alignment
	// 	{
	// 		get
	// 		{
	// 			//int alignmentShift = 3;
	// 			int alignmentShift = Mem.Is64Bit ? 3 : 2;
	// 			int alignment      = 1 << alignmentShift;
	// 			int alignmentMask  = alignment - 1;
	//
	// 			return alignment;
	// 		}
	// 	}
	//
	// 	internal CorILMethod* ILHeader
	// 	{
	// 		get
	// 		{
	// 			fixed (MethodDesc* p = &this) {
	// 				const int fAllowOverrides = 0;
	// 				return Func_GetILHeader(p, fAllowOverrides);
	// 			}
	// 		}
	// 	}
	//
	// 	internal Pointer<MethodDescChunk> MethodDescChunk
	// 	{
	// 		get
	// 		{
	// 			// PTR_MethodDescChunk(dac_cast<TADDR>(this) -(sizeof(MethodDescChunk) + (GetMethodDescIndex() * MethodDesc::ALIGNMENT)));
	//
	// 			var thisptr = Mem.AddressOf(ref this).Cast();
	// 			return (thisptr - (sizeof(MethodDescChunk) + (ChunkIndex * Alignment)));
	// 		}
	// 	}
	//
	// 	internal void Reset()
	// 	{
	// 		fixed (MethodDesc* p = &this) {
	// 			Func_Reset(p);
	// 		}
	// 	}
	//
	// 	internal Pointer<MethodTable> MethodTable => MethodDescChunk.Reference.MethodTable;
	// 	
	// 	/// <summary>
	// 	/// <see cref="MethodDesc.IsPointingToNativeCode"/>
	// 	/// </summary>
	// 	[field: ImportClr("Sig_IsPointingToNativeCode")]
	// 	private static delegate* unmanaged<MethodDesc*, int> Func_IsPointingToNativeCode { get; }
	// 	
	// 	/// <summary>
	// 	/// <see cref="MethodDesc.NativeCode"/>
	// 	/// </summary>
	// 	[field: ImportClr("Sig_GetNativeCode")]
	// 	private static delegate* unmanaged<MethodDesc*, void*> Func_GetNativeCode { get; }
	// 	
	// 	/// <summary>
	// 	/// <see cref="MethodDesc.Token"/>
	// 	/// </summary>
	// 	[field: ImportClr("Sig_GetMemberDef")]
	// 	private static delegate* unmanaged<MethodDesc*, int> Func_GetToken { get; }
	// 	
	// 	/// <summary>
	// 	/// <see cref="MethodDesc.RVA"/>
	// 	/// </summary>
	// 	[field: ImportClr("Sig_GetRVA")]
	// 	private static delegate* unmanaged<MethodDesc*, int> Func_GetRVA { get; }
	// 	
	// 	
	// 	/// <summary>
	// 	/// <see cref="MethodDesc.Reset"/>
	// 	/// </summary>
	// 	[field: ImportClr("Sig_Reset")]
	// 	private static delegate* unmanaged<MethodDesc*, void> Func_Reset { get; }
	// 	
	// 	/// <summary>
	// 	/// <see cref="ILHeader"/>
	// 	/// </summary>
	// 	[field: ImportClr("Sig_GetIL")]
	// 	private static delegate* unmanaged<MethodDesc*, int, CorILMethod*> Func_GetILHeader { get; }
	// }
	//
	// [StructLayout(LayoutKind.Sequential)]
	// public unsafe struct MethodDescChunk
	// {
	// 	/// <summary>
	// 	/// Relative fixup <see cref="Pointer{T}"/>
	// 	/// </summary>
	// 	private Pointer<MethodTable> MethodTableStub { get; }
	//
	// 	/// <summary>
	// 	/// Relative <see cref="Pointer{T}"/> to <see cref="MethodDescChunk"/>
	// 	/// </summary>
	// 	private Pointer<byte> Next { get; }
	//
	// 	/// <summary>
	// 	/// The size of this chunk minus 1 (in multiples of MethodDesc::ALIGNMENT)
	// 	/// </summary>
	// 	internal byte Size { get; }
	//
	// 	/// <summary>
	// 	/// The number of <see cref="MethodDesc"/> in this chunk minus 1
	// 	/// </summary>
	// 	internal byte Count { get; }
	//
	// 	internal ChunkFlags FlagsAndTokenRange { get; }
	//
	// 	// Followed by array of method descs...
	//
	// 	internal Pointer<MethodTable> MethodTable
	// 	{
	// 		get
	// 		{
	// 			// for MDC: m_methodTable.GetValue(PTR_HOST_MEMBER_TADDR(MethodDescChunk, this, m_methodTable));
	//
	// 			const int MT_FIELD_OFS = 0;
	// 			return RuntimeInfo.FieldOffset((MethodTable*) MethodTableStub.ToPointer(), MT_FIELD_OFS);
	// 		}
	// 	}
	// }

	[Flags]
	public enum ChunkFlags : ushort
	{
		/// <summary>
		///     This must equal METHOD_TOKEN_RANGE_MASK calculated higher in this file.
		///     These are separate to allow the flags space available and used to be obvious here
		///     and for the logic that splits the token to be algorithmically generated based on the #define
		/// </summary>
		TokenRangeMask = 0x03FF,

		/// <summary>
		///     Compact temporary entry points
		/// </summary>
		HasCompactEntryPoints = 0x4000,

		/// <summary>
		///     This chunk lives in NGen module
		/// </summary>
		IsZapped = 0x8000
	}

	/// <summary>
	///     Describes the type of <see cref="MethodDesc" />
	/// </summary>
	public enum MethodClassification
	{
		/// <summary>
		///     IL
		/// </summary>
		IL = 0,

		/// <summary>
		///     FCall(also includes tlbimped ctor, Delegate ctor)
		/// </summary>
		FCall = 1,

		/// <summary>
		///     N/Direct
		/// </summary>
		NDirect = 2,

		/// <summary>
		///     Special method; implementation provided by EE (like Delegate Invoke)
		/// </summary>
		EEImpl = 3,

		/// <summary>
		///     Array ECall
		/// </summary>
		Array = 4,

		/// <summary>
		///     Instantiated generic methods, including descriptors
		///     for both shared and unshared code (see InstantiatedMethodDesc)
		/// </summary>
		Instantiated = 5,

		//#ifdef FEATURE_COMINTEROP
		// This needs a little explanation.  There are MethodDescs on MethodTables
		// which are Interfaces.  These have the mdcInterface bit set.  Then there
		// are MethodDescs on MethodTables that are Classes, where the method is
		// exposed through an interface.  These do not have the mdcInterface bit set.
		//
		// So, today, a dispatch through an 'mdcInterface' MethodDesc is either an
		// error (someone forgot to look up the method in a class' VTable) or it is
		// a case of COM Interop.

		ComInterop = 6,

		//#endif                 // FEATURE_COMINTEROP

		/// <summary>
		///     For <see cref="MethodDesc" /> with no metadata behind
		/// </summary>
		Dynamic = 7,

		Count
	}

	/// <summary>
	///     Describes <see cref="MethodDesc" /> parameters
	/// </summary>
	[Flags]
	public enum ParamFlags : ushort
	{
		TokenRemainderMask = 0x3FFF,

		// These are separate to allow the flags space available and used to be obvious here
		// and for the logic that splits the token to be algorithmically generated based on the
		// #define

		/// <summary>
		///     Indicates that a type-forwarded type is used as a valuetype parameter (this flag is only valid for ngenned items)
		/// </summary>
		HasForwardedValueTypeParameter = 0x4000,

		/// <summary>
		///     Indicates that all typeref's in the signature of the method have been resolved to typedefs (or that process failed)
		///     (this flag is only valid for non-ngenned methods)
		/// </summary>
		ValueTypeParametersWalked = 0x4000,

		/// <summary>
		///     Indicates that we have verified that there are no equivalent valuetype parameters for this method
		/// </summary>
		DoesNotHaveEquivalentValueTypeParameters = 0x8000
	}

	/// <summary>
	///     Describes <see cref="MethodDesc" /> JIT/entry point status
	/// </summary>
	[Flags]
	public enum CodeFlags : byte
	{
		/// <summary>
		///     The method entry point is stable (either precode or actual code)
		/// </summary>
		HasStableEntryPoint = 0x01,

		/// <summary>
		///     implies that HasStableEntryPoint is set.
		///     Precode has been allocated for this method
		/// </summary>
		HasPrecode = 0x02,

		IsUnboxingStub = 0x04,

		/// <summary>
		///     Has slot for native code
		/// </summary>
		HasNativeCodeSlot = 0x08,

		/// <summary>
		///     Jit may expand method as an intrinsic
		/// </summary>
		IsJitIntrinsic = 0x10
	}

		/// <summary>
	///     Describes the type and properties of a <see cref="MethodDesc" />
	/// </summary>
	[Flags]
	public enum MethodProperties : ushort
	{
		/// <summary>
		///     Method is <see cref="MethodClassification.IL" />, <see cref="MethodClassification.FCall" /> etc., see
		///     <see cref="MethodClassification" /> above.
		/// </summary>
		Classification = 0x0007,

		ClassificationCount = Classification + 1,

		// Note that layout of code:MethodDesc::s_ClassificationSizeTable depends on the exact values
		// of mdcHasNonVtableSlot and mdcMethodImpl

		/// <summary>
		///     Has local slot (vs. has real slot in MethodTable)
		/// </summary>
		HasNonVtableSlot = 0x0008,

		/// <summary>
		///     Method is a body for a method impl (MI_MethodDesc, MI_NDirectMethodDesc, etc)
		///     where the function explicitly implements IInterface.foo() instead of foo().
		/// </summary>
		MethodImpl = 0x0010,

		/// <summary>
		///     Method is static
		/// </summary>
		Static = 0x0020,

		// unused                           = 0x0040,
		// unused                           = 0x0080,
		// unused                           = 0x0100,
		// unused                           = 0x0200,

		// Duplicate method. When a method needs to be placed in multiple slots in the
		// method table, because it could not be packed into one slot. For eg, a method
		// providing implementation for two interfaces, MethodImpl, etc
		Duplicate = 0x0400,

		/// <summary>
		///     Has this method been verified?
		/// </summary>
		VerifiedState = 0x0800,

		/// <summary>
		///     Is the method verifiable? It needs to be verified first to determine this
		/// </summary>
		Verifiable = 0x1000,

		/// <summary>
		///     Is this method ineligible for inlining?
		/// </summary>
		NotInline = 0x2000,

		/// <summary>
		///     Is the method synchronized
		/// </summary>
		Synchronized = 0x4000,

		/// <summary>
		///     Does the method's slot number require all 16 bits
		/// </summary>
		RequiresFullSlotNumber = 0x8000
	}
}
