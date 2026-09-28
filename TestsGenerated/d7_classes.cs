using System;
using static D7_classes.D7_classesImplementation;
using static D7_classes.D7_classesInterface;
using static System.SystemInterface;


namespace D7_classes
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


    public class D7_classesInterface
    {

        public struct TTranslationOptions
        {
            public enum TMode
            {
                tmConservative,
                tmBalanced,
                tmAggressive
            };
            public static TMode DefaultMode;
            public static void SelectBalancedMode()
            {
                DefaultMode = TMode.tmBalanced;
            }
            public static bool HasBalancedMode()
            {
                bool result = false;
                result = DefaultMode == TMode.tmBalanced;
                return result;
            }
            public static TTranslationOptions CreateRecord()
            {
                return new TTranslationOptions();
            }
        }

        public struct TStatusMapper
        {
            public enum TStatus
            {
                tsUnknown,
                tsAccepted,
                tsRejected
            };
            public TStatus Normalize(TStatus AStatus)
            {
                TStatus result = TStatus.tsUnknown;
                switch (AStatus)
                {
                    case TStatus.tsAccepted:
                    case TStatus.tsRejected:
                        result = AStatus;
                        break;
                    default:
                        result = TStatus.tsUnknown;
                        break;
                }
                return result;
            }
            public bool CheckAcceptedStatus()
            {
                bool result = false;
                result = Normalize(TStatus.tsAccepted) == TStatus.tsAccepted;
                return result;
            }
            public static TStatusMapper CreateRecord()
            {
                return new TStatusMapper();
            }
        }

        public class TSensor : TObject
        {
            private bool FUsesRange;
            private int FChannel;
            private int FFirstChannel;
            private int FLastChannel;
            public TSensor(int AChannel)
            {
                ;
                FUsesRange = false;
                FChannel = AChannel;
            }
            public TSensor(int AFirstChannel, int ALastChannel)
            {
                ;
                FUsesRange = true;
                FFirstChannel = AFirstChannel;
                FLastChannel = ALastChannel;
            }
            /*property UsesRange : bool read FUsesRange;*/
            public bool UsesRange
            {
                get
                {
                    return FUsesRange;
                }
            }
            /*property Channel : int read FChannel;*/
            public int Channel
            {
                get
                {
                    return FChannel;
                }
            }
            /*property FirstChannel : int read FFirstChannel;*/
            public int FirstChannel
            {
                get
                {
                    return FFirstChannel;
                }
            }
            /*property LastChannel : int read FLastChannel;*/
            public int LastChannel
            {
                get
                {
                    return FLastChannel;
                }
            }
        }

        public class TDevicePanel : TObject
        {
            public bool Accepts(TSensor ASensor)
            {
                bool result = false;
                if (ASensor.UsesRange)
                    result = ASensor.FirstChannel <= ASensor.LastChannel;
                else
                    result = ASensor.Channel >= 0;
                return result;
            }

            public TDevicePanel()
            {
            }
        }
        public static bool RunClassChecks()
        {
            bool result = false;
            TDevicePanel Panel = default;
            TSensor SingleSensor = default;
            TSensor RangeSensor = default;
            TStatusMapper Mapper = TStatusMapper.CreateRecord();
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            bool CheckResult7 = false;
            bool CheckResult8 = false;
            bool CheckResult9 = false;
            TTranslationOptions.SelectBalancedMode();
            Panel = new TDevicePanel();
            SingleSensor = new TSensor(12);
            RangeSensor = new TSensor(20, 24);
            try
            {
                CheckResult1 = TTranslationOptions.HasBalancedMode();
                result = CheckResult1;
                CheckResult2 = !SingleSensor.UsesRange;
                result = result && CheckResult2;
                CheckResult3 = (SingleSensor.Channel == 12);
                result = result && CheckResult3;
                CheckResult4 = RangeSensor.UsesRange;
                result = result && CheckResult4;
                CheckResult5 = (RangeSensor.FirstChannel == 20);
                result = result && CheckResult5;
                CheckResult6 = (RangeSensor.LastChannel == 24);
                result = result && CheckResult6;
                CheckResult7 = Panel.Accepts(SingleSensor);
                result = result && CheckResult7;
                CheckResult8 = Panel.Accepts(RangeSensor);
                result = result && CheckResult8;
                CheckResult9 = Mapper.CheckAcceptedStatus();
                result = result && CheckResult9;
            }
            finally
            {
                TObject.Free(RangeSensor);
                TObject.Free(SingleSensor);
                TObject.Free(Panel);
            }
            return result;
        }

    } // class D7_classesInterface


    file class D7_classesImplementation
    {

    } // class D7_classesImplementation

}  // namespace D7_classes

