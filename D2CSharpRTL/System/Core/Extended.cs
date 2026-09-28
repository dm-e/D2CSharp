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

    public struct Extended
    {
        private double FValue;

#if D2C_TARGET_WIN64
    public const int DelphiSizeOf = 8;
#else
        public const int DelphiSizeOf = 10;
#endif

        public Extended(double Value)
        {
            FValue = Value;
        }

        public double ToDouble()
        {
            return FValue;
        }

        public static implicit operator Extended(double Value)
        {
            return new Extended(Value);
        }

        public static implicit operator double(Extended Value)
        {
            return Value.FValue;
        }
    }

}