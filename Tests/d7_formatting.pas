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

unit d7_formatting;

interface

function RunFormattingChecks: Boolean;

implementation

uses
  System.SysUtils;

function CheckBuildMessage: Boolean;
var
  MessageText: string;
begin
  MessageText := Format('Build %s produced %d artifacts',
    ['linux-x64', 18]);

  Result := MessageText =
    'Build linux-x64 produced 18 artifacts';
end;

function CheckIdentifierLayout: Boolean;
begin
  Result := True;

  if Format('ID-%6.4d', [73]) <> 'ID-  0073' then
    Result := False;

  if Format('HEX-%4.4x', [$2A]) <> 'HEX-002A' then
    Result := False;

  if Format('%1:s/%0:s/%1:s', ['source', 'target']) <>
    'target/source/target' then
    Result := False;
end;

function CheckFloatingPointText: Boolean;
var
  SavedSettings: TFormatSettings;
  Measurement: Double;
begin
  SavedSettings := FormatSettings;
  try
    FormatSettings.DecimalSeparator := ',';
    FormatSettings.ThousandSeparator := '.';
    Measurement := 4312.24;

    Result := True;

    if FloatToStr(12.5) <> '12,5' then
      Result := False;

    if FloatToStr(1E40) <> '1E40' then
      Result := False;

    if FormatFloat('#,##0.00', Measurement) <> '4.312,24' then
      Result := False;

    if FormatFloat('000000', Measurement) <> '004312' then
      Result := False;

    if FormatFloat('0.000', Measurement) <> '4312,240' then
      Result := False;

    if FormatFloat('0.000E+00', Measurement) <> '4,312E+03' then
      Result := False;

    if FormatFloat('0.0 "up";0.0 "down"', -Measurement) <>
      '4312,2 down' then
      Result := False;

    if FormatFloat('0.0;-0.0;"idle"', 0) <> 'idle' then
      Result := False;
  finally
    FormatSettings := SavedSettings;
  end;
end;

function RunFormattingChecks: Boolean;
begin
  Result := True;

  if not CheckBuildMessage then
    Result := False;

  if not CheckIdentifierLayout then
    Result := False;

  if not CheckFloatingPointText then
    Result := False;
end;

end.
