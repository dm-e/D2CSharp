using System.Sysutils;
using System;
using static D7_ansi_compare.D7_ansi_compareImplementation;
using static D7_ansi_compare.D7_ansi_compareInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_ansi_compare
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


    public class D7_ansi_compareInterface
    {
        public static bool RunAnsiComparisonChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            CheckResult1 = (AnsiCompareStr("node-10", "node-20") < 0);
            result = CheckResult1;
            CheckResult2 = (AnsiCompareStr("stage.final", "stage.final") == 0);
            result = result && CheckResult2;
            CheckResult3 = (AnsiCompareStr("Mode", "mode") != 0);
            result = result && CheckResult3;
            CheckResult4 = SameTextIgnoringCase("Mode=SAFE", "mode=safe");
            result = result && CheckResult4;
            CheckResult5 = (AnsiCompareText("alpha-2", "alpha-9") < 0);
            result = result && CheckResult5;
            CheckResult6 = (AnsiCompareText("", "") == 0);
            result = result && CheckResult6;
            return result;
        }

    } // class D7_ansi_compareInterface


    file class D7_ansi_compareImplementation
    {


        public static bool SameTextIgnoringCase(string ALeft, string ARight)
        {
            bool result = false;
            result = AnsiCompareText(ALeft, ARight) == 0;
            return result;
        }
    } // class D7_ansi_compareImplementation

}  // namespace D7_ansi_compare

