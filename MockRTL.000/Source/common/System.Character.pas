{
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.Character functionality required by D2CSharp.

  The file provides public Unicode character types and routine signatures used
  during translation. Implementations are intentionally empty stubs.

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

unit System.Character;

interface

type
  {
    System.UCS4Char is a 32-bit Unicode scalar/code-point representation.
    It is repeated here as a translation-compatible fallback until the
    System MockRTL exposes UCS4Char directly.
  }
  UCS4Char = Cardinal;

  TUnicodeCategory = (
    ucControl,
    ucFormat,
    ucUnassigned,
    ucPrivateUse,
    ucSurrogate,
    ucLowercaseLetter,
    ucModifierLetter,
    ucOtherLetter,
    ucTitlecaseLetter,
    ucUppercaseLetter,
    ucCombiningMark,
    ucEnclosingMark,
    ucNonSpacingMark,
    ucDecimalNumber,
    ucLetterNumber,
    ucOtherNumber,
    ucConnectPunctuation,
    ucDashPunctuation,
    ucClosePunctuation,
    ucFinalPunctuation,
    ucInitialPunctuation,
    ucOtherPunctuation,
    ucOpenPunctuation,
    ucCurrencySymbol,
    ucModifierSymbol,
    ucMathSymbol,
    ucOtherSymbol,
    ucLineSeparator,
    ucParagraphSeparator,
    ucSpaceSeparator
  );

  TCharacter = record
  public
    class function ConvertFromUtf32(ConvertChar: UCS4Char): string; static;

    class function ConvertToUtf32(HighSurrogate, LowSurrogate: Char): UCS4Char; overload; static;
    class function ConvertToUtf32(const S: string; Index: Integer): UCS4Char; overload; static;

    class function GetNumericValue(C: Char): Double; overload; static;
    class function GetNumericValue(C: UCS4Char): Double; overload; static;
    class function GetNumericValue(const S: string; Index: Integer): Double; overload; static;

    class function GetUnicodeCategory(C: Char): TUnicodeCategory; overload; static;
    class function GetUnicodeCategory(C: UCS4Char): TUnicodeCategory; overload; static;
    class function GetUnicodeCategory(const S: string; Index: Integer): TUnicodeCategory; overload; static;

    class function IsControl(C: Char): Boolean; overload; static;
    class function IsControl(C: UCS4Char): Boolean; overload; static;
    class function IsControl(const S: string; Index: Integer): Boolean; overload; static;

    class function IsDefined(C: Char): Boolean; overload; static;
    class function IsDefined(C: UCS4Char): Boolean; overload; static;
    class function IsDefined(const S: string; Index: Integer): Boolean; overload; static;

    class function IsDigit(C: Char): Boolean; overload; static;
    class function IsDigit(C: UCS4Char): Boolean; overload; static;
    class function IsDigit(const S: string; Index: Integer): Boolean; overload; static;

    class function IsHighSurrogate(C: Char): Boolean; overload; static;
    class function IsHighSurrogate(const S: string; Index: Integer): Boolean; overload; static;

    class function IsLetter(C: Char): Boolean; overload; static;
    class function IsLetter(C: UCS4Char): Boolean; overload; static;
    class function IsLetter(const S: string; Index: Integer): Boolean; overload; static;

    class function IsLetterOrDigit(C: Char): Boolean; overload; static;
    class function IsLetterOrDigit(C: UCS4Char): Boolean; overload; static;
    class function IsLetterOrDigit(const S: string; Index: Integer): Boolean; overload; static;

    class function IsLowSurrogate(C: Char): Boolean; overload; static;
    class function IsLowSurrogate(const S: string; Index: Integer): Boolean; overload; static;

    class function IsLower(C: Char): Boolean; overload; static;
    class function IsLower(C: UCS4Char): Boolean; overload; static;
    class function IsLower(const S: string; Index: Integer): Boolean; overload; static;

    class function IsNumber(C: Char): Boolean; overload; static;
    class function IsNumber(C: UCS4Char): Boolean; overload; static;
    class function IsNumber(const S: string; Index: Integer): Boolean; overload; static;

    class function IsPunctuation(C: Char): Boolean; overload; static;
    class function IsPunctuation(C: UCS4Char): Boolean; overload; static;
    class function IsPunctuation(const S: string; Index: Integer): Boolean; overload; static;

    class function IsSeparator(C: Char): Boolean; overload; static;
    class function IsSeparator(C: UCS4Char): Boolean; overload; static;
    class function IsSeparator(const S: string; Index: Integer): Boolean; overload; static;

    class function IsSurrogate(C: Char): Boolean; overload; static;
    class function IsSurrogate(const S: string; Index: Integer): Boolean; overload; static;

    class function IsSurrogatePair(HighSurrogate, LowSurrogate: Char): Boolean; overload; static;
    class function IsSurrogatePair(const S: string; Index: Integer): Boolean; overload; static;

    class function IsSymbol(C: Char): Boolean; overload; static;
    class function IsSymbol(C: UCS4Char): Boolean; overload; static;
    class function IsSymbol(const S: string; Index: Integer): Boolean; overload; static;

    class function IsUpper(C: Char): Boolean; overload; static;
    class function IsUpper(C: UCS4Char): Boolean; overload; static;
    class function IsUpper(const S: string; Index: Integer): Boolean; overload; static;

    class function IsWhiteSpace(C: Char): Boolean; overload; static;
    class function IsWhiteSpace(C: UCS4Char): Boolean; overload; static;
    class function IsWhiteSpace(const S: string; Index: Integer): Boolean; overload; static;

    class function ToLower(C: Char): Char; overload; static;
    class function ToLower(C: UCS4Char): UCS4Char; overload; static;
    class function ToLower(const S: string): string; overload; static;

    class function ToLowerInvariant(C: Char): Char; overload; static;
    class function ToLowerInvariant(C: UCS4Char): UCS4Char; overload; static;

    class function ToUpper(C: Char): Char; overload; static;
    class function ToUpper(C: UCS4Char): UCS4Char; overload; static;
    class function ToUpper(const S: string): string; overload; static;

    class function ToUpperInvariant(C: Char): Char; overload; static;
    class function ToUpperInvariant(C: UCS4Char): UCS4Char; overload; static;
  end;

{ Global compatibility routines }

function ConvertFromUtf32(ConvertChar: UCS4Char): string;
function ConvertToUtf32(HighSurrogate, LowSurrogate: Char): UCS4Char; overload;
function ConvertToUtf32(const S: string; Index: Integer): UCS4Char; overload;

function GetNumericValue(C: Char): Double; overload;
function GetNumericValue(C: UCS4Char): Double; overload;
function GetNumericValue(const S: string; Index: Integer): Double; overload;

function GetUnicodeCategory(C: Char): TUnicodeCategory; overload;
function GetUnicodeCategory(C: UCS4Char): TUnicodeCategory; overload;
function GetUnicodeCategory(const S: string; Index: Integer): TUnicodeCategory; overload;

function IsControl(C: Char): Boolean; overload;
function IsControl(C: UCS4Char): Boolean; overload;
function IsControl(const S: string; Index: Integer): Boolean; overload;

function IsDefined(C: Char): Boolean; overload;
function IsDefined(C: UCS4Char): Boolean; overload;
function IsDefined(const S: string; Index: Integer): Boolean; overload;

function IsDigit(C: Char): Boolean; overload;
function IsDigit(C: UCS4Char): Boolean; overload;
function IsDigit(const S: string; Index: Integer): Boolean; overload;

function IsLetter(C: Char): Boolean; overload;
function IsLetter(C: UCS4Char): Boolean; overload;
function IsLetter(const S: string; Index: Integer): Boolean; overload;

function IsLetterOrDigit(C: Char): Boolean; overload;
function IsLetterOrDigit(C: UCS4Char): Boolean; overload;
function IsLetterOrDigit(const S: string; Index: Integer): Boolean; overload;

function IsLower(C: Char): Boolean; overload;
function IsLower(C: UCS4Char): Boolean; overload;
function IsLower(const S: string; Index: Integer): Boolean; overload;

function IsNumber(C: Char): Boolean; overload;
function IsNumber(C: UCS4Char): Boolean; overload;
function IsNumber(const S: string; Index: Integer): Boolean; overload;

function IsPunctuation(C: Char): Boolean; overload;
function IsPunctuation(C: UCS4Char): Boolean; overload;
function IsPunctuation(const S: string; Index: Integer): Boolean; overload;

function IsSeparator(C: Char): Boolean; overload;
function IsSeparator(C: UCS4Char): Boolean; overload;
function IsSeparator(const S: string; Index: Integer): Boolean; overload;

function IsSymbol(C: Char): Boolean; overload;
function IsSymbol(C: UCS4Char): Boolean; overload;
function IsSymbol(const S: string; Index: Integer): Boolean; overload;

function IsUpper(C: Char): Boolean; overload;
function IsUpper(C: UCS4Char): Boolean; overload;
function IsUpper(const S: string; Index: Integer): Boolean; overload;

function IsWhiteSpace(C: Char): Boolean; overload;
function IsWhiteSpace(C: UCS4Char): Boolean; overload;
function IsWhiteSpace(const S: string; Index: Integer): Boolean; overload;

function IsHighSurrogate(C: Char): Boolean; overload;
function IsHighSurrogate(const S: string; Index: Integer): Boolean; overload;

function IsLowSurrogate(C: Char): Boolean; overload;
function IsLowSurrogate(const S: string; Index: Integer): Boolean; overload;

function IsSurrogate(C: Char): Boolean; overload;
function IsSurrogate(const S: string; Index: Integer): Boolean; overload;

function IsSurrogatePair(HighSurrogate, LowSurrogate: Char): Boolean; overload;
function IsSurrogatePair(const S: string; Index: Integer): Boolean; overload;

function ToLower(C: Char): Char; overload;
function ToLower(C: UCS4Char): UCS4Char; overload;
function ToLower(const S: string): string; overload;

function ToLowerInvariant(C: Char): Char; overload;
function ToLowerInvariant(C: UCS4Char): UCS4Char; overload;

function ToUpper(C: Char): Char; overload;
function ToUpper(C: UCS4Char): UCS4Char; overload;
function ToUpper(const S: string): string; overload;

function ToUpperInvariant(C: Char): Char; overload;
function ToUpperInvariant(C: UCS4Char): UCS4Char; overload;

implementation

class function TCharacter.ConvertFromUtf32(ConvertChar: UCS4Char): string;
begin
end;

class function TCharacter.ConvertToUtf32(HighSurrogate, LowSurrogate: Char): UCS4Char;
begin
end;

class function TCharacter.ConvertToUtf32(const S: string; Index: Integer): UCS4Char;
begin
end;

class function TCharacter.GetNumericValue(C: Char): Double;
begin
end;

class function TCharacter.GetNumericValue(C: UCS4Char): Double;
begin
end;

class function TCharacter.GetNumericValue(const S: string; Index: Integer): Double;
begin
end;

class function TCharacter.GetUnicodeCategory(C: Char): TUnicodeCategory;
begin
end;

class function TCharacter.GetUnicodeCategory(C: UCS4Char): TUnicodeCategory;
begin
end;

class function TCharacter.GetUnicodeCategory(const S: string; Index: Integer): TUnicodeCategory;
begin
end;

class function TCharacter.IsControl(C: Char): Boolean;
begin
end;

class function TCharacter.IsControl(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsControl(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsDefined(C: Char): Boolean;
begin
end;

class function TCharacter.IsDefined(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsDefined(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsDigit(C: Char): Boolean;
begin
end;

class function TCharacter.IsDigit(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsDigit(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsHighSurrogate(C: Char): Boolean;
begin
end;

class function TCharacter.IsHighSurrogate(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsLetter(C: Char): Boolean;
begin
end;

class function TCharacter.IsLetter(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsLetter(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsLetterOrDigit(C: Char): Boolean;
begin
end;

class function TCharacter.IsLetterOrDigit(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsLetterOrDigit(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsLowSurrogate(C: Char): Boolean;
begin
end;

class function TCharacter.IsLowSurrogate(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsLower(C: Char): Boolean;
begin
end;

class function TCharacter.IsLower(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsLower(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsNumber(C: Char): Boolean;
begin
end;

class function TCharacter.IsNumber(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsNumber(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsPunctuation(C: Char): Boolean;
begin
end;

class function TCharacter.IsPunctuation(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsPunctuation(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsSeparator(C: Char): Boolean;
begin
end;

class function TCharacter.IsSeparator(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsSeparator(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsSurrogate(C: Char): Boolean;
begin
end;

class function TCharacter.IsSurrogate(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsSurrogatePair(HighSurrogate, LowSurrogate: Char): Boolean;
begin
end;

class function TCharacter.IsSurrogatePair(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsSymbol(C: Char): Boolean;
begin
end;

class function TCharacter.IsSymbol(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsSymbol(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsUpper(C: Char): Boolean;
begin
end;

class function TCharacter.IsUpper(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsUpper(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.IsWhiteSpace(C: Char): Boolean;
begin
end;

class function TCharacter.IsWhiteSpace(C: UCS4Char): Boolean;
begin
end;

class function TCharacter.IsWhiteSpace(const S: string; Index: Integer): Boolean;
begin
end;

class function TCharacter.ToLower(C: Char): Char;
begin
end;

class function TCharacter.ToLower(C: UCS4Char): UCS4Char;
begin
end;

class function TCharacter.ToLower(const S: string): string;
begin
end;

class function TCharacter.ToLowerInvariant(C: Char): Char;
begin
end;

class function TCharacter.ToLowerInvariant(C: UCS4Char): UCS4Char;
begin
end;

class function TCharacter.ToUpper(C: Char): Char;
begin
end;

class function TCharacter.ToUpper(C: UCS4Char): UCS4Char;
begin
end;

class function TCharacter.ToUpper(const S: string): string;
begin
end;

class function TCharacter.ToUpperInvariant(C: Char): Char;
begin
end;

class function TCharacter.ToUpperInvariant(C: UCS4Char): UCS4Char;
begin
end;

function ConvertFromUtf32(ConvertChar: UCS4Char): string;
begin
end;

function ConvertToUtf32(HighSurrogate, LowSurrogate: Char): UCS4Char;
begin
end;

function ConvertToUtf32(const S: string; Index: Integer): UCS4Char;
begin
end;

function GetNumericValue(C: Char): Double;
begin
end;

function GetNumericValue(C: UCS4Char): Double;
begin
end;

function GetNumericValue(const S: string; Index: Integer): Double;
begin
end;

function GetUnicodeCategory(C: Char): TUnicodeCategory;
begin
end;

function GetUnicodeCategory(C: UCS4Char): TUnicodeCategory;
begin
end;

function GetUnicodeCategory(const S: string; Index: Integer): TUnicodeCategory;
begin
end;

function IsControl(C: Char): Boolean;
begin
end;

function IsControl(C: UCS4Char): Boolean;
begin
end;

function IsControl(const S: string; Index: Integer): Boolean;
begin
end;

function IsDefined(C: Char): Boolean;
begin
end;

function IsDefined(C: UCS4Char): Boolean;
begin
end;

function IsDefined(const S: string; Index: Integer): Boolean;
begin
end;

function IsDigit(C: Char): Boolean;
begin
end;

function IsDigit(C: UCS4Char): Boolean;
begin
end;

function IsDigit(const S: string; Index: Integer): Boolean;
begin
end;

function IsLetter(C: Char): Boolean;
begin
end;

function IsLetter(C: UCS4Char): Boolean;
begin
end;

function IsLetter(const S: string; Index: Integer): Boolean;
begin
end;

function IsLetterOrDigit(C: Char): Boolean;
begin
end;

function IsLetterOrDigit(C: UCS4Char): Boolean;
begin
end;

function IsLetterOrDigit(const S: string; Index: Integer): Boolean;
begin
end;

function IsLower(C: Char): Boolean;
begin
end;

function IsLower(C: UCS4Char): Boolean;
begin
end;

function IsLower(const S: string; Index: Integer): Boolean;
begin
end;

function IsNumber(C: Char): Boolean;
begin
end;

function IsNumber(C: UCS4Char): Boolean;
begin
end;

function IsNumber(const S: string; Index: Integer): Boolean;
begin
end;

function IsPunctuation(C: Char): Boolean;
begin
end;

function IsPunctuation(C: UCS4Char): Boolean;
begin
end;

function IsPunctuation(const S: string; Index: Integer): Boolean;
begin
end;

function IsSeparator(C: Char): Boolean;
begin
end;

function IsSeparator(C: UCS4Char): Boolean;
begin
end;

function IsSeparator(const S: string; Index: Integer): Boolean;
begin
end;

function IsSymbol(C: Char): Boolean;
begin
end;

function IsSymbol(C: UCS4Char): Boolean;
begin
end;

function IsSymbol(const S: string; Index: Integer): Boolean;
begin
end;

function IsUpper(C: Char): Boolean;
begin
end;

function IsUpper(C: UCS4Char): Boolean;
begin
end;

function IsUpper(const S: string; Index: Integer): Boolean;
begin
end;

function IsWhiteSpace(C: Char): Boolean;
begin
end;

function IsWhiteSpace(C: UCS4Char): Boolean;
begin
end;

function IsWhiteSpace(const S: string; Index: Integer): Boolean;
begin
end;

function IsHighSurrogate(C: Char): Boolean;
begin
end;

function IsHighSurrogate(const S: string; Index: Integer): Boolean;
begin
end;

function IsLowSurrogate(C: Char): Boolean;
begin
end;

function IsLowSurrogate(const S: string; Index: Integer): Boolean;
begin
end;

function IsSurrogate(C: Char): Boolean;
begin
end;

function IsSurrogate(const S: string; Index: Integer): Boolean;
begin
end;

function IsSurrogatePair(HighSurrogate, LowSurrogate: Char): Boolean;
begin
end;

function IsSurrogatePair(const S: string; Index: Integer): Boolean;
begin
end;

function ToLower(C: Char): Char;
begin
end;

function ToLower(C: UCS4Char): UCS4Char;
begin
end;

function ToLower(const S: string): string;
begin
end;

function ToLowerInvariant(C: Char): Char;
begin
end;

function ToLowerInvariant(C: UCS4Char): UCS4Char;
begin
end;

function ToUpper(C: Char): Char;
begin
end;

function ToUpper(C: UCS4Char): UCS4Char;
begin
end;

function ToUpper(const S: string): string;
begin
end;

function ToUpperInvariant(C: Char): Char;
begin
end;

function ToUpperInvariant(C: UCS4Char): UCS4Char;
begin
end;

end.
