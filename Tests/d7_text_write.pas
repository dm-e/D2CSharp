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

unit d7_text_write;

interface

function RunTextWriteChecks: Boolean;

implementation

uses
  SysUtils;

type
  TProbeEntry = record
    Code: Integer;
    Enabled: Boolean;
  end;

function CheckTextOutput: Boolean;
var
  OutputFile: TextFile;
  FileName: string;
  FirstLine: string;
  SecondLine: string;
begin
  FileName := 'd7_write_text.tmp';
  AssignFile(OutputFile, FileName);
  Rewrite(OutputFile);
  try
    Write(OutputFile, 'value=');
    WriteLn(OutputFile, 42);
    WriteLn(OutputFile, 7.25:6:2);
  finally
    CloseFile(OutputFile);
  end;

  try
    AssignFile(OutputFile, FileName);
    Reset(OutputFile);
    try
      ReadLn(OutputFile, FirstLine);
      ReadLn(OutputFile, SecondLine);
    finally
      CloseFile(OutputFile);
    end;
    Result :=
      (FirstLine = 'value=42') and
      (SecondLine = '  7.25');
  finally
    if FileExists(FileName) then
      DeleteFile(FileName);
  end;
end;

function CheckTypedOutput: Boolean;
var
  OutputFile: file of TProbeEntry;
  FileName: string;
  Entry: TProbeEntry;
  SavedFileMode: Byte;
begin
  FileName := 'd7_write_record.tmp';
  AssignFile(OutputFile, FileName);
  Rewrite(OutputFile);
  try
    Entry.Code := 17;
    Entry.Enabled := False;
    Write(OutputFile, Entry);
    Entry.Code := 29;
    Entry.Enabled := True;
    Write(OutputFile, Entry);
  finally
    CloseFile(OutputFile);
  end;

  SavedFileMode := FileMode;
  try
    FileMode := fmOpenRead;
    Reset(OutputFile);
    try
      Read(OutputFile, Entry);
      Read(OutputFile, Entry);
      Result := Eof(OutputFile) and
        (Entry.Code = 29) and Entry.Enabled;
    finally
      CloseFile(OutputFile);
    end;
  finally
    FileMode := SavedFileMode;
    if FileExists(FileName) then
      DeleteFile(FileName);
  end;
end;

function RunTextWriteChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
begin
  CheckResult1 := CheckTextOutput;
  Result := CheckResult1;

  CheckResult2 := CheckTypedOutput;
  Result := Result and CheckResult2;
end;

end.
