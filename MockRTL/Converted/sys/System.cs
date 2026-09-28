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


public class SystemInterface
{

	public struct TResStringRec
	{
		public Pointer<uint> Module;
		public uint Identifier;
		public static TResStringRec CreateRecord(){return new TResStringRec();}
	}	

	public struct TTypeInfo
	{
		public TTypeKind Kind;
		public static TTypeInfo CreateRecord(){return new TTypeInfo();}
	}	
	public interface IInterface
	{
	}	

	public struct TInterfaceEntry
	{

		public static TInterfaceEntry CreateRecord(){return new TInterfaceEntry();}
	}	

	public struct TInterfaceTable
	{

		public static TInterfaceTable CreateRecord(){return new TInterfaceTable();}
	}	

	public class TMetaClass : TObject
	{


/* TMetaClass */
		public TMetaClass(Pointer AClassType)
		{
		}
		public string ClassName()
		{
			string result = string.Empty;
			return result;
		}
		public string QualifiedClassName()
		{
			string result = string.Empty;
			return result;
		}
		public string UnitName()
		{
			string result = string.Empty;
			return result;
		}
		public string UnitScope()
		{
			string result = string.Empty;
			return result;
		}
		public TMetaClass ClassParent()
		{
			TMetaClass result = default;
			return result;
		}
		public Pointer ClassInfo()
		{
			Pointer result = default;
			return result;
		}
		public TMetaClass ClassType()
		{
			TMetaClass result = default;
			return result;
		}
		public int InstanceSize()
		{
			int result = 0;
			return result;
		}
		public static bool InheritsFrom(TMetaClass AClass)
		{
			bool result = false;
			return result;
		}
		public bool ClassNameIs(string Name)
		{
			bool result = false;
			return result;
		}
		public TObject CreateInstance()
		{
			TObject result = default;
			return result;
		}
	}	

	public class TObject
	{


/* TObject */
		protected void CheckDisposed()/*# deprecated */
		{
		}
		protected bool GetDisposed()
		{
			bool result = false;
			return result;
		}
		public TObject()
		{
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
			}
		}
		public void Free()
		{
		}
		public void DisposeOf()/*# deprecated */
		{
		}
		public static /*#virtual*/ TObject NewInstance()
		{
			TObject result = default;
			return result;
		}
		public virtual void FreeInstance()
		{
		}
		public static TObject InitInstance(Pointer Instance)
		{
			TObject result = default;
			return result;
		}
		public void CleanupInstance()
		{
		}
		public virtual void AfterConstruction()
		{
		}
		public virtual void BeforeDestruction()
		{
		}
		public static string ClassName()
		{
			string result = string.Empty;
			return result;
		}
		public static string QualifiedClassName()
		{
			string result = string.Empty;
			return result;
		}
		public static string UnitName()
		{
			string result = string.Empty;
			return result;
		}
		public static string UnitScope()
		{
			string result = string.Empty;
			return result;
		}
		public static TClass ClassParent()
		{
			TClass result = default;
			return result;
		}
		public static Pointer ClassInfo()
		{
			Pointer result = default;
			return result;
		}
    // dme class 
		public static TClass ClassType()
		{
			TClass result = default;
			return result;
		}
		public static int InstanceSize()
		{
			int result = 0;
			return result;
		}

    // dme class 
		public static bool InheritsFrom(TClass AClass)
		{
			bool result = false;
			return result;
		} // dme
		public static bool ClassNameIs(string Name)
		{
			bool result = false;
			return result;
		}
		public Pointer FieldAddress(string Name)
		{
			Pointer result = default;
			return result;
		}
		public Pointer MethodAddress(string Name)
		{
			Pointer result = default;
			return result;
		}
		public string MethodName(Pointer Address)
		{
			string result = string.Empty;
			return result;
		}
		public virtual void Dispatch(UntypedPointer Message)
		{
		}
		public virtual void DefaultHandler(UntypedPointer Message)
		{
		}
		public static Pointer<TInterfaceEntry> GetInterfaceEntry(Guid IID)
		{
			Pointer<TInterfaceEntry> result = default;
			return result;
		}
		public static Pointer<TInterfaceTable> GetInterfaceTable()
		{
			Pointer<TInterfaceTable> result = default;
			return result;
		}
		public bool GetInterface(Guid IID, UntypedPointer Obj)
		{
			bool result = false;
			return result;
		}
		public virtual int SafeCallException(TObject ExceptObject, Pointer ExceptAddr)
		{
			int result = 0;
			return result;
		}
		public virtual bool Equals(TObject Obj)
		{
			bool result = false;
			return result;
		}
		public virtual int GetHashCode()
		{
			int result = 0;
			return result;
		}
		public virtual string ToString()
		{
			string result = string.Empty;
			return result;
		}
		/*property Disposed : bool read GetDisposed;*/
		public bool Disposed
		{
			get
			{
				return GetDisposed();
			}
		}
	}	

  /*
    Mock declaration for the Delphi reference-counted base class.

    IInterface remains a marker interface when USECOM is not defined.  The
    backing field is deliberately kept in the mock in both configurations so
    RefCount can be represented as a property without introducing a mock-only
    getter.  The hand-written C# RTL keeps the actual COM behavior conditional.
  */

	public class TInterfacedObject : TObject, IInterface
	{
		protected int FRefCount;
		/*property RefCount : int read FRefCount;*/
		public int RefCount
		{
			get
			{
				return FRefCount;
			}
		}

		public TInterfacedObject() {}
	}	

	public struct TTextRec
	{

		public static TTextRec CreateRecord(){return new TTextRec();}
	}	

	public struct TFileRec
	{

		public static TFileRec CreateRecord(){return new TFileRec();}
	}	

  /*
    Text, TextFile and File are Delphi compiler intrinsic file types.
    Do not alias them to TTextRec/TFileRec: those records describe the
    runtime representation, not the language-level file types.
  */
  /* Text = type TTextRec; */
  /* TextFile = type Text; */
  /* File = type TFileRec; */
  /*
    Public System-unit constants used by translated Delphi source.

    HRESULT error values are deliberately written as signed decimal Int32
    constants. This lets D2CSharp emit directly compilable C# int constants
    without requiring unchecked casts for $8000xxxx literals.
  */

	public class DynamicArray
	{
		public DynamicArray(){}
	}	/*
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
  Delphi-compatible declarations for the public System resource-string types.

  Independent source basis:
  Embarcadero RAD Studio API documentation for System.TResStringRec,
  System.PResStringRec and System.HMODULE.

  Insert these declarations in the type section of the MockRTL System.pas.
  HMODULE should only be declared here if it is not already present in System.pas.
*/

  /* System.HMODULE is publicly documented as Cardinal. */
	//#pragma pack (push, 1)

	//#pragma pack (pop)


  /*
    Text, TextFile and File are Delphi compiler intrinsic file types.
    Do not alias them to TTextRec/TFileRec: those records describe the
    runtime representation, not the language-level file types.
  */
  /* Text = type TTextRec; */
  /* TextFile = type Text; */
  /* File = type TFileRec; */
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
	public const Pointer Nil = ((Pointer) 0);
  /* Public System.FileMode variable used by Reset for typed and untyped files. */
	public static byte FileMode = 2;

/* Numeric intrinsics */
	public static int Abs(int X)
	{
		int result = 0;
		return result;
	}
	public static long Abs(long X)
	{
		long result = 0;
		return result;
	}
	public static float Abs(float X)
	{
		float result = 0.0F;
		return result;
	}
	public static double Abs(double X)
	{
		double result = 0.0D;
		return result;
	}
	//# output of equivalent "Abs" function suppressed
	public static int Sqr(int X)
	{
		int result = 0;
		return result;
	}
	public static long Sqr(long X)
	{
		long result = 0;
		return result;
	}
	public static float Sqr(float X)
	{
		float result = 0.0F;
		return result;
	}
	public static double Sqr(double X)
	{
		double result = 0.0D;
		return result;
	}
	//# output of equivalent "Sqr" function suppressed
	public static long Round(float X)
	{
		long result = 0;
		return result;
	}
	public static long Round(double X)
	{
		long result = 0;
		return result;
	}
	//# output of equivalent "Round" function suppressed
	public static long Trunc(float X)
	{
		long result = 0;
		return result;
	}
	public static long Trunc(double X)
	{
		long result = 0;
		return result;
	}
	//# output of equivalent "Trunc" function suppressed
	public static bool Odd(int X)
	{
		bool result = false;
		return result;
	}
	public static bool Odd(long X)
	{
		bool result = false;
		return result;
	}
	public static double Pi()
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInSin(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInCos(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInTan(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInArcTan(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInArcTan2(double Y, double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInSqrt(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInLn(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInLnXPlus1(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInLog2(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double BuiltInLog10(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static long MulDivInt64(long AValue, long AMul, long ADiv)
	{
		long result = 0;
		return result;
	}

/* Ordinal and type intrinsics */

//function Ord(X): Integer;
//function Chr(X: Byte): Char;
//function Succ(X): Integer;
//function Pred(X): Integer;
	public static byte Hi(int X)
	{
		byte result = 0;
		return result;
	}
	public static byte Hi(ushort X)
	{
		byte result = 0;
		return result;
	}
	public static byte Lo(int X)
	{
		byte result = 0;
		return result;
	}
	public static byte Lo(ushort X)
	{
		byte result = 0;
		return result;
	}
	public static ushort Swap(ushort X)
	{
		ushort result = 0;
		return result;
	}
	public static int Swap(int X)
	{
		int result = 0;
		return result;
	}

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


/*
  D2CSharp C# RTL note:

  Untyped Delphi var/const parameters below are represented by addressable C#
  values.  The hand-written System.cs therefore also supplies generic ref
  adapters for FillChar and Move and Pointer<T>-aware ref adapters for GetMem,
  FreeMem, and ReallocMem.  Pointer<T> is a C# RTL representation detail, so
  those adapter overloads are intentionally not modeled as separate Delphi
  declarations here.
*/
	public static Pointer Addr(UntypedPointer X)
	{
		Pointer result = default;
		return result;
	}
	public static Pointer Ptr(uint Address)
	{
		Pointer result = default;
		return result;
	}
	public static bool Assigned(Pointer P)
	{
		bool result = false;
		return result;
	}
	//# missing function body: public static bool Assigned(UntypedPointer P);
	public static void FillChar(UntypedPointer X, int Count, byte Value)
	{
	}
	public static void FillChar(UntypedPointer X, int Count, char Value)
	{
	}
	public static void FillChar(UntypedPointer X, int Count, int Value)
	{
	}
	public static void Move(UntypedPointer Source, UntypedPointer Dest, int Count)
	{
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
	public static void GetMem(ref Pointer P, int Size)
	{
	}
	public static Pointer GetMem(int Size)
	{
		Pointer result = default;
		return result;
	}
	public static void FreeMem(Pointer P)
	{
	}
	public static int FreeMem(Pointer P, int Size)
	{
		int result = 0;
		return result;
	}
	public static void ReallocMem(ref Pointer P, int Size)
	{
	}
	public static void MemoryBarrier()
	{
	}

/* Atomic intrinsics */
	public static int AtomicIncrement(ref int Target)
	{
		int result = 0;
		return result;
	}
	public static long AtomicIncrement(ref long Target)
	{
		long result = 0;
		return result;
	}
	public static int AtomicIncrement(ref int Target, int Increment)
	{
		int result = 0;
		return result;
	}
	public static long AtomicIncrement(ref long Target, long Increment)
	{
		long result = 0;
		return result;
	}
	public static int AtomicDecrement(ref int Target)
	{
		int result = 0;
		return result;
	}
	public static long AtomicDecrement(ref long Target)
	{
		long result = 0;
		return result;
	}
	public static int AtomicDecrement(ref int Target, int Decrement)
	{
		int result = 0;
		return result;
	}
	public static long AtomicDecrement(ref long Target, long Decrement)
	{
		long result = 0;
		return result;
	}
	public static int AtomicExchange(ref int Target, int Value)
	{
		int result = 0;
		return result;
	}
	public static long AtomicExchange(ref long Target, long Value)
	{
		long result = 0;
		return result;
	}
	public static Pointer AtomicExchange(ref Pointer Target, Pointer Value)
	{
		Pointer result = default;
		return result;
	}
	public static int AtomicCmpExchange(ref int Target, int NewValue, int Comparand)
	{
		int result = 0;
		return result;
	}
	public static long AtomicCmpExchange(ref long Target, long NewValue, long Comparand)
	{
		long result = 0;
		return result;
	}
	public static Pointer AtomicCmpExchange(ref Pointer Target, Pointer NewValue, Pointer Comparand)
	{
		Pointer result = default;
		return result;
	}

/* String and dynamic-array intrinsics */
	public static int Length(string S)
	{
		int result = 0;
		return result;
	}
//function Length(A): Integer; overload;
	public static string Copy(string S, int Index, int Count)
	{
		string result = string.Empty;
		return result;
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
		int result = 0;
		return result;
	}
	public static string Concat(string S1, string S2)
	{
		string result = string.Empty;
		return result;
	}
	public static string Concat(string S1, string S2, string S3)
	{
		string result = string.Empty;
		return result;
	}
	public static string Concat(string S1, string S2, string S3, string S4)
	{
		string result = string.Empty;
		return result;
	}
	public static string Concat(string S1, string S2, string S3, string S4, string S5)
	{
		string result = string.Empty;
		return result;
	}
	public static string Concat(string S1, string S2, string S3, string S4, string S5, string S6)
	{
		string result = string.Empty;
		return result;
	}
	public static string Concat(string S1, string S2, string S3, string S4, string S5, string S6, string S7)
	{
		string result = string.Empty;
		return result;
	}
	public static string Concat(string S1, string S2, string S3, string S4, string S5, string S6, string S7, string S8)
	{
		string result = string.Empty;
		return result;
	}
	public static string Concat(params TVarRec[] Values)
	{
		string result = string.Empty;
		return result;
	}
	public static void SetLength(ref string S, int NewLength)
	{
	}
	public static void SetLength(UntypedPointer A, int NewLength)
	{
	}
	public static void SetString(ref string S, PChar Buffer, int Len)
	{
	}
/* C# char[] adapter used when a Delphi Char array is translated as an array. */
	public static void SetString(ref string S, char[] Buffer, int Len)
	{
	}
	public static void SetString(ref AnsiString S, PAnsiChar Buffer, int Len)
	{
	}
	public static void SetString(ref string S, PChar Buffer, int Len)
	{
	}
	public static object Slice(out object A, int Count)
	{
		object result = default(object);
		return result;
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
	public static void Break()
	{
	}
	public static void Continue()
	{
	}
	public static void Exit()
	{
	}
//procedure Exit(Value); overload;
	public static void Halt()
	{
	}
	public static void Halt(int ExitCode)
	{
	}
	public static void RunError()
	{
	}
	public static void RunError(byte ErrorCode)
	{
	}
	public static void Assert(bool Condition)
	{
	}
	public static void Assert(bool Condition, string Message)
	{
	}
	public static void Fail()
	{
	}
	public static Pointer ReturnAddress()
	{
		Pointer result = default;
		return result;
	}

/* Text and file intrinsics */

/*
  File-intrinsic signatures are declaration-only mock metadata.
  The typed forms below follow the public RAD Studio API documentation and
  deliberately avoid an untyped first parameter, because D2CSharp uses these
  declarations when translating calls.
*/
	public static void Assign(ref file F, string FileName)
	{
	}
	public static void Assign(ref TextFile F, string FileName)
	{
	}
	public static void AssignFile(file F, string FileName)
	{
	}
	public static void AssignFile(TextFile F, string FileName)
	{
	}
	public static void AssignFile(TextFile F, string FileName, ushort CodePage)
	{
	}
	public static void Reset(ref file F)
	{
	}
	public static void Reset(ref file F, int RecSize)
	{
	}
	public static void Rewrite(ref file F)
	{
	}
	public static void Rewrite(ref file F, int RecSize)
	{
	}
	public static void Append(ref TextFile F)
	{
	}
	public static void Close(ref file F)
	{
	}
	public static void CloseFile(ref file F)
	{
	}
	public static void Erase(ref file F)
	{
	}
	public static void Rename(ref file F, string NewName)
	{
	}
	public static int Flush(ref TextFile F)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static void SetTextBuf(ref TextFile F, UntypedPointer Buf)
	{
	}
	public static void SetTextBuf(ref TextFile F, UntypedPointer Buf, int Size)
	{
	}
	public static bool Eof()
	{
		bool result = false;
		return result;
	}
	public static bool Eof(ref file F)
	{
		bool result = false;
		return result;
	}
	public static bool Eoln()
	{
		bool result = false;
		return result;
	}
	public static bool Eoln(ref TextFile F)
	{
		bool result = false;
		return result;
	}
	public static bool SeekEof()
	{
		bool result = false;
		return result;
	}
	public static bool SeekEof(ref TextFile F)
	{
		bool result = false;
		return result;
	}
	public static bool SeekEoln()
	{
		bool result = false;
		return result;
	}
	public static bool SeekEoln(ref TextFile F)
	{
		bool result = false;
		return result;
	}
	public static void Seek(ref file F, int N)
	{
	}
	public static int FilePos(ref file F)
	{
		int result = 0;
		return result;
	}
	public static int FileSize(ref file F)
	{
		int result = 0;
		return result;
	}
	public static void Truncate(ref file F)
	{
	}
	public static void BlockRead(ref file F, UntypedPointer Buf, int Count)
	{
	}
	public static void BlockRead(ref file F, UntypedPointer Buf, int Count, ref int Result)
	{
	}
	public static void BlockWrite(ref file F, UntypedPointer Buf, int Count)
	{
	}
	public static void BlockWrite(ref file F, UntypedPointer Buf, int Count, ref int Result)
	{
	}
	public static void GetDir(byte D, ref string S)
	{
	}
	public static void ChDir(string Path)
	{
	}

/*
  D2CSharp mock overloads with explicit Unicode string types.
  Keep the untyped compiler-intrinsic forms below for parser coverage, while
  these typed forms give the C# translation concrete string/ref string APIs
  that can be used by the AnsiString compatibility layer.
*/
	public static void Read()
	{
	}
	public static void Read(ref file F, UntypedPointer V)
	{
	}
	public static void Read(UntypedPointer V)
	{
	}
	public static void Read(ref string V)
	{
	}
	public static void Read(TextFile F, ref string V)
	{
	}
	public static void ReadLn()
	{
	}
	public static void ReadLn(ref file F)
	{
	}
	public static void ReadLn(ref file F, UntypedPointer V)
	{
	}
	public static void ReadLn(UntypedPointer V)
	{
	}
	public static void ReadLn(ref string V)
	{
	}
	public static void ReadLn(TextFile F, ref string V)
	{
	}
	public static void Write()
	{
	}
	public static void Write(UntypedPointer V)
	{
	}
	public static void Write(ref file F, UntypedPointer V)
	{
	}
	public static void Write(string V)
	{
	}
	public static void Write(string V, int MinWidth)
	{
	}
	public static void Write(TextFile F, string V)
	{
	}
	public static void Write(TextFile F, string V, int MinWidth)
	{
	}
	public static void WriteLn()
	{
	}
	public static void WriteLn(UntypedPointer V)
	{
	}
	public static void WriteLn(ref file F)
	{
	}
	public static void WriteLn(ref file F, UntypedPointer V)
	{
	}
	public static void WriteLn(string V)
	{
	}
	public static void WriteLn(string V, int MinWidth)
	{
	}
	public static void WriteLn(TextFile F, string V)
	{
	}
	public static void WriteLn(TextFile F, string V, int MinWidth)
	{
	}
	public static void Str(int X, ref string S)
	{
	}
	public static void Str(long X, ref string S)
	{
	}
	public static void Str(float X, ref string S)
	{
	}
	public static void Str(double X, ref string S)
	{
	}
	//# output of equivalent "Str" function suppressed
	public static void Str(Currency X, ref string S)
	{
	}
	public static void Str(int X, int Width, ref string S)
	{
	}
	public static void Str(long X, int Width, ref string S)
	{
	}
	public static void Str(float X, int Width, ref string S)
	{
	}
	public static void Str(double X, int Width, ref string S)
	{
	}
	//# output of equivalent "Str" function suppressed
	public static void Str(Currency X, int Width, ref string S)
	{
	}
	public static void Str(int X, int Width, int Decimals, ref string S)
	{
	}
	public static void Str(long X, int Width, int Decimals, ref string S)
	{
	}
	public static void Str(float X, int Width, int Decimals, ref string S)
	{
	}
	public static void Str(double X, int Width, int Decimals, ref string S)
	{
	}
	//# output of equivalent "Str" function suppressed
	public static void Str(Currency X, int Width, int Decimals, ref string S)
	{
	}

// Omit the untyped var overload: Delphi handles Val as an intrinsic.
// Explicit typed overloads let the converter select the correct numeric conversion.

// Signed integer types
	public static void Val(string S, ref sbyte V, ref int Code)
	{
	}
	public static void Val(string S, ref short V, ref int Code)
	{
	}
	public static void Val(string S, ref int V, ref int Code)
	{
	}
	public static void Val(string S, ref long V, ref int Code)
	{
	}
	//# missing function body: public static void Val(string S, ref int V, ref int Code);

// Unsigned integer types
	public static void Val(string S, ref byte V, ref int Code)
	{
	}
	public static void Val(string S, ref ushort V, ref int Code)
	{
	}
	public static void Val(string S, ref uint V, ref int Code)
	{
	}
	public static void Val(string S, ref ulong V, ref int Code)
	{
	}
//in C++ equivalent procedure Val(const S: string; var V: NativeUInt; var Code: Integer); overload;

// Floating-point types
	public static void Val(string S, ref float V, ref int Code)
	{
	}
	public static void Val(string S, ref double V, ref int Code)
	{
	}
	//# output of equivalent "Val" function suppressed
	//# output of equivalent "Val" function suppressed

// Additional numeric types
	//# missing function body: public static void Val(string S, ref long V, ref int Code);
	public static void Val(string S, ref Currency V, ref int Code)
	{
	}



/* Unicode counterparts used by hand-written AnsiString RTL adapters. */
	public static string ParamStr(int Index)
	{
		string result = string.Empty;
		return result;
	}
	public static string GetUILanguages(ushort LanguageID)
	{
		string result = string.Empty;
		return result;
	}
	public static string InternalGetLocaleOverride(string ApplicationName)
	{
		string result = string.Empty;
		return result;
	}
	public static string GetLocaleOverride(string ApplicationName)
	{
		string result = string.Empty;
		return result;
	}
	public static void SetLocaleOverride(string Languages)
	{
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
	} break; continue;
	//# missing function body: public static int SizeOf();
	//# missing function body: public static int Pred();
	
} // class SystemInterface


file class SystemImplementation
{


/* TInterfacedObject */  

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

/* Pointer and memory intrinsics */

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

/*
procedure Exit(Value);
begin
end;
*/

/* Text and file intrinsics */


// Signed integer types


// Unsigned integer types


//procedure Val(const S: string; var V: NativeUInt; var Code: Integer);
//begin
//end;

// Floating-point types


// Additional numeric types


/* Variant intrinsics */
} // class SystemImplementation

}  // namespace System

