using System.Runtime.InteropServices;
using System;
using static System.SystemImplementation;
using static System.SystemInterface;


namespace System
{

    /*
      D2CSharp Runtime Library (RTL)

  This Delphi source file provides the basis for generating C# mock
  implementations with D2CSharp. The generated files serve as a
  starting point for manual completion of the C# runtime library.

      Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
      SPDX-License-Identifier: Apache-2.0

      Licensed under the Apache License, Version 2.0 (the "License");
      you may not use this file except in compliance with the License.
      You may obtain a copy of the License at

          https://www.apache.org/licenses/LICENSE-2.0

      Unless required by applicable law or agreed to in writing, software
      distributed under the License is distributed on an "AS IS" BASIS,
      WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
      See the License for the specific language governing permissions and
      limitations under the License.

      Part of the D2CSharp project by t2t-soft. See LICENSE and NOTICE.
    */

    public struct TResStringRec
    {
        /*
         * Managed representation of a Delphi resourcestring record.
         *
         * Native module pointers and binary resource identifiers are intentionally
         * not represented in this first stage. Numeric LoadStr identifiers are
         * maintained by SysutilsInterface's managed registry.
         */
        private string? FStoredMessage;

        public TResStringRec(string Message)
        {
            FStoredMessage =
             Message ?? string.Empty;
        }

        public string FMessage
        {
            get
            {
                return FStoredMessage ??
                 string.Empty;
            }
            set
            {
                FStoredMessage =
                 value ?? string.Empty;
            }
        }

        public static implicit operator TResStringRec(string? value)
        {
            return new TResStringRec(
             value ?? string.Empty);
        }

        public static implicit operator string(TResStringRec value)
        {
            return value.FMessage;
        }

        public override string ToString()
        {
            return FMessage;
        }
    }


    public static partial class SystemInterface
    {

		public struct TTypeInfo
		{
			public TTypeKind Kind;
			public static TTypeInfo CreateRecord() { return new TTypeInfo(); }
	}	
		public interface IInterface
		{
#if USECOM
			int QueryInterface(Guid IID, UntypedPointer Obj);
			int _AddRef();
			int _Release();
#endif
		}

		public class TInterfacedObject : TObject, IInterface
		{
#if USECOM
			protected int FRefCount;

			public int RefCount
			{
				get
				{
					return global::System.Threading.Volatile.Read(ref FRefCount);
				}
			}

			public virtual int QueryInterface(Guid IID, UntypedPointer Obj)
			{
				object InterfaceObject;

				if (Obj.IsNull() || !GetInterface(IID, out InterfaceObject))
					return E_NOINTERFACE;

				// Delphi's untyped out parameter is represented by an addressable
				// managed object cell in the D2CSharp RTL.  Store the resolved
				// interface in that cell and acquire the corresponding interface
				// reference.
				Obj.Write<object>(InterfaceObject);
				_AddRef();
				return S_OK;
			}

			public virtual int _AddRef()
			{
				return global::System.Threading.Interlocked.Increment(ref FRefCount);
			}

			public virtual int _Release()
			{
				int Result = global::System.Threading.Interlocked.Decrement(ref FRefCount);

				if (Result == 0)
					Destroy();

				return Result;
			}
#else
			// Without COM support IInterface is a marker interface.  Keep the
			// Delphi class available so translated inheritance hierarchies do not
			// depend on the USECOM build symbol.
			public int RefCount
			{
				get { return 0; }
			}
#endif
		}
		public struct TInterfaceEntry
		{

			public static TInterfaceEntry CreateRecord() { return new TInterfaceEntry(); }
	}	

		public struct TInterfaceTable
		{

			public static TInterfaceTable CreateRecord() { return new TInterfaceTable(); }
	}	

	public class TMetaClass : TObject
	{


/* TMetaClass */
		public TMetaClass(Pointer AClassType)
		{
		}
		public string ClassName()
		{
			return string.Empty;
		}
		public string QualifiedClassName()
		{
			return string.Empty;
		}
		public string UnitName()
		{
			return string.Empty;
		}
		public string UnitScope()
		{
			return string.Empty;
		}
		public TMetaClass ClassParent()
		{
			return default;
		}
		public Pointer ClassInfo()
		{
			return default;
		}
		public TMetaClass ClassType()
		{
			return default;
		}
		public int InstanceSize()
		{
			return 0;
		}
		public static bool InheritsFrom(TMetaClass AClass)
		{
			return false;
		}
		public bool ClassNameIs(string Name)
		{
			return false;
		}
		public TObject CreateInstance()
		{
			return default;
		}
	}	

    //public class TObject
    //{
    //    protected bool FDisposed;

    //    public virtual void Destroy()
    //    {
    //        if (!FDisposed)
    //        {
    //            FDisposed = true;
    //            GC.SuppressFinalize(this);
    //        }
    //    }

    //    public void Free()
    //    {
    //        Destroy();
    //    }

    //    public static void Free(TObject obj)
    //    {
    //        if (obj != null)
    //        {
    //            obj.Destroy();
    //        }
    //    }

    //    public TClass ClassType()
    //    {
    //        return TClass.Of(GetType());
    //    }

    //    public string ClassName()
    //    {
    //        return ClassType().ClassName();
    //    }

    //    public bool ClassNameIs(string name)
    //    {
    //        return ClassType().ClassNameIs(name);
    //    }

    //    public TClass ClassParent()
    //    {
    //        return ClassType().ClassParent();
    //    }

    //    public bool InheritsFrom(TClass aClass)
    //    {
    //        return ClassType().InheritsFrom(aClass);
    //    }

    //    // dme from old code
    //    public string InterfaceName()  
    //    {
    //        return this.ToString();
    //    }
    //}


    //public sealed class TClass : global::System.IEquatable<TClass>
    //{
    //    private readonly global::System.Type _type;

    //    private TClass(global::System.Type type)
    //    {
    //        _type = type ?? throw new ArgumentNullException(nameof(type));
    //    }

    //    public global::System.Type Type
    //    {
    //        get
    //        {
    //            return _type;
    //        }
    //    }

    //    // Do not constrain T to TObject here.
    //    // TClass must also be able to represent and create DException-derived types,
    //    // which are translated to C# exceptions and therefore do not derive from TObject.
    //    public static TClass Of<T>()
    //    {
    //        return new TClass(typeof(T));
    //    }

    //    public static TClass Of(global::System.Type type)
    //    {
    //        if (type == null)
    //        {
    //            return null;
    //        }

    //        return new TClass(type);
    //    }

    //    public TObject Create()
    //    {
    //        return (TObject)global::System.Activator.CreateInstance(_type);
    //    }

    //    public object Create(params object[] args)
    //    {
    //        return global::System.Activator.CreateInstance(_type, args);
    //    }

    //    public global::System.Exception CreateException(params object[] args)
    //    {
    //        return (global::System.Exception)global::System.Activator.CreateInstance(_type, args);
    //    }

    //    public string ClassName()
    //    {
    //        return _type.Name;
    //    }

    //    public string QualifiedClassName()
    //    {
    //        return _type.FullName ?? _type.Name;
    //    }

    //    public string UnitName()
    //    {
    //        return _type.Namespace ?? string.Empty;
    //    }

    //    public string UnitScope()
    //    {
    //        string ns = _type.Namespace ?? string.Empty;
    //        int index = ns.LastIndexOf('.');

    //        if (index < 0)
    //        {
    //            return ns;
    //        }

    //        return ns.Substring(0, index);
    //    }

    //    public TClass ClassParent()
    //    {
    //        global::System.Type baseType = _type.BaseType;

    //        if (baseType == null || baseType == typeof(object))
    //        {
    //            return null;
    //        }

    //        return Of(baseType);
    //    }

    //    public bool InheritsFrom(TClass aClass)
    //    {
    //        if (aClass == null)
    //        {
    //            return false;
    //        }

    //        return aClass._type.IsAssignableFrom(_type);
    //    }

    //    public bool ClassNameIs(string name)
    //    {
    //        return string.Equals(ClassName(), name, global::System.StringComparison.OrdinalIgnoreCase);
    //    }

    //    public bool Equals(TClass other)
    //    {
    //        return other != null && _type == other._type;
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        return Equals(obj as TClass);
    //    }

    //    public override int GetHashCode()
    //    {
    //        return _type.GetHashCode();
    //    }

    //    public object InvokeClassMethod(string methodName, params object[] args)
    //    {
    //        global::System.Reflection.MethodInfo method = Type.GetMethod(
    //            methodName,
    //            global::System.Reflection.BindingFlags.Public |
    //            global::System.Reflection.BindingFlags.Static |
    //            global::System.Reflection.BindingFlags.FlattenHierarchy);

    //        if (method == null)
    //        {
    //            throw new global::System.MissingMethodException(Type.FullName, methodName);
    //        }

    //        return method.Invoke(null, args);
    //    }

    //    public TResult InvokeClassMethod<TResult>(string methodName, params object[] args)
    //    {
    //        object result = InvokeClassMethod(methodName, args);

    //        if (result == null)
    //        {
    //            return default(TResult);
    //        }

    //        return (TResult)result;
    //    }
    //    public static bool operator ==(TClass left, TClass right)
    //    {
    //        if (ReferenceEquals(left, right))
    //        {
    //            return true;
    //        }

    //        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
    //        {
    //            return false;
    //        }

    //        return left.Equals(right);
    //    }

    //    public static bool operator !=(TClass left, TClass right)
    //    {
    //        return !(left == right);
    //    }
    //}

        /*
         * TTextRec and TFileRec are parser placeholder types in the Delphi
         * mock source.  The working RTL uses the concrete implementations
         * System.TTextRec and System.TFileRec from TTextRec.cs/TFileRec.cs.
         * Do not declare nested SystemInterface.TTextRec/TFileRec here: a
         * nested declaration would shadow those concrete types in all partial
         * SystemInterface source files, including the AnsiString adapters.
         */

	public class List
	{
		public List(){}
		//# missing function body: public int Length();
		//# missing function body: public int High();
		//# missing function body: public int Low();
		//# missing function body: public /*#procedure*/ object Copy();
		//# missing function body: public int CopyRange();
	};	

	public class TDateTimeBase
	{
		//public override string ClassName() {return "TDateTimeBase";}
		//public override TMetaClass ClassType(){return class_id<TDateTimeBase>();}
		//public override TMetaClass ClassParent(){return class_id<[unknown type]>();}
		//public override TObject Create(){return new TDateTimeBase();}
		//public static new TDateTimeBase SCreate() {return new TDateTimeBase();}
	};	

	public struct TMethod
	{
		public nint Code;
		public nint Data;

		public TMethod(nint code, nint data)
		{
			Code = code;
			Data = data;
		}

		public static TMethod CreateRecord(){return new TMethod();}
	};	

	/*
	 * D2CSharp representation of Delphi TVarData.
	 *
	 * This is intentionally a managed compatibility record and not a binary
	 * representation of the Delphi/OLE Variant layout.  It only provides the
	 * fields required by translated source code without depending on translated
	 * Embarcadero RTL code.
	 */
	public struct TVarData
	{
		public ushort VType;
		public ushort Reserved1;
		public ushort Reserved2;
		public ushort Reserved3;

		public short VSmallInt;
		public int VInteger;
		public float VSingle;
		public double VDouble;
		public decimal VCurrency;
		public double VDate;
		public object VOleStr;
		public object VDispatch;
		public int VError;
		public short VBoolean;
		public object VUnknown;
		public sbyte VShortInt;
		public byte VByte;
		public ushort VWord;
		public uint VLongWord;
		public uint VUInt32;
		public long VInt64;
		public ulong VUInt64;
		public object VString;
		public object VAny;
		public object VArray;
		public object VPointer;
		public object VUString;
		public object VRecord;

		public static TVarData CreateRecord() { return new TVarData(); }
	};
  /* Basic placeholder types needed by the D2CSharp parser. */
	public enum TTypeKind {tkUnknown,
                tkInteger,
                tkChar,
                tkEnumeration,
                tkFloat,
                tkString,
                tkSet,
                tkClass,
                tkMethod,
                tkWChar,
                tkLString,
                tkWString,
                tkVariant,
                tkArray,
                tkRecord,
                tkInterface,
                tkInt64,
                tkDynArray,
                tkUString,
                tkClassRef,
                tkPointer,
                tkProcedure };

  /*
    Public System-unit constants used by translated Delphi source.

    HRESULT error values are deliberately written as signed decimal Int32
    constants. This lets D2CSharp emit directly compilable C# int constants
    without requiring unchecked casts for $8000xxxx literals.
  */
	public const int S_OK = 0;
	public const int S_FALSE = 1;
	public const int E_NOINTERFACE = -2147467262;  /* $80004002 */
	public const int E_UNEXPECTED = -2147418113;  /* $8000FFFF */
	public const int E_NOTIMPL = -2147467263;  /* $80004001 */

  /* Common public System constants useful during source translation. */
	public const int MaxInt = 2147483647;
	public const int MaxLongInt = 2147483647;
	public const int CP_ACP = 0;
	public const int CP_UTF7 = 65000;              /* $FDE8 */
	public const int CP_UTF8 = 65001;              /* $FDE9 */
	public const int fmClosed = 55216;             /* $D7B0 */
	public const int fmInput = 55217;             /* $D7B1 */
	public const int fmOutput = 55218;             /* $D7B2 */
	public const int fmInOut = 55219;             /* $D7B3 */
//	public const Pointer Nil = ((Pointer) 0);

/* Numeric intrinsics */
	//# output of equivalent "Abs" function suppressed
	//# missing function body: public static long Abs(long X);
	//# missing function body: public static float Abs(float X);
	//# missing function body: public static double Abs(double X);
	//# output of equivalent "Abs" function suppressed
	//# output of equivalent "Sqr" function suppressed
	//# missing function body: public static long Sqr(long X);
	//# missing function body: public static float Sqr(float X);
	//# missing function body: public static double Sqr(double X);
	//# output of equivalent "Sqr" function suppressed
	//# output of equivalent "Round" function suppressed
	//# missing function body: public static long Round(double X);
	//# output of equivalent "Round" function suppressed
	//# output of equivalent "Trunc" function suppressed
	//# missing function body: public static long Trunc(double X);
	//# output of equivalent "Trunc" function suppressed
	public static bool Odd(int X)
	{
		return false;
	}
	//# missing function body: public static bool Odd(long X);
	public static double Pi()
	{
		return 0.0D;
	}
	public static double BuiltInSin(double X)
	{
		return 0.0D;
	}
	public static double BuiltInCos(double X)
	{
		return 0.0D;
	}
	public static double BuiltInTan(double X)
	{
		return 0.0D;
	}
	public static double BuiltInArcTan(double X)
	{
		return 0.0D;
	}
	public static double BuiltInArcTan2(double Y, double X)
	{
		return 0.0D;
	}
	public static double BuiltInSqrt(double X)
	{
		return 0.0D;
	}
	public static double BuiltInLn(double X)
	{
		return 0.0D;
	}
	public static double BuiltInLnXPlus1(double X)
	{
		return 0.0D;
	}
	public static double BuiltInLog2(double X)
	{
		return 0.0D;
	}
	public static double BuiltInLog10(double X)
	{
		return 0.0D;
	}
	public static long MulDivInt64(long AValue, long AMul, long ADiv)
	{
		return 0;
	}

/* Ordinal and type intrinsics */

//function Ord(X): Integer;
//function Chr(X: Byte): Char;
//function Succ(X): Integer;
//function Pred(X): Integer;
	public static byte Hi(int X)
	{
		return (byte)(((uint)X >> 8) & 0xFF);
	}
	public static byte Hi(ushort X)
	{
		return (byte)((X >> 8) & 0xFF);
	}
	public static byte Lo(int X)
	{
		return (byte)((uint)X & 0xFF);
	}
	public static byte Lo(ushort X)
	{
		return (byte)(X & 0xFF);
	}
	public static int Swap(ushort X)
	{
		return 0;
	}
	//# missing function body: public static int Swap(int X);

//function High(X): Integer;
//function Low(X): Integer;
//function SizeOf(X): NativeInt;

//function Default(T): Variant;
//function TypeInfo(T): PTypeInfo;
//function TypeHandle(T): TTypeHandle;
//function TypeOf(X): PTypeInfo;
//function GetTypeKind(T): TTypeKind;

//function IsManagedType(T): Boolean;
//function HasWeakRef(T): Boolean;
//function IsConstValue(Value): Boolean;

/* Pointer and memory intrinsics */
	public static Pointer Addr(UntypedPointer X)
	{
		return X;
	}
	public static Pointer Ptr(uint Address)
	{
		return new Pointer(new global::System.IntPtr((long)Address));
	}
	public static bool Assigned(Pointer P)
	{
		return !P.IsNull();
	}
	//# missing function body: public static bool Assigned(UntypedPointer P);
	public static void FillChar(UntypedPointer X, int Count, byte Value)
	{
		if (Count <= 0)
			return;

		if (X.IsNull())
			throw new global::System.NullReferenceException("Pointer is null.");

		for (int Index = 0; Index < Count; Index++)
			X.Assign(Value, Index);
	}

	public static void FillChar(UntypedPointer X, int Count, char Value)
	{
		FillChar(X, Count, unchecked((byte)Value));
	}

	public static void FillChar(UntypedPointer X, int Count, int Value)
	{
		FillChar(X, Count, unchecked((byte)Value));
	}

	// Delphi's first FillChar parameter is an untyped var parameter.  Newer
	// D2CSharp output therefore correctly emits `ref` for variables and arrays.
	// A C# ref argument does not participate in the normal Pointer conversions,
	// so provide a real generic ref overload here.
	public static void FillChar<T>(ref T X, int Count, byte Value)
	{
		if (Count <= 0)
			return;

		UntypedPointer PointerValue;
		if (TryGetVariablePointer(X, out PointerValue))
		{
			FillChar(PointerValue, Count, Value);
			return;
		}

		FillValueBytes(ref X, Count, Value);
	}

	public static void FillChar<T>(ref T X, int Count, char Value)
	{
		FillChar(ref X, Count, unchecked((byte)Value));
	}

	public static void FillChar<T>(ref T X, int Count, int Value)
	{
		FillChar(ref X, Count, unchecked((byte)Value));
	}

	public static void Move(UntypedPointer Source, UntypedPointer Dest, int Count)
	{
		DelphiMemory.Move(Source, Dest, Count);
	}

	public static void Move<TSource>(ref TSource Source, UntypedPointer Dest, int Count)
	{
		if (Count <= 0)
			return;

		UntypedPointer SourcePointer;
		if (TryGetVariablePointer(Source, out SourcePointer))
		{
			DelphiMemory.Move(SourcePointer, Dest, Count);
			return;
		}

		byte[] Bytes = ReadValueBytes(Source, Count);
		DelphiMemory.Move(new UntypedPointer(Bytes), Dest, Count);
	}

	public static void Move<TDest>(UntypedPointer Source, ref TDest Dest, int Count)
	{
		if (Count <= 0)
			return;

		UntypedPointer DestPointer;
		if (TryGetVariablePointer(Dest, out DestPointer))
		{
			DelphiMemory.Move(Source, DestPointer, Count);
			return;
		}

		byte[] Bytes = new byte[Count];
		DelphiMemory.Move(Source, new UntypedPointer(Bytes), Count);
		WriteValueBytes(ref Dest, Bytes, Count);
	}

	public static void Move<TSource, TDest>(ref TSource Source, ref TDest Dest, int Count)
	{
		if (Count <= 0)
			return;

		UntypedPointer SourcePointer;
		UntypedPointer DestPointer;
		bool HasSourcePointer = TryGetVariablePointer(Source, out SourcePointer);
		bool HasDestPointer = TryGetVariablePointer(Dest, out DestPointer);

		if (HasSourcePointer && HasDestPointer)
		{
			DelphiMemory.Move(SourcePointer, DestPointer, Count);
			return;
		}

		byte[] Bytes;
		if (HasSourcePointer)
		{
			Bytes = new byte[Count];
			DelphiMemory.Move(SourcePointer, new UntypedPointer(Bytes), Count);
		}
		else
		{
			Bytes = ReadValueBytes(Source, Count);
		}

		if (HasDestPointer)
		{
			DelphiMemory.Move(new UntypedPointer(Bytes), DestPointer, Count);
		}
		else
		{
			WriteValueBytes(ref Dest, Bytes, Count);
		}
	}
	public static void Initialize(UntypedPointer V)
	{
	}
	public static void Finalize(UntypedPointer V)
	{
	}
	public static void New(UntypedPointer P)
	{
	}
	public static void Dispose(UntypedPointer P)
	{
	}
	public static Pointer GetMem(ref Pointer P, int Size)
	{
		P = DelphiMemory.GetMem(Size);
		return P;
	}

	public static Pointer<T> GetMem<T>(ref Pointer<T> P, int Size)
	{
		Pointer RawPointer = DelphiMemory.GetMem(Size);
		P = (Pointer<T>)RawPointer;
		return P;
	}
	//# missing function body: public static Pointer GetMem(int Size);
	public static int FreeMem(Pointer P)
	{
		if (!P.IsNull())
			DelphiMemory.FreeMem(ref P);

		return 0;
	}

	public static int FreeMem(ref Pointer P)
	{
		if (!P.IsNull())
			DelphiMemory.FreeMem(ref P);

		return 0;
	}

	public static int FreeMem(ref UntypedPointer P)
	{
		if (!P.IsNull())
			DelphiMemory.FreeMem(ref P);

		return 0;
	}

	public static int FreeMem(ref PChar P)
	{
		if (!P.IsNull())
			DelphiMemory.FreeMem(ref P);

		return 0;
	}

	public static int FreeMem<T>(ref Pointer<T> P)
	{
		if (!P.IsNull())
			DelphiMemory.FreeMem(ref P);

		return 0;
	}
	//# missing function body: public static int FreeMem(Pointer P, int Size);
	public static void ReallocMem(ref Pointer P, int Size)
	{
		if (Size < 0)
			throw new global::System.ArgumentOutOfRangeException(nameof(Size));

		if (Size == 0)
		{
			if (!P.IsNull())
				DelphiMemory.FreeMem(ref P);
			return;
		}

		Pointer NewPointer = DelphiMemory.GetMem(Size);
		if (!P.IsNull())
		{
			int CopyCount = global::System.Math.Min(P.Length, Size);
			if (CopyCount > 0)
				DelphiMemory.Move(P, NewPointer.ToUntypedPointer(), CopyCount);

			DelphiMemory.FreeMem(ref P);
		}

		P = NewPointer;
	}

	public static void ReallocMem<T>(ref Pointer<T> P, int Size)
	{
		Pointer RawPointer = P.ToPointer();
		ReallocMem(ref RawPointer, Size);
		P = (Pointer<T>)RawPointer;
	}
	public static void MemoryBarrier()
	{
	}

	private static bool TryGetVariablePointer<T>(T Value, out UntypedPointer Result)
	{
		object BoxedValue = Value;

		if (BoxedValue == null)
		{
			Result = default;
			return false;
		}

		if (BoxedValue is UntypedPointer)
		{
			Result = (UntypedPointer)BoxedValue;
			return true;
		}

		if (BoxedValue is Pointer)
		{
			Result = ((Pointer)BoxedValue).ToUntypedPointer();
			return true;
		}

		if (BoxedValue is PChar)
		{
			Result = ((PChar)BoxedValue).ToUntypedPointer();
			return true;
		}

		if (BoxedValue is PAnsiChar)
		{
			Result = ((PAnsiChar)BoxedValue).ToUntypedPointer();
			return true;
		}

		Array ArrayValue = BoxedValue as Array;
		if (ArrayValue != null)
		{
			Result = new UntypedPointer(ArrayValue);
			return true;
		}

		// Pointer<T> cannot be pattern-matched without knowing T.  All RTL
		// Pointer<T> instances expose ToUntypedPointer(), so use that common
		// surface for the generic untyped-var helpers.
		global::System.Reflection.MethodInfo ToUntypedPointerMethod =
			BoxedValue.GetType().GetMethod(
				"ToUntypedPointer",
				global::System.Type.EmptyTypes);

		if (ToUntypedPointerMethod != null &&
			ToUntypedPointerMethod.ReturnType == typeof(UntypedPointer))
		{
			Result = (UntypedPointer)ToUntypedPointerMethod.Invoke(
				BoxedValue,
				null);
			return true;
		}

		Result = default;
		return false;
	}

	private static byte[] ReadValueBytes<T>(T Value, int Count)
	{
		if (Count < 0)
			throw new global::System.ArgumentOutOfRangeException(nameof(Count));

		if (typeof(T) == typeof(string))
		{
			string Text = (string)(object)Value;
			char[] Characters = (Text ?? string.Empty).ToCharArray();
			UntypedPointer TextPointer = new UntypedPointer(Characters);

			if (Count > TextPointer.Length)
				throw new global::System.ArgumentOutOfRangeException(nameof(Count));

			byte[] Result = new byte[Count];
			if (Count > 0)
				DelphiMemory.Move(TextPointer, new UntypedPointer(Result), Count);
			return Result;
		}

		global::System.Type ValueType = typeof(T);
		if (!ValueType.IsValueType)
		{
			throw new global::System.NotSupportedException(
				"Move requires a pointer, array, string, or value type for an untyped var argument.");
		}

		int Size = DelphiTypeLayout.SizeOf(ValueType);
		if (Count > Size)
			throw new global::System.ArgumentOutOfRangeException(nameof(Count));

		byte[] AllBytes = DelphiValueCodec.ToBytes(Value, ValueType, Size);
		byte[] Bytes = new byte[Count];
		global::System.Buffer.BlockCopy(AllBytes, 0, Bytes, 0, Count);
		return Bytes;
	}

	private static void WriteValueBytes<T>(ref T Value, byte[] Bytes, int Count)
	{
		if (Bytes == null)
			throw new global::System.ArgumentNullException(nameof(Bytes));
		if (Count < 0 || Count > Bytes.Length)
			throw new global::System.ArgumentOutOfRangeException(nameof(Count));

		if (typeof(T) == typeof(string))
		{
			string Text = (string)(object)Value;
			char[] Characters = (Text ?? string.Empty).ToCharArray();
			UntypedPointer TextPointer = new UntypedPointer(Characters);

			if (Count > TextPointer.Length)
				throw new global::System.ArgumentOutOfRangeException(nameof(Count));

			if (Count > 0)
				DelphiMemory.Move(new UntypedPointer(Bytes), TextPointer, Count);

			Value = (T)(object)new string(Characters);
			return;
		}

		global::System.Type ValueType = typeof(T);
		if (!ValueType.IsValueType)
		{
			throw new global::System.NotSupportedException(
				"Move requires a pointer, array, string, or value type for an untyped var argument.");
		}

		int Size = DelphiTypeLayout.SizeOf(ValueType);
		if (Count > Size)
			throw new global::System.ArgumentOutOfRangeException(nameof(Count));

		byte[] AllBytes = DelphiValueCodec.ToBytes(Value, ValueType, Size);
		global::System.Buffer.BlockCopy(Bytes, 0, AllBytes, 0, Count);
		Value = (T)DelphiValueCodec.FromBytes(AllBytes, ValueType);
	}

	private static void FillValueBytes<T>(ref T Value, int Count, byte FillValue)
	{
		if (Count < 0)
			throw new global::System.ArgumentOutOfRangeException(nameof(Count));

		if (typeof(T) == typeof(string))
		{
			string Text = (string)(object)Value;
			char[] Characters = (Text ?? string.Empty).ToCharArray();
			UntypedPointer TextPointer = new UntypedPointer(Characters);

			if (Count > TextPointer.Length)
				throw new global::System.ArgumentOutOfRangeException(nameof(Count));

			FillChar(TextPointer, Count, FillValue);
			Value = (T)(object)new string(Characters);
			return;
		}

		global::System.Type ValueType = typeof(T);
		if (!ValueType.IsValueType)
		{
			throw new global::System.NotSupportedException(
				"FillChar requires a pointer, array, string, or value type for an untyped var argument.");
		}

		int Size = DelphiTypeLayout.SizeOf(ValueType);
		if (Count > Size)
			throw new global::System.ArgumentOutOfRangeException(nameof(Count));

		byte[] Bytes = DelphiValueCodec.ToBytes(Value, ValueType, Size);
		for (int Index = 0; Index < Count; Index++)
			Bytes[Index] = FillValue;

		Value = (T)DelphiValueCodec.FromBytes(Bytes, ValueType);
	}

/* Atomic intrinsics */
	public static long AtomicIncrement(ref int Target)
	{
		return 0;
	}
	//# missing function body: public static long AtomicIncrement(ref long Target);
	//# missing function body: public static int AtomicIncrement(ref int Target, int Increment);
	//# missing function body: public static long AtomicIncrement(ref long Target, long Increment);
	public static long AtomicDecrement(ref int Target)
	{
		return 0;
	}
	//# missing function body: public static long AtomicDecrement(ref long Target);
	//# missing function body: public static int AtomicDecrement(ref int Target, int Decrement);
	//# missing function body: public static long AtomicDecrement(ref long Target, long Decrement);
	public static Pointer AtomicExchange(ref int Target, int Value)
	{
		return default;
	}
	//# missing function body: public static long AtomicExchange(ref long Target, long Value);
	//# missing function body: public static Pointer AtomicExchange(ref Pointer Target, Pointer Value);
	public static Pointer AtomicCmpExchange(ref int Target, int NewValue, int Comparand)
	{
		return default;
	}
	//# missing function body: public static long AtomicCmpExchange(ref long Target, long NewValue, long Comparand);
	//# missing function body: public static Pointer AtomicCmpExchange(ref Pointer Target, Pointer NewValue, Pointer Comparand);

/* String and dynamic-array intrinsics */
	public static int Length(string S)
	{
		return 0;
	}
//function Length(A): Integer; overload;
	public static string Copy(string S, int Index, int Count)
	{
		return string.Empty;
	}
//function Copy(A; Index, Count: Integer): Variant; overload;
	public static void Delete(ref string S, int Index, int Count)
	{
	}
	public static void Insert(string Source, ref string S, int Index)
	{
	}
	public static int Pos(string SubStr, string S)
	{
		return 0;
	}
	public static string Concat(string S1, string S2)
	{
		return (S1 ?? string.Empty) + (S2 ?? string.Empty);
	}

	// Delphi Concat accepts string-compatible arguments.  In particular a
	// character literal remains a C# char in current D2CSharp output.
	public static string Concat(params object[] Values)
	{
		if (Values == null || Values.Length == 0)
			return string.Empty;

		global::System.Text.StringBuilder Builder =
			new global::System.Text.StringBuilder();

		foreach (object Value in Values)
		{
			if (Value == null)
				continue;

			AnsiString AnsiValue = Value as AnsiString;
			if (AnsiValue != null)
				Builder.Append(AnsiValue.Decode());
			else
				Builder.Append(Value.ToString());
		}

		return Builder.ToString();
	}
	public static void SetLength(ref string S, int NewLength)
	{
		if (NewLength < 0)
			throw new global::System.ArgumentOutOfRangeException(nameof(NewLength));

		S ??= string.Empty;

		if (NewLength == S.Length)
			return;

		if (NewLength < S.Length)
		{
			S = S.Substring(0, NewLength);
			return;
		}

		S += new string('\0', NewLength - S.Length);
	}
	//# missing function body: public static void SetLength(UntypedPointer A, int NewLength);
	public static void SetString(ref string S, PChar Buffer, int Len)
	{
		if (Len < 0)
			throw new global::System.ArgumentOutOfRangeException(nameof(Len));

		S = Buffer.IsNull() ? string.Empty : Buffer.Substring(0, Len);
	}

	public static void SetString(ref string S, char[] Buffer, int Len)
	{
		if (Len < 0)
			throw new global::System.ArgumentOutOfRangeException(nameof(Len));

		if (Len == 0)
		{
			S = string.Empty;
			return;
		}

		if (Buffer == null)
			throw new global::System.ArgumentNullException(nameof(Buffer));
		if (Len > Buffer.Length)
			throw new global::System.ArgumentOutOfRangeException(nameof(Len));

		S = new string(Buffer, 0, Len);
	}
	//# output of equivalent "SetString" function suppressed
	//# missing function body: public static void SetString(ref AnsiString S, PAnsiChar Buffer, int Len);
	public static object Slice(out object A, int Count)
	{
		A = default;
		return default(object);
	}

/* Set intrinsics */

//procedure Include(var S; I);
//procedure Exclude(var S; I);

/* Variable modification intrinsics */
	public static void Inc(UntypedPointer X)
	{
	}
//procedure Inc(var X; N); overload;
	public static void Dec(UntypedPointer X)
	{
	}
//procedure Dec(var X; N); overload;

/* Flow-control intrinsics */
	//# missing function body: public static void Break();
	//# missing function body: public static void Continue();
	public static void Exit()
	{
	}
//procedure Exit(Value); overload;
	public static void Halt()
	{
	}
	//# missing function body: public static void Halt(int ExitCode);
	public static void RunError()
	{
	}
	//# missing function body: public static void RunError(byte ErrorCode);
	public static void Assert(bool Condition)
	{
	}
	//# missing function body: public static void Assert(bool Condition, string Message);
	public static void Fail()
	{
	}
	public static Pointer ReturnAddress()
	{
		return default;
	}

	/* Text and file intrinsics */
		public static void Assign(UntypedPointer F, string FileName)
		{
		}

        public static void AssignFile(
            global::System.DelphiFileRecord fileRecord,
            string fileName)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Assign(fileName);
        }

		public static void AssignFile(UntypedPointer F, string FileName)
		{
		}

		public static void Reset(UntypedPointer F)
		{
		}
		//# missing function body: public static void Reset(UntypedPointer F, int RecSize);
		public static void Rewrite(UntypedPointer F)
		{
		}
		//# missing function body: public static void Rewrite(UntypedPointer F, int RecSize);
		public static void Append(ref TextFile F)
		{
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            F.Append();
		}
		public static void Close(UntypedPointer F)
		{
		}
		public static void CloseFile(UntypedPointer F)
		{
		}
		public static void Erase(UntypedPointer F)
		{
		}

        public static void Rename(
            global::System.DelphiFileRecord fileRecord,
            string newName)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Rename(newName);
        }

		public static void Rename(UntypedPointer F, string NewName)
		{
		}
		public static void Flush(ref TextFile F)
		{
            F?.Writer?.Flush();
		}
		public static void SetTextBuf(ref TextFile F, UntypedPointer Buf)
		{
		}
		//# missing function body: public static void SetTextBuf(ref TextFile F, UntypedPointer Buf, int Size);
		public static bool Eof()
		{
			return global::System.Console.In.Peek() < 0;
		}
		//# missing function body: public static bool Eof(UntypedPointer F);
		public static bool Eoln()
		{
            int value = global::System.Console.In.Peek();
			return value < 0 || value == '\r' || value == '\n';
		}
		//# missing function body: public static bool Eoln(UntypedPointer F);
		public static bool SeekEof()
		{
			return Eof();
		}
		//# missing function body: public static bool SeekEof(UntypedPointer F);
		public static bool SeekEoln()
		{
			return Eoln();
		}
		//# missing function body: public static bool SeekEoln(UntypedPointer F);
		public static void Seek(UntypedPointer F, int N)
		{
		}
		public static int FilePos(UntypedPointer F)
		{
			return 0;
		}
		public static int FileSize(UntypedPointer F)
		{
			return 0;
		}
		public static void Truncate(UntypedPointer F)
		{
		}
		public static void BlockRead(UntypedPointer F, UntypedPointer Buf, int Count)
		{
		}
		//# missing function body: public static void BlockRead(UntypedPointer F, UntypedPointer Buf, int Count, ref int Result);
		public static void BlockWrite(UntypedPointer F, UntypedPointer Buf, int Count)
		{
		}
		//# missing function body: public static void BlockWrite(UntypedPointer F, UntypedPointer Buf, int Count, ref int Result);

        public static void GetDir(byte D, ref string S)
        {
            /*
             * Drive 0 means the current drive in Delphi.  For non-zero drive
             * values the precise per-drive current-directory semantics are
             * Windows-specific.  The working RTL currently exposes the process
             * current directory, which is also the useful cross-platform
             * fallback.
             */
            S = global::System.IO.Directory.GetCurrentDirectory();
        }

        public static void ChDir(string Path)
        {
            global::System.IO.Directory.SetCurrentDirectory(Path);
        }

        /*
         * Explicit Unicode overloads generated from the extended System.pas
         * mock.  These are the Unicode core API used by the AnsiString adapter
         * partial class.
         */
        public static void Read()
        {
        }

        public static void Read(ref string V)
        {
            V = global::System.Console.ReadLine() ?? string.Empty;
        }

        public static void Read(
            global::System.TTextRec F,
            ref string V)
        {
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            V = F.ReadString();
        }

        public static void Read(
            global::System.TextFile F,
            ref string V)
        {
            Read((global::System.TTextRec)F, ref V);
        }

        public static void ReadLn()
        {
            global::System.Console.ReadLine();
        }

        public static void ReadLn(ref string V)
        {
            V = global::System.Console.ReadLine() ?? string.Empty;
        }

        public static void ReadLn(global::System.TTextRec F)
        {
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            F.SkipLine();
        }

        public static void ReadLn(
            global::System.TTextRec F,
            ref string V)
        {
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            V = F.ReadLine();
        }

        public static void ReadLn(
            global::System.TextFile F,
            ref string V)
        {
            ReadLn((global::System.TTextRec)F, ref V);
        }

        /* Preserve the spelling emitted by older mock translations. */
        public static void Readln()
        {
            ReadLn();
        }

        public static void Write()
        {
        }

        public static void Write(string V)
        {
            global::System.Console.Write(V ?? string.Empty);
        }

        public static void Write(string V, int MinWidth)
        {
            global::System.Console.Write(FormatTextField(V, MinWidth));
        }

        public static void Write(
            global::System.TTextRec F,
            string V)
        {
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            F.Write(V ?? string.Empty);
        }

        public static void Write(
            global::System.TTextRec F,
            string V,
            int MinWidth)
        {
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            F.Write(FormatTextField(V, MinWidth));
        }

        public static void Write(
            global::System.TextFile F,
            string V)
        {
            Write((global::System.TTextRec)F, V);
        }

        public static void Write(
            global::System.TextFile F,
            string V,
            int MinWidth)
        {
            Write((global::System.TTextRec)F, V, MinWidth);
        }

        public static void WriteLn()
        {
            global::System.Console.WriteLine();
        }

        public static void WriteLn(string V)
        {
            global::System.Console.WriteLine(V ?? string.Empty);
        }

        public static void WriteLn(string V, int MinWidth)
        {
            global::System.Console.WriteLine(FormatTextField(V, MinWidth));
        }

        public static void WriteLn(global::System.TTextRec F)
        {
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            F.WriteLine();
        }

        public static void WriteLn(
            global::System.TTextRec F,
            string V)
        {
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            F.WriteLine(V ?? string.Empty);
        }

        public static void WriteLn(
            global::System.TTextRec F,
            string V,
            int MinWidth)
        {
            if (F == null)
                throw new global::System.ArgumentNullException(nameof(F));

            F.WriteLine(FormatTextField(V, MinWidth));
        }

        public static void WriteLn(
            global::System.TextFile F,
            string V)
        {
            WriteLn((global::System.TTextRec)F, V);
        }

        public static void WriteLn(
            global::System.TextFile F,
            string V,
            int MinWidth)
        {
            WriteLn((global::System.TTextRec)F, V, MinWidth);
        }

        /* Preserve the spelling emitted by older mock translations. */
        public static void Writeln()
        {
            WriteLn();
        }

        private static string FormatTextField(string value, int minWidth)
        {
            string result = value ?? string.Empty;
            if (minWidth > result.Length)
                return result.PadLeft(minWidth);

            return result;
        }

        public static void Str(int X, ref string S)
        {
            S = X.ToString(global::System.Globalization.CultureInfo.InvariantCulture);
        }

        public static void Val(string S, UntypedPointer V, ref int Code)
        {
            Code = 1;
        }

        public static void Val(string S, ref byte V, ref int Code)
        {
            ulong parsed;
            if (TryParseUnsignedInteger(S, out parsed) && parsed <= byte.MaxValue)
            {
                V = (byte)parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref sbyte V, ref int Code)
        {
            long parsed;
            if (TryParseSignedInteger(S, out parsed) && parsed >= sbyte.MinValue && parsed <= sbyte.MaxValue)
            {
                V = (sbyte)parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref short V, ref int Code)
        {
            long parsed;
            if (TryParseSignedInteger(S, out parsed) && parsed >= short.MinValue && parsed <= short.MaxValue)
            {
                V = (short)parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref ushort V, ref int Code)
        {
            ulong parsed;
            if (TryParseUnsignedInteger(S, out parsed) && parsed <= ushort.MaxValue)
            {
                V = (ushort)parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref uint V, ref int Code)
        {
            ulong parsed;
            if (TryParseUnsignedInteger(S, out parsed) && parsed <= uint.MaxValue)
            {
                V = (uint)parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref int V, ref int Code)
        {
            long parsed;
            if (TryParseSignedInteger(S, out parsed) && parsed >= int.MinValue && parsed <= int.MaxValue)
            {
                V = (int)parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref long V, ref int Code)
        {
            long parsed;
            if (TryParseSignedInteger(S, out parsed))
            {
                V = parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref ulong V, ref int Code)
        {
            ulong parsed;
            if (TryParseUnsignedInteger(S, out parsed))
            {
                V = parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref float V, ref int Code)
        {
            float parsed;
            if (float.TryParse(
                S,
                global::System.Globalization.NumberStyles.Float,
                global::System.Globalization.CultureInfo.InvariantCulture,
                out parsed))
            {
                V = parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        public static void Val(string S, ref double V, ref int Code)
        {
            double parsed;
            if (double.TryParse(
                S,
                global::System.Globalization.NumberStyles.Float,
                global::System.Globalization.CultureInfo.InvariantCulture,
                out parsed))
            {
                V = parsed;
                Code = 0;
                return;
            }

            Code = ValErrorCode(S);
        }

        private static bool TryParseSignedInteger(string value, out long result)
        {
            result = 0;
            if (value == null)
                return false;

            string text = value.Trim();
            if (text.Length == 0)
                return false;

            bool negative = false;
            int position = 0;
            if (text[position] == '+' || text[position] == '-')
            {
                negative = text[position] == '-';
                position++;
                if (position >= text.Length)
                    return false;
            }

            int numberBase = 10;
            if (text[position] == '$')
            {
                numberBase = 16;
                position++;
            }
            else if (text[position] == '%')
            {
                numberBase = 2;
                position++;
            }
            else if (text[position] == '&')
            {
                numberBase = 8;
                position++;
            }
            else if (position + 1 < text.Length &&
                     text[position] == '0' &&
                     (text[position + 1] == 'x' || text[position + 1] == 'X'))
            {
                numberBase = 16;
                position += 2;
            }

            if (position >= text.Length)
                return false;

            if (numberBase == 10)
            {
                return long.TryParse(
                    text,
                    global::System.Globalization.NumberStyles.Integer,
                    global::System.Globalization.CultureInfo.InvariantCulture,
                    out result);
            }

            ulong magnitude;
            if (!TryParseUnsignedDigits(text.Substring(position), numberBase, out magnitude))
                return false;

            if (negative)
            {
                ulong limit = ((ulong)long.MaxValue) + 1UL;
                if (magnitude > limit)
                    return false;

                result = magnitude == limit ? long.MinValue : -(long)magnitude;
            }
            else
            {
                if (magnitude > long.MaxValue)
                    return false;

                result = (long)magnitude;
            }

            return true;
        }

        private static bool TryParseUnsignedInteger(string value, out ulong result)
        {
            result = 0;
            if (value == null)
                return false;

            string text = value.Trim();
            if (text.Length == 0)
                return false;

            int position = 0;
            if (text[position] == '+')
            {
                position++;
                if (position >= text.Length)
                    return false;
            }
            else if (text[position] == '-')
            {
                return false;
            }

            int numberBase = 10;
            if (text[position] == '$')
            {
                numberBase = 16;
                position++;
            }
            else if (text[position] == '%')
            {
                numberBase = 2;
                position++;
            }
            else if (text[position] == '&')
            {
                numberBase = 8;
                position++;
            }
            else if (position + 1 < text.Length &&
                     text[position] == '0' &&
                     (text[position + 1] == 'x' || text[position + 1] == 'X'))
            {
                numberBase = 16;
                position += 2;
            }

            if (position >= text.Length)
                return false;

            if (numberBase == 10)
            {
                return ulong.TryParse(
                    text,
                    global::System.Globalization.NumberStyles.Integer,
                    global::System.Globalization.CultureInfo.InvariantCulture,
                    out result);
            }

            return TryParseUnsignedDigits(text.Substring(position), numberBase, out result);
        }

        private static bool TryParseUnsignedDigits(
            string digits,
            int numberBase,
            out ulong result)
        {
            result = 0;
            if (digits.Length == 0)
                return false;

            foreach (char ch in digits)
            {
                int digit;
                if (ch >= '0' && ch <= '9')
                    digit = ch - '0';
                else if (ch >= 'A' && ch <= 'F')
                    digit = ch - 'A' + 10;
                else if (ch >= 'a' && ch <= 'f')
                    digit = ch - 'a' + 10;
                else
                    return false;

                if (digit >= numberBase)
                    return false;

                ulong baseValue = (ulong)numberBase;
                if (result > (ulong.MaxValue - (ulong)digit) / baseValue)
                    return false;

                result = result * baseValue + (ulong)digit;
            }

            return true;
        }

        private static int ValErrorCode(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 1;

            /*
             * Delphi Val reports a 1-based error position.  For range/overflow
             * failures there is no invalid lexical character, so report the
             * position immediately after the input.
             */
            return value.Length + 1;
        }

        private static string FLocaleOverride = string.Empty;

        public static string ParamStr(int Index)
        {
            string[] arguments = global::System.Environment.GetCommandLineArgs();
            if (Index < 0 || Index >= arguments.Length)
                return string.Empty;

            return arguments[Index] ?? string.Empty;
        }

        public static string GetUILanguages(ushort LanguageID)
        {
            try
            {
                return global::System.Globalization.CultureInfo
                    .GetCultureInfo(LanguageID)
                    .Name;
            }
            catch (global::System.Globalization.CultureNotFoundException)
            {
                return string.Empty;
            }
        }

        public static string InternalGetLocaleOverride(string ApplicationName)
        {
            return FLocaleOverride;
        }

        public static string GetLocaleOverride(string ApplicationName)
        {
            return InternalGetLocaleOverride(ApplicationName);
        }

        public static void SetLocaleOverride(string Languages)
        {
            FLocaleOverride = Languages ?? string.Empty;
        }

/* Variant intrinsics */
	public static void VarClear(ref object V)
	{
	}
	public static void VarCopy(ref object Dest, object Source)
	{
	}
	public static void VarCast(ref object Dest, object Source, int VarType)
	{
	}
	public static void VarArrayRedim(ref object A, int HighBound)
	{
	}
        //break; continue;
        //uint HInstance; FileMode;
        //# missing function body: public static char Chr();
        //# missing function body: public static void Exclude();
        //# missing function body: public static void FreeAndNil();
        //# missing function body: public static int High();
        //# missing function body: public static void Include();
        //# missing function body: public static int Low();
        //# missing function body: public static int Ord();
        //# missing function body: public static int Pred();
        //# missing function body: public static int SizeOf();
        //# missing function body: public static string StringOfChar(ref char Ch, /*#_integer*/ object Count);
        //# missing function body: public static object TypeInfo();

        public static double Sqr(double value)
        {
            return value * value;
        }

    } // class SystemInterface


file class SystemImplementation
{


/* Numeric intrinsics */

/* Ordinal and type intrinsics */

/*
function Ord(X): Integer;
begin
end;

function Chr(X: Byte): Char;
begin
end;

function Succ(X): Integer;
begin
end;

function Pred(X): Integer;
begin
end;
*/

/*
function High(X): Integer;
begin
end;

function Low(X): Integer;
begin
end;

function SizeOf(X): NativeInt;
begin
end;

function Default(T): Variant;
begin
end;

function TypeInfo(T): PTypeInfo;
begin
end;

function TypeHandle(T): TTypeHandle;
begin
end;

function TypeOf(X): PTypeInfo;
begin
end;

function GetTypeKind(T): TTypeKind;
begin
end;

function IsManagedType(T): Boolean;
begin
end;

function HasWeakRef(T): Boolean;
begin
end;

function IsConstValue(Value): Boolean;
begin
end;
*/

/* object and memory intrinsics */

/* Atomic intrinsics */

/* String and dynamic-array intrinsics */

/*
function Length(A): Integer;
begin
end;
*/

/*
function Copy(A; Index, Count: Integer): Variant;
begin
end;
*/

/* Set intrinsics */

/*
procedure Include(var S; I);
begin
end;

procedure Exclude(var S; I);
begin
end;
*/

/* Variable modification intrinsics */

/*
procedure Inc(var X; N);
begin
end;
*/

/*
procedure Dec(var X; N);
begin
end;
*/

/* Flow-control intrinsics */

	public static void Break()
	{
	}

	public static void Continue()
	{
	}

/*
procedure Exit(Value);
begin
end;
*/

/* Text and file intrinsics */

/*
procedure Str(X; var S: string);
begin
end;
*/

/* Variant intrinsics */
} // class SystemImplementation

}  // namespace System
