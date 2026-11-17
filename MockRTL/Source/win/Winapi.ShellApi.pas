{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of selected Winapi.ShellApi declarations.
  This file is independently written for source translation.
  It does not call Windows and does not implement Shell API behavior.
  The records describe source-level members, not guaranteed native layouts.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit Winapi.ShellApi;

interface

const
  // Window display modes (retained here for the original mock's users).
  SW_HIDE = 0;
  SW_SHOWNORMAL = 1;
  SW_NORMAL = 1;
  SW_SHOWMINIMIZED = 2;
  SW_SHOWMAXIMIZED = 3;
  SW_MAXIMIZE = 3;
  SW_SHOWNOACTIVATE = 4;
  SW_SHOW = 5;
  SW_MINIMIZE = 6;
  SW_SHOWMINNOACTIVE = 7;
  SW_SHOWNA = 8;
  SW_RESTORE = 9;
  SW_SHOWDEFAULT = 10;
  SW_FORCEMINIMIZE = 11;

  // ShellExecute error results (values <= 32 indicate failure).
  SE_ERR_FNF = 2;
  SE_ERR_PNF = 3;
  SE_ERR_ACCESSDENIED = 5;
  SE_ERR_OOM = 8;
  SE_ERR_DLLNOTFOUND = 32;
  SE_ERR_SHARE = 26;
  SE_ERR_ASSOCINCOMPLETE = 27;
  SE_ERR_DDETIMEOUT = 28;
  SE_ERR_DDEFAIL = 29;
  SE_ERR_DDEBUSY = 30;
  SE_ERR_NOASSOC = 31;

  // ShellExecuteEx mask values.
  SEE_MASK_CLASSNAME = $00000001;
  SEE_MASK_CLASSKEY = $00000003;
  SEE_MASK_IDLIST = $00000004;
  SEE_MASK_INVOKEIDLIST = $0000000C;
  SEE_MASK_ICON = $00000010;
  SEE_MASK_HOTKEY = $00000020;
  SEE_MASK_NOCLOSEPROCESS = $00000040;
  SEE_MASK_CONNECTNETDRV = $00000080;
  SEE_MASK_NOASYNC = $00000100;
  SEE_MASK_FLAG_DDEWAIT = $00000100;
  SEE_MASK_DOENVSUBST = $00000200;
  SEE_MASK_FLAG_NO_UI = $00000400;
  SEE_MASK_UNICODE = $00004000;
  SEE_MASK_NO_CONSOLE = $00008000;
  SEE_MASK_ASYNCOK = $00100000;
  SEE_MASK_HMONITOR = $00200000;
  SEE_MASK_NOZONECHECKS = $00800000;
  SEE_MASK_WAITFORINPUTIDLE = $02000000;
  SEE_MASK_FLAG_LOG_USAGE = $04000000;

  // SHFileOperation operation codes.
  FO_MOVE = $0001;
  FO_COPY = $0002;
  FO_DELETE = $0003;
  FO_RENAME = $0004;

  // SHFileOperation flags.
  FOF_MULTIDESTFILES = $0001;
  FOF_CONFIRMMOUSE = $0002;
  FOF_SILENT = $0004;
  FOF_RENAMEONCOLLISION = $0008;
  FOF_NOCONFIRMATION = $0010;
  FOF_WANTMAPPINGHANDLE = $0020;
  FOF_ALLOWUNDO = $0040;
  FOF_FILESONLY = $0080;
  FOF_SIMPLEPROGRESS = $0100;
  FOF_NOCONFIRMMKDIR = $0200;
  FOF_NOERRORUI = $0400;
  FOF_NOCOPYSECURITYATTRIBS = $0800;
  FOF_NORECURSION = $1000;
  FOF_NO_CONNECTED_ELEMENTS = $2000;
  FOF_WANTNUKEWARNING = $4000;
  FOF_NORECURSEREPARSE = $8000;

  // SHGetFileInfo flags.
  SHGFI_ICON = $000000100;
  SHGFI_DISPLAYNAME = $000000200;
  SHGFI_TYPENAME = $000000400;
  SHGFI_ATTRIBUTES = $000000800;
  SHGFI_ICONLOCATION = $000001000;
  SHGFI_EXETYPE = $000002000;
  SHGFI_SYSICONINDEX = $000004000;
  SHGFI_LINKOVERLAY = $000008000;
  SHGFI_SELECTED = $000010000;
  SHGFI_ATTR_SPECIFIED = $000020000;
  SHGFI_LARGEICON = $000000000;
  SHGFI_SMALLICON = $000000001;
  SHGFI_OPENICON = $000000002;
  SHGFI_SHELLICONSIZE = $000000004;
  SHGFI_PIDL = $000000008;
  SHGFI_USEFILEATTRIBUTES = $000000010;
  SHGFI_ADDOVERLAYS = $000000020;
  SHGFI_OVERLAYINDEX = $000000040;

  // Shell notification event flags (selected).
  SHCNE_RENAMEITEM = $00000001;
  SHCNE_CREATE = $00000002;
  SHCNE_DELETE = $00000004;
  SHCNE_MKDIR = $00000008;
  SHCNE_RMDIR = $00000010;
  SHCNE_MEDIAINSERTED = $00000020;
  SHCNE_MEDIAREMOVED = $00000040;
  SHCNE_DRIVEREMOVED = $00000080;
  SHCNE_DRIVEADD = $00000100;
  SHCNE_UPDATEDIR = $00001000;
  SHCNE_UPDATEITEM = $00002000;
  SHCNE_ASSOCCHANGED = $08000000;
  SHCNE_ALLEVENTS = $7FFFFFFF;
  SHCNF_IDLIST = $0000;
  SHCNF_PATHA = $0001;
  SHCNF_PRINTERA = $0002;
  SHCNF_DWORD = $0003;
  SHCNF_PATHW = $0005;
  SHCNF_PRINTERW = $0006;
  SHCNF_FLUSH = $1000;
  SHCNF_FLUSHNOWAIT = $2000;

type
  // Do not assume binary-compatible native packing for these mock records.
  TShellExecuteInfo = record
    cbSize: Cardinal;
    fMask: Cardinal;
    Wnd: NativeUInt;
    lpVerb: PChar;
    lpFile: PChar;
    lpParameters: PChar;
    lpDirectory: PChar;
    nShow: Integer;
    hInstApp: NativeUInt;
    lpIDList: Pointer;
    lpClass: PChar;
    hkeyClass: NativeUInt;
    dwHotKey: Cardinal;
    hIcon: NativeUInt;
    hProcess: NativeUInt;
  end;
  PShellExecuteInfo = ^TShellExecuteInfo;

  TSHFileOpStruct = record
    Wnd: NativeUInt;
    wFunc: Cardinal;
    pFrom: PChar;
    pTo: PChar;
    fFlags: Word;
    fAnyOperationsAborted: LongBool;
    hNameMappings: Pointer;
    lpszProgressTitle: PChar;
  end;
  PSHFileOpStruct = ^TSHFileOpStruct;

  TSHFileInfo = record
    hIcon: NativeUInt;
    iIcon: Integer;
    dwAttributes: Cardinal;
    szDisplayName: array[0..259] of Char;
    szTypeName: array[0..79] of Char;
  end;
  PSHFileInfo = ^TSHFileInfo;

  TSHNameMapping = record
    pszOldPath: PChar;
    pszNewPath: PChar;
    cchOldPath: Integer;
    cchNewPath: Integer;
  end;
  PSHNameMapping = ^TSHNameMapping;

  // Preserve the existing declaration used by DelphiSudoku.
function ShellExecute(hWnd: Integer; Operation: string; FileName: PChar;
  Parameters: PChar; Directory: PChar; ShowCmd: Integer): Integer;

// Unicode-oriented declaration variants used by newer applications.
// These are stubs and intentionally contain no external imports.
function ShellExecuteW(hWnd: NativeUInt; Operation, FileName,
  Parameters, Directory: PWideChar; ShowCmd: Integer): NativeUInt;
function ShellExecuteEx(var ExecuteInfo: TShellExecuteInfo): LongBool;
function SHFileOperation(var FileOp: TSHFileOpStruct): Integer;
function SHGetFileInfo(Path: PChar; FileAttributes: Cardinal;
  var FileInfo: TSHFileInfo; FileInfoSize: Cardinal;
  Flags: Cardinal): NativeUInt;
procedure SHChangeNotify(EventId: Longint; Flags: Cardinal;
  Item1, Item2: Pointer);
procedure SHFreeNameMappings(NameMappings: Pointer);

implementation

function ShellExecute(hWnd: Integer; Operation: string; FileName: PChar;
  Parameters: PChar; Directory: PChar; ShowCmd: Integer): Integer;
begin
  Result := 0;
end;

function ShellExecuteW(hWnd: NativeUInt; Operation, FileName,
  Parameters, Directory: PWideChar; ShowCmd: Integer): NativeUInt;
begin
  Result := 0;
end;

function ShellExecuteEx(var ExecuteInfo: TShellExecuteInfo): LongBool;
begin
  Result := False;
end;

function SHFileOperation(var FileOp: TSHFileOpStruct): Integer;
begin
  Result := 0;
end;

function SHGetFileInfo(Path: PChar; FileAttributes: Cardinal;
  var FileInfo: TSHFileInfo; FileInfoSize: Cardinal;
  Flags: Cardinal): NativeUInt;
begin
  Result := 0;
end;

procedure SHChangeNotify(EventId: Longint; Flags: Cardinal;
  Item1, Item2: Pointer);
begin
end;

procedure SHFreeNameMappings(NameMappings: Pointer);
begin
end;

end.
