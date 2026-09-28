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

unit d7_arrays;

interface

function RunArrayChecks: Boolean;

implementation

uses
  System.SysUtils;

type
  TLetterBuffer = array of Char;
  TMarkerSet = set of Char;

function AcceptMixedValues(const AValues: array of const): Boolean;
begin
  Result := High(AValues) = 2;
end;

function AcceptMarkers(const AMarkers: TMarkerSet): Boolean;
begin
  Result := ('!' in AMarkers) and ('?' in AMarkers) and
    not ('#' in AMarkers);
end;

function CheckArrayLiterals: Boolean;
begin
  Result :=
    AcceptMixedValues(['Q', 17, True]) and
    AcceptMarkers(['!', '?']);
end;

function CheckStaticArrays: Boolean;
var
  OpcodeTable: array[Word] of Byte;
  Samples: array[2..6] of Integer;
  Grid: array[0..1, 3..5] of Char;
  Index: Integer;
  OpcodeLengthOk: Boolean;
  OpcodeLowOk: Boolean;
  OpcodeHighOk: Boolean;
  OpcodeValueOk: Boolean;
  SamplesLengthOk: Boolean;
  SamplesLowOk: Boolean;
  SamplesHighOk: Boolean;
  Sample3Ok: Boolean;
  Sample6Ok: Boolean;
  GridLengthOk: Boolean;
  GridFirstValueOk: Boolean;
  GridLastValueOk: Boolean;
begin
  OpcodeTable[$1234] := $5A;

  for Index := Low(Samples) to High(Samples) do
    Samples[Index] := Index * Index;

  Grid[0, 3] := 'A';
  Grid[1, 5] := 'Z';

  OpcodeLengthOk := Length(OpcodeTable) = 65536;
  OpcodeLowOk := Low(OpcodeTable) = 0;
  OpcodeHighOk := High(OpcodeTable) = 65535;
  OpcodeValueOk := OpcodeTable[$1234] = $5A;

  SamplesLengthOk := Length(Samples) = 5;
  SamplesLowOk := Low(Samples) = 2;
  SamplesHighOk := High(Samples) = 6;
  Sample3Ok := Samples[3] = 9;
  Sample6Ok := Samples[6] = 36;

  GridLengthOk := Length(Grid) = 2;
  GridFirstValueOk := Grid[0, 3] = 'A';
  GridLastValueOk := Grid[1, 5] = 'Z';

  Result :=
    OpcodeLengthOk and
    OpcodeLowOk and
    OpcodeHighOk and
    OpcodeValueOk and
    SamplesLengthOk and
    SamplesLowOk and
    SamplesHighOk and
    Sample3Ok and
    Sample6Ok and
    GridLengthOk and
    GridFirstValueOk and
    GridLastValueOk;
end;

function CheckDynamicArrays: Boolean;
var
  Values: array of Integer;
  Matrix: array of array of string;
  Row: Integer;
  Column: Integer;
  Joined: string;
begin
  SetLength(Values, 4);
  for Row := 0 to High(Values) do
    Values[Row] := (Row + 1) * 10;

  SetLength(Matrix, 2);
  SetLength(Matrix[0], 2);
  SetLength(Matrix[1], 3);

  Joined := '';
  for Row := 0 to High(Matrix) do
    for Column := 0 to High(Matrix[Row]) do
    begin
      Matrix[Row, Column] := IntToStr(Row * 3 + Column);
      Joined := Joined + Matrix[Row, Column];
    end;

  Result :=
    (Length(Values) = 4) and
    (Values[0] = 10) and
    (Values[3] = 40) and
    (Length(Matrix[0]) = 2) and
    (Length(Matrix[1]) = 3) and
    (Joined = '01345');
end;

procedure FillLetterBuffer(var ABuffer: TLetterBuffer);
var
  Index: Integer;
begin
  SetLength(ABuffer, 4);
  for Index := 0 to High(ABuffer) do
    ABuffer[Index] := Chr(Ord('K') + Index);
end;

function JoinCharacters(const ACharacters: array of Char): string;
var
  Index: Integer;
begin
  Result := '';
  for Index := 0 to High(ACharacters) do
    Result := Result + ACharacters[Index];
end;

function JoinConstCharacters(const ACharacters: array of const): string;
var
  Index: Integer;
begin
  Result := '';
  for Index := 0 to High(ACharacters) do
    Result := Result + ACharacters[Index].VChar;
end;

function CheckOpenArrays: Boolean;
var
  Buffer: TLetterBuffer;
  FixedText: array[0..3] of Char;
begin
  FillLetterBuffer(Buffer);

  FixedText[0] := 'T';
  FixedText[1] := 'E';
  FixedText[2] := 'S';
  FixedText[3] := 'T';

  Result :=
    (JoinCharacters(Buffer) = 'KLMN') and
    (JoinCharacters(FixedText) = 'TEST') and
    (JoinCharacters([]) = '') and
    (JoinConstCharacters(['O', 'K']) = 'OK');
end;

function CheckSliceValues(const AValues: array of Integer): Boolean;
begin
  Result :=
    (Length(AValues) = 4) and
    (AValues[0] = 10) and
    (AValues[1] = 20) and
    (AValues[2] = 30) and
    (AValues[3] = 40);
end;

function CheckArraySlice: Boolean;
var
  Source: array[0..5] of Integer;
  Index: Integer;
begin
  for Index := Low(Source) to High(Source) do
    Source[Index] := (Index + 1) * 10;

  Result := CheckSliceValues(Slice(Source, 4));
end;

function RunArrayChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
begin
  CheckResult1 := CheckArrayLiterals;
  Result := CheckResult1;

  CheckResult2 := CheckStaticArrays;
  Result := Result and CheckResult2;

  CheckResult3 := CheckDynamicArrays;
  Result := Result and CheckResult3;

  CheckResult4 := CheckOpenArrays;
  Result := Result and CheckResult4;

  CheckResult5 := CheckArraySlice;
  Result := Result and CheckResult5;
end;

end.
