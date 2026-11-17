{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of Winapi.Messages.
  This file is independently written using publicly documented interfaces.
  It contains no Windows message processing or native layout guarantees.
  Message records are deliberately simplified for code translation.
  In particular, alternative/overlaid record fields and 64-bit filler
  fields of the native Delphi declarations are not reproduced.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit Winapi.Messages;

interface

uses
  Winapi.Windows,
  System.Types;

const
  WM_NULL = $0000;
  WM_CREATE = $0001;
  WM_DESTROY = $0002;
  WM_MOVE = $0003;
  WM_SIZE = $0005;
  WM_ACTIVATE = $0006;
  WM_SETFOCUS = $0007;
  WM_KILLFOCUS = $0008;
  WM_ENABLE = $000A;
  WM_SETREDRAW = $000B;
  WM_SETTEXT = $000C;
  WM_GETTEXT = $000D;
  WM_GETTEXTLENGTH = $000E;
  WM_PAINT = $000F;
  WM_CLOSE = $0010;
  WM_QUERYENDSESSION = $0011;
  WM_QUIT = $0012;
  WM_QUERYOPEN = $0013;
  WM_ERASEBKGND = $0014;
  WM_SYSCOLORCHANGE = $0015;
  WM_ENDSESSION = $0016;
  WM_SHOWWINDOW = $0018;
  WM_WININICHANGE = $001A;
  WM_SETTINGCHANGE = $001A;
  WM_DEVMODECHANGE = $001B;
  WM_ACTIVATEAPP = $001C;
  WM_FONTCHANGE = $001D;
  WM_TIMECHANGE = $001E;
  WM_CANCELMODE = $001F;
  WM_SETCURSOR = $0020;
  WM_MOUSEACTIVATE = $0021;
  WM_CHILDACTIVATE = $0022;
  WM_QUEUESYNC = $0023;
  WM_GETMINMAXINFO = $0024;
  WM_PAINTICON = $0026;
  WM_ICONERASEBKGND = $0027;
  WM_NEXTDLGCTL = $0028;
  WM_SPOOLERSTATUS = $002A;
  WM_DRAWITEM = $002B;
  WM_MEASUREITEM = $002C;
  WM_DELETEITEM = $002D;
  WM_VKEYTOITEM = $002E;
  WM_CHARTOITEM = $002F;
  WM_SETFONT = $0030;
  WM_GETFONT = $0031;
  WM_SETHOTKEY = $0032;
  WM_GETHOTKEY = $0033;
  WM_QUERYDRAGICON = $0037;
  WM_COMPAREITEM = $0039;
  WM_COMPACTING = $0041;
  WM_COMMNOTIFY = $0044;
  WM_WINDOWPOSCHANGING = $0046;
  WM_WINDOWPOSCHANGED = $0047;
  WM_POWER = $0048;
  WM_COPYDATA = $004A;
  WM_CANCELJOURNAL = $004B;
  WM_NOTIFY = $004E;
  WM_INPUTLANGCHANGEREQUEST = $0050;
  WM_INPUTLANGCHANGE = $0051;
  WM_TCARD = $0052;
  WM_HELP = $0053;
  WM_USERCHANGED = $0054;
  WM_NOTIFYFORMAT = $0055;
  WM_CONTEXTMENU = $007B;
  WM_STYLECHANGING = $007C;
  WM_STYLECHANGED = $007D;
  WM_DISPLAYCHANGE = $007E;
  WM_GETICON = $007F;
  WM_SETICON = $0080;
  WM_NCCREATE = $0081;
  WM_NCDESTROY = $0082;
  WM_NCCALCSIZE = $0083;
  WM_NCHITTEST = $0084;
  WM_NCPAINT = $0085;
  WM_NCACTIVATE = $0086;
  WM_GETDLGCODE = $0087;
  WM_SYNCPAINT = $0088;
  WM_NCMOUSEMOVE = $00A0;
  WM_NCLBUTTONDOWN = $00A1;
  WM_NCLBUTTONUP = $00A2;
  WM_NCLBUTTONDBLCLK = $00A3;
  WM_NCRBUTTONDOWN = $00A4;
  WM_NCRBUTTONUP = $00A5;
  WM_NCRBUTTONDBLCLK = $00A6;
  WM_KEYDOWN = $0100;
  WM_KEYUP = $0101;
  WM_CHAR = $0102;
  WM_DEADCHAR = $0103;
  WM_SYSKEYDOWN = $0104;
  WM_SYSKEYUP = $0105;
  WM_SYSCHAR = $0106;
  WM_SYSDEADCHAR = $0107;
  WM_UNICHAR = $0109;
  WM_IME_STARTCOMPOSITION = $010D;
  WM_IME_ENDCOMPOSITION = $010E;
  WM_IME_COMPOSITION = $010F;
  WM_INITDIALOG = $0110;
  WM_COMMAND = $0111;
  WM_SYSCOMMAND = $0112;
  WM_TIMER = $0113;
  WM_HSCROLL = $0114;
  WM_VSCROLL = $0115;
  WM_INITMENU = $0116;
  WM_INITMENUPOPUP = $0117;
  WM_MENUSELECT = $011F;
  WM_MENUCHAR = $0120;
  WM_ENTERIDLE = $0121;
  WM_MENURBUTTONUP = $0122;
  WM_MENUDRAG = $0123;
  WM_MENUGETOBJECT = $0124;
  WM_UNINITMENUPOPUP = $0125;
  WM_MENUCOMMAND = $0126;
  WM_CHANGEUISTATE = $0127;
  WM_UPDATEUISTATE = $0128;
  WM_QUERYUISTATE = $0129;
  WM_CTLCOLORMSGBOX = $0132;
  WM_CTLCOLOREDIT = $0133;
  WM_CTLCOLORLISTBOX = $0134;
  WM_CTLCOLORBTN = $0135;
  WM_CTLCOLORDLG = $0136;
  WM_CTLCOLORSCROLLBAR = $0137;
  WM_CTLCOLORSTATIC = $0138;
  WM_MOUSEMOVE = $0200;
  WM_LBUTTONDOWN = $0201;
  WM_LBUTTONUP = $0202;
  WM_LBUTTONDBLCLK = $0203;
  WM_RBUTTONDOWN = $0204;
  WM_RBUTTONUP = $0205;
  WM_RBUTTONDBLCLK = $0206;
  WM_MBUTTONDOWN = $0207;
  WM_MBUTTONUP = $0208;
  WM_MBUTTONDBLCLK = $0209;
  WM_MOUSEWHEEL = $020A;
  WM_XBUTTONDOWN = $020B;
  WM_XBUTTONUP = $020C;
  WM_XBUTTONDBLCLK = $020D;
  WM_MOUSEHWHEEL = $020E;
  WM_PARENTNOTIFY = $0210;
  WM_ENTERMENULOOP = $0211;
  WM_EXITMENULOOP = $0212;
  WM_NEXTMENU = $0213;
  WM_SIZING = $0214;
  WM_CAPTURECHANGED = $0215;
  WM_MOVING = $0216;
  WM_POWERBROADCAST = $0218;
  WM_DEVICECHANGE = $0219;
  WM_MDICREATE = $0220;
  WM_MDIDESTROY = $0221;
  WM_MDIACTIVATE = $0222;
  WM_MDIRESTORE = $0223;
  WM_MDINEXT = $0224;
  WM_MDIMAXIMIZE = $0225;
  WM_MDITILE = $0226;
  WM_MDICASCADE = $0227;
  WM_MDIICONARRANGE = $0228;
  WM_MDIGETACTIVE = $0229;
  WM_MDISETMENU = $0230;
  WM_DROPFILES = $0233;
  WM_MDIREFRESHMENU = $0234;
  WM_CUT = $0300;
  WM_COPY = $0301;
  WM_PASTE = $0302;
  WM_CLEAR = $0303;
  WM_UNDO = $0304;
  WM_RENDERFORMAT = $0305;
  WM_RENDERALLFORMATS = $0306;
  WM_DESTROYCLIPBOARD = $0307;
  WM_DRAWCLIPBOARD = $0308;
  WM_PAINTCLIPBOARD = $0309;
  WM_VSCROLLCLIPBOARD = $030A;
  WM_SIZECLIPBOARD = $030B;
  WM_ASKCBFORMATNAME = $030C;
  WM_CHANGECBCHAIN = $030D;
  WM_HSCROLLCLIPBOARD = $030E;
  WM_QUERYNEWPALETTE = $030F;
  WM_PALETTEISCHANGING = $0310;
  WM_PALETTECHANGED = $0311;
  WM_HOTKEY = $0312;
  WM_PRINT = $0317;
  WM_PRINTCLIENT = $0318;
  WM_APPCOMMAND = $0319;
  WM_THEMECHANGED = $031A;
  WM_DWMCOMPOSITIONCHANGED = $031E;
  WM_DWMNCRENDERINGCHANGED = $031F;
  WM_DWMCOLORIZATIONCOLORCHANGED = $0320;
  WM_DWMWINDOWMAXIMIZEDCHANGE = $0321;
  WM_USER = $0400;
  WM_APP = $8000;

  PM_REMOVE = $0001;
  MK_LBUTTON = $0001;
  MK_RBUTTON = $0002;
  MK_SHIFT = $0004;
  MK_CONTROL = $0008;
  MK_MBUTTON = $0010;
  MK_XBUTTON1 = $0020;
  MK_XBUTTON2 = $0040;

  SIZE_RESTORED = 0;
  SIZE_MINIMIZED = 1;
  SIZE_MAXIMIZED = 2;
  SIZE_MAXSHOW = 3;
  SIZE_MAXHIDE = 4;

type
  { Pointer and message records for WndProc and message methods. }
  PMessage = ^TMessage;
  TMessage = record
    Msg: Cardinal;
    WParam: WPARAM;
    LParam: LPARAM;
    Result: LRESULT;
  end;

  TWMNoParams = record
    Msg: Cardinal;
    WParam: WPARAM;
    LParam: LPARAM;
    Result: LRESULT;
  end;

  TWMEraseBkgnd = record
    Msg: Cardinal;
    DC: HDC;
    Unused: LPARAM;
    Result: LRESULT;
  end;
  TWMGetDlgCode = TWMNoParams;

  TWMKey = record
    Msg: Cardinal;
    CharCode: Word;
    Unused: Word;
    KeyData: Longint;
    Result: NativeInt;
  end;

  TWMChar = TWMKey;
  TWMKeyDown = TWMKey;
  TWMKeyUp = TWMKey;
  TWMSysKeyDown = TWMKey;
  TWMSysKeyUp = TWMKey;
  TWMSysChar = TWMKey;
  TWMDeadChar = TWMKey;
  TWMSysDeadChar = TWMKey;

  TWMCommand = record
    Msg: Cardinal;
    ItemID: Word;
    NotifyCode: Word;
    Ctl: HWND;
    Result: LRESULT;
  end;

  TWMNotify = record
    Msg: Cardinal;
    IDCtrl: WPARAM;
    NMHdr: PNMHdr;
    Result: LRESULT;
  end;

  TWMSize = record
    Msg: Cardinal;
    SizeType: WPARAM;
    Width: Word;
    Height: Word;
    Result: LRESULT;
  end;

  TWMMove = record
    Msg: Cardinal;
    Unused: WPARAM;
    XPos: Smallint;
    YPos: Smallint;
    Result: LRESULT;
  end;

  TWMMouse = record
    Msg: Cardinal;
    Keys: Longint;
    XPos: Smallint;
    YPos: Smallint;
    Pos: TSmallPoint;
    Result: LRESULT;
  end;

  TWMMouseWheel = record
    Msg: Cardinal;
    Keys: Smallint;
    WheelDelta: Smallint;
    XPos: Smallint;
    YPos: Smallint;
    Pos: TSmallPoint;
    Result: LRESULT;
  end;

  TWMLButtonDown = TWMMouse;
  TWMLButtonUp = TWMMouse;
  TWMLButtonDblClk = TWMMouse;
  TWMRButtonDown = TWMMouse;
  TWMRButtonUp = TWMMouse;
  TWMRButtonDblClk = TWMMouse;
  TWMMButtonDown = TWMMouse;
  TWMMButtonUp = TWMMouse;
  TWMMButtonDblClk = TWMMouse;
  TWMMouseMove = TWMMouse;

  TWMTimer = record
    Msg: Cardinal;
    TimerID: WPARAM;
    TimerProc: LPARAM;
    Result: LRESULT;
  end;

  TWMSetFocus = record
    Msg: Cardinal;
    FocusedWnd: HWND;
    Unused: LPARAM;
    Result: LRESULT;
  end;

  TWMKillFocus = TWMSetFocus;

  TWMActivate = record
    Msg: Cardinal;
    Active: Word;
    Minimized: Word;
    ActiveWindow: HWND;
    Result: LRESULT;
  end;

  TWMClose = TWMNoParams;
  TWMDestroy = TWMNoParams;
  TWMPaint = TWMNoParams;
  TWMCancelMode = TWMNoParams;
  TWMFontChange = TWMNoParams;
  TWMSysColorChange = TWMNoParams;
  TWMTimeChange = TWMNoParams;

  TWMEnable = record
    Msg: Cardinal;
    Enabled: WPARAM;
    Unused: LPARAM;
    Result: LRESULT;
  end;

  TWMShowWindow = record
    Msg: Cardinal;
    Show: WPARAM;
    Status: LPARAM;
    Result: LRESULT;
  end;

  TWMHScroll = record
    Msg: Cardinal;
    ScrollCode: Word;
    Pos: Word;
    ScrollBar: HWND;
    Result: LRESULT;
  end;

  TWMVScroll = TWMHScroll;

  TWMContextMenu = record
    Msg: Cardinal;
    HWND: HWND;
    XPos: Smallint;
    YPos: Smallint;
    Result: LRESULT;
  end;

  TWMSysCommand = record
    Msg: Cardinal;
    CmdType: WPARAM;
    Key: LPARAM;
    Result: LRESULT;
  end;

  { Stubs: no message is sent to the Windows message queue. }
  function SendTextMessage(Handle: HWND; Msg: UINT; WParam: WPARAM;
    LParam: UnicodeString): LRESULT;
  function SendStructMessage(Handle: HWND; Msg: UINT; WParam: WPARAM;
    const LParam): LRESULT;
  function SendGetStructMessage(Handle: HWND; Msg: UINT; WParam: WPARAM;
    var LParam; Unused: Boolean = False): LRESULT;
  function SendGetIntMessage(Handle: HWND; Msg: UINT;
    var WParam: Integer; var LParam: Integer): LRESULT;

implementation

function SendTextMessage(Handle: HWND; Msg: UINT; WParam: WPARAM;
  LParam: UnicodeString): LRESULT;
begin
  Result := 0;
end;

function SendStructMessage(Handle: HWND; Msg: UINT; WParam: WPARAM;
  const LParam): LRESULT;
begin
  Result := 0;
end;

function SendGetStructMessage(Handle: HWND; Msg: UINT; WParam: WPARAM;
  var LParam; Unused: Boolean): LRESULT;
begin
  Result := 0;
end;

function SendGetIntMessage(Handle: HWND; Msg: UINT;
  var WParam: Integer; var LParam: Integer): LRESULT;
begin
  Result := 0;
end;

end.
