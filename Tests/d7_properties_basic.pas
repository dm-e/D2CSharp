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

unit d7_properties_basic;

interface

function RunBasicPropertyChecks: Boolean;

implementation

type
  TLevel = class
  private
    FValue: Integer;
    function GetValue: Integer;
    procedure SetValue(const AValue: Integer);
  public
    property Value: Integer read GetValue write SetValue;
  end;

function TLevel.GetValue: Integer;
begin
  Result := FValue;
end;

procedure TLevel.SetValue(const AValue: Integer);
begin
  if AValue < 0 then
    FValue := 0
  else if AValue > 100 then
    FValue := 100
  else
    FValue := AValue;
end;

function RunBasicPropertyChecks: Boolean;
var
  Level: TLevel;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
begin
  Level := TLevel.Create;
  try
    Level.Value := 72;
    CheckResult1 := Level.Value = 72;
    Result := CheckResult1;

    Level.Value := 140;
    CheckResult2 := (Level.Value = 100);
    Result := Result and CheckResult2;

    Level.Value := -8;
    CheckResult3 := (Level.Value = 0);
    Result := Result and CheckResult3;
  finally
    Level.Free;
  end;
end;

end.
