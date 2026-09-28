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
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// Byte-preserving representation of Delphi ShortString/string[N].
    /// Payload indexes are zero-based in C#. Delphi S[0] is exposed separately
    /// through LengthByte; generated S[I] payload access continues to pass I-1.
    /// </summary>
    public sealed class ShortString :
        IReadOnlyList<byte>,
        IEquatable<ShortString>,
        IComparable<ShortString>
    {
        public const int DefaultMaximumLength = 255;
        public static int DelphiSizeOf => DefaultMaximumLength + 1;

        private readonly byte[] FBytes;

        public static ShortString Empty => new ShortString(
            ReadOnlySpan<byte>.Empty,
            AnsiStringSettings.DefaultCodePage,
            DefaultMaximumLength);

        public ShortString()
            : this(
                ReadOnlySpan<byte>.Empty,
                AnsiStringSettings.DefaultCodePage,
                DefaultMaximumLength)
        {
        }

        public ShortString(
            string? value,
            ushort codePage = 0,
            int maximumLength = DefaultMaximumLength)
            : this(
                (ReadOnlySpan<byte>)Encode(
                    value ?? string.Empty,
                    codePage),
                AnsiStringSettings.ResolveCodePage(codePage),
                maximumLength)
        {
        }

        public ShortString(
            byte[]? bytes,
            ushort codePage = 0,
            int maximumLength = DefaultMaximumLength)
            : this(
                (ReadOnlySpan<byte>)(bytes ?? Array.Empty<byte>()),
                AnsiStringSettings.ResolveCodePage(codePage),
                maximumLength)
        {
        }

        private ShortString(
            ReadOnlySpan<byte> bytes,
            ushort effectiveCodePage,
            int maximumLength)
        {
            ValidateMaximumLength(maximumLength);
            int length = Math.Min(bytes.Length, maximumLength);
            FBytes = bytes.Slice(0, length).ToArray();
            CodePage = effectiveCodePage;
            MaximumLength = maximumLength;
        }

        public int Length => FBytes.Length;
        public int Count => Length;
        public bool IsEmpty => Length == 0;
        public byte LengthByte => checked((byte)Length);
        public ushort CodePage { get; }
        /// <summary>
        /// Declared Delphi ShortString capacity. This is the value returned by
        /// Delphi High(S); it is independent of the active Length.
        /// </summary>
        public int MaximumLength { get; }
        public int DelphiStorageSize => checked(MaximumLength + 1);

        public byte this[int zeroBasedIndex]
        {
            get
            {
                if ((uint)zeroBasedIndex >= (uint)Length)
                    throw new ArgumentOutOfRangeException(nameof(zeroBasedIndex));

                return FBytes[zeroBasedIndex];
            }
        }

        public static ShortString FromBytes(
            ReadOnlySpan<byte> bytes,
            ushort codePage = 0,
            int maximumLength = DefaultMaximumLength)
        {
            return new ShortString(
                bytes,
                AnsiStringSettings.ResolveCodePage(codePage),
                maximumLength);
        }

        public static ShortString Create(
            int maximumLength = DefaultMaximumLength,
            ushort codePage = 0)
        {
            return FromBytes(
                ReadOnlySpan<byte>.Empty,
                codePage,
                maximumLength);
        }

        public static ShortString FromString(
            string? value,
            ushort codePage = 0,
            int maximumLength = DefaultMaximumLength)
        {
            return new ShortString(value, codePage, maximumLength);
        }

        public static ShortString FromUtf8String(
            string? value,
            int maximumLength = DefaultMaximumLength)
        {
            if (value is null || value.Length == 0)
            {
                return FromBytes(
                    ReadOnlySpan<byte>.Empty,
                    AnsiStringSettings.Utf8CodePage,
                    maximumLength);
            }

            ValidateMaximumLength(maximumLength);
            // Delphi UTF8EncodeToShortString passes High(Result) to
            // UnicodeToUtf8. That byte count includes the trailing null, so a
            // plain ShortString can receive at most 254 encoded payload bytes.
            int encodedCapacity = Math.Max(0, maximumLength - 1);
            if (encodedCapacity == 0)
            {
                return FromBytes(
                    ReadOnlySpan<byte>.Empty,
                    AnsiStringSettings.Utf8CodePage,
                    maximumLength);
            }

            Encoding utf8 = AnsiStringSettings.GetEncoding(
                AnsiStringSettings.Utf8CodePage);
            char[] characters = value.ToCharArray();
            byte[] bytes = new byte[encodedCapacity];
            Encoder encoder = utf8.GetEncoder();
            encoder.Convert(
                characters,
                0,
                characters.Length,
                bytes,
                0,
                bytes.Length,
                flush: true,
                out _,
                out int bytesUsed,
                out _);
            return FromBytes(
                bytes.AsSpan(0, bytesUsed),
                AnsiStringSettings.Utf8CodePage,
                maximumLength);
        }

        public static ShortString FromAnsiString(
            AnsiString? value,
            ushort codePage = 0,
            int maximumLength = DefaultMaximumLength)
        {
            ushort effectiveCodePage = AnsiStringSettings.ResolveCodePage(codePage);
            AnsiString actual = AnsiString.Normalize(value);
            AnsiString converted = actual.CodePage == effectiveCodePage
                ? actual
                : actual.Reencode(effectiveCodePage);
            return FromBytes(converted.AsSpan(), effectiveCodePage, maximumLength);
        }

        public static ShortString FromPAnsiChar(
            PAnsiChar value,
            int maximumLength = DefaultMaximumLength)
        {
            return value.IsNull()
                ? FromBytes(ReadOnlySpan<byte>.Empty, value.CodePage, maximumLength)
                : FromBytes(value.ToByteArray(), value.CodePage, maximumLength);
        }

        public ReadOnlySpan<byte> AsSpan() => FBytes;

        public byte[] ToByteArray() => (byte[])FBytes.Clone();

        /// <summary>Returns Length followed by the active payload bytes.</summary>
        public byte[] ToLengthPrefixedByteArray()
        {
            byte[] result = new byte[checked(Length + 1)];
            result[0] = LengthByte;
            AsSpan().CopyTo(result.AsSpan(1));
            return result;
        }

        /// <summary>
        /// Returns Delphi's complete inline storage: length byte plus the
        /// declared payload capacity. Bytes beyond Length are zero-filled.
        /// </summary>
        public byte[] ToDelphiBuffer()
        {
            byte[] result = new byte[DelphiStorageSize];
            result[0] = LengthByte;
            AsSpan().CopyTo(result.AsSpan(1));
            return result;
        }

        internal byte[] ToNullTerminatedByteArray()
        {
            byte[] result = new byte[checked(Length + 1)];
            AsSpan().CopyTo(result);
            return result;
        }

        public string Decode(AnsiStringConversionMode? mode = null)
        {
            if (Length == 0)
                return string.Empty;

            return AnsiStringSettings
                .GetEncoding(CodePage, mode)
                .GetString(FBytes);
        }

        public override string ToString() => Decode();

        public AnsiString ToAnsiString()
            => AnsiString.FromBytes(AsSpan(), CodePage);

        public ShortString Substring(int zeroBasedIndex)
            => Substring(zeroBasedIndex, Length - zeroBasedIndex);

        public ShortString Substring(int zeroBasedIndex, int count)
        {
            ValidateRange(zeroBasedIndex, count, Length);
            return FromBytes(
                AsSpan().Slice(zeroBasedIndex, count),
                CodePage,
                MaximumLength);
        }

        public int IndexOf(ShortString? value, int zeroBasedStartIndex = 0)
        {
            if ((uint)zeroBasedStartIndex > (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(zeroBasedStartIndex));

            ShortString needle = ConvertForTarget(Normalize(value), CodePage);
            int relative = AsSpan().Slice(zeroBasedStartIndex).IndexOf(needle.AsSpan());
            return relative < 0 ? -1 : zeroBasedStartIndex + relative;
        }

        public ShortString Insert(int zeroBasedIndex, ShortString? value)
        {
            if ((uint)zeroBasedIndex > (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(zeroBasedIndex));

            ShortString converted = ConvertForTarget(Normalize(value), CodePage);
            if (converted.Length == 0)
                return this;

            int resultLength = Math.Min(
                MaximumLength,
                checked(Length + converted.Length));
            int insertedLength = Math.Min(
                converted.Length,
                resultLength - zeroBasedIndex);
            int tailLength = Math.Min(
                Length - zeroBasedIndex,
                resultLength - zeroBasedIndex - insertedLength);
            byte[] result = new byte[resultLength];
            AsSpan().Slice(0, zeroBasedIndex).CopyTo(result);
            converted.AsSpan().Slice(0, insertedLength)
                .CopyTo(result.AsSpan(zeroBasedIndex));
            if (tailLength > 0)
            {
                AsSpan().Slice(zeroBasedIndex, tailLength).CopyTo(
                    result.AsSpan(zeroBasedIndex + insertedLength));
            }
            return FromBytes(result, CodePage, MaximumLength);
        }

        public ShortString Remove(int zeroBasedIndex, int count)
        {
            ValidateRange(zeroBasedIndex, count, Length);
            if (count == 0)
                return this;

            byte[] result = new byte[Length - count];
            AsSpan().Slice(0, zeroBasedIndex).CopyTo(result);
            AsSpan().Slice(zeroBasedIndex + count)
                .CopyTo(result.AsSpan(zeroBasedIndex));
            return FromBytes(result, CodePage, MaximumLength);
        }

        public ShortString WithByte(int zeroBasedIndex, byte value)
        {
            if ((uint)zeroBasedIndex >= (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(zeroBasedIndex));
            if (FBytes[zeroBasedIndex] == value)
                return this;

            byte[] result = ToByteArray();
            result[zeroBasedIndex] = value;
            return FromBytes(result, CodePage, MaximumLength);
        }

        public ShortString WithLength(int newLength)
        {
            if (newLength < 0 || newLength > MaximumLength)
                throw new ArgumentOutOfRangeException(nameof(newLength));
            if (newLength == Length)
                return this;

            byte[] result = new byte[newLength];
            AsSpan().Slice(0, Math.Min(Length, newLength)).CopyTo(result);
            return FromBytes(result, CodePage, MaximumLength);
        }

        internal ShortString WithMovedBytes(
            ReadOnlySpan<byte> source,
            int destinationByteOffset)
        {
            if (destinationByteOffset < 0 ||
                destinationByteOffset > Length - source.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(destinationByteOffset));
            }

            byte[] result = ToByteArray();
            source.CopyTo(result.AsSpan(destinationByteOffset));
            return FromBytes(result, CodePage, MaximumLength);
        }

        public static void SetByte(
            ref ShortString? value,
            int zeroBasedIndex,
            byte byteValue)
        {
            value = Normalize(value).WithByte(zeroBasedIndex, byteValue);
        }

        public static void SetLength(
            ref ShortString? value,
            int newLength)
        {
            value = Normalize(value).WithLength(newLength);
        }

        public static void SetLengthByte(
            ref ShortString? value,
            byte newLength)
        {
            SetLength(ref value, newLength);
        }

        public static void Assign(
            ref ShortString? destination,
            ShortString? source)
        {
            ShortString actual = Normalize(source);
            int maximumLength = destination?.MaximumLength ??
                actual.MaximumLength;
            Assign(ref destination, actual, maximumLength);
        }

        public static void Assign(
            ref ShortString? destination,
            ShortString? source,
            int maximumLength)
        {
            ShortString actual = Normalize(source);
            ushort targetCodePage = destination?.CodePage ?? actual.CodePage;
            ShortString converted = ConvertForTarget(actual, targetCodePage);
            destination = FromBytes(
                converted.AsSpan(),
                targetCodePage,
                maximumLength);
        }

        public static void Assign(
            ref ShortString? destination,
            string? source)
        {
            int maximumLength = destination?.MaximumLength ??
                DefaultMaximumLength;
            Assign(ref destination, source, maximumLength);
        }

        public static void Assign(
            ref ShortString? destination,
            string? source,
            int maximumLength)
        {
            ushort targetCodePage = destination?.CodePage ??
                AnsiStringSettings.DefaultCodePage;
            destination = FromString(
                source,
                targetCodePage,
                maximumLength);
        }

        public bool Equals(ShortString? other)
            => other is not null && AsSpan().SequenceEqual(other.AsSpan());

        private bool EqualsString(string? other)
            => other is not null && Equals(FromString(other, CodePage, MaximumLength));

        public override bool Equals(object? obj)
            => obj is ShortString other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            foreach (byte value in AsSpan())
                hash.Add(value);
            return hash.ToHashCode();
        }

        public int CompareTo(ShortString? other)
        {
            if (other is null)
                return 1;

            ReadOnlySpan<byte> left = AsSpan();
            ReadOnlySpan<byte> right = other.AsSpan();
            int commonLength = Math.Min(left.Length, right.Length);
            for (int index = 0; index < commonLength; index++)
            {
                int difference = left[index] - right[index];
                if (difference != 0)
                    return difference;
            }

            return left.Length.CompareTo(right.Length);
        }

        public IEnumerator<byte> GetEnumerator()
        {
            for (int index = 0; index < Length; index++)
                yield return FBytes[index];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static implicit operator ShortString(string? value)
            => FromString(value);

        public static implicit operator ShortString(byte value)
            => FromBytes(new[] { value });

        public static explicit operator string(ShortString? value)
            => Normalize(value).Decode();

        public static explicit operator byte[](ShortString? value)
            => Normalize(value).ToByteArray();

        public static explicit operator ShortString(byte[]? value)
            => FromBytes(value ?? Array.Empty<byte>());

        public static explicit operator AnsiString(ShortString? value)
            => Normalize(value).ToAnsiString();

        public static explicit operator ShortString(AnsiString? value)
            => FromAnsiString(value);

        public static ShortString operator +(
            ShortString? left,
            ShortString? right)
        {
            ShortString actualLeft = Normalize(left);
            ShortString actualRight = ConvertForTarget(
                Normalize(right),
                actualLeft.CodePage);
            int resultLength = Math.Min(
                actualLeft.MaximumLength,
                actualLeft.Length + actualRight.Length);
            byte[] result = new byte[resultLength];
            actualLeft.AsSpan().CopyTo(result);
            int remaining = resultLength - actualLeft.Length;
            if (remaining > 0)
                actualRight.AsSpan().Slice(0, remaining)
                    .CopyTo(result.AsSpan(actualLeft.Length));
            return FromBytes(result, actualLeft.CodePage, actualLeft.MaximumLength);
        }

        public static ShortString operator +(ShortString? left, string? right)
        {
            ShortString actualLeft = Normalize(left);
            return actualLeft + FromString(
                right,
                actualLeft.CodePage,
                actualLeft.MaximumLength);
        }

        public static ShortString operator +(string? left, ShortString? right)
        {
            ShortString actualRight = Normalize(right);
            return FromString(
                left,
                actualRight.CodePage,
                actualRight.MaximumLength) + actualRight;
        }

        public static bool operator ==(ShortString? left, ShortString? right)
        {
            if (ReferenceEquals(left, right))
                return true;
            return Normalize(left).AsSpan().SequenceEqual(Normalize(right).AsSpan());
        }

        public static bool operator !=(ShortString? left, ShortString? right)
            => !(left == right);

        public static bool operator ==(ShortString? left, string? right)
            => Normalize(left).EqualsString(right ?? string.Empty);

        public static bool operator !=(ShortString? left, string? right)
            => !(left == right);

        public static bool operator ==(string? left, ShortString? right)
            => right == left;

        public static bool operator !=(string? left, ShortString? right)
            => !(right == left);

        public static bool operator <(ShortString? left, ShortString? right)
            => Normalize(left).CompareTo(Normalize(right)) < 0;

        public static bool operator >(ShortString? left, ShortString? right)
            => Normalize(left).CompareTo(Normalize(right)) > 0;

        public static bool operator <=(ShortString? left, ShortString? right)
            => Normalize(left).CompareTo(Normalize(right)) <= 0;

        public static bool operator >=(ShortString? left, ShortString? right)
            => Normalize(left).CompareTo(Normalize(right)) >= 0;

        internal static ShortString Normalize(ShortString? value)
            => value ?? Empty;

        private static ShortString ConvertForTarget(
            ShortString value,
            ushort targetCodePage)
        {
            if (value.CodePage == targetCodePage)
                return value;

            return FromString(
                value.Decode(),
                targetCodePage,
                value.MaximumLength);
        }

        private static byte[] Encode(string value, ushort codePage)
        {
            return AnsiStringSettings
                .GetEncoding(codePage)
                .GetBytes(value);
        }

        private static void ValidateMaximumLength(int maximumLength)
        {
            if (maximumLength < 0 || maximumLength > DefaultMaximumLength)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(maximumLength),
                    "A Delphi ShortString capacity must be between 0 and 255 bytes.");
            }
        }

        private static void ValidateRange(int index, int count, int length)
        {
            if (index < 0 || index > length)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (count < 0 || count > length - index)
                throw new ArgumentOutOfRangeException(nameof(count));
        }
    }
}
