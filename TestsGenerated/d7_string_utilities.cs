using System.Strutils;
using System;
using static D7_string_utilities.D7_string_utilitiesImplementation;
using static D7_string_utilities.D7_string_utilitiesInterface;
using static System.Strutils.StrutilsInterface;
using static System.SystemInterface;


namespace D7_string_utilities
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


    public class D7_string_utilitiesInterface
    {
        public static bool RunStringUtilityChecks()
        {
            bool result = false;
            AnsiString Source = AnsiString.Empty;
            AnsiString Updated = AnsiString.Empty;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            bool CheckResult9 = false;
            Source = "alpha|beta|gamma";
            Updated = AnsiReplaceStr(Source, "beta", "delta");
            CheckResult1 = (LeftStr(Source, 5) == "alpha");
            result = CheckResult1;
            CheckResult2 = (AnsiMidStr(Source, 7, 4) == "beta");
            result = result && CheckResult2;
            CheckResult3 = (AnsiRightStr(Source, 5) == "gamma");
            result = result && CheckResult3;
            CheckResult4 = AnsiStartsStr("alpha|", Source);
            result = result && CheckResult4;
            CheckResult5 = !AnsiStartsStr("ALPHA|", Source);
            result = result && CheckResult5;
            CheckResult6 = (Updated == "alpha|delta|gamma");
            result = result && CheckResult6;
            CheckResult7 = (AnsiReverseString("stressed") == "desserts");
            result = result && CheckResult7;
            CheckResult8 = (AnsiIndexStr("package", new object[] { "prepare", "compile", "package", "deploy" }) == 2);
            result = result && CheckResult8;
            CheckResult9 = (AnsiIndexStr("PACKAGE", new object[] { "prepare", "compile", "package", "deploy" }) == -1);
            result = result && CheckResult9;
            return result;
        }

    } // class D7_string_utilitiesInterface


    file class D7_string_utilitiesImplementation
    {

    } // class D7_string_utilitiesImplementation

}  // namespace D7_string_utilities

