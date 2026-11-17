
namespace System
{

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
    public static partial class SystemInterface
    {
        public static string StringOfChar(char value, int count) =>
            count > 0 ? new string(value, count) : string.Empty;

        public static int DelphiLength(string? value) => value?.Length ?? 0;
        public static int DelphiLength(AnsiString? value) => value?.Length ?? 0;
        public static int DelphiLength(ShortString? value) => value?.Length ?? 0;
        public static int DelphiLength(PChar value) => value.Length;
        public static int DelphiLength(PAnsiChar value) => value.Length;
        public static int DelphiLength(char value) => 1;

        public static int DelphiPos(string? needle, string? text, int offset = 1)
        {
            text ??= string.Empty;
            needle ??= string.Empty;
            if (offset < 1 || offset > text.Length || needle.Length == 0) return 0;
            return text.IndexOf(needle, offset - 1, StringComparison.Ordinal) + 1;
        }

        public static PChar StringToWideChar(string? source, char[] destination, int destinationSize)
        {
            ArgumentNullException.ThrowIfNull(destination);
            if (destinationSize < 0 || destinationSize > destination.Length)
                throw new ArgumentOutOfRangeException(nameof(destinationSize));
            source ??= string.Empty;
            if (destinationSize > 0)
            {
                int length = Math.Min(source.Length, destinationSize - 1);
                source.CopyTo(0, destination, 0, length);
                destination[length] = '\0';
            }
            return new PChar(destination);
        }

        public static string WideCharLenToString(PChar source, int length)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(length);
            var chars = new char[length];
            for (int i = 0; i < length; ++i) chars[i] = source[i];
            return new string(chars);
        }

        public static PChar StringToWideChar(string? source, PChar destination, int destinationSize)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(destinationSize);
            source ??= string.Empty;
            if (destinationSize > 0)
            {
                int length = Math.Min(source.Length, destinationSize - 1);
                for (int i = 0; i < length; ++i) destination[i] = source[i];
                destination[length] = '\0';
            }
            return destination;
        }

        public static int MaxSubstringLength(PChar source, int position, int count) =>
            Math.Max(0, Math.Min(source.Length - position, count));
    }
}
