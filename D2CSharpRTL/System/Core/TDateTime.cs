/*
  D2CSharp Runtime Library (RTL)

  This file is implemented directly in C# and provides supporting
  functionality for the runtime library. It is not generated from
  a Delphi source file.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: MPL-2.0

  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at https://mozilla.org/MPL/2.0/.

  Part of the D2CSharp project by t2t-soft.
*/

using static System.SystemInterface;

namespace System
{
#if NO_TDATETIME

    // See SystemInterface.IntegerToDateTime(int Days).

#else

    public static class TDateTime_Helpers
    {
        public static TDateTime Now()
        {
            return new TDateTime(
                global::System.DateTime.Now);
        }

        public static TDateTime Date()
        {
            return new TDateTime(
                global::System.DateTime.Today);
        }

        public static TDateTime Time()
        {
            return new TDateTime(
                global::System.DateTime.Now.TimeOfDay.TotalDays);
        }
    }


    /// <summary>
    /// Represents Delphi's TDateTime type.
    /// The value contains the number of days since December 30, 1899.
    /// </summary>
    [global::System.Runtime.InteropServices.StructLayout(
        global::System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct TDateTime :
        global::System.IEquatable<TDateTime>,
        global::System.IComparable<TDateTime>,
        global::System.IComparable
    {
        public const int DelphiSizeOf = 8;

        private double FValue;


        public enum TDateTimeFlag
        {
            Date,
            Time,
            TDateTime
        }


        public TDateTime(double Value)
        {
            FValue = Value;
        }

        public TDateTime(float Value)
        {
            FValue = Value;
        }

        public TDateTime(int Value)
        {
            FValue = Value;
        }

        public TDateTime(long Value)
        {
            FValue = Value;
        }

        public TDateTime(TDateTime Source)
        {
            FValue = Source.FValue;
        }

        public TDateTime(
            global::System.DateTime Source)
        {
            FValue = DateTimeToDouble(Source);
        }

        public TDateTime(
            int Year,
            int Month,
            int Day)
        {
            global::System.DateTime Value =
                new global::System.DateTime(
                    Year,
                    Month,
                    Day);

            FValue = DateTimeToDouble(Value);
        }

        public TDateTime(
            int Year,
            int Month,
            int Day,
            int Hour,
            int Minute,
            int Second)
        {
            global::System.DateTime Value =
                new global::System.DateTime(
                    Year,
                    Month,
                    Day,
                    Hour,
                    Minute,
                    Second);

            FValue = DateTimeToDouble(Value);
        }

        public TDateTime(
            int Year,
            int Month,
            int Day,
            int Hour,
            int Minute,
            int Second,
            int Millisecond)
        {
            global::System.DateTime Value =
                new global::System.DateTime(
                    Year,
                    Month,
                    Day,
                    Hour,
                    Minute,
                    Second,
                    Millisecond);

            FValue = DateTimeToDouble(Value);
        }


        public static TDateTime CreateRecord()
        {
            return default(TDateTime);
        }


        public double Value
        {
            get
            {
                return FValue;
            }
            set
            {
                FValue = value;
            }
        }


        public static TDateTime Zero
        {
            get
            {
                return new TDateTime(0.0);
            }
        }

        public static TDateTime Now
        {
            get
            {
                return TDateTime_Helpers.Now();
            }
        }

        public static TDateTime Today
        {
            get
            {
                return TDateTime_Helpers.Date();
            }
        }

        public static TDateTime CurrentTime
        {
            get
            {
                return TDateTime_Helpers.Time();
            }
        }


        public bool IsZero
        {
            get
            {
                return FValue == 0.0;
            }
        }


        public double ToDouble()
        {
            return FValue;
        }

        public global::System.DateTime ToDateTime()
        {
            return DoubleToDateTime(FValue);
        }


        public TDateTime AddDays(double Days)
        {
            return new TDateTime(
                FValue + Days);
        }

        public TDateTime AddHours(double Hours)
        {
            return new TDateTime(
                FValue +
                Hours / 24.0);
        }

        public TDateTime AddMinutes(double Minutes)
        {
            return new TDateTime(
                FValue +
                Minutes / (24.0 * 60.0));
        }

        public TDateTime AddSeconds(double Seconds)
        {
            return new TDateTime(
                FValue +
                Seconds / (24.0 * 60.0 * 60.0));
        }

        public TDateTime AddMilliseconds(
            double Milliseconds)
        {
            return new TDateTime(
                FValue +
                Milliseconds /
                (24.0 * 60.0 * 60.0 * 1000.0));
        }


        public static implicit operator double(
            TDateTime Value)
        {
            return Value.FValue;
        }

        public static implicit operator TDateTime(
            double Value)
        {
            return new TDateTime(Value);
        }

        public static implicit operator TDateTime(
            global::System.DateTime Value)
        {
            return new TDateTime(Value);
        }

        public static implicit operator global::System.DateTime(
            TDateTime Value)
        {
            return DoubleToDateTime(Value.FValue);
        }


        /*
         * Only operators with TDateTime as the left operand are defined.
         * This prevents ambiguous overload resolution for expressions
         * containing two TDateTime values.
         */

        public static TDateTime operator +(
            TDateTime Left,
            double Right)
        {
            return new TDateTime(
                Left.FValue + Right);
        }

        public static TDateTime operator -(
            TDateTime Left,
            double Right)
        {
            return new TDateTime(
                Left.FValue - Right);
        }

        public static TDateTime operator +(
            TDateTime Value)
        {
            return Value;
        }

        public static TDateTime operator -(
            TDateTime Value)
        {
            return new TDateTime(
                -Value.FValue);
        }

        public static TDateTime operator ++(
            TDateTime Value)
        {
            return new TDateTime(
                Value.FValue + 1.0);
        }

        public static TDateTime operator --(
            TDateTime Value)
        {
            return new TDateTime(
                Value.FValue - 1.0);
        }


        /*
         * Comparison operators also use double as the right operand.
         * A second TDateTime value is implicitly converted to double.
         */

        public static bool operator ==(
            TDateTime Left,
            double Right)
        {
            return Left.FValue == Right;
        }

        public static bool operator !=(
            TDateTime Left,
            double Right)
        {
            return Left.FValue != Right;
        }

        public static bool operator <(
            TDateTime Left,
            double Right)
        {
            return Left.FValue < Right;
        }

        public static bool operator <=(
            TDateTime Left,
            double Right)
        {
            return Left.FValue <= Right;
        }

        public static bool operator >(
            TDateTime Left,
            double Right)
        {
            return Left.FValue > Right;
        }

        public static bool operator >=(
            TDateTime Left,
            double Right)
        {
            return Left.FValue >= Right;
        }


        public bool Equals(TDateTime Other)
        {
            return FValue == Other.FValue;
        }

        public override bool Equals(object Other)
        {
            if (!(Other is TDateTime))
            {
                return false;
            }

            return Equals((TDateTime)Other);
        }


        public int CompareTo(TDateTime Other)
        {
            return FValue.CompareTo(
                Other.FValue);
        }

        public int CompareTo(object Other)
        {
            if (Other == null)
            {
                return 1;
            }

            if (!(Other is TDateTime))
            {
                throw new global::System.ArgumentException(
                    "The value must be a TDateTime.",
                    nameof(Other));
            }

            return CompareTo((TDateTime)Other);
        }


        public override int GetHashCode()
        {
            return FValue.GetHashCode();
        }


        public override string ToString()
        {
            return FValue.ToString(
                global::System.Globalization.CultureInfo.InvariantCulture);
        }

        public string ToString(
            string Format)
        {
            return ToDateTime().ToString(
                Format,
                global::System.Globalization.CultureInfo.CurrentCulture);
        }

        public string ToString(
            string Format,
            global::System.IFormatProvider FormatProvider)
        {
            return ToDateTime().ToString(
                Format,
                FormatProvider);
        }

        public string ToDateTimeString()
        {
            return ToDateTime().ToString(
                global::System.Globalization.CultureInfo.CurrentCulture);
        }


        private static double DateTimeToDouble(
            global::System.DateTime Value)
        {
            return Value.ToOADate();
        }

        private static global::System.DateTime DoubleToDateTime(
            double Value)
        {
            return global::System.DateTime.FromOADate(Value);
        }
    }

#endif
}

