using System.Sysutils;
using System.Types;
using System;
using static System.Dmath.DmathImplementation;
using static System.Dmath.DmathInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;
using static System.Types.TypesInterface;

namespace System
{

namespace Dmath
{

/*
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.Math functionality required by D2CSharp.

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


public class DmathInterface
{

	public class EInvalidArgument : DException
	{


		public EInvalidArgument(string Msg) : base(Msg) {}
		public EInvalidArgument(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EInvalidArgument(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EInvalidArgument(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EInvalidArgument(uint Ident) : base(Ident) {}
		public EInvalidArgument(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EInvalidArgument(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EInvalidArgument(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EInvalidArgument(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EInvalidArgument(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EInvalidArgument(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EInvalidArgument(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	
	public const int ZeroValue = 0;
	public const int PositiveValue = 1;
	public const int NegativeValue = -1;
	public const double MaxSingle = 3.403e38D;
	public const double MinSingle = 1.175e-38D;
	public const double MinSingleDenormal = 1.401e-45D;
	public const double MaxDouble = 1.798e308D;
	public const double MinDouble = 2.225e-308D;
	public const double MinDoubleDenormal = 0.0D;
	public const int seSSE = 1;
	public const int seSSE2 = 2;
	public const int seSSE3 = 4;
	public const int seSSSE3 = 8;
	public const int seSSE41 = 0x10;
	public const int seSSE42 = 0x20;
	public const int sePOPCNT = 0x40;
	public const int seAESNI = 0x80;
	public const int sePCLMULQDQ = 0x100;
	public enum TRoundingMode {rmNearest,
                    rmDown,
                    rmUp,
                    rmTruncate };

	public enum TFPUPrecisionMode {pmSingle,
                        pmReserved,
                        pmDouble,
                        pmExtended };
	public enum TArithmeticException {exInvalidOp,
                           exDenormalized,
                           exZeroDivide,
                           exOverflow,
                           exUnderflow,
                           exPrecision };

	public enum TPaymentTime {ptEndOfPeriod,
                   ptStartOfPeriod };
	public static double Infinity = 0.0D;
	public static double NegInfinity = 0.0D;
	public static double NaN = 0.0D;
	public static long MaxComp = 0;
	public static long MinComp = 0;

/* Min/max and range */
	public static sbyte Min(sbyte A, sbyte B)
	{
		sbyte result = 0;
		return result;
	}
	public static byte Min(byte A, byte B)
	{
		byte result = 0;
		return result;
	}
	public static short Min(short A, short B)
	{
		short result = 0;
		return result;
	}
	public static ushort Min(ushort A, ushort B)
	{
		ushort result = 0;
		return result;
	}
	public static int Min(int A, int B)
	{
		int result = 0;
		return result;
	}
	public static uint Min(uint A, uint B)
	{
		uint result = 0;
		return result;
	}
	public static long Min(long A, long B)
	{
		long result = 0;
		return result;
	}
	public static ulong Min(ulong A, ulong B)
	{
		ulong result = 0;
		return result;
	}
	public static float Min(float A, float B)
	{
		float result = 0.0F;
		return result;
	}
	public static double Min(double A, double B)
	{
		double result = 0.0D;
		return result;
	}
	public static Currency Min(Currency A, Currency B)
	{
		Currency result = 0.0M;
		return result;
	}
	public static sbyte Max(sbyte A, sbyte B)
	{
		sbyte result = 0;
		return result;
	}
	public static byte Max(byte A, byte B)
	{
		byte result = 0;
		return result;
	}
	public static short Max(short A, short B)
	{
		short result = 0;
		return result;
	}
	public static ushort Max(ushort A, ushort B)
	{
		ushort result = 0;
		return result;
	}
	public static int Max(int A, int B)
	{
		int result = 0;
		return result;
	}
	public static uint Max(uint A, uint B)
	{
		uint result = 0;
		return result;
	}
	public static long Max(long A, long B)
	{
		long result = 0;
		return result;
	}
	public static ulong Max(ulong A, ulong B)
	{
		ulong result = 0;
		return result;
	}
	public static float Max(float A, float B)
	{
		float result = 0.0F;
		return result;
	}
	public static double Max(double A, double B)
	{
		double result = 0.0D;
		return result;
	}
	public static Currency Max(Currency A, Currency B)
	{
		Currency result = 0.0M;
		return result;
	}
	public static int EnsureRange(int AValue, int AMin, int AMax)
	{
		int result = 0;
		return result;
	}
	public static long EnsureRange(long AValue, long AMin, long AMax)
	{
		long result = 0;
		return result;
	}
	public static ulong EnsureRange(ulong AValue, ulong AMin, ulong AMax)
	{
		ulong result = 0;
		return result;
	}
	public static float EnsureRange(float AValue, float AMin, float AMax)
	{
		float result = 0.0F;
		return result;
	}
	public static double EnsureRange(double AValue, double AMin, double AMax)
	{
		double result = 0.0D;
		return result;
	}
	public static bool InRange(int AValue, int AMin, int AMax)
	{
		bool result = false;
		return result;
	}
	public static bool InRange(long AValue, long AMin, long AMax)
	{
		bool result = false;
		return result;
	}
	public static bool InRange(ulong AValue, ulong AMin, ulong AMax)
	{
		bool result = false;
		return result;
	}
	public static bool InRange(float AValue, float AMin, float AMax)
	{
		bool result = false;
		return result;
	}
	public static bool InRange(double AValue, double AMin, double AMax)
	{
		bool result = false;
		return result;
	}

/* Comparison */
	public static bool SameValue(float A, float B, float Epsilon = 0.0F)
	{
		bool result = false;
		return result;
	}
	public static bool SameValue(double A, double B, double Epsilon = 0.0F)
	{
		bool result = false;
		return result;
	}
	public static bool IsZero(float A, float Epsilon = 0.0F)
	{
		bool result = false;
		return result;
	}
	public static bool IsZero(double A, double Epsilon = 0.0F)
	{
		bool result = false;
		return result;
	}
	public static int /*-1..1*/ CompareValue(float A, float B, float Epsilon = 0.0F)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ CompareValue(double A, double B, double Epsilon = 0.0F)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ CompareValue(int A, int B)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ CompareValue(long A, long B)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ CompareValue(ulong A, ulong B)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ Sign(int AValue)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ Sign(long AValue)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ Sign(float AValue)
	{
		int /*-1..1*/ result = 0;
		return result;
	}
	public static int /*-1..1*/ Sign(double AValue)
	{
		int /*-1..1*/ result = 0;
		return result;
	}

/* Floating-point control */
	public static TRoundingMode GetRoundMode()
	{
		TRoundingMode result = TRoundingMode.rmNearest;
		return result;
	}
	public static TRoundingMode SetRoundMode(TRoundingMode RoundMode)
	{
		TRoundingMode result = TRoundingMode.rmNearest;
		return result;
	}
	public static TRoundingMode GetFPURoundMode()
	{
		TRoundingMode result = TRoundingMode.rmNearest;
		return result;
	}
	public static TRoundingMode SetFPURoundMode(TRoundingMode RoundMode)
	{
		TRoundingMode result = TRoundingMode.rmNearest;
		return result;
	}
	public static TRoundingMode GetSSERoundMode()
	{
		TRoundingMode result = TRoundingMode.rmNearest;
		return result;
	}
	public static TRoundingMode SetSSERoundMode(TRoundingMode RoundMode)
	{
		TRoundingMode result = TRoundingMode.rmNearest;
		return result;
	}
	public static TFPUPrecisionMode GetPrecisionMode()
	{
		TFPUPrecisionMode result = TFPUPrecisionMode.pmSingle;
		return result;
	}
	public static TFPUPrecisionMode SetPrecisionMode(TFPUPrecisionMode Precision)
	{
		TFPUPrecisionMode result = TFPUPrecisionMode.pmSingle;
		return result;
	}
	public static TSet GetExceptionMask()
	{
		TSet result = new TSet();
		return result;
	}
	public static TSet SetExceptionMask(TSet Mask)
	{
		TSet result = new TSet();
		return result;
	}
	public static TSet GetExceptions()
	{
		TSet result = new TSet();
		return result;
	}
	public static TSet SetExceptions(TSet Exceptions)
	{
		TSet result = new TSet();
		return result;
	}
	public static TSet GetFPUExceptionMask()
	{
		TSet result = new TSet();
		return result;
	}
	public static TSet SetFPUExceptionMask(TSet Mask)
	{
		TSet result = new TSet();
		return result;
	}
	public static TSet GetSSEExceptionMask()
	{
		TSet result = new TSet();
		return result;
	}
	public static TSet SetSSEExceptionMask(TSet Mask)
	{
		TSet result = new TSet();
		return result;
	}
	public static void ClearExceptions(bool RaisePending = true)
	{
	}
	public static void ClearFPUExceptions(bool RaisePending = true)
	{
	}
	public static void ClearSSEExceptions(bool RaisePending = true)
	{
	}
	public static void RaiseExceptions(TSet ExceptionFlags)
	{
	}

/* Rounding and decomposition */
	public static double RoundTo(double AValue, int /*-20..20*/ ADigit)
	{
		double result = 0.0D;
		return result;
	}
	public static float SimpleRoundTo(float AValue, int /*-37..37*/ ADigit = -2)
	{
		float result = 0.0F;
		return result;
	}
	public static double SimpleRoundTo(double AValue, int /*-37..37*/ ADigit = -2)
	{
		double result = 0.0D;
		return result;
	}
	public static int Floor(float X)
	{
		int result = 0;
		return result;
	}
	public static int Floor(double X)
	{
		int result = 0;
		return result;
	}
	public static int Ceil(float X)
	{
		int result = 0;
		return result;
	}
	public static int Ceil(double X)
	{
		int result = 0;
		return result;
	}
	public static void Frexp(float X, ref float Mantissa, ref int Exponent)
	{
	}
	public static void Frexp(double X, ref double Mantissa, ref int Exponent)
	{
	}
	public static float FMod(float ANumerator, float ADenominator)
	{
		float result = 0.0F;
		return result;
	}
	public static double FMod(double ANumerator, double ADenominator)
	{
		double result = 0.0D;
		return result;
	}
	public static void DivMod(uint Dividend, ushort Divisor, ref ushort Result, ref ushort Remainder)
	{
	}
	public static void DivMod(ulong Dividend, ulong Divisor, ref ulong Result, ref ulong Remainder)
	{
	}

/* Powers and logarithms */
	public static float IntPower(float Base, int Exponent)
	{
		float result = 0.0F;
		return result;
	}
	public static double IntPower(double Base, int Exponent)
	{
		double result = 0.0D;
		return result;
	}
	public static double Power(double Base, double Exponent)
	{
		double result = 0.0D;
		return result;
	}
	public static double LogN(double Base, double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Log2(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Log10(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double LnXP1(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Ldexp(double X, int P)
	{
		double result = 0.0D;
		return result;
	}

/* Trigonometric and hyperbolic functions */
	public static double ArcCos(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcSin(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcTan2(double Y, double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcCot(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcCotH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcCsc(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcCscH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcSec(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcSecH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double SinH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double CosH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double TanH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double SecH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double CscH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double CotH(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcSinh(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcCosh(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double ArcTanh(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Tan(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Cot(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Cotan(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Sec(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Secant(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Csc(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static double Cosecant(double X)
	{
		double result = 0.0D;
		return result;
	}
	public static void SinCos(double Theta, ref double Sin, ref double Cos)
	{
	}
	public static float Hypot(float X, float Y)
	{
		float result = 0.0F;
		return result;
	}
	public static double Hypot(double X, double Y)
	{
		double result = 0.0D;
		return result;
	}
	public static float Hypot(float X, float Y, float Z)
	{
		float result = 0.0F;
		return result;
	}
	public static double Hypot(double X, double Y, double Z)
	{
		double result = 0.0D;
		return result;
	}

/* Angle conversion */
	public static double DegToRad(double Degrees)
	{
		double result = 0.0D;
		return result;
	}
	public static double RadToDeg(double Radians)
	{
		double result = 0.0D;
		return result;
	}
	public static double GradToRad(double Grads)
	{
		double result = 0.0D;
		return result;
	}
	public static double RadToGrad(double Radians)
	{
		double result = 0.0D;
		return result;
	}
	public static double DegToGrad(double Degrees)
	{
		double result = 0.0D;
		return result;
	}
	public static double GradToDeg(double Grads)
	{
		double result = 0.0D;
		return result;
	}
	public static double CycleToRad(double Cycles)
	{
		double result = 0.0D;
		return result;
	}
	public static double RadToCycle(double Radians)
	{
		double result = 0.0D;
		return result;
	}
	public static double CycleToDeg(double Cycles)
	{
		double result = 0.0D;
		return result;
	}
	public static double DegToCycle(double Degrees)
	{
		double result = 0.0D;
		return result;
	}
	public static double CycleToGrad(double Cycles)
	{
		double result = 0.0D;
		return result;
	}
	public static double GradToCycle(double Grads)
	{
		double result = 0.0D;
		return result;
	}

/* Conditional helpers */
	public static int IfThen(bool AValue, int ATrue, int AFalse = 0)
	{
		int result = 0;
		return result;
	}
	public static long IfThen(bool AValue, long ATrue, long AFalse = 0)
	{
		long result = 0;
		return result;
	}
	public static float IfThen(bool AValue, float ATrue, float AFalse = 0.0F)
	{
		float result = 0.0F;
		return result;
	}
	public static double IfThen(bool AValue, double ATrue, double AFalse = 0.0F)
	{
		double result = 0.0D;
		return result;
	}

/* Random helpers */
	public static int RandomRange(int AFrom, int ATo)
	{
		int result = 0;
		return result;
	}
	public static long RandomRange(long AFrom, long ATo)
	{
		long result = 0;
		return result;
	}
	public static sbyte RandomFrom(sbyte[] AValues)
	{
		sbyte result = 0;
		return result;
	}
	public static short RandomFrom(short[] AValues)
	{
		short result = 0;
		return result;
	}
	public static int RandomFrom(int[] AValues)
	{
		int result = 0;
		return result;
	}
	public static long RandomFrom(long[] AValues)
	{
		long result = 0;
		return result;
	}
	public static byte RandomFrom(byte[] AValues)
	{
		byte result = 0;
		return result;
	}
	public static ushort RandomFrom(ushort[] AValues)
	{
		ushort result = 0;
		return result;
	}
	public static uint RandomFrom(uint[] AValues)
	{
		uint result = 0;
		return result;
	}
	public static ulong RandomFrom(ulong[] AValues)
	{
		ulong result = 0;
		return result;
	}
	public static float RandomFrom(float[] AValues)
	{
		float result = 0.0F;
		return result;
	}
	public static double RandomFrom(double[] AValues)
	{
		double result = 0.0D;
		return result;
	}
	public static bool RandomFrom(bool[] AValues)
	{
		bool result = false;
		return result;
	}
	public static float RandG(float Mean, float StdDev)
	{
		float result = 0.0F;
		return result;
	}
	public static double RandG(double Mean, double StdDev)
	{
		double result = 0.0D;
		return result;
	}

/* Classification */
	public static bool IsNan(float AValue)
	{
		bool result = false;
		return result;
	}
	public static bool IsNan(double AValue)
	{
		bool result = false;
		return result;
	}
	public static bool IsInfinite(float AValue)
	{
		bool result = false;
		return result;
	}
	public static bool IsInfinite(double AValue)
	{
		bool result = false;
		return result;
	}

/* Statistics */
	public static float Sum(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double Sum(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static long SumInt(int[] Data)
	{
		long result = 0;
		return result;
	}
	public static float SumOfSquares(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double SumOfSquares(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static void SumsAndSquares(float[] Data, ref float Sum, ref float SumOfSquares)
	{
	}
	public static void SumsAndSquares(double[] Data, ref double Sum, ref double SumOfSquares)
	{
	}
	public static float Mean(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double Mean(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static float TotalVariance(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double TotalVariance(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static float Variance(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double Variance(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static float PopnVariance(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double PopnVariance(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static float StdDev(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double StdDev(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static float PopnStdDev(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double PopnStdDev(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static void MeanAndStdDev(float[] Data, ref float Mean, ref float StdDev)
	{
	}
	public static void MeanAndStdDev(double[] Data, ref double Mean, ref double StdDev)
	{
	}
	public static float MaxValue(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double MaxValue(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static float MinValue(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double MinValue(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static int MaxIntValue(int[] Data)
	{
		int result = 0;
		return result;
	}
	public static int MinIntValue(int[] Data)
	{
		int result = 0;
		return result;
	}
	public static float Norm(float[] Data)
	{
		float result = 0.0F;
		return result;
	}
	public static double Norm(double[] Data)
	{
		double result = 0.0D;
		return result;
	}
	public static float Poly(float X, float[] Coefficients)
	{
		float result = 0.0F;
		return result;
	}
	public static double Poly(double X, double[] Coefficients)
	{
		double result = 0.0D;
		return result;
	}

/* Finance */
	public static double DoubleDecliningBalance(double Cost, double Salvage, int Life, int Period)
	{
		double result = 0.0D;
		return result;
	}
	public static double FutureValue(double Rate, int NPeriods, double Payment, double PresentValue, TPaymentTime PaymentTime)
	{
		double result = 0.0D;
		return result;
	}
	public static double PresentValue(double Rate, int NPeriods, double Payment, double FutureValue, TPaymentTime PaymentTime)
	{
		double result = 0.0D;
		return result;
	}
	public static double InterestPayment(double Rate, int Period, int NPeriods, double PresentValue, double FutureValue, TPaymentTime PaymentTime)
	{
		double result = 0.0D;
		return result;
	}
	public static double InterestRate(int NPeriods, double Payment, double PresentValue, double FutureValue, TPaymentTime PaymentTime, double Guess)
	{
		double result = 0.0D;
		return result;
	}
	public static double InternalRateOfReturn(double Guess, double[] CashFlows)
	{
		double result = 0.0D;
		return result;
	}
	public static double NumberOfPeriods(double Rate, double Payment, double PresentValue, double FutureValue, TPaymentTime PaymentTime)
	{
		double result = 0.0D;
		return result;
	}
	public static double Payment(double Rate, int NPeriods, double PresentValue, double FutureValue, TPaymentTime PaymentTime)
	{
		double result = 0.0D;
		return result;
	}
	public static double PeriodPayment(double Rate, int Period, int NPeriods, double PresentValue, double FutureValue, TPaymentTime PaymentTime)
	{
		double result = 0.0D;
		return result;
	}
	public static double SLNDepreciation(double Cost, double Salvage, int Life)
	{
		double result = 0.0D;
		return result;
	}
	public static double SYDDepreciation(double Cost, double Salvage, int Life, int Period)
	{
		double result = 0.0D;
		return result;
	}
	
} // class DmathInterface


file class DmathImplementation
{

} // class DmathImplementation

}  // namespace Dmath

}  // namespace System

