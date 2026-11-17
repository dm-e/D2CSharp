using System.Sysutils;
using System;
using static System.Ansistrings.AnsistringsImplementation;
using static System.Ansistrings.AnsistringsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;

namespace System
{

namespace Ansistrings
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.AnsiStrings.
  Independently written for source-code translation.
  No actual ANSI, locale, MBCS, or file-system operations are performed.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/

public class AnsistringsInterface
{
	public enum TFilenameCaseMatch : byte {mkNone,
                         mkExactMatch,
                         mkSingleMatch,
                         mkAmbiguous };
	public static int AnsiCompareStr(AnsiString S1, AnsiString S2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int AnsiCompareText(AnsiString S1, AnsiString S2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int AnsiCompareFileName(AnsiString S1, AnsiString S2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static bool AnsiSameStr(AnsiString S1, AnsiString S2)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiSameText(AnsiString S1, AnsiString S2)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiContainsStr(AnsiString AText, AnsiString ASubText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiContainsText(AnsiString AText, AnsiString ASubText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiStartsStr(AnsiString ASubText, AnsiString AText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiStartsText(AnsiString ASubText, AnsiString AText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiEndsStr(AnsiString ASubText, AnsiString AText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiEndsText(AnsiString ASubText, AnsiString AText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiMatchStr(AnsiString AText, AnsiString[] AValues)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool AnsiMatchText(AnsiString AText, AnsiString[] AValues)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static int AnsiIndexStr(AnsiString AText, AnsiString[] AValues)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int AnsiIndexText(AnsiString AText, AnsiString[] AValues)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int AnsiPos(AnsiString Substr, AnsiString S)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static AnsiString AnsiLeftStr(AnsiString AText, int ACount)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiRightStr(AnsiString AText, int ACount)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiMidStr(AnsiString AText, int AStart, int ACount)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiReplaceStr(AnsiString AText, AnsiString AFromText, AnsiString AToText)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiReplaceText(AnsiString AText, AnsiString AFromText, AnsiString AToText)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiQuotedStr(AnsiString S, byte Quote)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiDequotedStr(AnsiString S, byte AQuote)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiReverseString(AnsiString AText)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiLowerCase(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiUpperCase(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiLowerCaseFileName(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AnsiUpperCaseFileName(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static int CompareStr(AnsiString S1, AnsiString S2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int CompareText(AnsiString S1, AnsiString S2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static bool SameStr(AnsiString S1, AnsiString S2)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool SameText(AnsiString S1, AnsiString S2)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool ContainsStr(AnsiString AText, AnsiString ASubText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool ContainsText(AnsiString AText, AnsiString ASubText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool StartsStr(AnsiString ASubText, AnsiString AText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool StartsText(AnsiString ASubText, AnsiString AText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool EndsStr(AnsiString ASubText, AnsiString AText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool EndsText(AnsiString ASubText, AnsiString AText)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool MatchStr(AnsiString AText, AnsiString[] AValues)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool MatchText(AnsiString AText, AnsiString[] AValues)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static int IndexStr(AnsiString AText, AnsiString[] AValues)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int IndexText(AnsiString AText, AnsiString[] AValues)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static AnsiString LeftStr(AnsiString AText, int ACount)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString RightStr(AnsiString AText, int ACount)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString MidStr(AnsiString AText, int AStart, int ACount)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static int PosEx(AnsiString SubStr, AnsiString S, int Offset = 1)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static AnsiString ReplaceStr(AnsiString AText, AnsiString AFromText, AnsiString AToText)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ReplaceText(AnsiString AText, AnsiString AFromText, AnsiString AToText)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ReverseString(AnsiString AText)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString LowerCase(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString UpperCase(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString Trim(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString TrimLeft(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString TrimRight(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString QuotedStr(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString DupeString(AnsiString AText, int ACount)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString StuffString(AnsiString AText, uint AStart, uint ALength, AnsiString ASubText)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString AdjustLineBreaks(AnsiString S, TTextLineBreakStyle Style)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString StringReplace(AnsiString S, AnsiString OldPattern, AnsiString NewPattern, TSet Flags)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static bool IsDelimiter(AnsiString Delimiters, AnsiString S, int Index)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static int LastDelimiter(AnsiString Delimiters, AnsiString S)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int AnsiStrComp(PAnsiChar S1, PAnsiChar S2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int AnsiStrIComp(PAnsiChar S1, PAnsiChar S2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int AnsiStrLComp(PAnsiChar S1, PAnsiChar S2, uint MaxLen)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int AnsiStrLIComp(PAnsiChar S1, PAnsiChar S2, uint MaxLen)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static PAnsiChar AnsiStrLastChar(PAnsiChar P)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar AnsiStrPos(PAnsiChar Str, PAnsiChar SubStr)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar AnsiStrScan(PAnsiChar Str, byte Chr)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar AnsiStrRScan(PAnsiChar Str, byte Chr)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar AnsiStrLower(PAnsiChar Str)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar AnsiStrUpper(PAnsiChar Str)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar AnsiStrAlloc(uint Size)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static uint StrLen(PAnsiChar Str)
	{
		uint result = 0;
		result = 0;
		return result;
	}
	public static PAnsiChar StrEnd(PAnsiChar Str)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrCopy(PAnsiChar Dest, PAnsiChar Source)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrECopy(PAnsiChar Dest, PAnsiChar Source)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrLCopy(PAnsiChar Dest, PAnsiChar Source, uint MaxLen)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrCat(PAnsiChar Dest, PAnsiChar Source)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrLCat(PAnsiChar Dest, PAnsiChar Source, uint MaxLen)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static int StrComp(PAnsiChar Str1, PAnsiChar Str2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int StrIComp(PAnsiChar Str1, PAnsiChar Str2)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int StrLComp(PAnsiChar Str1, PAnsiChar Str2, uint MaxLen)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int StrLIComp(PAnsiChar Str1, PAnsiChar Str2, uint MaxLen)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static PAnsiChar StrPos(PAnsiChar Str1, PAnsiChar Str2)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrScan(PAnsiChar Str, byte Chr)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrRScan(PAnsiChar Str, byte Chr)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrNew(PAnsiChar Str)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static AnsiString StrPas(PAnsiChar Str)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static PAnsiChar StrPCopy(PAnsiChar Dest, AnsiString Source)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrPLCopy(PAnsiChar Dest, AnsiString Source, uint MaxLen)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrMove(PAnsiChar Dest, PAnsiChar Source, uint Count)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrLower(PAnsiChar Str)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrUpper(PAnsiChar Str)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static PAnsiChar StrNextChar(PAnsiChar Str)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static int StrCharLength(PAnsiChar Str)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static uint StrBufSize(PAnsiChar Str)
	{
		uint result = 0;
		result = 0;
		return result;
	}
	public static int CharLength(AnsiString S, int Index)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static TMbcsByteType ByteType(AnsiString S, int Index)
	{
		TMbcsByteType result = TMbcsByteType.mbSingleByte;
		result = System.Sysutils.SysutilsInterface.TMbcsByteType.mbSingleByte;
		return result;
	}
	public static TMbcsByteType StrByteType(PAnsiChar Str, uint Index)
	{
		TMbcsByteType result = TMbcsByteType.mbSingleByte;
		result = System.Sysutils.SysutilsInterface.TMbcsByteType.mbSingleByte;
		return result;
	}
	public static int NextCharIndex(AnsiString S, int Index)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int CharToElementIndex(AnsiString S, int Index)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int CharToElementLen(AnsiString S, int MaxLen)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int ElementToCharIndex(AnsiString S, int Index)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static int ElementToCharLen(AnsiString S, int MaxLen)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static AnsiString ExtractFileName(AnsiString FileName)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExtractFilePath(AnsiString FileName)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExtractFileDir(AnsiString FileName)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExtractFileDrive(AnsiString FileName)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExtractFileExt(AnsiString FileName)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ChangeFileExt(AnsiString FileName, AnsiString Extension)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ChangeFilePath(AnsiString FileName, AnsiString Path)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExpandFileName(AnsiString FileName)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExpandUNCFileName(AnsiString FileName)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString IncludeTrailingPathDelimiter(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExcludeTrailingPathDelimiter(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString IncludeTrailingBackslash(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExcludeTrailingBackslash(AnsiString S)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static bool IsPathDelimiter(AnsiString S, int Index)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool SameFileName(AnsiString S1, AnsiString S2)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static AnsiString AnsiExtractQuotedStr(ref PAnsiChar Src, byte Quote)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString ExtractRelativePath(AnsiString BaseName, AnsiString DestName)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static void StrDispose(PAnsiChar Str)
	{
	}
	public static void AppendStr(ref AnsiString Dest, AnsiString S)
	{
	}
	public static void AssignStr(ref PAnsiString P, AnsiString S)
	{
	}
	public static PAnsiChar AnsiLastChar(AnsiString S)
	{
		PAnsiChar result = default;
		result = default;
		return result;
	}
	public static AnsiString Format(AnsiString Format, params TVarRec[] Args)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	public static AnsiString Format(AnsiString Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		AnsiString result = AnsiString.Empty;
		result = "";
		return result;
	}
	
} // class AnsistringsInterface


file class AnsistringsImplementation
{

} // class AnsistringsImplementation

}  // namespace Ansistrings

}  // namespace System

