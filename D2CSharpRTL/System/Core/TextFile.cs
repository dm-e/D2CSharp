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
    public sealed class TextFile : TTextRec
    {
        public new static TextFile CreateRecord()
        {
            return new TextFile();
        }

        internal static TextFile CreateInput(
            global::System.IO.TextReader reader)
        {
            TextFile result = new TextFile();
            result.AttachReader(reader);
            return result;
        }

        internal static TextFile CreateOutput(
            global::System.IO.TextWriter writer)
        {
            TextFile result = new TextFile();
            result.AttachWriter(writer);
            return result;
        }
    }
}