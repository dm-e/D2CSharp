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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System
{
    // A const untyped pointer argument addresses the pointer value itself.
    // Keep its target pinned while exposing the serialized address to native IO.
    internal sealed class PointerValueBacking : PointerBacking
    {
        private readonly Func<PointerPin> FPinTarget;
        internal PointerValueBacking(Func<PointerPin> pinTarget) => FPinTarget = pinTarget;
        internal override nint ByteLength => D2C.PointerSize;
        internal override bool IsReadOnly => true;

        private byte[] AddressBytes(IntPtr address)
        {
            return D2C.PointerSize == 4
                ? BitConverter.GetBytes(unchecked((int)address.ToInt64()))
                : BitConverter.GetBytes(address.ToInt64());
        }

        internal override byte ReadByte(nint offset)
        {
            ValidateRange(offset, 1);
            using PointerPin target = FPinTarget();
            return AddressBytes(target.Address)[checked((int)offset)];
        }

        internal override void WriteByte(nint offset, byte value) =>
            throw new InvalidOperationException("A pointer value snapshot is read-only.");

        internal override IntPtr GetPersistentAddress(nint offset) =>
            throw new InvalidOperationException("A pointer value snapshot requires a pin.");

        internal override PointerPin Pin(nint offset)
        {
            ValidateRange(offset, 0);
            PointerPin target = FPinTarget();
            try
            {
                PointerPin storage = PointerBackingRegistry.ForArray(AddressBytes(target.Address)).Pin(offset);
                return new PointerPin(storage.Address, () =>
                {
                    try { storage.Dispose(); }
                    finally { target.Dispose(); }
                });
            }
            catch
            {
                target.Dispose();
                throw;
            }
        }
    }

    public struct UntypedPointer : IPointer<byte>, IEquatable<UntypedPointer>
    {
        private PointerView FView;

        public static int DelphiSizeOf
        {
            get
            {
                return D2C.PointerSize;
            }
        }

        internal UntypedPointer(PointerView view)
        {
            FView = view;
        }

        public UntypedPointer(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            FView = size == 0
                ? default
                : PointerView.FromBacking(
                    PointerBackingRegistry.ForArray(new byte[size]));
        }

        public UntypedPointer(uint size)
        {
            if (size > int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(size));

            FView = size == 0
                ? default
                : PointerView.FromBacking(
                    PointerBackingRegistry.ForArray(new byte[(int)size]));
        }

        public UntypedPointer(byte value)
        {
            FView = PointerView.FromBacking(
                PointerBackingRegistry.ForArray(new[] { value }));
        }

        public UntypedPointer(
            byte[]? array,
            int index = 0,
            bool copy = false)
        {
            if (array == null)
            {
                FView = default;
                return;
            }

            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            byte[] backingArray = copy
                ? (byte[])array.Clone()
                : array;

            FView = PointerView.FromBacking(
                PointerBackingRegistry.ForArray(backingArray)).Slice(index);
        }

        public UntypedPointer(Array? array, int elementIndex = 0)
        {
            FView = CreateArrayElementView(array, elementIndex);
        }

        #if USEDYNAMICARRAY
        public UntypedPointer(IDynamicArray? array, int elementIndex = 0)
        {
            FView = CreateArrayElementView(
                array?.RawArrayUntyped,
                elementIndex);
        }
#endif

        public UntypedPointer(
            IntPtr address,
            int capacity = 0,
            bool ownsMemory = false)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            if (address == IntPtr.Zero)
            {
                FView = default;
                return;
            }

            if (PointerBackingRegistry.TryResolvePin(address, capacity, out FView))
            {
                if (ownsMemory)
                    throw new ArgumentException("Pinned managed storage cannot be owned as native memory.", nameof(ownsMemory));
                return;
            }
            nint length = capacity == 0 ? -1 : capacity;
            FView = PointerView.FromBacking(
                new NativeMemoryBacking(address, length, ownsMemory));
        }

        public UntypedPointer(UntypedPointer other, int delta = 0)
        {
            if (other.IsNull())
            {
                FView = default;
                return;
            }

            FView = delta == 0
                ? other.FView
                : other.FView.Slice(delta);
        }

        public UntypedPointer(
            string? value,
            int charIndex = 0,
            bool addNullTerminator = true)
        {
            if (value == null)
            {
                FView = default;
                return;
            }

            if (charIndex < 0 || charIndex > value.Length)
                throw new ArgumentOutOfRangeException(nameof(charIndex));

            int extra = addNullTerminator ? 1 : 0;
            char[] buffer = new char[value.Length + extra];
            value.CopyTo(0, buffer, 0, value.Length);

            if (addNullTerminator)
                buffer[value.Length] = '\0';

            FView = PointerView.FromBacking(
                PointerBackingRegistry.ForArray(buffer)).Slice(
                    checked((nint)charIndex * sizeof(char)));
        }

        internal PointerView View => FView;
        internal object? BackingIdentity => FView.Backing?.Identity;
        internal nint AbsoluteByteOffset => FView.ByteOffset;
        internal nint RemainingByteLength => FView.ByteLength;
        internal int ValueSize<T>() => FView.Backing == null
            ? DelphiTypeLayout.SizeOf<T>() : FView.Backing.ValueSize<T>();

        public int Length => ToPublicLength(FView.ByteLength);

        public int Capacity
        {
            get
            {
                if (IsNull())
                    return 0;

                return ToPublicLength(FView.Backing!.ByteLength);
            }
        }

        public int Position => IsNull()
            ? 0
            : checked((int)FView.ByteOffset);

        public bool IsReadOnly =>
            !IsNull() && FView.Backing!.IsReadOnly;

        public bool IsNull()
        {
            return FView.IsNull;
        }

        public void SetNull()
        {
            FView = default;
        }

        public byte Deref()
        {
            return FView.ReadByte(0);
        }

        public byte this[int index]
        {
            get => FView.ReadByte(index);
            set => FView.WriteByte(index, value);
        }

        public void Assign(byte value, int index = 0)
        {
            FView.WriteByte(index, value);
        }

        public void Inc(int count)
        {
            if (IsNull())
                throw new NullReferenceException("Pointer is null.");

            FView = FView.Slice(count);
        }

        public void Dec(int count)
        {
            Inc(checked(-count));
        }

        public T Read<T>(int index = 0)
        {
            if (typeof(T) == typeof(string))
            {
                if (FView.Backing != null && FView.Backing.TryReadValue(
                    checked(FView.ByteOffset + index), out T value))
                {
                    FView.ValidateRelativeRange(index, DelphiTypeLayout.SizeOf<T>());
                    return value;
                }
                return (T)(object)ReadUtf16String(index);
            }

            return FView.Read<T>(index);
        }

        public void Write<T>(T value, int index = 0)
        {
            if (typeof(T) == typeof(string))
            {
                if (FView.Backing != null && FView.Backing.TryReadValue(
                    checked(FView.ByteOffset + index), out T previous))
                {
                    FView.Write(index, value);
                    return;
                }
                string text = (object?)value == null
                    ? string.Empty
                    : (string)(object)value!;

                WriteUtf16String(text, index, false);
                return;
            }

            FView.Write(index, value);
        }

        public string ToManagedString()
        {
            return ReadUtf16String(0);
        }

        public byte[] ToArray()
        {
            if (IsNull())
                return Array.Empty<byte>();

            if (FView.ByteLength < 0)
            {
                throw new InvalidOperationException(
                    "Cannot copy a pointer with unknown length.");
            }

            int length = checked((int)FView.ByteLength);
            byte[] result = new byte[length];

            for (int i = 0; i < length; i++)
                result[i] = FView.ReadByte(i);

            return result;
        }

        public Pointer<T> As<T>()
        {
            return new Pointer<T>(this);
        }

        public PointerPin Pin()
        {
            return FView.Pin();
        }

        public IntPtr ToIntPtr()
        {
            return FView.GetPersistentAddress();
        }

        public bool CanFreeMemory()
        {
            return FView.CanFreeBacking();
        }

        public bool TryFreeMemory()
        {
            bool result = FView.TryFreeBacking();

            if (result)
                FView = default;

            return result;
        }

        public void FreeMemory()
        {
            FView.FreeBacking();
            FView = default;
        }

        public void Dispose()
        {
            FView = default;
        }

        public static UntypedPointer FromValue(
            string? value,
            int charIndex = 0)
        {
            return new UntypedPointer(value, charIndex, true);
        }

        public static UntypedPointer FromStringView(
            string? value,
            int charIndex = 0)
        {
            if (value == null)
                return default;

            if (charIndex < 0 || charIndex > value.Length)
                throw new ArgumentOutOfRangeException(nameof(charIndex));

            return new UntypedPointer(
                PointerView.FromBacking(
                    PointerBackingRegistry.ForString(value)).Slice(
                        checked((nint)charIndex * sizeof(char))));
        }

        [Obsolete(
            "Use a byte[]/PAnsiChar backing. ANSI bytes are not UTF-16 chars.")]
        public static UntypedPointer FromAnsiBytesTarget(
            string? value,
            int charIndex = 0)
        {
            if (value == null)
                return default;

            if (charIndex < 0 || charIndex > value.Length)
                throw new ArgumentOutOfRangeException(nameof(charIndex));

            byte[] bytes = new byte[value.Length + 1];

            for (int i = 0; i < value.Length; i++)
                bytes[i] = unchecked((byte)value[i]);

            return new UntypedPointer(bytes, charIndex);
        }

        private static UntypedPointer FromPointerValue(Func<PointerPin> pinTarget, int byteIndex)
        {
            PointerView view = PointerView.FromBacking(new PointerValueBacking(pinTarget));
            if (byteIndex < 0 || byteIndex > view.ByteLength)
                throw new ArgumentOutOfRangeException(nameof(byteIndex));
            return new UntypedPointer(view.Slice(byteIndex));
        }

        public static UntypedPointer FromValue(PChar value, int byteIndex = 0) =>
            FromPointerValue(value.Pin, byteIndex);

        public static UntypedPointer FromValue(PAnsiChar value, int byteIndex = 0) =>
            FromPointerValue(value.Pin, byteIndex);

        public static UntypedPointer FromValue(Pointer value, int byteIndex = 0) =>
            FromPointerValue(value.Pin, byteIndex);

        public static UntypedPointer FromValue(UntypedPointer value, int byteIndex = 0) =>
            FromPointerValue(value.Pin, byteIndex);

        public static UntypedPointer FromValue<T>(Pointer<T> value, int byteIndex = 0) =>
            FromPointerValue(value.Pin, byteIndex);

        public static UntypedPointer FromValue(TSet value, int byteIndex = 0) =>
            FromByteIndex(value?.ToBytes() ?? new byte[TSet.DelphiSizeOf], byteIndex);

        public static UntypedPointer FromValue<T>(
            T value,
            int byteIndex = 0)
            where T : struct
        {
            T[] cell = new[] { value };
            PointerView view = PointerView.FromBacking(
                PointerBackingRegistry.ForArray(cell));

            if (byteIndex < 0 || byteIndex > view.ByteLength)
                throw new ArgumentOutOfRangeException(nameof(byteIndex));

            return new UntypedPointer(view.Slice(byteIndex));
        }

        public static UntypedPointer FromByteIndex(
            Array? array,
            int byteIndex = 0)
        {
            if (array == null)
                return default;

            PointerView view = PointerView.FromBacking(
                PointerBackingRegistry.ForArray(array));

            if (byteIndex < 0 || byteIndex > view.ByteLength)
                throw new ArgumentOutOfRangeException(nameof(byteIndex));

            return new UntypedPointer(view.Slice(byteIndex));
        }

        #if USEDYNAMICARRAY
        public static UntypedPointer FromByteIndex(
            IDynamicArray? array,
            int byteIndex = 0)
        {
            return FromByteIndex(array?.RawArrayUntyped, byteIndex);
        }
        #endif
        private sealed class ReferenceTokenBox
        {
            internal ReferenceTokenBox(IntPtr token)
            {
                Token = token;
            }

            internal IntPtr Token { get; }
        }

        private static readonly ConditionalWeakTable<object, ReferenceTokenBox>
            FReferenceTokens =
                new ConditionalWeakTable<object, ReferenceTokenBox>();

        private static long FNextReferenceToken;

        [Obsolete(
            "Reference tokens are identities, not writable addresses. " +
            "Use DelphiReferenceCell<T> for an addressable reference slot.")]
        public static UntypedPointer FromReference(object? value)
        {
            return FromValue(ReferenceToken(value));
        }

        public static IntPtr ReferenceToken(object? value)
        {
            if (value == null)
                return IntPtr.Zero;

            ReferenceTokenBox box = FReferenceTokens.GetValue(
                value,
                static _ =>
                {
                    long id = Interlocked.Increment(ref FNextReferenceToken);
                    return new ReferenceTokenBox(new IntPtr(id));
                });

            return box.Token;
        }

        public static UntypedPointer AllocBytes(int size)
        {
            return new UntypedPointer(size);
        }

        public static UntypedPointer AllocNative(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            if (size == 0)
                return default;

            IntPtr address = Marshal.AllocHGlobal(size);
            return new UntypedPointer(address, size, true);
        }

        public UntypedPointer AddBytes(nint byteCount)
        {
            if (IsNull())
                return default;

            return new UntypedPointer(
                View.Slice(byteCount));
        }

        //Alternativ, falls der Konstruktor bereits einen int-Byteoffset übernimmt:
        //public UntypedPointer AddBytes(nint byteCount)
        //{
        //    if (byteCount < int.MinValue ||
        //        byteCount > int.MaxValue)
        //    {
        //        throw new ArgumentOutOfRangeException(
        //            nameof(byteCount));
        //    }

        //    return new UntypedPointer(
        //        this,
        //        checked((int)byteCount));
        //}

        public bool IsAfter(UntypedPointer other)
        {
            if (IsNull() || other.IsNull())
            {
                throw new NullReferenceException(
                    "Cannot compare null pointers.");
            }

            PointerView leftView = View;
            PointerView rightView = other.View;

            if (!ReferenceEquals(
                leftView.Backing,
                rightView.Backing))
            {
                // Different backings cannot overlap.
                // Forward copying is safe.
                return false;
            }

            return leftView.ByteOffset >
                   rightView.ByteOffset;
        }



        public static UntypedPointer operator +(
            UntypedPointer pointer,
            int byteOffset)
        {
            return pointer.IsNull()
                ? default
                : new UntypedPointer(pointer.FView.Slice(byteOffset));
        }

        public static UntypedPointer operator -(
            UntypedPointer pointer,
            int byteOffset)
        {
            return pointer + checked(-byteOffset);
        }

        public static UntypedPointer operator ++(UntypedPointer pointer)
        {
            return pointer + 1;
        }

        public static UntypedPointer operator --(UntypedPointer pointer)
        {
            return pointer - 1;
        }

        public bool Equals(UntypedPointer other)
        {
            return FView.Equals(other.FView);
        }

        public override bool Equals(object? obj)
        {
            return obj is UntypedPointer other && Equals(other);
        }

        public override int GetHashCode()
        {
            return FView.GetHashCode();
        }

        public static bool operator ==(
            UntypedPointer left,
            UntypedPointer right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            UntypedPointer left,
            UntypedPointer right)
        {
            return !left.Equals(right);
        }

        public static implicit operator IntPtr(UntypedPointer pointer)
        {
            return pointer.ToIntPtr();
        }

        public static implicit operator UntypedPointer(IntPtr address)
        {
            return new UntypedPointer(address);
        }

        /// <summary>Addresses an element of a rectangular array using CLR indices.</summary>
        public static UntypedPointer FromArrayElement(Array array, params int[] indices)
        {
            ArgumentNullException.ThrowIfNull(array);
            ArgumentNullException.ThrowIfNull(indices);
            if (indices.Length != array.Rank)
                throw new ArgumentException("One index per array dimension is required.", nameof(indices));
            int linearIndex = 0;
            for (int dimension = 0; dimension < indices.Length; dimension++)
            {
                int index = checked(indices[dimension] - array.GetLowerBound(dimension));
                int length = array.GetLength(dimension);
                if ((uint)index >= (uint)length) throw new IndexOutOfRangeException();
                linearIndex = checked(linearIndex * length + index);
            }
            return new UntypedPointer(array, linearIndex);
        }

        private static PointerView CreateArrayElementView(
            Array? array,
            int elementIndex)
        {
            if (array == null)
                return default;

            if (elementIndex < 0 || elementIndex > array.Length)
                throw new ArgumentOutOfRangeException(nameof(elementIndex));

            ManagedArrayBacking backing =
                PointerBackingRegistry.ForArray(array);

            return PointerView.FromBacking(backing).Slice(
                checked((nint)elementIndex * backing.ElementSize));
        }

        private string ReadUtf16String(int byteOffset)
        {
            if (IsNull())
                return string.Empty;

            if (byteOffset < 0)
                throw new ArgumentOutOfRangeException(nameof(byteOffset));

            nint remaining = FView.ByteLength < 0
                ? int.MaxValue
                : FView.ByteLength - byteOffset;

            if (remaining < 0)
            {
                throw new IndexOutOfRangeException(
                    "String read outside pointer bounds.");
            }

            int maxChars = checked((int)(remaining / sizeof(char)));
            char[] buffer = new char[Math.Min(maxChars, 256)];
            int count = 0;

            while (count < maxChars)
            {
                char value = FView.Read<char>(
                    checked(byteOffset + count * sizeof(char)));

                if (value == '\0')
                    break;

                if (count == buffer.Length)
                {
                    int newLength = buffer.Length == 0
                        ? 16
                        : checked(buffer.Length * 2);

                    if (newLength > maxChars)
                        newLength = maxChars;

                    Array.Resize(ref buffer, newLength);
                }

                buffer[count++] = value;
            }

            return count == 0
                ? string.Empty
                : new string(buffer, 0, count);
        }

        private void WriteUtf16String(
            string value,
            int byteOffset,
            bool writeNullTerminator)
        {
            for (int i = 0; i < value.Length; i++)
            {
                FView.Write(
                    checked(byteOffset + i * sizeof(char)),
                    value[i]);
            }

            if (writeNullTerminator)
            {
                FView.Write(
                    checked(byteOffset + value.Length * sizeof(char)),
                    '\0');
            }
        }

        private static int ToPublicLength(nint length)
        {
            if (length < 0 || length > int.MaxValue)
                return int.MaxValue;

            return (int)length;
        }
    }
}
