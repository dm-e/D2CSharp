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
    /// <summary>Code identity of managed translations of Delphi procedure variables.</summary>
    public static class DelegatePointer
    {
        // This is a code identity, not an unmanaged callback thunk. No delegate
        // marshalling is involved, so managed Pointer parameters remain supported.
        public static Pointer CodeAddress(Delegate? procedure) => procedure is null
            ? default
            : new Pointer(procedure.Method.MethodHandle.GetFunctionPointer());
    }
}