using System.Runtime.InteropServices;
using System;
using static D7_interfaces_basic.D7_interfaces_basicImplementation;
using static D7_interfaces_basic.D7_interfaces_basicInterface;
using static System.SystemInterface;


namespace D7_interfaces_basic
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


    public class D7_interfaces_basicInterface
    {
        public static bool RunBasicInterfaceChecks()
        {
            bool result = false;
            IValueProvider Provider = default;
            bool CheckResult1 = false;
            Provider = new TValueProvider(314);
            CheckResult1 = Provider.GetValue() == 314;
            result = CheckResult1;
            return result;
        }

    } // class D7_interfaces_basicInterface


    file class D7_interfaces_basicImplementation
    {

        public interface IValueProvider : IInterface
        {

            int GetValue();
        }

        public class TValueProvider : TInterfacedObject, IValueProvider
        {
            private int FValue;
            public TValueProvider(int AValue)
            {
                ;
                FValue = AValue;
            }

            public int GetValue()
            {
                int result = 0;
                result = FValue;
                return result;
            }
        }
    } // class D7_interfaces_basicImplementation

}  // namespace D7_interfaces_basic

