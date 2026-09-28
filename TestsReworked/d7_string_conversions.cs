using System.Sysutils;
using System;
using static D7_string_conversions.D7_string_conversionsImplementation;
using static D7_string_conversions.D7_string_conversionsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_string_conversions
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


    public class D7_string_conversionsInterface
    {
        public static bool RunStringConversionChecks()
        {
            bool result = false;
            TFormatSettings SavedFormatSettings = TFormatSettings.CreateRecord();
            double ParsedFloat = 0.0D;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            CheckResult1 = (StrToInt("2048") == 2048);
            result = CheckResult1;
            CheckResult2 = (StrToInt("  -17") == -17);
            result = result && CheckResult2;
            CheckResult3 = (StrToInt("$2A") == 42);
            result = result && CheckResult3;
            CheckResult4 = (StrToInt64("5000000000") == 5000000000);
            result = result && CheckResult4;
            CheckResult5 = (StrToIntDef("invalid", 73) == 73);
            result = result && CheckResult5;
            CheckResult6 = (StrToInt64Def("", 9000000001) == 9000000001);
            result = result && CheckResult6;
            CheckResult7 = InvalidIntegerRaises();
            result = result && CheckResult7;
            SavedFormatSettings = FormatSettings;
            try
            {
                FormatSettings.DecimalSeparator = ',';
                ParsedFloat = StrToFloat("125,75");
                //CheckResult8 = (Abs(ParsedFloat - 125.75D) < 1E-10D);
                //result = result && CheckResult8;
            }
            finally
            {
                FormatSettings = SavedFormatSettings;
            }
            return result;
        }

    } // class D7_string_conversionsInterface


    file class D7_string_conversionsImplementation
    {


        public static bool InvalidIntegerRaises()
        {
            bool result = false;
            result = false;
            try
            {
                StrToInt("12x");
            }
            catch (EConvertError E)
            {
                result = true;
            }
            return result;
        }
    } // class D7_string_conversionsImplementation

}  // namespace D7_string_conversions

