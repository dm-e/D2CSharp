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
using System.Threading;

namespace System
{
    public enum AnsiStringConversionMode
    {
        DelphiCompatible,
        Strict
    }

    /// <summary>
    /// Process-wide defaults used when Delphi code refers to an unqualified
    /// AnsiString (code page 0 / CP_ACP).
    /// </summary>
    public static class AnsiStringSettings
    {
        public const ushort SystemDefaultCodePage = 0;
        public const ushort Utf8CodePage = 65001;
        public const ushort RawByteStringCodePage = 65535;

        private static int FDefaultCodePage = 1252;
        private static int FConversionMode =
            (int)AnsiStringConversionMode.DelphiCompatible;

        static AnsiStringSettings()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// Effective Windows ANSI code page used for code page 0. The default
        /// is 1252, matching a typical US Windows installation.
        /// </summary>
        public static ushort DefaultCodePage
        {
            get => checked((ushort)Volatile.Read(ref FDefaultCodePage));
            set
            {
                if (value == SystemDefaultCodePage ||
                    value == RawByteStringCodePage)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "The configured default must be a concrete text code page.");
                }

                // Validate before publishing the setting.
                _ = CreateEncoding(value, ConversionMode);
                Volatile.Write(ref FDefaultCodePage, value);
            }
        }

        public static AnsiStringConversionMode ConversionMode
        {
            get => (AnsiStringConversionMode)Volatile.Read(ref FConversionMode);
            set
            {
                if (!Enum.IsDefined(typeof(AnsiStringConversionMode), value))
                    throw new ArgumentOutOfRangeException(nameof(value));

                Volatile.Write(ref FConversionMode, (int)value);
            }
        }

        public static ushort ResolveCodePage(ushort codePage)
        {
            return codePage == SystemDefaultCodePage
                ? DefaultCodePage
                : codePage;
        }

        public static Encoding GetEncoding(
            ushort codePage,
            AnsiStringConversionMode? mode = null)
        {
            ushort effectiveCodePage = ResolveCodePage(codePage);

            if (effectiveCodePage == RawByteStringCodePage)
            {
                throw new InvalidOperationException(
                    "RawByteString bytes have no intrinsic text encoding. " +
                    "Supply a concrete code page before converting them to text.");
            }

            return CreateEncoding(
                effectiveCodePage,
                mode ?? ConversionMode);
        }

        private static Encoding CreateEncoding(
            ushort codePage,
            AnsiStringConversionMode mode)
        {
            return mode == AnsiStringConversionMode.Strict
                ? Encoding.GetEncoding(
                    codePage,
                    EncoderFallback.ExceptionFallback,
                    DecoderFallback.ExceptionFallback)
                : Encoding.GetEncoding(
                    codePage,
                    new EncoderReplacementFallback("?"),
                    new DecoderReplacementFallback("\uFFFD"));
        }
    }

    /// <summary>
    /// Immutable, byte-preserving representation of Delphi's AnsiString.
    /// The indexer and instance methods use normal zero-based C# indexes. The
    /// generator passes its already translated Index - 1 values to RTL helpers.
    /// </summary>
    public sealed class AnsiString :
        IReadOnlyList<byte>,
        IEquatable<AnsiString>,
        IComparable<AnsiString>
    {
        // The final zero is storage only and is not part of Length.
        private readonly byte[] FBuffer;

        public static AnsiString Empty => new AnsiString(
            Array.Empty<byte>(),
            AnsiStringSettings.DefaultCodePage,
            copy: true);

        public AnsiString()
            : this(
                Array.Empty<byte>(),
                AnsiStringSettings.DefaultCodePage,
                copy: true)
        {
        }

        public AnsiString(string? value)
            : this(
                Encode(
                    value ?? string.Empty,
                    AnsiStringSettings.DefaultCodePage,
                    null),
                AnsiStringSettings.DefaultCodePage,
                copy: false)
        {
        }

        public AnsiString(string? value, ushort codePage)
            : this(
                Encode(value ?? string.Empty, codePage, null),
                AnsiStringSettings.ResolveCodePage(codePage),
                copy: false)
        {
        }

        public AnsiString(byte value, ushort codePage = 0)
            : this(
                new[] { value },
                AnsiStringSettings.ResolveCodePage(codePage),
                copy: false)
        {
        }

        public AnsiString(byte[]? bytes, ushort codePage = 0)
            : this(
                bytes ?? Array.Empty<byte>(),
                AnsiStringSettings.ResolveCodePage(codePage),
                copy: true)
        {
        }

        private AnsiString(
            ReadOnlySpan<byte> bytes,
            ushort effectiveCodePage,
            bool copy)
        {
            // The copy flag documents ownership at call sites. A span cannot
            // be retained, so both paths materialize private storage.
            _ = copy;
            FBuffer = new byte[checked(bytes.Length + 1)];
            bytes.CopyTo(FBuffer);
            CodePage = effectiveCodePage;
        }

        public int Length => FBuffer.Length - 1;
        public int Count => Length;
        public bool IsEmpty => Length == 0;
        public ushort CodePage { get; }

        public byte this[int zeroBasedIndex]
        {
            get
            {
                if ((uint)zeroBasedIndex >= (uint)Length)
                    throw new ArgumentOutOfRangeException(nameof(zeroBasedIndex));

                return FBuffer[zeroBasedIndex];
            }
        }

        public static AnsiString FromBytes(
            ReadOnlySpan<byte> bytes,
            ushort codePage = 0)
        {
            return new AnsiString(
                bytes,
                AnsiStringSettings.ResolveCodePage(codePage),
                copy: true);
        }

        /// <summary>
        /// Creates an empty value carrying a concrete Delphi AnsiString code
        /// page. This is useful for translated declarations of AnsiString(N).
        /// </summary>
        public static AnsiString CreateEmpty(ushort codePage)
            => FromBytes(ReadOnlySpan<byte>.Empty, codePage);

        public static AnsiString FromString(
            string? value,
            ushort codePage = 0,
            AnsiStringConversionMode? mode = null)
        {
            ushort effectiveCodePage =
                AnsiStringSettings.ResolveCodePage(codePage);

            return new AnsiString(
                Encode(value ?? string.Empty, effectiveCodePage, mode),
                effectiveCodePage,
                copy: false);
        }

        public static AnsiString FromPAnsiChar(PAnsiChar value)
        {
            return value.IsNull()
                ? FromBytes(Array.Empty<byte>(), value.CodePage)
                : value.ToAnsiString();
        }

        public static AnsiString FromPAnsiChar(
            PAnsiChar value,
            int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));
            if (value.IsNull())
            {
                return FromBytes(
                    new byte[length],
                    value.CodePage);
            }
            if (length > value.Capacity)
                throw new ArgumentOutOfRangeException(nameof(length));

            byte[] result = new byte[length];
            for (int index = 0; index < length; index++)
                result[index] = value[index];
            return FromBytes(result, value.CodePage);
        }

        public ReadOnlySpan<byte> AsSpan()
        {
            return FBuffer.AsSpan(0, Length);
        }

        public byte[] ToByteArray()
        {
            return AsSpan().ToArray();
        }

        internal byte[] ToNullTerminatedByteArray()
        {
            return (byte[])FBuffer.Clone();
        }

        public string Decode(AnsiStringConversionMode? mode = null)
        {
            if (Length == 0)
                return string.Empty;

            return AnsiStringSettings
                .GetEncoding(CodePage, mode)
                .GetString(FBuffer, 0, Length);
        }

        public override string ToString() => Decode();

        public AnsiString Reencode(
            ushort codePage,
            AnsiStringConversionMode? mode = null)
        {
            ushort effectiveCodePage =
                AnsiStringSettings.ResolveCodePage(codePage);

            if (effectiveCodePage == CodePage)
                return this;

            return FromString(Decode(mode), effectiveCodePage, mode);
        }

        /// <summary>
        /// Changes only the code-page tag when convert is false. This mirrors
        /// Delphi SetCodePage and must be used deliberately.
        /// </summary>
        public AnsiString WithCodePage(
            ushort codePage,
            bool convert = true,
            AnsiStringConversionMode? mode = null)
        {
            ushort effectiveCodePage =
                AnsiStringSettings.ResolveCodePage(codePage);

            if (convert)
                return Reencode(effectiveCodePage, mode);

            return new AnsiString(AsSpan(), effectiveCodePage, copy: true);
        }

        public AnsiString Substring(int zeroBasedIndex)
        {
            return Substring(zeroBasedIndex, Length - zeroBasedIndex);
        }

        public AnsiString Substring(int zeroBasedIndex, int count)
        {
            ValidateRange(zeroBasedIndex, count, Length);
            return FromBytes(AsSpan().Slice(zeroBasedIndex, count), CodePage);
        }

        public int IndexOf(AnsiString? value, int zeroBasedStartIndex = 0)
        {
            if ((uint)zeroBasedStartIndex > (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(zeroBasedStartIndex));

            ReadOnlySpan<byte> needle = Normalize(value).AsSpan();
            int relative = AsSpan().Slice(zeroBasedStartIndex).IndexOf(needle);
            return relative < 0 ? -1 : zeroBasedStartIndex + relative;
        }

        public AnsiString Insert(int zeroBasedIndex, AnsiString? value)
        {
            if ((uint)zeroBasedIndex > (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(zeroBasedIndex));

            AnsiString converted = ConvertForTarget(Normalize(value), CodePage);
            if (converted.Length == 0)
                return this;

            byte[] result = new byte[checked(Length + converted.Length)];
            AsSpan().Slice(0, zeroBasedIndex).CopyTo(result);
            converted.AsSpan().CopyTo(result.AsSpan(zeroBasedIndex));
            AsSpan().Slice(zeroBasedIndex).CopyTo(
                result.AsSpan(zeroBasedIndex + converted.Length));
            return FromBytes(result, CodePage);
        }

        public AnsiString Remove(int zeroBasedIndex, int count)
        {
            ValidateRange(zeroBasedIndex, count, Length);
            if (count == 0)
                return this;

            byte[] result = new byte[Length - count];
            AsSpan().Slice(0, zeroBasedIndex).CopyTo(result);
            AsSpan().Slice(zeroBasedIndex + count).CopyTo(
                result.AsSpan(zeroBasedIndex));
            return FromBytes(result, CodePage);
        }

        public AnsiString WithByte(int zeroBasedIndex, byte value)
        {
            if ((uint)zeroBasedIndex >= (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(zeroBasedIndex));

            if (FBuffer[zeroBasedIndex] == value)
                return this;

            byte[] result = ToByteArray();
            result[zeroBasedIndex] = value;
            return FromBytes(result, CodePage);
        }

        public AnsiString WithLength(int newLength)
        {
            if (newLength < 0)
                throw new ArgumentOutOfRangeException(nameof(newLength));

            if (newLength == Length)
                return this;

            byte[] result = new byte[newLength];
            AsSpan().Slice(0, Math.Min(Length, newLength)).CopyTo(result);
            return FromBytes(result, CodePage);
        }

        internal AnsiString WithMovedBytes(
            ReadOnlySpan<byte> source,
            int destinationByteOffset)
        {
            if (destinationByteOffset < 0 ||
                destinationByteOffset > Length - source.Length)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(destinationByteOffset));
            }

            byte[] result = ToByteArray();
            source.CopyTo(result.AsSpan(destinationByteOffset));
            return FromBytes(result, CodePage);
        }

        public static void SetByte(
            ref AnsiString? value,
            int zeroBasedIndex,
            byte byteValue)
        {
            value = Normalize(value).WithByte(zeroBasedIndex, byteValue);
        }

        public static void SetLength(
            ref AnsiString? value,
            int newLength)
        {
            value = Normalize(value).WithLength(newLength);
        }

        public bool Equals(AnsiString? other)
        {
            return other is not null && AsSpan().SequenceEqual(other.AsSpan());
        }

        private bool EqualsString(string? other)
        {
            if (other is null)
                return false;

            return Equals(FromString(other, CodePage));
        }

        public override bool Equals(object? obj)
        {
            return obj is AnsiString value && Equals(value);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            foreach (byte value in AsSpan())
                hash.Add(value);
            return hash.ToHashCode();
        }

        public int CompareTo(AnsiString? other)
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
                yield return FBuffer[index];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static implicit operator AnsiString(string? value)
        {
            return FromString(value);
        }

        // AnsiChar is represented as byte in generated C#.
        public static implicit operator AnsiString(byte value)
        {
            return new AnsiString(value);
        }

        public static explicit operator string(AnsiString? value)
        {
            return Normalize(value).Decode();
        }

        public static explicit operator byte[](AnsiString? value)
        {
            return Normalize(value).ToByteArray();
        }

        public static explicit operator AnsiString(byte[]? value)
        {
            return FromBytes(value ?? Array.Empty<byte>());
        }

        public static AnsiString operator +(
            AnsiString? left,
            AnsiString? right)
        {
            AnsiString actualLeft = Normalize(left);
            AnsiString actualRight = ConvertForTarget(
                Normalize(right),
                actualLeft.CodePage);

            byte[] result = new byte[checked(
                actualLeft.Length + actualRight.Length)];
            actualLeft.AsSpan().CopyTo(result);
            actualRight.AsSpan().CopyTo(result.AsSpan(actualLeft.Length));
            return FromBytes(result, actualLeft.CodePage);
        }

        public static AnsiString operator +(AnsiString? left, string? right)
        {
            AnsiString actualLeft = Normalize(left);
            return actualLeft + FromString(right, actualLeft.CodePage);
        }

        public static AnsiString operator +(string? left, AnsiString? right)
        {
            AnsiString actualRight = Normalize(right);
            return FromString(left, actualRight.CodePage) + actualRight;
        }

        public static bool operator ==(AnsiString? left, AnsiString? right)
        {
            if (ReferenceEquals(left, right))
                return true;

            return Normalize(left).AsSpan().SequenceEqual(
                Normalize(right).AsSpan());
        }

        public static bool operator !=(AnsiString? left, AnsiString? right)
            => !(left == right);

        public static bool operator ==(AnsiString? left, string? right)
            => Normalize(left).EqualsString(right ?? string.Empty);

        public static bool operator !=(AnsiString? left, string? right)
            => !(left == right);

        public static bool operator ==(string? left, AnsiString? right)
            => right == left;

        public static bool operator !=(string? left, AnsiString? right)
            => !(right == left);

        public static bool operator <(AnsiString? left, AnsiString? right)
            => Normalize(left).CompareTo(Normalize(right)) < 0;

        public static bool operator >(AnsiString? left, AnsiString? right)
            => Normalize(left).CompareTo(Normalize(right)) > 0;

        public static bool operator <=(AnsiString? left, AnsiString? right)
            => Normalize(left).CompareTo(Normalize(right)) <= 0;

        public static bool operator >=(AnsiString? left, AnsiString? right)
            => Normalize(left).CompareTo(Normalize(right)) >= 0;

        internal static AnsiString Normalize(AnsiString? value)
        {
            return value ?? Empty;
        }

        private static AnsiString ConvertForTarget(
            AnsiString value,
            ushort targetCodePage)
        {
            return value.CodePage == targetCodePage
                ? value
                : value.Reencode(targetCodePage);
        }

        private static byte[] Encode(
            string value,
            ushort codePage,
            AnsiStringConversionMode? mode)
        {
            return AnsiStringSettings
                .GetEncoding(codePage, mode)
                .GetBytes(value);
        }

        private static void ValidateRange(
            int index,
            int count,
            int length)
        {
            if (index < 0 || index > length)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (count < 0 || count > length - index)
                throw new ArgumentOutOfRangeException(nameof(count));
        }
    }
}
