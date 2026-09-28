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

unit d7_text_append;

interface

function RunAppendChecks: Boolean;

implementation

uses
  System.SysUtils;

function CheckTextFileAppend: Boolean;
var
  DataFile: TextFile;
  FileName: string;
  FirstLine: string;
  SecondLine: string;
begin
  FileName := IncludeTrailingPathDelimiter(GetCurrentDir) +
    'd7_append_probe.txt';

  try
    AssignFile(DataFile, FileName);
    Rewrite(DataFile);
    try
      WriteLn(DataFile, 'sequence=41');
    finally
      CloseFile(DataFile);
    end;

    AssignFile(DataFile, FileName);
    Append(DataFile);
    try
      WriteLn(DataFile, 'state=complete');
    finally
      CloseFile(DataFile);
    end;

    AssignFile(DataFile, FileName);
    Reset(DataFile);
    try
      ReadLn(DataFile, FirstLine);
      ReadLn(DataFile, SecondLine);
      Result :=
        (FirstLine = 'sequence=41') and
        (SecondLine = 'state=complete') and
        Eof(DataFile);
    finally
      CloseFile(DataFile);
    end;
  finally
    if FileExists(FileName) then
      DeleteFile(FileName);
  end;
end;

function CheckStringBuilderAppend: Boolean;
var
  Builder: TStringBuilder;
begin
  Builder := TStringBuilder.Create;
  try
    Builder.AppendLine('phase');
    Builder.Append('#').Append(3);
    Result := Builder.ToString = 'phase' + sLineBreak + '#3';
  finally
    Builder.Free;
  end;
end;

function RunAppendChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
begin
  CheckResult1 := CheckTextFileAppend;
  Result := CheckResult1;

  CheckResult2 := CheckStringBuilderAppend;
  Result := Result and CheckResult2;
end;

end.
