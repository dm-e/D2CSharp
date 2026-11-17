namespace System
{
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
    public static partial class SystemInterface
    {
        public static uint[] UnicodeStringToUCS4String(string value)
        {
            var result = new Collections.Generic.List<uint>();
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsHighSurrogate(value[i]) && i + 1 < value.Length && char.IsLowSurrogate(value[i + 1]))
                {
                    result.Add((uint)char.ConvertToUtf32(value[i], value[i + 1]));
                    i++;
                }
                else result.Add(value[i]);
            }
            result.Add(0); // Delphi UCS4String includes a trailing null code point.
            return result.ToArray();
        }

        public static string UCS4StringToWideString(uint[] value)
        {
            if (value == null || value.Length == 0) return string.Empty;
            var result = new Text.StringBuilder();
            // Delphi always reserves the final element for the terminator.
            int count = value.Length - 1;
            for (int i = 0; i < count; i++)
            {
                uint point = value[i];
                if (point <= 0xffff) result.Append((char)point);
                else result.Append(char.ConvertFromUtf32(checked((int)point)));
            }
            return result.ToString();
        }
    }
}
