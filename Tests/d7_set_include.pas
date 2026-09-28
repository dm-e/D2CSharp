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

unit d7_set_include;

interface

function RunSetIncludeChecks: Boolean;

implementation

type
  TFeature = (ftLogging, ftCache, ftMetrics, ftTracing);
  TFeatures = set of TFeature;

function RunSetIncludeChecks: Boolean;
var
  Features: TFeatures;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
begin
  Features := [];
  Include(Features, ftCache);
  Include(Features, ftMetrics);
  Include(Features, ftCache);

  CheckResult1 := not (ftLogging in Features);
  Result := CheckResult1;

  CheckResult2 := (ftCache in Features);
  Result := Result and CheckResult2;

  CheckResult3 := (ftMetrics in Features);
  Result := Result and CheckResult3;

  CheckResult4 := not (ftTracing in Features);
  Result := Result and CheckResult4;
end;

end.
