/*
  D2CSharp Runtime Library (RTL)

  AnsiString adapters for the System.TextIO.cs Unicode core.

  Only adapters that require a real ref AnsiString parameter live here.
  Value-parameter Write/WriteLn overloads are deliberately not duplicated:
  keeping them in the AnsiString adapter layer causes ambiguous overload
  resolution for string literals and TextFile values.

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
    public static partial class SystemInterface
    {
        public static void Read(ref AnsiString value)
        {
            string text = string.Empty;
            Read(ref text);
            value = text;
        }

        public static void Read(
            TTextRec fileRecord,
            ref AnsiString value)
        {
            string text = string.Empty;
            Read(fileRecord, ref text);
            value = text;
        }

        public static void ReadLn(ref AnsiString value)
        {
            string text = string.Empty;
            ReadLn(ref text);
            value = text;
        }

        public static void ReadLn(
            TTextRec fileRecord,
            ref AnsiString value)
        {
            string text = string.Empty;
            ReadLn(fileRecord, ref text);
            value = text;
        }
    }
}
