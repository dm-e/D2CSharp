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

namespace System
{
    public struct Pointer : IPointer<byte>, IEquatable<Pointer>
    {
        private UntypedPointer FValue;

        public static int DelphiSizeOf
        {
            get
            {
                return D2C.PointerSize;
            }
        }



        internal Pointer(UntypedPointer value)
        {
            FValue = value;
        }

        public Pointer(int size)
        {
            FValue = UntypedPointer.AllocNative(size);
        }

        [Obsolete(
            "Allocated memory is always owned. Use Pointer(IntPtr, size, false) " +
            "for borrowed native memory.")]
        public Pointer(int size, bool ownsMemory)
        {
            FValue = UntypedPointer.AllocNative(size);
        }

        public Pointer(
            IntPtr address,
            int size = 0,
            bool ownsMemory = false)
        {
            FValue = new UntypedPointer(address, size, ownsMemory);
        }

        public Pointer(byte[]? bytes)
        {
            FValue = new UntypedPointer(bytes);
        }

        public Pointer(Pointer other, int byteDelta = 0)
        {
            FValue = byteDelta == 0
                ? other.FValue
                : other.FValue + byteDelta;
        }

        public int Length => FValue.Length;
        public int Capacity => FValue.Capacity;
        public int Position => FValue.Position;
        public IntPtr Address => FValue.ToIntPtr();
        public IntPtr ToIntPtr => FValue.ToIntPtr(); // cgpt often assumes this member

        public bool IsNull() => FValue.IsNull();
        public void SetNull() => FValue.SetNull();
        public byte Deref() => FValue.Deref();

        public byte this[int index]
        {
            get => FValue[index];
            set => FValue[index] = value;
        }

        public void Assign(byte value, int index = 0)
        {
            FValue.Assign(value, index);
        }

        public void Inc(int count) => FValue.Inc(count);
        public void Dec(int count) => FValue.Dec(count);

        public Pointer Add(int byteDelta)
        {
            return new Pointer(FValue + byteDelta);
        }

        public byte ReadByte() => FValue.Deref();
        public byte ReadByte(int index) => FValue[index];
        public void WriteByte(byte value) => FValue.Assign(value);
        public void WriteByte(int index, byte value) => FValue.Assign(value, index);
        public int ReadInt32() => FValue.Read<int>();
        public void WriteInt32(int value) => FValue.Write(value);

        public T Read<T>(int index = 0)
        {
            return FValue.Read<T>(checked(
                index * DelphiTypeLayout.SizeOf<T>()));
        }

        public void Write<T>(int index, T value)
        {
            FValue.Write(value, checked(
                index * DelphiTypeLayout.SizeOf<T>()));
        }

        public UntypedPointer ToUntypedPointer(int byteOffset = 0)
        {
            return byteOffset == 0 ? FValue : FValue + byteOffset;
        }

        public Pointer<T> CreateView<T>(IntPtr address, int byteLength)
        {
            if (IsNull())
            {
                throw new NullReferenceException(
                    "The owner pointer is null.");
            }

            if (address == IntPtr.Zero)
                return default;

            if (byteLength < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(byteLength));
            }

            PointerView ownerView = FValue.View;
            IntPtr ownerAddress = FValue.ToIntPtr(); // Managed owners require a caller-held pin.
            long relativeOffset64;

            try
            {
                relativeOffset64 = checked(
                    address.ToInt64() -
                    ownerAddress.ToInt64());
            }
            catch (OverflowException exception)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(address),
                    "The address cannot be represented relative to the owner pointer.");
            }

            if (relativeOffset64 < 0 ||
                relativeOffset64 > nint.MaxValue)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(address),
                    "The address is outside the owner pointer view.");
            }

            nint relativeOffset = (nint)relativeOffset64;
            nint requestedLength = byteLength;

            if (ownerView.ByteLength >= 0)
            {
                nint end;

                try
                {
                    end = checked(
                        relativeOffset + requestedLength);
                }
                catch (OverflowException exception)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(byteLength),
                        "The requested view length overflows the owner pointer view.");
                }

                if (end > ownerView.ByteLength)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(byteLength),
                        "The requested view is outside the owner pointer view.");
                }
            }

            nint absoluteOffset = checked(
                ownerView.ByteOffset + relativeOffset);

            PointerView view = new PointerView(
                ownerView.Backing!,
                absoluteOffset,
                requestedLength);

            return new Pointer<T>(
                new UntypedPointer(view));
        }

        public bool CanFreeMemory()
        {
            return FValue.CanFreeMemory();
        }

        public bool TryFreeMemory()
        {
            return FValue.TryFreeMemory();
        }

        public Pointer<T> As<T>() => new Pointer<T>(FValue);
        public PointerPin Pin() => FValue.Pin();
        public void FreeMemory() => FValue.FreeMemory();
        public void Dispose() => FValue.Dispose();

        public static Pointer FromValue(int value)
        {
            Pointer result = new Pointer(sizeof(int));
            result.WriteInt32(value);
            return result;
        }

        public static Pointer FromInt32(int value) => FromValue(value);

        private static readonly ConditionalWeakTable<TObject, TObject[]>
            FObjectPointerCells =
                new ConditionalWeakTable<TObject, TObject[]>();

        public static Pointer FromObject(TObject? value)
        {
            if (value == null)
            {
                return default;
            }

            TObject[] cell = FObjectPointerCells.GetValue(
                value,
                static obj => new TObject[] { obj });

            return new Pointer<TObject>(cell).ToPointer();
        }

        public TObject? ToObject()
        {
            return IsNull()
                ? null
                : As<TObject>().Deref();
        }

        private static readonly ConditionalWeakTable<Type, TClass[]>
            FClassPointerCells =
                new ConditionalWeakTable<Type, TClass[]>();

        public static Pointer FromClass(TClass? value)
        {
            if (value == null)
            {
                return default;
            }

            TClass[] cell = FClassPointerCells.GetValue(
                value.Type,
                static type => new TClass[] { TClass.Of(type) });

            return new Pointer<TClass>(cell).ToPointer();
        }

        public TClass? ToClass()
        {
            if (IsNull())
            {
                return null;
            }

            return As<TClass>().Deref();
        }

        public static Pointer operator +(Pointer pointer, int byteDelta)
        {
            return pointer.IsNull() ? default : pointer.Add(byteDelta);
        }

        public static Pointer operator -(Pointer pointer, int byteDelta)
        {
            return pointer + checked(-byteDelta);
        }

        public static Pointer operator ++(Pointer pointer) => pointer + 1;
        public static Pointer operator --(Pointer pointer) => pointer - 1;

        public static implicit operator IntPtr(Pointer pointer) => pointer.Address;
        public static implicit operator Pointer(IntPtr address) => new Pointer(address);
        public static implicit operator UntypedPointer(Pointer pointer) => pointer.FValue;
        public static implicit operator Pointer(UntypedPointer pointer) => new Pointer(pointer);

        public bool Equals(Pointer other) => FValue.Equals(other.FValue);
        public override bool Equals(object? obj) => obj is Pointer other && Equals(other);
        public override int GetHashCode() => FValue.GetHashCode();
        public static bool operator ==(Pointer left, Pointer right) => left.Equals(right);
        public static bool operator !=(Pointer left, Pointer right) => !left.Equals(right);
    }

    public struct Pointer<T> : IPointer<T>, IEquatable<Pointer<T>>
    {
        private UntypedPointer FValue;

        public Pointer(T value)
        {
            FValue = new UntypedPointer(new[] { value }, 0);
        }

        public Pointer(T[]? array, int index = 0)
        {
            FValue = new UntypedPointer(array, index);
        }

        #if USEDYNAMICARRAY
        public Pointer(DynamicArray<T> array, int index = 0)
        {
            FValue = array.IsNil
                ? default
                : new UntypedPointer(array.RawArrayUntyped, index);
        }
        #endif

        public Pointer(Pointer<T> other, int delta = 0)
        {
            FValue = delta == 0
                ? other.FValue
                : other.FValue + checked(
                    delta * other.ValueSize);
        }

        public Pointer(Pointer rawPointer)
        {
            FValue = rawPointer.ToUntypedPointer();
        }

        internal Pointer(UntypedPointer pointer)
        {
            FValue = pointer;
        }

        public Pointer(int size, bool rawMemory)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            FValue = rawMemory
                ? UntypedPointer.AllocNative(size)
                : size == 0
                    ? default
                    : new UntypedPointer(new T[size], 0);
        }

        /// <summary>
        /// Address a static array variable. Reuse the same Ref instance for the
        /// same variable; repeated calls preserve pointer identity and layout.
        /// </summary>
        public static Pointer<T> FromLocation(Ref<T> location,
            DelphiStaticArrayInfo info)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));
            StaticArrayBacking<T> backing = StaticArrayLocationRegistry.ForField(
                location, nameof(Ref<T>.Value), info,
                () => new StaticArrayBacking<T>(location, info, false));
            return new Pointer<T>(new UntypedPointer(PointerView.FromBacking(backing)));
        }

        /// <summary>Address a typed variable using its declared Delphi size.</summary>
        public static Pointer<T> FromReference(Ref<T> location, int size) =>
            new(new UntypedPointer(PointerView.FromBacking(ReferenceBacking<T>.ForLocation(location, size))));

        /// <summary>Address an array field through a typed record variable pointer.</summary>
        public static Pointer<T> FromRecordField<TRecord>(Pointer<TRecord> record,
            string fieldKey, Func<TRecord, T> getter, Action<TRecord, T> setter,
            DelphiStaticArrayInfo info)
        {
            if (record.IsNull()) throw new NullReferenceException("Pointer is null.");
            if (getter == null) throw new ArgumentNullException(nameof(getter));
            if (setter == null) throw new ArgumentNullException(nameof(setter));
            var view = record.FValue.View;
            if (view.ByteOffset != 0 || view.Backing is not ReferenceBacking<TRecord> backing)
                throw new NotSupportedException("A typed record variable location is required.");
            return FromField(backing.Location, fieldKey,
                location => getter(location.Value), (location, value) => setter(location.Value, value), info);
        }

        /// <summary>
        /// Address a field of a FIXED receiver. Two calls with the same receiver
        /// (reference identity) and fieldKey yield pointers to the same Delphi
        /// location and therefore compare equal. A different fieldKey or receiver
        /// is a different address, even when the fields contain the same array.
        /// Use the declaring Type as receiver for static fields.
        /// The caller must use a unique, stable fieldKey (e.g. nameof(Cells)).
        /// Do not use this API for changing receiver expressions: evaluate the
        /// receiver once, then pass it here.
        /// </summary>
        public static Pointer<T> FromField<TOwner>(
            TOwner owner, string fieldKey,
            Func<TOwner, T> getter, Action<TOwner, T> setter,
            DelphiStaticArrayInfo info) where TOwner : class
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));
            if (setter == null)
                throw new ArgumentNullException(nameof(setter));
            StaticArrayBacking<T> backing = StaticArrayLocationRegistry.ForField(
                owner, fieldKey, info,
                () => new StaticArrayBacking<T>(
                    new Ref<T>(() => getter(owner), value => setter(owner, value)),
                    info, false));
            return new Pointer<T>(new UntypedPointer(PointerView.FromBacking(backing)));
        }

        /// <summary>
        /// Address a static field qualified by a receiver expression. The caller
        /// evaluates that expression once at this argument position; the field
        /// identity still belongs to its declaring type, including a null receiver.
        /// </summary>
        public static Pointer<T> FromStaticField<TOwner>(
            TOwner evaluatedReceiver, Type declaringType, string fieldKey,
            Func<Type, T> getter, Action<Type, T> setter, DelphiStaticArrayInfo info)
        {
            return FromField(declaringType, fieldKey, getter, setter, info);
        }

        /// <summary>
        /// Interpret this pointer's addressed ARRAY VARIABLE as a complete
        /// Delphi static-array location with a known source-level layout.
        /// Useful when an outer static array contains another static array:
        /// outer.ElementPointer&lt;int[]&gt;(0).AsStaticArrayPointer(innerInfo).
        /// The returned borrowed view delegates reads/writes to this pointer;
        /// it shares the underlying owner's lifetime and does not own memory.
        /// </summary>
        public Pointer<T> AsStaticArrayPointer(DelphiStaticArrayInfo info)
        {
            if (IsNull())
                throw new NullReferenceException("Pointer is null.");
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            // If this is already a pointer to the complete static array,
            // preserve its address identity instead of wrapping it again.
            DelphiStaticArrayInfo? current = StaticArrayInfo;
            if (current != null)
            {
                if (!current.IsCompatibleLocationLayout(info))
                    throw new InvalidOperationException(
                        "The pointer already has a different static array layout.");
                return this;
            }

            PointerView view = FValue.View;
            if (!view.Backing!.IsAlive)
                throw new ObjectDisposedException("Pointer backing");
            Pointer<T> location = this;
            StaticArrayBacking<T> backing = StaticArrayLocationRegistry.ForNested(
                view.Backing, view.ByteOffset, info,
                () => new StaticArrayBacking<T>(new Ref<T>(
                    () => location.Deref(),
                    value => location.Assign(value)), info, false));
            return new Pointer<T>(new UntypedPointer(PointerView.FromBacking(backing)));
        }

        /// <summary>Allocate exactly one full Delphi static array value.</summary>
        public static Pointer<T> AllocateStaticArray(DelphiStaticArrayInfo info)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            if (!typeof(T).IsArray ||
                typeof(T).GetArrayRank() != info.Rank ||
                typeof(T).GetElementType() != info.ElementType)
                throw new ArgumentException(
                    "The pointer's array type does not match its layout.", nameof(info));
            T[] cell = new[] { (T)(object)info.Allocate() };
            return FromOwnedStaticArray(cell, info);
        }

        private static Pointer<T> FromOwnedStaticArray(T[] cell,
            DelphiStaticArrayInfo info)
        {
            return new Pointer<T>(new UntypedPointer(
                PointerView.FromBacking(new StaticArrayBacking<T>(
                    new Ref<T>(() => cell[0], value => cell[0] = value),
                    info, true))));
        }

        /// <summary>
        /// Address an element within a complete static array. Indices are
        /// ZERO-BASED CLR indices, not Delphi indices; the converter applies
        /// the bounds shift before calling this method. The returned pointer
        /// shares its backing and lifetime with the complete array pointer.
        /// This also supports record and reference elements (without casting
        /// their values into bytes).
        /// </summary>
        public Pointer<TElement> ElementPointer<TElement>(params int[] zeroBasedIndices)
        {
            if (IsNull())
                throw new NullReferenceException("Pointer is null.");
            if (FValue.View.ByteOffset != 0)
                throw new InvalidOperationException(
                    "An element address requires a pointer to the complete static array.");
            DelphiStaticArrayInfo? info = StaticArrayInfo;
            if (info == null)
                throw new InvalidOperationException(
                    "The pointer does not have a static array layout.");
            if (info.ElementType != typeof(TElement))
                throw new ArgumentException(
                    "The requested element pointer type does not match the array element type.");

            // Keep the SAME backing (including when it points at a mutable field).
            return new Pointer<TElement>(FValue +
                info.GetElementByteOffset(zeroBasedIndices));
        }

        internal DelphiStaticArrayInfo? StaticArrayInfo =>
            (FValue.View.Backing as StaticArrayBacking<T>)?.Info;

        private int ValueSize => FValue.ValueSize<T>();

        public int Length
        {
            get
            {
                if (IsNull())
                    return 0;

                nint bytes = FValue.RemainingByteLength;

                if (bytes < 0)
                    return int.MaxValue;

                return checked((int)(bytes / ValueSize));
            }
        }

        public int Capacity
        {
            get
            {
                if (IsNull())
                    return 0;

                int bytes = FValue.Capacity;
                return bytes == int.MaxValue
                    ? int.MaxValue
                    : bytes / ValueSize;
            }
        }

        public int Position => IsNull()
            ? 0
            : checked((int)(
                FValue.AbsoluteByteOffset /
                ValueSize));

        public bool IsNull() => FValue.IsNull();
        public void SetNull() => FValue.SetNull();
        public T Deref() => FValue.Read<T>();

        public T this[int index]
        {
            get => FValue.Read<T>(checked(
                index * ValueSize));
            set => Assign(value, index);
        }

        public void Assign(T value, int index = 0)
        {
            FValue.Write(value, checked(
                index * ValueSize));
        }

        public void Inc(int count)
        {
            FValue.Inc(checked(count * ValueSize));
        }

        public void Dec(int count)
        {
            FValue.Dec(checked(count * ValueSize));
        }

        public Pointer<T> Add(int elementDelta)
        {
            return IsNull()
                ? default
                : new Pointer<T>(FValue + checked(
                    elementDelta * ValueSize));
        }

        public bool CanFreeMemory()
        {
            return FValue.CanFreeMemory();
        }

        public bool TryFreeMemory()
        {
            return FValue.TryFreeMemory();
        }

        public UntypedPointer ToUntypedPointer() => FValue;
        public Pointer ToPointer() => new Pointer(FValue);
        public IntPtr ToIntPtr() => FValue.ToIntPtr();
        public PointerPin Pin() => FValue.Pin();
        public T FromIntPtr() => IsNull() ? default! : Deref();
        public void FreeMemory() => FValue.FreeMemory();
        public void Dispose() => FValue.Dispose();

        public static Pointer<T> operator +(Pointer<T> pointer, int delta) => pointer.Add(delta);
        public static Pointer<T> operator -(Pointer<T> pointer, int delta) => pointer.Add(checked(-delta));
        public static Pointer<T> operator ++(Pointer<T> pointer) => pointer.Add(1);
        public static Pointer<T> operator --(Pointer<T> pointer) => pointer.Add(-1);

        public static implicit operator UntypedPointer(Pointer<T> pointer) => pointer.FValue;
        public static explicit operator Pointer<T>(UntypedPointer pointer) => new Pointer<T>(pointer);
        public static explicit operator Pointer<T>(Pointer pointer) => new Pointer<T>(pointer);

        public bool Equals(Pointer<T> other) => FValue.Equals(other.FValue);
        public override bool Equals(object? obj) => obj is Pointer<T> other && Equals(other);
        public override int GetHashCode() => FValue.GetHashCode();
        public static bool operator ==(Pointer<T> left, Pointer<T> right) => left.Equals(right);
        public static bool operator !=(Pointer<T> left, Pointer<T> right) => !left.Equals(right);
    }

    public sealed class DelphiCell<T>
    {
        private readonly T[] FStorage;

        public DelphiCell()
            : this(default!)
        {
        }

        public DelphiCell(T value)
        {
            FStorage = new[] { value };
        }

        // Preserve assignable fields when the stored Delphi value is a record.
        public ref T Value => ref FStorage[0];

        public Pointer<T> AsPointer() => new Pointer<T>(FStorage);
        public UntypedPointer AsUntypedPointer() => new UntypedPointer(FStorage);

        /// <summary>
        /// Address the static array held in this variable cell. Unlike
        /// AsPointer(), writes to the complete array copy its contents.
        /// </summary>
        public Pointer<T> AsStaticArrayPointer(DelphiStaticArrayInfo info) =>
            Pointer<T>.FromField(this, nameof(Value),
                static cell => cell.Value,
                static (cell, value) => cell.Value = value, info);
    }

    public sealed class DelphiReferenceCell<T>
        where T : class?
    {
        private readonly T?[] FStorage;

        public DelphiReferenceCell(T? value = default)
        {
            FStorage = new[] { value };
        }

        public T? Value
        {
            get => FStorage[0];
            set => FStorage[0] = value;
        }

        public Pointer<T?> AsPointer() => new Pointer<T?>(FStorage);
    }

    public sealed class DelphiPointer
    {
        public DelphiPointer()
        {
        }

        public DelphiPointer(object? target)
        {
            Target = target;
        }

        public object? Target { get; set; }
    }

    public sealed class DelphiBuffer
    {
        private readonly byte[] FData;

        public DelphiBuffer(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            FData = new byte[size];
        }

        public Span<byte> Span => FData;
        public byte[] Data => FData;
        public UntypedPointer Pointer => new UntypedPointer(FData);
    }

    public sealed class Ref<T>
    {
        private readonly Func<T> FGetter;
        private readonly Action<T> FSetter;

        public Ref(Func<T> getter, Action<T> setter)
        {
            FGetter = getter ?? throw new ArgumentNullException(nameof(getter));
            FSetter = setter ?? throw new ArgumentNullException(nameof(setter));
        }

        public T Value
        {
            get => FGetter();
            set => FSetter(value);
        }
    }
}
