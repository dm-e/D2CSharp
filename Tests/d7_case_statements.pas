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

unit d7_case_statements;

interface

function RunCaseStatementChecks: Boolean;

implementation

type
  TBuildState = (bsQueued, bsRunning, bsSucceeded, bsFailed);

  TPayload = record
    Name: string[24];
    case IsRange: Boolean of
      False: (Value: Integer);
      True: (FirstValue: Integer; LastValue: Integer);
  end;

function StateCode(const AState: TBuildState): Integer;
begin
  case AState of
    bsQueued: Result := 10;
    bsRunning: Result := 20;
    bsSucceeded: Result := 30;
    bsFailed: Result := 40;
  else
    Result := -1;
  end;
end;

function ScoreBand(const AScore: Integer): Char;
begin
  case AScore of
    0..39: Result := 'D';
    40..59: Result := 'C';
    60..79: Result := 'B';
    80..100: Result := 'A';
  else
    Result := '?';
  end;
end;

function FindFirstSeparator(const AText: string): Integer;
var
  Index: Integer;
begin
  Result := 0;
  for Index := 1 to Length(AText) do
    case AText[Index] of
      '/', ':', '|':
        begin
          Result := Index;
          Break;
        end;
    end;
end;

function CharacterGroup(const AValue: WideChar): Integer;
begin
  case Ord(AValue) of
    $0000..$001F: Result := 1;
    $0030..$0039: Result := 2;
    $0041..$005A, $0061..$007A: Result := 3;
    $0080..$FFFF: Result := 4;
  else
    Result := 5;
  end;
end;

function CheckVariantRecord: Boolean;
var
  SingleValue: TPayload;
  RangeValue: TPayload;
begin
  SingleValue.Name := 'retries';
  SingleValue.IsRange := False;
  SingleValue.Value := 4;

  RangeValue.Name := 'ports';
  RangeValue.IsRange := True;
  RangeValue.FirstValue := 8000;
  RangeValue.LastValue := 8010;

  Result :=
    not SingleValue.IsRange and
    (SingleValue.Value = 4) and
    RangeValue.IsRange and
    (RangeValue.FirstValue = 8000) and
    (RangeValue.LastValue = 8010);
end;

function RunCaseStatementChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
  CheckResult8: Boolean;
  CheckResult9: Boolean;
  CheckResult10: Boolean;
begin
  CheckResult1 := (StateCode(bsSucceeded) = 30);
  Result := CheckResult1;

  CheckResult2 := (ScoreBand(73) = 'B');
  Result := Result and CheckResult2;

  CheckResult3 := (ScoreBand(140) = '?');
  Result := Result and CheckResult3;

  CheckResult4 := (FindFirstSeparator('scheme:value/rest') = 7);
  Result := Result and CheckResult4;

  CheckResult5 := (CharacterGroup(#9) = 1);
  Result := Result and CheckResult5;

  CheckResult6 := (CharacterGroup('7') = 2);
  Result := Result and CheckResult6;

  CheckResult7 := (CharacterGroup('q') = 3);
  Result := Result and CheckResult7;

  CheckResult8 := (CharacterGroup(WideChar($03A9)) = 4);
  Result := Result and CheckResult8;

  CheckResult9 := (CharacterGroup('.') = 5);
  Result := Result and CheckResult9;

  CheckResult10 := CheckVariantRecord;
  Result := Result and CheckResult10;
end;

end.
