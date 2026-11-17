using System.Text;
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
		public ulong Internal;
		public ulong InternalHigh;
		public uint Offset;
		public uint OffsetHigh;
		public ulong hEvent;
		public static TOverlapped CreateRecord(){return new TOverlapped();}
	}	

	public struct TMsg
	{
		public ulong hwnd;
		public uint message;
		public ulong wParam;
		public long lParam;
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
		public ulong hInstance;
		public ulong hIcon;
		public ulong hCursor;
		public ulong hbrBackground;
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
		public ulong hInstance;
		public ulong hIcon;
		public ulong hCursor;
		public ulong hbrBackground;
		public PChar lpszMenuName;
		public PChar lpszClassName;
		public ulong hIconSm;
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
		public ulong hStdInput;
		public ulong hStdOutput;
		public ulong hStdError;
		public static TStartupInfo CreateRecord(){return new TStartupInfo();}
	}	

	public struct TProcessInformation
	{
		public ulong hProcess;
		public ulong hThread;
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
		public static TWin32FindData D2CCloneValue(TWin32FindData value)
		{
			value.cAlternateFileName = DelphiStaticArrayInfo.Create<char>(new int[] { 0 }, new int[] { 14 }).Clone(value.cAlternateFileName);
			value.cFileName = DelphiStaticArrayInfo.Create<char>(new int[] { 0 }, new int[] { 260 }).Clone(value.cFileName);
			return value;
		}
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
  /* Virtual-key codes; Pascal identifiers are case-insensitive. *//*
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
  /* Basic Win32 scalar types. */
public delegate long TFNWndProc(ulong hWnd, uint Msg, ulong wParam, long lParam);
  /* Virtual-key codes; Pascal identifiers are case-insensitive. */
	public const int VK_SHIFT = 0x10;
	public const int vkTab = 0x09;
	public const int vkPrior = 0x21;
	public const int vkNext = 0x22;
	public const int vkEnd = 0x23;
	public const int vkHome = 0x24;
	public const int vkLeft = 0x25;
	public const int vkUp = 0x26;
	public const int vkRight = 0x27;
	public const int vkDown = 0x28;
	public const int vkDelete = 0x2E;
	public const int MAX_PATH = 260;
	public const ulong INVALID_HANDLE_VALUE = unchecked((ulong) -1);
	public const uint INFINITE = ((uint)(0xFFFFFFFF));
	public const uint WAIT_OBJECT_0 = ((uint)(0x00000000));
	public const uint WAIT_ABANDONED = ((uint)(0x00000080));
	public const uint WAIT_TIMEOUT = ((uint)(0x00000102));
	public const uint WAIT_FAILED = ((uint)(0xFFFFFFFF));
	public const uint GENERIC_READ = ((uint)(0x80000000));
	public const uint GENERIC_WRITE = ((uint)(0x40000000));
	public const uint GENERIC_EXECUTE = ((uint)(0x20000000));
	public const uint GENERIC_ALL = ((uint)(0x10000000));
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
	public const uint INVALID_FILE_ATTRIBUTES = ((uint)(0xFFFFFFFF));
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
	public const ulong HWND_TOP = unchecked((ulong) 0);
	public const ulong HWND_BOTTOM = unchecked((ulong) 1);
	public const ulong HWND_TOPMOST = unchecked((ulong) -1);
	public const ulong HWND_NOTOPMOST = unchecked((ulong) -2);
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
	public const ulong HKEY_CLASSES_ROOT = unchecked((ulong) 0x80000000);
	public const ulong HKEY_CURRENT_USER = unchecked((ulong) 0x80000001);
	public const ulong HKEY_LOCAL_MACHINE = unchecked((ulong) 0x80000002);
	public const ulong HKEY_USERS = unchecked((ulong) 0x80000003);
	public const ulong HKEY_PERFORMANCE_DATA = unchecked((ulong) 0x80000004);
	public const ulong HKEY_CURRENT_CONFIG = unchecked((ulong) 0x80000005);

/* Error handling and timing */
	public static uint /*stdcall*/ GetLastError()
	{
		uint result = 0;
		return result;
	}
	public static string /*stdcall*/ CharLower(StringBuilder lpsz)
	{
		string result = default;
		result = ref lpsz;
		return result;
	}
	public static string /*stdcall*/ CharLowerW(StringBuilder lpsz)
	{
		string result = default;
		result = ref lpsz;
		return result;
	}
	public static string /*stdcall*/ CharUpper(StringBuilder lpsz)
	{
		string result = default;
		result = ref lpsz;
		return result;
	}
	public static string /*stdcall*/ CharUpperW(StringBuilder lpsz)
	{
		string result = default;
		result = ref lpsz;
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
	public static ulong /*stdcall*/ GetCurrentProcess()
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetCurrentProcessId()
	{
		uint result = 0;
		return result;
	}
	public static ulong /*stdcall*/ GetCurrentThread()
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetCurrentThreadId()
	{
		uint result = 0;
		return result;
	}
	public static ulong /*stdcall*/ LoadLibrary(PChar lpLibFileName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ LoadLibraryA(PAnsiChar lpLibFileName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ LoadLibraryW(PChar lpLibFileName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ FreeLibrary(ulong hLibModule)
	{
		int result = 0;
		return result;
	}
	public static Pointer /*stdcall*/ GetProcAddress(ulong hModule, PAnsiChar lpProcName)
	{
		Pointer result = default;
		return result;
	}
	public static ulong /*stdcall*/ GetModuleHandle(PChar lpModuleName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ GetModuleHandleA(PAnsiChar lpModuleName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ GetModuleHandleW(PChar lpModuleName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ GetModuleFileName(ulong hModule, PChar lpFilename, uint nSize)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ CreateProcess(PChar lpApplicationName, PChar lpCommandLine, Pointer<TSecurityAttributes> lpProcessAttributes, Pointer<TSecurityAttributes> lpThreadAttributes, int bInheritHandles, uint dwCreationFlags, Pointer lpEnvironment, PChar lpCurrentDirectory, TStartupInfo lpStartupInfo, ref TProcessInformation lpProcessInformation)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ TerminateProcess(ulong hProcess, uint uExitCode)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetExitCodeProcess(ulong hProcess, ref uint lpExitCode)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ CloseHandle(ulong hObject)
	{
		int result = 0;
		return result;
	}

/* Synchronization */
	public static ulong /*stdcall*/ CreateEvent(Pointer<TSecurityAttributes> lpEventAttributes, int bManualReset, int bInitialState, PChar lpName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ OpenEvent(uint dwDesiredAccess, int bInheritHandle, PChar lpName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ SetEvent(ulong hEvent)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ ResetEvent(ulong hEvent)
	{
		int result = 0;
		return result;
	}
	public static ulong /*stdcall*/ CreateMutex(Pointer<TSecurityAttributes> lpMutexAttributes, int bInitialOwner, PChar lpName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ ReleaseMutex(ulong hMutex)
	{
		int result = 0;
		return result;
	}
	public static ulong /*stdcall*/ CreateSemaphore(Pointer<TSecurityAttributes> lpSemaphoreAttributes, int lInitialCount, int lMaximumCount, PChar lpName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ ReleaseSemaphore(ulong hSemaphore, int lReleaseCount, Pointer<int> lpPreviousCount)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ WaitForSingleObject(ulong hHandle, uint dwMilliseconds)
	{
		uint result = 0;
		return result;
	}
	public static uint /*stdcall*/ WaitForMultipleObjects(uint nCount, Pointer<ulong> lpHandles, int bWaitAll, uint dwMilliseconds)
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
	public static ulong /*stdcall*/ CreateFile(PChar lpFileName, uint dwDesiredAccess, uint dwShareMode, Pointer<TSecurityAttributes> lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, ulong hTemplateFile)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ ReadFile(ulong hFile, UntypedPointer Buffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, Pointer<TOverlapped> lpOverlapped)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ WriteFile(ulong hFile, UntypedPointer Buffer, uint nNumberOfBytesToWrite, ref uint lpNumberOfBytesWritten, Pointer<TOverlapped> lpOverlapped)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ SetFilePointer(ulong hFile, int lDistanceToMove, Pointer<int> lpDistanceToMoveHigh, uint dwMoveMethod)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ SetEndOfFile(ulong hFile)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ FlushFileBuffers(ulong hFile)
	{
		int result = 0;
		return result;
	}
	public static uint /*stdcall*/ GetFileSize(ulong hFile, Pointer<uint> lpFileSizeHigh)
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
	public static ulong /*stdcall*/ FindFirstFile(PChar lpFileName, ref TWin32FindData lpFindFileData)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ FindNextFile(ulong hFindFile, ref TWin32FindData lpFindFileData)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ FindClose(ulong hFindFile)
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
	public static int /*stdcall*/ MessageBox(ulong hWnd, PChar lpText, PChar lpCaption, uint uType)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ MessageBoxA(ulong hWnd, PAnsiChar lpText, PAnsiChar lpCaption, uint uType)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ MessageBoxW(ulong hWnd, PChar lpText, PChar lpCaption, uint uType)
	{
		int result = 0;
		return result;
	}
	public static ulong /*stdcall*/ FindWindow(PChar lpClassName, PChar lpWindowName)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ GetDesktopWindow()
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ GetForegroundWindow()
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ SetForegroundWindow(ulong hWnd)
	{
		int result = 0;
		return result;
	}
	public static ulong /*stdcall*/ GetActiveWindow()
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ GetFocus()
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static ulong /*stdcall*/ SetFocus(ulong hWnd)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ IsWindow(ulong hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ IsWindowVisible(ulong hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ IsWindowEnabled(ulong hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ ShowWindow(ulong hWnd, int nCmdShow)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ EnableWindow(ulong hWnd, int bEnable)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ DestroyWindow(ulong hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowRect(ulong hWnd, ref TRect lpRect)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetClientRect(ulong hWnd, ref TRect lpRect)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ ClientToScreen(ulong hWnd, ref TPoint lpPoint)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ ScreenToClient(ulong hWnd, ref TPoint lpPoint)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ MoveWindow(ulong hWnd, int X, int Y, int nWidth, int nHeight, int bRepaint)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ SetWindowPos(ulong hWnd, ulong hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowText(ulong hWnd, PChar lpString, int nMaxCount)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowTextLength(ulong hWnd)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ SetWindowText(ulong hWnd, PChar lpString)
	{
		int result = 0;
		return result;
	}
	public static long /*stdcall*/ SendMessage(ulong hWnd, uint Msg, ulong wParam, long lParam)
	{
		long result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ PostMessage(ulong hWnd, uint Msg, ulong wParam, long lParam)
	{
		int result = 0;
		return result;
	}
	public static long /*stdcall*/ DefWindowProc(ulong hWnd, uint Msg, ulong wParam, long lParam)
	{
		long result = 0 /*Native*/;
		return result;
	}
	public static void /*stdcall*/ PostQuitMessage(int nExitCode)
	{
	}
	public static int /*stdcall*/ PeekMessage(ref TMsg lpMsg, ulong hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ GetMessage(ref TMsg lpMsg, ulong hWnd, uint wMsgFilterMin, uint wMsgFilterMax)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ TranslateMessage(TMsg lpMsg)
	{
		int result = 0;
		return result;
	}
	public static long /*stdcall*/ DispatchMessage(TMsg lpMsg)
	{
		long result = 0 /*Native*/;
		return result;
	}
	public static uint /*stdcall*/ RegisterWindowMessage(PChar lpString)
	{
		uint result = 0;
		return result;
	}
	public static int /*stdcall*/ GetWindowLong(ulong hWnd, int nIndex)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ SetWindowLong(ulong hWnd, int nIndex, int dwNewLong)
	{
		int result = 0;
		return result;
	}
	public static long /*stdcall*/ GetWindowLongPtr(ulong hWnd, int nIndex)
	{
		long result = 0 /*Native*/;
		return result;
	}
	public static long /*stdcall*/ SetWindowLongPtr(ulong hWnd, int nIndex, long dwNewLong)
	{
		long result = 0 /*Native*/;
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
	public static int /*stdcall*/ UnregisterClass(PChar lpClassName, ulong hInstance)
	{
		int result = 0;
		return result;
	}
	public static ulong /*stdcall*/ CreateWindowEx(uint dwExStyle, PChar lpClassName, PChar lpWindowName, uint dwStyle, int X, int Y, int nWidth, int nHeight, ulong hWndParent, ulong hMenu, ulong hInstance, Pointer lpParam)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ InvalidateRect(ulong hWnd, Pointer<TRect> lpRect, int bErase)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ UpdateWindow(ulong hWnd)
	{
		int result = 0;
		return result;
	}
	public static ulong /*stdcall*/ SetCursor(ulong hCursor)
	{
		ulong result = 0 /*Native*/;
		result = 0;
		return result;
	}
	public static ulong /*stdcall*/ GetCursor()
	{
		ulong result = 0 /*Native*/;
		result = 0;
		return result;
	}
	public static ulong /*stdcall*/ GetDC(ulong hWnd)
	{
		ulong result = 0 /*Native*/;
		return result;
	}
	public static int /*stdcall*/ ReleaseDC(ulong hWnd, ulong hDC)
	{
		int result = 0;
		return result;
	}

/* Registry */
	public static int /*stdcall*/ RegOpenKeyEx(ulong hKey, PChar lpSubKey, uint ulOptions, uint samDesired, ref ulong phkResult)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegCreateKeyEx(ulong hKey, PChar lpSubKey, uint Reserved, PChar lpClass, uint dwOptions, uint samDesired, Pointer<TSecurityAttributes> lpSecurityAttributes, ref ulong phkResult, Pointer<uint> lpdwDisposition)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegCloseKey(ulong hKey)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegQueryValueEx(ulong hKey, PChar lpValueName, Pointer<uint> lpReserved, Pointer<uint> lpType, Pointer<byte> lpData, Pointer<uint> lpcbData)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegSetValueEx(ulong hKey, PChar lpValueName, uint Reserved, uint dwType, Pointer<byte> lpData, uint cbData)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegDeleteValue(ulong hKey, PChar lpValueName)
	{
		int result = 0;
		return result;
	}
	public static int /*stdcall*/ RegDeleteKey(ulong hKey, PChar lpSubKey)
	{
		int result = 0;
		return result;
	}

/* Returns the key state, including the high-order pressed bit. */
	public static short /*stdcall*/ GetKeyState(int nVirtKey)
	{
		short result = 0;
		result = 0;
		return result;
	}
	
} // class WindowsInterface


file class WindowsImplementation
{

} // class WindowsImplementation

}  // namespace Windows

}  // namespace Winapi

