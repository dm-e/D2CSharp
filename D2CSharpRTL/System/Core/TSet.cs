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
using System.Collections;
using System.Collections.Generic;

namespace System
{
    

    /// <summary>
    /// Represents a Delphi-compatible set with ordinal values from 0 to 255.
    /// The logical Delphi storage size is 32 bytes.
    /// </summary>
    public sealed class TSet :
        IEnumerable<int>,
        IEnumerable,
        IEquatable<TSet>,
        ICloneable
    {
        public const int MinValue = 0;
        public const int MaxValue = 255;
        public const int Capacity = MaxValue - MinValue + 1;
        public const int BitsPerWord = 32;
        public const int WordCount = Capacity / BitsPerWord;

        // Delphi: set of Byte occupies 256 bits = 32 bytes.
        public const int DelphiSizeOf = 32;

        private readonly uint[] bits;
        private int version;

        public TSet()
        {
            bits = new uint[WordCount];
        }

        public TSet(TSet OtherSet)
        {
            if (OtherSet == null)
            {
                throw new ArgumentNullException(nameof(OtherSet));
            }

            bits = new uint[WordCount];
            Array.Copy(OtherSet.bits, bits, WordCount);
        }

        public TSet(params int[] Values)
            : this()
        {
            if (Values == null)
            {
                throw new ArgumentNullException(nameof(Values));
            }

            Include(Values);
        }

        public bool this[int Index]
        {
            get
            {
                return Contains(Index);
            }
            set
            {
                if (value)
                {
                    Include(Index);
                }
                else
                {
                    Exclude(Index);
                }
            }
        }

        public int Count
        {
            get
            {
                int Result = 0;

                for (int i = 0; i < WordCount; ++i)
                {
                    Result += CountBits(bits[i]);
                }

                return Result;
            }
        }

        public bool IsEmpty
        {
            get
            {
                for (int i = 0; i < WordCount; ++i)
                {
                    if (bits[i] != 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        internal int Version
        {
            get
            {
                return version;
            }
        }

        public TSet Clear()
        {
            bool Changed = false;

            for (int i = 0; i < WordCount; ++i)
            {
                if (bits[i] != 0)
                {
                    bits[i] = 0;
                    Changed = true;
                }
            }

            if (Changed)
            {
                ++version;
            }

            return this;
        }

        public void Include(int Index)
        {
            if (!IsValidIndex(Index))
            {
                return;
            }

            int WordIndex = Index >> 5;
            uint Mask = 1u << (Index & 31);
            uint OldValue = bits[WordIndex];
            uint NewValue = OldValue | Mask;

            if (NewValue != OldValue)
            {
                bits[WordIndex] = NewValue;
                ++version;
            }
        }

        public void Include(params int[] Values)
        {
            if (Values == null)
            {
                throw new ArgumentNullException(nameof(Values));
            }

            for (int i = 0; i < Values.Length; ++i)
            {
                Include(Values[i]);
            }
        }

        public void IncludeRange(int First, int Last)
        {
            ValidateRange(First, Last);

            for (int i = First; i <= Last; ++i)
            {
                Include(i);
            }
        }

        public static TSet operator <<(TSet ImpliedObject, int Index)
        {
            EnsureNotNull(ImpliedObject, nameof(ImpliedObject));
            ImpliedObject.Include(Index);
            return ImpliedObject;
        }

        public void Exclude(int Index)
        {
            if (!IsValidIndex(Index))
            {
                return;
            }

            int WordIndex = Index >> 5;
            uint Mask = 1u << (Index & 31);
            uint OldValue = bits[WordIndex];
            uint NewValue = OldValue & ~Mask;

            if (NewValue != OldValue)
            {
                bits[WordIndex] = NewValue;
                ++version;
            }
        }

        public void Exclude(params int[] Values)
        {
            if (Values == null)
            {
                throw new ArgumentNullException(nameof(Values));
            }

            for (int i = 0; i < Values.Length; ++i)
            {
                Exclude(Values[i]);
            }
        }

        public void ExcludeRange(int First, int Last)
        {
            ValidateRange(First, Last);

            for (int i = First; i <= Last; ++i)
            {
                Exclude(i);
            }
        }

        public static TSet operator >>(TSet ImpliedObject, int Index)
        {
            EnsureNotNull(ImpliedObject, nameof(ImpliedObject));
            ImpliedObject.Exclude(Index);
            return ImpliedObject;
        }

        public bool Empty()
        {
            return IsEmpty;
        }

        public bool Contains(int Index)
        {
            if (!IsValidIndex(Index))
            {
                return false;
            }

            uint Mask = 1u << (Index & 31);
            return (bits[Index >> 5] & Mask) != 0;
        }

        public void UnionWith(TSet OtherSet)
        {
            EnsureNotNull(OtherSet, nameof(OtherSet));

            bool Changed = false;

            for (int i = 0; i < WordCount; ++i)
            {
                uint NewValue = bits[i] | OtherSet.bits[i];

                if (NewValue != bits[i])
                {
                    bits[i] = NewValue;
                    Changed = true;
                }
            }

            if (Changed)
            {
                ++version;
            }
        }

        public void ExceptWith(TSet OtherSet)
        {
            EnsureNotNull(OtherSet, nameof(OtherSet));

            bool Changed = false;

            for (int i = 0; i < WordCount; ++i)
            {
                uint NewValue = bits[i] & ~OtherSet.bits[i];

                if (NewValue != bits[i])
                {
                    bits[i] = NewValue;
                    Changed = true;
                }
            }

            if (Changed)
            {
                ++version;
            }
        }

        public void IntersectWith(TSet OtherSet)
        {
            EnsureNotNull(OtherSet, nameof(OtherSet));

            bool Changed = false;

            for (int i = 0; i < WordCount; ++i)
            {
                uint NewValue = bits[i] & OtherSet.bits[i];

                if (NewValue != bits[i])
                {
                    bits[i] = NewValue;
                    Changed = true;
                }
            }

            if (Changed)
            {
                ++version;
            }
        }

        public bool IsSubsetOf(TSet OtherSet)
        {
            EnsureNotNull(OtherSet, nameof(OtherSet));

            for (int i = 0; i < WordCount; ++i)
            {
                if ((bits[i] & ~OtherSet.bits[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsSupersetOf(TSet OtherSet)
        {
            EnsureNotNull(OtherSet, nameof(OtherSet));
            return OtherSet.IsSubsetOf(this);
        }

        public bool Overlaps(TSet OtherSet)
        {
            EnsureNotNull(OtherSet, nameof(OtherSet));

            for (int i = 0; i < WordCount; ++i)
            {
                if ((bits[i] & OtherSet.bits[i]) != 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool SetEquals(TSet OtherSet)
        {
            return Equals(OtherSet);
        }

        public static TSet operator +(TSet ImpliedObject, TSet AddSet)
        {
            EnsureNotNull(ImpliedObject, nameof(ImpliedObject));
            EnsureNotNull(AddSet, nameof(AddSet));

            TSet NewSet = new TSet(ImpliedObject);
            NewSet.UnionWith(AddSet);
            return NewSet;
        }

        public static TSet operator -(TSet ImpliedObject, TSet SubSet)
        {
            EnsureNotNull(ImpliedObject, nameof(ImpliedObject));
            EnsureNotNull(SubSet, nameof(SubSet));

            TSet NewSet = new TSet(ImpliedObject);
            NewSet.ExceptWith(SubSet);
            return NewSet;
        }

        public static TSet operator *(TSet ImpliedObject, TSet MulSet)
        {
            EnsureNotNull(ImpliedObject, nameof(ImpliedObject));
            EnsureNotNull(MulSet, nameof(MulSet));

            TSet NewSet = new TSet(ImpliedObject);
            NewSet.IntersectWith(MulSet);
            return NewSet;
        }

        public static bool operator ==(TSet Left, TSet Right)
        {
            if (ReferenceEquals(Left, Right))
            {
                return true;
            }

            if (ReferenceEquals(Left, null) ||
                ReferenceEquals(Right, null))
            {
                return false;
            }

            return Left.Equals(Right);
        }

        public static bool operator !=(TSet Left, TSet Right)
        {
            return !(Left == Right);
        }

        public static bool operator <=(TSet ImpliedObject, TSet CmpSet)
        {
            EnsureNotNull(ImpliedObject, nameof(ImpliedObject));
            EnsureNotNull(CmpSet, nameof(CmpSet));
            return ImpliedObject.IsSubsetOf(CmpSet);
        }

        public static bool operator >=(TSet ImpliedObject, TSet CmpSet)
        {
            EnsureNotNull(ImpliedObject, nameof(ImpliedObject));
            EnsureNotNull(CmpSet, nameof(CmpSet));
            return ImpliedObject.IsSupersetOf(CmpSet);
        }

        public bool Equals(TSet Other)
        {
            if (ReferenceEquals(Other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, Other))
            {
                return true;
            }

            for (int i = 0; i < WordCount; ++i)
            {
                if (bits[i] != Other.bits[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object Other)
        {
            TSet OtherSet = Other as TSet;
            return OtherSet != null && Equals(OtherSet);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int Result = 17;

                for (int i = 0; i < WordCount; ++i)
                {
                    Result = Result * 31 + bits[i].GetHashCode();
                }

                return Result;
            }
        }

        public object Clone()
        {
            return new TSet(this);
        }

        public TSet Copy()
        {
            return new TSet(this);
        }

        public int[] ToArray()
        {
            int[] Result = new int[Count];
            int Position = 0;

            foreach (int Value in this)
            {
                Result[Position++] = Value;
            }

            return Result;
        }

        public void CopyTo(int[] Array, int ArrayIndex)
        {
            if (Array == null)
            {
                throw new ArgumentNullException(nameof(Array));
            }

            if (ArrayIndex < 0 || ArrayIndex > Array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(ArrayIndex));
            }

            if (Array.Length - ArrayIndex < Count)
            {
                throw new ArgumentException(
                    "The destination array is too small.",
                    nameof(Array));
            }

            foreach (int Value in this)
            {
                Array[ArrayIndex++] = Value;
            }
        }

        public TSetEnum GetEnumerator()
        {
            return new TSetEnum(this);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal static bool IsValidIndex(int Index)
        {
            return Index >= MinValue && Index <= MaxValue;
        }

        private static int CountBits(uint Value)
        {
            int Result = 0;

            while (Value != 0)
            {
                Value &= Value - 1;
                ++Result;
            }

            return Result;
        }

        private static void ValidateRange(int First, int Last)
        {
            if (!IsValidIndex(First))
            {
                throw new ArgumentOutOfRangeException(nameof(First));
            }

            if (!IsValidIndex(Last))
            {
                throw new ArgumentOutOfRangeException(nameof(Last));
            }

            if (First > Last)
            {
                throw new ArgumentException(
                    "The first value must not be greater than the last value.");
            }
        }

        private static void EnsureNotNull(TSet Value, string ParameterName)
        {
            if (ReferenceEquals(Value, null))
            {
                throw new ArgumentNullException(ParameterName);
            }
        }
    }

    public sealed class TSetEnum : IEnumerator<int>, IEnumerator
    {
        private readonly TSet set;
        private readonly int version;
        private int position;

        public TSetEnum(TSet Set)
        {
            if (Set == null)
            {
                throw new ArgumentNullException(nameof(Set));
            }

            set = Set;
            version = Set.Version;
            position = TSet.MinValue - 1;
        }

        public int Current
        {
            get
            {
                CheckVersion();

                if (!TSet.IsValidIndex(position) ||
                    !set.Contains(position))
                {
                    throw new InvalidOperationException(
                        "The enumerator is not positioned on a set element.");
                }

                return position;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            CheckVersion();

            int FirstCandidate = position + 1;

            if (FirstCandidate < TSet.MinValue)
            {
                FirstCandidate = TSet.MinValue;
            }

            for (int i = FirstCandidate; i <= TSet.MaxValue; ++i)
            {
                if (set.Contains(i))
                {
                    position = i;
                    return true;
                }
            }

            position = TSet.MaxValue + 1;
            return false;
        }

        public void Reset()
        {
            CheckVersion();
            position = TSet.MinValue - 1;
        }

        public void Dispose()
        {
        }

        private void CheckVersion()
        {
            if (version != set.Version)
            {
                throw new InvalidOperationException(
                    "The set was modified during enumeration.");
            }
        }
    }
}
