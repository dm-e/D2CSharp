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

unit d7_interfaces_basic;

interface

function RunBasicInterfaceChecks: Boolean;

implementation

type
  IValueProvider = interface(IInterface)
    ['{31C1730F-F8B7-49AE-934C-27AB0A97F780}']
    function GetValue: Integer;
  end;

  TValueProvider = class(TInterfacedObject, IValueProvider)
  private
    FValue: Integer;
  public
    constructor Create(const AValue: Integer);
    function GetValue: Integer;
  end;

constructor TValueProvider.Create(const AValue: Integer);
begin
  inherited Create;
  FValue := AValue;
end;

function TValueProvider.GetValue: Integer;
begin
  Result := FValue;
end;

function RunBasicInterfaceChecks: Boolean;
var
  Provider: IValueProvider;
  CheckResult1: Boolean;
begin
  Provider := TValueProvider.Create(314);
  CheckResult1 := Provider.GetValue = 314;
  Result := CheckResult1;
end;

end.
