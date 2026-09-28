using System.Sysutils;
using System;
using static D7_string_processor.D7_string_processorImplementation;
using static D7_string_processor.D7_string_processorInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_string_processor
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


    public class D7_string_processorInterface
    {
        public static bool RunStringProcessorChecks()
        {
            bool result = false;
            TTextScanner Scanner = default;
            int FirstIndex = 0;
            int SecondIndex = 0;
            int Replacements = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            Scanner = new TTextScanner("red green\x09" + "blue red\x0d\x0a" + "orange");
            try
            {
                CheckResult1 = Scanner.TokenCount == 5;
                result = CheckResult1;
                FirstIndex = Scanner.FindFirst("red");
                SecondIndex = Scanner.FindNext();
                CheckResult2 = (FirstIndex == 1);
                result = result && CheckResult2;
                CheckResult3 = (SecondIndex == 16);
                result = result && CheckResult3;
                CheckResult4 = (Scanner.FindNext() == 0);
                result = result && CheckResult4;
                Replacements = Scanner.ReplaceAll("red", "gold");
                CheckResult5 = (Replacements == 2);
                result = result && CheckResult5;
                CheckResult6 = (Scanner.Text == "gold green\x09" + "blue gold\x0d\x0a" + "orange");
                result = result && CheckResult6;
                Scanner.Text = "one  two three";
                CheckResult7 = (Scanner.TokenCount == 3);
                result = result && CheckResult7;
            }
            finally
            {
                TObject.Free(Scanner);
            }
            return result;
        }

    } // class D7_string_processorInterface


    file class D7_string_processorImplementation
    {


        public class TTextScanner : TObject
        {
            private string FText = string.Empty;
            private string FNeedle = string.Empty;
            private int FNextIndex;

            private int GetTokenCount()
            {
                int result = 0;
                int Index = 0;
                bool InsideToken = false;
                result = 0;
                InsideToken = false;
                for (Index = 1; Index <= FText.Length; Index++)
                {
                    if ((new TSet() << '\x09' << '\x0a' << '\x0d' << ' ').Contains(FText[Index - 1]))
                    {
                        if (InsideToken)
                            ++result;
                        InsideToken = false;
                    }
                    else
                        InsideToken = true;
                }
                if (InsideToken)
                    ++result;
                return result;
            }

            private void SetText(string AValue)
            {
                FText = AValue;
                FNeedle = "";
                FNextIndex = 1;
            }
            public TTextScanner(string AText)
            {
                ;
                SetText(AText);
            }

            public int FindFirst(string ANeedle)
            {
                int result = 0;
                FNeedle = ANeedle;
                FNextIndex = 1;
                result = FindNext();
                return result;
            }

            public int FindNext()
            {
                int result = 0;
                int RelativeIndex = 0;
                if (FNeedle == "")
                {
                    result = 0;
                    return result;
                }
                RelativeIndex = FText.Substring(FNextIndex - 1, MaxSubstringLength(FText, FNextIndex - 1, MaxInt)).IndexOf(FNeedle) + 1;
                if (RelativeIndex == 0)
                {
                    result = 0;
                    return result;
                }
                result = FNextIndex + RelativeIndex - 1;
                FNextIndex = result + FNeedle.Length;
                return result;
            }

            public int ReplaceAll(string AOldText, string ANewText)
            {
                int result = 0;
                int MatchIndex = 0;
                int RelativeIndex = 0;
                int SearchStart = 0;
                result = 0;
                if (AOldText == "")
                    return result;
                MatchIndex = FText.IndexOf(AOldText) + 1;
                while (MatchIndex > 0)
                {
                    Delete(ref FText, MatchIndex - 1, AOldText.Length);
                    Insert(ANewText, ref FText, MatchIndex - 1);
                    ++result;
                    SearchStart = MatchIndex + ANewText.Length;
                    RelativeIndex = FText.Substring(SearchStart - 1, MaxSubstringLength(FText, SearchStart - 1, MaxInt)).IndexOf(AOldText) + 1;
                    if (RelativeIndex == 0)
                        MatchIndex = 0;
                    else
                        MatchIndex = SearchStart + RelativeIndex - 1;
                }
                FNeedle = "";
                FNextIndex = 1;
                return result;
            }
            /*property Text : string read FText write SetText;*/
            public string Text
            {
                get
                {
                    return FText;
                }
                set
                {
                    SetText(value);
                }
            }
            /*property TokenCount : int read GetTokenCount;*/
            public int TokenCount
            {
                get
                {
                    return GetTokenCount();
                }
            }
        }
    } // class D7_string_processorImplementation

}  // namespace D7_string_processor

