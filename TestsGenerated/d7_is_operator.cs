using System;
using static D7_is_operator.D7_is_operatorImplementation;
using static D7_is_operator.D7_is_operatorInterface;
using static System.SystemInterface;


namespace D7_is_operator
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


    public class D7_is_operatorInterface
    {
        public static bool RunIsOperatorChecks()
        {
            bool result = false;
            TTransportBase Transport = default;
            TClass TransportClass = default;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            Transport = new TLocalTransport();
            try
            {
                TransportClass = TClass.Of<TTransportBase>();
                CheckResult1 = (Transport is TTransportBase);
                result = CheckResult1;
                CheckResult2 = (TClass.IsInstance(Transport, TransportClass));
                result = result && CheckResult2;
                CheckResult3 = (Transport is TLocalTransport);
                result = result && CheckResult3;
                CheckResult4 = !(Transport is TRemoteTransport);
                result = result && CheckResult4;
                CheckResult5 = (Transport.ClassType() == TClass.Of<TLocalTransport>());
                result = result && CheckResult5;
                CheckResult6 = !(Transport.ClassType() == TClass.Of<TTransportBase>());
                result = result && CheckResult6;
            }
            finally
            {
                TObject.Free(Transport);
            }
            return result;
        }

    } // class D7_is_operatorInterface


    file class D7_is_operatorImplementation
    {


        public class TTransportBase : TObject
        {


            public TTransportBase()
            {
            }
        }

        public class TLocalTransport : TTransportBase
        {


            public TLocalTransport()
            {
            }
        }

        public class TRemoteTransport : TTransportBase
        {


            public TRemoteTransport()
            {
            }
        }
    } // class D7_is_operatorImplementation

}  // namespace D7_is_operator

