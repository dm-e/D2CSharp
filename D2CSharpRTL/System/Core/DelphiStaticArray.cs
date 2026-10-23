/*
  D2CSharp Runtime Library (RTL)
  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: MPL-2.0
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at https://mozilla.org/MPL/2.0/.
*/

#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System
{
    /// <summary>
    /// Source-level layout of a Delphi STATIC array. Unlike typeof(T[]), this
    /// descriptor retains its fixed lengths and Delphi index lower bounds.
    /// Do not globally register this layout against a CLR array Type: several
    /// Delphi static arrays can map to the same CLR Type.
    /// </summary>
    public sealed class DelphiStaticArrayInfo
    {
        private readonly int[] FLowerBounds;
        private readonly int[] FLengths;
        // Optional, explicitly generated rules for elements which themselves
        // contain Delphi VALUE-owned references (nested static arrays/records).
        // CLR reflection cannot distinguish them from dynamic arrays/references.
        private readonly Func<object?, object?>? FCloneElement;
        private readonly Func<object?, object?, object?>? FAssignElement;
        private readonly Func<object?>? FCreateElement;

        private DelphiStaticArrayInfo(Type elementType, int elementSize,
            int[] lowerBounds, int[] lengths,
            Func<object?, object?>? cloneElement = null,
            Func<object?, object?, object?>? assignElement = null,
            Func<object?>? createElement = null)
        {
            if (elementSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(elementSize));
            if (lowerBounds == null)
                throw new ArgumentNullException(nameof(lowerBounds));
            if (lengths == null)
                throw new ArgumentNullException(nameof(lengths));
            if (lengths.Length == 0 || lengths.Length != lowerBounds.Length)
                throw new ArgumentException("Array dimensions do not match.");

            ElementType = elementType;
            ElementSize = elementSize;
            FLowerBounds = (int[])lowerBounds.Clone();
            FLengths = (int[])lengths.Clone();
            FCloneElement = cloneElement;
            FAssignElement = assignElement;
            FCreateElement = createElement;
            int count = 1;
            foreach (int length in FLengths)
            {
                if (length <= 0)
                    throw new ArgumentOutOfRangeException(nameof(lengths),
                        "Static array dimensions must be positive.");
                count = checked(count * length);
            }
            ElementCount = count;
            ByteSize = checked(count * elementSize);
        }

        public static DelphiStaticArrayInfo Create<TElement>(
            int[] lowerBounds, int[] lengths)
        {
            // D2C.SizeOf models the Delphi target, not the host CLR size.
            return new DelphiStaticArrayInfo(typeof(TElement),
                D2C.SizeOf(typeof(TElement)), lowerBounds, lengths);
        }

        public static DelphiStaticArrayInfo Create<TElement>(
            int[] lowerBounds, int[] lengths, int elementSize)
        {
            // Explicit layout is useful for packed records or custom codecs.
            return new DelphiStaticArrayInfo(typeof(TElement),
                elementSize, lowerBounds, lengths);
        }

        /// <summary>
        /// Registers source-level value semantics for array elements containing
        /// nested static arrays or Delphi records. "clone" makes a new value,
        /// "assign" writes a value to an EXISTING element and should preserve
        /// locations of nested static arrays where possible. "create" initializes
        /// nested values when a complete array is allocated through GetMem.
        /// Dynamic arrays and class references should normally retain their
        /// ordinary (shallow) Delphi copy semantics.
        /// The returned descriptor is immutable; the original is unchanged.
        /// </summary>
        public DelphiStaticArrayInfo WithElementValueSemantics<TElement>(
            Func<TElement, TElement> clone,
            Func<TElement, TElement, TElement> assign,
            Func<TElement>? create = null)
        {
            if (typeof(TElement) != ElementType)
                throw new ArgumentException("Element copy type differs from the static array element type.");
            if (clone == null)
                throw new ArgumentNullException(nameof(clone));
            if (assign == null)
                throw new ArgumentNullException(nameof(assign));
            return new DelphiStaticArrayInfo(ElementType, ElementSize,
                FLowerBounds, FLengths,
                value => clone((TElement)value!)!,
                (value, destination) => assign((TElement)value!, (TElement)destination!)!,
                create == null ? null : () => create()!);
        }

        /// <summary>
        /// Makes a Delphi value-copy of an element for normal (non-var)
        /// assignments or parameter passing. This does not change the original.
        /// </summary>
        public TElement CloneElement<TElement>(TElement value)
        {
            if (typeof(TElement) != ElementType)
                throw new ArgumentException("The requested element type does not match the array layout.");
            return (TElement)CloneElementValue(value)!;
        }

        internal object? CloneElementValue(object? value) =>
            FCloneElement == null ? value : FCloneElement(value);

        internal object? AssignElementValue(object? source, object? target) =>
            FAssignElement == null ? source : FAssignElement(source, target);

        public Type ElementType { get; }
        public int ElementSize { get; }
        public int Rank => FLengths.Length;
        public int ElementCount { get; }
        public int ByteSize { get; }
        public int[] LowerBounds => (int[])FLowerBounds.Clone();
        public int[] Lengths => (int[])FLengths.Clone();

        /// <summary>
        /// Equality of the memory layout and its VALUE-copy rules for the
        /// purpose of reusing a location backing. A descriptor with custom
        /// callbacks must be reused as the SAME descriptor instance: two
        /// separately constructed callback sets may behave differently.
        /// </summary>
        internal bool IsCompatibleLocationLayout(DelphiStaticArrayInfo other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (other == null || ElementType != other.ElementType ||
                ElementSize != other.ElementSize || Rank != other.Rank ||
                FCloneElement != null || other.FCloneElement != null ||
                FAssignElement != null || other.FAssignElement != null ||
                FCreateElement != null || other.FCreateElement != null)
                return false;
            for (int i = 0; i < Rank; ++i)
                if (FLowerBounds[i] != other.FLowerBounds[i] ||
                    FLengths[i] != other.FLengths[i])
                    return false;
            return true;
        }

        internal void ValidateArray(Array array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Rank != Rank || array.GetType().GetElementType() != ElementType)
                throw new ArgumentException("The CLR array type does not match the Delphi array layout.");
            for (int i = 0; i < Rank; ++i)
            {
                // Generated CLR arrays use zero-based indices. Delphi bounds
                // are kept in the descriptor for the converter's index shift.
                if (array.GetLowerBound(i) != 0 || array.GetLength(i) != FLengths[i])
                    throw new ArgumentException("The CLR array shape does not match the Delphi array layout.");
            }
        }

        /// <summary>
        /// Returns the byte position of an element using ZERO-BASED CLR indices.
        /// The converter must translate Delphi bounds before calling this method.
        /// The last dimension varies fastest, as in a normal rectangular array.
        /// </summary>
        public int GetElementByteOffset(params int[] zeroBasedIndices)
        {
            if (zeroBasedIndices == null)
                throw new ArgumentNullException(nameof(zeroBasedIndices));
            if (zeroBasedIndices.Length != Rank)
                throw new ArgumentException("Wrong number of array indices.", nameof(zeroBasedIndices));

            int linearIndex = 0;
            for (int dimension = 0; dimension < Rank; dimension++)
            {
                int index = zeroBasedIndices[dimension];
                if (index < 0 || index >= FLengths[dimension])
                    throw new IndexOutOfRangeException("Static array index is outside its bounds.");
                linearIndex = checked(linearIndex * FLengths[dimension] + index);
            }
            return checked(linearIndex * ElementSize);
        }

        internal int[] IndicesFromByteOffset(nint absoluteOffset)
        {
            if (absoluteOffset < 0 || absoluteOffset >= ByteSize ||
                absoluteOffset % ElementSize != 0)
                throw new IndexOutOfRangeException("Pointer is not aligned to an array element.");

            int linearIndex = checked((int)(absoluteOffset / ElementSize));
            int[] indices = new int[Rank];
            for (int dimension = Rank - 1; dimension >= 0; --dimension)
            {
                indices[dimension] = linearIndex % FLengths[dimension];
                linearIndex /= FLengths[dimension];
            }
            return indices;
        }

        /// <summary>
        /// Copies the complete static array value. With explicitly registered
        /// element semantics, nested static arrays/records are value-copied.
        /// Without such metadata only the CLR elements themselves are copied.
        /// </summary>
        public TArray Clone<TArray>(TArray source) where TArray : class
        {
            if (source is not Array sourceArray)
                throw new ArgumentException("Source must be a static array.", nameof(source));
            ValidateArray(sourceArray);
            Array result = Allocate();
            Copy(sourceArray, result);
            return (TArray)(object)result;
        }

        internal Array Allocate()
        {
            Array result = AllocateEmpty();
            if (FCreateElement != null)
            {
                for (int linearIndex = 0; linearIndex < ElementCount; ++linearIndex)
                    result.SetValue(FCreateElement(), IndicesFromLinearIndex(linearIndex));
            }
            return result;
        }

        private Array AllocateEmpty() => Array.CreateInstance(ElementType, FLengths);

        private int[] IndicesFromLinearIndex(int linearIndex)
        {
            int[] indices = new int[Rank];
            for (int dimension = Rank - 1; dimension >= 0; --dimension)
            {
                indices[dimension] = linearIndex % FLengths[dimension];
                linearIndex /= FLengths[dimension];
            }
            return indices;
        }

        /// <summary>
        /// Assigns the VALUE of a Delphi static array to an existing array.
        /// Preserves the destination's CLR array identity. An explicit element
        /// assign callback can also preserve nested static-array identities.
        /// All sources are snapshotted before the first destination is changed;
        /// exceptions during the assign callbacks may still cause partial writes.
        /// </summary>
        public void Copy(Array source, Array destination)
        {
            ValidateArray(source);
            ValidateArray(destination);
            if (ReferenceEquals(source, destination))
                return;

            if (FCloneElement == null)
            {
                Array.Copy(source, destination, ElementCount);
                return;
            }

            // Snapshot before mutating the destination. Source and destination
            // may have aliases inside their nested values.
            Array snapshot = AllocateEmpty();
            for (int linearIndex = 0; linearIndex < ElementCount; ++linearIndex)
            {
                int[] indices = IndicesFromLinearIndex(linearIndex);
                snapshot.SetValue(CloneElementValue(source.GetValue(indices)), indices);
            }
            for (int linearIndex = 0; linearIndex < ElementCount; ++linearIndex)
            {
                int[] indices = IndicesFromLinearIndex(linearIndex);
                destination.SetValue(AssignElementValue(
                    snapshot.GetValue(indices), destination.GetValue(indices)), indices);
            }
        }
    }

    /// <summary>
    /// Canonicalizes the backing for a *storage location*, not for the CLR
    /// array object currently stored there. Different instance fields with
    /// equal array references are different Delphi addresses. Replacing a
    /// field's array reference does NOT change the field's address.
    ///
    /// Identity is never inferred from arbitrary Func/Action delegates:
    /// compiler-generated closure objects do not identify Delphi variables.
    /// Callers must supply a stable receiver and a member key for fields.
    /// Nested array locations are keyed by parent backing and byte offset.
    /// ConditionalWeakTable ensures the registry does not own receivers.
    /// </summary>
    internal static class StaticArrayLocationRegistry
    {
        private sealed class FieldEntries
        {
            internal readonly Dictionary<string, PointerBacking> Backings =
                new Dictionary<string, PointerBacking>(StringComparer.Ordinal);
        }

        private sealed class OffsetEntries
        {
            internal readonly Dictionary<nint, PointerBacking> Backings =
                new Dictionary<nint, PointerBacking>();
        }

        private static readonly ConditionalWeakTable<object, FieldEntries> FFields =
            new ConditionalWeakTable<object, FieldEntries>();

        private static readonly ConditionalWeakTable<PointerBacking, OffsetEntries> FOffsets =
            new ConditionalWeakTable<PointerBacking, OffsetEntries>();

        private static StaticArrayBacking<TArray> Check<TArray>(
            PointerBacking backing, DelphiStaticArrayInfo info)
        {
            if (backing is not StaticArrayBacking<TArray> typed)
                throw new InvalidOperationException(
                    "The same Delphi location was addressed with different CLR types.");
            if (!typed.Info.IsCompatibleLocationLayout(info))
                throw new InvalidOperationException(
                    "The same Delphi location was addressed with incompatible static array layouts or copy rules.");
            return typed;
        }

        internal static StaticArrayBacking<TArray> ForField<TArray>(
            object receiver, string fieldKey, DelphiStaticArrayInfo info,
            Func<StaticArrayBacking<TArray>> create)
        {
            if (receiver == null)
                throw new ArgumentNullException(nameof(receiver));
            if (string.IsNullOrEmpty(fieldKey))
                throw new ArgumentException("A stable field key is required.", nameof(fieldKey));
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            FieldEntries entries = FFields.GetValue(receiver,
                static _ => new FieldEntries());
            lock (entries)
            {
                if (entries.Backings.TryGetValue(fieldKey, out PointerBacking existing))
                    return Check<TArray>(existing, info);
                StaticArrayBacking<TArray> result = create();
                entries.Backings.Add(fieldKey, result);
                return result;
            }
        }

        internal static StaticArrayBacking<TArray> ForNested<TArray>(
            PointerBacking parent, nint byteOffset, DelphiStaticArrayInfo info,
            Func<StaticArrayBacking<TArray>> create)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            OffsetEntries entries = FOffsets.GetValue(parent,
                static _ => new OffsetEntries());
            lock (entries)
            {
                if (entries.Backings.TryGetValue(byteOffset, out PointerBacking existing))
                    return Check<TArray>(existing, info);
                StaticArrayBacking<TArray> result = create();
                entries.Backings.Add(byteOffset, result);
                return result;
            }
        }
    }

    /// <summary>
    /// A typed backing for a *complete* static array value. The array is a
    /// CLR object, but assignments to the Delphi static array copy its CONTENTS.
    /// Borrowed locations are never eligible for FreeMem.
    /// </summary>
    internal sealed class StaticArrayBacking<TArray> : PointerBacking
    {
        private readonly Ref<TArray> FLocation;
        private readonly DelphiStaticArrayInfo FInfo;
        private readonly bool FOwned;
        private int FFreed;

        internal StaticArrayBacking(Ref<TArray> location,
            DelphiStaticArrayInfo info, bool owned)
        {
            FLocation = location ?? throw new ArgumentNullException(nameof(location));
            FInfo = info ?? throw new ArgumentNullException(nameof(info));
            if (!typeof(TArray).IsArray ||
                typeof(TArray).GetElementType() != info.ElementType ||
                typeof(TArray).GetArrayRank() != info.Rank)
                throw new ArgumentException("The pointer's array type does not match its layout.", nameof(info));
            FOwned = owned;
            // Validate immediately, not only at first dereference.
            GetArray();
        }

        internal DelphiStaticArrayInfo Info => FInfo;
        internal override nint ByteLength => FInfo.ByteSize;
        internal override bool IsAlive => Volatile.Read(ref FFreed) == 0;
        internal override bool CanFree => FOwned && IsAlive;
        internal override int ValueSize<T>() => typeof(T) == typeof(TArray)
            ? FInfo.ByteSize
            : typeof(T) == FInfo.ElementType
                ? FInfo.ElementSize
                : DelphiTypeLayout.SizeOf<T>();

        private Array GetArray()
        {
            if (!IsAlive)
                throw new ObjectDisposedException("Static array backing");
            TArray value = FLocation.Value;
            if (value is not Array array)
                throw new InvalidOperationException("The addressed static array is null.");
            FInfo.ValidateArray(array);
            return array;
        }

        internal override bool TryReadValue<T>(nint absoluteOffset, out T value)
        {
            if (absoluteOffset == 0 && typeof(T) == typeof(TArray))
            {
                value = (T)(object)GetArray();
                return true;
            }
            if (typeof(T) == FInfo.ElementType &&
                absoluteOffset >= 0 && absoluteOffset < FInfo.ByteSize &&
                absoluteOffset % FInfo.ElementSize == 0)
            {
                object? element = GetArray().GetValue(
                    FInfo.IndicesFromByteOffset(absoluteOffset));
                value = element is null ? default! : (T)element;
                return true;
            }
            value = default!;
            return false;
        }

        internal override bool TryWriteValue<T>(nint absoluteOffset, T value)
        {
            if (absoluteOffset == 0 && typeof(T) == typeof(TArray))
            {
                if (value is not Array source)
                    throw new ArgumentNullException(nameof(value));
                FInfo.Copy(source, GetArray());
                return true;
            }
            if (typeof(T) == FInfo.ElementType &&
                absoluteOffset >= 0 && absoluteOffset < FInfo.ByteSize &&
                absoluteOffset % FInfo.ElementSize == 0)
            {
                Array array = GetArray();
                int[] indices = FInfo.IndicesFromByteOffset(absoluteOffset);
                array.SetValue(FInfo.AssignElementValue(value, array.GetValue(indices)), indices);
                return true;
            }
            return false;
        }

        internal override byte ReadByte(nint absoluteOffset)
        {
            ValidateRange(absoluteOffset, 1);
            Array array = GetArray();
            if (!FInfo.ElementType.IsPrimitive ||
                FInfo.ElementSize != DelphiTypeLayout.SizeOf(FInfo.ElementType))
                throw new NotSupportedException("Byte access requires a primitive array with native element layout.");
            return Buffer.GetByte(array, checked((int)absoluteOffset));
        }

        internal override void WriteByte(nint absoluteOffset, byte value)
        {
            ValidateRange(absoluteOffset, 1);
            Array array = GetArray();
            if (!FInfo.ElementType.IsPrimitive ||
                FInfo.ElementSize != DelphiTypeLayout.SizeOf(FInfo.ElementType))
                throw new NotSupportedException("Byte access requires a primitive array with native element layout.");
            Buffer.SetByte(array, checked((int)absoluteOffset), value);
        }

        internal override PointerPin Pin(nint absoluteOffset)
        {
            throw new NotSupportedException("Pinning static array locations is not implemented. No stable native address can be guaranteed.");
        }

        internal override IntPtr GetPersistentAddress(nint absoluteOffset)
        {
            throw new NotSupportedException("Static array locations do not expose a persistent native address.");
        }

        internal override void Free()
        {
            if (!FOwned)
                throw new InvalidOperationException("Cannot free a borrowed Delphi static array location.");
            Volatile.Write(ref FFreed, 1);
        }
    }
}
