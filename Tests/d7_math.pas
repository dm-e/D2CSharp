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

unit d7_math;

interface

function RunMathChecks: Boolean;

implementation

uses
  Math;

const
  Tolerance = 1E-10;

type
  TCompassPoint = (cpNorth, cpEast, cpSouth, cpWest);

function CheckOrdinalOperations: Boolean;
var
  Number: Integer;
  Letter: Char;
  Direction: TCompassPoint;
begin
  Number := 40;
  Inc(Number, 3);
  Dec(Number);

  Letter := 'K';
  Inc(Letter);

  Direction := cpEast;
  Result :=
    (Number = 42) and
    (Letter = 'L') and
    (Pred(Direction) = cpNorth) and
    (Succ(Direction) = cpSouth);
end;

function CheckArrayMath: Boolean;
var
  Values: array[0..3] of Double;
begin
  Values[0] := 1.25;
  Values[1] := 2.5;
  Values[2] := -0.75;
  Values[3] := 7.0;
  Result := Abs(Sum(Values) - 10.0) < Tolerance;
end;

function RunMathChecks: Boolean;
var
  RootValue: Extended;
  PowerValue: Extended;
  SineValue: Extended;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
  CheckResult8: Boolean;
begin
  RootValue := Sqrt(144.0);
  PowerValue := Power(3.0, 4.0);
  SineValue := Sin(Pi / 2);

  CheckResult1 := (Abs(RootValue - 12.0) < Tolerance);
  Result := CheckResult1;

  CheckResult2 := (Abs(PowerValue - 81.0) < Tolerance);
  Result := Result and CheckResult2;

  CheckResult3 := (Abs(SineValue - 1.0) < Tolerance);
  Result := Result and CheckResult3;

  CheckResult4 := (Sqr(9) = 81);
  Result := Result and CheckResult4;

  CheckResult5 := IsInfinite(Infinity);
  Result := Result and CheckResult5;

  CheckResult6 := IsNan(NaN);
  Result := Result and CheckResult6;

  CheckResult7 := CheckOrdinalOperations;
  Result := Result and CheckResult7;

  CheckResult8 := CheckArrayMath;
  Result := Result and CheckResult8;
end;

end.
