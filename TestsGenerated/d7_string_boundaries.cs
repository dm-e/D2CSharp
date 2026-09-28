using System.Strutils;
using System.Sysutils;
using System;
using static D7_string_boundaries.D7_string_boundariesImplementation;
using static D7_string_boundaries.D7_string_boundariesInterface;
using static System.Strutils.StrutilsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_string_boundaries
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


    public class D7_string_boundariesInterface
    {
        public static bool RunStringBoundaryChecks()
        {
            bool result = false;
            string MessageText = string.Empty;
            AnsiString AnsiMessage = AnsiString.Empty;
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
            bool CheckResult11 = false;
            MessageText = "Build READY: package stored";
            AnsiMessage = "Build READY: package stored";
            CheckResult1 = AnsiContainsStr(MessageText, "READY");
            result = CheckResult1;
            CheckResult2 = !AnsiContainsStr(MessageText, "ready");
            result = result && CheckResult2;
            CheckResult3 = AnsiContainsText(MessageText, "ready");
            result = result && CheckResult3;
            CheckResult4 = AnsiStartsText("build ready", MessageText);
            result = result && CheckResult4;
            CheckResult5 = AnsiEndsText("PACKAGE STORED", MessageText);
            result = result && CheckResult5;
            CheckResult6 = MessageText.Contains("package");
            result = result && CheckResult6;
            CheckResult7 = !MessageText.Contains("Package");
            result = result && CheckResult7;
            CheckResult8 = MessageText.StartsWith("Build");
            result = result && CheckResult8;
            CheckResult9 = MessageText.EndsWith("stored");
            result = result && CheckResult9;
            CheckResult10 = string.EndsText("STORED", MessageText);
            result = result && CheckResult10;
            CheckResult11 = AnsiContainsText(AnsiMessage, "build ready");
            result = result && CheckResult11;
            return result;
        }

    } // class D7_string_boundariesInterface


    file class D7_string_boundariesImplementation
    {

    } // class D7_string_boundariesImplementation

}  // namespace D7_string_boundaries

