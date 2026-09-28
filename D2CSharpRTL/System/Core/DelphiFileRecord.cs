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

namespace System
{
    public abstract class DelphiFileRecord :
        global::System.IDisposable
    {
        public const ushort fmClosed = 0xD7B0;
        public const ushort fmInput = 0xD7B1;
        public const ushort fmOutput = 0xD7B2;
        public const ushort fmInOut = 0xD7B3;

        private string FFileName = string.Empty;

        protected DelphiFileRecord()
        {
            Handle = global::System.IntPtr.Zero;
            Mode = fmClosed;
            Flags = 0;
            UserData = new byte[32];
            Name = new char[260];
        }

        public global::System.IntPtr Handle;
        public ushort Mode;
        public ushort Flags;
        public byte[] UserData;
        public char[] Name;

        internal string FileName
        {
            get
            {
                return FFileName;
            }
        }

        public bool IsAssigned
        {
            get
            {
                return FFileName.Length != 0;
            }
        }

        public bool IsOpen
        {
            get
            {
                return Mode != fmClosed;
            }
        }

        internal void Assign(string fileName)
        {
            if (fileName == null)
            {
                throw new global::System.ArgumentNullException(
                    nameof(fileName));
            }

            if (fileName.Length == 0)
            {
                throw new global::System.ArgumentException(
                    "The file name must not be empty.",
                    nameof(fileName));
            }

            if (IsOpen)
            {
                throw new global::System.InvalidOperationException(
                    "The file must be closed before AssignFile is called.");
            }

            FFileName = fileName;
            CopyName(fileName);
        }

        protected void EnsureAssigned()
        {
            if (!IsAssigned)
            {
                throw new global::System.InvalidOperationException(
                    "AssignFile must be called before opening the file.");
            }
        }

        private void CopyName(string fileName)
        {
            global::System.Array.Clear(
                Name,
                0,
                Name.Length);

            int count = global::System.Math.Min(
                fileName.Length,
                Name.Length - 1);

            for (int i = 0; i < count; i++)
                Name[i] = fileName[i];

            Name[count] = '\0';
        }

        internal void Rename(string newFileName)
        {
            if (newFileName == null)
            {
                throw new global::System.ArgumentNullException(
                    nameof(newFileName));
            }

            if (newFileName.Length == 0)
            {
                throw new global::System.ArgumentException(
                    "The new file name must not be empty.",
                    nameof(newFileName));
            }

            EnsureAssigned();

            if (IsOpen)
            {
                throw new global::System.IO.IOException(
                    "The file must be closed before it can be renamed.");
            }

            string oldFileName = FileName;

            global::System.IO.File.Move(
                oldFileName,
                newFileName);

            /*
             * Update the associated file name only after the physical
             * file has been renamed successfully.
             */
            Assign(newFileName);
        }

        internal abstract void Close();

        public void Dispose()
        {
            Close();
        }
    }
}
