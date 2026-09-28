using System;
using static D7_functions.D7_functionsImplementation;
using static D7_functions.D7_functionsInterface;
using static System.SystemInterface;


namespace D7_functions
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


    public class D7_functionsInterface
    {
        public static bool RunFunctionChecks()
        {
            bool result = false;
            int Doubled = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            CheckResult1 = (ScaleAndOffset(7, 4, 3) == 31);
            result = CheckResult1;
            CheckResult2 = TryDouble(14, out Doubled);
            result = result && CheckResult2;
            CheckResult3 = (Doubled == 28);
            result = result && CheckResult3;
            CheckResult4 = !TryDouble(-1, out Doubled);
            result = result && CheckResult4;
            CheckResult5 = (Doubled == 0);
            result = result && CheckResult5;
            return result;
        }

    } // class D7_functionsInterface


    file class D7_functionsImplementation
    {


        public static int ScaleAndOffset(int AValue, int AScale, int AOffset)
        {
            int result = 0;
            result = AValue * AScale + AOffset;
            return result;
        }

        public static bool TryDouble(int AValue, out int ADoubled)
        {
            ADoubled = 0; //# clear out parameter
            bool result = false;

            result = AValue >= 0;
            if (result)
                ADoubled = AValue * 2;
            else
                ADoubled = 0;
            return result;
        }
    } // class D7_functionsImplementation

}  // namespace D7_functions

