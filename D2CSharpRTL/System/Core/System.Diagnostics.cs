using System.Timespan;
using System;
using static System.Diagnostics.DiagnosticsImplementation;
using static System.Diagnostics.DiagnosticsInterface;
using static System.SystemInterface;
using static System.Timespan.TimespanInterface;

namespace System
{

namespace Diagnostics
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.Diagnostics for D2CSharp.
  Provides the public TStopwatch API without performing time measurements.
  The method bodies return default values and intentionally have no
  runtime stopwatch behavior.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/


public class DiagnosticsInterface
{

	public struct TStopwatch
	{
		private static long FFrequency;
		private static bool FIsHighResolution;
		private static long FElapsed;
		private static bool FRunning;
		private static long FStartTimeStamp;
		private TTimeSpan GetElapsed()
		{
			TTimeSpan result;
			result = default(TTimeSpan);
			return result;
		}
		private long GetElapsedMilliseconds()
		{
			long result = 0;
			result = 0;
			return result;
		}
		private long GetElapsedTicks()
		{
			long result = 0;
			result = 0;
			return result;
		}
		public static TStopwatch Create()
		{
			TStopwatch result = TStopwatch.CreateRecord();
			//result.FElapsed = 0;
			//result.FRunning = false;
			//result.FStartTimeStamp = 0;
			return result;
		}
		public static long GetTimeStamp()
		{
			long result = 0;
			result = 0;
			return result;
		}
		public static TStopwatch StartNew()
		{
			TStopwatch result = TStopwatch.CreateRecord();
			result = Create();
			return result;
		}
		public void Reset()
		{
		}
		public void Start()
		{
		}
		public void Stop()
		{
		}
		/*property Elapsed : TTimeSpan read GetElapsed;*/
		public TTimeSpan Elapsed
		{
			get
			{
				return GetElapsed();
			}
		}
		/*property ElapsedMilliseconds : long read GetElapsedMilliseconds;*/
		public long ElapsedMilliseconds
		{
			get
			{
				return GetElapsedMilliseconds();
			}
		}
		/*property ElapsedTicks : long read GetElapsedTicks;*/
		public long ElapsedTicks
		{
			get
			{
				return GetElapsedTicks();
			}
		}
		/*property IsRunning : bool read FRunning;*/
		public bool IsRunning
		{
			get
			{
				return FRunning;
			}
		}
		/*property Frequency : long read FFrequency;*/
		public static long Frequency
		{
			get
			{
				return FFrequency;
			}
		}
		/*property IsHighResolution : bool read FIsHighResolution;*/
		public static bool IsHighResolution
		{
			get
			{
				return FIsHighResolution;
			}
		}
		public static TStopwatch CreateRecord(){return new TStopwatch();}
	}	
	
} // class DiagnosticsInterface


file class DiagnosticsImplementation
{

} // class DiagnosticsImplementation

}  // namespace Diagnostics

}  // namespace System

