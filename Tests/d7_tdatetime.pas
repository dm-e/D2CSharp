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

unit d7_tdatetime;

interface

function RunTDateTimeChecks: Boolean;

implementation

uses
  SysUtils,
  DateUtils;

function RunTDateTimeChecks: Boolean;
var
  StartValue: TDateTime;
  EndValue: TDateTime;
  YearValue: Word;
  MonthValue: Word;
  DayValue: Word;
  HourValue: Word;
  MinuteValue: Word;
  SecondValue: Word;
  MillisecondValue: Word;
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
  CheckResult11: Boolean;
  CheckResult12: Boolean;
begin
  StartValue := EncodeDateTime(2004, 2, 28, 18, 30, 0, 0);
  EndValue := EncodeDateTime(2004, 3, 2, 6, 30, 0, 0);
  DecodeDateTime(EndValue, YearValue, MonthValue, DayValue,
    HourValue, MinuteValue, SecondValue, MillisecondValue);

  CheckResult1 := (YearValue = 2004);
  Result := CheckResult1;

  CheckResult2 := (MonthValue = 3);
  Result := Result and CheckResult2;

  CheckResult3 := (DayValue = 2);
  Result := Result and CheckResult3;

  CheckResult4 := (HourValue = 6);
  Result := Result and CheckResult4;

  CheckResult5 := (MinuteValue = 30);
  Result := Result and CheckResult5;

  CheckResult6 := (DayOfTheMonth(StartValue) = 28);
  Result := Result and CheckResult6;

  CheckResult7 := (DayOfTheWeek(StartValue) = 6);
  Result := Result and CheckResult7;

  CheckResult8 := (DayOfTheYear(StartValue) = 59);
  Result := Result and CheckResult8;

  CheckResult9 := (DaysBetween(StartValue, EndValue) = 2);
  Result := Result and CheckResult9;

  CheckResult10 := (Abs(DaySpan(EndValue, StartValue) - 2.5) < 1E-10);
  Result := Result and CheckResult10;

  CheckResult11 := (DaysInAMonth(2004, 2) = 29);
  Result := Result and CheckResult11;

  CheckResult12 := (DaysInAYear(2004) = 366);
  Result := Result and CheckResult12;
end;

end.
