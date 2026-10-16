using System.Sysutils;
using System;
using static D7_int_to_str.D7_int_to_strImplementation;
using static D7_int_to_str.D7_int_to_strInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_int_to_str
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


    public class D7_int_to_strInterface
    {
        public static bool RunIntToStrChecks()
        {
            bool result = false;
            long LargeValue = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            LargeValue = 7000000001;
            CheckResult1 = ((0).ToString() == "0");
            result = CheckResult1;
            CheckResult2 = ((-2048).ToString() == "-2048");
            result = result && CheckResult2;
            CheckResult3 = ((65535).ToString() == "65535");
            result = result && CheckResult3;
            CheckResult4 = ((LargeValue).ToString() == "7000000001");
            result = result && CheckResult4;
            CheckResult5 = (IntToHex(0x2A, 4) == "002A");
            result = result && CheckResult5;
            CheckResult6 = (IntToHex(255, 2) == "FF");
            result = result && CheckResult6;
            return result;
        }

    } // class D7_int_to_strInterface


    file class D7_int_to_strImplementation
    {

    } // class D7_int_to_strImplementation

}  // namespace D7_int_to_str

