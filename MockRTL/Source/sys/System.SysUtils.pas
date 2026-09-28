{
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.SysUtils functionality required by D2CSharp.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The routines below intentionally contain no RTL implementation.  Functions
  return simple default values and procedures have empty bodies.

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

unit System.SysUtils;

interface

const
  { File open modes }
  fmOpenRead       = $0000;
  fmOpenWrite      = $0001;
  fmOpenReadWrite  = $0002;
  fmExclusive      = $0004;
  fmShareCompat    = $0000;
  fmShareExclusive = $0010;
  fmShareDenyWrite = $0020;
  fmShareDenyRead  = $0030;
  fmShareDenyNone  = $0040;

  { File attribute constants }
  faInvalid    = -1;
  faReadOnly   = $00000001;
  faHidden     = $00000002;
  faSysFile    = $00000004;
  faVolumeID   = $00000008;
  faDirectory  = $00000010;
  faArchive    = $00000020;
  faNormal     = $00000080;
  faTemporary  = $00000100;
  faSymLink    = $00000400;
  faCompressed = $00000800;
  faEncrypted  = $00004000;
  faVirtual    = $00010000;
  faAnyFile    = $000001FF;

type
  { Keep simple value types first so their translation can be verified
    independently from the special Exception handling. }
  TFloatFormat = (
    ffGeneral,
    ffExponent,
    ffFixed,
    ffNumber,
    ffCurrency
  );

  TReplaceFlag = (
    rfReplaceAll,
    rfIgnoreCase
  );
  TReplaceFlags = set of TReplaceFlag;

  TTextLineBreakStyle = (
    tlbsCRLF,
    tlbsLF
  );

  TFilenameCaseMatch = (
    mkNone,
    mkExactMatch,
    mkSingleMatch,
    mkAmbiguous
  );

  TCmdLineSwitchType = (
    clstValueNextParam,
    clstValueAppended
  );
  TCmdLineSwitchTypes = set of TCmdLineSwitchType;

  TSysCharSet = set of Char;

  TLocaleOptions = (
    loInvariantLocale,
    loUserLocale
  );

  TMbcsByteType = (
    mbSingleByte,
    mbLeadByte,
    mbTrailByte
  );

  TFileSystemAttribute = (
    fsCaseSensitive,
    fsCasePreserving,
    fsLocal,
    fsNetwork,
    fsRemovable,
    fsSymLink
  );
  TFileSystemAttributes = set of TFileSystemAttribute;

  TFloatValue = (
    fvExtended,
    fvCurrency
  );

  TFloatRec = packed record
  public
    Exponent: SmallInt;
    Negative: Boolean;
    Digits: array[0..20] of Byte;
  end;

  TNameType = (
    ntContainsUnit,
    ntRequiresPackage,
    ntDcpBpiName
  );

  { Callback/procedural types used by the public SysUtils package and
    termination APIs. }
  HMODULE = THandle;
  TProcedure = procedure;
  TTerminateProc = function: Boolean;
  TValidatePackageProc = function(Module: HMODULE): Boolean;
  TPackageInfoProc = procedure(
    const Name: string;
    NameType: TNameType;
    Flags: Byte;
    Param: Pointer
  );
  TGrowCollectionFunc = function(
    OldCapacity, NewCount: NativeInt
  ): NativeInt;

  TFileSystemAttributes = set of TFileSystemAttribute;

  { Windows API compatibility types required by the public SysUtils records.
    These mirror the publicly documented FILETIME / WIN32_FIND_DATAW layout;
    they are dependencies of TSearchRec and TSymLinkRec, not SysUtils-owned API. }
  TFileTime = record
  public
    dwLowDateTime: Cardinal;
    dwHighDateTime: Cardinal;
  end;

  TSystemTime = record
  public
    wYear: Word;
    wMonth: Word;
    wDayOfWeek: Word;
    wDay: Word;
    wHour: Word;
    wMinute: Word;
    wSecond: Word;
    wMilliseconds: Word;
  end;

  TWin32FindData = record
  public
    dwFileAttributes: Cardinal;
    ftCreationTime: TFileTime;
    ftLastAccessTime: TFileTime;
    ftLastWriteTime: TFileTime;
    nFileSizeHigh: Cardinal;
    nFileSizeLow: Cardinal;
    dwReserved0: Cardinal;
    dwReserved1: Cardinal;
    cFileName: array[0..259] of WideChar;
    cAlternateFileName: array[0..13] of WideChar;
  end;

  TEraInfo = record
  public
    EraName: string;
    EraOffset: Integer;
    EraStart: TDateTime;
    EraEnd: TDateTime;
  end;

  TFormatSettings = record
    CurrencyFormat: Byte;
    NegCurrFormat: Byte;
    ThousandSeparator: Char;
    DecimalSeparator: Char;
    CurrencyDecimals: Byte;
    DateSeparator: Char;
    TimeSeparator: Char;
    ListSeparator: Char;
    CurrencyString: string;
    ShortDateFormat: string;
    LongDateFormat: string;
    TimeAMString: string;
    TimePMString: string;
    ShortTimeFormat: string;
    LongTimeFormat: string;
    ShortMonthNames: array[1..12] of string;
    LongMonthNames: array[1..12] of string;
    ShortDayNames: array[1..7] of string;
    LongDayNames: array[1..7] of string;
    EraInfo: array of TEraInfo;
    TwoDigitYearCenturyWindow: Word;
    NormalizedLocaleName: string;

    class function Create: TFormatSettings; overload; static;
    class function Create(Locale: TLocaleID): TFormatSettings; overload; static;
    class function Create(const LocaleName: string): TFormatSettings; overload; static;
    class function Invariant: TFormatSettings; static;
    function GetEraYearOffset(const Name: string): Integer;
  end;

  TSearchRec = record
  private
    function GetCreationTime: TDateTime;
    function GetLastAccessTime: TDateTime;
    function GetTimeStamp: TDateTime;
  public
    Time: Integer;
    Size: Int64;
    Attr: Integer;
    Name: string;
    ExcludeAttr: Integer;
    FindHandle: THandle;
    FindData: TWin32FindData;
    property CreationTime: TDateTime read GetCreationTime;
    property LastAccessTime: TDateTime read GetLastAccessTime;
    property TimeStamp: TDateTime read GetTimeStamp;
  end;

  TSymLinkRec = record
  private
    function GetTimeStamp: TDateTime;
  public
    TargetName: string;
    Attr: Integer;
    Size: Int64;
    FindData: TWin32FindData;
    property TimeStamp: TDateTime read GetTimeStamp;
  end;

  TDateTimeInfoRec = record
  private
    Data: TWin32FindData;
    function GetCreationTime: TDateTime;
    function GetLastAccessTime: TDateTime;
    function GetTimeStamp: TDateTime;
  public
    property CreationTime: TDateTime read GetCreationTime;
    property LastAccessTime: TDateTime read GetLastAccessTime;
    property TimeStamp: TDateTime read GetTimeStamp;
  end;

  TTimeStamp = record
    Time: Integer;
    Date: Integer;
  end;

  TLocaleID = Cardinal;

  TSysLocale = packed record
    DefaultLCID: TLocaleID;
    PriLangID: Integer;
    SubLangID: Integer;
    FarEast: Boolean;
    MiddleEast: Boolean;
  end;

  {
    Delphi exception declarations used as translation metadata.

    D2CSharp/Delphi2C# maps System.SysUtils.Exception to DException in C#.
    The Pascal declarations retain the Delphi names and inheritance hierarchy.
    The C# runtime implementation provides the .NET-specific DException base.
  }
  Exception = class(TObject)
  public
    constructor Create(const Msg: string);
    constructor CreateFmt(const Msg: string; const Args: array of const);

    constructor CreateRes(Ident: NativeUInt); overload;
    constructor CreateRes(ResStringRec: PResStringRec); overload;

    constructor CreateResFmt(
      Ident: NativeUInt;
      const Args: array of const
    ); overload;
    constructor CreateResFmt(
      ResStringRec: PResStringRec;
      const Args: array of const
    ); overload;

    constructor CreateHelp(
      const Msg: string;
      AHelpContext: Integer
    );
    constructor CreateFmtHelp(
      const Msg: string;
      const Args: array of const;
      AHelpContext: Integer
    );

    constructor CreateResHelp(
      Ident: NativeUInt;
      AHelpContext: Integer
    ); overload;
    constructor CreateResHelp(
      ResStringRec: PResStringRec;
      AHelpContext: Integer
    ); overload;

    constructor CreateResFmtHelp(
      ResStringRec: PResStringRec;
      const Args: array of const;
      AHelpContext: Integer
    ); overload;
    constructor CreateResFmtHelp(
      Ident: NativeUInt;
      const Args: array of const;
      AHelpContext: Integer
    ); overload;
  end;

  EArgumentException = class(Exception);
  EArgumentOutOfRangeException = class(EArgumentException);
  EArgumentNilException = class(EArgumentException);

  EPathTooLongException = class(Exception);
  ENotSupportedException = class(Exception);
  EDirectoryNotFoundException = class(Exception);
  EFileNotFoundException = class(Exception);
  EPathNotFoundException = class(Exception);
  EInvalidOpException = class(Exception);
  ENoConstructException = class(Exception);

  EAbort = class(Exception);
  EAbstractError = class(Exception);
  EAssertionFailed = class(Exception);
  ECFError = class(Exception);
  EConvertError = class(Exception);
  EEncodingError = class(Exception);
  EIntfCastError = class(Exception);
  EInvalidCast = class(Exception);
  EInvalidContainer = class(Exception);
  EInvalidInsert = class(Exception);
  ENotImplemented = class(Exception);
  EObjectDisposed = class(Exception);
  EOperationCancelled = class(Exception);
  EPackageError = class(Exception);
  EProgrammerNotFound = class(Exception);
  EPropReadOnly = class(Exception);
  EPropWriteOnly = class(Exception);
  ESafecallException = class(Exception);
  EVariantError = class(Exception);

  EHeapException = class(Exception);
  EOutOfMemory = class(EHeapException);
  EInvalidPointer = class(EHeapException);

  EInOutError = class(Exception);

  EExternal = class(Exception);
  EExternalException = class(EExternal);
  EAccessViolation = class(EExternal);
  EControlC = class(EExternal);
  EPrivilege = class(EExternal);
  EStackOverflow = class(EExternal);

  EIntError = class(EExternal);
  EDivByZero = class(EIntError);
  ERangeError = class(EIntError);
  EIntOverflow = class(EIntError);

  EMathError = class(EExternal);
  EInvalidOp = class(EMathError);
  EZeroDivide = class(EMathError);
  EOverflow = class(EMathError);
  EUnderflow = class(EMathError);

  EOSError = class(Exception);
  EWin32Error = class(EOSError);

  EMonitor = class(Exception);
  EMonitorLockException = class(EMonitor);
  ENoMonitorSupportException = class(EMonitor);

var
  FormatSettings: TFormatSettings;
  SysLocale: TSysLocale;
  GrowCollectionFunc: TGrowCollectionFunc;

{ Integer conversion }

function IntToStr(Value: Integer): string; overload;
function IntToStr(Value: Int64): string; overload;
function UIntToStr(Value: Cardinal): string; overload;
function UIntToStr(Value: UInt64): string; overload;

function StrToInt(const S: string): Integer;
function StrToIntDef(const S: string; Default: Integer): Integer;
function TryStrToInt(const S: string; out Value: Integer): Boolean;

function StrToInt64(const S: string): Int64;
function StrToInt64Def(const S: string; Default: Int64): Int64;
function TryStrToInt64(const S: string; out Value: Int64): Boolean;

function StrToUInt(const S: string): Cardinal;
function StrToUIntDef(const S: string; Default: Cardinal): Cardinal;
function TryStrToUInt(const S: string; out Value: Cardinal): Boolean;

function StrToUInt64(const S: string): UInt64;
function StrToUInt64Def(const S: string; Default: UInt64): UInt64;
function TryStrToUInt64(const S: string; out Value: UInt64): Boolean;

{ Boolean conversion }

function BoolToStr(B: Boolean; UseBoolStrs: Boolean = False): string;
function StrToBool(const S: string): Boolean;
function StrToBoolDef(const S: string; Default: Boolean): Boolean;
function TryStrToBool(const S: string; out Value: Boolean): Boolean;

{ Hexadecimal conversion }

function IntToHex(Value: Integer; Digits: Integer): string; overload;
function IntToHex(Value: Int64; Digits: Integer): string; overload;
function IntToHex(Value: UInt64; Digits: Integer): string; overload;

function IntToHex(Value: ShortInt): string; overload;
function IntToHex(Value: Byte): string; overload;
function IntToHex(Value: SmallInt): string; overload;
function IntToHex(Value: Word): string; overload;
function IntToHex(Value: Integer): string; overload;
function IntToHex(Value: Cardinal): string; overload;
function IntToHex(Value: Int64): string; overload;
function IntToHex(Value: UInt64): string; overload;

{ Floating-point conversion }

function FloatToStr(Value: Extended): string; overload;
function FloatToStr(Value: Extended; const FormatSettings: TFormatSettings): string; overload;

function FloatToStrF(
  Value: Extended;
  Format: TFloatFormat;
  Precision: Integer;
  Digits: Integer
): string; overload;

function FloatToStrF(
  Value: Extended;
  Format: TFloatFormat;
  Precision: Integer;
  Digits: Integer;
  const FormatSettings: TFormatSettings
): string; overload;

function StrToFloat(const S: string): Extended; overload;
function StrToFloat(const S: string; const FormatSettings: TFormatSettings): Extended; overload;

function StrToFloatDef(const S: string; Default: Extended): Extended; overload;
function StrToFloatDef(
  const S: string;
  Default: Extended;
  const FormatSettings: TFormatSettings
): Extended; overload;

function TryStrToFloat(const S: string; out Value: Extended): Boolean; overload;
function TryStrToFloat(
  const S: string;
  out Value: Extended;
  const FormatSettings: TFormatSettings
): Boolean; overload;

{ Additional floating-point/currency conversion }

procedure FloatToDecimal(
  var Result: TFloatRec;
  const Value;
  ValueType: TFloatValue;
  Precision, Decimals: Integer
);

function FloatToText(
  BufferArg: PWideChar;
  const Value;
  ValueType: TFloatValue;
  Format: TFloatFormat;
  Precision, Digits: Integer
): Integer; overload;
function FloatToText(
  BufferArg: PAnsiChar;
  const Value;
  ValueType: TFloatValue;
  Format: TFloatFormat;
  Precision, Digits: Integer
): Integer; overload;
function FloatToText(
  BufferArg: PWideChar;
  const Value;
  ValueType: TFloatValue;
  Format: TFloatFormat;
  Precision, Digits: Integer;
  const AFormatSettings: TFormatSettings
): Integer; overload;
function FloatToText(
  BufferArg: PAnsiChar;
  const Value;
  ValueType: TFloatValue;
  Format: TFloatFormat;
  Precision, Digits: Integer;
  const AFormatSettings: TFormatSettings
): Integer; overload;

function FloatToTextFmt(
  Buf: PAnsiChar;
  const Value;
  ValueType: TFloatValue;
  Format: PAnsiChar
): Integer; overload;
function FloatToTextFmt(
  Buf: PAnsiChar;
  const Value;
  ValueType: TFloatValue;
  Format: PAnsiChar;
  const AFormatSettings: TFormatSettings
): Integer; overload;
function FloatToTextFmt(
  Buf: PWideChar;
  const Value;
  ValueType: TFloatValue;
  Format: PWideChar
): Integer; overload;
function FloatToTextFmt(
  Buf: PWideChar;
  const Value;
  ValueType: TFloatValue;
  Format: PWideChar;
  const AFormatSettings: TFormatSettings
): Integer; overload;

function TextToFloat(
  Buffer: PWideChar;
  var Value;
  ValueType: TFloatValue
): Boolean; overload;
function TextToFloat(
  Buffer: PWideChar;
  var Value;
  ValueType: TFloatValue;
  const AFormatSettings: TFormatSettings
): Boolean; overload;
function TextToFloat(
  Buffer: PAnsiChar;
  var Value;
  ValueType: TFloatValue
): Boolean; overload;
function TextToFloat(
  Buffer: PAnsiChar;
  var Value;
  ValueType: TFloatValue;
  const AFormatSettings: TFormatSettings
): Boolean; overload;
function TextToFloat(const S: string; var Value: Extended): Boolean; overload;
function TextToFloat(
  const S: string;
  var Value: Extended;
  const AFormatSettings: TFormatSettings
): Boolean; overload;
function TextToFloat(const S: string; var Value: Double): Boolean; overload;
function TextToFloat(
  const S: string;
  var Value: Double;
  const AFormatSettings: TFormatSettings
): Boolean; overload;
function TextToFloat(const S: string; var Value: Currency): Boolean; overload;
function TextToFloat(
  const S: string;
  var Value: Currency;
  const AFormatSettings: TFormatSettings
): Boolean; overload;

function FloatToCurr(const Value: Extended): Currency;
function TryFloatToCurr(
  const Value: Extended;
  out AResult: Currency
): Boolean;

{ Currency conversion }

function CurrToStr(Value: Currency): string; overload;
function CurrToStr(
  Value: Currency;
  const FormatSettings: TFormatSettings
): string; overload;

function StrToCurr(const S: string): Currency; overload;
function StrToCurr(
  const S: string;
  const FormatSettings: TFormatSettings
): Currency; overload;

function StrToCurrDef(
  const S: string;
  Default: Currency
): Currency; overload;
function StrToCurrDef(
  const S: string;
  Default: Currency;
  const FormatSettings: TFormatSettings
): Currency; overload;

function TryStrToCurr(
  const S: string;
  out Value: Currency
): Boolean; overload;
function TryStrToCurr(
  const S: string;
  out Value: Currency;
  const FormatSettings: TFormatSettings
): Boolean; overload;

function FormatFloat(
  const Format: string;
  Value: Extended
): string; overload;
function FormatFloat(
  const Format: string;
  Value: Extended;
  const AFormatSettings: TFormatSettings
): string; overload;

function FormatCurr(
  const Format: string;
  Value: Currency
): string; overload;
function FormatCurr(
  const Format: string;
  Value: Currency;
  const AFormatSettings: TFormatSettings
): string; overload;

{ Date and time construction }

function EncodeDate(Year, Month, Day: Word): TDateTime;
function TryEncodeDate(
  Year, Month, Day: Word;
  out Date: TDateTime
): Boolean;
procedure DecodeDate(
  const DateTime: TDateTime;
  out Year, Month, Day: Word
);

function DecodeDateFully(
  const DateTime: TDateTime;
  var Year, Month, Day, DOW: Word
): Boolean;

function DateTimeToTimeStamp(
  const DateTime: TDateTime
): TTimeStamp;

function TimeStampToDateTime(
  const TimeStamp: TTimeStamp
): TDateTime;

function MSecsToTimeStamp(
  MSecs: Comp
): TTimeStamp;

function TimeStampToMSecs(
  const TimeStamp: TTimeStamp
): Comp;

function FloatToDateTime(
  Value: Extended
): TDateTime;

function TryFloatToDateTime(
  Value: Extended;
  out AResult: TDateTime
): Boolean;

function EncodeTime(Hour, Min, Sec, MSec: Word): TDateTime;
function TryEncodeTime(
  Hour, Min, Sec, MSec: Word;
  out Time: TDateTime
): Boolean;
procedure DecodeTime(
  const DateTime: TDateTime;
  out Hour, Min, Sec, MSec: Word
);

procedure DateTimeToSystemTime(
  const DateTime: TDateTime;
  var SystemTime: TSystemTime
);

function SystemTimeToDateTime(
  const SystemTime: TSystemTime
): TDateTime;

function TrySystemTimeToDateTime(
  const SystemTime: TSystemTime;
  out DateTime: TDateTime
): Boolean;

function EncodeDateTime(
  Year, Month, Day, Hour, Minute, Second, MilliSecond: Word
): TDateTime;
function TryEncodeDateTime(
  Year, Month, Day, Hour, Minute, Second, MilliSecond: Word;
  out Value: TDateTime
): Boolean;
procedure DecodeDateTime(
  const AValue: TDateTime;
  out AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word
);

function Date: TDateTime;
function Time: TDateTime;
function Now: TDateTime;
function DayOfWeek(const DateTime: TDateTime): Word;
function IsLeapYear(Year: Word): Boolean;
function GetTime: TDateTime;
function CurrentYear: Word;

function IncMonth(
  const DateTime: TDateTime;
  NumberOfMonths: Integer = 1
): TDateTime;

procedure IncAMonth(
  var Year, Month, Day: Word;
  NumberOfMonths: Integer = 1
);

procedure ReplaceTime(
  var DateTime: TDateTime;
  const NewTime: TDateTime
);

procedure ReplaceDate(
  var DateTime: TDateTime;
  const NewDate: TDateTime
);

{ Formatting }

function Format(const Format: string; const Args: array of const): string; overload;
function Format(
  const Format: string;
  const Args: array of const;
  const FormatSettings: TFormatSettings
): string; overload;

function FormatBuf(
  var Buffer;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const
): Cardinal; overload;
function FormatBuf(
  Buffer: PWideChar;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const
): Cardinal; overload;
function FormatBuf(
  Buffer: PWideChar;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): Cardinal; overload;
function FormatBuf(
  var Buffer: UnicodeString;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const
): Cardinal; overload;
function FormatBuf(
  var Buffer: UnicodeString;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): Cardinal; overload;
function FormatBuf(
  var Buffer;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): Cardinal; overload;

function WideFormat(
  const Format: WideString;
  const Args: array of const
): WideString; overload;
function WideFormat(
  const Format: WideString;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): WideString; overload;

procedure WideFmtStr(
  var Result: WideString;
  const Format: WideString;
  const Args: array of const
); overload;
procedure WideFmtStr(
  var Result: WideString;
  const Format: WideString;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
); overload;

function WideFormatBuf(
  var Buffer;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const
): Cardinal; overload;
function WideFormatBuf(
  var Buffer;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): Cardinal; overload;

procedure FmtStr(
  var Result: string;
  const Format: string;
  const Args: array of const
); overload;

procedure FmtStr(
  var Result: string;
  const Format: string;
  const Args: array of const;
  const FormatSettings: TFormatSettings
); overload;

{ String helpers }

function CompareStr(const S1, S2: string): Integer; overload;
function CompareStr(
  const S1, S2: string;
  LocaleOptions: TLocaleOptions
): Integer; overload;

function CompareText(const S1, S2: string): Integer; overload;
function CompareText(
  const S1, S2: string;
  LocaleOptions: TLocaleOptions
): Integer; overload;

function SameStr(const S1, S2: string): Boolean; overload;
function SameStr(
  const S1, S2: string;
  LocaleOptions: TLocaleOptions
): Boolean; overload;

function SameText(const S1, S2: string): Boolean; overload;
function SameText(
  const S1, S2: string;
  LocaleOptions: TLocaleOptions
): Boolean; overload;

function UpperCase(const S: string): string; overload;
function UpperCase(
  const S: string;
  LocaleOptions: TLocaleOptions
): string; overload;

function LowerCase(const S: string): string; overload;
function LowerCase(
  const S: string;
  LocaleOptions: TLocaleOptions
): string; overload;

function Trim(const S: string): string;
function TrimLeft(const S: string): string;
function TrimRight(const S: string): string;

function QuotedStr(const S: string): string;
function AnsiQuotedStr(const S: string; Quote: Char): string;

function StringReplace(
  const S, OldPattern, NewPattern: string;
  Flags: TReplaceFlags
): string;

function FindDelimiter(
  const Delimiters, S: string;
  StartIdx: Integer = 1
): Integer;
function AnsiPos(
  const Substr, S: string
): Integer;
function AnsiLowerCaseFileName(const S: string): string;
function AnsiUpperCaseFileName(const S: string): string;
function ByteLength(const S: UnicodeString): Integer; overload;
function ByteLength(const S: RawByteString): Integer; overload;
function CharLength(const S: UnicodeString; Index: Integer): Integer;
function NextCharIndex(const S: string; Index: Integer): Integer;
function IsLeadChar(C: AnsiChar): Boolean; overload;
function IsLeadChar(C: Byte): Boolean; overload;
function IsLeadChar(C: WideChar): Boolean; overload;
function CharInSet(C: Char; const CharSet: TSysCharSet): Boolean;

function ByteType(const S: AnsiString; Index: Integer): TMbcsByteType; overload;
function ByteType(const S: UnicodeString; Index: Integer): TMbcsByteType; overload;
function StrByteType(Str: PAnsiChar; Index: Cardinal): TMbcsByteType; overload;
function StrByteType(Str: PWideChar; Index: Cardinal): TMbcsByteType; overload;
function CharToElementIndex(const S: AnsiString; Index: Integer): Integer; overload;
function CharToElementIndex(const S: UnicodeString; Index: Integer): Integer; overload;
function ElementToCharIndex(const S: AnsiString; Index: Integer): Integer; overload;
function ElementToCharIndex(const S: UnicodeString; Index: Integer): Integer; overload;
function ElementToCharLen(const S: AnsiString; MaxLen: Integer): Integer; overload;
function ElementToCharLen(const S: UnicodeString; MaxLen: Integer): Integer; overload;

function CompareMem(P1, P2: Pointer; Length: NativeInt): Boolean;

function ByteToCharLen(const S: string; MaxLen: Integer): Integer;
function CharToByteLen(const S: string; MaxLen: Integer): Integer;
function ByteToCharIndex(const S: string; Index: Integer): Integer;
function CharToByteIndex(const S: string; Index: Integer): Integer;
function StrCharLength(const Str: PAnsiChar): Integer; overload;
function StrCharLength(const Str: PWideChar): Integer; overload;
function StrNextChar(const Str: PAnsiChar): PAnsiChar; overload;
function StrNextChar(const Str: PWideChar): PWideChar; overload;

function StrLen(const Str: PAnsiChar): Cardinal; overload;
function StrLen(const Str: PWideChar): Cardinal; overload;

function StrEnd(const Str: PAnsiChar): PAnsiChar; overload;
function StrEnd(const Str: PWideChar): PWideChar; overload;

function StrMove(
  Dest: PAnsiChar;
  const Source: PAnsiChar;
  Count: Cardinal
): PAnsiChar; overload;
function StrMove(
  Dest: PWideChar;
  const Source: PWideChar;
  Count: Cardinal
): PWideChar; overload;

function StrECopy(Dest: PAnsiChar; const Source: PAnsiChar): PAnsiChar; overload;
function StrECopy(Dest: PWideChar; const Source: PWideChar): PWideChar; overload;

function StrLCat(
  Dest: PAnsiChar;
  const Source: PAnsiChar;
  MaxLen: Cardinal
): PAnsiChar; overload;
function StrLCat(
  Dest: PWideChar;
  const Source: PWideChar;
  MaxLen: Cardinal
): PWideChar; overload;

procedure StrDispose(Str: PAnsiChar); overload;
procedure StrDispose(Str: PWideChar); overload;

function StrFmt(
  Buffer, Format: PAnsiChar;
  const Args: array of const
): PAnsiChar; overload;
function StrFmt(
  Buffer, Format: PWideChar;
  const Args: array of const
): PWideChar; overload;
function StrFmt(
  Buffer, Format: PAnsiChar;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): PAnsiChar; overload;
function StrFmt(
  Buffer, Format: PWideChar;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): PWideChar; overload;

function StrLFmt(
  Buffer: PAnsiChar;
  MaxBufLen: Cardinal;
  Format: PAnsiChar;
  const Args: array of const
): PAnsiChar; overload;
function StrLFmt(
  Buffer: PWideChar;
  MaxBufLen: Cardinal;
  Format: PWideChar;
  const Args: array of const
): PWideChar; overload;
function StrLFmt(
  Buffer: PAnsiChar;
  MaxBufLen: Cardinal;
  Format: PAnsiChar;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): PAnsiChar; overload;
function StrLFmt(
  Buffer: PWideChar;
  MaxBufLen: Cardinal;
  Format: PWideChar;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): PWideChar; overload;

function StrCopy(Dest: PAnsiChar; const Source: PAnsiChar): PAnsiChar; overload;
function StrCopy(Dest: PWideChar; const Source: PWideChar): PWideChar; overload;

function StrLCopy(
  Dest: PAnsiChar;
  const Source: PAnsiChar;
  MaxLen: Cardinal
): PAnsiChar; overload;
function StrLCopy(
  Dest: PWideChar;
  const Source: PWideChar;
  MaxLen: Cardinal
): PWideChar; overload;

function StrPCopy(Dest: PAnsiChar; const Source: AnsiString): PAnsiChar; overload;
function StrPCopy(Dest: PWideChar; const Source: UnicodeString): PWideChar; overload;

function StrPLCopy(
  Dest: PAnsiChar;
  const Source: AnsiString;
  MaxLen: Cardinal
): PAnsiChar; overload;
function StrPLCopy(
  Dest: PWideChar;
  const Source: UnicodeString;
  MaxLen: Cardinal
): PWideChar; overload;

function StrCat(Dest: PAnsiChar; const Source: PAnsiChar): PAnsiChar; overload;
function StrCat(Dest: PWideChar; const Source: PWideChar): PWideChar; overload;

function StrScan(const Str: PAnsiChar; Chr: AnsiChar): PAnsiChar; overload;
function StrScan(const Str: PWideChar; Chr: WideChar): PWideChar; overload;
function StrRScan(const Str: PAnsiChar; Chr: AnsiChar): PAnsiChar; overload;
function StrRScan(const Str: PWideChar; Chr: WideChar): PWideChar; overload;

function StrPos(const Str1, Str2: PAnsiChar): PAnsiChar; overload;
function StrPos(const Str1, Str2: PWideChar): PWideChar; overload;

function StrUpper(Str: PAnsiChar): PAnsiChar; overload;
function StrUpper(Str: PWideChar): PWideChar; overload;
function StrLower(Str: PAnsiChar): PAnsiChar; overload;
function StrLower(Str: PWideChar): PWideChar; overload;

function StrPas(const Str: PAnsiChar): AnsiString; overload;
function StrPas(const Str: PWideChar): UnicodeString; overload;

function StrNew(const Str: PAnsiChar): PAnsiChar; overload;
function StrNew(const Str: PWideChar): PWideChar; overload;
function StrBufSize(const Str: PAnsiChar): Cardinal; overload;
function StrBufSize(const Str: PWideChar): Cardinal; overload;
function StrAlloc(Size: Cardinal): PChar;

function StrComp(const Str1, Str2: PAnsiChar): Integer; overload;
function StrComp(const Str1, Str2: PWideChar): Integer; overload;
function StrIComp(const Str1, Str2: PAnsiChar): Integer; overload;
function StrIComp(const Str1, Str2: PWideChar): Integer; overload;
function StrLComp(
  const Str1, Str2: PAnsiChar;
  MaxLen: Cardinal
): Integer; overload;
function StrLComp(
  const Str1, Str2: PWideChar;
  MaxLen: Cardinal
): Integer; overload;
function StrLIComp(
  const Str1, Str2: PAnsiChar;
  MaxLen: Cardinal
): Integer; overload;
function StrLIComp(
  const Str1, Str2: PWideChar;
  MaxLen: Cardinal
): Integer; overload;

function TextPos(Str, SubStr: PAnsiChar): PAnsiChar; overload;
function TextPos(Str, SubStr: PWideChar): PWideChar; overload;
function HashName(Name: PAnsiChar): Cardinal;

function AnsiStrComp(S1, S2: PAnsiChar): Integer; overload;
function AnsiStrComp(S1, S2: PWideChar): Integer; overload;
function AnsiStrIComp(S1, S2: PAnsiChar): Integer; overload;
function AnsiStrIComp(S1, S2: PWideChar): Integer; overload;
function AnsiStrLComp(
  S1, S2: PAnsiChar;
  MaxLen: Cardinal
): Integer; overload;
function AnsiStrLComp(
  S1, S2: PWideChar;
  MaxLen: Cardinal
): Integer; overload;
function AnsiStrLIComp(
  S1, S2: PAnsiChar;
  MaxLen: Cardinal
): Integer; overload;
function AnsiStrLIComp(
  S1, S2: PWideChar;
  MaxLen: Cardinal
): Integer; overload;

function AnsiStrUpper(Str: PAnsiChar): PAnsiChar; overload;
function AnsiStrUpper(Str: PWideChar): PWideChar; overload;
function AnsiStrLower(Str: PAnsiChar): PAnsiChar; overload;
function AnsiStrLower(Str: PWideChar): PWideChar; overload;

function AnsiStrPos(Str, SubStr: PAnsiChar): PAnsiChar; overload;
function AnsiStrPos(Str, SubStr: PWideChar): PWideChar; overload;
function AnsiStrScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar; overload;
function AnsiStrScan(Str: PWideChar; Chr: WideChar): PWideChar; overload;
function AnsiStrRScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar; overload;
function AnsiStrRScan(Str: PWideChar; Chr: WideChar): PWideChar; overload;

function AnsiStrLastChar(P: PAnsiChar): PAnsiChar; overload;
function AnsiStrLastChar(P: PWideChar): PWideChar; overload;
function AnsiLastChar(const S: UnicodeString): PWideChar;

function AnsiExtractQuotedStr(
  var Src: PAnsiChar;
  Quote: AnsiChar
): AnsiString; overload;
function AnsiExtractQuotedStr(
  var Src: PWideChar;
  Quote: WideChar
): UnicodeString; overload;

function AnsiUpperCase(const S: string): string;
function AnsiLowerCase(const S: string): string;
function AnsiCompareStr(const S1, S2: string): Integer;
function AnsiCompareText(const S1, S2: string): Integer;
function AnsiSameStr(const S1, S2: string): Boolean;
function AnsiSameText(const S1, S2: string): Boolean;
function AnsiDequotedStr(const S: string; AQuote: Char): string;
function AdjustLineBreaks(
  const S: string;
  Style: TTextLineBreakStyle = tlbsCRLF
): string;
function IsValidIdent(
  const Ident: string;
  AllowDots: Boolean = False
): Boolean;
function WrapText(
  const Line, BreakStr: string;
  const BreakChars: TSysCharSet;
  MaxCol: Integer
): string; overload;
function WrapText(
  const Line: string;
  MaxCol: Integer = 45
): string; overload;

function WideUpperCase(const S: string): string;
function WideLowerCase(const S: string): string;
function WideCompareStr(const S1, S2: string): Integer;
function WideCompareText(const S1, S2: string): Integer;
function WideSameStr(const S1, S2: string): Boolean;
function WideSameText(const S1, S2: string): Boolean;

procedure AppendStr(var Dest: string; const S: string);

{ Date and time conversion }

function DateToStr(const DateTime: TDateTime): string; overload;
function DateToStr(
  const DateTime: TDateTime;
  const FormatSettings: TFormatSettings
): string; overload;

function TimeToStr(const DateTime: TDateTime): string; overload;
function TimeToStr(
  const DateTime: TDateTime;
  const FormatSettings: TFormatSettings
): string; overload;

function DateTimeToStr(const DateTime: TDateTime): string; overload;
function DateTimeToStr(
  const DateTime: TDateTime;
  const FormatSettings: TFormatSettings
): string; overload;

function StrToDate(const S: string): TDateTime; overload;
function StrToDate(
  const S: string;
  const FormatSettings: TFormatSettings
): TDateTime; overload;
function StrToDateDef(
  const S: string;
  Default: TDateTime
): TDateTime; overload;
function StrToDateDef(
  const S: string;
  Default: TDateTime;
  const FormatSettings: TFormatSettings
): TDateTime; overload;

function StrToTime(const S: string): TDateTime; overload;
function StrToTime(
  const S: string;
  const FormatSettings: TFormatSettings
): TDateTime; overload;
function StrToTimeDef(
  const S: string;
  Default: TDateTime
): TDateTime; overload;
function StrToTimeDef(
  const S: string;
  Default: TDateTime;
  const FormatSettings: TFormatSettings
): TDateTime; overload;

function StrToDateTime(const S: string): TDateTime; overload;
function StrToDateTime(
  const S: string;
  const FormatSettings: TFormatSettings
): TDateTime; overload;
function StrToDateTimeDef(
  const S: string;
  Default: TDateTime
): TDateTime; overload;
function StrToDateTimeDef(
  const S: string;
  Default: TDateTime;
  const FormatSettings: TFormatSettings
): TDateTime; overload;

function TryStrToDate(const S: string; out Value: TDateTime): Boolean; overload;
function TryStrToDate(
  const S: string;
  out Value: TDateTime;
  const FormatSettings: TFormatSettings
): Boolean; overload;

function TryStrToTime(const S: string; out Value: TDateTime): Boolean; overload;
function TryStrToTime(
  const S: string;
  out Value: TDateTime;
  const FormatSettings: TFormatSettings
): Boolean; overload;

function TryStrToDateTime(const S: string; out Value: TDateTime): Boolean; overload;
function TryStrToDateTime(
  const S: string;
  out Value: TDateTime;
  const FormatSettings: TFormatSettings
): Boolean; overload;

function FormatDateTime(const Format: string; DateTime: TDateTime): string; overload;
function FormatDateTime(
  const Format: string;
  DateTime: TDateTime;
  const FormatSettings: TFormatSettings
): string; overload;

{ File-name helpers }

function ChangeFileExt(const FileName, Extension: string): string;
function ChangeFilePath(const FileName, Path: string): string;
function ExtractFileDir(const FileName: string): string;
function ExtractFileDrive(const FileName: string): string;
function ExtractFileExt(const FileName: string): string;
function ExtractFileName(const FileName: string): string;
function ExtractFilePath(const FileName: string): string;

function IncludeTrailingPathDelimiter(const S: string): string;
function IncludeTrailingBackslash(const S: string): string;
function ExcludeTrailingPathDelimiter(const S: string): string;
function ExcludeTrailingBackslash(const S: string): string;

function ExpandFileName(const FileName: string): string;
function ExpandFileNameCase(
  const FileName: string;
  out MatchFound: TFilenameCaseMatch
): string;
function ExpandUNCFileName(const FileName: string): string;
function ExtractRelativePath(const BaseName, DestName: string): string;
function ExtractShortPathName(const FileName: string): string;
function IsPathDelimiter(const S: string; Index: Integer): Boolean;
function IsDelimiter(const Delimiters, S: string; Index: Integer): Boolean;
function LastDelimiter(const Delimiters, S: string): Integer;
function IsRelativePath(const Path: string): Boolean;
function FileSearch(const Name, DirList: string): string;
function SameFileName(const S1, S2: string): Boolean;
function AnsiCompareFileName(
  const S1, S2: string;
  CheckVolumeCase: Boolean = False
): Integer;

{ File and directory helpers }

function FileExists(const FileName: string; FollowLink: Boolean = True): Boolean;
function DirectoryExists(const Directory: string; FollowLink: Boolean = True): Boolean;
function ForceDirectories(Dir: string): Boolean;

function FindFirst(
  const Path: string;
  Attr: Integer;
  var F: TSearchRec
): Integer;
function FindNext(var F: TSearchRec): Integer;
procedure FindClose(var F: TSearchRec);

function FileGetDateTimeInfo(
  const FileName: string;
  out DateTime: TDateTimeInfoRec;
  FollowLink: Boolean = True
): Boolean;

function FileCreateSymLink(
  const Link, Target: string
): Boolean;

function FileGetSymLinkTarget(
  const FileName: string;
  var SymLinkRec: TSymLinkRec
): Boolean; overload;
function FileGetSymLinkTarget(
  const FileName: string;
  var TargetName: string
): Boolean; overload;

function FileSystemAttributes(
  const Path: string
): TFileSystemAttributes;

function GetCurrentDir: string;
function SetCurrentDir(const Dir: string): Boolean;
function CreateDir(const Dir: string): Boolean;
function RemoveDir(const Dir: string): Boolean;
function DiskFree(Drive: Byte): Int64;
function DiskSize(Drive: Byte): Int64;

function FileGetAttr(
  const FileName: string;
  FollowLink: Boolean = True
): Integer;
function FileSetAttr(
  const FileName: string;
  Attr: Integer;
  FollowLink: Boolean = True
): Integer;
function FileIsReadOnly(const FileName: string): Boolean;
function FileSetReadOnly(
  const FileName: string;
  ReadOnly: Boolean
): Boolean;
function DeleteFile(const FileName: string): Boolean;
function RenameFile(
  const OldName, NewName: string
): Boolean;
function IsAssembly(const FileName: string): Boolean;

function FileDateToDateTime(FileDate: Integer): TDateTime;
function DateTimeToFileDate(DateTime: TDateTime): Integer;

function FileAge(const FileName: string): Integer; overload;
function FileAge(
  const FileName: string;
  out FileDateTime: TDateTime;
  FollowLink: Boolean = True
): Boolean; overload;

function FileSetDate(
  const FileName: string;
  Age: Integer
): Integer; overload;
function FileSetDate(
  Handle: THandle;
  Age: Integer
): Integer; overload;

function FileOpen(
  const FileName: string;
  Mode: LongWord
): THandle;

function FileRead(
  Handle: THandle;
  var Buffer;
  Count: LongWord
): Integer;

function FileWrite(
  Handle: THandle;
  const Buffer;
  Count: LongWord
): Integer;

function FileCreate(const FileName: string): THandle; overload;
function FileCreate(
  const FileName: string;
  Rights: Integer
): THandle; overload;
function FileCreate(
  const FileName: string;
  Mode: LongWord;
  Rights: Integer
): THandle; overload;

function FileSeek(
  Handle: THandle;
  Offset, Origin: Integer
): Integer; overload;
function FileSeek(
  Handle: THandle;
  const Offset: Int64;
  Origin: Integer
): Int64; overload;

function FileGetDate(Handle: THandle): LongInt;
procedure FileClose(Handle: THandle);

{ Environment, resource and command-line helpers }

{ Package, termination and collection-growth helpers }

function SafeLoadLibrary(
  const FileName: string;
  ErrorMode: Cardinal = $8000
): HMODULE;

function LoadPackage(const Name: string): HMODULE; overload;
function LoadPackage(
  const Name: string;
  AValidatePackage: TValidatePackageProc
): HMODULE; overload;
procedure InitializePackage(Module: HMODULE); overload;
procedure InitializePackage(
  Module: HMODULE;
  AValidatePackage: TValidatePackageProc
); overload;
procedure FinalizePackage(Module: HMODULE);
procedure UnloadPackage(Module: HMODULE);

function GetPackageDescription(ModuleName: PChar): string;
procedure GetPackageInfo(
  Module: HMODULE;
  Param: Pointer;
  var Flags: Integer;
  InfoProc: TPackageInfoProc
);
function GetPackageTargets(Module: HMODULE): UInt32;

procedure AddExitProc(Proc: TProcedure);
procedure AddTerminateProc(TermProc: TTerminateProc);
function CallTerminateProcs: Boolean;

function GrowCollection(
  OldCapacity, NewCount: NativeInt
): NativeInt;
function SetGrowCollectionFunc(
  Func: TGrowCollectionFunc
): TGrowCollectionFunc;

function GetDefaultFallbackLanguages: string;
procedure SetDefaultFallbackLanguages(const Languages: string);
function PreferredUILanguages: string;

function GetEnvironmentVariable(const Name: string): string;
function GetHomePath: string;
function GetLocaleStr(
  Locale: Integer;
  LocaleType: Integer;
  const Default: string
): string;

function GetLocaleChar(
  Locale: Integer;
  LocaleType: Integer;
  Default: Char
): Char;

procedure GetLocaleFormatSettings(
  Locale: TLocaleID;
  var AFormatSettings: TFormatSettings
);

function LocaleFileExists(
  const FileName: string
): Boolean;

function GetLocaleFile(
  const FileName: string
): string;

function LocaleDirectoryExists(
  const Directory: string
): Boolean;

function GetLocaleDirectory(
  const Directory: string
): string;

function CheckWin32Version(
  AMajor: Integer;
  AMinor: Integer = 0
): Boolean;
function GetFileVersion(const AFileName: string): Cardinal;
function GetProductVersion(
  const AFileName: string;
  var AMajor, AMinor, ABuild: Cardinal
): Boolean;

procedure GetFormatSettings;
function LCIDToCodePage(const ALCID: Cardinal): Integer;
function GetModuleName(Module: THandle): string;

function LoadStr(Ident: NativeUInt): string;
function FmtLoadStr(
  Ident: NativeUInt;
  const Args: array of const
): string;

function FindCmdLineSwitch(
  const Switch: string;
  const Chars: TSysCharSet;
  IgnoreCase: Boolean
): Boolean; overload;
function FindCmdLineSwitch(
  const Switch: string
): Boolean; overload;
function FindCmdLineSwitch(
  const Switch: string;
  IgnoreCase: Boolean
): Boolean; overload;
function FindCmdLineSwitch(
  const Switch: string;
  var Value: string;
  IgnoreCase: Boolean = True;
  const SwitchTypes: TCmdLineSwitchTypes =
    [clstValueNextParam, clstValueAppended]
): Boolean; overload;

procedure Beep;

{ GUID and interface support }

function IsEqualGUID(
  const Guid1, Guid2: TGUID
): Boolean;

function CreateGUID(
  out Guid: TGUID
): HResult;

function StringToGUID(
  const S: string
): TGUID;

function StrToGUID(
  S: PWideChar
): TGUID;

function GUIDToString(
  const Guid: TGUID
): string; overload;
function GUIDToString(
  const Guid: TGUID;
  const Format: Char
): string; overload;

function Supports(
  const Instance: IInterface;
  const IID: TGUID;
  out Intf
): Boolean; overload;
function Supports(
  const Instance: TObject;
  const IID: TGUID;
  out Intf
): Boolean; overload;
function Supports(
  const Instance: IInterface;
  const IID: TGUID
): Boolean; overload;
function Supports(
  const Instance: TObject;
  const IID: TGUID
): Boolean; overload;
function Supports(
  const AClass: TClass;
  const IID: TGUID
): Boolean; overload;

{ Exception and operating-system helpers }

function ExceptionErrorMessage(
  ExceptObject: TObject;
  ExceptAddr: Pointer;
  Buffer: PChar;
  Size: Integer
): Integer;

procedure Abort;
procedure OutOfMemoryError;

procedure RaiseLastOSError; overload;
procedure RaiseLastOSError(LastError: Integer); overload;
procedure RaiseLastOSError(
  LastError: Integer;
  const AdditionalInfo: string
); overload;

procedure RaiseLastWin32Error;
function Win32Check(RetVal: LongBool): LongBool;

procedure CheckOSError(LastError: Integer);

function SysErrorMessage(
  ErrorCode: Cardinal;
  AModuleHandle: THandle = 0
): string;

procedure FreeAndNil(var Obj: TObject);

implementation

class function TFormatSettings.Create: TFormatSettings;
begin
end;

class function TFormatSettings.Create(Locale: TLocaleID): TFormatSettings;
begin
end;

class function TFormatSettings.Create(const LocaleName: string): TFormatSettings;
begin
end;

class function TFormatSettings.Invariant: TFormatSettings;
begin
end;

function TFormatSettings.GetEraYearOffset(const Name: string): Integer;
begin
end;

function TSearchRec.GetCreationTime: TDateTime;
begin
end;

function TSearchRec.GetLastAccessTime: TDateTime;
begin
end;

function TSearchRec.GetTimeStamp: TDateTime;
begin
end;

function TSymLinkRec.GetTimeStamp: TDateTime;
begin
end;

function TDateTimeInfoRec.GetCreationTime: TDateTime;
begin
end;

function TDateTimeInfoRec.GetLastAccessTime: TDateTime;
begin
end;

function TDateTimeInfoRec.GetTimeStamp: TDateTime;
begin
end;

constructor Exception.Create(const Msg: string);
begin
end;

constructor Exception.CreateFmt(const Msg: string; const Args: array of const);
begin
end;

constructor Exception.CreateRes(Ident: NativeUInt);
begin
end;

constructor Exception.CreateRes(ResStringRec: PResStringRec);
begin
end;

constructor Exception.CreateResFmt(
  Ident: NativeUInt;
  const Args: array of const
);
begin
end;

constructor Exception.CreateResFmt(
  ResStringRec: PResStringRec;
  const Args: array of const
);
begin
end;

constructor Exception.CreateHelp(
  const Msg: string;
  AHelpContext: Integer
);
begin
end;

constructor Exception.CreateFmtHelp(
  const Msg: string;
  const Args: array of const;
  AHelpContext: Integer
);
begin
end;

constructor Exception.CreateResHelp(
  Ident: NativeUInt;
  AHelpContext: Integer
);
begin
end;

constructor Exception.CreateResHelp(
  ResStringRec: PResStringRec;
  AHelpContext: Integer
);
begin
end;

constructor Exception.CreateResFmtHelp(
  ResStringRec: PResStringRec;
  const Args: array of const;
  AHelpContext: Integer
);
begin
end;

constructor Exception.CreateResFmtHelp(
  Ident: NativeUInt;
  const Args: array of const;
  AHelpContext: Integer
);
begin
end;

function IntToStr(Value: Integer): string;
begin
end;

function IntToStr(Value: Int64): string;
begin
end;

function UIntToStr(Value: Cardinal): string;
begin
end;

function UIntToStr(Value: UInt64): string;
begin
end;

function StrToInt(const S: string): Integer;
begin
end;

function StrToIntDef(const S: string; Default: Integer): Integer;
begin
end;

function TryStrToInt(const S: string; out Value: Integer): Boolean;
begin
end;

function StrToInt64(const S: string): Int64;
begin
end;

function StrToInt64Def(const S: string; Default: Int64): Int64;
begin
end;

function TryStrToInt64(const S: string; out Value: Int64): Boolean;
begin
end;

function StrToUInt(const S: string): Cardinal;
begin
end;

function StrToUIntDef(const S: string; Default: Cardinal): Cardinal;
begin
end;

function TryStrToUInt(const S: string; out Value: Cardinal): Boolean;
begin
end;

function StrToUInt64(const S: string): UInt64;
begin
end;

function StrToUInt64Def(const S: string; Default: UInt64): UInt64;
begin
end;

function TryStrToUInt64(const S: string; out Value: UInt64): Boolean;
begin
end;

function BoolToStr(B: Boolean; UseBoolStrs: Boolean = False): string;
begin
end;

function StrToBool(const S: string): Boolean;
begin
end;

function StrToBoolDef(const S: string; Default: Boolean): Boolean;
begin
end;

function TryStrToBool(const S: string; out Value: Boolean): Boolean;
begin
end;

function IntToHex(Value: Integer; Digits: Integer): string;
begin
end;

function IntToHex(Value: Int64; Digits: Integer): string;
begin
end;

function IntToHex(Value: UInt64; Digits: Integer): string;
begin
end;

function IntToHex(Value: ShortInt): string;
begin
end;

function IntToHex(Value: Byte): string;
begin
end;

function IntToHex(Value: SmallInt): string;
begin
end;

function IntToHex(Value: Word): string;
begin
end;

function IntToHex(Value: Integer): string;
begin
end;

function IntToHex(Value: Cardinal): string;
begin
end;

function IntToHex(Value: Int64): string;
begin
end;

function IntToHex(Value: UInt64): string;
begin
end;

function FloatToStr(Value: Extended): string;
begin
end;

function FloatToStr(Value: Extended; const FormatSettings: TFormatSettings): string;
begin
end;

function FloatToStrF(
  Value: Extended;
  Format: TFloatFormat;
  Precision: Integer;
  Digits: Integer
): string;
begin
end;

function FloatToStrF(
  Value: Extended;
  Format: TFloatFormat;
  Precision: Integer;
  Digits: Integer;
  const FormatSettings: TFormatSettings
): string;
begin
end;

function StrToFloat(const S: string): Extended;
begin
end;

function StrToFloat(const S: string; const FormatSettings: TFormatSettings): Extended;
begin
end;

function StrToFloatDef(const S: string; Default: Extended): Extended;
begin
end;

function StrToFloatDef(
  const S: string;
  Default: Extended;
  const FormatSettings: TFormatSettings
): Extended;
begin
end;

function TryStrToFloat(const S: string; out Value: Extended): Boolean;
begin
end;

function TryStrToFloat(
  const S: string;
  out Value: Extended;
  const FormatSettings: TFormatSettings
): Boolean;
begin
end;

procedure FloatToDecimal(
  var Result: TFloatRec;
  const Value;
  ValueType: TFloatValue;
  Precision, Decimals: Integer
);
begin
end;

function FloatToText(
  BufferArg: PWideChar;
  const Value;
  ValueType: TFloatValue;
  Format: TFloatFormat;
  Precision, Digits: Integer
): Integer;
begin
end;

function FloatToText(
  BufferArg: PAnsiChar;
  const Value;
  ValueType: TFloatValue;
  Format: TFloatFormat;
  Precision, Digits: Integer
): Integer;
begin
end;

function FloatToText(
  BufferArg: PWideChar;
  const Value;
  ValueType: TFloatValue;
  Format: TFloatFormat;
  Precision, Digits: Integer;
  const AFormatSettings: TFormatSettings
): Integer;
begin
end;

function FloatToText(
  BufferArg: PAnsiChar;
  const Value;
  ValueType: TFloatValue;
  Format: TFloatFormat;
  Precision, Digits: Integer;
  const AFormatSettings: TFormatSettings
): Integer;
begin
end;

function FloatToTextFmt(
  Buf: PAnsiChar;
  const Value;
  ValueType: TFloatValue;
  Format: PAnsiChar
): Integer;
begin
end;

function FloatToTextFmt(
  Buf: PAnsiChar;
  const Value;
  ValueType: TFloatValue;
  Format: PAnsiChar;
  const AFormatSettings: TFormatSettings
): Integer;
begin
end;

function FloatToTextFmt(
  Buf: PWideChar;
  const Value;
  ValueType: TFloatValue;
  Format: PWideChar
): Integer;
begin
end;

function FloatToTextFmt(
  Buf: PWideChar;
  const Value;
  ValueType: TFloatValue;
  Format: PWideChar;
  const AFormatSettings: TFormatSettings
): Integer;
begin
end;

function TextToFloat(
  Buffer: PWideChar;
  var Value;
  ValueType: TFloatValue
): Boolean;
begin
end;

function TextToFloat(
  Buffer: PWideChar;
  var Value;
  ValueType: TFloatValue;
  const AFormatSettings: TFormatSettings
): Boolean;
begin
end;

function TextToFloat(
  Buffer: PAnsiChar;
  var Value;
  ValueType: TFloatValue
): Boolean;
begin
end;

function TextToFloat(
  Buffer: PAnsiChar;
  var Value;
  ValueType: TFloatValue;
  const AFormatSettings: TFormatSettings
): Boolean;
begin
end;

function TextToFloat(const S: string; var Value: Extended): Boolean;
begin
end;

function TextToFloat(
  const S: string;
  var Value: Extended;
  const AFormatSettings: TFormatSettings
): Boolean;
begin
end;

function TextToFloat(const S: string; var Value: Double): Boolean;
begin
end;

function TextToFloat(
  const S: string;
  var Value: Double;
  const AFormatSettings: TFormatSettings
): Boolean;
begin
end;

function TextToFloat(const S: string; var Value: Currency): Boolean;
begin
end;

function TextToFloat(
  const S: string;
  var Value: Currency;
  const AFormatSettings: TFormatSettings
): Boolean;
begin
end;

function FloatToCurr(const Value: Extended): Currency;
begin
end;

function TryFloatToCurr(
  const Value: Extended;
  out AResult: Currency
): Boolean;
begin
end;

function CurrToStr(Value: Currency): string;
begin
end;

function CurrToStr(
  Value: Currency;
  const FormatSettings: TFormatSettings
): string;
begin
end;

function StrToCurr(const S: string): Currency;
begin
end;

function StrToCurr(
  const S: string;
  const FormatSettings: TFormatSettings
): Currency;
begin
end;

function StrToCurrDef(
  const S: string;
  Default: Currency
): Currency;
begin
end;

function StrToCurrDef(
  const S: string;
  Default: Currency;
  const FormatSettings: TFormatSettings
): Currency;
begin
end;

function TryStrToCurr(
  const S: string;
  out Value: Currency
): Boolean;
begin
end;

function TryStrToCurr(
  const S: string;
  out Value: Currency;
  const FormatSettings: TFormatSettings
): Boolean;
begin
end;

function FormatFloat(
  const Format: string;
  Value: Extended
): string;
begin
end;

function FormatFloat(
  const Format: string;
  Value: Extended;
  const AFormatSettings: TFormatSettings
): string;
begin
end;

function FormatCurr(
  const Format: string;
  Value: Currency
): string;
begin
end;

function FormatCurr(
  const Format: string;
  Value: Currency;
  const AFormatSettings: TFormatSettings
): string;
begin
end;

function EncodeDate(Year, Month, Day: Word): TDateTime;
begin
end;

function TryEncodeDate(
  Year, Month, Day: Word;
  out Date: TDateTime
): Boolean;
begin
end;

procedure DecodeDate(
  const DateTime: TDateTime;
  out Year, Month, Day: Word
);
begin
end;

function DecodeDateFully(
  const DateTime: TDateTime;
  var Year, Month, Day, DOW: Word
): Boolean;
begin
end;

function DateTimeToTimeStamp(
  const DateTime: TDateTime
): TTimeStamp;
begin
end;

function TimeStampToDateTime(
  const TimeStamp: TTimeStamp
): TDateTime;
begin
end;

function MSecsToTimeStamp(
  MSecs: Comp
): TTimeStamp;
begin
end;

function TimeStampToMSecs(
  const TimeStamp: TTimeStamp
): Comp;
begin
end;

function FloatToDateTime(
  Value: Extended
): TDateTime;
begin
end;

function TryFloatToDateTime(
  Value: Extended;
  out AResult: TDateTime
): Boolean;
begin
end;

function EncodeTime(Hour, Min, Sec, MSec: Word): TDateTime;
begin
end;

function TryEncodeTime(
  Hour, Min, Sec, MSec: Word;
  out Time: TDateTime
): Boolean;
begin
end;

procedure DecodeTime(
  const DateTime: TDateTime;
  out Hour, Min, Sec, MSec: Word
);
begin
end;

procedure DateTimeToSystemTime(
  const DateTime: TDateTime;
  var SystemTime: TSystemTime
);
begin
end;

function SystemTimeToDateTime(
  const SystemTime: TSystemTime
): TDateTime;
begin
end;

function TrySystemTimeToDateTime(
  const SystemTime: TSystemTime;
  out DateTime: TDateTime
): Boolean;
begin
end;

function EncodeDateTime(
  Year, Month, Day, Hour, Minute, Second, MilliSecond: Word
): TDateTime;
begin
end;

function TryEncodeDateTime(
  Year, Month, Day, Hour, Minute, Second, MilliSecond: Word;
  out Value: TDateTime
): Boolean;
begin
end;

procedure DecodeDateTime(
  const AValue: TDateTime;
  out AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word
);
begin
end;

function Date: TDateTime;
begin
end;

function Time: TDateTime;
begin
end;

function Now: TDateTime;
begin
end;

function DayOfWeek(const DateTime: TDateTime): Word;
begin
end;

function IsLeapYear(Year: Word): Boolean;
begin
end;

function GetTime: TDateTime;
begin
end;

function CurrentYear: Word;
begin
end;

function IncMonth(
  const DateTime: TDateTime;
  NumberOfMonths: Integer = 1
): TDateTime;
begin
end;

procedure IncAMonth(
  var Year, Month, Day: Word;
  NumberOfMonths: Integer = 1
);
begin
end;

procedure ReplaceTime(
  var DateTime: TDateTime;
  const NewTime: TDateTime
);
begin
end;

procedure ReplaceDate(
  var DateTime: TDateTime;
  const NewDate: TDateTime
);
begin
end;

function Format(const Format: string; const Args: array of const): string;
begin
end;

function Format(
  const Format: string;
  const Args: array of const;
  const FormatSettings: TFormatSettings
): string;
begin
end;

function FormatBuf(
  var Buffer;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const
): Cardinal;
begin
end;

function FormatBuf(
  Buffer: PWideChar;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const
): Cardinal;
begin
end;

function FormatBuf(
  Buffer: PWideChar;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): Cardinal;
begin
end;

function FormatBuf(
  var Buffer: UnicodeString;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const
): Cardinal;
begin
end;

function FormatBuf(
  var Buffer: UnicodeString;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): Cardinal;
begin
end;

function FormatBuf(
  var Buffer;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): Cardinal;
begin
end;

function WideFormat(
  const Format: WideString;
  const Args: array of const
): WideString;
begin
end;

function WideFormat(
  const Format: WideString;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): WideString;
begin
end;

procedure WideFmtStr(
  var Result: WideString;
  const Format: WideString;
  const Args: array of const
);
begin
end;

procedure WideFmtStr(
  var Result: WideString;
  const Format: WideString;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
);
begin
end;

function WideFormatBuf(
  var Buffer;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const
): Cardinal;
begin
end;

function WideFormatBuf(
  var Buffer;
  BufLen: Cardinal;
  const Format;
  FmtLen: Cardinal;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): Cardinal;
begin
end;

procedure FmtStr(
  var Result: string;
  const Format: string;
  const Args: array of const
);
begin
end;

procedure FmtStr(
  var Result: string;
  const Format: string;
  const Args: array of const;
  const FormatSettings: TFormatSettings
);
begin
end;

function CompareStr(const S1, S2: string): Integer;
begin
end;

function CompareStr(
  const S1, S2: string;
  LocaleOptions: TLocaleOptions
): Integer;
begin
end;

function CompareText(const S1, S2: string): Integer;
begin
end;

function CompareText(
  const S1, S2: string;
  LocaleOptions: TLocaleOptions
): Integer;
begin
end;

function SameStr(const S1, S2: string): Boolean;
begin
end;

function SameStr(
  const S1, S2: string;
  LocaleOptions: TLocaleOptions
): Boolean;
begin
end;

function SameText(const S1, S2: string): Boolean;
begin
end;

function SameText(
  const S1, S2: string;
  LocaleOptions: TLocaleOptions
): Boolean;
begin
end;

function UpperCase(const S: string): string;
begin
end;

function UpperCase(
  const S: string;
  LocaleOptions: TLocaleOptions
): string;
begin
end;

function LowerCase(const S: string): string;
begin
end;

function LowerCase(
  const S: string;
  LocaleOptions: TLocaleOptions
): string;
begin
end;

function Trim(const S: string): string;
begin
end;

function TrimLeft(const S: string): string;
begin
end;

function TrimRight(const S: string): string;
begin
end;

function QuotedStr(const S: string): string;
begin
end;

function AnsiQuotedStr(const S: string; Quote: Char): string;
begin
end;

function StringReplace(
  const S, OldPattern, NewPattern: string;
  Flags: TReplaceFlags
): string;
begin
end;

function FindDelimiter(
  const Delimiters, S: string;
  StartIdx: Integer = 1
): Integer;
begin
end;

function AnsiPos(
  const Substr, S: string
): Integer;
begin
end;

function AnsiLowerCaseFileName(const S: string): string;
begin
end;

function AnsiUpperCaseFileName(const S: string): string;
begin
end;

function ByteLength(const S: UnicodeString): Integer;
begin
end;

function ByteLength(const S: RawByteString): Integer;
begin
end;

function CharLength(const S: UnicodeString; Index: Integer): Integer;
begin
end;

function NextCharIndex(const S: string; Index: Integer): Integer;
begin
end;

function IsLeadChar(C: AnsiChar): Boolean;
begin
end;

function IsLeadChar(C: Byte): Boolean;
begin
end;

function IsLeadChar(C: WideChar): Boolean;
begin
end;

function CharInSet(C: Char; const CharSet: TSysCharSet): Boolean;
begin
end;

function ByteType(const S: AnsiString; Index: Integer): TMbcsByteType;
begin
end;

function ByteType(const S: UnicodeString; Index: Integer): TMbcsByteType;
begin
end;

function StrByteType(Str: PAnsiChar; Index: Cardinal): TMbcsByteType;
begin
end;

function StrByteType(Str: PWideChar; Index: Cardinal): TMbcsByteType;
begin
end;

function CharToElementIndex(const S: AnsiString; Index: Integer): Integer;
begin
end;

function CharToElementIndex(const S: UnicodeString; Index: Integer): Integer;
begin
end;

function ElementToCharIndex(const S: AnsiString; Index: Integer): Integer;
begin
end;

function ElementToCharIndex(const S: UnicodeString; Index: Integer): Integer;
begin
end;

function ElementToCharLen(const S: AnsiString; MaxLen: Integer): Integer;
begin
end;

function ElementToCharLen(const S: UnicodeString; MaxLen: Integer): Integer;
begin
end;

function CompareMem(P1, P2: Pointer; Length: NativeInt): Boolean;
begin
end;

function ByteToCharLen(const S: string; MaxLen: Integer): Integer;
begin
end;

function CharToByteLen(const S: string; MaxLen: Integer): Integer;
begin
end;

function ByteToCharIndex(const S: string; Index: Integer): Integer;
begin
end;

function CharToByteIndex(const S: string; Index: Integer): Integer;
begin
end;

function StrCharLength(const Str: PAnsiChar): Integer;
begin
end;

function StrCharLength(const Str: PWideChar): Integer;
begin
end;

function StrNextChar(const Str: PAnsiChar): PAnsiChar;
begin
end;

function StrNextChar(const Str: PWideChar): PWideChar;
begin
end;

function StrLen(const Str: PAnsiChar): Cardinal;
begin
end;

function StrLen(const Str: PWideChar): Cardinal;
begin
end;

function StrEnd(const Str: PAnsiChar): PAnsiChar;
begin
end;

function StrEnd(const Str: PWideChar): PWideChar;
begin
end;

function StrMove(
  Dest: PAnsiChar;
  const Source: PAnsiChar;
  Count: Cardinal
): PAnsiChar;
begin
end;

function StrMove(
  Dest: PWideChar;
  const Source: PWideChar;
  Count: Cardinal
): PWideChar;
begin
end;

function StrECopy(Dest: PAnsiChar; const Source: PAnsiChar): PAnsiChar;
begin
end;

function StrECopy(Dest: PWideChar; const Source: PWideChar): PWideChar;
begin
end;

function StrLCat(
  Dest: PAnsiChar;
  const Source: PAnsiChar;
  MaxLen: Cardinal
): PAnsiChar;
begin
end;

function StrLCat(
  Dest: PWideChar;
  const Source: PWideChar;
  MaxLen: Cardinal
): PWideChar;
begin
end;

procedure StrDispose(Str: PAnsiChar);
begin
end;

procedure StrDispose(Str: PWideChar);
begin
end;

function StrFmt(
  Buffer, Format: PAnsiChar;
  const Args: array of const
): PAnsiChar;
begin
end;

function StrFmt(
  Buffer, Format: PWideChar;
  const Args: array of const
): PWideChar;
begin
end;

function StrFmt(
  Buffer, Format: PAnsiChar;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): PAnsiChar;
begin
end;

function StrFmt(
  Buffer, Format: PWideChar;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): PWideChar;
begin
end;

function StrLFmt(
  Buffer: PAnsiChar;
  MaxBufLen: Cardinal;
  Format: PAnsiChar;
  const Args: array of const
): PAnsiChar;
begin
end;

function StrLFmt(
  Buffer: PWideChar;
  MaxBufLen: Cardinal;
  Format: PWideChar;
  const Args: array of const
): PWideChar;
begin
end;

function StrLFmt(
  Buffer: PAnsiChar;
  MaxBufLen: Cardinal;
  Format: PAnsiChar;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): PAnsiChar;
begin
end;

function StrLFmt(
  Buffer: PWideChar;
  MaxBufLen: Cardinal;
  Format: PWideChar;
  const Args: array of const;
  const AFormatSettings: TFormatSettings
): PWideChar;
begin
end;

function StrCopy(Dest: PAnsiChar; const Source: PAnsiChar): PAnsiChar;
begin
end;

function StrCopy(Dest: PWideChar; const Source: PWideChar): PWideChar;
begin
end;

function StrLCopy(
  Dest: PAnsiChar;
  const Source: PAnsiChar;
  MaxLen: Cardinal
): PAnsiChar;
begin
end;

function StrLCopy(
  Dest: PWideChar;
  const Source: PWideChar;
  MaxLen: Cardinal
): PWideChar;
begin
end;

function StrPCopy(Dest: PAnsiChar; const Source: AnsiString): PAnsiChar;
begin
end;

function StrPCopy(Dest: PWideChar; const Source: UnicodeString): PWideChar;
begin
end;

function StrPLCopy(
  Dest: PAnsiChar;
  const Source: AnsiString;
  MaxLen: Cardinal
): PAnsiChar;
begin
end;

function StrPLCopy(
  Dest: PWideChar;
  const Source: UnicodeString;
  MaxLen: Cardinal
): PWideChar;
begin
end;

function StrCat(Dest: PAnsiChar; const Source: PAnsiChar): PAnsiChar;
begin
end;

function StrCat(Dest: PWideChar; const Source: PWideChar): PWideChar;
begin
end;

function StrScan(const Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
begin
end;

function StrScan(const Str: PWideChar; Chr: WideChar): PWideChar;
begin
end;

function StrRScan(const Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
begin
end;

function StrRScan(const Str: PWideChar; Chr: WideChar): PWideChar;
begin
end;

function StrPos(const Str1, Str2: PAnsiChar): PAnsiChar;
begin
end;

function StrPos(const Str1, Str2: PWideChar): PWideChar;
begin
end;

function StrUpper(Str: PAnsiChar): PAnsiChar;
begin
end;

function StrUpper(Str: PWideChar): PWideChar;
begin
end;

function StrLower(Str: PAnsiChar): PAnsiChar;
begin
end;

function StrLower(Str: PWideChar): PWideChar;
begin
end;

function StrPas(const Str: PAnsiChar): AnsiString;
begin
end;

function StrPas(const Str: PWideChar): UnicodeString;
begin
end;

function StrNew(const Str: PAnsiChar): PAnsiChar;
begin
end;

function StrNew(const Str: PWideChar): PWideChar;
begin
end;

function StrBufSize(const Str: PAnsiChar): Cardinal;
begin
end;

function StrBufSize(const Str: PWideChar): Cardinal;
begin
end;

function StrAlloc(Size: Cardinal): PChar;
begin
end;

function StrComp(const Str1, Str2: PAnsiChar): Integer;
begin
end;

function StrComp(const Str1, Str2: PWideChar): Integer;
begin
end;

function StrIComp(const Str1, Str2: PAnsiChar): Integer;
begin
end;

function StrIComp(const Str1, Str2: PWideChar): Integer;
begin
end;

function StrLComp(
  const Str1, Str2: PAnsiChar;
  MaxLen: Cardinal
): Integer;
begin
end;

function StrLComp(
  const Str1, Str2: PWideChar;
  MaxLen: Cardinal
): Integer;
begin
end;

function StrLIComp(
  const Str1, Str2: PAnsiChar;
  MaxLen: Cardinal
): Integer;
begin
end;

function StrLIComp(
  const Str1, Str2: PWideChar;
  MaxLen: Cardinal
): Integer;
begin
end;

function TextPos(Str, SubStr: PAnsiChar): PAnsiChar;
begin
end;

function TextPos(Str, SubStr: PWideChar): PWideChar;
begin
end;

function HashName(Name: PAnsiChar): Cardinal;
begin
end;

function AnsiStrComp(S1, S2: PAnsiChar): Integer;
begin
end;

function AnsiStrComp(S1, S2: PWideChar): Integer;
begin
end;

function AnsiStrIComp(S1, S2: PAnsiChar): Integer;
begin
end;

function AnsiStrIComp(S1, S2: PWideChar): Integer;
begin
end;

function AnsiStrLComp(
  S1, S2: PAnsiChar;
  MaxLen: Cardinal
): Integer;
begin
end;

function AnsiStrLComp(
  S1, S2: PWideChar;
  MaxLen: Cardinal
): Integer;
begin
end;

function AnsiStrLIComp(
  S1, S2: PAnsiChar;
  MaxLen: Cardinal
): Integer;
begin
end;

function AnsiStrLIComp(
  S1, S2: PWideChar;
  MaxLen: Cardinal
): Integer;
begin
end;

function AnsiStrUpper(Str: PAnsiChar): PAnsiChar;
begin
end;

function AnsiStrUpper(Str: PWideChar): PWideChar;
begin
end;

function AnsiStrLower(Str: PAnsiChar): PAnsiChar;
begin
end;

function AnsiStrLower(Str: PWideChar): PWideChar;
begin
end;

function AnsiStrPos(Str, SubStr: PAnsiChar): PAnsiChar;
begin
end;

function AnsiStrPos(Str, SubStr: PWideChar): PWideChar;
begin
end;

function AnsiStrScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
begin
end;

function AnsiStrScan(Str: PWideChar; Chr: WideChar): PWideChar;
begin
end;

function AnsiStrRScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
begin
end;

function AnsiStrRScan(Str: PWideChar; Chr: WideChar): PWideChar;
begin
end;

function AnsiStrLastChar(P: PAnsiChar): PAnsiChar;
begin
end;

function AnsiStrLastChar(P: PWideChar): PWideChar;
begin
end;

function AnsiLastChar(const S: UnicodeString): PWideChar;
begin
end;

function AnsiExtractQuotedStr(
  var Src: PAnsiChar;
  Quote: AnsiChar
): AnsiString;
begin
end;

function AnsiExtractQuotedStr(
  var Src: PWideChar;
  Quote: WideChar
): UnicodeString;
begin
end;

function AnsiUpperCase(const S: string): string;
begin
end;

function AnsiLowerCase(const S: string): string;
begin
end;

function AnsiCompareStr(const S1, S2: string): Integer;
begin
end;

function AnsiCompareText(const S1, S2: string): Integer;
begin
end;

function AnsiSameStr(const S1, S2: string): Boolean;
begin
end;

function AnsiSameText(const S1, S2: string): Boolean;
begin
end;

function AnsiDequotedStr(const S: string; AQuote: Char): string;
begin
end;

function AdjustLineBreaks(
  const S: string;
  Style: TTextLineBreakStyle = tlbsCRLF
): string;
begin
end;

function IsValidIdent(
  const Ident: string;
  AllowDots: Boolean = False
): Boolean;
begin
end;

function WrapText(
  const Line, BreakStr: string;
  const BreakChars: TSysCharSet;
  MaxCol: Integer
): string;
begin
end;

function WrapText(
  const Line: string;
  MaxCol: Integer = 45
): string;
begin
end;

function WideUpperCase(const S: string): string;
begin
end;

function WideLowerCase(const S: string): string;
begin
end;

function WideCompareStr(const S1, S2: string): Integer;
begin
end;

function WideCompareText(const S1, S2: string): Integer;
begin
end;

function WideSameStr(const S1, S2: string): Boolean;
begin
end;

function WideSameText(const S1, S2: string): Boolean;
begin
end;

procedure AppendStr(var Dest: string; const S: string);
begin
end;

function DateToStr(const DateTime: TDateTime): string;
begin
end;

function DateToStr(
  const DateTime: TDateTime;
  const FormatSettings: TFormatSettings
): string;
begin
end;

function TimeToStr(const DateTime: TDateTime): string;
begin
end;

function TimeToStr(
  const DateTime: TDateTime;
  const FormatSettings: TFormatSettings
): string;
begin
end;

function DateTimeToStr(const DateTime: TDateTime): string;
begin
end;

function DateTimeToStr(
  const DateTime: TDateTime;
  const FormatSettings: TFormatSettings
): string;
begin
end;

function StrToDate(const S: string): TDateTime;
begin
end;

function StrToDate(
  const S: string;
  const FormatSettings: TFormatSettings
): TDateTime;
begin
end;

function StrToDateDef(
  const S: string;
  Default: TDateTime
): TDateTime;
begin
end;

function StrToDateDef(
  const S: string;
  Default: TDateTime;
  const FormatSettings: TFormatSettings
): TDateTime;
begin
end;

function StrToTime(const S: string): TDateTime;
begin
end;

function StrToTime(
  const S: string;
  const FormatSettings: TFormatSettings
): TDateTime;
begin
end;

function StrToTimeDef(
  const S: string;
  Default: TDateTime
): TDateTime;
begin
end;

function StrToTimeDef(
  const S: string;
  Default: TDateTime;
  const FormatSettings: TFormatSettings
): TDateTime;
begin
end;

function StrToDateTime(const S: string): TDateTime;
begin
end;

function StrToDateTime(
  const S: string;
  const FormatSettings: TFormatSettings
): TDateTime;
begin
end;

function StrToDateTimeDef(
  const S: string;
  Default: TDateTime
): TDateTime;
begin
end;

function StrToDateTimeDef(
  const S: string;
  Default: TDateTime;
  const FormatSettings: TFormatSettings
): TDateTime;
begin
end;

function TryStrToDate(const S: string; out Value: TDateTime): Boolean;
begin
end;

function TryStrToDate(
  const S: string;
  out Value: TDateTime;
  const FormatSettings: TFormatSettings
): Boolean;
begin
end;

function TryStrToTime(const S: string; out Value: TDateTime): Boolean;
begin
end;

function TryStrToTime(
  const S: string;
  out Value: TDateTime;
  const FormatSettings: TFormatSettings
): Boolean;
begin
end;

function TryStrToDateTime(const S: string; out Value: TDateTime): Boolean;
begin
end;

function TryStrToDateTime(
  const S: string;
  out Value: TDateTime;
  const FormatSettings: TFormatSettings
): Boolean;
begin
end;

function FormatDateTime(const Format: string; DateTime: TDateTime): string;
begin
end;

function FormatDateTime(
  const Format: string;
  DateTime: TDateTime;
  const FormatSettings: TFormatSettings
): string;
begin
end;

function ChangeFileExt(const FileName, Extension: string): string;
begin
end;

function ChangeFilePath(const FileName, Path: string): string;
begin
end;

function ExtractFileDir(const FileName: string): string;
begin
end;

function ExtractFileDrive(const FileName: string): string;
begin
end;

function ExtractFileExt(const FileName: string): string;
begin
end;

function ExtractFileName(const FileName: string): string;
begin
end;

function ExtractFilePath(const FileName: string): string;
begin
end;

function IncludeTrailingPathDelimiter(const S: string): string;
begin
end;

function IncludeTrailingBackslash(const S: string): string;
begin
end;

function ExcludeTrailingPathDelimiter(const S: string): string;
begin
end;

function ExcludeTrailingBackslash(const S: string): string;
begin
end;

function ExpandFileName(const FileName: string): string;
begin
end;

function ExpandFileNameCase(
  const FileName: string;
  out MatchFound: TFilenameCaseMatch
): string;
begin
end;

function ExpandUNCFileName(const FileName: string): string;
begin
end;

function ExtractRelativePath(const BaseName, DestName: string): string;
begin
end;

function ExtractShortPathName(const FileName: string): string;
begin
end;

function IsPathDelimiter(const S: string; Index: Integer): Boolean;
begin
end;

function IsDelimiter(const Delimiters, S: string; Index: Integer): Boolean;
begin
end;

function LastDelimiter(const Delimiters, S: string): Integer;
begin
end;

function IsRelativePath(const Path: string): Boolean;
begin
end;

function FileSearch(const Name, DirList: string): string;
begin
end;

function SameFileName(const S1, S2: string): Boolean;
begin
end;

function AnsiCompareFileName(
  const S1, S2: string;
  CheckVolumeCase: Boolean = False
): Integer;
begin
end;

function FileExists(const FileName: string; FollowLink: Boolean = True): Boolean;
begin
end;

function DirectoryExists(const Directory: string; FollowLink: Boolean = True): Boolean;
begin
end;

function ForceDirectories(Dir: string): Boolean;
begin
end;

function FindFirst(
  const Path: string;
  Attr: Integer;
  var F: TSearchRec
): Integer;
begin
end;

function FindNext(var F: TSearchRec): Integer;
begin
end;

procedure FindClose(var F: TSearchRec);
begin
end;

function FileGetDateTimeInfo(
  const FileName: string;
  out DateTime: TDateTimeInfoRec;
  FollowLink: Boolean = True
): Boolean;
begin
end;

function FileCreateSymLink(
  const Link, Target: string
): Boolean;
begin
end;

function FileGetSymLinkTarget(
  const FileName: string;
  var SymLinkRec: TSymLinkRec
): Boolean;
begin
end;

function FileGetSymLinkTarget(
  const FileName: string;
  var TargetName: string
): Boolean;
begin
end;

function FileSystemAttributes(
  const Path: string
): TFileSystemAttributes;
begin
end;

function GetCurrentDir: string;
begin
end;

function SetCurrentDir(const Dir: string): Boolean;
begin
end;

function CreateDir(const Dir: string): Boolean;
begin
end;

function RemoveDir(const Dir: string): Boolean;
begin
end;

function DiskFree(Drive: Byte): Int64;
begin
end;

function DiskSize(Drive: Byte): Int64;
begin
end;

function FileGetAttr(
  const FileName: string;
  FollowLink: Boolean = True
): Integer;
begin
end;

function FileSetAttr(
  const FileName: string;
  Attr: Integer;
  FollowLink: Boolean = True
): Integer;
begin
end;

function FileIsReadOnly(const FileName: string): Boolean;
begin
end;

function FileSetReadOnly(
  const FileName: string;
  ReadOnly: Boolean
): Boolean;
begin
end;

function DeleteFile(const FileName: string): Boolean;
begin
end;

function RenameFile(
  const OldName, NewName: string
): Boolean;
begin
end;

function IsAssembly(const FileName: string): Boolean;
begin
end;

function FileDateToDateTime(FileDate: Integer): TDateTime;
begin
end;

function DateTimeToFileDate(DateTime: TDateTime): Integer;
begin
end;

function FileAge(const FileName: string): Integer;
begin
end;

function FileAge(
  const FileName: string;
  out FileDateTime: TDateTime;
  FollowLink: Boolean = True
): Boolean;
begin
end;

function FileSetDate(
  const FileName: string;
  Age: Integer
): Integer;
begin
end;

function FileSetDate(
  Handle: THandle;
  Age: Integer
): Integer;
begin
end;

function FileOpen(
  const FileName: string;
  Mode: LongWord
): THandle;
begin
end;

function FileRead(
  Handle: THandle;
  var Buffer;
  Count: LongWord
): Integer;
begin
end;

function FileWrite(
  Handle: THandle;
  const Buffer;
  Count: LongWord
): Integer;
begin
end;

function FileCreate(const FileName: string): THandle;
begin
end;

function FileCreate(
  const FileName: string;
  Rights: Integer
): THandle;
begin
end;

function FileCreate(
  const FileName: string;
  Mode: LongWord;
  Rights: Integer
): THandle;
begin
end;

function FileSeek(
  Handle: THandle;
  Offset, Origin: Integer
): Integer;
begin
end;

function FileSeek(
  Handle: THandle;
  const Offset: Int64;
  Origin: Integer
): Int64;
begin
end;

function FileGetDate(Handle: THandle): LongInt;
begin
end;

procedure FileClose(Handle: THandle);
begin
end;

function SafeLoadLibrary(
  const FileName: string;
  ErrorMode: Cardinal
): HMODULE;
begin
end;

function LoadPackage(const Name: string): HMODULE;
begin
end;

function LoadPackage(
  const Name: string;
  AValidatePackage: TValidatePackageProc
): HMODULE;
begin
end;

procedure InitializePackage(Module: HMODULE);
begin
end;

procedure InitializePackage(
  Module: HMODULE;
  AValidatePackage: TValidatePackageProc
);
begin
end;

procedure FinalizePackage(Module: HMODULE);
begin
end;

procedure UnloadPackage(Module: HMODULE);
begin
end;

function GetPackageDescription(ModuleName: PChar): string;
begin
end;

procedure GetPackageInfo(
  Module: HMODULE;
  Param: Pointer;
  var Flags: Integer;
  InfoProc: TPackageInfoProc
);
begin
end;

function GetPackageTargets(Module: HMODULE): UInt32;
begin
end;

procedure AddExitProc(Proc: TProcedure);
begin
end;

procedure AddTerminateProc(TermProc: TTerminateProc);
begin
end;

function CallTerminateProcs: Boolean;
begin
end;

function GrowCollection(
  OldCapacity, NewCount: NativeInt
): NativeInt;
begin
end;

function SetGrowCollectionFunc(
  Func: TGrowCollectionFunc
): TGrowCollectionFunc;
begin
end;

function GetDefaultFallbackLanguages: string;
begin
end;

procedure SetDefaultFallbackLanguages(const Languages: string);
begin
end;

function PreferredUILanguages: string;
begin
end;

function GetEnvironmentVariable(const Name: string): string;
begin
end;

function GetHomePath: string;
begin
end;

function GetLocaleStr(
  Locale: Integer;
  LocaleType: Integer;
  const Default: string
): string;
begin
end;

function GetLocaleChar(
  Locale: Integer;
  LocaleType: Integer;
  Default: Char
): Char;
begin
end;

procedure GetLocaleFormatSettings(
  Locale: TLocaleID;
  var AFormatSettings: TFormatSettings
);
begin
end;

function LocaleFileExists(
  const FileName: string
): Boolean;
begin
end;

function GetLocaleFile(
  const FileName: string
): string;
begin
end;

function LocaleDirectoryExists(
  const Directory: string
): Boolean;
begin
end;

function GetLocaleDirectory(
  const Directory: string
): string;
begin
end;

function CheckWin32Version(
  AMajor: Integer;
  AMinor: Integer = 0
): Boolean;
begin
end;

function GetFileVersion(const AFileName: string): Cardinal;
begin
end;

function GetProductVersion(
  const AFileName: string;
  var AMajor, AMinor, ABuild: Cardinal
): Boolean;
begin
end;

procedure GetFormatSettings;
begin
end;

function LCIDToCodePage(const ALCID: Cardinal): Integer;
begin
end;

function GetModuleName(Module: THandle): string;
begin
end;

function LoadStr(Ident: NativeUInt): string;
begin
end;

function FmtLoadStr(
  Ident: NativeUInt;
  const Args: array of const
): string;
begin
end;

function FindCmdLineSwitch(
  const Switch: string;
  const Chars: TSysCharSet;
  IgnoreCase: Boolean
): Boolean;
begin
end;

function FindCmdLineSwitch(
  const Switch: string
): Boolean;
begin
end;

function FindCmdLineSwitch(
  const Switch: string;
  IgnoreCase: Boolean
): Boolean;
begin
end;

function FindCmdLineSwitch(
  const Switch: string;
  var Value: string;
  IgnoreCase: Boolean = True;
  const SwitchTypes: TCmdLineSwitchTypes =
    [clstValueNextParam, clstValueAppended]
): Boolean;
begin
end;

procedure Beep;
begin
end;

function IsEqualGUID(
  const Guid1, Guid2: TGUID
): Boolean;
begin
end;

function CreateGUID(
  out Guid: TGUID
): HResult;
begin
end;

function StringToGUID(
  const S: string
): TGUID;
begin
end;

function StrToGUID(
  S: PWideChar
): TGUID;
begin
end;

function GUIDToString(
  const Guid: TGUID
): string;
begin
end;

function GUIDToString(
  const Guid: TGUID;
  const Format: Char
): string;
begin
end;

function Supports(
  const Instance: IInterface;
  const IID: TGUID;
  out Intf
): Boolean;
begin
end;

function Supports(
  const Instance: TObject;
  const IID: TGUID;
  out Intf
): Boolean;
begin
end;

function Supports(
  const Instance: IInterface;
  const IID: TGUID
): Boolean;
begin
end;

function Supports(
  const Instance: TObject;
  const IID: TGUID
): Boolean;
begin
end;

function Supports(
  const AClass: TClass;
  const IID: TGUID
): Boolean;
begin
end;

function ExceptionErrorMessage(
  ExceptObject: TObject;
  ExceptAddr: Pointer;
  Buffer: PChar;
  Size: Integer
): Integer;
begin
end;

procedure Abort;
begin
end;

procedure OutOfMemoryError;
begin
end;

procedure RaiseLastOSError;
begin
end;

procedure RaiseLastOSError(LastError: Integer);
begin
end;

procedure RaiseLastOSError(
  LastError: Integer;
  const AdditionalInfo: string
);
begin
end;

procedure RaiseLastWin32Error;
begin
end;

function Win32Check(RetVal: LongBool): LongBool;
begin
end;

procedure CheckOSError(LastError: Integer);
begin
end;

function SysErrorMessage(
  ErrorCode: Cardinal;
  AModuleHandle: THandle = 0
): string;
begin
end;

procedure FreeAndNil(var Obj: TObject);
begin
end;

end.
