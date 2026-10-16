using System.Sysutils;
using System;
using static D7_ansi_case.D7_ansi_caseImplementation;
using static D7_ansi_case.D7_ansi_caseInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_ansi_case
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


    public class D7_ansi_caseInterface
    {
        public static bool RunAnsiCaseChecks()
        {
            bool result = false;
            string LabelText = string.Empty;
            string CommandText = string.Empty;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            LabelText = "RELEASE Candidate 17".ToString().ToLower();
            CommandText = "compile target-x".ToString().ToUpper();
            CheckResult1 = (LabelText == "release candidate 17");
            result = CheckResult1;
            CheckResult2 = (CommandText == "COMPILE TARGET-X");
            result = result && CheckResult2;
            CheckResult3 = ("already lower".ToString().ToLower() == "already lower");
            result = result && CheckResult3;
            CheckResult4 = ("".ToUpper() == "");
            result = result && CheckResult4;
            return result;
        }

    } // class D7_ansi_caseInterface


    file class D7_ansi_caseImplementation
    {

    } // class D7_ansi_caseImplementation

}  // namespace D7_ansi_case

