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
            ShortString? source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;

            ShortString actualSource = ShortString.Normalize(source);
            ShortString actualDestination = ShortString.Normalize(destination);
            ValidateShortStringRange(actualSource.Length, from, copyCount, nameof(from));
            ValidateShortStringRange(actualDestination.Length, to, copyCount, nameof(to));

            byte[] temporary = actualSource.AsSpan()
                .Slice(from, copyCount)
                .ToArray();
            destination = actualDestination.WithMovedBytes(temporary, to);
        }

        public static void Move(
            ShortString? source,
            int from,
            ref byte[]? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (destination is null)
                throw new NullReferenceException("Destination dynamic array is nil.");

            ShortString actualSource = ShortString.Normalize(source);
            ValidateShortStringRange(actualSource.Length, from, copyCount, nameof(from));
            ValidateShortStringRange(destination.Length, to, copyCount, nameof(to));
            actualSource.AsSpan().Slice(from, copyCount)
                .CopyTo(destination.AsSpan(to, copyCount));
        }

        public static void Move(
            byte[]? source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source is null)
                throw new NullReferenceException("Source array is nil.");

            ShortString actualDestination = ShortString.Normalize(destination);
            ValidateShortStringRange(source.Length, from, copyCount, nameof(from));
            ValidateShortStringRange(actualDestination.Length, to, copyCount, nameof(to));
            destination = actualDestination.WithMovedBytes(
                source.AsSpan(from, copyCount),
                to);
        }

        public static void Move(
            ShortString? source,
            int from,
            ref PAnsiChar destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (destination.IsNull())
                throw new NullReferenceException("Destination pointer is null.");

            ShortString actualSource = ShortString.Normalize(source);
            ValidateShortStringRange(actualSource.Length, from, copyCount, nameof(from));
            if (to < 0 || to > destination.Capacity - copyCount)
                throw new ArgumentOutOfRangeException(nameof(to));

            for (int index = 0; index < copyCount; index++)
                destination[to + index] = actualSource[from + index];
        }

        public static void Move(
            PAnsiChar source,
            int from,
            ref ShortString? destination,
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
            ShortString? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;

            ShortString actualSource = ShortString.Normalize(source);
            AnsiString actualDestination = AnsiString.Normalize(destination);
            ValidateShortStringRange(actualSource.Length, from, copyCount, nameof(from));
            ValidateShortStringRange(actualDestination.Length, to, copyCount, nameof(to));
            destination = actualDestination.WithMovedBytes(
                actualSource.AsSpan().Slice(from, copyCount),
                to);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;

            AnsiString actualSource = AnsiString.Normalize(source);
            ShortString actualDestination = ShortString.Normalize(destination);
            ValidateShortStringRange(actualSource.Length, from, copyCount, nameof(from));
            ValidateShortStringRange(actualDestination.Length, to, copyCount, nameof(to));
            destination = actualDestination.WithMovedBytes(
                actualSource.AsSpan().Slice(from, copyCount),
                to);
        }

        public static void Move(
            ShortString? source,
            int from,
            ref string destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;

            ShortString actualSource = ShortString.Normalize(source);
            destination ??= string.Empty;
            ValidateShortStringRange(actualSource.Length, from, copyCount, nameof(from));
            ValidateAnsiUtf16ByteRange(destination.Length, to, copyCount, nameof(to));
            byte[] destinationBytes = GetLittleEndianUtf16Bytes(destination);
            actualSource.AsSpan().Slice(from, copyCount).CopyTo(
                destinationBytes.AsSpan(checked(to * sizeof(char)), copyCount));
            destination = FromLittleEndianUtf16Bytes(destinationBytes);
        }

        public static void Move(
            string? source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            if (copyCount <= 0)
                return;
            if (source is null)
                throw new NullReferenceException("Source string is nil.");

            ShortString actualDestination = ShortString.Normalize(destination);
            ValidateAnsiUtf16ByteRange(source.Length, from, copyCount, nameof(from));
            ValidateShortStringRange(actualDestination.Length, to, copyCount, nameof(to));
            byte[] sourceBytes = GetLittleEndianUtf16Bytes(source);
            destination = actualDestination.WithMovedBytes(
                sourceBytes.AsSpan(checked(from * sizeof(char)), copyCount),
                to);
        }

        private static void ValidateShortStringRange(
            int length,
            int offset,
            int byteCount,
            string parameterName)
        {
            if (offset < 0 || offset > length || byteCount > length - offset)
                throw new ArgumentOutOfRangeException(parameterName);
        }
    }
}
