using System.Dateutils;
using System.Sysutils;
using System;
using static D7_datetime.D7_datetimeImplementation;
using static D7_datetime.D7_datetimeInterface;
using static System.Dateutils.DateutilsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_datetime
{

    /*
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
    */


    public class D7_datetimeInterface
    {
        public static bool RunDateTimeChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            CheckResult1 = CheckFileDateRoundTrip();
            CheckResult2 = CheckCalendarRules();
            CheckResult3 = CheckTimeStampConversions();
            result = CheckResult1;
            result = result && CheckResult2;
            result = result && CheckResult3;
            return result;
        }

    } // class D7_datetimeInterface


    file class D7_datetimeImplementation
    {


        public static bool CheckFileDateRoundTrip()
        {
            bool result = false;
            TextFile DataFile = TextFile.CreateRecord();
            string FileName = string.Empty;
            TDateTime DesiredDate = new TDateTime();
            TDateTime DecodedDate = new TDateTime();
            int FileStamp = 0;
            bool FileStampValid = false;
            bool FileDateSet = false;
            bool FileAgeValid = false;
            bool YearMatches = false;
            bool MonthMatches = false;
            bool DayMatches = false;
            bool HourMatches = false;
            bool MinuteMatches = false;
            bool SecondMatches = false;
            ushort Year = 0;
            ushort Month = 0;
            ushort Day = 0;
            ushort Hour = 0;
            ushort Minute = 0;
            ushort Second = 0;
            ushort Millisecond = 0;
            FileName = IncludeTrailingPathDelimiter(GetCurrentDir()) + "d7_filedate_probe.txt";
            AssignFile(DataFile, FileName);
            Rewrite(DataFile);
            try
            {
                WriteLn(DataFile, "timestamp probe");
            }
            finally
            {
                CloseFile(DataFile);
            }
            try
            {
                DesiredDate = EncodeDateTime(2022, 4, 15, 10, 20, 30, 0);
                FileStamp = DateTimeToFileDate(DesiredDate);
                FileStampValid = FileStamp != -1;
                result = FileStampValid;
                if (result)
                {
                    FileDateSet = FileSetDate(FileName, FileStamp) == 0;
                    result = FileDateSet;
                }
                if (result)
                {
                    FileStamp = FileAge(FileName);
                    FileAgeValid = FileStamp != -1;
                    result = FileAgeValid;
                }
                if (result)
                {
                    DecodedDate = FileDateToDateTime(FileStamp);
                    DecodeDateTime(DecodedDate, out Year, out Month, out Day, out Hour, out Minute, out Second, out Millisecond);
                    YearMatches = Year == 2022;
                    MonthMatches = Month == 4;
                    DayMatches = Day == 15;
                    HourMatches = Hour == 10;
                    MinuteMatches = Minute == 20;
                    SecondMatches = Second == 30;
                    result = YearMatches;
                    result = result && MonthMatches;
                    result = result && DayMatches;
                    result = result && HourMatches;
                    result = result && MinuteMatches;
                    result = result && SecondMatches;
                }
            }
            finally
            {
                if (FileExists(FileName))
                    DeleteFile(FileName);
            }
            return result;
        }

        public static bool CheckCalendarRules()
        {
            bool result = false;
            bool LeapYearFebruaryMatches = false;
            bool CenturyFebruaryMatches = false;
            bool AprilMatches = false;
            bool DecemberMatches = false;
            bool LeapYearMonthDaysMatches = false;
            bool NormalYearMonthDaysMatches = false;
            LeapYearFebruaryMatches = DaysInAMonth(2024, 2) == 29;
            CenturyFebruaryMatches = DaysInAMonth(2100, 2) == 28;
            AprilMatches = DaysInAMonth(2023, 4) == 30;
            DecemberMatches = DaysInAMonth(2023, 12) == 31;
            LeapYearMonthDaysMatches = MonthDays[Convert.ToInt32(true)[2] == 29;
            NormalYearMonthDaysMatches = MonthDays[Convert.ToInt32(false)[2] == 28;
            result = LeapYearFebruaryMatches;
            result = result && CenturyFebruaryMatches;
            result = result && AprilMatches;
            result = result && DecemberMatches;
            result = result && LeapYearMonthDaysMatches;
            result = result && NormalYearMonthDaysMatches;
            return result;
        }

        public static int ComposeTimePart(int AHour, int AMinute, int ASecond, int AMillisecond)
        {
            int result = 0;
            const int MillisecondsPerSecond = 1000;
            const int MillisecondsPerMinute = 60 * MillisecondsPerSecond;
            const int MillisecondsPerHour = 60 * MillisecondsPerMinute;
            int HourPart = 0;
            int MinutePart = 0;
            int SecondPart = 0;
            int MillisecondPart = 0;
            int HourAndMinutePart = 0;
            int HourMinuteAndSecondPart = 0;
            HourPart = AHour * MillisecondsPerHour;
            MinutePart = AMinute * MillisecondsPerMinute;
            SecondPart = ASecond * MillisecondsPerSecond;
            MillisecondPart = AMillisecond;
            HourAndMinutePart = HourPart + MinutePart;
            HourMinuteAndSecondPart = HourAndMinutePart + SecondPart;
            result = HourMinuteAndSecondPart + MillisecondPart;
            return result;
        }

        public static long ExpectedMilliseconds(TTimeStamp ATimeStamp)
        {
            long result = 0;
            long DatePart = 0;
            long TimePart = 0;
            long DatePartInMilliseconds = 0;
            DatePart = ATimeStamp.Date;
            TimePart = ATimeStamp.Time;
            DatePartInMilliseconds = DatePart * MSecsPerDay;
            result = DatePartInMilliseconds + TimePart;
            return result;
        }

        public static bool InvalidTimeStampRaises(int ADate, int ATime)
        {
            bool result = false;
            TTimeStamp TimeStamp = TTimeStamp.CreateRecord();
            long ConversionResult = 0;
            TimeStamp.Date = ADate;
            TimeStamp.Time = ATime;
            result = false;
            try
            {
                ConversionResult = TimeStampToMSecs(TimeStamp);
            }
            catch (EConvertError E)
            {
                result = true;
            }
            return result;
        }

        public static bool CheckTimeStampConversions()
        {
            bool result = false;
            TTimeStamp SourceStamp = TTimeStamp.CreateRecord();
            TTimeStamp ConvertedStamp = TTimeStamp.CreateRecord();
            long Milliseconds = 0;
            long ExpectedMillisecondsValue = 0;
            bool MillisecondsMatch = false;
            bool DateMatches = false;
            bool TimeMatches = false;
            bool InvalidZeroStampRaises = false;
            bool InvalidNegativeTimeRaises = false;
            bool InvalidFullDayTimeRaises = false;
            SourceStamp.Date = 51234;
            SourceStamp.Time = ComposeTimePart(21, 8, 7, 654);
            Milliseconds = TimeStampToMSecs(SourceStamp);
            ConvertedStamp = MSecsToTimeStamp(Milliseconds);
            ExpectedMillisecondsValue = ExpectedMilliseconds(SourceStamp);
            MillisecondsMatch = Milliseconds == ExpectedMillisecondsValue;
            DateMatches = ConvertedStamp.Date == SourceStamp.Date;
            TimeMatches = ConvertedStamp.Time == SourceStamp.Time;
            InvalidZeroStampRaises = InvalidTimeStampRaises(0, 0);
            InvalidNegativeTimeRaises = InvalidTimeStampRaises(3, -1);
            InvalidFullDayTimeRaises = InvalidTimeStampRaises(3, MSecsPerDay);
            result = MillisecondsMatch;
            result = result && DateMatches;
            result = result && TimeMatches;
            result = result && InvalidZeroStampRaises;
            result = result && InvalidNegativeTimeRaises;
            result = result && InvalidFullDayTimeRaises;
            return result;
        }
    } // class D7_datetimeImplementation

}  // namespace D7_datetime

