using System;
using static D7_procedures.D7_proceduresImplementation;
using static D7_procedures.D7_proceduresInterface;
using static System.SystemInterface;


namespace D7_procedures
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


    public class D7_proceduresInterface
    {
        public static bool RunProcedureChecks()
        {
            bool result = false;
            int LeftValue = 0;
            int RightValue = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            LeftValue = 12;
            RightValue = 35;
            ExchangeIntegers(ref LeftValue, ref RightValue);
            AddAmount(ref LeftValue, 7);
            CheckResult1 = (LeftValue == 42);
            result = CheckResult1;
            CheckResult2 = (RightValue == 12);
            result = result && CheckResult2;
            return result;
        }

    } // class D7_proceduresInterface


    file class D7_proceduresImplementation
    {


        public static void ExchangeIntegers(ref int ALeft, ref int ARight)
        {
            int Temporary = 0;
            Temporary = ALeft;
            ALeft = ARight;
            ARight = Temporary;
        }

        public static void AddAmount(ref int ATarget, int AAmount)
        {
            ATarget += AAmount;
        }
    } // class D7_proceduresImplementation

}  // namespace D7_procedures

