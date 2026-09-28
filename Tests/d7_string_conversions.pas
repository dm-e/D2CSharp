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

unit d7_string_conversions;

interface

function RunStringConversionChecks: Boolean;

implementation

uses
  SysUtils;

function InvalidIntegerRaises: Boolean;
begin
  Result := False;
  try
    StrToInt('12x');
  except
    on E: EConvertError do
      Result := True;
  end;
end;

function RunStringConversionChecks: Boolean;
var
  {$IF CompilerVersion >= 20.0}
  SavedFormatSettings: TFormatSettings;
  {$ELSE}
  SavedDecimalSeparator: Char;
  {$IFEND}
  ParsedFloat: Extended;
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
  CheckResult4: Boolean;
  CheckResult5: Boolean;
  CheckResult6: Boolean;
  CheckResult7: Boolean;
  CheckResult8: Boolean;
begin
  CheckResult1 := (StrToInt('2048') = 2048);
  Result := CheckResult1;

  CheckResult2 := (StrToInt('  -17') = -17);
  Result := Result and CheckResult2;

  CheckResult3 := (StrToInt('$2A') = 42);
  Result := Result and CheckResult3;

  CheckResult4 := (StrToInt64('5000000000') = 5000000000);
  Result := Result and CheckResult4;

  CheckResult5 := (StrToIntDef('invalid', 73) = 73);
  Result := Result and CheckResult5;

  CheckResult6 := (StrToInt64Def('', 9000000001) = 9000000001);
  Result := Result and CheckResult6;

  CheckResult7 := InvalidIntegerRaises;
  Result := Result and CheckResult7;

  {$IF CompilerVersion >= 20.0}
  SavedFormatSettings := FormatSettings;
  {$ELSE}
  SavedDecimalSeparator := DecimalSeparator;
  {$IFEND}
  try
    {$IF CompilerVersion >= 20.0}
    FormatSettings.DecimalSeparator := ',';
    {$ELSE}
    DecimalSeparator := ',';
    {$IFEND}
    ParsedFloat := StrToFloat('125,75');
    CheckResult8 := (Abs(ParsedFloat - 125.75) < 1E-10);
    Result := Result and CheckResult8;
  finally
    {$IF CompilerVersion >= 20.0}
    FormatSettings := SavedFormatSettings;
    {$ELSE}
    DecimalSeparator := SavedDecimalSeparator;
    {$IFEND}
  end;
end;

end.
