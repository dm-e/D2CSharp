//using System.Classes;
using System.Sysutils;
using System;
using static D7_string_list.D7_string_listImplementation;
using static D7_string_list.D7_string_listInterface;
//using static System.Classes.ClassesInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_string_list
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


    public class D7_string_listInterface
    {
        //public static bool RunStringListChecks()
        //{
        //    bool result = false;
        //    bool CheckResult1 = false;
        //    bool CheckResult2 = false;
        //    bool CheckResult3 = false;
        //    bool CheckResult4 = false;
        //    CheckResult1 = CheckStageList();
        //    result = CheckResult1;
        //    CheckResult2 = CheckOptionValues();
        //    result = result && CheckResult2;
        //    CheckResult3 = CheckDelimitedFields();
        //    result = result && CheckResult3;
        //    CheckResult4 = CheckFileRoundTrip();
        //    result = result && CheckResult4;
        //    return result;
        //}

    } // class D7_string_listInterface


    file class D7_string_listImplementation
    {


        //public static bool CheckStageList()
        //{
        //    bool result = false;
        //    TStringList Stages = default;
        //    Stages = new TStringList();
        //    try
        //    {
        //        Stages.Add("scan");
        //        Stages.Add("emit");
        //        Stages.Insert(1, "validate");
        //        Stages.Exchange(0, 2);
        //        result = (Stages.Count == 3) && (Stages[0] == "emit") && (Stages[1] == "validate") && (Stages[2] == "scan") && (Stages.IndexOf("validate") == 1) && (Stages.IndexOf("missing") == -1);
        //    }
        //    finally
        //    {
        //        TObject.Free(Stages);
        //    }
        //    return result;
        //}

        //public static bool CheckOptionValues()
        //{
        //    bool result = false;
        //    TStringList Options = default;
        //    Options = new TStringList();
        //    try
        //    {
        //        Options.WritePropertyValues("mode", "safe");
        //        Options.WritePropertyValues("workers", "6");
        //        Options.WritePropertyValues("trace", "off");
        //        result = (Options.ReadPropertyNames(0) == "mode") && (Options.ReadPropertyValues("mode") == "safe") && (Options.ReadPropertyValues("workers") == "6") && (Options.ReadPropertyValues("trace") == "off");
        //    }
        //    finally
        //    {
        //        TObject.Free(Options);
        //    }
        //    return result;
        //}

        //public static bool CheckDelimitedFields()
        //{
        //    bool result = false;
        //    TStringList Fields = default;
        //    Fields = new TStringList();
        //    try
        //    {
        //        Fields.Delimiter = ';';
        //        Fields.QuoteChar = '\"';
        //        Fields.StrictDelimiter = true;
        //        Fields.DelimitedText = "alpha;\"two words\";omega";
        //        result = (Fields.Count == 3) && (Fields[0] == "alpha") && (Fields[1] == "two words") && (Fields[2] == "omega");
        //    }
        //    finally
        //    {
        //        TObject.Free(Fields);
        //    }
        //    return result;
        //}

        //public static bool CheckFileRoundTrip()
        //{
        //    bool result = false;
        //    TStringList SourceLines = default;
        //    TStringList LoadedLines = default;
        //    string FileName = string.Empty;
        //    FileName = "d7_string_list.tmp";
        //    SourceLines = new TStringList();
        //    LoadedLines = new TStringList();
        //    try
        //    {
        //        SourceLines.Add("first=alpha");
        //        SourceLines.Add("second=beta");
        //        SourceLines.SaveToFile(FileName);
        //        LoadedLines.LoadFromFile(FileName);
        //        result = (LoadedLines.Count == 2) && (LoadedLines.ReadPropertyValues("first") == "alpha") && (LoadedLines.ReadPropertyValues("second") == "beta");
        //    }
        //    finally
        //    {
        //        TObject.Free(LoadedLines);
        //        TObject.Free(SourceLines);
        //        if (FileExists(FileName))
        //            DeleteFile(FileName);
        //    }
        //    return result;
        //}
    } // class D7_string_listImplementation

}  // namespace D7_string_list

