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
using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System
{
    public sealed class PointerPin : IDisposable
    {
        // A pin is a lease, not a lock for native consumers. Do not dispose it
        // while another thread or native callback still uses its address.
        private readonly object FLock = new object();
        private Action? FRelease;
        private IntPtr FAddress;
        private bool FDisposed;

        internal PointerPin(IntPtr address)
        {
            FAddress = address;
        }

        internal PointerPin(IntPtr address, Action release)
        {
            FAddress = address;
            FRelease = release;
        }

        public IntPtr Address
        {
            get
            {
                lock (FLock)
                {
                    if (FDisposed)
                        throw new ObjectDisposedException(nameof(PointerPin));
                    return FAddress;
                }
            }
        }

        public void Dispose()
        {
            lock (FLock)
            {
                if (FDisposed)
                    return;

                FDisposed = true;
                FAddress = IntPtr.Zero;
                Action? release = FRelease;
                FRelease = null;
                release?.Invoke();
            }
            GC.SuppressFinalize(this);
        }

        ~PointerPin()
        {
            Dispose();
        }
    }

    internal interface IDelphiBinaryCodec
    {
        int Size { get; }
        byte[] Encode(object? value);
        object Decode(byte[] bytes);
    }

    internal sealed class DelphiBinaryCodec<T> : IDelphiBinaryCodec
    {
        private readonly Func<T, byte[]> FEncoder;
        private readonly Func<byte[], T> FDecoder;

        internal DelphiBinaryCodec(
            int size,
            Func<T, byte[]> encoder,
            Func<byte[], T> decoder)
        {
            Size = size;
            FEncoder = encoder;
            FDecoder = decoder;
        }

        public int Size { get; }

        public byte[] Encode(object? value)
        {
            byte[] result = FEncoder(value == null ? default! : (T)value);

            if (result == null || result.Length != Size)
            {
                throw new InvalidOperationException(
                    $"The codec for '{typeof(T).FullName}' must return " +
                    $"exactly {Size} bytes.");
            }

            return result;
        }

        public object Decode(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (bytes.Length != Size)
            {
                throw new ArgumentException(
                    $"The codec for '{typeof(T).FullName}' expects " +
                    $"exactly {Size} bytes.",
                    nameof(bytes));
            }

            return FDecoder(bytes)!;
        }
    }

    public static class DelphiTypeLayout
    {
        private static readonly ConcurrentDictionary<Type, int> FSizeOverrides =
            new ConcurrentDictionary<Type, int>();

        private static readonly ConcurrentDictionary<Type, IDelphiBinaryCodec> FCodecs =
            new ConcurrentDictionary<Type, IDelphiBinaryCodec>();

        public static void RegisterSize<T>(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            FSizeOverrides[typeof(T)] = size;
        }

        public static void RegisterCodec<T>(
            int size,
            Func<T, byte[]> encoder,
            Func<byte[], T> decoder)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            if (encoder == null)
                throw new ArgumentNullException(nameof(encoder));
            if (decoder == null)
                throw new ArgumentNullException(nameof(decoder));

            FSizeOverrides[typeof(T)] = size;
            FCodecs[typeof(T)] = new DelphiBinaryCodec<T>(
                size,
                encoder,
                decoder);
        }

        public static int SizeOf<T>()
        {
            return SizeOf(typeof(T));
        }

        public static int SizeOf(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (FSizeOverrides.TryGetValue(type, out int size))
                return size;

            if (type.IsEnum)
                return SizeOf(Enum.GetUnderlyingType(type));

            if (type == typeof(bool) ||
                type == typeof(byte) ||
                type == typeof(sbyte))
            {
                return 1;
            }

            if (type == typeof(char) ||
                type == typeof(short) ||
                type == typeof(ushort))
            {
                return 2;
            }

            if (type == typeof(int) ||
                type == typeof(uint) ||
                type == typeof(float))
            {
                return 4;
            }

            if (type == typeof(long) ||
                type == typeof(ulong) ||
                type == typeof(double))
            {
                return 8;
            }

            if (type == typeof(decimal))
                return 16;

            if (type == typeof(IntPtr) ||
                type == typeof(UIntPtr) ||
                !type.IsValueType)
            {
                return IntPtr.Size;
            }

            try
            {
                return Marshal.SizeOf(type);
            }
            catch (Exception exception) when (
                exception is ArgumentException ||
                exception is TypeLoadException)
            {
                throw new NotSupportedException(
                    $"No Delphi memory layout is available for '{type.FullName}'.",
                    exception);
            }
        }

        public static bool IsByteAddressable<T>()
        {
            return IsByteAddressable(typeof(T));
        }

        public static bool IsByteAddressable(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return IsByteAddressable(
                type,
                new ConcurrentDictionary<Type, bool>());
        }

        internal static bool TryGetCodec(
            Type type,
            out IDelphiBinaryCodec codec)
        {
            return FCodecs.TryGetValue(type, out codec!);
        }

        private static bool IsByteAddressable(
            Type type,
            ConcurrentDictionary<Type, bool> visited)
        {
            if (type.IsPointer || type.IsEnum || type.IsPrimitive)
                return true;

            if (type == typeof(decimal) ||
                type == typeof(IntPtr) ||
                type == typeof(UIntPtr))
            {
                return true;
            }

            if (!type.IsValueType)
                return false;

            if (visited.ContainsKey(type))
                return true;

            visited[type] = true;

            FieldInfo[] fields = type.GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                if (!IsByteAddressable(field.FieldType, visited))
                    return false;
            }

            return true;
        }
    }

    internal static class PointerBackingRegistry
    {
        private static readonly ConditionalWeakTable<Array, ManagedArrayBacking> FArrays =
            new ConditionalWeakTable<Array, ManagedArrayBacking>();

        private static readonly ConditionalWeakTable<string, ReadOnlyStringBacking> FStrings =
            new ConditionalWeakTable<string, ReadOnlyStringBacking>();

        internal static ManagedArrayBacking ForArray(Array array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            return FArrays.GetValue(
                array,
                static value => new ManagedArrayBacking(value));
        }

        internal static ReadOnlyStringBacking ForString(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return FStrings.GetValue(
                value,
                static text => new ReadOnlyStringBacking(text));
        }
    }

    internal abstract class PointerBacking
    {
        internal abstract nint ByteLength { get; }
        internal virtual bool IsReadOnly => false;
        internal virtual bool IsAlive => true;
        internal object Identity => this;

        internal abstract byte ReadByte(nint absoluteOffset);
        internal abstract void WriteByte(nint absoluteOffset, byte value);

        internal virtual bool TryReadValue<T>(nint absoluteOffset, out T value)
        {
            value = default!;
            return false;
        }

        internal virtual bool TryWriteValue<T>(nint absoluteOffset, T value)
        {
            return false;
        }

        internal abstract PointerPin Pin(nint absoluteOffset);
        internal abstract IntPtr GetPersistentAddress(nint absoluteOffset);

        internal virtual bool CanFree => false;

        internal virtual void Free()
        {
            throw new InvalidOperationException(
                "The pointer backing does not own native memory.");
        }

        internal void ValidateRange(nint offset, nint count)
        {
            if (!IsAlive)
                throw new ObjectDisposedException("Pointer backing");

            if (offset < 0)
            {
                throw new IndexOutOfRangeException(
                    "Pointer access before the backing storage.");
            }

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (ByteLength < 0)
                return;

            nint end;

            try
            {
                end = checked(offset + count);
            }
            catch (OverflowException)
            {
                throw new IndexOutOfRangeException(
                    "Pointer access outside the backing storage.");
            }

            if (end > ByteLength)
            {
                throw new IndexOutOfRangeException(
                    "Pointer access outside the backing storage.");
            }
        }
    }

    internal abstract class PinnableBacking : PointerBacking
    {
        private readonly object FPinLock = new object();
        private GCHandle FPin;
        private int FPinCount;

        protected abstract object PinnedObject { get; }

        internal override PointerPin Pin(nint absoluteOffset)
        {
            ValidateRange(absoluteOffset, 0);
            lock (FPinLock)
            {
                bool allocated = FPinCount == 0;
                if (allocated)
                    FPin = GCHandle.Alloc(PinnedObject, GCHandleType.Pinned);
                try
                {
                    IntPtr address = IntPtr.Add(
                        FPin.AddrOfPinnedObject(), checked((int)absoluteOffset));
                    int nextCount = checked(FPinCount + 1);
                    PointerPin pin = new PointerPin(address, ReleasePin);
                    FPinCount = nextCount;
                    return pin;
                }
                catch
                {
                    if (allocated)
                        FPin.Free();
                    throw;
                }
            }
        }

        internal override IntPtr GetPersistentAddress(nint absoluteOffset)
        {
            // Compatibility API: managed addresses require a caller-owned pin.
            ValidateRange(absoluteOffset, 0);

            lock (FPinLock)
            {
                if (FPinCount == 0)
                {
                    throw new InvalidOperationException(
                        "Managed memory requires an active PointerPin. " +
                        "Keep the pin alive until native use has finished.");
                }

                return IntPtr.Add(
                    FPin.AddrOfPinnedObject(),
                    checked((int)absoluteOffset));
            }
        }

        private void ReleasePin()
        {
            lock (FPinLock)
            {
                if (--FPinCount == 0)
                    FPin.Free();
            }
        }
    }

    internal sealed class ManagedArrayBacking : PinnableBacking
    {
        private readonly Array FArray;
        private readonly Type FElementType;
        private readonly int FElementSize;
        private readonly int FLowerBound;
        private readonly bool FByteAddressable;

        internal ManagedArrayBacking(Array array)
        {
            FArray = array ?? throw new ArgumentNullException(nameof(array));

            if (array.Rank != 1)
            {
                throw new NotSupportedException(
                    "Only one-dimensional array pointer views are supported.");
            }

            FElementType = array.GetType().GetElementType()
                ?? throw new InvalidOperationException(
                    "The array has no element type.");

            FElementSize = DelphiTypeLayout.SizeOf(FElementType);
            FLowerBound = array.GetLowerBound(0);
            FByteAddressable = DelphiTypeLayout.IsByteAddressable(FElementType);
        }

        internal int ElementSize => FElementSize;

        internal override nint ByteLength =>
            checked((nint)FArray.Length * FElementSize);

        protected override object PinnedObject => FArray;

        internal override byte ReadByte(nint absoluteOffset)
        {
            ValidateRange(absoluteOffset, 1);
            EnsureByteAddressable();
            int offset = checked((int)absoluteOffset);

            if (FElementType.IsPrimitive)
                return Buffer.GetByte(FArray, offset);

            int elementIndex = offset / FElementSize;
            int byteInElement = offset % FElementSize;
            object? element = FArray.GetValue(FLowerBound + elementIndex);
            byte[] bytes = DelphiValueCodec.ToBytes(
                element,
                FElementType,
                FElementSize);

            return bytes[byteInElement];
        }

        internal override void WriteByte(nint absoluteOffset, byte value)
        {
            ValidateRange(absoluteOffset, 1);
            EnsureByteAddressable();
            int offset = checked((int)absoluteOffset);

            if (FElementType.IsPrimitive)
            {
                Buffer.SetByte(FArray, offset, value);
                return;
            }

            int elementIndex = offset / FElementSize;
            int byteInElement = offset % FElementSize;
            int actualIndex = FLowerBound + elementIndex;
            object? element = FArray.GetValue(actualIndex);
            byte[] bytes = DelphiValueCodec.ToBytes(
                element,
                FElementType,
                FElementSize);

            bytes[byteInElement] = value;
            FArray.SetValue(
                DelphiValueCodec.FromBytes(bytes, FElementType),
                actualIndex);
        }

        internal override bool TryReadValue<T>(
            nint absoluteOffset,
            out T value)
        {
            if (typeof(T) != FElementType ||
                absoluteOffset < 0 ||
                absoluteOffset % FElementSize != 0)
            {
                value = default!;
                return false;
            }

            nint elementIndex = absoluteOffset / FElementSize;

            if (elementIndex < 0 || elementIndex >= FArray.Length)
            {
                value = default!;
                return false;
            }

            object? item = FArray.GetValue(
                FLowerBound + checked((int)elementIndex));

            value = item == null ? default! : (T)item;
            return true;
        }

        internal override bool TryWriteValue<T>(
            nint absoluteOffset,
            T value)
        {
            if (typeof(T) != FElementType ||
                absoluteOffset < 0 ||
                absoluteOffset % FElementSize != 0)
            {
                return false;
            }

            nint elementIndex = absoluteOffset / FElementSize;

            if (elementIndex < 0 || elementIndex >= FArray.Length)
                return false;

            FArray.SetValue(
                value,
                FLowerBound + checked((int)elementIndex));

            return true;
        }

        internal override PointerPin Pin(nint absoluteOffset)
        {
            EnsureByteAddressable();
            return base.Pin(absoluteOffset);
        }

        internal override IntPtr GetPersistentAddress(nint absoluteOffset)
        {
            EnsureByteAddressable();
            return base.GetPersistentAddress(absoluteOffset);
        }

        private void EnsureByteAddressable()
        {
            if (!FByteAddressable)
            {
                throw new NotSupportedException(
                    $"Array elements of type '{FElementType.FullName}' " +
                    "contain managed references and cannot be addressed as bytes.");
            }
        }
    }

    internal sealed class ReadOnlyStringBacking : PinnableBacking
    {
        private readonly string FValue;

        internal ReadOnlyStringBacking(string value)
        {
            FValue = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal override nint ByteLength =>
            checked((nint)(FValue.Length + 1) * sizeof(char));

        internal override bool IsReadOnly => true;
        protected override object PinnedObject => FValue;

        internal override byte ReadByte(nint absoluteOffset)
        {
            ValidateRange(absoluteOffset, 1);
            int byteOffset = checked((int)absoluteOffset);
            int charIndex = byteOffset / sizeof(char);
            int byteInChar = byteOffset % sizeof(char);
            char value = charIndex < FValue.Length
                ? FValue[charIndex]
                : '\0';

            if (BitConverter.IsLittleEndian)
            {
                return byteInChar == 0
                    ? unchecked((byte)value)
                    : unchecked((byte)(value >> 8));
            }

            return byteInChar == 0
                ? unchecked((byte)(value >> 8))
                : unchecked((byte)value);
        }

        internal override void WriteByte(nint absoluteOffset, byte value)
        {
            throw new InvalidOperationException(
                "A managed string pointer is read-only.");
        }

        internal override bool TryReadValue<T>(
            nint absoluteOffset,
            out T value)
        {
            if (typeof(T) != typeof(char) ||
                absoluteOffset < 0 ||
                absoluteOffset % sizeof(char) != 0)
            {
                value = default!;
                return false;
            }

            nint charIndex = absoluteOffset / sizeof(char);

            if (charIndex < 0 || charIndex > FValue.Length)
            {
                value = default!;
                return false;
            }

            char character = charIndex < FValue.Length
                ? FValue[checked((int)charIndex)]
                : '\0';

            value = (T)(object)character;
            return true;
        }
    }

    internal sealed class NativeMemoryBacking : PointerBacking
    {
        private readonly object FLifetimeLock = new object();
        private IntPtr FAddress;
        private readonly nint FByteLength;
        private readonly bool FOwnsMemory;
        private int FFreed;
        private int FPinCount;

        internal NativeMemoryBacking(
            IntPtr address,
            nint byteLength,
            bool ownsMemory)
        {
            if (byteLength < -1)
                throw new ArgumentOutOfRangeException(nameof(byteLength));

            FAddress = address;
            FByteLength = byteLength;
            FOwnsMemory = ownsMemory;
        }

        internal override nint ByteLength => FByteLength;

        internal override bool IsAlive =>
            Volatile.Read(ref FFreed) == 0 &&
            FAddress != IntPtr.Zero;

        internal override byte ReadByte(nint absoluteOffset)
        {
            lock (FLifetimeLock)
            {
                ValidateRange(absoluteOffset, 1);
                return Marshal.ReadByte(FAddress, checked((int)absoluteOffset));
            }
        }

        internal override void WriteByte(nint absoluteOffset, byte value)
        {
            lock (FLifetimeLock)
            {
                ValidateRange(absoluteOffset, 1);
                Marshal.WriteByte(FAddress, checked((int)absoluteOffset), value);
            }
        }

        internal override PointerPin Pin(nint absoluteOffset)
        {
            lock (FLifetimeLock)
            {
                ValidateRange(absoluteOffset, 0);
                IntPtr address = IntPtr.Add(FAddress, checked((int)absoluteOffset));
                int nextCount = checked(FPinCount + 1);
                PointerPin pin = new PointerPin(address, ReleasePin);
                FPinCount = nextCount;
                return pin;
            }
        }

        internal override IntPtr GetPersistentAddress(nint absoluteOffset)
        {
            lock (FLifetimeLock)
            {
                ValidateRange(absoluteOffset, 0);
                return IntPtr.Add(FAddress, checked((int)absoluteOffset));
            }
        }

        internal override bool CanFree =>
            FOwnsMemory &&
            IsAlive;

        internal override void Free()
        {
            if (!FOwnsMemory)
            {
                throw new InvalidOperationException(
                    "The native memory is borrowed and cannot be freed here.");
            }

            Release();
            GC.SuppressFinalize(this);
        }

        private void Release()
        {
            lock (FLifetimeLock)
            {
                if (FFreed != 0)
                    return;
                Volatile.Write(ref FFreed, 1);
                if (FPinCount == 0)
                    ReleaseStorage();
            }
        }

        private void ReleasePin()
        {
            lock (FLifetimeLock)
            {
                if (--FPinCount == 0 && FFreed != 0)
                    ReleaseStorage();
            }
        }

        // The caller holds FLifetimeLock. Borrowed memory is never freed here.
        private void ReleaseStorage()
        {
            IntPtr address = FAddress;
            FAddress = IntPtr.Zero;
            if (FOwnsMemory && address != IntPtr.Zero)
                Marshal.FreeHGlobal(address);
        }

        ~NativeMemoryBacking()
        {
            if (FOwnsMemory)
                Release();
        }
    }

    internal readonly struct PointerView : IEquatable<PointerView>
    {
        internal PointerView(
            PointerBacking backing,
            nint byteOffset,
            nint byteLength)
        {
            Backing = backing ?? throw new ArgumentNullException(nameof(backing));

            if (byteOffset < 0)
                throw new ArgumentOutOfRangeException(nameof(byteOffset));
            if (byteLength < -1)
                throw new ArgumentOutOfRangeException(nameof(byteLength));

            backing.ValidateRange(byteOffset, 0);

            if (byteLength >= 0)
                backing.ValidateRange(byteOffset, byteLength);

            ByteOffset = byteOffset;
            ByteLength = byteLength;
        }

        internal PointerBacking? Backing { get; }
        internal nint ByteOffset { get; }
        internal nint ByteLength { get; }
        internal bool IsNull => Backing == null;

        internal static PointerView FromBacking(PointerBacking backing)
        {
            return new PointerView(backing, 0, backing.ByteLength);
        }

        internal PointerView Slice(nint relativeByteOffset)
        {
            if (IsNull)
                throw new NullReferenceException("Pointer is null.");

            nint newOffset = checked(ByteOffset + relativeByteOffset);

            if (newOffset < 0)
                throw new ArgumentOutOfRangeException(nameof(relativeByteOffset));

            if (relativeByteOffset >= 0 &&
                ByteLength >= 0 &&
                relativeByteOffset > ByteLength)
            {
                throw new ArgumentOutOfRangeException(nameof(relativeByteOffset));
            }

            nint newLength;

            if (Backing!.ByteLength >= 0)
                newLength = Backing.ByteLength - newOffset;
            else
                newLength = -1;

            return new PointerView(Backing, newOffset, newLength);
        }

        internal void ValidateRelativeRange(nint relativeOffset, nint count)
        {
            if (IsNull)
                throw new NullReferenceException("Pointer is null.");

            if (relativeOffset < 0)
            {
                throw new IndexOutOfRangeException(
                    "Pointer access before the current position.");
            }

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            nint end = checked(relativeOffset + count);

            if (ByteLength >= 0 && end > ByteLength)
            {
                throw new IndexOutOfRangeException(
                    "Pointer access outside the current view.");
            }

            Backing!.ValidateRange(
                checked(ByteOffset + relativeOffset),
                count);
        }

        internal byte ReadByte(nint relativeOffset)
        {
            ValidateRelativeRange(relativeOffset, 1);
            return Backing!.ReadByte(ByteOffset + relativeOffset);
        }

        internal void WriteByte(nint relativeOffset, byte value)
        {
            ValidateRelativeRange(relativeOffset, 1);

            if (Backing!.IsReadOnly)
                throw new InvalidOperationException("Pointer is read-only.");

            Backing.WriteByte(ByteOffset + relativeOffset, value);
        }

        internal T Read<T>(nint relativeOffset)
        {
            int size = DelphiTypeLayout.SizeOf<T>();
            ValidateRelativeRange(relativeOffset, size);
            nint absoluteOffset = checked(ByteOffset + relativeOffset);

            if (Backing!.TryReadValue(absoluteOffset, out T value))
                return value;

            if (!DelphiTypeLayout.IsByteAddressable<T>())
            {
                throw new NotSupportedException(
                    $"Type '{typeof(T).FullName}' cannot be read from raw bytes.");
            }

            byte[] bytes = new byte[size];

            for (int i = 0; i < size; i++)
                bytes[i] = Backing.ReadByte(absoluteOffset + i);

            return (T)DelphiValueCodec.FromBytes(bytes, typeof(T));
        }

        internal void Write<T>(nint relativeOffset, T value)
        {
            int size = DelphiTypeLayout.SizeOf<T>();
            ValidateRelativeRange(relativeOffset, size);

            if (Backing!.IsReadOnly)
                throw new InvalidOperationException("Pointer is read-only.");

            nint absoluteOffset = checked(ByteOffset + relativeOffset);

            if (Backing.TryWriteValue(absoluteOffset, value))
                return;

            if (!DelphiTypeLayout.IsByteAddressable<T>())
            {
                throw new NotSupportedException(
                    $"Type '{typeof(T).FullName}' cannot be written as raw bytes.");
            }

            byte[] bytes = DelphiValueCodec.ToBytes(
                value,
                typeof(T),
                size);

            for (int i = 0; i < size; i++)
                Backing.WriteByte(absoluteOffset + i, bytes[i]);
        }

        internal PointerPin Pin()
        {
            return IsNull
                ? new PointerPin(IntPtr.Zero)
                : Backing!.Pin(ByteOffset);
        }

        internal IntPtr GetPersistentAddress()
        {
            return IsNull
                ? IntPtr.Zero
                : Backing!.GetPersistentAddress(ByteOffset);
        }

        internal bool CanFreeBacking()
        {
            return !IsNull &&
                   ByteOffset == 0 &&
                   Backing!.CanFree;
        }

        internal bool TryFreeBacking()
        {
            if (!CanFreeBacking())
                return false;

            Backing!.Free();
            return true;
        }
        internal void FreeBacking()
        {
            if (!IsNull)
                Backing!.Free();
        }

        public bool Equals(PointerView other)
        {
            if (IsNull || other.IsNull)
                return IsNull && other.IsNull;

            return ReferenceEquals(Backing, other.Backing) &&
                   ByteOffset == other.ByteOffset;
        }

        public override bool Equals(object? obj)
        {
            return obj is PointerView other && Equals(other);
        }

        public override int GetHashCode()
        {
            return IsNull
                ? 0
                : HashCode.Combine(Backing, ByteOffset);
        }
    }

    internal static class DelphiValueCodec
    {
        internal static byte[] ToBytes(
            object? value,
            Type type,
            int size)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            if (DelphiTypeLayout.TryGetCodec(type, out IDelphiBinaryCodec codec))
                return codec.Encode(value);

            if (type.IsEnum)
            {
                Type underlying = Enum.GetUnderlyingType(type);
                object converted = value == null
                    ? Activator.CreateInstance(underlying)!
                    : Convert.ChangeType(value, underlying);

                return ToBytes(
                    converted,
                    underlying,
                    DelphiTypeLayout.SizeOf(underlying));
            }

            if (value == null)
                return new byte[size];

            byte[] result;

            if (type == typeof(bool))
                result = new[] { (bool)value ? (byte)1 : (byte)0 };
            else if (type == typeof(byte))
                result = new[] { (byte)value };
            else if (type == typeof(sbyte))
                result = new[] { unchecked((byte)(sbyte)value) };
            else if (type == typeof(char))
                result = BitConverter.GetBytes((char)value);
            else if (type == typeof(short))
                result = BitConverter.GetBytes((short)value);
            else if (type == typeof(ushort))
                result = BitConverter.GetBytes((ushort)value);
            else if (type == typeof(int))
                result = BitConverter.GetBytes((int)value);
            else if (type == typeof(uint))
                result = BitConverter.GetBytes((uint)value);
            else if (type == typeof(long))
                result = BitConverter.GetBytes((long)value);
            else if (type == typeof(ulong))
                result = BitConverter.GetBytes((ulong)value);
            else if (type == typeof(float))
                result = BitConverter.GetBytes((float)value);
            else if (type == typeof(double))
                result = BitConverter.GetBytes((double)value);
            else if (type == typeof(IntPtr))
                result = IntPtr.Size == 4
                    ? BitConverter.GetBytes(((IntPtr)value).ToInt32())
                    : BitConverter.GetBytes(((IntPtr)value).ToInt64());
            else if (type == typeof(UIntPtr))
                result = UIntPtr.Size == 4
                    ? BitConverter.GetBytes(((UIntPtr)value).ToUInt32())
                    : BitConverter.GetBytes(((UIntPtr)value).ToUInt64());
            else if (type == typeof(decimal))
            {
                int[] bits = decimal.GetBits((decimal)value);
                result = new byte[16];
                Buffer.BlockCopy(bits, 0, result, 0, 16);
            }
            else
            {
                if (!DelphiTypeLayout.IsByteAddressable(type))
                    throw new NotSupportedException($"Type '{type.FullName}' is not byte-addressable.");

                int marshalSize = Marshal.SizeOf(type);

                if (marshalSize > size)
                {
                    throw new NotSupportedException(
                        $"The Delphi size for '{type.FullName}' is smaller than " +
                        "its marshalled size. Register a custom codec.");
                }

                IntPtr memory = Marshal.AllocHGlobal(size);

                try
                {
                    for (int i = 0; i < size; i++)
                        Marshal.WriteByte(memory, i, 0);

                    Marshal.StructureToPtr(value, memory, false);
                    result = new byte[size];
                    Marshal.Copy(memory, result, 0, size);
                }
                finally
                {
                    Marshal.FreeHGlobal(memory);
                }
            }

            if (result.Length == size)
                return result;

            byte[] resized = new byte[size];
            Buffer.BlockCopy(result, 0, resized, 0, Math.Min(result.Length, size));
            return resized;
        }

        internal static object FromBytes(byte[] bytes, Type type)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (DelphiTypeLayout.TryGetCodec(type, out IDelphiBinaryCodec codec))
                return codec.Decode(bytes);

            if (type.IsEnum)
            {
                Type underlying = Enum.GetUnderlyingType(type);
                return Enum.ToObject(type, FromBytes(bytes, underlying));
            }

            if (type == typeof(bool))
                return bytes[0] != 0;
            if (type == typeof(byte))
                return bytes[0];
            if (type == typeof(sbyte))
                return unchecked((sbyte)bytes[0]);
            if (type == typeof(char))
                return BitConverter.ToChar(bytes, 0);
            if (type == typeof(short))
                return BitConverter.ToInt16(bytes, 0);
            if (type == typeof(ushort))
                return BitConverter.ToUInt16(bytes, 0);
            if (type == typeof(int))
                return BitConverter.ToInt32(bytes, 0);
            if (type == typeof(uint))
                return BitConverter.ToUInt32(bytes, 0);
            if (type == typeof(long))
                return BitConverter.ToInt64(bytes, 0);
            if (type == typeof(ulong))
                return BitConverter.ToUInt64(bytes, 0);
            if (type == typeof(float))
                return BitConverter.ToSingle(bytes, 0);
            if (type == typeof(double))
                return BitConverter.ToDouble(bytes, 0);
            if (type == typeof(IntPtr))
            {
                return IntPtr.Size == 4
                    ? new IntPtr(BitConverter.ToInt32(bytes, 0))
                    : new IntPtr(BitConverter.ToInt64(bytes, 0));
            }
            if (type == typeof(UIntPtr))
            {
                return UIntPtr.Size == 4
                    ? new UIntPtr(BitConverter.ToUInt32(bytes, 0))
                    : new UIntPtr(BitConverter.ToUInt64(bytes, 0));
            }
            if (type == typeof(decimal))
            {
                int[] bits = new int[4];
                Buffer.BlockCopy(bytes, 0, bits, 0, 16);
                return new decimal(bits);
            }

            if (!DelphiTypeLayout.IsByteAddressable(type))
                throw new NotSupportedException($"Type '{type.FullName}' is not byte-addressable.");

            int marshalSize = Marshal.SizeOf(type);

            if (bytes.Length < marshalSize)
            {
                throw new NotSupportedException(
                    $"The Delphi size for '{type.FullName}' is smaller than " +
                    "its marshalled size. Register a custom codec.");
            }

            IntPtr memory = Marshal.AllocHGlobal(bytes.Length);

            try
            {
                Marshal.Copy(bytes, 0, memory, bytes.Length);
                return Marshal.PtrToStructure(memory, type)
                    ?? throw new InvalidOperationException(
                        $"Cannot reconstruct '{type.FullName}' from bytes.");
            }
            finally
            {
                Marshal.FreeHGlobal(memory);
            }
        }
    }
}
