using System;
using static D7_set_length.D7_set_lengthImplementation;
using static D7_set_length.D7_set_lengthInterface;
using static System.SystemInterface;


namespace D7_set_length
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


    public class D7_set_lengthInterface
    {
        public static bool RunSetLengthChecks()
        {
            bool result = false;
            string Text = string.Empty;
            int[] Values = new int[] { };
            int[][] Matrix = new int[][] { };
            int Row = 0;
            int Column = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            Text = "converter";
            SetLength(ref Text, 4);
            Array.Resize(ref Values, 5);
            for (Column = 0 /*# Low(Values) */.AsInteger(); Column <= Values.Length - 1 /*# High(Values) */; Column++)
            {
                Values[Column] = Column * Column;
            }
            Array.Resize(ref Values, 7);
            Array.Resize(ref Matrix, 2);
            for (Row = 0 /*# Low(Matrix) */.AsInteger(); Row <= Matrix.Length - 1 /*# High(Matrix) */; Row++)
            {
                Array.Resize(ref Matrix[Row], 3);
                for (Column = 0 /*# Low(Matrix[Row]) */.AsInteger(); Column <= Matrix[Row].Length - 1 /*# High(Matrix[Row]) */; Column++)
                {
                    Matrix[Row][Column] = Row * 10 + Column;
                }
            }
            CheckResult1 = (Text == "conv");
            result = CheckResult1;
            CheckResult2 = (Values.Length == 7);
            result = result && CheckResult2;
            CheckResult3 = (Values[4] == 16);
            result = result && CheckResult3;
            CheckResult4 = (Values[5] == 0);
            result = result && CheckResult4;
            CheckResult5 = (Matrix.Length == 2);
            result = result && CheckResult5;
            CheckResult6 = (Matrix[1].Length == 3);
            result = result && CheckResult6;
            CheckResult7 = (Matrix[1][2] == 12);
            result = result && CheckResult7;
            return result;
        }

    } // class D7_set_lengthInterface


    file class D7_set_lengthImplementation
    {

    } // class D7_set_lengthImplementation

}  // namespace D7_set_length

