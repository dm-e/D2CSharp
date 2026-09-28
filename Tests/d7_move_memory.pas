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

unit d7_move_memory;

interface

function RunMoveChecks: Boolean;

implementation

function RunMoveChecks: Boolean;
var
  Source: array[0..7] of Byte;
  Target: array[0..7] of Byte;
  SourceText: AnsiString;
  TargetText: AnsiString;
  Index: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
begin
  for Index := Low(Source) to High(Source) do
    Source[Index] := (Index + 1) * 10;

  FillChar(Target, SizeOf(Target), 0);
  Move(Source[2], Target[1], 4);

  SourceText := 'abcdefgh';
  TargetText := '--------';
  Move(SourceText[3], TargetText[2], 4);

  CheckResult1 := (Target[0] = 0);
  Result := CheckResult1;

  CheckResult2 := (Target[1] = 30);
  Result := Result and CheckResult2;

  CheckResult3 := (Target[2] = 40);
  Result := Result and CheckResult3;

  CheckResult4 := (Target[3] = 50);
  Result := Result and CheckResult4;

  CheckResult5 := (Target[4] = 60);
  Result := Result and CheckResult5;

  CheckResult6 := (Target[5] = 0);
  Result := Result and CheckResult6;

  CheckResult7 := (TargetText = '-cdef---');
  Result := Result and CheckResult7;
end;

end.
