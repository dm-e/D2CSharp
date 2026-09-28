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

unit d7_text_read;

interface

function RunTextReadChecks: Boolean;

implementation

uses
  SysUtils;

type
  TReadEntry = record
    Code: Integer;
    Active: Boolean;
  end;

function CheckTypedRead: Boolean;
var
  DataFile: file of TReadEntry;
  FileName: string;
  Entry: TReadEntry;
  SavedFileMode: Byte;
begin
  FileName := 'd7_read_record.tmp';
  AssignFile(DataFile, FileName);
  Rewrite(DataFile);
  try
    Entry.Code := 51;
    Entry.Active := True;
    Write(DataFile, Entry);
  finally
    CloseFile(DataFile);
  end;

  SavedFileMode := FileMode;
  try
    FileMode := fmOpenRead;
    Reset(DataFile);
    try
      Read(DataFile, Entry);
      Result := Eof(DataFile) and
        (Entry.Code = 51) and Entry.Active;
    finally
      CloseFile(DataFile);
    end;
  finally
    FileMode := SavedFileMode;
    if FileExists(FileName) then
      DeleteFile(FileName);
  end;
end;

function RunTextReadChecks: Boolean;
var
  DataFile: TextFile;
  FileName: string;
  FirstValue: Integer;
  SecondValue: Integer;
  StateText: string;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
begin
  FileName := 'd7_read_probe.tmp';
  AssignFile(DataFile, FileName);
  Rewrite(DataFile);
  try
    WriteLn(DataFile, '12 30');
    WriteLn(DataFile, 'ready');
  finally
    CloseFile(DataFile);
  end;

  try
    AssignFile(DataFile, FileName);
    Reset(DataFile);
    try
      Read(DataFile, FirstValue);
      Read(DataFile, SecondValue);
      ReadLn(DataFile);
      ReadLn(DataFile, StateText);
      CheckResult1 := (FirstValue = 12);
      Result := CheckResult1;

      CheckResult2 := (SecondValue = 30);
      Result := Result and CheckResult2;

      CheckResult3 := (StateText = 'ready');
      Result := Result and CheckResult3;

      CheckResult4 := Eof(DataFile);
      Result := Result and CheckResult4;

      CheckResult5 := CheckTypedRead;
      Result := Result and CheckResult5;
    finally
      CloseFile(DataFile);
    end;
  finally
    if FileExists(FileName) then
      DeleteFile(FileName);
  end;
end;

end.
