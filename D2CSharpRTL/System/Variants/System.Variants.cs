using System.Sysutils;
using System;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;
using static System.Variants.VariantsImplementation;
using static System.Variants.VariantsInterface;

namespace System
{

namespace Variants
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of selected System.Variants functionality.
  This file supplies translation symbols and routine signatures, not
  working Variant semantics. Implementations intentionally return defaults.

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


public class VariantsInterface
{

	public class EVariantTypeCastError : EVariantError
	{


		public EVariantTypeCastError(string Msg) : base(Msg) {}
		public EVariantTypeCastError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EVariantTypeCastError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EVariantTypeCastError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EVariantTypeCastError(uint Ident) : base(Ident) {}
		public EVariantTypeCastError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EVariantTypeCastError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EVariantTypeCastError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EVariantTypeCastError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EVariantTypeCastError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EVariantTypeCastError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EVariantTypeCastError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EVariantInvalidOpError : EVariantError
	{


		public EVariantInvalidOpError(string Msg) : base(Msg) {}
		public EVariantInvalidOpError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EVariantInvalidOpError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EVariantInvalidOpError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EVariantInvalidOpError(uint Ident) : base(Ident) {}
		public EVariantInvalidOpError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EVariantInvalidOpError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EVariantInvalidOpError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EVariantInvalidOpError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EVariantInvalidOpError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EVariantInvalidOpError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EVariantInvalidOpError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EVariantOverflowError : EVariantError
	{


		public EVariantOverflowError(string Msg) : base(Msg) {}
		public EVariantOverflowError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EVariantOverflowError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EVariantOverflowError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EVariantOverflowError(uint Ident) : base(Ident) {}
		public EVariantOverflowError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EVariantOverflowError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EVariantOverflowError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EVariantOverflowError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EVariantOverflowError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EVariantOverflowError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EVariantOverflowError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EVariantRangeCheckError : EVariantError
	{


		public EVariantRangeCheckError(string Msg) : base(Msg) {}
		public EVariantRangeCheckError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EVariantRangeCheckError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EVariantRangeCheckError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EVariantRangeCheckError(uint Ident) : base(Ident) {}
		public EVariantRangeCheckError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EVariantRangeCheckError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EVariantRangeCheckError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EVariantRangeCheckError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EVariantRangeCheckError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EVariantRangeCheckError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EVariantRangeCheckError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EVariantArrayCreateError : EVariantError
	{


		public EVariantArrayCreateError(string Msg) : base(Msg) {}
		public EVariantArrayCreateError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EVariantArrayCreateError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EVariantArrayCreateError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EVariantArrayCreateError(uint Ident) : base(Ident) {}
		public EVariantArrayCreateError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EVariantArrayCreateError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EVariantArrayCreateError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EVariantArrayCreateError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EVariantArrayCreateError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EVariantArrayCreateError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EVariantArrayCreateError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EVariantArrayLockedError : EVariantError
	{


		public EVariantArrayLockedError(string Msg) : base(Msg) {}
		public EVariantArrayLockedError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EVariantArrayLockedError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EVariantArrayLockedError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EVariantArrayLockedError(uint Ident) : base(Ident) {}
		public EVariantArrayLockedError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EVariantArrayLockedError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EVariantArrayLockedError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EVariantArrayLockedError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EVariantArrayLockedError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EVariantArrayLockedError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EVariantArrayLockedError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

	public class EVariantBadVarTypeError : EVariantError
	{


		public EVariantBadVarTypeError(string Msg) : base(Msg) {}
		public EVariantBadVarTypeError(string Msg, params TVarRec[] Args) : base(Msg, Args) {}
		public EVariantBadVarTypeError(string Msg, TVarRec[] Args, int AHelpContext) : base(Msg, Args, AHelpContext) {}
		public EVariantBadVarTypeError(string Msg, int AHelpContext) : base(Msg, AHelpContext) {}
		public EVariantBadVarTypeError(uint Ident) : base(Ident) {}
		public EVariantBadVarTypeError(Pointer<TResStringRec> ResStringRec) : base(ResStringRec) {}
		public EVariantBadVarTypeError(uint Ident, params TVarRec[] Args) : base(Ident, Args) {}
		public EVariantBadVarTypeError(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args) : base(ResStringRec, Args) {}
		public EVariantBadVarTypeError(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext) : base(ResStringRec, Args, AHelpContext) {}
		public EVariantBadVarTypeError(uint Ident, TVarRec[] Args, int AHelpContext) : base(Ident, Args, AHelpContext) {}
		public EVariantBadVarTypeError(uint Ident, int AHelpContext) : base(Ident, AHelpContext) {}
		public EVariantBadVarTypeError(Pointer<TResStringRec> ResStringRec, int AHelpContext) : base(ResStringRec, AHelpContext) {}
	}	

/* The current MockRTL/System.pas does not define TVarType or the varXXX
  constants. They are declared here temporarily for converter support.
  In Delphi these base declarations belong to System. Move them there
  when the System mock is extended, and remove the duplicates here. */
	public enum TVariantRelationship {vrEqual,
                           vrLessThan,
                           vrGreaterThan,
                           vrNotEqual };

	public const int varEmpty = 0x0000;
	public const int varNull = 0x0001;
	public const int varSmallint = 0x0002;
	public const int varInteger = 0x0003;
	public const int varSingle = 0x0004;
	public const int varDouble = 0x0005;
	public const int varCurrency = 0x0006;
	public const int varDate = 0x0007;
	public const int varOleStr = 0x0008;
	public const int varDispatch = 0x0009;
	public const int varError = 0x000A;
	public const int varBoolean = 0x000B;
	public const int varVariant = 0x000C;
	public const int varUnknown = 0x000D;
	public const int varShortInt = 0x0010;
	public const int varByte = 0x0011;
	public const int varWord = 0x0012;
	public const int varLongWord = 0x0013;
	public const int varInt64 = 0x0014;
	public const int varUInt64 = 0x0015;
	public const int varStrArg = 0x0048;
	public const int varString = 0x0100;
	public const int varAny = 0x0101;
	public const int varUString = 0x0102;
	public const int varTypeMask = 0x0FFF;
	public const int varArray = 0x2000;
	public const int varByRef = 0x4000;

/* VarClear, VarCopy, VarCast and VarArrayRedim are already declared
  as intrinsics in the current MockRTL/Source/sys/System.pas and must
  not be duplicated here. */
	public static ushort VarType(Variant V)
	{
        return V.VType;
		}
	public static string VarTypeAsText(ushort AType)
	{
        string name = (AType & varTypeMask) switch
        {
            varEmpty => "Empty", varNull => "Null", varSmallint => "Smallint",
            varInteger => "Integer", varSingle => "Single", varDouble => "Double",
            varCurrency => "Currency", varDate => "Date", varOleStr => "OleStr",
            varDispatch => "Dispatch", varError => "Error", varBoolean => "Boolean",
            varVariant => "Variant", varUnknown => "Unknown", varShortInt => "ShortInt",
            varByte => "Byte", varWord => "Word", varLongWord => "LongWord",
            varInt64 => "Int64", varUInt64 => "UInt64", varString => "String",
            varUString => "UString", _ => "Unknown"
        };
        if ((AType & varArray) != 0) name = "Array of " + name;
        if ((AType & varByRef) != 0) name = "ByRef " + name;
        return name;
	
		}
	public static bool VarIsEmpty(Variant V)
	{
        return V.IsEmpty;
		}
	public static bool VarIsNull(Variant V)
	{
        return V.IsNull;
		}
	public static bool VarIsArray(Variant V)
	{
        return (V.VType & varArray) != 0;
		}
	public static bool VarIsStr(Variant V)
	{
        if (VarIsArray(V)) return false;
        return (V.VType & varTypeMask) is varString or varUString or varOleStr;
	
		}
	public static bool VarIsNumeric(Variant V)
	{
        if (VarIsArray(V)) return false;
        return (V.VType & varTypeMask) is varShortInt or varByte or varSmallint
            or varWord or varInteger or varLongWord or varInt64 or varUInt64
            or varSingle or varDouble or varCurrency;
	
		}
	public static bool VarIsOrdinal(Variant V)
	{
        if (VarIsArray(V)) return false;
        return (V.VType & varTypeMask) is varShortInt or varByte or varSmallint
            or varWord or varInteger or varLongWord or varInt64 or varUInt64
            or varBoolean;
	
		}
	public static bool VarIsFloat(Variant V)
	{
        if (VarIsArray(V)) return false;
        return (V.VType & varTypeMask) is varSingle or varDouble or varCurrency or varDate;
	
		}
	public static bool VarIsType(Variant V, ushort AVarType)
	{
        return V.VType == AVarType;
	
		}
	public static bool VarIsType(Variant V, ushort[] AVarTypes)
	{
        ArgumentNullException.ThrowIfNull(AVarTypes);
        return Array.IndexOf(AVarTypes, V.VType) >= 0;
		}
	public static Variant VarAsType(Variant V, ushort AVarType)
	{
        try
        {
            return V.AsType(AVarType);
        }
        catch (OverflowException ex)
        {
            throw new EVariantOverflowError("Variant conversion overflow: " + ex.Message);
        }
        catch (Exception ex) when (ex is InvalidCastException or FormatException)
        {
            throw new EVariantTypeCastError("Invalid Variant conversion: " + ex.Message);
        }
	
		}
	public static string VarToStr(Variant V)
	{
        return V.IsEmpty || V.IsNull ? string.Empty : (string)V;
		}
	public static string VarToStrDef(Variant V, string ADefault)
	{
        return V.IsEmpty || V.IsNull ? ADefault : VarToStr(V);
		}
	public static string VarToWideStr(Variant V)
	{
        return VarToStr(V);
		}
	public static string VarToWideStrDef(Variant V, string ADefault)
	{
        return VarToStrDef(V, ADefault);
		}
	public static TDateTime VarToDateTime(Variant V)
	{
        try
        {
            if (V.IsEmpty || V.IsNull || VarIsArray(V))
                throw new InvalidCastException("Empty, Null or array Variant is not a date.");
            // Delphi TDateTime is a day count; date Variants already store this value.
            if (VarIsStr(V))
                return (TDateTime)DateTime.Parse((string)V,
                    global::System.Globalization.CultureInfo.CurrentCulture).ToOADate();
            return (TDateTime)(double)V;
        }
        catch (Exception ex) when (ex is FormatException or InvalidCastException or OverflowException)
        {
            throw new EVariantTypeCastError("Variant cannot be converted to TDateTime: " + ex.Message);
        }
	
		}
	public static Variant VarFromDateTime(TDateTime AValue)
	{
        return Variant.FromDateTime((double)AValue);
		}
	public static TVariantRelationship VarCompareValue(Variant A, Variant B)
	{
        if (A.IsNull || B.IsNull)
            return TVariantRelationship.vrNotEqual;
        if (A == B) return TVariantRelationship.vrEqual;
        try
        {
            return A < B ? TVariantRelationship.vrLessThan : TVariantRelationship.vrGreaterThan;
        }
        catch (Exception ex) when (ex is InvalidOperationException or InvalidCastException or FormatException)
        {
            throw new EVariantInvalidOpError("Variant comparison failed: " + ex.Message);
        }
	
		}
	public static bool VarSameValue(Variant A, Variant B)
	{
        return A == B;
		}
	public static bool VarInRange(Variant AValue, Variant AMin, Variant AMax)
	{
        if (AMin > AMax)
            throw new EVariantRangeCheckError("Variant range minimum exceeds maximum.");
        return AValue >= AMin && AValue <= AMax;
	
		}
	public static Variant VarEnsureRange(Variant AValue, Variant AMin, Variant AMax)
	{
        if (AMin > AMax)
            throw new EVariantRangeCheckError("Variant range minimum exceeds maximum.");
        return AValue < AMin ? AMin : AValue > AMax ? AMax : AValue;
	
		}
	public static Variant VarArrayCreate(int[] Bounds, ushort AVarType)
	{
        try { return Variant.CreateArray(Bounds, AVarType); }
        catch (Exception ex) when (ex is ArgumentException or OverflowException or NotSupportedException)
        {
            throw new EVariantArrayCreateError("Unable to create Variant array: " + ex.Message);
        }
	
	}
	public static Variant VarArrayOf(Variant[] Values)
	{
        try { return Variant.ArrayOf(Values); }
        catch (ArgumentException ex)
        {
            throw new EVariantArrayCreateError("Unable to create Variant array: " + ex.Message);
        }
	
	}
	public static int VarArrayDimCount(Variant A)
	{
        return VarIsArray(A) ? A.ArrayRank : 0;
	
	}
	public static int VarArrayLowBound(Variant A, int Dim)
	{
        try { return A.ArrayLowBound(Dim); }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            throw new EVariantError("Invalid Variant array dimension: " + ex.Message);
        }
	
	}
	public static int VarArrayHighBound(Variant A, int Dim)
	{
        try { return A.ArrayHighBound(Dim); }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            throw new EVariantError("Invalid Variant array dimension: " + ex.Message);
        }
	
	}
	public static Variant VarArrayGet(Variant A, int[] Indices)
	{
        try { return A.ArrayGet(Indices); }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException or IndexOutOfRangeException)
        {
            throw new EVariantError("Variant array access failed: " + ex.Message);
        }
	
	}
	public static void VarArrayPut(ref Variant A, Variant Value, int[] Indices)
	{
        try { A.ArrayPut(Value, Indices); }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException or IndexOutOfRangeException)
        {
            throw new EVariantError("Variant array assignment failed: " + ex.Message);
        }
	
	}
	public static Pointer VarArrayLock(Variant A)
	{
        // No stable native buffer is exposed by the managed VariantArrayStorage.
        // Returning a null pointer here would incorrectly suggest a successful lock.
        throw new NotSupportedException(
            "VarArrayLock requires a pinned, type-specific native buffer and is not yet supported.");
	
	}
	public static void VarArrayUnlock(Variant A)
	{
        throw new NotSupportedException(
            "VarArrayUnlock is not supported without a matching VarArrayLock implementation.");
	
	}
	public static bool VarTypeIsValidArrayType(ushort AVarType)
	{
        return VarTypeIsValidElementType(AVarType);
	
		}
	public static bool VarTypeIsValidElementType(ushort AVarType)
	{
        return AVarType is varVariant or varShortInt or varByte or varSmallint
            or varWord or varInteger or varLongWord or varInt64 or varUInt64
            or varSingle or varDouble or varCurrency or varBoolean or varString
            or varUString or varOleStr;
	
		}
	public static void VarCopyNoInd(ref Variant Dest, Variant Source)
	{
        Dest = Source;
		}
	public static void VarCheckEmpty(Variant V)
	{
        if (V.IsEmpty) throw new EVariantError("Variant is unassigned.");
		}
	
} // class VariantsInterface


file class VariantsImplementation
{

} // class VariantsImplementation

}  // namespace Variants

}  // namespace System

