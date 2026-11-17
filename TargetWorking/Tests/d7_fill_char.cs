using System.Runtime.InteropServices;
using System;
using static D7_fill_char.D7_fill_charImplementation;
using static D7_fill_char.D7_fill_charInterface;
using static System.SystemInterface;


namespace D7_fill_char
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


    public class D7_fill_charInterface
    {
        public static bool RunFillCharChecks()
        {
            bool result = false;
            TProbeRecord Probe = TProbeRecord.CreateRecord();
            byte[] Buffer = new byte[8/*# range 0..7*/];
            Ref<byte[]> __d2cArrayLocation_Buffer = new Ref<byte[]>(() => Buffer, __d2cArrayValue => Buffer = __d2cArrayValue);
            int Index = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            Probe.Counter = 99;
            Probe.Enabled = true;
            Probe.Code = 17;
            FillChar(Pointer<TProbeRecord>.FromStorage(new Ref<TProbeRecord>(() => Probe, __d2cUntypedValue => Probe = __d2cUntypedValue), DelphiTypeLayout.SizeOf<TProbeRecord>()).ToUntypedPointer(), 8 /* SizeOf(TProbeRecord) */, 0);
            CheckResult1 = Probe.Counter == 0;
            CheckResult2 = !Probe.Enabled;
            CheckResult3 = Probe.Code == 0;
            FillChar(new UntypedPointer(Buffer), (8 * (int)DelphiTypeSize.Byte), 0xA5);
            CheckResult4 = true;
            for (Index = 0 /*# Low(Buffer) */; Index <= 7 /*# High(Buffer) */; Index++)
            {
                CheckResult4 = CheckResult4 && (Buffer[Index] == 0xA5);
            }
            result = CheckResult1;
            result = result && CheckResult2;
            result = result && CheckResult3;
            result = result && CheckResult4;
            return result;
        }

    } // class D7_fill_charInterface


    file class D7_fill_charImplementation
    {


        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public struct TProbeRecord
        {
            [global::System.Runtime.InteropServices.FieldOffset(0)]
            public int Counter;
            [global::System.Runtime.InteropServices.FieldOffset(4)]
            [MarshalAs(UnmanagedType.U1)]
            public bool Enabled;
            [global::System.Runtime.InteropServices.FieldOffset(5)]
            public byte Code;
            public static TProbeRecord CreateRecord()
            {
                return new TProbeRecord();
            }
        }
    } // class D7_fill_charImplementation

}  // namespace D7_fill_char

