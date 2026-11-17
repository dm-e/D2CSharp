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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
namespace System
{
    public static class DelphiInterlocked
    {
        private static readonly object PointerGate = new();
        public static T CompareExchange<T>(ref T target, T value, T comparand)
        {
            Type type = typeof(T);
            if (type == typeof(Pointer) || type == typeof(UntypedPointer) ||
                type == typeof(PChar) || type == typeof(PAnsiChar) ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Pointer<>)))
            {
                // Pointer wrappers contain managed backing metadata. A shared
                // lock preserves their complete identity and atomic CAS update.
                lock (PointerGate)
                {
                    T previous = target;
                    if (EqualityComparer<T>.Default.Equals(previous, comparand)) target = value;
                    return previous;
                }
            }
            if (!type.IsValueType)
            {
                object? previous = Interlocked.CompareExchange(ref Unsafe.As<T, object?>(ref target), value, comparand);
                return (T)previous!;
            }
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                throw new NotSupportedException("Atomic bit comparison requires a scalar or a record without managed reference fields.");
            if (Unsafe.SizeOf<T>() == 4)
            {
                int previous = Interlocked.CompareExchange(ref Unsafe.As<T, int>(ref target),
                    Unsafe.As<T, int>(ref value), Unsafe.As<T, int>(ref comparand));
                return Unsafe.As<int, T>(ref previous);
            }
            if (Unsafe.SizeOf<T>() == 8)
            {
                long previous = Interlocked.CompareExchange(ref Unsafe.As<T, long>(ref target),
                    Unsafe.As<T, long>(ref value), Unsafe.As<T, long>(ref comparand));
                return Unsafe.As<long, T>(ref previous);
            }
            throw new NotSupportedException("Atomic bit comparison requires four or eight bytes.");
        }
        public static T CompareExchange<T>(ref T target, T value, T comparand, int width)
        {
            if (DelphiTypeLayout.SizeOf<T>() != width)
                throw new NotSupportedException("Atomic bit comparison must address the complete value.");
            return CompareExchange(ref target, value, comparand);
        }
        public static bool EqualBytes<T>(T left, T right)
        {
            int size = DelphiTypeLayout.SizeOf<T>();
            return DelphiValueCodec.ToBytes(left, typeof(T), size).AsSpan().SequenceEqual(
                DelphiValueCodec.ToBytes(right, typeof(T), size));
        }
    }
}