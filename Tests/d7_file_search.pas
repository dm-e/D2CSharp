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

unit d7_file_search;

interface

function RunFileSearchChecks: Boolean;

implementation

uses
  SysUtils;

function RunFileSearchChecks: Boolean;
var
  ProbeFile: TextFile;
  FirstName: string;
  SecondName: string;
  LocatedName: string;
  SearchRecord: TSearchRec;
  MatchCount: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
begin
  FirstName := 'd7_find_alpha.tmp';
  SecondName := 'd7_find_beta.tmp';

  AssignFile(ProbeFile, FirstName);
  Rewrite(ProbeFile);
  try
    WriteLn(ProbeFile, 'alpha');
  finally
    CloseFile(ProbeFile);
  end;

  AssignFile(ProbeFile, SecondName);
  Rewrite(ProbeFile);
  try
    WriteLn(ProbeFile, 'beta');
  finally
    CloseFile(ProbeFile);
  end;

  try
    LocatedName := FileSearch(FirstName, GetCurrentDir);
    CheckResult1 := (LocatedName <> '');
    Result := CheckResult1;

    CheckResult2 := FileExists(LocatedName);
    Result := Result and CheckResult2;

    CheckResult3 := (ExtractFileName(LocatedName) = FirstName);
    Result := Result and CheckResult3;

    CheckResult4 := (FileSearch('missing_d7_probe.tmp', GetCurrentDir) = '');
    Result := Result and CheckResult4;

    MatchCount := 0;
    if FindFirst('d7_find_*.tmp', faAnyFile, SearchRecord) = 0 then
    begin
      try
        repeat
          if (SearchRecord.Name = FirstName) or
             (SearchRecord.Name = SecondName) then
            Inc(MatchCount);
        until FindNext(SearchRecord) <> 0;
      finally
        FindClose(SearchRecord);
      end;
    end;
    CheckResult5 := (MatchCount = 2);
    Result := Result and CheckResult5;
  finally
    if FileExists(FirstName) then
      DeleteFile(FirstName);
    if FileExists(SecondName) then
      DeleteFile(SecondName);
  end;
end;

end.
