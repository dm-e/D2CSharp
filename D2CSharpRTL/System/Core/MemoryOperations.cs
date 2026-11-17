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

#nullable enable
using System.Reflection;

namespace System
{
    public static partial class SystemInterface
    {
        public static Exception RaisedObject(object value) =>
            value as Exception ?? new DelphiRaisedObjectException(value);

        public static void MoveToValue<T>(UntypedPointer source, ref T destination, int count)
        {
            T[] cell = new[] { destination };
            DelphiMemory.Move(source, UntypedPointer.FromByteIndex(cell), count);
            destination = cell[0];
        }
        public static void MoveChars(UntypedPointer source, UntypedPointer destination, int count)
        {
            if (count <= 0) return;
            DelphiMemory.Move(source, destination, checked(count * sizeof(char)));
        }

        public static void Initialize<T>(Pointer<T> pointer) =>
            pointer.Assign(ResetManagedFields(pointer.Deref()));

        public static void Initialize<T>(ref T value) => value = ResetManagedFields(value);

        public static void Finalize<T>(Pointer<T> pointer) =>
            pointer.Assign(ResetManagedFields(pointer.Deref()));

        public static void Finalize<T>(ref T value) => value = ResetManagedFields(value);

        private static T ResetManagedFields<T>(T value) => (T)ResetManagedFields(typeof(T), value)!;

        private static object? ResetManagedFields(Type type, object? value)
        {
            if (type == typeof(string)) return string.Empty;
            if (type == typeof(AnsiString)) return AnsiString.Empty;
            if (type.IsArray || type.IsInterface) return null;
            if (!type.IsValueType || type.IsPrimitive || type.IsEnum) return value;

            object result = value ?? Activator.CreateInstance(type)!;
            foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (field.IsInitOnly) continue;
                object? before = field.GetValue(result);
                object? after = ResetManagedFields(field.FieldType, before);
                field.SetValue(result, after);
            }
            return result;
        }
    }

    public sealed class DelphiRaisedObjectException : Exception
    {
        public object RaisedValue { get; }
        public DelphiRaisedObjectException(object value) : base(value?.GetType().FullName)
        {
            RaisedValue = value;
        }
    }
}
