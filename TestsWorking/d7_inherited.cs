using System;
using static D7_inherited.D7_inheritedImplementation;
using static D7_inherited.D7_inheritedInterface;
using static System.SystemInterface;


namespace D7_inherited
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


    public class D7_inheritedInterface
    {
        public static bool RunInheritedChecks()
        {
            bool result = false;
            TBaseRenderer Renderer = default;
            bool CheckResult1 = false;
            Renderer = new TTaggedRenderer();
            try
            {
                CheckResult1 = Renderer.Render("payload") == "base[payload]:tagged";
                result = CheckResult1;
            }
            finally
            {
                TObject.Free(Renderer);
            }
            return result;
        }

    } // class D7_inheritedInterface


    file class D7_inheritedImplementation
    {


        public class TBaseRenderer : TObject
        {

            public virtual string Render(string AText)
            {
                string result = string.Empty;
                result = "base[" + AText + "]";
                return result;
            }

            public TBaseRenderer()
            {
            }
        }

        public class TTaggedRenderer : TBaseRenderer
        {

            public override string Render(string AText)
            {
                string result = string.Empty;
                result = base.Render(AText) + ":tagged";
                return result;
            }

            public TTaggedRenderer()
            {
            }
        }
    } // class D7_inheritedImplementation

}  // namespace D7_inherited

