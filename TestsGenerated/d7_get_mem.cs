using System;
using static D7_get_mem.D7_get_memImplementation;
using static D7_get_mem.D7_get_memInterface;
using static System.SystemInterface;


namespace D7_get_mem
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


    public class D7_get_memInterface
    {
        public static bool RunGetMemChecks()
        {
            bool result = false;
            Pointer<int> Block = default;
            int Index = 0;
            int Sum = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            Block = default;
            GetMem(ref Block, 8 * sizeof(int));
            try
            {
                Sum = 0;
                for (Index = 0 /*# Low(Block^) */; Index <= 7 /*# High(Block^) */; Index++)
                {
                    Block[Index] = Index + 1;
                    Sum = Sum + Block[Index];
                }
                CheckResult1 = (!Block.IsNull());
                result = CheckResult1;
                CheckResult2 = (Block[0] == 1);
                result = result && CheckResult2;
                CheckResult3 = (Block[7] == 8);
                result = result && CheckResult3;
                CheckResult4 = (Sum == 36);
                result = result && CheckResult4;
            }
            finally
            {
                FreeMem(ref Block);
            }
            return result;
        }

    } // class D7_get_memInterface


    file class D7_get_memImplementation
    {

    } // class D7_get_memImplementation

}  // namespace D7_get_mem

