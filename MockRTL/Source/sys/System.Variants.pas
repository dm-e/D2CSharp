{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of selected System.Variants functionality.
  This file supplies translation symbols and routine signatures, not
  working Variant semantics. Implementations intentionally return defaults.

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

unit System.Variants;

interface

uses
  System.SysUtils;

{ The current MockRTL/System.pas does not define TVarType or the varXXX
  constants. They are declared here temporarily for converter support.
  In Delphi these base declarations belong to System. Move them there
  when the System mock is extended, and remove the duplicates here. }
type
  TVarType = Word;

  TVariantRelationship = (
    vrEqual,
    vrLessThan,
    vrGreaterThan,
    vrNotEqual
  );

  EVariantTypeCastError = class(EVariantError);
  EVariantInvalidOpError = class(EVariantError);
  EVariantOverflowError = class(EVariantError);
  EVariantRangeCheckError = class(EVariantError);
  EVariantArrayCreateError = class(EVariantError);
  EVariantArrayLockedError = class(EVariantError);
  EVariantBadVarTypeError = class(EVariantError);

const
  varEmpty    = $0000;
  varNull     = $0001;
  varSmallint = $0002;
  varInteger  = $0003;
  varSingle   = $0004;
  varDouble   = $0005;
  varCurrency = $0006;
  varDate     = $0007;
  varOleStr   = $0008;
  varDispatch = $0009;
  varError    = $000A;
  varBoolean  = $000B;
  varVariant  = $000C;
  varUnknown  = $000D;
  varShortInt = $0010;
  varByte     = $0011;
  varWord     = $0012;
  varLongWord = $0013;
  varInt64    = $0014;
  varUInt64   = $0015;
  varStrArg   = $0048;
  varString   = $0100;
  varAny      = $0101;
  varUString  = $0102;
  varTypeMask = $0FFF;
  varArray    = $2000;
  varByRef    = $4000;

{ VarClear, VarCopy, VarCast and VarArrayRedim are already declared
  as intrinsics in the current MockRTL/Source/sys/System.pas and must
  not be duplicated here. }

function VarType(const V: Variant): TVarType;
function VarTypeAsText(const AType: TVarType): string;
function VarIsEmpty(const V: Variant): Boolean;
function VarIsNull(const V: Variant): Boolean;
function VarIsArray(const V: Variant): Boolean;
function VarIsStr(const V: Variant): Boolean;
function VarIsNumeric(const V: Variant): Boolean;
function VarIsOrdinal(const V: Variant): Boolean;
function VarIsFloat(const V: Variant): Boolean;
function VarIsType(const V: Variant; AVarType: TVarType): Boolean; overload;
function VarIsType(const V: Variant; const AVarTypes: array of TVarType): Boolean; overload;
function VarAsType(const V: Variant; AVarType: TVarType): Variant;
function VarToStr(const V: Variant): string;
function VarToStrDef(const V: Variant; const ADefault: string): string;
function VarToWideStr(const V: Variant): WideString;
function VarToWideStrDef(const V: Variant; const ADefault: WideString): WideString;
function VarToDateTime(const V: Variant): TDateTime;
function VarFromDateTime(const AValue: TDateTime): Variant;
function VarCompareValue(const A, B: Variant): TVariantRelationship;
function VarSameValue(const A, B: Variant): Boolean;
function VarInRange(const AValue, AMin, AMax: Variant): Boolean;
function VarEnsureRange(const AValue, AMin, AMax: Variant): Variant;
function VarArrayCreate(const Bounds: array of Integer; AVarType: TVarType): Variant;
function VarArrayOf(const Values: array of Variant): Variant;
function VarArrayDimCount(const A: Variant): Integer;
function VarArrayLowBound(const A: Variant; Dim: Integer): Integer;
function VarArrayHighBound(const A: Variant; Dim: Integer): Integer;
function VarArrayGet(const A: Variant; const Indices: array of Integer): Variant;
procedure VarArrayPut(var A: Variant; const Value: Variant; const Indices: array of Integer);
function VarArrayLock(const A: Variant): Pointer;
procedure VarArrayUnlock(const A: Variant);
function VarTypeIsValidArrayType(const AVarType: TVarType): Boolean;
function VarTypeIsValidElementType(const AVarType: TVarType): Boolean;
procedure VarCopyNoInd(var Dest: Variant; const Source: Variant);
procedure VarCheckEmpty(const V: Variant);

implementation

function VarType(const V: Variant): TVarType;
begin
  Result := 0;
end;

function VarTypeAsText(const AType: TVarType): string;
begin
  Result := '';
end;

function VarIsEmpty(const V: Variant): Boolean;
begin
  Result := False;
end;

function VarIsNull(const V: Variant): Boolean;
begin
  Result := False;
end;

function VarIsArray(const V: Variant): Boolean;
begin
  Result := False;
end;

function VarIsStr(const V: Variant): Boolean;
begin
  Result := False;
end;

function VarIsNumeric(const V: Variant): Boolean;
begin
  Result := False;
end;

function VarIsOrdinal(const V: Variant): Boolean;
begin
  Result := False;
end;

function VarIsFloat(const V: Variant): Boolean;
begin
  Result := False;
end;

function VarIsType(const V: Variant; AVarType: TVarType): Boolean;
begin
  Result := False;
end;

function VarIsType(const V: Variant; const AVarTypes: array of TVarType): Boolean;
begin
  Result := False;
end;

function VarAsType(const V: Variant; AVarType: TVarType): Variant;
begin
end;

function VarToStr(const V: Variant): string;
begin
  Result := '';
end;

function VarToStrDef(const V: Variant; const ADefault: string): string;
begin
  Result := '';
end;

function VarToWideStr(const V: Variant): WideString;
begin
  Result := '';
end;

function VarToWideStrDef(const V: Variant; const ADefault: WideString): WideString;
begin
  Result := '';
end;

function VarToDateTime(const V: Variant): TDateTime;
begin
  Result := 0;
end;

function VarFromDateTime(const AValue: TDateTime): Variant;
begin
end;

function VarCompareValue(const A, B: Variant): TVariantRelationship;
begin
  Result := vrNotEqual;
end;

function VarSameValue(const A, B: Variant): Boolean;
begin
  Result := False;
end;

function VarInRange(const AValue, AMin, AMax: Variant): Boolean;
begin
  Result := False;
end;

function VarEnsureRange(const AValue, AMin, AMax: Variant): Variant;
begin
end;

function VarArrayCreate(const Bounds: array of Integer; AVarType: TVarType): Variant;
begin
end;

function VarArrayOf(const Values: array of Variant): Variant;
begin
end;

function VarArrayDimCount(const A: Variant): Integer;
begin
  Result := 0;
end;

function VarArrayLowBound(const A: Variant; Dim: Integer): Integer;
begin
  Result := 0;
end;

function VarArrayHighBound(const A: Variant; Dim: Integer): Integer;
begin
  Result := 0;
end;

function VarArrayGet(const A: Variant; const Indices: array of Integer): Variant;
begin
end;

procedure VarArrayPut(var A: Variant; const Value: Variant; const Indices: array of Integer);
begin
end;

function VarArrayLock(const A: Variant): Pointer;
begin
  Result := nil;
end;

procedure VarArrayUnlock(const A: Variant);
begin
end;

function VarTypeIsValidArrayType(const AVarType: TVarType): Boolean;
begin
  Result := False;
end;

function VarTypeIsValidElementType(const AVarType: TVarType): Boolean;
begin
  Result := False;
end;

procedure VarCopyNoInd(var Dest: Variant; const Source: Variant);
begin
end;

procedure VarCheckEmpty(const V: Variant);
begin
end;

end.
