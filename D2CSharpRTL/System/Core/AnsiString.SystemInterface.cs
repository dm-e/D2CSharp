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
using System.Text;

namespace System
{
    public static partial class SystemInterface
    {
        public static int Length(AnsiString? value)
            => value?.Length ?? 0;

        public static void SetLength(
            ref AnsiString? value,
            int newLength)
        {
            AnsiString.SetLength(ref value, newLength);
        }

        public static void SetLength(
            ref AnsiString? value,
            uint newLength)
        {
            SetLength(ref value, checked((int)newLength));
        }

        public static void SetLength(
            ref AnsiString? value,
            long newLength)
        {
            if (newLength < 0 || newLength > int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(newLength));
            SetLength(ref value, (int)newLength);
        }

        public static void Insert(
            AnsiString? source,
            ref AnsiString? destination,
            int index)
        {
            AnsiString actualDestination = AnsiString.Normalize(destination);
            int zeroBasedIndex = Math.Clamp(index, 0, actualDestination.Length);
            destination = actualDestination.Insert(zeroBasedIndex, source);
        }

        public static void Delete(
            ref AnsiString? source,
            int startChar,
            int count)
        {
            AnsiString actualSource = AnsiString.Normalize(source);
            if (count <= 0 || startChar < 0 || startChar >= actualSource.Length)
                return;

            int zeroBasedIndex = startChar;
            int actualCount = Math.Min(
                count,
                actualSource.Length - zeroBasedIndex);
            source = actualSource.Remove(zeroBasedIndex, actualCount);
        }

        public static int MaxSubstringLength(
            AnsiString? source,
            int position,
            int count)
        {
            int remaining = Length(source) - position;
            return remaining > 0 ? Math.Min(remaining, count) : 0;
        }

        public static int MaxSubstringLength(
            AnsiString? source,
            int position,
            uint count)
        {
            return MaxSubstringLength(
                source,
                position,
                checked((int)count));
        }

        public static int MaxSubstringLength(
            AnsiString? source,
            uint position,
            int count)
        {
            return MaxSubstringLength(
                source,
                checked((int)position),
                count);
        }

        public static int MaxSubstringLength(
            AnsiString? source,
            uint position,
            uint count)
        {
            return MaxSubstringLength(
                source,
                checked((int)position),
                checked((int)count));
        }
        public static AnsiString ReplaceAtIndex(
            AnsiString? source,
            int index,
            byte value)
        {
            return AnsiString.Normalize(source).WithByte(index, value);
        }

        public static AnsiString ReplaceCharAt(
            AnsiString? source,
            int index,
            byte newChar)
        {
            return ReplaceAtIndex(source, index, newChar);
        }
    }
}
