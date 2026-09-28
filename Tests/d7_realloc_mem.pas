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

unit d7_realloc_mem;

interface

function RunReallocMemChecks: Boolean;

implementation

type
  PByteBlock = ^TByteBlock;
  TByteBlock = array[0..7] of Byte;

function RunReallocMemChecks: Boolean;
var
  RawMemory: Pointer;
  Index: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
begin
  RawMemory := nil;
  GetMem(RawMemory, 4);
  try
    for Index := 0 to 3 do
      PByteBlock(RawMemory)^[Index] := Index + 10;

    ReallocMem(RawMemory, SizeOf(TByteBlock));
    for Index := 4 to 7 do
      PByteBlock(RawMemory)^[Index] := Index + 10;

    CheckResult1 := (PByteBlock(RawMemory)^[0] = 10);
    Result := CheckResult1;

    CheckResult2 := (PByteBlock(RawMemory)^[3] = 13);
    Result := Result and CheckResult2;

    CheckResult3 := (PByteBlock(RawMemory)^[4] = 14);
    Result := Result and CheckResult3;

    CheckResult4 := (PByteBlock(RawMemory)^[7] = 17);
    Result := Result and CheckResult4;
  finally
    FreeMem(RawMemory);
  end;
end;

end.
