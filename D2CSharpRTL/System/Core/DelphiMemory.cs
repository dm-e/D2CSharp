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
using System.Runtime.InteropServices;

namespace System
{
    public static partial class DelphiMemory
    {
        public static void Move(
            UntypedPointer source,
            UntypedPointer destination,
            nint count)
        {
            if (count <= 0)
                return;

            if (count > int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (source.IsNull())
                throw new NullReferenceException("Source pointer is null.");
            if (destination.IsNull())
                throw new NullReferenceException("Destination pointer is null.");

            source.View.ValidateRelativeRange(0, count);
            destination.View.ValidateRelativeRange(0, count);

            if (destination.IsReadOnly)
                throw new InvalidOperationException("Destination pointer is read-only.");

            int byteCount = checked((int)count);

            if (TryGetCopyDirection(
                source,
                destination,
                byteCount,
                out bool copyBackward))
            {
                if (copyBackward)
                {
                    for (int i = byteCount - 1; i >= 0; i--)
                        destination.Assign(source[i], i);
                }
                else
                {
                    for (int i = 0; i < byteCount; i++)
                        destination.Assign(source[i], i);
                }

                return;
            }

            byte[] temporary = new byte[byteCount];

            for (int i = 0; i < byteCount; i++)
                temporary[i] = source[i];

            for (int i = 0; i < byteCount; i++)
                destination.Assign(temporary[i], i);
        }

        public static void Move(
            UntypedPointer source,
            UntypedPointer destination,
            int count)
        {
            Move(source, destination, (nint)count);
        }

        public static void Move(
            UntypedPointer source,
            UntypedPointer destination,
            uint count)
        {
            Move(source, destination, checked((nint)count));
        }

        public static void Move(
            Pointer source,
            UntypedPointer destination,
            nint count)
        {
            Move(source.ToUntypedPointer(), destination, count);
        }

        public static void Move(
            Pointer source,
            UntypedPointer destination,
            int count)
        {
            Move(source, destination, (nint)count);
        }

        public static void Move(
            Pointer source,
            UntypedPointer destination,
            uint count)
        {
            Move(source, destination, checked((nint)count));
        }

        public static void Move(
            Pointer source,
            Pointer destination,
            nint count)
        {
            Move(
                source.ToUntypedPointer(),
                destination.ToUntypedPointer(),
                count);
        }

        public static void Move<TSource, TDestination>(
            Pointer<TSource> source,
            Pointer<TDestination> destination,
            nint count)
        {
            Move(
                source.ToUntypedPointer(),
                destination.ToUntypedPointer(),
                count);
        }

        public static void Move(
            PChar source,
            int from,
            ref PChar destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;

            ValidateCharacterOffset(from, nameof(from));
            ValidateCharacterOffset(to, nameof(to));

            Move(
                source.ToUntypedPointer() + checked(from * sizeof(char)),
                destination.ToUntypedPointer() + checked(to * sizeof(char)),
                copyCount);
        }

        public static void Move(
            PChar source,
            int from,
            ref PChar destination,
            uint copyCount)
        {
            if (copyCount == 0)
                return;

            Move(
                source,
                from,
                ref destination,
                0,
                checked((int)copyCount));
        }

        public static void Move(
            char[]? source,
            int from,
            ref string destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source == null)
                throw new NullReferenceException("Source array is null.");
            if (destination == null)
                throw new NullReferenceException("Destination string is null.");

            ValidateCharacterOffset(from, nameof(from));
            ValidateCharacterOffset(to, nameof(to));
            ValidateByteRange(source.Length, from, copyCount, nameof(from));
            ValidateByteRange(destination.Length, to, copyCount, nameof(to));

            char[] destinationBuffer = destination.ToCharArray();

            Move(
                new UntypedPointer(source, from),
                new UntypedPointer(destinationBuffer, to),
                copyCount);

            destination = new string(destinationBuffer);
        }

#if USEDYNAMICARRAY
        public static void Move(
            string? source,
            int from,
            ref char[] destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source == null)
                throw new NullReferenceException("Source string is null.");
            if (destination == null)
                throw new NullReferenceException("Destination array is null.");

            ValidateCharacterOffset(from, nameof(from));
            ValidateCharacterOffset(to, nameof(to));
            ValidateByteRange(source.Length, from, copyCount, nameof(from));
            ValidateByteRange(destination.Length, to, copyCount, nameof(to));

            Move(
                UntypedPointer.FromStringView(source, from),
                new UntypedPointer(destination, to),
                copyCount);
        }

        public static void Move(
            string? source,
            int from,
            ref DynamicArray<char> destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source == null)
                throw new NullReferenceException("Source string is null.");
            if (destination.IsNil)
            {
                throw new NullReferenceException(
                    "Destination dynamic array is nil. Call SetLength before Move.");
            }

            ValidateCharacterOffset(from, nameof(from));
            ValidateCharacterOffset(to, nameof(to));
            ValidateByteRange(source.Length, from, copyCount, nameof(from));
            ValidateByteRange(destination.Length, to, copyCount, nameof(to));

            Move(
                UntypedPointer.FromStringView(source, from),
                new UntypedPointer(destination, to),
                copyCount);
        }

        public static void Move(
            string? source,
            int from,
            ref DynamicArray<char>? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (!destination.HasValue)
            {
                throw new NullReferenceException(
                    "Destination dynamic array is nil. Call SetLength before Move.");
            }

            DynamicArray<char> value = destination.Value;
            Move(source, from, ref value, to, copyCount);
            destination = value;
        }
#else

        /// <summary>
        /// Delphi-compatible Move overload for copying bytes from a UTF-16 string
        /// into a dynamic Char array.
        ///
        /// from and to are character indexes.
        /// copyCount is a byte count.
        /// </summary>
        public static void Move(
            string? source,
            int from,
            ref char[]? destination,
            int to,
            int copyCount)
        {
            // Delphi Move with Count <= 0 performs no copy.
            if (copyCount <= 0)
                return;

            if (source is null)
                throw new NullReferenceException("Source string is nil.");

            if (destination is null)
            {
                throw new NullReferenceException(
                    "Destination dynamic array is nil. Call SetLength before Move.");
            }

            ValidateCharacterOffset(source.Length, from, nameof(from));
            ValidateCharacterOffset(destination.Length, to, nameof(to));

            ValidateByteRange(
                source.Length,
                from,
                copyCount,
                nameof(source));

            ValidateByteRange(
                destination.Length,
                to,
                copyCount,
                nameof(destination));

            ReadOnlySpan<byte> sourceBytes =
                MemoryMarshal.AsBytes(source.AsSpan(from));

            Span<byte> destinationBytes =
                MemoryMarshal.AsBytes(destination.AsSpan(to));

            // Span.CopyTo has memmove semantics for overlapping regions.
            sourceBytes[..copyCount].CopyTo(destinationBytes);
        }

        private static void ValidateCharacterOffset(
            int characterLength,
            int offset,
            string parameterName)
        {
            if ((uint)offset > (uint)characterLength)
            {
                throw new ArgumentOutOfRangeException(
                    parameterName,
                    offset,
                    "Character offset is outside the valid range.");
            }
        }

        private static void ValidateByteRange(
            int characterLength,
            int characterOffset,
            int byteCount,
            string parameterName)
        {
            long availableByteCount =
                (long)(characterLength - characterOffset) * sizeof(char);

            if (byteCount > availableByteCount)
            {
                throw new ArgumentOutOfRangeException(
                    parameterName,
                    $"Cannot copy {byteCount} bytes; only " +
                    $"{availableByteCount} bytes are available.");
            }
        }


#endif

    public static void Move(
            string? source,
            int from,
            ref string destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source == null)
                throw new NullReferenceException("Source string is null.");
            if (destination == null)
                throw new NullReferenceException("Destination string is null.");

            ValidateCharacterOffset(from, nameof(from));
            ValidateCharacterOffset(to, nameof(to));
            ValidateByteRange(source.Length, from, copyCount, nameof(from));
            ValidateByteRange(destination.Length, to, copyCount, nameof(to));

            char[] destinationBuffer = destination.ToCharArray();

            Move(
                UntypedPointer.FromStringView(source, from),
                new UntypedPointer(destinationBuffer, to),
                copyCount);

            destination = new string(destinationBuffer);
        }

        public static Pointer GetMem(int size)
        {
            return new Pointer(size);
        }

        public static Pointer AllocMem(int size)
        {
            Pointer result = new Pointer(size);

            for (int i = 0; i < size; i++)
                result.Assign(0, i);

            return result;
        }

        public static void FreeMem(ref Pointer pointer)
        {
            pointer.FreeMemory();
            pointer = default;
        }

        public static void FreeMem(ref UntypedPointer pointer)
        {
            pointer.FreeMemory();
            pointer = default;
        }

        public static void FreeMem<T>(ref Pointer<T> pointer)
        {
            pointer.FreeMemory();
            pointer = default;
        }

        public static void FreeMem(ref PChar pointer)
        {
            pointer.FreeMemory();
            pointer = default;
        }

        private static bool TryGetCopyDirection(
            UntypedPointer source,
            UntypedPointer destination,
            int count,
            out bool copyBackward)
        {
            copyBackward = false;

            if (ReferenceEquals(
                source.BackingIdentity,
                destination.BackingIdentity))
            {
                nint sourceStart = source.AbsoluteByteOffset;
                nint destinationStart = destination.AbsoluteByteOffset;
                nint sourceEnd = checked(sourceStart + count);
                nint destinationEnd = checked(destinationStart + count);
                bool overlaps =
                    sourceStart < destinationEnd &&
                    destinationStart < sourceEnd;

                copyBackward = overlaps && destinationStart > sourceStart;
                return true;
            }

            try
            {
                using PointerPin sourcePin = source.Pin();
                using PointerPin destinationPin = destination.Pin();
                long sourceStart = sourcePin.Address.ToInt64();
                long destinationStart = destinationPin.Address.ToInt64();
                long sourceEnd = checked(sourceStart + count);
                long destinationEnd = checked(destinationStart + count);
                bool overlaps =
                    sourceStart < destinationEnd &&
                    destinationStart < sourceEnd;

                copyBackward = overlaps && destinationStart > sourceStart;
                return true;
            }
            catch (Exception exception) when (
                exception is InvalidOperationException ||
                exception is NotSupportedException ||
                exception is ArgumentException)
            {
                return false;
            }
        }

        private static void ValidateCharacterOffset(
            int offset,
            string parameterName)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException(parameterName);
        }

        //private static void ValidateByteRange(
        //    int charLength,
        //    int charOffset,
        //    int byteCount,
        //    string parameterName)
        //{
        //    if (byteCount < 0)
        //        throw new ArgumentOutOfRangeException(nameof(byteCount));

        //    long byteOffset = checked((long)charOffset * sizeof(char));
        //    long byteLength = checked((long)charLength * sizeof(char));
        //    long end = checked(byteOffset + byteCount);

        //    if (end > byteLength)
        //        throw new ArgumentOutOfRangeException(parameterName);
        //}
    }

    public sealed class Utf16StringBuffer : IDisposable
    {
        private char[]? FBuffer;

        public Utf16StringBuffer(string? value, int capacity = -1)
        {
            value ??= string.Empty;

            if (capacity < -1)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            int required = checked(value.Length + 1);
            int actualCapacity = capacity < 0
                ? required
                : Math.Max(capacity, required);

            FBuffer = new char[actualCapacity];
            value.CopyTo(0, FBuffer, 0, value.Length);
            FBuffer[value.Length] = '\0';
        }

        public int Capacity => FBuffer?.Length ?? 0;

        public PChar Pointer
        {
            get
            {
                if (FBuffer == null)
                    throw new ObjectDisposedException(nameof(Utf16StringBuffer));

                return new PChar(FBuffer);
            }
        }

        public UntypedPointer GetPointer(int charIndex = 0)
        {
            if (FBuffer == null)
                throw new ObjectDisposedException(
                    nameof(Utf16StringBuffer));

            if (charIndex < 0 || charIndex > FBuffer.Length)
                throw new ArgumentOutOfRangeException(
                    nameof(charIndex));

            return new UntypedPointer(FBuffer, charIndex);
        }
        public string Commit()
        {
            if (FBuffer == null)
                throw new ObjectDisposedException(nameof(Utf16StringBuffer));

            int length = 0;

            while (length < FBuffer.Length && FBuffer[length] != '\0')
                length++;

            return new string(FBuffer, 0, length);
        }

        public void Dispose()
        {
            FBuffer = null;
        }
    }
}
