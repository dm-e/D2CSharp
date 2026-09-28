using System.Sysutils;
using System;
using static D7_for_loops.D7_for_loopsImplementation;
using static D7_for_loops.D7_for_loopsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_for_loops
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


    public class D7_for_loopsInterface
    {
        public static bool RunForLoopChecks()
        {
            bool result = false;
            int Index = 0;
            int Sum = 0;
            string ReverseDigits = string.Empty;
            int[] Values = new int[] { };
            int Value = 0;
            string Text = string.Empty;
            char CharacterValue = '\0';
            TPipelineStage Stage = TPipelineStage.psRead;
            TSet SelectedStages = new TSet();
            int StageCount = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            Sum = 0;
            for (Index = 1; Index <= 10; Index++)
            {
                Sum = Sum + Index;
            }
            ReverseDigits = "";
            for (Index = 4; Index >= 1; Index--)
            {
                ReverseDigits = ReverseDigits + (Index).ToString();
            }
            Array.Resize(ref Values, 4);
            Values[0] = 3;
            Values[1] = 5;
            Values[2] = 7;
            Values[3] = 11;
            foreach (int element_0 in Values)
            {
                Value = element_0;
                Sum += Value;
            }
            Text = "";
            foreach (char element_0 in "D7")
            {
                CharacterValue = element_0;
                Text = Text + CharacterValue;
            }
            SelectedStages = new TSet() << (int)TPipelineStage.psRead << (int)TPipelineStage.psGenerate;
            StageCount = 0;
            foreach (TPipelineStage element_0 in SelectedStages)
            {
                Stage = element_0;
                ++StageCount;
            }
            CheckResult1 = (Sum == 81);
            result = CheckResult1;
            CheckResult2 = (ReverseDigits == "4321");
            result = result && CheckResult2;
            CheckResult3 = (Text == "D7");
            result = result && CheckResult3;
            CheckResult4 = (StageCount == 2);
            result = result && CheckResult4;
            return result;
        }

    } // class D7_for_loopsInterface


    file class D7_for_loopsImplementation
    {

        public enum TPipelineStage
        {
            psRead,
            psAnalyze,
            psGenerate
        };
    } // class D7_for_loopsImplementation

}  // namespace D7_for_loops

