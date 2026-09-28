using System.Sysutils;
using System;
using static D7_try_blocks.D7_try_blocksImplementation;
using static D7_try_blocks.D7_try_blocksInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_try_blocks
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


    public class D7_try_blocksInterface
    {
        public static bool RunTryBlockChecks()
        {
            bool result = false;
            bool FinallyReached = false;
            bool TypedHandlerReached = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            FinallyReached = false;
            TypedHandlerReached = false;
            try
            {
                try
                {
                    throw new EStageError("stage failed");
                }
                finally
                {
                    FinallyReached = true;
                }
            }
            catch (EStageError E)
            {
                TypedHandlerReached = E.Message == "stage failed";
            }
            catch
            {
                TypedHandlerReached = false;
            }
            CheckResult1 = FinallyReached;
            result = CheckResult1;
            CheckResult2 = TypedHandlerReached;
            result = result && CheckResult2;
            return result;
        }

    } // class D7_try_blocksInterface


    file class D7_try_blocksImplementation
    {


        public class EStageError : DException
        {


            public EStageError(string Msg) : base(Msg) { }
            //           public EStageError(string Msg, params TVarRec[] Args) : base(Msg, Args) { }
            //           public EStageError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) { }
            //           public EStageError(string Msg, int AHelpContext) : base(Msg, AHelpContext) { }
            //           public EStageError(uint Ident) : base(Ident) { }
            ////           public EStageError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) { }
            //           public EStageError(uint Ident, params TVarRec[] Args) : base(Ident, Args) { }
            //            public EStageError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) { }
            //            public EStageError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) { }
            //public EStageError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) { }
            //public EStageError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) { }
            //            public EStageError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) { }
        }
    } // class D7_try_blocksImplementation

}  // namespace D7_try_blocks

