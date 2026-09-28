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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
    public static class DelphiRecordSerializer<T>
        where T : struct
    {
        public static int Size
        {
            get
            {
                ValidateType();
                return global::System.Runtime.InteropServices.Marshal.SizeOf<T>();
            }
        }

        public static byte[] ToBytes(T value)
        {
            ValidateType();

            int size =
                global::System.Runtime.InteropServices.Marshal.SizeOf<T>();

            byte[] result = new byte[size];
            global::System.IntPtr memory =
                global::System.Runtime.InteropServices.Marshal.AllocHGlobal(size);

            try
            {
                global::System.Runtime.InteropServices.Marshal.StructureToPtr(
                    value,
                    memory,
                    false);

                global::System.Runtime.InteropServices.Marshal.Copy(
                    memory,
                    result,
                    0,
                    size);

                return result;
            }
            finally
            {
                global::System.Runtime.InteropServices.Marshal.FreeHGlobal(
                    memory);
            }
        }

        public static T FromBytes(byte[] buffer)
        {
            if (buffer == null)
                throw new global::System.ArgumentNullException(nameof(buffer));

            ValidateType();

            int size =
                global::System.Runtime.InteropServices.Marshal.SizeOf<T>();

            if (buffer.Length != size)
            {
                throw new global::System.ArgumentException(
                    "The buffer size does not match the record size.",
                    nameof(buffer));
            }

            global::System.IntPtr memory =
                global::System.Runtime.InteropServices.Marshal.AllocHGlobal(size);

            try
            {
                global::System.Runtime.InteropServices.Marshal.Copy(
                    buffer,
                    0,
                    memory,
                    size);

                return global::System.Runtime.InteropServices.Marshal
                    .PtrToStructure<T>(memory);
            }
            finally
            {
                global::System.Runtime.InteropServices.Marshal.FreeHGlobal(
                    memory);
            }
        }

        private static void ValidateType()
        {
            if (global::System.Runtime.CompilerServices.RuntimeHelpers
                .IsReferenceOrContainsReferences<T>())
            {
                throw new global::System.NotSupportedException(
                    "A Delphi typed file requires a fixed-size value type " +
                    "without managed references.");
            }
        }
    }
}
