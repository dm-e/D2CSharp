using System.Sysutils;
using System;
using static D7_float_to_strf.D7_float_to_strfImplementation;
using static D7_float_to_strf.D7_float_to_strfInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_float_to_strf
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


    public class D7_float_to_strfInterface
    {
        public static bool RunFloatToStrFChecks()
        {
            bool result = false;
            TFormatSettings SavedFormatSettings = TFormatSettings.CreateRecord();
            string GeneralText = string.Empty;
            string ExponentText = string.Empty;
            string CurrencyText = string.Empty;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            bool CheckResult9 = false;
            bool CheckResult10 = false;
            SavedFormatSettings = FormatSettings;
            try
            {
                FormatSettings.DecimalSeparator = ',';
                FormatSettings.ThousandSeparator = '.';
                FormatSettings.CurrencyString = "C";
                FormatSettings.CurrencyFormat = 0;
                GeneralText = FloatToStrF(78.125D, TFloatFormat.ffGeneral, 6, 3);
                ExponentText = FloatToStrF(78.125D, TFloatFormat.ffExponent, 6, 3);
                CurrencyText = FloatToStrF(1234.5D, TFloatFormat.ffCurrency, 12, 2);
                CheckResult1 = (FloatToStrF(782.346D, TFloatFormat.ffFixed, 12, 2) == "782,35");
                result = CheckResult1;
                CheckResult2 = (FloatToStrF(782.346D, TFloatFormat.ffNumber, 12, 3) == "782,346");
                result = result && CheckResult2;
                CheckResult3 = (FloatToStrF(12000.5D, TFloatFormat.ffNumber, 12, 1) == "12.000,5");
                result = result && CheckResult3;
                CheckResult4 = (FloatToStrF(0.125D, TFloatFormat.ffFixed, 8, 4) == "0,1250");
                result = result && CheckResult4;
                CheckResult5 = (GeneralText == "78,125");
                result = result && CheckResult5;
                CheckResult6 = (ExponentText.IndexOf("7,8125") + 1 == 1);
                result = result && CheckResult6;
                CheckResult7 = (ExponentText.IndexOf("E+") + 1 > 0);
                result = result && CheckResult7;
                CheckResult8 = (CurrencyText.IndexOf("C") + 1 > 0);
                result = result && CheckResult8;
                CheckResult9 = (CurrencyText.IndexOf("1.234") + 1 > 0);
                result = result && CheckResult9;
                CheckResult10 = (CurrencyText.IndexOf(",50") + 1 > 0);
                result = result && CheckResult10;
            }
            finally
            {
                FormatSettings = SavedFormatSettings;
            }
            return result;
        }

    } // class D7_float_to_strfInterface


    file class D7_float_to_strfImplementation
    {

    } // class D7_float_to_strfImplementation

}  // namespace D7_float_to_strf

