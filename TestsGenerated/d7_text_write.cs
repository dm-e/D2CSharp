using System.Sysutils;
using System;
using static D7_text_write.D7_text_writeImplementation;
using static D7_text_write.D7_text_writeInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_text_write
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


    public class D7_text_writeInterface
    {
        public static bool RunTextWriteChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            CheckResult1 = CheckTextOutput();
            result = CheckResult1;
            CheckResult2 = CheckTypedOutput();
            result = result && CheckResult2;
            return result;
        }

    } // class D7_text_writeInterface


    file class D7_text_writeImplementation
    {


        public struct TProbeEntry
        {
            public int Code;
            public bool Enabled;
            public static TProbeEntry CreateRecord()
            {
                return new TProbeEntry();
            }
        }

        public static bool CheckTextOutput()
        {
            bool result = false;
            TextFile OutputFile = TextFile.CreateRecord();
            string FileName = string.Empty;
            string FirstLine = string.Empty;
            string SecondLine = string.Empty;
            FileName = "d7_write_text.tmp";
            AssignFile(OutputFile, FileName);
            Rewrite(OutputFile);
            try
            {
                Write(OutputFile, "value=");
                WriteLn(OutputFile, 42);
                WriteLn(OutputFile, 7.25D, 6, 2);
            }
            finally
            {
                CloseFile(OutputFile);
            }
            try
            {
                AssignFile(OutputFile, FileName);
                Reset(OutputFile);
                try
                {
                    ReadLn(OutputFile, ref FirstLine);
                    ReadLn(OutputFile, ref SecondLine);
                }
                finally
                {
                    CloseFile(OutputFile);
                }
                result = (FirstLine == "value=42") && (SecondLine == "  7.25");
            }
            finally
            {
                if (FileExists(FileName))
                    DeleteFile(FileName);
            }
            return result;
        }

        public static bool CheckTypedOutput()
        {
            bool result = false;
            TypedFile<TProbeEntry> OutputFile = TypedFile<TProbeEntry>.CreateRecord();
            string FileName = string.Empty;
            TProbeEntry Entry = TProbeEntry.CreateRecord();
            byte SavedFileMode = 0;
            FileName = "d7_write_record.tmp";
            AssignFile(OutputFile, FileName);
            Rewrite(OutputFile);
            try
            {
                Entry.Code = 17;
                Entry.Enabled = false;
                Write(OutputFile, Entry);
                Entry.Code = 29;
                Entry.Enabled = true;
                Write(OutputFile, Entry);
            }
            finally
            {
                CloseFile(OutputFile);
            }
            SavedFileMode = SystemInterface.FileMode;
            try
            {
                SystemInterface.FileMode = (byte)fmOpenRead;
                Reset(OutputFile);
                try
                {
                    Read(OutputFile, ref Entry);
                    Read(OutputFile, ref Entry);
                    result = Eof(OutputFile) && (Entry.Code == 29) && Entry.Enabled;
                }
                finally
                {
                    CloseFile(OutputFile);
                }
            }
            finally
            {
                SystemInterface.FileMode = SavedFileMode;
                if (FileExists(FileName))
                    DeleteFile(FileName);
            }
            return result;
        }
    } // class D7_text_writeImplementation

}  // namespace D7_text_write

