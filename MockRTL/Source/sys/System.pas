{
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
}

unit System;

interface

type
  { Basic placeholder types needed by the D2CSharp parser. }
  ShortInt = -128..127;
  Byte = 0..255;
  SmallInt = -32768..32767;
  Word = 0..65535;

  Integer = -2147483648..2147483647;
  Cardinal = 0..4294967295;
  LongInt = Integer;
  LongWord = Cardinal;

  Int8 = ShortInt;
  UInt8 = Byte;
  Int16 = SmallInt;
  UInt16 = Word;
  Int32 = Integer;
  UInt32 = Cardinal;
  Int64 = type Integer;
  UInt64 = type Cardinal;

  NativeInt = Integer;
  NativeUInt = Cardinal;
  THandle = NativeUInt;

  Boolean = (False, True);

  AnsiChar = type Byte;
  WideChar = type Word;
  Char = WideChar;

  Pointer = ^Byte;
  PPointer = ^Pointer;
  PByte = ^Byte;
  PWord = ^Word;
  PInteger = ^Integer;
  PCardinal = ^Cardinal;
  PLongInt = ^LongInt;
  PLongWord = ^LongWord;
  PInt64 = ^Int64;
  PUInt64 = ^UInt64;

  PChar = ^Char;
  PAnsiChar = ^AnsiChar;
  PWideChar = ^WideChar;

  string = type UnicodeString;
  UnicodeString = type string;
  AnsiString = type string;
  WideString = type string;
  RawByteString = type AnsiString;

  Single = type Real;
  Double = type Real;
  Extended = type Real;
  Real = type Double;
  Currency = type Int64;
  Comp = type Int64;

  Variant = type record
  end;

  OleVariant = type Variant;

  TDateTime = type Double;
  HRESULT = LongInt;
  HResult = HRESULT;

  {
    Managed MockRTL representation of a Delphi resource-string record.
    The native module/identifier layout is intentionally not modeled here.
    The completed C# RTL provides the managed TResStringRec implementation.
  }
  TResStringRec = record
    FMessage: string;
  end;

  PResStringRec = ^TResStringRec;

  TTypeKind = (
    tkUnknown,
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
    tkProcedure
  );

  PTypeInfo = ^TTypeInfo;
  TTypeInfo = record
    Kind: TTypeKind;
  end;

  TTypeHandle = Pointer;

  TGUID = record
    D1: Cardinal;
    D2: Word;
    D3: Word;
    D4: array[0..7] of Byte;
  end;

  PGUID = ^TGUID;

  IInterface = interface
    ['{00000000-0000-0000-C000-000000000046}']
{$IFDEF USECOM}
    function QueryInterface(const IID: TGUID; out Obj): HRESULT;
    function _AddRef: Integer;
    function _Release: Integer;
{$ENDIF}
  end;

  IUnknown = IInterface;

  TObject = class;
  TClass = class of TObject;
  TMetaClass = class;

  PInterfaceEntry = ^TInterfaceEntry;
  PInterfaceTable = ^TInterfaceTable;

  TInterfaceEntry = record
  end;

  TInterfaceTable = record
  end;
  
  TMetaClass = class
  public
    constructor Create(AClassType: Pointer);

    function ClassName: string;
    function QualifiedClassName: string;
    function UnitName: string;
    function UnitScope: string;

    function ClassParent: TMetaClass;
    function ClassInfo: Pointer;
    function ClassType: TMetaClass;
    function InstanceSize: Longint;

    class function InheritsFrom(AClass: TMetaClass): Boolean;
    function ClassNameIs(const Name: string): Boolean;

    function CreateInstance: TObject;
  end;

  TObject = class
  protected
    procedure CheckDisposed; deprecated;
    function GetDisposed: Boolean;

  public
    constructor Create;
    destructor Destroy; virtual;

    procedure Free;
    procedure DisposeOf; deprecated;

    class function NewInstance: TObject; virtual;
    procedure FreeInstance; virtual;

    class function InitInstance(Instance: Pointer): TObject;
    procedure CleanupInstance;

    procedure AfterConstruction; virtual;
    procedure BeforeDestruction; virtual;

    class function ClassName: string;
    class function QualifiedClassName: string;
    class function UnitName: string;
    class function UnitScope: string;

    class function ClassParent: TClass;
    class function ClassInfo: Pointer;
    // dme class 
    function ClassType: TClass;
    class function InstanceSize: Longint;

    // dme class 
    function InheritsFrom(AClass: TClass): Boolean; // dme
    class function ClassNameIs(const Name: string): Boolean;

    function FieldAddress(const Name: string): Pointer;
    function MethodAddress(const Name: string): Pointer;
    function MethodName(Address: Pointer): string;

    procedure Dispatch(var Message); virtual;
    procedure DefaultHandler(var Message); virtual;

    class function GetInterfaceEntry(const IID: TGUID): PInterfaceEntry;
    class function GetInterfaceTable: PInterfaceTable;
    function GetInterface(const IID: TGUID; out Obj): Boolean;

    function SafeCallException(ExceptObject: TObject; ExceptAddr: Pointer): HResult; virtual;

    function Equals(Obj: TObject): Boolean; virtual;
    function GetHashCode: Integer; virtual;
    function ToString: string; virtual;

    property Disposed: Boolean read GetDisposed;
  end;

  {
    Mock declaration for the Delphi reference-counted base class.

    IInterface remains a marker interface when USECOM is not defined.  The
    backing field is deliberately kept in the mock in both configurations so
    RefCount can be represented as a property without introducing a mock-only
    getter.  The hand-written C# RTL keeps the actual COM behavior conditional.
  }
  TInterfacedObject = class(TObject, IInterface)
  protected
    FRefCount: Integer;
  public
{$IFDEF USECOM}
    function QueryInterface(const IID: TGUID; out Obj): HRESULT; virtual;
    function _AddRef: Integer; virtual;
    function _Release: Integer; virtual;
{$ENDIF}
    property RefCount: Integer read FRefCount;
  end;

  TTextRec = record
  end;

  TFileRec = record
  end;

  {
    Text, TextFile and File are Delphi compiler intrinsic file types.
    Do not alias them to TTextRec/TFileRec: those records describe the
    runtime representation, not the language-level file types.
  }
  { Text = type TTextRec; }
  { TextFile = type Text; }
  { File = type TFileRec; }

const
  {
    Public System-unit constants used by translated Delphi source.

    HRESULT error values are deliberately written as signed decimal Int32
    constants. This lets D2CSharp emit directly compilable C# int constants
    without requiring unchecked casts for $8000xxxx literals.
  }
  S_OK = 0;
  S_FALSE = 1;
  E_NOINTERFACE = -2147467262;  { $80004002 }
  E_UNEXPECTED  = -2147418113;  { $8000FFFF }
  E_NOTIMPL     = -2147467263;  { $80004001 }

  { Common public System constants useful during source translation. }
  MaxInt = 2147483647;
  MaxLongInt = 2147483647;

  CP_ACP = 0;
  CP_UTF7 = 65000;              { $FDE8 }
  CP_UTF8 = 65001;              { $FDE9 }

  fmClosed = 55216;             { $D7B0 }
  fmInput  = 55217;             { $D7B1 }
  fmOutput = 55218;             { $D7B2 }
  fmInOut  = 55219;             { $D7B3 }

  Nil = Pointer(0);

var
  { Public System.FileMode variable used by Reset for typed and untyped files. }
  FileMode: Byte = 2;

{ Numeric intrinsics }

function Abs(X: Integer): Integer; overload;
function Abs(X: Int64): Int64; overload;
function Abs(X: Single): Single; overload;
function Abs(X: Double): Double; overload;
function Abs(X: Extended): Extended; overload;

function Sqr(X: Integer): Integer; overload;
function Sqr(X: Int64): Int64; overload;
function Sqr(X: Single): Single; overload;
function Sqr(X: Double): Double; overload;
function Sqr(X: Extended): Extended; overload;

function Round(X: Single): Int64; overload;
function Round(X: Double): Int64; overload;
function Round(X: Extended): Int64; overload;

function Trunc(X: Single): Int64; overload;
function Trunc(X: Double): Int64; overload;
function Trunc(X: Extended): Int64; overload;

function Odd(X: Integer): Boolean; overload;
function Odd(X: Int64): Boolean; overload;

function Pi: Extended;

function BuiltInSin(X: Extended): Extended;
function BuiltInCos(X: Extended): Extended;
function BuiltInTan(X: Extended): Extended;
function BuiltInArcTan(X: Extended): Extended;
function BuiltInArcTan2(Y, X: Extended): Extended;
function BuiltInSqrt(X: Extended): Extended;
function BuiltInLn(X: Extended): Extended;
function BuiltInLnXPlus1(X: Extended): Extended;
function BuiltInLog2(X: Extended): Extended;
function BuiltInLog10(X: Extended): Extended;

function MulDivInt64(AValue, AMul, ADiv: Int64): Int64;

{ Ordinal and type intrinsics }

//function Ord(X): Integer;
//function Chr(X: Byte): Char;
//function Succ(X): Integer;
//function Pred(X): Integer;

function Hi(X: Integer): Byte; overload;
function Hi(X: Word): Byte; overload;
function Lo(X: Integer): Byte; overload;
function Lo(X: Word): Byte; overload;
function Swap(X: Word): Word; overload;
function Swap(X: Integer): Integer; overload;

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

{ Pointer and memory intrinsics }

{
  D2CSharp C# RTL note:

  Untyped Delphi var/const parameters below are represented by addressable C#
  values.  The hand-written System.cs therefore also supplies generic ref
  adapters for FillChar and Move and Pointer<T>-aware ref adapters for GetMem,
  FreeMem, and ReallocMem.  Pointer<T> is a C# RTL representation detail, so
  those adapter overloads are intentionally not modeled as separate Delphi
  declarations here.
}

function Addr(var X): Pointer;
function Ptr(Address: NativeUInt): Pointer;
function Assigned(P: Pointer): Boolean; overload;
function Assigned(var P): Boolean; overload;

procedure FillChar(var X; Count: NativeInt; Value: Byte); overload;
procedure FillChar(var X; Count: NativeInt; Value: Char); overload;
procedure FillChar(var X; Count: NativeInt; Value: Integer); overload;

procedure Move(const Source; var Dest; Count: NativeInt);

procedure Initialize(var V);
procedure Finalize(var V);

procedure New(var P);
procedure Dispose(var P);

procedure GetMem(var P: Pointer; Size: NativeInt); overload;
function GetMem(Size: NativeInt): Pointer; overload;

procedure FreeMem(P: Pointer); overload;
function FreeMem(P: Pointer; Size: NativeInt): Integer; overload;

procedure ReallocMem(var P: Pointer; Size: NativeInt);

procedure MemoryBarrier;

{ Atomic intrinsics }

function AtomicIncrement(var Target: Integer): Integer; overload;
function AtomicIncrement(var Target: Int64): Int64; overload;
function AtomicIncrement(var Target: Integer; Increment: Integer): Integer; overload;
function AtomicIncrement(var Target: Int64; Increment: Int64): Int64; overload;

function AtomicDecrement(var Target: Integer): Integer; overload;
function AtomicDecrement(var Target: Int64): Int64; overload;
function AtomicDecrement(var Target: Integer; Decrement: Integer): Integer; overload;
function AtomicDecrement(var Target: Int64; Decrement: Int64): Int64; overload;

function AtomicExchange(var Target: Integer; Value: Integer): Integer; overload;
function AtomicExchange(var Target: Int64; Value: Int64): Int64; overload;
function AtomicExchange(var Target: Pointer; Value: Pointer): Pointer; overload;

function AtomicCmpExchange(var Target: Integer; NewValue, Comparand: Integer): Integer; overload;
function AtomicCmpExchange(var Target: Int64; NewValue, Comparand: Int64): Int64; overload;
function AtomicCmpExchange(var Target: Pointer; NewValue, Comparand: Pointer): Pointer; overload;

{ String and dynamic-array intrinsics }

function Length(S: string): Integer; overload;
//function Length(A): Integer; overload;

function Copy(S: string; Index, Count: Integer): string; overload;
//function Copy(A; Index, Count: Integer): Variant; overload;

procedure Delete(var S: string; Index, Count: Integer);

procedure Insert(Source: string; var S: string; Index: Integer);

function Pos(SubStr: string; S: string): Integer;

function Concat(const S1, S2: string): string; overload;
function Concat(const S1, S2, S3: string): string; overload;
function Concat(const S1, S2, S3, S4: string): string; overload;
function Concat(const S1, S2, S3, S4, S5: string): string; overload;
function Concat(const S1, S2, S3, S4, S5, S6: string): string; overload;
function Concat(const S1, S2, S3, S4, S5, S6, S7: string): string; overload;
function Concat(const S1, S2, S3, S4, S5, S6, S7, S8: string): string; overload;

function Concat(const Values: array of const): string; overload;

procedure SetLength(var S: string; NewLength: Integer); overload;
procedure SetLength(var A; NewLength: Integer); overload;

procedure SetString(var S: string; Buffer: PChar; Len: Integer); overload;
{ C# char[] adapter used when a Delphi Char array is translated as an array. }
procedure SetString(var S: string; const Buffer: array of Char; Len: Integer); overload;
procedure SetString(var S: AnsiString; Buffer: PAnsiChar; Len: Integer); overload;
procedure SetString(var S: UnicodeString; Buffer: PWideChar; Len: Integer); overload;

function Slice(var A; Count: Integer): Variant;

{ Set intrinsics }

//procedure Include(var S; I);
//procedure Exclude(var S; I);

{ Variable modification intrinsics }

procedure Inc(var X); overload;
//procedure Inc(var X; N); overload;

procedure Dec(var X); overload;
//procedure Dec(var X; N); overload;

{ Flow-control intrinsics }

procedure Break;
procedure Continue;
procedure Exit; overload;
//procedure Exit(Value); overload;
procedure Halt; overload;
procedure Halt(ExitCode: Integer); overload;
procedure RunError; overload;
procedure RunError(ErrorCode: Byte); overload;
procedure Assert(Condition: Boolean); overload;
procedure Assert(Condition: Boolean; const Message: string); overload;
procedure Fail;

function ReturnAddress: Pointer;

{ Text and file intrinsics }

{
  File-intrinsic signatures are declaration-only mock metadata.
  The typed forms below follow the public RAD Studio API documentation and
  deliberately avoid an untyped first parameter, because D2CSharp uses these
  declarations when translating calls.
}
procedure Assign(var F: File; const FileName: string); overload;
procedure Assign(var F: TextFile; const FileName: string); overload;
procedure AssignFile(F: File; const FileName: string); overload;
procedure AssignFile(F: TextFile; const FileName: string); overload;
procedure AssignFile(F: TextFile; const FileName: string; CodePage: Word); overload;

procedure Reset(var F: File); overload;
procedure Reset(var F: File; RecSize: Integer); overload;

procedure Rewrite(var F: File); overload;
procedure Rewrite(var F: File; RecSize: Integer); overload;

procedure Append(var F: Text);

procedure Close(var F: File);
procedure CloseFile(var F: File);

procedure Erase(var F: File);
procedure Rename(var F: File; const NewName: string);

function Flush(var F: Text): Integer;
procedure SetTextBuf(var F: Text; var Buf); overload;
procedure SetTextBuf(var F: Text; var Buf; Size: Integer); overload;

function Eof: Boolean; overload;
function Eof(var F: File): Boolean; overload;

function Eoln: Boolean; overload;
function Eoln(var F: Text): Boolean; overload;

function SeekEof: Boolean; overload;
function SeekEof(var F: Text): Boolean; overload;

function SeekEoln: Boolean; overload;
function SeekEoln(var F: Text): Boolean; overload;

procedure Seek(var F: File; N: Integer);
function FilePos(var F: File): Integer;
function FileSize(var F: File): Integer;
procedure Truncate(var F: File);

procedure BlockRead(var F: File; var Buf; Count: Integer); overload;
procedure BlockRead(var F: File; var Buf; Count: Integer; var Result: Integer); overload;

procedure BlockWrite(var F: File; const Buf; Count: Integer); overload;
procedure BlockWrite(var F: File; const Buf; Count: Integer; var Result: Integer); overload;

procedure GetDir(D: Byte; var S: string);
procedure ChDir(const Path: string);

{
  D2CSharp mock overloads with explicit Unicode string types.
  Keep the untyped compiler-intrinsic forms below for parser coverage, while
  these typed forms give the C# translation concrete string/ref string APIs
  that can be used by the AnsiString compatibility layer.
}
procedure Read; overload;
procedure Read(var F: File; var V); overload;
procedure Read(var V); overload;
procedure Read(var V: string); overload;
procedure Read(F: Text; var V: string); overload;

procedure ReadLn; overload;
procedure ReadLn(var F: File); overload;
procedure ReadLn(var F: File; var V); overload;
procedure ReadLn(var V); overload;
procedure ReadLn(var V: string); overload;
procedure ReadLn(F: Text; var V: string); overload;

procedure Write; overload;
procedure Write(const V); overload;
procedure Write(var F: File; const V); overload;
procedure Write(const V: string); overload;
procedure Write(const V: string; MinWidth: Integer); overload;
procedure Write(F: Text; const V: string); overload;
procedure Write(F: Text; const V: string; MinWidth: Integer); overload;

procedure WriteLn; overload;
procedure WriteLn(const V); overload;
procedure WriteLn(var F: File); overload;
procedure WriteLn(var F: File; const V); overload;
procedure WriteLn(const V: string); overload;
procedure WriteLn(const V: string; MinWidth: Integer); overload;
procedure WriteLn(F: Text; const V: string); overload;
procedure WriteLn(F: Text; const V: string; MinWidth: Integer); overload;

procedure Str(X: Integer; var S: String); overload;
procedure Str(X: Int64; var S: String); overload;
procedure Str(X: Single; var S: String); overload;
procedure Str(X: Double; var S: String); overload;
procedure Str(X: Extended; var S: String); overload;
procedure Str(X: Currency; var S: String); overload;
procedure Str(X: Integer; Width: Integer; var S: String); overload;
procedure Str(X: Int64; Width: Integer; var S: String); overload;
procedure Str(X: Single; Width: Integer; var S: String); overload;
procedure Str(X: Double; Width: Integer; var S: String); overload;
procedure Str(X: Extended; Width: Integer; var S: String); overload;
procedure Str(X: Currency; Width: Integer; var S: String); overload;
procedure Str(X: Integer; Width: Integer; Decimals: Integer; var S: String); overload;
procedure Str(X: Int64; Width: Integer; Decimals: Integer; var S: String); overload;
procedure Str(X: Single; Width: Integer; Decimals: Integer; var S: String); overload;
procedure Str(X: Double; Width: Integer; Decimals: Integer; var S: String); overload;
procedure Str(X: Extended; Width: Integer; Decimals: Integer; var S: String); overload;
procedure Str(X: Currency; Width: Integer; Decimals: Integer; var S: String); overload;

// Omit the untyped var overload: Delphi handles Val as an intrinsic.
// Explicit typed overloads let the converter select the correct numeric conversion.

// Signed integer types
procedure Val(const S: string; var V: ShortInt; var Code: Integer); overload;
procedure Val(const S: string; var V: SmallInt; var Code: Integer); overload;
procedure Val(const S: string; var V: Integer; var Code: Integer); overload;
procedure Val(const S: string; var V: Int64; var Code: Integer); overload;
procedure Val(const S: string; var V: NativeInt; var Code: Integer); overload;

// Unsigned integer types
procedure Val(const S: string; var V: Byte; var Code: Integer); overload;
procedure Val(const S: string; var V: Word; var Code: Integer); overload;
procedure Val(const S: string; var V: Cardinal; var Code: Integer); overload;
procedure Val(const S: string; var V: UInt64; var Code: Integer); overload;
//in C++ equivalent procedure Val(const S: string; var V: NativeUInt; var Code: Integer); overload;

// Floating-point types
procedure Val(const S: string; var V: Single; var Code: Integer); overload;
procedure Val(const S: string; var V: Double; var Code: Integer); overload;
procedure Val(const S: string; var V: Extended; var Code: Integer); overload;
procedure Val(const S: string; var V: Real48; var Code: Integer); overload;

// Additional numeric types
procedure Val(const S: string; var V: Comp; var Code: Integer); overload;
procedure Val(const S: string; var V: Currency; var Code: Integer); overload;



{ Unicode counterparts used by hand-written AnsiString RTL adapters. }
function ParamStr(Index: Integer): string;
function GetUILanguages(LanguageID: Word): string;
function InternalGetLocaleOverride(const ApplicationName: string): string;
function GetLocaleOverride(const ApplicationName: string): string;
procedure SetLocaleOverride(const Languages: string);

{ Variant intrinsics }

procedure VarClear(var V: Variant);
procedure VarCopy(var Dest: Variant; const Source: Variant);
procedure VarCast(var Dest: Variant; const Source: Variant; VarType: Integer);
procedure VarArrayRedim(var A: Variant; HighBound: Integer);

implementation

{ TMetaClass }

constructor TMetaClass.Create(AClassType: Pointer);
begin
end;

function TMetaClass.ClassName: string;
begin
end;

function TMetaClass.QualifiedClassName: string;
begin
end;

function TMetaClass.UnitName: string;
begin
end;

function TMetaClass.UnitScope: string;
begin
end;

function TMetaClass.ClassParent: TMetaClass;
begin
end;

function TMetaClass.ClassInfo: Pointer;
begin
end;

function TMetaClass.ClassType: TMetaClass;
begin
end;

function TMetaClass.InstanceSize: Longint;
begin
end;

class function TMetaClass.InheritsFrom(AClass: TMetaClass): Boolean;
begin
end;

function TMetaClass.ClassNameIs(const Name: string): Boolean;
begin
end;

function TMetaClass.CreateInstance: TObject;
begin
end;

{ TObject }

procedure TObject.CheckDisposed;
begin
end;

function TObject.GetDisposed: Boolean;
begin
end;

constructor TObject.Create;
begin
end;

destructor TObject.Destroy;
begin
end;

procedure TObject.Free;
begin
end;

procedure TObject.DisposeOf;
begin
end;

class function TObject.NewInstance: TObject;
begin
end;

procedure TObject.FreeInstance;
begin
end;

class function TObject.InitInstance(Instance: Pointer): TObject;
begin
end;

procedure TObject.CleanupInstance;
begin
end;

procedure TObject.AfterConstruction;
begin
end;

procedure TObject.BeforeDestruction;
begin
end;

class function TObject.ClassName: string;
begin
end;

class function TObject.QualifiedClassName: string;
begin
end;

class function TObject.UnitName: string;
begin
end;

class function TObject.UnitScope: string;
begin
end;

class function TObject.ClassParent: TClass;
begin
end;

class function TObject.ClassInfo: Pointer;
begin
end;

class function TObject.ClassType: TClass;
begin
end;

class function TObject.InstanceSize: Longint;
begin
end;

class function TObject.InheritsFrom(AClass: TClass): Boolean;
begin
end;

class function TObject.ClassNameIs(const Name: string): Boolean;
begin
end;

function TObject.FieldAddress(const Name: string): Pointer;
begin
end;

function TObject.MethodAddress(const Name: string): Pointer;
begin
end;

function TObject.MethodName(Address: Pointer): string;
begin
end;

procedure TObject.Dispatch(var Message);
begin
end;

procedure TObject.DefaultHandler(var Message);
begin
end;

class function TObject.GetInterfaceEntry(const IID: TGUID): PInterfaceEntry;
begin
end;

class function TObject.GetInterfaceTable: PInterfaceTable;
begin
end;

function TObject.GetInterface(const IID: TGUID; out Obj): Boolean;
begin
end;

function TObject.SafeCallException(ExceptObject: TObject; ExceptAddr: Pointer): HResult;
begin
end;

function TObject.Equals(Obj: TObject): Boolean;
begin
end;

function TObject.GetHashCode: Integer;
begin
end;

function TObject.ToString: string;
begin
end;

{ TInterfacedObject }

{$IFDEF USECOM}
function TInterfacedObject.QueryInterface(const IID: TGUID; out Obj): HRESULT;
begin
end;

function TInterfacedObject._AddRef: Integer;
begin
end;

function TInterfacedObject._Release: Integer;
begin
end;
{$ENDIF}

{ Numeric intrinsics }

function Abs(X: Integer): Integer;
begin
end;

function Abs(X: Int64): Int64;
begin
end;

function Abs(X: Single): Single;
begin
end;

function Abs(X: Double): Double;
begin
end;

function Abs(X: Extended): Extended;
begin
end;

function Sqr(X: Integer): Integer;
begin
end;

function Sqr(X: Int64): Int64;
begin
end;

function Sqr(X: Single): Single;
begin
end;

function Sqr(X: Double): Double;
begin
end;

function Sqr(X: Extended): Extended;
begin
end;

function Round(X: Single): Int64;
begin
end;

function Round(X: Double): Int64;
begin
end;

function Round(X: Extended): Int64;
begin
end;

function Trunc(X: Single): Int64;
begin
end;

function Trunc(X: Double): Int64;
begin
end;

function Trunc(X: Extended): Int64;
begin
end;

function Odd(X: Integer): Boolean;
begin
end;

function Odd(X: Int64): Boolean;
begin
end;

function Pi: Extended;
begin
end;

function BuiltInSin(X: Extended): Extended;
begin
end;

function BuiltInCos(X: Extended): Extended;
begin
end;

function BuiltInTan(X: Extended): Extended;
begin
end;

function BuiltInArcTan(X: Extended): Extended;
begin
end;

function BuiltInArcTan2(Y, X: Extended): Extended;
begin
end;

function BuiltInSqrt(X: Extended): Extended;
begin
end;

function BuiltInLn(X: Extended): Extended;
begin
end;

function BuiltInLnXPlus1(X: Extended): Extended;
begin
end;

function BuiltInLog2(X: Extended): Extended;
begin
end;

function BuiltInLog10(X: Extended): Extended;
begin
end;

function MulDivInt64(AValue, AMul, ADiv: Int64): Int64;
begin
end;

{ Ordinal and type intrinsics }

{
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
}

function Hi(X: Integer): Byte;
begin
end;

function Hi(X: Word): Byte;
begin
end;

function Lo(X: Integer): Byte;
begin
end;

function Lo(X: Word): Byte;
begin
end;

function Swap(X: Word): Word;
begin
end;

function Swap(X: Integer): Integer;
begin
end;

(*
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
*)

{ Pointer and memory intrinsics }

function Addr(var X): Pointer;
begin
end;

function Ptr(Address: NativeUInt): Pointer;
begin
end;

function Assigned(P: Pointer): Boolean;
begin
end;

function Assigned(var P): Boolean;
begin
end;

procedure FillChar(var X; Count: NativeInt; Value: Byte);
begin
end;

procedure FillChar(var X; Count: NativeInt; Value: Char);
begin
end;

procedure FillChar(var X; Count: NativeInt; Value: Integer);
begin
end;

procedure Move(const Source; var Dest; Count: NativeInt);
begin
end;

procedure Initialize(var V);
begin
end;

procedure Finalize(var V);
begin
end;

procedure New(var P);
begin
end;

procedure Dispose(var P);
begin
end;

procedure GetMem(var P: Pointer; Size: NativeInt);
begin
end;

function GetMem(Size: NativeInt): Pointer;
begin
end;

procedure FreeMem(P: Pointer);
begin
end;

function FreeMem(P: Pointer; Size: NativeInt): Integer;
begin
end;

procedure ReallocMem(var P: Pointer; Size: NativeInt);
begin
end;

procedure MemoryBarrier;
begin
end;

{ Atomic intrinsics }

function AtomicIncrement(var Target: Integer): Integer;
begin
end;

function AtomicIncrement(var Target: Int64): Int64;
begin
end;

function AtomicIncrement(var Target: Integer; Increment: Integer): Integer;
begin
end;

function AtomicIncrement(var Target: Int64; Increment: Int64): Int64;
begin
end;

function AtomicDecrement(var Target: Integer): Integer;
begin
end;

function AtomicDecrement(var Target: Int64): Int64;
begin
end;

function AtomicDecrement(var Target: Integer; Decrement: Integer): Integer;
begin
end;

function AtomicDecrement(var Target: Int64; Decrement: Int64): Int64;
begin
end;

function AtomicExchange(var Target: Integer; Value: Integer): Integer;
begin
end;

function AtomicExchange(var Target: Int64; Value: Int64): Int64;
begin
end;

function AtomicExchange(var Target: Pointer; Value: Pointer): Pointer;
begin
end;

function AtomicCmpExchange(var Target: Integer; NewValue, Comparand: Integer): Integer;
begin
end;

function AtomicCmpExchange(var Target: Int64; NewValue, Comparand: Int64): Int64;
begin
end;

function AtomicCmpExchange(var Target: Pointer; NewValue, Comparand: Pointer): Pointer;
begin
end;

{ String and dynamic-array intrinsics }

function Length(S: string): Integer;
begin
end;

(*
function Length(A): Integer;
begin
end;
*)

function Copy(S: string; Index, Count: Integer): string;
begin
end;

(*
function Copy(A; Index, Count: Integer): Variant;
begin
end;
*)

procedure Delete(var S: string; Index, Count: Integer);
begin
end;

procedure Insert(Source: string; var S: string; Index: Integer);
begin
end;

function Pos(SubStr: string; S: string): Integer;
begin
end;


function Concat(const S1, S2: string): string;
begin
end;

function Concat(const S1, S2, S3: string): string;
begin
end;

function Concat(const S1, S2, S3, S4: string): string;
begin
end;

function Concat(const S1, S2, S3, S4, S5: string): string;
begin
end;

function Concat(const S1, S2, S3, S4, S5, S6: string): string;
begin
end;

function Concat(const S1, S2, S3, S4, S5, S6, S7: string): string;
begin
end;

function Concat(const S1, S2, S3, S4, S5, S6, S7, S8: string): string;
begin
end;

function Concat(const Values: array of const): string;
begin
end;


procedure SetLength(var S: string; NewLength: Integer);
begin
end;

procedure SetLength(var A; NewLength: Integer);
begin
end;

procedure SetString(var S: string; Buffer: PChar; Len: Integer);
begin
end;

procedure SetString(var S: string; const Buffer: array of Char; Len: Integer);
begin
end;

procedure SetString(var S: AnsiString; Buffer: PAnsiChar; Len: Integer);
begin
end;

procedure SetString(var S: UnicodeString; Buffer: PWideChar; Len: Integer);
begin
end;

function Slice(var A; Count: Integer): Variant;
begin
end;

{ Set intrinsics }

(*
procedure Include(var S; I);
begin
end;

procedure Exclude(var S; I);
begin
end;
*)

{ Variable modification intrinsics }

procedure Inc(var X);
begin
end;

(*
procedure Inc(var X; N);
begin
end;
*)

procedure Dec(var X);
begin
end;

(*
procedure Dec(var X; N);
begin
end;
*)

{ Flow-control intrinsics }

procedure Break;
begin
end;

procedure Continue;
begin
end;

procedure Exit;
begin
end;

(*
procedure Exit(Value);
begin
end;
*)

procedure Halt;
begin
end;

procedure Halt(ExitCode: Integer);
begin
end;

procedure RunError;
begin
end;

procedure RunError(ErrorCode: Byte);
begin
end;

procedure Assert(Condition: Boolean);
begin
end;

procedure Assert(Condition: Boolean; const Message: string);
begin
end;

procedure Fail;
begin
end;

function ReturnAddress: Pointer;
begin
end;

{ Text and file intrinsics }

procedure Assign(var F: File; const FileName: string);
begin
end;

procedure Assign(var F: TextFile; const FileName: string);
begin
end;

procedure AssignFile(F: File; const FileName: string);
begin
end;

procedure AssignFile(F: TextFile; const FileName: string);
begin
end;

procedure AssignFile(F: TextFile; const FileName: string; CodePage: Word);
begin
end;

procedure Reset(var F: File);
begin
end;

procedure Reset(var F: File; RecSize: Integer);
begin
end;

procedure Rewrite(var F: File);
begin
end;

procedure Rewrite(var F: File; RecSize: Integer);
begin
end;

procedure Append(var F: Text);
begin
end;

procedure Close(var F: File);
begin
end;

procedure CloseFile(var F: File);
begin
end;

procedure Erase(var F: File);
begin
end;

procedure Rename(var F: File; const NewName: string);
begin
end;

function Flush(var F: Text): Integer;
begin
  Result := 0;
end;

procedure SetTextBuf(var F: Text; var Buf);
begin
end;

procedure SetTextBuf(var F: Text; var Buf; Size: Integer);
begin
end;

function Eof: Boolean;
begin
end;

function Eof(var F: File): Boolean;
begin
end;

function Eoln: Boolean;
begin
end;

function Eoln(var F: Text): Boolean;
begin
end;

function SeekEof: Boolean;
begin
end;

function SeekEof(var F: Text): Boolean;
begin
end;

function SeekEoln: Boolean;
begin
end;

function SeekEoln(var F: Text): Boolean;
begin
end;

procedure Seek(var F: File; N: Integer);
begin
end;

function FilePos(var F: File): Integer;
begin
end;

function FileSize(var F: File): Integer;
begin
end;

procedure Truncate(var F: File);
begin
end;

procedure BlockRead(var F: File; var Buf; Count: Integer);
begin
end;

procedure BlockRead(var F: File; var Buf; Count: Integer; var Result: Integer);
begin
end;

procedure BlockWrite(var F: File; const Buf; Count: Integer);
begin
end;

procedure BlockWrite(var F: File; const Buf; Count: Integer; var Result: Integer);
begin
end;

procedure GetDir(D: Byte; var S: string);
begin
end;

procedure ChDir(const Path: string);
begin
end;

procedure Read;
begin
end;

procedure Read(var F: File; var V);
begin
end;

procedure Read(var V);
begin
end;

procedure Read(var V: string);
begin
end;

procedure Read(F: Text; var V: string);
begin
end;

procedure ReadLn;
begin
end;

procedure ReadLn(var F: File);
begin
end;

procedure ReadLn(var F: File; var V);
begin
end;

procedure ReadLn(var V);
begin
end;

procedure ReadLn(var V: string);
begin
end;

procedure ReadLn(F: Text; var V: string);
begin
end;

procedure Write;
begin
end;

procedure Write(const V);
begin
end;

procedure Write(var F: File; const V);
begin
end;

procedure Write(const V: string);
begin
end;

procedure Write(const V: string; MinWidth: Integer);
begin
end;

procedure Write(F: Text; const V: string);
begin
end;

procedure Write(F: Text; const V: string; MinWidth: Integer);
begin
end;

procedure WriteLn;
begin
end;

procedure WriteLn(const V);
begin
end;

procedure WriteLn(var F: File);
begin
end;

procedure WriteLn(var F: File; const V);
begin
end;

procedure WriteLn(const V: string);
begin
end;

procedure WriteLn(const V: string; MinWidth: Integer);
begin
end;

procedure WriteLn(F: Text; const V: string);
begin
end;

procedure WriteLn(F: Text; const V: string; MinWidth: Integer);
begin
end;


procedure Str(X: Integer; var S: String); overload;
begin
end;

procedure Str(X: Int64; var S: String); overload;
begin
end;

procedure Str(X: Single; var S: String); overload;
begin
end;

procedure Str(X: Double; var S: String); overload;
begin
end;

procedure Str(X: Extended; var S: String); overload;
begin
end;

procedure Str(X: Currency; var S: String); overload;
begin
end;

procedure Str(X: Integer; Width: Integer; var S: String); overload;
begin
end;

procedure Str(X: Int64; Width: Integer; var S: String); overload;
begin
end;

procedure Str(X: Single; Width: Integer; var S: String); overload;
begin
end;

procedure Str(X: Double; Width: Integer; var S: String); overload;
begin
end;

procedure Str(X: Extended; Width: Integer; var S: String); overload;
begin
end;

procedure Str(X: Currency; Width: Integer; var S: String); overload;
begin
end;

procedure Str(X: Integer; Width: Integer; Decimals: Integer; var S: String); overload;
begin
end;

procedure Str(X: Int64; Width: Integer; Decimals: Integer; var S: String); overload;
begin
end;

procedure Str(X: Single; Width: Integer; Decimals: Integer; var S: String); overload;
begin
end;

procedure Str(X: Double; Width: Integer; Decimals: Integer; var S: String); overload;
begin
end;

procedure Str(X: Extended; Width: Integer; Decimals: Integer; var S: String); overload;
begin
end;

procedure Str(X: Currency; Width: Integer; Decimals: Integer; var S: String); overload;
begin
end;


// Signed integer types

procedure Val(const S: string; var V: ShortInt; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: SmallInt; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: Integer; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: Int64; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: NativeInt; var Code: Integer);
begin
end;

// Unsigned integer types

procedure Val(const S: string; var V: Byte; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: Word; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: Cardinal; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: UInt64; var Code: Integer);
begin
end;

//procedure Val(const S: string; var V: NativeUInt; var Code: Integer);
//begin
//end;

// Floating-point types

procedure Val(const S: string; var V: Single; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: Double; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: Extended; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: Real48; var Code: Integer);
begin
end;

// Additional numeric types

procedure Val(const S: string; var V: Comp; var Code: Integer);
begin
end;

procedure Val(const S: string; var V: Currency; var Code: Integer);
begin
end;


function ParamStr(Index: Integer): string;
begin
end;

function GetUILanguages(LanguageID: Word): string;
begin
end;

function InternalGetLocaleOverride(const ApplicationName: string): string;
begin
end;

function GetLocaleOverride(const ApplicationName: string): string;
begin
end;

procedure SetLocaleOverride(const Languages: string);
begin
end;

{ Variant intrinsics }

procedure VarClear(var V: Variant);
begin
end;

procedure VarCopy(var Dest: Variant; const Source: Variant);
begin
end;

procedure VarCast(var Dest: Variant; const Source: Variant; VarType: Integer);
begin
end;

procedure VarArrayRedim(var A: Variant; HighBound: Integer);
begin
end;

end.
