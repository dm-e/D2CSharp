using System.Runtime.InteropServices;
using System;
using static D7_case_statements.D7_case_statementsImplementation;
using static D7_case_statements.D7_case_statementsInterface;
using static System.SystemInterface;


namespace D7_case_statements
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


    public class D7_case_statementsInterface
    {
        public static bool RunCaseStatementChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            bool CheckResult9 = false;
            bool CheckResult10 = false;
            CheckResult1 = (StateCode(TBuildState.bsSucceeded) == 30);
            result = CheckResult1;
            CheckResult2 = (ScoreBand(73) == 'B');
            result = result && CheckResult2;
            CheckResult3 = (ScoreBand(140) == '?');
            result = result && CheckResult3;
            CheckResult4 = (FindFirstSeparator("scheme:value/rest") == 7);
            result = result && CheckResult4;
            CheckResult5 = (CharacterGroup('\x09') == 1);
            result = result && CheckResult5;
            CheckResult6 = (CharacterGroup('7') == 2);
            result = result && CheckResult6;
            CheckResult7 = (CharacterGroup('q') == 3);
            result = result && CheckResult7;
            CheckResult8 = (CharacterGroup(((char)0x03A9)) == 4);
            result = result && CheckResult8;
            CheckResult9 = (CharacterGroup('.') == 5);
            result = result && CheckResult9;
            CheckResult10 = CheckVariantRecord();
            result = result && CheckResult10;
            return result;
        }

    } // class D7_case_statementsInterface


    file class D7_case_statementsImplementation
    {

        public enum TBuildState
        {
            bsQueued,
            bsRunning,
            bsSucceeded,
            bsFailed
        };

        [StructLayout(LayoutKind.Explicit, Size = 24)]
        public struct TPayload
        {
            [FieldOffset(0)]
            public ShortString Name;
            [FieldOffset(8)]
            public bool IsRange;
            [FieldOffset(12)]
            public int Value;
            [FieldOffset(12)]
            public int FirstValue;
            [FieldOffset(16)]
            public int LastValue;
            public void CreateRecordMembers()
            {
                Name = ShortString.Create(24);
            }
            public static TPayload CreateRecord()
            {
                TPayload tmp = new TPayload();
                tmp.CreateRecordMembers();
                return tmp;
            }
        }

        public static int StateCode(TBuildState AState)
        {
            int result = 0;
            switch (AState)
            {
                case TBuildState.bsQueued:
                    result = 10;
                    break;
                case TBuildState.bsRunning:
                    result = 20;
                    break;
                case TBuildState.bsSucceeded:
                    result = 30;
                    break;
                case TBuildState.bsFailed:
                    result = 40;
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;
        }

        public static char ScoreBand(int AScore)
        {
            char result = '\0';
            switch (AScore)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                    result = 'D';
                    break;
                case 40:
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                    result = 'C';
                    break;
                case 60:
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                    result = 'B';
                    break;
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                case 96:
                case 97:
                case 98:
                case 99:
                case 100:
                    result = 'A';
                    break;
                default:
                    result = '?';
                    break;
            }
            return result;
        }

        public static int FindFirstSeparator(string AText)
        {
            int result = 0;
            int Index = 0;
            result = 0;
            for (Index = 1; Index <= AText.Length; Index++)
            {
                switch (AText[Index - 1])
                {
                    case '/':
                    case ':':
                    case '|':
                        {
                            result = Index;
                            goto label0;
                        }
                    default:
                        ;
                        break;
                }
            }
        label0:
            ;
            return result;
        }

        public static int CharacterGroup(char AValue)
        {
            int result = 0;
            switch ((int)(AValue))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                    result = 1;
                    break;
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                    result = 2;
                    break;
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                case 97:
                case 98:
                case 99:
                case 100:
                case 101:
                case 102:
                case 103:
                case 104:
                case 105:
                case 106:
                case 107:
                case 108:
                case 109:
                case 110:
                case 111:
                case 112:
                case 113:
                case 114:
                case 115:
                case 116:
                case 117:
                case 118:
                case 119:
                case 120:
                case 121:
                case 122:
                    result = 3;
                    break;
                default:
                    if ((int)(AValue) >= 0x0080 && (int)(AValue) <= 0xFFFF)
                        result = 4;
                    else
                    {
                        result = 5;
                    }
                    break;
            }
            return result;
        }

        public static bool CheckVariantRecord()
        {
            bool result = false;
            TPayload SingleValue = TPayload.CreateRecord();
            TPayload RangeValue = TPayload.CreateRecord();
            ShortString.Assign(ref SingleValue.Name, "retries");
            SingleValue.IsRange = false;
            SingleValue.Value = 4;
            ShortString.Assign(ref RangeValue.Name, "ports");
            RangeValue.IsRange = true;
            RangeValue.FirstValue = 8000;
            RangeValue.LastValue = 8010;
            result = !SingleValue.IsRange && (SingleValue.Value == 4) && RangeValue.IsRange && (RangeValue.FirstValue == 8000) && (RangeValue.LastValue == 8010);
            return result;
        }
    } // class D7_case_statementsImplementation

}  // namespace D7_case_statements

