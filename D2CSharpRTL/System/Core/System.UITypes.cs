using System.Runtime.InteropServices;
using System;
using static System.SystemInterface;
using static System.Uitypes.UitypesImplementation;
using static System.Uitypes.UitypesInterface;

namespace System
{

namespace Uitypes
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.UITypes.
  Provides shared UI-related RTL types, constants and routine signatures
  for translation. This is not an implementation of the VCL or FMX.
  Vcl.Graphics may expose aliases of types declared here.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/


public class UitypesInterface
{

	[StructLayout(LayoutKind.Explicit, Size = 4)]
	public struct TColorRec
	{
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public int Color;
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public ushort HiWord;
		[global::System.Runtime.InteropServices.FieldOffset(2)]
		public ushort LoWord;
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public byte R;
		[global::System.Runtime.InteropServices.FieldOffset(1)]
		public byte G;
		[global::System.Runtime.InteropServices.FieldOffset(2)]
		public byte B;
		[global::System.Runtime.InteropServices.FieldOffset(3)]
		public byte A;
		public const uint SystemColor = 0xFF000000;
    // System Colors (Windows only)
		public const int cSCROLLBAR = 0;
		public const int cBACKGROUND = 1;
		public const int cACTIVECAPTION = 2;
		public const int cINACTIVECAPTION = 3;
		public const int cMENU = 4;
		public const int cWINDOW = 5;
		public const int cWINDOWFRAME = 6;
		public const int cMENUTEXT = 7;
		public const int cWINDOWTEXT = 8;
		public const int cCAPTIONTEXT = 9;
		public const int cACTIVEBORDER = 10;
		public const int cINACTIVEBORDER = 11;
		public const int cAPPWORKSPACE = 12;
		public const int cHIGHLIGHT = 13;
		public const int cHIGHLIGHTTEXT = 14;
		public const int cBTNFACE = 15;
		public const int cBTNSHADOW = 0x10;
		public const int cGRAYTEXT = 17;
		public const int cBTNTEXT = 18;
		public const int cINACTIVECAPTIONTEXT = 19;
		public const int cBTNHIGHLIGHT = 20;
		public const int c3DDKSHADOW = 21;
		public const int c3DLIGHT = 22;
		public const int cINFOTEXT = 23;
		public const int cINFOBK = 24;
		public const int cHOTLIGHT = 26;
		public const int cGRADIENTACTIVECAPTION = 27;
		public const int cGRADIENTINACTIVECAPTION = 28;
		public const int cMENUHILIGHT = 29;
		public const int cMENUBAR = 30;
		public const int cENDCOLORS = cMENUBAR;
		public const int cDESKTOP = cBACKGROUND;
		public const int c3DFACE = cBTNFACE;
		public const int c3DSHADOW = cBTNSHADOW;
		public const int c3DHIGHLIGHT = cBTNHIGHLIGHT;
		public const int c3DHILIGHT = cBTNHIGHLIGHT;
		public const int cBTNHILIGHT = cBTNHIGHLIGHT;
		public const int SysScrollBar = unchecked((int)(SystemColor | cSCROLLBAR));
		public const int SysBackground = unchecked((int)(SystemColor | cBACKGROUND));
		public const int SysActiveCaption = unchecked((int)(SystemColor | cACTIVECAPTION));
		public const int SysInactiveCaption = unchecked((int)(SystemColor | cINACTIVECAPTION));
		public const int SysMenu = unchecked((int)(SystemColor | cMENU));
		public const int SysWindow = unchecked((int)(SystemColor | cWINDOW));
		public const int SysWindowFrame = unchecked((int)(SystemColor | cWINDOWFRAME));
		public const int SysMenuText = unchecked((int)(SystemColor | cMENUTEXT));
		public const int SysWindowText = unchecked((int)(SystemColor | cWINDOWTEXT));
		public const int SysCaptionText = unchecked((int)(SystemColor | cCAPTIONTEXT));
		public const int SysActiveBorder = unchecked((int)(SystemColor | cACTIVEBORDER));
		public const int SysInactiveBorder = unchecked((int)(SystemColor | cINACTIVEBORDER));
		public const int SysAppWorkSpace = unchecked((int)(SystemColor | cAPPWORKSPACE));
		public const int SysHighlight = unchecked((int)(SystemColor | cHIGHLIGHT));
		public const int SysHighlightText = unchecked((int)(SystemColor | cHIGHLIGHTTEXT));
		public const int SysBtnFace = unchecked((int)(SystemColor | cBTNFACE));
		public const int SysBtnShadow = unchecked((int)(SystemColor | cBTNSHADOW));
		public const int SysGrayText = unchecked((int)(SystemColor | cGRAYTEXT));
		public const int SysBtnText = unchecked((int)(SystemColor | cBTNTEXT));
		public const int SysInactiveCaptionText = unchecked((int)(SystemColor | cINACTIVECAPTIONTEXT));
		public const int SysBtnHighlight = unchecked((int)(SystemColor | cBTNHIGHLIGHT));
		public const int Sys3DDkShadow = unchecked((int)(SystemColor | c3DDKSHADOW));
		public const int Sys3DLight = unchecked((int)(SystemColor | c3DLIGHT));
		public const int SysInfoText = unchecked((int)(SystemColor | cINFOTEXT));
		public const int SysInfoBk = unchecked((int)(SystemColor | cINFOBK));
		public const int SysHotLight = unchecked((int)(SystemColor | cHOTLIGHT));
		public const int SysGradientActiveCaption = unchecked((int)(SystemColor | cGRADIENTACTIVECAPTION));
		public const int SysGradientInactiveCaption = unchecked((int)(SystemColor | cGRADIENTINACTIVECAPTION));
		public const int SysMenuHighlight = unchecked((int)(SystemColor | cMENUHILIGHT));
		public const int SysMenuBar = unchecked((int)(SystemColor | cMENUBAR));
		public const int SysNone = ((int)(0x1FFFFFFF));
		public const int SysDefault = ((int)(0x20000000));
    // Actual colors
		public const int Aliceblue = ((int)(0xFFF8F0));
		public const int Antiquewhite = ((int)(0xD7EBFA));
		public const int Aqua = ((int)(0xFFFF00));
		public const int Aquamarine = ((int)(0xD4FF7F));
		public const int Azure = ((int)(0xFFFFF0));
		public const int Beige = ((int)(0xDCF5F5));
		public const int Bisque = ((int)(0xC4E4FF));
		public const int Black = ((int)(0x000000));
		public const int Blanchedalmond = ((int)(0xCDEBFF));
		public const int Blue = ((int)(0xFF0000));
		public const int Blueviolet = ((int)(0xE22B8A));
		public const int Brown = ((int)(0x2A2AA5));
		public const int Burlywood = ((int)(0x87B8DE));
		public const int Cadetblue = ((int)(0xA09E5F));
		public const int Chartreuse = ((int)(0x00FF7F));
		public const int Chocolate = ((int)(0x1E69D2));
		public const int Coral = ((int)(0x507FFF));
		public const int Cornflowerblue = ((int)(0xED9564));
		public const int Cornsilk = ((int)(0xDCF8FF));
		public const int Crimson = ((int)(0x3C14DC));
		public const int Cyan = ((int)(0xFFFF00));
		public const int Darkblue = ((int)(0x8B0000));
		public const int Darkcyan = ((int)(0x8B8B00));
		public const int Darkgoldenrod = ((int)(0x0B86B8));
		public const int Darkgray = ((int)(0xA9A9A9));
		public const int Darkgreen = ((int)(0x006400));
		public const int Darkgrey = ((int)(0xA9A9A9));
		public const int Darkkhaki = ((int)(0x6BB7BD));
		public const int Darkmagenta = ((int)(0x8B008B));
		public const int Darkolivegreen = ((int)(0x2F6B55));
		public const int Darkorange = ((int)(0x008CFF));
		public const int Darkorchid = ((int)(0xCC3299));
		public const int Darkred = ((int)(0x00008B));
		public const int Darksalmon = ((int)(0x7A96E9));
		public const int Darkseagreen = ((int)(0x8FBC8F));
		public const int Darkslateblue = ((int)(0x8B3D48));
		public const int Darkslategray = ((int)(0x4F4F2F));
		public const int Darkslategrey = ((int)(0x4F4F2F));
		public const int Darkturquoise = ((int)(0xD1CE00));
		public const int Darkviolet = ((int)(0xD30094));
		public const int Deeppink = ((int)(0x9314FF));
		public const int Deepskyblue = ((int)(0xFFBF00));
		public const int Dimgray = ((int)(0x696969));
		public const int Dimgrey = ((int)(0x696969));
		public const int Dodgerblue = ((int)(0xFF901E));
		public const int Firebrick = ((int)(0x2222B2));
		public const int Floralwhite = ((int)(0xF0FAFF));
		public const int Forestgreen = ((int)(0x228B22));
		public const int Fuchsia = ((int)(0xFF00FF));
		public const int Gainsboro = ((int)(0xDCDCDC));
		public const int Ghostwhite = ((int)(0xFFF8F8));
		public const int Gold = ((int)(0x00D7FF));
		public const int Goldenrod = ((int)(0x20A5DA));
		public const int Gray = ((int)(0x808080));
		public const int Green = ((int)(0x008000));
		public const int Greenyellow = ((int)(0x2FFFAD));
		public const int Grey = ((int)(0x808080));
		public const int Honeydew = ((int)(0xF0FFF0));
		public const int Hotpink = ((int)(0xB469FF));
		public const int Indianred = ((int)(0x5C5CCD));
		public const int Indigo = ((int)(0x82004B));
		public const int Ivory = ((int)(0xF0FFFF));
		public const int Khaki = ((int)(0x8CE6F0));
		public const int Lavender = ((int)(0xFAE6E6));
		public const int Lavenderblush = ((int)(0xF5F0FF));
		public const int Lawngreen = ((int)(0x00FC7C));
		public const int Lemonchiffon = ((int)(0xCDFAFF));
		public const int Lightblue = ((int)(0xE6D8AD));
		public const int Lightcoral = ((int)(0x8080F0));
		public const int Lightcyan = ((int)(0xFFFFE0));
		public const int Lightgoldenrodyellow = ((int)(0xD2FAFA));
		public const int Lightgray = ((int)(0xD3D3D3));
		public const int Lightgreen = ((int)(0x90EE90));
		public const int Lightgrey = ((int)(0xD3D3D3));
		public const int Lightpink = ((int)(0xC1B6FF));
		public const int Lightsalmon = ((int)(0x7AA0FF));
		public const int Lightseagreen = ((int)(0xAAB220));
		public const int Lightskyblue = ((int)(0xFACE87));
		public const int Lightslategray = ((int)(0x998877));
		public const int Lightslategrey = ((int)(0x998877));
		public const int Lightsteelblue = ((int)(0xDEC4B0));
		public const int Lightyellow = ((int)(0xE0FFFF));
		public const int LtGray = ((int)(0xC0C0C0));
		public const int MedGray = ((int)(0xA4A0A0));
		public const int DkGray = ((int)(0x808080));
		public const int MoneyGreen = ((int)(0xC0DCC0));
		public const int LegacySkyBlue = ((int)(0xF0CAA6));
		public const int Cream = ((int)(0xF0FBFF));
		public const int Lime = ((int)(0x00FF00));
		public const int Limegreen = ((int)(0x32CD32));
		public const int Linen = ((int)(0xE6F0FA));
		public const int Magenta = ((int)(0xFF00FF));
		public const int Maroon = ((int)(0x000080));
		public const int Mediumaquamarine = ((int)(0xAACD66));
		public const int Mediumblue = ((int)(0xCD0000));
		public const int Mediumorchid = ((int)(0xD355BA));
		public const int Mediumpurple = ((int)(0xDB7093));
		public const int Mediumseagreen = ((int)(0x71B33C));
		public const int Mediumslateblue = ((int)(0xEE687B));
		public const int Mediumspringgreen = ((int)(0x9AFA00));
		public const int Mediumturquoise = ((int)(0xCCD148));
		public const int Mediumvioletred = ((int)(0x8515C7));
		public const int Midnightblue = ((int)(0x701919));
		public const int Mintcream = ((int)(0xFAFFF5));
		public const int Mistyrose = ((int)(0xE1E4FF));
		public const int Moccasin = ((int)(0xB5E4FF));
		public const int Navajowhite = ((int)(0xADDEFF));
		public const int Navy = ((int)(0x800000));
		public const int Oldlace = ((int)(0xE6F5FD));
		public const int Olive = ((int)(0x008080));
		public const int Olivedrab = ((int)(0x238E6B));
		public const int Orange = ((int)(0x00A5FF));
		public const int Orangered = ((int)(0x0045FF));
		public const int Orchid = ((int)(0xD670DA));
		public const int Palegoldenrod = ((int)(0xAAE8EE));
		public const int Palegreen = ((int)(0x98FB98));
		public const int Paleturquoise = ((int)(0xEEEEAF));
		public const int Palevioletred = ((int)(0x9370DB));
		public const int Papayawhip = ((int)(0xD5EFFF));
		public const int Peachpuff = ((int)(0xB9DAFF));
		public const int Peru = ((int)(0x3F85CD));
		public const int Pink = ((int)(0xCBC0FF));
		public const int Plum = ((int)(0xDDA0DD));
		public const int Powderblue = ((int)(0xE6E0B0));
		public const int Purple = ((int)(0x800080));
		public const int Red = ((int)(0x0000FF));
		public const int Rosybrown = ((int)(0x8F8FBC));
		public const int Royalblue = ((int)(0xE16941));
		public const int Saddlebrown = ((int)(0x13458B));
		public const int Salmon = ((int)(0x7280FA));
		public const int Sandybrown = ((int)(0x60A4F4));
		public const int Seagreen = ((int)(0x578B2E));
		public const int Seashell = ((int)(0xEEF5FF));
		public const int Sienna = ((int)(0x2D52A0));
		public const int Silver = ((int)(0xC0C0C0));
		public const int Skyblue = ((int)(0xEBCE87));
		public const int Slateblue = ((int)(0xCD5A6A));
		public const int Slategray = ((int)(0x908070));
		public const int Slategrey = ((int)(0x908070));
		public const int Snow = ((int)(0xFAFAFF));
		public const int Springgreen = ((int)(0x7FFF00));
		public const int Steelblue = ((int)(0xB48246));
		public const int Tan = ((int)(0x8CB4D2));
		public const int Teal = ((int)(0x808000));
		public const int Thistle = ((int)(0xD8BFD8));
		public const int Tomato = ((int)(0x4763FF));
		public const int Turquoise = ((int)(0xD0E040));
		public const int Violet = ((int)(0xEE82EE));
		public const int Wheat = ((int)(0xB3DEF5));
		public const int White = ((int)(0xFFFFFF));
		public const int Whitesmoke = ((int)(0xF5F5F5));
		public const int Yellow = ((int)(0x00FFFF));
		public const int Yellowgreen = ((int)(0x32CD9A));
		public const int Null = ((int)(0x00000000));
/*    class operator Implicit(const C: TColor): TColorRec; inline;
    class operator Implicit(const C: TColorRec): TColor; inline;
    class operator Implicit(const C: TColorRec): Longint; inline;
    class operator Explicit(const C: TColorRec): Longint; inline;*/
		public static UITypesDelegate0 ColorToRGB = default;
		public static TColorRec CreateRecord(){return new TColorRec();}
	}	
  /* ARGB color channels (little-endian Delphi/Windows layout).
    This is a translation mock, not a full platform implementation. */

	[StructLayout(LayoutKind.Explicit, Size = 4)]
	public struct TAlphaColorRec
	{
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public uint Color;
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public ushort HiWord;
		[global::System.Runtime.InteropServices.FieldOffset(2)]
		public ushort LoWord;
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public byte B;
		[global::System.Runtime.InteropServices.FieldOffset(1)]
		public byte G;
		[global::System.Runtime.InteropServices.FieldOffset(2)]
		public byte R;
		[global::System.Runtime.InteropServices.FieldOffset(3)]
		public byte A;
		public const uint Alpha = ((uint)(0xFF000000));
		public const uint Aliceblue = ((uint)(0xFFF0F8FF));
		public const uint Antiquewhite = ((uint)(0xFFFAEBD7));
		public const uint Aqua = ((uint)(0xFF00FFFF));
		public const uint Aquamarine = ((uint)(0xFF7FFFD4));
		public const uint Azure = ((uint)(0xFFF0FFFF));
		public const uint Beige = ((uint)(0xFFF5F5DC));
		public const uint Bisque = ((uint)(0xFFFFE4C4));
		public const uint Black = ((uint)(0xFF000000));
		public const uint Blanchedalmond = ((uint)(0xFFFFEBCD));
		public const uint Blue = ((uint)(0xFF0000FF));
		public const uint Blueviolet = ((uint)(0xFF8A2BE2));
		public const uint Brown = ((uint)(0xFFA52A2A));
		public const uint Burlywood = ((uint)(0xFFDEB887));
		public const uint Cadetblue = ((uint)(0xFF5F9EA0));
		public const uint Chartreuse = ((uint)(0xFF7FFF00));
		public const uint Chocolate = ((uint)(0xFFD2691E));
		public const uint Coral = ((uint)(0xFFFF7F50));
		public const uint Cornflowerblue = ((uint)(0xFF6495ED));
		public const uint Cornsilk = ((uint)(0xFFFFF8DC));
		public const uint Crimson = ((uint)(0xFFDC143C));
		public const uint Cyan = ((uint)(0xFF00FFFF));
		public const uint Darkblue = ((uint)(0xFF00008B));
		public const uint Darkcyan = ((uint)(0xFF008B8B));
		public const uint Darkgoldenrod = ((uint)(0xFFB8860B));
		public const uint Darkgray = ((uint)(0xFFA9A9A9));
		public const uint Darkgreen = ((uint)(0xFF006400));
		public const uint Darkgrey = ((uint)(0xFFA9A9A9));
		public const uint Darkkhaki = ((uint)(0xFFBDB76B));
		public const uint Darkmagenta = ((uint)(0xFF8B008B));
		public const uint Darkolivegreen = ((uint)(0xFF556B2F));
		public const uint Darkorange = ((uint)(0xFFFF8C00));
		public const uint Darkorchid = ((uint)(0xFF9932CC));
		public const uint Darkred = ((uint)(0xFF8B0000));
		public const uint Darksalmon = ((uint)(0xFFE9967A));
		public const uint Darkseagreen = ((uint)(0xFF8FBC8F));
		public const uint Darkslateblue = ((uint)(0xFF483D8B));
		public const uint Darkslategray = ((uint)(0xFF2F4F4F));
		public const uint Darkslategrey = ((uint)(0xFF2F4F4F));
		public const uint Darkturquoise = ((uint)(0xFF00CED1));
		public const uint Darkviolet = ((uint)(0xFF9400D3));
		public const uint Deeppink = ((uint)(0xFFFF1493));
		public const uint Deepskyblue = ((uint)(0xFF00BFFF));
		public const uint Dimgray = ((uint)(0xFF696969));
		public const uint Dimgrey = ((uint)(0xFF696969));
		public const uint Dodgerblue = ((uint)(0xFF1E90FF));
		public const uint Firebrick = ((uint)(0xFFB22222));
		public const uint Floralwhite = ((uint)(0xFFFFFAF0));
		public const uint Forestgreen = ((uint)(0xFF228B22));
		public const uint Fuchsia = ((uint)(0xFFFF00FF));
		public const uint Gainsboro = ((uint)(0xFFDCDCDC));
		public const uint Ghostwhite = ((uint)(0xFFF8F8FF));
		public const uint Gold = ((uint)(0xFFFFD700));
		public const uint Goldenrod = ((uint)(0xFFDAA520));
		public const uint Gray = ((uint)(0xFF808080));
		public const uint Green = ((uint)(0xFF008000));
		public const uint Greenyellow = ((uint)(0xFFADFF2F));
		public const uint Grey = ((uint)(0xFF808080));
		public const uint Honeydew = ((uint)(0xFFF0FFF0));
		public const uint Hotpink = ((uint)(0xFFFF69B4));
		public const uint Indianred = ((uint)(0xFFCD5C5C));
		public const uint Indigo = ((uint)(0xFF4B0082));
		public const uint Ivory = ((uint)(0xFFFFFFF0));
		public const uint Khaki = ((uint)(0xFFF0E68C));
		public const uint Lavender = ((uint)(0xFFE6E6FA));
		public const uint Lavenderblush = ((uint)(0xFFFFF0F5));
		public const uint Lawngreen = ((uint)(0xFF7CFC00));
		public const uint Lemonchiffon = ((uint)(0xFFFFFACD));
		public const uint Lightblue = ((uint)(0xFFADD8E6));
		public const uint Lightcoral = ((uint)(0xFFF08080));
		public const uint Lightcyan = ((uint)(0xFFE0FFFF));
		public const uint Lightgoldenrodyellow = ((uint)(0xFFFAFAD2));
		public const uint Lightgray = ((uint)(0xFFD3D3D3));
		public const uint Lightgreen = ((uint)(0xFF90EE90));
		public const uint Lightgrey = ((uint)(0xFFD3D3D3));
		public const uint Lightpink = ((uint)(0xFFFFB6C1));
		public const uint Lightsalmon = ((uint)(0xFFFFA07A));
		public const uint Lightseagreen = ((uint)(0xFF20B2AA));
		public const uint Lightskyblue = ((uint)(0xFF87CEFA));
		public const uint Lightslategray = ((uint)(0xFF778899));
		public const uint Lightslategrey = ((uint)(0xFF778899));
		public const uint Lightsteelblue = ((uint)(0xFFB0C4DE));
		public const uint Lightyellow = ((uint)(0xFFFFFFE0));
		public const uint Lime = ((uint)(0xFF00FF00));
		public const uint Limegreen = ((uint)(0xFF32CD32));
		public const uint Linen = ((uint)(0xFFFAF0E6));
		public const uint Magenta = ((uint)(0xFFFF00FF));
		public const uint Maroon = ((uint)(0xFF800000));
		public const uint Mediumaquamarine = ((uint)(0xFF66CDAA));
		public const uint Mediumblue = ((uint)(0xFF0000CD));
		public const uint Mediumorchid = ((uint)(0xFFBA55D3));
		public const uint Mediumpurple = ((uint)(0xFF9370DB));
		public const uint Mediumseagreen = ((uint)(0xFF3CB371));
		public const uint Mediumslateblue = ((uint)(0xFF7B68EE));
		public const uint Mediumspringgreen = ((uint)(0xFF00FA9A));
		public const uint Mediumturquoise = ((uint)(0xFF48D1CC));
		public const uint Mediumvioletred = ((uint)(0xFFC71585));
		public const uint Midnightblue = ((uint)(0xFF191970));
		public const uint Mintcream = ((uint)(0xFFF5FFFA));
		public const uint Mistyrose = ((uint)(0xFFFFE4E1));
		public const uint Moccasin = ((uint)(0xFFFFE4B5));
		public const uint Navajowhite = ((uint)(0xFFFFDEAD));
		public const uint Navy = ((uint)(0xFF000080));
		public const uint Oldlace = ((uint)(0xFFFDF5E6));
		public const uint Olive = ((uint)(0xFF808000));
		public const uint Olivedrab = ((uint)(0xFF6B8E23));
		public const uint Orange = ((uint)(0xFFFFA500));
		public const uint Orangered = ((uint)(0xFFFF4500));
		public const uint Orchid = ((uint)(0xFFDA70D6));
		public const uint Palegoldenrod = ((uint)(0xFFEEE8AA));
		public const uint Palegreen = ((uint)(0xFF98FB98));
		public const uint Paleturquoise = ((uint)(0xFFAFEEEE));
		public const uint Palevioletred = ((uint)(0xFFDB7093));
		public const uint Papayawhip = ((uint)(0xFFFFEFD5));
		public const uint Peachpuff = ((uint)(0xFFFFDAB9));
		public const uint Peru = ((uint)(0xFFCD853F));
		public const uint Pink = ((uint)(0xFFFFC0CB));
		public const uint Plum = ((uint)(0xFFDDA0DD));
		public const uint Powderblue = ((uint)(0xFFB0E0E6));
		public const uint Purple = ((uint)(0xFF800080));
		public const uint Rebeccapurple = ((uint)(0xFF663399));
		public const uint Red = ((uint)(0xFFFF0000));
		public const uint Rosybrown = ((uint)(0xFFBC8F8F));
		public const uint Royalblue = ((uint)(0xFF4169E1));
		public const uint Saddlebrown = ((uint)(0xFF8B4513));
		public const uint Salmon = ((uint)(0xFFFA8072));
		public const uint Sandybrown = ((uint)(0xFFF4A460));
		public const uint Seagreen = ((uint)(0xFF2E8B57));
		public const uint Seashell = ((uint)(0xFFFFF5EE));
		public const uint Sienna = ((uint)(0xFFA0522D));
		public const uint Silver = ((uint)(0xFFC0C0C0));
		public const uint Skyblue = ((uint)(0xFF87CEEB));
		public const uint Slateblue = ((uint)(0xFF6A5ACD));
		public const uint Slategray = ((uint)(0xFF708090));
		public const uint Slategrey = ((uint)(0xFF708090));
		public const uint Snow = ((uint)(0xFFFFFAFA));
		public const uint Springgreen = ((uint)(0xFF00FF7F));
		public const uint Steelblue = ((uint)(0xFF4682B4));
		public const uint Tan = ((uint)(0xFFD2B48C));
		public const uint Teal = ((uint)(0xFF008080));
		public const uint Thistle = ((uint)(0xFFD8BFD8));
		public const uint Tomato = ((uint)(0xFFFF6347));
		public const uint Turquoise = ((uint)(0xFF40E0D0));
		public const uint Violet = ((uint)(0xFFEE82EE));
		public const uint Wheat = ((uint)(0xFFF5DEB3));
		public const uint White = ((uint)(0xFFFFFFFF));
		public const uint Whitesmoke = ((uint)(0xFFF5F5F5));
		public const uint Yellow = ((uint)(0xFFFFFF00));
		public const uint Yellowgreen = ((uint)(0xFF9ACD32));
		public const uint LtGray = ((uint)(0xFFC0C0C0));
		public const uint MedGray = ((uint)(0xFFA0A0A0));
		public const uint DkGray = ((uint)(0xFF808080));
		public const uint MoneyGreen = ((uint)(0xFFC0DCC0));
		public const uint LegacySkyBlue = ((uint)(0xFFF0CAA6));
		public const uint Cream = ((uint)(0xFFF0FBFF));
		public const uint Null = ((uint)(0x00000000));
		public static UitypesDelegate1 ColorToRGB;
		public TAlphaColorRec(uint Color)
		{
			this.Color = Color;
		}
		public void Create(uint Color)
		{
			this.Color = Color;
		}
		public static TAlphaColorRec CreateRecord(){return new TAlphaColorRec();}
	}	
  /* Standard dialog result identifiers. */
	public enum TOpenOption : byte {ofReadOnly,
                  ofOverwritePrompt,
                  ofHideReadOnly,
                  ofNoChangeDir,
                  ofShowHelp,
                  ofNoValidate,
                  ofAllowMultiSelect,
                  ofExtensionDifferent,
                  ofPathMustExist,
                  ofFileMustExist,
                  ofCreatePrompt,
                  ofShareAware,
                  ofNoReadOnlyReturn,
                  ofNoTestFileCreate,
                  ofNoNetworkButton,
                  ofNoLongNames,
                  ofOldStyleDialog,
                  ofNoDereferenceLinks,
                  ofEnableIncludeNotify,
                  ofEnableSizing,
                  ofDontAddToRecent,
                  ofForceShowHidden };
	public enum TOpenOptionEx : byte {ofExNoPlacesBar };

  /* Dialog and printing API surface; enumerator order is significant. */
	public enum TDialogType : byte {Standard,
                  Directory };
	public enum TPrintRange : byte {prAllPages,
                  prSelection,
                  prPageNums };
	public enum TPrinterKind : byte {pkDotMatrix,
                   pkHPPCL };
	public enum TPageType : byte {ptEnvelope,
                ptPaper };
	public enum TPageMeasureUnits : byte {pmDefault,
                        pmMillimeters,
                        pmInches };
	public enum TPrinterState : byte {psNoHandle,
                    psHandleIC,
                    psHandleDC };
	public enum TPrinterOrientation : byte {poPortrait,
                          poLandscape };
	public enum TPrintDialogOption : byte {poPrintToFile,
                         poPageNums,
                         poSelection,
                         poWarning,
                         poHelp,
                         poDisablePrintToFile };
	public enum TPageSetupDialogOption : byte {psoDefaultMinMargins,
                             psoDisableMargins,
                             psoDisableOrientation,
                             psoDisablePagePainting,
                             psoDisablePaper,
                             psoDisablePrinter,
                             psoMargins,
                             psoMinMargins,
                             psoShowHelp,
                             psoWarning,
                             psoNoNetworkButton };
	public enum TPrinterCapability : byte {pcCopies,
                         pcOrientation,
                         pcCollation };

  /* Font types shared with graphics frameworks. */
	public enum TFontStyle : byte {fsBold,
                 fsItalic,
                 fsUnderline,
                 fsStrikeOut };
	public enum TFontPitch : byte {fpDefault,
                 fpVariable,
                 fpFixed };
	public enum TFontQuality : byte {fqDefault,
                   fqDraft,
                   fqProof,
                   fqNonAntialiased,
                   fqAntialiased,
                   fqClearType,
                   fqClearTypeNatural };


  /* Color types contain packed color values, not color objects. */
  /* Stable named callback type. The old anonymous class var declaration
    produced a compiler-dependent autogenerated C# delegate name. */
public delegate int UitypesDelegate1(uint Color);
		public delegate int UITypesDelegate0(int Color);

  /* Common controls, forms and input types. */
  /* Calendar: Monday maps to ordinal 0, locale-default to 7. */
	public enum TCalDayOfWeek : byte {dowMonday,
                    dowTuesday,
                    dowWednesday,
                    dowThursday,
                    dowFriday,
                    dowSaturday,
                    dowSunday,
                    dowLocaleDefault };

  /* Scroll codes follow the standard Win32 scroll request sequence. */
	public enum TScrollCode : byte {scLineUp,
                  scLineDown,
                  scPageUp,
                  scPageDown,
                  scPosition,
                  scTrack,
                  scTop,
                  scBottom,
                  scEndScroll };
	public enum TMouseActivate : byte {maDefault,
                     maActivate,
                     maActivateAndEat,
                     maNoActivate,
                     maNoActivateAndEat };
	public enum TMouseButton : byte {mbLeft,
                   mbRight,
                   mbMiddle };
	public enum TAnchorKind : byte {akLeft,
                  akTop,
                  akRight,
                  akBottom };
	public enum TBorderIcon : byte {biSystemMenu,
                  biMinimize,
                  biMaximize,
                  biHelp };
	public enum TCloseAction : byte {caNone,
                   caHide,
                   caFree,
                   caMinimize };
	public enum TDragMode : byte {dmManual,
                dmAutomatic };
	public enum TDragState : byte {dsDragEnter,
                 dsDragLeave,
                 dsDragMove };
	public enum TDragKind : byte {dkDrag,
                dkDock };
	public enum TEditCharCase : byte {ecNormal,
                    ecUpperCase,
                    ecLowerCase };
	public enum TScrollStyle : byte {ssNone,
                   ssHorizontal,
                   ssVertical,
                   ssBoth };
	public enum TWindowState : byte {wsNormal,
                   wsMinimized,
                   wsMaximized };


  /* Message dialogs and modal results. */
	public enum TMsgDlgType : byte {mtWarning,
                  mtError,
                  mtInformation,
                  mtConfirmation,
                  mtCustom };
	public enum TMsgDlgBtn : byte {mbYes,
                 mbNo,
                 mbOK,
                 mbCancel,
                 mbAbort,
                 mbRetry,
                 mbIgnore,
                 mbAll,
                 mbNoToAll,
                 mbYesToAll,
                 mbHelp,
                 mbClose };

  /* Standard dialog result identifiers. */
	public const int idOK = 1;
	public const int idCancel = 2;
	public const int idAbort = 3;
	public const int idRetry = 4;
	public const int idIgnore = 5;
	public const int idYes = 6;
	public const int idNo = 7;
	public const int idClose = 8;
	public const int idHelp = 9;
	public const int idTryAgain = 10;
	public const int idContinue = 11;

  /* Modal result values correspond to the standard dialog identifiers. */
	public const int mrNone = 0;
	public const int mrOk = idOK;
	public const int mrCancel = idCancel;
	public const int mrAbort = idAbort;
	public const int mrRetry = idRetry;
	public const int mrIgnore = idIgnore;
	public const int mrYes = idYes;
	public const int mrNo = idNo;
	public const int mrClose = idClose;
	public const int mrHelp = idHelp;
	public const int mrTryAgain = idTryAgain;
	public const int mrContinue = idContinue;
	public const int mrAll = 12;
	public const int mrNoToAll = 13;
	public const int mrYesToAll = 14;

  /* Common font character sets. */
	public const int ANSI_CHARSET = 0;
	public const int DEFAULT_CHARSET = 1;
	public const int SYMBOL_CHARSET = 2;
	public const int SHIFTJIS_CHARSET = 128;
	public const int HANGEUL_CHARSET = 129;
	public const int GB2312_CHARSET = 134;
	public const int CHINESEBIG5_CHARSET = 136;
	public const int GREEK_CHARSET = 161;
	public const int TURKISH_CHARSET = 162;
	public const int VIETNAMESE_CHARSET = 163;
	public const int HEBREW_CHARSET = 177;
	public const int ARABIC_CHARSET = 178;
	public const int BALTIC_CHARSET = 186;
	public const int RUSSIAN_CHARSET = 204;
	public const int THAI_CHARSET = 222;
	public const int EASTEUROPE_CHARSET = 238;
	public const int OEM_CHARSET = 255;

  /* Standard cursor identifiers. */
	public const int crDefault = 0;
	public const int crNone = -1;
	public const int crArrow = -2;
	public const int crCross = -3;
	public const int crIBeam = -4;
	public const int crSize = -22;
	public const int crSizeNESW = -6;
	public const int crSizeNS = -7;
	public const int crSizeNWSE = -8;
	public const int crSizeWE = -9;
	public const int crUpArrow = -10;
	public const int crHourGlass = -11;
	public const int crDrag = -12;
	public const int crNoDrop = -13;
	public const int crHSplit = -14;
	public const int crVSplit = -15;
	public const int crMultiDrag = -16;
	public const int crSQLWait = -17;
	public const int crNo = -18;
	public const int crAppStart = -19;
	public const int crHelp = -20;
	public const int crHandPoint = -21;
	public const int crSizeAll = -22;

  /* Virtual-key constants for keyboard and mouse input. */
	public const int vkLButton = 0x01;
	public const int vkRButton = 0x02;
	public const int vkCancel = 0x03;
	public const int vkMButton = 0x04;
	public const int vkXButton1 = 0x05;
	public const int vkXButton2 = 0x06;
	public const int vkBack = 0x08;
	public const int vkTab = 0x09;
	public const int vkLineFeed = 0x0A;
	public const int vkClear = 0x0C;
	public const int vkReturn = 0x0D;
	public const int vkShift = 0x10;
	public const int vkControl = 0x11;
	public const int vkMenu = 0x12;
	public const int vkPause = 0x13;
	public const int vkCapital = 0x14;
	public const int vkKana = 0x15;
	public const int vkHangul = 0x15;
	public const int vkJunja = 0x17;
	public const int vkFinal = 0x18;
	public const int vkHanja = 0x19;
	public const int vkKanji = 0x19;
	public const int vkEscape = 0x1B;
	public const int vkConvert = 0x1C;
	public const int vkNonConvert = 0x1D;
	public const int vkAccept = 0x1E;
	public const int vkModeChange = 0x1F;
	public const int vkSpace = 0x20;
	public const int vkPrior = 0x21;
	public const int vkNext = 0x22;
	public const int vkEnd = 0x23;
	public const int vkHome = 0x24;
	public const int vkLeft = 0x25;
	public const int vkUp = 0x26;
	public const int vkRight = 0x27;
	public const int vkDown = 0x28;
	public const int vkSelect = 0x29;
	public const int vkPrint = 0x2A;
	public const int vkExecute = 0x2B;
	public const int vkSnapshot = 0x2C;
	public const int vkInsert = 0x2D;
	public const int vkDelete = 0x2E;
	public const int vkHelp = 0x2F;
	public const int vkLWin = 0x5B;
	public const int vkRWin = 0x5C;
	public const int vkApps = 0x5D;
	public const int vkSleep = 0x5F;
	public const int vkMultiply = 0x6A;
	public const int vkAdd = 0x6B;
	public const int vkSeparator = 0x6C;
	public const int vkSubtract = 0x6D;
	public const int vkDecimal = 0x6E;
	public const int vkDivide = 0x6F;
	public const int vkNumLock = 0x90;
	public const int vkScroll = 0x91;
	public const int vkLShift = 0xA0;
	public const int vkRShift = 0xA1;
	public const int vkLControl = 0xA2;
	public const int vkRControl = 0xA3;
	public const int vkLMenu = 0xA4;
	public const int vkRMenu = 0xA5;
	public const int vkBrowserBack = 0xA6;
	public const int vkBrowserForward = 0xA7;
	public const int vkBrowserRefresh = 0xA8;
	public const int vkBrowserStop = 0xA9;
	public const int vkBrowserSearch = 0xAA;
	public const int vkBrowserFavorites = 0xAB;
	public const int vkBrowserHome = 0xAC;
	public const int vkVolumeMute = 0xAD;
	public const int vkVolumeDown = 0xAE;
	public const int vkVolumeUp = 0xAF;
	public const int vkMediaNextTrack = 0xB0;
	public const int vkMediaPrevTrack = 0xB1;
	public const int vkMediaStop = 0xB2;
	public const int vkMediaPlayPause = 0xB3;
	public const int vkLaunchMail = 0xB4;
	public const int vkLaunchMediaSelect = 0xB5;
	public const int vkLaunchApp1 = 0xB6;
	public const int vkLaunchApp2 = 0xB7;
	public const int vkSemicolon = 0xBA;
	public const int vkPlus = 0xBB;
	public const int vkEqual = 0xBB;  /* VK_OEM_PLUS: equal/plus key, Microsoft Win32 */
	public const int vkComma = 0xBC;
	public const int vkMinus = 0xBD;
	public const int vkPeriod = 0xBE;
	public const int vkSlash = 0xBF;
	public const int vkTilde = 0xC0;
	public const int vkLeftBracket = 0xDB;
	public const int vkBackslash = 0xDC;
	public const int vkRightBracket = 0xDD;
	public const int vkQuote = 0xDE;
	public const int vkOem8 = 0xDF;
	public const int vkOem102 = 0xE2;
	public const int vkProcessKey = 0xE5;
	public const int vkIcoClear = 0xE6;
	public const int vkPacket = 0xE7;
	public const int vkOemReset = 0xE9;
	public const int vkOemJump = 0xEA;
	public const int vkOemPa1 = 0xEB;
	public const int vkOemPa2 = 0xEC;
	public const int vkOemPa3 = 0xED;
	public const int vkOemWsCtrl = 0xEE;
	public const int vkOemCuSel = 0xEF;
	public const int vkOemAttn = 0xF0;
	public const int vkOemFinish = 0xF1;
	public const int vkOemCopy = 0xF2;
	public const int vkOemAuto = 0xF3;
	public const int vkOemEnlw = 0xF4;
	public const int vkOemBackTab = 0xF5;
	public const int vkAttn = 0xF6;
	public const int vkCrSel = 0xF7;
	public const int vkExSel = 0xF8;
	public const int vkErEof = 0xF9;
	public const int vkPlay = 0xFA;
	public const int vkZoom = 0xFB;
	public const int vkNoname = 0xFC;
	public const int vkPa1 = 0xFD;
	public const int vkOemClear = 0xFE;
	public const int vkNone = 0xFF;
	public const int vk0 = 0x30;
	public const int vk1 = 0x31;
	public const int vk2 = 0x32;
	public const int vk3 = 0x33;
	public const int vk4 = 0x34;
	public const int vk5 = 0x35;
	public const int vk6 = 0x36;
	public const int vk7 = 0x37;
	public const int vk8 = 0x38;
	public const int vk9 = 0x39;
	public const int vkA = 0x41;
	public const int vkB = 0x42;
	public const int vkC = 0x43;
	public const int vkD = 0x44;
	public const int vkE = 0x45;
	public const int vkF = 0x46;
	public const int vkG = 0x47;
	public const int vkH = 0x48;
	public const int vkI = 0x49;
	public const int vkJ = 0x4A;
	public const int vkK = 0x4B;
	public const int vkL = 0x4C;
	public const int vkM = 0x4D;
	public const int vkN = 0x4E;
	public const int vkO = 0x4F;
	public const int vkP = 0x50;
	public const int vkQ = 0x51;
	public const int vkR = 0x52;
	public const int vkS = 0x53;
	public const int vkT = 0x54;
	public const int vkU = 0x55;
	public const int vkV = 0x56;
	public const int vkW = 0x57;
	public const int vkX = 0x58;
	public const int vkY = 0x59;
	public const int vkZ = 0x5A;
	public const int vkNumpad0 = 0x60;
	public const int vkNumpad1 = 0x61;
	public const int vkNumpad2 = 0x62;
	public const int vkNumpad3 = 0x63;
	public const int vkNumpad4 = 0x64;
	public const int vkNumpad5 = 0x65;
	public const int vkNumpad6 = 0x66;
	public const int vkNumpad7 = 0x67;
	public const int vkNumpad8 = 0x68;
	public const int vkNumpad9 = 0x69;
	public const int vkF1 = 0x70;
	public const int vkF2 = 0x71;
	public const int vkF3 = 0x72;
	public const int vkF4 = 0x73;
	public const int vkF5 = 0x74;
	public const int vkF6 = 0x75;
	public const int vkF7 = 0x76;
	public const int vkF8 = 0x77;
	public const int vkF9 = 0x78;
	public const int vkF10 = 0x79;
	public const int vkF11 = 0x7A;
	public const int vkF12 = 0x7B;
	public const int vkF13 = 0x7C;
	public const int vkF14 = 0x7D;
	public const int vkF15 = 0x7E;
	public const int vkF16 = 0x7F;
	public const int vkF17 = 0x80;
	public const int vkF18 = 0x81;
	public const int vkF19 = 0x82;
	public const int vkF20 = 0x83;
	public const int vkF21 = 0x84;
	public const int vkF22 = 0x85;
	public const int vkF23 = 0x86;
	public const int vkF24 = 0x87;
	public const int vkIcoHelp = 0xE3;
	public const int vkIco00 = 0xE4;
	public const int vkHagul = 0x15;

/* These simple predicates are implemented for meaningful mock behavior. */
	public static bool IsAbortResult(int AModalResult)
	{
		bool result = false;
		result = (AModalResult == mrAbort) || (AModalResult == mrCancel);
		return result;
	}
	public static bool IsAnAllResult(int AModalResult)
	{
		bool result = false;
		result = (AModalResult == mrAll) || (AModalResult == mrNoToAll) || (AModalResult == mrYesToAll);
		return result;
	}
	public static bool IsNegativeResult(int AModalResult)
	{
		bool result = false;
		result = (AModalResult == mrNo) || (AModalResult == mrNoToAll);
		return result;
	}
	public static bool IsPositiveResult(int AModalResult)
	{
		bool result = false;
		result = (AModalResult == mrOk) || (AModalResult == mrYes) || (AModalResult == mrAll) || (AModalResult == mrYesToAll);
		return result;
	}
	public static int StripAllFromResult(int AModalResult)
	{
		int result = 0;
		result = AModalResult;
		switch(AModalResult)
		{
			case mrAll:
			result = mrOk;
			break;
			case mrNoToAll:
			result = mrNo;
			break;
			case mrYesToAll:
			result = mrYes;
			break;
			default:
			  ;
			break;
		}
		return result;
	}
	
} // class UitypesInterface


file class UitypesImplementation
{

} // class UitypesImplementation

}  // namespace Uitypes

}  // namespace System

