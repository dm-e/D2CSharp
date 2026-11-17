using System;
using static System.SystemInterface;
using static Winapi.Shellapi.ShellapiImplementation;
using static Winapi.Shellapi.ShellapiInterface;

namespace Winapi
{

namespace Shellapi
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of selected Winapi.ShellApi declarations.
  This file is independently written for source translation.
  It does not call Windows and does not implement Shell API behavior.
  The records describe source-level members, not guaranteed native layouts.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/


public class ShellapiInterface
{

	public struct TShellExecuteInfo
	{
		public uint cbSize;
		public uint fMask;
		public ulong Wnd;
		public PChar lpVerb;
		public PChar lpFile;
		public PChar lpParameters;
		public PChar lpDirectory;
		public int nShow;
		public ulong hInstApp;
		public Pointer lpIDList;
		public PChar lpClass;
		public ulong hkeyClass;
		public uint dwHotKey;
		public ulong hIcon;
		public ulong hProcess;
		public static TShellExecuteInfo CreateRecord(){return new TShellExecuteInfo();}
	}	

	public struct TSHFileOpStruct
	{
		public ulong Wnd;
		public uint wFunc;
		public PChar pFrom;
		public PChar pTo;
		public ushort fFlags;
		public int fAnyOperationsAborted;
		public Pointer hNameMappings;
		public PChar lpszProgressTitle;
		public static TSHFileOpStruct CreateRecord(){return new TSHFileOpStruct();}
	}	

	public struct TSHFileInfo
	{
		public ulong hIcon;
		public int iIcon;
		public uint dwAttributes;
		public char[] szDisplayName;
		public char[] szTypeName;
		public static TSHFileInfo D2CCloneValue(TSHFileInfo value)
		{
			value.szDisplayName = DelphiStaticArrayInfo.Create<char>(new int[] { 0 }, new int[] { 260 }).Clone(value.szDisplayName);
			value.szTypeName = DelphiStaticArrayInfo.Create<char>(new int[] { 0 }, new int[] { 80 }).Clone(value.szTypeName);
			return value;
		}
		public void CreateRecordMembers()
		{
			szDisplayName = new char[260/*# range 0..259*/];
			szTypeName = new char[80/*# range 0..79*/];
		}
		public static TSHFileInfo CreateRecord()
		{
			TSHFileInfo tmp = new TSHFileInfo();
			tmp.CreateRecordMembers();
			return tmp;
		}
	}	

	public struct TSHNameMapping
	{
		public PChar pszOldPath;
		public PChar pszNewPath;
		public int cchOldPath;
		public int cchNewPath;
		public static TSHNameMapping CreateRecord(){return new TSHNameMapping();}
	}	

  // Preserve the existing declaration used by DelphiSudoku.

  // Window display modes (retained here for the original mock's users).
	public const int SW_HIDE = 0;
	public const int SW_SHOWNORMAL = 1;
	public const int SW_NORMAL = 1;
	public const int SW_SHOWMINIMIZED = 2;
	public const int SW_SHOWMAXIMIZED = 3;
	public const int SW_MAXIMIZE = 3;
	public const int SW_SHOWNOACTIVATE = 4;
	public const int SW_SHOW = 5;
	public const int SW_MINIMIZE = 6;
	public const int SW_SHOWMINNOACTIVE = 7;
	public const int SW_SHOWNA = 8;
	public const int SW_RESTORE = 9;
	public const int SW_SHOWDEFAULT = 10;
	public const int SW_FORCEMINIMIZE = 11;

  // ShellExecute error results (values <= 32 indicate failure).
	public const int SE_ERR_FNF = 2;
	public const int SE_ERR_PNF = 3;
	public const int SE_ERR_ACCESSDENIED = 5;
	public const int SE_ERR_OOM = 8;
	public const int SE_ERR_DLLNOTFOUND = 32;
	public const int SE_ERR_SHARE = 26;
	public const int SE_ERR_ASSOCINCOMPLETE = 27;
	public const int SE_ERR_DDETIMEOUT = 28;
	public const int SE_ERR_DDEFAIL = 29;
	public const int SE_ERR_DDEBUSY = 30;
	public const int SE_ERR_NOASSOC = 31;

  // ShellExecuteEx mask values.
	public const int SEE_MASK_CLASSNAME = 0x00000001;
	public const int SEE_MASK_CLASSKEY = 0x00000003;
	public const int SEE_MASK_IDLIST = 0x00000004;
	public const int SEE_MASK_INVOKEIDLIST = 0x0000000C;
	public const int SEE_MASK_ICON = 0x00000010;
	public const int SEE_MASK_HOTKEY = 0x00000020;
	public const int SEE_MASK_NOCLOSEPROCESS = 0x00000040;
	public const int SEE_MASK_CONNECTNETDRV = 0x00000080;
	public const int SEE_MASK_NOASYNC = 0x00000100;
	public const int SEE_MASK_FLAG_DDEWAIT = 0x00000100;
	public const int SEE_MASK_DOENVSUBST = 0x00000200;
	public const int SEE_MASK_FLAG_NO_UI = 0x00000400;
	public const int SEE_MASK_UNICODE = 0x00004000;
	public const int SEE_MASK_NO_CONSOLE = 0x00008000;
	public const int SEE_MASK_ASYNCOK = 0x00100000;
	public const int SEE_MASK_HMONITOR = 0x00200000;
	public const int SEE_MASK_NOZONECHECKS = 0x00800000;
	public const int SEE_MASK_WAITFORINPUTIDLE = 0x02000000;
	public const int SEE_MASK_FLAG_LOG_USAGE = 0x04000000;

  // SHFileOperation operation codes.
	public const int FO_MOVE = 0x0001;
	public const int FO_COPY = 0x0002;
	public const int FO_DELETE = 0x0003;
	public const int FO_RENAME = 0x0004;

  // SHFileOperation flags.
	public const int FOF_MULTIDESTFILES = 0x0001;
	public const int FOF_CONFIRMMOUSE = 0x0002;
	public const int FOF_SILENT = 0x0004;
	public const int FOF_RENAMEONCOLLISION = 0x0008;
	public const int FOF_NOCONFIRMATION = 0x0010;
	public const int FOF_WANTMAPPINGHANDLE = 0x0020;
	public const int FOF_ALLOWUNDO = 0x0040;
	public const int FOF_FILESONLY = 0x0080;
	public const int FOF_SIMPLEPROGRESS = 0x0100;
	public const int FOF_NOCONFIRMMKDIR = 0x0200;
	public const int FOF_NOERRORUI = 0x0400;
	public const int FOF_NOCOPYSECURITYATTRIBS = 0x0800;
	public const int FOF_NORECURSION = 0x1000;
	public const int FOF_NO_CONNECTED_ELEMENTS = 0x2000;
	public const int FOF_WANTNUKEWARNING = 0x4000;
	public const int FOF_NORECURSEREPARSE = 0x8000;

  // SHGetFileInfo flags.
	public const int SHGFI_ICON = 0x000000100;
	public const int SHGFI_DISPLAYNAME = 0x000000200;
	public const int SHGFI_TYPENAME = 0x000000400;
	public const int SHGFI_ATTRIBUTES = 0x000000800;
	public const int SHGFI_ICONLOCATION = 0x000001000;
	public const int SHGFI_EXETYPE = 0x000002000;
	public const int SHGFI_SYSICONINDEX = 0x000004000;
	public const int SHGFI_LINKOVERLAY = 0x000008000;
	public const int SHGFI_SELECTED = 0x000010000;
	public const int SHGFI_ATTR_SPECIFIED = 0x000020000;
	public const int SHGFI_LARGEICON = 0x000000000;
	public const int SHGFI_SMALLICON = 0x000000001;
	public const int SHGFI_OPENICON = 0x000000002;
	public const int SHGFI_SHELLICONSIZE = 0x000000004;
	public const int SHGFI_PIDL = 0x000000008;
	public const int SHGFI_USEFILEATTRIBUTES = 0x000000010;
	public const int SHGFI_ADDOVERLAYS = 0x000000020;
	public const int SHGFI_OVERLAYINDEX = 0x000000040;

  // Shell notification event flags (selected).
	public const int SHCNE_RENAMEITEM = 0x00000001;
	public const int SHCNE_CREATE = 0x00000002;
	public const int SHCNE_DELETE = 0x00000004;
	public const int SHCNE_MKDIR = 0x00000008;
	public const int SHCNE_RMDIR = 0x00000010;
	public const int SHCNE_MEDIAINSERTED = 0x00000020;
	public const int SHCNE_MEDIAREMOVED = 0x00000040;
	public const int SHCNE_DRIVEREMOVED = 0x00000080;
	public const int SHCNE_DRIVEADD = 0x00000100;
	public const int SHCNE_UPDATEDIR = 0x00001000;
	public const int SHCNE_UPDATEITEM = 0x00002000;
	public const int SHCNE_ASSOCCHANGED = 0x08000000;
	public const int SHCNE_ALLEVENTS = 0x7FFFFFFF;
	public const int SHCNF_IDLIST = 0x0000;
	public const int SHCNF_PATHA = 0x0001;
	public const int SHCNF_PRINTERA = 0x0002;
	public const int SHCNF_DWORD = 0x0003;
	public const int SHCNF_PATHW = 0x0005;
	public const int SHCNF_PRINTERW = 0x0006;
	public const int SHCNF_FLUSH = 0x1000;
	public const int SHCNF_FLUSHNOWAIT = 0x2000;
  // Do not assume binary-compatible native packing for these mock records.


  // Preserve the existing declaration used by DelphiSudoku.
	public static int ShellExecute(int hWnd, string Operation, PChar FileName, PChar Parameters, PChar Directory, int ShowCmd)
	{
		int result = 0;
		result = 0;
		return result;
	}

// Unicode-oriented declaration variants used by newer applications.
// These are stubs and intentionally contain no external imports.
	public static ulong ShellExecuteW(ulong hWnd, PChar Operation, PChar FileName, PChar Parameters, PChar Directory, int ShowCmd)
	{
		ulong result = 0 /*Native*/;
		result = 0;
		return result;
	}
	public static int ShellExecuteEx(ref TShellExecuteInfo ExecuteInfo)
	{
		int result = 0;
		result = 0/*#false*/;
		return result;
	}
	public static int SHFileOperation(ref TSHFileOpStruct FileOp)
	{
		int result = 0;
		result = 0;
		return result;
	}
	public static ulong SHGetFileInfo(PChar Path, uint FileAttributes, ref TSHFileInfo FileInfo, uint FileInfoSize, uint Flags)
	{
		ulong result = 0 /*Native*/;
		result = 0;
		return result;
	}
	public static void SHChangeNotify(int EventId, uint Flags, Pointer Item1, Pointer Item2)
	{
	}
	public static void SHFreeNameMappings(Pointer NameMappings)
	{
	}
	
} // class ShellapiInterface


file class ShellapiImplementation
{

} // class ShellapiImplementation

}  // namespace Shellapi

}  // namespace Winapi

