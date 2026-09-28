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

unit d7_extract_file_path;

interface

function RunExtractFilePathChecks: Boolean;

implementation

uses
  SysUtils;

function RunExtractFilePathChecks: Boolean;
var
  FullName: string;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
begin
  FullName := 'D:\work\input\report.final.txt';
  CheckResult1 := (ExtractFileDrive(FullName) = 'D:');
  Result := CheckResult1;

  CheckResult2 := (ExtractFileDir(FullName) = 'D:\work\input');
  Result := Result and CheckResult2;

  CheckResult3 := (ExtractFilePath(FullName) = 'D:\work\input\');
  Result := Result and CheckResult3;

  CheckResult4 := (ExtractFileName(FullName) = 'report.final.txt');
  Result := Result and CheckResult4;

  CheckResult5 := (ExtractFileExt(FullName) = '.txt');
  Result := Result and CheckResult5;

  CheckResult6 :=
    (ExtractFilePath('relative\report.txt') =
    'relative\');
  Result := Result and CheckResult6;

  CheckResult7 := (ExtractFilePath('plain.txt') = '');
  Result := Result and CheckResult7;
end;

end.
