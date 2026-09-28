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

unit d7_fill_char;

interface

function RunFillCharChecks: Boolean;

implementation

type
  TProbeRecord = record
    Counter: Integer;
    Enabled: Boolean;
    Code: Byte;
  end;

function RunFillCharChecks: Boolean;
var
  Probe: TProbeRecord;
  Buffer: array[0..7] of Byte;
  Index: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
begin
  Probe.Counter := 99;
  Probe.Enabled := True;
  Probe.Code := 17;
  FillChar(Probe, SizeOf(Probe), 0);

  CheckResult1 := Probe.Counter = 0;
  CheckResult2 := not Probe.Enabled;
  CheckResult3 := Probe.Code = 0;

  FillChar(Buffer, SizeOf(Buffer), $A5);
  CheckResult4 := True;
  for Index := Low(Buffer) to High(Buffer) do
    CheckResult4 := CheckResult4 and (Buffer[Index] = $A5);

  Result := CheckResult1;
  Result := Result and CheckResult2;
  Result := Result and CheckResult3;
  Result := Result and CheckResult4;
end;

end.
