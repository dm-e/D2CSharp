using System;
using static System.SystemInterface;
using static Vstatic.VstaticImplementation;
using static Vstatic.VstaticInterface;


namespace Vstatic
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


    public class VstaticInterface
    {

        public class a : TObject
        {
            public a()
            {
                _result = "a::a ";
            }
            public virtual string prn()
            {
                string result = string.Empty;
                result = "a";
                return result;
            }
        }

        public class b : a
        {
            public b()
            {
                _result = "b::b";
            }
            public override string prn()
            {
                string result = string.Empty;
                result = "b";
                return result;
            }
        }

        public class c : b
        {
            public c()
            {
                _result = "c::c";
            }
            public override string prn()
            {
                string result = string.Empty;
                result = "c";
                return result;
            }
        }

        public class d : c
        {
            public d()
            {
                _result = "d::d";
            }
            public override string prn()
            {
                string result = string.Empty;
                result = "d";
                return result;
            }
        }

        public class TBase : TObject
        {
            public virtual void Init()
            {
                _result = "TBase.Init";
            }
            public void Done()
            {
                _result = "TBase.Done";
            }
            public static /*#virtual*/ int ClassVirtual(int xi)
            {
                int result = 0;
                /*# with Create do */
                {
                    TBase with0 = (TBase)(TBase)TClass.ClassMethodSelf<TBase>().Create();
                    with0.Init();
                    with0.Done();
                    with0.Free();
                }
                result = xi;
                return result;
            }
            public static int ClassMethod(int xi)
            {
                int result = 0;
                /*# with Create do */
                {
                    TBase with0 = (TBase)new TBase();
                    with0.Init();
                    with0.Done();
                    with0.Free();
                }
                result = xi;
                return result;
            }
            public static int SecondClassMethod(int xi)
            {
                int result = 0;
                TBase Base = default;
                ClassMethod(xi);
                ClassVirtual(xi);
                Base = new TBase();
                TBase.ClassMethod(0);
                TObject.Free(Base);
                return result;
            }

            public TBase()
            {
            }
        }

        public class TDerived1 : TBase
        {
            public static new int ClassVirtual(int xi)
            {
                int result = 0;
                /*# with Create do */
                {
                    TDerived1 with0 = (TDerived1)(TDerived1)TClass.ClassMethodSelf<TDerived1>().Create();
                    with0.Init();
                    with0.Done();
                    with0.Free();
                }
                result = xi;
                return result;
            }

            ///////////  Derived1
            public override void Init()
            {
                _result = "TDerived1.Init";
            }
            public void Done()
            {
                _result = "TDerived1.Done";
            }

            public TDerived1()
            {
            }
        }

        public class TDerived2 : TDerived1
        {



            ///////////  Derived2
            public override void Init()
            {
                _result = "TDerived2.Init";
            }
            public void Done()
            {
                _result = "TDerived2.Done";
            }
            public static new int ClassVirtual(int xi)
            {
                int result = 0;
                /*# with Create do */
                {
                    TDerived2 with0 = (TDerived2)(TDerived2)TClass.ClassMethodSelf<TDerived2>().Create();
                    with0.Init();
                    with0.Done();
                    with0.Free();
                }
                result = xi;
                return result;
            }

            public TDerived2()
            {
            }
        }
        public static bool TestVStatic()
        {
            bool result = false;
            TObject pobj = default;
            TClass mobj = default;
            a pa = default;
            TClass ma = default;
            a pa2 = default;
            TClass ma2 = default;
            b pb = default;
            TClass mb = default;
            c pc = default;
            TClass mc = default;
            a aBase = default;
            TBase p = default;
            TBase pBase = default;
            TDerived1 pDerived1 = default;
            TDerived2 pDerived2 = default;
            bool bl = false;
            string s1 = string.Empty;
            string s2 = string.Empty;
            result = true;
            pobj = new TObject();
            mobj = pobj.ClassType();
            s1 = pobj.ClassName(); // Delphi: 'TObject'; VisualC++: class System::TObject
            s2 = mobj.ClassName();
            result = result && (s1 == s2);

            // compile test: call class method by instance and by class
            pBase = new TBase();
            TBase.ClassMethod(0);
            TBase.ClassMethod(0);
            // compile test end
            pa = new a();
            ma = pa.ClassType();
            s1 = pa.ClassName();
            s2 = ma.ClassName();
            result = result && (s1 == s2);
            pb = new b();
            mb = pb.ClassType();
            s1 = pb.ClassName();
            s2 = mb.ClassName();
            result = result && (s1 == s2);
            pc = new c();
            mc = pc.ClassType();
            s1 = pc.ClassName();
            s2 = mc.ClassName();
            result = result && (s1 == s2);
            pa2 = pc;
            ma2 = mc;
            s1 = pa2.ClassName();   // c
            s2 = ma2.ClassName();   // c
            result = result && (s1 == s2);
            s1 = pb.ClassName();
            s2 = mc.ClassName();
            result = result && (s1 != s2);
            aBase = new c();
            s1 = aBase.prn(); // = 'c';
            bl = pa.ClassType().InheritsFrom(pobj.ClassType());
            result = result && bl;
            bl = pa.ClassType().InheritsFrom(pc.ClassType());
            result = result && !bl;
            bl = pc.ClassType().InheritsFrom(pa.ClassType());
            result = result && bl;
            bl = pa.InheritsFrom(pc.ClassType());
            result = result && !bl;
            bl = pc.InheritsFrom(pa.ClassType());
            result = result && bl;
            bl = pa.InheritsFrom(TClass.Of<c>());
            result = result && !bl;
            bl = pc.InheritsFrom(TClass.Of<a>());
            result = result && bl;

            //------
            aBase = pb;
            s1 = aBase.ClassName(); // = 'b'
            mobj = aBase.ClassType();
            s2 = mobj.ClassName(); // = 'b'
            ma = aBase.ClassType();
            result = result && (s1 == s2);
            s1 = ma.ClassName(); // = 'b'
            mb = aBase.ClassType();
            s2 = mb.ClassName(); // = 'b'
            result = result && (s1 == s2);
            pBase = new TBase();
            pDerived1 = new TDerived1();
            pDerived2 = new TDerived2();
            TBase.ClassMethod(0);
            result = result && (_result == "TBase.Done");
            TDerived1.ClassMethod(1);
            result = result && (_result == "TBase.Done");
            TDerived2.ClassMethod(2);
            result = result && (_result == "TBase.Done");
            pBase.ClassType().InvokeClassMethod<int>("ClassVirtual", 1);
            result = result && (_result == "TBase.Done");
            pDerived1.ClassType().InvokeClassMethod<int>("ClassVirtual", 1);
            result = result && (_result == "TDerived1.Done");
            pDerived2.ClassType().InvokeClassMethod<int>("ClassVirtual", 2);
            result = result && (_result == "TDerived2.Done");
            p = pDerived1;
            p.ClassType().InvokeClassMethod<int>("ClassVirtual", 1);
            result = result && (_result == "TDerived1.Done");
            p = pDerived2;
            p.ClassType().InvokeClassMethod<int>("ClassVirtual", 2);
            result = result && (_result == "TDerived2.Done");
            TBase.ClassMethod(0);
            result = result && (_result == "TBase.Done");
            TDerived1.ClassMethod(1);
            result = result && (_result == "TBase.Done");
            TDerived2.ClassMethod(2);
            result = result && (_result == "TBase.Done");
            TClass.Of<TBase>().InvokeClassMethod<int>("ClassVirtual", 0);
            result = result && (_result == "TBase.Done");
            TClass.Of<TDerived1>().InvokeClassMethod<int>("ClassVirtual", 1);
            result = result && (_result == "TDerived1.Done");
            TClass.Of<TDerived2>().InvokeClassMethod<int>("ClassVirtual", 2);
            result = result && (_result == "TDerived2.Done");
            TObject.Free(pa);
            TObject.Free(pb);
            TObject.Free(pc);
            TObject.Free(pBase);
            TObject.Free(pDerived1);
            TObject.Free(pDerived2);
            return result;
        }

    } // class VstaticInterface


    file class VstaticImplementation
    {

        public static string _result = string.Empty;
    } // class VstaticImplementation

}  // namespace Vstatic

