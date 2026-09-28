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
    public class TTextRec : DelphiFileRecord
    {
        internal global::System.IO.TextReader? Reader;
        internal global::System.IO.TextWriter? Writer;

        private bool FOwnsReader;
        private bool FOwnsWriter;

        private global::System.Text.Encoding FEncoding =
            global::System.Text.Encoding.ASCII;

        public TTextRec()
        {
            BufSize = 128;
            BufPos = 0;
            BufEnd = 0;
            BufPtr = global::System.IntPtr.Zero;

            Buffer = new char[128];

            CodePage = 0;
            MBCSLength = 0;
            MBCSBufPos = 0;
            MBCSBuffer = new byte[6];
        }

        public uint BufSize;
        public uint BufPos;
        public uint BufEnd;
        public global::System.IntPtr BufPtr;
        public char[] Buffer;
        public ushort CodePage;
        public sbyte MBCSLength;
        public byte MBCSBufPos;
        public byte[] MBCSBuffer;

        public global::System.Text.Encoding TextEncoding
        {
            get
            {
                return FEncoding;
            }
            set
            {
                FEncoding = value
                    ?? throw new global::System.ArgumentNullException(
                        nameof(value));
            }
        }

        public static TTextRec CreateRecord()
        {
            return new TTextRec();
        }

        internal void Rewrite()
        {
            EnsureAssigned();

            /*
             * Close preserves the association established by AssignFile.
             */
            Close();

            global::System.IO.StreamWriter writer =
                new global::System.IO.StreamWriter(
                    FileName,
                    false,
                    FEncoding);

            Reader = null;
            Writer = writer;

            FOwnsReader = false;
            FOwnsWriter = true;

            Mode = fmOutput;
            BufPos = 0;
            BufEnd = 0;
        }

        internal void Append()
        {
            EnsureAssigned();
            Close();

            global::System.IO.StreamWriter writer =
                new global::System.IO.StreamWriter(
                    FileName,
                    true,
                    FEncoding);

            Reader = null;
            Writer = writer;

            FOwnsReader = false;
            FOwnsWriter = true;

            Mode = fmOutput;
            BufPos = 0;
            BufEnd = 0;
        }

        internal void Reset()
        {
            EnsureAssigned();
            Close();

            global::System.IO.StreamReader reader =
                new global::System.IO.StreamReader(
                    FileName,
                    FEncoding,
                    true);

            Reader = reader;
            Writer = null;

            FOwnsReader = true;
            FOwnsWriter = false;

            Mode = fmInput;
            BufPos = 0;
            BufEnd = 0;
        }
        
        internal string ReadString()
        {
            EnsureInput();

            global::System.Text.StringBuilder result =
                new global::System.Text.StringBuilder();

            while (true)
            {
                int value = Reader!.Peek();

                if (value < 0 || value == '\r' || value == '\n')
                    break;

                result.Append((char)Reader.Read());
            }

            return result.ToString();
        }
        
        internal string ReadNumberToken()
        {
            EnsureInput();

            int next;
            // Skip leading whitespace, including line breaks.
            while ((next = Reader!.Peek()) >= 0 && next <= ' ')
                Reader.Read();

            global::System.Text.StringBuilder result =
                new global::System.Text.StringBuilder();

            // Leave the delimiter unread so ReadLn can consume the line end.
            while ((next = Reader!.Peek()) > ' ')
                result.Append((char)Reader.Read());

            return result.ToString();
        }

        internal char ReadCharacter()
        {
            EnsureInput();

            int value = Reader!.Read();

            if (value < 0)
            {
                throw new global::System.IO.EndOfStreamException(
                    "Unexpected end of text file.");
            }

            return (char)value;
        }

        internal void AttachReader(
            global::System.IO.TextReader reader)
        {
            if (reader == null)
            {
                throw new global::System.ArgumentNullException(
                    nameof(reader));
            }

            Close();

            Reader = reader;
            Writer = null;

            FOwnsReader = false;
            FOwnsWriter = false;

            Mode = fmInput;
            BufPos = 0;
            BufEnd = 0;
        }

        internal void AttachWriter(
            global::System.IO.TextWriter writer)
        {
            if (writer == null)
            {
                throw new global::System.ArgumentNullException(
                    nameof(writer));
            }

            Close();

            Reader = null;
            Writer = writer;

            FOwnsReader = false;
            FOwnsWriter = false;

            Mode = fmOutput;
            BufPos = 0;
            BufEnd = 0;
        }

        internal void Write(string value)
        {
            EnsureOutput();
            Writer!.Write(value);
        }

        internal void WriteLine()
        {
            EnsureOutput();
            Writer!.WriteLine();
        }

        internal void WriteLine(string value)
        {
            EnsureOutput();
            Writer!.WriteLine(value);
        }

        internal string ReadLine()
        {
            EnsureInput();

            string? result = Reader!.ReadLine();

            if (result == null)
            {
                throw new global::System.IO.EndOfStreamException(
                    "Unexpected end of text file.");
            }

            return result;
        }

        internal void SkipLine()
        {
            if (Mode != fmInput || Reader == null)
            {
                throw new global::System.InvalidOperationException(
                    "The text file is not open for reading.");
            }

            Reader.ReadLine();
        }

        internal bool EndOfFile()
        {
            EnsureInput();
            return Reader!.Peek() < 0;
        }

        internal bool EndOfLine()
        {
            EnsureInput();

            int value = Reader!.Peek();

            return value < 0 ||
                   value == '\r' ||
                   value == '\n';
        }

        internal override void Close()
        {
            if (Writer != null)
            {
                if (FOwnsWriter)
                    Writer.Dispose();
                else
                    Writer.Flush();
            }

            if (Reader != null && FOwnsReader)
                Reader.Dispose();

            Reader = null;
            Writer = null;

            FOwnsReader = false;
            FOwnsWriter = false;

            Handle = global::System.IntPtr.Zero;
            Mode = fmClosed;
            BufPos = 0;
            BufEnd = 0;

            /*
             * FileName and Name must remain assigned.
             */
        }

        private void EnsureInput()
        {
            if (Mode != fmInput || Reader == null)
            {
                throw new global::System.InvalidOperationException(
                    "The text file is not open for reading.");
            }
        }

        private void EnsureOutput()
        {
            if (Mode != fmOutput || Writer == null)
            {
                throw new global::System.InvalidOperationException(
                    "The text file is not open for writing.");
            }
        }
    }
}
