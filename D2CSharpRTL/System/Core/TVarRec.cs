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

using System.Globalization;
using static System.SystemInterface;

namespace System
{
    public enum TVarRecType
    {
        vtInteger = 0,
        vtBoolean = 1,
        vtChar = 2,
        vtExtended = 3,
        vtString = 4,
        vtPointer = 5,
        vtPChar = 6,
        vtObject = 7,
        vtClass = 8,
        vtWideChar = 9,
        vtPWideChar = 10,
        vtAnsiString = 11,
        vtCurrency = 12,
        vtVariant = 13,
        vtInterface = 14,
        vtWideString = 15,
        vtInt64 = 16,
        vtUnicodeString = 17
    }

    /// <summary>
    /// Managed representation of Delphi's TVarRec, used for array of const.
    ///
    /// The implementation preserves the Delphi VType information explicitly.
    /// It is not a binary copy of Delphi's variant record layout. Fields that
    /// are pointers in Delphi are represented by managed values or pointer views
    /// with a lifetime controlled by the translated C# code.
    /// </summary>
    public readonly struct TVarRec
    {
        /*
         * Delphi TVarRec contains one NativeInt-sized value slot followed by
         * VType and alignment padding. It is 8 bytes on Win32 and 16 bytes on
         * Win64.
         */
        public static int DelphiSizeOf
        {
            get
            {
                return 2 * IntPtr.Size;
            }
        }
        private readonly object? FValue;

        public TVarRecType VType
        {
            get;
        }

        public object? Value
        {
            get
            {
                return FValue;
            }
        }

        private TVarRec(TVarRecType vType, object? value)
        {
            VType = vType;
            FValue = value;
        }


        public object? RawValue => FValue;

        public static implicit operator TVarRec(sbyte value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(byte value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(short value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(ushort value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(int value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(uint value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(long value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(ulong value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(bool value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(TVarData value)
        {
            return FromVariant(value);
        }

        public static implicit operator TVarRec(char value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(float value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(double value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(decimal value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(Currency value)
        {
            return FromCurrency(value);
        }


        public static implicit operator TVarRec(string value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(ShortString value)
        {
            return FromShortString(value);
        }

        public static implicit operator TVarRec(AnsiString value)
        {
            return FromAnsiString(value);
        }

        public static implicit operator TVarRec(PChar value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(PAnsiChar value)
        {
            return FromPAnsiChar(value);
        }

        public static implicit operator TVarRec(Pointer value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(UntypedPointer value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(IntPtr value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(UIntPtr value)
        {
            return From(value);
        }

        public static implicit operator TVarRec(Type value)
        {
            return From(value);
        }

        public static TVarRec NullPointer => new TVarRec(TVarRecType.vtPointer, default(Pointer));

        public static TVarRec FromInteger(int value)
        {
            return new TVarRec(TVarRecType.vtInteger, value);
        }

        public static TVarRec FromBoolean(bool value)
        {
            return new TVarRec(TVarRecType.vtBoolean, value);
        }

        public static TVarRec FromChar(byte value)
        {
            return new TVarRec(TVarRecType.vtChar, value);
        }

        public static TVarRec FromChar(char value)
        {
            return new TVarRec(TVarRecType.vtWideChar, value);
        }

        public static TVarRec FromWideChar(char value)
        {
            return new TVarRec(TVarRecType.vtWideChar, value);
        }

        public static TVarRec FromExtended(double value)
        {
            return new TVarRec(TVarRecType.vtExtended, value);
        }

        public static TVarRec FromCurrency(decimal value)
        {
            return new TVarRec(TVarRecType.vtCurrency, value);
        }

        public static TVarRec FromCurrency(Currency value)
        {
            return new TVarRec(
                TVarRecType.vtCurrency,
                value.ToDecimal());
        }

        public static TVarRec FromInt64(long value)
        {
            return new TVarRec(TVarRecType.vtInt64, value);
        }

        public static TVarRec FromPointer(Pointer value)
        {
            return new TVarRec(TVarRecType.vtPointer, value);
        }

        public static TVarRec FromPointer(UntypedPointer value)
        {
            return new TVarRec(TVarRecType.vtPointer, value);
        }

        public static TVarRec FromPointer(IntPtr value)
        {
            return new TVarRec(TVarRecType.vtPointer, value);
        }

        public static TVarRec FromPointer(UIntPtr value)
        {
            return new TVarRec(TVarRecType.vtPointer, value);
        }

        public static TVarRec FromPointer<T>(Pointer<T> value)
        {
            return new TVarRec(TVarRecType.vtPointer, value.ToPointer());
        }

        public static TVarRec FromPChar(PChar value)
        {
            return new TVarRec(TVarRecType.vtPWideChar, value);
        }

        public static TVarRec FromUnicodeString(string? value)
        {
            return new TVarRec(TVarRecType.vtUnicodeString, value ?? string.Empty);
        }

        public static TVarRec FromWideString(string? value)
        {
            return new TVarRec(TVarRecType.vtWideString, value ?? string.Empty);
        }

        public static TVarRec FromAnsiString(AnsiString? value)
        {
            return new TVarRec(
                TVarRecType.vtAnsiString,
                value ?? AnsiString.Empty);
        }

        public static TVarRec FromObject(object? value)
        {
            return new TVarRec(TVarRecType.vtObject, value);
        }

        public static TVarRec FromClass(Type? value)
        {
            return new TVarRec(TVarRecType.vtClass, value);
        }

        public static TVarRec FromVariant(object? value)
        {
            return new TVarRec(TVarRecType.vtVariant, value);
        }

        public static TVarRec FromInterface(object? value)
        {
            return new TVarRec(TVarRecType.vtInterface, value);
        }

        public static TVarRec FromString(string value)
        {
            return FromUnicodeString(value);
        }

        public static TVarRec FromShortString(ShortString? value)
        {
            return new TVarRec(
                TVarRecType.vtString,
                value ?? ShortString.Empty);
        }

        public static TVarRec FromAnsiString(
            string? value,
            ushort codePage = 0)
        {
            return FromAnsiString(
                AnsiString.FromString(value, codePage));
        }

        //public static TVarRec FromWideString(string value)
        //{
        //    return new TVarRec(
        //        TVarRecType.vtWideString,
        //        value ?? string.Empty);
        //}

        //public static TVarRec FromUnicodeString(string value)
        //{
        //    return new TVarRec(
        //        TVarRecType.vtUnicodeString,
        //        value ?? string.Empty);
        //}

        //public static TVarRec FromPChar(PChar value)
        //{
        //    return FromPWideChar(value);
        //}

        public static TVarRec FromPAnsiChar(PAnsiChar value)
        {
            return new TVarRec(
                TVarRecType.vtPChar,
                value);
        }

        public static TVarRec FromPWideChar(PChar value)
        {
            return new TVarRec(
                TVarRecType.vtPWideChar,
                value);
        }

        //public static TVarRec FromWideChar(char value)
        //{
        //    return new TVarRec(
        //        TVarRecType.vtWideChar,
        //        value);
        //}

        //public static TVarRec FromChar(char value)
        //{
        //    return FromWideChar(value);
        //}

        public static TVarRec FromAnsiChar(byte value)
        {
            return new TVarRec(
                TVarRecType.vtChar,
                value);
        }

        public static TVarRec From(TVarRec value)
        {
            return value;
        }

        public static TVarRec From(int value)
        {
            return FromInteger(value);
        }

        public static TVarRec From(uint value)
        {
            return FromInteger(unchecked((int)value));
        }

        public static TVarRec From(short value)
        {
            return FromInteger(value);
        }

        public static TVarRec From(ushort value)
        {
            return FromInteger(value);
        }

        public static TVarRec From(byte value)
        {
            return FromInteger(value);
        }

        public static TVarRec From(sbyte value)
        {
            return FromInteger(value);
        }

        public static TVarRec From(long value)
        {
            return FromInt64(value);
        }

        public static TVarRec From(ulong value)
        {
            return FromInt64(unchecked((long)value));
        }

        public static TVarRec From(bool value)
        {
            return FromBoolean(value);
        }

        public static TVarRec From(char value)
        {
            return FromWideChar(value);
        }

        public static TVarRec From(float value)
        {
            return FromExtended(value);
        }

        public static TVarRec From(double value)
        {
            return FromExtended(value);
        }

        public static TVarRec From(decimal value)
        {
            return FromCurrency(value);
        }

        public static TVarRec From(string? value)
        {
            return FromUnicodeString(value);
        }

        public static TVarRec From(Pointer value)
        {
            return FromPointer(value);
        }

        public static TVarRec From(UntypedPointer value)
        {
            return FromPointer(value);
        }

        public static TVarRec From(PChar value)
        {
            return FromPChar(value);
        }

        public static TVarRec From(PAnsiChar value)
        {
            return FromPAnsiChar(value);
        }

        public static TVarRec From(IntPtr value)
        {
            return FromPointer(value);
        }

        public static TVarRec From(UIntPtr value)
        {
            return FromPointer(value);
        }

        public static TVarRec From(Type? value)
        {
            return FromClass(value);
        }

        public static TVarRec From<T>(Pointer<T> value)
        {
            return FromPointer(value);
        }

        public static TVarRec From(object? value)
        {
            if (value == null)
                return NullPointer;

            if (value is TVarRec varRec)
                return varRec;

            if (value is TVarData variantValue)
                return FromVariant(variantValue);

            if (value is int intValue)
                return From(intValue);
            if (value is uint uintValue)
                return From(uintValue);
            if (value is short shortValue)
                return From(shortValue);
            if (value is ushort ushortValue)
                return From(ushortValue);
            if (value is byte byteValue)
                return From(byteValue);
            if (value is sbyte sbyteValue)
                return From(sbyteValue);
            if (value is long longValue)
                return From(longValue);
            if (value is ulong ulongValue)
                return From(ulongValue);
            if (value is bool boolValue)
                return From(boolValue);
            if (value is char charValue)
                return From(charValue);
            if (value is float floatValue)
                return From(floatValue);
            if (value is double doubleValue)
                return From(doubleValue);
            if (value is decimal decimalValue)
                return From(decimalValue);
            if (value is string stringValue)
                return From(stringValue);
            if (value is ShortString shortStringValue)
                return FromShortString(shortStringValue);
            if (value is AnsiString ansiStringValue)
                return FromAnsiString(ansiStringValue);
            if (value is Pointer pointerValue)
                return From(pointerValue);
            if (value is UntypedPointer untypedPointerValue)
                return From(untypedPointerValue);
            if (value is PChar pcharValue)
                return From(pcharValue);
            if (value is PAnsiChar pansiCharValue)
                return FromPAnsiChar(pansiCharValue);
            if (value is IntPtr intPtrValue)
                return From(intPtrValue);
            if (value is UIntPtr uintPtrValue)
                return From(uintPtrValue);
            if (value is Type typeValue)
                return From(typeValue);

            if (value is Enum)
            {
                Type underlyingType = Enum.GetUnderlyingType(value.GetType());
                object converted = Convert.ChangeType(
                    value,
                    underlyingType,
                    CultureInfo.InvariantCulture);

                return From(converted);
            }

            return FromObject(value);
        }

        public static TVarRec[] FromObjectArray(object[]? values)
        {
            if (values == null || values.Length == 0)
                return Array.Empty<TVarRec>();

            TVarRec[] result = new TVarRec[values.Length];

            for (int i = 0; i < values.Length; i++)
                result[i] = From(values[i]);

            return result;
        }

        public int ToIntegerValue()
        {
            RequireType(TVarRecType.vtInteger, "Integer");

            if (Value is int)
            {
                return (int)Value;
            }

            throw CreateInvalidStoredValueException("Integer");
        }
        public uint ToCardinalValue()
        {
            return unchecked((uint)ToIntegerValue());
        }

        public bool ToBooleanValue()
        {
            RequireType(TVarRecType.vtBoolean, "Boolean");
            return (bool)Value;
        }

        public string ToStringValue()
        {
            if (!IsStringType(VType))
            {
                throw CreateInvalidCastException("string");
            }

            if (VType == TVarRecType.vtAnsiString)
                return ToAnsiStringValue().Decode();
            if (VType == TVarRecType.vtString)
                return ToShortStringValue().Decode();
            return (string)Value;
        }

        public ShortString ToShortStringValue()
        {
            RequireType(TVarRecType.vtString, "ShortString");
            return Value is ShortString value
                ? value
                : throw CreateInvalidStoredValueException("ShortString");
        }

        public AnsiString ToAnsiStringValue()
        {
            RequireType(TVarRecType.vtAnsiString, "AnsiString");
            return Value is AnsiString value
                ? value
                : throw CreateInvalidStoredValueException("AnsiString");
        }

        public string ToWideStringValue()
        {
            RequireType(TVarRecType.vtWideString, "WideString");
            return (string)Value;
        }

        public string ToUnicodeStringValue()
        {
            RequireType(TVarRecType.vtUnicodeString, "UnicodeString");
            return (string)Value;
        }

        public byte ToAnsiCharValue()
        {
            RequireType(TVarRecType.vtChar, "AnsiChar");
            return Value is byte value
                ? value
                : throw CreateInvalidStoredValueException("AnsiChar");
        }

        public char ToCharValue()
        {
            return ToWideCharValue();
        }

        public char ToWideCharValue()
        {
            RequireType(TVarRecType.vtWideChar, "WideChar");
            return (char)Value;
        }

        public PChar ToPCharValue()
        {
            return ToPWideCharValue();
        }

        public PAnsiChar ToPAnsiCharValue()
        {
            RequireType(TVarRecType.vtPChar, "PAnsiChar");
            return Value is PAnsiChar value
                ? value
                : throw CreateInvalidStoredValueException("PAnsiChar");
        }

        public PChar ToPWideCharValue()
        {
            RequireType(TVarRecType.vtPWideChar, "PWideChar");
            return (PChar)Value;
        }

        public double ToDoubleValue()
        {
            return ToExtendedValue();
        }

        public double ToExtendedValue()
        {
            RequireType(TVarRecType.vtExtended, "Extended");

            if (Value is double)
            {
                return (double)Value;
            }

            if (Value is float)
            {
                return (float)Value;
            }

            if (Value is decimal)
            {
                return (double)(decimal)Value;
            }

            if (Value is long)
            {
                return (long)Value;
            }

            if (Value is int)
            {
                return (int)Value;
            }

            throw CreateInvalidStoredValueException("Extended");
        }

        public long ToCompValue()
        {
            RequireType(TVarRecType.vtExtended, "Comp");

            if (Value is long)
            {
                return (long)Value;
            }

            throw CreateInvalidStoredValueException("Comp");
        }

        public decimal ToCurrencyValue()
        {
            RequireType(TVarRecType.vtCurrency, "Currency");
            return (decimal)Value;
        }

        public decimal ToDecimalValue()
        {
            return ToCurrencyValue();
        }

        public long ToInt64Value()
        {
            RequireType(TVarRecType.vtInt64, "Int64");
            return (long)Value;
        }

        public ulong ToUInt64Value()
        {
            return unchecked((ulong)ToInt64Value());
        }

        public object ToObjectValue()
        {
            RequireType(TVarRecType.vtObject, "TObject");
            return Value;
        }

        public object ToInterfaceValue()
        {
            RequireType(TVarRecType.vtInterface, "interface");
            return Value;
        }

        public object ToVariantValue()
        {
            RequireType(TVarRecType.vtVariant, "Variant");
            return Value;
        }

        public object ToReferenceValue()
        {
            if ((VType != TVarRecType.vtObject) &&
                (VType != TVarRecType.vtInterface) &&
                (VType != TVarRecType.vtVariant))
            {
                throw CreateInvalidCastException("reference value");
            }

            return Value;
        }

        public Pointer ToPointerValue()
        {
            RequireType(TVarRecType.vtPointer, "Pointer");

            if (Value is Pointer)
            {
                return (Pointer)Value;
            }

            if (Value is UntypedPointer)
            {
                return new Pointer((UntypedPointer)Value);
            }

            if (Value is IntPtr)
            {
                return new Pointer((IntPtr)Value, 0, false);
            }

            throw CreateInvalidStoredValueException("Pointer");
        }

        public IntPtr ToPointerIntPtrValue()
        {
            RequireType(TVarRecType.vtPointer, "Pointer");

            if (Value is IntPtr)
            {
                return (IntPtr)Value;
            }

            if (Value is Pointer)
            {
                return ((Pointer)Value).Address;
            }

            if (Value is UntypedPointer)
            {
                return ((UntypedPointer)Value).ToIntPtr();
            }

            throw CreateInvalidStoredValueException("Pointer");
        }
        public Type ToClassValue()
        {
            RequireType(TVarRecType.vtClass, "class reference");
            return (Type)Value;
        }

        private static bool IsStringType(TVarRecType type)
        {
            return (type == TVarRecType.vtString) ||
                (type == TVarRecType.vtAnsiString) ||
                (type == TVarRecType.vtWideString) ||
                (type == TVarRecType.vtUnicodeString);
        }

        private void RequireType(
            TVarRecType expectedType,
            string targetTypeName)
        {
            if (VType != expectedType)
            {
                throw CreateInvalidCastException(targetTypeName);
            }
        }

        private InvalidCastException CreateInvalidCastException(
            string targetTypeName)
        {
            return new InvalidCastException(
                "Cannot convert TVarRec type " + VType +
                " to " + targetTypeName + ".");
        }

        private InvalidCastException CreateInvalidStoredValueException(
            string targetTypeName)
        {
            string storedTypeName = Value == null
                ? "null"
                : Value.GetType().FullName;

            return new InvalidCastException(
                "TVarRec type " + VType +
                " contains an incompatible CLR value of type '" +
                storedTypeName + "' for " + targetTypeName + ".");
        }

        public int VInteger
        {
            get
            {
                return VType == TVarRecType.vtInteger
                    ? (int)FValue!
                    : throw InvalidField(nameof(VInteger));
            }
        }

        public bool VBoolean
        {
            get
            {
                return VType == TVarRecType.vtBoolean
                    ? (bool)FValue!
                    : throw InvalidField(nameof(VBoolean));
            }
        }

        public byte VChar
        {
            get
            {
                return VType == TVarRecType.vtChar
                    ? (byte)FValue!
                    : throw InvalidField(nameof(VChar));
            }
        }

        public char VWideChar
        {
            get
            {
                return VType == TVarRecType.vtWideChar
                    ? (char)FValue!
                    : throw InvalidField(nameof(VWideChar));
            }
        }

        public double VExtended
        {
            get
            {
                return VType == TVarRecType.vtExtended
                    ? (double)FValue!
                    : throw InvalidField(nameof(VExtended));
            }
        }

        public decimal VCurrency
        {
            get
            {
                return VType == TVarRecType.vtCurrency
                    ? (decimal)FValue!
                    : throw InvalidField(nameof(VCurrency));
            }
        }

        public long VInt64
        {
            get
            {
                return VType == TVarRecType.vtInt64
                    ? (long)FValue!
                    : throw InvalidField(nameof(VInt64));
            }
        }

        public Pointer VPointer
        {
            get
            {
                if (VType != TVarRecType.vtPointer)
                    throw InvalidField(nameof(VPointer));

                if (FValue is Pointer pointerValue)
                    return pointerValue;

                if (FValue is IntPtr intPtrValue)
                    return intPtrValue;

                throw InvalidField(nameof(VPointer));
            }
        }

        public PAnsiChar VPChar
        {
            get
            {
                return VType == TVarRecType.vtPChar
                    ? (PAnsiChar)FValue!
                    : throw InvalidField(nameof(VPChar));
            }
        }

        public PChar VPWideChar
        {
            get
            {
                return VType == TVarRecType.vtPWideChar
                    ? (PChar)FValue!
                    : throw InvalidField(nameof(VPWideChar));
            }
        }

        public string VUnicodeString
        {
            get
            {
                return VType == TVarRecType.vtUnicodeString
                    ? (string)FValue!
                    : throw InvalidField(nameof(VUnicodeString));
            }
        }

        public string VWideString
        {
            get
            {
                return VType == TVarRecType.vtWideString
                    ? (string)FValue!
                    : throw InvalidField(nameof(VWideString));
            }
        }

        public AnsiString VAnsiString
        {
            get
            {
                return VType == TVarRecType.vtAnsiString
                    ? (AnsiString)FValue!
                    : throw InvalidField(nameof(VAnsiString));
            }
        }

        public ShortString VString
        {
            get
            {
                return VType == TVarRecType.vtString
                    ? (ShortString)FValue!
                    : throw InvalidField(nameof(VString));
            }
        }

        public object? VObject
        {
            get
            {
                return VType == TVarRecType.vtObject
                    ? FValue
                    : throw InvalidField(nameof(VObject));
            }
        }

        public Type? VClass
        {
            get
            {
                return VType == TVarRecType.vtClass
                    ? (Type?)FValue
                    : throw InvalidField(nameof(VClass));
            }
        }

        public bool TryGetInteger(
            out bool is64Bit,
            out long signedValue,
            out ulong unsignedValue)
        {
            is64Bit = false;
            signedValue = 0;
            unsignedValue = 0;

            switch (VType)
            {
                case TVarRecType.vtInteger:
                    signedValue = VInteger;
                    unsignedValue = unchecked((uint)VInteger);
                    return true;

                case TVarRecType.vtInt64:
                    is64Bit = true;
                    signedValue = VInt64;
                    unsignedValue = unchecked((ulong)VInt64);
                    return true;
            }

            return false;
        }

        public bool TryGetInt32(out int value)
        {
            value = 0;

            if (!TryGetInteger(out _, out long signedValue, out _))
                return false;

            if (signedValue < int.MinValue || signedValue > int.MaxValue)
                return false;

            value = (int)signedValue;
            return true;
        }

        public bool TryGetFloating(
            out object value,
            out bool isCurrency)
        {
            switch (VType)
            {
                case TVarRecType.vtExtended:
                    value = VExtended;
                    isCurrency = false;
                    return true;

                case TVarRecType.vtCurrency:
                    value = VCurrency;
                    isCurrency = true;
                    return true;
            }

            value = 0.0D;
            isCurrency = false;
            return false;
        }

        public bool TryGetPointerAddress(out ulong address)
        {
            address = 0;

            switch (VType)
            {
                case TVarRecType.vtPointer:
                    if (FValue == null)
                        return true;

                    if (FValue is Pointer pointerValue)
                    {
                        using PointerPin pin = pointerValue.Pin();
                        address = unchecked((ulong)pin.Address.ToInt64());
                        return true;
                    }

                    if (FValue is UntypedPointer untypedPointerValue)
                    {
                        using PointerPin pin = untypedPointerValue.Pin();
                        address = unchecked((ulong)pin.Address.ToInt64());
                        return true;
                    }

                    if (FValue is IntPtr intPtrValue)
                    {
                        address = unchecked((ulong)intPtrValue.ToInt64());
                        return true;
                    }

                    if (FValue is UIntPtr uintPtrValue)
                    {
                        address = uintPtrValue.ToUInt64();
                        return true;
                    }

                    return false;

                case TVarRecType.vtPChar:
                    if (FValue is PAnsiChar pcharValue)
                    {
                        using PointerPin pin = pcharValue.Pin();
                        address = unchecked((ulong)pin.Address.ToInt64());
                        return true;
                    }

                    return false;

                case TVarRecType.vtPWideChar:
                    if (FValue is PChar pwideCharValue)
                    {
                        using PointerPin pin = pwideCharValue.Pin();
                        address = unchecked((ulong)pin.Address.ToInt64());
                        return true;
                    }

                    return false;
            }

            return false;
        }

        public bool TryGetString(out string value)
        {
            switch (VType)
            {
                case TVarRecType.vtChar:
                    value = ((char)VChar).ToString();
                    return true;

                case TVarRecType.vtWideChar:
                    value = VWideChar.ToString();
                    return true;

                case TVarRecType.vtWideString:
                case TVarRecType.vtUnicodeString:
                    value = FValue?.ToString() ?? string.Empty;
                    return true;

                case TVarRecType.vtString:
                    value = VString.Decode();
                    return true;

                case TVarRecType.vtAnsiString:
                    value = VAnsiString.Decode();
                    return true;

                case TVarRecType.vtPChar:
                    value = VPChar.IsNull() ? string.Empty : VPChar.ToString();
                    return true;

                case TVarRecType.vtPWideChar:
                    value = VPWideChar.IsNull() ? string.Empty : VPWideChar.ToString();
                    return true;
            }

            value = string.Empty;
            return false;
        }

        public override string ToString()
        {
            if (TryGetString(out string value))
                return value;

            return FValue?.ToString() ?? string.Empty;
        }

        private InvalidOperationException InvalidField(string fieldName)
        {
            return new InvalidOperationException(
                fieldName + " is not valid for TVarRec type " + VType + ".");
        }
    }
}
