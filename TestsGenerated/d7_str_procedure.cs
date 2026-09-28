using System.Sysutils;
using System;
using static D7_str_procedure.D7_str_procedureImplementation;
using static D7_str_procedure.D7_str_procedureInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_str_procedure
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


    public class D7_str_procedureInterface
    {
        public static bool RunStrProcedureChecks()
        {
            bool result = false;
            string Text = string.Empty;
            int IntegerValue = 0;
            double RealValue = 0.0D;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            IntegerValue = -731;
            Str(IntegerValue, ref Text);
            CheckResult1 = Text == "-731";
            result = CheckResult1;
            Str(IntegerValue, 8, ref Text);
            CheckResult2 = (Text == "    -731");
            result = result && CheckResult2;
            RealValue = 48.375D;
            Str(RealValue, 0, 3, ref Text);
            CheckResult3 = (Text == "48.375");
            result = result && CheckResult3;
            Str(RealValue, 10, 1, ref Text);
            CheckResult4 = (Text == "      48.4");
            result = result && CheckResult4;
            Str(RealValue, ref Text);
            CheckResult5 = (Text.IndexOf("4.8375") + 1 > 0);
            result = result && CheckResult5;
            CheckResult6 = (Text.IndexOf("E+") + 1 > 0);
            result = result && CheckResult6;
            return result;
        }

    } // class D7_str_procedureInterface


    file class D7_str_procedureImplementation
    {

    } // class D7_str_procedureImplementation

}  // namespace D7_str_procedure

