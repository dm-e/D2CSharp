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

unit d7_records;

interface

function RunRecordChecks: Boolean;

implementation

type
  TBuildResult = record
    ExitCode: Integer;
    WarningCount: Integer;
    TargetName: string[24];
  end;

function CreateBuildResult(const ATarget: string;
  const AExitCode, AWarningCount: Integer): TBuildResult;
begin
  Result.TargetName := ATarget;
  Result.ExitCode := AExitCode;
  Result.WarningCount := AWarningCount;
end;

function IsSuccessful(const AResult: TBuildResult): Boolean;
begin
  Result :=
    (AResult.ExitCode = 0) and
    (AResult.WarningCount < 5);
end;

function RunRecordChecks: Boolean;
var
  BuildResult: TBuildResult;
  CopyOfResult: TBuildResult;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
begin
  BuildResult := CreateBuildResult('win32-debug', 0, 2);
  CopyOfResult := BuildResult;
  CopyOfResult.WarningCount := 3;

  CheckResult1 := IsSuccessful(BuildResult);
  Result := CheckResult1;

  CheckResult2 := IsSuccessful(CopyOfResult);
  Result := Result and CheckResult2;

  CheckResult3 := (BuildResult.WarningCount = 2);
  Result := Result and CheckResult3;

  CheckResult4 := (CopyOfResult.WarningCount = 3);
  Result := Result and CheckResult4;

  CheckResult5 := (CopyOfResult.TargetName = 'win32-debug');
  Result := Result and CheckResult5;
end;

end.
