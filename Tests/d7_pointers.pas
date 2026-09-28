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

unit d7_pointers;

interface

function RunPointerChecks: Boolean;

implementation

type
  TCoordinate = record
    X: Integer;
    Y: Integer;
  end;
  PCoordinate = ^TCoordinate;
  PIntegerBuffer = ^TIntegerBuffer;
  TIntegerBuffer = array[0..5] of Integer;

function RunPointerChecks: Boolean;
var
  Number: Integer;
  NumberPointer: ^Integer;
  Coordinate: TCoordinate;
  CoordinatePointer: PCoordinate;
  Buffer: PIntegerBuffer;
  Index: Integer;
  Total: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
begin
  Number := 41;
  NumberPointer := @Number;
  Inc(NumberPointer^);

  Coordinate.X := 7;
  Coordinate.Y := 11;
  CoordinatePointer := @Coordinate;
  CoordinatePointer^.Y := 13;

  Buffer := nil;
  GetMem(Buffer, SizeOf(TIntegerBuffer));
  try
    Total := 0;
    for Index := Low(Buffer^) to High(Buffer^) do
    begin
      Buffer^[Index] := (Index + 1) * 4;
      Inc(Total, Buffer^[Index]);
    end;

    CheckResult1 := (Number = 42);
    Result := CheckResult1;

    CheckResult2 := (NumberPointer^ = 42);
    Result := Result and CheckResult2;

    CheckResult3 := (CoordinatePointer^.X = 7);
    Result := Result and CheckResult3;

    CheckResult4 := (Coordinate.Y = 13);
    Result := Result and CheckResult4;

    CheckResult5 := (Buffer^[5] = 24);
    Result := Result and CheckResult5;

    CheckResult6 := (Total = 84);
    Result := Result and CheckResult6;
  finally
    FreeMem(Buffer);
  end;
end;

end.
