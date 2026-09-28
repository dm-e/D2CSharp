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

unit d7_with_statement;

interface

function RunWithStatementChecks: Boolean;

implementation

type
  TWindowState = record
    Left: Integer;
    Top: Integer;
    Width: Integer;
    Height: Integer;
  end;

  TWindowSettings = class
  private
    FState: TWindowState;
  public
    procedure Configure;
    property State: TWindowState read FState;
  end;

procedure TWindowSettings.Configure;
begin
  with FState do
  begin
    Left := 12;
    Top := 18;
    Width := 640;
    Height := 480;
  end;
end;

function RunWithStatementChecks: Boolean;
var
  Settings: TWindowSettings;
  Snapshot: TWindowState;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
begin
  Settings := TWindowSettings.Create;
  try
    Settings.Configure;
    Snapshot := Settings.State;
    with Snapshot do
    begin
      CheckResult1 := Left = 12;
      CheckResult2 := Top = 18;
      CheckResult3 := Width = 640;
      CheckResult4 := Height = 480;
    end;

    Result := CheckResult1;
    Result := Result and CheckResult2;
    Result := Result and CheckResult3;
    Result := Result and CheckResult4;
  finally
    Settings.Free;
  end;
end;

end.
