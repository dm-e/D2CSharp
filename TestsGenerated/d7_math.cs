using System.Dmath;
using System;
using static D7_math.D7_mathImplementation;
using static D7_math.D7_mathInterface;
using static System.Dmath.DmathInterface;
using static System.SystemInterface;


namespace D7_math
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


    public class D7_mathInterface
    {
        public static bool RunMathChecks()
        {
            bool result = false;
            double RootValue = 0.0D;
            double PowerValue = 0.0D;
            double SineValue = 0.0D;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            RootValue = Sqrt(144.0D);
            PowerValue = Power(3.0D, 4.0D);
            SineValue = Sin(Pi() / 2.0F);
            CheckResult1 = (Abs(RootValue - 12.0D) < Tolerance);
            result = CheckResult1;
            CheckResult2 = (Abs(PowerValue - 81.0D) < Tolerance);
            result = result && CheckResult2;
            CheckResult3 = (Abs(SineValue - 1.0D) < Tolerance);
            result = result && CheckResult3;
            CheckResult4 = (Sqr(9) == 81);
            result = result && CheckResult4;
            CheckResult5 = IsInfinite(Infinity);
            result = result && CheckResult5;
            CheckResult6 = IsNan(NaN);
            result = result && CheckResult6;
            CheckResult7 = CheckOrdinalOperations();
            result = result && CheckResult7;
            CheckResult8 = CheckArrayMath();
            result = result && CheckResult8;
            return result;
        }

    } // class D7_mathInterface


    file class D7_mathImplementation
    {

        public const double Tolerance = 1E-10D;
        public enum TCompassPoint
        {
            cpNorth,
            cpEast,
            cpSouth,
            cpWest
        };

        public static bool CheckOrdinalOperations()
        {
            bool result = false;
            int Number = 0;
            char Letter = '\0';
            TCompassPoint Direction = TCompassPoint.cpNorth;
            Number = 40;
            Number += 3;
            --Number;
            Letter = 'K';
            ++Letter;
            Direction = TCompassPoint.cpEast;
            result = (Number == 42) && (Letter == 'L') && (Pred(Direction) == TCompassPoint.cpNorth) && (Succ(Direction) == TCompassPoint.cpSouth);
            return result;
        }

        public static bool CheckArrayMath()
        {
            bool result = false;
            double[] Values = new double[4/*# range 0..3*/];
            Values[0] = 1.25D;
            Values[1] = 2.5D;
            Values[2] = -0.75D;
            Values[3] = 7.0D;
            result = Abs(Sum(Values) - 10.0D) < Tolerance;
            return result;
        }
    } // class D7_mathImplementation

}  // namespace D7_math

