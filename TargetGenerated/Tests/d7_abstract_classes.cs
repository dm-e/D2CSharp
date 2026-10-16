using System;
using static D7_abstract_classes.D7_abstract_classesImplementation;
using static D7_abstract_classes.D7_abstract_classesInterface;
using static System.SystemInterface;


namespace D7_abstract_classes
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

    public class D7_abstract_classesInterface
    {

        abstract public class TImportTask : TObject
        {
            private string FSourceName = string.Empty;
            private string FProfile = string.Empty;
            abstract protected void Configure();
            /*property Profile : string read FProfile write FProfile;*/
            protected string Profile
            {
                get
                {
                    return FProfile;
                }
                set
                {
                    FProfile = value;
                }
            }
            public TImportTask(string ASourceName)
            {
                ;
                FSourceName = ASourceName;
                Configure();
            }
            /*property SourceName : string read FSourceName;*/
            public string SourceName
            {
                get
                {
                    return FSourceName;
                }
            }
            /*property SelectedProfile : string read FProfile;*/
            public string SelectedProfile
            {
                get
                {
                    return FProfile;
                }
            }
        }

        public class TDelimitedImportTask : TImportTask
        {
            protected override void Configure()
            {
                Profile = "delimited:semicolon";
            }

            public TDelimitedImportTask(string ASourceName) : base(ASourceName) { }
        }

        public class TStructuredImportTask : TImportTask
        {
            protected override void Configure()
            {
                Profile = "structured:object";
            }

            public TStructuredImportTask(string ASourceName) : base(ASourceName) { }
        }
        public static bool RunAbstractClassChecks()
        {
            bool result = false;
            TDelimitedImportTask DelimitedTask = default;
            TStructuredImportTask StructuredTask = default;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            bool CheckResult3 = false;
            bool CheckResult4 = false;
            DelimitedTask = new TDelimitedImportTask("measurements.txt");
            StructuredTask = new TStructuredImportTask("settings.data");
            try
            {
                CheckResult1 = (DelimitedTask.SourceName == "measurements.txt");
                result = CheckResult1;
                CheckResult2 = (DelimitedTask.SelectedProfile == "delimited:semicolon");
                result = result && CheckResult2;
                CheckResult3 = (StructuredTask.SourceName == "settings.data");
                result = result && CheckResult3;
                CheckResult4 = (StructuredTask.SelectedProfile == "structured:object");
                result = result && CheckResult4;
            }
            finally
            {
                TObject.Free(StructuredTask);
                TObject.Free(DelimitedTask);
            }
            return result;
        }

    } // class D7_abstract_classesInterface


    file class D7_abstract_classesImplementation
    {

    } // class D7_abstract_classesImplementation

}  // namespace D7_abstract_classes

