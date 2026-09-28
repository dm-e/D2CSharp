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

namespace System
{
    public struct PChar : IPointer<char>, IEquatable<PChar>
    {
        private Pointer<char> FPointer;

        public PChar(int size, bool alloc = false)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            if (size == 0)
            {
                FPointer = default;
                return;
            }

            FPointer = alloc
                ? new Pointer<char>(checked(size * sizeof(char)), true)
                : new Pointer<char>(new char[size]);
        }

        public PChar(char value)
        {
            FPointer = new Pointer<char>(new[] { value, '\0' });
        }

        public PChar(string? value, int index = 0)
        {
            if (value == null)
            {
                FPointer = default;
                return;
            }

            if (index < 0 || index > value.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            char[] buffer = new char[value.Length + 1];
            value.CopyTo(0, buffer, 0, value.Length);
            buffer[value.Length] = '\0';
            FPointer = new Pointer<char>(buffer, index);
        }

        public PChar(
            char[]? value,
            int index = 0,
            bool copy = false)
        {
            if (value == null)
            {
                FPointer = default;
                return;
            }

            if (index < 0 || index > value.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            char[] buffer = copy
                ? (char[])value.Clone()
                : value;

            FPointer = new Pointer<char>(buffer, index);
        }

        public PChar(PChar other, int delta = 0)
        {
            FPointer = delta == 0
                ? other.FPointer
                : other.FPointer + delta;
        }

        public PChar(Pointer<char> pointer)
        {
            FPointer = pointer;
        }

        public PChar(UntypedPointer pointer)
        {
            FPointer = new Pointer<char>(pointer);
        }

        public PChar(Pointer pointer)
        {
            FPointer = new Pointer<char>(pointer);
        }

        public static implicit operator PChar(Pointer pointer)
        {
            return new PChar(pointer);
        }

        public static implicit operator PChar(Pointer<char> pointer)
        {
            return new PChar(pointer);
        }

        public static implicit operator PChar(UntypedPointer pointer)
        {
            return new PChar(pointer);
        }

        public int Length
        {
            get
            {
                if (IsNull())
                    return 0;

                int capacity = Capacity;

                for (int i = 0; i < capacity; i++)
                {
                    if (FPointer[i] == '\0')
                        return i;
                }

                return capacity;
            }
        }

        public int Capacity => FPointer.Length;
        public int Position => FPointer.Position;

        public char this[int index]
        {
            get => FPointer[index];
            set => FPointer[index] = value;
        }

        public bool IsNull() => FPointer.IsNull();
        public void SetNull() => FPointer.SetNull();
        public char Deref() => FPointer.Deref();

        public UntypedPointer Dereferenced
        {
            get
            {
                return ToUntypedPointer();
            }
        }

        public void Assign(char value, int index = 0)
        {
            FPointer.Assign(value, index);
        }

        public void Assign(string? value)
        {
            value ??= string.Empty;
            EnsureWritableCount(value.Length + 1);

            for (int i = 0; i < value.Length; i++)
                FPointer[i] = value[i];

            FPointer[value.Length] = '\0';
        }

        public void Inc(int count) => FPointer.Inc(count);
        public void Dec(int count) => FPointer.Dec(count);

        public void DerefAdd(int value)
        {
            Assign(unchecked((char)(Deref() + value)));
        }

        public void DerefSubstract(int value)
        {
            Assign(unchecked((char)(Deref() - value)));
        }

        public string Substring(int from, int count)
        {
            if (from < 0)
                throw new ArgumentOutOfRangeException(nameof(from));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (IsNull())
                return string.Empty;

            int actualCount = Math.Min(
                Math.Max(0, Length - from),
                count);

            if (actualCount == 0)
                return string.Empty;

            char[] result = new char[actualCount];

            for (int i = 0; i < actualCount; i++)
                result[i] = FPointer[from + i];

            return new string(result);
        }

        public void Insert(string? value)
        {
            Insert(value, 0);
        }

        public void Insert(string? value, int startIndex)
        {
            if (string.IsNullOrEmpty(value))
                return;

            if (startIndex < 0 || startIndex > Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            int oldLength = Length;
            int newLength = checked(oldLength + value.Length);
            EnsureWritableCount(newLength + 1);

            for (int i = oldLength; i >= startIndex; i--)
                FPointer[i + value.Length] = FPointer[i];

            for (int i = 0; i < value.Length; i++)
                FPointer[startIndex + i] = value[i];
        }

        public PointerPin Pin() => FPointer.Pin();
        public IntPtr ToIntPtr() => FPointer.ToIntPtr();

        public void FromIntPtr()
        {
            // A pinned managed backing or native backing is already shared.
        }

        public Pointer<char> AsPointer() => FPointer;
        public UntypedPointer ToUntypedPointer() => FPointer.ToUntypedPointer();

        public char[] ToCharArray()
        {
            int length = Length;
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
                result[i] = FPointer[i];

            return result;
        }

        public override string ToString()
        {
            char[] chars = ToCharArray();
            return chars.Length == 0 ? string.Empty : new string(chars);
        }

        public void Synchronize(ref string value)
        {
            value = ToString();
        }

        public void Synchronize(ref char[] value)
        {
            value = ToCharArray();
        }

        public void FreeMemory() => FPointer.FreeMemory();
        public void Dispose() => FPointer.Dispose();

        public static PChar FromStringView(
            string? value,
            int charIndex = 0)
        {
            return value == null
                ? default
                : new PChar(new Pointer<char>(
                    UntypedPointer.FromStringView(value, charIndex)));
        }

        public static PChar operator +(PChar pointer, int offset)
        {
            return pointer.IsNull()
                ? default
                : new PChar(pointer.FPointer + offset);
        }

        public static PChar operator -(PChar pointer, int offset)
        {
            return pointer + checked(-offset);
        }

        public static PChar operator ++(PChar pointer) => pointer + 1;
        public static PChar operator --(PChar pointer) => pointer - 1;

        public bool Equals(PChar other) => FPointer.Equals(other.FPointer);
        public override bool Equals(object? obj) => obj is PChar other && Equals(other);
        public override int GetHashCode() => FPointer.GetHashCode();
        public static bool operator ==(PChar left, PChar right) => left.Equals(right);
        public static bool operator !=(PChar left, PChar right) => !left.Equals(right);

        public static implicit operator UntypedPointer(PChar pointer)
        {
            return pointer.ToUntypedPointer();
        }

        //public static explicit operator PChar(UntypedPointer pointer)
        //{
        //    return new PChar(pointer);
        //}

        private void EnsureWritableCount(int requiredChars)
        {
            if (IsNull())
                throw new NullReferenceException("PChar is null.");

            if (requiredChars < 0 || requiredChars > Capacity)
            {
                throw new IndexOutOfRangeException(
                    "PChar writes never resize the backing storage.");
            }
        }
    }
}
