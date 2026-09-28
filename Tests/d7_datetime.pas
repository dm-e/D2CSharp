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

unit d7_datetime;

interface

function RunDateTimeChecks: Boolean;

implementation

uses
  System.SysUtils,
  System.DateUtils;

function CheckFileDateRoundTrip: Boolean;
var
  DataFile: TextFile;
  FileName: string;
  DesiredDate: TDateTime;
  DecodedDate: TDateTime;
  FileStamp: Integer;
  FileStampValid: Boolean;
  FileDateSet: Boolean;
  FileAgeValid: Boolean;
  YearMatches: Boolean;
  MonthMatches: Boolean;
  DayMatches: Boolean;
  HourMatches: Boolean;
  MinuteMatches: Boolean;
  SecondMatches: Boolean;
  Year: Word;
  Month: Word;
  Day: Word;
  Hour: Word;
  Minute: Word;
  Second: Word;
  Millisecond: Word;
begin
  FileName := IncludeTrailingPathDelimiter(GetCurrentDir) +
    'd7_filedate_probe.txt';

  AssignFile(DataFile, FileName);
  Rewrite(DataFile);
  try
    WriteLn(DataFile, 'timestamp probe');
  finally
    CloseFile(DataFile);
  end;

  try
    DesiredDate := EncodeDateTime(2022, 4, 15, 10, 20, 30, 0);

    FileStamp := DateTimeToFileDate(DesiredDate);
    FileStampValid := FileStamp <> -1;
    Result := FileStampValid;

    if Result then
    begin
      FileDateSet := FileSetDate(FileName, FileStamp) = 0;
      Result := FileDateSet;
    end;

    if Result then
    begin
      FileStamp := FileAge(FileName);
      FileAgeValid := FileStamp <> -1;
      Result := FileAgeValid;
    end;

    if Result then
    begin
      DecodedDate := FileDateToDateTime(FileStamp);
      DecodeDateTime(DecodedDate, Year, Month, Day,
        Hour, Minute, Second, Millisecond);

      YearMatches := Year = 2022;
      MonthMatches := Month = 4;
      DayMatches := Day = 15;
      HourMatches := Hour = 10;
      MinuteMatches := Minute = 20;
      SecondMatches := Second = 30;

      Result := YearMatches;
      Result := Result and MonthMatches;
      Result := Result and DayMatches;
      Result := Result and HourMatches;
      Result := Result and MinuteMatches;
      Result := Result and SecondMatches;
    end;
  finally
    if FileExists(FileName) then
      DeleteFile(FileName);
  end;
end;

function CheckCalendarRules: Boolean;
var
  LeapYearFebruaryMatches: Boolean;
  CenturyFebruaryMatches: Boolean;
  AprilMatches: Boolean;
  DecemberMatches: Boolean;
  LeapYearMonthDaysMatches: Boolean;
  NormalYearMonthDaysMatches: Boolean;
begin
  LeapYearFebruaryMatches := DaysInAMonth(2024, 2) = 29;
  CenturyFebruaryMatches := DaysInAMonth(2100, 2) = 28;
  AprilMatches := DaysInAMonth(2023, 4) = 30;
  DecemberMatches := DaysInAMonth(2023, 12) = 31;
  LeapYearMonthDaysMatches := MonthDays[True, 2] = 29;
  NormalYearMonthDaysMatches := MonthDays[False, 2] = 28;

  Result := LeapYearFebruaryMatches;
  Result := Result and CenturyFebruaryMatches;
  Result := Result and AprilMatches;
  Result := Result and DecemberMatches;
  Result := Result and LeapYearMonthDaysMatches;
  Result := Result and NormalYearMonthDaysMatches;
end;

function ComposeTimePart(const AHour, AMinute,
  ASecond, AMillisecond: Integer): Integer;
const
  MillisecondsPerSecond = 1000;
  MillisecondsPerMinute = 60 * MillisecondsPerSecond;
  MillisecondsPerHour = 60 * MillisecondsPerMinute;
var
  HourPart: Integer;
  MinutePart: Integer;
  SecondPart: Integer;
  MillisecondPart: Integer;
  HourAndMinutePart: Integer;
  HourMinuteAndSecondPart: Integer;
begin
  HourPart := AHour * MillisecondsPerHour;
  MinutePart := AMinute * MillisecondsPerMinute;
  SecondPart := ASecond * MillisecondsPerSecond;
  MillisecondPart := AMillisecond;

  HourAndMinutePart := HourPart + MinutePart;
  HourMinuteAndSecondPart := HourAndMinutePart + SecondPart;
  Result := HourMinuteAndSecondPart + MillisecondPart;
end;

function ExpectedMilliseconds(const ATimeStamp: TTimeStamp): Comp;
var
  DatePart: Comp;
  TimePart: Comp;
  DatePartInMilliseconds: Comp;
begin
  DatePart := ATimeStamp.Date;
  TimePart := ATimeStamp.Time;
  DatePartInMilliseconds := DatePart * MSecsPerDay;
  Result := DatePartInMilliseconds + TimePart;
end;

function InvalidTimeStampRaises(
  const ADate, ATime: Integer): Boolean;
var
  TimeStamp: TTimeStamp;
  ConversionResult: Comp;
begin
  TimeStamp.Date := ADate;
  TimeStamp.Time := ATime;
  Result := False;
  try
    ConversionResult := TimeStampToMSecs(TimeStamp);
  except
    on E: EConvertError do
      Result := True;
  end;
end;

function CheckTimeStampConversions: Boolean;
var
  SourceStamp: TTimeStamp;
  ConvertedStamp: TTimeStamp;
  Milliseconds: Comp;
  ExpectedMillisecondsValue: Comp;
  MillisecondsMatch: Boolean;
  DateMatches: Boolean;
  TimeMatches: Boolean;
  InvalidZeroStampRaises: Boolean;
  InvalidNegativeTimeRaises: Boolean;
  InvalidFullDayTimeRaises: Boolean;
begin
  SourceStamp.Date := 51234;
  SourceStamp.Time := ComposeTimePart(21, 8, 7, 654);

  Milliseconds := TimeStampToMSecs(SourceStamp);
  ConvertedStamp := MSecsToTimeStamp(Milliseconds);
  ExpectedMillisecondsValue := ExpectedMilliseconds(SourceStamp);

  MillisecondsMatch := Milliseconds = ExpectedMillisecondsValue;
  DateMatches := ConvertedStamp.Date = SourceStamp.Date;
  TimeMatches := ConvertedStamp.Time = SourceStamp.Time;
  InvalidZeroStampRaises := InvalidTimeStampRaises(0, 0);
  InvalidNegativeTimeRaises := InvalidTimeStampRaises(3, -1);
  InvalidFullDayTimeRaises := InvalidTimeStampRaises(3, MSecsPerDay);

  Result := MillisecondsMatch;
  Result := Result and DateMatches;
  Result := Result and TimeMatches;
  Result := Result and InvalidZeroStampRaises;
  Result := Result and InvalidNegativeTimeRaises;
  Result := Result and InvalidFullDayTimeRaises;
end;

function RunDateTimeChecks: Boolean;
var
  CheckResult1: Boolean;
  CheckResult2: Boolean;
  CheckResult3: Boolean;
begin
  CheckResult1 := CheckFileDateRoundTrip;
  CheckResult2 := CheckCalendarRules;
  CheckResult3 := CheckTimeStampConversions;

  Result := CheckResult1;
  Result := Result and CheckResult2;
  Result := Result and CheckResult3;
end;

end.
