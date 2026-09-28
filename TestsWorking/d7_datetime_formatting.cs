//using System.Dateutils;
//using System.Sysutils;
using System;
using static D7_datetime_formatting.D7_datetime_formattingImplementation;
using static D7_datetime_formatting.D7_datetime_formattingInterface;
//using static System.Dateutils.DateutilsInterface;
//using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_datetime_formatting
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


    public class D7_datetime_formattingInterface
    {
        //public static bool RunDateTimeFormattingChecks()
        //{
        //    bool result = false;
        //    TFormatSettings SavedSettings = TFormatSettings.CreateRecord();
        //    TDateTime Sample = new TDateTime();
        //    bool CheckResult1 = false;
        //    bool CheckResult2 = false;
        //    bool CheckResult3 = false;
        //    bool CheckResult4 = false;
        //    bool CheckResult5 = false;
        //    bool CheckResult6 = false;
        //    bool CheckResult7 = false;
        //    bool CheckResult8 = false;
        //    bool CheckResult9 = false;
        //    bool CheckResult10 = false;
        //    SavedSettings = FormatSettings;
        //    try
        //    {
        //        FormatSettings.DateSeparator = '|';
        //        FormatSettings.TimeSeparator = '~';
        //        FormatSettings.ShortDateFormat = "yyyy/mm/dd";
        //        FormatSettings.LongDateFormat = "dddd, d mmmm yyyy";
        //        FormatSettings.ShortTimeFormat = "hh:nn";
        //        FormatSettings.LongTimeFormat = "hh:nn:ss";
        //        FormatSettings.TimeAMString = "amx";
        //        FormatSettings.TimePMString = "pmx";
        //        FormatSettings.ShortMonthNames[11 - 1] = "N11";
        //        FormatSettings.LongMonthNames[11 - 1] = "MonthEleven";
        //        FormatSettings.ShortDayNames[1 - 1] = "SunX";
        //        FormatSettings.LongDayNames[1 - 1] = "SundayX";
        //        Sample = EncodeDateTime(2027, 11, 14, 16, 7, 8, 9);
        //        CheckResult1 = (RenderDateTime("yyyy/mm/dd hh:nn:ss.zzz", Sample) == "2027|11|14 16~07~08.009");
        //        result = CheckResult1;
        //        CheckResult2 = (RenderDateTime("ddd d mmm yyyy", Sample) == "SunX 14 N11 2027");
        //        result = result && CheckResult2;
        //        CheckResult3 = (RenderDateTime("dddd, d mmmm yyyy", Sample) == "SundayX, 14 MonthEleven 2027");
        //        result = result && CheckResult3;
        //        CheckResult4 = (RenderDateTime("ddddd", Sample) == "2027|11|14");
        //        result = result && CheckResult4;
        //        CheckResult5 = (RenderDateTime("dddddd", Sample) == "SundayX, 14 MonthEleven 2027");
        //        result = result && CheckResult5;
        //        CheckResult6 = (RenderDateTime("t", Sample) == "16~07");
        //        result = result && CheckResult6;
        //        CheckResult7 = (RenderDateTime("tt", Sample) == "16~07~08");
        //        result = result && CheckResult7;
        //        CheckResult8 = (RenderDateTime("c", Sample) == "2027|11|14 16~07~08");
        //        result = result && CheckResult8;
        //        CheckResult9 = (RenderDateTime("hh:nn ampm", Sample) == "04~07 pmx");
        //        result = result && CheckResult9;
        //        CheckResult10 = (DateTimeToStr(Sample) == "2027|11|14 16~07~08");
        //        result = result && CheckResult10;
        //    }
        //    finally
        //    {
        //        FormatSettings = SavedSettings;
        //    }
        //    return result;
        //}

    } // class D7_datetime_formattingInterface


    file class D7_datetime_formattingImplementation
    {


        //public static string RenderDateTime(string APattern, TDateTime AValue)
        //{
        //    string result = string.Empty;
        //    DateTimeToString(ref result, APattern, AValue);
        //    return result;
        //}
    } // class D7_datetime_formattingImplementation

}  // namespace D7_datetime_formatting

