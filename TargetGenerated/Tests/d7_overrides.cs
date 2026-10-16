using System;
using static D7_overrides.D7_overridesImplementation;
using static D7_overrides.D7_overridesInterface;
using static System.SystemInterface;


namespace D7_overrides
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


    public class D7_overridesInterface
    {
        public static bool RunOverrideChecks()
        {
            bool result = false;
            TOperation Operation = default;
            bool CheckResult1 = false;
            Operation = new TDoubleOperation();
            try
            {
                CheckResult1 = Operation.Execute(23) == 46;
                result = CheckResult1;
            }
            finally
            {
                TObject.Free(Operation);
            }
            return result;
        }

    } // class D7_overridesInterface


    file class D7_overridesImplementation
    {


        public class TOperation : TObject
        {

            public virtual int Execute(int AValue)
            {
                int result = 0;
                result = AValue;
                return result;
            }

            public TOperation()
            {
            }
        }

        public class TDoubleOperation : TOperation
        {

            public override int Execute(int AValue)
            {
                int result = 0;
                result = AValue * 2;
                return result;
            }

            public TDoubleOperation()
            {
            }
        }
    } // class D7_overridesImplementation

}  // namespace D7_overrides

