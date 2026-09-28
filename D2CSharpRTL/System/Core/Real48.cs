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

using System.Runtime.InteropServices;

namespace System
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Real48
    {
        public const int DelphiSizeOf = 6;

        private byte FByte0;
        private byte FByte1;
        private byte FByte2;
        private byte FByte3;
        private byte FByte4;
        private byte FByte5;

        public static Real48 CreateRecord()
        {
            return new Real48();
        }
    }

}