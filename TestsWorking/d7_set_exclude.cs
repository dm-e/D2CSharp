using System;
using static D7_set_exclude.D7_set_excludeImplementation;
using static D7_set_exclude.D7_set_excludeInterface;
using static System.SystemInterface;


namespace D7_set_exclude
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


    public class D7_set_excludeInterface
    {
        public static bool RunSetExcludeChecks()
        {
            bool result = false;
            TSet Flags = new TSet();
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            Flags = new TSet() << (int)TAccessFlag.afRead << (int)TAccessFlag.afWrite << (int)TAccessFlag.afAudit;
            Flags = Flags >> (int)TAccessFlag.afWrite;
            Flags = Flags >> (int)TAccessFlag.afExecute;
            CheckResult1 = (Flags.Contains((int)TAccessFlag.afRead));
            result = CheckResult1;
            CheckResult2 = !(Flags.Contains((int)TAccessFlag.afWrite));
            result = result && CheckResult2;
            CheckResult3 = !(Flags.Contains((int)TAccessFlag.afExecute));
            result = result && CheckResult3;
            CheckResult4 = (Flags.Contains((int)TAccessFlag.afAudit));
            result = result && CheckResult4;
            return result;
        }

    } // class D7_set_excludeInterface


    file class D7_set_excludeImplementation
    {

        public enum TAccessFlag
        {
            afRead,
            afWrite,
            afExecute,
            afAudit
        };
    } // class D7_set_excludeImplementation

}  // namespace D7_set_exclude

