using System.Sysutils;
using System;
using static D7_file_search.D7_file_searchImplementation;
using static D7_file_search.D7_file_searchInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_file_search
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


    public class D7_file_searchInterface
    {
        //public static bool RunFileSearchChecks()
        //{
        //    bool result = false;
        //    TextFile ProbeFile = TextFile.CreateRecord();
        //    string FirstName = string.Empty;
        //    string SecondName = string.Empty;
        //    string LocatedName = string.Empty;
        //    TSearchRec SearchRecord = TSearchRec.CreateRecord();
        //    int MatchCount = 0;
        //    bool CheckResult1 = false;
        //    bool CheckResult2 = false;
        //    bool CheckResult3 = false;
        //    bool CheckResult4 = false;
        //    bool CheckResult5 = false;
        //    FirstName = "d7_find_alpha.tmp";
        //    SecondName = "d7_find_beta.tmp";
        //    AssignFile(ProbeFile, FirstName);
        //    Rewrite(ProbeFile);
        //    try
        //    {
        //        WriteLn(ProbeFile, "alpha");
        //    }
        //    finally
        //    {
        //        CloseFile(ProbeFile);
        //    }
        //    AssignFile(ProbeFile, SecondName);
        //    Rewrite(ProbeFile);
        //    try
        //    {
        //        WriteLn(ProbeFile, "beta");
        //    }
        //    finally
        //    {
        //        CloseFile(ProbeFile);
        //    }
        //    try
        //    {
        //        LocatedName = FileSearch(FirstName, GetCurrentDir());
        //        CheckResult1 = (LocatedName != "");
        //        result = CheckResult1;
        //        CheckResult2 = FileExists(LocatedName);
        //        result = result && CheckResult2;
        //        CheckResult3 = (ExtractFileName(LocatedName) == FirstName);
        //        result = result && CheckResult3;
        //        CheckResult4 = (FileSearch("missing_d7_probe.tmp", GetCurrentDir()) == "");
        //        result = result && CheckResult4;
        //        MatchCount = 0;
        //        if (FindFirst("d7_find_*.tmp", faAnyFile, ref SearchRecord) == 0)
        //        {
        //            try
        //            {
        //                do
        //                {
        //                    if ((SearchRecord.Name == FirstName) || (SearchRecord.Name == SecondName))
        //                        ++MatchCount;
        //                }
        //                while (!(FindNext(ref SearchRecord) != 0));
        //            }
        //            finally
        //            {
        //                FindClose(ref SearchRecord);
        //            }
        //        }
        //        CheckResult5 = (MatchCount == 2);
        //        result = result && CheckResult5;
        //    }
        //    finally
        //    {
        //        if (FileExists(FirstName))
        //            DeleteFile(FirstName);
        //        if (FileExists(SecondName))
        //            DeleteFile(SecondName);
        //    }
        //    return result;
        //}

    } // class D7_file_searchInterface


    file class D7_file_searchImplementation
    {

    } // class D7_file_searchImplementation

}  // namespace D7_file_search

