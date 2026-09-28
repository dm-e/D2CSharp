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

unit d7_string_list;

interface

function RunStringListChecks: Boolean;

implementation

uses
  System.Classes,
  System.SysUtils;

function CheckStageList: Boolean;
var
  Stages: TStringList;
begin
  Stages := TStringList.Create;
  try
    Stages.Add('scan');
    Stages.Add('emit');
    Stages.Insert(1, 'validate');
    Stages.Exchange(0, 2);

    Result :=
      (Stages.Count = 3) and
      (Stages[0] = 'emit') and
      (Stages[1] = 'validate') and
      (Stages[2] = 'scan') and
      (Stages.IndexOf('validate') = 1) and
      (Stages.IndexOf('missing') = -1);
  finally
    Stages.Free;
  end;
end;

function CheckOptionValues: Boolean;
var
  Options: TStringList;
begin
  Options := TStringList.Create;
  try
    Options.Values['mode'] := 'safe';
    Options.Values['workers'] := '6';
    Options.Values['trace'] := 'off';

    Result :=
      (Options.Names[0] = 'mode') and
      (Options.Values['mode'] = 'safe') and
      (Options.Values['workers'] = '6') and
      (Options.Values['trace'] = 'off');
  finally
    Options.Free;
  end;
end;

function CheckDelimitedFields: Boolean;
var
  Fields: TStringList;
begin
  Fields := TStringList.Create;
  try
    Fields.Delimiter := ';';
    Fields.QuoteChar := '"';
    Fields.StrictDelimiter := True;
    Fields.DelimitedText := 'alpha;"two words";omega';

    Result :=
      (Fields.Count = 3) and
      (Fields[0] = 'alpha') and
      (Fields[1] = 'two words') and
      (Fields[2] = 'omega');
  finally
    Fields.Free;
  end;
end;

function CheckFileRoundTrip: Boolean;
var
  SourceLines: TStringList;
  LoadedLines: TStringList;
  FileName: string;
begin
  FileName := 'd7_string_list.tmp';
  SourceLines := TStringList.Create;
  LoadedLines := TStringList.Create;
  try
    SourceLines.Add('first=alpha');
    SourceLines.Add('second=beta');
    SourceLines.SaveToFile(FileName);
    LoadedLines.LoadFromFile(FileName);

    Result :=
      (LoadedLines.Count = 2) and
      (LoadedLines.Values['first'] = 'alpha') and
      (LoadedLines.Values['second'] = 'beta');
  finally
    LoadedLines.Free;
    SourceLines.Free;
    if FileExists(FileName) then
      DeleteFile(FileName);
  end;
end;

function RunStringListChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
begin
  CheckResult1 := CheckStageList;
  Result := CheckResult1;

  CheckResult2 := CheckOptionValues;
  Result := Result and CheckResult2;

  CheckResult3 := CheckDelimitedFields;
  Result := Result and CheckResult3;

  CheckResult4 := CheckFileRoundTrip;
  Result := Result and CheckResult4;
end;

end.
