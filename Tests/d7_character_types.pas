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

unit d7_character_types;

interface

function RunCharacterChecks: Boolean;

implementation

uses
  System.SysUtils;

function CheckCharacterAssignments: Boolean;
var
  UnicodeValue: Char;
  AnsiValue: AnsiChar;
begin
  UnicodeValue := 'R';
  Result := UnicodeValue = 'R';

  UnicodeValue := #84;
  Result := Result and (UnicodeValue = 'T');

  UnicodeValue := ^K;
  Result := Result and (UnicodeValue = Chr(11));

  UnicodeValue := Char(90);
  Result := Result and (UnicodeValue = 'Z');

  AnsiValue := 'b';
  Result := Result and (AnsiValue = AnsiChar(98));
end;

function CheckControlCharacters: Boolean;
var
  TextValue: string;
begin
  TextValue := 'left' + Chr(9) + 'right';
  Result := TextValue = 'left' + ^I + 'right';

  TextValue := 'first' + Chr(13) + Chr(10) + 'second';
  Result := Result and
    (TextValue = 'first' + ^M^J + 'second');
end;

function CheckOrdinalValues: Boolean;
var
  Flag: Boolean;
  Number: Integer;
  LargeNumber: Int64;
begin
  Flag := True;
  Number := 314;
  LargeNumber := 9001;

  Result :=
    (Ord('D') = 68) and
    (Ord(WideChar(#$03A9)) = $03A9) and
    (Ord(Flag) = 1) and
    (Ord(Number) = 314) and
    (Ord(LargeNumber) = 9001);
end;

function CheckValConversion: Boolean;
var
  SourceText: string;
  ParsedValue: Extended;
  ErrorPosition: Integer;
begin
  SourceText := '2718.125';
  Val(SourceText, ParsedValue, ErrorPosition);
  Result :=
    (ErrorPosition = 0) and
    (Abs(ParsedValue - 2718.125) < 0.000001);

  SourceText := '71x9';
  Val(SourceText, ParsedValue, ErrorPosition);
  Result := Result and (ErrorPosition = 3);
end;

function CheckUnicodeCharacters: Boolean;
var
  LineSeparator: Char;
  GreekOmega: Char;
begin
  LineSeparator := Chr($2028);
  GreekOmega := Char($03A9);

  Result :=
    (LineSeparator = #$2028) and
    (Ord(LineSeparator) = $2028) and
    (GreekOmega = #$03A9) and
    (Ord(GreekOmega) = $03A9);
end;

function RunCharacterChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
begin
  CheckResult1 := CheckCharacterAssignments;
  Result := CheckResult1;

  CheckResult2 := CheckControlCharacters;
  Result := Result and CheckResult2;

  CheckResult3 := CheckOrdinalValues;
  Result := Result and CheckResult3;

  CheckResult4 := CheckValConversion;
  Result := Result and CheckResult4;

  CheckResult5 := CheckUnicodeCharacters;
  Result := Result and CheckResult5;
end;

end.
