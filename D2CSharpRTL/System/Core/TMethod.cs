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

using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using static System.SystemInterface;

namespace System
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TMethod : IEquatable<TMethod>
    {
        public IntPtr Code;
        public IntPtr Data;

        public static int DelphiSizeOf
        {
            get
            {
                return 2 * IntPtr.Size;
            }
        }

        public TMethod(IntPtr code, IntPtr data)
        {
            Code = code;
            Data = data;
        }

        public void CreateRecordMembers()
        {
            // TMethod contains only scalar fields.
            // No managed array or nested record members need initialization.
        }

        public static TMethod CreateRecord()
        {
            TMethod result = new TMethod();
            result.CreateRecordMembers();
            return result;
        }

        public bool IsEmpty
        {
            get
            {
                return Code == IntPtr.Zero &&
                    Data == IntPtr.Zero;
            }
        }

        public void Clear()
        {
            Code = IntPtr.Zero;
            Data = IntPtr.Zero;
        }

        public bool IsAssigned()
        {
            return !IsEmpty;
        }

        public bool Equals(TMethod other)
        {
            return Code == other.Code &&
                Data == other.Data;
        }

        public override bool Equals(object other)
        {
            return other is TMethod &&
                Equals((TMethod)other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Code.GetHashCode() * 397) ^
                    Data.GetHashCode();
            }
        }

        public static bool operator ==(
            TMethod left,
            TMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            TMethod left,
            TMethod right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format(
                "Code: 0x{0:X}, Data: 0x{1:X}",
                Code.ToInt64(),
                Data.ToInt64());
        }
    }

    public static partial class SystemInterface
    {
        private sealed class TMethodTargetToken
        {
            public readonly IntPtr Token;

            public TMethodTargetToken(long value)
            {
                Token = new IntPtr(value);
            }
        }

        private static readonly ConditionalWeakTable<object, TMethodTargetToken> FMethodTargetTokens =
            new ConditionalWeakTable<object, TMethodTargetToken>();

        private static readonly ConcurrentDictionary<MethodInfo, IntPtr> FMethodCodeTokens =
            new ConcurrentDictionary<MethodInfo, IntPtr>();

        private static readonly ConcurrentDictionary<TMethod, Delegate> FMethodDelegates =
            new ConcurrentDictionary<TMethod, Delegate>();

        private static long FNextMethodTargetToken;
        private static long FNextMethodCodeToken = 0x100000;

        public static TMethod CreateMethod(Delegate method)
        {
            if (method == null)
                return TMethod.CreateRecord();

            TMethod result = new TMethod(
                GetMethodCodePointer(method),
                GetMethodDataPointer(method));

            FMethodDelegates[result] = method;

            return result;
        }

        public static TMethod CreateMethod(IntPtr code, IntPtr data)
        {
            return new TMethod(code, data);
        }

        public static bool MethodDataEquals(TMethod method, object target)
        {
            if (target == null)
                return method.Data == IntPtr.Zero;

            if (method.Data == IntPtr.Zero)
                return false;

            TMethodTargetToken token;

            if (!FMethodTargetTokens.TryGetValue(target, out token))
                return false;

            return method.Data == token.Token;
        }

        private static IntPtr GetMethodCodePointer(Delegate method)
        {
            try
            {
                RuntimeMethodHandle handle = method.Method.MethodHandle;
                RuntimeHelpers.PrepareMethod(handle);

                return handle.GetFunctionPointer();
            }
            catch
            {
                return FMethodCodeTokens.GetOrAdd(
                    method.Method,
                    delegate
                    {
                        return new IntPtr(
                            Interlocked.Increment(ref FNextMethodCodeToken));
                    });
            }
        }

        private static IntPtr GetMethodDataPointer(Delegate method)
        {
            object target = method.Target;

            if (target == null)
                return IntPtr.Zero;

            return FMethodTargetTokens.GetValue(
                target,
                delegate
                {
                    return new TMethodTargetToken(
                        Interlocked.Increment(ref FNextMethodTargetToken));
                }).Token;
        }

        public static T AsDelegate<T>(TMethod method) where T : Delegate
        {
            Delegate result;

            if (FMethodDelegates.TryGetValue(method, out result))
            {
                T typedResult = result as T;

                if (typedResult != null)
                    return typedResult;
            }

            throw new InvalidCastException(
                "The TMethod does not contain a compatible managed delegate.");
        }

        public static bool TryAsDelegate<T>(
            TMethod method,
            out T result) where T : Delegate
        {
            result = null;

            Delegate storedDelegate;

            if (!FMethodDelegates.TryGetValue(method, out storedDelegate))
                return false;

            result = storedDelegate as T;

            return result != null;
        }
    }
}
