using System.Dateutils;
using System.Sysutils;
using System;
using static D7_file_age.D7_file_ageImplementation;
using static D7_file_age.D7_file_ageInterface;
using static System.Dateutils.DateutilsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_file_age
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


    public class D7_file_ageInterface
    {
        public static bool RunFileAgeChecks()
        {
            bool result = false;
            TDateTime OriginalDate = new TDateTime();
            TDateTime LaterDate = new TDateTime();
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            CheckResult1 = ReadExecutableAge(out OriginalDate);
            result = CheckResult1;
            if (!result)
                return result;
            LaterDate = IncDay(OriginalDate, 31);
            CheckResult2 = (LaterDate > OriginalDate);
            result = CheckResult2;
            CheckResult3 = (DaysBetween(LaterDate, OriginalDate) == 31);
            result = result && CheckResult3;
            return result;
        }

    } // class D7_file_ageInterface


    file class D7_file_ageImplementation
    {


        public static bool ReadExecutableAge(out TDateTime ADate)
        {
            ADate = new TDateTime(); //# clear out parameter
            bool result = false;

            result = FileAge(ParamStr(0), out ADate);
            return result;
        }
    } // class D7_file_ageImplementation

}  // namespace D7_file_age

