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

unit d7_classes;

interface

type
  TTranslationOptions = record
  public type
    TMode = (tmConservative, tmBalanced, tmAggressive);
  public
    class var DefaultMode: TMode;
    class procedure SelectBalancedMode; static;
    class function HasBalancedMode: Boolean; static;
  end;

  TStatusMapper = record
  public type
    TStatus = (tsUnknown, tsAccepted, tsRejected);
  public
    function Normalize(const AStatus: TStatus): TStatus;
    function CheckAcceptedStatus: Boolean;
  end;

  TDevicePanel = class;

  TSensor = class(TObject)
  private
    FUsesRange: Boolean;
    FChannel: Integer;
    FFirstChannel: Integer;
    FLastChannel: Integer;
  public
    constructor Create(const AChannel: Integer); overload;
    constructor Create(const AFirstChannel, ALastChannel: Integer); overload;
    property UsesRange: Boolean read FUsesRange;
    property Channel: Integer read FChannel;
    property FirstChannel: Integer read FFirstChannel;
    property LastChannel: Integer read FLastChannel;
  end;

  TDevicePanel = class(TObject)
  public
    function Accepts(const ASensor: TSensor): Boolean;
  end;

function RunClassChecks: Boolean;

implementation

class procedure TTranslationOptions.SelectBalancedMode;
begin
  DefaultMode := tmBalanced;
end;

class function TTranslationOptions.HasBalancedMode: Boolean;
begin
  Result := DefaultMode = tmBalanced;
end;

function TStatusMapper.Normalize(
  const AStatus: TStatus): TStatus;
begin
  case AStatus of
    tsAccepted,
    tsRejected:
      Result := AStatus;
  else
    Result := tsUnknown;
  end;
end;

function TStatusMapper.CheckAcceptedStatus: Boolean;
begin
  Result := Normalize(tsAccepted) = tsAccepted;
end;

constructor TSensor.Create(const AChannel: Integer);
begin
  inherited Create;
  FUsesRange := False;
  FChannel := AChannel;
end;

constructor TSensor.Create(
  const AFirstChannel, ALastChannel: Integer);
begin
  inherited Create;
  FUsesRange := True;
  FFirstChannel := AFirstChannel;
  FLastChannel := ALastChannel;
end;

function TDevicePanel.Accepts(const ASensor: TSensor): Boolean;
begin
  if ASensor.UsesRange then
    Result := ASensor.FirstChannel <= ASensor.LastChannel
  else
    Result := ASensor.Channel >= 0;
end;

function RunClassChecks: Boolean;
var
  Panel: TDevicePanel;
  SingleSensor: TSensor;
  RangeSensor: TSensor;
  Mapper: TStatusMapper;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
  CheckResult8: Boolean;
  CheckResult9: Boolean;
begin
  TTranslationOptions.SelectBalancedMode;

  Panel := TDevicePanel.Create;
  SingleSensor := TSensor.Create(12);
  RangeSensor := TSensor.Create(20, 24);
  try
    CheckResult1 := TTranslationOptions.HasBalancedMode;
    Result := CheckResult1;

    CheckResult2 := not SingleSensor.UsesRange;
    Result := Result and CheckResult2;

    CheckResult3 := (SingleSensor.Channel = 12);
    Result := Result and CheckResult3;

    CheckResult4 := RangeSensor.UsesRange;
    Result := Result and CheckResult4;

    CheckResult5 := (RangeSensor.FirstChannel = 20);
    Result := Result and CheckResult5;

    CheckResult6 := (RangeSensor.LastChannel = 24);
    Result := Result and CheckResult6;

    CheckResult7 := Panel.Accepts(SingleSensor);
    Result := Result and CheckResult7;

    CheckResult8 := Panel.Accepts(RangeSensor);
    Result := Result and CheckResult8;

    CheckResult9 := Mapper.CheckAcceptedStatus;
    Result := Result and CheckResult9;
  finally
    RangeSensor.Free;
    SingleSensor.Free;
    Panel.Free;
  end;
end;

end.
