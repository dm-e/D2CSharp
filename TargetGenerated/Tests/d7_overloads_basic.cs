using System.Sysutils;
using System;
using static D7_overloads_basic.D7_overloads_basicImplementation;
using static D7_overloads_basic.D7_overloads_basicInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_overloads_basic
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


    public class D7_overloads_basicInterface
    {
        public static bool RunBasicOverloadChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            CheckResult1 = (Describe(27) == "integer:27");
            result = CheckResult1;
            CheckResult2 = (Describe("ready") == "text:ready");
            result = result && CheckResult2;
            CheckResult3 = (Describe(4, 9) == "pair:4,9");
            result = result && CheckResult3;
            return result;
        }

    } // class D7_overloads_basicInterface


    file class D7_overloads_basicImplementation
    {


        public static string Describe(int AValue)
        {
            string result = string.Empty;
            result = "integer:" + (AValue).ToString();
            return result;
        }

        public static string Describe(string AValue)
        {
            string result = string.Empty;
            result = "text:" + AValue;
            return result;
        }

        public static string Describe(int ALeft, int ARight)
        {
            string result = string.Empty;
            result = "pair:" + (ALeft).ToString() + "," + (ARight).ToString();
            return result;
        }
    } // class D7_overloads_basicImplementation

}  // namespace D7_overloads_basic

