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

unit d7_for_loops;

interface

function RunForLoopChecks: Boolean;

implementation

uses
  SysUtils;

type
  TPipelineStage = (psRead, psAnalyze, psGenerate);
  TPipelineStages = set of TPipelineStage;

function RunForLoopChecks: Boolean;
var
  Index: Integer;
  Sum: Integer;
  ReverseDigits: string;
  Values: array of Integer;
  Value: Integer;
  Text: string;
  CharacterValue: Char;
  Stage: TPipelineStage;
  SelectedStages: TPipelineStages;
  StageCount: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
begin
  Sum := 0;
  for Index := 1 to 10 do
    Sum := Sum + Index;

  ReverseDigits := '';
  for Index := 4 downto 1 do
    ReverseDigits := ReverseDigits + IntToStr(Index);

  SetLength(Values, 4);
  Values[0] := 3;
  Values[1] := 5;
  Values[2] := 7;
  Values[3] := 11;
  for Value in Values do
    Inc(Sum, Value);

  Text := '';
  for CharacterValue in 'D7' do
    Text := Text + CharacterValue;

  SelectedStages := [psRead, psGenerate];
  StageCount := 0;
  for Stage in SelectedStages do
    Inc(StageCount);

  CheckResult1 := (Sum = 81);
  Result := CheckResult1;

  CheckResult2 := (ReverseDigits = '4321');
  Result := Result and CheckResult2;

  CheckResult3 := (Text = 'D7');
  Result := Result and CheckResult3;

  CheckResult4 := (StageCount = 2);
  Result := Result and CheckResult4;
end;

end.
