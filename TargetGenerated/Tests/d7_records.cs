using System;
using static D7_records.D7_recordsImplementation;
using static D7_records.D7_recordsInterface;
using static System.SystemInterface;


namespace D7_records
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


    public class D7_recordsInterface
    {
        public static bool RunRecordChecks()
        {
            bool result = false;
            TBuildResult BuildResult = TBuildResult.CreateRecord();
            TBuildResult CopyOfResult = TBuildResult.CreateRecord();
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            BuildResult = CreateBuildResult("win32-debug", 0, 2);
            CopyOfResult = BuildResult;
            CopyOfResult.WarningCount = 3;
            CheckResult1 = IsSuccessful(BuildResult);
            result = CheckResult1;
            CheckResult2 = IsSuccessful(CopyOfResult);
            result = result && CheckResult2;
            CheckResult3 = (BuildResult.WarningCount == 2);
            result = result && CheckResult3;
            CheckResult4 = (CopyOfResult.WarningCount == 3);
            result = result && CheckResult4;
            CheckResult5 = (CopyOfResult.TargetName == "win32-debug");
            result = result && CheckResult5;
            return result;
        }

    } // class D7_recordsInterface


    file class D7_recordsImplementation
    {


        public struct TBuildResult
        {
            public int ExitCode;
            public int WarningCount;
            public ShortString TargetName;
            public void CreateRecordMembers()
            {
                TargetName = ShortString.Create(24);
            }
            public static TBuildResult CreateRecord()
            {
                TBuildResult tmp = new TBuildResult();
                tmp.CreateRecordMembers();
                return tmp;
            }
        }

        public static TBuildResult CreateBuildResult(string ATarget, int AExitCode, int AWarningCount)
        {
            TBuildResult result = TBuildResult.CreateRecord();
            ShortString.Assign(ref result.TargetName, ATarget);
            result.ExitCode = AExitCode;
            result.WarningCount = AWarningCount;
            return result;
        }

        public static bool IsSuccessful(TBuildResult AResult)
        {
            bool result = false;
            result = (AResult.ExitCode == 0) && (AResult.WarningCount < 5);
            return result;
        }
    } // class D7_recordsImplementation

}  // namespace D7_records

