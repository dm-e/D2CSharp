{
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.DateUtils functionality required by D2CSharp.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The routines below intentionally contain no RTL implementation. Functions
  return simple default values and procedures have empty bodies.

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

unit System.DateUtils;

interface

uses
  System.SysUtils,
  System.Types;

const
  { Calendar constants }
  DaysPerWeek = 7;
  WeeksPerFortnight = 2;
  MonthsPerYear = 12;
  YearsPerDecade = 10;
  YearsPerCentury = 100;
  YearsPerMillennium = 1000;

  HoursPerDay = 24;
  MinsPerHour = 60;
  SecsPerMin = 60;
  MSecsPerSec = 1000;

  MinsPerDay = HoursPerDay * MinsPerHour;
  SecsPerHour = MinsPerHour * SecsPerMin;
  SecsPerDay = MinsPerDay * SecsPerMin;
  MSecsPerMin = SecsPerMin * MSecsPerSec;
  MSecsPerHour = SecsPerHour * MSecsPerSec;
  MSecsPerDay = SecsPerDay * MSecsPerSec;

  DaysPerYear = 365;
  ApproxDaysPerMonth = 30.4375;
  ApproxDaysPerYear = 365.25;

  OneHour = 1 / HoursPerDay;
  OneMinute = 1 / MinsPerDay;
  OneSecond = 1 / SecsPerDay;
  OneMillisecond = 1 / MSecsPerDay;

  RecodeLeaveFieldAsIs = 65535;

  { ISO weekday numbers used by DateUtils. }
  DayMonday = 1;
  DayTuesday = 2;
  DayWednesday = 3;
  DayThursday = 4;
  DayFriday = 5;
  DaySaturday = 6;
  DaySunday = 7;

  MonthJanuary = 1;
  MonthFebruary = 2;
  MonthMarch = 3;
  MonthApril = 4;
  MonthMay = 5;
  MonthJune = 6;
  MonthJuly = 7;
  MonthAugust = 8;
  MonthSeptember = 9;
  MonthOctober = 10;
  MonthNovember = 11;
  MonthDecember = 12;

type
  { Public DateUtils helper types used by common APIs. }
  TDateTimePart = (
    dtpYear,
    dtpMonth,
    dtpWeek,
    dtpDay,
    dtpHour,
    dtpMinute,
    dtpSecond,
    dtpMilliSecond
  );
  TDateTimeParts = set of TDateTimePart;

  TISO8601ToDateOption = (
    ioReturnUTC,
    ioNoTZIsLocal
  );
  TISO8601ToDateOptions = set of TISO8601ToDateOption;

  EDateTimeException = class(Exception);

{ Basic extraction }

function DateOf(const AValue: TDateTime): TDateTime;
function TimeOf(const AValue: TDateTime): TDateTime;

function IsInLeapYear(const AValue: TDateTime): Boolean;
function IsPM(const AValue: TDateTime): Boolean;
function IsAM(const AValue: TDateTime): Boolean;
function IsToday(const AValue: TDateTime): Boolean;
function IsSameDay(const AValue, ABasis: TDateTime): Boolean;
function IsSameMonth(const AValue, ABasis: TDateTime): Boolean;

function YearOf(const AValue: TDateTime): Word;
function MonthOf(const AValue: TDateTime): Word;
function WeekOf(const AValue: TDateTime): Word;
function DayOf(const AValue: TDateTime): Word;
function HourOf(const AValue: TDateTime): Word;
function MinuteOf(const AValue: TDateTime): Word;
function SecondOf(const AValue: TDateTime): Word;
function MilliSecondOf(const AValue: TDateTime): Word;

function WeekOfTheYear(const AValue: TDateTime): Word; overload;
function WeekOfTheYear(const AValue: TDateTime; var AYear: Word): Word; overload;
function MonthOfTheYear(const AValue: TDateTime): Word;
function DayOfTheYear(const AValue: TDateTime): Word;
function DayOfTheMonth(const AValue: TDateTime): Word;
function DayOfTheWeek(const AValue: TDateTime): Word;
function WeekOfTheMonth(const AValue: TDateTime): Word;
function NthDayOfWeek(const AValue: TDateTime): Word;

function HourOfTheYear(const AValue: TDateTime): Word;
function HourOfTheMonth(const AValue: TDateTime): Word;
function HourOfTheWeek(const AValue: TDateTime): Word;
function HourOfTheDay(const AValue: TDateTime): Word;

function MinuteOfTheYear(const AValue: TDateTime): Cardinal;
function MinuteOfTheMonth(const AValue: TDateTime): Word;
function MinuteOfTheWeek(const AValue: TDateTime): Word;
function MinuteOfTheDay(const AValue: TDateTime): Word;
function MinuteOfTheHour(const AValue: TDateTime): Word;

function SecondOfTheYear(const AValue: TDateTime): Cardinal;
function SecondOfTheMonth(const AValue: TDateTime): Cardinal;
function SecondOfTheWeek(const AValue: TDateTime): Cardinal;
function SecondOfTheDay(const AValue: TDateTime): Cardinal;
function SecondOfTheHour(const AValue: TDateTime): Word;
function SecondOfTheMinute(const AValue: TDateTime): Word;

function MilliSecondOfTheYear(const AValue: TDateTime): Int64;
function MilliSecondOfTheMonth(const AValue: TDateTime): Cardinal;
function MilliSecondOfTheWeek(const AValue: TDateTime): Cardinal;
function MilliSecondOfTheDay(const AValue: TDateTime): Cardinal;
function MilliSecondOfTheHour(const AValue: TDateTime): Cardinal;
function MilliSecondOfTheMinute(const AValue: TDateTime): Word;
function MilliSecondOfTheSecond(const AValue: TDateTime): Word;

{ Calendar size }

function WeeksInAYear(const AYear: Word): Word;
function WeeksInYear(const AValue: TDateTime): Word;
function DaysInAYear(const AYear: Word): Word;
function DaysInYear(const AValue: TDateTime): Word;
function DaysInAMonth(const AYear, AMonth: Word): Word;
function DaysInMonth(const AValue: TDateTime): Word;

{ Encoding and decoding }

function EncodeDateDay(const AYear, ADayOfYear: Word): TDateTime;
function TryEncodeDateDay(const AYear, ADayOfYear: Word; out AValue: TDateTime): Boolean;
procedure DecodeDateDay(const AValue: TDateTime; out AYear, ADayOfYear: Word);

function EncodeDateWeek(const AYear, AWeekOfYear: Word; const ADayOfWeek: Word = 1): TDateTime;
function TryEncodeDateWeek(const AYear, AWeekOfYear: Word; out AValue: TDateTime; const ADayOfWeek: Word = 1): Boolean;
procedure DecodeDateWeek(const AValue: TDateTime; out AYear, AWeekOfYear, ADayOfWeek: Word);

function EncodeDateMonthWeek(const AYear, AMonth, AWeekOfMonth, ADayOfWeek: Word): TDateTime;
function TryEncodeDateMonthWeek(const AYear, AMonth, AWeekOfMonth, ADayOfWeek: Word; out AValue: TDateTime): Boolean;
procedure DecodeDateMonthWeek(const AValue: TDateTime; out AYear, AMonth, AWeekOfMonth, ADayOfWeek: Word);

function EncodeDayOfWeekInMonth(const AYear, AMonth, ANthDayOfWeek, ADayOfWeek: Word): TDateTime;
function TryEncodeDayOfWeekInMonth(const AYear, AMonth, ANthDayOfWeek, ADayOfWeek: Word; out AValue: TDateTime): Boolean;
procedure DecodeDayOfWeekInMonth(const AValue: TDateTime; out AYear, AMonth, ANthDayOfWeek, ADayOfWeek: Word);

function EncodeDateTime(const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word): TDateTime;
function TryEncodeDateTime(const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word; out AValue: TDateTime): Boolean;
procedure DecodeDateTime(const AValue: TDateTime; out AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word);

{ Beginning/end helpers }

function StartOfTheYear(const AValue: TDateTime): TDateTime;
function EndOfTheYear(const AValue: TDateTime): TDateTime;
function StartOfAYear(const AYear: Word): TDateTime;
function EndOfAYear(const AYear: Word): TDateTime;

function StartOfTheMonth(const AValue: TDateTime): TDateTime;
function EndOfTheMonth(const AValue: TDateTime): TDateTime;
function StartOfAMonth(const AYear, AMonth: Word): TDateTime;
function EndOfAMonth(const AYear, AMonth: Word): TDateTime;

function StartOfTheWeek(const AValue: TDateTime): TDateTime;
function EndOfTheWeek(const AValue: TDateTime): TDateTime;
function StartOfAWeek(const AYear, AWeekOfYear: Word; const ADayOfWeek: Word = 1): TDateTime;
function EndOfAWeek(const AYear, AWeekOfYear: Word; const ADayOfWeek: Word = 7): TDateTime;

function StartOfTheDay(const AValue: TDateTime): TDateTime;
function EndOfTheDay(const AValue: TDateTime): TDateTime;
function StartOfADay(const AYear, AMonth, ADay: Word): TDateTime; overload;
function StartOfADay(const AYear, ADayOfYear: Word): TDateTime; overload;
function EndOfADay(const AYear, AMonth, ADay: Word): TDateTime; overload;
function EndOfADay(const AYear, ADayOfYear: Word): TDateTime; overload;

function Today: TDateTime;
function Yesterday: TDateTime;
function Tomorrow: TDateTime;

{ Increment helpers }

function IncYear(const AValue: TDateTime; const ANumberOfYears: Integer = 1): TDateTime;
function IncWeek(const AValue: TDateTime; const ANumberOfWeeks: Integer = 1): TDateTime;
function IncDay(const AValue: TDateTime; const ANumberOfDays: Integer = 1): TDateTime;
function IncHour(const AValue: TDateTime; const ANumberOfHours: Int64 = 1): TDateTime;
function IncMinute(const AValue: TDateTime; const ANumberOfMinutes: Int64 = 1): TDateTime;
function IncSecond(const AValue: TDateTime; const ANumberOfSeconds: Int64 = 1): TDateTime;
function IncMilliSecond(const AValue: TDateTime; const ANumberOfMilliSeconds: Int64 = 1): TDateTime;

{ Recode helpers }

function RecodeYear(const AValue: TDateTime; const AYear: Word): TDateTime;
function RecodeMonth(const AValue: TDateTime; const AMonth: Word): TDateTime;
function RecodeDay(const AValue: TDateTime; const ADay: Word): TDateTime;
function RecodeHour(const AValue: TDateTime; const AHour: Word): TDateTime;
function RecodeMinute(const AValue: TDateTime; const AMinute: Word): TDateTime;
function RecodeSecond(const AValue: TDateTime; const ASecond: Word): TDateTime;
function RecodeMilliSecond(const AValue: TDateTime; const AMilliSecond: Word): TDateTime;
function RecodeDate(const AValue: TDateTime; const AYear, AMonth, ADay: Word): TDateTime;
function RecodeTime(const AValue: TDateTime; const AHour, AMinute, ASecond, AMilliSecond: Word): TDateTime;
function RecodeDateTime(const AValue: TDateTime; const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word): TDateTime;
function TryRecodeDateTime(const AValue: TDateTime; const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word; out AResult: TDateTime): Boolean;

{ Comparison }

function SameDateTime(const A, B: TDateTime): Boolean;
function SameDate(const A, B: TDateTime): Boolean;
function SameTime(const A, B: TDateTime): Boolean;
function CompareDateTime(const A, B: TDateTime): TValueRelationship;
function CompareDate(const A, B: TDateTime): TValueRelationship;
function CompareTime(const A, B: TDateTime): TValueRelationship;

{ Difference and span }

function YearsBetween(const ANow, AThen: TDateTime): Integer;
function MonthsBetween(const ANow, AThen: TDateTime): Integer;
function WeeksBetween(const ANow, AThen: TDateTime): Integer;
function DaysBetween(const ANow, AThen: TDateTime): Integer;
function HoursBetween(const ANow, AThen: TDateTime): Int64;
function MinutesBetween(const ANow, AThen: TDateTime): Int64;
function SecondsBetween(const ANow, AThen: TDateTime): Int64;
function MilliSecondsBetween(const ANow, AThen: TDateTime): Int64;

function YearSpan(const ANow, AThen: TDateTime): Double;
function MonthSpan(const ANow, AThen: TDateTime): Double;
function WeekSpan(const ANow, AThen: TDateTime): Double;
function DaySpan(const ANow, AThen: TDateTime): Double;
function HourSpan(const ANow, AThen: TDateTime): Double;
function MinuteSpan(const ANow, AThen: TDateTime): Double;
function SecondSpan(const ANow, AThen: TDateTime): Double;
function MilliSecondSpan(const ANow, AThen: TDateTime): Double;

function WithinPastYears(const ANow, AThen: TDateTime; const AYears: Integer): Boolean;
function WithinPastMonths(const ANow, AThen: TDateTime; const AMonths: Integer): Boolean;
function WithinPastWeeks(const ANow, AThen: TDateTime; const AWeeks: Integer): Boolean;
function WithinPastDays(const ANow, AThen: TDateTime; const ADays: Integer): Boolean;
function WithinPastHours(const ANow, AThen: TDateTime; const AHours: Int64): Boolean;
function WithinPastMinutes(const ANow, AThen: TDateTime; const AMinutes: Int64): Boolean;
function WithinPastSeconds(const ANow, AThen: TDateTime; const ASeconds: Int64): Boolean;
function WithinPastMilliSeconds(const ANow, AThen: TDateTime; const AMilliSeconds: Int64): Boolean;

{ Validation }

function IsValidDate(const AYear, AMonth, ADay: Word): Boolean;
function IsValidDateDay(const AYear, ADayOfYear: Word): Boolean;
function IsValidDateWeek(const AYear, AWeekOfYear, ADayOfWeek: Word): Boolean;
function IsValidDateMonthWeek(const AYear, AMonth, AWeekOfMonth, ADayOfWeek: Word): Boolean;
function IsValidTime(const AHour, AMinute, ASecond, AMilliSecond: Word): Boolean;
function IsValidDateTime(const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word): Boolean;

{ Julian, Unix and ISO-8601 conversion }

function DateTimeToJulianDate(const AValue: TDateTime): Double;
function JulianDateToDateTime(const AValue: Double): TDateTime;
function TryJulianDateToDateTime(const AValue: Double; out ADateTime: TDateTime): Boolean;
function DateTimeToModifiedJulianDate(const AValue: TDateTime): Double;
function ModifiedJulianDateToDateTime(const AValue: Double): TDateTime;
function TryModifiedJulianDateToDateTime(const AValue: Double; out ADateTime: TDateTime): Boolean;

function DateTimeToUnix(const AValue: TDateTime; AInputIsUTC: Boolean = True): Int64;
function UnixToDateTime(const AValue: Int64; AReturnUTC: Boolean = True): TDateTime;

function DateToISO8601(const ADate: TDateTime; AInputIsUTC: Boolean = True): string;
function ISO8601ToDate(const AISODate: string; AReturnUTC: Boolean = True): TDateTime; overload;
function ISO8601ToDate(const AISODate: string; AOptions: TISO8601ToDateOptions): TDateTime; overload;

implementation

function DateOf(const AValue: TDateTime): TDateTime; begin end;
function TimeOf(const AValue: TDateTime): TDateTime; begin end;
function IsInLeapYear(const AValue: TDateTime): Boolean; begin end;
function IsPM(const AValue: TDateTime): Boolean; begin end;
function IsAM(const AValue: TDateTime): Boolean; begin end;
function IsToday(const AValue: TDateTime): Boolean; begin end;
function IsSameDay(const AValue, ABasis: TDateTime): Boolean; begin end;
function IsSameMonth(const AValue, ABasis: TDateTime): Boolean; begin end;
function YearOf(const AValue: TDateTime): Word; begin end;
function MonthOf(const AValue: TDateTime): Word; begin end;
function WeekOf(const AValue: TDateTime): Word; begin end;
function DayOf(const AValue: TDateTime): Word; begin end;
function HourOf(const AValue: TDateTime): Word; begin end;
function MinuteOf(const AValue: TDateTime): Word; begin end;
function SecondOf(const AValue: TDateTime): Word; begin end;
function MilliSecondOf(const AValue: TDateTime): Word; begin end;
function WeekOfTheYear(const AValue: TDateTime): Word; begin end;
function WeekOfTheYear(const AValue: TDateTime; var AYear: Word): Word; begin end;
function MonthOfTheYear(const AValue: TDateTime): Word; begin end;
function DayOfTheYear(const AValue: TDateTime): Word; begin end;
function DayOfTheMonth(const AValue: TDateTime): Word; begin end;
function DayOfTheWeek(const AValue: TDateTime): Word; begin end;
function WeekOfTheMonth(const AValue: TDateTime): Word; begin end;
function NthDayOfWeek(const AValue: TDateTime): Word; begin end;
function HourOfTheYear(const AValue: TDateTime): Word; begin end;
function HourOfTheMonth(const AValue: TDateTime): Word; begin end;
function HourOfTheWeek(const AValue: TDateTime): Word; begin end;
function HourOfTheDay(const AValue: TDateTime): Word; begin end;
function MinuteOfTheYear(const AValue: TDateTime): Cardinal; begin end;
function MinuteOfTheMonth(const AValue: TDateTime): Word; begin end;
function MinuteOfTheWeek(const AValue: TDateTime): Word; begin end;
function MinuteOfTheDay(const AValue: TDateTime): Word; begin end;
function MinuteOfTheHour(const AValue: TDateTime): Word; begin end;
function SecondOfTheYear(const AValue: TDateTime): Cardinal; begin end;
function SecondOfTheMonth(const AValue: TDateTime): Cardinal; begin end;
function SecondOfTheWeek(const AValue: TDateTime): Cardinal; begin end;
function SecondOfTheDay(const AValue: TDateTime): Cardinal; begin end;
function SecondOfTheHour(const AValue: TDateTime): Word; begin end;
function SecondOfTheMinute(const AValue: TDateTime): Word; begin end;
function MilliSecondOfTheYear(const AValue: TDateTime): Int64; begin end;
function MilliSecondOfTheMonth(const AValue: TDateTime): Cardinal; begin end;
function MilliSecondOfTheWeek(const AValue: TDateTime): Cardinal; begin end;
function MilliSecondOfTheDay(const AValue: TDateTime): Cardinal; begin end;
function MilliSecondOfTheHour(const AValue: TDateTime): Cardinal; begin end;
function MilliSecondOfTheMinute(const AValue: TDateTime): Word; begin end;
function MilliSecondOfTheSecond(const AValue: TDateTime): Word; begin end;
function WeeksInAYear(const AYear: Word): Word; begin end;
function WeeksInYear(const AValue: TDateTime): Word; begin end;
function DaysInAYear(const AYear: Word): Word; begin end;
function DaysInYear(const AValue: TDateTime): Word; begin end;
function DaysInAMonth(const AYear, AMonth: Word): Word; begin end;
function DaysInMonth(const AValue: TDateTime): Word; begin end;
function EncodeDateDay(const AYear, ADayOfYear: Word): TDateTime; begin end;
function TryEncodeDateDay(const AYear, ADayOfYear: Word; out AValue: TDateTime): Boolean; begin end;
procedure DecodeDateDay(const AValue: TDateTime; out AYear, ADayOfYear: Word); begin end;
function EncodeDateWeek(const AYear, AWeekOfYear: Word; const ADayOfWeek: Word = 1): TDateTime; begin end;
function TryEncodeDateWeek(const AYear, AWeekOfYear: Word; out AValue: TDateTime; const ADayOfWeek: Word = 1): Boolean; begin end;
procedure DecodeDateWeek(const AValue: TDateTime; out AYear, AWeekOfYear, ADayOfWeek: Word); begin end;
function EncodeDateMonthWeek(const AYear, AMonth, AWeekOfMonth, ADayOfWeek: Word): TDateTime; begin end;
function TryEncodeDateMonthWeek(const AYear, AMonth, AWeekOfMonth, ADayOfWeek: Word; out AValue: TDateTime): Boolean; begin end;
procedure DecodeDateMonthWeek(const AValue: TDateTime; out AYear, AMonth, AWeekOfMonth, ADayOfWeek: Word); begin end;
function EncodeDayOfWeekInMonth(const AYear, AMonth, ANthDayOfWeek, ADayOfWeek: Word): TDateTime; begin end;
function TryEncodeDayOfWeekInMonth(const AYear, AMonth, ANthDayOfWeek, ADayOfWeek: Word; out AValue: TDateTime): Boolean; begin end;
procedure DecodeDayOfWeekInMonth(const AValue: TDateTime; out AYear, AMonth, ANthDayOfWeek, ADayOfWeek: Word); begin end;
function EncodeDateTime(const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word): TDateTime; begin end;
function TryEncodeDateTime(const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word; out AValue: TDateTime): Boolean; begin end;
procedure DecodeDateTime(const AValue: TDateTime; out AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word); begin end;
function StartOfTheYear(const AValue: TDateTime): TDateTime; begin end;
function EndOfTheYear(const AValue: TDateTime): TDateTime; begin end;
function StartOfAYear(const AYear: Word): TDateTime; begin end;
function EndOfAYear(const AYear: Word): TDateTime; begin end;
function StartOfTheMonth(const AValue: TDateTime): TDateTime; begin end;
function EndOfTheMonth(const AValue: TDateTime): TDateTime; begin end;
function StartOfAMonth(const AYear, AMonth: Word): TDateTime; begin end;
function EndOfAMonth(const AYear, AMonth: Word): TDateTime; begin end;
function StartOfTheWeek(const AValue: TDateTime): TDateTime; begin end;
function EndOfTheWeek(const AValue: TDateTime): TDateTime; begin end;
function StartOfAWeek(const AYear, AWeekOfYear: Word; const ADayOfWeek: Word = 1): TDateTime; begin end;
function EndOfAWeek(const AYear, AWeekOfYear: Word; const ADayOfWeek: Word = 7): TDateTime; begin end;
function StartOfTheDay(const AValue: TDateTime): TDateTime; begin end;
function EndOfTheDay(const AValue: TDateTime): TDateTime; begin end;
function StartOfADay(const AYear, AMonth, ADay: Word): TDateTime; begin end;
function StartOfADay(const AYear, ADayOfYear: Word): TDateTime; begin end;
function EndOfADay(const AYear, AMonth, ADay: Word): TDateTime; begin end;
function EndOfADay(const AYear, ADayOfYear: Word): TDateTime; begin end;
function Today: TDateTime; begin end;
function Yesterday: TDateTime; begin end;
function Tomorrow: TDateTime; begin end;
function IncYear(const AValue: TDateTime; const ANumberOfYears: Integer = 1): TDateTime; begin end;
function IncWeek(const AValue: TDateTime; const ANumberOfWeeks: Integer = 1): TDateTime; begin end;
function IncDay(const AValue: TDateTime; const ANumberOfDays: Integer = 1): TDateTime; begin end;
function IncHour(const AValue: TDateTime; const ANumberOfHours: Int64 = 1): TDateTime; begin end;
function IncMinute(const AValue: TDateTime; const ANumberOfMinutes: Int64 = 1): TDateTime; begin end;
function IncSecond(const AValue: TDateTime; const ANumberOfSeconds: Int64 = 1): TDateTime; begin end;
function IncMilliSecond(const AValue: TDateTime; const ANumberOfMilliSeconds: Int64 = 1): TDateTime; begin end;
function RecodeYear(const AValue: TDateTime; const AYear: Word): TDateTime; begin end;
function RecodeMonth(const AValue: TDateTime; const AMonth: Word): TDateTime; begin end;
function RecodeDay(const AValue: TDateTime; const ADay: Word): TDateTime; begin end;
function RecodeHour(const AValue: TDateTime; const AHour: Word): TDateTime; begin end;
function RecodeMinute(const AValue: TDateTime; const AMinute: Word): TDateTime; begin end;
function RecodeSecond(const AValue: TDateTime; const ASecond: Word): TDateTime; begin end;
function RecodeMilliSecond(const AValue: TDateTime; const AMilliSecond: Word): TDateTime; begin end;
function RecodeDate(const AValue: TDateTime; const AYear, AMonth, ADay: Word): TDateTime; begin end;
function RecodeTime(const AValue: TDateTime; const AHour, AMinute, ASecond, AMilliSecond: Word): TDateTime; begin end;
function RecodeDateTime(const AValue: TDateTime; const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word): TDateTime; begin end;
function TryRecodeDateTime(const AValue: TDateTime; const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word; out AResult: TDateTime): Boolean; begin end;
function SameDateTime(const A, B: TDateTime): Boolean; begin end;
function SameDate(const A, B: TDateTime): Boolean; begin end;
function SameTime(const A, B: TDateTime): Boolean; begin end;
function CompareDateTime(const A, B: TDateTime): TValueRelationship; begin end;
function CompareDate(const A, B: TDateTime): TValueRelationship; begin end;
function CompareTime(const A, B: TDateTime): TValueRelationship; begin end;
function YearsBetween(const ANow, AThen: TDateTime): Integer; begin end;
function MonthsBetween(const ANow, AThen: TDateTime): Integer; begin end;
function WeeksBetween(const ANow, AThen: TDateTime): Integer; begin end;
function DaysBetween(const ANow, AThen: TDateTime): Integer; begin end;
function HoursBetween(const ANow, AThen: TDateTime): Int64; begin end;
function MinutesBetween(const ANow, AThen: TDateTime): Int64; begin end;
function SecondsBetween(const ANow, AThen: TDateTime): Int64; begin end;
function MilliSecondsBetween(const ANow, AThen: TDateTime): Int64; begin end;
function YearSpan(const ANow, AThen: TDateTime): Double; begin end;
function MonthSpan(const ANow, AThen: TDateTime): Double; begin end;
function WeekSpan(const ANow, AThen: TDateTime): Double; begin end;
function DaySpan(const ANow, AThen: TDateTime): Double; begin end;
function HourSpan(const ANow, AThen: TDateTime): Double; begin end;
function MinuteSpan(const ANow, AThen: TDateTime): Double; begin end;
function SecondSpan(const ANow, AThen: TDateTime): Double; begin end;
function MilliSecondSpan(const ANow, AThen: TDateTime): Double; begin end;
function WithinPastYears(const ANow, AThen: TDateTime; const AYears: Integer): Boolean; begin end;
function WithinPastMonths(const ANow, AThen: TDateTime; const AMonths: Integer): Boolean; begin end;
function WithinPastWeeks(const ANow, AThen: TDateTime; const AWeeks: Integer): Boolean; begin end;
function WithinPastDays(const ANow, AThen: TDateTime; const ADays: Integer): Boolean; begin end;
function WithinPastHours(const ANow, AThen: TDateTime; const AHours: Int64): Boolean; begin end;
function WithinPastMinutes(const ANow, AThen: TDateTime; const AMinutes: Int64): Boolean; begin end;
function WithinPastSeconds(const ANow, AThen: TDateTime; const ASeconds: Int64): Boolean; begin end;
function WithinPastMilliSeconds(const ANow, AThen: TDateTime; const AMilliSeconds: Int64): Boolean; begin end;
function IsValidDate(const AYear, AMonth, ADay: Word): Boolean; begin end;
function IsValidDateDay(const AYear, ADayOfYear: Word): Boolean; begin end;
function IsValidDateWeek(const AYear, AWeekOfYear, ADayOfWeek: Word): Boolean; begin end;
function IsValidDateMonthWeek(const AYear, AMonth, AWeekOfMonth, ADayOfWeek: Word): Boolean; begin end;
function IsValidTime(const AHour, AMinute, ASecond, AMilliSecond: Word): Boolean; begin end;
function IsValidDateTime(const AYear, AMonth, ADay, AHour, AMinute, ASecond, AMilliSecond: Word): Boolean; begin end;
function DateTimeToJulianDate(const AValue: TDateTime): Double; begin end;
function JulianDateToDateTime(const AValue: Double): TDateTime; begin end;
function TryJulianDateToDateTime(const AValue: Double; out ADateTime: TDateTime): Boolean; begin end;
function DateTimeToModifiedJulianDate(const AValue: TDateTime): Double; begin end;
function ModifiedJulianDateToDateTime(const AValue: Double): TDateTime; begin end;
function TryModifiedJulianDateToDateTime(const AValue: Double; out ADateTime: TDateTime): Boolean; begin end;
function DateTimeToUnix(const AValue: TDateTime; AInputIsUTC: Boolean = True): Int64; begin end;
function UnixToDateTime(const AValue: Int64; AReturnUTC: Boolean = True): TDateTime; begin end;
function DateToISO8601(const ADate: TDateTime; AInputIsUTC: Boolean = True): string; begin end;
function ISO8601ToDate(const AISODate: string; AReturnUTC: Boolean = True): TDateTime; begin end;
function ISO8601ToDate(const AISODate: string; AOptions: TISO8601ToDateOptions): TDateTime; begin end;

end.
