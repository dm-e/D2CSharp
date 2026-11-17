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

namespace System
{
    public sealed class ShortStringBuffer : IDisposable
    {
        private byte[]? FBytes;
        private readonly int FMaximumLength;
        private readonly ushort FCodePage;
        private readonly int FLength;

        public ShortStringBuffer(ShortString? value)
        {
            ShortString initial = ShortString.Normalize(value);
            FMaximumLength = initial.MaximumLength;
            FCodePage = initial.CodePage;
            FLength = initial.Length;
            FBytes = new byte[FMaximumLength + 1];
            initial.AsSpan().CopyTo(FBytes);
        }

        public UntypedPointer GetPointer(int index = 0)
        {
            ObjectDisposedException.ThrowIf(FBytes is null, this);
            if ((uint)index > (uint)FMaximumLength) throw new ArgumentOutOfRangeException(nameof(index));
            return new UntypedPointer(FBytes, index);
        }

        public ShortString Commit() => Commit(FLength);
        public ShortString Commit(int length)
        {
            ObjectDisposedException.ThrowIf(FBytes is null, this);
            if ((uint)length > (uint)FMaximumLength) throw new ArgumentOutOfRangeException(nameof(length));
            return ShortString.FromBytes(FBytes.AsSpan(0, length), FCodePage, FMaximumLength);
        }

        public void Dispose() => FBytes = null;
    }

    public static partial class SystemInterface
    {
        public static int MaxSubstringLength(ShortString? source, int position, int count)
        {
            int remaining = Length(source) - position;
            return remaining > 0 ? Math.Min(remaining, count) : 0;
        }
    }
}
