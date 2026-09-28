using System;
using static D7_set_string.D7_set_stringImplementation;
using static D7_set_string.D7_set_stringInterface;
using static System.SystemInterface;


namespace D7_set_string
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


    public class D7_set_stringInterface
    {
        public static bool RunSetStringChecks()
        {
            bool result = false;
            char[] Letters = new char[7/*# range 0..6*/] { 'A', 'u', 'r', 'o', 'r', 'a', '!' };
            string Text = string.Empty;
            PChar Start = default;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            Start = new PChar(Letters, 0);
            SetString(ref Text, Start, 6);
            CheckResult1 = Text == "Aurora";
            result = CheckResult1;
            Start.Inc(2);
            SetString(ref Text, Start, 3);
            CheckResult2 = (Text == "ror");
            result = result && CheckResult2;
            SetString(ref Text, (char[])default, 0);
            CheckResult3 = (Text == "");
            result = result && CheckResult3;
            return result;
        }

    } // class D7_set_stringInterface


    file class D7_set_stringImplementation
    {

    } // class D7_set_stringImplementation

}  // namespace D7_set_string

