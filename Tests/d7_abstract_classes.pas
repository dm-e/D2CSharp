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

unit d7_abstract_classes;

interface

function RunAbstractClassChecks: Boolean;

type
  TImportTask = class abstract
  private
    FSourceName: string;
    FProfile: string;
  protected
    procedure Configure; virtual; abstract;
    property Profile: string read FProfile write FProfile;
  public
    constructor Create(const ASourceName: string);
    property SourceName: string read FSourceName;
    property SelectedProfile: string read FProfile;
  end;

  TDelimitedImportTask = class(TImportTask)
  protected
    procedure Configure; override;
  end;

  TStructuredImportTask = class(TImportTask)
  protected
    procedure Configure; override;
  end;

implementation

constructor TImportTask.Create(const ASourceName: string);
begin
  inherited Create;
  FSourceName := ASourceName;
  Configure;
end;

procedure TDelimitedImportTask.Configure;
begin
  Profile := 'delimited:semicolon';
end;

procedure TStructuredImportTask.Configure;
begin
  Profile := 'structured:object';
end;

function RunAbstractClassChecks: Boolean;
var
  DelimitedTask: TDelimitedImportTask;
  StructuredTask: TStructuredImportTask;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
begin
  DelimitedTask := TDelimitedImportTask.Create('measurements.txt');
  StructuredTask := TStructuredImportTask.Create('settings.data');
  try
    CheckResult1 := (DelimitedTask.SourceName = 'measurements.txt');
    Result := CheckResult1;

    CheckResult2 := (DelimitedTask.SelectedProfile = 'delimited:semicolon');
    Result := Result and CheckResult2;

    CheckResult3 := (StructuredTask.SourceName = 'settings.data');
    Result := Result and CheckResult3;

    CheckResult4 := (StructuredTask.SelectedProfile = 'structured:object');
    Result := Result and CheckResult4;
  finally
    StructuredTask.Free;
    DelimitedTask.Free;
  end;
end;

end.
