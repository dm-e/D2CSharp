/*
  D2CSharp Runtime Library (RTL)

  System.TextIO.cs contains the text and file I/O implementation of
  System.SystemInterface.  It is maintained separately from the generated
  System.cs so that the generated System unit and the hand-maintained .NET
  I/O bridge remain clearly separated.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0

  Licensed under the Apache License, Version 2.0 (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at

      https://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.
*/

#nullable enable

namespace System
{
    public static partial class SystemInterface
    {
	/* Text and file intrinsics */

        /*
         * Standard Delphi text files.  They are backed by the process console
         * streams through the D2CSharp TextFile helper class.
         */
        public static readonly TextFile Input =
            TextFile.CreateInput(global::System.Console.In);

        public static readonly TextFile Output =
            TextFile.CreateOutput(global::System.Console.Out);

        public static readonly TextFile ErrOutput =
            TextFile.CreateOutput(global::System.Console.Error);

        /* Delphi System.FileMode. */
        public static byte FileMode = 2;

        public static void Assign(UntypedPointer F, string FileName)
        {
        }

        public static void AssignFile(
            global::System.DelphiFileRecord fileRecord,
            string fileName)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Assign(fileName);
        }

        public static void AssignFile(UntypedPointer F, string FileName)
        {
        }

        private static global::System.IO.FileAccess GetFileModeAccess()
        {
            int openMode = FileMode & 0x0F;

            switch (openMode)
            {
                case 0: // fmOpenRead
                    return global::System.IO.FileAccess.Read;
                case 1: // fmOpenWrite
                    return global::System.IO.FileAccess.Write;
                case 2: // fmOpenReadWrite
                    return global::System.IO.FileAccess.ReadWrite;
                case 4: // fmExclusive is a share flag, not an access mode
                    throw new global::System.NotSupportedException(
                        "Delphi FileMode access value 4 is not supported.");
                default:
                    throw new global::System.IO.IOException(
                        "Invalid Delphi FileMode access value: " + openMode.ToString());
            }
        }

        private static global::System.IO.FileShare GetFileModeShare()
        {
            int shareMode = FileMode & 0xF0;

            switch (shareMode)
            {
                case 0x00: // fmShareCompat
                case 0x10: // fmShareExclusive
                    return global::System.IO.FileShare.None;
                case 0x20: // fmShareDenyWrite
                    return global::System.IO.FileShare.Read;
                case 0x30: // fmShareDenyRead
                    return global::System.IO.FileShare.Write;
                case 0x40: // fmShareDenyNone
                    return global::System.IO.FileShare.ReadWrite;
                default:
                    throw new global::System.IO.IOException(
                        "Invalid Delphi FileMode share value: " + shareMode.ToString());
            }
        }

        public static void Reset(UntypedPointer F)
        {
        }

        public static void Reset(global::System.TTextRec fileRecord)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Reset();
        }

        public static void Reset(global::System.UntypedFile fileRecord)
        {
            Reset(fileRecord, 128);
        }

        public static void Reset(
            global::System.UntypedFile fileRecord,
            int recordSize)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Reset(recordSize, GetFileModeAccess(), GetFileModeShare());
        }

        public static void Reset<T>(global::System.TypedFile<T> fileRecord)
            where T : struct
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Reset(
                checked((int)fileRecord.RecSize),
                GetFileModeAccess(),
                GetFileModeShare());
        }

        public static void Rewrite(UntypedPointer F)
        {
        }

        public static void Rewrite(global::System.TTextRec fileRecord)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Rewrite();
        }

        public static void Rewrite(global::System.UntypedFile fileRecord)
        {
            Rewrite(fileRecord, 128);
        }

        public static void Rewrite(
            global::System.UntypedFile fileRecord,
            int recordSize)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Rewrite(recordSize);
        }

        public static void Rewrite<T>(global::System.TypedFile<T> fileRecord)
            where T : struct
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Rewrite(checked((int)fileRecord.RecSize));
        }

        public static void Append(global::System.TTextRec fileRecord)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Append();
        }

        public static void Close(UntypedPointer F)
        {
        }

        public static void CloseFile(global::System.DelphiFileRecord fileRecord)
        {
            if (fileRecord == null)
                return;

            fileRecord.Close();
        }

        public static void CloseFile(UntypedPointer F)
        {
        }

        public static void Erase(UntypedPointer F)
        {
        }

        public static void Rename(
            global::System.DelphiFileRecord fileRecord,
            string newName)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Rename(newName);
        }

        public static void Rename(
            global::System.DelphiFileRecord fileRecord,
            PChar newName)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));
            if (newName.IsNull())
                throw new global::System.ArgumentNullException(nameof(newName));

            fileRecord.Rename(newName.ToString());
        }

        public static void Rename(UntypedPointer F, string NewName)
        {
        }

        public static int Flush(global::System.TTextRec fileRecord)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.Writer?.Flush();
            return 0;
        }

        public static void SetTextBuf(ref TextFile F, UntypedPointer Buf)
        {
        }

        //# missing function body: public static void SetTextBuf(ref TextFile F, UntypedPointer Buf, int Size);

        public static bool Eof()
        {
            return Eof(Input);
        }

        public static bool Eof(global::System.TTextRec fileRecord)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            return fileRecord.EndOfFile();
        }

        public static bool Eof(global::System.TFileRec fileRecord)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            return fileRecord.EndOfFile();
        }

        public static bool Eoln()
        {
            return Eoln(Input);
        }

        public static bool Eoln(global::System.TTextRec fileRecord)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            return fileRecord.EndOfLine();
        }

        public static bool SeekEof()
        {
            return Eof();
        }

        public static bool SeekEoln()
        {
            return Eoln();
        }

        public static void Seek(UntypedPointer F, int N)
        {
        }

        public static int FilePos(UntypedPointer F)
        {
            return 0;
        }

        public static int FileSize(UntypedPointer F)
        {
            return 0;
        }

        public static void Truncate(UntypedPointer F)
        {
        }

        public static void BlockRead(UntypedPointer F, UntypedPointer Buf, int Count)
        {
        }

        public static void BlockWrite(UntypedPointer F, UntypedPointer Buf, int Count)
        {
        }

        public static void BlockRead(
            global::System.UntypedFile fileRecord,
            byte[] buffer,
            int recordCount,
            out int recordsRead)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            recordsRead = fileRecord.BlockRead(buffer, 0, recordCount);
        }

        public static void BlockWrite(
            global::System.UntypedFile fileRecord,
            byte[] buffer,
            int recordCount,
            out int recordsWritten)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            recordsWritten = fileRecord.BlockWrite(buffer, 0, recordCount);
        }

        public static void BlockRead(
            global::System.UntypedFile fileRecord,
            byte[] buffer,
            int recordCount)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.BlockRead(buffer, 0, recordCount);
        }

        public static void BlockWrite(
            global::System.UntypedFile fileRecord,
            byte[] buffer,
            int recordCount)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.BlockWrite(buffer, 0, recordCount);
        }

        public static void GetDir(byte D, ref string S)
        {
            /*
             * Drive 0 means the current drive in Delphi.  For non-zero drive
             * values the precise per-drive current-directory semantics are
             * Windows-specific.  The working RTL currently exposes the process
             * current directory, which is also the useful cross-platform
             * fallback.
             */
            S = global::System.IO.Directory.GetCurrentDirectory();
        }

        public static void ChDir(string Path)
        {
            global::System.IO.Directory.SetCurrentDirectory(Path);
        }

        /*
         * Text I/O overloads used by translated Delphi source.  TextFile is a
         * reference-type wrapper around TTextRec, so TTextRec overloads are the
         * common implementation surface.
         */
        public static void Read()
        {
        }

        public static void Read(ref string value)
        {
            Read(Input, ref value);
        }

        public static void Read(
            global::System.TTextRec fileRecord,
            ref char value)
        {
            EnsureTextFile(fileRecord);
            value = fileRecord.ReadCharacter();
        }

        public static void Read(
            global::System.TTextRec fileRecord,
            ref string value)
        {
            EnsureTextFile(fileRecord);
            value = fileRecord.ReadString();
        }

        public static void Read(
            global::System.TTextRec fileRecord,
            ref int value)
        {
            EnsureTextFile(fileRecord);
            value = int.Parse(
                fileRecord.ReadNumberToken(),
                global::System.Globalization.NumberStyles.Integer,
                global::System.Globalization.CultureInfo.InvariantCulture);
        }

        public static void Read<T>(
            global::System.TypedFile<T> fileRecord,
            ref T value)
            where T : struct
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            value = fileRecord.ReadRecord();
        }

        public static void ReadLn()
        {
            Input.SkipLine();
        }

        public static void ReadLn(ref string value)
        {
            ReadLn(Input, ref value);
        }

        public static void ReadLn(global::System.TTextRec fileRecord)
        {
            EnsureTextFile(fileRecord);
            fileRecord.SkipLine();
        }

        public static void ReadLn(
            global::System.TTextRec fileRecord,
            ref string value)
        {
            EnsureTextFile(fileRecord);
            value = fileRecord.ReadLine();
        }

        /* Preserve the spelling emitted by older mock translations. */
        public static void Readln()
        {
            ReadLn();
        }

        public static void Write()
        {
        }

        public static void Write(string? value)
        {
            Write(Output, value);
        }

        public static void Write(
            string? value,
            int minWidth)
        {
            Write(Output, value, minWidth);
        }

        public static void Write(
            global::System.TTextRec fileRecord,
            string? value)
        {
            EnsureTextFile(fileRecord);
            fileRecord.Write(value ?? string.Empty);
        }

        public static void Write(
            global::System.TTextRec fileRecord,
            string? value,
            int minWidth)
        {
            EnsureTextFile(fileRecord);
            fileRecord.Write(ApplyWriteWidth(value ?? string.Empty, minWidth));
        }

        /* Preserve value types before implicit conversions to AnsiString. */
        public static void Write<T>(
            global::System.TTextRec fileRecord,
            T value)
            where T : struct
        {
            EnsureTextFile(fileRecord);
            fileRecord.Write(FormatUnformattedWriteValue(value));
        }

        public static void Write<T>(
            global::System.TTextRec fileRecord,
            T value,
            int minWidth)
            where T : struct
        {
            EnsureTextFile(fileRecord);
            fileRecord.Write(
                ApplyWriteWidth(
                    FormatUnformattedWriteValue(value),
                    minWidth));
        }

        public static void Write(
            global::System.TTextRec fileRecord,
            double value,
            int minWidth,
            int decimalPlaces)
        {
            EnsureTextFile(fileRecord);
            fileRecord.Write(
                FormatFixedPoint(value, minWidth, decimalPlaces));
        }

        public static void Write(
            global::System.TTextRec fileRecord,
            float value,
            int minWidth,
            int decimalPlaces)
        {
            Write(fileRecord, (double)value, minWidth, decimalPlaces);
        }

        public static void Write(
            global::System.TTextRec fileRecord,
            decimal value,
            int minWidth,
            int decimalPlaces)
        {
            EnsureTextFile(fileRecord);

            if (decimalPlaces < 0)
            {
                fileRecord.Write(
                    ApplyWriteWidth(
                        value.ToString(global::System.Globalization.CultureInfo.InvariantCulture),
                        minWidth));
                return;
            }

            int actualDecimalPlaces = global::System.Math.Min(decimalPlaces, 216);
            string text = value.ToString(
                "F" + actualDecimalPlaces.ToString(
                    global::System.Globalization.CultureInfo.InvariantCulture),
                global::System.Globalization.CultureInfo.InvariantCulture);

            fileRecord.Write(ApplyWriteWidth(text, minWidth));
        }

        public static void Write<T>(
            global::System.TypedFile<T> fileRecord,
            T value)
            where T : struct
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));

            fileRecord.WriteRecord(value);
        }

        public static void WriteLn()
        {
            Output.WriteLine();
        }

        public static void WriteLn(string? value)
        {
            WriteLn(Output, value);
        }

        public static void WriteLn(
            string? value,
            int minWidth)
        {
            WriteLn(Output, value, minWidth);
        }

        public static void WriteLn(global::System.TTextRec fileRecord)
        {
            EnsureTextFile(fileRecord);
            fileRecord.WriteLine();
        }

        public static void WriteLn(
            global::System.TTextRec fileRecord,
            string? value)
        {
            EnsureTextFile(fileRecord);
            fileRecord.WriteLine(value ?? string.Empty);
        }

        public static void WriteLn(
            global::System.TTextRec fileRecord,
            string? value,
            int minWidth)
        {
            EnsureTextFile(fileRecord);
            fileRecord.WriteLine(ApplyWriteWidth(value ?? string.Empty, minWidth));
        }

        public static void WriteLn<T>(
            global::System.TTextRec fileRecord,
            T value)
            where T : struct
        {
            EnsureTextFile(fileRecord);
            fileRecord.Write(FormatUnformattedWriteValue(value));
            fileRecord.WriteLine();
        }

        public static void WriteLn<T>(
            global::System.TTextRec fileRecord,
            T value,
            int minWidth)
            where T : struct
        {
            EnsureTextFile(fileRecord);
            fileRecord.Write(
                ApplyWriteWidth(
                    FormatUnformattedWriteValue(value),
                    minWidth));
            fileRecord.WriteLine();
        }

        public static void WriteLn(
            global::System.TTextRec fileRecord,
            double value,
            int minWidth,
            int decimalPlaces)
        {
            Write(fileRecord, value, minWidth, decimalPlaces);
            fileRecord.WriteLine();
        }

        public static void WriteLn(
            global::System.TTextRec fileRecord,
            float value,
            int minWidth,
            int decimalPlaces)
        {
            Write(fileRecord, value, minWidth, decimalPlaces);
            fileRecord.WriteLine();
        }

        public static void WriteLn(
            global::System.TTextRec fileRecord,
            decimal value,
            int minWidth,
            int decimalPlaces)
        {
            Write(fileRecord, value, minWidth, decimalPlaces);
            fileRecord.WriteLine();
        }

        /* Preserve the spelling emitted by older mock translations. */
        public static void Writeln()
        {
            WriteLn();
        }

        private static void EnsureTextFile(global::System.TTextRec fileRecord)
        {
            if (fileRecord == null)
                throw new global::System.ArgumentNullException(nameof(fileRecord));
        }

        private static string FormatUnformattedWriteValue(object? value)
        {
            if (value == null)
                return string.Empty;

            if (value is bool booleanValue)
                return booleanValue ? "True" : "False";

            if (value is global::System.IFormattable formattable)
            {
                return formattable.ToString(
                           null,
                           global::System.Globalization.CultureInfo.InvariantCulture)
                       ?? string.Empty;
            }

            return value.ToString() ?? string.Empty;
        }

        private static string ApplyWriteWidth(
            string value,
            int minWidth)
        {
            if (minWidth < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(minWidth));

            return value.Length < minWidth
                ? value.PadLeft(minWidth)
                : value;
        }

        private static string FormatFixedPoint(
            double value,
            int minWidth,
            int decimalPlaces)
        {
            if (decimalPlaces < 0)
            {
                return ApplyWriteWidth(
                    value.ToString(
                        "E",
                        global::System.Globalization.CultureInfo.InvariantCulture),
                    minWidth);
            }

            int actualDecimalPlaces = global::System.Math.Min(decimalPlaces, 216);
            string result = value.ToString(
                "F" + actualDecimalPlaces.ToString(
                    global::System.Globalization.CultureInfo.InvariantCulture),
                global::System.Globalization.CultureInfo.InvariantCulture);

            return ApplyWriteWidth(result, minWidth);
        }
    }
}
