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

unit d7_string_processor;

interface

function RunStringProcessorChecks: Boolean;

implementation

uses
  SysUtils;

type
  TTextScanner = class
  private
    FText: string;
    FNeedle: string;
    FNextIndex: Integer;
    function GetTokenCount: Integer;
    procedure SetText(const AValue: string);
  public
    constructor Create(const AText: string);
    function FindFirst(const ANeedle: string): Integer;
    function FindNext: Integer;
    function ReplaceAll(const AOldText, ANewText: string): Integer;
    property Text: string read FText write SetText;
    property TokenCount: Integer read GetTokenCount;
  end;

constructor TTextScanner.Create(const AText: string);
begin
  inherited Create;
  SetText(AText);
end;

procedure TTextScanner.SetText(const AValue: string);
begin
  FText := AValue;
  FNeedle := '';
  FNextIndex := 1;
end;

function TTextScanner.GetTokenCount: Integer;
var
  Index: Integer;
  InsideToken: Boolean;
begin
  Result := 0;
  InsideToken := False;
  for Index := 1 to Length(FText) do
  begin
    if FText[Index] in [#9, #10, #13, ' '] then
    begin
      if InsideToken then
        Inc(Result);
      InsideToken := False;
    end
    else
      InsideToken := True;
  end;
  if InsideToken then
    Inc(Result);
end;

function TTextScanner.FindFirst(const ANeedle: string): Integer;
begin
  FNeedle := ANeedle;
  FNextIndex := 1;
  Result := FindNext;
end;

function TTextScanner.FindNext: Integer;
var
  RelativeIndex: Integer;
begin
  if FNeedle = '' then
  begin
    Result := 0;
    Exit;
  end;

  RelativeIndex := Pos(FNeedle, Copy(FText, FNextIndex, MaxInt));
  if RelativeIndex = 0 then
  begin
    Result := 0;
    Exit;
  end;

  Result := FNextIndex + RelativeIndex - 1;
  FNextIndex := Result + Length(FNeedle);
end;

function TTextScanner.ReplaceAll(const AOldText,
  ANewText: string): Integer;
var
  MatchIndex: Integer;
  RelativeIndex: Integer;
  SearchStart: Integer;
begin
  Result := 0;
  if AOldText = '' then
    Exit;

  MatchIndex := Pos(AOldText, FText);
  while MatchIndex > 0 do
  begin
    Delete(FText, MatchIndex, Length(AOldText));
    Insert(ANewText, FText, MatchIndex);
    Inc(Result);
    SearchStart := MatchIndex + Length(ANewText);
    RelativeIndex := Pos(AOldText,
      Copy(FText, SearchStart, MaxInt));
    if RelativeIndex = 0 then
      MatchIndex := 0
    else
      MatchIndex := SearchStart + RelativeIndex - 1;
  end;
  FNeedle := '';
  FNextIndex := 1;
end;

function RunStringProcessorChecks: Boolean;
var
  Scanner: TTextScanner;
  FirstIndex: Integer;
  SecondIndex: Integer;
  Replacements: Integer;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
begin
  Scanner := TTextScanner.Create(
    'red green'#9'blue red'#13#10'orange');
  try
    CheckResult1 := Scanner.TokenCount = 5;
    Result := CheckResult1;

    FirstIndex := Scanner.FindFirst('red');
    SecondIndex := Scanner.FindNext;
    CheckResult2 := (FirstIndex = 1);
    Result := Result and CheckResult2;

    CheckResult3 := (SecondIndex = 16);
    Result := Result and CheckResult3;

    CheckResult4 := (Scanner.FindNext = 0);
    Result := Result and CheckResult4;

    Replacements := Scanner.ReplaceAll('red', 'gold');
    CheckResult5 := (Replacements = 2);
    Result := Result and CheckResult5;

    CheckResult6 := (Scanner.Text = 'gold green'#9'blue gold'#13#10'orange');
    Result := Result and CheckResult6;

    Scanner.Text := 'one  two three';
    CheckResult7 := (Scanner.TokenCount = 3);
    Result := Result and CheckResult7;
  finally
    Scanner.Free;
  end;
end;

end.
