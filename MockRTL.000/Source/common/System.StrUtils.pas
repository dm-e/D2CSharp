{
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
}

unit System.StrUtils;

interface

uses
  System.SysUtils,
  System.Types;

type
  TStringSeachOption = (
    soDown,
    soMatchCase,
    soWholeWord
  );

  TStringSearchOptions = set of TStringSeachOption;

  TSoundexLength = 1..MaxInt;
  TSoundexIntLength = 1..8;

  TCompareTextProc = function(const AText, AOther: string): Boolean;

  {
    Translation-compatible fallback for the current MockRTL.
    The public Delphi API documents TStringDynArray in System.Types.
  }
  TStringDynArray = array of string;

var
  AnsiResemblesProc: TCompareTextProc;
  ResemblesProc: TCompareTextProc;
  WordDelimiters: set of Byte;

function LeftStr(const AText: string; const ACount: Integer): string;
function RightStr(const AText: string; const ACount: Integer): string;
function MidStr(const AText: string; const AStart, ACount: Integer): string;

function AnsiLeftStr(const AText: string; const ACount: Integer): string;
function AnsiRightStr(const AText: string; const ACount: Integer): string;
function AnsiMidStr(const AText: string; const AStart, ACount: Integer): string;

function LeftBStr(const AText: string; const AByteCount: Integer): string;
function RightBStr(const AText: string; const AByteCount: Integer): string;
function MidBStr(const AText: string; const AByteStart, AByteCount: Integer): string;

function StartsStr(const ASubText, AText: string): Boolean;
function StartsText(const ASubText, AText: string): Boolean;
function EndsStr(const ASubText, AText: string): Boolean;
function EndsText(const ASubText, AText: string): Boolean;
function ContainsStr(const AText, ASubText: string): Boolean;
function ContainsText(const AText, ASubText: string): Boolean;

function AnsiStartsStr(const ASubText, AText: string): Boolean;
function AnsiStartsText(const ASubText, AText: string): Boolean;
function AnsiEndsStr(const ASubText, AText: string): Boolean;
function AnsiEndsText(const ASubText, AText: string): Boolean;
function AnsiContainsStr(const AText, ASubText: string): Boolean;
function AnsiContainsText(const AText, ASubText: string): Boolean;

function MatchStr(const AText: string; const AValues: array of string): Boolean;
function MatchText(const AText: string; const AValues: array of string): Boolean;
function IndexStr(const AText: string; const AValues: array of string): Integer;
function IndexText(const AText: string; const AValues: array of string): Integer;

function AnsiMatchStr(const AText: string; const AValues: array of string): Boolean;
function AnsiMatchText(const AText: string; const AValues: array of string): Boolean;
function AnsiIndexStr(const AText: string; const AValues: array of string): Integer;
function AnsiIndexText(const AText: string; const AValues: array of string): Integer;

function ReplaceStr(const AText, AFromText, AToText: string): string;
function ReplaceText(const AText, AFromText, AToText: string): string;
function ReverseString(const AText: string): string;

function AnsiReplaceStr(const AText, AFromText, AToText: string): string;
function AnsiReplaceText(const AText, AFromText, AToText: string): string;
function AnsiReverseString(const AText: string): string;

function PosEx(const SubStr, S: string; Offset: Integer = 1): Integer;

function SearchBuf(
  Buf: PAnsiChar;
  BufLen: Integer;
  SelStart, SelLength: Integer;
  SearchString: AnsiString;
  Options: TStringSearchOptions
): PAnsiChar; overload;

function SearchBuf(
  Buf: PChar;
  BufLen: Integer;
  SelStart, SelLength: Integer;
  SearchString: string;
  Options: TStringSearchOptions
): PChar; overload;

function DupeString(const AText: string; ACount: Integer): string;

function StuffString(
  const AText: string;
  AStart, ALength: Cardinal;
  const ASubText: string
): string;

function IfThen(
  AValue: Boolean;
  const ATrue: string;
  AFalse: string = ''
): string;

function SplitString(const S, Delimiters: string): TStringDynArray;

function Soundex(
  const AText: string;
  ALength: TSoundexLength = 4
): string;

function SoundexInt(
  const AText: string;
  ALength: TSoundexIntLength = 4
): Integer;

function SoundexWord(const AText: string): Word;

function DecodeSoundexInt(AValue: Integer): string;
function DecodeSoundexWord(AValue: Word): string;

function SoundexSimilar(
  const AText, AOther: string;
  ALength: TSoundexLength = 4
): Boolean;

function SoundexCompare(
  const AText, AOther: string;
  ALength: TSoundexLength = 4
): Integer;

function SoundexProc(const AText, AOther: string): Boolean;

function ResemblesText(const AText, AOther: string): Boolean;
function AnsiResemblesText(const AText, AOther: string): Boolean;

implementation

function LeftStr(const AText: string; const ACount: Integer): string;
begin
end;

function RightStr(const AText: string; const ACount: Integer): string;
begin
end;

function MidStr(const AText: string; const AStart, ACount: Integer): string;
begin
end;

function AnsiLeftStr(const AText: string; const ACount: Integer): string;
begin
end;

function AnsiRightStr(const AText: string; const ACount: Integer): string;
begin
end;

function AnsiMidStr(const AText: string; const AStart, ACount: Integer): string;
begin
end;

function LeftBStr(const AText: string; const AByteCount: Integer): string;
begin
end;

function RightBStr(const AText: string; const AByteCount: Integer): string;
begin
end;

function MidBStr(const AText: string; const AByteStart, AByteCount: Integer): string;
begin
end;

function StartsStr(const ASubText, AText: string): Boolean;
begin
end;

function StartsText(const ASubText, AText: string): Boolean;
begin
end;

function EndsStr(const ASubText, AText: string): Boolean;
begin
end;

function EndsText(const ASubText, AText: string): Boolean;
begin
end;

function ContainsStr(const AText, ASubText: string): Boolean;
begin
end;

function ContainsText(const AText, ASubText: string): Boolean;
begin
end;

function AnsiStartsStr(const ASubText, AText: string): Boolean;
begin
end;

function AnsiStartsText(const ASubText, AText: string): Boolean;
begin
end;

function AnsiEndsStr(const ASubText, AText: string): Boolean;
begin
end;

function AnsiEndsText(const ASubText, AText: string): Boolean;
begin
end;

function AnsiContainsStr(const AText, ASubText: string): Boolean;
begin
end;

function AnsiContainsText(const AText, ASubText: string): Boolean;
begin
end;

function MatchStr(const AText: string; const AValues: array of string): Boolean;
begin
end;

function MatchText(const AText: string; const AValues: array of string): Boolean;
begin
end;

function IndexStr(const AText: string; const AValues: array of string): Integer;
begin
end;

function IndexText(const AText: string; const AValues: array of string): Integer;
begin
end;

function AnsiMatchStr(const AText: string; const AValues: array of string): Boolean;
begin
end;

function AnsiMatchText(const AText: string; const AValues: array of string): Boolean;
begin
end;

function AnsiIndexStr(const AText: string; const AValues: array of string): Integer;
begin
end;

function AnsiIndexText(const AText: string; const AValues: array of string): Integer;
begin
end;

function ReplaceStr(const AText, AFromText, AToText: string): string;
begin
end;

function ReplaceText(const AText, AFromText, AToText: string): string;
begin
end;

function ReverseString(const AText: string): string;
begin
end;

function AnsiReplaceStr(const AText, AFromText, AToText: string): string;
begin
end;

function AnsiReplaceText(const AText, AFromText, AToText: string): string;
begin
end;

function AnsiReverseString(const AText: string): string;
begin
end;

function PosEx(const SubStr, S: string; Offset: Integer): Integer;
begin
end;

function SearchBuf(
  Buf: PAnsiChar;
  BufLen: Integer;
  SelStart, SelLength: Integer;
  SearchString: AnsiString;
  Options: TStringSearchOptions
): PAnsiChar;
begin
end;

function SearchBuf(
  Buf: PChar;
  BufLen: Integer;
  SelStart, SelLength: Integer;
  SearchString: string;
  Options: TStringSearchOptions
): PChar;
begin
end;

function DupeString(const AText: string; ACount: Integer): string;
begin
end;

function StuffString(
  const AText: string;
  AStart, ALength: Cardinal;
  const ASubText: string
): string;
begin
end;

function IfThen(
  AValue: Boolean;
  const ATrue: string;
  AFalse: string
): string;
begin
end;

function SplitString(const S, Delimiters: string): TStringDynArray;
begin
end;

function Soundex(
  const AText: string;
  ALength: TSoundexLength
): string;
begin
end;

function SoundexInt(
  const AText: string;
  ALength: TSoundexIntLength
): Integer;
begin
end;

function SoundexWord(const AText: string): Word;
begin
end;

function DecodeSoundexInt(AValue: Integer): string;
begin
end;

function DecodeSoundexWord(AValue: Word): string;
begin
end;

function SoundexSimilar(
  const AText, AOther: string;
  ALength: TSoundexLength
): Boolean;
begin
end;

function SoundexCompare(
  const AText, AOther: string;
  ALength: TSoundexLength
): Integer;
begin
end;

function SoundexProc(const AText, AOther: string): Boolean;
begin
end;

function ResemblesText(const AText, AOther: string): Boolean;
begin
end;

function AnsiResemblesText(const AText, AOther: string): Boolean;
begin
end;

end.
