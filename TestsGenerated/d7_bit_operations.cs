using System.Runtime.InteropServices;
using System;
using static D7_bit_operations.D7_bit_operationsImplementation;
using static D7_bit_operations.D7_bit_operationsInterface;
using static System.SystemInterface;


namespace D7_bit_operations
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


    public class D7_bit_operationsInterface
    {
        public static bool RunBitOperationChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            CheckResult1 = CheckHighAndLowBytes();
            result = CheckResult1;
            CheckResult2 = CheckRecordAndMasks();
            result = result && CheckResult2;
            CheckResult3 = CheckWordShifts();
            result = result && CheckResult3;
            return result;
        }

    } // class D7_bit_operationsInterface


    file class D7_bit_operationsImplementation
    {

        //#pragma pack (push, 1)


        [StructLayout(LayoutKind.Explicit, Size = 4)]
        public struct TLongWordParts
        {
            [FieldOffset(0)]
            public uint Value;
            [FieldOffset(0)]
            public ushort LowPart;
            [FieldOffset(2)]
            public ushort HighPart;
            public static TLongWordParts CreateRecord()
            {
                return new TLongWordParts();
            }
        }
        //#pragma pack (pop)


        public static bool CheckHighAndLowBytes()
        {
            bool result = false;
            ushort Code = 0;
            Code = 0xABCD;
            result = (Hi(Code) == 0xAB) && (Lo(Code) == 0xCD);
            return result;
        }

        public static bool CheckRecordAndMasks()
        {
            bool result = false;
            TLongWordParts Parts = TLongWordParts.CreateRecord();
            ushort UpperWord = 0;
            int GroupCode = 0;
            int FlagCode = 0;
            Parts.Value = 0x4A21C3D4;
            UpperWord = Parts.HighPart;
            GroupCode = (UpperWord >> 8) & 0xFF;
            FlagCode = UpperWord & 0xFF;
            result = (Parts.LowPart == 0xC3D4) && (UpperWord == 0x4A21) && (GroupCode == 0x4A) && (FlagCode == 0x21);
            return result;
        }

        public static bool CheckWordShifts()
        {
            bool result = false;
            ushort Value = 0;
            Value = 0x002D;
            Value = (ushort)(Value << 8);
            result = Value == 0x2D00;
            Value = (ushort)(Value >> 4);
            result = result && (Value == 0x02D0);
            return result;
        }
    } // class D7_bit_operationsImplementation

}  // namespace D7_bit_operations

