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

unit d7_str_procedure;

interface

function RunStrProcedureChecks: Boolean;

implementation

uses
  SysUtils;

function RunStrProcedureChecks: Boolean;
var
  Text: string;
  IntegerValue: Integer;
  RealValue: Double;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
begin
  IntegerValue := -731;
  Str(IntegerValue, Text);
  CheckResult1 := Text = '-731';
  Result := CheckResult1;

  Str(IntegerValue:8, Text);
  CheckResult2 := (Text = '    -731');
  Result := Result and CheckResult2;

  RealValue := 48.375;
  Str(RealValue:0:3, Text);
  CheckResult3 := (Text = '48.375');
  Result := Result and CheckResult3;

  Str(RealValue:10:1, Text);
  CheckResult4 := (Text = '      48.4');
  Result := Result and CheckResult4;

  Str(RealValue, Text);
  CheckResult5 := (Pos('4.8375', Text) > 0);
  Result := Result and CheckResult5;

  CheckResult6 := (Pos('E+', Text) > 0);
  Result := Result and CheckResult6;
end;

end.
