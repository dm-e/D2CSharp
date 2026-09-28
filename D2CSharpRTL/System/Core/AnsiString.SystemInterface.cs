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

        // Delphi High/Low values. Generated element access still subtracts 1.
        public static int High(AnsiString? value)
            => value?.Length ?? 0;

        public static int Low(AnsiString? value) => 1;

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

        /// <summary>
        /// Copy helper for generated C#: index is already zero-based because
        /// the generator translates the Delphi argument as Index - 1.
        /// Negative translated indexes are clamped to zero, matching Delphi.
        /// </summary>
        public static AnsiString Copy(
            AnsiString? source,
            int index,
            int count)
        {
            AnsiString actualSource = AnsiString.Normalize(source);
            if (count <= 0 || index >= actualSource.Length)
            {
                return AnsiString.FromBytes(
                    Array.Empty<byte>(),
                    actualSource.CodePage);
            }

            int zeroBasedIndex = Math.Max(0, index);
            int actualCount = Math.Min(
                count,
                actualSource.Length - zeroBasedIndex);
            return actualSource.Substring(zeroBasedIndex, actualCount);
        }

        /// <summary>Delphi Pos: returns a one-based byte index or zero.</summary>
        public static int Pos(AnsiString? substring, AnsiString? source)
        {
            return Pos(substring, source, 0);
        }

        /// <summary>
        /// Pos helper with an already translated zero-based start offset. The
        /// result remains Delphi-compatible: one-based or zero when not found.
        /// </summary>
        public static int Pos(
            AnsiString? substring,
            AnsiString? source,
            int offset)
        {
            AnsiString actualSource = AnsiString.Normalize(source);
            AnsiString needle = AnsiString.Normalize(substring);
            if (needle.Length == 0)
                return 0;
            if (offset < 0)
                offset = 0;
            if (offset >= actualSource.Length)
                return 0;
            if (needle.CodePage != actualSource.CodePage)
                needle = needle.Reencode(actualSource.CodePage);

            int index = actualSource.IndexOf(needle, offset);
            return index < 0 ? 0 : index + 1;
        }

        /// <summary>
        /// Insert helper for generated C#: index is an already translated,
        /// zero-based byte position.
        /// </summary>
        public static void Insert(
            AnsiString? source,
            ref AnsiString? destination,
            int index)
        {
            AnsiString actualDestination = AnsiString.Normalize(destination);
            int zeroBasedIndex = Math.Clamp(index, 0, actualDestination.Length);
            destination = actualDestination.Insert(zeroBasedIndex, source);
        }

        /// <summary>
        /// Delete helper for generated C#: startChar is already zero-based.
        /// A negative translated index is invalid and performs no deletion.
        /// </summary>
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

        public static void SetString(
            ref AnsiString? value,
            byte[]? buffer,
            int length,
            ushort codePage = 0)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            ushort effectiveCodePage = value?.CodePage ??
                AnsiStringSettings.ResolveCodePage(codePage);
            byte[] result = new byte[length];
            if (buffer is not null)
            {
                buffer.AsSpan(0, Math.Min(buffer.Length, length))
                    .CopyTo(result);
            }

            value = AnsiString.FromBytes(result, effectiveCodePage);
        }

        public static void SetString(
            ref AnsiString? value,
            PAnsiChar buffer,
            int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            ushort codePage = value?.CodePage ?? buffer.CodePage;
            byte[] result = new byte[length];
            if (!buffer.IsNull())
            {
                if (length > buffer.Capacity)
                    throw new ArgumentOutOfRangeException(nameof(length));

                for (int index = 0; index < length; index++)
                    result[index] = buffer[index];
            }

            value = AnsiString.FromBytes(result, codePage);
        }

        public static void SetString(
            ref AnsiString? value,
            PAnsiChar buffer,
            uint length)
        {
            SetString(ref value, buffer, checked((int)length));
        }

        public static PAnsiChar Addr(
            AnsiString? value,
            int index = 0)
        {
            return value is null ? default : new PAnsiChar(value, index);
        }

        public static void UniqueString(ref AnsiString? value)
        {
            // AnsiString is immutable. A subsequent write creates a new value,
            // which is the observable effect Delphi UniqueString guarantees.
            value ??= AnsiString.Empty;
        }

        public static AnsiString Concat(params AnsiString?[] values)
        {
            if (values is null || values.Length == 0)
                return AnsiString.Empty;

            AnsiString result = AnsiString.Normalize(values[0]);
            for (int index = 1; index < values.Length; index++)
                result += values[index];
            return result;
        }

        public static AnsiString AnsiStringOfChar(
            byte value,
            int count,
            ushort codePage = 0)
        {
            if (count <= 0)
                return AnsiString.FromBytes(Array.Empty<byte>(), codePage);

            byte[] result = new byte[count];
            Array.Fill(result, value);
            return AnsiString.FromBytes(result, codePage);
        }

        public static AnsiString StringOfChar(byte value, int count)
        {
            return AnsiStringOfChar(value, count);
        }

        public static void Write(TTextRec fileRecord, AnsiString? value)
        {
            Write(fileRecord, AnsiToUnicodeForSystem(value));
        }

        public static void Write(
            TTextRec fileRecord,
            AnsiString? value,
            int minWidth)
        {
            Write(fileRecord, AnsiToUnicodeForSystem(value), minWidth);
        }

        public static void Write(AnsiString? value)
        {
            Write(AnsiToUnicodeForSystem(value));
        }

        public static void Write(AnsiString? value, int minWidth)
        {
            Write(AnsiToUnicodeForSystem(value), minWidth);
        }

        public static void WriteLn(AnsiString? value)
        {
            WriteLn(AnsiToUnicodeForSystem(value));
        }

        public static void WriteLn(AnsiString? value, int minWidth)
        {
            WriteLn(AnsiToUnicodeForSystem(value), minWidth);
        }

        public static void WriteLn(
            TTextRec fileRecord,
            AnsiString? value)
        {
            WriteLn(fileRecord, AnsiToUnicodeForSystem(value));
        }

        public static void WriteLn(
            TTextRec fileRecord,
            AnsiString? value,
            int minWidth)
        {
            WriteLn(fileRecord, AnsiToUnicodeForSystem(value), minWidth);
        }

        public static void Write(TextFile file, AnsiString? value)
        {
            Write(file, AnsiToUnicodeForSystem(value));
        }

        public static void WriteLn(TextFile file, AnsiString? value)
        {
            WriteLn(file, AnsiToUnicodeForSystem(value));
        }

        public static void AssignFile(
            DelphiFileRecord fileRecord,
            AnsiString? fileName)
        {
            AssignFile(fileRecord, AnsiToUnicodeForSystem(fileName));
        }

        public static void Rename(
            DelphiFileRecord fileRecord,
            AnsiString? newFileName)
        {
            Rename(fileRecord, AnsiToUnicodeForSystem(newFileName));
        }

        public static void Read(
            TTextRec fileRecord,
            ref AnsiString? value)
        {
            ushort codePage = value?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            string unicodeValue = string.Empty;
            Read(fileRecord, ref unicodeValue);
            value = AnsiString.FromString(unicodeValue, codePage);
        }

        public static void ReadLn(
            TTextRec fileRecord,
            ref AnsiString? value)
        {
            ushort codePage = value?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            string unicodeValue = string.Empty;
            ReadLn(fileRecord, ref unicodeValue);
            value = AnsiString.FromString(unicodeValue, codePage);
        }

        public static void SetString(
            ref AnsiString? value,
            StringBuilder? buffer,
            int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            ushort codePage = value?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            string text;
            if (buffer is null)
            {
                text = new string('\0', length);
            }
            else if (length <= buffer.Length)
            {
                text = buffer.ToString(0, length);
            }
            else
            {
                text = buffer.ToString() +
                    new string('\0', length - buffer.Length);
            }

            value = AnsiString.FromString(text, codePage);
        }

        public static void SetString(
            ref AnsiString? value,
            StringBuilder? buffer,
            uint length)
        {
            SetString(ref value, buffer, checked((int)length));
        }

        public static void SetString(
            ref AnsiString? value,
            char[]? buffer,
            int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            ushort codePage = value?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            char[] result = new char[length];
            if (buffer is not null)
            {
                Array.Copy(
                    buffer,
                    result,
                    Math.Min(buffer.Length, length));
            }

            value = AnsiString.FromString(
                new string(result),
                codePage);
        }

        public static void SetString(
            ref AnsiString? value,
            char[]? buffer,
            uint length)
        {
            SetString(ref value, buffer, checked((int)length));
        }

        public static void SetString(
            ref AnsiString? value,
            PChar buffer,
            int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            ushort codePage = value?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            string text = buffer.IsNull()
                ? new string('\0', length)
                : buffer.ToString();
            if (text.Length < length)
                text += new string('\0', length - text.Length);
            else if (text.Length > length)
                text = text.Substring(0, length);

            value = AnsiString.FromString(text, codePage);
        }

        public static void SetString(
            ref AnsiString? value,
            PChar buffer,
            uint length)
        {
            SetString(ref value, buffer, checked((int)length));
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

        public static void Val(
            AnsiString? numberString,
            ref byte number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref sbyte number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref short number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref ushort number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref uint number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref int number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref long number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref ulong number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref float number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void Val(
            AnsiString? numberString,
            ref double number,
            ref int errorCode)
            => Val(AnsiToUnicodeForSystem(numberString), ref number, ref errorCode);

        public static void ChDir(AnsiString? path)
        {
            ChDir(AnsiToUnicodeForSystem(path));
        }

        public static void GetDir(byte drive, ref AnsiString? path)
        {
            string unicodePath = string.Empty;
            GetDir(drive, ref unicodePath);
            ushort codePage = path?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            path = AnsiString.FromString(unicodePath, codePage);
        }

        public static PAnsiChar GetParamStr(
            PAnsiChar pointer,
            ref AnsiString? parameter)
        {
            PAnsiChar cursor = pointer;
            while (true)
            {
                while (!cursor.IsNull() && cursor[0] != 0 && cursor[0] <= 32)
                    cursor++;
                if (!cursor.IsNull() && cursor[0] == (byte)'\"' &&
                    cursor[1] == (byte)'\"')
                {
                    cursor += 2;
                }
                else
                {
                    break;
                }
            }

            PAnsiChar start = cursor;
            int length = 0;
            while (!cursor.IsNull() && cursor[0] > 32)
            {
                if (cursor[0] == (byte)'\"')
                {
                    cursor++;
                    while (cursor[0] != 0 && cursor[0] != (byte)'\"')
                    {
                        length++;
                        cursor++;
                    }
                    if (cursor[0] != 0)
                        cursor++;
                }
                else
                {
                    length++;
                    cursor++;
                }
            }

            byte[] result = new byte[length];
            cursor = start;
            int outputIndex = 0;
            while (!cursor.IsNull() && cursor[0] > 32)
            {
                if (cursor[0] == (byte)'\"')
                {
                    cursor++;
                    while (cursor[0] != 0 && cursor[0] != (byte)'\"')
                    {
                        result[outputIndex++] = cursor[0];
                        cursor++;
                    }
                    if (cursor[0] != 0)
                        cursor++;
                }
                else
                {
                    result[outputIndex++] = cursor[0];
                    cursor++;
                }
            }

            ushort codePage = pointer.CodePage;
            parameter = AnsiString.FromBytes(result, codePage);
            return cursor;
        }

        public static AnsiString LoadResString(AnsiString? resourceString)
        {
            return AnsiString.Normalize(resourceString);
        }

        public static AnsiString UTF8Encode(AnsiString? value)
        {
            AnsiString actual = AnsiString.Normalize(value);
            return actual.CodePage == AnsiStringSettings.Utf8CodePage
                ? actual
                : AnsiString.FromString(
                    actual.Decode(),
                    AnsiStringSettings.Utf8CodePage);
        }

        public static ShortString UTF8EncodeToShortString(AnsiString? value)
        {
            AnsiString actual = AnsiString.Normalize(value);
            if (actual.CodePage == AnsiStringSettings.Utf8CodePage)
            {
                return ShortString.FromBytes(
                    actual.AsSpan(),
                    AnsiStringSettings.Utf8CodePage);
            }

            return ShortString.FromUtf8String(actual.Decode());
        }

        public static string UTF8ToWideString(AnsiString? value)
        {
            return DecodeAsUtf8(value);
        }

        public static string UTF8ToUnicodeString(AnsiString? value)
        {
            return DecodeAsUtf8(value);
        }

        public static string UTF8ToString(AnsiString? value)
        {
            return DecodeAsUtf8(value);
        }

        public static AnsiString AnsiToUtf8(AnsiString? value)
        {
            return UTF8Encode(value);
        }

        public static string Utf8ToAnsi(AnsiString? value)
        {
            return DecodeAsUtf8(value);
        }

        public static void StringCopy(
            ref AnsiString? destination,
            int destinationSize,
            AnsiString? source)
        {
            if (destinationSize < 0)
                throw new ArgumentOutOfRangeException(nameof(destinationSize));

            AnsiString actualSource = AnsiString.Normalize(source);
            int count = Math.Min(destinationSize, actualSource.Length);
            destination = AnsiString.FromBytes(
                actualSource.AsSpan().Slice(0, count),
                actualSource.CodePage);
        }

        public static AnsiString InternalGetLocaleOverride(
            AnsiString? applicationName)
        {
            ushort codePage = applicationName?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            return AnsiString.FromString(
                InternalGetLocaleOverride(
                    AnsiToUnicodeForSystem(applicationName)),
                codePage);
        }

        public static AnsiString GetLocaleOverride(
            AnsiString? applicationName)
        {
            ushort codePage = applicationName?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            return AnsiString.FromString(
                GetLocaleOverride(AnsiToUnicodeForSystem(applicationName)),
                codePage);
        }

        public static void SetLocaleOverride(AnsiString? languages)
        {
            SetLocaleOverride(AnsiToUnicodeForSystem(languages));
        }

        public static AnsiString ParamStrAnsi(
            int index,
            ushort codePage = 0)
        {
            return AnsiString.FromString(ParamStr(index), codePage);
        }

        public static AnsiString GetUILanguagesAnsi(
            ushort languageId,
            ushort codePage = 0)
        {
            return AnsiString.FromString(
                GetUILanguages(languageId),
                codePage);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref byte[]? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            byte[]? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref string destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            byte[]? source,
            int from,
            ref string destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            string? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            char[]? source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            if (source is null)
                throw new NullReferenceException("Source array is nil.");

            string unicodeSource = new string(source);
            DelphiMemory.Move(
                unicodeSource,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref char[]? destination,
            int to,
            int copyCount)
        {
            if (destination is null)
            {
                throw new NullReferenceException(
                    "Destination array is nil. Call SetLength before Move.");
            }

            string unicodeDestination = new string(destination);
            DelphiMemory.Move(
                source,
                from,
                ref unicodeDestination,
                to,
                copyCount);
            destination = unicodeDestination.ToCharArray();
        }

#if USEDYNAMICARRAY
        public static void Move(
            AnsiString? source,
            int from,
            ref DynamicArray<char> destination,
            int to,
            int copyCount)
        {
            if (destination is null)
                DelphiArray.SetLength(ref destination, 0);
            if (to < 0)
                throw new ArgumentOutOfRangeException(nameof(to));

            int requiredCharacters = checked(
                to + (copyCount + sizeof(char) - 1) / sizeof(char));
            if (destination.Length < requiredCharacters)
                DelphiArray.SetLength(ref destination, requiredCharacters);

            char[] temporary = new char[destination.Length];
            for (int index = 0; index < destination.Length; index++)
                temporary[index] = destination[index];
            Move(source, from, ref temporary, to, copyCount);
            for (int index = 0; index < destination.Length; index++)
                destination[index] = temporary[index];
        }
#endif

        public static void Move(
            PAnsiChar source,
            int from,
            ref PAnsiChar destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            PAnsiChar source,
            int from,
            ref AnsiString? destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void Move(
            AnsiString? source,
            int from,
            ref PAnsiChar destination,
            int to,
            int copyCount)
        {
            DelphiMemory.Move(
                source,
                from,
                ref destination,
                to,
                copyCount);
        }

        public static void GetMem(
            ref PAnsiChar storagePointer,
            int storageSize)
        {
            if (storageSize < 0)
                throw new ArgumentOutOfRangeException(nameof(storageSize));

            storagePointer = new PAnsiChar(storageSize, alloc: true);
        }

        public static void FreeMem(ref PAnsiChar memoryPointer)
        {
            DelphiMemory.FreeMem(ref memoryPointer);
        }

        private static string AnsiToUnicodeForSystem(AnsiString? value)
        {
            return AnsiString.Normalize(value).Decode();
        }

        private static string DecodeAsUtf8(AnsiString? value)
        {
            return AnsiStringSettings.GetEncoding(
                AnsiStringSettings.Utf8CodePage).GetString(
                    AnsiString.Normalize(value).AsSpan());
        }
    }
}
