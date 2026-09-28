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

unit d7_free_mem;

interface

function RunFreeMemChecks: Boolean;

implementation

type
  PByteBuffer = ^TByteBuffer;
  TByteBuffer = array[0..15] of Byte;

function RunFreeMemChecks: Boolean;
var
  Buffer: PByteBuffer;
  Index: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
begin
  Buffer := nil;
  GetMem(Buffer, SizeOf(TByteBuffer));
  try
    for Index := Low(Buffer^) to High(Buffer^) do
      Buffer^[Index] := Index * 3;

    CheckResult1 := (Buffer^[0] = 0);
    Result := CheckResult1;

    CheckResult2 := (Buffer^[5] = 15);
    Result := Result and CheckResult2;

    CheckResult3 := (Buffer^[15] = 45);
    Result := Result and CheckResult3;
  finally
    FreeMem(Buffer);
  end;
end;

end.
