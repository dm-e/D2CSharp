using System;
using static Objfree.ObjfreeImplementation;
using static Objfree.ObjfreeInterface;
using static System.SystemInterface;


namespace Objfree
{



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

