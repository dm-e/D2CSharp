using System.Sysutils;
using System;
using static D7_formatting.D7_formattingImplementation;
using static D7_formatting.D7_formattingInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_formatting
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


    public class D7_formattingInterface
    {
        public static bool RunFormattingChecks()
        {
            bool result = false;
            result = true;
            if (!CheckBuildMessage())
                result = false;
            if (!CheckIdentifierLayout())
                result = false;
            if (!CheckFloatingPointText())
                result = false;
            return result;
        }

    } // class D7_formattingInterface


    file class D7_formattingImplementation
    {


        public static bool CheckBuildMessage()
        {
            bool result = false;
            string MessageText = string.Empty;
            MessageText = Format("Build %s produced %d artifacts", new TVarRec[] { "linux-x64", 18 });
            result = MessageText == "Build linux-x64 produced 18 artifacts";
            return result;
        }

        public static bool CheckIdentifierLayout()
        {
            bool result = false;
            result = true;
            if (Format("ID-%6.4d", new TVarRec[] { 73 }) != "ID-  0073")
                result = false;
            if (Format("HEX-%4.4x", new TVarRec[] { 0x2A }) != "HEX-002A")
                result = false;
            if (Format("%1:s/%0:s/%1:s", new TVarRec[] { "source", "target" }) != "target/source/target")
                result = false;
            return result;
        }

        public static bool CheckFloatingPointText()
        {
            bool result = false;
            TFormatSettings SavedSettings = TFormatSettings.CreateRecord();
            double Measurement = 0.0D;
            SavedSettings = FormatSettings;
            try
            {
                FormatSettings.DecimalSeparator = ',';
                FormatSettings.ThousandSeparator = '.';
                Measurement = 4312.24D;
                result = true;
                if (FloatToStr(12.5D) != "12,5")
                    result = false;
                if (FloatToStr(1E40D) != "1E40")
                    result = false;
                if (FormatFloat("#,##0.00", Measurement) != "4.312,24")
                    result = false;
                if (FormatFloat("000000", Measurement) != "004312")
                    result = false;
                if (FormatFloat("0.000", Measurement) != "4312,240")
                    result = false;
                if (FormatFloat("0.000E+00", Measurement) != "4,312E+03")
                    result = false;
                if (FormatFloat("0.0 \"up\";0.0 \"down\"", -Measurement) != "4312,2 down")
                    result = false;
                if (FormatFloat("0.0;-0.0;\"idle\"", 0.0F) != "idle")
                    result = false;
            }
            finally
            {
                FormatSettings = SavedSettings;
            }
            return result;
        }
    } // class D7_formattingImplementation

}  // namespace D7_formatting

