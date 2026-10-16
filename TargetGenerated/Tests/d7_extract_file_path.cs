using System.Sysutils;
using System;
using static D7_extract_file_path.D7_extract_file_pathImplementation;
using static D7_extract_file_path.D7_extract_file_pathInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_extract_file_path
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


    public class D7_extract_file_pathInterface
    {
        public static bool RunExtractFilePathChecks()
        {
            bool result = false;
            string FullName = string.Empty;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            FullName = "D:\\work\\input\\report.final.txt";
            CheckResult1 = (ExtractFileDrive(FullName) == "D:");
            result = CheckResult1;
            CheckResult2 = (ExtractFileDir(FullName) == "D:\\work\\input");
            result = result && CheckResult2;
            CheckResult3 = (ExtractFilePath(FullName) == "D:\\work\\input\\");
            result = result && CheckResult3;
            CheckResult4 = (ExtractFileName(FullName) == "report.final.txt");
            result = result && CheckResult4;
            CheckResult5 = (ExtractFileExt(FullName) == ".txt");
            result = result && CheckResult5;
            CheckResult6 = (ExtractFilePath("relative\\report.txt") == "relative\\");
            result = result && CheckResult6;
            CheckResult7 = (ExtractFilePath("plain.txt") == "");
            result = result && CheckResult7;
            return result;
        }

    } // class D7_extract_file_pathInterface


    file class D7_extract_file_pathImplementation
    {

    } // class D7_extract_file_pathImplementation

}  // namespace D7_extract_file_path

