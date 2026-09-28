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
    public static partial class DelphiMemory
    {
        public static void Move(
            AnsiString? source,
            int from,
            ref byte[]? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (destination is null)
                throw new NullReferenceException(
                    "Destination dynamic array is nil. Call SetLength before Move.");

            AnsiString actualSource = AnsiString.Normalize(source);
            ValidateAnsiByteRange(actualSource.Length, from, copyCount, nameof(from));
            ValidateAnsiByteRange(destination.Length, to, copyCount, nameof(to));
            actualSource.AsSpan().Slice(from, copyCount)
                .CopyTo(destination.AsSpan(to, copyCount));
        }

        public static void Move(
            byte[]? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source is null)
                throw new NullReferenceException("Source array is nil.");

            AnsiString actualDestination = AnsiString.Normalize(destination);
            ValidateAnsiByteRange(source.Length, from, copyCount, nameof(from));
            ValidateAnsiByteRange(actualDestination.Length, to, copyCount, nameof(to));
            destination = actualDestination.WithMovedBytes(
                source.AsSpan(from, copyCount),
                to);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;

            AnsiString actualSource = AnsiString.Normalize(source);
            AnsiString actualDestination = AnsiString.Normalize(destination);
            ValidateAnsiByteRange(actualSource.Length, from, copyCount, nameof(from));
            ValidateAnsiByteRange(actualDestination.Length, to, copyCount, nameof(to));

            // Materializing the source slice gives memmove behavior even when
            // source and destination reference the same AnsiString instance.
            byte[] temporary = actualSource.AsSpan()
                .Slice(from, copyCount)
                .ToArray();
            destination = actualDestination.WithMovedBytes(temporary, to);
        }

        /// <summary>
        /// Copies ANSI bytes into the byte representation of a UTF-16 string.
        /// Source offsets are bytes, destination offsets are UTF-16 code units,
        /// and copyCount is always bytes, as in Delphi Move.
        /// </summary>
        public static void Move(
            AnsiString? source,
            int from,
            ref string destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;

            AnsiString actualSource = AnsiString.Normalize(source);
            destination ??= string.Empty;
            ValidateAnsiByteRange(actualSource.Length, from, copyCount, nameof(from));
            ValidateAnsiUtf16ByteRange(destination.Length, to, copyCount, nameof(to));

            byte[] destinationBytes = GetLittleEndianUtf16Bytes(destination);
            actualSource.AsSpan().Slice(from, copyCount).CopyTo(
                destinationBytes.AsSpan(checked(to * sizeof(char)), copyCount));
            destination = FromLittleEndianUtf16Bytes(destinationBytes);
        }

        public static void Move(
            byte[]? source,
            int from,
            ref string destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source is null)
                throw new NullReferenceException("Source array is nil.");

            destination ??= string.Empty;
            ValidateAnsiByteRange(source.Length, from, copyCount, nameof(from));
            ValidateAnsiUtf16ByteRange(destination.Length, to, copyCount, nameof(to));

            byte[] destinationBytes = GetLittleEndianUtf16Bytes(destination);
            source.AsSpan(from, copyCount).CopyTo(
                destinationBytes.AsSpan(checked(to * sizeof(char)), copyCount));
            destination = FromLittleEndianUtf16Bytes(destinationBytes);
        }

        /// <summary>
        /// Copies raw little-endian UTF-16 bytes into an AnsiString without
        /// applying a character encoding conversion.
        /// </summary>
        public static void Move(
            string? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source is null)
                throw new NullReferenceException("Source string is nil.");

            AnsiString actualDestination = AnsiString.Normalize(destination);
            ValidateAnsiUtf16ByteRange(source.Length, from, copyCount, nameof(from));
            ValidateAnsiByteRange(actualDestination.Length, to, copyCount, nameof(to));

            byte[] sourceBytes = GetLittleEndianUtf16Bytes(source);
            destination = actualDestination.WithMovedBytes(
                sourceBytes.AsSpan(checked(from * sizeof(char)), copyCount),
                to);
        }

        public static void Move(
            PAnsiChar source,
            int from,
            ref PAnsiChar destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source.IsNull())
                throw new NullReferenceException("Source pointer is null.");
            if (destination.IsNull())
                throw new NullReferenceException("Destination pointer is null.");

            Move(
                source.ToUntypedPointer() + from,
                destination.ToUntypedPointer() + to,
                copyCount);
        }

        public static void Move(
            PAnsiChar source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source.IsNull())
                throw new NullReferenceException("Source pointer is null.");
            if (from < 0 || from > source.Capacity - copyCount)
                throw new ArgumentOutOfRangeException(nameof(from));

            byte[] temporary = new byte[copyCount];
            for (int index = 0; index < copyCount; index++)
                temporary[index] = source[from + index];
            Move(temporary, 0, ref destination, to, copyCount);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref PAnsiChar destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (destination.IsNull())
                throw new NullReferenceException("Destination pointer is null.");

            AnsiString actualSource = AnsiString.Normalize(source);
            ValidateAnsiByteRange(actualSource.Length, from, copyCount, nameof(from));
            if (to < 0 || to > destination.Capacity - copyCount)
                throw new ArgumentOutOfRangeException(nameof(to));

            for (int index = 0; index < copyCount; index++)
                destination[to + index] = actualSource[from + index];
        }

        public static void FreeMem(ref PAnsiChar pointer)
        {
            pointer.FreeMemory();
            pointer = default;
        }

        private static void ValidateAnsiByteRange(
            int length,
            int offset,
            int byteCount,
            string parameterName)
        {
            if (offset < 0 || offset > length || byteCount > length - offset)
                throw new ArgumentOutOfRangeException(parameterName);
        }

        private static void ValidateAnsiUtf16ByteRange(
            int characterLength,
            int characterOffset,
            int byteCount,
            string parameterName)
        {
            if (characterOffset < 0 || characterOffset > characterLength)
                throw new ArgumentOutOfRangeException(parameterName);

            long available = checked(
                (long)(characterLength - characterOffset) * sizeof(char));
            if (byteCount > available)
                throw new ArgumentOutOfRangeException(parameterName);
        }

        private static byte[] GetLittleEndianUtf16Bytes(string value)
        {
            byte[] result = new byte[checked(value.Length * sizeof(char))];
            for (int index = 0; index < value.Length; index++)
            {
                ushort character = value[index];
                result[index * 2] = unchecked((byte)character);
                result[index * 2 + 1] = unchecked((byte)(character >> 8));
            }

            return result;
        }

        private static string FromLittleEndianUtf16Bytes(byte[] bytes)
        {
            if ((bytes.Length & 1) != 0)
                throw new ArgumentException("A UTF-16 buffer must contain whole code units.");

            char[] result = new char[bytes.Length / sizeof(char)];
            for (int index = 0; index < result.Length; index++)
            {
                result[index] = unchecked((char)(
                    bytes[index * 2] |
                    (bytes[index * 2 + 1] << 8)));
            }

            return result.Length == 0 ? string.Empty : new string(result);
        }
    }
}
