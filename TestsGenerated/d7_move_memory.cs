using System;
using static D7_move_memory.D7_move_memoryImplementation;
using static D7_move_memory.D7_move_memoryInterface;
using static System.SystemInterface;


namespace D7_move_memory
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


    public class D7_move_memoryInterface
    {
        public static bool RunMoveChecks()
        {
            bool result = false;
            byte[] Source = new byte[8/*# range 0..7*/];
            byte[] Target = new byte[8/*# range 0..7*/];
            AnsiString SourceText = AnsiString.Empty;
            AnsiString TargetText = AnsiString.Empty;
            int Index = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            for (Index = 0 /*# Low(Source) */; Index <= 7 /*# High(Source) */; Index++)
            {
                Source[Index] = (byte)((Index + 1) * 10);
            }
            FillChar(ref Target, Target.Length, (byte)0);
            Move(new UntypedPointer(Source, 2), new UntypedPointer(Target, 1), 4);
            SourceText = "abcdefgh";
            TargetText = "--------";
            Move(SourceText, 3 - 1, ref TargetText, 2 - 1, 4);
            CheckResult1 = (Target[0] == 0);
            result = CheckResult1;
            CheckResult2 = (Target[1] == 30);
            result = result && CheckResult2;
            CheckResult3 = (Target[2] == 40);
            result = result && CheckResult3;
            CheckResult4 = (Target[3] == 50);
            result = result && CheckResult4;
            CheckResult5 = (Target[4] == 60);
            result = result && CheckResult5;
            CheckResult6 = (Target[5] == 0);
            result = result && CheckResult6;
            CheckResult7 = (TargetText == "-cdef---");
            result = result && CheckResult7;
            return result;
        }

    } // class D7_move_memoryInterface


    file class D7_move_memoryImplementation
    {

    } // class D7_move_memoryImplementation

}  // namespace D7_move_memory

