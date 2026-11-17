{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.AnsiStrings.
  Independently written for source-code translation.
  No actual ANSI, locale, MBCS, or file-system operations are performed.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit System.AnsiStrings;

interface

uses
  System.SysUtils;

type
  TFilenameCaseMatch = (mkNone, mkExactMatch, mkSingleMatch, mkAmbiguous);

function AnsiCompareStr(const S1, S2: AnsiString): Integer;
function AnsiCompareText(const S1, S2: AnsiString): Integer;
function AnsiCompareFileName(const S1, S2: AnsiString): Integer;
function AnsiSameStr(const S1, S2: AnsiString): Boolean;
function AnsiSameText(const S1, S2: AnsiString): Boolean;
function AnsiContainsStr(const AText, ASubText: AnsiString): Boolean;
function AnsiContainsText(const AText, ASubText: AnsiString): Boolean;
function AnsiStartsStr(const ASubText, AText: AnsiString): Boolean;
function AnsiStartsText(const ASubText, AText: AnsiString): Boolean;
function AnsiEndsStr(const ASubText, AText: AnsiString): Boolean;
function AnsiEndsText(const ASubText, AText: AnsiString): Boolean;
function AnsiMatchStr(const AText: AnsiString; const AValues: array of AnsiString): Boolean;
function AnsiMatchText(const AText: AnsiString; const AValues: array of AnsiString): Boolean;
function AnsiIndexStr(const AText: AnsiString; const AValues: array of AnsiString): Integer;
function AnsiIndexText(const AText: AnsiString; const AValues: array of AnsiString): Integer;
function AnsiPos(const Substr, S: AnsiString): Integer;
function AnsiLeftStr(const AText: AnsiString; const ACount: Integer): AnsiString;
function AnsiRightStr(const AText: AnsiString; const ACount: Integer): AnsiString;
function AnsiMidStr(const AText: AnsiString; const AStart, ACount: Integer): AnsiString;
function AnsiReplaceStr(const AText, AFromText, AToText: AnsiString): AnsiString;
function AnsiReplaceText(const AText, AFromText, AToText: AnsiString): AnsiString;
function AnsiQuotedStr(const S: AnsiString; Quote: AnsiChar): AnsiString;
function AnsiDequotedStr(const S: AnsiString; AQuote: AnsiChar): AnsiString;
function AnsiReverseString(const AText: AnsiString): AnsiString;
function AnsiLowerCase(const S: AnsiString): AnsiString;
function AnsiUpperCase(const S: AnsiString): AnsiString;
function AnsiLowerCaseFileName(const S: AnsiString): AnsiString;
function AnsiUpperCaseFileName(const S: AnsiString): AnsiString;
function CompareStr(const S1, S2: AnsiString): Integer;
function CompareText(const S1, S2: AnsiString): Integer;
function SameStr(const S1, S2: AnsiString): Boolean;
function SameText(const S1, S2: AnsiString): Boolean;
function ContainsStr(const AText, ASubText: AnsiString): Boolean;
function ContainsText(const AText, ASubText: AnsiString): Boolean;
function StartsStr(const ASubText, AText: AnsiString): Boolean;
function StartsText(const ASubText, AText: AnsiString): Boolean;
function EndsStr(const ASubText, AText: AnsiString): Boolean;
function EndsText(const ASubText, AText: AnsiString): Boolean;
function MatchStr(const AText: AnsiString; const AValues: array of AnsiString): Boolean;
function MatchText(const AText: AnsiString; const AValues: array of AnsiString): Boolean;
function IndexStr(const AText: AnsiString; const AValues: array of AnsiString): Integer;
function IndexText(const AText: AnsiString; const AValues: array of AnsiString): Integer;
function LeftStr(const AText: AnsiString; const ACount: Integer): AnsiString;
function RightStr(const AText: AnsiString; const ACount: Integer): AnsiString;
function MidStr(const AText: AnsiString; const AStart, ACount: Integer): AnsiString;
function PosEx(const SubStr, S: AnsiString; Offset: Integer = 1): Integer;
function ReplaceStr(const AText, AFromText, AToText: AnsiString): AnsiString;
function ReplaceText(const AText, AFromText, AToText: AnsiString): AnsiString;
function ReverseString(const AText: AnsiString): AnsiString;
function LowerCase(const S: AnsiString): AnsiString;
function UpperCase(const S: AnsiString): AnsiString;
function Trim(const S: AnsiString): AnsiString;
function TrimLeft(const S: AnsiString): AnsiString;
function TrimRight(const S: AnsiString): AnsiString;
function QuotedStr(const S: AnsiString): AnsiString;
function DupeString(const AText: AnsiString; ACount: Integer): AnsiString;
function StuffString(const AText: AnsiString; AStart, ALength: Cardinal; const ASubText: AnsiString): AnsiString;
function AdjustLineBreaks(const S: AnsiString; Style: TTextLineBreakStyle): AnsiString;
function StringReplace(const S, OldPattern, NewPattern: AnsiString; Flags: TReplaceFlags): AnsiString;
function IsDelimiter(const Delimiters, S: AnsiString; Index: Integer): Boolean;
function LastDelimiter(const Delimiters, S: AnsiString): Integer;
function AnsiStrComp(S1, S2: PAnsiChar): Integer;
function AnsiStrIComp(S1, S2: PAnsiChar): Integer;
function AnsiStrLComp(S1, S2: PAnsiChar; MaxLen: Cardinal): Integer;
function AnsiStrLIComp(S1, S2: PAnsiChar; MaxLen: Cardinal): Integer;
function AnsiStrLastChar(P: PAnsiChar): PAnsiChar;
function AnsiStrPos(Str, SubStr: PAnsiChar): PAnsiChar;
function AnsiStrScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
function AnsiStrRScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
function AnsiStrLower(Str: PAnsiChar): PAnsiChar;
function AnsiStrUpper(Str: PAnsiChar): PAnsiChar;
function AnsiStrAlloc(Size: Cardinal): PAnsiChar;
function StrLen(Str: PAnsiChar): Cardinal;
function StrEnd(Str: PAnsiChar): PAnsiChar;
function StrCopy(Dest, Source: PAnsiChar): PAnsiChar;
function StrECopy(Dest, Source: PAnsiChar): PAnsiChar;
function StrLCopy(Dest, Source: PAnsiChar; MaxLen: Cardinal): PAnsiChar;
function StrCat(Dest, Source: PAnsiChar): PAnsiChar;
function StrLCat(Dest, Source: PAnsiChar; MaxLen: Cardinal): PAnsiChar;
function StrComp(Str1, Str2: PAnsiChar): Integer;
function StrIComp(Str1, Str2: PAnsiChar): Integer;
function StrLComp(Str1, Str2: PAnsiChar; MaxLen: Cardinal): Integer;
function StrLIComp(Str1, Str2: PAnsiChar; MaxLen: Cardinal): Integer;
function StrPos(Str1, Str2: PAnsiChar): PAnsiChar;
function StrScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
function StrRScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
function StrNew(Str: PAnsiChar): PAnsiChar;
function StrPas(Str: PAnsiChar): AnsiString;
function StrPCopy(Dest: PAnsiChar; const Source: AnsiString): PAnsiChar;
function StrPLCopy(Dest: PAnsiChar; const Source: AnsiString; MaxLen: Cardinal): PAnsiChar;
function StrMove(Dest, Source: PAnsiChar; Count: Cardinal): PAnsiChar;
function StrLower(Str: PAnsiChar): PAnsiChar;
function StrUpper(Str: PAnsiChar): PAnsiChar;
function StrNextChar(Str: PAnsiChar): PAnsiChar;
function StrCharLength(Str: PAnsiChar): Integer;
function StrBufSize(Str: PAnsiChar): Cardinal;
function CharLength(const S: AnsiString; Index: Integer): Integer;
function ByteType(const S: AnsiString; Index: Integer): TMbcsByteType;
function StrByteType(Str: PAnsiChar; Index: Cardinal): TMbcsByteType;
function NextCharIndex(const S: AnsiString; Index: Integer): Integer;
function CharToElementIndex(const S: AnsiString; Index: Integer): Integer;
function CharToElementLen(const S: AnsiString; MaxLen: Integer): Integer;
function ElementToCharIndex(const S: AnsiString; Index: Integer): Integer;
function ElementToCharLen(const S: AnsiString; MaxLen: Integer): Integer;
function ExtractFileName(const FileName: AnsiString): AnsiString;
function ExtractFilePath(const FileName: AnsiString): AnsiString;
function ExtractFileDir(const FileName: AnsiString): AnsiString;
function ExtractFileDrive(const FileName: AnsiString): AnsiString;
function ExtractFileExt(const FileName: AnsiString): AnsiString;
function ChangeFileExt(const FileName, Extension: AnsiString): AnsiString;
function ChangeFilePath(const FileName, Path: AnsiString): AnsiString;
function ExpandFileName(const FileName: AnsiString): AnsiString;
function ExpandUNCFileName(const FileName: AnsiString): AnsiString;
function IncludeTrailingPathDelimiter(const S: AnsiString): AnsiString;
function ExcludeTrailingPathDelimiter(const S: AnsiString): AnsiString;
function IncludeTrailingBackslash(const S: AnsiString): AnsiString;
function ExcludeTrailingBackslash(const S: AnsiString): AnsiString;
function IsPathDelimiter(const S: AnsiString; Index: Integer): Boolean;
function SameFileName(const S1, S2: AnsiString): Boolean;
function AnsiExtractQuotedStr(var Src: PAnsiChar; Quote: AnsiChar): AnsiString;
function ExtractRelativePath(const BaseName, DestName: AnsiString): AnsiString;
procedure StrDispose(Str: PAnsiChar);
procedure AppendStr(var Dest: AnsiString; const S: AnsiString);
procedure AssignStr(var P: PAnsiString; const S: AnsiString);

function AnsiLastChar(const S: AnsiString): PAnsiChar;
function Format(const Format: AnsiString; const Args: array of const): AnsiString; overload;
function Format(const Format: AnsiString; const Args: array of const;
  const AFormatSettings: TFormatSettings): AnsiString; overload;

implementation

function AnsiLastChar(const S: AnsiString): PAnsiChar;
begin
  Result := nil;
end;

function Format(const Format: AnsiString; const Args: array of const): AnsiString;
begin
  Result := '';
end;

function Format(const Format: AnsiString; const Args: array of const;
  const AFormatSettings: TFormatSettings): AnsiString;
begin
  Result := '';
end;

function AnsiCompareStr(const S1, S2: AnsiString): Integer;
begin
  Result := 0;
end;

function AnsiCompareText(const S1, S2: AnsiString): Integer;
begin
  Result := 0;
end;

function AnsiCompareFileName(const S1, S2: AnsiString): Integer;
begin
  Result := 0;
end;

function AnsiSameStr(const S1, S2: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiSameText(const S1, S2: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiContainsStr(const AText, ASubText: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiContainsText(const AText, ASubText: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiStartsStr(const ASubText, AText: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiStartsText(const ASubText, AText: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiEndsStr(const ASubText, AText: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiEndsText(const ASubText, AText: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiMatchStr(const AText: AnsiString; const AValues: array of AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiMatchText(const AText: AnsiString; const AValues: array of AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiIndexStr(const AText: AnsiString; const AValues: array of AnsiString): Integer;
begin
  Result := 0;
end;

function AnsiIndexText(const AText: AnsiString; const AValues: array of AnsiString): Integer;
begin
  Result := 0;
end;

function AnsiPos(const Substr, S: AnsiString): Integer;
begin
  Result := 0;
end;

function AnsiLeftStr(const AText: AnsiString; const ACount: Integer): AnsiString;
begin
  Result := '';
end;

function AnsiRightStr(const AText: AnsiString; const ACount: Integer): AnsiString;
begin
  Result := '';
end;

function AnsiMidStr(const AText: AnsiString; const AStart, ACount: Integer): AnsiString;
begin
  Result := '';
end;

function AnsiReplaceStr(const AText, AFromText, AToText: AnsiString): AnsiString;
begin
  Result := '';
end;

function AnsiReplaceText(const AText, AFromText, AToText: AnsiString): AnsiString;
begin
  Result := '';
end;

function AnsiQuotedStr(const S: AnsiString; Quote: AnsiChar): AnsiString;
begin
  Result := '';
end;

function AnsiDequotedStr(const S: AnsiString; AQuote: AnsiChar): AnsiString;
begin
  Result := '';
end;

function AnsiReverseString(const AText: AnsiString): AnsiString;
begin
  Result := '';
end;

function AnsiLowerCase(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function AnsiUpperCase(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function AnsiLowerCaseFileName(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function AnsiUpperCaseFileName(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function CompareStr(const S1, S2: AnsiString): Integer;
begin
  Result := 0;
end;

function CompareText(const S1, S2: AnsiString): Integer;
begin
  Result := 0;
end;

function SameStr(const S1, S2: AnsiString): Boolean;
begin
  Result := False;
end;

function SameText(const S1, S2: AnsiString): Boolean;
begin
  Result := False;
end;

function ContainsStr(const AText, ASubText: AnsiString): Boolean;
begin
  Result := False;
end;

function ContainsText(const AText, ASubText: AnsiString): Boolean;
begin
  Result := False;
end;

function StartsStr(const ASubText, AText: AnsiString): Boolean;
begin
  Result := False;
end;

function StartsText(const ASubText, AText: AnsiString): Boolean;
begin
  Result := False;
end;

function EndsStr(const ASubText, AText: AnsiString): Boolean;
begin
  Result := False;
end;

function EndsText(const ASubText, AText: AnsiString): Boolean;
begin
  Result := False;
end;

function MatchStr(const AText: AnsiString; const AValues: array of AnsiString): Boolean;
begin
  Result := False;
end;

function MatchText(const AText: AnsiString; const AValues: array of AnsiString): Boolean;
begin
  Result := False;
end;

function IndexStr(const AText: AnsiString; const AValues: array of AnsiString): Integer;
begin
  Result := 0;
end;

function IndexText(const AText: AnsiString; const AValues: array of AnsiString): Integer;
begin
  Result := 0;
end;

function LeftStr(const AText: AnsiString; const ACount: Integer): AnsiString;
begin
  Result := '';
end;

function RightStr(const AText: AnsiString; const ACount: Integer): AnsiString;
begin
  Result := '';
end;

function MidStr(const AText: AnsiString; const AStart, ACount: Integer): AnsiString;
begin
  Result := '';
end;

function PosEx(const SubStr, S: AnsiString; Offset: Integer): Integer;
begin
  Result := 0;
end;

function ReplaceStr(const AText, AFromText, AToText: AnsiString): AnsiString;
begin
  Result := '';
end;

function ReplaceText(const AText, AFromText, AToText: AnsiString): AnsiString;
begin
  Result := '';
end;

function ReverseString(const AText: AnsiString): AnsiString;
begin
  Result := '';
end;

function LowerCase(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function UpperCase(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function Trim(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function TrimLeft(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function TrimRight(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function QuotedStr(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function DupeString(const AText: AnsiString; ACount: Integer): AnsiString;
begin
  Result := '';
end;

function StuffString(const AText: AnsiString; AStart, ALength: Cardinal; const ASubText: AnsiString): AnsiString;
begin
  Result := '';
end;

function AdjustLineBreaks(const S: AnsiString; Style: TTextLineBreakStyle): AnsiString;
begin
  Result := '';
end;

function StringReplace(const S, OldPattern, NewPattern: AnsiString; Flags: TReplaceFlags): AnsiString;
begin
  Result := '';
end;

function IsDelimiter(const Delimiters, S: AnsiString; Index: Integer): Boolean;
begin
  Result := False;
end;

function LastDelimiter(const Delimiters, S: AnsiString): Integer;
begin
  Result := 0;
end;

function AnsiStrComp(S1, S2: PAnsiChar): Integer;
begin
  Result := 0;
end;

function AnsiStrIComp(S1, S2: PAnsiChar): Integer;
begin
  Result := 0;
end;

function AnsiStrLComp(S1, S2: PAnsiChar; MaxLen: Cardinal): Integer;
begin
  Result := 0;
end;

function AnsiStrLIComp(S1, S2: PAnsiChar; MaxLen: Cardinal): Integer;
begin
  Result := 0;
end;

function AnsiStrLastChar(P: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function AnsiStrPos(Str, SubStr: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function AnsiStrScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function AnsiStrRScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function AnsiStrLower(Str: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function AnsiStrUpper(Str: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function AnsiStrAlloc(Size: Cardinal): PAnsiChar;
begin
  Result := nil;
end;

function StrLen(Str: PAnsiChar): Cardinal;
begin
  Result := 0;
end;

function StrEnd(Str: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrCopy(Dest, Source: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrECopy(Dest, Source: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrLCopy(Dest, Source: PAnsiChar; MaxLen: Cardinal): PAnsiChar;
begin
  Result := nil;
end;

function StrCat(Dest, Source: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrLCat(Dest, Source: PAnsiChar; MaxLen: Cardinal): PAnsiChar;
begin
  Result := nil;
end;

function StrComp(Str1, Str2: PAnsiChar): Integer;
begin
  Result := 0;
end;

function StrIComp(Str1, Str2: PAnsiChar): Integer;
begin
  Result := 0;
end;

function StrLComp(Str1, Str2: PAnsiChar; MaxLen: Cardinal): Integer;
begin
  Result := 0;
end;

function StrLIComp(Str1, Str2: PAnsiChar; MaxLen: Cardinal): Integer;
begin
  Result := 0;
end;

function StrPos(Str1, Str2: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrRScan(Str: PAnsiChar; Chr: AnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrNew(Str: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrPas(Str: PAnsiChar): AnsiString;
begin
  Result := '';
end;

function StrPCopy(Dest: PAnsiChar; const Source: AnsiString): PAnsiChar;
begin
  Result := nil;
end;

function StrPLCopy(Dest: PAnsiChar; const Source: AnsiString; MaxLen: Cardinal): PAnsiChar;
begin
  Result := nil;
end;

function StrMove(Dest, Source: PAnsiChar; Count: Cardinal): PAnsiChar;
begin
  Result := nil;
end;

function StrLower(Str: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrUpper(Str: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrNextChar(Str: PAnsiChar): PAnsiChar;
begin
  Result := nil;
end;

function StrCharLength(Str: PAnsiChar): Integer;
begin
  Result := 0;
end;

function StrBufSize(Str: PAnsiChar): Cardinal;
begin
  Result := 0;
end;

function CharLength(const S: AnsiString; Index: Integer): Integer;
begin
  Result := 0;
end;

function ByteType(const S: AnsiString; Index: Integer): TMbcsByteType;
begin
  Result := mbSingleByte;
end;

function StrByteType(Str: PAnsiChar; Index: Cardinal): TMbcsByteType;
begin
  Result := mbSingleByte;
end;

function NextCharIndex(const S: AnsiString; Index: Integer): Integer;
begin
  Result := 0;
end;

function CharToElementIndex(const S: AnsiString; Index: Integer): Integer;
begin
  Result := 0;
end;

function CharToElementLen(const S: AnsiString; MaxLen: Integer): Integer;
begin
  Result := 0;
end;

function ElementToCharIndex(const S: AnsiString; Index: Integer): Integer;
begin
  Result := 0;
end;

function ElementToCharLen(const S: AnsiString; MaxLen: Integer): Integer;
begin
  Result := 0;
end;

function ExtractFileName(const FileName: AnsiString): AnsiString;
begin
  Result := '';
end;

function ExtractFilePath(const FileName: AnsiString): AnsiString;
begin
  Result := '';
end;

function ExtractFileDir(const FileName: AnsiString): AnsiString;
begin
  Result := '';
end;

function ExtractFileDrive(const FileName: AnsiString): AnsiString;
begin
  Result := '';
end;

function ExtractFileExt(const FileName: AnsiString): AnsiString;
begin
  Result := '';
end;

function ChangeFileExt(const FileName, Extension: AnsiString): AnsiString;
begin
  Result := '';
end;

function ChangeFilePath(const FileName, Path: AnsiString): AnsiString;
begin
  Result := '';
end;

function ExpandFileName(const FileName: AnsiString): AnsiString;
begin
  Result := '';
end;

function ExpandUNCFileName(const FileName: AnsiString): AnsiString;
begin
  Result := '';
end;

function IncludeTrailingPathDelimiter(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function ExcludeTrailingPathDelimiter(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function IncludeTrailingBackslash(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function ExcludeTrailingBackslash(const S: AnsiString): AnsiString;
begin
  Result := '';
end;

function IsPathDelimiter(const S: AnsiString; Index: Integer): Boolean;
begin
  Result := False;
end;

function SameFileName(const S1, S2: AnsiString): Boolean;
begin
  Result := False;
end;

function AnsiExtractQuotedStr(var Src: PAnsiChar; Quote: AnsiChar): AnsiString;
begin
  Result := '';
end;

function ExtractRelativePath(const BaseName, DestName: AnsiString): AnsiString;
begin
  Result := '';
end;

procedure StrDispose(Str: PAnsiChar);
begin
end;

procedure AppendStr(var Dest: AnsiString; const S: AnsiString);
begin
end;

procedure AssignStr(var P: PAnsiString; const S: AnsiString);
begin
end;

end.
