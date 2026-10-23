{
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
}

unit System.Types;

interface

const
  { Comparison results used by routines such as System.DateUtils.CompareDate. }
  LessThanValue    = -1;
  EqualsValue      = 0;
  GreaterThanValue = 1;

  NullChar           = #0;
  Tabulator          = #9;
  LineFeed           = #10;
  VerticalTab        = #11;
  FormFeed           = #12;
  CarriageReturn     = #13;
  Space              = #32;
  LineSeparator      = #$2028;
  ParagraphSeparator = #$2029;
  BOM_LSB_FIRST      = #$FEFF;
  BOM_MSB_FIRST      = #$FFFE;

type
  {
    Public Delphi comparison-result type.

    The documented Delphi declaration is a subrange from -1 to 1. Keeping
    the subrange here also lets D2CSharp distinguish this API type from a
    general Integer while remaining simple enough for the MockRTL.
  }
  TDirection = (
    FromBeginning,
    FromEnd
  );

  TDuplicates = (
    dupIgnore,
    dupAccept,
    dupError
  );

  TEndian = (
    Little,
    Big
  );

  TSplitRectType = (
    srLeft,
    srRight,
    srTop,
    srBottom
  );

  THorzRectAlign = (
    Center,
    Left,
    Right
  );

  TVertRectAlign = (
    Center,
    Top,
    Bottom
  );

  TPointFType = (
    ptInteger,
    ptFloat
  );

  TStringDynArray = array of string;
  TClassicStringDynArray = array of string;
  TByteDynArray = array of Byte;
  TClassicByteDynArray = array of Byte;

  TValueRelationship = -1..1;

  {
    Compact integer point used by the public System.Types API.

    The real RTL uses the platform-compatible layout expected for TSmallPoint.
    For the MockRTL only the public fields are relevant.
  }
  TSmallPoint = packed record
  public
    X: SmallInt;
    Y: SmallInt;
  end;

  { Integer point using Delphi's fixed-width signed integer type. }
  TPoint = record
  public
    X: FixedInt;
    Y: FixedInt;

    constructor Create(P: TPoint); overload;
    constructor Create(const AX, AY: FixedInt); overload;

    class function Zero: TPoint; static;

    function Add(const Point: TPoint): TPoint;
    function Subtract(const Point: TPoint): TPoint;
    function Distance(const P2: TPoint): Double;
    function IsZero: Boolean;

    procedure SetLocation(const AX, AY: FixedInt); overload;
    procedure SetLocation(const P: TPoint); overload;
    procedure Offset(const DX, DY: FixedInt); overload;
    procedure Offset(const Point: TPoint); overload;
  end;

  { Integer size using Delphi's fixed-width signed integer type. }
  TSize = record
  public
    cx: FixedInt;
    cy: FixedInt;

    constructor Create(P: TSize); overload;
    constructor Create(const X, Y: FixedInt); overload;

    function Add(const Size: TSize): TSize;
    function Subtract(const Size: TSize): TSize;
    function Distance(const P2: TSize): Double;
    function IsZero: Boolean;

    property Width: FixedInt read cx write cx;
    property Height: FixedInt read cy write cy;
  end;

  TRect = record
  private
    function GetWidth: FixedInt;
    procedure SetWidth(const Value: FixedInt);
    function GetHeight: FixedInt;
    procedure SetHeight(const Value: FixedInt);
    function GetSize: TSize;
    procedure SetSize(const Value: TSize);
    function GetLocation: TPoint;
  public
    Left: FixedInt;
    Top: FixedInt;
    Right: FixedInt;
    Bottom: FixedInt;

    constructor Create(const Origin: TPoint); overload;
    constructor Create(
      const Origin: TPoint;
      Width, Height: FixedInt
    ); overload;
    constructor Create(
      const ALeft, ATop, ARight, ABottom: FixedInt
    ); overload;
    constructor Create(
      const P1, P2: TPoint;
      Normalize: Boolean = False
    ); overload;
    constructor Create(
      const R: TRect;
      Normalize: Boolean = False
    ); overload;

    class function Empty: TRect; static;

    function IsEmpty: Boolean;
    function Contains(const Pt: TPoint): Boolean; overload;
    function Contains(const R: TRect): Boolean; overload;
    function IntersectsWith(const R: TRect): Boolean;
    function Intersect(const R: TRect): TRect;
    function Union(const R: TRect): TRect;
    function CenterPoint: TPoint;
    function CenteredRect(const R: TRect): TRect;
    function SplitRect(SplitType: TSplitRectType; Size: Integer): TRect; overload;
    function SplitRect(SplitType: TSplitRectType; Percent: Double): TRect; overload;

    procedure NormalizeRect;
    procedure Offset(const DX, DY: FixedInt); overload;
    procedure Offset(const Point: TPoint); overload;
    procedure Inflate(const DX, DY: FixedInt); overload;

    property Width: FixedInt read GetWidth write SetWidth;
    property Height: FixedInt read GetHeight write SetHeight;
    property Size: TSize read GetSize write SetSize;
    property Location: TPoint read GetLocation;
  end;

  TPointF = record
  public
    X: Single;
    Y: Single;

    class function Create(const AX, AY: Single): TPointF; overload; static;
    class function Create(const APoint: TPoint): TPointF; overload; static;
    class function Zero: TPointF; static;

    function Add(const Point: TPointF): TPointF;
    function Subtract(const Point: TPointF): TPointF;
    function Distance(const P2: TPointF): Double;
    function IsZero: Boolean;

    procedure SetLocation(const AX, AY: Single); overload;
    procedure SetLocation(const P: TPointF); overload;
    procedure Offset(const DX, DY: Single); overload;
    procedure Offset(const Point: TPointF); overload;
  end;

  TSizeF = record
  public
    cx: Single;
    cy: Single;

    constructor Create(P: TSizeF); overload;
    constructor Create(const X, Y: Single); overload;

    function Add(const Size: TSizeF): TSizeF;
    function Subtract(const Size: TSizeF): TSizeF;
    function Distance(const P2: TSizeF): Double;
    function IsZero: Boolean;
    function Ceiling: TSize;
    function Truncate: TSize;
    function Round: TSize;
    function SwapDimensions: TSizeF;

    property Width: Single read cx write cx;
    property Height: Single read cy write cy;
  end;

  TRectF = record
  private
    function GetWidth: Single;
    procedure SetWidth(const Value: Single);
    function GetHeight: Single;
    procedure SetHeight(const Value: Single);
    function GetSize: TSizeF;
    procedure SetSize(const Value: TSizeF);
    function GetLocation: TPointF;
  public
    Left: Single;
    Top: Single;
    Right: Single;
    Bottom: Single;

    constructor Create(const Origin: TPointF); overload;
    constructor Create(
      const Origin: TPointF;
      const Width, Height: Single
    ); overload;
    constructor Create(
      const ALeft, ATop, ARight, ABottom: Single
    ); overload;
    constructor Create(
      const P1, P2: TPointF;
      Normalize: Boolean = False
    ); overload;
    constructor Create(
      const R: TRectF;
      Normalize: Boolean = False
    ); overload;
    constructor Create(
      const R: TRect;
      Normalize: Boolean = False
    ); overload;

    class function Empty: TRectF; static;

    function IsEmpty: Boolean;
    function Contains(const Pt: TPointF): Boolean; overload;
    function Contains(const R: TRectF): Boolean; overload;
    function IntersectsWith(const R: TRectF): Boolean;
    function Intersect(const R: TRectF): TRectF;
    function Union(const R: TRectF): TRectF;
    function CenterPoint: TPointF;
    function CenteredRect(const R: TRectF): TRectF;
    function FitInto(const DesignatedArea: TRectF): TRectF; overload;
    function FitInto(const DesignatedArea: TRectF; var Ratio: Single): TRectF; overload;
    function PlaceInto(
      const DesignatedArea: TRectF;
      HorzAlign: THorzRectAlign;
      VertAlign: TVertRectAlign
    ): TRectF;
    function SnapToPixel(
      Scale: Single;
      PlaceBetweenPixels: Boolean = True
    ): TRectF;
    function Ceiling: TRect;
    function Truncate: TRect;
    function Round: TRect;

    procedure NormalizeRect;
    procedure Offset(const DX, DY: Single); overload;
    procedure Offset(const Point: TPointF); overload;
    procedure Inflate(const DX, DY: Single); overload;

    property Width: Single read GetWidth write SetWidth;
    property Height: Single read GetHeight write SetHeight;
    property Size: TSizeF read GetSize write SetSize;
    property Location: TPointF read GetLocation;
  end;

  PSmallPoint = ^TSmallPoint;
  PPoint = ^TPoint;
  PPointF = ^TPointF;
  PSize = ^TSize;
  PSizeF = ^TSizeF;
  PRect = ^TRect;
  PRectF = ^TRectF;

function TRectF.CenterPoint: TPointF;
begin
end;

function TRectF.CenteredRect(const R: TRectF): TRectF;
begin
end;

function TRectF.FitInto(const DesignatedArea: TRectF): TRectF;
begin
end;

function TRectF.FitInto(
  const DesignatedArea: TRectF;
  var Ratio: Single
): TRectF;
begin
end;

function TRectF.PlaceInto(
  const DesignatedArea: TRectF;
  HorzAlign: THorzRectAlign;
  VertAlign: TVertRectAlign
): TRectF;
begin
end;

function TRectF.SnapToPixel(
  Scale: Single;
  PlaceBetweenPixels: Boolean = True
): TRectF;
begin
end;

{ Construction helpers }

function Point(X, Y: FixedInt): TPoint;
function SmallPoint(X, Y: Integer): TSmallPoint; overload;
function SmallPoint(XY: LongWord): TSmallPoint; overload;
function Rect(Left, Top, Right, Bottom: FixedInt): TRect;
function Bounds(ALeft, ATop, AWidth, AHeight: FixedInt): TRect;

function PointF(X, Y: Single): TPointF;
function RectF(Left, Top, Right, Bottom: Single): TRectF;
function BoundsF(ALeft, ATop, AWidth, AHeight: Single): TRectF;

function EqualRect(const R1, R2: TRect): Boolean; overload;
function EqualRect(const R1, R2: TRectF): Boolean; overload;

function IsRectEmpty(const Rect: TRect): Boolean; overload;
function IsRectEmpty(const Rect: TRectF): Boolean; overload;

function PtInRect(const Rect: TRect; const P: TPoint): Boolean; overload;
function PtInRect(const Rect: TRectF; const P: TPointF): Boolean; overload;

function PtInCircle(
  const Point, Center: TPoint;
  Radius: Integer
): Boolean;

function IntersectRect(
  const Rect1, Rect2: TRect
): Boolean; overload;
function IntersectRect(
  out Rect: TRect;
  const R1, R2: TRect
): Boolean; overload;
function IntersectRect(
  const Rect1, Rect2: TRectF
): Boolean; overload;
function IntersectRect(
  out Rect: TRectF;
  const R1, R2: TRectF
): Boolean; overload;

function UnionRect(
  out Rect: TRect;
  const R1, R2: TRect
): Boolean; overload;
function UnionRect(
  out Rect: TRectF;
  const R1, R2: TRectF
): Boolean; overload;
function UnionRect(
  const ARect1, ARect2: TRect
): TRect; overload;
function UnionRect(
  const ARect1, ARect2: TRectF
): TRectF; overload;

function OffsetRect(
  var Rect: TRect;
  DX, DY: Integer
): Boolean; overload;
function OffsetRect(
  var Rect: TRectF;
  DX, DY: Single
): Boolean; overload;

function InflateRect(
  var Rect: TRect;
  DX, DY: Integer
): Boolean; overload;
function InflateRect(
  var Rect: TRectF;
  DX, DY: Single
): Boolean; overload;

function CenterPoint(const Rect: TRect): TPoint; overload;
function CenterPoint(const Rect: TRectF): TPointF; overload;

function RectCenter(var R: TRect; const Bounds: TRect): TRect; overload;
function RectCenter(var R: TRectF; const Bounds: TRectF): TRectF; overload;

function RectWidth(const Rect: TRect): Integer; overload;
function RectWidth(const Rect: TRectF): Single; overload;
function RectHeight(const Rect: TRect): Integer; overload;
function RectHeight(const Rect: TRectF): Single; overload;

function ScalePoint(
  const P: TPoint;
  DX, DY: Single
): TPoint; overload;
function ScalePoint(
  const P: TPointF;
  DX, DY: Single
): TPointF; overload;

function SplitRect(
  const Rect: TRect;
  SplitType: TSplitRectType;
  Size: Integer
): TRect; overload;
function SplitRect(
  const Rect: TRect;
  SplitType: TSplitRectType;
  Percent: Double
): TRect; overload;

implementation

{ TPoint }

constructor TPoint.Create(P: TPoint);
begin
end;

constructor TPoint.Create(const AX, AY: FixedInt);
begin
end;

class function TPoint.Zero: TPoint;
begin
end;

function TPoint.Add(const Point: TPoint): TPoint;
begin
end;

function TPoint.Subtract(const Point: TPoint): TPoint;
begin
end;

function TPoint.Distance(const P2: TPoint): Double;
begin
end;

function TPoint.IsZero: Boolean;
begin
end;

procedure TPoint.SetLocation(const AX, AY: FixedInt);
begin
end;

procedure TPoint.SetLocation(const P: TPoint);
begin
end;

procedure TPoint.Offset(const DX, DY: FixedInt);
begin
end;

procedure TPoint.Offset(const Point: TPoint);
begin
end;

{ TSize }

constructor TSize.Create(P: TSize);
begin
end;

constructor TSize.Create(const X, Y: FixedInt);
begin
end;

function TSize.Add(const Size: TSize): TSize;
begin
end;

function TSize.Subtract(const Size: TSize): TSize;
begin
end;

function TSize.Distance(const P2: TSize): Double;
begin
end;

function TSize.IsZero: Boolean;
begin
end;

{ TRect }

function TRect.GetWidth: FixedInt;
begin
end;

procedure TRect.SetWidth(const Value: FixedInt);
begin
end;

function TRect.GetHeight: FixedInt;
begin
end;

procedure TRect.SetHeight(const Value: FixedInt);
begin
end;

function TRect.GetSize: TSize;
begin
end;

procedure TRect.SetSize(const Value: TSize);
begin
end;

function TRect.GetLocation: TPoint;
begin
end;

constructor TRect.Create(const Origin: TPoint);
begin
end;

constructor TRect.Create(
  const Origin: TPoint;
  Width, Height: FixedInt
);
begin
end;

constructor TRect.Create(
  const ALeft, ATop, ARight, ABottom: FixedInt
);
begin
end;

constructor TRect.Create(
  const P1, P2: TPoint;
  Normalize: Boolean = False
);
begin
end;

constructor TRect.Create(
  const R: TRect;
  Normalize: Boolean = False
);
begin
end;

class function TRect.Empty: TRect;
begin
end;

function TRect.IsEmpty: Boolean;
begin
end;

function TRect.Contains(const Pt: TPoint): Boolean;
begin
end;

function TRect.Contains(const R: TRect): Boolean;
begin
end;

function TRect.IntersectsWith(const R: TRect): Boolean;
begin
end;

function TRect.Intersect(const R: TRect): TRect;
begin
end;

function TRect.Union(const R: TRect): TRect;
begin
end;

procedure TRect.NormalizeRect;
begin
end;

procedure TRect.Offset(const DX, DY: FixedInt);
begin
end;

procedure TRect.Offset(const Point: TPoint);
begin
end;

procedure TRect.Inflate(const DX, DY: FixedInt);
begin
end;

function TRect.CenterPoint: TPoint;
begin
end;

function TRect.CenteredRect(const R: TRect): TRect;
begin
end;

function TRect.SplitRect(
  SplitType: TSplitRectType;
  Size: Integer
): TRect;
begin
end;

function TRect.SplitRect(
  SplitType: TSplitRectType;
  Percent: Double
): TRect;
begin
end;

{ TPointF }

class function TPointF.Create(const AX, AY: Single): TPointF;
begin
end;

class function TPointF.Create(const APoint: TPoint): TPointF;
begin
end;

class function TPointF.Zero: TPointF;
begin
end;

function TPointF.Add(const Point: TPointF): TPointF;
begin
end;

function TPointF.Subtract(const Point: TPointF): TPointF;
begin
end;

function TPointF.Distance(const P2: TPointF): Double;
begin
end;

function TPointF.IsZero: Boolean;
begin
end;

procedure TPointF.SetLocation(const AX, AY: Single);
begin
end;

procedure TPointF.SetLocation(const P: TPointF);
begin
end;

procedure TPointF.Offset(const DX, DY: Single);
begin
end;

procedure TPointF.Offset(const Point: TPointF);
begin
end;

{ TSizeF }

constructor TSizeF.Create(P: TSizeF);
begin
end;

constructor TSizeF.Create(const X, Y: Single);
begin
end;

function TSizeF.Add(const Size: TSizeF): TSizeF;
begin
end;

function TSizeF.Subtract(const Size: TSizeF): TSizeF;
begin
end;

function TSizeF.Distance(const P2: TSizeF): Double;
begin
end;

function TSizeF.IsZero: Boolean;
begin
end;

function TSizeF.Ceiling: TSize;
begin
end;

function TSizeF.Truncate: TSize;
begin
end;

function TSizeF.Round: TSize;
begin
end;

function TSizeF.SwapDimensions: TSizeF;
begin
end;

{ TRectF }

function TRectF.GetWidth: Single;
begin
end;

procedure TRectF.SetWidth(const Value: Single);
begin
end;

function TRectF.GetHeight: Single;
begin
end;

procedure TRectF.SetHeight(const Value: Single);
begin
end;

function TRectF.GetSize: TSizeF;
begin
end;

procedure TRectF.SetSize(const Value: TSizeF);
begin
end;

function TRectF.GetLocation: TPointF;
begin
end;

constructor TRectF.Create(const Origin: TPointF);
begin
end;

constructor TRectF.Create(
  const Origin: TPointF;
  const Width, Height: Single
);
begin
end;

constructor TRectF.Create(
  const ALeft, ATop, ARight, ABottom: Single
);
begin
end;

constructor TRectF.Create(
  const P1, P2: TPointF;
  Normalize: Boolean = False
);
begin
end;

constructor TRectF.Create(
  const R: TRectF;
  Normalize: Boolean = False
);
begin
end;

constructor TRectF.Create(
  const R: TRect;
  Normalize: Boolean = False
);
begin
end;

class function TRectF.Empty: TRectF;
begin
end;

function TRectF.IsEmpty: Boolean;
begin
end;

function TRectF.Contains(const Pt: TPointF): Boolean;
begin
end;

function TRectF.Contains(const R: TRectF): Boolean;
begin
end;

function TRectF.IntersectsWith(const R: TRectF): Boolean;
begin
end;

function TRectF.Intersect(const R: TRectF): TRectF;
begin
end;

function TRectF.Union(const R: TRectF): TRectF;
begin
end;

function TRectF.Ceiling: TRect;
begin
end;

function TRectF.Truncate: TRect;
begin
end;

function TRectF.Round: TRect;
begin
end;

procedure TRectF.NormalizeRect;
begin
end;

procedure TRectF.Offset(const DX, DY: Single);
begin
end;

procedure TRectF.Offset(const Point: TPointF);
begin
end;

procedure TRectF.Inflate(const DX, DY: Single);
begin
end;

{ Construction helpers }

function Point(X, Y: FixedInt): TPoint;
begin
end;

function SmallPoint(X, Y: Integer): TSmallPoint;
begin
end;

function SmallPoint(XY: LongWord): TSmallPoint;
begin
end;

function Rect(Left, Top, Right, Bottom: FixedInt): TRect;
begin
end;

function Bounds(ALeft, ATop, AWidth, AHeight: FixedInt): TRect;
begin
end;

function PointF(X, Y: Single): TPointF;
begin
end;

function RectF(Left, Top, Right, Bottom: Single): TRectF;
begin
end;

function BoundsF(ALeft, ATop, AWidth, AHeight: Single): TRectF;
begin
end;


function EqualRect(const R1, R2: TRect): Boolean;
begin
end;

function EqualRect(const R1, R2: TRectF): Boolean;
begin
end;

function IsRectEmpty(const Rect: TRect): Boolean;
begin
end;

function IsRectEmpty(const Rect: TRectF): Boolean;
begin
end;

function PtInRect(const Rect: TRect; const P: TPoint): Boolean;
begin
end;

function PtInRect(const Rect: TRectF; const P: TPointF): Boolean;
begin
end;

function PtInCircle(
  const Point, Center: TPoint;
  Radius: Integer
): Boolean;
begin
end;

function IntersectRect(const Rect1, Rect2: TRect): Boolean;
begin
end;

function IntersectRect(
  out Rect: TRect;
  const R1, R2: TRect
): Boolean;
begin
end;

function IntersectRect(const Rect1, Rect2: TRectF): Boolean;
begin
end;

function IntersectRect(
  out Rect: TRectF;
  const R1, R2: TRectF
): Boolean;
begin
end;

function UnionRect(
  out Rect: TRect;
  const R1, R2: TRect
): Boolean;
begin
end;

function UnionRect(
  out Rect: TRectF;
  const R1, R2: TRectF
): Boolean;
begin
end;

function UnionRect(const ARect1, ARect2: TRect): TRect;
begin
end;

function UnionRect(const ARect1, ARect2: TRectF): TRectF;
begin
end;

function OffsetRect(
  var Rect: TRect;
  DX, DY: Integer
): Boolean;
begin
end;

function OffsetRect(
  var Rect: TRectF;
  DX, DY: Single
): Boolean;
begin
end;

function InflateRect(
  var Rect: TRect;
  DX, DY: Integer
): Boolean;
begin
end;

function InflateRect(
  var Rect: TRectF;
  DX, DY: Single
): Boolean;
begin
end;

function CenterPoint(const Rect: TRect): TPoint;
begin
end;

function CenterPoint(const Rect: TRectF): TPointF;
begin
end;

function RectCenter(var R: TRect; const Bounds: TRect): TRect;
begin
end;

function RectCenter(var R: TRectF; const Bounds: TRectF): TRectF;
begin
end;

function RectWidth(const Rect: TRect): Integer;
begin
end;

function RectWidth(const Rect: TRectF): Single;
begin
end;

function RectHeight(const Rect: TRect): Integer;
begin
end;

function RectHeight(const Rect: TRectF): Single;
begin
end;

function ScalePoint(
  const P: TPoint;
  DX, DY: Single
): TPoint;
begin
end;

function ScalePoint(
  const P: TPointF;
  DX, DY: Single
): TPointF;
begin
end;

function SplitRect(
  const Rect: TRect;
  SplitType: TSplitRectType;
  Size: Integer
): TRect;
begin
end;

function SplitRect(
  const Rect: TRect;
  SplitType: TSplitRectType;
  Percent: Double
): TRect;
begin
end;

end.
