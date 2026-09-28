using System;
using static Factory.FactoryImplementation;
using static Factory.FactoryInterface;
using static System.SystemInterface;


namespace Factory
{

    /*
      D2CSharp test file

      Original source language: Delphi (Pascal).
      The corresponding C# files are automatically translated from the
      Delphi source files by D2CSharp.
      This notice is retained unchanged in both versions.

      Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
      SPDX-License-Identifier: Apache-2.0  
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


    public class FactoryInterface
    {

        public class TFBase : TObject
        {
            public virtual string GetName()
            {
                string result = string.Empty;
                result = "TFBase";
                return result;
            }

            public TFBase()
            {
            }
        }

        // ClassRef<TFBase> TFBaseClass;

        public class TFDerived1 : TFBase
        {
            public override string GetName()
            {
                string result = string.Empty;
                result = "TFDerived1";
                return result;
            }

            public TFDerived1()
            {
            }
        }

        // ClassRef<TFDerived1> TFDerived1Class;

        public class TFDerived1b : TFBase
        {
            public TFDerived1b(string s)
            {
                FName = s;
            }
            public override string GetName()
            {
                string result = string.Empty;
                result = FName;
                return result;
            }
            private string FName = string.Empty;
        }

        // ClassRef<TFDerived1b> TFDerived1bClass;

        public class TFDerived2 : TFDerived1
        {
            public override string GetName()
            {
                string result = string.Empty;
                result = "TFDerived2";
                return result;
            }
            private string FName = string.Empty;

            public TFDerived2()
            {
            }
        }
        public static bool testfactory()
        {
            bool result = false;
            string s = string.Empty;
            TFBase p = default;
            p = make(TClass.Of<TFDerived1>());
            result = p.GetName() == "TFDerived1";
            p = make(TClass.Of<TFDerived1b>());
            result = result && (p.GetName() == "");
            result = result && TestInheritsFrom();
            return result;
        }

    } // class FactoryInterface


    file class FactoryImplementation
    {


        public static TFBase make(TClass Base)
        {
            TFBase result = default;
            result = (TFBase)Base.Create();
            return result;
        }

        public static bool TestInheritsFrom()
        {
            bool result = false;
            TFBase b = default;
            TFDerived1 d1 = default;
            TFDerived1b d2 = default;
            TFDerived2 d1d = default;
            TClass bc = default;
            TClass d1c = default;
            TClass d2c = default;
            TClass cls1 = default;
            TClass cls2 = default;
            TClass cls3 = default;
            TClass pcls1 = default;
            TClass pcls2 = default;
            b = new TFBase();
            d1 = new TFDerived1();
            d2 = new TFDerived1b("");
            d1d = new TFDerived2();
            bc = TClass.Of<TFBase>();
            d1c = TClass.Of<TFDerived1>();
            d2c = TClass.Of<TFDerived1b>();
            result = true;
            cls1 = b.ClassType();
            result = result && (cls1 == bc);
            cls2 = d1.ClassType();
            result = result && (cls2 == d1c);
            pcls1 = d1c.ClassParent();
            result = result && (pcls1 == bc);
            cls3 = d1d.ClassType();
            result = result && (cls3 == TClass.Of<TFDerived2>());
            pcls2 = cls3.ClassParent();
            result = result && (pcls2 == d1c);
            result = result && d1.InheritsFrom(bc);
            result = result && d1c.InheritsFrom(bc);
            result = result && d2.InheritsFrom(bc);
            result = result && d2c.InheritsFrom(bc);
            result = result && !d2.InheritsFrom(d1c);
            result = result && !d2c.InheritsFrom(d1c);
            result = result && d1.InheritsFrom(TClass.Of<TFBase>());
            result = result && TClass.Of<TFDerived1>().InheritsFrom(TClass.Of<TFBase>());
            result = result && d1c.InheritsFrom(TClass.Of<TFBase>());
            result = result && d2.InheritsFrom(TClass.Of<TFBase>());
            result = result && d2c.InheritsFrom(TClass.Of<TFBase>());
            result = result && !d2.InheritsFrom(TClass.Of<TFDerived1>());
            result = result && !d2c.InheritsFrom(TClass.Of<TFDerived1>());
            result = result && !b.InheritsFrom(d1c);
            result = result && d1d.InheritsFrom(TClass.Of<TFBase>());
            result = result && d1d.InheritsFrom(TClass.Of<TFDerived1>());
            result = result && !d1d.InheritsFrom(TClass.Of<TFDerived1b>());
            return result;
        }
    } // class FactoryImplementation

}  // namespace Factory

