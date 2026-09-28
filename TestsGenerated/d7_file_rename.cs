using System.Sysutils;
using System;
using static D7_file_rename.D7_file_renameImplementation;
using static D7_file_rename.D7_file_renameInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_file_rename
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


    public class D7_file_renameInterface
    {
        public static bool RunFileRenameChecks()
        {
            bool result = false;
            TextFile DataFile = TextFile.CreateRecord();
            string OriginalName = string.Empty;
            string RenamedName = string.Empty;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            OriginalName = "d7_rename_source.tmp";
            RenamedName = "d7_rename_target.tmp";
            if (FileExists(OriginalName))
                DeleteFile(OriginalName);
            if (FileExists(RenamedName))
                DeleteFile(RenamedName);
            AssignFile(DataFile, OriginalName);
            Rewrite(DataFile);
            try
            {
                WriteLn(DataFile, "rename");
            }
            finally
            {
                CloseFile(DataFile);
            }
            try
            {
                AssignFile(DataFile, OriginalName);
                Rename(DataFile, RenamedName);
                CheckResult1 = !FileExists(OriginalName);
                result = CheckResult1;
                CheckResult2 = FileExists(RenamedName);
                result = result && CheckResult2;
            }
            finally
            {
                if (FileExists(OriginalName))
                    DeleteFile(OriginalName);
                if (FileExists(RenamedName))
                    DeleteFile(RenamedName);
            }
            return result;
        }

    } // class D7_file_renameInterface


    file class D7_file_renameImplementation
    {

    } // class D7_file_renameImplementation

}  // namespace D7_file_rename

