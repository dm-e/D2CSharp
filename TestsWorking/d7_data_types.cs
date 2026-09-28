using System;
using static D7_data_types.D7_data_typesImplementation;
using static D7_data_types.D7_data_typesInterface;
using static System.SystemInterface;


namespace D7_data_types
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


    public class D7_data_typesInterface
    {

        public struct TBuildAgent
        {
            public ShortString Identifier;
            public ShortString HostName;
            public byte WorkerCount;
            public void CreateRecordMembers()
            {
                Identifier = ShortString.Create(24);
                HostName = ShortString.Create(32);
            }
            public static TBuildAgent CreateRecord()
            {
                TBuildAgent tmp = new TBuildAgent();
                tmp.CreateRecordMembers();
                return tmp;
            }
        }
        public static bool RunDataTypeChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            CheckResult1 = CheckNumericAssignments();
            CheckResult2 = CheckTextAndBooleanTypes();
            CheckResult3 = CheckSubranges();
            CheckResult4 = CheckRecordSetEnumAndArray();
            result = CheckResult1 && CheckResult2 && CheckResult3 && CheckResult4;
            return result;
        }

    } // class D7_data_typesInterface


    file class D7_data_typesImplementation
    {

        public enum TTransport
        {
            trLocal,
            trNetwork,
            trCloud,
            trOffline
        };

        public const string DefaultAgent = "runner-a";
        public const int DefaultWorkers = 6;
        public const float DefaultLoad = 72.5F;
        public const bool DefaultEnabled = true;
        public static byte ByteValue = 0;
        public static sbyte ShortValue = 0;
        public static ushort WordValue = 0;
        public static short SmallValue = 0;
        public static uint LongWordValue = 0;
        public static uint CardinalValue = 0;
        public static int LongValue = 0;
        public static int IntegerValue = 0;
        public static long Int64Value = 0;
        public static ulong UInt64Value = 0;
        public static int NativeIntegerValue = 0 /*Native*/;
        public static uint NativeUnsignedValue = 0 /*Native*/;
        public static float SingleValue = 0.0F;
        public static Currency CurrencyValue = 0.0M;
        public static double DoubleValue = 0.0D;
        public static double ExtendedValue = 0.0D;
        public static double RealValue = 0.0F;
        public static double Real48Value = 0.0F;
        public static char CharValue = '\0';
        public static char WideCharValue = '\0';
        public static byte AnsiCharValue = 0;
        public static ShortString ShortText = ShortString.Empty;
        public static string UnicodeText = string.Empty;
        public static AnsiString AnsiText = AnsiString.Empty;
        public static string WideText = string.Empty;
        public static bool ByteBooleanValue = false;
        public static int LongBooleanValue = 0;
        public static bool WordBooleanValue = false;
        public static Pointer PointerValue = default;
        public static string[] TransportNames = new string[4/*# range 0..3*/];

        public static bool CheckNumericAssignments()
        {
            bool result = false;
            bool ByteValueOk = false;
            bool ShortValueOk = false;
            bool WordValueOk = false;
            bool SmallValueOk = false;
            bool LongWordValueOk = false;
            bool CardinalValueOk = false;
            bool LongValueOk = false;
            bool IntegerValueOk = false;
            bool Int64ValueOk = false;
            bool UInt64ValueOk = false;
            bool NativeIntegerValueOk = false;
            bool NativeUnsignedValueOk = false;
            bool SingleValueOk = false;
            bool CurrencyValueOk = false;
            bool DoubleValueOk = false;
            bool ExtendedValueOk = false;
            bool RealValueOk = false;
            bool Real48ValueOk = false;
            ByteValue = 240;
            ShortValue = (sbyte)-100;
            WordValue = 60000;
            SmallValue = (short)-30000;
            LongWordValue = 3000000000;
            CardinalValue = 4000000000;
            LongValue = -2000000000;
            IntegerValue = ShortValue;
            Int64Value = 7000000000;
            UInt64Value = 12000000000;
            NativeIntegerValue = 1024;
            NativeUnsignedValue = 2048;
            SingleValue = DefaultLoad;
            CurrencyValue = 81.1250M;
            DoubleValue = 1.25E100D;
            ExtendedValue = 3.141592653589793238D;
            RealValue = 12.75F;
            Real48Value = 6.5F;
            ByteValueOk = ByteValue == 240;
            ShortValueOk = ShortValue == -100;
            WordValueOk = WordValue == 60000;
            SmallValueOk = SmallValue == -30000;
            LongWordValueOk = LongWordValue == 3000000000;
            CardinalValueOk = CardinalValue == 4000000000;
            LongValueOk = LongValue == -2000000000;
            IntegerValueOk = IntegerValue == -100;
            Int64ValueOk = Int64Value == 7000000000;
            UInt64ValueOk = UInt64Value == 12000000000;
            NativeIntegerValueOk = NativeIntegerValue == 1024;
            NativeUnsignedValueOk = NativeUnsignedValue == 2048;
            SingleValueOk = SingleValue == DefaultLoad;
            CurrencyValueOk = CurrencyValue == 81.1250M;
            DoubleValueOk = DoubleValue > 1E99D;
            ExtendedValueOk = ExtendedValue > 3.14D;
            RealValueOk = RealValue == 12.75F;
            Real48ValueOk = Real48Value == 6.5F;
            result = ByteValueOk && ShortValueOk && WordValueOk && SmallValueOk && LongWordValueOk && CardinalValueOk && LongValueOk && IntegerValueOk && Int64ValueOk && UInt64ValueOk && NativeIntegerValueOk && NativeUnsignedValueOk && SingleValueOk && CurrencyValueOk && DoubleValueOk && ExtendedValueOk && RealValueOk && Real48ValueOk;
            return result;
        }

        public static bool CheckTextAndBooleanTypes()
        {
            bool result = false;
            bool CharValueOk = false;
            bool WideCharValueOk = false;
            bool AnsiCharValueOk = false;
            bool ShortTextOk = false;
            bool UnicodeTextOk = false;
            bool AnsiTextOk = false;
            bool WideTextOk = false;
            bool ByteBooleanValueOk = false;
            bool LongBooleanValueOk = false;
            bool WordBooleanValueOk = false;
            bool PointerValueOk = false;
            CharValue = 'R';
            WideCharValue = '\x3a9';
            AnsiCharValue = (byte)'A';
            ShortText = "short";
            UnicodeText = "unicode";
            AnsiText = "ansi";
            WideText = "wide";
            ByteBooleanValue = Convert.ToBoolean(true);
            LongBooleanValue = 1/*#true*/;
            WordBooleanValue = Convert.ToBoolean(false);
            PointerValue = default;
            CharValueOk = CharValue == 'R';
            WideCharValueOk = WideCharValue == '\x3a9';
            AnsiCharValueOk = AnsiCharValue == 'A';
            ShortTextOk = ShortText == "short";
            UnicodeTextOk = UnicodeText == "unicode";
            AnsiTextOk = AnsiText == "ansi";
            WideTextOk = WideText == "wide";
            ByteBooleanValueOk = ByteBooleanValue == true;
            LongBooleanValueOk = LongBooleanValue == 1/*#true*/;
            WordBooleanValueOk = WordBooleanValue == false;
            PointerValueOk = PointerValue == default;
            result = CharValueOk && WideCharValueOk && AnsiCharValueOk && ShortTextOk && UnicodeTextOk && AnsiTextOk && WideTextOk && ByteBooleanValueOk && LongBooleanValueOk && WordBooleanValueOk && PointerValueOk;
            return result;
        }

        public static bool CheckSubranges()
        {
            bool result = false;
            int /*1..5*/ Priority = 0;
            char /*'A'..'Z'*/ Letter = '\0';
            char /*'0'..'9'*/ Digit = '\0';
            bool PriorityOk = false;
            bool LetterOk = false;
            bool DigitOk = false;
            Priority = 4;
            Letter = 'M';
            Digit = '8';
            PriorityOk = Priority == 4;
            LetterOk = Letter == 'M';
            DigitOk = Digit == '8';
            result = PriorityOk && LetterOk && DigitOk;
            return result;
        }

        public static bool CheckRecordSetEnumAndArray()
        {
            bool result = false;
            TBuildAgent Agent = TBuildAgent.CreateRecord();
            TSet ActiveDays = new TSet();
            TTransport Transport = TTransport.trLocal;
            bool AgentIdentifierOk = false;
            bool AgentHostNameOk = false;
            bool AgentWorkerCountOk = false;
            bool DefaultEnabledOk = false;
            bool ActiveDay1Ok = false;
            bool ActiveDay2Ok = false;
            bool ActiveDay5Ok = false;
            bool TransportOk = false;
            bool TransportNameOk = false;
            ShortString.Assign(ref Agent.Identifier, DefaultAgent);
            ShortString.Assign(ref Agent.HostName, "node-17");
            Agent.WorkerCount = (byte)DefaultWorkers;
            ActiveDays = new TSet() << 1 << 3 << 5;
            Transport = TTransport.trCloud;
            TransportNames[0] = "local";
            TransportNames[1] = "network";
            TransportNames[2] = "cloud";
            TransportNames[3] = "offline";
            AgentIdentifierOk = Agent.Identifier == "runner-a";
            AgentHostNameOk = Agent.HostName == "node-17";
            AgentWorkerCountOk = Agent.WorkerCount == 6;
            DefaultEnabledOk = DefaultEnabled == true;
            ActiveDay1Ok = ActiveDays.Contains(1);
            ActiveDay2Ok = !(ActiveDays.Contains(2));
            ActiveDay5Ok = ActiveDays.Contains(5);
            TransportOk = Transport == TTransport.trCloud;
            TransportNameOk = TransportNames[(int)(Transport)] == "cloud";
            result = AgentIdentifierOk && AgentHostNameOk && AgentWorkerCountOk && DefaultEnabledOk && ActiveDay1Ok && ActiveDay2Ok && ActiveDay5Ok && TransportOk && TransportNameOk;
            return result;
        }
    } // class D7_data_typesImplementation

}  // namespace D7_data_types

