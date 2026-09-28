using System.Sysutils;
using System;
using static D7_currency.D7_currencyImplementation;
using static D7_currency.D7_currencyInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_currency
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


    public class D7_currencyInterface
    {
        public static bool RunCurrencyChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            CheckResult1 = CheckCurrencyStorage();
            result = CheckResult1;
            //CheckResult2 = CheckCurrencyLayouts();
            //result = result && CheckResult2;
            //CheckResult3 = CheckCurrencyConversions();
            //result = result && CheckResult3;
            return result;
        }

    } // class D7_currencyInterface


    file class D7_currencyImplementation
    {


        public static bool CheckCurrencyStorage()
        {
            bool result = false;
            Currency FirstAmount = 0.0M;
            Currency SecondAmount = 0.0M;
            Currency TotalAmount = 0.0M;
            FirstAmount = 17.20491M;
            SecondAmount = 17.20509M;
            TotalAmount = FirstAmount + SecondAmount;
            result = (FirstAmount == 17.2049M) && (SecondAmount == 17.2051M) && (TotalAmount == 34.4100M);
            return result;
        }

        //public static bool CheckCurrencyLayouts()
        //{
        //    bool result = false;
        //    string[] Expected = new string[4/*# range 0..3*/] { "CRD27", "27CRD", "CRD 27", "27 CRD" };
        //    TFormatSettings SavedSettings = TFormatSettings.CreateRecord();
        //    int Layout = 0;
        //    string Rendered = string.Empty;
        //    SavedSettings = FormatSettings;
        //    try
        //    {
        //        FormatSettings.CurrencyString = "CRD";
        //        FormatSettings.CurrencyDecimals = 0;
        //        result = true;
        //        for (Layout = 0; Layout <= 3; Layout++)
        //        {
        //            FormatSettings.CurrencyFormat = (byte)Layout;
        //            Rendered = CurrToStrF(27, TFloatFormat.ffCurrency, 0);
        //            result = result && (Rendered == Expected[Layout]);
        //        }
        //    }
        //    finally
        //    {
        //        FormatSettings = SavedSettings;
        //    }
        //    return result;
        //}

        //public static bool CheckCurrencyConversions()
        //{
        //    bool result = false;
        //    TFormatSettings SavedSettings = TFormatSettings.CreateRecord();
        //    Currency Amount = 0.0M;
        //    string FormattedAmount = string.Empty;
        //    string CurrencyAsString = string.Empty;
        //    string CurrencyWithThreeDecimals = string.Empty;
        //    string CurrencyWithoutDecimals = string.Empty;
        //    bool IsFormattedAmountValid = false;
        //    bool IsCurrencyStringValid = false;
        //    bool IsThreeDecimalFormatValid = false;
        //    bool IsZeroDecimalFormatValid = false;
        //    SavedSettings = FormatSettings;
        //    try
        //    {
        //        FormatSettings.DecimalSeparator = ',';
        //        FormatSettings.ThousandSeparator = '.';
        //        FormatSettings.CurrencyString = "CRD";
        //        FormatSettings.CurrencyFormat = 3;
        //        FormatSettings.CurrencyDecimals = 2;
        //        Amount = 7654.321M;
        //        FormattedAmount = Format("%m", new TVarRec[] { Amount });
        //        CurrencyAsString = CurrToStr(42.375M);
        //        CurrencyWithThreeDecimals = CurrToStrF(Amount, TFloatFormat.ffCurrency, 3);
        //        CurrencyWithoutDecimals = CurrToStrF(Amount, TFloatFormat.ffCurrency, 0);
        //        IsFormattedAmountValid = FormattedAmount == "7.654,32 CRD";
        //        IsCurrencyStringValid = CurrencyAsString == "42,375";
        //        IsThreeDecimalFormatValid = CurrencyWithThreeDecimals == "7.654,321 CRD";
        //        IsZeroDecimalFormatValid = CurrencyWithoutDecimals == "7.654 CRD";
        //        result = IsFormattedAmountValid && IsCurrencyStringValid && IsThreeDecimalFormatValid && IsZeroDecimalFormatValid;
        //    }
        //    finally
        //    {
        //        FormatSettings = SavedSettings;
        //    }
        //    return result;
        //}
    } // class D7_currencyImplementation

}  // namespace D7_currency

