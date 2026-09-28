{
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
}

unit Winapi.Windows;

interface


type
  { Basic Win32 scalar types. }
  BOOL = Integer;
  BYTE = System.Byte;
  PBYTE = ^BYTE;
  LPBYTE = PBYTE;

  WORD = System.Word;
  PWORD = ^WORD;
  LPWORD = PWORD;

  DWORD = LongWord;
  PDWORD = ^DWORD;
  LPDWORD = PDWORD;

  INT = Integer;
  PINT = ^INT;
  UINT = Cardinal;
  PUINT = ^UINT;

  LONG = LongInt;
  PLONG = ^LONG;
  ULONG = LongWord;
  PULONG = ^ULONG;

  SHORT = SmallInt;
  USHORT = Word;

  DWORD_PTR = NativeUInt;
  ULONG_PTR = NativeUInt;
  LONG_PTR = NativeInt;
  UINT_PTR = NativeUInt;
  INT_PTR = NativeInt;
  SIZE_T = NativeUInt;
  SSIZE_T = NativeInt;

  WPARAM = NativeUInt;
  LPARAM = NativeInt;
  LRESULT = NativeInt;

  ATOM = Word;
  LANGID = Word;
  LCID = DWORD;
  LCTYPE = DWORD;
  COLORREF = DWORD;

  THandle = System.THandle;
  HANDLE = THandle;
  PHANDLE = ^HANDLE;

  HWND = type THandle;
  PHWND = ^HWND;
  HDC = type THandle;
  HGDIOBJ = type THandle;
  HBITMAP = type THandle;
  HBRUSH = type THandle;
  HFONT = type THandle;
  HPEN = type THandle;
  HRGN = type THandle;
  HPALETTE = type THandle;
  HICON = type THandle;
  HCURSOR = type THandle;
  HMENU = type THandle;
  HINSTANCE = type THandle;
  HINST = HINSTANCE;
  HMODULE = type THandle;
  HGLOBAL = type THandle;
  HLOCAL = type THandle;
  HRSRC = type THandle;
  HHOOK = type THandle;
  HMONITOR = type THandle;
  HKEY = type THandle;

  PHKEY = ^HKEY;

  PVOID = Pointer;
  LPVOID = Pointer;
  LPCVOID = Pointer;

  CHAR = AnsiChar;
  PCHARA = PAnsiChar;
  LPSTR = PAnsiChar;
  LPCSTR = PAnsiChar;

  WCHAR = WideChar;
  PWCHAR = PWideChar;
  LPWSTR = PWideChar;
  LPCWSTR = PWideChar;

  LPTSTR = PChar;
  LPCTSTR = PChar;

  FARPROC = Pointer;
  PROC = Pointer;

  TPoint = record
    X: LONG;
    Y: LONG;
  end;
  PPoint = ^TPoint;
  POINT = TPoint;
  PPOINT = ^POINT;

  TSize = record
    cx: LONG;
    cy: LONG;
  end;
  PSize = ^TSize;
  SIZE = TSize;
  PSIZE = ^SIZE;

  TRect = record
    Left: LONG;
    Top: LONG;
    Right: LONG;
    Bottom: LONG;
  end;
  PRect = ^TRect;
  RECT = TRect;
  PRECT = ^RECT;
  LPRECT = PRECT;
  LPCRECT = ^RECT;

  TFileTime = record
    dwLowDateTime: DWORD;
    dwHighDateTime: DWORD;
  end;
  PFileTime = ^TFileTime;
  FILETIME = TFileTime;
  PFILETIME = ^FILETIME;

  TSystemTime = record
    wYear: WORD;
    wMonth: WORD;
    wDayOfWeek: WORD;
    wDay: WORD;
    wHour: WORD;
    wMinute: WORD;
    wSecond: WORD;
    wMilliseconds: WORD;
  end;
  PSystemTime = ^TSystemTime;
  SYSTEMTIME = TSystemTime;
  PSYSTEMTIME = ^SYSTEMTIME;

  TSecurityAttributes = record
    nLength: DWORD;
    lpSecurityDescriptor: Pointer;
    bInheritHandle: BOOL;
  end;
  PSecurityAttributes = ^TSecurityAttributes;
  SECURITY_ATTRIBUTES = TSecurityAttributes;
  PSECURITY_ATTRIBUTES = ^SECURITY_ATTRIBUTES;
  LPSECURITY_ATTRIBUTES = PSECURITY_ATTRIBUTES;

  TOverlapped = record
    Internal: ULONG_PTR;
    InternalHigh: ULONG_PTR;
    Offset: DWORD;
    OffsetHigh: DWORD;
    hEvent: THandle;
  end;
  POverlapped = ^TOverlapped;
  OVERLAPPED = TOverlapped;
  LPOVERLAPPED = ^OVERLAPPED;

  TMsg = record
    hwnd: HWND;
    message: UINT;
    wParam: WPARAM;
    lParam: LPARAM;
    time: DWORD;
    pt: TPoint;
  end;
  PMsg = ^TMsg;
  MSG = TMsg;
  PMSG = ^MSG;
  LPMSG = PMSG;

  TFNWndProc = function(hWnd: HWND; Msg: UINT; wParam: WPARAM;
    lParam: LPARAM): LRESULT; stdcall;
  WNDPROC = TFNWndProc;

  TWndClass = record
    style: UINT;
    lpfnWndProc: WNDPROC;
    cbClsExtra: Integer;
    cbWndExtra: Integer;
    hInstance: HINST;
    hIcon: HICON;
    hCursor: HCURSOR;
    hbrBackground: HBRUSH;
    lpszMenuName: PChar;
    lpszClassName: PChar;
  end;
  PWndClass = ^TWndClass;
  WNDCLASS = TWndClass;
  PWNDCLASS = ^WNDCLASS;

  TWndClassEx = record
    cbSize: UINT;
    style: UINT;
    lpfnWndProc: WNDPROC;
    cbClsExtra: Integer;
    cbWndExtra: Integer;
    hInstance: HINST;
    hIcon: HICON;
    hCursor: HCURSOR;
    hbrBackground: HBRUSH;
    lpszMenuName: PChar;
    lpszClassName: PChar;
    hIconSm: HICON;
  end;
  PWndClassEx = ^TWndClassEx;
  WNDCLASSEX = TWndClassEx;
  PWNDCLASSEX = ^WNDCLASSEX;

  TStartupInfo = record
    cb: DWORD;
    lpReserved: PChar;
    lpDesktop: PChar;
    lpTitle: PChar;
    dwX: DWORD;
    dwY: DWORD;
    dwXSize: DWORD;
    dwYSize: DWORD;
    dwXCountChars: DWORD;
    dwYCountChars: DWORD;
    dwFillAttribute: DWORD;
    dwFlags: DWORD;
    wShowWindow: WORD;
    cbReserved2: WORD;
    lpReserved2: PBYTE;
    hStdInput: THandle;
    hStdOutput: THandle;
    hStdError: THandle;
  end;
  PStartupInfo = ^TStartupInfo;
  STARTUPINFO = TStartupInfo;
  LPSTARTUPINFO = ^STARTUPINFO;

  TProcessInformation = record
    hProcess: THandle;
    hThread: THandle;
    dwProcessId: DWORD;
    dwThreadId: DWORD;
  end;
  PProcessInformation = ^TProcessInformation;
  PROCESS_INFORMATION = TProcessInformation;
  LPPROCESS_INFORMATION = ^PROCESS_INFORMATION;

  TWin32FindData = record
    dwFileAttributes: DWORD;
    ftCreationTime: TFileTime;
    ftLastAccessTime: TFileTime;
    ftLastWriteTime: TFileTime;
    nFileSizeHigh: DWORD;
    nFileSizeLow: DWORD;
    dwReserved0: DWORD;
    dwReserved1: DWORD;
    cFileName: array[0..259] of System.Char;
    cAlternateFileName: array[0..13] of System.Char;
  end;
  PWin32FindData = ^TWin32FindData;

const
  MAX_PATH = 260;

  INVALID_HANDLE_VALUE = THandle(-1);

  INFINITE = DWORD($FFFFFFFF);
  WAIT_OBJECT_0 = DWORD($00000000);
  WAIT_ABANDONED = DWORD($00000080);
  WAIT_TIMEOUT = DWORD($00000102);
  WAIT_FAILED = DWORD($FFFFFFFF);

  GENERIC_READ = DWORD($80000000);
  GENERIC_WRITE = DWORD($40000000);
  GENERIC_EXECUTE = DWORD($20000000);
  GENERIC_ALL = DWORD($10000000);

  FILE_SHARE_READ = $00000001;
  FILE_SHARE_WRITE = $00000002;
  FILE_SHARE_DELETE = $00000004;

  CREATE_NEW = 1;
  CREATE_ALWAYS = 2;
  OPEN_EXISTING = 3;
  OPEN_ALWAYS = 4;
  TRUNCATE_EXISTING = 5;

  FILE_ATTRIBUTE_READONLY = $00000001;
  FILE_ATTRIBUTE_HIDDEN = $00000002;
  FILE_ATTRIBUTE_SYSTEM = $00000004;
  FILE_ATTRIBUTE_DIRECTORY = $00000010;
  FILE_ATTRIBUTE_ARCHIVE = $00000020;
  FILE_ATTRIBUTE_NORMAL = $00000080;
  FILE_ATTRIBUTE_TEMPORARY = $00000100;
  FILE_ATTRIBUTE_COMPRESSED = $00000800;
  FILE_ATTRIBUTE_OFFLINE = $00001000;
  FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = $00002000;
  FILE_ATTRIBUTE_ENCRYPTED = $00004000;
  INVALID_FILE_ATTRIBUTES = DWORD($FFFFFFFF);

  FILE_BEGIN = 0;
  FILE_CURRENT = 1;
  FILE_END = 2;

  ERROR_SUCCESS = 0;
  ERROR_FILE_NOT_FOUND = 2;
  ERROR_PATH_NOT_FOUND = 3;
  ERROR_ACCESS_DENIED = 5;
  ERROR_INVALID_HANDLE = 6;
  ERROR_NOT_ENOUGH_MEMORY = 8;
  ERROR_INVALID_DATA = 13;
  ERROR_OUTOFMEMORY = 14;
  ERROR_NO_MORE_FILES = 18;
  ERROR_SHARING_VIOLATION = 32;
  ERROR_FILE_EXISTS = 80;
  ERROR_INVALID_PARAMETER = 87;
  ERROR_INSUFFICIENT_BUFFER = 122;
  ERROR_ALREADY_EXISTS = 183;

  FORMAT_MESSAGE_ALLOCATE_BUFFER = $00000100;
  FORMAT_MESSAGE_IGNORE_INSERTS = $00000200;
  FORMAT_MESSAGE_FROM_STRING = $00000400;
  FORMAT_MESSAGE_FROM_HMODULE = $00000800;
  FORMAT_MESSAGE_FROM_SYSTEM = $00001000;

  MB_OK = $00000000;
  MB_OKCANCEL = $00000001;
  MB_ABORTRETRYIGNORE = $00000002;
  MB_YESNOCANCEL = $00000003;
  MB_YESNO = $00000004;
  MB_RETRYCANCEL = $00000005;
  MB_ICONERROR = $00000010;
  MB_ICONQUESTION = $00000020;
  MB_ICONWARNING = $00000030;
  MB_ICONINFORMATION = $00000040;

  IDOK = 1;
  IDCANCEL = 2;
  IDABORT = 3;
  IDRETRY = 4;
  IDIGNORE = 5;
  IDYES = 6;
  IDNO = 7;

  SW_HIDE = 0;
  SW_SHOWNORMAL = 1;
  SW_SHOWMINIMIZED = 2;
  SW_SHOWMAXIMIZED = 3;
  SW_SHOWNOACTIVATE = 4;
  SW_SHOW = 5;
  SW_MINIMIZE = 6;
  SW_SHOWMINNOACTIVE = 7;
  SW_SHOWNA = 8;
  SW_RESTORE = 9;

  SWP_NOSIZE = $0001;
  SWP_NOMOVE = $0002;
  SWP_NOZORDER = $0004;
  SWP_NOREDRAW = $0008;
  SWP_NOACTIVATE = $0010;
  SWP_FRAMECHANGED = $0020;
  SWP_SHOWWINDOW = $0040;
  SWP_HIDEWINDOW = $0080;
  SWP_NOCOPYBITS = $0100;
  SWP_NOOWNERZORDER = $0200;
  SWP_NOSENDCHANGING = $0400;

  HWND_TOP = HWND(0);
  HWND_BOTTOM = HWND(1);
  HWND_TOPMOST = HWND(-1);
  HWND_NOTOPMOST = HWND(-2);

  GWL_WNDPROC = -4;
  GWL_HINSTANCE = -6;
  GWL_HWNDPARENT = -8;
  GWL_ID = -12;
  GWL_STYLE = -16;
  GWL_EXSTYLE = -20;
  GWL_USERDATA = -21;

  GWLP_WNDPROC = -4;
  GWLP_HINSTANCE = -6;
  GWLP_HWNDPARENT = -8;
  GWLP_ID = -12;
  GWLP_USERDATA = -21;

  WM_NULL = $0000;
  WM_CREATE = $0001;
  WM_DESTROY = $0002;
  WM_MOVE = $0003;
  WM_SIZE = $0005;
  WM_SETFOCUS = $0007;
  WM_KILLFOCUS = $0008;
  WM_ENABLE = $000A;
  WM_SETREDRAW = $000B;
  WM_SETTEXT = $000C;
  WM_GETTEXT = $000D;
  WM_GETTEXTLENGTH = $000E;
  WM_PAINT = $000F;
  WM_CLOSE = $0010;
  WM_QUIT = $0012;
  WM_ERASEBKGND = $0014;
  WM_SHOWWINDOW = $0018;
  WM_SETCURSOR = $0020;
  WM_GETMINMAXINFO = $0024;
  WM_COMMAND = $0111;
  WM_TIMER = $0113;
  WM_HSCROLL = $0114;
  WM_VSCROLL = $0115;
  WM_MOUSEMOVE = $0200;
  WM_LBUTTONDOWN = $0201;
  WM_LBUTTONUP = $0202;
  WM_RBUTTONDOWN = $0204;
  WM_RBUTTONUP = $0205;
  WM_MOUSEWHEEL = $020A;
  WM_USER = $0400;
  WM_APP = $8000;

  PM_NOREMOVE = $0000;
  PM_REMOVE = $0001;
  PM_NOYIELD = $0002;

  KEY_QUERY_VALUE = $0001;
  KEY_SET_VALUE = $0002;
  KEY_CREATE_SUB_KEY = $0004;
  KEY_ENUMERATE_SUB_KEYS = $0008;
  KEY_NOTIFY = $0010;
  KEY_CREATE_LINK = $0020;
  KEY_WOW64_64KEY = $0100;
  KEY_WOW64_32KEY = $0200;
  KEY_READ = $20019;
  KEY_WRITE = $20006;
  KEY_ALL_ACCESS = $F003F;

  REG_NONE = 0;
  REG_SZ = 1;
  REG_EXPAND_SZ = 2;
  REG_BINARY = 3;
  REG_DWORD = 4;
  REG_MULTI_SZ = 7;
  REG_QWORD = 11;

  HKEY_CLASSES_ROOT = HKEY($80000000);
  HKEY_CURRENT_USER = HKEY($80000001);
  HKEY_LOCAL_MACHINE = HKEY($80000002);
  HKEY_USERS = HKEY($80000003);
  HKEY_PERFORMANCE_DATA = HKEY($80000004);
  HKEY_CURRENT_CONFIG = HKEY($80000005);

{ Error handling and timing }

function GetLastError: DWORD; stdcall;
procedure SetLastError(dwErrCode: DWORD); stdcall;
function GetTickCount: DWORD; stdcall;
procedure Sleep(dwMilliseconds: DWORD); stdcall;
function QueryPerformanceCounter(var lpPerformanceCount: Int64): BOOL; stdcall;
function QueryPerformanceFrequency(var lpFrequency: Int64): BOOL; stdcall;

function FormatMessage(dwFlags: DWORD; lpSource: Pointer; dwMessageId: DWORD;
  dwLanguageId: DWORD; lpBuffer: PChar; nSize: DWORD;
  Arguments: Pointer): DWORD; stdcall;

{ Process, thread and module functions }

function GetCurrentProcess: THandle; stdcall;
function GetCurrentProcessId: DWORD; stdcall;
function GetCurrentThread: THandle; stdcall;
function GetCurrentThreadId: DWORD; stdcall;

function LoadLibrary(lpLibFileName: PChar): HMODULE; stdcall;
function LoadLibraryA(lpLibFileName: PAnsiChar): HMODULE; stdcall;
function LoadLibraryW(lpLibFileName: PWideChar): HMODULE; stdcall;
function FreeLibrary(hLibModule: HMODULE): BOOL; stdcall;
function GetProcAddress(hModule: HMODULE; lpProcName: PAnsiChar): FARPROC; stdcall;
function GetModuleHandle(lpModuleName: PChar): HMODULE; stdcall;
function GetModuleHandleA(lpModuleName: PAnsiChar): HMODULE; stdcall;
function GetModuleHandleW(lpModuleName: PWideChar): HMODULE; stdcall;
function GetModuleFileName(hModule: HMODULE; lpFilename: PChar;
  nSize: DWORD): DWORD; stdcall;

function CreateProcess(lpApplicationName: PChar; lpCommandLine: PChar;
  lpProcessAttributes: PSecurityAttributes;
  lpThreadAttributes: PSecurityAttributes; bInheritHandles: BOOL;
  dwCreationFlags: DWORD; lpEnvironment: Pointer;
  lpCurrentDirectory: PChar; const lpStartupInfo: TStartupInfo;
  var lpProcessInformation: TProcessInformation): BOOL; stdcall;

function TerminateProcess(hProcess: THandle; uExitCode: UINT): BOOL; stdcall;
function GetExitCodeProcess(hProcess: THandle; var lpExitCode: DWORD): BOOL; stdcall;
function CloseHandle(hObject: THandle): BOOL; stdcall;

{ Synchronization }

function CreateEvent(lpEventAttributes: PSecurityAttributes;
  bManualReset, bInitialState: BOOL; lpName: PChar): THandle; stdcall;
function OpenEvent(dwDesiredAccess: DWORD; bInheritHandle: BOOL;
  lpName: PChar): THandle; stdcall;
function SetEvent(hEvent: THandle): BOOL; stdcall;
function ResetEvent(hEvent: THandle): BOOL; stdcall;

function CreateMutex(lpMutexAttributes: PSecurityAttributes;
  bInitialOwner: BOOL; lpName: PChar): THandle; stdcall;
function ReleaseMutex(hMutex: THandle): BOOL; stdcall;

function CreateSemaphore(lpSemaphoreAttributes: PSecurityAttributes;
  lInitialCount, lMaximumCount: LONG; lpName: PChar): THandle; stdcall;
function ReleaseSemaphore(hSemaphore: THandle; lReleaseCount: LONG;
  lpPreviousCount: PLONG): BOOL; stdcall;

function WaitForSingleObject(hHandle: THandle; dwMilliseconds: DWORD): DWORD; stdcall;
function WaitForMultipleObjects(nCount: DWORD; lpHandles: PHANDLE;
  bWaitAll: BOOL; dwMilliseconds: DWORD): DWORD; stdcall;

function InterlockedIncrement(var Addend: LONG): LONG; stdcall;
function InterlockedDecrement(var Addend: LONG): LONG; stdcall;
function InterlockedExchange(var Target: LONG; Value: LONG): LONG; stdcall;
function InterlockedCompareExchange(var Destination: LONG;
  Exchange, Comparand: LONG): LONG; stdcall;

{ File system }

function CreateFile(lpFileName: PChar; dwDesiredAccess, dwShareMode: DWORD;
  lpSecurityAttributes: PSecurityAttributes; dwCreationDisposition,
  dwFlagsAndAttributes: DWORD; hTemplateFile: THandle): THandle; stdcall;

function ReadFile(hFile: THandle; var Buffer; nNumberOfBytesToRead: DWORD;
  var lpNumberOfBytesRead: DWORD; lpOverlapped: POverlapped): BOOL; stdcall;
function WriteFile(hFile: THandle; const Buffer; nNumberOfBytesToWrite: DWORD;
  var lpNumberOfBytesWritten: DWORD; lpOverlapped: POverlapped): BOOL; stdcall;

function SetFilePointer(hFile: THandle; lDistanceToMove: LONG;
  lpDistanceToMoveHigh: PLONG; dwMoveMethod: DWORD): DWORD; stdcall;
function SetEndOfFile(hFile: THandle): BOOL; stdcall;
function FlushFileBuffers(hFile: THandle): BOOL; stdcall;
function GetFileSize(hFile: THandle; lpFileSizeHigh: PDWORD): DWORD; stdcall;

function DeleteFile(lpFileName: PChar): BOOL; stdcall;
function MoveFile(lpExistingFileName, lpNewFileName: PChar): BOOL; stdcall;
function CopyFile(lpExistingFileName, lpNewFileName: PChar;
  bFailIfExists: BOOL): BOOL; stdcall;
function GetFileAttributes(lpFileName: PChar): DWORD; stdcall;
function SetFileAttributes(lpFileName: PChar; dwFileAttributes: DWORD): BOOL; stdcall;

function CreateDirectory(lpPathName: PChar;
  lpSecurityAttributes: PSecurityAttributes): BOOL; stdcall;
function RemoveDirectory(lpPathName: PChar): BOOL; stdcall;
function GetCurrentDirectory(nBufferLength: DWORD; lpBuffer: PChar): DWORD; stdcall;
function SetCurrentDirectory(lpPathName: PChar): BOOL; stdcall;
function GetTempPath(nBufferLength: DWORD; lpBuffer: PChar): DWORD; stdcall;
function GetTempFileName(lpPathName, lpPrefixString: PChar;
  uUnique: UINT; lpTempFileName: PChar): UINT; stdcall;

function FindFirstFile(lpFileName: PChar;
  var lpFindFileData: TWin32FindData): THandle; stdcall;
function FindNextFile(hFindFile: THandle;
  var lpFindFileData: TWin32FindData): BOOL; stdcall;
function FindClose(hFindFile: THandle): BOOL; stdcall;

{ Date and time }

procedure GetSystemTime(var lpSystemTime: TSystemTime); stdcall;
procedure GetLocalTime(var lpSystemTime: TSystemTime); stdcall;
function SystemTimeToFileTime(const lpSystemTime: TSystemTime;
  var lpFileTime: TFileTime): BOOL; stdcall;
function FileTimeToSystemTime(const lpFileTime: TFileTime;
  var lpSystemTime: TSystemTime): BOOL; stdcall;
function LocalFileTimeToFileTime(const lpLocalFileTime: TFileTime;
  var lpFileTime: TFileTime): BOOL; stdcall;
function FileTimeToLocalFileTime(const lpFileTime: TFileTime;
  var lpLocalFileTime: TFileTime): BOOL; stdcall;

{ Windows and messages }

function MessageBox(hWnd: HWND; lpText, lpCaption: PChar;
  uType: UINT): Integer; stdcall;
function MessageBoxA(hWnd: HWND; lpText, lpCaption: PAnsiChar;
  uType: UINT): Integer; stdcall;
function MessageBoxW(hWnd: HWND; lpText, lpCaption: PWideChar;
  uType: UINT): Integer; stdcall;

function FindWindow(lpClassName, lpWindowName: PChar): HWND; stdcall;
function GetDesktopWindow: HWND; stdcall;
function GetForegroundWindow: HWND; stdcall;
function SetForegroundWindow(hWnd: HWND): BOOL; stdcall;
function GetActiveWindow: HWND; stdcall;
function GetFocus: HWND; stdcall;
function SetFocus(hWnd: HWND): HWND; stdcall;
function IsWindow(hWnd: HWND): BOOL; stdcall;
function IsWindowVisible(hWnd: HWND): BOOL; stdcall;
function IsWindowEnabled(hWnd: HWND): BOOL; stdcall;
function ShowWindow(hWnd: HWND; nCmdShow: Integer): BOOL; stdcall;
function EnableWindow(hWnd: HWND; bEnable: BOOL): BOOL; stdcall;
function DestroyWindow(hWnd: HWND): BOOL; stdcall;

function GetWindowRect(hWnd: HWND; var lpRect: TRect): BOOL; stdcall;
function GetClientRect(hWnd: HWND; var lpRect: TRect): BOOL; stdcall;
function ClientToScreen(hWnd: HWND; var lpPoint: TPoint): BOOL; stdcall;
function ScreenToClient(hWnd: HWND; var lpPoint: TPoint): BOOL; stdcall;
function MoveWindow(hWnd: HWND; X, Y, nWidth, nHeight: Integer;
  bRepaint: BOOL): BOOL; stdcall;
function SetWindowPos(hWnd, hWndInsertAfter: HWND; X, Y, cx, cy: Integer;
  uFlags: UINT): BOOL; stdcall;

function GetWindowText(hWnd: HWND; lpString: PChar; nMaxCount: Integer): Integer; stdcall;
function GetWindowTextLength(hWnd: HWND): Integer; stdcall;
function SetWindowText(hWnd: HWND; lpString: PChar): BOOL; stdcall;

function SendMessage(hWnd: HWND; Msg: UINT; wParam: WPARAM;
  lParam: LPARAM): LRESULT; stdcall;
function PostMessage(hWnd: HWND; Msg: UINT; wParam: WPARAM;
  lParam: LPARAM): BOOL; stdcall;
function DefWindowProc(hWnd: HWND; Msg: UINT; wParam: WPARAM;
  lParam: LPARAM): LRESULT; stdcall;
procedure PostQuitMessage(nExitCode: Integer); stdcall;

function PeekMessage(var lpMsg: TMsg; hWnd: HWND; wMsgFilterMin,
  wMsgFilterMax, wRemoveMsg: UINT): BOOL; stdcall;
function GetMessage(var lpMsg: TMsg; hWnd: HWND; wMsgFilterMin,
  wMsgFilterMax: UINT): BOOL; stdcall;
function TranslateMessage(const lpMsg: TMsg): BOOL; stdcall;
function DispatchMessage(const lpMsg: TMsg): LRESULT; stdcall;
function RegisterWindowMessage(lpString: PChar): UINT; stdcall;

function GetWindowLong(hWnd: HWND; nIndex: Integer): LONG; stdcall;
function SetWindowLong(hWnd: HWND; nIndex: Integer; dwNewLong: LONG): LONG; stdcall;
function GetWindowLongPtr(hWnd: HWND; nIndex: Integer): LONG_PTR; stdcall;
function SetWindowLongPtr(hWnd: HWND; nIndex: Integer;
  dwNewLong: LONG_PTR): LONG_PTR; stdcall;

function RegisterClass(const lpWndClass: TWndClass): ATOM; stdcall;
function RegisterClassEx(const lpWndClass: TWndClassEx): ATOM; stdcall;
function UnregisterClass(lpClassName: PChar; hInstance: HINST): BOOL; stdcall;

function CreateWindowEx(dwExStyle: DWORD; lpClassName, lpWindowName: PChar;
  dwStyle: DWORD; X, Y, nWidth, nHeight: Integer; hWndParent: HWND;
  hMenu: HMENU; hInstance: HINST; lpParam: Pointer): HWND; stdcall;

function InvalidateRect(hWnd: HWND; lpRect: PRect; bErase: BOOL): BOOL; stdcall;
function UpdateWindow(hWnd: HWND): BOOL; stdcall;

function GetDC(hWnd: HWND): HDC; stdcall;
function ReleaseDC(hWnd: HWND; hDC: HDC): Integer; stdcall;

{ Registry }

function RegOpenKeyEx(hKey: HKEY; lpSubKey: PChar; ulOptions: DWORD;
  samDesired: DWORD; var phkResult: HKEY): LONG; stdcall;
function RegCreateKeyEx(hKey: HKEY; lpSubKey: PChar; Reserved: DWORD;
  lpClass: PChar; dwOptions, samDesired: DWORD;
  lpSecurityAttributes: PSecurityAttributes; var phkResult: HKEY;
  lpdwDisposition: PDWORD): LONG; stdcall;
function RegCloseKey(hKey: HKEY): LONG; stdcall;
function RegQueryValueEx(hKey: HKEY; lpValueName: PChar; lpReserved: PDWORD;
  lpType: PDWORD; lpData: PBYTE; lpcbData: PDWORD): LONG; stdcall;
function RegSetValueEx(hKey: HKEY; lpValueName: PChar; Reserved, dwType: DWORD;
  lpData: PBYTE; cbData: DWORD): LONG; stdcall;
function RegDeleteValue(hKey: HKEY; lpValueName: PChar): LONG; stdcall;
function RegDeleteKey(hKey: HKEY; lpSubKey: PChar): LONG; stdcall;

implementation

function GetLastError: DWORD;
begin
end;

procedure SetLastError(dwErrCode: DWORD);
begin
end;

function GetTickCount: DWORD;
begin
end;

procedure Sleep(dwMilliseconds: DWORD);
begin
end;

function QueryPerformanceCounter(var lpPerformanceCount: Int64): BOOL;
begin
end;

function QueryPerformanceFrequency(var lpFrequency: Int64): BOOL;
begin
end;

function FormatMessage(dwFlags: DWORD; lpSource: Pointer; dwMessageId: DWORD;
  dwLanguageId: DWORD; lpBuffer: PChar; nSize: DWORD;
  Arguments: Pointer): DWORD;
begin
end;

function GetCurrentProcess: THandle;
begin
end;

function GetCurrentProcessId: DWORD;
begin
end;

function GetCurrentThread: THandle;
begin
end;

function GetCurrentThreadId: DWORD;
begin
end;

function LoadLibrary(lpLibFileName: PChar): HMODULE;
begin
end;

function LoadLibraryA(lpLibFileName: PAnsiChar): HMODULE;
begin
end;

function LoadLibraryW(lpLibFileName: PWideChar): HMODULE;
begin
end;

function FreeLibrary(hLibModule: HMODULE): BOOL;
begin
end;

function GetProcAddress(hModule: HMODULE; lpProcName: PAnsiChar): FARPROC;
begin
end;

function GetModuleHandle(lpModuleName: PChar): HMODULE;
begin
end;

function GetModuleHandleA(lpModuleName: PAnsiChar): HMODULE;
begin
end;

function GetModuleHandleW(lpModuleName: PWideChar): HMODULE;
begin
end;

function GetModuleFileName(hModule: HMODULE; lpFilename: PChar;
  nSize: DWORD): DWORD;
begin
end;

function CreateProcess(lpApplicationName: PChar; lpCommandLine: PChar;
  lpProcessAttributes: PSecurityAttributes;
  lpThreadAttributes: PSecurityAttributes; bInheritHandles: BOOL;
  dwCreationFlags: DWORD; lpEnvironment: Pointer;
  lpCurrentDirectory: PChar; const lpStartupInfo: TStartupInfo;
  var lpProcessInformation: TProcessInformation): BOOL;
begin
end;

function TerminateProcess(hProcess: THandle; uExitCode: UINT): BOOL;
begin
end;

function GetExitCodeProcess(hProcess: THandle; var lpExitCode: DWORD): BOOL;
begin
end;

function CloseHandle(hObject: THandle): BOOL;
begin
end;

function CreateEvent(lpEventAttributes: PSecurityAttributes;
  bManualReset, bInitialState: BOOL; lpName: PChar): THandle;
begin
end;

function OpenEvent(dwDesiredAccess: DWORD; bInheritHandle: BOOL;
  lpName: PChar): THandle;
begin
end;

function SetEvent(hEvent: THandle): BOOL;
begin
end;

function ResetEvent(hEvent: THandle): BOOL;
begin
end;

function CreateMutex(lpMutexAttributes: PSecurityAttributes;
  bInitialOwner: BOOL; lpName: PChar): THandle;
begin
end;

function ReleaseMutex(hMutex: THandle): BOOL;
begin
end;

function CreateSemaphore(lpSemaphoreAttributes: PSecurityAttributes;
  lInitialCount, lMaximumCount: LONG; lpName: PChar): THandle;
begin
end;

function ReleaseSemaphore(hSemaphore: THandle; lReleaseCount: LONG;
  lpPreviousCount: PLONG): BOOL;
begin
end;

function WaitForSingleObject(hHandle: THandle; dwMilliseconds: DWORD): DWORD;
begin
end;

function WaitForMultipleObjects(nCount: DWORD; lpHandles: PHANDLE;
  bWaitAll: BOOL; dwMilliseconds: DWORD): DWORD;
begin
end;

function InterlockedIncrement(var Addend: LONG): LONG;
begin
end;

function InterlockedDecrement(var Addend: LONG): LONG;
begin
end;

function InterlockedExchange(var Target: LONG; Value: LONG): LONG;
begin
end;

function InterlockedCompareExchange(var Destination: LONG;
  Exchange, Comparand: LONG): LONG;
begin
end;

function CreateFile(lpFileName: PChar; dwDesiredAccess, dwShareMode: DWORD;
  lpSecurityAttributes: PSecurityAttributes; dwCreationDisposition,
  dwFlagsAndAttributes: DWORD; hTemplateFile: THandle): THandle;
begin
end;

function ReadFile(hFile: THandle; var Buffer; nNumberOfBytesToRead: DWORD;
  var lpNumberOfBytesRead: DWORD; lpOverlapped: POverlapped): BOOL;
begin
end;

function WriteFile(hFile: THandle; const Buffer; nNumberOfBytesToWrite: DWORD;
  var lpNumberOfBytesWritten: DWORD; lpOverlapped: POverlapped): BOOL;
begin
end;

function SetFilePointer(hFile: THandle; lDistanceToMove: LONG;
  lpDistanceToMoveHigh: PLONG; dwMoveMethod: DWORD): DWORD;
begin
end;

function SetEndOfFile(hFile: THandle): BOOL;
begin
end;

function FlushFileBuffers(hFile: THandle): BOOL;
begin
end;

function GetFileSize(hFile: THandle; lpFileSizeHigh: PDWORD): DWORD;
begin
end;

function DeleteFile(lpFileName: PChar): BOOL;
begin
end;

function MoveFile(lpExistingFileName, lpNewFileName: PChar): BOOL;
begin
end;

function CopyFile(lpExistingFileName, lpNewFileName: PChar;
  bFailIfExists: BOOL): BOOL;
begin
end;

function GetFileAttributes(lpFileName: PChar): DWORD;
begin
end;

function SetFileAttributes(lpFileName: PChar; dwFileAttributes: DWORD): BOOL;
begin
end;

function CreateDirectory(lpPathName: PChar;
  lpSecurityAttributes: PSecurityAttributes): BOOL;
begin
end;

function RemoveDirectory(lpPathName: PChar): BOOL;
begin
end;

function GetCurrentDirectory(nBufferLength: DWORD; lpBuffer: PChar): DWORD;
begin
end;

function SetCurrentDirectory(lpPathName: PChar): BOOL;
begin
end;

function GetTempPath(nBufferLength: DWORD; lpBuffer: PChar): DWORD;
begin
end;

function GetTempFileName(lpPathName, lpPrefixString: PChar;
  uUnique: UINT; lpTempFileName: PChar): UINT;
begin
end;

function FindFirstFile(lpFileName: PChar;
  var lpFindFileData: TWin32FindData): THandle;
begin
end;

function FindNextFile(hFindFile: THandle;
  var lpFindFileData: TWin32FindData): BOOL;
begin
end;

function FindClose(hFindFile: THandle): BOOL;
begin
end;

procedure GetSystemTime(var lpSystemTime: TSystemTime);
begin
end;

procedure GetLocalTime(var lpSystemTime: TSystemTime);
begin
end;

function SystemTimeToFileTime(const lpSystemTime: TSystemTime;
  var lpFileTime: TFileTime): BOOL;
begin
end;

function FileTimeToSystemTime(const lpFileTime: TFileTime;
  var lpSystemTime: TSystemTime): BOOL;
begin
end;

function LocalFileTimeToFileTime(const lpLocalFileTime: TFileTime;
  var lpFileTime: TFileTime): BOOL;
begin
end;

function FileTimeToLocalFileTime(const lpFileTime: TFileTime;
  var lpLocalFileTime: TFileTime): BOOL;
begin
end;

function MessageBox(hWnd: HWND; lpText, lpCaption: PChar;
  uType: UINT): Integer;
begin
end;

function MessageBoxA(hWnd: HWND; lpText, lpCaption: PAnsiChar;
  uType: UINT): Integer;
begin
end;

function MessageBoxW(hWnd: HWND; lpText, lpCaption: PWideChar;
  uType: UINT): Integer;
begin
end;

function FindWindow(lpClassName, lpWindowName: PChar): HWND;
begin
end;

function GetDesktopWindow: HWND;
begin
end;

function GetForegroundWindow: HWND;
begin
end;

function SetForegroundWindow(hWnd: HWND): BOOL;
begin
end;

function GetActiveWindow: HWND;
begin
end;

function GetFocus: HWND;
begin
end;

function SetFocus(hWnd: HWND): HWND;
begin
end;

function IsWindow(hWnd: HWND): BOOL;
begin
end;

function IsWindowVisible(hWnd: HWND): BOOL;
begin
end;

function IsWindowEnabled(hWnd: HWND): BOOL;
begin
end;

function ShowWindow(hWnd: HWND; nCmdShow: Integer): BOOL;
begin
end;

function EnableWindow(hWnd: HWND; bEnable: BOOL): BOOL;
begin
end;

function DestroyWindow(hWnd: HWND): BOOL;
begin
end;

function GetWindowRect(hWnd: HWND; var lpRect: TRect): BOOL;
begin
end;

function GetClientRect(hWnd: HWND; var lpRect: TRect): BOOL;
begin
end;

function ClientToScreen(hWnd: HWND; var lpPoint: TPoint): BOOL;
begin
end;

function ScreenToClient(hWnd: HWND; var lpPoint: TPoint): BOOL;
begin
end;

function MoveWindow(hWnd: HWND; X, Y, nWidth, nHeight: Integer;
  bRepaint: BOOL): BOOL;
begin
end;

function SetWindowPos(hWnd, hWndInsertAfter: HWND; X, Y, cx, cy: Integer;
  uFlags: UINT): BOOL;
begin
end;

function GetWindowText(hWnd: HWND; lpString: PChar; nMaxCount: Integer): Integer;
begin
end;

function GetWindowTextLength(hWnd: HWND): Integer;
begin
end;

function SetWindowText(hWnd: HWND; lpString: PChar): BOOL;
begin
end;

function SendMessage(hWnd: HWND; Msg: UINT; wParam: WPARAM;
  lParam: LPARAM): LRESULT;
begin
end;

function PostMessage(hWnd: HWND; Msg: UINT; wParam: WPARAM;
  lParam: LPARAM): BOOL;
begin
end;

function DefWindowProc(hWnd: HWND; Msg: UINT; wParam: WPARAM;
  lParam: LPARAM): LRESULT;
begin
end;

procedure PostQuitMessage(nExitCode: Integer);
begin
end;

function PeekMessage(var lpMsg: TMsg; hWnd: HWND; wMsgFilterMin,
  wMsgFilterMax, wRemoveMsg: UINT): BOOL;
begin
end;

function GetMessage(var lpMsg: TMsg; hWnd: HWND; wMsgFilterMin,
  wMsgFilterMax: UINT): BOOL;
begin
end;

function TranslateMessage(const lpMsg: TMsg): BOOL;
begin
end;

function DispatchMessage(const lpMsg: TMsg): LRESULT;
begin
end;

function RegisterWindowMessage(lpString: PChar): UINT;
begin
end;

function GetWindowLong(hWnd: HWND; nIndex: Integer): LONG;
begin
end;

function SetWindowLong(hWnd: HWND; nIndex: Integer; dwNewLong: LONG): LONG;
begin
end;

function GetWindowLongPtr(hWnd: HWND; nIndex: Integer): LONG_PTR;
begin
end;

function SetWindowLongPtr(hWnd: HWND; nIndex: Integer;
  dwNewLong: LONG_PTR): LONG_PTR;
begin
end;

function RegisterClass(const lpWndClass: TWndClass): ATOM;
begin
end;

function RegisterClassEx(const lpWndClass: TWndClassEx): ATOM;
begin
end;

function UnregisterClass(lpClassName: PChar; hInstance: HINST): BOOL;
begin
end;

function CreateWindowEx(dwExStyle: DWORD; lpClassName, lpWindowName: PChar;
  dwStyle: DWORD; X, Y, nWidth, nHeight: Integer; hWndParent: HWND;
  hMenu: HMENU; hInstance: HINST; lpParam: Pointer): HWND;
begin
end;

function InvalidateRect(hWnd: HWND; lpRect: PRect; bErase: BOOL): BOOL;
begin
end;

function UpdateWindow(hWnd: HWND): BOOL;
begin
end;

function GetDC(hWnd: HWND): HDC;
begin
end;

function ReleaseDC(hWnd: HWND; hDC: HDC): Integer;
begin
end;

function RegOpenKeyEx(hKey: HKEY; lpSubKey: PChar; ulOptions: DWORD;
  samDesired: DWORD; var phkResult: HKEY): LONG;
begin
end;

function RegCreateKeyEx(hKey: HKEY; lpSubKey: PChar; Reserved: DWORD;
  lpClass: PChar; dwOptions, samDesired: DWORD;
  lpSecurityAttributes: PSecurityAttributes; var phkResult: HKEY;
  lpdwDisposition: PDWORD): LONG;
begin
end;

function RegCloseKey(hKey: HKEY): LONG;
begin
end;

function RegQueryValueEx(hKey: HKEY; lpValueName: PChar; lpReserved: PDWORD;
  lpType: PDWORD; lpData: PBYTE; lpcbData: PDWORD): LONG;
begin
end;

function RegSetValueEx(hKey: HKEY; lpValueName: PChar; Reserved, dwType: DWORD;
  lpData: PBYTE; cbData: DWORD): LONG;
begin
end;

function RegDeleteValue(hKey: HKEY; lpValueName: PChar): LONG;
begin
end;

function RegDeleteKey(hKey: HKEY; lpSubKey: PChar): LONG;
begin
end;

end.
