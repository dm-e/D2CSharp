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
    /// <summary>
    /// Byte pointer used for Delphi PAnsiChar. Pointer indexes are zero-based.
    /// Constructors copy string values into writable, null-terminated storage,
    /// matching the existing PChar compatibility layer.
    /// </summary>
    public struct PAnsiChar : IPointer<byte>, IEquatable<PAnsiChar>
    {
        private Pointer<byte> FPointer;
        private ushort FCodePage;

        public static int DelphiSizeOf => D2C.PointerSize;

        public PAnsiChar(
            int size,
            bool alloc = false,
            ushort codePage = 0)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            FPointer = size == 0
                ? default
                : new Pointer<byte>(size, alloc);
            FCodePage = AnsiStringSettings.ResolveCodePage(codePage);
        }

        public PAnsiChar(byte value, ushort codePage = 0)
        {
            FPointer = new Pointer<byte>(new[] { value, (byte)0 });
            FCodePage = AnsiStringSettings.ResolveCodePage(codePage);
        }

        public PAnsiChar(
            AnsiString? value,
            int index = 0)
        {
            if (value is null)
            {
                FPointer = default;
                FCodePage = AnsiStringSettings.DefaultCodePage;
                return;
            }

            if ((uint)index > (uint)value.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            FPointer = new Pointer<byte>(
                value.ToNullTerminatedByteArray(),
                index);
            FCodePage = value.CodePage;
        }

        public PAnsiChar(
            ShortString? value,
            int index = 0)
        {
            if (value is null)
            {
                FPointer = default;
                FCodePage = AnsiStringSettings.DefaultCodePage;
                return;
            }

            if ((uint)index > (uint)value.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            FPointer = new Pointer<byte>(
                value.ToNullTerminatedByteArray(),
                index);
            FCodePage = value.CodePage;
        }

        public PAnsiChar(
            string? value,
            int index = 0,
            ushort codePage = 0)
            : this(AnsiString.FromString(value, codePage), index)
        {
        }

        public PAnsiChar(
            byte[]? value,
            int index = 0,
            bool copy = false,
            ushort codePage = 0)
        {
            if (value is null)
            {
                FPointer = default;
                FCodePage = AnsiStringSettings.ResolveCodePage(codePage);
                return;
            }

            if ((uint)index > (uint)value.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            byte[] buffer;
            if (value.Length == 0 || value[value.Length - 1] != 0)
            {
                buffer = new byte[checked(value.Length + 1)];
                value.CopyTo(buffer, 0);
            }
            else
            {
                buffer = copy ? (byte[])value.Clone() : value;
            }

            FPointer = new Pointer<byte>(buffer, index);
            FCodePage = AnsiStringSettings.ResolveCodePage(codePage);
        }

        public PAnsiChar(PAnsiChar other, int delta = 0)
        {
            FPointer = delta == 0
                ? other.FPointer
                : other.FPointer + delta;
            FCodePage = other.FCodePage;
        }

        public PAnsiChar(Pointer<byte> pointer, ushort codePage = 0)
        {
            FPointer = pointer;
            FCodePage = AnsiStringSettings.ResolveCodePage(codePage);
        }

        public PAnsiChar(UntypedPointer pointer, ushort codePage = 0)
        {
            FPointer = new Pointer<byte>(pointer);
            FCodePage = AnsiStringSettings.ResolveCodePage(codePage);
        }

        public PAnsiChar(Pointer pointer, ushort codePage = 0)
        {
            FPointer = new Pointer<byte>(pointer);
            FCodePage = AnsiStringSettings.ResolveCodePage(codePage);
        }

        public int Length
        {
            get
            {
                if (IsNull())
                    return 0;

                int capacity = Capacity;
                for (int index = 0; index < capacity; index++)
                {
                    if (FPointer[index] == 0)
                        return index;
                }

                return capacity;
            }
        }

        public int Capacity => FPointer.Length;
        public int Position => FPointer.Position;
        public ushort CodePage => FCodePage;

        public byte this[int index]
        {
            get => FPointer[index];
            set => FPointer[index] = value;
        }

        public bool IsNull() => FPointer.IsNull();
        public void SetNull() => FPointer.SetNull();
        public byte Deref() => FPointer.Deref();

        public UntypedPointer Dereferenced => ToUntypedPointer();

        public void Assign(byte value, int index = 0)
        {
            FPointer.Assign(value, index);
        }

        public void Assign(AnsiString? value)
        {
            AnsiString converted = value is null
                ? AnsiString.FromBytes(Array.Empty<byte>(), FCodePage)
                : value.CodePage == FCodePage
                    ? value
                    : value.Reencode(FCodePage);

            EnsureWritableCount(converted.Length + 1);
            for (int index = 0; index < converted.Length; index++)
                FPointer[index] = converted[index];
            FPointer[converted.Length] = 0;
        }

        public void Assign(ShortString? value)
        {
            ShortString actual = ShortString.Normalize(value);
            Assign(actual.ToAnsiString());
        }

        public void Assign(string? value)
        {
            Assign(AnsiString.FromString(value, FCodePage));
        }

        public void Inc(int count) => FPointer.Inc(count);
        public void Dec(int count) => FPointer.Dec(count);

        public void DerefAdd(int value)
        {
            Assign(unchecked((byte)(Deref() + value)));
        }

        public void DerefSubstract(int value)
        {
            Assign(unchecked((byte)(Deref() - value)));
        }

        public AnsiString Substring(int from, int count)
        {
            if (from < 0)
                throw new ArgumentOutOfRangeException(nameof(from));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (IsNull())
                return AnsiString.FromBytes(Array.Empty<byte>(), FCodePage);

            int actualCount = Math.Min(Math.Max(0, Length - from), count);
            byte[] result = new byte[actualCount];
            for (int index = 0; index < actualCount; index++)
                result[index] = FPointer[from + index];
            return AnsiString.FromBytes(result, FCodePage);
        }

        public void Insert(AnsiString? value, int startIndex = 0)
        {
            AnsiString converted = value is null
                ? AnsiString.FromBytes(Array.Empty<byte>(), FCodePage)
                : value.CodePage == FCodePage
                    ? value
                    : value.Reencode(FCodePage);

            if (converted.Length == 0)
                return;
            if ((uint)startIndex > (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            int oldLength = Length;
            int newLength = checked(oldLength + converted.Length);
            EnsureWritableCount(newLength + 1);

            for (int index = oldLength; index >= startIndex; index--)
                FPointer[index + converted.Length] = FPointer[index];
            for (int index = 0; index < converted.Length; index++)
                FPointer[startIndex + index] = converted[index];
        }

        public byte[] ToByteArray()
        {
            int length = Length;
            byte[] result = new byte[length];
            for (int index = 0; index < length; index++)
                result[index] = FPointer[index];
            return result;
        }

        public AnsiString ToAnsiString()
        {
            return AnsiString.FromBytes(ToByteArray(), FCodePage);
        }

        public ShortString ToShortString(
            int maximumLength = ShortString.DefaultMaximumLength)
        {
            return ShortString.FromBytes(
                ToByteArray(),
                FCodePage,
                maximumLength);
        }

        public override string ToString() => ToAnsiString().Decode();

        public void Synchronize(ref AnsiString? value)
        {
            value = ToAnsiString();
        }

        public void Synchronize(ref ShortString? value)
        {
            int maximumLength = value?.MaximumLength ??
                ShortString.DefaultMaximumLength;
            value = ToShortString(maximumLength);
        }

        public void Synchronize(ref byte[] value)
        {
            value = ToByteArray();
        }

        public PointerPin Pin() => FPointer.Pin();
        public IntPtr ToIntPtr() => FPointer.ToIntPtr();
        public Pointer<byte> AsPointer() => FPointer;
        public UntypedPointer ToUntypedPointer() => FPointer.ToUntypedPointer();
        public void FromIntPtr() { }
        public void FreeMemory() => FPointer.FreeMemory();
        public void Dispose() => FPointer.Dispose();

        public static PAnsiChar operator +(PAnsiChar pointer, int offset)
        {
            return pointer.IsNull()
                ? default
                : new PAnsiChar(pointer.FPointer + offset, pointer.FCodePage);
        }

        public static PAnsiChar operator -(PAnsiChar pointer, int offset)
            => pointer + checked(-offset);

        public static PAnsiChar operator ++(PAnsiChar pointer) => pointer + 1;
        public static PAnsiChar operator --(PAnsiChar pointer) => pointer - 1;

        public bool Equals(PAnsiChar other)
            => FPointer.Equals(other.FPointer);

        public override bool Equals(object? obj)
            => obj is PAnsiChar other && Equals(other);

        public override int GetHashCode() => FPointer.GetHashCode();
        public static bool operator ==(PAnsiChar left, PAnsiChar right)
            => left.Equals(right);
        public static bool operator !=(PAnsiChar left, PAnsiChar right)
            => !left.Equals(right);

        public static implicit operator UntypedPointer(PAnsiChar pointer)
            => pointer.ToUntypedPointer();

        public static explicit operator Pointer(PAnsiChar pointer)
        {
            if (pointer.IsNull())
                return default;

            return pointer.ToUntypedPointer();
        }

        public static implicit operator PAnsiChar(Pointer<byte> pointer)
            => new PAnsiChar(pointer);

        public static implicit operator PAnsiChar(Pointer pointer)
            => new PAnsiChar(pointer);

        public static implicit operator PAnsiChar(UntypedPointer pointer)
            => new PAnsiChar(pointer);

        public static explicit operator PAnsiChar(AnsiString? value)
            // Delphi's PAnsiChar(S) cast for an empty AnsiString yields a
            // readable pointer to a terminating zero byte. Normalize null as
            // the managed representation of Delphi's empty string value.
            => new PAnsiChar(AnsiString.Normalize(value));

        public static explicit operator PAnsiChar(ShortString? value)
            => value is null ? default : new PAnsiChar(value);

        public static explicit operator AnsiString(PAnsiChar value)
            => value.ToAnsiString();

        public static explicit operator ShortString(PAnsiChar value)
            => value.ToShortString();

        private void EnsureWritableCount(int requiredBytes)
        {
            if (IsNull())
                throw new NullReferenceException("PAnsiChar is null.");
            if (requiredBytes < 0 || requiredBytes > Capacity)
            {
                throw new IndexOutOfRangeException(
                    "PAnsiChar writes never resize the backing storage.");
            }
        }
    }

    public sealed class AnsiStringBuffer : IDisposable
    {
        private byte[]? FBuffer;
        private readonly ushort FCodePage;

        public AnsiStringBuffer(
            AnsiString? value,
            int capacity = -1,
            ushort codePage = 0)
        {
            AnsiString initial = value ?? AnsiString.FromBytes(
                Array.Empty<byte>(),
                codePage);

            FCodePage = initial.CodePage;
            if (capacity < -1)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            int required = checked(initial.Length + 1);
            int actualCapacity = capacity < 0
                ? required
                : Math.Max(capacity, required);

            FBuffer = new byte[actualCapacity];
            initial.AsSpan().CopyTo(FBuffer);
        }

        public int Capacity => FBuffer?.Length ?? 0;

        public PAnsiChar Pointer
        {
            get
            {
                if (FBuffer is null)
                    throw new ObjectDisposedException(nameof(AnsiStringBuffer));

                return new PAnsiChar(FBuffer, codePage: FCodePage);
            }
        }

        public UntypedPointer GetPointer(int byteIndex = 0)
        {
            if (FBuffer is null)
                throw new ObjectDisposedException(nameof(AnsiStringBuffer));
            if ((uint)byteIndex > (uint)FBuffer.Length)
                throw new ArgumentOutOfRangeException(nameof(byteIndex));

            return new UntypedPointer(FBuffer, byteIndex);
        }

        public AnsiString Commit()
        {
            if (FBuffer is null)
                throw new ObjectDisposedException(nameof(AnsiStringBuffer));

            int length = Array.IndexOf(FBuffer, (byte)0);
            if (length < 0)
                length = FBuffer.Length;
            return AnsiString.FromBytes(FBuffer.AsSpan(0, length), FCodePage);
        }

        public AnsiString Commit(int length)
        {
            if (FBuffer is null)
                throw new ObjectDisposedException(nameof(AnsiStringBuffer));
            if ((uint)length > (uint)FBuffer.Length)
                throw new ArgumentOutOfRangeException(nameof(length));

            return AnsiString.FromBytes(FBuffer.AsSpan(0, length), FCodePage);
        }

        public void Dispose()
        {
            FBuffer = null;
        }
    }
}
