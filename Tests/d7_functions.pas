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

unit d7_functions;

interface

function RunFunctionChecks: Boolean;

implementation

function ScaleAndOffset(const AValue, AScale,
  AOffset: Integer): Integer;
begin
  Result := AValue * AScale + AOffset;
end;

function TryDouble(const AValue: Integer;
  out ADoubled: Integer): Boolean;
begin
  Result := AValue >= 0;
  if Result then
    ADoubled := AValue * 2
  else
    ADoubled := 0;
end;

function RunFunctionChecks: Boolean;
var
  Doubled: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
begin
  CheckResult1 := (ScaleAndOffset(7, 4, 3) = 31);
  Result := CheckResult1;

  CheckResult2 := TryDouble(14, Doubled);
  Result := Result and CheckResult2;

  CheckResult3 := (Doubled = 28);
  Result := Result and CheckResult3;

  CheckResult4 := not TryDouble(-1, Doubled);
  Result := Result and CheckResult4;

  CheckResult5 := (Doubled = 0);
  Result := Result and CheckResult5;
end;

end.
