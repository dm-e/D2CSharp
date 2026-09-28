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

unit d7_set_length;

interface

function RunSetLengthChecks: Boolean;

implementation

type
  TIntegerRow = array of Integer;
  TIntegerMatrix = array of TIntegerRow;

function RunSetLengthChecks: Boolean;
var
  Text: string;
  Values: array of Integer;
  Matrix: TIntegerMatrix;
  Row: Integer;
  Column: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
begin
  Text := 'converter';
  SetLength(Text, 4);

  SetLength(Values, 5);
  for Column := Low(Values) to High(Values) do
    Values[Column] := Column * Column;
  SetLength(Values, 7);

  SetLength(Matrix, 2);
  for Row := Low(Matrix) to High(Matrix) do
  begin
    SetLength(Matrix[Row], 3);
    for Column := Low(Matrix[Row]) to High(Matrix[Row]) do
      Matrix[Row][Column] := Row * 10 + Column;
  end;

  CheckResult1 := (Text = 'conv');
  Result := CheckResult1;

  CheckResult2 := (Length(Values) = 7);
  Result := Result and CheckResult2;

  CheckResult3 := (Values[4] = 16);
  Result := Result and CheckResult3;

  CheckResult4 := (Values[5] = 0);
  Result := Result and CheckResult4;

  CheckResult5 := (Length(Matrix) = 2);
  Result := Result and CheckResult5;

  CheckResult6 := (Length(Matrix[1]) = 3);
  Result := Result and CheckResult6;

  CheckResult7 := (Matrix[1][2] = 12);
  Result := Result and CheckResult7;
end;

end.
