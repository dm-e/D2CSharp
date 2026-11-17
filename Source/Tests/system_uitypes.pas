{
  D2CSharp test file

  Original source language: Delphi (Pascal).
  The corresponding C# files are automatically translated from the
  Delphi source files by D2CSharp.
  This notice is retained unchanged in both versions.

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

unit system_uitypes;

interface

function SUT_RunAllTests: Boolean;

implementation

// XE3: Some virtual-key constants are not declared in System.UITypes.
// Use DECLARED to enable only tests for constants present in the RTL.

uses
  System.UITypes;

// Browser and media key constants are missing in Delphi XE3.
// The following tests are compiled only when all referenced constants exist.
{$IF Declared(vkBrowserBack) and Declared(vkBrowserForward) and Declared(vkBrowserRefresh) and Declared(vkBrowserStop) and Declared(vkBrowserSearch)}
  {$DEFINE SUT_HAS_BROWSER_VK}
{$IFEND}

{$IF Declared(vkVolumeMute) and Declared(vkVolumeDown) and Declared(vkVolumeUp) and Declared(vkMediaNextTrack) and Declared(vkMediaPlayPause)}
  {$DEFINE SUT_HAS_MEDIA_VK}
{$IFEND}

// System.UITypes uses scoped enumerations. Members are accessed via
// TEnumType.Member, without relying on aliases from VCL units.

// Each test returns False on failure or an exception.
// No VCL or FireMonkey units are required.
// Test functions are private to this unit.

function SUT_TestModalResultValues: Boolean;
begin
  try
    Result := (mrNone = 0);
    Result := Result and (mrOk = 1);
    Result := Result and (mrCancel = 2);
    Result := Result and (mrAbort = 3);
    Result := Result and (mrRetry = 4);
    Result := Result and (mrIgnore = 5);
    Result := Result and (mrYes = 6);
    Result := Result and (mrNo = 7);
    Result := Result and (mrClose = 8);
    Result := Result and (mrHelp = 9);
    Result := Result and (mrTryAgain = 10);
    Result := Result and (mrContinue = 11);
    Result := Result and (mrAll = 12);
    Result := Result and (mrNoToAll = 13);
    Result := Result and (mrYesToAll = 14);
  except
    Result := False;
  end;
end;

function SUT_TestModalResultType: Boolean;
begin
  try
    Result := (SizeOf(TModalResult) = SizeOf(Integer));
    Result := Result and (TModalResult(mrYes) = 6);
    Result := Result and (TModalResult(mrNone) = 0);
  except
    Result := False;
  end;
end;

function SUT_TestPositiveResults: Boolean;
begin
  try
    Result := (IsPositiveResult(mrOk));
    Result := Result and (IsPositiveResult(mrYes));
    Result := Result and (IsPositiveResult(mrYesToAll));
    Result := Result and (IsPositiveResult(mrAll));
  except
    Result := False;
  end;
end;

function SUT_TestPositiveResultsNegativeCases: Boolean;
begin
  try
    Result := (not IsPositiveResult(mrNone));
    Result := Result and (not IsPositiveResult(mrNo));
    Result := Result and (not IsPositiveResult(mrNoToAll));
    Result := Result and (not IsPositiveResult(mrCancel));
    Result := Result and (not IsPositiveResult(mrClose));
  except
    Result := False;
  end;
end;

function SUT_TestNegativeResults: Boolean;
begin
  try
    Result := (IsNegativeResult(mrNo));
    Result := Result and (IsNegativeResult(mrNoToAll));
  except
    Result := False;
  end;
end;

function SUT_TestNegativeResultsNegativeCases: Boolean;
begin
  try
    Result := (not IsNegativeResult(mrNone));
    Result := Result and (not IsNegativeResult(mrOk));
    Result := Result and (not IsNegativeResult(mrYes));
    Result := Result and (not IsNegativeResult(mrYesToAll));
    Result := Result and (not IsNegativeResult(mrCancel));
  except
    Result := False;
  end;
end;

function SUT_TestAbortResults: Boolean;
begin
  try
    Result := (IsAbortResult(mrAbort));
    Result := Result and (IsAbortResult(mrCancel));
  except
    Result := False;
  end;
end;

function SUT_TestAbortResultsNegativeCases: Boolean;
begin
  try
    Result := (not IsAbortResult(mrNone));
    Result := Result and (not IsAbortResult(mrOk));
    Result := Result and (not IsAbortResult(mrYes));
    Result := Result and (not IsAbortResult(mrNo));
    Result := Result and (not IsAbortResult(mrClose));
  except
    Result := False;
  end;
end;

function SUT_TestAllResults: Boolean;
begin
  try
    Result := (IsAnAllResult(mrAll));
    Result := Result and (IsAnAllResult(mrYesToAll));
    Result := Result and (IsAnAllResult(mrNoToAll));
  except
    Result := False;
  end;
end;

function SUT_TestAllResultsNegativeCases: Boolean;
begin
  try
    Result := (not IsAnAllResult(mrNone));
    Result := Result and (not IsAnAllResult(mrOk));
    Result := Result and (not IsAnAllResult(mrYes));
    Result := Result and (not IsAnAllResult(mrNo));
    Result := Result and (not IsAnAllResult(mrCancel));
  except
    Result := False;
  end;
end;

function SUT_TestStripAllResults: Boolean;
begin
  try
    Result := (StripAllFromResult(mrAll) = mrOk);
    Result := Result and (StripAllFromResult(mrYesToAll) = mrYes);
    Result := Result and (StripAllFromResult(mrNoToAll) = mrNo);
  except
    Result := False;
  end;
end;

function SUT_TestStripNormalResults: Boolean;
begin
  try
    Result := (StripAllFromResult(mrNone) = mrNone);
    Result := Result and (StripAllFromResult(mrOk) = mrOk);
    Result := Result and (StripAllFromResult(mrNo) = mrNo);
    Result := Result and (StripAllFromResult(mrYes) = mrYes);
    Result := Result and (StripAllFromResult(mrCancel) = mrCancel);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaColorPrimitives: Boolean;
begin
  try
    Result := (SizeOf(TAlphaColor) = 4);
    Result := Result and (Cardinal(TAlphaColorRec.Red) = $FFFF0000);
    Result := Result and (Cardinal(TAlphaColorRec.Green) = $FF008000);
    Result := Result and (Cardinal(TAlphaColorRec.Blue) = $FF0000FF);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaColorRgbConstants: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Lime) = $FF00FF00);
    Result := Result and (Cardinal(TAlphaColorRec.Yellow) = $FFFFFF00);
    Result := Result and (Cardinal(TAlphaColorRec.Aqua) = $FF00FFFF);
    Result := Result and (Cardinal(TAlphaColorRec.Fuchsia) = $FFFF00FF);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaColorSimpleConstants: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Black) = $FF000000);
    Result := Result and (Cardinal(TAlphaColorRec.White) = $FFFFFFFF);
    Result := Result and (Cardinal(TAlphaColorRec.Null) = 0);
    Result := Result and (Cardinal(TAlphaColorRec.Alpha) = $FF000000);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaColorExtendedConstants: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Orange) = $FFFFA500);
    Result := Result and (Cardinal(TAlphaColorRec.Navy) = $FF000080);
    Result := Result and (Cardinal(TAlphaColorRec.Purple) = $FF800080);
    Result := Result and (Cardinal(TAlphaColorRec.Coral) = $FFFF7F50);
    Result := Result and (Cardinal(TAlphaColorRec.Silver) = $FFC0C0C0);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaColorNameAliases: Boolean;
begin
  try
    Result := (TAlphaColorRec.Cyan = TAlphaColorRec.Aqua);
    Result := Result and (TAlphaColorRec.Magenta = TAlphaColorRec.Fuchsia);
    Result := Result and (TAlphaColorRec.Grey = TAlphaColorRec.Gray);
    Result := Result and (TAlphaColorRec.Darkgrey = TAlphaColorRec.Darkgray);
  except
    Result := False;
  end;
end;

// The record constructor is not available in Delphi XE3.
// Enable this test only for RTL versions where it is documented.
{$IF CompilerVersion >= 34.0}
function SUT_TestAlphaRecordConstructor: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R := TAlphaColorRec.Create(TAlphaColor($7F123456));
    Result := R.Color = TAlphaColor($7F123456);
    Result := Result and (R.A = $7F);
    Result := Result and (R.R = $12);
    Result := Result and (R.G = $34);
    Result := Result and (R.B = $56);
  except
    Result := False;
  end;
end;

{$IFEND}
function SUT_TestAlphaRecordReadChannels: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColor($A1B2C3D4);
    Result := R.A = $A1;
    Result := Result and (R.R = $B2);
    Result := Result and (R.G = $C3);
    Result := Result and (R.B = $D4);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordWriteChannels: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColor(0);
    R.A := $AA;
    R.R := $BB;
    R.G := $CC;
    R.B := $DD;
    Result := R.Color = TAlphaColor($AABBCCDD);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordModifyChannel: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColor($10203040);
    R.G := $99;
    Result := R.Color = TAlphaColor($10209940);
    Result := Result and (R.A = $10);
    Result := Result and (R.R = $20);
    Result := Result and (R.B = $40);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordWordOverlay: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColor($12345678);
    Result := R.HiWord = $5678;
    Result := Result and (R.LoWord = $1234);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordCopy: Boolean;
var
  A, B: TAlphaColorRec;
begin
  try
    A.Color := TAlphaColor($AABBCCDD);
    B := A;
    B.R := $11;
    Result := A.Color = TAlphaColor($AABBCCDD);
    Result := Result and (B.Color = TAlphaColor($AA11CCDD));
  except
    Result := False;
  end;
end;

function SUT_TestAlphaColorPointer: Boolean;
var
  C: TAlphaColor;
  P: PAlphaColor;
begin
  try
    C := TAlphaColorRec.Red;
    P := @C;
    Result := P^ = TAlphaColorRec.Red;
    P^ := TAlphaColorRec.Blue;
    Result := Result and (C = TAlphaColorRec.Blue);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPointer: Boolean;
var
  R: TAlphaColorRec;
  P: PAlphaColorRec;
begin
  try
    R.Color := TAlphaColor($11223344);
    P := @R;
    P^.A := $FE;
    Result := R.Color = TAlphaColor($FE223344);
  except
    Result := False;
  end;
end;

// Additional TAlphaColorRec tests (Delphi XE3 compatible).

// The byte channel and word fields overlap the Color field in XE3.
// These tests deliberately avoid TAlphaColorRec.Create (not available in XE3).

function SUT_TestAlphaRecordSize: Boolean;
begin
  try
    Result := SizeOf(TAlphaColorRec) = SizeOf(TAlphaColor);
    Result := Result and (SizeOf(TAlphaColorRec) = 4);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordZeroChannels: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColorRec.Null;
    Result := R.A = 0;
    Result := Result and (R.R = 0);
    Result := Result and (R.G = 0);
    Result := Result and (R.B = 0);
    Result := Result and (R.HiWord = 0);
    Result := Result and (R.LoWord = 0);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordAlphaChange: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColor($00123456);
    R.A := $EF;
    Result := R.Color = TAlphaColor($EF123456);
    Result := Result and (R.R = $12);
    Result := Result and (R.G = $34);
    Result := Result and (R.B = $56);
    R.A := 0;
    Result := Result and (R.Color = TAlphaColor($00123456));
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordWriteWords: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColor(0);
    R.HiWord := $3344;
    R.LoWord := $1122;
    Result := R.Color = TAlphaColor($11223344);
    Result := Result and (R.A = $11);
    Result := Result and (R.R = $22);
    Result := Result and (R.G = $33);
    Result := Result and (R.B = $44);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordEachChannel: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColor($10203040);
    R.B := $DD;
    Result := R.Color = TAlphaColor($102030DD);
    R.G := $CC;
    Result := Result and (R.Color = TAlphaColor($1020CCDD));
    R.R := $BB;
    Result := Result and (R.Color = TAlphaColor($10BBCCDD));
    R.A := $AA;
    Result := Result and (R.Color = TAlphaColor($AABBCCDD));
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordChannelLimits: Boolean;
var
  R: TAlphaColorRec;
begin
  try
    R.Color := TAlphaColor($FFFFFFFF);
    Result := (R.A = 255);
    Result := Result and (R.R = 255);
    Result := Result and (R.G = 255);
    Result := Result and (R.B = 255);
    R.B := 0;
    R.G := 0;
    R.R := 0;
    R.A := 0;
    Result := Result and (R.Color = TAlphaColor(0));
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordByteOrder: Boolean;
var
  R: TAlphaColorRec;
  P: PByte;
begin
  try
    R.Color := TAlphaColor($12345678);
    P := @R;
    Result := P^ = $78;
    Inc(P);
    Result := Result and (P^ = $56);
    Inc(P);
    Result := Result and (P^ = $34);
    Inc(P);
    Result := Result and (P^ = $12);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPointerChannels: Boolean;
var
  R: TAlphaColorRec;
  P: PAlphaColorRec;
begin
  try
    R.Color := TAlphaColor($12345678);
    P := @R;
    P^.G := $AB;
    Result := R.Color = TAlphaColor($1234AB78);
    P^.A := $EF;
    Result := Result and (R.Color = TAlphaColor($EF34AB78));
    Result := Result and (P^.R = $34);
    Result := Result and (P^.B = $78);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordArrayCopies: Boolean;
var
  Items: array[0..1] of TAlphaColorRec;
begin
  try
    Items[0].Color := TAlphaColor($11223344);
    Items[1].Color := TAlphaColor($55667788);
    Items[1] := Items[0];
    Items[1].B := $99;
    Result := Items[0].Color = TAlphaColor($11223344);
    Result := Result and (Items[1].Color = TAlphaColor($11223399));
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordAliasColors: Boolean;
begin
  try
    Result := (TAlphaColorRec.Aqua = TAlphaColorRec.Cyan);
    Result := Result and (TAlphaColorRec.Fuchsia = TAlphaColorRec.Magenta);
    Result := Result and (TAlphaColorRec.Gray = TAlphaColorRec.Grey);
    Result := Result and (TAlphaColorRec.Darkgray = TAlphaColorRec.Darkgrey);
    Result := Result and (TAlphaColorRec.Dimgray = TAlphaColorRec.Dimgrey);
    Result := Result and (TAlphaColorRec.Lightgray = TAlphaColorRec.Lightgrey);
    Result := Result and (TAlphaColorRec.Lightslategray = TAlphaColorRec.Lightslategrey);
    Result := Result and (TAlphaColorRec.Slategray = TAlphaColorRec.Slategrey);
    Result := Result and (TAlphaColorRec.Darkslategray = TAlphaColorRec.Darkslategrey);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordLegacyColors: Boolean;
begin
  try
    Result := Cardinal(TAlphaColorRec.LtGray) = $FFC0C0C0;
    Result := Result and (Cardinal(TAlphaColorRec.MedGray) = $FFA0A0A0);
    Result := Result and (Cardinal(TAlphaColorRec.DkGray) = $FF808080);
    Result := Result and (Cardinal(TAlphaColorRec.MoneyGreen) = $FFC0DCC0);
    // Historical RTL revisions differ on the RGB bytes of these names.
    Result := Result and ((Cardinal(TAlphaColorRec.LegacySkyBlue) and $FF000000) = $FF000000);
    Result := Result and ((Cardinal(TAlphaColorRec.Cream) and $FF000000) = $FF000000);
  except
    Result := False;
  end;
end;

// The callback field is optional in older System.UITypes revisions.
//{$IF Declared(TAlphaColorRec.ColorToRGB)}
type
  SUT_TAlphaColorRGBProc = function(Color: TAlphaColor): Longint;

function SUT_AlphaColorRGBCallback(Color: TAlphaColor): Longint;
begin
  Result := Longint(Cardinal(Color) and $00FFFFFF);
end;

function SUT_TestAlphaRecordColorToRGBCallback: Boolean;
var
  OldCallback: SUT_TAlphaColorRGBProc;
begin
  try
    OldCallback := TAlphaColorRec.ColorToRGB;
    try
      TAlphaColorRec.ColorToRGB := SUT_AlphaColorRGBCallback;
      Result := TAlphaColorRec.ColorToRGB(TAlphaColor($AB102030)) = $102030;
    finally
      TAlphaColorRec.ColorToRGB := OldCallback;
    end;
  except
    Result := False;
  end;
end;
//{$IFEND}

// ARGB values of the standard named colors.

function SUT_TestAlphaRecordPalette01: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Aliceblue) = $FFF0F8FF);
    Result := Result and (Cardinal(TAlphaColorRec.Antiquewhite) = $FFFAEBD7);
    Result := Result and (Cardinal(TAlphaColorRec.Aqua) = $FF00FFFF);
    Result := Result and (Cardinal(TAlphaColorRec.Aquamarine) = $FF7FFFD4);
    Result := Result and (Cardinal(TAlphaColorRec.Azure) = $FFF0FFFF);
    Result := Result and (Cardinal(TAlphaColorRec.Beige) = $FFF5F5DC);
    Result := Result and (Cardinal(TAlphaColorRec.Bisque) = $FFFFE4C4);
    Result := Result and (Cardinal(TAlphaColorRec.Black) = $FF000000);
    Result := Result and (Cardinal(TAlphaColorRec.Blanchedalmond) = $FFFFEBCD);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette02: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Blue) = $FF0000FF);
    Result := Result and (Cardinal(TAlphaColorRec.Blueviolet) = $FF8A2BE2);
    Result := Result and (Cardinal(TAlphaColorRec.Brown) = $FFA52A2A);
    Result := Result and (Cardinal(TAlphaColorRec.Burlywood) = $FFDEB887);
    Result := Result and (Cardinal(TAlphaColorRec.Cadetblue) = $FF5F9EA0);
    Result := Result and (Cardinal(TAlphaColorRec.Chartreuse) = $FF7FFF00);
    Result := Result and (Cardinal(TAlphaColorRec.Chocolate) = $FFD2691E);
    Result := Result and (Cardinal(TAlphaColorRec.Coral) = $FFFF7F50);
    Result := Result and (Cardinal(TAlphaColorRec.Cornflowerblue) = $FF6495ED);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette03: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Cornsilk) = $FFFFF8DC);
    Result := Result and (Cardinal(TAlphaColorRec.Crimson) = $FFDC143C);
    Result := Result and (Cardinal(TAlphaColorRec.Cyan) = $FF00FFFF);
    Result := Result and (Cardinal(TAlphaColorRec.Darkblue) = $FF00008B);
    Result := Result and (Cardinal(TAlphaColorRec.Darkcyan) = $FF008B8B);
    Result := Result and (Cardinal(TAlphaColorRec.Darkgoldenrod) = $FFB8860B);
    Result := Result and (Cardinal(TAlphaColorRec.Darkgray) = $FFA9A9A9);
    Result := Result and (Cardinal(TAlphaColorRec.Darkgreen) = $FF006400);
    Result := Result and (Cardinal(TAlphaColorRec.Darkgrey) = $FFA9A9A9);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette04: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Darkkhaki) = $FFBDB76B);
    Result := Result and (Cardinal(TAlphaColorRec.Darkmagenta) = $FF8B008B);
    Result := Result and (Cardinal(TAlphaColorRec.Darkolivegreen) = $FF556B2F);
    Result := Result and (Cardinal(TAlphaColorRec.Darkorange) = $FFFF8C00);
    Result := Result and (Cardinal(TAlphaColorRec.Darkorchid) = $FF9932CC);
    Result := Result and (Cardinal(TAlphaColorRec.Darkred) = $FF8B0000);
    Result := Result and (Cardinal(TAlphaColorRec.Darksalmon) = $FFE9967A);
    Result := Result and (Cardinal(TAlphaColorRec.Darkseagreen) = $FF8FBC8F);
    Result := Result and (Cardinal(TAlphaColorRec.Darkslateblue) = $FF483D8B);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette05: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Darkslategray) = $FF2F4F4F);
    Result := Result and (Cardinal(TAlphaColorRec.Darkslategrey) = $FF2F4F4F);
    Result := Result and (Cardinal(TAlphaColorRec.Darkturquoise) = $FF00CED1);
    Result := Result and (Cardinal(TAlphaColorRec.Darkviolet) = $FF9400D3);
    Result := Result and (Cardinal(TAlphaColorRec.Deeppink) = $FFFF1493);
    Result := Result and (Cardinal(TAlphaColorRec.Deepskyblue) = $FF00BFFF);
    Result := Result and (Cardinal(TAlphaColorRec.Dimgray) = $FF696969);
    Result := Result and (Cardinal(TAlphaColorRec.Dimgrey) = $FF696969);
    Result := Result and (Cardinal(TAlphaColorRec.Dodgerblue) = $FF1E90FF);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette06: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Firebrick) = $FFB22222);
    Result := Result and (Cardinal(TAlphaColorRec.Floralwhite) = $FFFFFAF0);
    Result := Result and (Cardinal(TAlphaColorRec.Forestgreen) = $FF228B22);
    Result := Result and (Cardinal(TAlphaColorRec.Fuchsia) = $FFFF00FF);
    Result := Result and (Cardinal(TAlphaColorRec.Gainsboro) = $FFDCDCDC);
    Result := Result and (Cardinal(TAlphaColorRec.Ghostwhite) = $FFF8F8FF);
    Result := Result and (Cardinal(TAlphaColorRec.Gold) = $FFFFD700);
    Result := Result and (Cardinal(TAlphaColorRec.Goldenrod) = $FFDAA520);
    Result := Result and (Cardinal(TAlphaColorRec.Gray) = $FF808080);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette07: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Green) = $FF008000);
    Result := Result and (Cardinal(TAlphaColorRec.Greenyellow) = $FFADFF2F);
    Result := Result and (Cardinal(TAlphaColorRec.Grey) = $FF808080);
    Result := Result and (Cardinal(TAlphaColorRec.Honeydew) = $FFF0FFF0);
    Result := Result and (Cardinal(TAlphaColorRec.Hotpink) = $FFFF69B4);
    Result := Result and (Cardinal(TAlphaColorRec.Indianred) = $FFCD5C5C);
    Result := Result and (Cardinal(TAlphaColorRec.Indigo) = $FF4B0082);
    Result := Result and (Cardinal(TAlphaColorRec.Ivory) = $FFFFFFF0);
    Result := Result and (Cardinal(TAlphaColorRec.Khaki) = $FFF0E68C);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette08: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Lavender) = $FFE6E6FA);
    Result := Result and (Cardinal(TAlphaColorRec.Lavenderblush) = $FFFFF0F5);
    Result := Result and (Cardinal(TAlphaColorRec.Lawngreen) = $FF7CFC00);
    Result := Result and (Cardinal(TAlphaColorRec.Lemonchiffon) = $FFFFFACD);
    Result := Result and (Cardinal(TAlphaColorRec.Lightblue) = $FFADD8E6);
    Result := Result and (Cardinal(TAlphaColorRec.Lightcoral) = $FFF08080);
    Result := Result and (Cardinal(TAlphaColorRec.Lightcyan) = $FFE0FFFF);
    Result := Result and (Cardinal(TAlphaColorRec.Lightgoldenrodyellow) = $FFFAFAD2);
    Result := Result and (Cardinal(TAlphaColorRec.Lightgray) = $FFD3D3D3);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette09: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Lightgreen) = $FF90EE90);
    Result := Result and (Cardinal(TAlphaColorRec.Lightgrey) = $FFD3D3D3);
    Result := Result and (Cardinal(TAlphaColorRec.Lightpink) = $FFFFB6C1);
    Result := Result and (Cardinal(TAlphaColorRec.Lightsalmon) = $FFFFA07A);
    Result := Result and (Cardinal(TAlphaColorRec.Lightseagreen) = $FF20B2AA);
    Result := Result and (Cardinal(TAlphaColorRec.Lightskyblue) = $FF87CEFA);
    Result := Result and (Cardinal(TAlphaColorRec.Lightslategray) = $FF778899);
    Result := Result and (Cardinal(TAlphaColorRec.Lightslategrey) = $FF778899);
    Result := Result and (Cardinal(TAlphaColorRec.Lightsteelblue) = $FFB0C4DE);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette10: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Lightyellow) = $FFFFFFE0);
    Result := Result and (Cardinal(TAlphaColorRec.Lime) = $FF00FF00);
    Result := Result and (Cardinal(TAlphaColorRec.Limegreen) = $FF32CD32);
    Result := Result and (Cardinal(TAlphaColorRec.Linen) = $FFFAF0E6);
    Result := Result and (Cardinal(TAlphaColorRec.Magenta) = $FFFF00FF);
    Result := Result and (Cardinal(TAlphaColorRec.Maroon) = $FF800000);
    Result := Result and (Cardinal(TAlphaColorRec.Mediumaquamarine) = $FF66CDAA);
    Result := Result and (Cardinal(TAlphaColorRec.Mediumblue) = $FF0000CD);
    Result := Result and (Cardinal(TAlphaColorRec.Mediumorchid) = $FFBA55D3);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette11: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Mediumpurple) = $FF9370DB);
    Result := Result and (Cardinal(TAlphaColorRec.Mediumseagreen) = $FF3CB371);
    Result := Result and (Cardinal(TAlphaColorRec.Mediumslateblue) = $FF7B68EE);
    Result := Result and (Cardinal(TAlphaColorRec.Mediumspringgreen) = $FF00FA9A);
    Result := Result and (Cardinal(TAlphaColorRec.Mediumturquoise) = $FF48D1CC);
    Result := Result and (Cardinal(TAlphaColorRec.Mediumvioletred) = $FFC71585);
    Result := Result and (Cardinal(TAlphaColorRec.Midnightblue) = $FF191970);
    Result := Result and (Cardinal(TAlphaColorRec.Mintcream) = $FFF5FFFA);
    Result := Result and (Cardinal(TAlphaColorRec.Mistyrose) = $FFFFE4E1);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette12: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Moccasin) = $FFFFE4B5);
    Result := Result and (Cardinal(TAlphaColorRec.Navajowhite) = $FFFFDEAD);
    Result := Result and (Cardinal(TAlphaColorRec.Navy) = $FF000080);
    Result := Result and (Cardinal(TAlphaColorRec.Oldlace) = $FFFDF5E6);
    Result := Result and (Cardinal(TAlphaColorRec.Olive) = $FF808000);
    Result := Result and (Cardinal(TAlphaColorRec.Olivedrab) = $FF6B8E23);
    Result := Result and (Cardinal(TAlphaColorRec.Orange) = $FFFFA500);
    Result := Result and (Cardinal(TAlphaColorRec.Orangered) = $FFFF4500);
    Result := Result and (Cardinal(TAlphaColorRec.Orchid) = $FFDA70D6);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette13: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Palegoldenrod) = $FFEEE8AA);
    Result := Result and (Cardinal(TAlphaColorRec.Palegreen) = $FF98FB98);
    Result := Result and (Cardinal(TAlphaColorRec.Paleturquoise) = $FFAFEEEE);
    Result := Result and (Cardinal(TAlphaColorRec.Palevioletred) = $FFDB7093);
    Result := Result and (Cardinal(TAlphaColorRec.Papayawhip) = $FFFFEFD5);
    Result := Result and (Cardinal(TAlphaColorRec.Peachpuff) = $FFFFDAB9);
    Result := Result and (Cardinal(TAlphaColorRec.Peru) = $FFCD853F);
    Result := Result and (Cardinal(TAlphaColorRec.Pink) = $FFFFC0CB);
    Result := Result and (Cardinal(TAlphaColorRec.Plum) = $FFDDA0DD);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette14: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Powderblue) = $FFB0E0E6);
    Result := Result and (Cardinal(TAlphaColorRec.Purple) = $FF800080);
    Result := Result and (Cardinal(TAlphaColorRec.Red) = $FFFF0000);
    Result := Result and (Cardinal(TAlphaColorRec.Rosybrown) = $FFBC8F8F);
    Result := Result and (Cardinal(TAlphaColorRec.Royalblue) = $FF4169E1);
    Result := Result and (Cardinal(TAlphaColorRec.Saddlebrown) = $FF8B4513);
    Result := Result and (Cardinal(TAlphaColorRec.Salmon) = $FFFA8072);
    Result := Result and (Cardinal(TAlphaColorRec.Sandybrown) = $FFF4A460);
    Result := Result and (Cardinal(TAlphaColorRec.Seagreen) = $FF2E8B57);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette15: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Seashell) = $FFFFF5EE);
    Result := Result and (Cardinal(TAlphaColorRec.Sienna) = $FFA0522D);
    Result := Result and (Cardinal(TAlphaColorRec.Silver) = $FFC0C0C0);
    Result := Result and (Cardinal(TAlphaColorRec.Skyblue) = $FF87CEEB);
    Result := Result and (Cardinal(TAlphaColorRec.Slateblue) = $FF6A5ACD);
    Result := Result and (Cardinal(TAlphaColorRec.Slategray) = $FF708090);
    Result := Result and (Cardinal(TAlphaColorRec.Slategrey) = $FF708090);
    Result := Result and (Cardinal(TAlphaColorRec.Snow) = $FFFFFAFA);
    Result := Result and (Cardinal(TAlphaColorRec.Springgreen) = $FF00FF7F);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette16: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Steelblue) = $FF4682B4);
    Result := Result and (Cardinal(TAlphaColorRec.Tan) = $FFD2B48C);
    Result := Result and (Cardinal(TAlphaColorRec.Teal) = $FF008080);
    Result := Result and (Cardinal(TAlphaColorRec.Thistle) = $FFD8BFD8);
    Result := Result and (Cardinal(TAlphaColorRec.Tomato) = $FFFF6347);
    Result := Result and (Cardinal(TAlphaColorRec.Turquoise) = $FF40E0D0);
    Result := Result and (Cardinal(TAlphaColorRec.Violet) = $FFEE82EE);
    Result := Result and (Cardinal(TAlphaColorRec.Wheat) = $FFF5DEB3);
    Result := Result and (Cardinal(TAlphaColorRec.White) = $FFFFFFFF);
  except
    Result := False;
  end;
end;

function SUT_TestAlphaRecordPalette17: Boolean;
begin
  try
    Result := (Cardinal(TAlphaColorRec.Whitesmoke) = $FFF5F5F5);
    Result := Result and (Cardinal(TAlphaColorRec.Yellow) = $FFFFFF00);
    Result := Result and (Cardinal(TAlphaColorRec.Yellowgreen) = $FF9ACD32);
  except
    Result := False;
  end;
end;
function SUT_TestColorPrimitives: Boolean;
begin
  try
    Result := (SizeOf(TColor) = SizeOf(Integer));
    Result := Result and (Cardinal(TColorRec.Red) = $000000FF);
    Result := Result and (Cardinal(TColorRec.Green) = $00008000);
    Result := Result and (Cardinal(TColorRec.Blue) = $00FF0000);
  except
    Result := False;
  end;
end;

function SUT_TestColorRgbConstants: Boolean;
begin
  try
    Result := (Cardinal(TColorRec.Lime) = $0000FF00);
    Result := Result and (Cardinal(TColorRec.Yellow) = $0000FFFF);
    Result := Result and (Cardinal(TColorRec.Aqua) = $00FFFF00);
    Result := Result and (Cardinal(TColorRec.Fuchsia) = $00FF00FF);
  except
    Result := False;
  end;
end;

function SUT_TestColorSimpleConstants: Boolean;
begin
  try
    Result := (Cardinal(TColorRec.Black) = 0);
    Result := Result and (Cardinal(TColorRec.White) = $00FFFFFF);
    Result := Result and (Cardinal(TColorRec.Gray) = $00808080);
    Result := Result and (Cardinal(TColorRec.Null) = 0);
  except
    Result := False;
  end;
end;

function SUT_TestColorExtendedConstants: Boolean;
begin
  try
    Result := (Cardinal(TColorRec.Orange) = $0000A5FF);
    Result := Result and (Cardinal(TColorRec.Navy) = $00800000);
    Result := Result and (Cardinal(TColorRec.Purple) = $00800080);
    Result := Result and (Cardinal(TColorRec.Coral) = $00507FFF);
    Result := Result and (Cardinal(TColorRec.Silver) = $00C0C0C0);
  except
    Result := False;
  end;
end;

function SUT_TestColorNameAliases: Boolean;
begin
  try
    Result := (TColorRec.Cyan = TColorRec.Aqua);
    Result := Result and (TColorRec.Magenta = TColorRec.Fuchsia);
    Result := Result and (TColorRec.Grey = TColorRec.Gray);
    Result := Result and (TColorRec.Darkgrey = TColorRec.Darkgray);
  except
    Result := False;
  end;
end;

function SUT_TestColorSystemConstants: Boolean;
begin
  try
    Result := (Cardinal(TColorRec.SystemColor) = $FF000000);
    Result := Result and (Cardinal(TColorRec.SysWindow) = $FF000005);
    Result := Result and (Cardinal(TColorRec.SysHighlight) = $FF00000D);
    Result := Result and (Cardinal(TColorRec.SysBtnFace) = $FF00000F);
  except
    Result := False;
  end;
end;

function SUT_TestColorSystemSpecialConstants: Boolean;
begin
  try
    Result := (Cardinal(TColorRec.SysNone) = $1FFFFFFF);
    Result := Result and (Cardinal(TColorRec.SysDefault) = $20000000);
    Result := Result and (TColorRec.cWINDOW = 5);
    Result := Result and (TColorRec.cHIGHLIGHT = 13);
    Result := Result and (TColorRec.cBTNFACE = 15);
  except
    Result := False;
  end;
end;

function SUT_TestColorRecordReadChannels: Boolean;
var
  R: TColorRec;
begin
  try
    R.Color := TColor($00112233);
    Result := R.R = $33;
    Result := Result and (R.G = $22);
    Result := Result and (R.B = $11);
    Result := Result and (R.A = 0);
  except
    Result := False;
  end;
end;

function SUT_TestColorRecordWriteChannels: Boolean;
var
  R: TColorRec;
begin
  try
    R.Color := TColor(0);
    R.R := $11;
    R.G := $22;
    R.B := $33;
    R.A := 0;
    Result := Cardinal(R.Color) = $00332211;
  except
    Result := False;
  end;
end;

function SUT_TestColorRecordModifyChannel: Boolean;
var
  R: TColorRec;
begin
  try
    R.Color := TColor($00112233);
    R.G := $99;
    Result := Cardinal(R.Color) = $00119933;
    Result := Result and (R.R = $33);
    Result := Result and (R.B = $11);
  except
    Result := False;
  end;
end;

function SUT_TestColorRecordWordOverlay: Boolean;
var
  R: TColorRec;
begin
  try
    R.Color := TColor($12345678);
    Result := R.HiWord = $5678;
    Result := Result and (R.LoWord = $1234);
  except
    Result := False;
  end;
end;

function SUT_TestColorRecordCopy: Boolean;
var
  A, B: TColorRec;
begin
  try
    A.Color := TColor($00112233);
    B := A;
    B.B := $77;
    Result := Cardinal(A.Color) = $00112233;
    Result := Result and (Cardinal(B.Color) = $00772233);
  except
    Result := False;
  end;
end;

function SUT_TestColorPointer: Boolean;
var
  C: TColor;
  P: PColor;
begin
  try
    C := TColorRec.Red;
    P := @C;
    Result := P^ = TColorRec.Red;
    P^ := TColorRec.Blue;
    Result := Result and (C = TColorRec.Blue);
  except
    Result := False;
  end;
end;

function SUT_TestColorRecordPointer: Boolean;
var
  R: TColorRec;
  P: PColorRec;
begin
  try
    R.Color := TColor($00112233);
    P := @R;
    P^.R := $AA;
    Result := Cardinal(R.Color) = $001122AA;
  except
    Result := False;
  end;
end;

function SUT_TestColorVsAlphaChannelOrder: Boolean;
begin
  try
    Result := (Cardinal(TColorRec.Red) = $000000FF);
    Result := Result and (Cardinal(TAlphaColorRec.Red) = $FFFF0000);
    Result := Result and (Cardinal(TColorRec.Blue) = $00FF0000);
    Result := Result and (Cardinal(TAlphaColorRec.Blue) = $FF0000FF);
  except
    Result := False;
  end;
end;

function SUT_TestFontStyleOrdinals: Boolean;
begin
  try
    Result := (Ord(TFontStyle.fsBold) = 0);
    Result := Result and (Ord(TFontStyle.fsItalic) = 1);
    Result := Result and (Ord(TFontStyle.fsUnderline) = 2);
    Result := Result and (Ord(TFontStyle.fsStrikeOut) = 3);
  except
    Result := False;
  end;
end;

function SUT_TestFontStylesSet: Boolean;
var
  S: TFontStyles;
begin
  try
    S := [TFontStyle.fsBold, TFontStyle.fsUnderline];
    Result := TFontStyle.fsBold in S;
    Result := Result and (TFontStyle.fsUnderline in S);
    Result := Result and not (TFontStyle.fsItalic in S);
    Result := Result and not (TFontStyle.fsStrikeOut in S);
  except
    Result := False;
  end;
end;

function SUT_TestFontStylesSetMutation: Boolean;
var
  S: TFontStyles;
begin
  try
    S := [];
    Include(S, TFontStyle.fsItalic);
    Include(S, TFontStyle.fsStrikeOut);
    Exclude(S, TFontStyle.fsItalic);
    Result := TFontStyle.fsStrikeOut in S;
    Result := Result and not (TFontStyle.fsItalic in S);
    Result := Result and (S = [TFontStyle.fsStrikeOut]);
  except
    Result := False;
  end;
end;

function SUT_TestFontStylesSetOperators: Boolean;
var
  A, B, C: TFontStyles;
begin
  try
    A := [TFontStyle.fsBold, TFontStyle.fsItalic];
    B := [TFontStyle.fsItalic, TFontStyle.fsUnderline];
    C := A + B;
    Result := C = [TFontStyle.fsBold, TFontStyle.fsItalic, TFontStyle.fsUnderline];
    C := A * B;
    Result := Result and (C = [TFontStyle.fsItalic]);
    C := A - B;
    Result := Result and (C = [TFontStyle.fsBold]);
  except
    Result := False;
  end;
end;

function SUT_TestMessageDialogTypeOrdinals: Boolean;
begin
  try
    Result := (Ord(TMsgDlgType.mtWarning) = 0);
    Result := Result and (Ord(TMsgDlgType.mtError) = 1);
    Result := Result and (Ord(TMsgDlgType.mtInformation) = 2);
    Result := Result and (Ord(TMsgDlgType.mtConfirmation) = 3);
    Result := Result and (Ord(TMsgDlgType.mtCustom) = 4);
  except
    Result := False;
  end;
end;

function SUT_TestMessageDialogButtonsSet: Boolean;
var
  S: TMsgDlgButtons;
begin
  try
    S := [TMsgDlgBtn.mbYes, TMsgDlgBtn.mbNo, TMsgDlgBtn.mbCancel];
    Result := TMsgDlgBtn.mbYes in S;
    Result := Result and (TMsgDlgBtn.mbNo in S);
    Result := Result and (TMsgDlgBtn.mbCancel in S);
    Result := Result and not (TMsgDlgBtn.mbOK in S);
    Result := Result and not (TMsgDlgBtn.mbHelp in S);
  except
    Result := False;
  end;
end;

function SUT_TestMessageDialogButtonsMutation: Boolean;
var
  S: TMsgDlgButtons;
begin
  try
    S := [TMsgDlgBtn.mbYes, TMsgDlgBtn.mbNo];
    Include(S, TMsgDlgBtn.mbHelp);
    Exclude(S, TMsgDlgBtn.mbNo);
    Result := S = [TMsgDlgBtn.mbYes, TMsgDlgBtn.mbHelp];
  except
    Result := False;
  end;
end;

function SUT_TestAnchorKindOrdinals: Boolean;
begin
  try
    Result := (Ord(TAnchorKind.akLeft) = 0);
    Result := Result and (Ord(TAnchorKind.akTop) = 1);
    Result := Result and (Ord(TAnchorKind.akRight) = 2);
    Result := Result and (Ord(TAnchorKind.akBottom) = 3);
  except
    Result := False;
  end;
end;

function SUT_TestAnchorsSet: Boolean;
var
  S: TAnchors;
begin
  try
    S := [TAnchorKind.akLeft, TAnchorKind.akTop];
    Result := TAnchorKind.akLeft in S;
    Result := Result and (TAnchorKind.akTop in S);
    Result := Result and not (TAnchorKind.akRight in S);
    Include(S, TAnchorKind.akBottom);
    Result := Result and (TAnchorKind.akBottom in S);
  except
    Result := False;
  end;
end;

function SUT_TestBorderIconsSet: Boolean;
var
  S: TBorderIcons;
begin
  try
    S := [TBorderIcon.biSystemMenu, TBorderIcon.biMinimize];
    Result := TBorderIcon.biSystemMenu in S;
    Result := Result and (TBorderIcon.biMinimize in S);
    Result := Result and not (TBorderIcon.biMaximize in S);
    Include(S, TBorderIcon.biHelp);
    Result := Result and (TBorderIcon.biHelp in S);
  except
    Result := False;
  end;
end;

function SUT_TestCalendarWeekDays: Boolean;
begin
  try
    Result := (Ord(TCalDayOfWeek.dowMonday) = 0);
    Result := Result and (Ord(TCalDayOfWeek.dowTuesday) = 1);
    Result := Result and (Ord(TCalDayOfWeek.dowSunday) = 6);
    Result := Result and (Ord(TCalDayOfWeek.dowLocaleDefault) = 7);
  except
    Result := False;
  end;
end;

function SUT_TestWindowStates: Boolean;
begin
  try
    Result := (Ord(TWindowState.wsNormal) = 0);
    Result := Result and (Ord(TWindowState.wsMinimized) = 1);
    Result := Result and (Ord(TWindowState.wsMaximized) = 2);
  except
    Result := False;
  end;
end;

function SUT_TestMouseButtons: Boolean;
begin
  try
    Result := (Ord(TMouseButton.mbLeft) = 0);
    Result := Result and (Ord(TMouseButton.mbRight) = 1);
    Result := Result and (Ord(TMouseButton.mbMiddle) = 2);
  except
    Result := False;
  end;
end;

function SUT_TestEditCharCases: Boolean;
begin
  try
    Result := (Ord(TEditCharCase.ecNormal) = 0);
    Result := Result and (Ord(TEditCharCase.ecUpperCase) = 1);
    Result := Result and (Ord(TEditCharCase.ecLowerCase) = 2);
  except
    Result := False;
  end;
end;

function SUT_TestFontPitches: Boolean;
begin
  try
    Result := (Ord(TFontPitch.fpDefault) = 0);
    Result := Result and (Ord(TFontPitch.fpVariable) = 1);
    Result := Result and (Ord(TFontPitch.fpFixed) = 2);
  except
    Result := False;
  end;
end;

function SUT_TestDragModes: Boolean;
begin
  try
    Result := (Ord(TDragMode.dmManual) = 0);
    Result := Result and (Ord(TDragMode.dmAutomatic) = 1);
  except
    Result := False;
  end;
end;

function SUT_TestDragKinds: Boolean;
begin
  try
    Result := (Ord(TDragKind.dkDrag) = 0);
    Result := Result and (Ord(TDragKind.dkDock) = 1);
  except
    Result := False;
  end;
end;

function SUT_TestDragStates: Boolean;
begin
  try
    Result := (Ord(TDragState.dsDragEnter) = 0);
    Result := Result and (Ord(TDragState.dsDragLeave) = 1);
    Result := Result and (Ord(TDragState.dsDragMove) = 2);
  except
    Result := False;
  end;
end;

function SUT_TestCloseActions: Boolean;
begin
  try
    Result := (Ord(TCloseAction.caNone) = 0);
    Result := Result and (Ord(TCloseAction.caHide) = 1);
    Result := Result and (Ord(TCloseAction.caFree) = 2);
    Result := Result and (Ord(TCloseAction.caMinimize) = 3);
  except
    Result := False;
  end;
end;

function SUT_TestScrollStyles: Boolean;
begin
  try
    Result := (Ord(TScrollStyle.ssNone) = 0);
    Result := Result and (Ord(TScrollStyle.ssHorizontal) = 1);
    Result := Result and (Ord(TScrollStyle.ssVertical) = 2);
    Result := Result and (Ord(TScrollStyle.ssBoth) = 3);
  except
    Result := False;
  end;
end;

function SUT_TestScrollCodes: Boolean;
begin
  try
    Result := (Ord(TScrollCode.scLineUp) = 0);
    Result := Result and (Ord(TScrollCode.scLineDown) = 1);
    Result := Result and (Ord(TScrollCode.scPageUp) = 2);
    Result := Result and (Ord(TScrollCode.scPageDown) = 3);
  except
    Result := False;
  end;
end;

function SUT_TestPrinterOrientations: Boolean;
begin
  try
    Result := (Ord(TPrinterOrientation.poPortrait) = 0);
    Result := Result and (Ord(TPrinterOrientation.poLandscape) = 1);
  except
    Result := False;
  end;
end;

function SUT_TestOpenOptionsSet: Boolean;
var
  S: TOpenOptions;
begin
  try
    S := [TOpenOption.ofReadOnly, TOpenOption.ofFileMustExist, TOpenOption.ofAllowMultiSelect];
    Result := TOpenOption.ofReadOnly in S;
    Result := Result and (TOpenOption.ofFileMustExist in S);
    Result := Result and (TOpenOption.ofAllowMultiSelect in S);
    Result := Result and not (TOpenOption.ofNoValidate in S);
  except
    Result := False;
  end;
end;

function SUT_TestOpenOptionsMutation: Boolean;
var
  S: TOpenOptions;
begin
  try
    S := [TOpenOption.ofPathMustExist];
    Include(S, TOpenOption.ofNoChangeDir);
    Exclude(S, TOpenOption.ofPathMustExist);
    Result := S = [TOpenOption.ofNoChangeDir];
  except
    Result := False;
  end;
end;

function SUT_TestOpenOptionsExSet: Boolean;
var
  S: TOpenOptionsEx;
begin
  try
    S := [TOpenOptionEx.ofExNoPlacesBar];
    Result := TOpenOptionEx.ofExNoPlacesBar in S;
    S := [];
    Result := Result and not (TOpenOptionEx.ofExNoPlacesBar in S);
  except
    Result := False;
  end;
end;

function SUT_TestPrintDialogOptionsSet: Boolean;
var
  S: TPrintDialogOptions;
begin
  try
    S := [TPrintDialogOption.poPrintToFile, TPrintDialogOption.poPageNums, TPrintDialogOption.poSelection];
    Result := TPrintDialogOption.poPrintToFile in S;
    Result := Result and (TPrintDialogOption.poPageNums in S);
    Result := Result and (TPrintDialogOption.poSelection in S);
    Result := Result and not (TPrintDialogOption.poWarning in S);
  except
    Result := False;
  end;
end;

function SUT_TestPageSetupDialogOptionsSet: Boolean;
var
  S: TPageSetupDialogOptions;
begin
  try
    S := [TPageSetupDialogOption.psoMargins, TPageSetupDialogOption.psoMinMargins, TPageSetupDialogOption.psoShowHelp];
    Result := TPageSetupDialogOption.psoMargins in S;
    Result := Result and (TPageSetupDialogOption.psoMinMargins in S);
    Result := Result and (TPageSetupDialogOption.psoShowHelp in S);
    Result := Result and not (TPageSetupDialogOption.psoWarning in S);
  except
    Result := False;
  end;
end;

function SUT_TestPrinterCapabilitiesSet: Boolean;
var
  S: TPrinterCapabilities;
begin
  try
    S := [TPrinterCapability.pcCopies, TPrinterCapability.pcOrientation];
    Result := TPrinterCapability.pcCopies in S;
    Result := Result and (TPrinterCapability.pcOrientation in S);
    Result := Result and not (TPrinterCapability.pcCollation in S);
  except
    Result := False;
  end;
end;

function SUT_TestFontCharsetType: Boolean;
var
  C: TFontCharset;
begin
  try
    C := TFontCharset(204);
    Result := Ord(C) = 204;
    C := TFontCharset(0);
    Result := Result and (Ord(C) = 0);
  except
    Result := False;
  end;
end;

function SUT_TestImageIndexType: Boolean;
var
  N: TImageIndex;
begin
  try
    N := TImageIndex(-1);
    Result := Integer(N) = -1;
    N := TImageIndex(1234);
    Result := Result and (Integer(N) = 1234);
  except
    Result := False;
  end;
end;

function SUT_TestTabOrderType: Boolean;
var
  N: TTabOrder;
begin
  try
    N := TTabOrder(7);
    Result := Integer(N) = 7;
  except
    Result := False;
  end;
end;

function SUT_TestCursorBasic: Boolean;
begin
  try
    Result := (Integer(crDefault) = 0);
    Result := Result and (Integer(crNone) = -1);
    Result := Result and (Integer(crArrow) = -2);
    Result := Result and (Integer(crCross) = -3);
    Result := Result and (Integer(crIBeam) = -4);
  except
    Result := False;
  end;
end;

function SUT_TestCursorSizes: Boolean;
begin
  try
    Result := (Integer(crSizeNESW) = -6);
    Result := Result and (Integer(crSizeNS) = -7);
    Result := Result and (Integer(crSizeNWSE) = -8);
    Result := Result and (Integer(crSizeWE) = -9);
    Result := Result and (Integer(crUpArrow) = -10);
  except
    Result := False;
  end;
end;

function SUT_TestCursorSpecial: Boolean;
begin
  try
    Result := (Integer(crHourGlass) = -11);
    Result := Result and (Integer(crNoDrop) = -13);
    Result := Result and (Integer(crHandPoint) = -21);
    Result := Result and (Integer(crSizeAll) = Integer(crSize));
  except
    Result := False;
  end;
end;

function SUT_TestDialogIdConstants: Boolean;
begin
  try
    Result := (idOK = 1);
    Result := Result and (idCancel = 2);
    Result := Result and (idAbort = 3);
    Result := Result and (idRetry = 4);
    Result := Result and (idIgnore = 5);
    Result := Result and (idNo = 7);
    Result := Result and (idClose = 8);
  except
    Result := False;
  end;
end;

function SUT_TestDialogIdExtended: Boolean;
begin
  try
    Result := (idHelp = 9);
    Result := Result and (idTryAgain = 10);
    Result := Result and (idContinue = 11);
  except
    Result := False;
  end;
end;

function SUT_TestKeyModifiers: Boolean;
begin
  try
    Result := (vkShift = $10);
    Result := Result and (vkControl = $11);
    Result := Result and (vkMenu = $12);
    Result := Result and (vkCapital = $14);
  except
    Result := False;
  end;
end;

function SUT_TestKeyTextNavigation: Boolean;
begin
  try
    Result := (vkBack = 8);
    Result := Result and (vkTab = 9);
    Result := Result and (vkReturn = $0D);
    Result := Result and (vkEscape = $1B);
    Result := Result and (vkSpace = $20);
  except
    Result := False;
  end;
end;

function SUT_TestKeyArrows: Boolean;
begin
  try
    Result := (vkLeft = $25);
    Result := Result and (vkUp = $26);
    Result := Result and (vkRight = $27);
    Result := Result and (vkDown = $28);
  except
    Result := False;
  end;
end;

function SUT_TestKeyPages: Boolean;
begin
  try
    Result := (vkPrior = $21);
    Result := Result and (vkNext = $22);
    Result := Result and (vkEnd = $23);
    Result := Result and (vkHome = $24);
  except
    Result := False;
  end;
end;

function SUT_TestKeyEditing: Boolean;
begin
  try
    Result := (vkInsert = $2D);
    Result := Result and (vkDelete = $2E);
    Result := Result and (vkSnapshot = $2C);
  except
    Result := False;
  end;
end;

function SUT_TestKeyFunctions: Boolean;
begin
  try
    Result := (vkF1 = $70);
    Result := Result and (vkF2 = $71);
    Result := Result and (vkF10 = $79);
    Result := Result and (vkF12 = $7B);
    Result := Result and (vkF24 = $87);
  except
    Result := False;
  end;
end;

function SUT_TestKeyNumberPad: Boolean;
begin
  try
    Result := (vkNumpad0 = $60);
    Result := Result and (vkNumpad1 = $61);
    Result := Result and (vkNumpad9 = $69);
  except
    Result := False;
  end;
end;

function SUT_TestKeyArithmetic: Boolean;
begin
  try
    Result := (vkMultiply = $6A);
    Result := Result and (vkAdd = $6B);
    Result := Result and (vkSubtract = $6D);
    Result := Result and (vkDecimal = $6E);
    Result := Result and (vkDivide = $6F);
  except
    Result := False;
  end;
end;

function SUT_TestKeyMouseButtons: Boolean;
begin
  try
    Result := (vkLButton = 1);
    Result := Result and (vkRButton = 2);
    Result := Result and (vkMButton = 4);
    Result := Result and (vkXButton1 = 5);
    Result := Result and (vkXButton2 = 6);
  except
    Result := False;
  end;
end;

function SUT_TestKeyLocks: Boolean;
begin
  try
    Result := (vkNumLock = $90);
    Result := Result and (vkScroll = $91);
    Result := Result and (vkLShift = $A0);
    Result := Result and (vkRShift = $A1);
  except
    Result := False;
  end;
end;

function SUT_TestKeyControlSides: Boolean;
begin
  try
    Result := (vkLControl = $A2);
    Result := Result and (vkRControl = $A3);
    Result := Result and (vkLMenu = $A4);
    Result := Result and (vkRMenu = $A5);
  except
    Result := False;
  end;
end;

{$IFDEF SUT_HAS_BROWSER_VK}
function SUT_TestKeyBrowser: Boolean;
begin
  try
    Result := (vkBrowserBack = $A6);
    Result := Result and (vkBrowserForward = $A7);
    Result := Result and (vkBrowserRefresh = $A8);
    Result := Result and (vkBrowserStop = $A9);
    Result := Result and (vkBrowserSearch = $AA);
  except
    Result := False;
  end;
end;

{$ENDIF}

{$IFDEF SUT_HAS_MEDIA_VK}
function SUT_TestKeyMedia: Boolean;
begin
  try
    Result := (vkVolumeMute = $AD);
    Result := Result and (vkVolumeDown = $AE);
    Result := Result and (vkVolumeUp = $AF);
    Result := Result and (vkMediaNextTrack = $B0);
    Result := Result and (vkMediaPlayPause = $B3);
  except
    Result := False;
  end;
end;

{$ENDIF}

function SUT_TestKeyOem: Boolean;
begin
  try
    Result := (vkSemicolon = $BA);
    Result := Result and (vkEqual = $BB);
    Result := Result and (vkComma = $BC);
    Result := Result and (vkMinus = $BD);
{$IF Declared(vkPeriod)}
    Result := Result and (vkPeriod = $BE);
{$IFEND}
    Result := Result and (vkSlash = $BF);
    Result := Result and (vkTilde = $C0);
  except
    Result := False;
  end;
end;

{$B+}
function SUT_RunAllTests: Boolean;
begin
  Result := True;
  Result := Result and SUT_TestModalResultValues;
  Result := Result and SUT_TestModalResultType;
  Result := Result and SUT_TestPositiveResults;
  Result := Result and SUT_TestPositiveResultsNegativeCases;
  Result := Result and SUT_TestNegativeResults;
  Result := Result and SUT_TestNegativeResultsNegativeCases;
  Result := Result and SUT_TestAbortResults;
  Result := Result and SUT_TestAbortResultsNegativeCases;
  Result := Result and SUT_TestAllResults;
  Result := Result and SUT_TestAllResultsNegativeCases;
  Result := Result and SUT_TestStripAllResults;
  Result := Result and SUT_TestStripNormalResults;
  Result := Result and SUT_TestAlphaColorPrimitives;
  Result := Result and SUT_TestAlphaColorRgbConstants;
  Result := Result and SUT_TestAlphaColorSimpleConstants;
  Result := Result and SUT_TestAlphaColorExtendedConstants;
  Result := Result and SUT_TestAlphaColorNameAliases;
{$IF CompilerVersion >= 34.0}
  Result := Result and SUT_TestAlphaRecordConstructor;
{$IFEND}
  Result := Result and SUT_TestAlphaRecordReadChannels;
  Result := Result and SUT_TestAlphaRecordWriteChannels;
  Result := Result and SUT_TestAlphaRecordModifyChannel;
  Result := Result and SUT_TestAlphaRecordWordOverlay;
  Result := Result and SUT_TestAlphaRecordCopy;
  Result := Result and SUT_TestAlphaColorPointer;
  Result := Result and SUT_TestAlphaRecordPointer;
  Result := Result and SUT_TestAlphaRecordSize;
  Result := Result and SUT_TestAlphaRecordZeroChannels;
  Result := Result and SUT_TestAlphaRecordAlphaChange;
  Result := Result and SUT_TestAlphaRecordWriteWords;
  Result := Result and SUT_TestAlphaRecordEachChannel;
  Result := Result and SUT_TestAlphaRecordChannelLimits;
  Result := Result and SUT_TestAlphaRecordByteOrder;
  Result := Result and SUT_TestAlphaRecordPointerChannels;
  Result := Result and SUT_TestAlphaRecordArrayCopies;
  Result := Result and SUT_TestAlphaRecordAliasColors;
  Result := Result and SUT_TestAlphaRecordLegacyColors;
//{$IF Declared(TAlphaColorRec.ColorToRGB)}
  Result := Result and SUT_TestAlphaRecordColorToRGBCallback;
//{$IFEND}
  Result := Result and SUT_TestAlphaRecordPalette01;
  Result := Result and SUT_TestAlphaRecordPalette02;
  Result := Result and SUT_TestAlphaRecordPalette03;
  Result := Result and SUT_TestAlphaRecordPalette04;
  Result := Result and SUT_TestAlphaRecordPalette05;
  Result := Result and SUT_TestAlphaRecordPalette06;
  Result := Result and SUT_TestAlphaRecordPalette07;
  Result := Result and SUT_TestAlphaRecordPalette08;
  Result := Result and SUT_TestAlphaRecordPalette09;
  Result := Result and SUT_TestAlphaRecordPalette10;
  Result := Result and SUT_TestAlphaRecordPalette11;
  Result := Result and SUT_TestAlphaRecordPalette12;
  Result := Result and SUT_TestAlphaRecordPalette13;
  Result := Result and SUT_TestAlphaRecordPalette14;
  Result := Result and SUT_TestAlphaRecordPalette15;
  Result := Result and SUT_TestAlphaRecordPalette16;
  Result := Result and SUT_TestAlphaRecordPalette17;
  Result := Result and SUT_TestColorPrimitives;
  Result := Result and SUT_TestColorRgbConstants;
  Result := Result and SUT_TestColorSimpleConstants;
  Result := Result and SUT_TestColorExtendedConstants;
  Result := Result and SUT_TestColorNameAliases;
  Result := Result and SUT_TestColorSystemConstants;
  Result := Result and SUT_TestColorSystemSpecialConstants;
  Result := Result and SUT_TestColorRecordReadChannels;
  Result := Result and SUT_TestColorRecordWriteChannels;
  Result := Result and SUT_TestColorRecordModifyChannel;
  Result := Result and SUT_TestColorRecordWordOverlay;
  Result := Result and SUT_TestColorRecordCopy;
  Result := Result and SUT_TestColorPointer;
  Result := Result and SUT_TestColorRecordPointer;
  Result := Result and SUT_TestColorVsAlphaChannelOrder;
  Result := Result and SUT_TestFontStyleOrdinals;
  Result := Result and SUT_TestFontStylesSet;
  Result := Result and SUT_TestFontStylesSetMutation;
  Result := Result and SUT_TestFontStylesSetOperators;
  Result := Result and SUT_TestMessageDialogTypeOrdinals;
  Result := Result and SUT_TestMessageDialogButtonsSet;
  Result := Result and SUT_TestMessageDialogButtonsMutation;
  Result := Result and SUT_TestAnchorKindOrdinals;
  Result := Result and SUT_TestAnchorsSet;
  Result := Result and SUT_TestBorderIconsSet;
  Result := Result and SUT_TestCalendarWeekDays;
  Result := Result and SUT_TestWindowStates;
  Result := Result and SUT_TestMouseButtons;
  Result := Result and SUT_TestEditCharCases;
  Result := Result and SUT_TestFontPitches;
  Result := Result and SUT_TestDragModes;
  Result := Result and SUT_TestDragKinds;
  Result := Result and SUT_TestDragStates;
  Result := Result and SUT_TestCloseActions;
  Result := Result and SUT_TestScrollStyles;
  Result := Result and SUT_TestScrollCodes;
  Result := Result and SUT_TestPrinterOrientations;
  Result := Result and SUT_TestOpenOptionsSet;
  Result := Result and SUT_TestOpenOptionsMutation;
  Result := Result and SUT_TestOpenOptionsExSet;
  Result := Result and SUT_TestPrintDialogOptionsSet;
  Result := Result and SUT_TestPageSetupDialogOptionsSet;
  Result := Result and SUT_TestPrinterCapabilitiesSet;
  Result := Result and SUT_TestFontCharsetType;
  Result := Result and SUT_TestImageIndexType;
  Result := Result and SUT_TestTabOrderType;
  Result := Result and SUT_TestCursorBasic;
  Result := Result and SUT_TestCursorSizes;
  Result := Result and SUT_TestCursorSpecial;
  Result := Result and SUT_TestDialogIdConstants;
  Result := Result and SUT_TestDialogIdExtended;
  Result := Result and SUT_TestKeyModifiers;
  Result := Result and SUT_TestKeyTextNavigation;
  Result := Result and SUT_TestKeyArrows;
  Result := Result and SUT_TestKeyPages;
  Result := Result and SUT_TestKeyEditing;
  Result := Result and SUT_TestKeyFunctions;
  Result := Result and SUT_TestKeyNumberPad;
  Result := Result and SUT_TestKeyArithmetic;
  Result := Result and SUT_TestKeyMouseButtons;
  Result := Result and SUT_TestKeyLocks;
  Result := Result and SUT_TestKeyControlSides;
{$IFDEF SUT_HAS_BROWSER_VK}
  Result := Result and SUT_TestKeyBrowser;
{$ENDIF}
{$IFDEF SUT_HAS_MEDIA_VK}
  Result := Result and SUT_TestKeyMedia;
{$ENDIF}
  Result := Result and SUT_TestKeyOem;
end;
{$B-}

end.
