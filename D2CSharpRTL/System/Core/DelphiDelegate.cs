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
    /// <summary>Converts structurally compatible Delphi procedural values.</summary>
    public static class DelphiDelegate
    {
        public static T Convert<T>(Delegate value) where T : Delegate
        {
            if (value == null) return null;
            Delegate result = null;
            foreach (Delegate item in value.GetInvocationList())
                result = Delegate.Combine(result, Delegate.CreateDelegate(typeof(T), item.Target, item.Method));
            return (T)result;
        }
    }
}
