using System.Sysutils;
using System;
using static D7_position_search.D7_position_searchImplementation;
using static D7_position_search.D7_position_searchInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_position_search
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


    public class D7_position_searchInterface
    {
        public static bool RunPositionChecks()
        {
            bool result = false;
            string TextValue = string.Empty;
            ShortString ShortValue = ShortString.Empty;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            TextValue = "red-blue-red";
            ShortValue = "red-blue-red";
            CheckResult1 = (AnsiPos("blue", TextValue) == 5);
            result = CheckResult1;
            CheckResult2 = (AnsiPos("Blue", TextValue) == 0);
            result = result && CheckResult2;
            CheckResult3 = (TextValue.IndexOf("red") + 1 == 1);
            result = result && CheckResult3;
            CheckResult4 = (TextValue.IndexOf("red", 2 - 1) + 1 == 10);
            result = result && CheckResult4;
            CheckResult5 = (TextValue.IndexOf("red", 11 - 1) + 1 == 0);
            result = result && CheckResult5;
            CheckResult6 = (ShortValue.IndexOf("red") + 1 == 1);
            result = result && CheckResult6;
            CheckResult7 = (ShortValue.IndexOf("red", 2 - 1) + 1 == 10);
            result = result && CheckResult7;
            CheckResult8 = (ShortValue.IndexOf("green") + 1 == 0);
            result = result && CheckResult8;
            return result;
        }

    } // class D7_position_searchInterface


    file class D7_position_searchImplementation
    {

    } // class D7_position_searchImplementation

}  // namespace D7_position_search

