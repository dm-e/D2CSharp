using System;
using static D7_free_mem.D7_free_memImplementation;
using static D7_free_mem.D7_free_memInterface;
using static System.SystemInterface;


namespace D7_free_mem
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


    public class D7_free_memInterface
    {
        public static bool RunFreeMemChecks()
        {
            bool result = false;
            Pointer<byte> Buffer = default;
            int Index = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            Buffer = default;
            GetMem(ref Buffer, 16 * sizeof(byte));
            try
            {
                for (Index = 0 /*# Low(Buffer^) */; Index <= 15 /*# High(Buffer^) */; Index++)
                {
                    Buffer[Index] = (byte)(Index * 3);
                }
                CheckResult1 = (Buffer[0] == 0);
                result = CheckResult1;
                CheckResult2 = (Buffer[5] == 15);
                result = result && CheckResult2;
                CheckResult3 = (Buffer[15] == 45);
                result = result && CheckResult3;
            }
            finally
            {
                FreeMem(ref Buffer);
            }
            return result;
        }

    } // class D7_free_memInterface


    file class D7_free_memImplementation
    {

    } // class D7_free_memImplementation

}  // namespace D7_free_mem

