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

unit d7_file_age;

interface

function RunFileAgeChecks: Boolean;

implementation

uses
  System.SysUtils,
  System.DateUtils;

function ReadExecutableAge(out ADate: TDateTime): Boolean;
{$IF CompilerVersion < 20.0}
var
  DosStamp: Integer;
{$IFEND}
begin
  {$IF CompilerVersion >= 20.0}
  Result := FileAge(ParamStr(0), ADate);
  {$ELSE}
  DosStamp := FileAge(ParamStr(0));
  Result := DosStamp <> -1;
  if Result then
    ADate := FileDateToDateTime(DosStamp);
  {$IFEND}
end;

function RunFileAgeChecks: Boolean;
var
  OriginalDate: TDateTime;
  LaterDate: TDateTime;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
begin
  CheckResult1 := ReadExecutableAge(OriginalDate);
  Result := CheckResult1;
  if not Result then
    Exit;

  LaterDate := IncDay(OriginalDate, 31);
  CheckResult2 := (LaterDate > OriginalDate);
  Result := CheckResult2;

  CheckResult3 := (DaysBetween(LaterDate, OriginalDate) = 31);
  Result := Result and CheckResult3;
end;

end.
