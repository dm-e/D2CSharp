using System;
using static D7_goto.D7_gotoImplementation;
using static D7_goto.D7_gotoInterface;
using static System.SystemInterface;


namespace D7_goto
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


    public class D7_gotoInterface
    {
        public static bool RunGotoChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            CheckResult1 = FindFirstMultipleOfSeven() == 35;
            result = CheckResult1;
            return result;
        }

    } // class D7_gotoInterface


    file class D7_gotoImplementation
    {


        public static int FindFirstMultipleOfSeven()
        {
            int result = 0;
            int Candidate = 0;
            result = -1;
            for (Candidate = 30; Candidate <= 50; Candidate++)
            {
                if ((Candidate % 7) == 0)
                {
                    result = Candidate;
                    goto Found;
                }
            }
        Found:
            ;
            return result;
        }
    } // class D7_gotoImplementation

}  // namespace D7_goto

