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

  This Delphi source file provides a declaration-oriented mock of selected
  System.SysUtils functionality required by D2CSharp.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The routines below intentionally contain no RTL implementation.  Functions
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

public class SysutilsInterface
{

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

	public struct TFormatSettings
	{
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
			TFormatSettings result = TFormatSettings.CreateRecord();
			return result;
		}
		public static TFormatSettings Create(uint Locale)
		{
			TFormatSettings result = TFormatSettings.CreateRecord();
			return result;
		}
		public static TFormatSettings Create(string LocaleName)
		{
			TFormatSettings result = TFormatSettings.CreateRecord();
			return result;
		}
		public static TFormatSettings Invariant()
		{
			TFormatSettings result = TFormatSettings.CreateRecord();
			return result;
		}
		public int GetEraYearOffset(string Name)
		{
			int result = 0;
			return result;
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
			TDateTime result = new TDateTime();
			return result;
		}
		private TDateTime GetLastAccessTime()
		{
			TDateTime result = new TDateTime();
			return result;
		}
		private TDateTime GetTimeStamp()
		{
			TDateTime result = new TDateTime();
			return result;
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
			TDateTime result = new TDateTime();
			return result;
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
		private TWin32FindData Data;
		private TDateTime GetCreationTime()
		{
			TDateTime result = new TDateTime();
			return result;
		}
		private TDateTime GetLastAccessTime()
		{
			TDateTime result = new TDateTime();
			return result;
		}
		private TDateTime GetTimeStamp()
		{
			TDateTime result = new TDateTime();
			return result;
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
		public DException(string Msg)
		{
		}
		public DException(string Msg, params TVarRec[] Args)
		{
		}
		public DException(uint Ident)
		{
		}
		public DException(Pointer<TResStringRec> ResStringRec)
		{
		}
		public DException(uint Ident, params TVarRec[] Args)
		{
		}
		public DException(Pointer<TResStringRec> ResStringRec, params TVarRec[] Args)
		{
		}
		public DException(string Msg, int AHelpContext)
		{
		}
		public DException(string Msg, TVarRec[] Args, int AHelpContext)
		{
		}
		public DException(uint Ident, int AHelpContext)
		{
		}
		public DException(Pointer<TResStringRec> ResStringRec, int AHelpContext)
		{
		}
		public DException(Pointer<TResStringRec> ResStringRec, TVarRec[] Args, int AHelpContext)
		{
		}
		public DException(uint Ident, TVarRec[] Args, int AHelpContext)
		{
		}
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
public delegate int TGrowCollectionFunc(int OldCapacity, int NewCount);
	//#pragma pack (push, 1)

	//#pragma pack (pop)

	public static TFormatSettings FormatSettings = TFormatSettings.CreateRecord();
	public static TSysLocale SysLocale = TSysLocale.CreateRecord();
	public static TGrowCollectionFunc GrowCollectionFunc = default;

/* Integer conversion */
	public static string IntToStr(int Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToStr(long Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string UIntToStr(uint Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string UIntToStr(ulong Value)
	{
		string result = string.Empty;
		return result;
	}
	public static int StrToInt(string S)
	{
		int result = 0;
		return result;
	}
	public static int StrToIntDef(string S, int Default)
	{
		int result = 0;
		return result;
	}
	public static bool TryStrToInt(string S, out int Value)
	{
		Value = 0; //# clear out parameter
		bool result = false;
		return result;
	}
	public static long StrToInt64(string S)
	{
		long result = 0;
		return result;
	}
	public static long StrToInt64Def(string S, long Default)
	{
		long result = 0;
		return result;
	}
	public static bool TryStrToInt64(string S, out long Value)
	{
		Value = 0; //# clear out parameter
		bool result = false;
		return result;
	}
	public static uint StrToUInt(string S)
	{
		uint result = 0;
		return result;
	}
	public static uint StrToUIntDef(string S, uint Default)
	{
		uint result = 0;
		return result;
	}
	public static bool TryStrToUInt(string S, out uint Value)
	{
		Value = 0; //# clear out parameter
		bool result = false;
		return result;
	}
	public static ulong StrToUInt64(string S)
	{
		ulong result = 0;
		return result;
	}
	public static ulong StrToUInt64Def(string S, ulong Default)
	{
		ulong result = 0;
		return result;
	}
	public static bool TryStrToUInt64(string S, out ulong Value)
	{
		Value = 0; //# clear out parameter
		bool result = false;
		return result;
	}

/* Boolean conversion */
	public static string BoolToStr(bool B, bool UseBoolStrs = false)
	{
		string result = string.Empty;
		return result;
	}
	public static bool StrToBool(string S)
	{
		bool result = false;
		return result;
	}
	public static bool StrToBoolDef(string S, bool Default)
	{
		bool result = false;
		return result;
	}
	public static bool TryStrToBool(string S, out bool Value)
	{
		Value = false; //# clear out parameter
		bool result = false;
		return result;
	}

/* Hexadecimal conversion */
	public static string IntToHex(int Value, int Digits)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(long Value, int Digits)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(ulong Value, int Digits)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(sbyte Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(byte Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(short Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(ushort Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(int Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(uint Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(long Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string IntToHex(ulong Value)
	{
		string result = string.Empty;
		return result;
	}

/* Floating-point conversion */
	public static string FloatToStr(double Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string FloatToStr(double Value, TFormatSettings FormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static string FloatToStrF(double Value, TFloatFormat Format, int Precision, int Digits)
	{
		string result = string.Empty;
		return result;
	}
	public static string FloatToStrF(double Value, TFloatFormat Format, int Precision, int Digits, TFormatSettings FormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static double StrToFloat(string S)
	{
		double result = 0.0D;
		return result;
	}
	public static double StrToFloat(string S, TFormatSettings FormatSettings)
	{
		double result = 0.0D;
		return result;
	}
	public static double StrToFloatDef(string S, double Default)
	{
		double result = 0.0D;
		return result;
	}
	public static double StrToFloatDef(string S, double Default, TFormatSettings FormatSettings)
	{
		double result = 0.0D;
		return result;
	}
	public static bool TryStrToFloat(string S, out double Value)
	{
		Value = 0.0D; //# clear out parameter
		bool result = false;
		return result;
	}
	public static bool TryStrToFloat(string S, out double Value, TFormatSettings FormatSettings)
	{
		Value = 0.0D; //# clear out parameter
		bool result = false;
		return result;
	}

/* Additional floating-point/currency conversion */
	public static void FloatToDecimal(ref TFloatRec Result, UntypedPointer Value, TFloatValue ValueType, int Precision, int Decimals)
	{
	}
	public static int FloatToText(PChar BufferArg, UntypedPointer Value, TFloatValue ValueType, TFloatFormat Format, int Precision, int Digits)
	{
		int result = 0;
		return result;
	}
	public static int FloatToText(PAnsiChar BufferArg, UntypedPointer Value, TFloatValue ValueType, TFloatFormat Format, int Precision, int Digits)
	{
		int result = 0;
		return result;
	}
	public static int FloatToText(PChar BufferArg, UntypedPointer Value, TFloatValue ValueType, TFloatFormat Format, int Precision, int Digits, TFormatSettings AFormatSettings)
	{
		int result = 0;
		return result;
	}
	public static int FloatToText(PAnsiChar BufferArg, UntypedPointer Value, TFloatValue ValueType, TFloatFormat Format, int Precision, int Digits, TFormatSettings AFormatSettings)
	{
		int result = 0;
		return result;
	}
	public static int FloatToTextFmt(PAnsiChar Buf, UntypedPointer Value, TFloatValue ValueType, PAnsiChar Format)
	{
		int result = 0;
		return result;
	}
	public static int FloatToTextFmt(PAnsiChar Buf, UntypedPointer Value, TFloatValue ValueType, PAnsiChar Format, TFormatSettings AFormatSettings)
	{
		int result = 0;
		return result;
	}
	public static int FloatToTextFmt(PChar Buf, UntypedPointer Value, TFloatValue ValueType, PChar Format)
	{
		int result = 0;
		return result;
	}
	public static int FloatToTextFmt(PChar Buf, UntypedPointer Value, TFloatValue ValueType, PChar Format, TFormatSettings AFormatSettings)
	{
		int result = 0;
		return result;
	}
	public static bool TextToFloat(PChar Buffer, UntypedPointer Value, TFloatValue ValueType)
	{
		bool result = false;
		return result;
	}
	public static bool TextToFloat(PChar Buffer, UntypedPointer Value, TFloatValue ValueType, TFormatSettings AFormatSettings)
	{
		bool result = false;
		return result;
	}
	public static bool TextToFloat(PAnsiChar Buffer, UntypedPointer Value, TFloatValue ValueType)
	{
		bool result = false;
		return result;
	}
	public static bool TextToFloat(PAnsiChar Buffer, UntypedPointer Value, TFloatValue ValueType, TFormatSettings AFormatSettings)
	{
		bool result = false;
		return result;
	}
	//# output of equivalent "TextToFloat" function suppressed
	//# output of equivalent "TextToFloat" function suppressed
	public static bool TextToFloat(string S, ref double Value)
	{
		bool result = false;
		return result;
	}
	public static bool TextToFloat(string S, ref double Value, TFormatSettings AFormatSettings)
	{
		bool result = false;
		return result;
	}
	public static bool TextToFloat(string S, ref Currency Value)
	{
		bool result = false;
		return result;
	}
	public static bool TextToFloat(string S, ref Currency Value, TFormatSettings AFormatSettings)
	{
		bool result = false;
		return result;
	}
	public static Currency FloatToCurr(double Value)
	{
		Currency result = 0.0M;
		return result;
	}
	public static bool TryFloatToCurr(double Value, out Currency AResult)
	{
		AResult = 0.0M; //# clear out parameter
		bool result = false;
		return result;
	}

/* Currency conversion */
	public static string CurrToStr(Currency Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string CurrToStr(Currency Value, TFormatSettings FormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static Currency StrToCurr(string S)
	{
		Currency result = 0.0M;
		return result;
	}
	public static Currency StrToCurr(string S, TFormatSettings FormatSettings)
	{
		Currency result = 0.0M;
		return result;
	}
	public static Currency StrToCurrDef(string S, Currency Default)
	{
		Currency result = 0.0M;
		return result;
	}
	public static Currency StrToCurrDef(string S, Currency Default, TFormatSettings FormatSettings)
	{
		Currency result = 0.0M;
		return result;
	}
	public static bool TryStrToCurr(string S, out Currency Value)
	{
		Value = 0.0M; //# clear out parameter
		bool result = false;
		return result;
	}
	public static bool TryStrToCurr(string S, out Currency Value, TFormatSettings FormatSettings)
	{
		Value = 0.0M; //# clear out parameter
		bool result = false;
		return result;
	}
	public static string FormatFloat(string Format, double Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string FormatFloat(string Format, double Value, TFormatSettings AFormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static string FormatCurr(string Format, Currency Value)
	{
		string result = string.Empty;
		return result;
	}
	public static string FormatCurr(string Format, Currency Value, TFormatSettings AFormatSettings)
	{
		string result = string.Empty;
		return result;
	}

/* Date and time construction */
	public static TDateTime EncodeDate(ushort Year, ushort Month, ushort Day)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryEncodeDate(ushort Year, ushort Month, ushort Day, out TDateTime Date)
	{
		Date = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static void DecodeDate(TDateTime DateTime, out ushort Year, out ushort Month, out ushort Day)
	{
		Year = 0; //# clear out parameter
		Month = 0; //# clear out parameter
		Day = 0; //# clear out parameter
	}
	public static bool DecodeDateFully(TDateTime DateTime, ref ushort Year, ref ushort Month, ref ushort Day, ref ushort DOW)
	{
		bool result = false;
		return result;
	}
	public static TTimeStamp DateTimeToTimeStamp(TDateTime DateTime)
	{
		TTimeStamp result = TTimeStamp.CreateRecord();
		return result;
	}
	public static TDateTime TimeStampToDateTime(TTimeStamp TimeStamp)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TTimeStamp MSecsToTimeStamp(long MSecs)
	{
		TTimeStamp result = TTimeStamp.CreateRecord();
		return result;
	}
	public static long TimeStampToMSecs(TTimeStamp TimeStamp)
	{
		long result = 0;
		return result;
	}
	public static TDateTime FloatToDateTime(double Value)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryFloatToDateTime(double Value, out TDateTime AResult)
	{
		AResult = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static TDateTime EncodeTime(ushort Hour, ushort Min, ushort Sec, ushort MSec)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryEncodeTime(ushort Hour, ushort Min, ushort Sec, ushort MSec, out TDateTime Time)
	{
		Time = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static void DecodeTime(TDateTime DateTime, out ushort Hour, out ushort Min, out ushort Sec, out ushort MSec)
	{
		Hour = 0; //# clear out parameter
		Min = 0; //# clear out parameter
		Sec = 0; //# clear out parameter
		MSec = 0; //# clear out parameter
	}
	public static void DateTimeToSystemTime(TDateTime DateTime, ref TSystemTime SystemTime)
	{
	}
	public static TDateTime SystemTimeToDateTime(TSystemTime SystemTime)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TrySystemTimeToDateTime(TSystemTime SystemTime, out TDateTime DateTime)
	{
		DateTime = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static TDateTime EncodeDateTime(ushort Year, ushort Month, ushort Day, ushort Hour, ushort Minute, ushort Second, ushort MilliSecond)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryEncodeDateTime(ushort Year, ushort Month, ushort Day, ushort Hour, ushort Minute, ushort Second, ushort MilliSecond, out TDateTime Value)
	{
		Value = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static void DecodeDateTime(TDateTime AValue, out ushort AYear, out ushort AMonth, out ushort ADay, out ushort AHour, out ushort AMinute, out ushort ASecond, out ushort AMilliSecond)
	{
		AYear = 0; //# clear out parameter
		AMonth = 0; //# clear out parameter
		ADay = 0; //# clear out parameter
		AHour = 0; //# clear out parameter
		AMinute = 0; //# clear out parameter
		ASecond = 0; //# clear out parameter
		AMilliSecond = 0; //# clear out parameter
	}
	public static TDateTime Date()
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime Time()
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime Now()
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static ushort DayOfWeek(TDateTime DateTime)
	{
		ushort result = 0;
		return result;
	}
	public static bool IsLeapYear(ushort Year)
	{
		bool result = false;
		return result;
	}
	public static TDateTime GetTime()
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static ushort CurrentYear()
	{
		ushort result = 0;
		return result;
	}
	public static TDateTime IncMonth(TDateTime DateTime, int NumberOfMonths = 1)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static void IncAMonth(ref ushort Year, ref ushort Month, ref ushort Day, int NumberOfMonths = 1)
	{
	}
	public static void ReplaceTime(ref TDateTime DateTime, TDateTime NewTime)
	{
	}
	public static void ReplaceDate(ref TDateTime DateTime, TDateTime NewDate)
	{
	}

/* Formatting */
	public static string Format(string Format, params TVarRec[] Args)
	{
		string result = string.Empty;
		return result;
	}
	public static string Format(string Format, TVarRec[] Args, TFormatSettings FormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static uint FormatBuf(UntypedPointer Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, params TVarRec[] Args)
	{
		uint result = 0;
		return result;
	}
	public static uint FormatBuf(PChar Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, params TVarRec[] Args)
	{
		uint result = 0;
		return result;
	}
	public static uint FormatBuf(PChar Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		uint result = 0;
		return result;
	}
	public static uint FormatBuf(ref string Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, params TVarRec[] Args)
	{
		uint result = 0;
		return result;
	}
	public static uint FormatBuf(ref string Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		uint result = 0;
		return result;
	}
	public static uint FormatBuf(UntypedPointer Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		uint result = 0;
		return result;
	}
	public static string WideFormat(string Format, params TVarRec[] Args)
	{
		string result = string.Empty;
		return result;
	}
	public static string WideFormat(string Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static void WideFmtStr(ref string Result, string Format, params TVarRec[] Args)
	{
	}
	public static void WideFmtStr(ref string Result, string Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
	}
	public static uint WideFormatBuf(UntypedPointer Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, params TVarRec[] Args)
	{
		uint result = 0;
		return result;
	}
	public static uint WideFormatBuf(UntypedPointer Buffer, uint BufLen, UntypedPointer Format, uint FmtLen, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		uint result = 0;
		return result;
	}
	public static void FmtStr(ref string Result, string Format, params TVarRec[] Args)
	{
	}
	public static void FmtStr(ref string Result, string Format, TVarRec[] Args, TFormatSettings FormatSettings)
	{
	}

/* String helpers */
	public static int CompareStr(string S1, string S2)
	{
		int result = 0;
		return result;
	}
	public static int CompareStr(string S1, string S2, TLocaleOptions LocaleOptions)
	{
		int result = 0;
		return result;
	}
	public static int CompareText(string S1, string S2)
	{
		int result = 0;
		return result;
	}
	public static int CompareText(string S1, string S2, TLocaleOptions LocaleOptions)
	{
		int result = 0;
		return result;
	}
	public static bool SameStr(string S1, string S2)
	{
		bool result = false;
		return result;
	}
	public static bool SameStr(string S1, string S2, TLocaleOptions LocaleOptions)
	{
		bool result = false;
		return result;
	}
	public static bool SameText(string S1, string S2)
	{
		bool result = false;
		return result;
	}
	public static bool SameText(string S1, string S2, TLocaleOptions LocaleOptions)
	{
		bool result = false;
		return result;
	}
	public static string UpperCase(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string UpperCase(string S, TLocaleOptions LocaleOptions)
	{
		string result = string.Empty;
		return result;
	}
	public static string LowerCase(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string LowerCase(string S, TLocaleOptions LocaleOptions)
	{
		string result = string.Empty;
		return result;
	}
	public static string Trim(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string TrimLeft(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string TrimRight(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string QuotedStr(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiQuotedStr(string S, char Quote)
	{
		string result = string.Empty;
		return result;
	}
	public static string StringReplace(string S, string OldPattern, string NewPattern, TSet Flags)
	{
		string result = string.Empty;
		return result;
	}
	public static int FindDelimiter(string Delimiters, string S, int StartIdx = 1)
	{
		int result = 0;
		return result;
	}
	public static int AnsiPos(string Substr, string S)
	{
		int result = 0;
		return result;
	}
	public static string AnsiLowerCaseFileName(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiUpperCaseFileName(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static int ByteLength(string S)
	{
		int result = 0;
		return result;
	}
	public static int ByteLength(AnsiString S)
	{
		int result = 0;
		return result;
	}
	public static int CharLength(string S, int Index)
	{
		int result = 0;
		return result;
	}
	public static int NextCharIndex(string S, int Index)
	{
		int result = 0;
		return result;
	}
	public static bool IsLeadChar(byte C)
	{
		bool result = false;
		return result;
	}
	//public static bool IsLeadChar(byte C)
	//{
	//	bool result = false;
	//	return result;
	//}
	public static bool IsLeadChar(char C)
	{
		bool result = false;
		return result;
	}
	public static bool CharInSet(char C, TSet CharSet)
	{
		bool result = false;
		return result;
	}
	public static TMbcsByteType ByteType(AnsiString S, int Index)
	{
		TMbcsByteType result = TMbcsByteType.mbSingleByte;
		return result;
	}
	public static TMbcsByteType ByteType(string S, int Index)
	{
		TMbcsByteType result = TMbcsByteType.mbSingleByte;
		return result;
	}
	public static TMbcsByteType StrByteType(PAnsiChar Str, uint Index)
	{
		TMbcsByteType result = TMbcsByteType.mbSingleByte;
		return result;
	}
	public static TMbcsByteType StrByteType(PChar Str, uint Index)
	{
		TMbcsByteType result = TMbcsByteType.mbSingleByte;
		return result;
	}
	public static int CharToElementIndex(AnsiString S, int Index)
	{
		int result = 0;
		return result;
	}
	public static int CharToElementIndex(string S, int Index)
	{
		int result = 0;
		return result;
	}
	public static int ElementToCharIndex(AnsiString S, int Index)
	{
		int result = 0;
		return result;
	}
	public static int ElementToCharIndex(string S, int Index)
	{
		int result = 0;
		return result;
	}
	public static int ElementToCharLen(AnsiString S, int MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int ElementToCharLen(string S, int MaxLen)
	{
		int result = 0;
		return result;
	}
	public static bool CompareMem(Pointer P1, Pointer P2, int Length)
	{
		bool result = false;
		return result;
	}
	public static int ByteToCharLen(string S, int MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int CharToByteLen(string S, int MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int ByteToCharIndex(string S, int Index)
	{
		int result = 0;
		return result;
	}
	public static int CharToByteIndex(string S, int Index)
	{
		int result = 0;
		return result;
	}
	public static int StrCharLength(PAnsiChar Str)
	{
		int result = 0;
		return result;
	}
	public static int StrCharLength(PChar Str)
	{
		int result = 0;
		return result;
	}
	public static PAnsiChar StrNextChar(PAnsiChar Str)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrNextChar(PChar Str)
	{
		PChar result = default;
		return result;
	}
	public static uint StrLen(PAnsiChar Str)
	{
		uint result = 0;
		return result;
	}
	public static uint StrLen(PChar Str)
	{
		uint result = 0;
		return result;
	}
	public static PAnsiChar StrEnd(PAnsiChar Str)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrEnd(PChar Str)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrMove(PAnsiChar Dest, PAnsiChar Source, uint Count)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrMove(PChar Dest, PChar Source, uint Count)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrECopy(PAnsiChar Dest, PAnsiChar Source)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrECopy(PChar Dest, PChar Source)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrLCat(PAnsiChar Dest, PAnsiChar Source, uint MaxLen)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrLCat(PChar Dest, PChar Source, uint MaxLen)
	{
		PChar result = default;
		return result;
	}
	public static void StrDispose(PAnsiChar Str)
	{
	}
	public static void StrDispose(PChar Str)
	{
	}
	public static PAnsiChar StrFmt(PAnsiChar Buffer, PAnsiChar Format, params TVarRec[] Args)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrFmt(PChar Buffer, PChar Format, params TVarRec[] Args)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrFmt(PAnsiChar Buffer, PAnsiChar Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrFmt(PChar Buffer, PChar Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrLFmt(PAnsiChar Buffer, uint MaxBufLen, PAnsiChar Format, params TVarRec[] Args)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrLFmt(PChar Buffer, uint MaxBufLen, PChar Format, params TVarRec[] Args)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrLFmt(PAnsiChar Buffer, uint MaxBufLen, PAnsiChar Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrLFmt(PChar Buffer, uint MaxBufLen, PChar Format, TVarRec[] Args, TFormatSettings AFormatSettings)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrCopy(PAnsiChar Dest, PAnsiChar Source)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrCopy(PChar Dest, PChar Source)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrLCopy(PAnsiChar Dest, PAnsiChar Source, uint MaxLen)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrLCopy(PChar Dest, PChar Source, uint MaxLen)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrPCopy(PAnsiChar Dest, AnsiString Source)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrPCopy(PChar Dest, string Source)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrPLCopy(PAnsiChar Dest, AnsiString Source, uint MaxLen)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrPLCopy(PChar Dest, string Source, uint MaxLen)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrCat(PAnsiChar Dest, PAnsiChar Source)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrCat(PChar Dest, PChar Source)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrScan(PAnsiChar Str, byte Chr)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrScan(PChar Str, char Chr)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrRScan(PAnsiChar Str, byte Chr)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrRScan(PChar Str, char Chr)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrPos(PAnsiChar Str1, PAnsiChar Str2)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrPos(PChar Str1, PChar Str2)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrUpper(PAnsiChar Str)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrUpper(PChar Str)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar StrLower(PAnsiChar Str)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrLower(PChar Str)
	{
		PChar result = default;
		return result;
	}
	public static AnsiString StrPas(PAnsiChar Str)
	{
		AnsiString result = AnsiString.Empty;
		return result;
	}
	public static string StrPas(PChar Str)
	{
		string result = string.Empty;
		return result;
	}
	public static PAnsiChar StrNew(PAnsiChar Str)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar StrNew(PChar Str)
	{
		PChar result = default;
		return result;
	}
	public static uint StrBufSize(PAnsiChar Str)
	{
		uint result = 0;
		return result;
	}
	public static uint StrBufSize(PChar Str)
	{
		uint result = 0;
		return result;
	}
	public static PChar StrAlloc(uint Size)
	{
		PChar result = default;
		return result;
	}
	public static int StrComp(PAnsiChar Str1, PAnsiChar Str2)
	{
		int result = 0;
		return result;
	}
	public static int StrComp(PChar Str1, PChar Str2)
	{
		int result = 0;
		return result;
	}
	public static int StrIComp(PAnsiChar Str1, PAnsiChar Str2)
	{
		int result = 0;
		return result;
	}
	public static int StrIComp(PChar Str1, PChar Str2)
	{
		int result = 0;
		return result;
	}
	public static int StrLComp(PAnsiChar Str1, PAnsiChar Str2, uint MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int StrLComp(PChar Str1, PChar Str2, uint MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int StrLIComp(PAnsiChar Str1, PAnsiChar Str2, uint MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int StrLIComp(PChar Str1, PChar Str2, uint MaxLen)
	{
		int result = 0;
		return result;
	}
	public static PAnsiChar TextPos(PAnsiChar Str, PAnsiChar SubStr)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar TextPos(PChar Str, PChar SubStr)
	{
		PChar result = default;
		return result;
	}
	public static uint HashName(PAnsiChar Name)
	{
		uint result = 0;
		return result;
	}
	public static int AnsiStrComp(PAnsiChar S1, PAnsiChar S2)
	{
		int result = 0;
		return result;
	}
	public static int AnsiStrComp(PChar S1, PChar S2)
	{
		int result = 0;
		return result;
	}
	public static int AnsiStrIComp(PAnsiChar S1, PAnsiChar S2)
	{
		int result = 0;
		return result;
	}
	public static int AnsiStrIComp(PChar S1, PChar S2)
	{
		int result = 0;
		return result;
	}
	public static int AnsiStrLComp(PAnsiChar S1, PAnsiChar S2, uint MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int AnsiStrLComp(PChar S1, PChar S2, uint MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int AnsiStrLIComp(PAnsiChar S1, PAnsiChar S2, uint MaxLen)
	{
		int result = 0;
		return result;
	}
	public static int AnsiStrLIComp(PChar S1, PChar S2, uint MaxLen)
	{
		int result = 0;
		return result;
	}
	public static PAnsiChar AnsiStrUpper(PAnsiChar Str)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar AnsiStrUpper(PChar Str)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar AnsiStrLower(PAnsiChar Str)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar AnsiStrLower(PChar Str)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar AnsiStrPos(PAnsiChar Str, PAnsiChar SubStr)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar AnsiStrPos(PChar Str, PChar SubStr)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar AnsiStrScan(PAnsiChar Str, byte Chr)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar AnsiStrScan(PChar Str, char Chr)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar AnsiStrRScan(PAnsiChar Str, byte Chr)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar AnsiStrRScan(PChar Str, char Chr)
	{
		PChar result = default;
		return result;
	}
	public static PAnsiChar AnsiStrLastChar(PAnsiChar P)
	{
		PAnsiChar result = default;
		return result;
	}
	public static PChar AnsiStrLastChar(PChar P)
	{
		PChar result = default;
		return result;
	}
	public static PChar AnsiLastChar(string S)
	{
		PChar result = default;
		return result;
	}
	public static AnsiString AnsiExtractQuotedStr(ref PAnsiChar Src, byte Quote)
	{
		AnsiString result = AnsiString.Empty;
		return result;
	}
	public static string AnsiExtractQuotedStr(ref PChar Src, char Quote)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiUpperCase(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string AnsiLowerCase(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static int AnsiCompareStr(string S1, string S2)
	{
		int result = 0;
		return result;
	}
	public static int AnsiCompareText(string S1, string S2)
	{
		int result = 0;
		return result;
	}
	public static bool AnsiSameStr(string S1, string S2)
	{
		bool result = false;
		return result;
	}
	public static bool AnsiSameText(string S1, string S2)
	{
		bool result = false;
		return result;
	}
	public static string AnsiDequotedStr(string S, char AQuote)
	{
		string result = string.Empty;
		return result;
	}
	public static string AdjustLineBreaks(string S, TTextLineBreakStyle Style = TTextLineBreakStyle.tlbsCRLF)
	{
		string result = string.Empty;
		return result;
	}
	public static bool IsValidIdent(string Ident, bool AllowDots = false)
	{
		bool result = false;
		return result;
	}
	public static string WrapText(string Line, string BreakStr, TSet BreakChars, int MaxCol)
	{
		string result = string.Empty;
		return result;
	}
	public static string WrapText(string Line, int MaxCol = 45)
	{
		string result = string.Empty;
		return result;
	}
	public static string WideUpperCase(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string WideLowerCase(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static int WideCompareStr(string S1, string S2)
	{
		int result = 0;
		return result;
	}
	public static int WideCompareText(string S1, string S2)
	{
		int result = 0;
		return result;
	}
	public static bool WideSameStr(string S1, string S2)
	{
		bool result = false;
		return result;
	}
	public static bool WideSameText(string S1, string S2)
	{
		bool result = false;
		return result;
	}
	public static void AppendStr(ref string Dest, string S)
	{
	}

/* Date and time conversion */
	public static string DateToStr(TDateTime DateTime)
	{
		string result = string.Empty;
		return result;
	}
	public static string DateToStr(TDateTime DateTime, TFormatSettings FormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static string TimeToStr(TDateTime DateTime)
	{
		string result = string.Empty;
		return result;
	}
	public static string TimeToStr(TDateTime DateTime, TFormatSettings FormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static string DateTimeToStr(TDateTime DateTime)
	{
		string result = string.Empty;
		return result;
	}
	public static string DateTimeToStr(TDateTime DateTime, TFormatSettings FormatSettings)
	{
		string result = string.Empty;
		return result;
	}
	public static TDateTime StrToDate(string S)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToDate(string S, TFormatSettings FormatSettings)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToDateDef(string S, TDateTime Default)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToDateDef(string S, TDateTime Default, TFormatSettings FormatSettings)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToTime(string S)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToTime(string S, TFormatSettings FormatSettings)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToTimeDef(string S, TDateTime Default)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToTimeDef(string S, TDateTime Default, TFormatSettings FormatSettings)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToDateTime(string S)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToDateTime(string S, TFormatSettings FormatSettings)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToDateTimeDef(string S, TDateTime Default)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static TDateTime StrToDateTimeDef(string S, TDateTime Default, TFormatSettings FormatSettings)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static bool TryStrToDate(string S, out TDateTime Value)
	{
		Value = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static bool TryStrToDate(string S, out TDateTime Value, TFormatSettings FormatSettings)
	{
		Value = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static bool TryStrToTime(string S, out TDateTime Value)
	{
		Value = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static bool TryStrToTime(string S, out TDateTime Value, TFormatSettings FormatSettings)
	{
		Value = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static bool TryStrToDateTime(string S, out TDateTime Value)
	{
		Value = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static bool TryStrToDateTime(string S, out TDateTime Value, TFormatSettings FormatSettings)
	{
		Value = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static string FormatDateTime(string Format, TDateTime DateTime)
	{
		string result = string.Empty;
		return result;
	}
	public static string FormatDateTime(string Format, TDateTime DateTime, TFormatSettings FormatSettings)
	{
		string result = string.Empty;
		return result;
	}

/* File-name helpers */
	public static string ChangeFileExt(string FileName, string Extension)
	{
		string result = string.Empty;
		return result;
	}
	public static string ChangeFilePath(string FileName, string Path)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExtractFileDir(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExtractFileDrive(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExtractFileExt(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExtractFileName(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExtractFilePath(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static string IncludeTrailingPathDelimiter(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string IncludeTrailingBackslash(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExcludeTrailingPathDelimiter(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExcludeTrailingBackslash(string S)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExpandFileName(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExpandFileNameCase(string FileName, out TFilenameCaseMatch MatchFound)
	{
		MatchFound = TFilenameCaseMatch.mkNone; //# clear out parameter
		string result = string.Empty;
		return result;
	}
	public static string ExpandUNCFileName(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExtractRelativePath(string BaseName, string DestName)
	{
		string result = string.Empty;
		return result;
	}
	public static string ExtractShortPathName(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static bool IsPathDelimiter(string S, int Index)
	{
		bool result = false;
		return result;
	}
	public static bool IsDelimiter(string Delimiters, string S, int Index)
	{
		bool result = false;
		return result;
	}
	public static int LastDelimiter(string Delimiters, string S)
	{
		int result = 0;
		return result;
	}
	public static bool IsRelativePath(string Path)
	{
		bool result = false;
		return result;
	}
	public static string FileSearch(string Name, string DirList)
	{
		string result = string.Empty;
		return result;
	}
	public static bool SameFileName(string S1, string S2)
	{
		bool result = false;
		return result;
	}
	public static int AnsiCompareFileName(string S1, string S2, bool CheckVolumeCase = false)
	{
		int result = 0;
		return result;
	}

/* File and directory helpers */
	public static bool FileExists(string FileName, bool FollowLink = true)
	{
		bool result = false;
		return result;
	}
	public static bool DirectoryExists(string Directory, bool FollowLink = true)
	{
		bool result = false;
		return result;
	}
	public static bool ForceDirectories(string Dir)
	{
		bool result = false;
		return result;
	}
	public static int FindFirst(string Path, int Attr, ref TSearchRec F)
	{
		int result = 0;
		return result;
	}
	public static int FindNext(ref TSearchRec F)
	{
		int result = 0;
		return result;
	}
	public static void FindClose(ref TSearchRec F)
	{
	}
	public static bool FileGetDateTimeInfo(string FileName, out TDateTimeInfoRec DateTime, bool FollowLink = true)
	{
		DateTime = TDateTimeInfoRec.CreateRecord(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static bool FileCreateSymLink(string Link, string Target)
	{
		bool result = false;
		return result;
	}
	public static bool FileGetSymLinkTarget(string FileName, ref TSymLinkRec SymLinkRec)
	{
		bool result = false;
		return result;
	}
	public static bool FileGetSymLinkTarget(string FileName, ref string TargetName)
	{
		bool result = false;
		return result;
	}
	public static TSet FileSystemAttributes(string Path)
	{
		TSet result = new TSet();
		return result;
	}
	public static string GetCurrentDir()
	{
		string result = string.Empty;
		return result;
	}
	public static bool SetCurrentDir(string Dir)
	{
		bool result = false;
		return result;
	}
	public static bool CreateDir(string Dir)
	{
		bool result = false;
		return result;
	}
	public static bool RemoveDir(string Dir)
	{
		bool result = false;
		return result;
	}
	public static long DiskFree(byte Drive)
	{
		long result = 0;
		return result;
	}
	public static long DiskSize(byte Drive)
	{
		long result = 0;
		return result;
	}
	public static int FileGetAttr(string FileName, bool FollowLink = true)
	{
		int result = 0;
		return result;
	}
	public static int FileSetAttr(string FileName, int Attr, bool FollowLink = true)
	{
		int result = 0;
		return result;
	}
	public static bool FileIsReadOnly(string FileName)
	{
		bool result = false;
		return result;
	}
	public static bool FileSetReadOnly(string FileName, bool ReadOnly)
	{
		bool result = false;
		return result;
	}
	public static bool DeleteFile(string FileName)
	{
		bool result = false;
		return result;
	}
	public static bool RenameFile(string OldName, string NewName)
	{
		bool result = false;
		return result;
	}
	public static bool IsAssembly(string FileName)
	{
		bool result = false;
		return result;
	}
	public static TDateTime FileDateToDateTime(int FileDate)
	{
		TDateTime result = new TDateTime();
		return result;
	}
	public static int DateTimeToFileDate(TDateTime DateTime)
	{
		int result = 0;
		return result;
	}
	public static int FileAge(string FileName)
	{
		int result = 0;
		return result;
	}
	public static bool FileAge(string FileName, out TDateTime FileDateTime, bool FollowLink = true)
	{
		FileDateTime = new TDateTime(); //# clear out parameter
		bool result = false;
		return result;
	}
	public static int FileSetDate(string FileName, int Age)
	{
		int result = 0;
		return result;
	}
	public static int FileSetDate(uint Handle, int Age)
	{
		int result = 0;
		return result;
	}
	public static uint FileOpen(string FileName, uint Mode)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int FileRead(uint Handle, UntypedPointer Buffer, uint Count)
	{
		int result = 0;
		return result;
	}
	public static int FileWrite(uint Handle, UntypedPointer Buffer, uint Count)
	{
		int result = 0;
		return result;
	}
	public static uint FileCreate(string FileName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint FileCreate(string FileName, int Rights)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint FileCreate(string FileName, uint Mode, int Rights)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int FileSeek(uint Handle, int Offset, int Origin)
	{
		int result = 0;
		return result;
	}
	public static long FileSeek(uint Handle, long Offset, int Origin)
	{
		long result = 0;
		return result;
	}
	public static int FileGetDate(uint Handle)
	{
		int result = 0;
		return result;
	}
	public static void FileClose(uint Handle)
	{
	}

/* Environment, resource and command-line helpers */

/* Package, termination and collection-growth helpers */
	public static uint SafeLoadLibrary(string FileName, uint ErrorMode = 0x8000)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint LoadPackage(string Name)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint LoadPackage(string Name, TValidatePackageProc AValidatePackage)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static void InitializePackage(uint Module)
	{
	}
	public static void InitializePackage(uint Module, TValidatePackageProc AValidatePackage)
	{
	}
	public static void FinalizePackage(uint Module)
	{
	}
	public static void UnloadPackage(uint Module)
	{
	}
	public static string GetPackageDescription(PChar ModuleName)
	{
		string result = string.Empty;
		return result;
	}
	public static void GetPackageInfo(uint Module, Pointer Param, ref int Flags, TPackageInfoProc InfoProc)
	{
	}
	public static uint GetPackageTargets(uint Module)
	{
		uint result = 0;
		return result;
	}
	public static void AddExitProc(TProcedure Proc)
	{
	}
	public static void AddTerminateProc(TTerminateProc TermProc)
	{
	}
	public static bool CallTerminateProcs()
	{
		bool result = false;
		return result;
	}
	public static int GrowCollection(int OldCapacity, int NewCount)
	{
		int result = 0 /*Native*/;
		return result;
	}
	public static TGrowCollectionFunc SetGrowCollectionFunc(TGrowCollectionFunc Func)
	{
		TGrowCollectionFunc result = default;
		return result;
	}
	public static string GetDefaultFallbackLanguages()
	{
		string result = string.Empty;
		return result;
	}
	public static void SetDefaultFallbackLanguages(string Languages)
	{
	}
	public static string PreferredUILanguages()
	{
		string result = string.Empty;
		return result;
	}
	public static string GetEnvironmentVariable(string Name)
	{
		string result = string.Empty;
		return result;
	}
	public static string GetHomePath()
	{
		string result = string.Empty;
		return result;
	}
	public static string GetLocaleStr(int Locale, int LocaleType, string Default)
	{
		string result = string.Empty;
		return result;
	}
	public static char GetLocaleChar(int Locale, int LocaleType, char Default)
	{
		char result = '\0';
		return result;
	}
	public static void GetLocaleFormatSettings(uint Locale, ref TFormatSettings AFormatSettings)
	{
	}
	public static bool LocaleFileExists(string FileName)
	{
		bool result = false;
		return result;
	}
	public static string GetLocaleFile(string FileName)
	{
		string result = string.Empty;
		return result;
	}
	public static bool LocaleDirectoryExists(string Directory)
	{
		bool result = false;
		return result;
	}
	public static string GetLocaleDirectory(string Directory)
	{
		string result = string.Empty;
		return result;
	}
	public static bool CheckWin32Version(int AMajor, int AMinor = 0)
	{
		bool result = false;
		return result;
	}
	public static uint GetFileVersion(string AFileName)
	{
		uint result = 0;
		return result;
	}
	public static bool GetProductVersion(string AFileName, ref uint AMajor, ref uint AMinor, ref uint ABuild)
	{
		bool result = false;
		return result;
	}
	public static void GetFormatSettings()
	{
	}
	public static int LCIDToCodePage(uint ALCID)
	{
		int result = 0;
		return result;
	}
	public static string GetModuleName(uint Module)
	{
		string result = string.Empty;
		return result;
	}
	public static string LoadStr(uint Ident)
	{
		string result = string.Empty;
		return result;
	}
	public static string FmtLoadStr(uint Ident, params TVarRec[] Args)
	{
		string result = string.Empty;
		return result;
	}
	public static bool FindCmdLineSwitch(string Switch, TSet Chars, bool IgnoreCase)
	{
		bool result = false;
		return result;
	}
	public static bool FindCmdLineSwitch(string Switch)
	{
		bool result = false;
		return result;
	}
	public static bool FindCmdLineSwitch(string Switch, bool IgnoreCase)
	{
		bool result = false;
		return result;
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
         return false;
    }
	public static void Beep()
	{
	}

/* GUID and interface support */
	public static bool IsEqualGUID(Guid Guid1, Guid Guid2)
	{
		bool result = false;
		return result;
	}
	public static int CreateGUID(out Guid Guid)
	{
		Guid = new Guid(); //# clear out parameter
		int result = 0;
		return result;
	}
	public static Guid StringToGUID(string S)
	{
		Guid result = new Guid();
		return result;
	}
	public static Guid StrToGUID(PChar S)
	{
		Guid result = new Guid();
		return result;
	}
	public static string GUIDToString(Guid Guid)
	{
		string result = string.Empty;
		return result;
	}
	public static string GUIDToString(Guid Guid, char Format)
	{
		string result = string.Empty;
		return result;
	}
	public static bool Supports(IInterface Instance, Guid IID, UntypedPointer Intf)
	{
		bool result = false;
		return result;
	}
	public static bool Supports(TObject Instance, Guid IID, UntypedPointer Intf)
	{
		bool result = false;
		return result;
	}
	public static bool Supports(IInterface Instance, Guid IID)
	{
		bool result = false;
		return result;
	}
	public static bool Supports(TObject Instance, Guid IID)
	{
		bool result = false;
		return result;
	}
	public static bool Supports(TClass AClass, Guid IID)
	{
		bool result = false;
		return result;
	}

/* Exception and operating-system helpers */
	public static int ExceptionErrorMessage(TObject ExceptObject, Pointer ExceptAddr, PChar Buffer, int Size)
	{
		int result = 0;
		return result;
	}
	public static void Abort()
	{
	}
	public static void OutOfMemoryError()
	{
	}
	public static void RaiseLastOSError()
	{
	}
	public static void RaiseLastOSError(int LastError)
	{
	}
	public static void RaiseLastOSError(int LastError, string AdditionalInfo)
	{
	}
	public static void RaiseLastWin32Error()
	{
	}
	public static int Win32Check(int RetVal)
	{
		int result = 0;
		return result;
	}
	public static void CheckOSError(int LastError)
	{
	}
	public static string SysErrorMessage(uint ErrorCode, uint AModuleHandle = 0)
	{
		string result = string.Empty;
		return result;
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

