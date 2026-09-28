{
  D2CSharp test file

  Original source language: Delphi (Pascal).
  The corresponding C# files are automatically translated from the
  Delphi source files by D2CSharp.
  This notice is retained unchanged in both versions.

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

unit d7_bit_operations;

interface

function RunBitOperationChecks: Boolean;

implementation

type
  TLongWordParts = packed record
    case Integer of
      0: (Value: LongWord);
      1: (LowPart, HighPart: Word);
  end;

function CheckHighAndLowBytes: Boolean;
var
  Code: Word;
begin
  Code := $ABCD;
  Result := (Hi(Code) = $AB) and (Lo(Code) = $CD);
end;

function CheckRecordAndMasks: Boolean;
var
  Parts: TLongWordParts;
  UpperWord: Word;
  GroupCode: Integer;
  FlagCode: Integer;
begin
  Parts.Value := $4A21C3D4;
  UpperWord := Parts.HighPart;
  GroupCode := (UpperWord shr 8) and $FF;
  FlagCode := UpperWord and $FF;

  Result :=
    (Parts.LowPart = $C3D4) and
    (UpperWord = $4A21) and
    (GroupCode = $4A) and
    (FlagCode = $21);
end;

function CheckWordShifts: Boolean;
var
  Value: Word;
begin
  Value := $002D;
  Value := Value shl 8;
  Result := Value = $2D00;

  Value := Value shr 4;
  Result := Result and (Value = $02D0);
end;

function RunBitOperationChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
begin
  CheckResult1 := CheckHighAndLowBytes;
  Result := CheckResult1;

  CheckResult2 := CheckRecordAndMasks;
  Result := Result and CheckResult2;

  CheckResult3 := CheckWordShifts;
  Result := Result and CheckResult3;
end;

end.
