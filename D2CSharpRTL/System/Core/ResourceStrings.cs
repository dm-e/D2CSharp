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

using System.Collections.Concurrent;

namespace System
{
    public static partial class SystemInterface
    {
        private static readonly ConcurrentDictionary<string, Pointer<TResStringRec>>
            ResourceStringLocations = new(StringComparer.OrdinalIgnoreCase);

        // Each Delphi declaration has its own stable address, even when two
        // resources contain the same message.
        public static Pointer<TResStringRec> ResourceStringAddress(string declaration, string message)
        {
            return ResourceStringLocations.GetOrAdd(declaration,
                static (_, value) => new Pointer<TResStringRec>(new TResStringRec(value)), message);
        }
    }
}
