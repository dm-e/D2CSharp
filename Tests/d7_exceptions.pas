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

unit d7_exceptions;

interface

function RunExceptionChecks: Boolean;

implementation

uses
  SysUtils;

type
  EProbeError = class(Exception);

procedure RequirePositive(const AValue: Integer);
begin
  if AValue <= 0 then
    raise EProbeError.Create('value must be positive');
end;

function RunExceptionChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
begin
  CheckResult1 := False;
  try
    RequirePositive(-3);
  except
    on E: EProbeError do
      CheckResult1 := E.Message = 'value must be positive';
    else
      CheckResult1 := False;
  end;
  Result := CheckResult1;

  if Result then
  begin
    CheckResult2 := True;
    try
      RequirePositive(8);
    except
      CheckResult2 := False;
    end;
    Result := Result and CheckResult2;
  end;
end;

end.
