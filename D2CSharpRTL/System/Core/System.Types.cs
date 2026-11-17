using System;

namespace System
{
namespace Types
{

/*
  D2CSharp Runtime Library (RTL)

  This C# source file provides the runtime implementation corresponding to
  the declaration-oriented System.Types MockRTL unit.

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

public static partial class TypesInterface
{
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

    public enum TDirection { FromBeginning, FromEnd }
    public enum TDuplicates { dupIgnore, dupAccept, dupError }
    public enum TEndian { Little, Big }
    public enum TSplitRectType { srLeft, srRight, srTop, srBottom }
    public enum THorzRectAlign { Center, Left, Right }
    public enum TVertRectAlign { Center, Top, Bottom }
    public enum TPointFType { ptInteger, ptFloat }

    public struct TSmallPoint
    {
        public short X;
        public short Y;

        public TSmallPoint(short x, short y)
        {
            X = x;
            Y = y;
        }

        public static TSmallPoint CreateRecord() => new TSmallPoint();
    }

    public struct TPoint
    {
        public int X;
        public int Y;

        public TPoint(TPoint p)
        {
            X = p.X;
            Y = p.Y;
        }

        public TPoint(int ax, int ay)
        {
            X = ax;
            Y = ay;
        }

        public static TPoint Zero() => new TPoint(0, 0);

        public TPoint Add(TPoint point) => new TPoint(X + point.X, Y + point.Y);

        public TPoint Subtract(TPoint point) => new TPoint(X - point.X, Y - point.Y);

        public double Distance(TPoint p2)
        {
            long dx = (long)p2.X - X;
            long dy = (long)p2.Y - Y;
            return global::System.Math.Sqrt((double)dx * dx + (double)dy * dy);
        }

        public bool IsZero() => X == 0 && Y == 0;

        public void SetLocation(int ax, int ay)
        {
            X = ax;
            Y = ay;
        }

        public void SetLocation(TPoint p)
        {
            X = p.X;
            Y = p.Y;
        }

        public void Offset(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public void Offset(TPoint point) => Offset(point.X, point.Y);

        public static TPoint CreateRecord() => new TPoint();
    }

    public struct TSize
    {
        public int cx;
        public int cy;

        public TSize(TSize p)
        {
            cx = p.cx;
            cy = p.cy;
        }

        public TSize(int x, int y)
        {
            cx = x;
            cy = y;
        }

        public TSize Add(TSize size) => new TSize(cx + size.cx, cy + size.cy);

        public TSize Subtract(TSize size) => new TSize(cx - size.cx, cy - size.cy);

        public double Distance(TSize p2)
        {
            long dx = (long)p2.cx - cx;
            long dy = (long)p2.cy - cy;
            return global::System.Math.Sqrt((double)dx * dx + (double)dy * dy);
        }

        public bool IsZero() => cx == 0 && cy == 0;

        public int Width
        {
            get => cx;
            set => cx = value;
        }

        public int Height
        {
            get => cy;
            set => cy = value;
        }

        public static TSize CreateRecord() => new TSize();
    }

    public struct TRect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        private int GetWidth() => Right - Left;
        private void SetWidth(int value) => Right = Left + value;
        private int GetHeight() => Bottom - Top;
        private void SetHeight(int value) => Bottom = Top + value;
        private TSize GetSize() => new TSize(GetWidth(), GetHeight());

        private void SetSize(TSize value)
        {
            Right = Left + value.cx;
            Bottom = Top + value.cy;
        }

        private TPoint GetLocation() => new TPoint(Left, Top);

        public TRect(TPoint origin)
        {
            Left = origin.X;
            Top = origin.Y;
            Right = origin.X;
            Bottom = origin.Y;
        }

        public TRect(TPoint origin, int width, int height)
        {
            Left = origin.X;
            Top = origin.Y;
            Right = origin.X + width;
            Bottom = origin.Y + height;
        }

        public TRect(int aLeft, int aTop, int aRight, int aBottom)
        {
            Left = aLeft;
            Top = aTop;
            Right = aRight;
            Bottom = aBottom;
        }

        public TRect(TPoint p1, TPoint p2, bool normalize = false)
        {
            Left = p1.X;
            Top = p1.Y;
            Right = p2.X;
            Bottom = p2.Y;
            if (normalize)
                NormalizeRect();
        }

        public TRect(TRect r, bool normalize = false)
        {
            Left = r.Left;
            Top = r.Top;
            Right = r.Right;
            Bottom = r.Bottom;
            if (normalize)
                NormalizeRect();
        }

        public static TRect Empty() => new TRect(0, 0, 0, 0);

        public bool IsEmpty() => Left >= Right || Top >= Bottom;

        public bool Contains(TPoint pt) =>
            pt.X >= Left && pt.X < Right &&
            pt.Y >= Top && pt.Y < Bottom;

        public bool Contains(TRect r) =>
            r.Left >= Left && r.Top >= Top &&
            r.Right <= Right && r.Bottom <= Bottom;

        public bool IntersectsWith(TRect r) =>
            global::System.Math.Max(Left, r.Left) <
            global::System.Math.Min(Right, r.Right) &&
            global::System.Math.Max(Top, r.Top) <
            global::System.Math.Min(Bottom, r.Bottom);

        public TRect Intersect(TRect r)
        {
            TRect result = new TRect(
                global::System.Math.Max(Left, r.Left),
                global::System.Math.Max(Top, r.Top),
                global::System.Math.Min(Right, r.Right),
                global::System.Math.Min(Bottom, r.Bottom));

            return result.IsEmpty() ? Empty() : result;
        }

        public TRect Union(TRect r)
        {
            if (IsEmpty()) return r;
            if (r.IsEmpty()) return this;

            return new TRect(
                global::System.Math.Min(Left, r.Left),
                global::System.Math.Min(Top, r.Top),
                global::System.Math.Max(Right, r.Right),
                global::System.Math.Max(Bottom, r.Bottom));
        }

        public TPoint CenterPoint() =>
            new TPoint(Left + Width / 2, Top + Height / 2);

        public TRect CenteredRect(TRect r)
        {
            int width = r.Width;
            int height = r.Height;
            int left = Left + (Width - width) / 2;
            int top = Top + (Height - height) / 2;
            return new TRect(left, top, left + width, top + height);
        }

        public TRect SplitRect(TSplitRectType splitType, int size)
        {
            int amount = global::System.Math.Max(0, size);
            switch (splitType)
            {
                case TSplitRectType.srLeft:
                    return new TRect(Left, Top, global::System.Math.Min(Right, Left + amount), Bottom);
                case TSplitRectType.srRight:
                    return new TRect(global::System.Math.Max(Left, Right - amount), Top, Right, Bottom);
                case TSplitRectType.srTop:
                    return new TRect(Left, Top, Right, global::System.Math.Min(Bottom, Top + amount));
                case TSplitRectType.srBottom:
                    return new TRect(Left, global::System.Math.Max(Top, Bottom - amount), Right, Bottom);
                default:
                    return Empty();
            }
        }

        public TRect SplitRect(TSplitRectType splitType, double percent)
        {
            double p = global::System.Math.Max(0.0D, global::System.Math.Min(1.0D, percent));
            int size = splitType == TSplitRectType.srLeft || splitType == TSplitRectType.srRight
                ? (int)global::System.Math.Round(Width * p)
                : (int)global::System.Math.Round(Height * p);
            return SplitRect(splitType, size);
        }

        public void NormalizeRect()
        {
            if (Left > Right)
            {
                int t = Left; Left = Right; Right = t;
            }
            if (Top > Bottom)
            {
                int t = Top; Top = Bottom; Bottom = t;
            }
        }

        public void Offset(int dx, int dy)
        {
            Left += dx;
            Right += dx;
            Top += dy;
            Bottom += dy;
        }

        public void Offset(TPoint point) => Offset(point.X, point.Y);

        public void Inflate(int dx, int dy)
        {
            Left -= dx;
            Right += dx;
            Top -= dy;
            Bottom += dy;
        }

        public int Width
        {
            get => GetWidth();
            set => SetWidth(value);
        }

        public int Height
        {
            get => GetHeight();
            set => SetHeight(value);
        }

        public TSize Size
        {
            get => GetSize();
            set => SetSize(value);
        }

        public TPoint Location => GetLocation();

        public static TRect CreateRecord() => new TRect();
    }

    public struct TPointF
    {
        public float X;
        public float Y;

        public static TPointF Create(float ax, float ay) => new TPointF { X = ax, Y = ay };
        public static TPointF Create(TPoint point) => new TPointF { X = point.X, Y = point.Y };
        public static TPointF Zero() => new TPointF();

        public TPointF Add(TPointF point) => Create(X + point.X, Y + point.Y);
        public TPointF Subtract(TPointF point) => Create(X - point.X, Y - point.Y);

        public double Distance(TPointF p2)
        {
            double dx = p2.X - X;
            double dy = p2.Y - Y;
            return global::System.Math.Sqrt(dx * dx + dy * dy);
        }

        public bool IsZero() => X == 0.0F && Y == 0.0F;

        public void SetLocation(float ax, float ay)
        {
            X = ax;
            Y = ay;
        }

        public void SetLocation(TPointF p)
        {
            X = p.X;
            Y = p.Y;
        }

        public void Offset(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }

        public void Offset(TPointF point) => Offset(point.X, point.Y);

        public static TPointF CreateRecord() => new TPointF();
    }

    public struct TSizeF
    {
        public float cx;
        public float cy;

        public TSizeF(TSizeF p)
        {
            cx = p.cx;
            cy = p.cy;
        }

        public TSizeF(float x, float y)
        {
            cx = x;
            cy = y;
        }

        public TSizeF Add(TSizeF size) => new TSizeF(cx + size.cx, cy + size.cy);
        public TSizeF Subtract(TSizeF size) => new TSizeF(cx - size.cx, cy - size.cy);

        public double Distance(TSizeF p2)
        {
            double dx = p2.cx - cx;
            double dy = p2.cy - cy;
            return global::System.Math.Sqrt(dx * dx + dy * dy);
        }

        public bool IsZero() => cx == 0.0F && cy == 0.0F;

        public TSize Ceiling() =>
            new TSize(
                checked((int)global::System.Math.Ceiling(cx)),
                checked((int)global::System.Math.Ceiling(cy)));

        public TSize Truncate() =>
            new TSize(checked((int)cx), checked((int)cy));

        public TSize Round() =>
            new TSize(
                checked((int)global::System.Math.Round(cx)),
                checked((int)global::System.Math.Round(cy)));

        public TSizeF SwapDimensions() => new TSizeF(cy, cx);

        public float Width
        {
            get => cx;
            set => cx = value;
        }

        public float Height
        {
            get => cy;
            set => cy = value;
        }

        public static TSizeF CreateRecord() => new TSizeF();
    }

    public struct TRectF
    {
        public float Left;
        public float Top;
        public float Right;
        public float Bottom;

        private float GetWidth() => Right - Left;
        private void SetWidth(float value) => Right = Left + value;
        private float GetHeight() => Bottom - Top;
        private void SetHeight(float value) => Bottom = Top + value;
        private TSizeF GetSize() => new TSizeF(GetWidth(), GetHeight());

        private void SetSize(TSizeF value)
        {
            Right = Left + value.cx;
            Bottom = Top + value.cy;
        }

        private TPointF GetLocation() => TPointF.Create(Left, Top);

        public TRectF(TPointF origin)
        {
            Left = origin.X;
            Top = origin.Y;
            Right = origin.X;
            Bottom = origin.Y;
        }

        public TRectF(TPointF origin, float width, float height)
        {
            Left = origin.X;
            Top = origin.Y;
            Right = origin.X + width;
            Bottom = origin.Y + height;
        }

        public TRectF(float aLeft, float aTop, float aRight, float aBottom)
        {
            Left = aLeft;
            Top = aTop;
            Right = aRight;
            Bottom = aBottom;
        }

        public TRectF(TPointF p1, TPointF p2, bool normalize = false)
        {
            Left = p1.X;
            Top = p1.Y;
            Right = p2.X;
            Bottom = p2.Y;
            if (normalize)
                NormalizeRect();
        }

        public TRectF(TRectF r, bool normalize = false)
        {
            Left = r.Left;
            Top = r.Top;
            Right = r.Right;
            Bottom = r.Bottom;
            if (normalize)
                NormalizeRect();
        }

        public TRectF(TRect r, bool normalize = false)
        {
            Left = r.Left;
            Top = r.Top;
            Right = r.Right;
            Bottom = r.Bottom;
            if (normalize)
                NormalizeRect();
        }

        public static TRectF Empty() => new TRectF(0, 0, 0, 0);

        public bool IsEmpty() => Left >= Right || Top >= Bottom;

        public bool Contains(TPointF pt) =>
            pt.X >= Left && pt.X < Right &&
            pt.Y >= Top && pt.Y < Bottom;

        public bool Contains(TRectF r) =>
            r.Left >= Left && r.Top >= Top &&
            r.Right <= Right && r.Bottom <= Bottom;

        public bool IntersectsWith(TRectF r) =>
            global::System.Math.Max(Left, r.Left) <
            global::System.Math.Min(Right, r.Right) &&
            global::System.Math.Max(Top, r.Top) <
            global::System.Math.Min(Bottom, r.Bottom);

        public TRectF Intersect(TRectF r)
        {
            TRectF result = new TRectF(
                global::System.Math.Max(Left, r.Left),
                global::System.Math.Max(Top, r.Top),
                global::System.Math.Min(Right, r.Right),
                global::System.Math.Min(Bottom, r.Bottom));

            return result.IsEmpty() ? Empty() : result;
        }

        public TRectF Union(TRectF r)
        {
            if (IsEmpty()) return r;
            if (r.IsEmpty()) return this;

            return new TRectF(
                global::System.Math.Min(Left, r.Left),
                global::System.Math.Min(Top, r.Top),
                global::System.Math.Max(Right, r.Right),
                global::System.Math.Max(Bottom, r.Bottom));
        }

        public TPointF CenterPoint() =>
            TPointF.Create(Left + Width * 0.5F, Top + Height * 0.5F);

        public TRectF CenteredRect(TRectF r)
        {
            float width = r.Width;
            float height = r.Height;
            float left = Left + (Width - width) * 0.5F;
            float top = Top + (Height - height) * 0.5F;
            return new TRectF(left, top, left + width, top + height);
        }

        public TRectF FitInto(TRectF designatedArea)
        {
            float ratio = 1.0F;
            return FitInto(designatedArea, ref ratio);
        }

        public TRectF FitInto(TRectF designatedArea, ref float ratio)
        {
            if (IsEmpty() || designatedArea.IsEmpty())
            {
                ratio = 0.0F;
                return Empty();
            }

            float widthRatio = designatedArea.Width / Width;
            float heightRatio = designatedArea.Height / Height;
            ratio = global::System.Math.Min(widthRatio, heightRatio);

            float width = Width * ratio;
            float height = Height * ratio;
            float left = designatedArea.Left + (designatedArea.Width - width) * 0.5F;
            float top = designatedArea.Top + (designatedArea.Height - height) * 0.5F;
            return new TRectF(left, top, left + width, top + height);
        }

        public TRectF PlaceInto(
            TRectF designatedArea,
            THorzRectAlign horzAlign,
            TVertRectAlign vertAlign)
        {
            float left;
            float top;

            switch (horzAlign)
            {
                case THorzRectAlign.Left:
                    left = designatedArea.Left;
                    break;
                case THorzRectAlign.Right:
                    left = designatedArea.Right - Width;
                    break;
                default:
                    left = designatedArea.Left + (designatedArea.Width - Width) * 0.5F;
                    break;
            }

            switch (vertAlign)
            {
                case TVertRectAlign.Top:
                    top = designatedArea.Top;
                    break;
                case TVertRectAlign.Bottom:
                    top = designatedArea.Bottom - Height;
                    break;
                default:
                    top = designatedArea.Top + (designatedArea.Height - Height) * 0.5F;
                    break;
            }

            return new TRectF(left, top, left + Width, top + Height);
        }

        public TRectF SnapToPixel(float scale, bool placeBetweenPixels = true)
        {
            if (scale <= 0.0F)
                return this;

            float offset = placeBetweenPixels ? 0.5F / scale : 0.0F;

            float Snap(float value)
            {
                return (float)(global::System.Math.Round((value - offset) * scale) / scale + offset);
            }

            return new TRectF(Snap(Left), Snap(Top), Snap(Right), Snap(Bottom));
        }

        public TRect Ceiling() =>
            new TRect(
                checked((int)global::System.Math.Ceiling(Left)),
                checked((int)global::System.Math.Ceiling(Top)),
                checked((int)global::System.Math.Ceiling(Right)),
                checked((int)global::System.Math.Ceiling(Bottom)));

        public TRect Truncate() =>
            new TRect(
                checked((int)Left),
                checked((int)Top),
                checked((int)Right),
                checked((int)Bottom));

        public TRect Round() =>
            new TRect(
                checked((int)global::System.Math.Round(Left)),
                checked((int)global::System.Math.Round(Top)),
                checked((int)global::System.Math.Round(Right)),
                checked((int)global::System.Math.Round(Bottom)));

        public void NormalizeRect()
        {
            if (Left > Right)
            {
                float t = Left; Left = Right; Right = t;
            }
            if (Top > Bottom)
            {
                float t = Top; Top = Bottom; Bottom = t;
            }
        }

        public void Offset(float dx, float dy)
        {
            Left += dx;
            Right += dx;
            Top += dy;
            Bottom += dy;
        }

        public void Offset(TPointF point) => Offset(point.X, point.Y);

        public void Inflate(float dx, float dy)
        {
            Left -= dx;
            Right += dx;
            Top -= dy;
            Bottom += dy;
        }

        public float Width
        {
            get => GetWidth();
            set => SetWidth(value);
        }

        public float Height
        {
            get => GetHeight();
            set => SetHeight(value);
        }

        public TSizeF Size
        {
            get => GetSize();
            set => SetSize(value);
        }

        public TPointF Location => GetLocation();

        public static TRectF CreateRecord() => new TRectF();
    }

    public static TPoint point(int x, int y) => new TPoint(x, y);

    public static TSmallPoint SmallPoint(int x, int y) =>
        new TSmallPoint(checked((short)x), checked((short)y));

    public static TSmallPoint SmallPoint(uint xy) =>
        new TSmallPoint(
            unchecked((short)(xy & 0xFFFF)),
            unchecked((short)((xy >> 16) & 0xFFFF)));

    public static TRect Rect(int left, int top, int right, int bottom) =>
        new TRect(left, top, right, bottom);

    public static TRect Bounds(int aLeft, int aTop, int aWidth, int aHeight) =>
        new TRect(aLeft, aTop, aLeft + aWidth, aTop + aHeight);

    public static TPointF PointF(float x, float y) => TPointF.Create(x, y);

    public static TRectF RectF(float left, float top, float right, float bottom) =>
        new TRectF(left, top, right, bottom);

    public static TRectF BoundsF(float aLeft, float aTop, float aWidth, float aHeight) =>
        new TRectF(aLeft, aTop, aLeft + aWidth, aTop + aHeight);

    public static bool EqualRect(TRect r1, TRect r2) =>
        r1.Left == r2.Left && r1.Top == r2.Top &&
        r1.Right == r2.Right && r1.Bottom == r2.Bottom;

    public static bool EqualRect(TRectF r1, TRectF r2) =>
        r1.Left == r2.Left && r1.Top == r2.Top &&
        r1.Right == r2.Right && r1.Bottom == r2.Bottom;

    public static bool IsRectEmpty(TRect rect) => rect.IsEmpty();
    public static bool IsRectEmpty(TRectF rect) => rect.IsEmpty();

    public static bool PtInRect(TRect rect, TPoint p) => rect.Contains(p);
    public static bool PtInRect(TRectF rect, TPointF p) => rect.Contains(p);

    public static bool PtInCircle(TPoint point, TPoint center, int radius)
    {
        long dx = (long)point.X - center.X;
        long dy = (long)point.Y - center.Y;
        long rr = (long)radius * radius;
        return dx * dx + dy * dy <= rr;
    }

    public static bool IntersectRect(TRect rect1, TRect rect2) =>
        rect1.IntersectsWith(rect2);

    public static bool IntersectRect(out TRect rect, TRect r1, TRect r2)
    {
        rect = r1.Intersect(r2);
        return !rect.IsEmpty();
    }

    public static bool IntersectRect(TRectF rect1, TRectF rect2) =>
        rect1.IntersectsWith(rect2);

    public static bool IntersectRect(out TRectF rect, TRectF r1, TRectF r2)
    {
        rect = r1.Intersect(r2);
        return !rect.IsEmpty();
    }

    public static bool UnionRect(out TRect rect, TRect r1, TRect r2)
    {
        rect = r1.Union(r2);
        return !rect.IsEmpty();
    }

    public static bool UnionRect(out TRectF rect, TRectF r1, TRectF r2)
    {
        rect = r1.Union(r2);
        return !rect.IsEmpty();
    }

    public static TRect UnionRect(TRect aRect1, TRect aRect2) =>
        aRect1.Union(aRect2);

    public static TRectF UnionRect(TRectF aRect1, TRectF aRect2) =>
        aRect1.Union(aRect2);

    public static bool OffsetRect(ref TRect rect, int dx, int dy)
    {
        rect.Offset(dx, dy);
        return true;
    }

    public static bool OffsetRect(ref TRectF rect, float dx, float dy)
    {
        rect.Offset(dx, dy);
        return true;
    }

    public static bool InflateRect(ref TRect rect, int dx, int dy)
    {
        rect.Inflate(dx, dy);
        return true;
    }

    public static bool InflateRect(ref TRectF rect, float dx, float dy)
    {
        rect.Inflate(dx, dy);
        return true;
    }

    public static TPoint CenterPoint(TRect rect) => rect.CenterPoint();
    public static TPointF CenterPoint(TRectF rect) => rect.CenterPoint();

    public static TRect RectCenter(ref TRect r, TRect bounds)
    {
        r = bounds.CenteredRect(r);
        return r;
    }

    public static TRectF RectCenter(ref TRectF r, TRectF bounds)
    {
        r = bounds.CenteredRect(r);
        return r;
    }

    public static int RectWidth(TRect rect) => rect.Width;
    public static float RectWidth(TRectF rect) => rect.Width;
    public static int RectHeight(TRect rect) => rect.Height;
    public static float RectHeight(TRectF rect) => rect.Height;

    public static TPoint ScalePoint(TPoint p, float dx, float dy) =>
        new TPoint(
            checked((int)global::System.Math.Round(p.X * dx)),
            checked((int)global::System.Math.Round(p.Y * dy)));

    public static TPointF ScalePoint(TPointF p, float dx, float dy) =>
        TPointF.Create(p.X * dx, p.Y * dy);

    public static TRect SplitRect(TRect rect, TSplitRectType splitType, int size) =>
        rect.SplitRect(splitType, size);

    public static TRect SplitRect(TRect rect, TSplitRectType splitType, double percent) =>
        rect.SplitRect(splitType, percent);
}

file static class TypesImplementation
{
}

} // namespace Types
} // namespace System
