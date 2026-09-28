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

unit d7_overloads_basic;

interface

function RunBasicOverloadChecks: Boolean;

implementation

uses
  SysUtils;

function Describe(const AValue: Integer): string; overload;
begin
  Result := 'integer:' + IntToStr(AValue);
end;

function Describe(const AValue: string): string; overload;
begin
  Result := 'text:' + AValue;
end;

function Describe(const ALeft, ARight: Integer): string; overload;
begin
  Result := 'pair:' + IntToStr(ALeft) + ',' + IntToStr(ARight);
end;

function RunBasicOverloadChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
begin
  CheckResult1 := (Describe(27) = 'integer:27');
  Result := CheckResult1;

  CheckResult2 := (Describe('ready') = 'text:ready');
  Result := Result and CheckResult2;

  CheckResult3 := (Describe(4, 9) = 'pair:4,9');
  Result := Result and CheckResult3;
end;

end.
