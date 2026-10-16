using System;
using static D7_realloc_mem.D7_realloc_memImplementation;
using static D7_realloc_mem.D7_realloc_memInterface;
using static System.SystemInterface;


namespace D7_realloc_mem
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


    public class D7_realloc_memInterface
    {
        public static bool RunReallocMemChecks()
        {
            bool result = false;
            Pointer RawMemory = default;
            int Index = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            RawMemory = default;
            GetMem(ref RawMemory, 4);
            try
            {
                for (Index = 0; Index <= 3; Index++)
                {
                    RawMemory.Write<byte>(Index, (byte)(Index + 10));
                }
                ReallocMem(ref RawMemory, 8 * sizeof(byte));
                for (Index = 4; Index <= 7; Index++)
                {
                    RawMemory.Write<byte>(Index, (byte)(Index + 10));
                }
                CheckResult1 = (RawMemory.As<byte>()[0] == 10);
                result = CheckResult1;
                CheckResult2 = (RawMemory.As<byte>()[3] == 13);
                result = result && CheckResult2;
                CheckResult3 = (RawMemory.As<byte>()[4] == 14);
                result = result && CheckResult3;
                CheckResult4 = (RawMemory.As<byte>()[7] == 17);
                result = result && CheckResult4;
            }
            finally
            {
                FreeMem(ref RawMemory);
            }
            return result;
        }

    } // class D7_realloc_memInterface


    file class D7_realloc_memImplementation
    {

    } // class D7_realloc_memImplementation

}  // namespace D7_realloc_mem

