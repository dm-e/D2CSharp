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

unit d7_procedures;

interface

function RunProcedureChecks: Boolean;

implementation

procedure ExchangeIntegers(var ALeft, ARight: Integer);
var
  Temporary: Integer;
begin
  Temporary := ALeft;
  ALeft := ARight;
  ARight := Temporary;
end;

procedure AddAmount(var ATarget: Integer; const AAmount: Integer);
begin
  Inc(ATarget, AAmount);
end;

function RunProcedureChecks: Boolean;
var
  LeftValue: Integer;
  RightValue: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
begin
  LeftValue := 12;
  RightValue := 35;
  ExchangeIntegers(LeftValue, RightValue);
  AddAmount(LeftValue, 7);

  CheckResult1 := (LeftValue = 42);
  Result := CheckResult1;

  CheckResult2 := (RightValue = 12);
  Result := Result and CheckResult2;
end;

end.
