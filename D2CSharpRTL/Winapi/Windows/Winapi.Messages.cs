using System;
using static System.SystemInterface;
using static Winapi.Messages.MessagesImplementation;
using static Winapi.Messages.MessagesInterface;

namespace Winapi
{

namespace Messages
{

/*
  D2CSharp Runtime Library (RTL)
  Minimal declaration-oriented mock of Winapi.Messages.
  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/

public class MessagesInterface
{
    public const int WM_ERASEBKGND = 0x0014;
    public const int WM_GETDLGCODE = 0x0087;
    public struct TMessage
    {
        public uint Msg;
        public nuint WParam;
        public nint LParam;
        public nint Result;
        public static TMessage CreateRecord() => new TMessage();
    }
    public struct TWMNoParams
    {
        public uint Msg;
        public nuint WParam;
        public nint LParam;
        public nint Result;
        public static TWMNoParams CreateRecord() => new TWMNoParams();
    }
    public struct TWMEraseBkgnd
    {
        public uint Msg;
        public nuint DC;
        public nint Unused;
        public nint Result;
        public static TWMEraseBkgnd CreateRecord() => new TWMEraseBkgnd();
    }
    public struct TWMKey
    {
        public uint Msg;
        public ushort CharCode;
        public ushort Unused;
        public int KeyData;
        public int Result;
    }
}

file class MessagesImplementation
{
}

} // namespace Messages

} // namespace Winapi
