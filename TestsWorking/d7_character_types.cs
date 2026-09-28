using System.Sysutils;
using System;
using static D7_character_types.D7_character_typesImplementation;
using static D7_character_types.D7_character_typesInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_character_types
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


    public class D7_character_typesInterface
    {
        public static bool RunCharacterChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            CheckResult1 = CheckCharacterAssignments();
            result = CheckResult1;
            //CheckResult2 = CheckControlCharacters();
            //result = result && CheckResult2;
            CheckResult3 = CheckOrdinalValues();
            result = result && CheckResult3;
            //CheckResult4 = CheckValConversion();
            //result = result && CheckResult4;
            //CheckResult5 = CheckUnicodeCharacters();
            //result = result && CheckResult5;
            return result;
        }

    } // class D7_character_typesInterface


    file class D7_character_typesImplementation
    {


        public static bool CheckCharacterAssignments()
        {
            bool result = false;
            char UnicodeValue = '\0';
            byte AnsiValue = 0;
            UnicodeValue = 'R';
            result = UnicodeValue == 'R';
            UnicodeValue = '\x54';
            result = result && (UnicodeValue == 'T');
            UnicodeValue = '\v';
            //result = result && (UnicodeValue == Chr(11));
            //UnicodeValue = ((char)90);
            result = result && (UnicodeValue == 'Z');
            AnsiValue = (byte)'b';
            result = result && (AnsiValue == ((byte)98));
            return result;
        }

        //public static bool CheckControlCharacters()
        //{
        //    bool result = false;
        //    string TextValue = string.Empty;
        //    TextValue = "left" + Chr(9) + "right";
        //    result = TextValue == "left" + "\t" + "right";
        //    TextValue = "first" + Chr(13) + Chr(10) + "second";
        //    result = result && (TextValue == "first" + "\r\n" + "second");
        //    return result;
        //}

        public static bool CheckOrdinalValues()
        {
            bool result = false;
            bool Flag = false;
            int Number = 0;
            long LargeNumber = 0;
            Flag = true;
            Number = 314;
            LargeNumber = 9001;
            result = ((int)('D') == 68) && ((int)('\x3a9') == 0x03A9) && (Convert.ToInt32(Flag) == 1) && ((int)(Number) == 314) && ((int)(LargeNumber) == 9001);
            return result;
        }

        //public static bool CheckValConversion()
        //{
        //    bool result = false;
        //    string SourceText = string.Empty;
        //    double ParsedValue = 0.0D;
        //    int ErrorPosition = 0;
        //    SourceText = "2718.125";
        //    Val(SourceText, ref ParsedValue, ref ErrorPosition);
        //    result = (ErrorPosition == 0) && (Abs(ParsedValue - 2718.125D) < 0.000001D);
        //    SourceText = "71x9";
        //    Val(SourceText, ref ParsedValue, ref ErrorPosition);
        //    result = result && (ErrorPosition == 3);
        //    return result;
        //}

        //public static bool CheckUnicodeCharacters()
        //{
        //    bool result = false;
        //    char LineSeparator = '\0';
        //    char GreekOmega = '\0';
        //    LineSeparator = Chr(0x2028);
        //    GreekOmega = ((char)0x03A9);
        //    result = (LineSeparator == '\x2028') && ((int)(LineSeparator) == 0x2028) && (GreekOmega == '\x3a9') && ((int)(GreekOmega) == 0x03A9);
        //    return result;
        //}
    } // class D7_character_typesImplementation

}  // namespace D7_character_types

