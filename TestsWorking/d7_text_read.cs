using System.Sysutils;
using System;
using static D7_text_read.D7_text_readImplementation;
using static D7_text_read.D7_text_readInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_text_read
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


    public class D7_text_readInterface
    {
        //public static bool RunTextReadChecks()
        //{
        //    bool result = false;
        //    TextFile DataFile = TextFile.CreateRecord();
        //    string FileName = string.Empty;
        //    int FirstValue = 0;
        //    int SecondValue = 0;
        //    string StateText = string.Empty;
        //    bool CheckResult1 = false;
        //    bool CheckResult2 = false;
        //    bool CheckResult3 = false;
        //    bool CheckResult4 = false;
        //    bool CheckResult5 = false;
        //    FileName = "d7_read_probe.tmp";
        //    AssignFile(DataFile, FileName);
        //    Rewrite(DataFile);
        //    try
        //    {
        //        WriteLn(DataFile, "12 30");
        //        WriteLn(DataFile, "ready");
        //    }
        //    finally
        //    {
        //        CloseFile(DataFile);
        //    }
        //    try
        //    {
        //        AssignFile(DataFile, FileName);
        //        Reset(DataFile);
        //        try
        //        {
        //            Read(DataFile, ref FirstValue);
        //            Read(DataFile, ref SecondValue);
        //            ReadLn(DataFile);
        //            ReadLn(DataFile, ref StateText);
        //            CheckResult1 = (FirstValue == 12);
        //            result = CheckResult1;
        //            CheckResult2 = (SecondValue == 30);
        //            result = result && CheckResult2;
        //            CheckResult3 = (StateText == "ready");
        //            result = result && CheckResult3;
        //            CheckResult4 = Eof(DataFile);
        //            result = result && CheckResult4;
        //            CheckResult5 = CheckTypedRead();
        //            result = result && CheckResult5;
        //        }
        //        finally
        //        {
        //            CloseFile(DataFile);
        //        }
        //    }
        //    finally
        //    {
        //        if (FileExists(FileName))
        //            DeleteFile(FileName);
        //    }
        //    return result;
        //}

    } // class D7_text_readInterface


    file class D7_text_readImplementation
    {


        public struct TReadEntry
        {
            public int Code;
            public bool Active;
            public static TReadEntry CreateRecord()
            {
                return new TReadEntry();
            }
        }

        //public static bool CheckTypedRead()
        //{
        //    bool result = false;
        //    TypedFile<TReadEntry> DataFile = TypedFile<TReadEntry>.CreateRecord();
        //    string FileName = string.Empty;
        //    TReadEntry Entry = TReadEntry.CreateRecord();
        //    byte SavedFileMode = 0;
        //    FileName = "d7_read_record.tmp";
        //    AssignFile(DataFile, FileName);
        //    Rewrite(DataFile);
        //    try
        //    {
        //        Entry.Code = 51;
        //        Entry.Active = true;
        //        Write(DataFile, Entry);
        //    }
        //    finally
        //    {
        //        CloseFile(DataFile);
        //    }
        //    SavedFileMode = SystemInterface.FileMode;
        //    try
        //    {
        //        SystemInterface.FileMode = (byte)fmOpenRead;
        //        Reset(DataFile);
        //        try
        //        {
        //            Read(DataFile, ref Entry);
        //            result = Eof(DataFile) && (Entry.Code == 51) && Entry.Active;
        //        }
        //        finally
        //        {
        //            CloseFile(DataFile);
        //        }
        //    }
        //    finally
        //    {
        //        SystemInterface.FileMode = SavedFileMode;
        //        if (FileExists(FileName))
        //            DeleteFile(FileName);
        //    }
        //    return result;
        //}
    } // class D7_text_readImplementation

}  // namespace D7_text_read

