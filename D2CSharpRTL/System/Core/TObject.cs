/*
  D2CSharp Runtime Library (RTL)

  This file is implemented directly in C# and provides supporting
  functionality for the runtime library. It is not generated from
  a Delphi source file.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: MPL-2.0

  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at https://mozilla.org/MPL/2.0/.

  Part of the D2CSharp project by t2t-soft.
*/

using System.Formats.Asn1;
using static Winapi.Windows.WindowsInterface;
using static System.SystemInterface;

namespace System
{

    public sealed class DelphiInterfaceEntry
    {
        private readonly Guid FIID;
        private readonly Type FInterfaceType;
        private readonly Func<TObject, object> FGetter;

        public DelphiInterfaceEntry(Guid iid, Type interfaceType, Func<TObject, object> getter)
        {
            if (interfaceType == null)
                throw new ArgumentNullException("interfaceType");

            if (!interfaceType.IsInterface)
                throw new ArgumentException("The type must be an interface type.", "interfaceType");

            if (getter == null)
                throw new ArgumentNullException("getter");

            FIID = iid;
            FInterfaceType = interfaceType;
            FGetter = getter;
        }

        public Guid IID
        {
            get
            {
                return FIID;
            }
        }

        public Type InterfaceType
        {
            get
            {
                return FInterfaceType;
            }
        }

        public object GetObject(TObject self)
        {
            if (self == null)
                return null;

            return FGetter(self);
        }
    }
    public class TObject
    {
        protected bool FDisposed;

        public virtual void Destroy()
        {
            if (!FDisposed)
            {
                FDisposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public void Free()
        {
            Destroy();
        }

        public static void Free(TObject obj)
        {
            if (obj != null)
            {
                obj.Destroy();
            }
        }

        public TClass ClassType()
        {
            return TClass.Of(GetType());
        }

        public string ClassName()
        {
            return ClassType().ClassName();
        }

        public bool ClassNameIs(string name)
        {
            return ClassType().ClassNameIs(name);
        }

        public TClass ClassParent()
        {
            return ClassType().ClassParent();
        }

        public bool InheritsFrom(TClass aClass)
        {
            return ClassType().InheritsFrom(aClass);
        }

        // dme from old code
        public string InterfaceName()  
        {
            return this.ToString();
        }

        //    public virtual bool GetInterface<TInterface>(out TInterface obj)
        //where TInterface : class
        //    {
        //        obj = this as TInterface;
        //        return obj != null;
        //    }

        //    public virtual bool GetInterface(global::System.Type interfaceType, out object obj)
        //    {
        //        obj = null;

        //        if (interfaceType == null || !interfaceType.IsInterface)
        //        {
        //            return false;
        //        }

        //        if (interfaceType.IsInstanceOfType(this))
        //        {
        //            obj = this;
        //            return true;
        //        }

        //        return false;
        //    }

        //    public virtual bool GetInterface(global::System.Guid iid, out object obj)
        //    {
        //        obj = null;

        //        global::System.Type interfaceType = TInterfaceRegistry.GetInterfaceType(iid);

        //        if (interfaceType == null)
        //        {
        //            return false;
        //        }

        //        return GetInterface(interfaceType, out obj);
        //    }

        protected virtual IEnumerable<DelphiInterfaceEntry> GetDelphiInterfaces()
        {
            yield break;
        }

        public virtual bool GetInterface(Guid iid, out object obj)
        {
            foreach (DelphiInterfaceEntry entry in GetDelphiInterfaces())
            {
                if (entry.IID.Equals(iid))
                {
                    obj = entry.GetObject(this);
                    return obj != null;
                }
            }

            obj = null;
            return false;
        }

        public virtual int QueryInterface(Guid iid, out object obj)
        {
            if (GetInterface(iid, out obj))
                return S_OK;

            return E_NOINTERFACE;
        }

    }

    //public static class TInterfaceRegistry
    //{
    //    private static readonly global::System.Collections.Generic.Dictionary<global::System.Guid, global::System.Type> FTypes =
    //        new global::System.Collections.Generic.Dictionary<global::System.Guid, global::System.Type>();

    //    public static void Register(global::System.Guid iid, global::System.Type interfaceType)
    //    {
    //        FTypes[iid] = interfaceType;
    //    }

    //    public static global::System.Type GetInterfaceType(global::System.Guid iid)
    //    {
    //        global::System.Type result;

    //        if (FTypes.TryGetValue(iid, out result))
    //        {
    //            return result;
    //        }

    //        return null;
    //    }
    //}
}
