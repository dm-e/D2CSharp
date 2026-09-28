using System.Strutils;
using System;
using static D7_ansi_lookup.D7_ansi_lookupImplementation;
using static D7_ansi_lookup.D7_ansi_lookupInterface;
using static System.Strutils.StrutilsInterface;
using static System.SystemInterface;


namespace D7_ansi_lookup
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


    public class D7_ansi_lookupInterface
    {
        public static bool RunAnsiLookupChecks()
        {
            bool result = false;
            AnsiString CurrentStage = AnsiString.Empty;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            CurrentStage = "package";
            CheckResult1 = AnsiMatchStr(CurrentStage, new object[] { "plan", "compile", "package", "publish" });
            result = CheckResult1;
            CheckResult2 = !AnsiMatchStr("PACKAGE", new object[] { "plan", "compile", "package", "publish" });
            result = result && CheckResult2;
            CheckResult3 = (AnsiIndexStr(CurrentStage, new object[] { "plan", "compile", "package", "publish" }) == 2);
            result = result && CheckResult3;
            CheckResult4 = (AnsiIndexStr("missing", PipelineStages) == -1);
            result = result && CheckResult4;
            CheckResult5 = (AnsiIndexStr(CurrentStage, PipelineStages) == 2);
            result = result && CheckResult5;
            return result;
        }

    } // class D7_ansi_lookupInterface


    file class D7_ansi_lookupImplementation
    {

        public static readonly string[] PipelineStages = new string[4/*# range 0..3*/] { "plan", "compile", "package", "publish" };
    } // class D7_ansi_lookupImplementation

}  // namespace D7_ansi_lookup

