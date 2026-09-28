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

unit d7_file_rename;

interface

function RunFileRenameChecks: Boolean;

implementation

uses
  SysUtils;

function RunFileRenameChecks: Boolean;
var
  DataFile: TextFile;
  OriginalName: string;
  RenamedName: string;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
begin
  OriginalName := 'd7_rename_source.tmp';
  RenamedName := 'd7_rename_target.tmp';

  if FileExists(OriginalName) then
    DeleteFile(OriginalName);
  if FileExists(RenamedName) then
    DeleteFile(RenamedName);

  AssignFile(DataFile, OriginalName);
  Rewrite(DataFile);
  try
    WriteLn(DataFile, 'rename');
  finally
    CloseFile(DataFile);
  end;

  try
    AssignFile(DataFile, OriginalName);
    Rename(DataFile, RenamedName);
    CheckResult1 := not FileExists(OriginalName);
    Result := CheckResult1;

    CheckResult2 := FileExists(RenamedName);
    Result := Result and CheckResult2;
  finally
    if FileExists(OriginalName) then
      DeleteFile(OriginalName);
    if FileExists(RenamedName) then
      DeleteFile(RenamedName);
  end;
end;

end.
