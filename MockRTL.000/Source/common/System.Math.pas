{
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.Math functionality required by D2CSharp.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The routines below intentionally contain no RTL implementation. Functions
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

unit System.Math;

interface

uses
  System.SysUtils,
  System.Types;

const
  ZeroValue     = 0;
  PositiveValue = 1;
  NegativeValue = -1;


  MaxSingle         = 3.403e38;
  MinSingle         = 1.175e-38;
  MinSingleDenormal = 1.401e-45;
  MaxDouble         = 1.798e308;
  MinDouble         = 2.225e-308;
  MinDoubleDenormal = 0.0;

  seSSE       = 1;
  seSSE2      = 2;
  seSSE3      = 4;
  seSSSE3     = 8;
  seSSE41     = $10;
  seSSE42     = $20;
  sePOPCNT    = $40;
  seAESNI     = $80;
  sePCLMULQDQ = $100;

type
  TValueSign = -1..1;

  TRoundingMode = (
    rmNearest,
    rmDown,
    rmUp,
    rmTruncate
  );

  TFPURoundingMode = type TRoundingMode;
  TSSERoundingMode = type TRoundingMode;

  TFPUPrecisionMode = (
    pmSingle,
    pmReserved,
    pmDouble,
    pmExtended
  );

  TArithmeticException = (
    exInvalidOp,
    exDenormalized,
    exZeroDivide,
    exOverflow,
    exUnderflow,
    exPrecision
  );

  TArithmeticExceptions = set of TArithmeticException;
  TArithmeticExceptionMask = set of TArithmeticException;
  TFPUException = type TArithmeticException;
  TFPUExceptionMask = set of TArithmeticException;
  TSSEException = type TArithmeticException;
  TSSEExceptionMask = set of TArithmeticException;

  TRoundToRange = -37..37;
  TRoundToEXRangeExtended = -20..20;

  TPaymentTime = (
    ptEndOfPeriod,
    ptStartOfPeriod
  );

  EInvalidArgument = class(Exception);

var
  Infinity: Double;
  NegInfinity: Double;
  NaN: Double;
  MaxComp: Int64;
  MinComp: Int64;

{ Min/max and range }

function Min(const A, B: ShortInt): ShortInt; overload;
function Min(const A, B: Byte): Byte; overload;
function Min(const A, B: SmallInt): SmallInt; overload;
function Min(const A, B: Word): Word; overload;
function Min(const A, B: Integer): Integer; overload;
function Min(const A, B: Cardinal): Cardinal; overload;
function Min(const A, B: Int64): Int64; overload;
function Min(const A, B: UInt64): UInt64; overload;
function Min(const A, B: Single): Single; overload;
function Min(const A, B: Double): Double; overload;
function Min(const A, B: Currency): Currency; overload;

function Max(const A, B: ShortInt): ShortInt; overload;
function Max(const A, B: Byte): Byte; overload;
function Max(const A, B: SmallInt): SmallInt; overload;
function Max(const A, B: Word): Word; overload;
function Max(const A, B: Integer): Integer; overload;
function Max(const A, B: Cardinal): Cardinal; overload;
function Max(const A, B: Int64): Int64; overload;
function Max(const A, B: UInt64): UInt64; overload;
function Max(const A, B: Single): Single; overload;
function Max(const A, B: Double): Double; overload;
function Max(const A, B: Currency): Currency; overload;

function EnsureRange(const AValue, AMin, AMax: Integer): Integer; overload;
function EnsureRange(const AValue, AMin, AMax: Int64): Int64; overload;
function EnsureRange(const AValue, AMin, AMax: UInt64): UInt64; overload;
function EnsureRange(const AValue, AMin, AMax: Single): Single; overload;
function EnsureRange(const AValue, AMin, AMax: Double): Double; overload;

function InRange(const AValue, AMin, AMax: Integer): Boolean; overload;
function InRange(const AValue, AMin, AMax: Int64): Boolean; overload;
function InRange(const AValue, AMin, AMax: UInt64): Boolean; overload;
function InRange(const AValue, AMin, AMax: Single): Boolean; overload;
function InRange(const AValue, AMin, AMax: Double): Boolean; overload;

{ Comparison }

function SameValue(const A, B: Single; Epsilon: Single = 0): Boolean; overload;
function SameValue(const A, B: Double; Epsilon: Double = 0): Boolean; overload;
function IsZero(const A: Single; Epsilon: Single = 0): Boolean; overload;
function IsZero(const A: Double; Epsilon: Double = 0): Boolean; overload;

function CompareValue(const A, B: Single; Epsilon: Single = 0): TValueRelationship; overload;
function CompareValue(const A, B: Double; Epsilon: Double = 0): TValueRelationship; overload;
function CompareValue(const A, B: Integer): TValueRelationship; overload;
function CompareValue(const A, B: Int64): TValueRelationship; overload;
function CompareValue(const A, B: UInt64): TValueRelationship; overload;

function Sign(const AValue: Integer): TValueSign; overload;
function Sign(const AValue: Int64): TValueSign; overload;
function Sign(const AValue: Single): TValueSign; overload;
function Sign(const AValue: Double): TValueSign; overload;

{ Floating-point control }

function GetRoundMode: TRoundingMode;
function SetRoundMode(const RoundMode: TRoundingMode): TRoundingMode;
function GetFPURoundMode: TFPURoundingMode;
function SetFPURoundMode(const RoundMode: TFPURoundingMode): TFPURoundingMode;
function GetSSERoundMode: TSSERoundingMode;
function SetSSERoundMode(const RoundMode: TSSERoundingMode): TSSERoundingMode;
function GetPrecisionMode: TFPUPrecisionMode;
function SetPrecisionMode(const Precision: TFPUPrecisionMode): TFPUPrecisionMode;

function GetExceptionMask: TArithmeticExceptionMask;
function SetExceptionMask(const Mask: TArithmeticExceptionMask): TArithmeticExceptionMask;
function GetExceptions: TArithmeticExceptions;
function SetExceptions(const Exceptions: TArithmeticExceptions): TArithmeticExceptions;
function GetFPUExceptionMask: TFPUExceptionMask;
function SetFPUExceptionMask(const Mask: TFPUExceptionMask): TFPUExceptionMask;
function GetSSEExceptionMask: TSSEExceptionMask;
function SetSSEExceptionMask(const Mask: TSSEExceptionMask): TSSEExceptionMask;

procedure ClearExceptions(RaisePending: Boolean = True);
procedure ClearFPUExceptions(RaisePending: Boolean = True);
procedure ClearSSEExceptions(RaisePending: Boolean = True);
procedure RaiseExceptions(const ExceptionFlags: TArithmeticExceptions);

{ Rounding and decomposition }

function RoundTo(const AValue: Double; const ADigit: TRoundToEXRangeExtended): Double; overload;
function SimpleRoundTo(const AValue: Single; const ADigit: TRoundToRange = -2): Single; overload;
function SimpleRoundTo(const AValue: Double; const ADigit: TRoundToRange = -2): Double; overload;
function Floor(const X: Single): Integer; overload;
function Floor(const X: Double): Integer; overload;
function Ceil(const X: Single): Integer; overload;
function Ceil(const X: Double): Integer; overload;

procedure Frexp(const X: Single; var Mantissa: Single; var Exponent: Integer); overload;
procedure Frexp(const X: Double; var Mantissa: Double; var Exponent: Integer); overload;
function FMod(const ANumerator, ADenominator: Single): Single; overload;
function FMod(const ANumerator, ADenominator: Double): Double; overload;
procedure DivMod(Dividend: Cardinal; Divisor: Word; var Result, Remainder: Word); overload;
procedure DivMod(Dividend: UInt64; Divisor: UInt64; var Result, Remainder: UInt64); overload;

{ Powers and logarithms }

function IntPower(const Base: Single; const Exponent: Integer): Single; overload;
function IntPower(const Base: Double; const Exponent: Integer): Double; overload;
function Power(const Base, Exponent: Double): Double;
function LogN(const Base, X: Double): Double;
function Log2(const X: Double): Double;
function Log10(const X: Double): Double;
function LnXP1(const X: Double): Double;
function Ldexp(const X: Double; const P: Integer): Double;

{ Trigonometric and hyperbolic functions }

function ArcCos(const X: Double): Double;
function ArcSin(const X: Double): Double;
function ArcTan2(const Y, X: Double): Double;
function ArcCot(const X: Double): Double;
function ArcCotH(const X: Double): Double;
function ArcCsc(const X: Double): Double;
function ArcCscH(const X: Double): Double;
function ArcSec(const X: Double): Double;
function ArcSecH(const X: Double): Double;

function SinH(const X: Double): Double;
function CosH(const X: Double): Double;
function TanH(const X: Double): Double;
function SecH(const X: Double): Double;
function CscH(const X: Double): Double;
function CotH(const X: Double): Double;

function ArcSinh(const X: Double): Double;
function ArcCosh(const X: Double): Double;
function ArcTanh(const X: Double): Double;

function Tan(const X: Double): Double;
function Cot(const X: Double): Double;
function Cotan(const X: Double): Double;
function Sec(const X: Double): Double;
function Secant(const X: Double): Double;
function Csc(const X: Double): Double;
function Cosecant(const X: Double): Double;

procedure SinCos(const Theta: Double; var Sin, Cos: Double);

function Hypot(const X, Y: Single): Single; overload;
function Hypot(const X, Y: Double): Double; overload;
function Hypot(const X, Y, Z: Single): Single; overload;
function Hypot(const X, Y, Z: Double): Double; overload;

{ Angle conversion }

function DegToRad(const Degrees: Double): Double;
function RadToDeg(const Radians: Double): Double;
function GradToRad(const Grads: Double): Double;
function RadToGrad(const Radians: Double): Double;
function DegToGrad(const Degrees: Double): Double;
function GradToDeg(const Grads: Double): Double;
function CycleToRad(const Cycles: Double): Double;
function RadToCycle(const Radians: Double): Double;
function CycleToDeg(const Cycles: Double): Double;
function DegToCycle(const Degrees: Double): Double;
function CycleToGrad(const Cycles: Double): Double;
function GradToCycle(const Grads: Double): Double;

{ Conditional helpers }

function IfThen(AValue: Boolean; const ATrue: Integer; const AFalse: Integer = 0): Integer; overload;
function IfThen(AValue: Boolean; const ATrue: Int64; const AFalse: Int64 = 0): Int64; overload;
function IfThen(AValue: Boolean; const ATrue: Single; const AFalse: Single = 0): Single; overload;
function IfThen(AValue: Boolean; const ATrue: Double; const AFalse: Double = 0): Double; overload;

{ Random helpers }

function RandomRange(const AFrom, ATo: Integer): Integer; overload;
function RandomRange(const AFrom, ATo: Int64): Int64; overload;
function RandomFrom(const AValues: array of ShortInt): ShortInt; overload;
function RandomFrom(const AValues: array of SmallInt): SmallInt; overload;
function RandomFrom(const AValues: array of Integer): Integer; overload;
function RandomFrom(const AValues: array of Int64): Int64; overload;
function RandomFrom(const AValues: array of Byte): Byte; overload;
function RandomFrom(const AValues: array of Word): Word; overload;
function RandomFrom(const AValues: array of Cardinal): Cardinal; overload;
function RandomFrom(const AValues: array of UInt64): UInt64; overload;
function RandomFrom(const AValues: array of Single): Single; overload;
function RandomFrom(const AValues: array of Double): Double; overload;
function RandomFrom(const AValues: array of Boolean): Boolean; overload;
function RandG(Mean, StdDev: Single): Single; overload;
function RandG(Mean, StdDev: Double): Double; overload;

{ Classification }

function IsNan(const AValue: Single): Boolean; overload;
function IsNan(const AValue: Double): Boolean; overload;
function IsInfinite(const AValue: Single): Boolean; overload;
function IsInfinite(const AValue: Double): Boolean; overload;

{ Statistics }

function Sum(const Data: array of Single): Single; overload;
function Sum(const Data: array of Double): Double; overload;
function SumInt(const Data: array of Integer): Int64;
function SumOfSquares(const Data: array of Single): Single; overload;
function SumOfSquares(const Data: array of Double): Double; overload;
procedure SumsAndSquares(const Data: array of Single; var Sum, SumOfSquares: Single); overload;
procedure SumsAndSquares(const Data: array of Double; var Sum, SumOfSquares: Double); overload;

function Mean(const Data: array of Single): Single; overload;
function Mean(const Data: array of Double): Double; overload;
function TotalVariance(const Data: array of Single): Single; overload;
function TotalVariance(const Data: array of Double): Double; overload;
function Variance(const Data: array of Single): Single; overload;
function Variance(const Data: array of Double): Double; overload;
function PopnVariance(const Data: array of Single): Single; overload;
function PopnVariance(const Data: array of Double): Double; overload;
function StdDev(const Data: array of Single): Single; overload;
function StdDev(const Data: array of Double): Double; overload;
function PopnStdDev(const Data: array of Single): Single; overload;
function PopnStdDev(const Data: array of Double): Double; overload;

procedure MeanAndStdDev(const Data: array of Single; var Mean, StdDev: Single); overload;
procedure MeanAndStdDev(const Data: array of Double; var Mean, StdDev: Double); overload;

function MaxValue(const Data: array of Single): Single; overload;
function MaxValue(const Data: array of Double): Double; overload;
function MinValue(const Data: array of Single): Single; overload;
function MinValue(const Data: array of Double): Double; overload;
function MaxIntValue(const Data: array of Integer): Integer;
function MinIntValue(const Data: array of Integer): Integer;

function Norm(const Data: array of Single): Single; overload;
function Norm(const Data: array of Double): Double; overload;
function Poly(const X: Single; const Coefficients: array of Single): Single; overload;
function Poly(const X: Double; const Coefficients: array of Double): Double; overload;

{ Finance }

function DoubleDecliningBalance(const Cost, Salvage: Extended; Life, Period: Integer): Extended;
function FutureValue(const Rate: Extended; NPeriods: Integer; const Payment, PresentValue: Extended; PaymentTime: TPaymentTime): Extended;
function PresentValue(const Rate: Extended; NPeriods: Integer; const Payment, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
function InterestPayment(const Rate: Extended; Period, NPeriods: Integer; const PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
function InterestRate(NPeriods: Integer; const Payment, PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime; const Guess: Extended): Extended;
function InternalRateOfReturn(const Guess: Extended; const CashFlows: array of Double): Extended;
function NumberOfPeriods(const Rate, Payment, PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
function Payment(const Rate: Extended; NPeriods: Integer; const PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
function PeriodPayment(const Rate: Extended; Period, NPeriods: Integer; const PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
function SLNDepreciation(const Cost, Salvage: Extended; Life: Integer): Extended;
function SYDDepreciation(const Cost, Salvage: Extended; Life, Period: Integer): Extended;

implementation

function Min(const A, B: ShortInt): ShortInt;
begin
end;

function Min(const A, B: Byte): Byte;
begin
end;

function Min(const A, B: SmallInt): SmallInt;
begin
end;

function Min(const A, B: Word): Word;
begin
end;

function Min(const A, B: Integer): Integer;
begin
end;

function Min(const A, B: Cardinal): Cardinal;
begin
end;

function Min(const A, B: Int64): Int64;
begin
end;

function Min(const A, B: UInt64): UInt64;
begin
end;

function Min(const A, B: Single): Single;
begin
end;

function Min(const A, B: Double): Double;
begin
end;

function Min(const A, B: Currency): Currency;
begin
end;

function Max(const A, B: ShortInt): ShortInt;
begin
end;

function Max(const A, B: Byte): Byte;
begin
end;

function Max(const A, B: SmallInt): SmallInt;
begin
end;

function Max(const A, B: Word): Word;
begin
end;

function Max(const A, B: Integer): Integer;
begin
end;

function Max(const A, B: Cardinal): Cardinal;
begin
end;

function Max(const A, B: Int64): Int64;
begin
end;

function Max(const A, B: UInt64): UInt64;
begin
end;

function Max(const A, B: Single): Single;
begin
end;

function Max(const A, B: Double): Double;
begin
end;

function Max(const A, B: Currency): Currency;
begin
end;

function EnsureRange(const AValue, AMin, AMax: Integer): Integer;
begin
end;

function EnsureRange(const AValue, AMin, AMax: Int64): Int64;
begin
end;

function EnsureRange(const AValue, AMin, AMax: UInt64): UInt64;
begin
end;

function EnsureRange(const AValue, AMin, AMax: Single): Single;
begin
end;

function EnsureRange(const AValue, AMin, AMax: Double): Double;
begin
end;

function InRange(const AValue, AMin, AMax: Integer): Boolean;
begin
end;

function InRange(const AValue, AMin, AMax: Int64): Boolean;
begin
end;

function InRange(const AValue, AMin, AMax: UInt64): Boolean;
begin
end;

function InRange(const AValue, AMin, AMax: Single): Boolean;
begin
end;

function InRange(const AValue, AMin, AMax: Double): Boolean;
begin
end;

function SameValue(const A, B: Single; Epsilon: Single): Boolean;
begin
end;

function SameValue(const A, B: Double; Epsilon: Double): Boolean;
begin
end;

function IsZero(const A: Single; Epsilon: Single): Boolean;
begin
end;

function IsZero(const A: Double; Epsilon: Double): Boolean;
begin
end;

function CompareValue(const A, B: Single; Epsilon: Single): TValueRelationship;
begin
end;

function CompareValue(const A, B: Double; Epsilon: Double): TValueRelationship;
begin
end;

function CompareValue(const A, B: Integer): TValueRelationship;
begin
end;

function CompareValue(const A, B: Int64): TValueRelationship;
begin
end;

function CompareValue(const A, B: UInt64): TValueRelationship;
begin
end;

function Sign(const AValue: Integer): TValueSign;
begin
end;

function Sign(const AValue: Int64): TValueSign;
begin
end;

function Sign(const AValue: Single): TValueSign;
begin
end;

function Sign(const AValue: Double): TValueSign;
begin
end;

function GetRoundMode: TRoundingMode;
begin
end;

function SetRoundMode(const RoundMode: TRoundingMode): TRoundingMode;
begin
end;

function GetFPURoundMode: TFPURoundingMode;
begin
end;

function SetFPURoundMode(const RoundMode: TFPURoundingMode): TFPURoundingMode;
begin
end;

function GetSSERoundMode: TSSERoundingMode;
begin
end;

function SetSSERoundMode(const RoundMode: TSSERoundingMode): TSSERoundingMode;
begin
end;

function GetPrecisionMode: TFPUPrecisionMode;
begin
end;

function SetPrecisionMode(const Precision: TFPUPrecisionMode): TFPUPrecisionMode;
begin
end;

function GetExceptionMask: TArithmeticExceptionMask;
begin
end;

function SetExceptionMask(const Mask: TArithmeticExceptionMask): TArithmeticExceptionMask;
begin
end;

function GetExceptions: TArithmeticExceptions;
begin
end;

function SetExceptions(const Exceptions: TArithmeticExceptions): TArithmeticExceptions;
begin
end;

function GetFPUExceptionMask: TFPUExceptionMask;
begin
end;

function SetFPUExceptionMask(const Mask: TFPUExceptionMask): TFPUExceptionMask;
begin
end;

function GetSSEExceptionMask: TSSEExceptionMask;
begin
end;

function SetSSEExceptionMask(const Mask: TSSEExceptionMask): TSSEExceptionMask;
begin
end;

procedure ClearExceptions(RaisePending: Boolean);
begin
end;

procedure ClearFPUExceptions(RaisePending: Boolean);
begin
end;

procedure ClearSSEExceptions(RaisePending: Boolean);
begin
end;

procedure RaiseExceptions(const ExceptionFlags: TArithmeticExceptions);
begin
end;

function RoundTo(const AValue: Double; const ADigit: TRoundToEXRangeExtended): Double;
begin
end;

function SimpleRoundTo(const AValue: Single; const ADigit: TRoundToRange): Single;
begin
end;

function SimpleRoundTo(const AValue: Double; const ADigit: TRoundToRange): Double;
begin
end;

function Floor(const X: Single): Integer;
begin
end;

function Floor(const X: Double): Integer;
begin
end;

function Ceil(const X: Single): Integer;
begin
end;

function Ceil(const X: Double): Integer;
begin
end;

procedure Frexp(const X: Single; var Mantissa: Single; var Exponent: Integer);
begin
end;

procedure Frexp(const X: Double; var Mantissa: Double; var Exponent: Integer);
begin
end;

function FMod(const ANumerator, ADenominator: Single): Single;
begin
end;

function FMod(const ANumerator, ADenominator: Double): Double;
begin
end;

procedure DivMod(Dividend: Cardinal; Divisor: Word; var Result, Remainder: Word);
begin
end;

procedure DivMod(Dividend: UInt64; Divisor: UInt64; var Result, Remainder: UInt64);
begin
end;

function IntPower(const Base: Single; const Exponent: Integer): Single;
begin
end;

function IntPower(const Base: Double; const Exponent: Integer): Double;
begin
end;

function Power(const Base, Exponent: Double): Double;
begin
end;

function LogN(const Base, X: Double): Double;
begin
end;

function Log2(const X: Double): Double;
begin
end;

function Log10(const X: Double): Double;
begin
end;

function LnXP1(const X: Double): Double;
begin
end;

function Ldexp(const X: Double; const P: Integer): Double;
begin
end;

function ArcCos(const X: Double): Double;
begin
end;

function ArcSin(const X: Double): Double;
begin
end;

function ArcTan2(const Y, X: Double): Double;
begin
end;

function ArcCot(const X: Double): Double;
begin
end;

function ArcCotH(const X: Double): Double;
begin
end;

function ArcCsc(const X: Double): Double;
begin
end;

function ArcCscH(const X: Double): Double;
begin
end;

function ArcSec(const X: Double): Double;
begin
end;

function ArcSecH(const X: Double): Double;
begin
end;

function SinH(const X: Double): Double;
begin
end;

function CosH(const X: Double): Double;
begin
end;

function TanH(const X: Double): Double;
begin
end;

function SecH(const X: Double): Double;
begin
end;

function CscH(const X: Double): Double;
begin
end;

function CotH(const X: Double): Double;
begin
end;

function ArcSinh(const X: Double): Double;
begin
end;

function ArcCosh(const X: Double): Double;
begin
end;

function ArcTanh(const X: Double): Double;
begin
end;

function Tan(const X: Double): Double;
begin
end;

function Cot(const X: Double): Double;
begin
end;

function Cotan(const X: Double): Double;
begin
end;

function Sec(const X: Double): Double;
begin
end;

function Secant(const X: Double): Double;
begin
end;

function Csc(const X: Double): Double;
begin
end;

function Cosecant(const X: Double): Double;
begin
end;

procedure SinCos(const Theta: Double; var Sin, Cos: Double);
begin
end;

function Hypot(const X, Y: Single): Single;
begin
end;

function Hypot(const X, Y: Double): Double;
begin
end;

function Hypot(const X, Y, Z: Single): Single;
begin
end;

function Hypot(const X, Y, Z: Double): Double;
begin
end;

function DegToRad(const Degrees: Double): Double;
begin
end;

function RadToDeg(const Radians: Double): Double;
begin
end;

function GradToRad(const Grads: Double): Double;
begin
end;

function RadToGrad(const Radians: Double): Double;
begin
end;

function DegToGrad(const Degrees: Double): Double;
begin
end;

function GradToDeg(const Grads: Double): Double;
begin
end;

function CycleToRad(const Cycles: Double): Double;
begin
end;

function RadToCycle(const Radians: Double): Double;
begin
end;

function CycleToDeg(const Cycles: Double): Double;
begin
end;

function DegToCycle(const Degrees: Double): Double;
begin
end;

function CycleToGrad(const Cycles: Double): Double;
begin
end;

function GradToCycle(const Grads: Double): Double;
begin
end;

function IfThen(AValue: Boolean; const ATrue: Integer; const AFalse: Integer): Integer;
begin
end;

function IfThen(AValue: Boolean; const ATrue: Int64; const AFalse: Int64): Int64;
begin
end;

function IfThen(AValue: Boolean; const ATrue: Single; const AFalse: Single): Single;
begin
end;

function IfThen(AValue: Boolean; const ATrue: Double; const AFalse: Double): Double;
begin
end;

function RandomRange(const AFrom, ATo: Integer): Integer;
begin
end;

function RandomRange(const AFrom, ATo: Int64): Int64;
begin
end;

function RandomFrom(const AValues: array of ShortInt): ShortInt;
begin
end;

function RandomFrom(const AValues: array of SmallInt): SmallInt;
begin
end;

function RandomFrom(const AValues: array of Integer): Integer;
begin
end;

function RandomFrom(const AValues: array of Int64): Int64;
begin
end;

function RandomFrom(const AValues: array of Byte): Byte;
begin
end;

function RandomFrom(const AValues: array of Word): Word;
begin
end;

function RandomFrom(const AValues: array of Cardinal): Cardinal;
begin
end;

function RandomFrom(const AValues: array of UInt64): UInt64;
begin
end;

function RandomFrom(const AValues: array of Single): Single;
begin
end;

function RandomFrom(const AValues: array of Double): Double;
begin
end;

function RandomFrom(const AValues: array of Boolean): Boolean;
begin
end;

function RandG(Mean, StdDev: Single): Single;
begin
end;

function RandG(Mean, StdDev: Double): Double;
begin
end;

function IsNan(const AValue: Single): Boolean;
begin
end;

function IsNan(const AValue: Double): Boolean;
begin
end;

function IsInfinite(const AValue: Single): Boolean;
begin
end;

function IsInfinite(const AValue: Double): Boolean;
begin
end;

function Sum(const Data: array of Single): Single;
begin
end;

function Sum(const Data: array of Double): Double;
begin
end;

function SumInt(const Data: array of Integer): Int64;
begin
end;

function SumOfSquares(const Data: array of Single): Single;
begin
end;

function SumOfSquares(const Data: array of Double): Double;
begin
end;

procedure SumsAndSquares(const Data: array of Single; var Sum, SumOfSquares: Single);
begin
end;

procedure SumsAndSquares(const Data: array of Double; var Sum, SumOfSquares: Double);
begin
end;

function Mean(const Data: array of Single): Single;
begin
end;

function Mean(const Data: array of Double): Double;
begin
end;

function TotalVariance(const Data: array of Single): Single;
begin
end;

function TotalVariance(const Data: array of Double): Double;
begin
end;

function Variance(const Data: array of Single): Single;
begin
end;

function Variance(const Data: array of Double): Double;
begin
end;

function PopnVariance(const Data: array of Single): Single;
begin
end;

function PopnVariance(const Data: array of Double): Double;
begin
end;

function StdDev(const Data: array of Single): Single;
begin
end;

function StdDev(const Data: array of Double): Double;
begin
end;

function PopnStdDev(const Data: array of Single): Single;
begin
end;

function PopnStdDev(const Data: array of Double): Double;
begin
end;

procedure MeanAndStdDev(const Data: array of Single; var Mean, StdDev: Single);
begin
end;

procedure MeanAndStdDev(const Data: array of Double; var Mean, StdDev: Double);
begin
end;

function MaxValue(const Data: array of Single): Single;
begin
end;

function MaxValue(const Data: array of Double): Double;
begin
end;

function MinValue(const Data: array of Single): Single;
begin
end;

function MinValue(const Data: array of Double): Double;
begin
end;

function MaxIntValue(const Data: array of Integer): Integer;
begin
end;

function MinIntValue(const Data: array of Integer): Integer;
begin
end;

function Norm(const Data: array of Single): Single;
begin
end;

function Norm(const Data: array of Double): Double;
begin
end;

function Poly(const X: Single; const Coefficients: array of Single): Single;
begin
end;

function Poly(const X: Double; const Coefficients: array of Double): Double;
begin
end;

function DoubleDecliningBalance(const Cost, Salvage: Extended; Life, Period: Integer): Extended;
begin
end;

function FutureValue(const Rate: Extended; NPeriods: Integer; const Payment, PresentValue: Extended; PaymentTime: TPaymentTime): Extended;
begin
end;

function PresentValue(const Rate: Extended; NPeriods: Integer; const Payment, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
begin
end;

function InterestPayment(const Rate: Extended; Period, NPeriods: Integer; const PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
begin
end;

function InterestRate(NPeriods: Integer; const Payment, PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime; const Guess: Extended): Extended;
begin
end;

function InternalRateOfReturn(const Guess: Extended; const CashFlows: array of Double): Extended;
begin
end;

function NumberOfPeriods(const Rate, Payment, PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
begin
end;

function Payment(const Rate: Extended; NPeriods: Integer; const PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
begin
end;

function PeriodPayment(const Rate: Extended; Period, NPeriods: Integer; const PresentValue, FutureValue: Extended; PaymentTime: TPaymentTime): Extended;
begin
end;

function SLNDepreciation(const Cost, Salvage: Extended; Life: Integer): Extended;
begin
end;

function SYDDepreciation(const Cost, Salvage: Extended; Life, Period: Integer): Extended;
begin
end;

end.
