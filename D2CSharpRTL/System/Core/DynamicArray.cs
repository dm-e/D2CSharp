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

using System;
using System.Collections.Generic;

#if USEDYNAMICARRAY

namespace System
{
    public interface IDynamicArray
    {
        Array? RawArrayUntyped { get; }
        int Length { get; }
    }

    public struct DynamicArray<T> : IDynamicArray, IEquatable<DynamicArray<T>>
    {
        private T[]? FData;

        public DynamicArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            FData = length == 0 ? null : new T[length];
        }

        public DynamicArray(T[]? data, bool copy = false)
        {
            FData = data == null || data.Length == 0
                ? null
                : copy
                    ? (T[])data.Clone()
                    : data;
        }

        public int Length => FData?.Length ?? 0;
        public int Count => Length;
        public int Low => 0;
        public int High => Length - 1;
        public bool IsNil => FData == null;
        public Array? RawArrayUntyped => FData;
        internal T[]? RawArray => FData;

        public ref T this[int index]
        {
            get
            {
                if (FData == null)
                    throw new IndexOutOfRangeException(
                        "Dynamic array is nil.");

                if ((uint)index >= (uint)FData.Length)
                    throw new IndexOutOfRangeException();

                return ref FData[index];
            }
        }
        public static void SetLength<T>(
            ref DynamicArray<T> array,
            int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            array.SetLength(length);
        }

        public void SetLength(int newLength)
        {
            if (newLength < 0)
                throw new ArgumentOutOfRangeException(nameof(newLength));

            if (newLength == 0)
            {
                FData = null;
                return;
            }

            Array.Resize(ref FData, newLength);
        }

        public static void SetLength<T>(ref DynamicArray<DynamicArray<T>> array, int length1, int length2)
        {
            if (length1 < 0)
                throw new ArgumentOutOfRangeException(nameof(length1));

            if (length2 < 0)
                throw new ArgumentOutOfRangeException(nameof(length2));

            array.SetLength(length1);

            for (int i = 0; i < length1; i++)
            {
                array[i].SetLength(length2);
            }
        }
        public int IndexOf(T value)
        {
            return IndexOf(value, 0, Length);
        }

        public int IndexOf(T value, int startIndex)
        {
            return IndexOf(value, startIndex, Length - startIndex);
        }

        public int IndexOf(T value, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex > Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (count < 0 || startIndex + count > Length)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (FData == null)
                return -1;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (comparer.Equals(FData[i], value))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            int oldLength = Length;
            SetLength(oldLength + 1);

            if (FData == null)
                throw new InvalidOperationException();

            if (index < oldLength)
            {
                Array.Copy(
                    FData,
                    index,
                    FData,
                    index + 1,
                    oldLength - index);
            }

            FData[index] = value;
        }

        public int Add(T value)
        {
            int index = Length;
            Insert(index, value);
            return index;
        }

        public void RemoveAt(int index)
        {
            int oldLength = Length;

            if (index < 0 || index >= oldLength)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (FData == null)
                throw new InvalidOperationException();

            if (index < oldLength - 1)
            {
                Array.Copy(
                    FData,
                    index + 1,
                    FData,
                    index,
                    oldLength - index - 1);
            }

            FData[oldLength - 1] = default!;
            SetLength(oldLength - 1);
        }

        public DynamicArray<T> GetRange(int index, int count)
        {
            if (index < 0 || index > Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (count < 0 || index + count > Length)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (count == 0)
                return default;
            if (FData == null)
                throw new InvalidOperationException();

            T[] result = new T[count];
            Array.Copy(FData, index, result, 0, count);
            return new DynamicArray<T>(result);
        }

        public void RemoveRange(int index, int count)
        {
            int oldLength = Length;

            if (index < 0 || index > oldLength)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (count < 0 || index + count > oldLength)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (count == 0)
                return;
            if (FData == null)
                throw new InvalidOperationException();

            int moveCount = oldLength - index - count;

            if (moveCount > 0)
            {
                Array.Copy(
                    FData,
                    index + count,
                    FData,
                    index,
                    moveCount);
            }

            Array.Clear(FData, oldLength - count, count);
            SetLength(oldLength - count);
        }

        public DynamicArray<T> Copy()
        {
            return FData == null
                ? default
                : new DynamicArray<T>((T[])FData.Clone());
        }

        public DynamicArray<T> Copy(int index, int count)
        {
            if (FData == null || count <= 0)
                return default;
            if (index < 0)
                index = 0;
            if (index >= FData.Length)
                return default;

            int actualCount = Math.Min(count, FData.Length - index);
            T[] result = new T[actualCount];
            Array.Copy(FData, index, result, 0, actualCount);
            return new DynamicArray<T>(result);
        }

        public T[] AsArray() => FData ?? Array.Empty<T>();
        public static DynamicArray<T> FromArray(T[]? array) => new DynamicArray<T>(array);
        public Span<T> AsSpan() => FData == null ? Span<T>.Empty : FData.AsSpan();
        public ReadOnlySpan<T> AsReadOnlySpan() => FData == null ? ReadOnlySpan<T>.Empty : FData.AsSpan();

        public bool Equals(DynamicArray<T> other) => ReferenceEquals(FData, other.FData);
        public override bool Equals(object? obj) => obj is DynamicArray<T> other && Equals(other);
        public override int GetHashCode() => FData?.GetHashCode() ?? 0;
        public static bool operator ==(DynamicArray<T> left, DynamicArray<T> right) => left.Equals(right);
        public static bool operator !=(DynamicArray<T> left, DynamicArray<T> right) => !left.Equals(right);
        public static implicit operator DynamicArray<T>(T[]? value) => new DynamicArray<T>(value);
        public static explicit operator T[](DynamicArray<T> value) => value.FData ?? Array.Empty<T>();
    }

    public static class DelphiArray
    {
        public static int Length<T>(DynamicArray<T> array) => array.Length;
        public static int Length<T>(DynamicArray<T>? array) => array?.Length ?? 0;
        public static int Low<T>(DynamicArray<T> array) => 0;
        public static int Low<T>(DynamicArray<T>? array) => 0;
        public static int High<T>(DynamicArray<T> array) => array.Length - 1;
        public static int High<T>(DynamicArray<T>? array) => (array?.Length ?? 0) - 1;

        public static void SetLength<T>(ref DynamicArray<T> array, int length)
        {
            array.SetLength(length);
        }

        public static void SetLength<T>(ref DynamicArray<T>? array, int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            DynamicArray<T> value = array.GetValueOrDefault();
            value.SetLength(length);
            array = length == 0 ? null : value;
        }

        public static void SetLength2D<T>(
            ref DynamicArray<DynamicArray<T>> array,
            int length1,
            int length2)
        {
            if (length1 < 0)
                throw new ArgumentOutOfRangeException(nameof(length1));
            if (length2 < 0)
                throw new ArgumentOutOfRangeException(nameof(length2));

            array.SetLength(length1);

            for (int i = 0; i < length1; i++)
            {
                DynamicArray<T> row = array[i];
                row.SetLength(length2);
                array[i] = row;
            }
        }

        public static void SetLength2D<T>(
            ref DynamicArray<DynamicArray<T>>? array,
            int length1,
            int length2)
        {
            DynamicArray<DynamicArray<T>> value = array.GetValueOrDefault();
            SetLength2D(ref value, length1, length2);
            array = length1 == 0 ? null : value;
        }

        public static void SetLength<T>(
            ref DynamicArray<DynamicArray<T>> array,
            int length1,
            int length2)
        {
            SetLength2D(ref array, length1, length2);
        }

        public static void SetLength<T>(
            ref DynamicArray<DynamicArray<T>>? array,
            int length1,
            int length2)
        {
            SetLength2D(ref array, length1, length2);
        }

        public static void SetLength3D<T>(
            ref DynamicArray<DynamicArray<DynamicArray<T>>> array,
            int length1,
            int length2,
            int length3)
        {
            if (length1 < 0)
                throw new ArgumentOutOfRangeException(nameof(length1));
            if (length2 < 0)
                throw new ArgumentOutOfRangeException(nameof(length2));
            if (length3 < 0)
                throw new ArgumentOutOfRangeException(nameof(length3));

            array.SetLength(length1);

            for (int i = 0; i < length1; i++)
            {
                DynamicArray<DynamicArray<T>> plane = array[i];
                SetLength2D(ref plane, length2, length3);
                array[i] = plane;
            }
        }

        public static void SetLength3D<T>(
            ref DynamicArray<DynamicArray<DynamicArray<T>>>? array,
            int length1,
            int length2,
            int length3)
        {
            DynamicArray<DynamicArray<DynamicArray<T>>> value = array.GetValueOrDefault();
            SetLength3D(ref value, length1, length2, length3);
            array = length1 == 0 ? null : value;
        }

        public static void SetLength<T>(
            ref DynamicArray<DynamicArray<DynamicArray<T>>> array,
            int length1,
            int length2,
            int length3)
        {
            SetLength3D(ref array, length1, length2, length3);
        }

        public static void SetLength<T>(
            ref DynamicArray<DynamicArray<DynamicArray<T>>>? array,
            int length1,
            int length2,
            int length3)
        {
            SetLength3D(ref array, length1, length2, length3);
        }

        public static DynamicArray<T> Copy<T>(DynamicArray<T> array) => array.Copy();
        public static DynamicArray<T> Copy<T>(DynamicArray<T>? array) => array?.Copy() ?? default;
        public static DynamicArray<T> Copy<T>(DynamicArray<T> array, int index, int count) => array.Copy(index, count);
        public static DynamicArray<T> Copy<T>(DynamicArray<T>? array, int index, int count) => array?.Copy(index, count) ?? default;
        public static bool Assigned<T>(DynamicArray<T> array) => !array.IsNil;
        public static bool Assigned<T>(DynamicArray<T>? array) => array.HasValue && !array.Value.IsNil;
    }
}
#endif
