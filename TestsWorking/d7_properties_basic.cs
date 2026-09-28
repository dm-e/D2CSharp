using System;
using static D7_properties_basic.D7_properties_basicImplementation;
using static D7_properties_basic.D7_properties_basicInterface;
using static System.SystemInterface;


namespace D7_properties_basic
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


    public class D7_properties_basicInterface
    {
        public static bool RunBasicPropertyChecks()
        {
            bool result = false;
            TLevel Level = default;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            Level = new TLevel();
            try
            {
                Level.Value = 72;
                CheckResult1 = Level.Value == 72;
                result = CheckResult1;
                Level.Value = 140;
                CheckResult2 = (Level.Value == 100);
                result = result && CheckResult2;
                Level.Value = -8;
                CheckResult3 = (Level.Value == 0);
                result = result && CheckResult3;
            }
            finally
            {
                TObject.Free(Level);
            }
            return result;
        }

    } // class D7_properties_basicInterface


    file class D7_properties_basicImplementation
    {


        public class TLevel : TObject
        {
            private int FValue;

            private int GetValue()
            {
                int result = 0;
                result = FValue;
                return result;
            }

            private void SetValue(int AValue)
            {
                if (AValue < 0)
                    FValue = 0;
                else
                {
                    if (AValue > 100)
                        FValue = 100;
                    else
                        FValue = AValue;
                }
            }
            /*property Value : int read GetValue write SetValue;*/
            public int Value
            {
                get
                {
                    return GetValue();
                }
                set
                {
                    SetValue(value);
                }
            }

            public TLevel()
            {
            }
        }
    } // class D7_properties_basicImplementation

}  // namespace D7_properties_basic

