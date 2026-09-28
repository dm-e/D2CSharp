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

unit d7_datetime_formatting;

interface

function RunDateTimeFormattingChecks: Boolean;

implementation

uses
  System.SysUtils,
  System.DateUtils;

function RenderDateTime(const APattern: string;
  const AValue: TDateTime): string;
begin
  DateTimeToString(Result, APattern, AValue);
end;

function RunDateTimeFormattingChecks: Boolean;
var
  SavedSettings: TFormatSettings;
  Sample: TDateTime;
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
  SavedSettings := FormatSettings;
  try
    FormatSettings.DateSeparator := '|';
    FormatSettings.TimeSeparator := '~';
    FormatSettings.ShortDateFormat := 'yyyy/mm/dd';
    FormatSettings.LongDateFormat := 'dddd, d mmmm yyyy';
    FormatSettings.ShortTimeFormat := 'hh:nn';
    FormatSettings.LongTimeFormat := 'hh:nn:ss';
    FormatSettings.TimeAMString := 'amx';
    FormatSettings.TimePMString := 'pmx';
    FormatSettings.ShortMonthNames[11] := 'N11';
    FormatSettings.LongMonthNames[11] := 'MonthEleven';
    FormatSettings.ShortDayNames[1] := 'SunX';
    FormatSettings.LongDayNames[1] := 'SundayX';

    Sample := EncodeDateTime(2027, 11, 14, 16, 7, 8, 9);

    CheckResult1 :=
      (RenderDateTime('yyyy/mm/dd hh:nn:ss.zzz', Sample) =
      '2027|11|14 16~07~08.009');
    Result := CheckResult1;

    CheckResult2 :=
      (RenderDateTime('ddd d mmm yyyy', Sample) =
      'SunX 14 N11 2027');
    Result := Result and CheckResult2;

    CheckResult3 :=
      (RenderDateTime('dddd, d mmmm yyyy', Sample) =
      'SundayX, 14 MonthEleven 2027');
    Result := Result and CheckResult3;

    CheckResult4 :=
      (RenderDateTime('ddddd', Sample) =
      '2027|11|14');
    Result := Result and CheckResult4;

    CheckResult5 :=
      (RenderDateTime('dddddd', Sample) =
      'SundayX, 14 MonthEleven 2027');
    Result := Result and CheckResult5;

    CheckResult6 := (RenderDateTime('t', Sample) = '16~07');
    Result := Result and CheckResult6;

    CheckResult7 := (RenderDateTime('tt', Sample) = '16~07~08');
    Result := Result and CheckResult7;

    CheckResult8 :=
      (RenderDateTime('c', Sample) =
      '2027|11|14 16~07~08');
    Result := Result and CheckResult8;

    CheckResult9 :=
      (RenderDateTime('hh:nn ampm', Sample) =
      '04~07 pmx');
    Result := Result and CheckResult9;

    CheckResult10 :=
      (DateTimeToStr(Sample) =
      '2027|11|14 16~07~08');
    Result := Result and CheckResult10;
  finally
    FormatSettings := SavedSettings;
  end;
end;

end.
