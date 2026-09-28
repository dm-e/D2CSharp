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
    public sealed class TypedFile<T> : TFileRec
        where T : struct
    {
        public TypedFile()
        {
            RecSize = checked(
                (uint)DelphiRecordSerializer<T>.Size);
        }

        public new static TypedFile<T> CreateRecord()
        {
            return new TypedFile<T>();
        }

        internal T ReadRecord()
        {
            EnsureReadable();

            int recordSize = checked((int)RecSize);
            byte[] buffer = new byte[recordSize];

            int offset = 0;

            while (offset < recordSize)
            {
                int count = FStream!.Read(
                    buffer,
                    offset,
                    recordSize - offset);

                if (count == 0)
                {
                    throw new global::System.IO.EndOfStreamException(
                        "Unexpected end of typed-file record.");
                }

                offset += count;
            }

            return DelphiRecordSerializer<T>.FromBytes(buffer);
        }

        internal void WriteRecord(T value)
        {
            EnsureWritable();

            byte[] buffer =
                DelphiRecordSerializer<T>.ToBytes(value);

            if (buffer.Length != checked((int)RecSize))
            {
                throw new global::System.IO.IOException(
                    "The serialized value size does not match the typed-file record size.");
            }

            FStream!.Write(
                buffer,
                0,
                buffer.Length);
        }

    }
}
