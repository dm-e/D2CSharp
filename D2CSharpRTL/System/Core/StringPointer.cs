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
    public static class StringPointer
    {
        public static Pointer FromLocation(Ref<string> location)
        {
            ArgumentNullException.ThrowIfNull(location);
            if (string.IsNullOrEmpty(location.Value)) return default;
            return new Pointer(new UntypedPointer(PointerView.FromBacking(
                new StringCharacterBacking(location))));
        }
    }

    // A string character view is distinct from the address of a string slot.
    // Keep the character storage stable when the managed string is replaced.
    internal sealed class StringCharacterBacking : PinnableBacking
    {
        private readonly Ref<string> FLocation;
        private readonly char[] FCharacters;
        private string FPublished;

        internal StringCharacterBacking(Ref<string> location)
        {
            FLocation = location;
            FPublished = location.Value ?? string.Empty;
            FCharacters = new char[FPublished.Length + 1];
            FPublished.CopyTo(0, FCharacters, 0, FPublished.Length);
        }

        internal override nint ByteLength => checked(FCharacters.Length * sizeof(char));
        protected override object PinnedObject => FCharacters;

        private void Publish()
        {
            // An old pointer must not overwrite a subsequently reassigned string.
            if (ReferenceEquals(FLocation.Value, FPublished))
            {
                FPublished = new string(FCharacters, 0, FCharacters.Length - 1);
                FLocation.Value = FPublished;
            }
        }

        internal override byte ReadByte(nint offset)
        {
            ValidateRange(offset, 1);
            char value = FCharacters[checked((int)(offset / sizeof(char)))];
            bool low = (offset % sizeof(char) == 0) == BitConverter.IsLittleEndian;
            return unchecked((byte)(low ? value : value >> 8));
        }

        internal override void WriteByte(nint offset, byte value)
        {
            ValidateRange(offset, 1);
            int index = checked((int)(offset / sizeof(char)));
            bool low = (offset % sizeof(char) == 0) == BitConverter.IsLittleEndian;
            FCharacters[index] = (char)(low
                ? (FCharacters[index] & 0xff00) | value
                : (FCharacters[index] & 0x00ff) | (value << 8));
            Publish();
        }

        internal override bool TryReadValue<T>(nint offset, out T value)
        {
            if (typeof(T) == typeof(char) && offset % sizeof(char) == 0)
            {
                ValidateRange(offset, sizeof(char));
                value = (T)(object)FCharacters[checked((int)(offset / sizeof(char)))];
                return true;
            }
            value = default!;
            return false;
        }

        internal override bool TryWriteValue<T>(nint offset, T value)
        {
            if (typeof(T) != typeof(char) || offset % sizeof(char) != 0) return false;
            ValidateRange(offset, sizeof(char));
            FCharacters[checked((int)(offset / sizeof(char)))] = (char)(object)value!;
            Publish();
            return true;
        }

        internal override PointerPin Pin(nint offset)
        {
            PointerPin pin = base.Pin(offset);
            return new PointerPin(pin.Address, () =>
            {
                try { Publish(); }
                finally { pin.Dispose(); }
            });
        }
    }
}
