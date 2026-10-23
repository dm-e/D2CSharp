using System.Sysutils;
using System.Types;
using System;
using static System.Dateutils.DateutilsImplementation;
using static System.Dateutils.DateutilsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;
using static System.Types.TypesInterface;

namespace System
{

namespace Dateutils
{

/*
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
*/


public class DateutilsInterface
{

	public class EDateTimeException : DException
	{


		public EDateTimeException(string Msg) : base(Msg) {}
		public EDateTimeException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EDateTimeException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EDateTimeException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EDateTimeException(uint Ident) : base(Ident) {}
		public EDateTimeException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EDateTimeException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EDateTimeException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EDateTimeException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EDateTimeException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EDateTimeException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EDateTimeException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

/* Basic extraction */
  /* Calendar constants */
	public const int DaysPerWeek = 7;
	public const int WeeksPerFortnight = 2;
	public const int MonthsPerYear = 12;
	public const int YearsPerDecade = 10;
	public const int YearsPerCentury = 100;
	public const int YearsPerMillennium = 1000;
	public const int HoursPerDay = 24;
	public const int MinsPerHour = 60;
	public const int SecsPerMin = 60;
	public const int MSecsPerSec = 1000;
	public const int MinsPerDay = HoursPerDay * MinsPerHour;
	public const int SecsPerHour = MinsPerHour * SecsPerMin;
	public const int SecsPerDay = MinsPerDay * SecsPerMin;
	public const int MSecsPerMin = SecsPerMin * MSecsPerSec;
	public const int MSecsPerHour = SecsPerHour * MSecsPerSec;
	public const int MSecsPerDay = SecsPerDay * MSecsPerSec;
	public const int DaysPerYear = 365;
	public const double ApproxDaysPerMonth = 30.4375D;
	public const double ApproxDaysPerYear = 365.25D;
	public const double OneHour = (double)1 / HoursPerDay;
	public const double OneMinute = (double)1 / MinsPerDay;
	public const double OneSecond = (double)1 / SecsPerDay;
	public const double OneMillisecond = (double)1 / MSecsPerDay;
	public const int RecodeLeaveFieldAsIs = 65535;

  /* ISO weekday numbers used by DateUtils. */
	public const int DayMonday = 1;
	public const int DayTuesday = 2;
	public const int DayWednesday = 3;
	public const int DayThursday = 4;
	public const int DayFriday = 5;
	public const int DaySaturday = 6;
	public const int DaySunday = 7;
	public const int MonthJanuary = 1;
	public const int MonthFebruary = 2;
	public const int MonthMarch = 3;
	public const int MonthApril = 4;
	public const int MonthMay = 5;
	public const int MonthJune = 6;
	public const int MonthJuly = 7;
	public const int MonthAugust = 8;
	public const int MonthSeptember = 9;
	public const int MonthOctober = 10;
	public const int MonthNovember = 11;
	public const int MonthDecember = 12;
  /* Public DateUtils helper types used by common APIs. */
	public enum TDateTimePart {dtpYear,
                    dtpMonth,
                    dtpWeek,
                    dtpDay,
                    dtpHour,
                    dtpMinute,
                    dtpSecond,
                    dtpMilliSecond };
	public enum TISO8601ToDateOption {ioReturnUTC,
                           ioNoTZIsLocal };


/* Basic extraction */
	public static TDateTime DateOf(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime TimeOf(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool IsInLeapYear(TDateTime AValue)
	{
		bool result = false;
		return result;
	}
	public static bool IsPM(TDateTime AValue)
	{
		bool result = false;
		return result;
	}
	public static bool IsAM(TDateTime AValue)
	{
		bool result = false;
		return result;
	}
	public static bool IsToday(TDateTime AValue)
	{
		bool result = false;
		return result;
	}
	public static bool IsSameDay(TDateTime AValue, TDateTime ABasis)
	{
		bool result = false;
		return result;
	}
	public static bool IsSameMonth(TDateTime AValue, TDateTime ABasis)
	{
		bool result = false;
		return result;
	}
	public static ushort YearOf(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort MonthOf(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort WeekOf(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort DayOf(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort HourOf(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort MinuteOf(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort SecondOf(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort MilliSecondOf(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort WeekOfTheYear(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort WeekOfTheYear(TDateTime AValue, ref ushort AYear)
	{
		ushort result = 0;
		return result;
	}
	public static ushort MonthOfTheYear(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort DayOfTheYear(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort DayOfTheMonth(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort DayOfTheWeek(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort WeekOfTheMonth(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort NthDayOfWeek(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort HourOfTheYear(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort HourOfTheMonth(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort HourOfTheWeek(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort HourOfTheDay(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static uint MinuteOfTheYear(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static ushort MinuteOfTheMonth(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort MinuteOfTheWeek(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort MinuteOfTheDay(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort MinuteOfTheHour(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static uint SecondOfTheYear(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static uint SecondOfTheMonth(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static uint SecondOfTheWeek(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static uint SecondOfTheDay(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static ushort SecondOfTheHour(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort SecondOfTheMinute(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static long MilliSecondOfTheYear(TDateTime AValue)
	{
		long result = 0;
		return result;
	}
	public static uint MilliSecondOfTheMonth(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static uint MilliSecondOfTheWeek(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static uint MilliSecondOfTheDay(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static uint MilliSecondOfTheHour(TDateTime AValue)
	{
		uint result = 0;
		return result;
	}
	public static ushort MilliSecondOfTheMinute(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort MilliSecondOfTheSecond(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}

/* Calendar size */
	public static ushort WeeksInAYear(ushort AYear)
	{
		ushort result = 0;
		return result;
	}
	public static ushort WeeksInYear(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort DaysInAYear(ushort AYear)
	{
		ushort result = 0;
		return result;
	}
	public static ushort DaysInYear(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}
	public static ushort DaysInAMonth(ushort AYear, ushort AMonth)
	{
		ushort result = 0;
		return result;
	}
	public static ushort DaysInMonth(TDateTime AValue)
	{
		ushort result = 0;
		return result;
	}

/* Encoding and decoding */
	public static TDateTime EncodeDateDay(ushort AYear, ushort ADayOfYear)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryEncodeDateDay(ushort AYear, ushort ADayOfYear, out TDateTime AValue)
	{
		AValue = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static void DecodeDateDay(TDateTime AValue, out ushort AYear, out ushort ADayOfYear)
	{
		AYear = 0; //# clear out parameter
		ADayOfYear = 0; //# clear out parameter
	}
	public static TDateTime EncodeDateWeek(ushort AYear, ushort AWeekOfYear, ushort ADayOfWeek = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryEncodeDateWeek(ushort AYear, ushort AWeekOfYear, out TDateTime AValue, ushort ADayOfWeek = 1)
	{
		AValue = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static void DecodeDateWeek(TDateTime AValue, out ushort AYear, out ushort AWeekOfYear, out ushort ADayOfWeek)
	{
		AYear = 0; //# clear out parameter
		AWeekOfYear = 0; //# clear out parameter
		ADayOfWeek = 0; //# clear out parameter
	}
	public static TDateTime EncodeDateMonthWeek(ushort AYear, ushort AMonth, ushort AWeekOfMonth, ushort ADayOfWeek)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryEncodeDateMonthWeek(ushort AYear, ushort AMonth, ushort AWeekOfMonth, ushort ADayOfWeek, out TDateTime AValue)
	{
		AValue = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static void DecodeDateMonthWeek(TDateTime AValue, out ushort AYear, out ushort AMonth, out ushort AWeekOfMonth, out ushort ADayOfWeek)
	{
		AYear = 0; //# clear out parameter
		AMonth = 0; //# clear out parameter
		AWeekOfMonth = 0; //# clear out parameter
		ADayOfWeek = 0; //# clear out parameter
	}
	public static TDateTime EncodeDayOfWeekInMonth(ushort AYear, ushort AMonth, ushort ANthDayOfWeek, ushort ADayOfWeek)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryEncodeDayOfWeekInMonth(ushort AYear, ushort AMonth, ushort ANthDayOfWeek, ushort ADayOfWeek, out TDateTime AValue)
	{
		AValue = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static void DecodeDayOfWeekInMonth(TDateTime AValue, out ushort AYear, out ushort AMonth, out ushort ANthDayOfWeek, out ushort ADayOfWeek)
	{
		AYear = 0; //# clear out parameter
		AMonth = 0; //# clear out parameter
		ANthDayOfWeek = 0; //# clear out parameter
		ADayOfWeek = 0; //# clear out parameter
	}
	public static TDateTime EncodeDateTime(ushort AYear, ushort AMonth, ushort ADay, ushort AHour, ushort AMinute, ushort ASecond, ushort AMilliSecond)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryEncodeDateTime(ushort AYear, ushort AMonth, ushort ADay, ushort AHour, ushort AMinute, ushort ASecond, ushort AMilliSecond, out TDateTime AValue)
	{
		AValue = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static void DecodeDateTime(TDateTime AValue, out ushort AYear, out ushort AMonth, out ushort ADay, out ushort AHour, out ushort AMinute, out ushort ASecond, out ushort AMilliSecond)
	{
		AYear = 0; //# clear out parameter
		AMonth = 0; //# clear out parameter
		ADay = 0; //# clear out parameter
		AHour = 0; //# clear out parameter
		AMinute = 0; //# clear out parameter
		ASecond = 0; //# clear out parameter
		AMilliSecond = 0; //# clear out parameter
	}

/* Beginning/end helpers */
	public static TDateTime StartOfTheYear(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfTheYear(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StartOfAYear(ushort AYear)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfAYear(ushort AYear)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StartOfTheMonth(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfTheMonth(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StartOfAMonth(ushort AYear, ushort AMonth)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfAMonth(ushort AYear, ushort AMonth)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StartOfTheWeek(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfTheWeek(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StartOfAWeek(ushort AYear, ushort AWeekOfYear, ushort ADayOfWeek = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfAWeek(ushort AYear, ushort AWeekOfYear, ushort ADayOfWeek = 7)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StartOfTheDay(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfTheDay(TDateTime AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StartOfADay(ushort AYear, ushort AMonth, ushort ADay)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StartOfADay(ushort AYear, ushort ADayOfYear)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfADay(ushort AYear, ushort AMonth, ushort ADay)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime EndOfADay(ushort AYear, ushort ADayOfYear)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime Today()
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime Yesterday()
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime Tomorrow()
	{
		TDateTime result = new TDateTime();
		return result;
	}

/* Increment helpers */
	public static TDateTime IncYear(TDateTime AValue, int ANumberOfYears = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime IncWeek(TDateTime AValue, int ANumberOfWeeks = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime IncDay(TDateTime AValue, int ANumberOfDays = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime IncHour(TDateTime AValue, long ANumberOfHours = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime IncMinute(TDateTime AValue, long ANumberOfMinutes = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime IncSecond(TDateTime AValue, long ANumberOfSeconds = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime IncMilliSecond(TDateTime AValue, long ANumberOfMilliSeconds = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}

/* Recode helpers */
	public static TDateTime RecodeYear(TDateTime AValue, ushort AYear)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeMonth(TDateTime AValue, ushort AMonth)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeDay(TDateTime AValue, ushort ADay)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeHour(TDateTime AValue, ushort AHour)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeMinute(TDateTime AValue, ushort AMinute)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeSecond(TDateTime AValue, ushort ASecond)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeMilliSecond(TDateTime AValue, ushort AMilliSecond)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeDate(TDateTime AValue, ushort AYear, ushort AMonth, ushort ADay)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeTime(TDateTime AValue, ushort AHour, ushort AMinute, ushort ASecond, ushort AMilliSecond)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime RecodeDateTime(TDateTime AValue, ushort AYear, ushort AMonth, ushort ADay, ushort AHour, ushort AMinute, ushort ASecond, ushort AMilliSecond)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryRecodeDateTime(TDateTime AValue, ushort AYear, ushort AMonth, ushort ADay, ushort AHour, ushort AMinute, ushort ASecond, ushort AMilliSecond, out TDateTime AResult)
	{
		AResult = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}

/* Comparison */
	public static bool SameDateTime(TDateTime A, TDateTime B)
	{
		bool result = false;
		return result;
	}
	public static bool SameDate(TDateTime A, TDateTime B)
	{
		bool result = false;
		return result;
	}
	public static bool SameTime(TDateTime A, TDateTime B)
	{
		bool result = false;
		return result;
	}
	public static int /*-1..1*/ CompareDateTime(TDateTime A, TDateTime B)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ CompareDate(TDateTime A, TDateTime B)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ CompareTime(TDateTime A, TDateTime B)
	{
		int /*-1..1*/ result = 0;
		return result;
	}

/* Difference and span */
	public static int YearsBetween(TDateTime ANow, TDateTime AThen)
	{
		int result = 0;
		return result;
	}
	public static int MonthsBetween(TDateTime ANow, TDateTime AThen)
	{
		int result = 0;
		return result;
	}
	public static int WeeksBetween(TDateTime ANow, TDateTime AThen)
	{
		int result = 0;
		return result;
	}
	public static int DaysBetween(TDateTime ANow, TDateTime AThen)
	{
		int result = 0;
		return result;
	}
	public static long HoursBetween(TDateTime ANow, TDateTime AThen)
	{
		long result = 0;
		return result;
	}
	public static long MinutesBetween(TDateTime ANow, TDateTime AThen)
	{
		long result = 0;
		return result;
	}
	public static long SecondsBetween(TDateTime ANow, TDateTime AThen)
	{
		long result = 0;
		return result;
	}
	public static long MilliSecondsBetween(TDateTime ANow, TDateTime AThen)
	{
		long result = 0;
		return result;
	}
	public static double YearSpan(TDateTime ANow, TDateTime AThen)
	{
		double result = 0.0D;
		return result;
	}
	public static double MonthSpan(TDateTime ANow, TDateTime AThen)
	{
		double result = 0.0D;
		return result;
	}
	public static double WeekSpan(TDateTime ANow, TDateTime AThen)
	{
		double result = 0.0D;
		return result;
	}
	public static double DaySpan(TDateTime ANow, TDateTime AThen)
	{
		double result = 0.0D;
		return result;
	}
	public static double HourSpan(TDateTime ANow, TDateTime AThen)
	{
		double result = 0.0D;
		return result;
	}
	public static double MinuteSpan(TDateTime ANow, TDateTime AThen)
	{
		double result = 0.0D;
		return result;
	}
	public static double SecondSpan(TDateTime ANow, TDateTime AThen)
	{
		double result = 0.0D;
		return result;
	}
	public static double MilliSecondSpan(TDateTime ANow, TDateTime AThen)
	{
		double result = 0.0D;
		return result;
	}
	public static bool WithinPastYears(TDateTime ANow, TDateTime AThen, int AYears)
	{
		bool result = false;
		return result;
	}
	public static bool WithinPastMonths(TDateTime ANow, TDateTime AThen, int AMonths)
	{
		bool result = false;
		return result;
	}
	public static bool WithinPastWeeks(TDateTime ANow, TDateTime AThen, int AWeeks)
	{
		bool result = false;
		return result;
	}
	public static bool WithinPastDays(TDateTime ANow, TDateTime AThen, int ADays)
	{
		bool result = false;
		return result;
	}
	public static bool WithinPastHours(TDateTime ANow, TDateTime AThen, long AHours)
	{
		bool result = false;
		return result;
	}
	public static bool WithinPastMinutes(TDateTime ANow, TDateTime AThen, long AMinutes)
	{
		bool result = false;
		return result;
	}
	public static bool WithinPastSeconds(TDateTime ANow, TDateTime AThen, long ASeconds)
	{
		bool result = false;
		return result;
	}
	public static bool WithinPastMilliSeconds(TDateTime ANow, TDateTime AThen, long AMilliSeconds)
	{
		bool result = false;
		return result;
	}

/* Validation */
	public static bool IsValidDate(ushort AYear, ushort AMonth, ushort ADay)
	{
		bool result = false;
		return result;
	}
	public static bool IsValidDateDay(ushort AYear, ushort ADayOfYear)
	{
		bool result = false;
		return result;
	}
	public static bool IsValidDateWeek(ushort AYear, ushort AWeekOfYear, ushort ADayOfWeek)
	{
		bool result = false;
		return result;
	}
	public static bool IsValidDateMonthWeek(ushort AYear, ushort AMonth, ushort AWeekOfMonth, ushort ADayOfWeek)
	{
		bool result = false;
		return result;
	}
	public static bool IsValidTime(ushort AHour, ushort AMinute, ushort ASecond, ushort AMilliSecond)
	{
		bool result = false;
		return result;
	}
	public static bool IsValidDateTime(ushort AYear, ushort AMonth, ushort ADay, ushort AHour, ushort AMinute, ushort ASecond, ushort AMilliSecond)
	{
		bool result = false;
		return result;
	}

/* Julian, Unix and ISO-8601 conversion */
	public static double DateTimeToJulianDate(TDateTime AValue)
	{
		double result = 0.0D;
		return result;
	}
	public static TDateTime JulianDateToDateTime(double AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryJulianDateToDateTime(double AValue, out TDateTime ADateTime)
	{
		ADateTime = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static double DateTimeToModifiedJulianDate(TDateTime AValue)
	{
		double result = 0.0D;
		return result;
	}
	public static TDateTime ModifiedJulianDateToDateTime(double AValue)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryModifiedJulianDateToDateTime(double AValue, out TDateTime ADateTime)
	{
		ADateTime = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static long DateTimeToUnix(TDateTime AValue, bool AInputIsUTC = true)
	{
		long result = 0;
		return result;
	}
	public static TDateTime UnixToDateTime(long AValue, bool AReturnUTC = true)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static string DateToISO8601(TDateTime ADate, bool AInputIsUTC = true)
	{
		string result = string.Empty;
		return result;
	}
	public static TDateTime ISO8601ToDate(string AISODate, bool AReturnUTC = true)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime ISO8601ToDate(string AISODate, TSet AOptions)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	
} // class DateutilsInterface


file class DateutilsImplementation
{

} // class DateutilsImplementation

}  // namespace Dateutils

}  // namespace System

