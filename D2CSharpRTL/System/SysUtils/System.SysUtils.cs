global using TBytes = System.Byte[];
global using TCharArray = System.Char[];

using System.Text;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System;
using static System.SystemInterface;
using static System.Sysutils.SysutilsImplementation;
using static System.Sysutils.SysutilsInterface;

namespace System
{

namespace Sysutils
{

/*
  D2CSharp Runtime Library (RTL)

  This C# source file provides the D2CSharp runtime implementation of
  System.SysUtils functionality.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The implementation maps Delphi SysUtils behavior to managed .NET services
  while preserving the signatures generated from the MockRTL unit.

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


public class SysutilsInterface
{

	public enum TStringSplitOptions { None, ExcludeEmpty, ExcludeLastEmpty };


	// Primitive type helpers corresponding to the public System.SysUtils record helpers.
	public static class TBooleanHelper
	{
		public static bool Parse(string s) => SysutilsInterface.StrToBool(s);
		public static bool TryToParse(string s, out bool value) => SysutilsInterface.TryStrToBool(s, out value);
		public static int Size() => sizeof(bool);
		public static int ToInteger(bool value) => value ? 1 : 0;
		public static string ToString(bool value) => SysutilsInterface.BoolToStr(value, true);
	}
	public static class TByteBoolHelper
	{
		public static bool Parse(string s) => TBooleanHelper.Parse(s);
		public static bool TryToParse(string s, out bool value) => TBooleanHelper.TryToParse(s, out value);
		public static int Size() => 1;
		public static int ToInteger(bool value) => value ? 1 : 0;
		public static string ToString(bool value) => TBooleanHelper.ToString(value);
	}
	public static class TWordBoolHelper
	{
		public static bool Parse(string s) => TBooleanHelper.Parse(s);
		public static bool TryToParse(string s, out bool value) => TBooleanHelper.TryToParse(s, out value);
		public static int Size() => 2;
		public static int ToInteger(bool value) => value ? 1 : 0;
		public static string ToString(bool value) => TBooleanHelper.ToString(value);
	}
	public static class TLongBoolHelper
	{
		public static bool Parse(string s) => TBooleanHelper.Parse(s);
		public static bool TryToParse(string s, out bool value) => TBooleanHelper.TryToParse(s, out value);
		public static int Size() => 4;
		public static int ToInteger(bool value) => value ? 1 : 0;
		public static string ToString(bool value) => TBooleanHelper.ToString(value);
	}

	public static class TShortIntHelper
	{
		public const sbyte MinValue = sbyte.MinValue;
		public const sbyte MaxValue = sbyte.MaxValue;
		public static sbyte Parse(string s) => sbyte.Parse(s, NumberStyles.Integer, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out sbyte value) => sbyte.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(sbyte);
		public static bool ToBoolean(sbyte value) => value != 0;
		public static float ToSingle(sbyte value) => value;
		public static double ToDouble(sbyte value) => value;
		public static double ToExtended(sbyte value) => value;
		public static string ToHexString(sbyte value) => ToHexString(value, 0);
		public static string ToHexString(sbyte value, int minDigits) => unchecked((long)value).ToString("X" + global::System.Math.Max(0,minDigits), CultureInfo.InvariantCulture);
		public static string ToString(sbyte value) => value.ToString(CultureInfo.CurrentCulture);
	}

	public static class TByteHelper
	{
		public const byte MinValue = byte.MinValue;
		public const byte MaxValue = byte.MaxValue;
		public static byte Parse(string s) => byte.Parse(s, NumberStyles.Integer, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out byte value) => byte.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(byte);
		public static bool ToBoolean(byte value) => value != 0;
		public static float ToSingle(byte value) => value;
		public static double ToDouble(byte value) => value;
		public static double ToExtended(byte value) => value;
		public static string ToHexString(byte value) => ToHexString(value, 0);
		public static string ToHexString(byte value, int minDigits) => unchecked((long)value).ToString("X" + global::System.Math.Max(0,minDigits), CultureInfo.InvariantCulture);
		public static string ToString(byte value) => value.ToString(CultureInfo.CurrentCulture);
	}

	public static class TSmallIntHelper
	{
		public const short MinValue = short.MinValue;
		public const short MaxValue = short.MaxValue;
		public static short Parse(string s) => short.Parse(s, NumberStyles.Integer, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out short value) => short.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(short);
		public static bool ToBoolean(short value) => value != 0;
		public static float ToSingle(short value) => value;
		public static double ToDouble(short value) => value;
		public static double ToExtended(short value) => value;
		public static string ToHexString(short value) => ToHexString(value, 0);
		public static string ToHexString(short value, int minDigits) => unchecked((long)value).ToString("X" + global::System.Math.Max(0,minDigits), CultureInfo.InvariantCulture);
		public static string ToString(short value) => value.ToString(CultureInfo.CurrentCulture);
	}

	public static class TWordHelper
	{
		public const ushort MinValue = ushort.MinValue;
		public const ushort MaxValue = ushort.MaxValue;
		public static ushort Parse(string s) => ushort.Parse(s, NumberStyles.Integer, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out ushort value) => ushort.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(ushort);
		public static bool ToBoolean(ushort value) => value != 0;
		public static float ToSingle(ushort value) => value;
		public static double ToDouble(ushort value) => value;
		public static double ToExtended(ushort value) => value;
		public static string ToHexString(ushort value) => ToHexString(value, 0);
		public static string ToHexString(ushort value, int minDigits) => unchecked((long)value).ToString("X" + global::System.Math.Max(0,minDigits), CultureInfo.InvariantCulture);
		public static string ToString(ushort value) => value.ToString(CultureInfo.CurrentCulture);
	}

	public static class TIntegerHelper
	{
		public const int MinValue = int.MinValue;
		public const int MaxValue = int.MaxValue;
		public static int Parse(string s) => int.Parse(s, NumberStyles.Integer, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out int value) => int.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(int);
		public static bool ToBoolean(int value) => value != 0;
		public static float ToSingle(int value) => value;
		public static double ToDouble(int value) => value;
		public static double ToExtended(int value) => value;
		public static string ToHexString(int value) => ToHexString(value, 0);
		public static string ToHexString(int value, int minDigits) => unchecked((long)value).ToString("X" + global::System.Math.Max(0,minDigits), CultureInfo.InvariantCulture);
		public static string ToString(int value) => value.ToString(CultureInfo.CurrentCulture);
	}

	public static class TCardinalHelper
	{
		public const uint MinValue = uint.MinValue;
		public const uint MaxValue = uint.MaxValue;
		public static uint Parse(string s) => uint.Parse(s, NumberStyles.Integer, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out uint value) => uint.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(uint);
		public static bool ToBoolean(uint value) => value != 0;
		public static float ToSingle(uint value) => value;
		public static double ToDouble(uint value) => value;
		public static double ToExtended(uint value) => value;
		public static string ToHexString(uint value) => ToHexString(value, 0);
		public static string ToHexString(uint value, int minDigits) => unchecked((long)value).ToString("X" + global::System.Math.Max(0,minDigits), CultureInfo.InvariantCulture);
		public static string ToString(uint value) => value.ToString(CultureInfo.CurrentCulture);
	}

	public static class TInt64Helper
	{
		public const long MinValue = long.MinValue;
		public const long MaxValue = long.MaxValue;
		public static long Parse(string s) => long.Parse(s, NumberStyles.Integer, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out long value) => long.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(long);
		public static bool ToBoolean(long value) => value != 0;
		public static float ToSingle(long value) => value;
		public static double ToDouble(long value) => value;
		public static double ToExtended(long value) => value;
		public static string ToHexString(long value) => ToHexString(value, 0);
		public static string ToHexString(long value, int minDigits) => unchecked((long)value).ToString("X" + global::System.Math.Max(0,minDigits), CultureInfo.InvariantCulture);
		public static string ToString(long value) => value.ToString(CultureInfo.CurrentCulture);
	}

	public static class TUInt64Helper
	{
		public const ulong MinValue = ulong.MinValue;
		public const ulong MaxValue = ulong.MaxValue;
		public static ulong Parse(string s) => ulong.Parse(s, NumberStyles.Integer, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out ulong value) => ulong.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(ulong);
		public static bool ToBoolean(ulong value) => value != 0;
		public static float ToSingle(ulong value) => value;
		public static double ToDouble(ulong value) => value;
		public static double ToExtended(ulong value) => value;
		public static string ToHexString(ulong value) => ToHexString(value, 0);
		public static string ToHexString(ulong value, int minDigits) => unchecked((ulong)value).ToString("X" + global::System.Math.Max(0,minDigits), CultureInfo.InvariantCulture);
		public static string ToString(ulong value) => value.ToString(CultureInfo.CurrentCulture);
	}

	private static TFloatSpecial FloatSpecial(double value)
	{
		if (double.IsNaN(value)) return TFloatSpecial.fsNaN;
		if (double.IsPositiveInfinity(value)) return TFloatSpecial.fsInf;
		if (double.IsNegativeInfinity(value)) return TFloatSpecial.fsNInf;
		long bits = BitConverter.DoubleToInt64Bits(value);
		bool neg = bits < 0;
		if (value == 0.0) return neg ? TFloatSpecial.fsNZero : TFloatSpecial.fsZero;
		long exp = (bits >> 52) & 0x7FFL;
		if (exp == 0) return neg ? TFloatSpecial.fsNDenormal : TFloatSpecial.fsDenormal;
		return neg ? TFloatSpecial.fsNegative : TFloatSpecial.fsPositive;
	}
	public static class TSingleHelper
	{
		public const float MinValue = float.MinValue, MaxValue = float.MaxValue, Epsilon = float.Epsilon;
		public static readonly float NaN=float.NaN, NegativeInfinity=float.NegativeInfinity, PositiveInfinity=float.PositiveInfinity;
		public static float Parse(string s) => float.Parse(s, NumberStyles.Float, CultureInfo.CurrentCulture);
		public static bool TryParse(string s, out float value) => float.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
		public static int Size() => sizeof(float);
		public static float BuildUp(bool signFlag, ulong mantissa, int exponent) => (float)((signFlag?-1.0:1.0)*mantissa*global::System.Math.Pow(2.0,exponent-23));
		public static int Exponent(float value) => (BitConverter.SingleToInt32Bits(value)>>23)&0xFF;
		public static ulong Fraction(float value) => (uint)BitConverter.SingleToInt32Bits(value)&0x7FFFFFu;
		public static ulong Mantissa(float value) { ulong f=Fraction(value); return Exponent(value)==0?f:f|0x800000u; }
		public static TFloatSpecial SpecialType(float value) => FloatSpecial(value);
		public static bool IsNan(float value)=>float.IsNaN(value); public static bool IsInfinity(float value)=>float.IsInfinity(value);
		public static bool IsNegativeInfinity(float value)=>float.IsNegativeInfinity(value); public static bool IsPositiveInfinity(float value)=>float.IsPositiveInfinity(value);
		public static string ToString(float value)=>value.ToString(CultureFromSettings(SysutilsInterface.FormatSettings));
		public static string ToString(float value,TFloatFormat format,int precision,int digits)=>SysutilsInterface.FloatToStrF(value,format,precision,digits);
		public static string ToString(float value,TFloatFormat format,int precision,int digits,TFormatSettings fs)=>SysutilsInterface.FloatToStrF(value,format,precision,digits,fs);
	}
	public static class TDoubleHelper
	{
		public const double MinValue = double.MinValue, MaxValue = double.MaxValue, Epsilon = double.Epsilon;
		public static readonly double NaN=double.NaN, NegativeInfinity=double.NegativeInfinity, PositiveInfinity=double.PositiveInfinity;
		public static double Parse(string s) => SysutilsInterface.StrToFloat(s);
		public static bool TryParse(string s, out double value) => SysutilsInterface.TryStrToFloat(s,out value);
		public static int Size() => sizeof(double);
		public static double BuildUp(bool signFlag, ulong mantissa, int exponent) => (signFlag?-1.0:1.0)*mantissa*global::System.Math.Pow(2.0,exponent-52);
		public static int Exponent(double value) => (int)((BitConverter.DoubleToInt64Bits(value)>>52)&0x7FFL);
		public static ulong Fraction(double value) => (ulong)BitConverter.DoubleToInt64Bits(value)&0xFFFFFFFFFFFFFUL;
		public static ulong Mantissa(double value) { ulong f=Fraction(value); return Exponent(value)==0?f:f|0x10000000000000UL; }
		public static TFloatSpecial SpecialType(double value) => FloatSpecial(value);
		public static bool IsNan(double value)=>double.IsNaN(value); public static bool IsInfinity(double value)=>double.IsInfinity(value);
		public static bool IsNegativeInfinity(double value)=>double.IsNegativeInfinity(value); public static bool IsPositiveInfinity(double value)=>double.IsPositiveInfinity(value);
		public static string ToString(double value)=>value.ToString(CultureFromSettings(SysutilsInterface.FormatSettings));
		public static string ToString(double value,TFloatFormat format,int precision,int digits)=>SysutilsInterface.FloatToStrF(value,format,precision,digits);
		public static string ToString(double value,TFloatFormat format,int precision,int digits,TFormatSettings fs)=>SysutilsInterface.FloatToStrF(value,format,precision,digits,fs);
	}
	public static class TExtendedHelper
	{
		public const double MinValue = double.MinValue, MaxValue = double.MaxValue, Epsilon = double.Epsilon;
		public static readonly double NaN=double.NaN, NegativeInfinity=double.NegativeInfinity, PositiveInfinity=double.PositiveInfinity;
		public static double Parse(string s)=>TDoubleHelper.Parse(s); public static bool TryParse(string s,out double value)=>TDoubleHelper.TryParse(s,out value);
		public static int Size()=>sizeof(double); public static double BuildUp(bool signFlag,ulong mantissa,int exponent)=>TDoubleHelper.BuildUp(signFlag,mantissa,exponent);
		public static int Exponent(double value)=>TDoubleHelper.Exponent(value); public static ulong Fraction(double value)=>TDoubleHelper.Fraction(value); public static ulong Mantissa(double value)=>TDoubleHelper.Mantissa(value);
		public static TFloatSpecial SpecialType(double value)=>TDoubleHelper.SpecialType(value); public static bool IsNan(double value)=>double.IsNaN(value); public static bool IsInfinity(double value)=>double.IsInfinity(value);
		public static bool IsNegativeInfinity(double value)=>double.IsNegativeInfinity(value); public static bool IsPositiveInfinity(double value)=>double.IsPositiveInfinity(value);
		public static string ToString(double value)=>TDoubleHelper.ToString(value); public static string ToString(double value,TFloatFormat format,int precision,int digits)=>TDoubleHelper.ToString(value,format,precision,digits);
		public static string ToString(double value,TFloatFormat format,int precision,int digits,TFormatSettings fs)=>TDoubleHelper.ToString(value,format,precision,digits,fs);
	}
	public static class TCurrencyHelper
	{
		public static Currency Parse(string s)=>SysutilsInterface.StrToCurr(s);
		public static bool TryParse(string s,out Currency value)=>SysutilsInterface.TryStrToCurr(s,out value);
		public static int Size()=>8;
		public static string ToString(Currency value)=>SysutilsInterface.CurrToStr(value);
		public static string ToString(Currency value,TFloatFormat format,int digits)=>SysutilsInterface.CurrToStrF(value,format,digits);
		public static string ToString(Currency value,TFloatFormat format,int digits,TFormatSettings fs)=>SysutilsInterface.CurrToStrF(value,format,digits,fs);
	}
	public static class TGUIDHelper
	{
		public static Guid Create(string s)=>new Guid(s);
		public static Guid Create(byte[] bytes)=>new Guid(bytes ?? Array.Empty<byte>());
		public static Guid Create(uint a,ushort b,ushort c,byte d,byte e,byte f,byte g,byte h,byte i,byte j,byte k)=>new Guid(unchecked((int)a),unchecked((short)b),unchecked((short)c),d,e,f,g,h,i,j,k);
		public static Guid NewGuid()=>Guid.NewGuid();
		public static byte[] ToByteArray(Guid value)=>value.ToByteArray();
		public static string ToString(Guid value)=>value.ToString("B").ToUpperInvariant();
	}

	public static class TStringHelper
	{
		private static string S(string value) => value ?? string.Empty;
		private static StringComparison Cmp(bool ignoreCase) => ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
		private static int ClampStart(string s, int start) => global::System.Math.Max(0, global::System.Math.Min(start, s.Length));

		public static string Create(char c, int count) => new string(c, global::System.Math.Max(0, count));
		public static string Create(char[] value, int startIndex, int length) => new string(value ?? Array.Empty<char>(), startIndex, length);
		public static string Create(char[] value) => new string(value ?? Array.Empty<char>());
		public static int Compare(string a, string b) => string.Compare(S(a), S(b), StringComparison.Ordinal);
		public static int Compare(string a, string b, bool ignoreCase) => string.Compare(S(a), S(b), Cmp(ignoreCase));
		public static int Compare(string a, int indexA, string b, int indexB, int length) => string.Compare(S(a), indexA, S(b), indexB, length, StringComparison.Ordinal);
		public static int Compare(string a, int indexA, string b, int indexB, int length, bool ignoreCase) => string.Compare(S(a), indexA, S(b), indexB, length, Cmp(ignoreCase));
		public static int CompareOrdinal(string a, string b) => string.CompareOrdinal(S(a), S(b));
		public static int CompareOrdinal(string a, int indexA, string b, int indexB, int length) => string.CompareOrdinal(S(a), indexA, S(b), indexB, length);
		public static int CompareText(string a, string b) => string.Compare(S(a), S(b), StringComparison.OrdinalIgnoreCase);
		public static int CompareTo(string self, string b) => string.Compare(S(self), S(b), StringComparison.Ordinal);
		public static bool Contains(string self, string value) => S(self).Contains(S(value), StringComparison.Ordinal);
		public static string Copy(string value) => string.Copy(S(value));
		public static void CopyTo(string self, int sourceIndex, char[] destination, int destinationIndex, int count) => S(self).CopyTo(sourceIndex, destination, destinationIndex, count);
		public static int CountChar(string self, char c) => S(self).Count(x => x == c);
		public static string DeQuotedString(string self) => DeQuotedString(self, '\'');
		public static string DeQuotedString(string self, char quote) { string s=S(self); if(s.Length>=2 && s[0]==quote && s[^1]==quote) return s.Substring(1,s.Length-2).Replace(new string(quote,2), quote.ToString()); return s; }
		public static bool EndsText(string subText, string text) => S(text).EndsWith(S(subText), StringComparison.OrdinalIgnoreCase);
		public static bool EndsWith(string self, string value) => S(self).EndsWith(S(value), StringComparison.Ordinal);
		public static bool EndsWith(string self, string value, bool ignoreCase) => S(self).EndsWith(S(value), Cmp(ignoreCase));
		public static bool Equals(string a, string b) => string.Equals(S(a), S(b), StringComparison.Ordinal);
		public static string Format(string format, params TVarRec[] args) => SysutilsInterface.Format(format, args);
		public static int GetHashCode(string self) => S(self).GetHashCode();
		public static int IndexOf(string self, char value) => S(self).IndexOf(value);
		public static int IndexOf(string self, string value) => S(self).IndexOf(S(value), StringComparison.Ordinal);
		public static int IndexOf(string self, char value, int startIndex) => S(self).IndexOf(value, startIndex);
		public static int IndexOf(string self, string value, int startIndex) => S(self).IndexOf(S(value), startIndex, StringComparison.Ordinal);
		public static int IndexOf(string self, char value, int startIndex, int count) => S(self).IndexOf(value, startIndex, count);
		public static int IndexOf(string self, string value, int startIndex, int count) => S(self).IndexOf(S(value), startIndex, count, StringComparison.Ordinal);
		public static int IndexOfAny(string self, char[] anyOf) => S(self).IndexOfAny(anyOf ?? Array.Empty<char>());
		public static int IndexOfAny(string self, char[] anyOf, int startIndex) => S(self).IndexOfAny(anyOf ?? Array.Empty<char>(), startIndex);
		public static int IndexOfAny(string self, char[] anyOf, int startIndex, int count) => S(self).IndexOfAny(anyOf ?? Array.Empty<char>(), startIndex, count);
		private static int IndexOfAnyUnquotedCore(string self, string[] needles, char quoteStart, char quoteEnd, int start, int count, out int matched) { string s=S(self); matched=-1; int end=global::System.Math.Min(s.Length, start+global::System.Math.Max(0,count)); bool quoted=false; for(int i=global::System.Math.Max(0,start);i<end;i++){ if(!quoted && s[i]==quoteStart){quoted=true;continue;} if(quoted && s[i]==quoteEnd){quoted=false;continue;} if(quoted) continue; for(int n=0;n<needles.Length;n++){var q=needles[n]??string.Empty;if(q.Length>0 && i+q.Length<=end && string.CompareOrdinal(s,i,q,0,q.Length)==0){matched=n;return i;}} } return -1; }
		public static int IndexOfAnyUnquoted(string self, char[] anyOf, char startQuote, char endQuote) => IndexOfAnyUnquoted(self, anyOf, startQuote, endQuote, 0, S(self).Length);
		public static int IndexOfAnyUnquoted(string self, char[] anyOf, char startQuote, char endQuote, int startIndex) => IndexOfAnyUnquoted(self, anyOf, startQuote, endQuote, startIndex, S(self).Length-startIndex);
		public static int IndexOfAnyUnquoted(string self, char[] anyOf, char startQuote, char endQuote, int startIndex, int count) { int m; return IndexOfAnyUnquotedCore(self,(anyOf??Array.Empty<char>()).Select(c=>c.ToString()).ToArray(),startQuote,endQuote,startIndex,count,out m); }
		public static int IndexOfAnyUnquoted(string self, string[] anyOf, char startQuote, char endQuote, int startIndex, out int matched) => IndexOfAnyUnquotedCore(self,anyOf??Array.Empty<string>(),startQuote,endQuote,startIndex,S(self).Length-startIndex,out matched);
		public static string Insert(string self, int startIndex, string value) => S(self).Insert(ClampStart(S(self), startIndex), S(value));
		public static bool IsDelimiter(string self, string delimiters, int index) => index>=0 && index<S(self).Length && S(delimiters).IndexOf(S(self)[index])>=0;
		public static bool IsEmpty(string self) => S(self).Length==0;
		public static bool IsNullOrEmpty(string value) => string.IsNullOrEmpty(value);
		public static bool IsNullOrWhiteSpace(string value) => string.IsNullOrWhiteSpace(value);
		public static string Join(string separator, TVarRec[] values) => string.Join(S(separator),(values??Array.Empty<TVarRec>()).Select(v=>v.Value?.ToString()??string.Empty));
		public static string Join(string separator, string[] values) => string.Join(S(separator),values??Array.Empty<string>());
		public static string Join(string separator, string[] values, int startIndex, int count) => string.Join(S(separator),values??Array.Empty<string>(),startIndex,count);
		public static int LastDelimiter(string self, string delims) { string s=S(self); for(int i=s.Length-1;i>=0;i--) if(S(delims).IndexOf(s[i])>=0) return i; return -1; }
		public static int LastIndexOf(string self, char value) => S(self).LastIndexOf(value);
		public static int LastIndexOf(string self, string value) => S(self).LastIndexOf(S(value),StringComparison.Ordinal);
		public static int LastIndexOf(string self, char value, int startIndex) => S(self).LastIndexOf(value,startIndex);
		public static int LastIndexOf(string self, string value, int startIndex) => S(self).LastIndexOf(S(value),startIndex,StringComparison.Ordinal);
		public static int LastIndexOf(string self, char value, int startIndex, int count) => S(self).LastIndexOf(value,startIndex,count);
		public static int LastIndexOf(string self, string value, int startIndex, int count) => S(self).LastIndexOf(S(value),startIndex,count,StringComparison.Ordinal);
		public static int LastIndexOfAny(string self, char[] anyOf) => S(self).LastIndexOfAny(anyOf??Array.Empty<char>());
		public static int LastIndexOfAny(string self, char[] anyOf, int startIndex) => S(self).LastIndexOfAny(anyOf??Array.Empty<char>(),startIndex);
		public static int LastIndexOfAny(string self, char[] anyOf, int startIndex, int count) => S(self).LastIndexOfAny(anyOf??Array.Empty<char>(),startIndex,count);
		public static string PadLeft(string self, int width) => S(self).PadLeft(width);
		public static string PadLeft(string self, int width, char paddingChar) => S(self).PadLeft(width,paddingChar);
		public static string PadRight(string self, int width) => S(self).PadRight(width);
		public static string PadRight(string self, int width, char paddingChar) => S(self).PadRight(width,paddingChar);
		public static string Parse(int value) => value.ToString(CultureInfo.CurrentCulture);
		public static string Parse(long value) => value.ToString(CultureInfo.CurrentCulture);
		public static string Parse(bool value) => value.ToString();
		public static string Parse(double value) => SysutilsInterface.FloatToStr(value);
		public static string QuotedString(string self) => QuotedString(self,'"');
		public static string QuotedString(string self, char quote) => quote + S(self).Replace(quote.ToString(),new string(quote,2)) + quote;
		public static string Remove(string self, int startIndex) => S(self).Remove(startIndex);
		public static string Remove(string self, int startIndex, int count) => S(self).Remove(startIndex,count);
		public static string Replace(string self, char oldChar, char newChar) => S(self).Replace(oldChar,newChar);
		public static string Replace(string self, char oldChar, char newChar, TSet replaceFlags) => S(self).Replace(oldChar,newChar);
		public static string Replace(string self, string oldValue, string newValue) => S(self).Replace(S(oldValue),S(newValue));
		public static string Replace(string self, string oldValue, string newValue, TSet replaceFlags) => S(self).Replace(S(oldValue),S(newValue));
		private static string ReplaceStringIgnoreCase(string text,string oldValue,string newValue){ if(string.IsNullOrEmpty(oldValue)) return text; var b=new global::System.Text.StringBuilder(); int p=0; while(true){int i=text.IndexOf(oldValue,p,StringComparison.OrdinalIgnoreCase);if(i<0){b.Append(text,p,text.Length-p);break;}b.Append(text,p,i-p);b.Append(newValue);p=i+oldValue.Length;}return b.ToString(); }
		private static string[] SplitCore(string self, string[] sep, int count, TStringSplitOptions options, char? qs=null, char? qe=null){ string s=S(self); if(count<=0)return Array.Empty<string>(); if(qs==null) { var opt=options==TStringSplitOptions.ExcludeEmpty?StringSplitOptions.RemoveEmptyEntries:StringSplitOptions.None; var r=s.Split(sep??Array.Empty<string>(),count,opt); if(options==TStringSplitOptions.ExcludeLastEmpty && r.Length>0 && r[^1].Length==0) return r.Take(r.Length-1).ToArray(); return r; } var parts=new List<string>(); int start=0; bool quoted=false; for(int i=0;i<s.Length && parts.Count<count-1;i++){ if(!quoted && s[i]==qs){quoted=true;continue;} if(quoted && s[i]==qe){quoted=false;continue;} if(quoted)continue; string hit=null; foreach(var d in sep??Array.Empty<string>()){if(!string.IsNullOrEmpty(d)&&i+d.Length<=s.Length&&string.CompareOrdinal(s,i,d,0,d.Length)==0){hit=d;break;}} if(hit!=null){var part=s.Substring(start,i-start);if(options!=TStringSplitOptions.ExcludeEmpty||part.Length>0)parts.Add(part);i+=hit.Length-1;start=i+1;}} var last=s.Substring(start); if(options!=TStringSplitOptions.ExcludeEmpty||last.Length>0)parts.Add(last); if(options==TStringSplitOptions.ExcludeLastEmpty&&parts.Count>0&&parts[^1].Length==0)parts.RemoveAt(parts.Count-1); return parts.ToArray(); }
		public static string[] Split(string self, char[] sep) => Split(self,sep,int.MaxValue,TStringSplitOptions.None);
		public static string[] Split(string self, char[] sep, int count) => Split(self,sep,count,TStringSplitOptions.None);
		public static string[] Split(string self, char[] sep, TStringSplitOptions options) => Split(self,sep,int.MaxValue,options);
		public static string[] Split(string self, char[] sep, int count, TStringSplitOptions options) => SplitCore(self,(sep??Array.Empty<char>()).Select(c=>c.ToString()).ToArray(),count,options);
		public static string[] Split(string self, string[] sep) => Split(self,sep,int.MaxValue,TStringSplitOptions.None);
		public static string[] Split(string self, string[] sep, int count) => Split(self,sep,count,TStringSplitOptions.None);
		public static string[] Split(string self, string[] sep, TStringSplitOptions options) => Split(self,sep,int.MaxValue,options);
		public static string[] Split(string self, string[] sep, int count, TStringSplitOptions options) => SplitCore(self,sep,count,options);
		public static string[] Split(string self, char[] sep, char quote) => SplitCore(self,(sep??Array.Empty<char>()).Select(c=>c.ToString()).ToArray(),int.MaxValue,TStringSplitOptions.None,quote,quote);
		public static string[] Split(string self, char[] sep, char qs, char qe) => SplitCore(self,(sep??Array.Empty<char>()).Select(c=>c.ToString()).ToArray(),int.MaxValue,TStringSplitOptions.None,qs,qe);
		public static string[] Split(string self, char[] sep, char qs, char qe, TStringSplitOptions options) => SplitCore(self,(sep??Array.Empty<char>()).Select(c=>c.ToString()).ToArray(),int.MaxValue,options,qs,qe);
		public static string[] Split(string self, char[] sep, char qs, char qe, int count) => SplitCore(self,(sep??Array.Empty<char>()).Select(c=>c.ToString()).ToArray(),count,TStringSplitOptions.None,qs,qe);
		public static string[] Split(string self, char[] sep, char qs, char qe, int count, TStringSplitOptions options) => SplitCore(self,(sep??Array.Empty<char>()).Select(c=>c.ToString()).ToArray(),count,options,qs,qe);
		public static string[] Split(string self, string[] sep, char quote) => SplitCore(self,sep,int.MaxValue,TStringSplitOptions.None,quote,quote);
		public static string[] Split(string self, string[] sep, char qs, char qe) => SplitCore(self,sep,int.MaxValue,TStringSplitOptions.None,qs,qe);
		public static string[] Split(string self, string[] sep, char qs, char qe, TStringSplitOptions options) => SplitCore(self,sep,int.MaxValue,options,qs,qe);
		public static string[] Split(string self, string[] sep, char qs, char qe, int count) => SplitCore(self,sep,count,TStringSplitOptions.None,qs,qe);
		public static string[] Split(string self, string[] sep, char qs, char qe, int count, TStringSplitOptions options) => SplitCore(self,sep,count,options,qs,qe);
		public static bool StartsText(string subText, string text) => S(text).StartsWith(S(subText),StringComparison.OrdinalIgnoreCase);
		public static bool StartsWith(string self, string value) => S(self).StartsWith(S(value),StringComparison.Ordinal);
		public static bool StartsWith(string self, string value, bool ignoreCase) => S(self).StartsWith(S(value),Cmp(ignoreCase));
		public static string Substring(string self, int startIndex) => S(self).Substring(startIndex);
		public static string Substring(string self, int startIndex, int length) => S(self).Substring(startIndex,length);
		public static bool ToBoolean(string self) => SysutilsInterface.StrToBool(S(self));
		public static char[] ToCharArray(string self) => S(self).ToCharArray();
		public static char[] ToCharArray(string self, int startIndex, int length) => S(self).ToCharArray(startIndex,length);
		public static double ToDouble(string self) => SysutilsInterface.StrToFloat(S(self));
		public static double ToExtended(string self) => SysutilsInterface.StrToFloat(S(self));
		public static long ToInt64(string self) => SysutilsInterface.StrToInt64(S(self));
		public static int ToInteger(string self) => SysutilsInterface.StrToInt(S(self));
		public static float ToSingle(string self) => checked((float)SysutilsInterface.StrToFloat(S(self)));
		public static string ToLower(string self) => S(self).ToLower(CultureInfo.CurrentCulture);
		public static string ToLowerInvariant(string self) => S(self).ToLowerInvariant();
		public static string ToUpper(string self) => S(self).ToUpper(CultureInfo.CurrentCulture);
		public static string ToUpperInvariant(string self) => S(self).ToUpperInvariant();
		public static string Trim(string self) => S(self).Trim();
		public static string Trim(string self, char[] trimChars) => S(self).Trim(trimChars??Array.Empty<char>());
		public static string TrimEnd(string self, char[] trimChars) => S(self).TrimEnd(trimChars??Array.Empty<char>());
		public static string TrimLeft(string self) => S(self).TrimStart();
		public static string TrimLeft(string self, char[] trimChars) => S(self).TrimStart(trimChars??Array.Empty<char>());
		public static string TrimRight(string self) => S(self).TrimEnd();
		public static string TrimRight(string self, char[] trimChars) => S(self).TrimEnd(trimChars??Array.Empty<char>());
		public static string TrimStart(string self, char[] trimChars) => S(self).TrimStart(trimChars??Array.Empty<char>());
		public static string UpperCase(string s) => S(s).ToUpper(CultureInfo.CurrentCulture);
	}

	public struct WordRec
	{
		public byte Lo;
		public byte Hi;
		public static WordRec CreateRecord(){return new WordRec();}
	}	

	public struct LongRec
	{
		public ushort Lo;
		public ushort Hi;
		public static LongRec CreateRecord(){return new LongRec();}
	}	

	public struct Int64Rec
	{
		public uint Lo;
		public uint Hi;
		public static Int64Rec CreateRecord(){return new Int64Rec();}
	}	

	public struct TFloatRec
	{
		public short Exponent;
		public bool Negative;
		public byte[] Digits;
		public void CreateRecordMembers()
		{
			Digits = new byte[21/*# range 0..20*/];
		}
		public static TFloatRec CreateRecord()
		{
			TFloatRec tmp = new TFloatRec();
			tmp.CreateRecordMembers();
			return tmp;
		}
	}	

  /* Windows API compatibility types required by the public SysUtils records.
    These mirror the publicly documented FILETIME / WIN32_FIND_DATAW layout;
    they are dependencies of TSearchRec and TSymLinkRec, not SysUtils-owned API. */

	public struct TFileTime
	{
		public uint dwLowDateTime;
		public uint dwHighDateTime;
		public static TFileTime CreateRecord(){return new TFileTime();}
	}	

	public struct TSystemTime
	{
		public ushort wYear;
		public ushort wMonth;
		public ushort wDayOfWeek;
		public ushort wDay;
		public ushort wHour;
		public ushort wMinute;
		public ushort wSecond;
		public ushort wMilliseconds;
		public static TSystemTime CreateRecord(){return new TSystemTime();}
	}	

	public struct TWin32FindData
	{
		public uint dwFileAttributes;
		public TFileTime ftCreationTime;
		public TFileTime ftLastAccessTime;
		public TFileTime ftLastWriteTime;
		public uint nFileSizeHigh;
		public uint nFileSizeLow;
		public uint dwReserved0;
		public uint dwReserved1;
		public char[] cFileName;
		public char[] cAlternateFileName;
		public void CreateRecordMembers()
		{
			ftCreationTime = TFileTime.CreateRecord();
			ftLastAccessTime = TFileTime.CreateRecord();
			ftLastWriteTime = TFileTime.CreateRecord();
			cFileName = new char[260/*# range 0..259*/];
			cAlternateFileName = new char[14/*# range 0..13*/];
		}
		public static TWin32FindData CreateRecord()
		{
			TWin32FindData tmp = new TWin32FindData();
			tmp.CreateRecordMembers();
			return tmp;
		}
	}	

	public struct TOSVersion
	{
		public enum TArchitecture { arIntelX86, arIntelX64, arARM32, arARM64 };
		public enum TPlatform { pfWindows, pfMacOS, pfiOS, pfAndroid, pfWinRT, pfLinux };

		private static TArchitecture GetArchitecture()
		{
			switch (RuntimeInformation.ProcessArchitecture)
			{
				case global::System.Runtime.InteropServices.Architecture.X64: return TArchitecture.arIntelX64;
				case global::System.Runtime.InteropServices.Architecture.Arm: return TArchitecture.arARM32;
				case global::System.Runtime.InteropServices.Architecture.Arm64: return TArchitecture.arARM64;
				default: return TArchitecture.arIntelX86;
			}
		}

		private static Version OSVersion => Environment.OSVersion.Version;
		private static int GetBuild() => OSVersion.Build < 0 ? 0 : OSVersion.Build;
		private static int GetMajor() => OSVersion.Major;
		private static int GetMinor() => OSVersion.Minor;
		private static string GetName() => RuntimeInformation.OSDescription;

		private static TPlatform GetPlatform()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return TPlatform.pfWindows;
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return TPlatform.pfMacOS;
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return TPlatform.pfLinux;
			return TPlatform.pfWindows;
		}

		private static int GetServicePackMajor() => 0;
		private static int GetServicePackMinor() => 0;

		public static bool Check(int AMajor) => Check(AMajor, 0, 0);
		public static bool Check(int AMajor, int AMinor) => Check(AMajor, AMinor, 0);
		public static bool Check(int AMajor, int AMinor, int AServicePackMajor)
		{
			Version v = OSVersion;
			if (v.Major != AMajor) return v.Major > AMajor;
			if (v.Minor != AMinor) return v.Minor > AMinor;
			return GetServicePackMajor() >= AServicePackMajor;
		}

		public new static string ToString()
		{
			Version v = OSVersion;
			return $"{GetName()} {v.Major}.{v.Minor}.{GetBuild()}";
		}

		public static TArchitecture Architecture => GetArchitecture();
		public static int Build => GetBuild();
		public static int Major => GetMajor();
		public static int Minor => GetMinor();
		public static string Name => GetName();
		public static TPlatform Platform => GetPlatform();
		public static int ServicePackMajor => GetServicePackMajor();
		public static int ServicePackMinor => GetServicePackMinor();
		public static TOSVersion CreateRecord() => new TOSVersion();
	}	

	public class TEncoding : TObject
	{
		protected global::System.Text.Encoding FEncoding;

		public TEncoding()
			: this(new global::System.Text.UTF8Encoding(false))
		{
		}

		protected TEncoding(global::System.Text.Encoding encoding)
		{
			FEncoding = encoding ?? new global::System.Text.UTF8Encoding(false);
		}

		private static TEncoding GetANSI()
		{
			try { return new TEncoding(global::System.Text.Encoding.GetEncoding(0)); }
			catch { return new TEncoding(global::System.Text.Encoding.Default); }
		}
		private static TEncoding GetASCII() => new TEncoding(global::System.Text.Encoding.ASCII);
		private static TEncoding GetBigEndianUnicode() => new TEncoding(global::System.Text.Encoding.BigEndianUnicode);
		private static TEncoding GetDefault() => new TEncoding(global::System.Text.Encoding.Default);
		private static TEncoding GetUnicode() => new TEncoding(global::System.Text.Encoding.Unicode);
		private static TEncoding GetUTF7()
		{
#pragma warning disable SYSLIB0001
			return new TEncoding(global::System.Text.Encoding.UTF7);
#pragma warning restore SYSLIB0001
		}
		private static TEncoding GetUTF8() => new TEncoding(new global::System.Text.UTF8Encoding(false));

		protected virtual int GetCodePage() => FEncoding.CodePage;
		protected virtual string GetEncodingName() => FEncoding.EncodingName;
		protected virtual bool GetIsSingleByte() => FEncoding.IsSingleByte;
		protected virtual string GetMIMEName() => FEncoding.WebName;

		public static byte[] Convert(TEncoding Source, TEncoding Destination, byte[] Bytes)
		{
			if (Source == null) throw new EArgumentNilException("Source");
			if (Destination == null) throw new EArgumentNilException("Destination");
			Bytes ??= Array.Empty<byte>();
			return global::System.Text.Encoding.Convert(Source.FEncoding, Destination.FEncoding, Bytes);
		}

		public static byte[] Convert(TEncoding Source, TEncoding Destination, byte[] Bytes, int StartIndex, int Count)
		{
			if (Source == null) throw new EArgumentNilException("Source");
			if (Destination == null) throw new EArgumentNilException("Destination");
			Bytes ??= Array.Empty<byte>();
			return global::System.Text.Encoding.Convert(Source.FEncoding, Destination.FEncoding, Bytes, StartIndex, Count);
		}

		public static void FreeEncodings() { }

		public static int GetBufferEncoding(byte[] Buffer, ref TEncoding AEncoding) =>
			GetBufferEncoding(Buffer, ref AEncoding, Default);

		public static int GetBufferEncoding(byte[] Buffer, ref TEncoding AEncoding, TEncoding ADefaultEncoding)
		{
			Buffer ??= Array.Empty<byte>();
			if (Buffer.Length >= 3 && Buffer[0] == 0xEF && Buffer[1] == 0xBB && Buffer[2] == 0xBF)
			{
				AEncoding = UTF8; return 3;
			}
			if (Buffer.Length >= 2 && Buffer[0] == 0xFF && Buffer[1] == 0xFE)
			{
				AEncoding = Unicode; return 2;
			}
			if (Buffer.Length >= 2 && Buffer[0] == 0xFE && Buffer[1] == 0xFF)
			{
				AEncoding = BigEndianUnicode; return 2;
			}
			AEncoding = ADefaultEncoding ?? Default;
			return 0;
		}

		public static TEncoding GetEncoding(int CodePage)
		{
			try { return new TEncoding(global::System.Text.Encoding.GetEncoding(CodePage)); }
			catch (global::System.Exception ex) { throw new EEncodingError(ex.Message); }
		}

		public static TEncoding GetEncoding(string EncodingName)
		{
			try { return new TEncoding(global::System.Text.Encoding.GetEncoding(EncodingName)); }
			catch (global::System.Exception ex) { throw new EEncodingError(ex.Message); }
		}

		public virtual TEncoding Clone() =>
			new TEncoding((global::System.Text.Encoding)FEncoding.Clone());

		public virtual int GetByteCount(char[] Chars) => FEncoding.GetByteCount(Chars ?? Array.Empty<char>());
		public virtual int GetByteCount(char[] Chars, int CharIndex, int CharCount) =>
			FEncoding.GetByteCount(Chars ?? Array.Empty<char>(), CharIndex, CharCount);
		public virtual int GetByteCount(string S) => FEncoding.GetByteCount(S ?? string.Empty);
		public virtual byte[] GetBytes(char[] Chars) => FEncoding.GetBytes(Chars ?? Array.Empty<char>());
		public virtual byte[] GetBytes(char[] Chars, int CharIndex, int CharCount) =>
			FEncoding.GetBytes(Chars ?? Array.Empty<char>(), CharIndex, CharCount);
		public virtual byte[] GetBytes(string S) => FEncoding.GetBytes(S ?? string.Empty);
		public virtual int GetCharCount(byte[] Bytes) => FEncoding.GetCharCount(Bytes ?? Array.Empty<byte>());
		public virtual int GetCharCount(byte[] Bytes, int ByteIndex, int ByteCount) =>
			FEncoding.GetCharCount(Bytes ?? Array.Empty<byte>(), ByteIndex, ByteCount);
		public virtual char[] GetChars(byte[] Bytes) => FEncoding.GetChars(Bytes ?? Array.Empty<byte>());
		public virtual char[] GetChars(byte[] Bytes, int ByteIndex, int ByteCount) =>
			FEncoding.GetChars(Bytes ?? Array.Empty<byte>(), ByteIndex, ByteCount);
		public virtual int GetMaxByteCount(int CharCount) => FEncoding.GetMaxByteCount(CharCount);
		public virtual int GetMaxCharCount(int ByteCount) => FEncoding.GetMaxCharCount(ByteCount);
		public virtual byte[] GetPreamble() => FEncoding.GetPreamble();
		public virtual string GetString(byte[] Bytes) => FEncoding.GetString(Bytes ?? Array.Empty<byte>());
		public virtual string GetString(byte[] Bytes, int ByteIndex, int ByteCount) =>
			FEncoding.GetString(Bytes ?? Array.Empty<byte>(), ByteIndex, ByteCount);

		public virtual bool IsBufferValid(byte[] Buffer)
		{
			try
			{
				global::System.Text.Encoding clone = (global::System.Text.Encoding)FEncoding.Clone();
				clone.DecoderFallback = DecoderFallback.ExceptionFallback;
				clone.GetString(Buffer ?? Array.Empty<byte>());
				return true;
			}
			catch { return false; }
		}

		public bool IsStandardEncoding()
		{
			int cp = CodePage;
			return cp == global::System.Text.Encoding.ASCII.CodePage ||
				   cp == global::System.Text.Encoding.Unicode.CodePage ||
				   cp == global::System.Text.Encoding.BigEndianUnicode.CodePage ||
				   cp == global::System.Text.Encoding.UTF8.CodePage;
		}

		public int CodePage => GetCodePage();
		public string EncodingName => GetEncodingName();
		public bool IsSingleByte => GetIsSingleByte();
		public string MIMEName => GetMIMEName();
		public static TEncoding ANSI => GetANSI();
		public static TEncoding ASCII => GetASCII();
		public static TEncoding BigEndianUnicode => GetBigEndianUnicode();
		public static TEncoding Default => GetDefault();
		public static TEncoding Unicode => GetUnicode();
		public static TEncoding UTF7 => GetUTF7();
		public static TEncoding UTF8 => GetUTF8();
	}	

	public class TMBCSEncoding : TEncoding { public TMBCSEncoding() : base(global::System.Text.Encoding.Default) {} }	

	public class TUnicodeEncoding : TEncoding { public TUnicodeEncoding() : base(global::System.Text.Encoding.Unicode) {} }	

	public class TBigEndianUnicodeEncoding : TUnicodeEncoding { public TBigEndianUnicodeEncoding() : base() { FEncoding = global::System.Text.Encoding.BigEndianUnicode; } }	

	public class TUTF7Encoding : TEncoding { public TUTF7Encoding() : base(global::System.Text.Encoding.GetEncoding(65000)) {} }	

	public class TUTF8Encoding : TEncoding { public TUTF8Encoding() : base(new global::System.Text.UTF8Encoding(false)) {} }	

	public class TStringBuilder : TObject
	{
		private global::System.Text.StringBuilder FBuilder;
		private int FMaxCapacity;

		private int GetCapacity() => FBuilder.Capacity;
		private void SetCapacity(int Value) => FBuilder.Capacity = Value;
		private char GetChars(int Index) => FBuilder[Index];
		private void SetChars(int Index, char Value) => FBuilder[Index] = Value;
		private int GetLength() => FBuilder.Length;
		private void SetLength(int Value) => FBuilder.Length = Value;
		private int GetMaxCapacity() => FMaxCapacity;

		public TStringBuilder()
		{
			FMaxCapacity = int.MaxValue;
			FBuilder = new global::System.Text.StringBuilder();
		}
		public TStringBuilder(int ACapacity)
		{
			FMaxCapacity = int.MaxValue;
			FBuilder = new global::System.Text.StringBuilder(ACapacity);
		}
		public TStringBuilder(string Value)
		{
			FMaxCapacity = int.MaxValue;
			FBuilder = new global::System.Text.StringBuilder(Value ?? string.Empty);
		}
		public TStringBuilder(int ACapacity, int AMaxCapacity)
		{
			FMaxCapacity = AMaxCapacity;
			FBuilder = new global::System.Text.StringBuilder(ACapacity, AMaxCapacity);
		}
		public TStringBuilder(string Value, int ACapacity)
		{
			FMaxCapacity = int.MaxValue;
			FBuilder = new global::System.Text.StringBuilder(Value ?? string.Empty, ACapacity);
		}
		public TStringBuilder(string Value, int StartIndex, int ALength, int ACapacity)
		{
			FMaxCapacity = int.MaxValue;
			FBuilder = new global::System.Text.StringBuilder(Value ?? string.Empty, StartIndex, ALength, ACapacity);
		}

		private TStringBuilder Add(object Value) { FBuilder.Append(Value); return this; }
		public TStringBuilder Append(bool Value) => Add(Value);
		public TStringBuilder Append(byte Value) => Add(Value);
		public TStringBuilder Append(char Value) => Add(Value);
		public TStringBuilder Append(Currency Value) => Add(Value.ToDecimal());
		public TStringBuilder Append(double Value) => Add(Value);
		public TStringBuilder Append(short Value) => Add(Value);
		public TStringBuilder Append(int Value) => Add(Value);
		public TStringBuilder Append(long Value) => Add(Value);
		public TStringBuilder Append(TObject Value) => Add(Value);
		public TStringBuilder Append(sbyte Value) => Add(Value);
		public TStringBuilder Append(float Value) => Add(Value);
		public TStringBuilder Append(string Value) { FBuilder.Append(Value); return this; }
		public TStringBuilder Append(ulong Value) => Add(Value);
		public TStringBuilder Append(char Value, int RepeatCount) { FBuilder.Append(Value, RepeatCount); return this; }
		public TStringBuilder Append(char[] Value, int StartIndex, int CharCount)
		{
			FBuilder.Append(Value, StartIndex, CharCount); return this;
		}
		public TStringBuilder Append(string Value, int StartIndex, int Count = -1)
		{
			Value ??= string.Empty;
			if (Count < 0) Count = Value.Length - StartIndex;
			FBuilder.Append(Value, StartIndex, Count); return this;
		}
		public TStringBuilder AppendFormat(string AFormat, params TVarRec[] Args)
		{
			FBuilder.Append(SysutilsInterface.Format(AFormat, Args)); return this;
		}
		public TStringBuilder AppendLine() { FBuilder.AppendLine(); return this; }
		public TStringBuilder AppendLine(string Value) { FBuilder.AppendLine(Value); return this; }
		public void Clear() => FBuilder.Clear();
		public void CopyTo(int SourceIndex, ref char[] Destination, int DestinationIndex, int Count)
		{
			if (Destination == null) Destination = new char[DestinationIndex + Count];
			if (Destination.Length < DestinationIndex + Count)
				Array.Resize(ref Destination, DestinationIndex + Count);
			FBuilder.CopyTo(SourceIndex, Destination, DestinationIndex, Count);
		}
		public int EnsureCapacity(int Capacity) => FBuilder.EnsureCapacity(Capacity);
		public bool Equals(TStringBuilder Value) => Value != null && FBuilder.ToString() == Value.FBuilder.ToString();

		private TStringBuilder Ins(int Index, object Value) { FBuilder.Insert(Index, Value); return this; }
		public TStringBuilder Insert(int Index, bool Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, byte Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, char Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, Currency Value) => Ins(Index, Value.ToDecimal());
		public TStringBuilder Insert(int Index, double Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, short Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, int Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, long Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, TObject Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, sbyte Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, float Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, string Value) { FBuilder.Insert(Index, Value); return this; }
		public TStringBuilder Insert(int Index, ulong Value) => Ins(Index, Value);
		public TStringBuilder Insert(int Index, char[] Value) { FBuilder.Insert(Index, Value); return this; }
		public TStringBuilder Remove(int StartIndex, int RemLength) { FBuilder.Remove(StartIndex, RemLength); return this; }
		public TStringBuilder Replace(char OldChar, char NewChar) { FBuilder.Replace(OldChar, NewChar); return this; }
		public TStringBuilder Replace(string OldValue, string NewValue) { FBuilder.Replace(OldValue, NewValue); return this; }
		public TStringBuilder Replace(char OldChar, char NewChar, int StartIndex, int Count)
		{
			FBuilder.Replace(OldChar, NewChar, StartIndex, Count); return this;
		}
		public TStringBuilder Replace(string OldValue, string NewValue, int StartIndex, int Count)
		{
			FBuilder.Replace(OldValue, NewValue, StartIndex, Count); return this;
		}
		public override string ToString() => FBuilder.ToString();
		public string ToString(bool UpdateCapacity)
		{
			string value = FBuilder.ToString();
			if (UpdateCapacity) FBuilder.Capacity = FBuilder.Length;
			return value;
		}
		public string ToString(int StartIndex, int StrLength) => FBuilder.ToString(StartIndex, StrLength);
		public int Capacity { get => GetCapacity(); set => SetCapacity(value); }
		public char ReadPropertyChars(int Index) => GetChars(Index);
		public void WritePropertyChars(int Index, char Value) => SetChars(Index, Value);
		public char this[int Index] { get => GetChars(Index); set => SetChars(Index, value); }
		public int Length { get => GetLength(); set => SetLength(value); }
		public int MaxCapacity => GetMaxCapacity();
	}	

	public struct TFormatSettings
	{
		public struct TEraInfo
		{
			public string EraName;
			public int EraOffset;
			public TDateTime EraStart;
			public TDateTime EraEnd;
			public void CreateRecordMembers()
			{
				EraName = string.Empty;
				EraStart = new TDateTime();
				EraEnd = new TDateTime();
			}
			public static TEraInfo CreateRecord()
			{
				TEraInfo tmp = new TEraInfo();
				tmp.CreateRecordMembers();
				return tmp;
			}
		}		
		public byte CurrencyFormat;
		public byte NegCurrFormat;
		public char ThousandSeparator;
		public char DecimalSeparator;
		public byte CurrencyDecimals;
		public char DateSeparator;
		public char TimeSeparator;
		public char ListSeparator;
		public string CurrencyString;
		public string ShortDateFormat;
		public string LongDateFormat;
		public string TimeAMString;
		public string TimePMString;
		public string ShortTimeFormat;
		public string LongTimeFormat;
		public string[] ShortMonthNames;
		public string[] LongMonthNames;
		public string[] ShortDayNames;
		public string[] LongDayNames;
		public TEraInfo[] EraInfo;
		public ushort TwoDigitYearCenturyWindow;
		public string NormalizedLocaleName;
		public static TFormatSettings Create()
		{
			return Create(CultureInfo.CurrentCulture.Name);
		}
		public static TFormatSettings Create(uint Locale)
		{
			try { return Create(CultureInfo.GetCultureInfo((int)Locale).Name); } catch { return Create(); }
		}
		public static TFormatSettings Create(string LocaleName)
		{
			CultureInfo c;
			try { c = string.IsNullOrEmpty(LocaleName) ? CultureInfo.CurrentCulture : CultureInfo.GetCultureInfo(LocaleName); }
			catch { c = CultureInfo.CurrentCulture; }
			TFormatSettings r = CreateRecord();
			NumberFormatInfo n = c.NumberFormat;
			DateTimeFormatInfo d = c.DateTimeFormat;
			r.CurrencyFormat = (byte)global::System.Math.Max(0, n.CurrencyPositivePattern);
			r.NegCurrFormat = (byte)global::System.Math.Max(0, n.CurrencyNegativePattern);
			r.ThousandSeparator = string.IsNullOrEmpty(n.NumberGroupSeparator) ? ',' : n.NumberGroupSeparator[0];
			r.DecimalSeparator = string.IsNullOrEmpty(n.NumberDecimalSeparator) ? '.' : n.NumberDecimalSeparator[0];
			r.CurrencyDecimals = (byte)n.CurrencyDecimalDigits;
			r.DateSeparator = string.IsNullOrEmpty(d.DateSeparator) ? '/' : d.DateSeparator[0];
			r.TimeSeparator = string.IsNullOrEmpty(d.TimeSeparator) ? ':' : d.TimeSeparator[0];
			r.ListSeparator = string.IsNullOrEmpty(c.TextInfo.ListSeparator) ? ',' : c.TextInfo.ListSeparator[0];
			r.CurrencyString = n.CurrencySymbol;
			r.ShortDateFormat = d.ShortDatePattern;
			r.LongDateFormat = d.LongDatePattern;
			r.TimeAMString = d.AMDesignator;
			r.TimePMString = d.PMDesignator;
			r.ShortTimeFormat = d.ShortTimePattern;
			r.LongTimeFormat = d.LongTimePattern;
			r.ShortMonthNames = new string[12];
			r.LongMonthNames = new string[12];
			for (int i=0;i<12;i++) { r.ShortMonthNames[i]=d.AbbreviatedMonthNames[i] ?? string.Empty; r.LongMonthNames[i]=d.MonthNames[i] ?? string.Empty; }
			r.ShortDayNames = new string[7];
			r.LongDayNames = new string[7];
			for (int i=0;i<7;i++) { int di=(i+1)%7; r.ShortDayNames[i]=d.AbbreviatedDayNames[di] ?? string.Empty; r.LongDayNames[i]=d.DayNames[di] ?? string.Empty; }
			r.EraInfo = Array.Empty<TEraInfo>();
			r.TwoDigitYearCenturyWindow = 50;
			r.NormalizedLocaleName = c.Name;
			return r;
		}
		public static TFormatSettings Invariant()
		{
			return Create(CultureInfo.InvariantCulture.Name);
		}
		public int GetEraYearOffset(string Name)
		{
			if (EraInfo != null)
				for(int i=0;i<EraInfo.Length;i++)
					if (string.Equals(EraInfo[i].EraName, Name, StringComparison.OrdinalIgnoreCase))
						return EraInfo[i].EraOffset;
			return 0;
		}
		public void CreateRecordMembers()
		{
			CurrencyString = string.Empty;
			ShortDateFormat = string.Empty;
			LongDateFormat = string.Empty;
			TimeAMString = string.Empty;
			TimePMString = string.Empty;
			ShortTimeFormat = string.Empty;
			LongTimeFormat = string.Empty;
			ShortMonthNames = new string[12/*# range 1..12*/];
			LongMonthNames = new string[12/*# range 1..12*/];
			ShortDayNames = new string[7/*# range 1..7*/];
			LongDayNames = new string[7/*# range 1..7*/];
			NormalizedLocaleName = string.Empty;
		}
		public static TFormatSettings CreateRecord()
		{
			TFormatSettings tmp = new TFormatSettings();
			tmp.CreateRecordMembers();
			return tmp;
		}
	}	

	public struct TSearchRec
	{
		private TDateTime GetCreationTime()
		{
			return FromFileTime(FindData.ftCreationTime);
		}
		private TDateTime GetLastAccessTime()
		{
			return FromFileTime(FindData.ftLastAccessTime);
		}
		private TDateTime GetTimeStamp()
		{
			return FromFileTime(FindData.ftLastWriteTime);
		}
		public int Time;
		public long Size;
		public int Attr;
		public string Name;
		public int ExcludeAttr;
		public uint FindHandle;
		public TWin32FindData FindData;
		/*property CreationTime : TDateTime read GetCreationTime;*/
		public TDateTime CreationTime
		{
			get
			{
				return GetCreationTime();
			}
		}
		/*property LastAccessTime : TDateTime read GetLastAccessTime;*/
		public TDateTime LastAccessTime
		{
			get
			{
				return GetLastAccessTime();
			}
		}
		/*property TimeStamp : TDateTime read GetTimeStamp;*/
		public TDateTime TimeStamp
		{
			get
			{
				return GetTimeStamp();
			}
		}
		public void CreateRecordMembers()
		{
			Name = string.Empty;
			FindData = TWin32FindData.CreateRecord();
		}
		public static TSearchRec CreateRecord()
		{
			TSearchRec tmp = new TSearchRec();
			tmp.CreateRecordMembers();
			return tmp;
		}
	}	

	public struct TSymLinkRec
	{
		private TDateTime GetTimeStamp()
		{
			return FromFileTime(FindData.ftLastWriteTime);
		}
		public string TargetName;
		public int Attr;
		public long Size;
		public TWin32FindData FindData;
		/*property TimeStamp : TDateTime read GetTimeStamp;*/
		public TDateTime TimeStamp
		{
			get
			{
				return GetTimeStamp();
			}
		}
		public void CreateRecordMembers()
		{
			TargetName = string.Empty;
			FindData = TWin32FindData.CreateRecord();
		}
		public static TSymLinkRec CreateRecord()
		{
			TSymLinkRec tmp = new TSymLinkRec();
			tmp.CreateRecordMembers();
			return tmp;
		}
	}	

	public struct TDateTimeInfoRec
	{
		internal TWin32FindData Data;
		private TDateTime GetCreationTime()
		{
			return FromFileTime(Data.ftCreationTime);
		}
		private TDateTime GetLastAccessTime()
		{
			return FromFileTime(Data.ftLastAccessTime);
		}
		private TDateTime GetTimeStamp()
		{
			return FromFileTime(Data.ftLastWriteTime);
		}
		/*property CreationTime : TDateTime read GetCreationTime;*/
		public TDateTime CreationTime
		{
			get
			{
				return GetCreationTime();
			}
		}
		/*property LastAccessTime : TDateTime read GetLastAccessTime;*/
		public TDateTime LastAccessTime
		{
			get
			{
				return GetLastAccessTime();
			}
		}
		/*property TimeStamp : TDateTime read GetTimeStamp;*/
		public TDateTime TimeStamp
		{
			get
			{
				return GetTimeStamp();
			}
		}
		public void CreateRecordMembers()
		{
			Data = TWin32FindData.CreateRecord();
		}
		public static TDateTimeInfoRec CreateRecord()
		{
			TDateTimeInfoRec tmp = new TDateTimeInfoRec();
			tmp.CreateRecordMembers();
			return tmp;
		}
	}	

	public struct TTimeStamp
	{
		public int Time;
		public int Date;
		public static TTimeStamp CreateRecord(){return new TTimeStamp();}
	}	

	public struct TSysLocale
	{
		public uint DefaultLCID;
		public int PriLangID;
		public int SubLangID;
		public bool FarEast;
		public bool MiddleEast;
		public static TSysLocale CreateRecord(){return new TSysLocale();}
	}	

  /*
    Delphi exception declarations used as translation metadata.

    D2CSharp/Delphi2C# maps System.SysUtils.Exception to DException in C#.
    The Pascal declarations retain the Delphi names and inheritance hierarchy.
    The C# runtime implementation provides the .NET-specific DException base.
  */

	public class DException : global::System.Exception
	{
		public int HelpContext { get; protected set; }

		public DException(string Msg) : base(Msg ?? string.Empty) {}
		public DException(string Msg, params TVarRec[] Args) : base(SysutilsInterface.Format(Msg ?? string.Empty, Args)) {}
		public DException(uint Ident) : base(SysutilsInterface.LoadStr(Ident)) {}
		public DException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec.IsNull() ? string.Empty : ResStringRec.Deref().FMessage) {}
		public DException(uint Ident, params TVarRec[] Args) : base(SysutilsInterface.FmtLoadStr(Ident, Args)) {}
		public DException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(SysutilsInterface.Format(ResStringRec.IsNull() ? string.Empty : ResStringRec.Deref().FMessage, Args)) {}
		public DException(string Msg, int AHelpContext) : base(Msg ?? string.Empty) { HelpContext = AHelpContext; }
		public DException(string Msg, TVarRec[] Args, int AHelpContext) : base(SysutilsInterface.Format(Msg ?? string.Empty, Args)) { HelpContext = AHelpContext; }
		public DException(uint Ident, int AHelpContext) : base(SysutilsInterface.LoadStr(Ident)) { HelpContext = AHelpContext; }
		public DException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec.IsNull() ? string.Empty : ResStringRec.Deref().FMessage) { HelpContext = AHelpContext; }
		public DException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(SysutilsInterface.Format(ResStringRec.IsNull() ? string.Empty : ResStringRec.Deref().FMessage, Args)) { HelpContext = AHelpContext; }
		public DException(uint Ident, TVarRec[] Args, int AHelpContext) : base(SysutilsInterface.FmtLoadStr(Ident, Args)) { HelpContext = AHelpContext; }
	}	

	public class EArgumentException : DException
	{


		public EArgumentException(string Msg) : base(Msg) {}
		public EArgumentException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EArgumentException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EArgumentException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EArgumentException(uint Ident) : base(Ident) {}
		public EArgumentException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EArgumentException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EArgumentException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EArgumentException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EArgumentException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EArgumentException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EArgumentException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EArgumentOutOfRangeException : EArgumentException
	{


		public EArgumentOutOfRangeException(string Msg) : base(Msg) {}
		public EArgumentOutOfRangeException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EArgumentOutOfRangeException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EArgumentOutOfRangeException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EArgumentOutOfRangeException(uint Ident) : base(Ident) {}
		public EArgumentOutOfRangeException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EArgumentOutOfRangeException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EArgumentOutOfRangeException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EArgumentOutOfRangeException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EArgumentOutOfRangeException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EArgumentOutOfRangeException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EArgumentOutOfRangeException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EArgumentNilException : EArgumentException
	{


		public EArgumentNilException(string Msg) : base(Msg) {}
		public EArgumentNilException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EArgumentNilException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EArgumentNilException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EArgumentNilException(uint Ident) : base(Ident) {}
		public EArgumentNilException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EArgumentNilException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EArgumentNilException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EArgumentNilException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EArgumentNilException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EArgumentNilException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EArgumentNilException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EPathTooLongException : DException
	{


		public EPathTooLongException(string Msg) : base(Msg) {}
		public EPathTooLongException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EPathTooLongException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EPathTooLongException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EPathTooLongException(uint Ident) : base(Ident) {}
		public EPathTooLongException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EPathTooLongException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EPathTooLongException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EPathTooLongException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EPathTooLongException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EPathTooLongException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EPathTooLongException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class ENotSupportedException : DException
	{


		public ENotSupportedException(string Msg) : base(Msg) {}
		public ENotSupportedException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public ENotSupportedException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public ENotSupportedException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public ENotSupportedException(uint Ident) : base(Ident) {}
		public ENotSupportedException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public ENotSupportedException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public ENotSupportedException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public ENotSupportedException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public ENotSupportedException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public ENotSupportedException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public ENotSupportedException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EDirectoryNotFoundException : DException
	{


		public EDirectoryNotFoundException(string Msg) : base(Msg) {}
		public EDirectoryNotFoundException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EDirectoryNotFoundException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EDirectoryNotFoundException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EDirectoryNotFoundException(uint Ident) : base(Ident) {}
		public EDirectoryNotFoundException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EDirectoryNotFoundException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EDirectoryNotFoundException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EDirectoryNotFoundException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EDirectoryNotFoundException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EDirectoryNotFoundException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EDirectoryNotFoundException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EFileNotFoundException : DException
	{


		public EFileNotFoundException(string Msg) : base(Msg) {}
		public EFileNotFoundException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EFileNotFoundException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EFileNotFoundException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EFileNotFoundException(uint Ident) : base(Ident) {}
		public EFileNotFoundException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EFileNotFoundException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EFileNotFoundException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EFileNotFoundException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EFileNotFoundException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EFileNotFoundException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EFileNotFoundException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EPathNotFoundException : DException
	{


		public EPathNotFoundException(string Msg) : base(Msg) {}
		public EPathNotFoundException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EPathNotFoundException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EPathNotFoundException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EPathNotFoundException(uint Ident) : base(Ident) {}
		public EPathNotFoundException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EPathNotFoundException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EPathNotFoundException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EPathNotFoundException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EPathNotFoundException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EPathNotFoundException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EPathNotFoundException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EInvalidOpException : DException
	{


		public EInvalidOpException(string Msg) : base(Msg) {}
		public EInvalidOpException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EInvalidOpException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EInvalidOpException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EInvalidOpException(uint Ident) : base(Ident) {}
		public EInvalidOpException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EInvalidOpException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EInvalidOpException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EInvalidOpException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EInvalidOpException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EInvalidOpException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EInvalidOpException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class ENoConstructException : DException
	{


		public ENoConstructException(string Msg) : base(Msg) {}
		public ENoConstructException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public ENoConstructException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public ENoConstructException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public ENoConstructException(uint Ident) : base(Ident) {}
		public ENoConstructException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public ENoConstructException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public ENoConstructException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public ENoConstructException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public ENoConstructException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public ENoConstructException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public ENoConstructException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EAbort : DException
	{


		public EAbort(string Msg) : base(Msg) {}
		public EAbort(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EAbort(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EAbort(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EAbort(uint Ident) : base(Ident) {}
		public EAbort(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EAbort(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EAbort(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EAbort(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EAbort(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EAbort(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EAbort(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EAbstractError : DException
	{


		public EAbstractError(string Msg) : base(Msg) {}
		public EAbstractError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EAbstractError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EAbstractError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EAbstractError(uint Ident) : base(Ident) {}
		public EAbstractError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EAbstractError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EAbstractError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EAbstractError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EAbstractError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EAbstractError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EAbstractError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EAssertionFailed : DException
	{


		public EAssertionFailed(string Msg) : base(Msg) {}
		public EAssertionFailed(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EAssertionFailed(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EAssertionFailed(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EAssertionFailed(uint Ident) : base(Ident) {}
		public EAssertionFailed(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EAssertionFailed(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EAssertionFailed(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EAssertionFailed(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EAssertionFailed(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EAssertionFailed(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EAssertionFailed(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class ECFError : DException
	{


		public ECFError(string Msg) : base(Msg) {}
		public ECFError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public ECFError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public ECFError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public ECFError(uint Ident) : base(Ident) {}
		public ECFError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public ECFError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public ECFError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public ECFError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public ECFError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public ECFError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public ECFError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EConvertError : DException
	{


		public EConvertError(string Msg) : base(Msg) {}
		public EConvertError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EConvertError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EConvertError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EConvertError(uint Ident) : base(Ident) {}
		public EConvertError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EConvertError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EConvertError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EConvertError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EConvertError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EConvertError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EConvertError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EEncodingError : DException
	{


		public EEncodingError(string Msg) : base(Msg) {}
		public EEncodingError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EEncodingError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EEncodingError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EEncodingError(uint Ident) : base(Ident) {}
		public EEncodingError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EEncodingError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EEncodingError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EEncodingError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EEncodingError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EEncodingError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EEncodingError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EIntfCastError : DException
	{


		public EIntfCastError(string Msg) : base(Msg) {}
		public EIntfCastError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EIntfCastError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EIntfCastError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EIntfCastError(uint Ident) : base(Ident) {}
		public EIntfCastError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EIntfCastError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EIntfCastError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EIntfCastError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EIntfCastError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EIntfCastError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EIntfCastError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EInvalidCast : DException
	{


		public EInvalidCast(string Msg) : base(Msg) {}
		public EInvalidCast(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EInvalidCast(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EInvalidCast(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EInvalidCast(uint Ident) : base(Ident) {}
		public EInvalidCast(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EInvalidCast(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EInvalidCast(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EInvalidCast(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EInvalidCast(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EInvalidCast(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EInvalidCast(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EInvalidContainer : DException
	{


		public EInvalidContainer(string Msg) : base(Msg) {}
		public EInvalidContainer(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EInvalidContainer(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EInvalidContainer(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EInvalidContainer(uint Ident) : base(Ident) {}
		public EInvalidContainer(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EInvalidContainer(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EInvalidContainer(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EInvalidContainer(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EInvalidContainer(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EInvalidContainer(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EInvalidContainer(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EInvalidInsert : DException
	{


		public EInvalidInsert(string Msg) : base(Msg) {}
		public EInvalidInsert(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EInvalidInsert(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EInvalidInsert(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EInvalidInsert(uint Ident) : base(Ident) {}
		public EInvalidInsert(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EInvalidInsert(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EInvalidInsert(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EInvalidInsert(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EInvalidInsert(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EInvalidInsert(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EInvalidInsert(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class ENotImplemented : DException
	{


		public ENotImplemented(string Msg) : base(Msg) {}
		public ENotImplemented(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public ENotImplemented(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public ENotImplemented(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public ENotImplemented(uint Ident) : base(Ident) {}
		public ENotImplemented(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public ENotImplemented(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public ENotImplemented(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public ENotImplemented(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public ENotImplemented(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public ENotImplemented(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public ENotImplemented(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EObjectDisposed : DException
	{


		public EObjectDisposed(string Msg) : base(Msg) {}
		public EObjectDisposed(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EObjectDisposed(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EObjectDisposed(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EObjectDisposed(uint Ident) : base(Ident) {}
		public EObjectDisposed(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EObjectDisposed(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EObjectDisposed(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EObjectDisposed(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EObjectDisposed(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EObjectDisposed(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EObjectDisposed(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EOperationCancelled : DException
	{


		public EOperationCancelled(string Msg) : base(Msg) {}
		public EOperationCancelled(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EOperationCancelled(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EOperationCancelled(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EOperationCancelled(uint Ident) : base(Ident) {}
		public EOperationCancelled(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EOperationCancelled(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EOperationCancelled(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EOperationCancelled(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EOperationCancelled(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EOperationCancelled(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EOperationCancelled(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EPackageError : DException
	{


		public EPackageError(string Msg) : base(Msg) {}
		public EPackageError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EPackageError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EPackageError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EPackageError(uint Ident) : base(Ident) {}
		public EPackageError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EPackageError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EPackageError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EPackageError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EPackageError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EPackageError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EPackageError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EProgrammerNotFound : DException
	{


		public EProgrammerNotFound(string Msg) : base(Msg) {}
		public EProgrammerNotFound(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EProgrammerNotFound(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EProgrammerNotFound(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EProgrammerNotFound(uint Ident) : base(Ident) {}
		public EProgrammerNotFound(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EProgrammerNotFound(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EProgrammerNotFound(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EProgrammerNotFound(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EProgrammerNotFound(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EProgrammerNotFound(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EProgrammerNotFound(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EPropReadOnly : DException
	{


		public EPropReadOnly(string Msg) : base(Msg) {}
		public EPropReadOnly(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EPropReadOnly(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EPropReadOnly(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EPropReadOnly(uint Ident) : base(Ident) {}
		public EPropReadOnly(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EPropReadOnly(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EPropReadOnly(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EPropReadOnly(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EPropReadOnly(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EPropReadOnly(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EPropReadOnly(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EPropWriteOnly : DException
	{


		public EPropWriteOnly(string Msg) : base(Msg) {}
		public EPropWriteOnly(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EPropWriteOnly(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EPropWriteOnly(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EPropWriteOnly(uint Ident) : base(Ident) {}
		public EPropWriteOnly(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EPropWriteOnly(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EPropWriteOnly(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EPropWriteOnly(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EPropWriteOnly(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EPropWriteOnly(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EPropWriteOnly(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class ESafecallException : DException
	{


		public ESafecallException(string Msg) : base(Msg) {}
		public ESafecallException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public ESafecallException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public ESafecallException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public ESafecallException(uint Ident) : base(Ident) {}
		public ESafecallException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public ESafecallException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public ESafecallException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public ESafecallException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public ESafecallException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public ESafecallException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public ESafecallException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EVariantError : DException
	{


		public EVariantError(string Msg) : base(Msg) {}
		public EVariantError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EVariantError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EVariantError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EVariantError(uint Ident) : base(Ident) {}
		public EVariantError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EVariantError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EVariantError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EVariantError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EVariantError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EVariantError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EVariantError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EHeapException : DException
	{


		public EHeapException(string Msg) : base(Msg) {}
		public EHeapException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EHeapException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EHeapException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EHeapException(uint Ident) : base(Ident) {}
		public EHeapException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EHeapException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EHeapException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EHeapException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EHeapException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EHeapException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EHeapException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EOutOfMemory : EHeapException
	{


		public EOutOfMemory(string Msg) : base(Msg) {}
		public EOutOfMemory(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EOutOfMemory(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EOutOfMemory(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EOutOfMemory(uint Ident) : base(Ident) {}
		public EOutOfMemory(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EOutOfMemory(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EOutOfMemory(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EOutOfMemory(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EOutOfMemory(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EOutOfMemory(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EOutOfMemory(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EInvalidPointer : EHeapException
	{


		public EInvalidPointer(string Msg) : base(Msg) {}
		public EInvalidPointer(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EInvalidPointer(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EInvalidPointer(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EInvalidPointer(uint Ident) : base(Ident) {}
		public EInvalidPointer(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EInvalidPointer(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EInvalidPointer(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EInvalidPointer(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EInvalidPointer(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EInvalidPointer(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EInvalidPointer(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EInOutError : DException
	{


		public EInOutError(string Msg) : base(Msg) {}
		public EInOutError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EInOutError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EInOutError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EInOutError(uint Ident) : base(Ident) {}
		public EInOutError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EInOutError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EInOutError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EInOutError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EInOutError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EInOutError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EInOutError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EExternal : DException
	{


		public EExternal(string Msg) : base(Msg) {}
		public EExternal(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EExternal(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EExternal(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EExternal(uint Ident) : base(Ident) {}
		public EExternal(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EExternal(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EExternal(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EExternal(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EExternal(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EExternal(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EExternal(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EExternalException : EExternal
	{


		public EExternalException(string Msg) : base(Msg) {}
		public EExternalException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EExternalException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EExternalException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EExternalException(uint Ident) : base(Ident) {}
		public EExternalException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EExternalException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EExternalException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EExternalException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EExternalException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EExternalException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EExternalException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EAccessViolation : EExternal
	{


		public EAccessViolation(string Msg) : base(Msg) {}
		public EAccessViolation(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EAccessViolation(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EAccessViolation(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EAccessViolation(uint Ident) : base(Ident) {}
		public EAccessViolation(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EAccessViolation(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EAccessViolation(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EAccessViolation(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EAccessViolation(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EAccessViolation(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EAccessViolation(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EControlC : EExternal
	{


		public EControlC(string Msg) : base(Msg) {}
		public EControlC(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EControlC(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EControlC(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EControlC(uint Ident) : base(Ident) {}
		public EControlC(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EControlC(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EControlC(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EControlC(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EControlC(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EControlC(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EControlC(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EPrivilege : EExternal
	{


		public EPrivilege(string Msg) : base(Msg) {}
		public EPrivilege(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EPrivilege(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EPrivilege(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EPrivilege(uint Ident) : base(Ident) {}
		public EPrivilege(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EPrivilege(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EPrivilege(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EPrivilege(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EPrivilege(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EPrivilege(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EPrivilege(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EStackOverflow : EExternal
	{


		public EStackOverflow(string Msg) : base(Msg) {}
		public EStackOverflow(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EStackOverflow(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EStackOverflow(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EStackOverflow(uint Ident) : base(Ident) {}
		public EStackOverflow(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EStackOverflow(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EStackOverflow(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EStackOverflow(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EStackOverflow(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EStackOverflow(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EStackOverflow(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EIntError : EExternal
	{


		public EIntError(string Msg) : base(Msg) {}
		public EIntError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EIntError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EIntError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EIntError(uint Ident) : base(Ident) {}
		public EIntError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EIntError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EIntError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EIntError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EIntError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EIntError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EIntError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EDivByZero : EIntError
	{


		public EDivByZero(string Msg) : base(Msg) {}
		public EDivByZero(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EDivByZero(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EDivByZero(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EDivByZero(uint Ident) : base(Ident) {}
		public EDivByZero(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EDivByZero(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EDivByZero(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EDivByZero(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EDivByZero(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EDivByZero(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EDivByZero(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class ERangeError : EIntError
	{


		public ERangeError(string Msg) : base(Msg) {}
		public ERangeError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public ERangeError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public ERangeError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public ERangeError(uint Ident) : base(Ident) {}
		public ERangeError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public ERangeError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public ERangeError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public ERangeError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public ERangeError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public ERangeError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public ERangeError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EIntOverflow : EIntError
	{


		public EIntOverflow(string Msg) : base(Msg) {}
		public EIntOverflow(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EIntOverflow(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EIntOverflow(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EIntOverflow(uint Ident) : base(Ident) {}
		public EIntOverflow(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EIntOverflow(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EIntOverflow(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EIntOverflow(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EIntOverflow(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EIntOverflow(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EIntOverflow(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EMathError : EExternal
	{


		public EMathError(string Msg) : base(Msg) {}
		public EMathError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EMathError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EMathError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EMathError(uint Ident) : base(Ident) {}
		public EMathError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EMathError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EMathError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EMathError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EMathError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EMathError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EMathError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EInvalidOp : EMathError
	{


		public EInvalidOp(string Msg) : base(Msg) {}
		public EInvalidOp(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EInvalidOp(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EInvalidOp(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EInvalidOp(uint Ident) : base(Ident) {}
		public EInvalidOp(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EInvalidOp(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EInvalidOp(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EInvalidOp(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EInvalidOp(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EInvalidOp(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EInvalidOp(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EZeroDivide : EMathError
	{


		public EZeroDivide(string Msg) : base(Msg) {}
		public EZeroDivide(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EZeroDivide(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EZeroDivide(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EZeroDivide(uint Ident) : base(Ident) {}
		public EZeroDivide(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EZeroDivide(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EZeroDivide(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EZeroDivide(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EZeroDivide(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EZeroDivide(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EZeroDivide(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EOverflow : EMathError
	{


		public EOverflow(string Msg) : base(Msg) {}
		public EOverflow(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EOverflow(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EOverflow(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EOverflow(uint Ident) : base(Ident) {}
		public EOverflow(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EOverflow(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EOverflow(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EOverflow(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EOverflow(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EOverflow(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EOverflow(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EUnderflow : EMathError
	{


		public EUnderflow(string Msg) : base(Msg) {}
		public EUnderflow(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EUnderflow(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EUnderflow(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EUnderflow(uint Ident) : base(Ident) {}
		public EUnderflow(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EUnderflow(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EUnderflow(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EUnderflow(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EUnderflow(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EUnderflow(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EUnderflow(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EOSError : DException
	{


		public EOSError(string Msg) : base(Msg) {}
		public EOSError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EOSError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EOSError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EOSError(uint Ident) : base(Ident) {}
		public EOSError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EOSError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EOSError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EOSError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EOSError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EOSError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EOSError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EWin32Error : EOSError
	{


		public EWin32Error(string Msg) : base(Msg) {}
		public EWin32Error(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EWin32Error(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EWin32Error(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EWin32Error(uint Ident) : base(Ident) {}
		public EWin32Error(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EWin32Error(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EWin32Error(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EWin32Error(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EWin32Error(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EWin32Error(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EWin32Error(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EMonitor : DException
	{


		public EMonitor(string Msg) : base(Msg) {}
		public EMonitor(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EMonitor(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EMonitor(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EMonitor(uint Ident) : base(Ident) {}
		public EMonitor(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EMonitor(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EMonitor(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EMonitor(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EMonitor(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EMonitor(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EMonitor(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EMonitorLockException : EMonitor
	{


		public EMonitorLockException(string Msg) : base(Msg) {}
		public EMonitorLockException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EMonitorLockException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EMonitorLockException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EMonitorLockException(uint Ident) : base(Ident) {}
		public EMonitorLockException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EMonitorLockException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EMonitorLockException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EMonitorLockException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EMonitorLockException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EMonitorLockException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EMonitorLockException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class ENoMonitorSupportException : EMonitor
	{


		public ENoMonitorSupportException(string Msg) : base(Msg) {}
		public ENoMonitorSupportException(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public ENoMonitorSupportException(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public ENoMonitorSupportException(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public ENoMonitorSupportException(uint Ident) : base(Ident) {}
		public ENoMonitorSupportException(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public ENoMonitorSupportException(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public ENoMonitorSupportException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public ENoMonitorSupportException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public ENoMonitorSupportException(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public ENoMonitorSupportException(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public ENoMonitorSupportException(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	
  /*
    Days per month for normal years (False) and leap years (True).
    The second index follows the Delphi TDayTable range 1..12.
  *//*
  D2CSharp Runtime Library (RTL)

  This C# source file provides the D2CSharp runtime implementation of
  System.SysUtils functionality.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The implementation maps Delphi SysUtils behavior to managed .NET services
  while preserving the signatures generated from the MockRTL unit.

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
  /* File open modes */
	public const int fmOpenRead = 0x0000;
	public const int fmOpenWrite = 0x0001;
	public const int fmOpenReadWrite = 0x0002;
	public const int fmExclusive = 0x0004;
	public const int fmShareCompat = 0x0000;
	public const int fmShareExclusive = 0x0010;
	public const int fmShareDenyWrite = 0x0020;
	public const int fmShareDenyRead = 0x0030;
	public const int fmShareDenyNone = 0x0040;

  /* File attribute constants */
	public const int faInvalid = -1;
	public const int faReadOnly = 0x00000001;
	public const int faHidden = 0x00000002;
	public const int faSysFile = 0x00000004;
	public const int faVolumeID = 0x00000008;
	public const int faDirectory = 0x00000010;
	public const int faArchive = 0x00000020;
	public const int faNormal = 0x00000080;
	public const int faTemporary = 0x00000100;
	public const int faSymLink = 0x00000400;
	public const int faCompressed = 0x00000800;
	public const int faEncrypted = 0x00004000;
	public const int faVirtual = 0x00010000;
	public const int faAnyFile = 0x000001FF;

  /* Common public SysUtils constants. Windows values are used by the current
    D2CSharp RTL target; platform-specific implementations may override these
    semantics in the completed C# runtime. */
	public const char PathDelim = '\\';
	public const char DriveDelim = ':';
	public const char PathSep = ';';
	public const string DefaultTrueBoolStr = "True";
	public const string DefaultFalseBoolStr = "False";
	public const int DateDelta = 693594;
	public const int UnixDateDelta = 25569;

  /* Public TDateTime limits documented by System.SysUtils. */
	public const double MinDateTime = -657434.0D;
	public const double MaxDateTime = 2958465.99999D;
  /* Public array and utility types documented by System.SysUtils. */
	//#pragma pack (push, 1)

	//#pragma pack (pop)

	//#pragma pack (push, 1)

	//#pragma pack (pop)

	//#pragma pack (push, 1)

	//#pragma pack (pop)

	public enum TUncertainState {Maybe,
                      Yes,
                      No };


  /* Number of days in the twelve months of a year. */

  /* Keep simple value types first so their translation can be verified
    independently from the special Exception handling. */
	public enum TFloatFormat {ffGeneral,
                   ffExponent,
                   ffFixed,
                   ffNumber,
                   ffCurrency };
	public enum TReplaceFlag {rfReplaceAll,
                   rfIgnoreCase };
	public enum TTextLineBreakStyle {tlbsCRLF,
                          tlbsLF };
	public enum TFilenameCaseMatch {mkNone,
                         mkExactMatch,
                         mkSingleMatch,
                         mkAmbiguous };
	public enum TCmdLineSwitchType {clstValueNextParam,
                         clstValueAppended };
	public enum TLocaleOptions {loInvariantLocale,
                     loUserLocale };
	public enum TMbcsByteType {mbSingleByte,
                    mbLeadByte,
                    mbTrailByte };
	public enum TFileSystemAttribute {fsCaseSensitive,
                           fsCasePreserving,
                           fsLocal,
                           fsNetwork,
                           fsRemovable,
                           fsSymLink };
	public enum TFloatValue {fvExtended,
                  fvCurrency };
	//#pragma pack (push, 1)

	//#pragma pack (pop)

	public enum TNameType {ntContainsUnit,
                ntRequiresPackage,
                ntDcpBpiName };


  /* Callback/procedural types used by the public SysUtils package and
    termination APIs. */
public delegate void TProcedure();
public delegate bool TTerminateProc();
public delegate bool TValidatePackageProc(uint Module);
public delegate void TPackageInfoProc(string Name, TNameType NameType, byte Flags, IntPtr Param);

  /* Windows API compatibility types required by the public SysUtils records.
    These mirror the publicly documented FILETIME / WIN32_FIND_DATAW layout;
    they are dependencies of TSearchRec and TSymLinkRec, not SysUtils-owned API. */
public delegate int TGrowCollectionFunc(int OldCapacity, int NewCount);
	//#pragma pack (push, 1)

	//#pragma pack (pop)

  /*
    Days per month for normal years (False) and leap years (True).
    The second index follows the Delphi TDayTable range 1..12.
  */
	public static readonly ushort[][] MonthDays = new ushort[2/*# boolean*/][]
	{
		new ushort[]{31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}, new ushort[]{31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
	};
	public static TFormatSettings FormatSettings = TFormatSettings.Create();

	/*
	 * Legacy global formatting variables.
	 *
	 * Delphi source predating TFormatSettings may access these variables
	 * directly.  Keep them synchronized with FormatSettings so both the
	 * legacy globals and the modern record-based API affect the same runtime
	 * formatting state.
	 */
	public static char DecimalSeparator
	{
		get => FormatSettings.DecimalSeparator;
		set => FormatSettings.DecimalSeparator = value;
	}

	public static char ThousandSeparator
	{
		get => FormatSettings.ThousandSeparator;
		set => FormatSettings.ThousandSeparator = value;
	}

	public static string CurrencyString
	{
		get => FormatSettings.CurrencyString;
		set => FormatSettings.CurrencyString = value ?? string.Empty;
	}

	public static byte CurrencyFormat
	{
		get => FormatSettings.CurrencyFormat;
		set => FormatSettings.CurrencyFormat = value;
	}
	public static TSysLocale SysLocale = TSysLocale.CreateRecord();
	public static TGrowCollectionFunc GrowCollectionFunc = default;
	public static string[] TrueBoolStrs = new string[]{DefaultTrueBoolStr};
	public static string[] FalseBoolStrs = new string[]{DefaultFalseBoolStr};

	private static readonly object FFindLock = new object();
	private static readonly Dictionary<uint, IEnumerator<string>> FFindEnumerators = new Dictionary<uint, IEnumerator<string>>();
	private static uint FNextFindHandle = 1;
	private static readonly object FFileLock = new object();
	private static readonly Dictionary<uint, global::System.IO.FileStream> FFileStreams = new Dictionary<uint, global::System.IO.FileStream>();
	private static uint FNextFileHandle = 1;
	private static readonly List<TProcedure> FExitProcs = new List<TProcedure>();
	private static readonly List<TTerminateProc> FTerminateProcs = new List<TTerminateProc>();
	private static string FFallbackLanguages = string.Empty;
	private static readonly object FModuleLock = new object();
	private static readonly Dictionary<uint, IntPtr> FModules = new Dictionary<uint, IntPtr>();
	private static readonly Dictionary<uint, string> FModuleNames = new Dictionary<uint, string>();
	private static uint FNextModuleHandle = 1;

	private static CultureInfo CultureFromSettings(TFormatSettings fs)
	{
		CultureInfo c = (CultureInfo)CultureInfo.InvariantCulture.Clone();
		NumberFormatInfo n = c.NumberFormat;
		if (fs.DecimalSeparator != '\0')
		{
			n.NumberDecimalSeparator = fs.DecimalSeparator.ToString();
			n.CurrencyDecimalSeparator = fs.DecimalSeparator.ToString();
		}
		if (fs.ThousandSeparator != '\0')
		{
			n.NumberGroupSeparator = fs.ThousandSeparator.ToString();
			n.CurrencyGroupSeparator = fs.ThousandSeparator.ToString();
		}
		if (!string.IsNullOrEmpty(fs.CurrencyString))
			n.CurrencySymbol = fs.CurrencyString;
		n.CurrencyDecimalDigits = fs.CurrencyDecimals;
		if (fs.CurrencyFormat <= 3)
			n.CurrencyPositivePattern = fs.CurrencyFormat;
		if (fs.NegCurrFormat <= 15)
			n.CurrencyNegativePattern = fs.NegCurrFormat;
		DateTimeFormatInfo d = c.DateTimeFormat;
		if (!string.IsNullOrEmpty(fs.ShortDateFormat)) d.ShortDatePattern = DotNetDatePattern(fs.ShortDateFormat, fs);
		if (!string.IsNullOrEmpty(fs.LongDateFormat)) d.LongDatePattern = DotNetDatePattern(fs.LongDateFormat, fs);
		if (!string.IsNullOrEmpty(fs.ShortTimeFormat)) d.ShortTimePattern = DotNetDatePattern(fs.ShortTimeFormat, fs);
		if (!string.IsNullOrEmpty(fs.LongTimeFormat)) d.LongTimePattern = DotNetDatePattern(fs.LongTimeFormat, fs);
		if (fs.DateSeparator != '\0') d.DateSeparator = fs.DateSeparator.ToString();
		if (fs.TimeSeparator != '\0') d.TimeSeparator = fs.TimeSeparator.ToString();
		if (!string.IsNullOrEmpty(fs.TimeAMString)) d.AMDesignator = fs.TimeAMString;
		if (!string.IsNullOrEmpty(fs.TimePMString)) d.PMDesignator = fs.TimePMString;
		return c;
	}

	private static string DotNetDatePattern(string format, TFormatSettings fs)
	{
		// Retained for parsing/culture setup. Formatting itself is handled by
		// DelphiDateTimeFormatCore so Delphi-specific composite tokens and
		// TFormatSettings name arrays are respected.
		if (string.IsNullOrEmpty(format)) return format ?? string.Empty;
		global::System.Text.StringBuilder b = new global::System.Text.StringBuilder();
		for (int i = 0; i < format.Length;)
		{
			char ch = format[i];
			if (ch == '\'' || ch == '"')
			{
				char q = ch; int start = i++;
				while (i < format.Length && format[i] != q) i++;
				if (i < format.Length) i++;
				b.Append(format.Substring(start, i - start));
				continue;
			}
			int j=i+1;
			while(j<format.Length && char.ToLowerInvariant(format[j])==char.ToLowerInvariant(ch)) j++;
			int count=j-i;
			switch(char.ToLowerInvariant(ch))
			{
				case 'y': b.Append(count <= 2 ? "yy" : "yyyy"); break;
				case 'd': b.Append(count==1?"d":count==2?"dd":count==3?"ddd":"dddd"); break;
				case 'm': b.Append(count==1?"M":count==2?"MM":count==3?"MMM":"MMMM"); break;
				case 'h': b.Append(count==1?"H":"HH"); break;
				case 'n': b.Append(count==1?"m":"mm"); break;
				case 's': b.Append(count==1?"s":"ss"); break;
				case 'z': b.Append(count==1?"f":count==2?"ff":"fff"); break;
				case '/': b.Append('/'); break;
				case ':': b.Append(':'); break;
				default:
					for(int k=0;k<count;k++) b.Append(ch);
					break;
			}
			i=j;
		}
		return b.ToString();
	}

	private static string DelphiDateTimeFormatCore(string format, TDateTime value, TFormatSettings fs)
	{
		format ??= string.Empty;
		global::System.DateTime dt = value.ToDateTime();
		global::System.Text.StringBuilder b = new global::System.Text.StringBuilder();
		string lowerFormat = format.ToLowerInvariant();
		bool twelveHour = lowerFormat.Contains("ampm") ||
						  lowerFormat.Contains("am/pm") ||
						  lowerFormat.Contains("a/p");

		string ShortMonth(int month)
		{
			if (fs.ShortMonthNames != null && month >= 1 && month <= fs.ShortMonthNames.Length &&
				!string.IsNullOrEmpty(fs.ShortMonthNames[month - 1]))
				return fs.ShortMonthNames[month - 1];
			return CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[month - 1];
		}

		string LongMonth(int month)
		{
			if (fs.LongMonthNames != null && month >= 1 && month <= fs.LongMonthNames.Length &&
				!string.IsNullOrEmpty(fs.LongMonthNames[month - 1]))
				return fs.LongMonthNames[month - 1];
			return CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[month - 1];
		}

		string ShortDay(global::System.DayOfWeek day)
		{
			int index = (int)day; // Delphi ShortDayNames[1] is Sunday.
			if (fs.ShortDayNames != null && index < fs.ShortDayNames.Length &&
				!string.IsNullOrEmpty(fs.ShortDayNames[index]))
				return fs.ShortDayNames[index];
			return CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[index];
		}

		string LongDay(global::System.DayOfWeek day)
		{
			int index = (int)day; // Delphi LongDayNames[1] is Sunday.
			if (fs.LongDayNames != null && index < fs.LongDayNames.Length &&
				!string.IsNullOrEmpty(fs.LongDayNames[index]))
				return fs.LongDayNames[index];
			return CultureInfo.CurrentCulture.DateTimeFormat.DayNames[index];
		}

		for (int i = 0; i < format.Length;)
		{
			char ch = format[i];

			if (ch == '\'' || ch == '"')
			{
				char quote = ch++;
				i++;
				while (i < format.Length)
				{
					if (format[i] == quote)
					{
						i++;
						break;
					}
					b.Append(format[i++]);
				}
				continue;
			}

			if (i + 4 <= format.Length &&
				string.Compare(format, i, "ampm", 0, 4, true, CultureInfo.InvariantCulture) == 0)
			{
				b.Append(dt.Hour < 12 ? (fs.TimeAMString ?? string.Empty) : (fs.TimePMString ?? string.Empty));
				i += 4;
				continue;
			}
			if (i + 5 <= format.Length &&
				string.Compare(format, i, "am/pm", 0, 5, true, CultureInfo.InvariantCulture) == 0)
			{
				bool upper = char.IsUpper(format[i]);
				string designator = dt.Hour < 12 ? "am" : "pm";
				b.Append(upper ? designator.ToUpperInvariant() : designator);
				i += 5;
				continue;
			}
			if (i + 3 <= format.Length &&
				string.Compare(format, i, "a/p", 0, 3, true, CultureInfo.InvariantCulture) == 0)
			{
				char designator = dt.Hour < 12 ? 'a' : 'p';
				b.Append(char.IsUpper(format[i]) ? char.ToUpperInvariant(designator) : designator);
				i += 3;
				continue;
			}

			int j = i + 1;
			while (j < format.Length &&
				   char.ToLowerInvariant(format[j]) == char.ToLowerInvariant(ch))
				j++;
			int count = j - i;

			switch (char.ToLowerInvariant(ch))
			{
				case 'c':
					b.Append(DelphiDateTimeFormatCore(fs.ShortDateFormat, value, fs));
					if (dt.TimeOfDay.Ticks != 0)
					{
						b.Append(' ');
						b.Append(DelphiDateTimeFormatCore(fs.LongTimeFormat, value, fs));
					}
					break;

				case 'd':
					if (count == 1) b.Append(dt.Day.ToString(CultureInfo.InvariantCulture));
					else if (count == 2) b.Append(dt.Day.ToString("00", CultureInfo.InvariantCulture));
					else if (count == 3) b.Append(ShortDay(dt.DayOfWeek));
					else if (count == 4) b.Append(LongDay(dt.DayOfWeek));
					else if (count == 5) b.Append(DelphiDateTimeFormatCore(fs.ShortDateFormat, value, fs));
					else b.Append(DelphiDateTimeFormatCore(fs.LongDateFormat, value, fs));
					break;

				case 'm':
					if (count == 1) b.Append(dt.Month.ToString(CultureInfo.InvariantCulture));
					else if (count == 2) b.Append(dt.Month.ToString("00", CultureInfo.InvariantCulture));
					else if (count == 3) b.Append(ShortMonth(dt.Month));
					else b.Append(LongMonth(dt.Month));
					break;

				case 'y':
					if (count <= 2) b.Append((dt.Year % 100).ToString("00", CultureInfo.InvariantCulture));
					else b.Append(dt.Year.ToString("0000", CultureInfo.InvariantCulture));
					break;

				case 'h':
					int hour = dt.Hour;
					if (twelveHour)
					{
						hour %= 12;
						if (hour == 0) hour = 12;
					}
					b.Append(count == 1
						? hour.ToString(CultureInfo.InvariantCulture)
						: hour.ToString("00", CultureInfo.InvariantCulture));
					break;

				case 'n':
					b.Append(count == 1
						? dt.Minute.ToString(CultureInfo.InvariantCulture)
						: dt.Minute.ToString("00", CultureInfo.InvariantCulture));
					break;

				case 's':
					b.Append(count == 1
						? dt.Second.ToString(CultureInfo.InvariantCulture)
						: dt.Second.ToString("00", CultureInfo.InvariantCulture));
					break;

				case 'z':
					if (count == 1) b.Append(dt.Millisecond.ToString(CultureInfo.InvariantCulture));
					else if (count == 2) b.Append(dt.Millisecond.ToString("00", CultureInfo.InvariantCulture));
					else b.Append(dt.Millisecond.ToString("000", CultureInfo.InvariantCulture));
					break;

				case 't':
					if (count == 1) b.Append(DelphiDateTimeFormatCore(fs.ShortTimeFormat, value, fs));
					else b.Append(DelphiDateTimeFormatCore(fs.LongTimeFormat, value, fs));
					break;

				case '/':
					b.Append(fs.DateSeparator == '\0' ? '/' : fs.DateSeparator);
					break;

				case ':':
					b.Append(fs.TimeSeparator == '\0' ? ':' : fs.TimeSeparator);
					break;

				default:
					b.Append(format, i, count);
					break;
			}
			i = j;
		}
		return b.ToString();
	}

	private static object VarValue(TVarRec v)
	{
		object value = v.Value;
		if (value is Currency c) return c.ToDecimal();
		if (value is AnsiString a) return a.ToString();
		if (value is PChar pc) return pc.ToString();
		if (value is PAnsiChar pa) return pa.ToString();
		return value;
	}

	private static string DelphiFormatCore(string format, TVarRec[] args, IFormatProvider provider)
	{
		format ??= string.Empty;
		args ??= Array.Empty<TVarRec>();
		TStringBuilder output = new TStringBuilder();
		int sequential = 0;
		for (int i=0;i<format.Length;i++)
		{
			if (format[i] != '%') { output.Append(format[i]); continue; }
			if (i+1 < format.Length && format[i+1]=='%') { output.Append('%'); i++; continue; }
			int p=i+1, argIndex=-1;
			int save=p, number=0; bool any=false;
			while(p<format.Length && char.IsDigit(format[p])) { any=true; number=number*10+(format[p]-'0'); p++; }
			if(any && p<format.Length && format[p]==':') { argIndex=number; p++; } else p=save;
			bool left=false; if(p<format.Length && format[p]=='-'){ left=true; p++; }
			int width=0; while(p<format.Length && char.IsDigit(format[p])) { width=width*10+(format[p]-'0'); p++; }
			int precision=-1;
			if(p<format.Length && format[p]=='.'){ p++; precision=0; while(p<format.Length && char.IsDigit(format[p])) { precision=precision*10+(format[p]-'0'); p++; } }
			if(p>=format.Length) { output.Append('%'); break; }
			char spec=format[p];
			if(argIndex<0) argIndex=sequential++;
			object value=argIndex>=0 && argIndex<args.Length ? VarValue(args[argIndex]) : null;
			string s;
			try
			{
				switch(char.ToLowerInvariant(spec))
				{
					case 'd':
					{
						long iv = Convert.ToInt64(value ?? 0, provider);
						bool neg = iv < 0;
						ulong mag = neg
							? (ulong)(-(iv + 1)) + 1UL
							: (ulong)iv;
						s = mag.ToString(provider);
						if (precision >= 0 && s.Length < precision)
							s = s.PadLeft(precision, '0');
						if (neg)
							s = "-" + s;
						break;
					}
					case 'u':
					{
						s = Convert.ToUInt64(value ?? 0, provider).ToString(provider);
						if (precision >= 0 && s.Length < precision)
							s = s.PadLeft(precision, '0');
						break;
					}
					case 'x':
					{
						s = Convert.ToUInt64(value ?? 0, provider)
							.ToString("X", provider);
						if (precision >= 0 && s.Length < precision)
							s = s.PadLeft(precision, '0');
						break;
					}
					case 'e': s=Convert.ToDouble(value ?? 0, provider).ToString(precision>=0?"E"+precision:"E", provider); break;
					case 'f': s=Convert.ToDouble(value ?? 0, provider).ToString(precision>=0?"F"+precision:"F", provider); break;
					case 'g': s=Convert.ToDouble(value ?? 0, provider).ToString(precision>0?"G"+precision:"G", provider); break;
					case 'm': s=Convert.ToDecimal(value ?? 0, provider).ToString(precision>=0?"C"+precision:"C", provider); break;
					case 'n': s=Convert.ToDouble(value ?? 0, provider).ToString(precision>=0?"N"+precision:"N", provider); break;
					case 'p': s=value is IntPtr ip ? "0x"+ip.ToInt64().ToString("X") : value?.ToString() ?? "0"; break;
					case 's':
					default: s=value?.ToString() ?? string.Empty; if(precision>=0 && s.Length>precision) s=s.Substring(0,precision); break;
				}
			}
			catch { s=value?.ToString() ?? string.Empty; }
			if(width>s.Length) s=left?s.PadRight(width):s.PadLeft(width);
			output.Append(s); i=p;
		}
		return output.ToString();
	}

	private static bool TryParseInteger(string s, out long value)
	{
		value=0; if(s==null) return false; s=s.Trim();
		bool neg=false; if(s.StartsWith("-")){neg=true;s=s.Substring(1);} else if(s.StartsWith("+")) s=s.Substring(1);
		NumberStyles style=NumberStyles.Integer; int radix=10;
		if(s.StartsWith("$")) { s=s.Substring(1); style=NumberStyles.AllowHexSpecifier; radix=16; }
		else if(s.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) { s=s.Substring(2); style=NumberStyles.AllowHexSpecifier; radix=16; }
		if(!long.TryParse(s, style, CultureInfo.InvariantCulture, out long v)) return false;
		value=neg?-v:v; return true;
	}

	private static string PCharString(PChar p) => p.IsNull() ? string.Empty : p.ToString();
	private static string PAnsiString(PAnsiChar p) => p.IsNull() ? string.Empty : p.ToString();

	private static void FillSearchRec(ref TSearchRec f, string path)
	{
		FileSystemInfo info = Directory.Exists(path) ? (FileSystemInfo)new DirectoryInfo(path) : new FileInfo(path);
		f.Name = info.Name;
		f.Attr = FileGetAttr(path);
		if (info is FileInfo fi) f.Size = fi.Length; else f.Size = 0;
		f.Time = DateTimeToFileDate(new TDateTime(info.LastWriteTime));
	}

	private static TFileTime ToFileTime(global::System.DateTime value)
	{
		long n = value.ToUniversalTime().ToFileTimeUtc();
		TFileTime r=TFileTime.CreateRecord();
		r.dwLowDateTime=(uint)(n&0xffffffffL);
		r.dwHighDateTime=(uint)((ulong)n>>32);
		return r;
	}
	private static TDateTime FromFileTime(TFileTime ft)
	{
		long n=unchecked((long)(((ulong)ft.dwHighDateTime<<32)|ft.dwLowDateTime));
		try { return new TDateTime(global::System.DateTime.FromFileTimeUtc(n).ToLocalTime()); }
		catch { return default; }
	}


/* Byte/string conversion */
	public static byte[] BytesOf(AnsiString Val)
	{
		return Val == null ? Array.Empty<byte>() : Val.ToByteArray();
	}
	public static byte[] BytesOf(char Val)
	{
		return global::System.Text.Encoding.Unicode.GetBytes(new[]{Val});
	}
	public static byte[] BytesOf(byte Val)
	{
		return new[]{Val};
	}
	public static byte[] BytesOf(string Val)
	{
		return global::System.Text.Encoding.Unicode.GetBytes(Val ?? string.Empty);
	}
	public static byte[] BytesOf(Pointer Val, int Len)
	{
		if (Len <= 0) return Array.Empty<byte>();
		UntypedPointer p = Val;
		if (p.IsNull()) return Array.Empty<byte>();
		byte[] r = new byte[Len];
		for(int i=0;i<Len;i++) r[i]=p[i];
		return r;
	}
	public static byte[] WideBytesOf(string Value)
	{
		return global::System.Text.Encoding.Unicode.GetBytes(Value ?? string.Empty);
	}
	public static string StringOf(byte[] Bytes)
	{
		return global::System.Text.Encoding.Unicode.GetString(Bytes ?? Array.Empty<byte>());
	}
	public static string WideStringOf(byte[] Bytes)
	{
		return global::System.Text.Encoding.Unicode.GetString(Bytes ?? Array.Empty<byte>());
	}
	public static byte[] PlatformBytesOf(string Value)
	{
		return global::System.Text.Encoding.Default.GetBytes(Value ?? string.Empty);
	}
	public static string PlatformStringOf(byte[] Value)
	{
		return global::System.Text.Encoding.Default.GetString(Value ?? Array.Empty<byte>());
	}
	public static PChar WideStrAlloc(uint Size)
	{
		return Size == 0 ? default : new PChar(checked((int)Size), true);
	}

/* Integer conversion */
	public static string IntToStr(int Value)
	{
		return Value.ToString(CultureInfo.InvariantCulture);
	}
	public static string IntToStr(long Value)
	{
		return Value.ToString(CultureInfo.InvariantCulture);
	}
	public static string UIntToStr(uint Value)
	{
		return Value.ToString(CultureInfo.InvariantCulture);
	}
	public static string UIntToStr(ulong Value)
	{
		return Value.ToString(CultureInfo.InvariantCulture);
	}
	public static int StrToInt(string S)
	{
		if (!TryStrToInt(S, out int v)) throw new EConvertError("Invalid integer: " + S); return v;
	}
	public static int StrToIntDef(string S, int Default)
	{
		return TryStrToInt(S, out int v) ? v : Default;
	}
	public static bool TryStrToInt(string S, out int Value)
	{
		Value=0; if(!TryParseInteger(S,out long v) || v<int.MinValue || v>int.MaxValue) return false; Value=(int)v; return true;
	}
	public static long StrToInt64(string S)
	{
		if (!TryStrToInt64(S, out long v)) throw new EConvertError("Invalid Int64: " + S); return v;
	}
	public static long StrToInt64Def(string S, long Default)
	{
		return TryStrToInt64(S, out long v) ? v : Default;
	}
	public static bool TryStrToInt64(string S, out long Value)
	{
		return TryParseInteger(S,out Value);
	}
	public static uint StrToUInt(string S)
	{
		if (!TryStrToUInt(S, out uint v)) throw new EConvertError("Invalid unsigned integer: " + S); return v;
	}
	public static uint StrToUIntDef(string S, uint Default)
	{
		return TryStrToUInt(S,out uint v)?v:Default;
	}
	public static bool TryStrToUInt(string S, out uint Value)
	{
		Value=0; if(!TryParseInteger(S,out long v) || v<0 || v>uint.MaxValue) return false; Value=(uint)v; return true;
	}
	public static ulong StrToUInt64(string S)
	{
		if(!TryStrToUInt64(S,out ulong v)) throw new EConvertError("Invalid UInt64: " + S); return v;
	}
	public static ulong StrToUInt64Def(string S, ulong Default)
	{
		return TryStrToUInt64(S,out ulong v)?v:Default;
	}
	public static bool TryStrToUInt64(string S, out ulong Value)
	{
		Value=0; if(S==null) return false; string s=S.Trim();
		if(s.StartsWith("$")) return ulong.TryParse(s.Substring(1), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out Value);
		if(s.StartsWith("0x",StringComparison.OrdinalIgnoreCase)) return ulong.TryParse(s.Substring(2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out Value);
		return ulong.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out Value);
	}

/* Boolean conversion */
	public static string BoolToStr(bool B, bool UseBoolStrs = false)
	{
		if(UseBoolStrs)
		{
			string[] a=B?TrueBoolStrs:FalseBoolStrs;
			if(a!=null && a.Length>0 && !string.IsNullOrEmpty(a[0])) return a[0];
		}
		return B ? DefaultTrueBoolStr : DefaultFalseBoolStr;
	}
	public static bool StrToBool(string S)
	{
		if(!TryStrToBool(S,out bool v)) throw new EConvertError("Invalid boolean: "+S); return v;
	}
	public static bool StrToBoolDef(string S, bool Default)
	{
		return TryStrToBool(S,out bool v)?v:Default;
	}
	public static bool TryStrToBool(string S, out bool Value)
	{
		Value=false; if(S==null) return false; string s=S.Trim();
		if(string.Equals(s,"True",StringComparison.OrdinalIgnoreCase) || s=="1"){Value=true;return true;}
		if(string.Equals(s,"False",StringComparison.OrdinalIgnoreCase) || s=="0"){Value=false;return true;}
		if(TrueBoolStrs!=null) foreach(string x in TrueBoolStrs) if(string.Equals(s,x,StringComparison.OrdinalIgnoreCase)){Value=true;return true;}
		if(FalseBoolStrs!=null) foreach(string x in FalseBoolStrs) if(string.Equals(s,x,StringComparison.OrdinalIgnoreCase)){Value=false;return true;}
		return false;
	}

/* Hexadecimal conversion */
	public static string IntToHex(int Value, int Digits)
	{
		return unchecked((uint)Value).ToString("X"+global::System.Math.Max(0,Digits),CultureInfo.InvariantCulture);
	}
	public static string IntToHex(long Value, int Digits)
	{
		return unchecked((ulong)Value).ToString("X"+global::System.Math.Max(0,Digits),CultureInfo.InvariantCulture);
	}
	public static string IntToHex(ulong Value, int Digits)
	{
		return Value.ToString("X"+global::System.Math.Max(0,Digits),CultureInfo.InvariantCulture);
	}
	public static string IntToHex(sbyte Value)
	{
		return unchecked((byte)Value).ToString("X2");
	}
	public static string IntToHex(byte Value)
	{
		return Value.ToString("X2");
	}
	public static string IntToHex(short Value)
	{
		return unchecked((ushort)Value).ToString("X4");
	}
	public static string IntToHex(ushort Value)
	{
		return Value.ToString("X4");
	}
	public static string IntToHex(int Value)
	{
		return unchecked((uint)Value).ToString("X8");
	}
	public static string IntToHex(uint Value)
	{
		return Value.ToString("X8");
	}
	public static string IntToHex(long Value)
	{
		return unchecked((ulong)Value).ToString("X16");
	}
	public static string IntToHex(ulong Value)
	{
		return Value.ToString("X16");
	}

/* Floating-point conversion */
	private static string NormalizeDelphiGeneralFloat(string Value)
	{
		if (string.IsNullOrEmpty(Value))
			return Value ?? string.Empty;

		int e = Value.IndexOf('E');
		if (e < 0)
			e = Value.IndexOf('e');
		if (e < 0)
			return Value;

		string mantissa = Value.Substring(0, e);
		string exponent = Value.Substring(e + 1);
		char sign = '\0';

		if (exponent.Length > 0 && (exponent[0] == '+' || exponent[0] == '-'))
		{
			sign = exponent[0];
			exponent = exponent.Substring(1);
		}

		exponent = exponent.TrimStart('0');
		if (exponent.Length == 0)
			exponent = "0";

		return mantissa + "E" + (sign == '-' ? "-" : string.Empty) + exponent;
	}

	public static string FloatToStr(double Value)
	{
		return NormalizeDelphiGeneralFloat(
			Value.ToString("G15", CultureFromSettings(SysutilsInterface.FormatSettings)));
	}
	public static string FloatToStr(double Value, TFormatSettings FormatSettings)
	{
		return NormalizeDelphiGeneralFloat(
			Value.ToString("G15", CultureFromSettings(FormatSettings)));
	}
	public static string FloatToStrF(double Value, TFloatFormat Format, int Precision, int Digits)
	{
		return FloatToStrF(Value,Format,Precision,Digits,SysutilsInterface.FormatSettings);
	}
	private static string FloatToExponentString(
		double Value,
		int Precision,
		int Digits,
		IFormatProvider Provider)
	{
		/*
		 * Delphi ffExponent:
		 *   Precision = total significant digits before the exponent,
		 *               including the digit before the decimal separator.
		 *   Digits    = minimum number of exponent digits (0..4).
		 *
		 * .NET's standard E format instead interprets the numeric precision
		 * as the number of digits after the decimal separator and always
		 * emits a three-digit exponent.  Therefore both parts have to be
		 * adapted explicitly.
		 */
		int significantDigits = global::System.Math.Max(1,
			global::System.Math.Min(Precision, 15));
		int fractionalDigits = significantDigits - 1;
		int exponentDigits = global::System.Math.Max(0,
			global::System.Math.Min(Digits, 4));

		string result = Value.ToString(
			"E" + fractionalDigits.ToString(CultureInfo.InvariantCulture),
			Provider);

		int exponentPos = result.IndexOf('E');
		if (exponentPos < 0)
			return result;

		int signPos = exponentPos + 1;
		if (signPos >= result.Length)
			return result;

		char sign = result[signPos];
		int digitPos = (sign == '+' || sign == '-') ? signPos + 1 : signPos;

		string exponent = result.Substring(digitPos).TrimStart('0');
		if (exponent.Length == 0)
			exponent = "0";
		if (exponent.Length < exponentDigits)
			exponent = exponent.PadLeft(exponentDigits, '0');

		string exponentSign =
			(sign == '+' || sign == '-') ? sign.ToString() : "+";

		return result.Substring(0, exponentPos) + "E" + exponentSign + exponent;
	}

	public static string FloatToStrF(double Value, TFloatFormat Format, int Precision, int Digits, TFormatSettings FormatSettings)
	{
		IFormatProvider p=CultureFromSettings(FormatSettings);
		switch(Format)
		{
		case TFloatFormat.ffExponent:
			return FloatToExponentString(Value, Precision, Digits, p);
		case TFloatFormat.ffFixed:
			return Value.ToString("F"+global::System.Math.Max(0,Digits),p);
		case TFloatFormat.ffNumber:
			return Value.ToString("N"+global::System.Math.Max(0,Digits),p);
		case TFloatFormat.ffCurrency:
			return Value.ToString("C"+global::System.Math.Max(0,Digits),p);
		default:
			return Value.ToString(Precision>0?"G"+global::System.Math.Min(Precision,15):"G15",p);
		}
	}
	public static double StrToFloat(string S)
	{
		if(!TryStrToFloat(S,out double v)) throw new EConvertError("Invalid floating point: "+S); return v;
	}
	public static double StrToFloat(string S, TFormatSettings FormatSettings)
	{
		if(!TryStrToFloat(S,out double v,FormatSettings)) throw new EConvertError("Invalid floating point: "+S); return v;
	}
	public static double StrToFloatDef(string S, double Default)
	{
		return TryStrToFloat(S,out double v)?v:Default;
	}
	public static double StrToFloatDef(string S, double Default, TFormatSettings FormatSettings)
	{
		return TryStrToFloat(S,out double v,FormatSettings)?v:Default;
	}
	public static bool TryStrToFloat(string S, out double Value)
	{
		return double.TryParse(S,NumberStyles.Float|NumberStyles.AllowThousands,CultureInfo.CurrentCulture,out Value);
	}
	public static bool TryStrToFloat(string S, out double Value, TFormatSettings FormatSettings)
	{
		return double.TryParse(S,NumberStyles.Float|NumberStyles.AllowThousands,CultureFromSettings(FormatSettings),out Value);
	}

/* Additional floating-point/currency conversion */
	public static void FloatToDecimal(ref TFloatRec Result, UntypedPointer Value, TFloatValue ValueType, int Precision, int Decimals)
	{
		Result=TFloatRec.CreateRecord();
		double v=ValueType==TFloatValue.fvCurrency ? (double)Currency.FromRawValue(Value.Read<long>()).ToDecimal() : Value.Read<double>();
		Result.Negative=v<0; v=global::System.Math.Abs(v);
		string s=v.ToString("E"+global::System.Math.Max(0,global::System.Math.Min(18,Precision-1)),CultureInfo.InvariantCulture);
		int epos=s.IndexOf('E'); string mant=s.Substring(0,epos).Replace(".",""); short exp=short.Parse(s.Substring(epos+1),CultureInfo.InvariantCulture);
		Result.Exponent=(short)(exp+1);
		int n=global::System.Math.Min(Result.Digits.Length-1,mant.Length);
		for(int i=0;i<n;i++)Result.Digits[i]=(byte)mant[i];
		Result.Digits[n]=0;
	}
	public static int FloatToText(PChar BufferArg, UntypedPointer Value, TFloatValue ValueType, TFloatFormat Format, int Precision, int Digits)
	{
		double v=ValueType==TFloatValue.fvCurrency?(double)Currency.FromRawValue(Value.Read<long>()).ToDecimal():Value.Read<double>(); string s=FloatToStrF(v,Format,Precision,Digits); BufferArg.Assign(s); return s.Length;
	}
	public static int FloatToText(PAnsiChar BufferArg, UntypedPointer Value, TFloatValue ValueType, TFloatFormat Format, int Precision, int Digits)
	{
		double v=ValueType==TFloatValue.fvCurrency?(double)Currency.FromRawValue(Value.Read<long>()).ToDecimal():Value.Read<double>(); string s=FloatToStrF(v,Format,Precision,Digits); BufferArg.Assign(s); return s.Length;
	}
	public static int FloatToText(PChar BufferArg, UntypedPointer Value, TFloatValue ValueType, TFloatFormat Format, int Precision, int Digits, TFormatSettings AFormatSettings)
	{
		double v=ValueType==TFloatValue.fvCurrency?(double)Currency.FromRawValue(Value.Read<long>()).ToDecimal():Value.Read<double>(); string s=FloatToStrF(v,Format,Precision,Digits,AFormatSettings); BufferArg.Assign(s); return s.Length;
	}
	public static int FloatToText(PAnsiChar BufferArg, UntypedPointer Value, TFloatValue ValueType, TFloatFormat Format, int Precision, int Digits, TFormatSettings AFormatSettings)
	{
		double v=ValueType==TFloatValue.fvCurrency?(double)Currency.FromRawValue(Value.Read<long>()).ToDecimal():Value.Read<double>(); string s=FloatToStrF(v,Format,Precision,Digits,AFormatSettings); BufferArg.Assign(s); return s.Length;
	}
	public static int FloatToTextFmt(PAnsiChar Buf, UntypedPointer Value, TFloatValue ValueType, PAnsiChar Format)
	{
		string s=ValueType==TFloatValue.fvCurrency?FormatCurr(Format.ToString(),Currency.FromRawValue(Value.Read<long>())):FormatFloat(Format.ToString(),Value.Read<double>()); Buf.Assign(s); return s.Length;
	}
	public static int FloatToTextFmt(PAnsiChar Buf, UntypedPointer Value, TFloatValue ValueType, PAnsiChar Format, TFormatSettings AFormatSettings)
	{
		string s=ValueType==TFloatValue.fvCurrency?FormatCurr(Format.ToString(),Currency.FromRawValue(Value.Read<long>()),AFormatSettings):FormatFloat(Format.ToString(),Value.Read<double>(),AFormatSettings); Buf.Assign(s); return s.Length;
	}
	public static int FloatToTextFmt(PChar Buf, UntypedPointer Value, TFloatValue ValueType, PChar Format)
	{
		string s=ValueType==TFloatValue.fvCurrency?FormatCurr(Format.ToString(),Currency.FromRawValue(Value.Read<long>())):FormatFloat(Format.ToString(),Value.Read<double>()); Buf.Assign(s); return s.Length;
	}
	public static int FloatToTextFmt(PChar Buf, UntypedPointer Value, TFloatValue ValueType, PChar Format, TFormatSettings AFormatSettings)
	{
		string s=ValueType==TFloatValue.fvCurrency?FormatCurr(Format.ToString(),Currency.FromRawValue(Value.Read<long>()),AFormatSettings):FormatFloat(Format.ToString(),Value.Read<double>(),AFormatSettings); Buf.Assign(s); return s.Length;
	}
	public static bool TextToFloat(PChar Buffer, UntypedPointer Value, TFloatValue ValueType)
	{
		string s=Buffer.ToString(); if(ValueType==TFloatValue.fvCurrency){if(decimal.TryParse(s,NumberStyles.Number|NumberStyles.AllowCurrencySymbol,CultureInfo.CurrentCulture,out decimal d)){Value.Write<long>(new Currency(d).ToRawValue());return true;}}else{if(double.TryParse(s,NumberStyles.Float|NumberStyles.AllowThousands,CultureInfo.CurrentCulture,out double d)){Value.Write<double>(d);return true;}}return false;
	}
	public static bool TextToFloat(PChar Buffer, UntypedPointer Value, TFloatValue ValueType, TFormatSettings AFormatSettings)
	{
		string s=Buffer.ToString(); if(ValueType==TFloatValue.fvCurrency){if(decimal.TryParse(s,NumberStyles.Number|NumberStyles.AllowCurrencySymbol,CultureFromSettings(AFormatSettings),out decimal d)){Value.Write<long>(new Currency(d).ToRawValue());return true;}}else{if(double.TryParse(s,NumberStyles.Float|NumberStyles.AllowThousands,CultureFromSettings(AFormatSettings),out double d)){Value.Write<double>(d);return true;}}return false;
	}
	public static bool TextToFloat(PAnsiChar Buffer, UntypedPointer Value, TFloatValue ValueType)
	{
		string s=Buffer.ToString(); if(ValueType==TFloatValue.fvCurrency){if(decimal.TryParse(s,NumberStyles.Number|NumberStyles.AllowCurrencySymbol,CultureInfo.CurrentCulture,out decimal d)){Value.Write<long>(new Currency(d).ToRawValue());return true;}}else{if(double.TryParse(s,NumberStyles.Float|NumberStyles.AllowThousands,CultureInfo.CurrentCulture,out double d)){Value.Write<double>(d);return true;}}return false;
	}
	public static bool TextToFloat(PAnsiChar Buffer, UntypedPointer Value, TFloatValue ValueType, TFormatSettings AFormatSettings)
	{
		string s=Buffer.ToString(); if(ValueType==TFloatValue.fvCurrency){if(decimal.TryParse(s,NumberStyles.Number|NumberStyles.AllowCurrencySymbol,CultureFromSettings(AFormatSettings),out decimal d)){Value.Write<long>(new Currency(d).ToRawValue());return true;}}else{if(double.TryParse(s,NumberStyles.Float|NumberStyles.AllowThousands,CultureFromSettings(AFormatSettings),out double d)){Value.Write<double>(d);return true;}}return false;
	}
	//# output of equivalent "TextToFloat" function suppressed
	//# output of equivalent "TextToFloat" function suppressed
	public static bool TextToFloat(string S, ref double Value)
	{
		if(TryStrToFloat(S,out double v)){Value=v;return true;} return false;
	}
	public static bool TextToFloat(string S, ref double Value, TFormatSettings AFormatSettings)
	{
		if(TryStrToFloat(S,out double v,AFormatSettings)){Value=v;return true;} return false;
	}
	public static bool TextToFloat(string S, ref Currency Value)
	{
		if(decimal.TryParse(S,NumberStyles.Number|NumberStyles.AllowCurrencySymbol,CultureInfo.CurrentCulture,out decimal v)){Value=(Currency)v;return true;} return false;
	}
	public static bool TextToFloat(string S, ref Currency Value, TFormatSettings AFormatSettings)
	{
		if(decimal.TryParse(S,NumberStyles.Number|NumberStyles.AllowCurrencySymbol,CultureFromSettings(AFormatSettings),out decimal v)){Value=(Currency)v;return true;} return false;
	}
	public static Currency FloatToCurr(double Value)
	{
		return (Currency)checked((decimal)Value);
	}
	public static bool TryFloatToCurr(double Value, out Currency AResult)
	{
		try{AResult=(Currency)checked((decimal)Value);return true;}catch{AResult=(Currency)0;return false;}
	}

/* Currency conversion */
	public static string CurrToStr(Currency Value)
	{
		return Value.ToDecimal().ToString(CultureInfo.CurrentCulture);
	}
	public static string CurrToStr(Currency Value, TFormatSettings FormatSettings)
	{
		return Value.ToDecimal().ToString(CultureFromSettings(FormatSettings));
	}
	public static string CurrToStrF(Currency Value, TFloatFormat Format, int Digits)
	{
		return FloatToStrF((double)Value.ToDecimal(), Format, 19, Digits);
	}
	public static string CurrToStrF(Currency Value, TFloatFormat Format, int Digits, TFormatSettings AFormatSettings)
	{
		return FloatToStrF((double)Value.ToDecimal(), Format, 19, Digits, AFormatSettings);
	}
	public static Currency StrToCurr(string S)
	{
		if(!TryStrToCurr(S,out Currency v)) throw new EConvertError("Invalid currency: "+S); return v;
	}
	public static Currency StrToCurr(string S, TFormatSettings FormatSettings)
	{
		if(!TryStrToCurr(S,out Currency v,FormatSettings)) throw new EConvertError("Invalid currency: "+S); return v;
	}
	public static Currency StrToCurrDef(string S, Currency Default)
	{
		return TryStrToCurr(S,out Currency v)?v:Default;
	}
	public static Currency StrToCurrDef(string S, Currency Default, TFormatSettings FormatSettings)
	{
		return TryStrToCurr(S,out Currency v,FormatSettings)?v:Default;
	}
	public static bool TryStrToCurr(string S, out Currency Value)
	{
		Value=(Currency)0; if(decimal.TryParse(S,NumberStyles.Number|NumberStyles.AllowCurrencySymbol,CultureInfo.CurrentCulture,out decimal v)){try{Value=(Currency)v;return true;}catch{}} return false;
	}
	public static bool TryStrToCurr(string S, out Currency Value, TFormatSettings FormatSettings)
	{
		Value=(Currency)0; if(decimal.TryParse(S,NumberStyles.Number|NumberStyles.AllowCurrencySymbol,CultureFromSettings(FormatSettings),out decimal v)){try{Value=(Currency)v;return true;}catch{}} return false;
	}
	public static string FormatFloat(string Format, double Value)
	{
		return Value.ToString(
			Format ?? string.Empty,
			CultureFromSettings(SysutilsInterface.FormatSettings));
	}
	public static string FormatFloat(string Format, double Value, TFormatSettings AFormatSettings)
	{
		return Value.ToString(Format ?? string.Empty,CultureFromSettings(AFormatSettings));
	}
	public static string FormatCurr(string Format, Currency Value)
	{
		return Value.ToDecimal().ToString(
			Format ?? string.Empty,
			CultureFromSettings(SysutilsInterface.FormatSettings));
	}
	public static string FormatCurr(string Format, Currency Value, TFormatSettings AFormatSettings)
	{
		return Value.ToDecimal().ToString(Format ?? string.Empty,CultureFromSettings(AFormatSettings));
	}

/* Date and time construction */
	public static TDateTime EncodeDate(ushort Year, ushort Month, ushort Day)
	{
		try{return new TDateTime(Year,Month,Day);}catch(global::System.Exception ex){throw new EConvertError(ex.Message);}
	}
	public static bool TryEncodeDate(ushort Year, ushort Month, ushort Day, out TDateTime Date)
	{
		try{Date=new TDateTime(Year,Month,Day);return true;}catch{Date=default;return false;}
	}
	public static void DecodeDate(TDateTime DateTime, out ushort Year, out ushort Month, out ushort Day)
	{
		global::System.DateTime d=DateTime.ToDateTime(); Year=(ushort)d.Year;Month=(ushort)d.Month;Day=(ushort)d.Day;
	}
	public static bool DecodeDateFully(TDateTime DateTime, ref ushort Year, ref ushort Month, ref ushort Day, ref ushort DOW)
	{
		global::System.DateTime d=DateTime.ToDateTime();Year=(ushort)d.Year;Month=(ushort)d.Month;Day=(ushort)d.Day;DOW=(ushort)((int)d.DayOfWeek+1);return global::System.DateTime.IsLeapYear(d.Year);
	}
	public static TTimeStamp DateTimeToTimeStamp(TDateTime DateTime)
	{
		global::System.DateTime d=DateTime.ToDateTime(); TTimeStamp r=TTimeStamp.CreateRecord();r.Date=(int)(d.Date-new global::System.DateTime(1,1,1)).TotalDays+1;r.Time=(int)d.TimeOfDay.TotalMilliseconds;return r;
	}
	private const int MSecsPerDay = 24 * 60 * 60 * 1000;
	private const int MaxTimeStampDate = 3652059; // 31-Dec-9999; Date = 1 is 01-Jan-0001.

	private static void ValidateTimeStamp(TTimeStamp TimeStamp)
	{
		if (TimeStamp.Date < 1 || TimeStamp.Date > MaxTimeStampDate ||
			TimeStamp.Time < 0 || TimeStamp.Time >= MSecsPerDay)
			throw new EConvertError("Invalid time stamp.");
	}

	public static TDateTime TimeStampToDateTime(TTimeStamp TimeStamp)
	{
		ValidateTimeStamp(TimeStamp);
		return new TDateTime(
			new global::System.DateTime(1, 1, 1)
				.AddDays(TimeStamp.Date - 1)
				.AddMilliseconds(TimeStamp.Time));
	}
	public static TTimeStamp MSecsToTimeStamp(long MSecs)
	{
		TTimeStamp r=TTimeStamp.CreateRecord(); r.Date=(int)(MSecs/86400000L); r.Time=(int)(MSecs%86400000L); return r;
	}
	public static long TimeStampToMSecs(TTimeStamp TimeStamp)
	{
		ValidateTimeStamp(TimeStamp);
		return checked((long)TimeStamp.Date * MSecsPerDay + TimeStamp.Time);
	}
	public static TDateTime FloatToDateTime(double Value)
	{
		if(Value<MinDateTime||Value>MaxDateTime) throw new EConvertError("Invalid TDateTime value."); return new TDateTime(Value);
	}
	public static bool TryFloatToDateTime(double Value, out TDateTime AResult)
	{
		if(Value<MinDateTime||Value>MaxDateTime){AResult=default;return false;} AResult=new TDateTime(Value);return true;
	}
	public static TDateTime EncodeTime(ushort Hour, ushort Min, ushort Sec, ushort MSec)
	{
		if(!TryEncodeTime(Hour,Min,Sec,MSec,out TDateTime t)) throw new EConvertError("Invalid time."); return t;
	}
	public static bool TryEncodeTime(ushort Hour, ushort Min, ushort Sec, ushort MSec, out TDateTime Time)
	{
		if(Hour>23||Min>59||Sec>59||MSec>999){Time=default;return false;} Time=new TDateTime((Hour*3600000L+Min*60000L+Sec*1000L+MSec)/86400000.0); return true;
	}
	public static void DecodeTime(TDateTime DateTime, out ushort Hour, out ushort Min, out ushort Sec, out ushort MSec)
	{
		global::System.DateTime d=DateTime.ToDateTime();Hour=(ushort)d.Hour;Min=(ushort)d.Minute;Sec=(ushort)d.Second;MSec=(ushort)d.Millisecond;
	}
	public static void DateTimeToSystemTime(TDateTime DateTime, ref TSystemTime SystemTime)
	{
		global::System.DateTime d=DateTime.ToDateTime();SystemTime.wYear=(ushort)d.Year;SystemTime.wMonth=(ushort)d.Month;SystemTime.wDay=(ushort)d.Day;SystemTime.wDayOfWeek=(ushort)d.DayOfWeek;SystemTime.wHour=(ushort)d.Hour;SystemTime.wMinute=(ushort)d.Minute;SystemTime.wSecond=(ushort)d.Second;SystemTime.wMilliseconds=(ushort)d.Millisecond;
	}
	public static TDateTime SystemTimeToDateTime(TSystemTime SystemTime)
	{
		if(!TrySystemTimeToDateTime(SystemTime,out TDateTime d)) throw new EConvertError("Invalid system time."); return d;
	}
	public static bool TrySystemTimeToDateTime(TSystemTime SystemTime, out TDateTime DateTime)
	{
		try{DateTime=new TDateTime(SystemTime.wYear,SystemTime.wMonth,SystemTime.wDay,SystemTime.wHour,SystemTime.wMinute,SystemTime.wSecond,SystemTime.wMilliseconds);return true;}catch{DateTime=default;return false;}
	}
	public static TDateTime Date()
	{
		return TDateTime.Today;
	}
	public static TDateTime Time()
	{
		return TDateTime.CurrentTime;
	}
	public static TDateTime Now()
	{
		return TDateTime.Now;
	}
	public static ushort DayOfWeek(TDateTime DateTime)
	{
		return (ushort)((int)DateTime.ToDateTime().DayOfWeek+1);
	}
	public static bool IsLeapYear(ushort Year)
	{
		return global::System.DateTime.IsLeapYear(Year);
	}
	public static TDateTime GetTime()
	{
		return Time();
	}
	public static ushort CurrentYear()
	{
		return (ushort)global::System.DateTime.Now.Year;
	}
	public static TDateTime IncMonth(TDateTime DateTime, int NumberOfMonths = 1)
	{
		return new TDateTime(DateTime.ToDateTime().AddMonths(NumberOfMonths));
	}
	public static void IncAMonth(ref ushort Year, ref ushort Month, ref ushort Day, int NumberOfMonths = 1)
	{
		global::System.DateTime d=new global::System.DateTime(Year,Month,global::System.Math.Min(Day,(ushort)global::System.DateTime.DaysInMonth(Year,Month))); d=d.AddMonths(NumberOfMonths); Year=(ushort)d.Year;Month=(ushort)d.Month;Day=(ushort)global::System.Math.Min(Day,(ushort)global::System.DateTime.DaysInMonth(d.Year,d.Month));
	}
	public static void ReplaceTime(ref TDateTime DateTime, TDateTime NewTime)
	{
		global::System.DateTime d=DateTime.ToDateTime().Date; DateTime=new TDateTime(d+NewTime.ToDateTime().TimeOfDay);
	}
	public static void ReplaceDate(ref TDateTime DateTime, TDateTime NewDate)
	{
		global::System.TimeSpan t=DateTime.ToDateTime().TimeOfDay; DateTime=new TDateTime(NewDate.ToDateTime().Date+t);
	}

/* Formatting */
	public static string Format(string Format, params TVarRec[] Args)
	{
		return DelphiFormatCore(Format, Args,
			CultureFromSettings(SysutilsInterface.FormatSettings));
	}
	public static string Format(string Format, TVarRec[] Args, TFormatSettings FormatSettings)
	{
		return DelphiFormatCore(Format,Args,CultureFromSettings(FormatSettings));
	}
	public static uint FormatBuf(UntypedPointer Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, params TVarRec[] Args)
	{
		PChar fmt=new PChar(Format);string f=fmt.Substring(0,global::System.Math.Min(fmt.Length,(int)FmtLen));string s=SysutilsInterface.Format(f,Args);PChar dst=new PChar(Buffer);int n=global::System.Math.Min(s.Length,(int)BufLen);for(int i=0;i<n;i++)dst[i]=s[i];if(n<(int)BufLen)dst[n]='\0';return (uint)n;
	}
	public static uint FormatBuf(PChar Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, params TVarRec[] Args)
	{
		PChar fmt=new PChar(Format);string f=fmt.Substring(0,global::System.Math.Min(fmt.Length,(int)FmtLen));string s=SysutilsInterface.Format(f,Args);int n=global::System.Math.Min(s.Length,(int)BufLen);for(int i=0;i<n;i++)Buffer[i]=s[i];if(n<(int)BufLen)Buffer[n]='\0';return (uint)n;
	}
	public static uint FormatBuf(PChar Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		PChar fmt=new PChar(Format);string f=fmt.Substring(0,global::System.Math.Min(fmt.Length,(int)FmtLen));string s=SysutilsInterface.Format(f,Args,AFormatSettings);int n=global::System.Math.Min(s.Length,(int)BufLen);for(int i=0;i<n;i++)Buffer[i]=s[i];if(n<(int)BufLen)Buffer[n]='\0';return (uint)n;
	}
	public static uint FormatBuf(ref string Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, params TVarRec[] Args)
	{
		PChar fmt=new PChar(Format);string f=fmt.Substring(0,global::System.Math.Min(fmt.Length,(int)FmtLen));string s=SysutilsInterface.Format(f,Args);int n=global::System.Math.Min(s.Length,(int)BufLen);Buffer=s.Substring(0,n);return (uint)n;
	}
	public static uint FormatBuf(ref string Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		PChar fmt=new PChar(Format);string f=fmt.Substring(0,global::System.Math.Min(fmt.Length,(int)FmtLen));string s=SysutilsInterface.Format(f,Args,AFormatSettings);int n=global::System.Math.Min(s.Length,(int)BufLen);Buffer=s.Substring(0,n);return (uint)n;
	}
	public static uint FormatBuf(UntypedPointer Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		PChar fmt=new PChar(Format);string f=fmt.Substring(0,global::System.Math.Min(fmt.Length,(int)FmtLen));string s=SysutilsInterface.Format(f,Args,AFormatSettings);PChar dst=new PChar(Buffer);int n=global::System.Math.Min(s.Length,(int)BufLen);for(int i=0;i<n;i++)dst[i]=s[i];if(n<(int)BufLen)dst[n]='\0';return (uint)n;
	}
	public static string WideFormat(string Format, params TVarRec[] Args)
	{
		return SysutilsInterface.Format(Format,Args);
	}
	public static string WideFormat(string Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		return SysutilsInterface.Format(Format,Args,AFormatSettings);
	}
	public static void WideFmtStr(ref string Result, string Format, params TVarRec[] Args)
	{
		Result=SysutilsInterface.Format(Format,Args);
	}
	public static void WideFmtStr(ref string Result, string Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		Result=SysutilsInterface.Format(Format,Args,AFormatSettings);
	}
	public static uint WideFormatBuf(UntypedPointer Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, params TVarRec[] Args)
	{
		return FormatBuf(Buffer,BufLen,Format,FmtLen,Args);
	}
	public static uint WideFormatBuf(UntypedPointer Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		return FormatBuf(Buffer,BufLen,Format,FmtLen,Args,AFormatSettings);
	}
	public static void FmtStr(ref string Result, string Format, params TVarRec[] Args)
	{
		Result=SysutilsInterface.Format(Format,Args);
	}
	public static void FmtStr(ref string Result, string Format, TVarRec[] Args, TFormatSettings FormatSettings)
	{
		Result=SysutilsInterface.Format(Format,Args,FormatSettings);
	}

/* String helpers */
	public static int CompareStr(string S1, string S2)
	{
		return string.Compare(S1??string.Empty,S2??string.Empty,StringComparison.Ordinal);
	}
	public static int CompareStr(string S1, string S2, TLocaleOptions LocaleOptions)
	{
		return LocaleOptions==TLocaleOptions.loInvariantLocale?string.Compare(S1??string.Empty,S2??string.Empty,StringComparison.Ordinal):CultureInfo.CurrentCulture.CompareInfo.Compare(S1??string.Empty,S2??string.Empty,CompareOptions.None);
	}
	public static int CompareText(string S1, string S2)
	{
		return string.Compare(S1??string.Empty,S2??string.Empty,StringComparison.CurrentCultureIgnoreCase);
	}
	public static int CompareText(string S1, string S2, TLocaleOptions LocaleOptions)
	{
		return LocaleOptions==TLocaleOptions.loInvariantLocale?string.Compare(S1??string.Empty,S2??string.Empty,StringComparison.OrdinalIgnoreCase):CultureInfo.CurrentCulture.CompareInfo.Compare(S1??string.Empty,S2??string.Empty,CompareOptions.IgnoreCase);
	}
	public static bool SameStr(string S1, string S2)
	{
		return CompareStr(S1,S2)==0;
	}
	public static bool SameStr(string S1, string S2, TLocaleOptions LocaleOptions)
	{
		return CompareStr(S1,S2,LocaleOptions)==0;
	}
	public static bool SameText(string S1, string S2)
	{
		return CompareText(S1,S2)==0;
	}
	public static bool SameText(string S1, string S2, TLocaleOptions LocaleOptions)
	{
		return CompareText(S1,S2,LocaleOptions)==0;
	}
	public static string UpperCase(string S)
	{
		return (S??string.Empty).ToUpperInvariant();
	}
	public static string UpperCase(string S, TLocaleOptions LocaleOptions)
	{
		return LocaleOptions==TLocaleOptions.loInvariantLocale?(S??string.Empty).ToUpperInvariant():(S??string.Empty).ToUpper(CultureInfo.CurrentCulture);
	}
	public static string LowerCase(string S)
	{
		return (S??string.Empty).ToLowerInvariant();
	}
	public static string LowerCase(string S, TLocaleOptions LocaleOptions)
	{
		return LocaleOptions==TLocaleOptions.loInvariantLocale?(S??string.Empty).ToLowerInvariant():(S??string.Empty).ToLower(CultureInfo.CurrentCulture);
	}
	public static string Trim(string S)
	{
		return (S??string.Empty).Trim();
	}
	public static string TrimLeft(string S)
	{
		return (S??string.Empty).TrimStart();
	}
	public static string TrimRight(string S)
	{
		return (S??string.Empty).TrimEnd();
	}
	public static string QuotedStr(string S)
	{
		return AnsiQuotedStr(S,'\'');
	}
	public static string AnsiQuotedStr(string S, char Quote)
	{
		string q=Quote.ToString(); return q+(S??string.Empty).Replace(q,q+q)+q;
	}
	public static string StringReplace(string S, string OldPattern, string NewPattern, TSet Flags)
	{
		S??=string.Empty; OldPattern??=string.Empty; NewPattern??=string.Empty;
		if(OldPattern.Length==0) return S;
		bool all=Flags!=null && Flags.Contains((int)TReplaceFlag.rfReplaceAll);
		bool ignore=Flags!=null && Flags.Contains((int)TReplaceFlag.rfIgnoreCase);
		StringComparison cmp=ignore?StringComparison.CurrentCultureIgnoreCase:StringComparison.Ordinal;
		int pos=S.IndexOf(OldPattern,cmp); if(pos<0)return S;
		TStringBuilder b=new TStringBuilder(); int start=0;
		while(pos>=0){b.Append(S.Substring(start,pos-start));b.Append(NewPattern);start=pos+OldPattern.Length;if(!all)break;pos=S.IndexOf(OldPattern,start,cmp);}
		b.Append(S.Substring(start)); return b.ToString();
	}
	public static int FindDelimiter(string Delimiters, string S, int StartIdx = 1)
	{
		if(string.IsNullOrEmpty(S)||string.IsNullOrEmpty(Delimiters)) return 0;
		int start=global::System.Math.Max(1,StartIdx)-1;
		for(int i=start;i<S.Length;i++) if(Delimiters.IndexOf(S[i])>=0)return i+1;
		return 0;
	}
	public static int AnsiPos(string Substr, string S)
	{
		int p=(S??string.Empty).IndexOf(Substr??string.Empty,StringComparison.CurrentCulture); return p<0?0:p+1;
	}
	public static string AnsiLowerCaseFileName(string S)
	{
		return (S??string.Empty).ToLowerInvariant();
	}
	public static string AnsiUpperCaseFileName(string S)
	{
		return (S??string.Empty).ToUpperInvariant();
	}
	public static int ByteLength(string S)
	{
		return global::System.Text.Encoding.Unicode.GetByteCount(S??string.Empty);
	}
	public static int ByteLength(AnsiString S)
	{
		return S==null?0:S.Length;
	}
	public static int CharLength(string S, int Index)
	{
		if(string.IsNullOrEmpty(S)||Index<1||Index>S.Length)return 0; int i=Index-1; return char.IsHighSurrogate(S[i])&&i+1<S.Length&&char.IsLowSurrogate(S[i+1])?2:1;
	}
	public static int NextCharIndex(string S, int Index)
	{
		return Index+CharLength(S,Index);
	}
	public static bool IsLeadChar(byte C)
	{
		return C >= 0xC2 && C <= 0xF4;
	}
	public static bool IsLeadChar(char C)
	{
		return char.IsHighSurrogate(C);
	}
	public static bool CharInSet(char C, TSet CharSet)
	{
		return CharSet!=null && C<=255 && CharSet.Contains((int)C);
	}
	public static TMbcsByteType ByteType(AnsiString S, int Index)
	{
		return TMbcsByteType.mbSingleByte;
	}
	public static TMbcsByteType ByteType(string S, int Index)
	{
		return TMbcsByteType.mbSingleByte;
	}
	public static TMbcsByteType StrByteType(PAnsiChar Str, uint Index)
	{
		return TMbcsByteType.mbSingleByte;
	}
	public static TMbcsByteType StrByteType(PChar Str, uint Index)
	{
		return TMbcsByteType.mbSingleByte;
	}
	public static int CharToElementIndex(AnsiString S, int Index)
	{
		return Index;
	}
	public static int CharToElementIndex(string S, int Index)
	{
		if(Index<=0)return 0; return StringInfo.ParseCombiningCharacters(S??string.Empty).TakeWhile(x=>x<Index-1).Count()+1;
	}
	public static int ElementToCharIndex(AnsiString S, int Index)
	{
		return Index;
	}
	public static int ElementToCharIndex(string S, int Index)
	{
		if(Index<=0)return 0; int[] a=StringInfo.ParseCombiningCharacters(S??string.Empty); return Index<=a.Length?a[Index-1]+1:(S??string.Empty).Length+1;
	}
	public static int ElementToCharLen(AnsiString S, int MaxLen)
	{
		return global::System.Math.Min(S==null?0:S.Length,global::System.Math.Max(0,MaxLen));
	}
	public static int ElementToCharLen(string S, int MaxLen)
	{
		if(MaxLen<=0)return 0; int[] a=StringInfo.ParseCombiningCharacters(S??string.Empty); return global::System.Math.Min(MaxLen,a.Length);
	}
	public static bool CompareMem(Pointer P1, Pointer P2, int Length)
	{
		if(Length<=0)return true;UntypedPointer a=P1,b=P2;if(a.IsNull()||b.IsNull())return a.IsNull()&&b.IsNull();for(int i=0;i<Length;i++)if(a[i]!=b[i])return false;return true;
	}
	public static int ByteToCharLen(string S, int MaxLen)
	{
		return global::System.Math.Min((S??string.Empty).Length,global::System.Math.Max(0,MaxLen/2));
	}
	public static int CharToByteLen(string S, int MaxLen)
	{
		return global::System.Math.Min((S??string.Empty).Length,global::System.Math.Max(0,MaxLen))*2;
	}
	public static int ByteToCharIndex(string S, int Index)
	{
		return Index<=0?0:((Index-1)/2)+1;
	}
	public static int CharToByteIndex(string S, int Index)
	{
		return Index<=0?0:(Index-1)*2+1;
	}
	public static int StrCharLength(PAnsiChar Str)
	{
		return Str.IsNull()||Str.Length==0?0:1;
	}
	public static int StrCharLength(PChar Str)
	{
		if(Str.IsNull()||Str.Length==0)return 0; return char.IsHighSurrogate(Str[0])&&Str.Length>1&&char.IsLowSurrogate(Str[1])?2:1;
	}
	public static PAnsiChar StrNextChar(PAnsiChar Str)
	{
		return Str.IsNull()?default:Str+StrCharLength(Str);
	}
	public static PChar StrNextChar(PChar Str)
	{
		return Str.IsNull()?default:Str+StrCharLength(Str);
	}
	public static uint StrLen(PAnsiChar Str)
	{
		return Str.IsNull()?0u:(uint)Str.Length;
	}
	public static uint StrLen(PChar Str)
	{
		return Str.IsNull()?0u:(uint)Str.Length;
	}
	public static PAnsiChar StrEnd(PAnsiChar Str)
	{
		return Str.IsNull()?default:Str+Str.Length;
	}
	public static PChar StrEnd(PChar Str)
	{
		return Str.IsNull()?default:Str+Str.Length;
	}
	public static PAnsiChar StrMove(PAnsiChar Dest, PAnsiChar Source, uint Count)
	{
		if(Dest.IsNull()||Source.IsNull())return Dest;byte[] t=new byte[Count];for(int i=0;i<t.Length;i++)t[i]=Source[i];for(int i=0;i<t.Length;i++)Dest[i]=t[i];return Dest;
	}
	public static PChar StrMove(PChar Dest, PChar Source, uint Count)
	{
		if(Dest.IsNull()||Source.IsNull())return Dest;char[] t=new char[Count];for(int i=0;i<t.Length;i++)t[i]=Source[i];for(int i=0;i<t.Length;i++)Dest[i]=t[i];return Dest;
	}
	public static PAnsiChar StrECopy(PAnsiChar Dest, PAnsiChar Source)
	{
		StrCopy(Dest,Source);return Dest+(Source.IsNull()?0:Source.Length);
	}
	public static PChar StrECopy(PChar Dest, PChar Source)
	{
		StrCopy(Dest,Source);return Dest+(Source.IsNull()?0:Source.Length);
	}
	public static PAnsiChar StrLCat(PAnsiChar Dest, PAnsiChar Source, uint MaxLen)
	{
		int dl=Dest.IsNull()?0:Dest.Length;int n=global::System.Math.Min(Source.IsNull()?0:Source.Length,global::System.Math.Max(0,(int)MaxLen-dl));for(int i=0;i<n;i++)Dest[dl+i]=Source[i];Dest[dl+n]=0;return Dest;
	}
	public static PChar StrLCat(PChar Dest, PChar Source, uint MaxLen)
	{
		int dl=Dest.IsNull()?0:Dest.Length;int n=global::System.Math.Min(Source.IsNull()?0:Source.Length,global::System.Math.Max(0,(int)MaxLen-dl));for(int i=0;i<n;i++)Dest[dl+i]=Source[i];Dest[dl+n]='\0';return Dest;
	}
	public static void StrDispose(PAnsiChar Str)
	{
		if(!Str.IsNull())Str.FreeMemory();
	}
	public static void StrDispose(PChar Str)
	{
		if(!Str.IsNull())Str.FreeMemory();
	}
	public static PAnsiChar StrFmt(PAnsiChar Buffer, PAnsiChar Format, params TVarRec[] Args)
	{
		Buffer.Assign(SysutilsInterface.Format(Format.ToString(),Args));return Buffer;
	}
	public static PChar StrFmt(PChar Buffer, PChar Format, params TVarRec[] Args)
	{
		Buffer.Assign(SysutilsInterface.Format(Format.ToString(),Args));return Buffer;
	}
	public static PAnsiChar StrFmt(PAnsiChar Buffer, PAnsiChar Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		Buffer.Assign(SysutilsInterface.Format(Format.ToString(),Args,AFormatSettings));return Buffer;
	}
	public static PChar StrFmt(PChar Buffer, PChar Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		Buffer.Assign(SysutilsInterface.Format(Format.ToString(),Args,AFormatSettings));return Buffer;
	}
	public static PAnsiChar StrLFmt(PAnsiChar Buffer, uint MaxBufLen, PAnsiChar Format, params TVarRec[] Args)
	{
		string s=SysutilsInterface.Format(Format.ToString(),Args);Buffer.Assign(s.Substring(0,global::System.Math.Min(s.Length,(int)MaxBufLen)));return Buffer;
	}
	public static PChar StrLFmt(PChar Buffer, uint MaxBufLen, PChar Format, params TVarRec[] Args)
	{
		string s=SysutilsInterface.Format(Format.ToString(),Args);Buffer.Assign(s.Substring(0,global::System.Math.Min(s.Length,(int)MaxBufLen)));return Buffer;
	}
	public static PAnsiChar StrLFmt(PAnsiChar Buffer, uint MaxBufLen, PAnsiChar Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		string s=SysutilsInterface.Format(Format.ToString(),Args,AFormatSettings);Buffer.Assign(s.Substring(0,global::System.Math.Min(s.Length,(int)MaxBufLen)));return Buffer;
	}
	public static PChar StrLFmt(PChar Buffer, uint MaxBufLen, PChar Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		string s=SysutilsInterface.Format(Format.ToString(),Args,AFormatSettings);Buffer.Assign(s.Substring(0,global::System.Math.Min(s.Length,(int)MaxBufLen)));return Buffer;
	}
	public static PAnsiChar StrCopy(PAnsiChar Dest, PAnsiChar Source)
	{
		if(Dest.IsNull())return Dest;Dest.Assign(Source.IsNull()?string.Empty:Source.ToString());return Dest;
	}
	public static PChar StrCopy(PChar Dest, PChar Source)
	{
		if(Dest.IsNull())return Dest;Dest.Assign(Source.IsNull()?string.Empty:Source.ToString());return Dest;
	}
	public static PAnsiChar StrLCopy(PAnsiChar Dest, PAnsiChar Source, uint MaxLen)
	{
		if(Dest.IsNull())return Dest;Dest.Assign(Source.IsNull()?string.Empty:Source.Substring(0,global::System.Math.Min(Source.Length,(int)MaxLen)));return Dest;
	}
	public static PChar StrLCopy(PChar Dest, PChar Source, uint MaxLen)
	{
		if(Dest.IsNull())return Dest;Dest.Assign(Source.IsNull()?string.Empty:Source.Substring(0,global::System.Math.Min(Source.Length,(int)MaxLen)));return Dest;
	}
	public static PAnsiChar StrPCopy(PAnsiChar Dest, AnsiString Source)
	{
		if(Dest.IsNull())return Dest;Dest.Assign(Source);return Dest;
	}
	public static PChar StrPCopy(PChar Dest, string Source)
	{
		if(Dest.IsNull())return Dest;Dest.Assign(Source);return Dest;
	}
	public static PAnsiChar StrPLCopy(PAnsiChar Dest, AnsiString Source, uint MaxLen)
	{
		if(Dest.IsNull())return Dest;AnsiString s=Source??AnsiString.Empty;Dest.Assign(s.Substring(0,global::System.Math.Min(s.Length,(int)MaxLen)));return Dest;
	}
	public static PChar StrPLCopy(PChar Dest, string Source, uint MaxLen)
	{
		if(Dest.IsNull())return Dest;string s=Source??string.Empty;Dest.Assign(s.Substring(0,global::System.Math.Min(s.Length,(int)MaxLen)));return Dest;
	}
	public static PAnsiChar StrCat(PAnsiChar Dest, PAnsiChar Source)
	{
		return StrLCat(Dest,Source,uint.MaxValue);
	}
	public static PChar StrCat(PChar Dest, PChar Source)
	{
		return StrLCat(Dest,Source,uint.MaxValue);
	}
	public static PAnsiChar StrScan(PAnsiChar Str, byte Chr)
	{
		if(Str.IsNull())return default;for(int i=0;i<=Str.Length;i++)if(Str[i]==Chr)return Str+i;return default;
	}
	public static PChar StrScan(PChar Str, char Chr)
	{
		if(Str.IsNull())return default;for(int i=0;i<=Str.Length;i++)if(Str[i]==Chr)return Str+i;return default;
	}
	public static PAnsiChar StrRScan(PAnsiChar Str, byte Chr)
	{
		if(Str.IsNull())return default;for(int i=Str.Length;i>=0;i--)if(Str[i]==Chr)return Str+i;return default;
	}
	public static PChar StrRScan(PChar Str, char Chr)
	{
		if(Str.IsNull())return default;for(int i=Str.Length;i>=0;i--)if(Str[i]==Chr)return Str+i;return default;
	}
	public static PAnsiChar StrPos(PAnsiChar Str1, PAnsiChar Str2)
	{
		if(Str1.IsNull()||Str2.IsNull())return default;string a=Str1.ToString(),b=Str2.ToString();int i=a.IndexOf(b,StringComparison.Ordinal);return i<0?default:Str1+i;
	}
	public static PChar StrPos(PChar Str1, PChar Str2)
	{
		if(Str1.IsNull()||Str2.IsNull())return default;int i=Str1.ToString().IndexOf(Str2.ToString(),StringComparison.Ordinal);return i<0?default:Str1+i;
	}
	public static PAnsiChar StrUpper(PAnsiChar Str)
	{
		if(!Str.IsNull())Str.Assign(Str.ToString().ToUpperInvariant());return Str;
	}
	public static PChar StrUpper(PChar Str)
	{
		if(!Str.IsNull())Str.Assign(Str.ToString().ToUpperInvariant());return Str;
	}
	public static PAnsiChar StrLower(PAnsiChar Str)
	{
		if(!Str.IsNull())Str.Assign(Str.ToString().ToLowerInvariant());return Str;
	}
	public static PChar StrLower(PChar Str)
	{
		if(!Str.IsNull())Str.Assign(Str.ToString().ToLowerInvariant());return Str;
	}
	public static AnsiString StrPas(PAnsiChar Str)
	{
		return Str.IsNull()?AnsiString.Empty:Str.ToAnsiString();
	}
	public static string StrPas(PChar Str)
	{
		return Str.IsNull()?string.Empty:Str.ToString();
	}
	public static PAnsiChar StrNew(PAnsiChar Str)
	{
		return Str.IsNull()?default:new PAnsiChar(Str.ToAnsiString());
	}
	public static PChar StrNew(PChar Str)
	{
		return Str.IsNull()?default:new PChar(Str.ToString());
	}
	public static uint StrBufSize(PAnsiChar Str)
	{
		return Str.IsNull()?0u:(uint)(Str.Length+1);
	}
	public static uint StrBufSize(PChar Str)
	{
		return Str.IsNull()?0u:(uint)(Str.Length+1);
	}
	public static PChar StrAlloc(uint Size)
	{
		return Size==0?default:new PChar(checked((int)Size),true);
	}
	public static int StrComp(PAnsiChar Str1, PAnsiChar Str2)
	{
		return string.Compare(PAnsiString(Str1),PAnsiString(Str2),StringComparison.Ordinal);
	}
	public static int StrComp(PChar Str1, PChar Str2)
	{
		return string.Compare(PCharString(Str1),PCharString(Str2),StringComparison.Ordinal);
	}
	public static int StrIComp(PAnsiChar Str1, PAnsiChar Str2)
	{
		return string.Compare(PAnsiString(Str1),PAnsiString(Str2),StringComparison.OrdinalIgnoreCase);
	}
	public static int StrIComp(PChar Str1, PChar Str2)
	{
		return string.Compare(PCharString(Str1),PCharString(Str2),StringComparison.OrdinalIgnoreCase);
	}
	public static int StrLComp(PAnsiChar Str1, PAnsiChar Str2, uint MaxLen)
	{
		return string.Compare(PAnsiString(Str1),0,PAnsiString(Str2),0,(int)MaxLen,StringComparison.Ordinal);
	}
	public static int StrLComp(PChar Str1, PChar Str2, uint MaxLen)
	{
		return string.Compare(PCharString(Str1),0,PCharString(Str2),0,(int)MaxLen,StringComparison.Ordinal);
	}
	public static int StrLIComp(PAnsiChar Str1, PAnsiChar Str2, uint MaxLen)
	{
		return string.Compare(PAnsiString(Str1),0,PAnsiString(Str2),0,(int)MaxLen,StringComparison.OrdinalIgnoreCase);
	}
	public static int StrLIComp(PChar Str1, PChar Str2, uint MaxLen)
	{
		return string.Compare(PCharString(Str1),0,PCharString(Str2),0,(int)MaxLen,StringComparison.OrdinalIgnoreCase);
	}
	public static PAnsiChar TextPos(PAnsiChar Str, PAnsiChar SubStr)
	{
		if(Str.IsNull()||SubStr.IsNull())return default;int i=Str.ToString().IndexOf(SubStr.ToString(),StringComparison.CurrentCultureIgnoreCase);return i<0?default:Str+i;
	}
	public static PChar TextPos(PChar Str, PChar SubStr)
	{
		if(Str.IsNull()||SubStr.IsNull())return default;int i=Str.ToString().IndexOf(SubStr.ToString(),StringComparison.CurrentCultureIgnoreCase);return i<0?default:Str+i;
	}
	public static uint HashName(PAnsiChar Name)
	{
		uint h=0;if(Name.IsNull())return 0;for(int i=0;i<Name.Length;i++){h=(h<<4)+Name[i];uint g=h&0xF0000000u;if(g!=0){h^=g>>24;h&=~g;}}return h;
	}
	public static int AnsiStrComp(PAnsiChar S1, PAnsiChar S2)
	{
		return StrComp(S1,S2);
	}
	public static int AnsiStrComp(PChar S1, PChar S2)
	{
		return StrComp(S1,S2);
	}
	public static int AnsiStrIComp(PAnsiChar S1, PAnsiChar S2)
	{
		return StrIComp(S1,S2);
	}
	public static int AnsiStrIComp(PChar S1, PChar S2)
	{
		return StrIComp(S1,S2);
	}
	public static int AnsiStrLComp(PAnsiChar S1, PAnsiChar S2, uint MaxLen)
	{
		return StrLComp(S1,S2,MaxLen);
	}
	public static int AnsiStrLComp(PChar S1, PChar S2, uint MaxLen)
	{
		return StrLComp(S1,S2,MaxLen);
	}
	public static int AnsiStrLIComp(PAnsiChar S1, PAnsiChar S2, uint MaxLen)
	{
		return StrLIComp(S1,S2,MaxLen);
	}
	public static int AnsiStrLIComp(PChar S1, PChar S2, uint MaxLen)
	{
		return StrLIComp(S1,S2,MaxLen);
	}
	public static PAnsiChar AnsiStrUpper(PAnsiChar Str)
	{
		return StrUpper(Str);
	}
	public static PChar AnsiStrUpper(PChar Str)
	{
		return StrUpper(Str);
	}
	public static PAnsiChar AnsiStrLower(PAnsiChar Str)
	{
		return StrLower(Str);
	}
	public static PChar AnsiStrLower(PChar Str)
	{
		return StrLower(Str);
	}
	public static PAnsiChar AnsiStrPos(PAnsiChar Str, PAnsiChar SubStr)
	{
		return StrPos(Str,SubStr);
	}
	public static PChar AnsiStrPos(PChar Str, PChar SubStr)
	{
		return StrPos(Str,SubStr);
	}
	public static PAnsiChar AnsiStrScan(PAnsiChar Str, byte Chr)
	{
		return StrScan(Str,Chr);
	}
	public static PChar AnsiStrScan(PChar Str, char Chr)
	{
		return StrScan(Str,Chr);
	}
	public static PAnsiChar AnsiStrRScan(PAnsiChar Str, byte Chr)
	{
		return StrRScan(Str,Chr);
	}
	public static PChar AnsiStrRScan(PChar Str, char Chr)
	{
		return StrRScan(Str,Chr);
	}
	public static PAnsiChar AnsiStrLastChar(PAnsiChar P)
	{
		return P.IsNull()||P.Length==0?P:P+(P.Length-1);
	}
	public static PChar AnsiStrLastChar(PChar P)
	{
		if(P.IsNull()||P.Length==0)return P;int i=P.Length-1;if(i>0&&char.IsLowSurrogate(P[i])&&char.IsHighSurrogate(P[i-1]))i--;return P+i;
	}
	public static PChar AnsiLastChar(string S)
	{
		if(string.IsNullOrEmpty(S))return default;int i=S.Length-1;if(i>0&&char.IsLowSurrogate(S[i])&&char.IsHighSurrogate(S[i-1]))i--;return new PChar(S,i);
	}
	public static AnsiString AnsiExtractQuotedStr(ref PAnsiChar Src, byte Quote)
	{
		if(Src.IsNull()||Src.Length==0||Src[0]!=Quote)return AnsiString.Empty;List<byte> b=new List<byte>();int i=1;while(i<Src.Length){byte c=Src[i++];if(c==Quote){if(i<Src.Length&&Src[i]==Quote){b.Add(Quote);i++;continue;}break;}b.Add(c);}Src=Src+i;return AnsiString.FromBytes(b.ToArray(),Src.CodePage);
	}
	public static string AnsiExtractQuotedStr(ref PChar Src, char Quote)
	{
		if(Src.IsNull()||Src.Length==0||Src[0]!=Quote)return string.Empty;global::System.Text.StringBuilder b=new global::System.Text.StringBuilder();int i=1;while(i<Src.Length){char c=Src[i++];if(c==Quote){if(i<Src.Length&&Src[i]==Quote){b.Append(Quote);i++;continue;}break;}b.Append(c);}Src=Src+i;return b.ToString();
	}
	public static string AnsiUpperCase(string S)
	{
		return (S??string.Empty).ToUpper(CultureInfo.CurrentCulture);
	}
	public static string AnsiLowerCase(string S)
	{
		return (S??string.Empty).ToLower(CultureInfo.CurrentCulture);
	}
	public static int AnsiCompareStr(string S1, string S2)
	{
		return CultureInfo.CurrentCulture.CompareInfo.Compare(S1??string.Empty,S2??string.Empty,CompareOptions.None);
	}
	public static int AnsiCompareText(string S1, string S2)
	{
		return CultureInfo.CurrentCulture.CompareInfo.Compare(S1??string.Empty,S2??string.Empty,CompareOptions.IgnoreCase);
	}
	public static bool AnsiSameStr(string S1, string S2)
	{
		return AnsiCompareStr(S1,S2)==0;
	}
	public static bool AnsiSameText(string S1, string S2)
	{
		return AnsiCompareText(S1,S2)==0;
	}
	public static string AnsiDequotedStr(string S, char AQuote)
	{
		S??=string.Empty;
		if(S.Length>=2 && S[0]==AQuote && S[S.Length-1]==AQuote)
			return S.Substring(1,S.Length-2).Replace(new string(AQuote,2),AQuote.ToString());
		return S;
	}
	public static string AdjustLineBreaks(string S, TTextLineBreakStyle Style = TTextLineBreakStyle.tlbsCRLF)
	{
		string nl=Style==TTextLineBreakStyle.tlbsLF?"\n":"\r\n";
		string v=(S??string.Empty).Replace("\r\n","\n").Replace("\r","\n");
		return v.Replace("\n",nl);
	}
	public static bool IsValidIdent(string Ident, bool AllowDots = false)
	{
		if(string.IsNullOrEmpty(Ident)) return false;
		string[] parts=AllowDots?Ident.Split('.'):new[]{Ident};
		foreach(string p in parts){if(p.Length==0||!(char.IsLetter(p[0])||p[0]=='_'))return false;for(int i=1;i<p.Length;i++)if(!(char.IsLetterOrDigit(p[i])||p[i]=='_'))return false;}
		return true;
	}
	public static string WrapText(string Line, string BreakStr, TSet BreakChars, int MaxCol)
	{
		if(string.IsNullOrEmpty(Line)||MaxCol<=0)return Line??string.Empty;
		BreakStr??=Environment.NewLine; TStringBuilder r=new TStringBuilder(); int col=0,last=0;
		for(int i=0;i<Line.Length;i++){char c=Line[i];bool br=BreakChars!=null&&c<=255&&BreakChars.Contains((int)c);if(col>=MaxCol&&br){r.Append(Line.Substring(last,i-last));r.Append(BreakStr);last=i+1;col=0;}else col++;}
		r.Append(Line.Substring(last));return r.ToString();
	}
	public static string WrapText(string Line, int MaxCol = 45)
	{
		return WrapText(Line,Environment.NewLine,new TSet()<<32<<9,MaxCol);
	}
	public static string WideUpperCase(string S)
	{
		return (S??string.Empty).ToUpperInvariant();
	}
	public static string WideLowerCase(string S)
	{
		return (S??string.Empty).ToLowerInvariant();
	}
	public static int WideCompareStr(string S1, string S2)
	{
		return string.Compare(S1??string.Empty,S2??string.Empty,StringComparison.Ordinal);
	}
	public static int WideCompareText(string S1, string S2)
	{
		return string.Compare(S1??string.Empty,S2??string.Empty,StringComparison.OrdinalIgnoreCase);
	}
	public static bool WideSameStr(string S1, string S2)
	{
		return WideCompareStr(S1,S2)==0;
	}
	public static bool WideSameText(string S1, string S2)
	{
		return WideCompareText(S1,S2)==0;
	}
	public static void AppendStr(ref string Dest, string S)
	{
		Dest=(Dest??string.Empty)+(S??string.Empty);
	}

/* Date and time conversion */
	public static void DateTimeToString(ref string Result, string Format, TDateTime DateTime)
	{
		Result = FormatDateTime(Format, DateTime);
	}
	public static void DateTimeToString(ref string Result, string Format, TDateTime DateTime, TFormatSettings AFormatSettings)
	{
		Result = FormatDateTime(Format, DateTime, AFormatSettings);
	}
	public static string DateToStr(TDateTime DateTime)
	{
		return DelphiDateTimeFormatCore(SysutilsInterface.FormatSettings.ShortDateFormat, DateTime, SysutilsInterface.FormatSettings);
	}
	public static string DateToStr(TDateTime DateTime, TFormatSettings FormatSettings)
	{
		return DelphiDateTimeFormatCore(FormatSettings.ShortDateFormat, DateTime, FormatSettings);
	}
	public static string TimeToStr(TDateTime DateTime)
	{
		return DelphiDateTimeFormatCore(SysutilsInterface.FormatSettings.LongTimeFormat, DateTime, SysutilsInterface.FormatSettings);
	}
	public static string TimeToStr(TDateTime DateTime, TFormatSettings FormatSettings)
	{
		return DelphiDateTimeFormatCore(FormatSettings.LongTimeFormat, DateTime, FormatSettings);
	}
	public static string DateTimeToStr(TDateTime DateTime)
	{
		return DelphiDateTimeFormatCore("c", DateTime, SysutilsInterface.FormatSettings);
	}
	public static string DateTimeToStr(TDateTime DateTime, TFormatSettings FormatSettings)
	{
		return DelphiDateTimeFormatCore("c", DateTime, FormatSettings);
	}
	public static TDateTime StrToDate(string S)
	{
		if(!TryStrToDate(S,out TDateTime v))throw new EConvertError("Invalid date/time: "+S);return v;
	}
	public static TDateTime StrToDate(string S, TFormatSettings FormatSettings)
	{
		if(!TryStrToDate(S,out TDateTime v,FormatSettings))throw new EConvertError("Invalid date/time: "+S);return v;
	}
	public static TDateTime StrToDateDef(string S, TDateTime Default)
	{
		return TryStrToDate(S,out TDateTime v)?v:Default;
	}
	public static TDateTime StrToDateDef(string S, TDateTime Default, TFormatSettings FormatSettings)
	{
		return TryStrToDate(S,out TDateTime v,FormatSettings)?v:Default;
	}
	public static TDateTime StrToTime(string S)
	{
		if(!TryStrToTime(S,out TDateTime v))throw new EConvertError("Invalid date/time: "+S);return v;
	}
	public static TDateTime StrToTime(string S, TFormatSettings FormatSettings)
	{
		if(!TryStrToTime(S,out TDateTime v,FormatSettings))throw new EConvertError("Invalid date/time: "+S);return v;
	}
	public static TDateTime StrToTimeDef(string S, TDateTime Default)
	{
		return TryStrToTime(S,out TDateTime v)?v:Default;
	}
	public static TDateTime StrToTimeDef(string S, TDateTime Default, TFormatSettings FormatSettings)
	{
		return TryStrToTime(S,out TDateTime v,FormatSettings)?v:Default;
	}
	public static TDateTime StrToDateTime(string S)
	{
		if(!TryStrToDateTime(S,out TDateTime v))throw new EConvertError("Invalid date/time: "+S);return v;
	}
	public static TDateTime StrToDateTime(string S, TFormatSettings FormatSettings)
	{
		if(!TryStrToDateTime(S,out TDateTime v,FormatSettings))throw new EConvertError("Invalid date/time: "+S);return v;
	}
	public static TDateTime StrToDateTimeDef(string S, TDateTime Default)
	{
		return TryStrToDateTime(S,out TDateTime v)?v:Default;
	}
	public static TDateTime StrToDateTimeDef(string S, TDateTime Default, TFormatSettings FormatSettings)
	{
		return TryStrToDateTime(S,out TDateTime v,FormatSettings)?v:Default;
	}
	public static bool TryStrToDate(string S, out TDateTime Value)
	{
		Value=default; if(global::System.DateTime.TryParse(S,CultureInfo.CurrentCulture,DateTimeStyles.AllowWhiteSpaces,out global::System.DateTime d)){Value=new TDateTime(d.Date);return true;}return false;
	}
	public static bool TryStrToDate(string S, out TDateTime Value, TFormatSettings FormatSettings)
	{
		Value=default;if(global::System.DateTime.TryParse(S,CultureFromSettings(FormatSettings),DateTimeStyles.AllowWhiteSpaces,out global::System.DateTime d)){Value=new TDateTime(d.Date);return true;}return false;
	}
	public static bool TryStrToTime(string S, out TDateTime Value)
	{
		Value=default; if(global::System.DateTime.TryParse(S,CultureInfo.CurrentCulture,DateTimeStyles.AllowWhiteSpaces,out global::System.DateTime d)){Value=new TDateTime(d.TimeOfDay.TotalDays);return true;}return false;
	}
	public static bool TryStrToTime(string S, out TDateTime Value, TFormatSettings FormatSettings)
	{
		Value=default;if(global::System.DateTime.TryParse(S,CultureFromSettings(FormatSettings),DateTimeStyles.AllowWhiteSpaces,out global::System.DateTime d)){Value=new TDateTime(d.TimeOfDay.TotalDays);return true;}return false;
	}
	public static bool TryStrToDateTime(string S, out TDateTime Value)
	{
		Value=default; if(global::System.DateTime.TryParse(S,CultureInfo.CurrentCulture,DateTimeStyles.AllowWhiteSpaces,out global::System.DateTime d)){Value=new TDateTime(d);return true;}return false;
	}
	public static bool TryStrToDateTime(string S, out TDateTime Value, TFormatSettings FormatSettings)
	{
		Value=default;if(global::System.DateTime.TryParse(S,CultureFromSettings(FormatSettings),DateTimeStyles.AllowWhiteSpaces,out global::System.DateTime d)){Value=new TDateTime(d);return true;}return false;
	}
	public static string FormatDateTime(string Format, TDateTime DateTime)
	{
		return DelphiDateTimeFormatCore(Format, DateTime, SysutilsInterface.FormatSettings);
	}
	public static string FormatDateTime(string Format, TDateTime DateTime, TFormatSettings FormatSettings)
	{
		return DelphiDateTimeFormatCore(Format, DateTime, FormatSettings);
	}

/* File-name helpers */
	public static string ChangeFileExt(string FileName, string Extension)
	{
		return Path.ChangeExtension(FileName??string.Empty,Extension??string.Empty)??string.Empty;
	}
	public static string ChangeFilePath(string FileName, string Path)
	{
		return IncludeTrailingPathDelimiter(Path??string.Empty)+ExtractFileName(FileName);
	}
	public static string ExtractFileDir(string FileName)
	{
		return Path.GetDirectoryName(FileName??string.Empty)??string.Empty;
	}
	public static string ExtractFileDrive(string FileName)
	{
		return Path.GetPathRoot(FileName??string.Empty)?.TrimEnd(Path.DirectorySeparatorChar,Path.AltDirectorySeparatorChar)??string.Empty;
	}
	public static string ExtractFileExt(string FileName)
	{
		return Path.GetExtension(FileName??string.Empty)??string.Empty;
	}
	public static string ExtractFileName(string FileName)
	{
		return Path.GetFileName(FileName??string.Empty)??string.Empty;
	}
	public static string ExtractFilePath(string FileName)
	{
		string d=Path.GetDirectoryName(FileName??string.Empty)??string.Empty; return string.IsNullOrEmpty(d)?string.Empty:IncludeTrailingPathDelimiter(d);
	}
	public static string IncludeTrailingPathDelimiter(string S)
	{
		if(string.IsNullOrEmpty(S))return PathDelim.ToString(); char c=S[S.Length-1]; return c=='\\'||c=='/'?S:S+PathDelim;
	}
	public static string IncludeTrailingBackslash(string S)
	{
		return IncludeTrailingPathDelimiter(S);
	}
	public static string ExcludeTrailingPathDelimiter(string S)
	{
		if(string.IsNullOrEmpty(S))return string.Empty; return S.TrimEnd('\\','/');
	}
	public static string ExcludeTrailingBackslash(string S)
	{
		return ExcludeTrailingPathDelimiter(S);
	}
	public static string ExpandFileName(string FileName)
	{
		try{return Path.GetFullPath(FileName??string.Empty);}catch{return FileName??string.Empty;}
	}
	public static string ExpandFileNameCase(string FileName, out TFilenameCaseMatch MatchFound)
	{
		string r=ExpandFileName(FileName);MatchFound=(File.Exists(r)||Directory.Exists(r))?TFilenameCaseMatch.mkExactMatch:TFilenameCaseMatch.mkNone;return r;
	}
	public static string ExpandUNCFileName(string FileName)
	{
		return ExpandFileName(FileName);
	}
	public static string ExtractRelativePath(string BaseName, string DestName)
	{
		try
		{
			string baseDir=Path.GetDirectoryName(Path.GetFullPath(BaseName??string.Empty))??Directory.GetCurrentDirectory();
			return Path.GetRelativePath(baseDir,Path.GetFullPath(DestName??string.Empty));
		}
		catch{return DestName??string.Empty;}
	}
	public static string ExtractShortPathName(string FileName)
	{
		return FileName??string.Empty;
	}
	public static bool IsPathDelimiter(string S, int Index)
	{
		return !string.IsNullOrEmpty(S)&&Index>=1&&Index<=S.Length&&(S[Index-1]=='\\'||S[Index-1]=='/');
	}
	public static bool IsDelimiter(string Delimiters, string S, int Index)
	{
		return !string.IsNullOrEmpty(S)&&Index>=1&&Index<=S.Length&&(Delimiters??string.Empty).IndexOf(S[Index-1])>=0;
	}
	public static int LastDelimiter(string Delimiters, string S)
	{
		if(string.IsNullOrEmpty(S))return 0; for(int i=S.Length-1;i>=0;i--)if((Delimiters??string.Empty).IndexOf(S[i])>=0)return i+1;return 0;
	}
	public static bool IsRelativePath(string Path)
	{
		return !global::System.IO.Path.IsPathRooted(Path??string.Empty);
	}
	public static string FileSearch(string Name, string DirList)
	{
		if(File.Exists(Name))return Name;
		foreach(string d in (DirList??string.Empty).Split(Path.PathSeparator))
		{
			if(string.IsNullOrWhiteSpace(d))continue;
			string p=Path.Combine(d.Trim(),Name??string.Empty);
			if(File.Exists(p))return p;
		}
		return string.Empty;
	}
	public static bool SameFileName(string S1, string S2)
	{
		return string.Equals(ExpandFileName(S1),ExpandFileName(S2),RuntimeInformation.IsOSPlatform(OSPlatform.Windows)?StringComparison.OrdinalIgnoreCase:StringComparison.Ordinal);
	}
	public static int AnsiCompareFileName(string S1, string S2, bool CheckVolumeCase = false)
	{
		return string.Compare(S1??string.Empty,S2??string.Empty,RuntimeInformation.IsOSPlatform(OSPlatform.Windows)?StringComparison.OrdinalIgnoreCase:StringComparison.Ordinal);
	}

/* File and directory helpers */
	public static bool FileExists(string FileName, bool FollowLink = true)
	{
		return File.Exists(FileName);
	}
	public static bool DirectoryExists(string Directory, bool FollowLink = true)
	{
		return global::System.IO.Directory.Exists(Directory);
	}
	public static bool ForceDirectories(string Dir)
	{
		try{if(string.IsNullOrEmpty(Dir))return false;Directory.CreateDirectory(Dir);return true;}catch{return false;}
	}
	public static int FindFirst(string Path, int Attr, ref TSearchRec F)
	{
		try
		{
			string dir=global::System.IO.Path.GetDirectoryName(Path);
			if(string.IsNullOrEmpty(dir))dir=Directory.GetCurrentDirectory();
			string pattern=global::System.IO.Path.GetFileName(Path); if(string.IsNullOrEmpty(pattern))pattern="*";
			IEnumerator<string> e=Directory.EnumerateFileSystemEntries(dir,pattern).GetEnumerator();
			while(e.MoveNext())
			{
				int a=FileGetAttr(e.Current);
				if(Attr==faAnyFile || (a&Attr)!=0 || (a&faDirectory)==0)
				{
					uint h; lock(FFindLock){h=FNextFindHandle++;FFindEnumerators[h]=e;}
					F.FindHandle=h; F.ExcludeAttr=~Attr; FillSearchRec(ref F,e.Current); return 0;
				}
			}
			e.Dispose();return -1;
		}
		catch{return -1;}
	}
	public static int FindNext(ref TSearchRec F)
	{
		lock(FFindLock)
		{
			if(!FFindEnumerators.TryGetValue(F.FindHandle,out IEnumerator<string> e))return -1;
			try
			{
				while(e.MoveNext())
				{
					int a=FileGetAttr(e.Current);
					if((a&F.ExcludeAttr)==0 || (a&faDirectory)==0){FillSearchRec(ref F,e.Current);return 0;}
				}
				return -1;
			}
			catch{return -1;}
		}
	}
	public static void FindClose(ref TSearchRec F)
	{
		lock(FFindLock){if(FFindEnumerators.TryGetValue(F.FindHandle,out IEnumerator<string> e)){e.Dispose();FFindEnumerators.Remove(F.FindHandle);}}F.FindHandle=0;
	}
	public static bool FileGetDateTimeInfo(string FileName, out TDateTimeInfoRec DateTime, bool FollowLink = true)
	{
		DateTime=TDateTimeInfoRec.CreateRecord();
		try
		{
			FileInfo i=new FileInfo(FileName);
			DateTime.Data.dwFileAttributes=(uint)i.Attributes;
			DateTime.Data.ftCreationTime=ToFileTime(i.CreationTime);
			DateTime.Data.ftLastAccessTime=ToFileTime(i.LastAccessTime);
			DateTime.Data.ftLastWriteTime=ToFileTime(i.LastWriteTime);
			DateTime.Data.nFileSizeLow=(uint)(i.Length&0xffffffffL);
			DateTime.Data.nFileSizeHigh=(uint)((ulong)i.Length>>32);
			return i.Exists;
		}catch{return false;}
	}
	public static bool FileCreateSymLink(string Link, string Target)
	{
		try
		{
			if(Directory.Exists(Target)) Directory.CreateSymbolicLink(Link,Target);
			else File.CreateSymbolicLink(Link,Target);
			return true;
		}catch{return false;}
	}
	public static bool FileGetSymLinkTarget(string FileName, ref TSymLinkRec SymLinkRec)
	{
		string target=SymLinkRec.TargetName??string.Empty;if(!FileGetSymLinkTarget(FileName,ref target))return false;SymLinkRec.TargetName=target;SymLinkRec.Attr=FileGetAttr(FileName);try{SymLinkRec.Size=new FileInfo(FileName).Length;}catch{SymLinkRec.Size=0;}return true;
	}
	public static bool FileGetSymLinkTarget(string FileName, ref string TargetName)
	{
		try{FileSystemInfo i=Directory.Exists(FileName)?(FileSystemInfo)new DirectoryInfo(FileName):new FileInfo(FileName);FileSystemInfo t=i.ResolveLinkTarget(false);if(t==null)return false;TargetName=t.FullName;return true;}catch{return false;}
	}
	public static TSet FileSystemAttributes(string Path)
	{
		TSet r=new TSet();r.Include((int)TFileSystemAttribute.fsCasePreserving);r.Include((int)TFileSystemAttribute.fsLocal);
		if(!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))r.Include((int)TFileSystemAttribute.fsCaseSensitive);
		return r;
	}
	public static string GetCurrentDir()
	{
		return Directory.GetCurrentDirectory();
	}
	public static bool SetCurrentDir(string Dir)
	{
		try{Directory.SetCurrentDirectory(Dir);return true;}catch{return false;}
	}
	public static bool CreateDir(string Dir)
	{
		try{Directory.CreateDirectory(Dir);return true;}catch{return false;}
	}
	public static bool RemoveDir(string Dir)
	{
		try{Directory.Delete(Dir);return true;}catch{return false;}
	}
	public static long DiskFree(byte Drive)
	{
		try{string root=Drive==0?Path.GetPathRoot(Directory.GetCurrentDirectory()):((char)('A'+Drive-1))+":\\";return new DriveInfo(root).AvailableFreeSpace;}catch{return -1;}
	}
	public static long DiskSize(byte Drive)
	{
		try{string root=Drive==0?Path.GetPathRoot(Directory.GetCurrentDirectory()):((char)('A'+Drive-1))+":\\";return new DriveInfo(root).TotalSize;}catch{return -1;}
	}
	public static int FileGetAttr(string FileName, bool FollowLink = true)
	{
		try
		{
			FileAttributes a=File.GetAttributes(FileName); int r=0;
			if((a&FileAttributes.ReadOnly)!=0)r|=faReadOnly;if((a&FileAttributes.Hidden)!=0)r|=faHidden;if((a&FileAttributes.System)!=0)r|=faSysFile;
			if((a&FileAttributes.Directory)!=0)r|=faDirectory;if((a&FileAttributes.Archive)!=0)r|=faArchive;if((a&FileAttributes.Normal)!=0)r|=faNormal;
			if((a&FileAttributes.Temporary)!=0)r|=faTemporary;if((a&FileAttributes.ReparsePoint)!=0)r|=faSymLink;if((a&FileAttributes.Compressed)!=0)r|=faCompressed;if((a&FileAttributes.Encrypted)!=0)r|=faEncrypted;
			return r;
		}catch{return faInvalid;}
	}
	public static int FileSetAttr(string FileName, int Attr, bool FollowLink = true)
	{
		try
		{
			FileAttributes a=0;if((Attr&faReadOnly)!=0)a|=FileAttributes.ReadOnly;if((Attr&faHidden)!=0)a|=FileAttributes.Hidden;if((Attr&faSysFile)!=0)a|=FileAttributes.System;
			if((Attr&faArchive)!=0)a|=FileAttributes.Archive;if((Attr&faNormal)!=0)a|=FileAttributes.Normal;if((Attr&faTemporary)!=0)a|=FileAttributes.Temporary;
			File.SetAttributes(FileName,a);return 0;
		}catch{return -1;}
	}
	public static bool FileIsReadOnly(string FileName)
	{
		return (FileGetAttr(FileName)&faReadOnly)!=0;
	}
	public static bool FileSetReadOnly(string FileName, bool ReadOnly)
	{
		int a=FileGetAttr(FileName);if(a==faInvalid)return false;if(ReadOnly)a|=faReadOnly;else a&=~faReadOnly;return FileSetAttr(FileName,a)==0;
	}
	public static bool DeleteFile(string FileName)
	{
		try{File.Delete(FileName);return !File.Exists(FileName);}catch{return false;}
	}
	public static bool RenameFile(string OldName, string NewName)
	{
		try{File.Move(OldName,NewName);return true;}catch{return false;}
	}
	public static bool IsAssembly(string FileName)
	{
		try{global::System.Reflection.AssemblyName.GetAssemblyName(FileName);return true;}catch{return false;}
	}
	public static TDateTime FileDateToDateTime(int FileDate)
	{
		if(FileDate<0)return default;int date=(FileDate>>16)&0xffff,time=FileDate&0xffff;int y=((date>>9)&127)+1980,m=(date>>5)&15,d=date&31,h=(time>>11)&31,n=(time>>5)&63,s=(time&31)*2;try{return new TDateTime(y,m,d,h,n,s);}catch{return default;}
	}
	public static int DateTimeToFileDate(TDateTime DateTime)
	{
		global::System.DateTime d=DateTime.ToDateTime();if(d.Year<1980)return -1;int date=((d.Year-1980)<<9)|(d.Month<<5)|d.Day;int time=(d.Hour<<11)|(d.Minute<<5)|(d.Second/2);return (date<<16)|time;
	}
	public static int FileAge(string FileName)
	{
		try{return DateTimeToFileDate(new TDateTime(File.GetLastWriteTime(FileName)));}catch{return -1;}
	}
	public static bool FileAge(string FileName, out TDateTime FileDateTime, bool FollowLink = true)
	{
		try{if(!File.Exists(FileName)){FileDateTime=default;return false;}FileDateTime=new TDateTime(File.GetLastWriteTime(FileName));return true;}catch{FileDateTime=default;return false;}
	}
	public static int FileSetDate(string FileName, int Age)
	{
		try{TDateTime d=FileDateToDateTime(Age);File.SetLastWriteTime(FileName,d.ToDateTime());return 0;}catch{return -1;}
	}
	public static int FileSetDate(uint Handle, int Age)
	{
		lock(FFileLock){if(!FFileStreams.TryGetValue(Handle,out global::System.IO.FileStream s))return -1;return FileSetDate(s.Name,Age);}
	}
	public static uint FileOpen(string FileName, uint Mode)
	{
		try
		{
			global::System.IO.FileAccess access=(Mode&3)==fmOpenWrite?global::System.IO.FileAccess.Write:(Mode&3)==fmOpenReadWrite?global::System.IO.FileAccess.ReadWrite:global::System.IO.FileAccess.Read;
			global::System.IO.FileShare share=(Mode&0xF0)==fmShareExclusive?global::System.IO.FileShare.None:(Mode&0xF0)==fmShareDenyWrite?global::System.IO.FileShare.Read:(Mode&0xF0)==fmShareDenyRead?global::System.IO.FileShare.Write:global::System.IO.FileShare.ReadWrite;
			global::System.IO.FileStream s=new global::System.IO.FileStream(FileName,global::System.IO.FileMode.Open,access,share);lock(FFileLock){uint h=FNextFileHandle++;FFileStreams[h]=s;return h;}
		}catch{return uint.MaxValue;}
	}
	public static int FileRead(uint Handle, UntypedPointer Buffer, uint Count)
	{
		lock(FFileLock){if(!FFileStreams.TryGetValue(Handle,out global::System.IO.FileStream s)||Buffer.IsNull())return -1;byte[] b=new byte[checked((int)Count)];int n=s.Read(b,0,b.Length);for(int i=0;i<n;i++)Buffer[i]=b[i];return n;}
	}
	public static int FileWrite(uint Handle, UntypedPointer Buffer, uint Count)
	{
		lock(FFileLock){if(!FFileStreams.TryGetValue(Handle,out global::System.IO.FileStream s)||Buffer.IsNull())return -1;byte[] b=new byte[checked((int)Count)];for(int i=0;i<b.Length;i++)b[i]=Buffer[i];s.Write(b,0,b.Length);return b.Length;}
	}
	public static uint FileCreate(string FileName)
	{
		return FileCreate(FileName,0,0);
	}
	public static uint FileCreate(string FileName, int Rights)
	{
		return FileCreate(FileName,0,Rights);
	}
	public static uint FileCreate(string FileName, uint Mode, int Rights)
	{
		try{global::System.IO.FileStream s=new global::System.IO.FileStream(FileName,global::System.IO.FileMode.Create,global::System.IO.FileAccess.ReadWrite,global::System.IO.FileShare.Read);lock(FFileLock){uint h=FNextFileHandle++;FFileStreams[h]=s;return h;}}catch{return uint.MaxValue;}
	}
	public static int FileSeek(uint Handle, int Offset, int Origin)
	{
		long v=FileSeek(Handle,(long)Offset,Origin);return v>int.MaxValue||v<int.MinValue?-1:(int)v;
	}
	public static long FileSeek(uint Handle, long Offset, int Origin)
	{
        lock (FFileLock)
        {
            global::System.IO.FileStream s;

            if (!FFileStreams.TryGetValue(Handle, out s))
                return -1;

            return s.Seek(
                Offset,
                (global::System.IO.SeekOrigin)Origin);
        }
	}
	public static int FileGetDate(uint Handle)
	{
		lock(FFileLock){if(!FFileStreams.TryGetValue(Handle,out global::System.IO.FileStream s))return -1;try{return DateTimeToFileDate(new TDateTime(File.GetLastWriteTime(s.Name)));}catch{return -1;}}
	}
	public static void FileClose(uint Handle)
	{
		lock(FFileLock){if(FFileStreams.TryGetValue(Handle,out global::System.IO.FileStream s)){s.Dispose();FFileStreams.Remove(Handle);}}
	}

/* Environment, resource and command-line helpers */

/* Package, termination and collection-growth helpers */
	public static uint SafeLoadLibrary(string FileName, uint ErrorMode = 0x8000)
	{
		try{IntPtr h=NativeLibrary.Load(FileName);lock(FModuleLock){uint id=FNextModuleHandle++;FModules[id]=h;FModuleNames[id]=FileName;return id;}}catch{return 0;}
	}
	public static uint LoadPackage(string Name)
	{
		return SafeLoadLibrary(Name);
	}
	public static uint LoadPackage(string Name, TValidatePackageProc AValidatePackage)
	{
		uint h=SafeLoadLibrary(Name);if(h!=0&&AValidatePackage!=null&&!AValidatePackage(h)){UnloadPackage(h);return 0;}return h;
	}
	public static void InitializePackage(uint Module)
	{
		return;
	}
	public static void InitializePackage(uint Module, TValidatePackageProc AValidatePackage)
	{
		if(AValidatePackage!=null&&!AValidatePackage(Module))throw new EPackageError("Package validation failed.");
	}
	public static void FinalizePackage(uint Module)
	{
		return;
	}
	public static void UnloadPackage(uint Module)
	{
		lock(FModuleLock){if(FModules.TryGetValue(Module,out IntPtr h)){NativeLibrary.Free(h);FModules.Remove(Module);FModuleNames.Remove(Module);}}
	}
	public static string GetPackageDescription(PChar ModuleName)
	{
		return ModuleName.IsNull()?string.Empty:ModuleName.ToString();
	}
	public static void GetPackageInfo(uint Module, Pointer Param, ref int Flags, TPackageInfoProc InfoProc)
	{
		if(InfoProc!=null&&FModuleNames.TryGetValue(Module,out string n))InfoProc(n,TNameType.ntContainsUnit,0,Param);
	}
	public static uint GetPackageTargets(uint Module)
	{
		return 0;
	}
	public static void AddExitProc(TProcedure Proc)
	{
		if(Proc!=null)FExitProcs.Add(Proc);
	}
	public static void AddTerminateProc(TTerminateProc TermProc)
	{
		if(TermProc!=null)FTerminateProcs.Add(TermProc);
	}
	public static bool CallTerminateProcs()
	{
		bool ok=true;for(int i=FTerminateProcs.Count-1;i>=0;i--)try{ok=FTerminateProcs[i]()&&ok;}catch{ok=false;}return ok;
	}
	public static int GrowCollection(int OldCapacity, int NewCount)
	{
		if(GrowCollectionFunc!=null)return GrowCollectionFunc(OldCapacity,NewCount);if(NewCount<=OldCapacity)return OldCapacity;long n=OldCapacity<=0?4:OldCapacity+(OldCapacity>>1);if(n<NewCount)n=NewCount;return n>int.MaxValue?int.MaxValue:(int)n;
	}
	public static TGrowCollectionFunc SetGrowCollectionFunc(TGrowCollectionFunc Func)
	{
		TGrowCollectionFunc old=GrowCollectionFunc;GrowCollectionFunc=Func;return old;
	}
	public static string GetDefaultFallbackLanguages()
	{
		return FFallbackLanguages;
	}
	public static void SetDefaultFallbackLanguages(string Languages)
	{
		FFallbackLanguages=Languages??string.Empty;
	}
	public static string PreferredUILanguages()
	{
		return string.Join(";",CultureInfo.CurrentUICulture.Name,CultureInfo.CurrentUICulture.Parent?.Name).TrimEnd(';');
	}
	public static string GetEnvironmentVariable(string Name)
	{
		return Environment.GetEnvironmentVariable(Name??string.Empty)??string.Empty;
	}
	public static string GetHomePath()
	{
		return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
	}
	public static string GetLocaleStr(int Locale, int LocaleType, string Default)
	{
		try{return CultureInfo.GetCultureInfo(Locale).DisplayName??Default;}catch{return Default??string.Empty;}
	}
	public static char GetLocaleChar(int Locale, int LocaleType, char Default)
	{
		string s=GetLocaleStr(Locale,LocaleType,string.Empty);return s.Length>0?s[0]:Default;
	}
	public static void GetLocaleFormatSettings(uint Locale, ref TFormatSettings AFormatSettings)
	{
		AFormatSettings=TFormatSettings.Create(Locale);
	}
	public static bool LocaleFileExists(string FileName)
	{
		return File.Exists(GetLocaleFile(FileName));
	}
	public static string GetLocaleFile(string FileName)
	{
		string culture=CultureInfo.CurrentUICulture.Name;if(string.IsNullOrEmpty(culture))return FileName??string.Empty;string dir=Path.GetDirectoryName(FileName??string.Empty)??string.Empty;string name=Path.GetFileName(FileName??string.Empty);string localized=Path.Combine(dir,culture,name);return File.Exists(localized)?localized:(FileName??string.Empty);
	}
	public static bool LocaleDirectoryExists(string Directory)
	{
		return global::System.IO.Directory.Exists(GetLocaleDirectory(Directory));
	}
	public static string GetLocaleDirectory(string Directory)
	{
		string p=Path.Combine(Directory??string.Empty,CultureInfo.CurrentUICulture.Name);return global::System.IO.Directory.Exists(p)?p:(Directory??string.Empty);
	}
	public static bool CheckWin32Version(int AMajor, int AMinor = 0)
	{
		return TOSVersion.Platform==TOSVersion.TPlatform.pfWindows&&TOSVersion.Check(AMajor,AMinor);
	}
	public static uint GetFileVersion(string AFileName)
	{
		try{FileVersionInfo v=FileVersionInfo.GetVersionInfo(AFileName);return ((uint)(v.FileMajorPart&0xffff)<<16)|(uint)(v.FileMinorPart&0xffff);}catch{return 0;}
	}
	public static bool GetProductVersion(string AFileName, ref uint AMajor, ref uint AMinor, ref uint ABuild)
	{
		try{FileVersionInfo v=FileVersionInfo.GetVersionInfo(AFileName);AMajor=(uint)v.ProductMajorPart;AMinor=(uint)v.ProductMinorPart;ABuild=(uint)v.ProductBuildPart;return true;}catch{return false;}
	}
	public static void GetFormatSettings()
	{
		FormatSettings=TFormatSettings.Create();
	}
	public static int LCIDToCodePage(uint ALCID)
	{
		try{return CultureInfo.GetCultureInfo((int)ALCID).TextInfo.ANSICodePage;}catch{return global::System.Text.Encoding.Default.CodePage;}
	}
	public static string GetModuleName(uint Module)
	{
		lock(FModuleLock){return FModuleNames.TryGetValue(Module,out string n)?n:string.Empty;}
	}
	public static string LoadStr(uint Ident)
	{
		return Ident.ToString(CultureInfo.InvariantCulture);
	}
	public static string FmtLoadStr(uint Ident, params TVarRec[] Args)
	{
		return SysutilsInterface.Format(LoadStr(Ident),Args);
	}
	public static bool FindCmdLineSwitch(string Switch, TSet Chars, bool IgnoreCase)
	{
		string v=string.Empty;TSet st=new TSet()<<(int)TCmdLineSwitchType.clstValueNextParam<<(int)TCmdLineSwitchType.clstValueAppended;return FindCmdLineSwitch(Switch,ref v,IgnoreCase,st);
	}
	public static bool FindCmdLineSwitch(string Switch)
	{
		return FindCmdLineSwitch(Switch,true);
	}
	public static bool FindCmdLineSwitch(string Switch, bool IgnoreCase)
	{
		string v=string.Empty;return FindCmdLineSwitch(Switch,ref v,IgnoreCase);
	}
    public static bool FindCmdLineSwitch(string Switch, ref string Value, bool IgnoreCase = true)
	{
        return FindCmdLineSwitch(Switch, ref Value, IgnoreCase,
                                    new TSet()
                                        << (int)TCmdLineSwitchType.clstValueNextParam
                                        << (int)TCmdLineSwitchType.clstValueAppended);
    }

    public static bool FindCmdLineSwitch(string Switch, ref string Value, bool IgnoreCase, TSet SwitchTypes)
    {
    	Value=string.Empty;string[] a=Environment.GetCommandLineArgs();StringComparison cmp=IgnoreCase?StringComparison.OrdinalIgnoreCase:StringComparison.Ordinal;
    	for(int i=1;i<a.Length;i++)
    	{
    		string x=a[i];if(string.IsNullOrEmpty(x)||!(x[0]=='-'||x[0]=='/'))continue;string body=x.Substring(1);
    		if(string.Equals(body,Switch,cmp)){if(SwitchTypes!=null&&SwitchTypes.Contains((int)TCmdLineSwitchType.clstValueNextParam)&&i+1<a.Length)Value=a[i+1];return true;}
    		if(SwitchTypes!=null&&SwitchTypes.Contains((int)TCmdLineSwitchType.clstValueAppended)&&body.StartsWith(Switch,cmp)&&body.Length>Switch.Length)
    		{
    			string tail=body.Substring(Switch.Length);if(tail.StartsWith(":")||tail.StartsWith("="))tail=tail.Substring(1);Value=tail;return true;
    		}
    	}
    	return false;
    }
	public static void Beep()
	{
		try{Console.Beep();}catch{try{Console.Write("\a");}catch{}}
	}

/* GUID and interface support */
	public static bool IsEqualGUID(Guid Guid1, Guid Guid2)
	{
		return Guid1==Guid2;
	}
	public static int CreateGUID(out Guid Guid)
	{
		Guid=global::System.Guid.NewGuid();return 0;
	}
	public static Guid StringToGUID(string S)
	{
		try{return global::System.Guid.Parse(S);}catch(global::System.Exception ex){throw new EConvertError(ex.Message);}
	}
	public static Guid StrToGUID(PChar S)
	{
		return StringToGUID(S.IsNull()?string.Empty:S.ToString());
	}
	public static string GUIDToString(Guid Guid)
	{
		return "{"+Guid.ToString("D").ToUpperInvariant()+"}";
	}
	public static string GUIDToString(Guid Guid, char Format)
	{
		string f=char.ToUpperInvariant(Format)=='B'?"B":char.ToUpperInvariant(Format)=='N'?"N":char.ToUpperInvariant(Format)=='P'?"P":"D";return Guid.ToString(f).ToUpperInvariant();
	}
	public static bool Supports(IInterface Instance, Guid IID, UntypedPointer Intf)
	{
		if(Instance==null)return false;object o=Instance;bool ok=o.GetType().GetInterfaces().Any(i=>i.GUID==IID);if(ok&&!Intf.IsNull())Intf.Write<object>(o);return ok;
	}
	public static bool Supports(TObject Instance, Guid IID, UntypedPointer Intf)
	{
		if(Instance==null)return false;bool ok=Instance.GetType().GetInterfaces().Any(i=>i.GUID==IID);if(ok&&!Intf.IsNull())Intf.Write<object>(Instance);return ok;
	}
	public static bool Supports(IInterface Instance, Guid IID)
	{
		return Instance!=null&&Instance.GetType().GetInterfaces().Any(i=>i.GUID==IID);
	}
	public static bool Supports(TObject Instance, Guid IID)
	{
		return Instance!=null&&Instance.GetType().GetInterfaces().Any(i=>i.GUID==IID);
	}
	public static bool Supports(TClass AClass, Guid IID)
	{
		return AClass!=null&&AClass.Type.GetInterfaces().Any(i=>i.GUID==IID);
	}

/* Exception and operating-system helpers */
	public static int ExceptionErrorMessage(TObject ExceptObject, Pointer ExceptAddr, PChar Buffer, int Size)
	{
		string s=ExceptObject?.ToString()??string.Empty;int n=global::System.Math.Min(s.Length,global::System.Math.Max(0,Size-1));if(!Buffer.IsNull()){for(int i=0;i<n;i++)Buffer[i]=s[i];if(Size>0)Buffer[n]='\0';}return n;
	}
	public static void Abort()
	{
		throw new EAbort("Operation aborted.");
	}
	public static void OutOfMemoryError()
	{
		throw new EOutOfMemory("Out of memory.");
	}
	public static void RaiseLastOSError()
	{
		RaiseLastOSError(Marshal.GetLastWin32Error());
	}
	public static void RaiseLastOSError(int LastError)
	{
		RaiseLastOSError(LastError,string.Empty);
	}
	public static void RaiseLastOSError(int LastError, string AdditionalInfo)
	{
		string m=SysErrorMessage((uint)LastError);if(!string.IsNullOrEmpty(AdditionalInfo))m=m+" "+AdditionalInfo;throw new EOSError(m);
	}
	public static void RaiseLastWin32Error()
	{
		RaiseLastOSError();
	}
	public static int Win32Check(int RetVal)
	{
		if(RetVal==0)RaiseLastOSError();return RetVal;
	}
	public static void CheckOSError(int LastError)
	{
		if(LastError!=0)RaiseLastOSError(LastError);
	}
	public static string SysErrorMessage(uint ErrorCode, uint AModuleHandle = 0)
	{
		return new global::System.ComponentModel.Win32Exception(unchecked((int)ErrorCode)).Message;
	}
	//public static void FreeAndNil(ref TObject Obj)
	//{
	//}
  /* FreeAndNil frees the given TObject instance and sets the variable reference
  to nil.  Be careful to only pass TObjects to this routine. */
	public static void FreeAndNil<T>(ref T Obj)
		where T : TObject
	{
		T Temp = Obj;
		Obj = default;
		if(Temp != null)
			Temp.Free();
	}
	
} // class SysutilsInterface


file class SysutilsImplementation
{

} // class SysutilsImplementation

}  // namespace Sysutils

}  // namespace System

