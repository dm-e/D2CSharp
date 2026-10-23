using System;
using static System.SystemInterface;
using static Winapi.Windows.WindowsImplementation;
using static Winapi.Windows.WindowsInterface;

namespace Winapi
{

namespace Windows
{

/*
  D2CSharp Runtime Library (RTL)

  Mocking declarations for Delphi Winapi.Windows.
  Target compatibility: RAD Studio XE3.

  This file intentionally contains declarations and empty implementations
  only. It is not a replacement for the Windows API and is intended as input
  for D2CSharp translation and type resolution.

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


public class WindowsInterface
{

	public struct TPoint
	{
		public int X;
		public int Y;
		public static TPoint CreateRecord(){return new TPoint();}
	}	

	public struct TSize
	{
		public int cx;
		public int cy;
		public static TSize CreateRecord(){return new TSize();}
	}	

	public struct TRect
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
		public static TRect CreateRecord(){return new TRect();}
	}	

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

	public struct TSecurityAttributes
	{
		public uint nLength;
		public Pointer lpSecurityDescriptor;
		public int bInheritHandle;
		public static TSecurityAttributes CreateRecord(){return new TSecurityAttributes();}
	}	

	public struct TOverlapped
	{
		public uint Internal;
		public uint InternalHigh;
		public uint Offset;
		public uint OffsetHigh;
		public uint hEvent;
		public static TOverlapped CreateRecord(){return new TOverlapped();}
	}	

	public struct TMsg
	{
		public uint hwnd;
		public uint message;
		public uint wParam;
		public int lParam;
		public uint time;
		public TPoint pt;
		public void CreateRecordMembers()
		{
			pt = TPoint.CreateRecord();
		}
		public static TMsg CreateRecord()
		{
			TMsg tmp = new TMsg();
			tmp.CreateRecordMembers();
			return tmp;
		}
	}	

	public struct TWndClass
	{
		public uint style;
		public TFNWndProc lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public uint hInstance;
		public uint hIcon;
		public uint hCursor;
		public uint hbrBackground;
		public PChar lpszMenuName;
		public PChar lpszClassName;
		public static TWndClass CreateRecord(){return new TWndClass();}
	}	

	public struct TWndClassEx
	{
		public uint cbSize;
		public uint style;
		public TFNWndProc lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public uint hInstance;
		public uint hIcon;
		public uint hCursor;
		public uint hbrBackground;
		public PChar lpszMenuName;
		public PChar lpszClassName;
		public uint hIconSm;
		public static TWndClassEx CreateRecord(){return new TWndClassEx();}
	}	

	public struct TStartupInfo
	{
		public uint cb;
		public PChar lpReserved;
		public PChar lpDesktop;
		public PChar lpTitle;
		public uint dwX;
		public uint dwY;
		public uint dwXSize;
		public uint dwYSize;
		public uint dwXCountChars;
		public uint dwYCountChars;
		public uint dwFillAttribute;
		public uint dwFlags;
		public ushort wShowWindow;
		public ushort cbReserved2;
		public Pointer<byte> lpReserved2;
		public uint hStdInput;
		public uint hStdOutput;
		public uint hStdError;
		public static TStartupInfo CreateRecord(){return new TStartupInfo();}
	}	

	public struct TProcessInformation
	{
		public uint hProcess;
		public uint hThread;
		public uint dwProcessId;
		public uint dwThreadId;
		public static TProcessInformation CreateRecord(){return new TProcessInformation();}
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
  /* Basic Win32 scalar types. */
public delegate int TFNWndProc(uint hWnd, uint Msg, uint wParam, int lParam);
	public const int MAX_PATH = 260;
	public const uint INVALID_HANDLE_VALUE = unchecked((uint) -1);
	public const uint INFINITE = ((uint) 0xFFFFFFFF);
	public const uint WAIT_OBJECT_0 = ((uint) 0x00000000);
	public const uint WAIT_ABANDONED = ((uint) 0x00000080);
	public const uint WAIT_TIMEOUT = ((uint) 0x00000102);
	public const uint WAIT_FAILED = ((uint) 0xFFFFFFFF);
	public const uint GENERIC_READ = ((uint) 0x80000000);
	public const uint GENERIC_WRITE = ((uint) 0x40000000);
	public const uint GENERIC_EXECUTE = ((uint) 0x20000000);
	public const uint GENERIC_ALL = ((uint) 0x10000000);
	public const int FILE_SHARE_READ = 0x00000001;
	public const int FILE_SHARE_WRITE = 0x00000002;
	public const int FILE_SHARE_DELETE = 0x00000004;
	public const int CREATE_NEW = 1;
	public const int CREATE_ALWAYS = 2;
	public const int OPEN_EXISTING = 3;
	public const int OPEN_ALWAYS = 4;
	public const int TRUNCATE_EXISTING = 5;
	public const int FILE_ATTRIBUTE_READONLY = 0x00000001;
	public const int FILE_ATTRIBUTE_HIDDEN = 0x00000002;
	public const int FILE_ATTRIBUTE_SYSTEM = 0x00000004;
	public const int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
	public const int FILE_ATTRIBUTE_ARCHIVE = 0x00000020;
	public const int FILE_ATTRIBUTE_NORMAL = 0x00000080;
	public const int FILE_ATTRIBUTE_TEMPORARY = 0x00000100;
	public const int FILE_ATTRIBUTE_COMPRESSED = 0x00000800;
	public const int FILE_ATTRIBUTE_OFFLINE = 0x00001000;
	public const int FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000;
	public const int FILE_ATTRIBUTE_ENCRYPTED = 0x00004000;
	public const uint INVALID_FILE_ATTRIBUTES = ((uint) 0xFFFFFFFF);
	public const int FILE_BEGIN = 0;
	public const int FILE_CURRENT = 1;
	public const int FILE_END = 2;
	public const int ERROR_SUCCESS = 0;
	public const int ERROR_FILE_NOT_FOUND = 2;
	public const int ERROR_PATH_NOT_FOUND = 3;
	public const int ERROR_ACCESS_DENIED = 5;
	public const int ERROR_INVALID_HANDLE = 6;
	public const int ERROR_NOT_ENOUGH_MEMORY = 8;
	public const int ERROR_INVALID_DATA = 13;
	public const int ERROR_OUTOFMEMORY = 14;
	public const int ERROR_NO_MORE_FILES = 18;
	public const int ERROR_SHARING_VIOLATION = 32;
	public const int ERROR_FILE_EXISTS = 80;
	public const int ERROR_INVALID_PARAMETER = 87;
	public const int ERROR_INSUFFICIENT_BUFFER = 122;
	public const int ERROR_ALREADY_EXISTS = 183;
	public const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
	public const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
	public const int FORMAT_MESSAGE_FROM_STRING = 0x00000400;
	public const int FORMAT_MESSAGE_FROM_HMODULE = 0x00000800;
	public const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
	public const int MB_OK = 0x00000000;
	public const int MB_OKCANCEL = 0x00000001;
	public const int MB_ABORTRETRYIGNORE = 0x00000002;
	public const int MB_YESNOCANCEL = 0x00000003;
	public const int MB_YESNO = 0x00000004;
	public const int MB_RETRYCANCEL = 0x00000005;
	public const int MB_ICONERROR = 0x00000010;
	public const int MB_ICONQUESTION = 0x00000020;
	public const int MB_ICONWARNING = 0x00000030;
	public const int MB_ICONINFORMATION = 0x00000040;
	public const int IDOK = 1;
	public const int IDCANCEL = 2;
	public const int IDABORT = 3;
	public const int IDRETRY = 4;
	public const int IDIGNORE = 5;
	public const int IDYES = 6;
	public const int IDNO = 7;
	public const int SW_HIDE = 0;
	public const int SW_SHOWNORMAL = 1;
	public const int SW_SHOWMINIMIZED = 2;
	public const int SW_SHOWMAXIMIZED = 3;
	public const int SW_SHOWNOACTIVATE = 4;
	public const int SW_SHOW = 5;
	public const int SW_MINIMIZE = 6;
	public const int SW_SHOWMINNOACTIVE = 7;
	public const int SW_SHOWNA = 8;
	public const int SW_RESTORE = 9;
	public const int SWP_NOSIZE = 0x0001;
	public const int SWP_NOMOVE = 0x0002;
	public const int SWP_NOZORDER = 0x0004;
	public const int SWP_NOREDRAW = 0x0008;
	public const int SWP_NOACTIVATE = 0x0010;
	public const int SWP_FRAMECHANGED = 0x0020;
	public const int SWP_SHOWWINDOW = 0x0040;
	public const int SWP_HIDEWINDOW = 0x0080;
	public const int SWP_NOCOPYBITS = 0x0100;
	public const int SWP_NOOWNERZORDER = 0x0200;
	public const int SWP_NOSENDCHANGING = 0x0400;
	public const uint HWND_TOP = ((uint) 0);
	public const uint HWND_BOTTOM = ((uint) 1);
	public const uint HWND_TOPMOST = unchecked((uint) -1);
	public const uint HWND_NOTOPMOST = unchecked((uint) -2);
	public const int GWL_WNDPROC = -4;
	public const int GWL_HINSTANCE = -6;
	public const int GWL_HWNDPARENT = -8;
	public const int GWL_ID = -12;
	public const int GWL_STYLE = -16;
	public const int GWL_EXSTYLE = -20;
	public const int GWL_USERDATA = -21;
	public const int GWLP_WNDPROC = -4;
	public const int GWLP_HINSTANCE = -6;
	public const int GWLP_HWNDPARENT = -8;
	public const int GWLP_ID = -12;
	public const int GWLP_USERDATA = -21;
	public const int WM_NULL = 0x0000;
	public const int WM_CREATE = 0x0001;
	public const int WM_DESTROY = 0x0002;
	public const int WM_MOVE = 0x0003;
	public const int WM_SIZE = 0x0005;
	public const int WM_SETFOCUS = 0x0007;
	public const int WM_KILLFOCUS = 0x0008;
	public const int WM_ENABLE = 0x000A;
	public const int WM_SETREDRAW = 0x000B;
	public const int WM_SETTEXT = 0x000C;
	public const int WM_GETTEXT = 0x000D;
	public const int WM_GETTEXTLENGTH = 0x000E;
	public const int WM_PAINT = 0x000F;
	public const int WM_CLOSE = 0x0010;
	public const int WM_QUIT = 0x0012;
	public const int WM_ERASEBKGND = 0x0014;
	public const int WM_SHOWWINDOW = 0x0018;
	public const int WM_SETCURSOR = 0x0020;
	public const int WM_GETMINMAXINFO = 0x0024;
	public const int WM_COMMAND = 0x0111;
	public const int WM_TIMER = 0x0113;
	public const int WM_HSCROLL = 0x0114;
	public const int WM_VSCROLL = 0x0115;
	public const int WM_MOUSEMOVE = 0x0200;
	public const int WM_LBUTTONDOWN = 0x0201;
	public const int WM_LBUTTONUP = 0x0202;
	public const int WM_RBUTTONDOWN = 0x0204;
	public const int WM_RBUTTONUP = 0x0205;
	public const int WM_MOUSEWHEEL = 0x020A;
	public const int WM_USER = 0x0400;
	public const int WM_APP = 0x8000;
	public const int PM_NOREMOVE = 0x0000;
	public const int PM_REMOVE = 0x0001;
	public const int PM_NOYIELD = 0x0002;
	public const int KEY_QUERY_VALUE = 0x0001;
	public const int KEY_SET_VALUE = 0x0002;
	public const int KEY_CREATE_SUB_KEY = 0x0004;
	public const int KEY_ENUMERATE_SUB_KEYS = 0x0008;
	public const int KEY_NOTIFY = 0x0010;
	public const int KEY_CREATE_LINK = 0x0020;
	public const int KEY_WOW64_64KEY = 0x0100;
	public const int KEY_WOW64_32KEY = 0x0200;
	public const int KEY_READ = 0x20019;
	public const int KEY_WRITE = 0x20006;
	public const int KEY_ALL_ACCESS = 0xF003F;
	public const int REG_NONE = 0;
	public const int REG_SZ = 1;
	public const int REG_EXPAND_SZ = 2;
	public const int REG_BINARY = 3;
	public const int REG_DWORD = 4;
	public const int REG_MULTI_SZ = 7;
	public const int REG_QWORD = 11;
	public const uint HKEY_CLASSES_ROOT = ((uint) 0x80000000);
	public const uint HKEY_CURRENT_USER = ((uint) 0x80000001);
	public const uint HKEY_LOCAL_MACHINE = ((uint) 0x80000002);
	public const uint HKEY_USERS = ((uint) 0x80000003);
	public const uint HKEY_PERFORMANCE_DATA = ((uint) 0x80000004);
	public const uint HKEY_CURRENT_CONFIG = ((uint) 0x80000005);

/* Error handling and timing */
	public static uint /*stdcall*/ GetLastError()
	{
		uint result = 0;
		return result;
	}
	public static void /*stdcall*/ SetLastError(uint dwErrCode)
	{
	}
	public static uint /*stdcall*/ GetTickCount()
	{
		uint result = 0;
		return result;
	}
	public static void /*stdcall*/ Sleep(uint dwMilliseconds)
	{
	}
	public static int /*stdcall*/ QueryPerformanceCounter(ref long lpPerformanceCount)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ QueryPerformanceFrequency(ref long lpFrequency)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ FormatMessage(uint dwFlags, Pointer lpSource, uint dwMessageId, uint dwLanguageId, PChar lpBuffer, uint nSize, Pointer Arguments)
	{
		uint result = 0;
		return result;
	}

/* Process, thread and module functions */
	public static uint /*stdcall*/ GetCurrentProcess()
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetCurrentProcessId()
	{
		uint result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetCurrentThread()
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetCurrentThreadId()
	{
		uint result = 0;
		return result;
	}
	public static uint /*stdcall*/ LoadLibrary(PChar lpLibFileName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ LoadLibraryA(PAnsiChar lpLibFileName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ LoadLibraryW(PChar lpLibFileName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ FreeLibrary(uint hLibModule)
	{
		int result = 0;
		return result;
	}
	public static Pointer /*stdcall*/ GetProcAddress(uint hModule, PAnsiChar lpProcName)
	{
		Pointer result = default;
		return result;
	}
	public static uint /*stdcall*/ GetModuleHandle(PChar lpModuleName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetModuleHandleA(PAnsiChar lpModuleName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetModuleHandleW(PChar lpModuleName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetModuleFileName(uint hModule, PChar lpFilename, uint nSize)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ CreateProcess(PChar lpApplicationName, PChar lpCommandLine, Pointer<TSecurityAttributes> lpProcessAttributes, Pointer<TSecurityAttributes> lpThreadAttributes, int bInheritHandles, uint dwCreationFlags, Pointer lpEnvironment, PChar lpCurrentDirectory, TStartupInfo lpStartupInfo, ref TProcessInformation lpProcessInformation)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ TerminateProcess(uint hProcess, uint uExitCode)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetExitCodeProcess(uint hProcess, ref uint lpExitCode)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ CloseHandle(uint hObject)
	{
		int result = 0;
		return result;
	}

/* Synchronization */
	public static uint /*stdcall*/ CreateEvent(Pointer<TSecurityAttributes> lpEventAttributes, int bManualReset, int bInitialState, PChar lpName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ OpenEvent(uint dwDesiredAccess, int bInheritHandle, PChar lpName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ SetEvent(uint hEvent)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ ResetEvent(uint hEvent)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ CreateMutex(Pointer<TSecurityAttributes> lpMutexAttributes, int bInitialOwner, PChar lpName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ ReleaseMutex(uint hMutex)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ CreateSemaphore(Pointer<TSecurityAttributes> lpSemaphoreAttributes, int lInitialCount, int lMaximumCount, PChar lpName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ ReleaseSemaphore(uint hSemaphore, int lReleaseCount, Pointer<int> lpPreviousCount)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ WaitForSingleObject(uint hHandle, uint dwMilliseconds)
	{
		uint result = 0;
		return result;
	}
	public static uint /*stdcall*/ WaitForMultipleObjects(uint nCount, Pointer<uint> lpHandles, int bWaitAll, uint dwMilliseconds)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ InterlockedIncrement(ref int Addend)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ InterlockedDecrement(ref int Addend)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ InterlockedExchange(ref int Target, int Value)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ InterlockedCompareExchange(ref int Destination, int Exchange, int Comparand)
	{
		int result = 0;
		return result;
	}

/* File system */
	public static uint /*stdcall*/ CreateFile(PChar lpFileName, uint dwDesiredAccess, uint dwShareMode, Pointer<TSecurityAttributes> lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, uint hTemplateFile)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ ReadFile(uint hFile, UntypedPointer Buffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, Pointer<TOverlapped> lpOverlapped)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ WriteFile(uint hFile, UntypedPointer Buffer, uint nNumberOfBytesToWrite, ref uint lpNumberOfBytesWritten, Pointer<TOverlapped> lpOverlapped)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ SetFilePointer(uint hFile, int lDistanceToMove, Pointer<int> lpDistanceToMoveHigh, uint dwMoveMethod)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ SetEndOfFile(uint hFile)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ FlushFileBuffers(uint hFile)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetFileSize(uint hFile, Pointer<uint> lpFileSizeHigh)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ DeleteFile(PChar lpFileName)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ MoveFile(PChar lpExistingFileName, PChar lpNewFileName)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ CopyFile(PChar lpExistingFileName, PChar lpNewFileName, int bFailIfExists)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetFileAttributes(PChar lpFileName)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ SetFileAttributes(PChar lpFileName, uint dwFileAttributes)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ CreateDirectory(PChar lpPathName, Pointer<TSecurityAttributes> lpSecurityAttributes)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RemoveDirectory(PChar lpPathName)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetCurrentDirectory(uint nBufferLength, PChar lpBuffer)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ SetCurrentDirectory(PChar lpPathName)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetTempPath(uint nBufferLength, PChar lpBuffer)
	{
		uint result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetTempFileName(PChar lpPathName, PChar lpPrefixString, uint uUnique, PChar lpTempFileName)
	{
		uint result = 0;
		return result;
	}
	public static uint /*stdcall*/ FindFirstFile(PChar lpFileName, ref TWin32FindData lpFindFileData)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ FindNextFile(uint hFindFile, ref TWin32FindData lpFindFileData)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ FindClose(uint hFindFile)
	{
		int result = 0;
		return result;
	}

/* Date and time */
	public static void /*stdcall*/ GetSystemTime(ref TSystemTime lpSystemTime)
	{
	}
	public static void /*stdcall*/ GetLocalTime(ref TSystemTime lpSystemTime)
	{
	}
	public static int /*stdcall*/ SystemTimeToFileTime(TSystemTime lpSystemTime, ref TFileTime lpFileTime)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ FileTimeToSystemTime(TFileTime lpFileTime, ref TSystemTime lpSystemTime)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ LocalFileTimeToFileTime(TFileTime lpLocalFileTime, ref TFileTime lpFileTime)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ FileTimeToLocalFileTime(TFileTime lpFileTime, ref TFileTime lpLocalFileTime)
	{
		int result = 0;
		return result;
	}

/* Windows and messages */
	public static int /*stdcall*/ MessageBox(uint hWnd, PChar lpText, PChar lpCaption, uint uType)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ MessageBoxA(uint hWnd, PAnsiChar lpText, PAnsiChar lpCaption, uint uType)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ MessageBoxW(uint hWnd, PChar lpText, PChar lpCaption, uint uType)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ FindWindow(PChar lpClassName, PChar lpWindowName)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetDesktopWindow()
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetForegroundWindow()
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ SetForegroundWindow(uint hWnd)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetActiveWindow()
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetFocus()
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ SetFocus(uint hWnd)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ IsWindow(uint hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ IsWindowVisible(uint hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ IsWindowEnabled(uint hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ ShowWindow(uint hWnd, int nCmdShow)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ EnableWindow(uint hWnd, int bEnable)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ DestroyWindow(uint hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowRect(uint hWnd, ref TRect lpRect)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetClientRect(uint hWnd, ref TRect lpRect)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ ClientToScreen(uint hWnd, ref TPoint lpPoint)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ ScreenToClient(uint hWnd, ref TPoint lpPoint)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ MoveWindow(uint hWnd, int X, int Y, int nWidth, int nHeight, int bRepaint)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ SetWindowPos(uint hWnd, uint hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowText(uint hWnd, PChar lpString, int nMaxCount)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowTextLength(uint hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ SetWindowText(uint hWnd, PChar lpString)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ SendMessage(uint hWnd, uint Msg, uint wParam, int lParam)
	{
		int result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ PostMessage(uint hWnd, uint Msg, uint wParam, int lParam)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ DefWindowProc(uint hWnd, uint Msg, uint wParam, int lParam)
	{
		int result = 0 /*Native*/;
		return result;
	}
	public static void /*stdcall*/ PostQuitMessage(int nExitCode)
	{
	}
	public static int /*stdcall*/ PeekMessage(ref TMsg lpMsg, uint hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetMessage(ref TMsg lpMsg, uint hWnd, uint wMsgFilterMin, uint wMsgFilterMax)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ TranslateMessage(TMsg lpMsg)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ DispatchMessage(TMsg lpMsg)
	{
		int result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ RegisterWindowMessage(PChar lpString)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowLong(uint hWnd, int nIndex)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ SetWindowLong(uint hWnd, int nIndex, int dwNewLong)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowLongPtr(uint hWnd, int nIndex)
	{
		int result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ SetWindowLongPtr(uint hWnd, int nIndex, int dwNewLong)
	{
		int result = 0 /*Native*/;
		return result;
	}
	public static ushort /*stdcall*/ RegisterClass(TWndClass lpWndClass)
	{
		ushort result = 0;
		return result;
	}
	public static ushort /*stdcall*/ RegisterClassEx(TWndClassEx lpWndClass)
	{
		ushort result = 0;
		return result;
	}
	public static int /*stdcall*/ UnregisterClass(PChar lpClassName, uint hInstance)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ CreateWindowEx(uint dwExStyle, PChar lpClassName, PChar lpWindowName, uint dwStyle, int X, int Y, int nWidth, int nHeight, uint hWndParent, uint hMenu, uint hInstance, Pointer lpParam)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ InvalidateRect(uint hWnd, Pointer<TRect> lpRect, int bErase)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ UpdateWindow(uint hWnd)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetDC(uint hWnd)
	{
		uint result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ ReleaseDC(uint hWnd, uint hDC)
	{
		int result = 0;
		return result;
	}

/* Registry */
	public static int /*stdcall*/ RegOpenKeyEx(uint hKey, PChar lpSubKey, uint ulOptions, uint samDesired, ref uint phkResult)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegCreateKeyEx(uint hKey, PChar lpSubKey, uint Reserved, PChar lpClass, uint dwOptions, uint samDesired, Pointer<TSecurityAttributes> lpSecurityAttributes, ref uint phkResult, Pointer<uint> lpdwDisposition)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegCloseKey(uint hKey)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegQueryValueEx(uint hKey, PChar lpValueName, Pointer<uint> lpReserved, Pointer<uint> lpType, Pointer<byte> lpData, Pointer<uint> lpcbData)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegSetValueEx(uint hKey, PChar lpValueName, uint Reserved, uint dwType, Pointer<byte> lpData, uint cbData)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegDeleteValue(uint hKey, PChar lpValueName)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegDeleteKey(uint hKey, PChar lpSubKey)
	{
		int result = 0;
		return result;
	}
	
} // class WindowsInterface


file class WindowsImplementation
{

} // class WindowsImplementation

}  // namespace Windows

}  // namespace Winapi

