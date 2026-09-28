using System.Sysutils;
using System;
using static D7_arrays.D7_arraysImplementation;
using static D7_arrays.D7_arraysInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_arrays
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


    public class D7_arraysInterface
    {
        public static bool RunArrayChecks()
        {
            bool result = false;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            CheckResult1 = CheckArrayLiterals();
            result = CheckResult1;
            CheckResult2 = CheckStaticArrays();
            result = result && CheckResult2;
            CheckResult3 = CheckDynamicArrays();
            result = result && CheckResult3;
            //            CheckResult4 = CheckOpenArrays();
            //            result = result && CheckResult4;
            //CheckResult5 = CheckArraySlice();
            //result = result && CheckResult5;
            return result;
        }

    } // class D7_arraysInterface


    file class D7_arraysImplementation
    {


        public static bool AcceptMixedValues(params TVarRec[] AValues)
        {
            bool result = false;
            result = AValues.Length - 1 /*# High(AValues) */ == 2;
            return result;
        }

        public static bool AcceptMarkers(TSet AMarkers)
        {
            bool result = false;
            result = (AMarkers.Contains('!')) && (AMarkers.Contains('?')) && !(AMarkers.Contains('#'));
            return result;
        }

        public static bool CheckArrayLiterals()
        {
            bool result = false;
            result = AcceptMixedValues(new TVarRec[] { 'Q', 17, true }) && AcceptMarkers(new TSet() << '!' << '?');
            return result;
        }

        public static bool CheckStaticArrays()
        {
            bool result = false;
            byte[] OpcodeTable = new byte[65536/*# word*/];
            int[] Samples = new int[5/*# range 2..6*/];
            char[,] Grid = new char[2/*# range 0..1*/, 3/*# range 3..5*/];
            int Index = 0;
            bool OpcodeLengthOk = false;
            bool OpcodeLowOk = false;
            bool OpcodeHighOk = false;
            bool OpcodeValueOk = false;
            bool SamplesLengthOk = false;
            bool SamplesLowOk = false;
            bool SamplesHighOk = false;
            bool Sample3Ok = false;
            bool Sample6Ok = false;
            bool GridLengthOk = false;
            bool GridFirstValueOk = false;
            bool GridLastValueOk = false;
            OpcodeTable[0x1234] = 0x5A;
            for (Index = 2 /*# Low(Samples) */; Index <= 6 /*# High(Samples) */; Index++)
            {
                Samples[Index - 2] = Index * Index;
            }
            Grid[0, 3 - 3] = 'A';
            Grid[1, 5 - 3] = 'Z';
            OpcodeLengthOk = OpcodeTable.Length == 65536;
            OpcodeLowOk = 0 /*# Low(OpcodeTable) */ == 0;
            OpcodeHighOk = OpcodeTable.Length - 1 == 65535;
            OpcodeValueOk = OpcodeTable[0x1234] == 0x5A;
            SamplesLengthOk = Samples.Length == 5;
            SamplesLowOk = 2 /*# Low(Samples) */ == 2;
            SamplesHighOk = 6 /*# High(Samples) */ == 6;
            Sample3Ok = Samples[3 - 2] == 9;
            Sample6Ok = Samples[6 - 2] == 36;
            GridLengthOk = Grid.GetLength(0) == 2;
            GridFirstValueOk = Grid[0, 3 - 3] == 'A';
            GridLastValueOk = Grid[1, 5 - 3] == 'Z';
            result = OpcodeLengthOk && OpcodeLowOk && OpcodeHighOk && OpcodeValueOk && SamplesLengthOk && SamplesLowOk && SamplesHighOk && Sample3Ok && Sample6Ok && GridLengthOk && GridFirstValueOk && GridLastValueOk;
            return result;
        }

        public static bool CheckDynamicArrays()
        {
            bool result = false;
            int[] Values = new int[] { };
            string[][] Matrix = new string[][] { };
            int Row = 0;
            int Column = 0;
            string Joined = string.Empty;
            Array.Resize(ref Values, 4);
            for (Row = 0; Row <= Values.Length - 1 /*# High(Values) */; Row++)
            {
                Values[Row] = (Row + 1) * 10;
            }
            Array.Resize(ref Matrix, 2);
            Array.Resize(ref Matrix[0], 2);
            Array.Resize(ref Matrix[1], 3);
            Joined = "";
            for (Row = 0; Row <= Matrix.Length - 1 /*# High(Matrix) */; Row++)
            {
                for (Column = 0; Column <= Matrix[Row].Length - 1 /*# High(Matrix[Row]) */; Column++)
                {
                    Matrix[Row][Column] = (Row * 3 + Column).ToString();
                    Joined = Joined + Matrix[Row][Column];
                }
            }
            result = (Values.Length == 4) && (Values[0] == 10) && (Values[3] == 40) && (Matrix[0].Length == 2) && (Matrix[1].Length == 3) && (Joined == "01345");
            return result;
        }

        //public static void FillLetterBuffer(ref char[] ABuffer)
        //{
        //    int Index = 0;
        //    Array.Resize(ref ABuffer, 4);
        //    for (Index = 0; Index <= ABuffer.Length - 1 /*# High(ABuffer) */; Index++)
        //    {
        //        ABuffer[Index] = Chr((int)('K') + Index);
        //    }
        //}

        public static string JoinCharacters(char[] ACharacters)
        {
            string result = string.Empty;
            int Index = 0;
            result = "";
            for (Index = 0; Index <= ACharacters.Length - 1 /*# High(ACharacters) */; Index++)
            {
                result = result + ACharacters[Index];
            }
            return result;
        }

        public static string JoinConstCharacters(params TVarRec[] ACharacters)
        {
            string result = string.Empty;
            int Index = 0;
            result = "";
            for (Index = 0; Index <= ACharacters.Length - 1 /*# High(ACharacters) */; Index++)
            {
                result = result + ACharacters[Index].ToCharValue();
            }
            return result;
        }

        //public static bool CheckOpenArrays()
        //{
        //    bool result = false;
        //    char[] Buffer = new char[] { };
        //    char[] FixedText = new char[4/*# range 0..3*/];
        //    FillLetterBuffer(ref Buffer);
        //    FixedText[0] = 'T';
        //    FixedText[1] = 'E';
        //    FixedText[2] = 'S';
        //    FixedText[3] = 'T';
        //    result = (JoinCharacters(Buffer) == "KLMN") && (JoinCharacters(FixedText) == "TEST") && (JoinCharacters(new char[] { }) == "") && (JoinConstCharacters(new TVarRec[] { 'O', 'K' }) == "OK");
        //    return result;
        //}

        public static bool CheckSliceValues(int[] AValues)
        {
            bool result = false;
            result = (AValues.Length == 4) && (AValues[0] == 10) && (AValues[1] == 20) && (AValues[2] == 30) && (AValues[3] == 40);
            return result;
        }

        //public static bool CheckArraySlice()
        //{
        //    bool result = false;
        //    int[] Source = new int[6/*# range 0..5*/];
        //    int Index = 0;
        //    for (Index = 0 /*# Low(Source) */; Index <= 5 /*# High(Source) */; Index++)
        //    {
        //        Source[Index] = (Index + 1) * 10;
        //    }
        //    result = CheckSliceValues(Slice(Source, 4));
        //    return result;
        //}
    } // class D7_arraysImplementation

}  // namespace D7_arrays

