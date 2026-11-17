using System;
using static Objfree.ObjfreeImplementation;
using static Objfree.ObjfreeInterface;
using static System.SystemInterface;


namespace Objfree
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


    public class ObjfreeInterface
    {
        public static bool TestNilObjectFree()
        {
            bool result = false;
            TObject Obj = default;
            result = false;
            Obj = default;
            try
            {
                TObject.Free(Obj);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool TestNilObjectFreeDoesNotCallDestructor()
        {
            bool result = false;
            TFreeTestObject Obj = default;
            result = false;
            Obj = default;
            GDestroyCount = 0;
            try
            {
                TObject.Free(Obj);
                result = GDestroyCount == 0;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool TestObjectFreeCallsDestructor()
        {
            bool result = false;
            TFreeTestObject Obj = default;
            result = false;
            Obj = default;
            GDestroyCount = 0;
            try
            {
                Obj = new TFreeTestObject();
                TObject.Free(Obj);
                Obj = default;
                result = GDestroyCount == 1;
            }
            catch
            {
                if (Obj != default)
                    TObject.Free(Obj);
                result = false;
            }
            return result;
        }
        public static bool TestObjectFreeUsesVirtualDestructor()
        {
            bool result = false;
            TObject Obj = default;
            result = false;
            Obj = default;
            GDestroyCount = 0;
            try
            {
                Obj = new TFreeTestObject();
                TObject.Free(Obj);
                Obj = default;
                result = GDestroyCount == 1;
            }
            catch
            {
                if (Obj != default)
                    TObject.Free(Obj);
                result = false;
            }
            return result;
        }
        public static bool TestObjFreeAll()
        {
            bool result = false;
            result = true;
            result = result && TestNilObjectFree();
            result = result && TestNilObjectFreeDoesNotCallDestructor();
            result = result && TestObjectFreeCallsDestructor();
            result = result && TestObjectFreeUsesVirtualDestructor();
            return result;
        }

    } // class ObjfreeInterface


    file class ObjfreeImplementation
    {


        public class TFreeTestObject : TObject
        {
            public override void Destroy()
            {
                if (!FDisposed)
                {
                    ++GDestroyCount;
                    base.Destroy();
                }
            }

            public TFreeTestObject()
            {
            }
        }
        public static int GDestroyCount = 0;
    } // class ObjfreeImplementation

}  // namespace Objfree

