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

unit d7_string_boundaries;

interface

function RunStringBoundaryChecks: Boolean;

implementation

uses
  System.SysUtils,
  System.StrUtils;

function RunStringBoundaryChecks: Boolean;
var
  MessageText: string;
  AnsiMessage: AnsiString;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
  CheckResult8: Boolean;
  CheckResult9: Boolean;
  CheckResult10: Boolean;
  CheckResult11: Boolean;
begin
  MessageText := 'Build READY: package stored';
  AnsiMessage := 'Build READY: package stored';

  CheckResult1 := AnsiContainsStr(MessageText, 'READY');
  Result := CheckResult1;

  CheckResult2 := not AnsiContainsStr(MessageText, 'ready');
  Result := Result and CheckResult2;

  CheckResult3 := AnsiContainsText(MessageText, 'ready');
  Result := Result and CheckResult3;

  CheckResult4 := AnsiStartsText('build ready', MessageText);
  Result := Result and CheckResult4;

  CheckResult5 := AnsiEndsText('PACKAGE STORED', MessageText);
  Result := Result and CheckResult5;

  CheckResult6 := MessageText.Contains('package');
  Result := Result and CheckResult6;

  CheckResult7 := not MessageText.Contains('Package');
  Result := Result and CheckResult7;

  CheckResult8 := MessageText.StartsWith('Build');
  Result := Result and CheckResult8;

  CheckResult9 := MessageText.EndsWith('stored');
  Result := Result and CheckResult9;

  CheckResult10 := string.EndsText('STORED', MessageText);
  Result := Result and CheckResult10;

  CheckResult11 := AnsiContainsText(AnsiMessage, 'build ready');
  Result := Result and CheckResult11;
end;

end.
