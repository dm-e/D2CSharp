using System;
using static D7_pointers.D7_pointersImplementation;
using static D7_pointers.D7_pointersInterface;
using static System.SystemInterface;


namespace D7_pointers
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


    public class D7_pointersInterface
    {
        public static bool RunPointerChecks()
        {
            bool result = false;
            DelphiCell<int> Number = new DelphiCell<int>();
            Pointer<int> NumberPointer = default;
            DelphiCell<TCoordinate> Coordinate = new DelphiCell<TCoordinate>();
            Pointer<TCoordinate> CoordinatePointer = default;
            Pointer<int> Buffer = default;
            int Index = 0;
            int Total = 0;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            bool CheckResult5 = false;
            bool CheckResult6 = false;
            Number.Value = 41;
            NumberPointer = Number.AsPointer();
            IncDeref(NumberPointer);
            TCoordinate D7_pointers__0 = Coordinate.Value;

            D7_pointers__0.X = 7;
            Coordinate.Value = D7_pointers__0;
            TCoordinate D7_pointers__1 = Coordinate.Value;

            D7_pointers__1.Y = 11;
            Coordinate.Value = D7_pointers__1;
            CoordinatePointer = Coordinate.AsPointer();
            TCoordinate D7_pointers__2 = CoordinatePointer.Deref();
            D7_pointers__2.Y = 13;
            CoordinatePointer.Assign(D7_pointers__2);
            Buffer = default;
            GetMem(ref Buffer, 6 * sizeof(int));
            try
            {
                Total = 0;
                for (Index = 0 /*# Low(Buffer^) */; Index <= 5 /*# High(Buffer^) */; Index++)
                {
                    Buffer[Index] = (Index + 1) * 4;
                    Total += Buffer[Index];
                }
                CheckResult1 = (Number.Value == 42);
                result = CheckResult1;
                CheckResult2 = (NumberPointer.Deref() == 42);
                result = result && CheckResult2;
                CheckResult3 = (CoordinatePointer.Deref().X == 7);
                result = result && CheckResult3;
                CheckResult4 = (Coordinate.Value.Y == 13);
                result = result && CheckResult4;
                CheckResult5 = (Buffer[5] == 24);
                result = result && CheckResult5;
                CheckResult6 = (Total == 84);
                result = result && CheckResult6;
            }
            finally
            {
                FreeMem(ref Buffer);
            }
            return result;
        }

    } // class D7_pointersInterface


    file class D7_pointersImplementation
    {


        public struct TCoordinate
        {
            public int X;
            public int Y;
            public static TCoordinate CreateRecord()
            {
                return new TCoordinate();
            }
        }
    } // class D7_pointersImplementation

}  // namespace D7_pointers

