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
    /// <summary>
    /// Public AnsiString/RawByteString APIs declared by Delphi's System unit.
    /// Compiler-only _LStr* entry points are intentionally represented by the
    /// normal C# operators and SystemInterface intrinsics instead of exposed as
    /// a second low-level ABI.
    /// </summary>
    public static partial class SystemInterface
    {
        public static void WideCharLenToStrVar(
            PChar source,
            int sourceLength,
            ref AnsiString? destination)
        {
            if (sourceLength < 0)
                throw new ArgumentOutOfRangeException(nameof(sourceLength));
            if (source.IsNull())
            {
                destination = AnsiString.Empty;
                return;
            }

            char[] characters = new char[sourceLength];
            for (int index = 0; index < sourceLength; index++)
                characters[index] = source[index];
            destination = AnsiString.FromString(
                new string(characters),
                AnsiStringSettings.DefaultCodePage);
        }

        public static int UnicodeToUtf8(
            PAnsiChar destination,
            PChar source,
            int maxBytes)
        {
            if (maxBytes < 0)
                throw new ArgumentOutOfRangeException(nameof(maxBytes));
            if (source.IsNull())
                return 0;
            return checked((int)UnicodeToUtf8(
                destination,
                checked((uint)maxBytes),
                source,
                checked((uint)source.Length)));
        }

        public static uint UnicodeToUtf8(
            PAnsiChar destination,
            uint maxDestinationBytes,
            PChar source,
            uint sourceCharacters)
        {
            if (source.IsNull())
                return 0;

            int characterCount = sourceCharacters > int.MaxValue
                ? source.Length
                : Math.Min(checked((int)sourceCharacters), source.Capacity);
            char[] characters = new char[characterCount];
            for (int index = 0; index < characterCount; index++)
                characters[index] = source[index];

            Encoding utf8 = AnsiStringSettings.GetEncoding(
                AnsiStringSettings.Utf8CodePage);
            if (destination.IsNull())
                return checked((uint)utf8.GetByteCount(characters));
            if (maxDestinationBytes == 0)
                return 0;

            int available = maxDestinationBytes > int.MaxValue
                ? destination.Capacity
                : Math.Min(checked((int)maxDestinationBytes), destination.Capacity);
            if (available == 0)
                return 0;

            byte[] encoded = new byte[Math.Max(0, available - 1)];
            Encoder encoder = utf8.GetEncoder();
            encoder.Convert(
                characters,
                0,
                characters.Length,
                encoded,
                0,
                encoded.Length,
                flush: true,
                out _,
                out int bytesUsed,
                out _);
            for (int index = 0; index < bytesUsed; index++)
                destination[index] = encoded[index];
            destination[bytesUsed] = 0;
            return checked((uint)bytesUsed + 1);
        }

        public static int Utf8ToUnicode(
            PChar destination,
            PAnsiChar source,
            int maxCharacters)
        {
            if (maxCharacters < 0)
                throw new ArgumentOutOfRangeException(nameof(maxCharacters));
            if (source.IsNull())
                return 0;
            return checked((int)Utf8ToUnicode(
                destination,
                checked((uint)maxCharacters),
                source,
                checked((uint)source.Length)));
        }

        public static uint Utf8ToUnicode(
            PChar destination,
            uint maxDestinationCharacters,
            PAnsiChar source,
            uint sourceBytes)
        {
            if (source.IsNull())
                return 0;

            int byteCount = sourceBytes > int.MaxValue
                ? source.Length
                : Math.Min(checked((int)sourceBytes), source.Capacity);
            byte[] bytes = new byte[byteCount];
            for (int index = 0; index < byteCount; index++)
                bytes[index] = source[index];

            Encoding utf8 = AnsiStringSettings.GetEncoding(
                AnsiStringSettings.Utf8CodePage);
            if (destination.IsNull())
                return checked((uint)utf8.GetCharCount(bytes));
            if (maxDestinationCharacters == 0)
                return 0;

            int available = maxDestinationCharacters > int.MaxValue
                ? destination.Capacity
                : Math.Min(
                    checked((int)maxDestinationCharacters),
                    destination.Capacity);
            if (available == 0)
                return 0;

            char[] decoded = new char[Math.Max(0, available - 1)];
            Decoder decoder = utf8.GetDecoder();
            decoder.Convert(
                bytes,
                0,
                bytes.Length,
                decoded,
                0,
                decoded.Length,
                flush: true,
                out _,
                out int charactersUsed,
                out _);
            for (int index = 0; index < charactersUsed; index++)
                destination[index] = decoded[index];
            destination[charactersUsed] = '\0';
            return checked((uint)charactersUsed + 1);
        }

        public static string UTF8Decode(AnsiString? value)
            => UTF8ToUnicodeString(value);

        public static string UTF8ToUnicodeString(PAnsiChar value)
            => value.IsNull()
                ? string.Empty
                : UTF8ToUnicodeString(value.ToAnsiString());

        public static string UTF8ToString(PAnsiChar value)
            => UTF8ToUnicodeString(value);

        public static string UTF8ToString(byte[]? value)
            => value is null || value.Length == 0
                ? string.Empty
                : AnsiString.FromBytes(
                    value,
                    AnsiStringSettings.Utf8CodePage).Decode();

        public static void OleStrToStrVar(
            PChar source,
            ref AnsiString? destination)
        {
            destination = source.IsNull()
                ? AnsiString.Empty
                : AnsiString.FromString(source.ToString());
        }

        public static PChar StringToOleStr(AnsiString? source)
            => new PChar(AnsiString.Normalize(source).Decode());

        public static ushort StringElementSize(AnsiString? value) => 1;

        public static ushort StringCodePage(AnsiString? value)
            => value?.CodePage ?? AnsiStringSettings.DefaultCodePage;

        public static int StringRefCount(AnsiString? value)
        {
            // CLR references have no observable Delphi reference count.  Zero
            // still distinguishes nil/empty from a live managed value.
            return value is null || value.Length == 0 ? 0 : 1;
        }

        public static void SetAnsiString(
            Pointer<AnsiString> destination,
            PAnsiChar source,
            int length,
            ushort codePage)
        {
            if (destination.IsNull())
                throw new NullReferenceException("Destination PAnsiString is null.");
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));
            byte[] bytes = new byte[length];
            for (int index = 0; index < length; index++)
                bytes[index] = source[index];
            destination.Assign(AnsiString.FromBytes(bytes, codePage));
        }

        public static void SetAnsiString(
            Pointer<AnsiString> destination,
            PChar source,
            int length,
            ushort codePage)
        {
            if (destination.IsNull())
                throw new NullReferenceException("Destination PAnsiString is null.");
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));
            char[] characters = new char[length];
            for (int index = 0; index < length; index++)
                characters[index] = source[index];
            destination.Assign(AnsiString.FromString(new string(characters), codePage));
        }

        public static void SetCodePage(
            ref AnsiString? value,
            ushort codePage,
            bool convert = true)
        {
            AnsiString actual = AnsiString.Normalize(value);
            ushort resolved = AnsiStringSettings.ResolveCodePage(codePage);
            if (actual.CodePage == resolved)
                return;
            value = convert && actual.Length != 0
                ? actual.Reencode(resolved)
                : AnsiString.FromBytes(actual.AsSpan(), resolved);
        }
    }
}
