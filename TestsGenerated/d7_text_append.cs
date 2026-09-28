using System.Sysutils;
using System;
using static D7_text_append.D7_text_appendImplementation;
using static D7_text_append.D7_text_appendInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_text_append
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


    public class D7_text_appendInterface
    {
        public static bool RunAppendChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            CheckResult1 = CheckTextFileAppend();
            result = CheckResult1;
            CheckResult2 = CheckStringBuilderAppend();
            result = result && CheckResult2;
            return result;
        }

    } // class D7_text_appendInterface


    file class D7_text_appendImplementation
    {


        public static bool CheckTextFileAppend()
        {
            bool result = false;
            TextFile DataFile = TextFile.CreateRecord();
            string FileName = string.Empty;
            string FirstLine = string.Empty;
            string SecondLine = string.Empty;
            FileName = IncludeTrailingPathDelimiter(GetCurrentDir()) + "d7_append_probe.txt";
            try
            {
                AssignFile(DataFile, FileName);
                Rewrite(DataFile);
                try
                {
                    WriteLn(DataFile, "sequence=41");
                }
                finally
                {
                    CloseFile(DataFile);
                }
                AssignFile(DataFile, FileName);
                Append(DataFile);
                try
                {
                    WriteLn(DataFile, "state=complete");
                }
                finally
                {
                    CloseFile(DataFile);
                }
                AssignFile(DataFile, FileName);
                Reset(DataFile);
                try
                {
                    ReadLn(DataFile, ref FirstLine);
                    ReadLn(DataFile, ref SecondLine);
                    result = (FirstLine == "sequence=41") && (SecondLine == "state=complete") && Eof(DataFile);
                }
                finally
                {
                    CloseFile(DataFile);
                }
            }
            finally
            {
                if (FileExists(FileName))
                    DeleteFile(FileName);
            }
            return result;
        }

        public static bool CheckStringBuilderAppend()
        {
            bool result = false;
            StringBuilder Builder;
            Builder = StringBuilder.Create;
            try
            {
                Builder.AppendLine("phase");
                Builder.Append(ref '#').Append(ref 3);
                result = Builder.ToString == "phase" + sLineBreak + "#3";
            }
            finally
            {
                TObject.Free(Builder);
            }
            return result;
        }
    } // class D7_text_appendImplementation

}  // namespace D7_text_append

