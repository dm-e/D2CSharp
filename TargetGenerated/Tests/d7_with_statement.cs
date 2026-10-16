using System;
using static D7_with_statement.D7_with_statementImplementation;
using static D7_with_statement.D7_with_statementInterface;
using static System.SystemInterface;


namespace D7_with_statement
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


    public class D7_with_statementInterface
    {
        public static bool RunWithStatementChecks()
        {
            bool result = false;
            TWindowSettings Settings = default;
            TWindowState Snapshot = TWindowState.CreateRecord();
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            Settings = new TWindowSettings();
            try
            {
                Settings.Configure();
                Snapshot = Settings.State;
                /*# with Snapshot do */
                {
                    ref var with0 = ref Snapshot;
                    CheckResult1 = with0.Left == 12;
                    CheckResult2 = with0.Top == 18;
                    CheckResult3 = with0.Width == 640;
                    CheckResult4 = with0.Height == 480;
                }
                result = CheckResult1;
                result = result && CheckResult2;
                result = result && CheckResult3;
                result = result && CheckResult4;
            }
            finally
            {
                TObject.Free(Settings);
            }
            return result;
        }

    } // class D7_with_statementInterface


    file class D7_with_statementImplementation
    {


        public struct TWindowState
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
            public static TWindowState CreateRecord()
            {
                return new TWindowState();
            }
        }

        public class TWindowSettings : TObject
        {
            private TWindowState FState = TWindowState.CreateRecord();

            public void Configure()
            {
                /*# with FState do */
                {
                    ref var with0 = ref FState;
                    with0.Left = 12;
                    with0.Top = 18;
                    with0.Width = 640;
                    with0.Height = 480;
                }
            }
            /*property State : TWindowState read FState;*/
            public TWindowState State
            {
                get
                {
                    return FState;
                }
            }

            public TWindowSettings()
            {
            }
        }
    } // class D7_with_statementImplementation

}  // namespace D7_with_statement

