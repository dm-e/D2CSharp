using System.Sysutils;
using System.Timespan;
using System;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;
using static System.Timespan.TimespanInterface;
using static System_timespan.System_timespanImplementation;
using static System_timespan.System_timespanInterface;


namespace System_timespan
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


    public class System_timespanInterface
    {
        public static bool STS_RunAllTests()
        {
            bool result = false;
            result = true;
            result = result & STS_TestTickConstants();
            result = result & STS_TestZero();
            result = result & STS_TestMinMax();
            result = result & STS_TestCreateTicks();
            result = result & STS_TestCreateNegativeTicks();
            result = result & STS_TestCreateHMS();
            result = result & STS_TestCreateDHMS();
            result = result & STS_TestCreateDHMSM();
            result = result & STS_TestCreateNegativeHMS();
            result = result & STS_TestFromTicks();
            result = result & STS_TestFromMilliseconds();
            result = result & STS_TestFromSeconds();
            result = result & STS_TestFromMinutes();
            result = result & STS_TestFromHours();
            result = result & STS_TestFromDays();
            result = result & STS_TestFractionalDays();
            result = result & STS_TestFractionalHours();
            result = result & STS_TestFractionalMinutes();
            result = result & STS_TestFractionalSeconds();
            result = result & STS_TestDaysComponent();
            result = result & STS_TestHoursComponent();
            result = result & STS_TestMinutesComponent();
            result = result & STS_TestSecondsComponent();
            result = result & STS_TestMillisecondsComponent();
            result = result & STS_TestNegativeComponents();
            result = result & STS_TestTickPrecision();
            result = result & STS_TestTotalDays();
            result = result & STS_TestTotalHours();
            result = result & STS_TestTotalMinutes();
            result = result & STS_TestTotalSeconds();
            result = result & STS_TestTotalMilliseconds();
            result = result & STS_TestNegativeTotals();
            result = result & STS_TestAddMethod();
            result = result & STS_TestAddNegative();
            result = result & STS_TestSubtractMethod();
            result = result & STS_TestSubtractNegative();
            result = result & STS_TestDuration();
            result = result & STS_TestNegate();
            result = result & STS_TestOperatorAdd();
            result = result & STS_TestOperatorSubtract();
            result = result & STS_TestOperatorNegative();
            result = result & STS_TestOperatorPositive();
            result = result & STS_TestOperatorEqual();
            result = result & STS_TestOperatorNotEqual();
            result = result & STS_TestOperatorLessThan();
            result = result & STS_TestOperatorLessOrEqual();
            result = result & STS_TestOperatorGreaterThan();
            result = result & STS_TestOperatorGreaterOrEqual();
            result = result & STS_TestOperatorNegativeCompare();
            result = result & STS_TestAddDoesNotMutate();
            result = result & STS_TestToStringZero();
            result = result & STS_TestToStringHMS();
            result = result & STS_TestToStringDays();
            result = result & STS_TestToStringNegative();
            result = result & STS_TestParseHMS();
            result = result & STS_TestParseDays();
            result = result & STS_TestParseNegative();
            result = result & STS_TestParseFraction();
            result = result & STS_TestTryParseValid();
            result = result & STS_TestTryParseInvalid();
            result = result & STS_TestParseInvalidRaises();
            result = result & STS_TestToStringRoundTrip();
            result = result & STS_TestStringImplicit();
            result = result & STS_TestStringExplicit();
            result = result & STS_TestDateSubtractDays();
            result = result & STS_TestDateSubtractHours();
            result = result & STS_TestDateSubtractNegative();
            result = result & STS_TestDateAddSpanRight();
            result = result & STS_TestDateAddSpanLeft();
            result = result & STS_TestDateSubtractSpan();
            result = result & STS_TestDateCrossMidnight();
            result = result & STS_TestToStringFraction();
            result = result & STS_TestToStringOneTick();
            result = result & STS_TestParseZero();
            result = result & STS_TestParseOneTick();
            result = result & STS_TestTryParseOneTick();
            result = result & STS_TestFromTicksBoundaries();
            result = result & STS_TestOperatorDayCarry();
            result = result & STS_TestDateArithmeticRoundTrip();
            return result;
        }

    } // class System_timespanInterface


    file class System_timespanImplementation
    {


        // TTimeSpan.ToString is public starting with Delphi 10.1 Berlin.
        // For Delphi XE3, use the public implicit string conversion instead.
        // Delphi XE3: CompilerVersion = 24.0
        // Delphi 10.1 Berlin: CompilerVersion = 31.0

        public static string STS_TimeSpanText(TTimeSpan Value)
        {
            string result = string.Empty;
            result = Value;
            return result;
        }

        // All test functions are intentionally private to this unit.
        // Each test returns False on an exception or a wrong result.
        // Use tolerances only for floating-point results.

        public static bool STS_Close(double A, double B, double Tolerance)
        {
            bool result = false;
            result = Abs(A - B) <= Tolerance;
            return result;
        }

        public static bool STS_TestTickConstants()
        {
            bool result = false;
            try
            {
                result = TTimeSpan.TicksPerMillisecond == 10000;
                result = result && (TTimeSpan.TicksPerSecond == 10000000);
                result = result && (TTimeSpan.TicksPerMinute == 600000000);
                result = result && (TTimeSpan.TicksPerHour == ((long)(36000000000)));
                result = result && (TTimeSpan.TicksPerDay == ((long)(864000000000)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestZero()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.Zero;
                result = TS.Ticks == 0;
                result = result && (TS.Days == 0);
                result = result && (TS.Hours == 0);
                result = result && (TS.Minutes == 0);
                result = result && (TS.Seconds == 0);
                result = result && (TS.Milliseconds == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestMinMax()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.MinValue;
                B = TTimeSpan.MaxValue;
                result = A.Ticks == long.MinValue;
                result = result && (B.Ticks == long.MaxValue);
                result = result && (A < TTimeSpan.Zero);
                result = result && (B > TTimeSpan.Zero);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestCreateTicks()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(((long)(1234567890123)));
                result = TS.Ticks == ((long)(1234567890123));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestCreateNegativeTicks()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(((long)(-987654321)));
                result = TS.Ticks == ((long)(-987654321));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestCreateHMS()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(2, 3, 4);
                result = TS.Ticks == ((long)(7384)) * TTimeSpan.TicksPerSecond;
                result = result && (TS.Hours == 2);
                result = result && (TS.Minutes == 3);
                result = result && (TS.Seconds == 4);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestCreateDHMS()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(2, 3, 4, 5);
                result = TS.Ticks == ((long)(183845)) * TTimeSpan.TicksPerSecond;
                result = result && (TS.Days == 2);
                result = result && (TS.Hours == 3);
                result = result && (TS.Minutes == 4);
                result = result && (TS.Seconds == 5);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestCreateDHMSM()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(1, 2, 3, 4, 567);
                result = TS.Ticks == ((long)(93784)) * TTimeSpan.TicksPerSecond + ((long)(567)) * TTimeSpan.TicksPerMillisecond;
                result = result && (TS.Milliseconds == 567);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestCreateNegativeHMS()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(-2, -3, -4);
                result = TS.Ticks == -((long)(7384)) * TTimeSpan.TicksPerSecond;
                result = result && (TS.Hours == -2);
                result = result && (TS.Minutes == -3);
                result = result && (TS.Seconds == -4);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFromTicks()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromTicks(((long)(567890123)));
                result = TS.Ticks == ((long)(567890123));
                TS = TTimeSpan.FromTicks(-1);
                result = result && (TS.Ticks == -1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFromMilliseconds()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromMilliseconds(125.0D);
                result = TS.Ticks == 125 * TTimeSpan.TicksPerMillisecond;
                TS = TTimeSpan.FromMilliseconds(-250.0D);
                result = result && (TS.Ticks == -250 * TTimeSpan.TicksPerMillisecond);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFromSeconds()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromSeconds(123.0D);
                result = TS.Ticks == 123 * TTimeSpan.TicksPerSecond;
                TS = TTimeSpan.FromSeconds(-123.0D);
                result = result && (TS.Ticks == -123 * TTimeSpan.TicksPerSecond);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFromMinutes()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromMinutes(25.0D);
                result = TS.Ticks == 25 * TTimeSpan.TicksPerMinute;
                TS = TTimeSpan.FromMinutes(-25.0D);
                result = result && (TS.Ticks == -25 * TTimeSpan.TicksPerMinute);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFromHours()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromHours(26.0D);
                result = TS.Ticks == 26 * TTimeSpan.TicksPerHour;
                TS = TTimeSpan.FromHours(-26.0D);
                result = result && (TS.Ticks == -26 * TTimeSpan.TicksPerHour);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFromDays()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromDays(3.0D);
                result = TS.Ticks == 3 * TTimeSpan.TicksPerDay;
                TS = TTimeSpan.FromDays(-3.0D);
                result = result && (TS.Ticks == -3 * TTimeSpan.TicksPerDay);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFractionalDays()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromDays(1.5D);
                result = TS.Ticks == TTimeSpan.TicksPerDay + 12 * TTimeSpan.TicksPerHour;
                TS = TTimeSpan.FromDays(-0.25D);
                result = result && (TS.Ticks == -6 * TTimeSpan.TicksPerHour);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFractionalHours()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromHours(1.5D);
                result = TS.Ticks == 90 * TTimeSpan.TicksPerMinute;
                TS = TTimeSpan.FromHours(-2.25D);
                result = result && (TS.Ticks == -135 * TTimeSpan.TicksPerMinute);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFractionalMinutes()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromMinutes(1.5D);
                result = TS.Ticks == 90 * TTimeSpan.TicksPerSecond;
                TS = TTimeSpan.FromMinutes(-0.5D);
                result = result && (TS.Ticks == -30 * TTimeSpan.TicksPerSecond);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFractionalSeconds()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromSeconds(1.125D);
                result = TS.Ticks == TTimeSpan.TicksPerSecond + 125 * TTimeSpan.TicksPerMillisecond;
                TS = TTimeSpan.FromSeconds(-2.25D);
                result = result && (TS.Ticks == -2 * TTimeSpan.TicksPerSecond - 250 * TTimeSpan.TicksPerMillisecond);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDaysComponent()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromHours(49.0F);
                result = TS.Days == 2;
                result = result && (TS.Hours == 1);
                TS = TTimeSpan.FromHours(23.0F);
                result = result && (TS.Days == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestHoursComponent()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(3, 22, 0, 0);
                result = TS.Hours == 22;
                TS = TTimeSpan.FromHours(25.0F);
                result = result && (TS.Hours == 1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestMinutesComponent()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(1, 5, 59, 0);
                result = TS.Minutes == 59;
                TS = TTimeSpan.FromMinutes(61.0F);
                result = result && (TS.Minutes == 1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestSecondsComponent()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(1, 2, 3, 59);
                result = TS.Seconds == 59;
                TS = TTimeSpan.FromSeconds(125.0F);
                result = result && (TS.Seconds == 5);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestMillisecondsComponent()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(0, 0, 0, 1, 999);
                result = TS.Milliseconds == 999;
                TS = TTimeSpan.FromMilliseconds(1001.0F);
                result = result && (TS.Milliseconds == 1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestNegativeComponents()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(-1, -2, -3, -4, -500);
                result = TS.Days == -1;
                result = result && (TS.Hours == -2);
                result = result && (TS.Minutes == -3);
                result = result && (TS.Seconds == -4);
                result = result && (TS.Milliseconds == -500);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTickPrecision()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromTicks(1);
                result = TS.Ticks == 1;
                result = result && (TS.Milliseconds == 0);
                TS = TTimeSpan.FromTicks(10001);
                result = result && (TS.Ticks == 10001);
                result = result && (TS.Milliseconds == 1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTotalDays()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromHours(36.0F);
                result = STS_Close(TS.TotalDays, 1.5D, 1E-10D);
                TS = TTimeSpan.FromHours(6.0F);
                result = result && STS_Close(TS.TotalDays, 0.25D, 1E-10D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTotalHours()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(2, 3, 30, 0);
                result = STS_Close(TS.TotalHours, 51.5D, 1E-9D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTotalMinutes()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(0, 2, 3, 30);
                result = STS_Close(TS.TotalMinutes, 123.5D, 1E-8D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTotalSeconds()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(0, 0, 2, 3, 250);
                result = STS_Close(TS.TotalSeconds, 123.25D, 1E-8D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTotalMilliseconds()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = new TTimeSpan(0, 0, 0, 2, 250);
                result = STS_Close(TS.TotalMilliseconds, 2250.0D, 1E-6D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestNegativeTotals()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.FromMinutes((double)-90.0F);
                result = STS_Close(TS.TotalDays, -0.0625D, 1E-10D);
                result = result && STS_Close(TS.TotalHours, -1.5D, 1E-10D);
                result = result && STS_Close(TS.TotalMinutes, (double)-90.0F, 1E-9D);
                result = result && STS_Close(TS.TotalSeconds, (double)-5400.0F, 1E-8D);
                result = result && STS_Close(TS.TotalMilliseconds, (double)-5400000.0F, 1E-6D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestAddMethod()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = new TTimeSpan(1, 2, 0);
                B = new TTimeSpan(0, 3, 4);
                C = A.Add(B);
                result = C.Ticks == A.Ticks + B.Ticks;
                result = result && (C.Hours == 1);
                result = result && (C.Minutes == 5);
                result = result && (C.Seconds == 4);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestAddNegative()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromMinutes(10.0F);
                B = TTimeSpan.FromMinutes((double)-25.0F);
                C = A.Add(B);
                result = C.Ticks == -15 * TTimeSpan.TicksPerMinute;
                result = result && (A.Ticks == 10 * TTimeSpan.TicksPerMinute);
                result = result && (B.Ticks == -25 * TTimeSpan.TicksPerMinute);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestSubtractMethod()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromMinutes(90.0F);
                B = TTimeSpan.FromMinutes(25.0F);
                C = A.Subtract(B);
                result = C.Ticks == 65 * TTimeSpan.TicksPerMinute;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestSubtractNegative()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromSeconds((double)-10.0F);
                B = TTimeSpan.FromSeconds(5.0F);
                C = A.Subtract(B);
                result = C.Ticks == -15 * TTimeSpan.TicksPerSecond;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDuration()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromMinutes((double)-120.0F);
                B = A.Duration();
                result = B.Ticks == 120 * TTimeSpan.TicksPerMinute;
                A = TTimeSpan.FromSeconds(5.0F);
                B = A.Duration();
                result = result && (B.Ticks == A.Ticks);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestNegate()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromMinutes(90.0F);
                B = A.Negate();
                result = B.Ticks == -A.Ticks;
                B = B.Negate();
                result = result && (B.Ticks == A.Ticks);
                B = TTimeSpan.Zero;
                B = B.Negate();
                result = result && (B.Ticks == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorAdd()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromHours(2.0F);
                B = TTimeSpan.FromMinutes(30.0F);
                C = A + B;
                result = C.Ticks == 150 * TTimeSpan.TicksPerMinute;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorSubtract()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromHours(1.0F);
                B = TTimeSpan.FromMinutes(90.0F);
                C = A - B;
                result = C.Ticks == -30 * TTimeSpan.TicksPerMinute;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorNegative()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromSeconds(17.0F);
                B = -A;
                result = B.Ticks == -17 * TTimeSpan.TicksPerSecond;
                B = -B;
                result = result && (B.Ticks == A.Ticks);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorPositive()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromSeconds((double)-17.0F);
                B = +A;
                result = B.Ticks == A.Ticks;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorEqual()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromMinutes(60.0F);
                B = TTimeSpan.FromHours(1.0F);
                C = TTimeSpan.FromMinutes(61.0F);
                result = A == B;
                result = result && (B == A);
                result = result && !(A == C);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorNotEqual()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromSeconds(1.0F);
                B = TTimeSpan.FromSeconds(2.0F);
                C = TTimeSpan.FromTicks(A.Ticks);
                result = A != B;
                result = result && !(A != C);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorLessThan()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromHours(1.0F);
                B = TTimeSpan.FromHours(2.0F);
                result = A < B;
                result = result && !(B < A);
                result = result && !(A < A);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorLessOrEqual()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromHours(1.0F);
                B = TTimeSpan.FromHours(2.0F);
                result = A <= B;
                result = result && (A <= A);
                result = result && !(B <= A);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorGreaterThan()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromHours(2.0F);
                B = TTimeSpan.FromHours(1.0F);
                result = A > B;
                result = result && !(B > A);
                result = result && !(A > A);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorGreaterOrEqual()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromHours(2.0F);
                B = TTimeSpan.FromHours(1.0F);
                result = A >= B;
                result = result && (A >= A);
                result = result && !(B >= A);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorNegativeCompare()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromTicks(-2);
                B = TTimeSpan.FromTicks(-1);
                C = TTimeSpan.Zero;
                result = A < B;
                result = result && (B < C);
                result = result && (C > A);
                result = result && (A != C);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestAddDoesNotMutate()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromHours(2.0F);
                B = TTimeSpan.FromMinutes(30.0F);
                C = A.Add(B);
                result = A.Ticks == 2 * TTimeSpan.TicksPerHour;
                result = result && (B.Ticks == 30 * TTimeSpan.TicksPerMinute);
                result = result && (C.Ticks == 150 * TTimeSpan.TicksPerMinute);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestToStringZero()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                TS = TTimeSpan.Zero;
                S = STS_TimeSpanText(TS);
                result = S == "00:00:00";
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestToStringHMS()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                TS = new TTimeSpan(1, 2, 3);
                S = STS_TimeSpanText(TS);
                result = S == "01:02:03";
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestToStringDays()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                TS = new TTimeSpan(2, 3, 4, 5);
                S = STS_TimeSpanText(TS);
                result = S == "2.03:04:05";
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestToStringNegative()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                TS = new TTimeSpan(-2, -3, -4);
                S = STS_TimeSpanText(TS);
                result = TS.Ticks == -((long)(7384)) * TTimeSpan.TicksPerSecond;
                // XE3: the implicit string conversion omits the minus sign.
                // Check the observed RTL behavior, not the .NET formatting rule.
                result = result && (S == "02:03:04");
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestParseHMS()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.Parse("01:02:03");
                result = TS.Ticks == 3723 * TTimeSpan.TicksPerSecond;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestParseDays()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.Parse("2.03:04:05");
                result = TS.Ticks == 183845 * TTimeSpan.TicksPerSecond;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestParseNegative()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.Parse("-01:02:03");
                result = TS.Ticks == -3723 * TTimeSpan.TicksPerSecond;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestParseFraction()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.Parse("00:00:01.250");
                result = TS.Ticks == TTimeSpan.TicksPerSecond + 250 * TTimeSpan.TicksPerMillisecond;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTryParseValid()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                result = TTimeSpan.TryParse("01:30:00", out TS);
                result = result && (TS.Ticks == 90 * TTimeSpan.TicksPerMinute);
                result = result && TTimeSpan.TryParse("2.00:00:00", out TS);
                result = result && (TS.Ticks == 2 * TTimeSpan.TicksPerDay);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTryParseInvalid()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                result = !TTimeSpan.TryParse("invalid time span", out TS);
                result = result && !TTimeSpan.TryParse("", out TS);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestParseInvalidRaises()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            result = false;
            try
            {
                TS = TTimeSpan.Parse("invalid time span");
            }
            catch (DException E)
            {
                result = true;
            }
            return result;
        }

        public static bool STS_TestToStringRoundTrip()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                A = new TTimeSpan(3, 4, 5, 6, 250);
                S = STS_TimeSpanText(A);
                B = TTimeSpan.Parse(S);
                result = A.Ticks == B.Ticks;
                A = new TTimeSpan(-2, -3, -4);
                S = STS_TimeSpanText(A);
                B = TTimeSpan.Parse(S);
                // XE3: the implicit conversion of a negative TTimeSpan
                // omits its sign. Parse therefore returns a positive value.
                result = result && (A.Ticks < 0);
                result = result && (S == "02:03:04");
                result = result && (B.Ticks > 0);
                result = result && (B.Ticks == -A.Ticks);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestStringImplicit()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                TS = new TTimeSpan(1, 2, 3);
                S = TS;
                result = S == "01:02:03";
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestStringExplicit()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                TS = new TTimeSpan(1, 2, 3);
                S = ((string)TS);
                result = S == "01:02:03";
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDateSubtractDays()
        {
            bool result = false;
            TDateTime A = new TDateTime();
            TDateTime B = new TDateTime();
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                A = EncodeDate(2020, 1, 10);
                B = EncodeDate(2020, 1, 7);
                TS = TTimeSpan.Subtract(A, B);
                result = TS.Ticks == 3 * TTimeSpan.TicksPerDay;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDateSubtractHours()
        {
            bool result = false;
            TDateTime A = new TDateTime();
            TDateTime B = new TDateTime();
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                B = EncodeDate(2020, 1, 10) + EncodeTime(10, 0, 0, 0);
                A = EncodeDate(2020, 1, 10) + EncodeTime(16, 0, 0, 0);
                TS = TTimeSpan.Subtract(A, B);
                result = TS.Ticks == 6 * TTimeSpan.TicksPerHour;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDateSubtractNegative()
        {
            bool result = false;
            TDateTime A = new TDateTime();
            TDateTime B = new TDateTime();
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                A = EncodeDate(2020, 1, 7);
                B = EncodeDate(2020, 1, 10);
                TS = TTimeSpan.Subtract(A, B);
                result = TS.Ticks == -3 * TTimeSpan.TicksPerDay;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDateAddSpanRight()
        {
            bool result = false;
            TDateTime A = new TDateTime();
            TDateTime B = new TDateTime();
            TDateTime Expected = new TDateTime();
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                A = EncodeDate(2020, 1, 10) + EncodeTime(12, 0, 0, 0);
                TS = TTimeSpan.FromHours(6.0F);
                B = A + TS;
                Expected = EncodeDate(2020, 1, 10) + EncodeTime(18, 0, 0, 0);
                result = STS_Close(B, Expected, 1E-9D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDateAddSpanLeft()
        {
            bool result = false;
            TDateTime A = new TDateTime();
            TDateTime B = new TDateTime();
            TDateTime Expected = new TDateTime();
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                A = EncodeDate(2020, 1, 10) + EncodeTime(12, 0, 0, 0);
                TS = TTimeSpan.FromHours(6.0F);
                B = TS + A;
                Expected = EncodeDate(2020, 1, 10) + EncodeTime(18, 0, 0, 0);
                result = STS_Close(B, Expected, 1E-9D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDateSubtractSpan()
        {
            bool result = false;
            TDateTime A = new TDateTime();
            TDateTime B = new TDateTime();
            TDateTime Expected = new TDateTime();
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                A = EncodeDate(2020, 1, 10) + EncodeTime(12, 0, 0, 0);
                TS = TTimeSpan.FromHours(6.0F);
                B = A - TS;
                Expected = EncodeDate(2020, 1, 10) + EncodeTime(6, 0, 0, 0);
                result = STS_Close(B, Expected, 1E-9D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDateCrossMidnight()
        {
            bool result = false;
            TDateTime A = new TDateTime();
            TDateTime B = new TDateTime();
            TDateTime Expected = new TDateTime();
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                A = EncodeDate(2020, 1, 10) + EncodeTime(23, 0, 0, 0);
                TS = TTimeSpan.FromHours(2.0F);
                B = A + TS;
                Expected = EncodeDate(2020, 1, 11) + EncodeTime(1, 0, 0, 0);
                result = STS_Close(B, Expected, 1E-9D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestToStringFraction()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                TS = new TTimeSpan(0, 0, 0, 0, 250);
                S = STS_TimeSpanText(TS);
                result = S == "00:00:00.2500000";
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestToStringOneTick()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            string S = string.Empty;
            try
            {
                TS = TTimeSpan.FromTicks(1);
                S = STS_TimeSpanText(TS);
                result = S == "00:00:00.0000001";
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestParseZero()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.Parse("00:00:00");
                result = TS.Ticks == 0;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestParseOneTick()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                TS = TTimeSpan.Parse("00:00:00.0000001");
                result = TS.Ticks == 1;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestTryParseOneTick()
        {
            bool result = false;
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                result = TTimeSpan.TryParse("00:00:00.0000001", out TS);
                result = result && (TS.Ticks == 1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestFromTicksBoundaries()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromTicks(long.MinValue);
                B = TTimeSpan.FromTicks(long.MaxValue);
                result = A.Ticks == long.MinValue;
                result = result && (B.Ticks == long.MaxValue);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestOperatorDayCarry()
        {
            bool result = false;
            TTimeSpan A = TTimeSpan.CreateRecord();
            TTimeSpan B = TTimeSpan.CreateRecord();
            TTimeSpan C = TTimeSpan.CreateRecord();
            try
            {
                A = TTimeSpan.FromHours(23.0F);
                B = TTimeSpan.FromHours(2.0F);
                C = A + B;
                result = C.Days == 1;
                result = result && (C.Hours == 1);
                result = result && (C.Ticks == 25 * TTimeSpan.TicksPerHour);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool STS_TestDateArithmeticRoundTrip()
        {
            bool result = false;
            TDateTime A = new TDateTime();
            TDateTime B = new TDateTime();
            TTimeSpan TS = TTimeSpan.CreateRecord();
            try
            {
                A = EncodeDate(2020, 1, 10) + EncodeTime(6, 0, 0, 0);
                TS = TTimeSpan.FromHours(12.0F);
                B = A + TS;
                B = B - TS;
                result = STS_Close(A, B, 1E-9D);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // Force evaluation of all test functions, even after a failure.
        // The translated C# runner should preserve eager evaluation as well.
        /*$B+*/

        /*$B-*/
    } // class System_timespanImplementation

}  // namespace System_timespan

