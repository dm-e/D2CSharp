using System.Sysutils;
using System;
using static D7_free_and_nil.D7_free_and_nilImplementation;
using static D7_free_and_nil.D7_free_and_nilInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;


namespace D7_free_and_nil
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


    public class D7_free_and_nilInterface
    {
        public static bool RunFreeAndNilChecks()
        {
            bool result = false;
            TReleaseProbe Probe = default;
            bool CheckResult1 = false;
            bool CheckResult2 = false;
            ReleaseProbeDestroyCount = 0;
            Probe = new TReleaseProbe();
            FreeAndNil(ref Probe);
            CheckResult1 = (Probe == default);
            result = CheckResult1;
            CheckResult2 = (ReleaseProbeDestroyCount == 1);
            result = result && CheckResult2;
            return result;
        }

    } // class D7_free_and_nilInterface


    file class D7_free_and_nilImplementation
    {


        public class TReleaseProbe : TObject
        {
            public override void Destroy()
            {
                if (!FDisposed)
                {
                    ++ReleaseProbeDestroyCount;
                    base.Destroy();
                }
            }

            public TReleaseProbe()
            {
            }
        }
        public static int ReleaseProbeDestroyCount = 0;
    } // class D7_free_and_nilImplementation

}  // namespace D7_free_and_nil

