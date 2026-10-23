using System.Sysutils;
using System.Types;
using System;
using static System.Strutils.StrutilsImplementation;
using static System.Strutils.StrutilsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;
using static System.Types.TypesInterface;

namespace System
{

namespace Strutils
{

/*
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.StrUtils functionality required by D2CSharp.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The routines below intentionally contain no RTL implementation. Functions
  return simple default values and procedures have empty bodies.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0

  Licensed under the Apache License, Version 2.0 (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at

      https://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.

  Part of the D2CSharp project by t2t-soft. See LICENSE and NOTICE.
*/


public class StrutilsInterface
{
	public enum TStringSeachOption {soDown,
                         soMatchCase,
                         soWholeWord };


  /*
    Translation-compatible fallback for the current MockRTL.
    The public Delphi API documents TStringDynArray in System.Types.
  */
public delegate bool TCompareTextProc(string AText, string AOther);
	public static TCompareTextProc AnsiResemblesProc = default;
	public static TCompareTextProc ResemblesProc = default;
	public static TSet WordDelimiters = new TSet();
	public static string LeftStr(string AText, int ACount)
	{
		string result = string.Empty;
		return result;
	}
	public static string RightStr(string AText, int ACount)
	{
		string result = string.Empty;
		return result;
	}
	public static string MidStr(string AText, int AStart, int ACount)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiLeftStr(string AText, int ACount)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiRightStr(string AText, int ACount)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiMidStr(string AText, int AStart, int ACount)
	{
		string result = string.Empty;
		return result;
	}
	public static string LeftBStr(string AText, int AByteCount)
	{
		string result = string.Empty;
		return result;
	}
	public static string RightBStr(string AText, int AByteCount)
	{
		string result = string.Empty;
		return result;
	}
	public static string MidBStr(string AText, int AByteStart, int AByteCount)
	{
		string result = string.Empty;
		return result;
	}
	public static bool StartsStr(string ASubText, string AText)
	{
		bool result = false;
		return result;
	}
	public static bool StartsText(string ASubText, string AText)
	{
		bool result = false;
		return result;
	}
	public static bool EndsStr(string ASubText, string AText)
	{
		bool result = false;
		return result;
	}
	public static bool EndsText(string ASubText, string AText)
	{
		bool result = false;
		return result;
	}
	public static bool ContainsStr(string AText, string ASubText)
	{
		bool result = false;
		return result;
	}
	public static bool ContainsText(string AText, string ASubText)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiStartsStr(string ASubText, string AText)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiStartsText(string ASubText, string AText)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiEndsStr(string ASubText, string AText)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiEndsText(string ASubText, string AText)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiContainsStr(string AText, string ASubText)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiContainsText(string AText, string ASubText)
	{
		bool result = false;
		return result;
	}
	public static bool MatchStr(string AText, string[] AValues)
	{
		bool result = false;
		return result;
	}
	public static bool MatchText(string AText, string[] AValues)
	{
		bool result = false;
		return result;
	}
	public static int IndexStr(string AText, string[] AValues)
	{
		int result = 0;
		return result;
	}
	public static int IndexText(string AText, string[] AValues)
	{
		int result = 0;
		return result;
	}
	public static bool AnsiMatchStr(string AText, string[] AValues)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiMatchText(string AText, string[] AValues)
	{
		bool result = false;
		return result;
	}
	public static int AnsiIndexStr(string AText, string[] AValues)
	{
		int result = 0;
		return result;
	}
	public static int AnsiIndexText(string AText, string[] AValues)
	{
		int result = 0;
		return result;
	}
	public static string ReplaceStr(string AText, string AFromText, string AToText)
	{
		string result = string.Empty;
		return result;
	}
	public static string ReplaceText(string AText, string AFromText, string AToText)
	{
		string result = string.Empty;
		return result;
	}
	public static string ReverseString(string AText)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiReplaceStr(string AText, string AFromText, string AToText)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiReplaceText(string AText, string AFromText, string AToText)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiReverseString(string AText)
	{
		string result = string.Empty;
		return result;
	}
	public static int PosEx(string SubStr, string S, int Offset = 1)
	{
		int result = 0;
		return result;
	}
	public static PAnsiChar SearchBuf(PAnsiChar Buf, int BufLen, int SelStart, int SelLength, AnsiString SearchString, TSet Options)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar SearchBuf(PChar Buf, int BufLen, int SelStart, int SelLength, string SearchString, TSet Options)
	{
		PChar result = default;
		return result;
	}
	public static string DupeString(string AText, int ACount)
	{
		string result = string.Empty;
		return result;
	}
	public static string StuffString(string AText, uint AStart, uint ALength, string ASubText)
	{
		string result = string.Empty;
		return result;
	}
	public static string IfThen(bool AValue, string ATrue, string AFalse = "")
	{
		string result = string.Empty;
		return result;
	}
	public static string[] SplitString(string S, string Delimiters)
	{
		string[] result = new string[]{};
		return result;
	}
	public static string Soundex(string AText, int /*1..MaxInt*/ ALength = 4)
	{
		string result = string.Empty;
		return result;
	}
	public static int SoundexInt(string AText, int /*1..8*/ ALength = 4)
	{
		int result = 0;
		return result;
	}
	public static ushort SoundexWord(string AText)
	{
		ushort result = 0;
		return result;
	}
	public static string DecodeSoundexInt(int AValue)
	{
		string result = string.Empty;
		return result;
	}
	public static string DecodeSoundexWord(ushort AValue)
	{
		string result = string.Empty;
		return result;
	}
	public static bool SoundexSimilar(string AText, string AOther, int /*1..MaxInt*/ ALength = 4)
	{
		bool result = false;
		return result;
	}
	public static int SoundexCompare(string AText, string AOther, int /*1..MaxInt*/ ALength = 4)
	{
		int result = 0;
		return result;
	}
	public static bool SoundexProc(string AText, string AOther)
	{
		bool result = false;
		return result;
	}
	public static bool ResemblesText(string AText, string AOther)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiResemblesText(string AText, string AOther)
	{
		bool result = false;
		return result;
	}
	
} // class StrutilsInterface


file class StrutilsImplementation
{

} // class StrutilsImplementation

}  // namespace Strutils

}  // namespace System

