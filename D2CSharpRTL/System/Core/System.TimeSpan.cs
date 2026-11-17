using System;
using static System.SystemInterface;
using static System.Timespan.TimespanImplementation;
using static System.Timespan.TimespanInterface;

namespace System
{

namespace Timespan
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.TimeSpan.
  Public TTimeSpan declarations for conversion and RTL development.
  Methods intentionally return default values; no time calculations are performed.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/


public class TimespanInterface
{

	public struct TTimeSpan
	{
		private long FTicks;
		private static TTimeSpan FMinValue;
		private static TTimeSpan FMaxValue;
		private static TTimeSpan FZero;
		private int GetDays()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private int GetHours()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private int GetMinutes()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private int GetSeconds()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private int GetMilliseconds()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private double GetTotalDays()
		{
			double result = 0.0D;
			result = 0.0F;
			return result;
		}
		private double GetTotalHours()
		{
			double result = 0.0D;
			result = 0.0F;
			return result;
		}
		private double GetTotalMinutes()
		{
			double result = 0.0D;
			result = 0.0F;
			return result;
		}
		private double GetTotalSeconds()
		{
			double result = 0.0D;
			result = 0.0F;
			return result;
		}
		private double GetTotalMilliseconds()
		{
			double result = 0.0D;
			result = 0.0F;
			return result;
		}
		public const int TicksPerMillisecond = 10000;
		public const long TicksPerSecond = ((long) 10000000);
		public const long TicksPerMinute = ((long) 600000000);
		public const long TicksPerHour = ((long) 36000000000);
		public const long TicksPerDay = ((long) 864000000000);
		public TTimeSpan(long ATicks)
		{
			FTicks = 0;
		}
		public void Create(long ATicks)
		{
			FTicks = 0;
		}
		public TTimeSpan(int Hours, int Minutes, int Seconds)
		{
			FTicks = 0;
		}
		public void Create(int Hours, int Minutes, int Seconds)
		{
			FTicks = 0;
		}
		public TTimeSpan(int Days, int Hours, int Minutes, int Seconds)
		{
			FTicks = 0;
		}
		public void Create(int Days, int Hours, int Minutes, int Seconds)
		{
			FTicks = 0;
		}
		public TTimeSpan(int Days, int Hours, int Minutes, int Seconds, int Milliseconds)
		{
			FTicks = 0;
		}
		public void Create(int Days, int Hours, int Minutes, int Seconds, int Milliseconds)
		{
			FTicks = 0;
		}
		public TTimeSpan Add(TTimeSpan TS)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public TTimeSpan Duration()
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public TTimeSpan Negate()
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public TTimeSpan Subtract(TTimeSpan TS)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public string ToString()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static TTimeSpan FromDays(double Value)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TTimeSpan FromHours(double Value)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TTimeSpan FromMinutes(double Value)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TTimeSpan FromSeconds(double Value)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TTimeSpan FromMilliseconds(double Value)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TTimeSpan FromTicks(long Value)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TTimeSpan Subtract(TDateTime D1, TDateTime D2)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TTimeSpan Parse(string S)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static bool TryParse(string S, out TTimeSpan Value)
		{
			Value = TTimeSpan.CreateRecord(); //# clear out parameter
			bool result = false;

			Value.FTicks = 0;
			result = false;
			return result;
		}
		public static TTimeSpan operator + (TTimeSpan Left, TTimeSpan Right)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TDateTime operator + (TTimeSpan Left, TDateTime Right)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime operator + (TDateTime Left, TTimeSpan Right)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TTimeSpan operator - (TTimeSpan Left, TTimeSpan Right)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TDateTime operator - (TDateTime Left, TTimeSpan Right)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static bool operator == (TTimeSpan Left, TTimeSpan Right)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool operator != (TTimeSpan Left, TTimeSpan Right)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool operator > (TTimeSpan Left, TTimeSpan Right)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool operator >= (TTimeSpan Left, TTimeSpan Right)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool operator < (TTimeSpan Left, TTimeSpan Right)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool operator <= (TTimeSpan Left, TTimeSpan Right)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static TTimeSpan operator - (TTimeSpan Value)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		public static TTimeSpan operator + (TTimeSpan Value)
		{
			TTimeSpan result = TTimeSpan.CreateRecord();
			result.FTicks = 0;
			return result;
		}
		// One C# implicit conversion supports both assignment and explicit casts.
		public static implicit operator string (TTimeSpan Value)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		/*property Ticks : long read FTicks;*/
		public long Ticks
		{
			get
			{
				return FTicks;
			}
		}
		/*property Days : int read GetDays;*/
		public int Days
		{
			get
			{
				return GetDays();
			}
		}
		/*property Hours : int read GetHours;*/
		public int Hours
		{
			get
			{
				return GetHours();
			}
		}
		/*property Minutes : int read GetMinutes;*/
		public int Minutes
		{
			get
			{
				return GetMinutes();
			}
		}
		/*property Seconds : int read GetSeconds;*/
		public int Seconds
		{
			get
			{
				return GetSeconds();
			}
		}
		/*property Milliseconds : int read GetMilliseconds;*/
		public int Milliseconds
		{
			get
			{
				return GetMilliseconds();
			}
		}
		/*property TotalDays : double read GetTotalDays;*/
		public double TotalDays
		{
			get
			{
				return GetTotalDays();
			}
		}
		/*property TotalHours : double read GetTotalHours;*/
		public double TotalHours
		{
			get
			{
				return GetTotalHours();
			}
		}
		/*property TotalMinutes : double read GetTotalMinutes;*/
		public double TotalMinutes
		{
			get
			{
				return GetTotalMinutes();
			}
		}
		/*property TotalSeconds : double read GetTotalSeconds;*/
		public double TotalSeconds
		{
			get
			{
				return GetTotalSeconds();
			}
		}
		/*property TotalMilliseconds : double read GetTotalMilliseconds;*/
		public double TotalMilliseconds
		{
			get
			{
				return GetTotalMilliseconds();
			}
		}
		/*property MinValue : TTimeSpan read FMinValue;*/
		public static TTimeSpan MinValue
		{
			get
			{
				return FMinValue;
			}
		}
		/*property MaxValue : TTimeSpan read FMaxValue;*/
		public static TTimeSpan MaxValue
		{
			get
			{
				return FMaxValue;
			}
		}
		/*property Zero : TTimeSpan read FZero;*/
		public static TTimeSpan Zero
		{
			get
			{
				return FZero;
			}
		}
		public static TTimeSpan CreateRecord(){return new TTimeSpan();}
	}	/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.TimeSpan.
  Public TTimeSpan declarations for conversion and RTL development.
  Methods intentionally return default values; no time calculations are performed.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/
	
} // class TimespanInterface


file class TimespanImplementation
{

} // class TimespanImplementation

}  // namespace Timespan

}  // namespace System

