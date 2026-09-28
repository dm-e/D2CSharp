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
    public static partial class SystemInterface
    {
        public static int Length(ShortString? value)
            => value?.Length ?? 0;

        public static int High(ShortString? value)
            => ShortString.Normalize(value).MaximumLength;

        public static int Low(ShortString? value) => 0;

        public static void SetLength(
            ref ShortString? value,
            int newLength)
        {
            ShortString.SetLength(ref value, newLength);
        }

        public static void SetLength(
            ref ShortString? value,
            uint newLength)
        {
            SetLength(ref value, checked((int)newLength));
        }

        public static void SetLength(
            ref ShortString? value,
            long newLength)
        {
            if (newLength < 0 || newLength > ShortString.DefaultMaximumLength)
                throw new ArgumentOutOfRangeException(nameof(newLength));
            SetLength(ref value, (int)newLength);
        }

        public static ShortString Copy(
            ShortString? source,
            int index,
            int count)
        {
            ShortString actual = ShortString.Normalize(source);
            if (count <= 0 || index >= actual.Length)
            {
                return ShortString.FromBytes(
                    ReadOnlySpan<byte>.Empty,
                    actual.CodePage,
                    actual.MaximumLength);
            }

            int zeroBasedIndex = Math.Max(0, index);
            int actualCount = Math.Min(count, actual.Length - zeroBasedIndex);
            return actual.Substring(zeroBasedIndex, actualCount);
        }

        public static int Pos(
            ShortString? substring,
            ShortString? source)
        {
            return Pos(substring, source, 0);
        }

        public static int Pos(
            ShortString? substring,
            ShortString? source,
            int offset)
        {
            ShortString actualSource = ShortString.Normalize(source);
            ShortString needle = ShortString.Normalize(substring);
            if (needle.Length == 0)
                return 0;
            if (offset < 0)
                offset = 0;
            if (offset >= actualSource.Length)
                return 0;

            int index = actualSource.IndexOf(needle, offset);
            return index < 0 ? 0 : index + 1;
        }

        public static void Insert(
            ShortString? source,
            ref ShortString? destination,
            int index)
        {
            ShortString actual = ShortString.Normalize(destination);
            int zeroBasedIndex = Math.Clamp(index, 0, actual.Length);
            destination = actual.Insert(zeroBasedIndex, source);
        }

        public static void Delete(
            ref ShortString? source,
            int startChar,
            int count)
        {
            ShortString actual = ShortString.Normalize(source);
            if (count <= 0 || startChar < 0 || startChar >= actual.Length)
                return;

            int actualCount = Math.Min(count, actual.Length - startChar);
            source = actual.Remove(startChar, actualCount);
        }

        public static ShortString ReplaceAtIndex(
            ShortString? source,
            int index,
            byte value)
        {
            return ShortString.Normalize(source).WithByte(index, value);
        }

        public static ShortString ReplaceCharAt(
            ShortString? source,
            int index,
            byte newChar)
        {
            return ReplaceAtIndex(source, index, newChar);
        }

        public static void SetString(
            ref ShortString? value,
            byte[]? buffer,
            int length,
            ushort codePage = 0)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            ShortString current = ShortString.Normalize(value);
            int maximumLength = current.MaximumLength;
            ushort effectiveCodePage = value?.CodePage ??
                AnsiStringSettings.ResolveCodePage(codePage);
            int actualLength = Math.Min(length, maximumLength);
            byte[] result = new byte[actualLength];
            if (buffer is not null)
            {
                buffer.AsSpan(0, Math.Min(buffer.Length, actualLength))
                    .CopyTo(result);
            }

            value = ShortString.FromBytes(
                result,
                effectiveCodePage,
                maximumLength);
        }

        public static void SetString(
            ref ShortString? value,
            PAnsiChar buffer,
            int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            ShortString current = ShortString.Normalize(value);
            int actualLength = Math.Min(length, current.MaximumLength);
            byte[] result = new byte[actualLength];
            if (!buffer.IsNull())
            {
                if (actualLength > buffer.Capacity)
                    throw new ArgumentOutOfRangeException(nameof(length));
                for (int index = 0; index < actualLength; index++)
                    result[index] = buffer[index];
            }

            value = ShortString.FromBytes(
                result,
                buffer.CodePage,
                current.MaximumLength);
        }

        public static PAnsiChar Addr(
            ShortString? value,
            int index = 0)
        {
            return value is null ? default : new PAnsiChar(value, index);
        }

        public static string UTF8ToUnicodeString(ShortString? value)
            => DecodeShortStringAsUtf8(value);

        public static string UTF8ToString(ShortString? value)
            => DecodeShortStringAsUtf8(value);

        public static void Move(
            ShortString? source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        public static void Move(
            ShortString? source,
            int from,
            ref byte[]? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        public static void Move(
            byte[]? source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        public static void Move(
            ShortString? source,
            int from,
            ref PAnsiChar destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        public static void Move(
            PAnsiChar source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        public static void Move(
            ShortString? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        public static void Move(
            ShortString? source,
            int from,
            ref string destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        public static void Move(
            string? source,
            int from,
            ref ShortString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(source, from, ref destination, to, copyCount);
        }

        private static string DecodeShortStringAsUtf8(ShortString? value)
        {
            return AnsiStringSettings.GetEncoding(
                AnsiStringSettings.Utf8CodePage).GetString(
                    ShortString.Normalize(value).AsSpan());
        }
    }
}
