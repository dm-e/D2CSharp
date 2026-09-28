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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
 public static class ObjectExtensions
 {
  public static bool AsBoolean(this object obj)
  {
   if (obj == null)
    return false;

   if (obj is bool)
    return (bool)obj;

   bool result;
   if (bool.TryParse(obj.ToString(), out result))
    return result;

   throw new InvalidCastException("Cannot convert to boolean.");
  }
  public static int AsInteger(this object obj)
  {
   if (obj == null)
    return 0;

   if (obj is int)
    return (int)obj;

   int result;
   if (int.TryParse(obj.ToString(), out result))
    return result;

   throw new InvalidCastException("Cannot convert to integer.");
  }
 }

}
