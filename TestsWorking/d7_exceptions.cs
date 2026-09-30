using System.Sysutils;
using System;
using static D7_exceptions.D7_exceptionsImplementation;
using static D7_exceptions.D7_exceptionsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_exceptions
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


    public class D7_exceptionsInterface
    {
        public static bool RunExceptionChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            CheckResult1 = false;
            try
            {
                RequirePositive(-3);
            }
            catch (EProbeError E)
            {
                CheckResult1 = E.Message == "value must be positive";
            }
            catch
            {
                CheckResult1 = false;
            }
            result = CheckResult1;
            if (result)
            {
                CheckResult2 = true;
                try
                {
                    RequirePositive(8);
                }
                catch
                {
                    CheckResult2 = false;
                }
                result = result && CheckResult2;
            }
            return result;
        }

    } // class D7_exceptionsInterface


    file class D7_exceptionsImplementation
    {


        public class EProbeError : DException
        {


            public EProbeError(string Msg) : base(Msg) { }
            public EProbeError(string Msg, params TVarRec[] Args) : base(Msg, Args) { }
            public EProbeError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) { }
            public EProbeError(string Msg, int AHelpContext) : base(Msg, AHelpContext) { }
            public EProbeError(uint Ident) : base(Ident) { }
            public EProbeError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) { }
            public EProbeError(uint Ident, params TVarRec[] Args) : base(Ident, Args) { }
            public EProbeError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) { }
            public EProbeError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) { }
            public EProbeError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) { }
            public EProbeError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) { }
            public EProbeError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) { }
        }

        public static void RequirePositive(int AValue)
        {
            if (AValue <= 0)
                throw new EProbeError("value must be positive");
        }
    } // class D7_exceptionsImplementation

}  // namespace D7_exceptions

