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
    public class TFileRec : DelphiFileRecord
    {
        internal FileStream FStream;

        public TFileRec()
        {
            RecSize = 128;
            BufSize = 0;
            BufPos = 0;
            BufEnd = 0;
            BufPtr = IntPtr.Zero;

            OpenFunc = IntPtr.Zero;
            InOutFunc = IntPtr.Zero;
            FlushFunc = IntPtr.Zero;
            CloseFunc = IntPtr.Zero;
        }

        public uint RecSize;

        public uint BufSize;

        public uint BufPos;

        public uint BufEnd;

        public IntPtr BufPtr;

        public IntPtr OpenFunc;

        public IntPtr InOutFunc;

        public IntPtr FlushFunc;

        public IntPtr CloseFunc;

        public static TFileRec CreateRecord()
        {
            return new TFileRec();
        }

        internal void Rewrite(int recordSize)
        {
            if (recordSize <= 0)
            {
                throw new global::System.IO.IOException(
                    "Invalid record size.");
            }

            EnsureAssigned();
            Close();

            RecSize = checked((uint)recordSize);

            FStream = new global::System.IO.FileStream(
                FileName,
                global::System.IO.FileMode.Create,
                global::System.IO.FileAccess.Write,
                global::System.IO.FileShare.None);

            Mode = fmOutput;
        }

        internal void Reset(
            int recordSize,
            global::System.IO.FileAccess access,
            global::System.IO.FileShare share)
        {
            if (recordSize <= 0)
            {
                throw new global::System.IO.IOException(
                    "Invalid record size.");
            }

            EnsureAssigned();
            Close();

            RecSize = checked((uint)recordSize);

            FStream = new global::System.IO.FileStream(
                FileName,
                global::System.IO.FileMode.Open,
                access,
                share);

            switch (access)
            {
                case global::System.IO.FileAccess.Read:
                    Mode = fmInput;
                    break;

                case global::System.IO.FileAccess.Write:
                    Mode = fmOutput;
                    break;

                case global::System.IO.FileAccess.ReadWrite:
                    Mode = fmInOut;
                    break;

                default:
                    Close();

                    throw new global::System.ArgumentOutOfRangeException(
                        nameof(access));
            }
        }

        internal int BlockRead(byte[] buffer, int offset, int recordCount)
        {
            EnsureOpen();

            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            int byteCount = checked(recordCount * (int)RecSize);
            int bytesRead = FStream.Read(buffer, offset, byteCount);

            return bytesRead / (int)RecSize;
        }

        internal int BlockWrite(byte[] buffer, int offset, int recordCount)
        {
            EnsureOpen();

            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            int byteCount = checked(recordCount * (int)RecSize);

            FStream.Write(buffer, offset, byteCount);

            return recordCount;
        }

        internal long FilePosition()
        {
            EnsureOpen();
            return FStream.Position / RecSize;
        }

        internal long FileRecordCount()
        {
            EnsureOpen();
            return FStream.Length / RecSize;
        }

        internal void Seek(long recordNumber)
        {
            EnsureOpen();

            FStream.Seek(
                checked(recordNumber * RecSize),
                SeekOrigin.Begin);
        }

        internal void Truncate()
        {
            EnsureOpen();
            FStream.SetLength(FStream.Position);
        }

        internal bool EndOfFile()
        {
            EnsureReadable();

            return FStream!.Position >= FStream.Length;
        }

        internal override void Close()
        {
            if (FStream != null)
            {
                FStream.Dispose();
                FStream = null;
            }

            Handle = IntPtr.Zero;
            Mode = fmClosed;
            BufPos = 0;
            BufEnd = 0;
        }

        protected void EnsureOpen()
        {
            if (FStream == null || Mode == fmClosed)
            {
                throw new global::System.InvalidOperationException(
                    "The file is not open.");
            }
        }

        protected void EnsureReadable()
        {
            EnsureOpen();

            if (FStream == null || !FStream.CanRead)
            {
                throw new global::System.InvalidOperationException(
                    "The file is not open for reading.");
            }
        }

        protected void EnsureWritable()
        {
            EnsureOpen();

            if (FStream == null || !FStream.CanWrite)
            {
                throw new global::System.InvalidOperationException(
                    "The file is not open for writing.");
            }
        }
    }
}
