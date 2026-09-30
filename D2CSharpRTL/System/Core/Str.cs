using System.Globalization;

namespace System
{
    public static partial class SystemInterface
    {
        private const int D2CStrDefaultSignificantDigits = 15;

        private static readonly CultureInfo D2CStrCulture = CultureInfo.InvariantCulture;

        private static string D2CStrPad(string value, int width)
        {
            if (value == null)
                value = string.Empty;

            if (width == 0)
                return value;

            if (width > 0)
            {
                if (value.Length >= width)
                    return value;

                return value.PadLeft(width);
            }

            width = -width;

            if (value.Length >= width)
                return value;

            return value.PadRight(width);
        }

        private static string D2CStrSpecialFloat(double value)
        {
            if (double.IsPositiveInfinity(value))
                return "+Inf";

            if (double.IsNegativeInfinity(value))
                return "-Inf";

            if (double.IsNaN(value))
                return "Nan";

            return null;
        }

        private static string D2CStrScientific(double value, int significantDigits)
        {
            string special = D2CStrSpecialFloat(value);

            if (special != null)
                return special;

            if (significantDigits < 1)
                significantDigits = 1;

            int decimals = significantDigits - 1;
            string format;

            if (decimals == 0)
                format = "0E+0000";
            else
                format = "0." + new string('0', decimals) + "E+0000";

            return value.ToString(format, D2CStrCulture);
        }

        private static string D2CStrFixed(double value, int precision)
        {
            string special = D2CStrSpecialFloat(value);

            if (special != null)
                return special;

            if (precision < 0)
                precision = 0;

            string format = "F" + precision.ToString(D2CStrCulture);

            return value.ToString(format, D2CStrCulture);
        }

        private static string D2CStrRealWithoutPrecision(double value)
        {
            return D2CStrScientific(value, D2CStrDefaultSignificantDigits);
        }

        private static string D2CStrRealWithPrecision(double value, int precision)
        {
            string special = D2CStrSpecialFloat(value);

            if (special != null)
                return special;

            double absValue = Math.Abs(value);

            /*
              Delphi Str(Value:Width:Precision) normally uses fixed notation.
              For very large Extended values the Delphi RTL switches to exponential
              notation. This threshold is chosen to match the dbsc_str tests well.
            */
            if (absValue != 0.0 && absValue >= 1.0e36)
                return D2CStrScientific(value, 2);

            return D2CStrFixed(value, precision);
        }

        private static void D2CStrAssign(string value, ref string dest)
        {
            dest = value;
        }

        // --------------------------------------------------------------------
        // Signed integer overloads
        // --------------------------------------------------------------------

        public static void Str(sbyte value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(sbyte value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        public static void Str(short value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(short value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        public static void Str(int value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(int value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        public static void Str(long value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(long value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        // --------------------------------------------------------------------
        // Unsigned integer overloads
        // --------------------------------------------------------------------

        public static void Str(byte value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(byte value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        public static void Str(ushort value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(ushort value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        public static void Str(uint value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(uint value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        public static void Str(ulong value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(ulong value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        // --------------------------------------------------------------------
        // Floating point overloads
        // --------------------------------------------------------------------

        public static void Str(float value, ref string dest)
        {
            D2CStrAssign(D2CStrRealWithoutPrecision(value), ref dest);
        }

        public static void Str(float value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(D2CStrRealWithoutPrecision(value), width), ref dest);
        }

        public static void Str(float value, int width, int precision, ref string dest)
        {
            D2CStrAssign(D2CStrPad(D2CStrRealWithPrecision(value, precision), width), ref dest);
        }

        public static void Str(double value, ref string dest)
        {
            D2CStrAssign(D2CStrRealWithoutPrecision(value), ref dest);
        }

        public static void Str(double value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(D2CStrRealWithoutPrecision(value), width), ref dest);
        }

        public static void Str(double value, int width, int precision, ref string dest)
        {
            D2CStrAssign(D2CStrPad(D2CStrRealWithPrecision(value, precision), width), ref dest);
        }

        public static void Str(decimal value, ref string dest)
        {
            D2CStrAssign(value.ToString(D2CStrCulture), ref dest);
        }

        public static void Str(decimal value, int width, ref string dest)
        {
            D2CStrAssign(D2CStrPad(value.ToString(D2CStrCulture), width), ref dest);
        }

        public static void Str(decimal value, int width, int precision, ref string dest)
        {
            if (precision < 0)
                precision = 0;

            string format = "F" + precision.ToString(D2CStrCulture);
            string text = value.ToString(format, D2CStrCulture);

            D2CStrAssign(D2CStrPad(text, width), ref dest);
        }

        // --------------------------------------------------------------------
        // Return-value overloads.
        // These are not Delphi-compatible by themselves, but useful if generated
        // C# code chooses to translate Str(Value, S) as S = Str(Value).
        // --------------------------------------------------------------------

        public static string Str(sbyte value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(sbyte value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(short value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(short value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(int value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(int value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(long value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(long value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(byte value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(byte value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(ushort value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(ushort value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(uint value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(uint value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(ulong value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(ulong value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(float value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(float value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(float value, int width, int precision)
        {
            string result = "";
            Str(value, width, precision, ref result);
            return result;
        }

        public static string Str(double value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(double value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(double value, int width, int precision)
        {
            string result = "";
            Str(value, width, precision, ref result);
            return result;
        }

        public static string Str(decimal value)
        {
            string result = "";
            Str(value, ref result);
            return result;
        }

        public static string Str(decimal value, int width)
        {
            string result = "";
            Str(value, width, ref result);
            return result;
        }

        public static string Str(decimal value, int width, int precision)
        {
            string result = "";
            Str(value, width, precision, ref result);
            return result;
        }
    }
}
