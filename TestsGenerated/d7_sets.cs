using System;
using static D7_sets.D7_setsImplementation;
using static D7_sets.D7_setsInterface;
using static System.SystemInterface;


namespace D7_sets
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


    public class D7_setsInterface
    {
        public static bool RunSetChecks()
        {
            bool result = false;
            TSet Active = new TSet();
            TSet EvenValues = new TSet();
            int Index = default;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            Active = new TSet() << (int)TSignal.sgRed << (int)TSignal.sgGreen;
            Active = Active + (new TSet() << (int)TSignal.sgBlue);
            Active = Active - (new TSet() << (int)TSignal.sgRed);
            EvenValues = new TSet();
            for (Index = 0 /*# Low(TSmallNumber) */; Index <= 31 /*# High(TSmallNumber) */; Index++)
            {
                if ((Index % 2) == 0)
                    EvenValues = EvenValues << (int)Index;
            }
            CheckResult1 = !(Active.Contains((int)TSignal.sgRed));
            result = CheckResult1;
            CheckResult2 = !(Active.Contains((int)TSignal.sgAmber));
            result = result && CheckResult2;
            CheckResult3 = (Active.Contains((int)TSignal.sgGreen));
            result = result && CheckResult3;
            CheckResult4 = (Active.Contains((int)TSignal.sgBlue));
            result = result && CheckResult4;
            CheckResult5 = (EvenValues.Contains(0));
            result = result && CheckResult5;
            CheckResult6 = (EvenValues.Contains(18));
            result = result && CheckResult6;
            CheckResult7 = !(EvenValues.Contains(19));
            result = result && CheckResult7;
            CheckResult8 = (EvenValues.Contains(30));
            result = result && CheckResult8;
            return result;
        }

    } // class D7_setsInterface


    file class D7_setsImplementation
    {

        public enum TSignal
        {
            sgRed,
            sgAmber,
            sgGreen,
            sgBlue
        };
    } // class D7_setsImplementation

}  // namespace D7_sets

