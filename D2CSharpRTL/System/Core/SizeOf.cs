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

using System;
using System.Collections.Concurrent;
using System.Reflection;

public static class D2C
{
    public enum DelphiTargetPlatform
    {
        Win32,
        Win64
    }

    private static readonly ConcurrentDictionary<Type, int> SizeCache =
        new ConcurrentDictionary<Type, int>();

    public static int SizeOf<T>()
    {
        return SizeOf(typeof(T));
    }

    public static int SizeOfVariable<T>(T Value)
    {
        // Delphi SizeOf uses the static type, not the runtime value.
        return SizeOf(typeof(T));
    }

    public static int SizeOf(Type Type)
    {
        if (Type == null)
        {
            throw new ArgumentNullException(nameof(Type));
        }

        return SizeCache.GetOrAdd(Type, CalculateSizeOf);
    }

#if D2C_TARGET_WIN64
    public const int PointerSize = 8;
#else
    public const int PointerSize = 4;
#endif

    private static int CalculateSizeOf(Type Type)
    {
        int PrimitiveSize;

        if (TryGetPrimitiveSize(Type, out PrimitiveSize))
        {
            return PrimitiveSize;
        }

        if (Type.IsEnum)
        {
            return SizeOf(Enum.GetUnderlyingType(Type));
        }

        int DeclaredSize;

        if (TryGetDeclaredDelphiSize(Type, out DeclaredSize))
        {
            return DeclaredSize;
        }

        if (Type == typeof(string))
        {
            return PointerSize;
        }

        if (Type.IsArray)
        {
            return PointerSize;
        }

        if (Type.IsInterface)
        {
            return PointerSize;
        }

        if (Type.IsClass)
        {
            return PointerSize;
        }

        throw new NotSupportedException(
            "Delphi SizeOf is not defined for type '" +
            Type.FullName + "'.");
    }
    private static bool TryGetPrimitiveSize(
        Type Type,
        out int Size)
    {
        if (Type == typeof(bool))
        {
            Size = 1;
            return true;
        }

        if (Type == typeof(byte))
        {
            Size = 1;
            return true;
        }

        if (Type == typeof(sbyte))
        {
            Size = 1;
            return true;
        }

        if (Type == typeof(short))
        {
            Size = 2;
            return true;
        }

        if (Type == typeof(ushort))
        {
            Size = 2;
            return true;
        }

        if (Type == typeof(char))
        {
            Size = 2;
            return true;
        }

        if (Type == typeof(int))
        {
            Size = 4;
            return true;
        }

        if (Type == typeof(uint))
        {
            Size = 4;
            return true;
        }

        if (Type == typeof(float))
        {
            Size = 4;
            return true;
        }

        if (Type == typeof(long))
        {
            Size = 8;
            return true;
        }

        if (Type == typeof(ulong))
        {
            Size = 8;
            return true;
        }

        if (Type == typeof(double))
        {
            Size = 8;
            return true;
        }

        /*
         * System.Decimal has a CLR size of 16 bytes.
         * Delphi Currency must use a separate Currency type whose
         * DelphiSizeOf value is 8.
         */
        if (Type == typeof(decimal))
        {
            Size = 16;
            return true;
        }

        if (Type == typeof(IntPtr))
        {
            Size = IntPtr.Size;
            return true;
        }

        if (Type == typeof(UIntPtr))
        {
            Size = UIntPtr.Size;
            return true;
        }

        Size = 0;
        return false;
    }

    //private static bool TryGetDeclaredDelphiSize(
    //    Type Type,
    //    out int Size)
    //{
    //    const BindingFlags Flags =
    //        BindingFlags.Public |
    //        BindingFlags.NonPublic |
    //        BindingFlags.Static |
    //        BindingFlags.FlattenHierarchy;

    //    FieldInfo Field = Type.GetField(
    //        "DelphiSizeOf",
    //        Flags);

    //    if ((Field != null) && (Field.FieldType == typeof(int)))
    //    {
    //        object Value = Field.GetValue(null);

    //        if (Value != null)
    //        {
    //            Size = (int)Value;
    //            ValidateSize(Type, Size);
    //            return true;
    //        }
    //    }

    //    PropertyInfo Property = Type.GetProperty(
    //        "DelphiSizeOf",
    //        Flags);

    //    if ((Property != null) &&
    //        (Property.PropertyType == typeof(int)) &&
    //        (Property.GetIndexParameters().Length == 0) &&
    //        (Property.GetMethod != null) &&
    //        Property.GetMethod.IsStatic)
    //    {
    //        object Value = Property.GetValue(null, null);

    //        if (Value != null)
    //        {
    //            Size = (int)Value;
    //            ValidateSize(Type, Size);
    //            return true;
    //        }
    //    }

    //    Size = 0;
    //    return false;
    //}
    private static bool TryGetDeclaredDelphiSize(
    Type Type,
    out int Size)
    {
        const BindingFlags Flags =
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy;

        FieldInfo Field = Type.GetField(
            "DelphiSizeOf",
            Flags);

        if (Field != null && Field.FieldType == typeof(int))
        {
            Size = (int)Field.GetValue(null);
            return true;
        }

        PropertyInfo Property = Type.GetProperty(
            "DelphiSizeOf",
            Flags);

        if (Property != null &&
            Property.PropertyType == typeof(int) &&
            Property.GetIndexParameters().Length == 0 &&
            Property.GetMethod != null &&
            Property.GetMethod.IsStatic)
        {
            Size = (int)Property.GetValue(null, null);
            return true;
        }

        Size = 0;
        return false;
    }
    private static void ValidateSize(
        Type Type,
        int Size)
    {
        if (Size < 0)
        {
            throw new InvalidOperationException(
                "Type '" + Type.FullName +
                "' declares a negative DelphiSizeOf value.");
        }
    }

    private static int GetNaturalAlignment(Type Type)
    {
        int Size = SizeOf(Type);

        if (Size >= 8)
        {
            return 8;
        }

        if (Size >= 4)
        {
            return 4;
        }

        if (Size >= 2)
        {
            return 2;
        }

        return 1;
    }

    private static int AlignUp(
        int Value,
        int Alignment)
    {
        return (Value + Alignment - 1) &
            ~(Alignment - 1);
    }

    public const int SizeOfReal = 8;

    //#if WIN64
    //    public const int SizeOfExtended = 8;
    //#else
    //        public const int SizeOfExtended = 10;
    //#endif

    public static bool IsWin64
    {
        get
        {
            return IntPtr.Size == 8;
        }
    }

    public const DelphiTargetPlatform TargetPlatform =
  DelphiTargetPlatform.Win32;

    public static int SizeOfExtended
    {
        get
        {
            return TargetPlatform == DelphiTargetPlatform.Win64
                ? 8
                : 10;
        }
    }
}




