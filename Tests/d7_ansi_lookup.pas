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

unit d7_ansi_lookup;

interface

function RunAnsiLookupChecks: Boolean;

implementation

uses
  System.StrUtils;

const
  PipelineStages: array[0..3] of string =
    ('plan', 'compile', 'package', 'publish');

function RunAnsiLookupChecks: Boolean;
var
  CurrentStage: AnsiString;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
begin
  CurrentStage := 'package';

  CheckResult1 :=
    AnsiMatchStr(CurrentStage,
    ['plan', 'compile', 'package', 'publish']);
  Result := CheckResult1;

  CheckResult2 :=
    not AnsiMatchStr('PACKAGE',
    ['plan', 'compile', 'package', 'publish']);
  Result := Result and CheckResult2;

  CheckResult3 :=
    (AnsiIndexStr(CurrentStage,
    ['plan', 'compile', 'package', 'publish']) = 2);
  Result := Result and CheckResult3;

  CheckResult4 := (AnsiIndexStr('missing', PipelineStages) = -1);
  Result := Result and CheckResult4;

  CheckResult5 := (AnsiIndexStr(CurrentStage, PipelineStages) = 2);
  Result := Result and CheckResult5;
end;

end.
