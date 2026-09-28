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

unit d7_currency;

interface

function RunCurrencyChecks: Boolean;

implementation

uses
  System.SysUtils;

function CheckCurrencyStorage: Boolean;
var
  FirstAmount: Currency;
  SecondAmount: Currency;
  TotalAmount: Currency;
begin
  FirstAmount := 17.20491;
  SecondAmount := 17.20509;
  TotalAmount := FirstAmount + SecondAmount;

  Result :=
    (FirstAmount = 17.2049) and
    (SecondAmount = 17.2051) and
    (TotalAmount = 34.4100);
end;

function CheckCurrencyLayouts: Boolean;
const
  Expected: array[0..3] of string =
    ('CRD27', '27CRD', 'CRD 27', '27 CRD');
var
  SavedSettings: TFormatSettings;
  Layout: Integer;
  Rendered: string;
begin
  SavedSettings := FormatSettings;
  try
    FormatSettings.CurrencyString := 'CRD';
    FormatSettings.CurrencyDecimals := 0;
    Result := True;

    for Layout := 0 to 3 do
    begin
      FormatSettings.CurrencyFormat := Layout;
      Rendered := CurrToStrF(27, ffCurrency, 0);
      Result := Result and (Rendered = Expected[Layout]);
    end;
  finally
    FormatSettings := SavedSettings;
  end;
end;

function CheckCurrencyConversions: Boolean;
var
  SavedSettings: TFormatSettings;
  Amount: Currency;
  FormattedAmount: string;
  CurrencyAsString: string;
  CurrencyWithThreeDecimals: string;
  CurrencyWithoutDecimals: string;
  IsFormattedAmountValid: Boolean;
  IsCurrencyStringValid: Boolean;
  IsThreeDecimalFormatValid: Boolean;
  IsZeroDecimalFormatValid: Boolean;
begin
  SavedSettings := FormatSettings;
  try
    FormatSettings.DecimalSeparator := ',';
    FormatSettings.ThousandSeparator := '.';
    FormatSettings.CurrencyString := 'CRD';
    FormatSettings.CurrencyFormat := 3;
    FormatSettings.CurrencyDecimals := 2;

    Amount := 7654.321;

    FormattedAmount := Format('%m', [Amount]);
    CurrencyAsString := CurrToStr(42.375);
    CurrencyWithThreeDecimals := CurrToStrF(Amount, ffCurrency, 3);
    CurrencyWithoutDecimals := CurrToStrF(Amount, ffCurrency, 0);

    IsFormattedAmountValid := FormattedAmount = '7.654,32 CRD';
    IsCurrencyStringValid := CurrencyAsString = '42,375';
    IsThreeDecimalFormatValid :=
      CurrencyWithThreeDecimals = '7.654,321 CRD';
    IsZeroDecimalFormatValid :=
      CurrencyWithoutDecimals = '7.654 CRD';

    Result :=
      IsFormattedAmountValid and
      IsCurrencyStringValid and
      IsThreeDecimalFormatValid and
      IsZeroDecimalFormatValid;
  finally
    FormatSettings := SavedSettings;
  end;
end;

function RunCurrencyChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
begin
  CheckResult1 := CheckCurrencyStorage;
  Result := CheckResult1;

  CheckResult2 := CheckCurrencyLayouts;
  Result := Result and CheckResult2;

  CheckResult3 := CheckCurrencyConversions;
  Result := Result and CheckResult3;
end;

end.
