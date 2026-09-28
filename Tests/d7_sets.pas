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

unit d7_sets;

interface

function RunSetChecks: Boolean;

implementation

type
  TSignal = (sgRed, sgAmber, sgGreen, sgBlue);
  TSignals = set of TSignal;
  TSmallNumber = 0..31;
  TSmallNumbers = set of TSmallNumber;

function RunSetChecks: Boolean;
var
  Active: TSignals;
  EvenValues: TSmallNumbers;
  Index: TSmallNumber;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
  CheckResult8: Boolean;
begin
  Active := [sgRed, sgGreen];
  Active := Active + [sgBlue];
  Active := Active - [sgRed];

  EvenValues := [];
  for Index := Low(TSmallNumber) to High(TSmallNumber) do
    if (Index mod 2) = 0 then
      Include(EvenValues, Index);

  CheckResult1 := not (sgRed in Active);
  Result := CheckResult1;

  CheckResult2 := not (sgAmber in Active);
  Result := Result and CheckResult2;

  CheckResult3 := (sgGreen in Active);
  Result := Result and CheckResult3;

  CheckResult4 := (sgBlue in Active);
  Result := Result and CheckResult4;

  CheckResult5 := (0 in EvenValues);
  Result := Result and CheckResult5;

  CheckResult6 := (18 in EvenValues);
  Result := Result and CheckResult6;

  CheckResult7 := not (19 in EvenValues);
  Result := Result and CheckResult7;

  CheckResult8 := (30 in EvenValues);
  Result := Result and CheckResult8;
end;

end.
