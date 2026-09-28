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

namespace System
{
    public sealed class TClass : global::System.IEquatable<TClass>
    {
        private readonly global::System.Type _type;

        private TClass(global::System.Type type)
        {
            _type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public global::System.Type Type
        {
            get
            {
                return _type;
            }
        }

        // Do not constrain T to TObject here.
        // TClass must also be able to represent and create DException-derived types,
        // which are translated to C# exceptions and therefore do not derive from TObject.
        public static TClass Of<T>()
        {
            return new TClass(typeof(T));
        }

        public static TClass Of(global::System.Type type)
        {
            if (type == null)
            {
                return null;
            }

            return new TClass(type);
        }

        public TObject Create()
        {
            return (TObject)global::System.Activator.CreateInstance(_type);
        }

        public object Create(params object[] args)
        {
            return global::System.Activator.CreateInstance(_type, args);
        }

        public global::System.Exception CreateException(params object[] args)
        {
            return (global::System.Exception)global::System.Activator.CreateInstance(_type, args);
        }

        public string ClassName()
        {
            return _type.Name;
        }

        public string QualifiedClassName()
        {
            return _type.FullName ?? _type.Name;
        }

        public string UnitName()
        {
            return _type.Namespace ?? string.Empty;
        }

        public string UnitScope()
        {
            string ns = _type.Namespace ?? string.Empty;
            int index = ns.LastIndexOf('.');

            if (index < 0)
            {
                return ns;
            }

            return ns.Substring(0, index);
        }

        public TClass ClassParent()
        {
            global::System.Type baseType = _type.BaseType;

            if (baseType == null || baseType == typeof(object))
            {
                return null;
            }

            return Of(baseType);
        }

        public bool InheritsFrom(TClass aClass)
        {
            if (aClass == null)
            {
                return false;
            }

            return aClass._type.IsAssignableFrom(_type);
        }

        public bool IsInstance(object instance)
        {
            return instance != null && _type.IsInstanceOfType(instance);
        }

        public static bool IsInstance(object instance, TClass aClass)
        {
            return aClass != null && aClass.IsInstance(instance);
        }

        public bool ClassNameIs(string name)
        {
            return string.Equals(ClassName(), name, global::System.StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(TClass other)
        {
            return other != null && _type == other._type;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TClass);
        }

        public override int GetHashCode()
        {
            return _type.GetHashCode();
        }

        //public virtual Pointer<TInterfaceEntry> GetInterfaceEntry(global::System.Guid iid)
        //{
        //    return null;
        //}

        //public virtual Pointer<TInterfaceTable> GetInterfaceTable()
        //{
        //    return null;
        //}

        public object InvokeClassMethod(string methodName, params object[] args)
        {
            global::System.Reflection.MethodInfo method = Type.GetMethod(
                methodName,
                global::System.Reflection.BindingFlags.Public |
                global::System.Reflection.BindingFlags.Static |
                global::System.Reflection.BindingFlags.FlattenHierarchy);

            if (method == null)
            {
                throw new global::System.MissingMethodException(Type.FullName, methodName);
            }

            return method.Invoke(null, args);
        }

        public TResult InvokeClassMethod<TResult>(string methodName, params object[] args)
        {
            object result = InvokeClassMethod(methodName, args);

            if (result == null)
            {
                return default(TResult);
            }

            return (TResult)result;
        }
        public static bool operator ==(TClass left, TClass right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(TClass left, TClass right)
        {
            return !(left == right);
        }
    }

}
