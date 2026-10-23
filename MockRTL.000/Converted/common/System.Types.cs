using System;
using static System.SystemInterface;
using static System.Types.TypesImplementation;
using static System.Types.TypesInterface;

namespace System
{

namespace Types
{

/*
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.Types functionality required by D2CSharp.

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


public class TypesInterface
{

	public struct TSmallPoint
	{
		public short X;
		public short Y;
		public static TSmallPoint CreateRecord(){return new TSmallPoint();}
	}	

  /* Integer point using Delphi's fixed-width signed integer type. */

	public struct TPoint
	{
		public FixedInt X;
		public FixedInt Y;
		public TPoint(TPoint P){}
		public TPoint(FixedInt AX, FixedInt AY){}
		//# missing function body: public static TPoint Zero();
		//# missing function body: public TPoint Add(TPoint Point);
		//# missing function body: public TPoint Subtract(TPoint Point);
		//# missing function body: public double Distance(TPoint P2);
		//# missing function body: public bool IsZero();
		//# missing function body: public void SetLocation(FixedInt AX, FixedInt AY);
		//# missing function body: public void SetLocation(TPoint P);
		//# missing function body: public void Offset(FixedInt DX, FixedInt DY);
		//# missing function body: public void Offset(TPoint Point);
		public static TPoint CreateRecord(){return new TPoint();}
	}	

  /* Integer size using Delphi's fixed-width signed integer type. */

	public struct TSize
	{
		public FixedInt cx;
		public FixedInt cy;
		public TSize(TSize P){}
		public TSize(FixedInt X, FixedInt Y){}
		//# missing function body: public TSize Add(TSize Size);
		//# missing function body: public TSize Subtract(TSize Size);
		//# missing function body: public double Distance(TSize P2);
		//# missing function body: public bool IsZero();
		/*property Width : FixedInt read cx write cx;*/
		public FixedInt Width
		{
			get
			{
				return cx;
			}
			set
			{
				cx = value;
			}
		}
		/*property Height : FixedInt read cy write cy;*/
		public FixedInt Height
		{
			get
			{
				return cy;
			}
			set
			{
				cy = value;
			}
		}
		public static TSize CreateRecord(){return new TSize();}
	}	

	public struct TRect
	{
		//# missing function body: private FixedInt GetWidth();
		//# missing function body: private void SetWidth(FixedInt Value);
		//# missing function body: private FixedInt GetHeight();
		//# missing function body: private void SetHeight(FixedInt Value);
		//# missing function body: private TSize GetSize();
		//# missing function body: private void SetSize(TSize Value);
		//# missing function body: private TPoint GetLocation();
		public FixedInt Left;
		public FixedInt Top;
		public FixedInt Right;
		public FixedInt Bottom;
		public TRect(TPoint Origin){}
		public TRect(TPoint Origin, FixedInt Width, FixedInt Height){}
		public TRect(FixedInt ALeft, FixedInt ATop, FixedInt ARight, FixedInt ABottom){}
		public TRect(TPoint P1, TPoint P2, bool Normalize = false){}
		public TRect(TRect R, bool Normalize = false){}
		//# missing function body: public static TRect Empty();
		//# missing function body: public bool IsEmpty();
		//# missing function body: public bool Contains(TPoint Pt);
		//# missing function body: public bool Contains(TRect R);
		//# missing function body: public bool IntersectsWith(TRect R);
		//# missing function body: public TRect Intersect(TRect R);
		//# missing function body: public TRect Union(TRect R);
		//# missing function body: public TPoint CenterPoint();
		//# missing function body: public TRect CenteredRect(TRect R);
		//# missing function body: public TRect SplitRect(TSplitRectType SplitType, int Size);
		//# missing function body: public TRect SplitRect(TSplitRectType SplitType, double Percent);
		//# missing function body: public void NormalizeRect();
		//# missing function body: public void Offset(FixedInt DX, FixedInt DY);
		//# missing function body: public void Offset(TPoint Point);
		//# missing function body: public void Inflate(FixedInt DX, FixedInt DY);
		/*property Width : FixedInt read GetWidth write SetWidth;*/
		public FixedInt Width
		{
			get
			{
				return GetWidth();
			}
			set
			{
				SetWidth(value);
			}
		}
		/*property Height : FixedInt read GetHeight write SetHeight;*/
		public FixedInt Height
		{
			get
			{
				return GetHeight();
			}
			set
			{
				SetHeight(value);
			}
		}
		/*property Size : TSize read GetSize write SetSize;*/
		public TSize Size
		{
			get
			{
				return GetSize();
			}
			set
			{
				SetSize(value);
			}
		}
		/*property Location : TPoint read GetLocation;*/
		public TPoint Location
		{
			get
			{
				return GetLocation();
			}
		}
		public static TRect CreateRecord(){return new TRect();}
	}	

	public struct TPointF
	{
		public float X;
		public float Y;
		//# missing function body: public static TPointF Create(float AX, float AY);
		//# missing function body: public static TPointF Create(TPoint APoint);
		//# missing function body: public static TPointF Zero();
		//# missing function body: public TPointF Add(TPointF Point);
		//# missing function body: public TPointF Subtract(TPointF Point);
		//# missing function body: public double Distance(TPointF P2);
		//# missing function body: public bool IsZero();
		//# missing function body: public void SetLocation(float AX, float AY);
		//# missing function body: public void SetLocation(TPointF P);
		//# missing function body: public void Offset(float DX, float DY);
		//# missing function body: public void Offset(TPointF Point);
		public static TPointF CreateRecord(){return new TPointF();}
	}	

	public struct TSizeF
	{
		public float cx;
		public float cy;
		public TSizeF(TSizeF P){}
		public TSizeF(float X, float Y){}
		//# missing function body: public TSizeF Add(TSizeF Size);
		//# missing function body: public TSizeF Subtract(TSizeF Size);
		//# missing function body: public double Distance(TSizeF P2);
		//# missing function body: public bool IsZero();
		//# missing function body: public TSize Ceiling();
		//# missing function body: public TSize Truncate();
		//# missing function body: public TSize Round();
		//# missing function body: public TSizeF SwapDimensions();
		/*property Width : float read cx write cx;*/
		public float Width
		{
			get
			{
				return cx;
			}
			set
			{
				cx = value;
			}
		}
		/*property Height : float read cy write cy;*/
		public float Height
		{
			get
			{
				return cy;
			}
			set
			{
				cy = value;
			}
		}
		public static TSizeF CreateRecord(){return new TSizeF();}
	}	

	public struct TRectF
	{
		//# missing function body: private float GetWidth();
		//# missing function body: private void SetWidth(float Value);
		//# missing function body: private float GetHeight();
		//# missing function body: private void SetHeight(float Value);
		//# missing function body: private TSizeF GetSize();
		//# missing function body: private void SetSize(TSizeF Value);
		//# missing function body: private TPointF GetLocation();
		public float Left;
		public float Top;
		public float Right;
		public float Bottom;
		public TRectF(TPointF Origin){}
		public TRectF(TPointF Origin, float Width, float Height){}
		public TRectF(float ALeft, float ATop, float ARight, float ABottom){}
		public TRectF(TPointF P1, TPointF P2, bool Normalize = false){}
		public TRectF(TRectF R, bool Normalize = false){}
		public TRectF(TRect R, bool Normalize = false){}
		//# missing function body: public static TRectF Empty();
		//# missing function body: public bool IsEmpty();
		//# missing function body: public bool Contains(TPointF Pt);
		//# missing function body: public bool Contains(TRectF R);
		//# missing function body: public bool IntersectsWith(TRectF R);
		//# missing function body: public TRectF Intersect(TRectF R);
		//# missing function body: public TRectF Union(TRectF R);
		//# missing function body: public TPointF CenterPoint();
		//# missing function body: public TRectF CenteredRect(TRectF R);
		//# missing function body: public TRectF FitInto(TRectF DesignatedArea);
		//# missing function body: public TRectF FitInto(TRectF DesignatedArea, ref float Ratio);
		//# missing function body: public TRectF PlaceInto(TRectF DesignatedArea, THorzRectAlign HorzAlign, TVertRectAlign VertAlign);
		//# missing function body: public TRectF SnapToPixel(float Scale, bool PlaceBetweenPixels = true);
		//# missing function body: public TRect Ceiling();
		//# missing function body: public TRect Truncate();
		//# missing function body: public TRect Round();
		//# missing function body: public void NormalizeRect();
		//# missing function body: public void Offset(float DX, float DY);
		//# missing function body: public void Offset(TPointF Point);
		//# missing function body: public void Inflate(float DX, float DY);
		/*property Width : float read GetWidth write SetWidth;*/
		public float Width
		{
			get
			{
				return GetWidth();
			}
			set
			{
				SetWidth(value);
			}
		}
		/*property Height : float read GetHeight write SetHeight;*/
		public float Height
		{
			get
			{
				return GetHeight();
			}
			set
			{
				SetHeight(value);
			}
		}
		/*property Size : TSizeF read GetSize write SetSize;*/
		public TSizeF Size
		{
			get
			{
				return GetSize();
			}
			set
			{
				SetSize(value);
			}
		}
		/*property Location : TPointF read GetLocation;*/
		public TPointF Location
		{
			get
			{
				return GetLocation();
			}
		}
		public static TRectF CreateRecord(){return new TRectF();}
	}	/*
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.Types functionality required by D2CSharp.

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
  /* Comparison results used by routines such as System.DateUtils.CompareDate. */
	public const int LessThanValue = -1;
	public const int EqualsValue = 0;
	public const int GreaterThanValue = 1;
	public const char NullChar = '\x00';
	public const char Tabulator = '\x09';
	public const char LineFeed = '\x0a';
	public const char VerticalTab = '\x0b';
	public const char FormFeed = '\x0c';
	public const char CarriageReturn = '\x0d';
	public const char Space = '\x20';
	public const char LineSeparator = '\x2028';
	public const char ParagraphSeparator = '\x2029';
	public const char BOM_LSB_FIRST = '\xfeff';
	public const char BOM_MSB_FIRST = '\xfffe';
  /*
    Public Delphi comparison-result type.

    The documented Delphi declaration is a subrange from -1 to 1. Keeping
    the subrange here also lets D2CSharp distinguish this API type from a
    general Integer while remaining simple enough for the MockRTL.
  */
	public enum TDirection {FromBeginning,
                 FromEnd };
	public enum TDuplicates {dupIgnore,
                  dupAccept,
                  dupError };
	public enum TEndian {Little,
              Big };
	public enum TSplitRectType {srLeft,
                     srRight,
                     srTop,
                     srBottom };
	public enum THorzRectAlign {Center,
                     Left,
                     Right };
	public enum TVertRectAlign {Center,
                     Top,
                     Bottom };
	public enum TPointFType {ptInteger,
                  ptFloat };


  /*
    Compact integer point used by the public System.Types API.

    The real RTL uses the platform-compatible layout expected for TSmallPoint.
    For the MockRTL only the public fields are relevant.
  */
	//#pragma pack (push, 1)

	//#pragma pack (pop)

	
} // class TypesInterface


file class TypesImplementation
{

} // class TypesImplementation

}  // namespace Types

}  // namespace System

