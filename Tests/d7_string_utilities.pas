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

unit d7_string_utilities;

interface

function RunStringUtilityChecks: Boolean;

implementation

uses
  System.StrUtils;

function RunStringUtilityChecks: Boolean;
var
  Source: AnsiString;
  Updated: AnsiString;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
  CheckResult8: Boolean;
  CheckResult9: Boolean;
begin
  Source := 'alpha|beta|gamma';
  Updated := AnsiReplaceStr(Source, 'beta', 'delta');

  CheckResult1 := (LeftStr(Source, 5) = 'alpha');
  Result := CheckResult1;

  CheckResult2 := (AnsiMidStr(Source, 7, 4) = 'beta');
  Result := Result and CheckResult2;

  CheckResult3 := (AnsiRightStr(Source, 5) = 'gamma');
  Result := Result and CheckResult3;

  CheckResult4 := AnsiStartsStr('alpha|', Source);
  Result := Result and CheckResult4;

  CheckResult5 := not AnsiStartsStr('ALPHA|', Source);
  Result := Result and CheckResult5;

  CheckResult6 := (Updated = 'alpha|delta|gamma');
  Result := Result and CheckResult6;

  CheckResult7 := (AnsiReverseString('stressed') = 'desserts');
  Result := Result and CheckResult7;

  CheckResult8 :=
    (AnsiIndexStr('package',
    ['prepare', 'compile', 'package', 'deploy']) = 2);
  Result := Result and CheckResult8;

  CheckResult9 :=
    (AnsiIndexStr('PACKAGE',
    ['prepare', 'compile', 'package', 'deploy']) = -1);
  Result := Result and CheckResult9;
end;

end.
