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

using System;
using System.Runtime.InteropServices;

namespace System
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Comp
    {
        public const int DelphiSizeOf = 8;

        private long FValue;

        public Comp(long Value)
        {
            FValue = Value;
        }

        public long ToInt64()
        {
            return FValue;
        }

        public static implicit operator Comp(long Value)
        {
            return new Comp(Value);
        }

        public static implicit operator long(Comp Value)
        {
            return Value.FValue;
        }

        public override string ToString()
        {
            return FValue.ToString();
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Currency
    {
        public const int DelphiSizeOf = 8;

        private const decimal Scale = 10000m;

        // Delphi Currency stores the value as an Int64 scaled by 10000.
        private long FRawValue;

        private Currency(long RawValue, bool IsRawValue)
        {
            FRawValue = RawValue;
        }

        public Currency(decimal Value)
        {
            FRawValue = checked(
                (long)Math.Round(
                    Value * Scale,
                    0,
                    MidpointRounding.ToEven));
        }

        public static Currency FromRawValue(long RawValue)
        {
            return new Currency(RawValue, true);
        }

        public long ToRawValue()
        {
            return FRawValue;
        }

        public decimal ToDecimal()
        {
            return FRawValue / Scale;
        }

        public static implicit operator Currency(decimal Value)
        {
            return new Currency(Value);
        }

        public static implicit operator Currency(int Value)
        {
            return new Currency(Value);
        }

        public static implicit operator Currency(long Value)
        {
            return new Currency(Value);
        }

        public static implicit operator decimal(Currency Value)
        {
            return Value.ToDecimal();
        }

        public static Currency operator +(Currency Left, Currency Right)
        {
            return FromRawValue(
                checked(Left.FRawValue + Right.FRawValue));
        }

        public static Currency operator -(Currency Left, Currency Right)
        {
            return FromRawValue(
                checked(Left.FRawValue - Right.FRawValue));
        }

        public static Currency operator -(Currency Value)
        {
            return FromRawValue(checked(-Value.FRawValue));
        }

        public static bool operator ==(Currency Left, Currency Right)
        {
            return Left.FRawValue == Right.FRawValue;
        }

        public static bool operator !=(Currency Left, Currency Right)
        {
            return Left.FRawValue != Right.FRawValue;
        }

        public override bool Equals(object Obj)
        {
            return Obj is Currency Other &&
                FRawValue == Other.FRawValue;
        }

        public override int GetHashCode()
        {
            return FRawValue.GetHashCode();
        }

        public override string ToString()
        {
            return ToDecimal().ToString();
        }
    }

}