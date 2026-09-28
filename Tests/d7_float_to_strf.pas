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

unit d7_float_to_strf;

interface

function RunFloatToStrFChecks: Boolean;

implementation

uses
  SysUtils;

function RunFloatToStrFChecks: Boolean;
var
  {$IF CompilerVersion >= 20.0}
  SavedFormatSettings: TFormatSettings;
  {$ELSE}
  SavedDecimalSeparator: Char;
  SavedThousandSeparator: Char;
  SavedCurrencyString: string;
  SavedCurrencyFormat: Byte;
  {$IFEND}
  GeneralText: string;
  ExponentText: string;
  CurrencyText: string;
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
  {$IF CompilerVersion >= 20.0}
  SavedFormatSettings := FormatSettings;
  {$ELSE}
  SavedDecimalSeparator := DecimalSeparator;
  SavedThousandSeparator := ThousandSeparator;
  SavedCurrencyString := CurrencyString;
  SavedCurrencyFormat := CurrencyFormat;
  {$IFEND}
  try
    {$IF CompilerVersion >= 20.0}
    FormatSettings.DecimalSeparator := ',';
    FormatSettings.ThousandSeparator := '.';
    FormatSettings.CurrencyString := 'C';
    FormatSettings.CurrencyFormat := 0;
    {$ELSE}
    DecimalSeparator := ',';
    ThousandSeparator := '.';
    CurrencyString := 'C';
    CurrencyFormat := 0;
    {$IFEND}

    GeneralText := FloatToStrF(78.125, ffGeneral, 6, 3);
    ExponentText := FloatToStrF(78.125, ffExponent, 6, 3);
    CurrencyText := FloatToStrF(1234.5, ffCurrency, 12, 2);

    CheckResult1 := (FloatToStrF(782.346, ffFixed, 12, 2) = '782,35');
    Result := CheckResult1;

    CheckResult2 :=
      (FloatToStrF(782.346, ffNumber, 12, 3) =
      '782,346');
    Result := Result and CheckResult2;

    CheckResult3 :=
      (FloatToStrF(12000.5, ffNumber, 12, 1) =
      '12.000,5');
    Result := Result and CheckResult3;

    CheckResult4 :=
      (FloatToStrF(0.125, ffFixed, 8, 4) =
      '0,1250');
    Result := Result and CheckResult4;

    CheckResult5 := (GeneralText = '78,125');
    Result := Result and CheckResult5;

    CheckResult6 := (Pos('7,8125', ExponentText) = 1);
    Result := Result and CheckResult6;

    CheckResult7 := (Pos('E+', ExponentText) > 0);
    Result := Result and CheckResult7;

    CheckResult8 := (Pos('C', CurrencyText) > 0);
    Result := Result and CheckResult8;

    CheckResult9 := (Pos('1.234', CurrencyText) > 0);
    Result := Result and CheckResult9;

    CheckResult10 := (Pos(',50', CurrencyText) > 0);
    Result := Result and CheckResult10;
  finally
    {$IF CompilerVersion >= 20.0}
    FormatSettings := SavedFormatSettings;
    {$ELSE}
    DecimalSeparator := SavedDecimalSeparator;
    ThousandSeparator := SavedThousandSeparator;
    CurrencyString := SavedCurrencyString;
    CurrencyFormat := SavedCurrencyFormat;
    {$IFEND}
  end;
end;

end.
