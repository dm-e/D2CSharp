using Classes;
using System.Sysutils;
using System;
using static Classes.ClassesInterface;
using static D7_tlist.D7_tlistImplementation;
using static D7_tlist.D7_tlistInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_tlist
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


    public class D7_tlistInterface
    {
        public static bool RunTListChecks()
        {
            bool result = false;
            TList Items;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            Items = TList.Create;
            try
            {
                Items.Add(new TQueueItem("compile", 30));
                Items.Add(new TQueueItem("scan", 10));
                Items.Insert(1, ref new TQueueItem("parse", 20));
                CheckResult1 = (Items.Count == 3);
                result = CheckResult1;
                CheckResult2 = (((TQueueItem)Items[1]).LabelText == "parse");
                result = result && CheckResult2;
                CheckResult3 = (Items.IndexOf(Items[2]) == 2);
                result = result && CheckResult3;
                Items.Sort(CompareQueueItems());
                CheckResult4 = (((TQueueItem)Items[0]).LabelText == "scan");
                result = result && CheckResult4;
                CheckResult5 = (((TQueueItem)Items[1]).LabelText == "parse");
                result = result && CheckResult5;
                CheckResult6 = (((TQueueItem)Items[2]).LabelText == "compile");
                result = result && CheckResult6;
                Items.Exchange(0, 2);
                CheckResult7 = (((TQueueItem)Items[0]).LabelText == "compile");
                result = result && CheckResult7;
                TObject.Free(((TQueueItem)Items[1]));
                Items.Delete(ref 1);
                Items.Add(default);
                Items.Pack;
                CheckResult8 = (Items.Count == 2);
                result = result && CheckResult8;
            }
            finally
            {
                FreeItems(Items);
                TObject.Free(Items);
            }
            return result;
        }

    } // class D7_tlistInterface


    file class D7_tlistImplementation
    {


        public class TQueueItem : TObject
        {
            private string FLabelText = string.Empty;
            private int FPriority;
            public TQueueItem(string ALabelText, int APriority)
            {
                ;
                FLabelText = ALabelText;
                FPriority = APriority;
            }
            /*property LabelText : string read FLabelText;*/
            public string LabelText
            {
                get
                {
                    return FLabelText;
                }
            }
            /*property Priority : int read FPriority;*/
            public int Priority
            {
                get
                {
                    return FPriority;
                }
            }
        }

        public static int CompareQueueItems(Pointer Item1, Pointer Item2)
        {
            int result = 0;
            result = ((TQueueItem)Item1.ToObject()).Priority - ((TQueueItem)Item2.ToObject()).Priority;
            if (result == 0)
                result = CompareStr(((TQueueItem)Item1.ToObject()).LabelText, ((TQueueItem)Item2.ToObject()).LabelText);
            return result;
        }

        public static void FreeItems(TList AList)
        {
            int Index = 0;
            for (Index = AList.Count - 1; Index >= 0; Index--)
            {
                TObject.Free(((TObject)AList[Index]));
            }
            AList.Clear;
        }
    } // class D7_tlistImplementation

}  // namespace D7_tlist

