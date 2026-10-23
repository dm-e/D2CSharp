{
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.Classes functionality required by D2CSharp.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The routines below intentionally contain no RTL implementation. Functions
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
}

unit System.Classes;

interface

uses
  System.SysUtils;

const
  fmCreate = $FF00;
  MaxListSize = $07FFFFFF;

type
  TSeekOrigin = (soBeginning, soCurrent, soEnd);
  TStreamOwnership = (soReference, soOwned);

  TPersistent = class;
  TComponent = class;
  TStream = class;
  TStrings = class;
  TStringList = class;
  TList = class;

  TInterfacedPersistent = class(TPersistent, IInterface)
  protected
    function QueryInterface(const IID: TGUID; out Obj): HResult; virtual;
    function _AddRef: Integer; virtual;
    function _Release: Integer; virtual;
  end;

  TCollection = class;
  TCollectionItem = class;
  TFiler = class;
  TReader = class;
  TWriter = class;
  TBytesStream = class;
  TResourceStream = class;
  TThread = class;
  TThreadList = class;
  TStringsEnumerator = class;
  TStringReader = class;
  TStringWriter = class;
  TStreamReader = class;
  TStreamWriter = class;
  TRecall = class;
  TParser = class;
  TBasicAction = class;
  TBasicActionLink = class;
  TDataModule = class;
  TBits = class;
  TListEnumerator = class;
  TCollectionEnumerator = class;
  TComponentEnumerator = class;
  TInterfaceList = class;
  TInterfaceListEnumerator = class;
  TInterfacedPersistent = class;
  TOwnedCollection = class;
  TTextReader = class;
  TTextWriter = class;
  TTextReaderEnumerator = class;
  TBinaryReader = class;
  TBinaryWriter = class;
  TObservers = class;
  TObserverMapping = class;
  TLinkObservers = class;

  TNotifyEvent = procedure(Sender: TObject) of object;
  THelpEvent = function(Command: Word; Data: NativeInt;
    var CallHelp: Boolean): Boolean of object;

  TObserverToggleEvent = procedure(const AObserver: IInterface;
    const Value: Boolean) of object;

  IObserver = interface(IInterface)
    function GetActive: Boolean;
    function GetOnObserverToggle: TObserverToggleEvent;
    procedure SetActive(Value: Boolean);
    procedure SetOnObserverToggle(const Value: TObserverToggleEvent);
    property Active: Boolean read GetActive write SetActive;
    property OnObserverToggle: TObserverToggleEvent
      read GetOnObserverToggle write SetOnObserverToggle;
  end;

  IObserverTrack = interface(IInterface)
    function GetTrack: Boolean;
    property Track: Boolean read GetTrack;
  end;

  TCanObserveEvent = function(const ID: Integer): Boolean of object;
  TObserverAddedEvent = procedure(const ID: Integer;
    const Observer: IObserver) of object;
  TGetStrProc = procedure(const S: string) of object;
  TGetObjectProc = procedure(const S: string; AObject: TObject) of object;
  TReaderProc = procedure(Reader: TReader) of object;
  TWriterProc = procedure(Writer: TWriter) of object;
  TStreamProc = procedure(Stream: TStream) of object;
  TGetChildProc = procedure(Child: TComponent) of object;
  TListSortCompare = function(Item1, Item2: Pointer): Integer;
  TStringListSortCompare = function(List: TStringList;
    Index1, Index2: Integer): Integer;

  IInterfaceList = interface
    function GetCapacity: Integer;
    function GetCount: Integer;
    function GetItem(Index: Integer): IInterface;
    procedure SetCapacity(NewCapacity: Integer);
    procedure SetItem(Index: Integer; const Item: IInterface);
    function Add(const Item: IInterface): Integer;
    procedure Clear;
    procedure Delete(Index: Integer);
    procedure Exchange(Index1, Index2: Integer);
    function First: IInterface;
    function IndexOf(const Item: IInterface): Integer;
    procedure Insert(Index: Integer; const Item: IInterface);
    function Last: IInterface;
    function Remove(const Item: IInterface): Integer;
    property Capacity: Integer read GetCapacity write SetCapacity;
    property Count: Integer read GetCount;
    property Items[Index: Integer]: IInterface read GetItem write SetItem; default;
  end;

  IInterfaceListEx = interface(IInterfaceList)
    function GetEnumerator: TInterfaceListEnumerator;
  end;

  TPersistentClass = class of TPersistent;
  TComponentClass = class of TComponent;
  TCollectionItemClass = class of TCollectionItem;

  TComponentStateItem = (
    csLoading,
    csReading,
    csWriting,
    csDestroying,
    csDesigning,
    csAncestor,
    csUpdating,
    csFixups,
    csFreeNotification,
    csInline,
    csDesignInstance
  );
  TComponentState = set of TComponentStateItem;

  TComponentStyleItem = (
    csInheritable,
    csCheckPropAvail,
    csSubComponent,
    csTransient
  );
  TComponentStyle = set of TComponentStyleItem;

  TOperation = (opInsert, opRemove);

  TStringsDefinedItem = (
    sdDelimiter,
    sdQuoteChar,
    sdNameValueSeparator,
    sdLineBreak,
    sdStrictDelimiter
  );
  TStringsDefined = set of TStringsDefinedItem;

  TDuplicates = (dupIgnore, dupAccept, dupError);

  TListNotification = (lnAdded, lnExtracted, lnDeleted);

  TCollectionNotification = (
    cnAdded,
    cnExtracting,
    cnRemoved
  );

  TAlignment = (taLeftJustify, taRightJustify, taCenter);

  TToken = (
    toEOF,
    toSymbol,
    toString,
    toInteger,
    toFloat,
    toWString
  );

  TList = class(TObject)
  private
    FList: array of Pointer;
    FCount: Integer;
    FCapacity: Integer;
    function Get(Index: Integer): Pointer;
    procedure Put(Index: Integer; Item: Pointer);
    procedure SetCapacity(NewCapacity: Integer);
    procedure SetCount(NewCount: Integer);
  protected
    procedure Notify(Ptr: Pointer; Action: TListNotification); virtual;
  public
    destructor Destroy; override;
    function Add(Item: Pointer): Integer;
    procedure Clear; virtual;
    procedure Delete(Index: Integer);
    class procedure Error(const Msg: string; Data: NativeInt); overload;
    class procedure Error(Msg: PResStringRec; Data: NativeInt); overload;
    procedure Exchange(Index1, Index2: Integer);
    function Extract(Item: Pointer): Pointer;
    function First: Pointer;
    function IndexOf(Item: Pointer): Integer;
    procedure Insert(Index: Integer; Item: Pointer);
    function Last: Pointer;
    function GetEnumerator: TListEnumerator;
    procedure Move(CurIndex, NewIndex: Integer);
    procedure Pack;
    function Remove(Item: Pointer): Integer;
    procedure Sort(Compare: TListSortCompare);
    property Capacity: Integer read FCapacity write SetCapacity;
    property Count: Integer read FCount write SetCount;
    property Items[Index: Integer]: Pointer read Get write Put; default;
  end;


  TListEnumerator = class(TObject)
  private
    FList: TList;
    FIndex: Integer;
    function GetCurrent: Pointer;
  public
    constructor Create(AList: TList);
    function MoveNext: Boolean;
    property Current: Pointer read GetCurrent;
  end;

  TBits = class(TObject)
  private
    FSize: Integer;
    function GetBit(Index: Integer): Boolean;
    procedure SetBit(Index: Integer; Value: Boolean);
    procedure SetSize(Value: Integer);
  public
    function OpenBit: Integer;
    property Bits[Index: Integer]: Boolean read GetBit write SetBit; default;
    property Size: Integer read FSize write SetSize;
  end;

  TInterfaceList = class(TInterfacedObject, IInterfaceList, IInterfaceListEx)
  private
    FItems: array of IInterface;
    FCount: Integer;
    FCapacity: Integer;
    function GetCapacity: Integer;
    function GetCount: Integer;
    function GetItem(Index: Integer): IInterface;
    procedure SetCapacity(NewCapacity: Integer);
    procedure SetItem(Index: Integer; const Item: IInterface);
  public
    function Add(const Item: IInterface): Integer;
    procedure Clear;
    procedure Delete(Index: Integer);
    procedure Exchange(Index1, Index2: Integer);
    function Expand: TInterfaceList;
    function First: IInterface;
    function GetEnumerator: TInterfaceListEnumerator;
    function IndexOf(const Item: IInterface): Integer;
    procedure Insert(Index: Integer; const Item: IInterface);
    function Last: IInterface;
    function Remove(const Item: IInterface): Integer;
    procedure Lock;
    procedure Unlock;
    property Capacity: Integer read GetCapacity write SetCapacity;
    property Count: Integer read GetCount;
    property Items[Index: Integer]: IInterface read GetItem write SetItem; default;
  end;

  TInterfaceListEnumerator = class(TObject)
  private
    FList: TInterfaceList;
    FIndex: Integer;
    function GetCurrent: IInterface;
  public
    constructor Create(AList: TInterfaceList);
    function MoveNext: Boolean;
    property Current: IInterface read GetCurrent;
  end;


  TObservers = class(TObject)
  private
    FOnCanObserve: TCanObserveEvent;
    FOnObserverAdded: TObserverAddedEvent;
  public
    constructor Create;
    destructor Destroy; override;
    procedure AddObserver(const ID: Integer;
      const AIntf: IInterface); overload; virtual;
    procedure AddObserver(const IDs: array of Integer;
      const AIntf: IInterface); overload; virtual;
    function CanObserve(const ID: Integer): Boolean; overload; virtual;
    function IsObserving(const ID: Integer): Boolean; overload; virtual;
    procedure RemoveObserver(const ID: Integer;
      const AIntf: IInterface); virtual;
    function TryIsObserving(const ID: Integer;
      out AIntf: IInterface): Boolean; virtual;
    property OnCanObserve: TCanObserveEvent
      read FOnCanObserve write FOnCanObserve;
    property OnObserverAdded: TObserverAddedEvent
      read FOnObserverAdded write FOnObserverAdded;
  end;

  TObserverMapping = class(TObject)
  protected
    class function Instance: TObserverMapping; static;
  public
    constructor Create;
    destructor Destroy; override;
    class procedure Clear; static;
    class procedure EnableObservers(AClass: TClass); static;
    class procedure DisableObservers(AClass: TClass); static;
  end;

  TLinkObservers = class(TObject)
  public
    class function IsObserving(const AObservers: TObservers;
      const ID: Integer): Boolean; static;
  end;

  TPersistent = class(TObject)
  protected
    procedure AssignError(Source: TPersistent);
    procedure AssignTo(Dest: TPersistent); virtual;
  public
    procedure Assign(Source: TPersistent); virtual;
    function GetNamePath: string; virtual;
  end;

  TCollection = class;

  TCollectionItem = class(TPersistent)
  private
    FCollection: TCollection;
    FID: Integer;
    function GetIndex: Integer;
    procedure SetCollection(Value: TCollection);
    procedure SetIndex(Value: Integer);
  protected
    function GetDisplayName: string; virtual;
    procedure SetDisplayName(const Value: string); virtual;
    procedure SetItemName; virtual;
  public
    constructor Create(Collection: TCollection); virtual;
    destructor Destroy; override;
    property Collection: TCollection read FCollection write SetCollection;
    property ID: Integer read FID;
    property Index: Integer read GetIndex write SetIndex;
    property DisplayName: string read GetDisplayName write SetDisplayName;
  end;

  TCollection = class(TPersistent)
  private
    FItemClass: TCollectionItemClass;
    function GetCount: Integer;
    function GetItem(Index: Integer): TCollectionItem;
    procedure SetItem(Index: Integer; Value: TCollectionItem);
  protected
    function Add: TCollectionItem;
    procedure Added(var Item: TCollectionItem); virtual;
    procedure Deleting(Item: TCollectionItem); virtual;
    function GetItemClass: TCollectionItemClass; virtual;
    function GetItemName: string; virtual;
    function GetOwner: TPersistent; virtual;
    procedure Notify(Item: TCollectionItem;
      Action: TCollectionNotification); virtual;
    procedure PropertyNameChanged; virtual;
    procedure SetItemName(Item: TCollectionItem); virtual;
    procedure Update(Item: TCollectionItem); virtual;
  public
    constructor Create(ItemClass: TCollectionItemClass);
    destructor Destroy; override;
    procedure Assign(Source: TPersistent); override;
    procedure BeginUpdate;
    procedure Clear;
    procedure Delete(Index: Integer);
    procedure EndUpdate;
    function FindItemID(ID: Integer): TCollectionItem;
    function GetEnumerator: TCollectionEnumerator;
    function GetItemID: Integer;
    function Insert(Index: Integer): TCollectionItem;
    function Owner: TPersistent;
    property Count: Integer read GetCount;
    property ItemClass: TCollectionItemClass read FItemClass;
    property Items[Index: Integer]: TCollectionItem read GetItem write SetItem;
  end;


  TCollectionEnumerator = class(TObject)
  private
    FCollection: TCollection;
    FIndex: Integer;
    function GetCurrent: TCollectionItem;
  public
    constructor Create(ACollection: TCollection);
    function MoveNext: Boolean;
    property Current: TCollectionItem read GetCurrent;
  end;

  TOwnedCollection = class(TCollection)
  private
    FOwner: TPersistent;
  protected
    function GetOwner: TPersistent; override;
  public
    constructor Create(AOwner: TPersistent; ItemClass: TCollectionItemClass);
  end;

  TStrings = class(TPersistent)
  private
    FDelimiter: Char;
    FQuoteChar: Char;
    FNameValueSeparator: Char;
    FLineBreak: string;
    FStrictDelimiter: Boolean;
    FUpdateCount: Integer;
    function GetCommaText: string;
    function GetDelimitedText: string;
    function GetName(Index: Integer): string;
    function GetValue(const Name: string): string;
    function GetValueFromIndex(Index: Integer): string;
    function GetTextStr: string;
    procedure SetCommaText(const Value: string);
    procedure SetDelimitedText(const Value: string);
    procedure SetValue(const Name, Value: string);
    procedure SetValueFromIndex(Index: Integer; const Value: string);
    procedure SetTextStr(const Value: string);
  protected
    procedure DefineProperties(Filer: TFiler); virtual;
    procedure Error(const Msg: string; Data: Integer);
    function Get(Index: Integer): string; virtual; abstract;
    function GetCapacity: Integer; virtual;
    function GetCount: Integer; virtual; abstract;
    function GetObject(Index: Integer): TObject; virtual;
    function GetText: PChar; virtual;
    procedure Put(Index: Integer; const S: string); virtual;
    procedure PutObject(Index: Integer; AObject: TObject); virtual;
    procedure SetCapacity(NewCapacity: Integer); virtual;
    procedure SetUpdateState(Updating: Boolean); virtual;
  public
    destructor Destroy; override;
    function Add(const S: string): Integer; virtual;
    function AddObject(const S: string; AObject: TObject): Integer; virtual;
    procedure AddStrings(Strings: TStrings); overload; virtual;
    procedure AddStrings(const Strings: array of string); overload; virtual;
    procedure Append(const S: string);
    procedure Assign(Source: TPersistent); override;
    procedure BeginUpdate;
    procedure Clear; virtual; abstract;
    procedure Delete(Index: Integer); virtual; abstract;
    procedure EndUpdate;
    function Equals(Strings: TStrings): Boolean; reintroduce;
    procedure Exchange(Index1, Index2: Integer); virtual;
    function IndexOf(const S: string): Integer; virtual;
    function IndexOfName(const Name: string): Integer;
    function IndexOfObject(AObject: TObject): Integer;
    procedure Insert(Index: Integer; const S: string); virtual; abstract;
    procedure InsertObject(Index: Integer; const S: string;
      AObject: TObject); virtual;
    procedure LoadFromFile(const FileName: string); overload; virtual;
    procedure LoadFromFile(const FileName: string;
      Encoding: TEncoding); overload; virtual;
    procedure LoadFromStream(Stream: TStream); overload; virtual;
    procedure LoadFromStream(Stream: TStream;
      Encoding: TEncoding); overload; virtual;
    procedure Move(CurIndex, NewIndex: Integer); virtual;
    procedure SaveToFile(const FileName: string); overload; virtual;
    procedure SaveToFile(const FileName: string;
      Encoding: TEncoding); overload; virtual;
    procedure SaveToStream(Stream: TStream); overload; virtual;
    procedure SaveToStream(Stream: TStream;
      Encoding: TEncoding); overload; virtual;
    procedure SetText(Text: PChar); virtual;
    property Capacity: Integer read GetCapacity write SetCapacity;
    property CommaText: string read GetCommaText write SetCommaText;
    property Count: Integer read GetCount;
    property Delimiter: Char read FDelimiter write FDelimiter;
    property DelimitedText: string read GetDelimitedText write SetDelimitedText;
    property LineBreak: string read FLineBreak write FLineBreak;
    property Names[Index: Integer]: string read GetName;
    property NameValueSeparator: Char read FNameValueSeparator
      write FNameValueSeparator;
    property Objects[Index: Integer]: TObject read GetObject write PutObject;
    property QuoteChar: Char read FQuoteChar write FQuoteChar;
    property StrictDelimiter: Boolean read FStrictDelimiter
      write FStrictDelimiter;
    property Strings[Index: Integer]: string read Get write Put; default;
    property Text: string read GetTextStr write SetTextStr;
    property ValueFromIndex[Index: Integer]: string read GetValueFromIndex
      write SetValueFromIndex;
    property Values[const Name: string]: string read GetValue write SetValue;
  end;

  TStringList = class(TStrings)
  private
    FCaseSensitive: Boolean;
    FDuplicates: TDuplicates;
    FOwnsObjects: Boolean;
    FSorted: Boolean;
    FOnChange: TNotifyEvent;
    FOnChanging: TNotifyEvent;
  protected
    procedure Changed; virtual;
    procedure Changing; virtual;
    function CompareStrings(const S1, S2: string): Integer; virtual;
    function Get(Index: Integer): string; override;
    function GetCapacity: Integer; override;
    function GetCount: Integer; override;
    function GetObject(Index: Integer): TObject; override;
    procedure Put(Index: Integer; const S: string); override;
    procedure PutObject(Index: Integer; AObject: TObject); override;
    procedure SetCapacity(NewCapacity: Integer); override;
    procedure SetUpdateState(Updating: Boolean); override;
  public
    constructor Create; overload;
    constructor Create(OwnsObjects: Boolean); overload;
    destructor Destroy; override;
    function Add(const S: string): Integer; override;
    procedure Clear; override;
    procedure Delete(Index: Integer); override;
    procedure Exchange(Index1, Index2: Integer); override;
    function Find(const S: string; var Index: Integer): Boolean; virtual;
    function IndexOf(const S: string): Integer; override;
    procedure Insert(Index: Integer; const S: string); override;
    procedure Sort; virtual;
    procedure CustomSort(Compare: TStringListSortCompare); virtual;
    property CaseSensitive: Boolean read FCaseSensitive write FCaseSensitive;
    property Duplicates: TDuplicates read FDuplicates write FDuplicates;
    property OwnsObjects: Boolean read FOwnsObjects write FOwnsObjects;
    property Sorted: Boolean read FSorted write FSorted;
    property OnChange: TNotifyEvent read FOnChange write FOnChange;
    property OnChanging: TNotifyEvent read FOnChanging write FOnChanging;
  end;

  TStream = class(TObject)
  private
    function GetPosition: Int64;
    procedure SetPosition(const Pos: Int64);
    function GetSize: Int64;
    procedure SetSize64(const NewSize: Int64);
  protected
    procedure SetSize(NewSize: Longint); overload; virtual;
    procedure SetSize(const NewSize: Int64); overload; virtual;
  public
    function Read(var Buffer; Count: Longint): Longint; virtual; abstract;
    function Write(const Buffer; Count: Longint): Longint; virtual; abstract;
    function Seek(Offset: Longint; Origin: Word): Longint; overload; virtual;
    function Seek(const Offset: Int64; Origin: TSeekOrigin): Int64; overload; virtual;
    procedure ReadBuffer(var Buffer; Count: Longint);
    procedure WriteBuffer(const Buffer; Count: Longint);
    function CopyFrom(Source: TStream; Count: Int64): Int64;
    function ReadByte: Byte;
    procedure WriteByte(Value: Byte);
    property Position: Int64 read GetPosition write SetPosition;
    property Size: Int64 read GetSize write SetSize64;
  end;

  THandleStream = class(TStream)
  private
    FHandle: THandle;
  public
    constructor Create(AHandle: THandle);
    function Read(var Buffer; Count: Longint): Longint; override;
    function Write(const Buffer; Count: Longint): Longint; override;
    function Seek(const Offset: Int64; Origin: TSeekOrigin): Int64; override;
    property Handle: THandle read FHandle;
  end;

  TFileStream = class(THandleStream)
  private
    FFileName: string;
  public
    constructor Create(const FileName: string; Mode: Word); overload;
    constructor Create(const FileName: string; Mode: Word;
      Rights: Cardinal); overload;
    property FileName: string read FFileName;
  end;

  TCustomMemoryStream = class(TStream)
  private
    FMemory: Pointer;
    FSize: Int64;
    FPosition: Int64;
  protected
    procedure SetPointer(Ptr: Pointer; Size: NativeInt);
  public
    function Read(var Buffer; Count: Longint): Longint; override;
    function Seek(const Offset: Int64; Origin: TSeekOrigin): Int64; override;
    procedure SaveToStream(Stream: TStream);
    procedure SaveToFile(const FileName: string);
    property Memory: Pointer read FMemory;
  end;

  TMemoryStream = class(TCustomMemoryStream)
  private
    FCapacity: NativeInt;
    procedure SetCapacity(NewCapacity: NativeInt);
  protected
    function Realloc(var NewCapacity: NativeInt): Pointer; virtual;
    procedure SetSize(const NewSize: Int64); override;
  public
    destructor Destroy; override;
    procedure Clear;
    procedure LoadFromStream(Stream: TStream);
    procedure LoadFromFile(const FileName: string);
    function Write(const Buffer; Count: Longint): Longint; override;
    property Capacity: NativeInt read FCapacity write SetCapacity;
  end;

  TStringStream = class(TStream)
  private
    FDataString: string;
    FPosition: Int64;
    FEncoding: TEncoding;
  protected
    procedure SetSize(const NewSize: Int64); override;
  public
    constructor Create(const AString: string); overload;
    constructor Create(const AString: string; AEncoding: TEncoding); overload;
    destructor Destroy; override;
    function Read(var Buffer; Count: Longint): Longint; override;
    function Write(const Buffer; Count: Longint): Longint; override;
    function Seek(const Offset: Int64; Origin: TSeekOrigin): Int64; override;
    function ReadString(Count: Integer): string;
    procedure WriteString(const AString: string);
    property DataString: string read FDataString;
    property Encoding: TEncoding read FEncoding;
  end;


  TBytesStream = class(TMemoryStream)
  private
    FBytes: TBytes;
  protected
    function Realloc(var NewCapacity: NativeInt): Pointer; override;
  public
    constructor Create(const ABytes: TBytes);
    property Bytes: TBytes read FBytes;
  end;

  TResourceStream = class(TCustomMemoryStream)
  public
    constructor Create(Instance: THandle; const ResName: string;
      ResType: PChar); overload;
    constructor CreateFromID(Instance: THandle; ResID: Integer;
      ResType: PChar);
    destructor Destroy; override;
    function Write(const Buffer; Count: Longint): Longint; override;
  end;

  TThread = class(TObject)
  private
    FFreeOnTerminate: Boolean;
    FFinished: Boolean;
    FTerminated: Boolean;
  protected
    procedure Execute; virtual; abstract;
  public
    constructor Create(CreateSuspended: Boolean);
    destructor Destroy; override;
    procedure Start;
    procedure Resume;
    procedure Suspend;
    procedure Terminate;
    function WaitFor: Cardinal;
    property Finished: Boolean read FFinished;
    property FreeOnTerminate: Boolean read FFreeOnTerminate write FFreeOnTerminate;
    property Terminated: Boolean read FTerminated;
  end;

  TThreadList = class(TObject)
  private
    FList: TList;
    FDuplicates: TDuplicates;
  public
    constructor Create;
    destructor Destroy; override;
    procedure Add(Item: Pointer);
    procedure Clear;
    function LockList: TList;
    procedure Remove(Item: Pointer);
    procedure UnlockList;
    property Duplicates: TDuplicates read FDuplicates write FDuplicates;
  end;

  TStringsEnumerator = class(TObject)
  private
    FStrings: TStrings;
    FIndex: Integer;
    function GetCurrent: string;
  public
    constructor Create(AStrings: TStrings);
    function MoveNext: Boolean;
    property Current: string read GetCurrent;
  end;

  TStringReader = class(TObject)
  private
    FData: string;
    FPosition: Integer;
  public
    constructor Create(const AString: string);
    function Peek: Integer;
    function Read: Integer; overload;
    function Read(var Buffer: array of Char; Index, Count: Integer): Integer; overload;
    function ReadLine: string;
    function ReadToEnd: string;
  end;

  TStringWriter = class(TObject)
  private
    FBuilder: System.SysUtils.TStringBuilder;
  public
    constructor Create; overload;
    constructor Create(ABuilder: System.SysUtils.TStringBuilder); overload;
    procedure Write(const Value: string); overload;
    procedure Write(Value: Char); overload;
    procedure WriteLine; overload;
    procedure WriteLine(const Value: string); overload;
    function ToString: string; override;
    property Builder: System.SysUtils.TStringBuilder read FBuilder;
  end;

  TStreamReader = class(TObject)
  private
    FStream: TStream;
    FEncoding: TEncoding;
    FOwnsStream: Boolean;
    function GetEndOfStream: Boolean;
  public
    constructor Create(Stream: TStream); overload;
    constructor Create(Stream: TStream; Encoding: TEncoding;
      DetectBOM: Boolean = True; BufferSize: Integer = 1024); overload;
    constructor Create(const Filename: string); overload;
    constructor Create(const Filename: string; Encoding: TEncoding;
      DetectBOM: Boolean = True; BufferSize: Integer = 1024); overload;
    destructor Destroy; override;
    procedure Close;
    function Peek: Integer;
    function Read: Integer; overload;
    function Read(var Buffer: array of Char; Index, Count: Integer): Integer; overload;
    function ReadBlock(var Buffer: array of Char; Index, Count: Integer): Integer;
    function ReadLine: string;
    function ReadToEnd: string;
    property BaseStream: TStream read FStream;
    property CurrentEncoding: TEncoding read FEncoding;
    property EndOfStream: Boolean read GetEndOfStream;
  end;

  TStreamWriter = class(TObject)
  private
    FStream: TStream;
    FEncoding: TEncoding;
    FOwnsStream: Boolean;
    FAutoFlush: Boolean;
    FNewLine: string;
  public
    constructor Create(Stream: TStream); overload;
    constructor Create(Stream: TStream; Encoding: TEncoding;
      BufferSize: Integer = 1024); overload;
    constructor Create(const Filename: string; Append: Boolean = False); overload;
    constructor Create(const Filename: string; Append: Boolean;
      Encoding: TEncoding; BufferSize: Integer = 1024); overload;
    destructor Destroy; override;
    procedure Close;
    procedure Flush;
    procedure Write(const Value: string); overload;
    procedure Write(Value: Char); overload;
    procedure WriteLine; overload;
    procedure WriteLine(const Value: string); overload;
    property AutoFlush: Boolean read FAutoFlush write FAutoFlush;
    property BaseStream: TStream read FStream;
    property Encoding: TEncoding read FEncoding;
    property NewLine: string read FNewLine write FNewLine;
  end;

  TRecall = class(TObject)
  private
    FStorage: TPersistent;
    FReference: TPersistent;
  public
    constructor Create(AStorage, AReference: TPersistent);
    destructor Destroy; override;
    procedure Forget;
    procedure Store;
    property Reference: TPersistent read FReference;
  end;

  TParser = class(TObject)
  private
    FStream: TStream;
    FToken: TToken;
  public
    constructor Create(Stream: TStream);
    procedure CheckToken(T: TToken);
    procedure CheckTokenSymbol(const S: string);
    procedure Error(const Ident: string);
    procedure ErrorFmt(const Ident: string; const Args: array of const);
    function NextToken: TToken;
    function SourceLine: Integer;
    function TokenComponentIdent: string;
    function TokenFloat: Extended;
    function TokenInt: Int64;
    function TokenString: string;
    function TokenSymbolIs(const S: string): Boolean;
    function TokenWideString: WideString;
    property Token: TToken read FToken;
  end;

  TBasicActionLink = class(TObject)
  private
    FAction: TBasicAction;
    FClient: TObject;
  protected
    procedure AssignClient(AClient: TObject); virtual;
    function IsGroupIndexLinked: Boolean; virtual;
    function IsOnExecuteLinked: Boolean; virtual;
    procedure SetGroupIndex(Value: Integer); virtual;
    procedure SetOnExecute(Value: TNotifyEvent); virtual;
  public
    constructor Create(AClient: TObject); virtual;
    destructor Destroy; override;
    procedure Assign(Source: TObject); virtual;
    function Execute(AClient: TObject = nil): Boolean; virtual;
    function Update: Boolean; virtual;
    property Action: TBasicAction read FAction write FAction;
    property Client: TObject read FClient;
  end;


  TTextReader = class(TObject)
  public
    function Peek: Integer; virtual; abstract;
    function Read: Integer; overload; virtual; abstract;
    function Read(var Buffer: array of Char; Index, Count: Integer): Integer; overload; virtual;
    function ReadBlock(var Buffer: array of Char; Index, Count: Integer): Integer; virtual;
    function ReadLine: string; virtual;
    function ReadToEnd: string; virtual;
    function GetEnumerator: TTextReaderEnumerator;
  end;

  TTextReaderEnumerator = class(TObject)
  private
    FReader: TTextReader;
    FCurrent: string;
  public
    constructor Create(AReader: TTextReader);
    function MoveNext: Boolean;
    property Current: string read FCurrent;
  end;

  TTextWriter = class(TObject)
  private
    FNewLine: string;
  public
    constructor Create;
    procedure Close; virtual;
    procedure Flush; virtual;
    procedure Write(Value: Boolean); overload; virtual;
    procedure Write(Value: Char); overload; virtual;
    procedure Write(Value: Integer); overload; virtual;
    procedure Write(Value: Int64); overload; virtual;
    procedure Write(Value: Single); overload; virtual;
    procedure Write(Value: Double); overload; virtual;
    procedure Write(const Value: string); overload; virtual;
    procedure WriteLine; overload; virtual;
    procedure WriteLine(const Value: string); overload; virtual;
    property NewLine: string read FNewLine write FNewLine;
  end;

  TBinaryReader = class(TObject)
  private
    FStream: TStream;
    FEncoding: TEncoding;
    FOwnsStream: Boolean;
  public
    constructor Create(Stream: TStream; AEncoding: TEncoding = nil;
      AOwnsStream: Boolean = False); overload;
    constructor Create(const Filename: string;
      Encoding: TEncoding = nil); overload;
    destructor Destroy; override;
    procedure Close; virtual;
    function ReadBoolean: Boolean; virtual;
    function ReadByte: Byte; virtual;
    function ReadBytes(Count: Integer): TBytes; virtual;
    function ReadChar: Char; virtual;
    function ReadChars(Count: Integer): TCharArray; virtual;
    function ReadDouble: Double; virtual;
    function ReadInteger: Integer; virtual;
    function ReadInt64: Int64; virtual;
    function ReadShortInt: ShortInt; virtual;
    function ReadSingle: Single; virtual;
    function ReadSmallInt: SmallInt; virtual;
    function ReadString: string; virtual;
    function ReadUInt64: UInt64; virtual;
    function ReadWord: Word; virtual;
    function ReadCardinal: Cardinal; virtual;
    property BaseStream: TStream read FStream;
  end;

  TBinaryWriter = class(TObject)
  private
    FStream: TStream;
    FEncoding: TEncoding;
    FOwnsStream: Boolean;
  public
    constructor Create; overload;
    constructor Create(Stream: TStream); overload;
    constructor Create(Stream: TStream; Encoding: TEncoding); overload;
    constructor Create(Stream: TStream; Encoding: TEncoding;
      AOwnsStream: Boolean); overload;
    constructor Create(const Filename: string;
      Append: Boolean = False); overload;
    constructor Create(const Filename: string; Append: Boolean;
      Encoding: TEncoding); overload;
    destructor Destroy; override;
    procedure Close; virtual;
    procedure Flush; virtual;
    procedure Seek(Offset: Integer; Origin: TSeekOrigin); virtual;
    procedure Write(Value: Byte); overload; virtual;
    procedure Write(Value: Boolean); overload; virtual;
    procedure Write(Value: Char); overload; virtual;
    procedure Write(const Value: TCharArray); overload; virtual;
    procedure Write(const Value: TBytes); overload; virtual;
    procedure Write(Value: Double); overload; virtual;
    procedure Write(Value: Integer); overload; virtual;
    procedure Write(Value: SmallInt); overload; virtual;
    procedure Write(Value: ShortInt); overload; virtual;
    procedure Write(Value: Word); overload; virtual;
    procedure Write(Value: Cardinal); overload; virtual;
    procedure Write(Value: Int64); overload; virtual;
    procedure Write(Value: Single); overload; virtual;
    procedure Write(const Value: string); overload; virtual;
    procedure Write(Value: UInt64); overload; virtual;
    procedure Write(const Value: TCharArray; Index, Count: Integer); overload; virtual;
    procedure Write(const Value: TBytes; Index, Count: Integer); overload; virtual;
    property BaseStream: TStream read FStream;
  end;

  TFiler = class(TObject)
  private
    FRoot: TComponent;
  protected
    procedure DefineProperty(const Name: string;
      ReadData: TReaderProc; WriteData: TWriterProc; HasData: Boolean); overload;
    procedure DefineBinaryProperty(const Name: string;
      ReadData: TStreamProc; WriteData: TStreamProc; HasData: Boolean); overload;
  public
    constructor Create(Stream: TStream; BufSize: Integer);
    procedure DefineProperties(Instance: TPersistent); virtual;
    procedure FlushBuffer; virtual;
    property Root: TComponent read FRoot write FRoot;
  end;

  TReader = class(TFiler)
  public
    constructor Create(Stream: TStream; BufSize: Integer);
    procedure BeginReferences;
    procedure CheckValue(Value: Byte);
    procedure DefineProperties(Instance: TPersistent); override;
    procedure EndReferences;
    procedure FixupReferences;
    function ReadBoolean: Boolean;
    function ReadChar: Char;
    function ReadCollection(Collection: TCollection): TCollection;
    function ReadComponent(Component: TComponent): TComponent;
    function ReadFloat: Extended;
    function ReadIdent: string;
    function ReadInteger: Longint;
    function ReadInt64: Int64;
    function ReadListBegin: Boolean;
    procedure ReadListEnd;
    function ReadRootComponent(Root: TComponent): TComponent;
    function ReadString: string;
    function ReadVariant: Variant;
  end;

  TWriter = class(TFiler)
  public
    constructor Create(Stream: TStream; BufSize: Integer);
    procedure DefineProperties(Instance: TPersistent); override;
    procedure FlushBuffer; override;
    procedure WriteBoolean(Value: Boolean);
    procedure WriteChar(Value: Char);
    procedure WriteCollection(Value: TCollection);
    procedure WriteComponent(Component: TComponent);
    procedure WriteFloat(Value: Extended);
    procedure WriteIdent(const Ident: string);
    procedure WriteInteger(Value: Longint);
    procedure WriteInt64(Value: Int64);
    procedure WriteListBegin;
    procedure WriteListEnd;
    procedure WriteRootComponent(Root: TComponent);
    procedure WriteString(const Value: string);
    procedure WriteVariant(const Value: Variant);
  end;

  TComponent = class(TPersistent)
  private
    FOwner: TComponent;
    FName: string;
    FTag: NativeInt;
    FComponentState: TComponentState;
    FComponentStyle: TComponentStyle;
    FObservers: TObservers;
    function GetComponent(Index: Integer): TComponent;
    function GetComponentCount: Integer;
    function GetComponentIndex: Integer;
    procedure SetComponentIndex(Value: Integer);
    procedure SetName(const NewName: string);
  protected
    procedure ChangeName(const NewName: string); virtual;
    procedure DefineProperties(Filer: TFiler); virtual;
    procedure GetChildren(Proc: TGetChildProc; Root: TComponent); virtual;
    function GetChildOwner: TComponent; virtual;
    function GetChildParent: TComponent; virtual;
    function GetNamePath: string; override;
    function GetObservers: TObservers; virtual;
    function GetOwner: TPersistent; virtual;
    procedure Loaded; virtual;
    procedure Notification(AComponent: TComponent; Operation: TOperation); virtual;
    function CanObserve(const ID: Integer): Boolean; overload; virtual;
    procedure ObserverAdded(const ID: Integer;
      const Observer: IObserver); virtual;
    procedure ReadState(Reader: TReader); virtual;
    procedure SetAncestor(Value: Boolean);
    procedure SetDesigning(Value: Boolean; SetChildren: Boolean = True);
    procedure SetParentComponent(Value: TComponent); virtual;
    procedure SetSubComponent(IsSubComponent: Boolean);
    procedure Updating; virtual;
    procedure Updated; virtual;
    procedure ValidateContainer(AComponent: TComponent); dynamic;
    procedure ValidateInsert(AComponent: TComponent); dynamic;
    procedure WriteState(Writer: TWriter); virtual;
  public
    constructor Create(AOwner: TComponent); virtual;
    destructor Destroy; override;
    procedure BeforeDestruction; override;
    procedure DestroyComponents;
    procedure Destroying;
    function FindComponent(const AName: string): TComponent;
    function GetEnumerator: TComponentEnumerator;
    procedure FreeNotification(AComponent: TComponent);
    procedure RemoveFreeNotification(AComponent: TComponent);
    procedure FreeOnRelease;
    function GetParentComponent: TComponent; virtual;
    function HasParent: Boolean; virtual;
    procedure InsertComponent(AComponent: TComponent);
    procedure RemoveComponent(AComponent: TComponent);
    property ComponentCount: Integer read GetComponentCount;
    property ComponentIndex: Integer read GetComponentIndex write SetComponentIndex;
    property Components[Index: Integer]: TComponent read GetComponent;
    property ComponentState: TComponentState read FComponentState;
    property ComponentStyle: TComponentStyle read FComponentStyle;
    property Owner: TComponent read FOwner;
    property Observers: TObservers read GetObservers;
    property Name: string read FName write SetName;
    property Tag: NativeInt read FTag write FTag;
  end;



  TComponentEnumerator = class(TObject)
  private
    FComponent: TComponent;
    FIndex: Integer;
    function GetCurrent: TComponent;
  public
    constructor Create(AComponent: TComponent);
    function MoveNext: Boolean;
    property Current: TComponent read GetCurrent;
  end;

  TBasicAction = class(TComponent)
  private
    FActionComponent: TComponent;
    FOnExecute: TNotifyEvent;
    FOnUpdate: TNotifyEvent;
  protected
    procedure Change; virtual;
    function HandlesTarget(Target: TObject): Boolean; virtual;
    procedure SetAutoCheck(Value: Boolean); virtual;
    procedure SetCaption(const Value: string); virtual;
    procedure SetEnabled(Value: Boolean); virtual;
    procedure SetVisible(Value: Boolean); virtual;
  public
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
    function Execute: Boolean; dynamic;
    function ExecuteTarget(Target: TObject): Boolean; virtual;
    function Update: Boolean; dynamic;
    function UpdateTarget(Target: TObject): Boolean; virtual;
    property ActionComponent: TComponent read FActionComponent write FActionComponent;
    property OnExecute: TNotifyEvent read FOnExecute write FOnExecute;
    property OnUpdate: TNotifyEvent read FOnUpdate write FOnUpdate;
  end;

  TDataModule = class(TComponent)
  private
    FOldCreateOrder: Boolean;
    FOnCreate: TNotifyEvent;
    FOnDestroy: TNotifyEvent;
  public
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
    procedure AfterConstruction; override;
    procedure BeforeDestruction; override;
    property OldCreateOrder: Boolean read FOldCreateOrder write FOldCreateOrder;
    property OnCreate: TNotifyEvent read FOnCreate write FOnCreate;
    property OnDestroy: TNotifyEvent read FOnDestroy write FOnDestroy;
  end;


function StreamOriginalFormat: Word;
function ObjectBinaryToText(Input, Output: TStream): Boolean;
function ObjectTextToBinary(Input, Output: TStream): Boolean;
procedure WriteComponentResFile(const FileName: string; Instance: TComponent);
function ReadComponentResFile(const FileName: string; Instance: TComponent): TComponent;

implementation

{ TListEnumerator }

constructor TListEnumerator.Create(AList: TList);
begin
  inherited Create;
end;

function TListEnumerator.GetCurrent: Pointer;
begin
  Result := nil;
end;

function TListEnumerator.MoveNext: Boolean;
begin
  Result := False;
end;

{ TBits }

function TBits.GetBit(Index: Integer): Boolean;
begin
  Result := False;
end;

procedure TBits.SetBit(Index: Integer; Value: Boolean);
begin
end;

procedure TBits.SetSize(Value: Integer);
begin
end;

function TBits.OpenBit: Integer;
begin
  Result := -1;
end;

{ TInterfaceList }

function TInterfaceList.GetCapacity: Integer;
begin
  Result := FCapacity;
end;

function TInterfaceList.GetCount: Integer;
begin
  Result := FCount;
end;

function TInterfaceList.GetItem(Index: Integer): IInterface;
begin
  Result := nil;
end;

procedure TInterfaceList.SetCapacity(NewCapacity: Integer);
begin
end;

procedure TInterfaceList.SetItem(Index: Integer; const Item: IInterface);
begin
end;

function TInterfaceList.Add(const Item: IInterface): Integer;
begin
  Result := 0;
end;

procedure TInterfaceList.Clear;
begin
end;

procedure TInterfaceList.Delete(Index: Integer);
begin
end;

procedure TInterfaceList.Exchange(Index1, Index2: Integer);
begin
end;

function TInterfaceList.Expand: TInterfaceList;
begin
  Result := Self;
end;

function TInterfaceList.First: IInterface;
begin
  Result := nil;
end;

function TInterfaceList.GetEnumerator: TInterfaceListEnumerator;
begin
  Result := nil;
end;

function TInterfaceList.IndexOf(const Item: IInterface): Integer;
begin
  Result := -1;
end;

procedure TInterfaceList.Insert(Index: Integer; const Item: IInterface);
begin
end;

function TInterfaceList.Last: IInterface;
begin
  Result := nil;
end;

function TInterfaceList.Remove(const Item: IInterface): Integer;
begin
  Result := -1;
end;

procedure TInterfaceList.Lock;
begin
end;

procedure TInterfaceList.Unlock;
begin
end;

{ TInterfaceListEnumerator }

constructor TInterfaceListEnumerator.Create(AList: TInterfaceList);
begin
  inherited Create;
end;

function TInterfaceListEnumerator.GetCurrent: IInterface;
begin
  Result := nil;
end;

function TInterfaceListEnumerator.MoveNext: Boolean;
begin
  Result := False;
end;

{ TObservers }

constructor TObservers.Create;
begin
  inherited Create;
end;

destructor TObservers.Destroy;
begin
  inherited;
end;

procedure TObservers.AddObserver(const ID: Integer;
  const AIntf: IInterface);
begin
end;

procedure TObservers.AddObserver(const IDs: array of Integer;
  const AIntf: IInterface);
begin
end;

function TObservers.CanObserve(const ID: Integer): Boolean;
begin
  Result := True;
end;

function TObservers.IsObserving(const ID: Integer): Boolean;
begin
  Result := False;
end;

procedure TObservers.RemoveObserver(const ID: Integer;
  const AIntf: IInterface);
begin
end;

function TObservers.TryIsObserving(const ID: Integer;
  out AIntf: IInterface): Boolean;
begin
  AIntf := nil;
  Result := False;
end;

{ TObserverMapping }

constructor TObserverMapping.Create;
begin
  inherited Create;
end;

destructor TObserverMapping.Destroy;
begin
  inherited;
end;

class function TObserverMapping.Instance: TObserverMapping;
begin
  Result := nil;
end;

class procedure TObserverMapping.Clear;
begin
end;

class procedure TObserverMapping.EnableObservers(AClass: TClass);
begin
end;

class procedure TObserverMapping.DisableObservers(AClass: TClass);
begin
end;

{ TLinkObservers }

class function TLinkObservers.IsObserving(const AObservers: TObservers;
  const ID: Integer): Boolean;
begin
  Result := False;
end;

{ TPersistent }

procedure TPersistent.AssignError(Source: TPersistent);
begin
end;

procedure TPersistent.AssignTo(Dest: TPersistent);
begin
end;

procedure TPersistent.Assign(Source: TPersistent);
begin
end;

function TPersistent.GetNamePath: string;
begin
  Result := '';
end;

{ TList }

destructor TList.Destroy;
begin
  inherited;
end;

function TList.Get(Index: Integer): Pointer;
begin
  Result := nil;
end;

procedure TList.Put(Index: Integer; Item: Pointer);
begin
end;

procedure TList.SetCapacity(NewCapacity: Integer);
begin
end;

procedure TList.SetCount(NewCount: Integer);
begin
end;

procedure TList.Notify(Ptr: Pointer; Action: TListNotification);
begin
end;

function TList.Add(Item: Pointer): Integer;
begin
  Result := 0;
end;

procedure TList.Clear;
begin
end;

procedure TList.Delete(Index: Integer);
begin
end;

class procedure TList.Error(const Msg: string; Data: NativeInt);
begin
end;

class procedure TList.Error(Msg: PResStringRec; Data: NativeInt);
begin
end;

procedure TList.Exchange(Index1, Index2: Integer);
begin
end;

function TList.Extract(Item: Pointer): Pointer;
begin
  Result := nil;
end;

function TList.First: Pointer;
begin
  Result := nil;
end;

function TList.IndexOf(Item: Pointer): Integer;
begin
  Result := -1;
end;

procedure TList.Insert(Index: Integer; Item: Pointer);
begin
end;

function TList.Last: Pointer;
begin
  Result := nil;
end;

function TList.GetEnumerator: TListEnumerator;
begin
  Result := nil;
end;

procedure TList.Move(CurIndex, NewIndex: Integer);
begin
end;

procedure TList.Pack;
begin
end;

function TList.Remove(Item: Pointer): Integer;
begin
  Result := -1;
end;

procedure TList.Sort(Compare: TListSortCompare);
begin
end;

{ TInterfacedPersistent }

function TInterfacedPersistent.QueryInterface(const IID: TGUID; out Obj): HResult;
begin
  Result := E_NOINTERFACE;
end;

function TInterfacedPersistent._AddRef: Integer;
begin
  Result := -1;
end;

function TInterfacedPersistent._Release: Integer;
begin
  Result := -1;
end;

{ TCollectionEnumerator }

constructor TCollectionEnumerator.Create(ACollection: TCollection);
begin
  inherited Create;
end;

function TCollectionEnumerator.GetCurrent: TCollectionItem;
begin
  Result := nil;
end;

function TCollectionEnumerator.MoveNext: Boolean;
begin
  Result := False;
end;

{ TOwnedCollection }

constructor TOwnedCollection.Create(AOwner: TPersistent;
  ItemClass: TCollectionItemClass);
begin
  inherited Create(ItemClass);
end;

function TOwnedCollection.GetOwner: TPersistent;
begin
  Result := FOwner;
end;

{ TCollectionItem }

constructor TCollectionItem.Create(Collection: TCollection);
begin
  inherited Create;
end;

destructor TCollectionItem.Destroy;
begin
  inherited;
end;

function TCollectionItem.GetIndex: Integer;
begin
  Result := 0;
end;

procedure TCollectionItem.SetCollection(Value: TCollection);
begin
end;

procedure TCollectionItem.SetIndex(Value: Integer);
begin
end;

function TCollectionItem.GetDisplayName: string;
begin
  Result := '';
end;

procedure TCollectionItem.SetDisplayName(const Value: string);
begin
end;

procedure TCollectionItem.SetItemName;
begin
end;

{ TCollection }

constructor TCollection.Create(ItemClass: TCollectionItemClass);
begin
  inherited Create;
end;

destructor TCollection.Destroy;
begin
  inherited;
end;

function TCollection.GetCount: Integer;
begin
  Result := 0;
end;

function TCollection.GetItem(Index: Integer): TCollectionItem;
begin
  Result := nil;
end;

procedure TCollection.SetItem(Index: Integer; Value: TCollectionItem);
begin
end;

function TCollection.Add: TCollectionItem;
begin
  Result := nil;
end;

procedure TCollection.Added(var Item: TCollectionItem);
begin
end;

procedure TCollection.Deleting(Item: TCollectionItem);
begin
end;

function TCollection.GetItemClass: TCollectionItemClass;
begin
  Result := FItemClass;
end;

function TCollection.GetItemName: string;
begin
  Result := '';
end;

function TCollection.GetOwner: TPersistent;
begin
  Result := nil;
end;

procedure TCollection.Notify(Item: TCollectionItem; Action: TCollectionNotification);
begin
end;

procedure TCollection.PropertyNameChanged;
begin
end;

procedure TCollection.SetItemName(Item: TCollectionItem);
begin
end;

procedure TCollection.Update(Item: TCollectionItem);
begin
end;

procedure TCollection.Assign(Source: TPersistent);
begin
end;

procedure TCollection.BeginUpdate;
begin
end;

procedure TCollection.Clear;
begin
end;

procedure TCollection.Delete(Index: Integer);
begin
end;

procedure TCollection.EndUpdate;
begin
end;

function TCollection.FindItemID(ID: Integer): TCollectionItem;
begin
  Result := nil;
end;

function TCollection.GetEnumerator: TCollectionEnumerator;
begin
  Result := nil;
end;

function TCollection.GetItemID: Integer;
begin
  Result := 0;
end;

function TCollection.Insert(Index: Integer): TCollectionItem;
begin
  Result := nil;
end;

function TCollection.Owner: TPersistent;
begin
  Result := nil;
end;

{ TStrings }

destructor TStrings.Destroy;
begin
  inherited;
end;

procedure TStrings.DefineProperties(Filer: TFiler);
begin
end;

procedure TStrings.Error(const Msg: string; Data: Integer);
begin
end;

function TStrings.GetCapacity: Integer;
begin
  Result := 0;
end;

function TStrings.GetObject(Index: Integer): TObject;
begin
  Result := nil;
end;

function TStrings.GetText: PChar;
begin
  Result := nil;
end;

procedure TStrings.Put(Index: Integer; const S: string);
begin
end;

procedure TStrings.PutObject(Index: Integer; AObject: TObject);
begin
end;

procedure TStrings.SetCapacity(NewCapacity: Integer);
begin
end;

procedure TStrings.SetUpdateState(Updating: Boolean);
begin
end;

function TStrings.GetCommaText: string;
begin
  Result := '';
end;

function TStrings.GetDelimitedText: string;
begin
  Result := '';
end;

function TStrings.GetName(Index: Integer): string;
begin
  Result := '';
end;

function TStrings.GetValue(const Name: string): string;
begin
  Result := '';
end;

function TStrings.GetValueFromIndex(Index: Integer): string;
begin
  Result := '';
end;

function TStrings.GetTextStr: string;
begin
  Result := '';
end;

procedure TStrings.SetCommaText(const Value: string);
begin
end;

procedure TStrings.SetDelimitedText(const Value: string);
begin
end;

procedure TStrings.SetValue(const Name, Value: string);
begin
end;

procedure TStrings.SetValueFromIndex(Index: Integer; const Value: string);
begin
end;

procedure TStrings.SetTextStr(const Value: string);
begin
end;

function TStrings.Add(const S: string): Integer;
begin
  Result := 0;
end;

function TStrings.AddObject(const S: string; AObject: TObject): Integer;
begin
  Result := 0;
end;

procedure TStrings.AddStrings(Strings: TStrings);
begin
end;

procedure TStrings.AddStrings(const Strings: array of string);
begin
end;

procedure TStrings.Append(const S: string);
begin
end;

procedure TStrings.Assign(Source: TPersistent);
begin
end;

procedure TStrings.BeginUpdate;
begin
end;

procedure TStrings.EndUpdate;
begin
end;

function TStrings.Equals(Strings: TStrings): Boolean;
begin
  Result := False;
end;

procedure TStrings.Exchange(Index1, Index2: Integer);
begin
end;

function TStrings.IndexOf(const S: string): Integer;
begin
  Result := -1;
end;

function TStrings.IndexOfName(const Name: string): Integer;
begin
  Result := -1;
end;

function TStrings.IndexOfObject(AObject: TObject): Integer;
begin
  Result := -1;
end;

procedure TStrings.InsertObject(Index: Integer; const S: string; AObject: TObject);
begin
end;

procedure TStrings.LoadFromFile(const FileName: string);
begin
end;

procedure TStrings.LoadFromFile(const FileName: string; Encoding: TEncoding);
begin
end;

procedure TStrings.LoadFromStream(Stream: TStream);
begin
end;

procedure TStrings.LoadFromStream(Stream: TStream; Encoding: TEncoding);
begin
end;

procedure TStrings.Move(CurIndex, NewIndex: Integer);
begin
end;

procedure TStrings.SaveToFile(const FileName: string);
begin
end;

procedure TStrings.SaveToFile(const FileName: string; Encoding: TEncoding);
begin
end;

procedure TStrings.SaveToStream(Stream: TStream);
begin
end;

procedure TStrings.SaveToStream(Stream: TStream; Encoding: TEncoding);
begin
end;

procedure TStrings.SetText(Text: PChar);
begin
end;

{ TStringList }

constructor TStringList.Create;
begin
  inherited Create;
end;

constructor TStringList.Create(OwnsObjects: Boolean);
begin
  inherited Create;
end;

destructor TStringList.Destroy;
begin
  inherited;
end;

procedure TStringList.Changed;
begin
end;

procedure TStringList.Changing;
begin
end;

function TStringList.CompareStrings(const S1, S2: string): Integer;
begin
  Result := 0;
end;

function TStringList.Get(Index: Integer): string;
begin
  Result := '';
end;

function TStringList.GetCapacity: Integer;
begin
  Result := 0;
end;

function TStringList.GetCount: Integer;
begin
  Result := 0;
end;

function TStringList.GetObject(Index: Integer): TObject;
begin
  Result := nil;
end;

procedure TStringList.Put(Index: Integer; const S: string);
begin
end;

procedure TStringList.PutObject(Index: Integer; AObject: TObject);
begin
end;

procedure TStringList.SetCapacity(NewCapacity: Integer);
begin
end;

procedure TStringList.SetUpdateState(Updating: Boolean);
begin
end;

function TStringList.Add(const S: string): Integer;
begin
  Result := 0;
end;

procedure TStringList.Clear;
begin
end;

procedure TStringList.Delete(Index: Integer);
begin
end;

procedure TStringList.Exchange(Index1, Index2: Integer);
begin
end;

function TStringList.Find(const S: string; var Index: Integer): Boolean;
begin
  Result := False;
end;

function TStringList.IndexOf(const S: string): Integer;
begin
  Result := -1;
end;

procedure TStringList.Insert(Index: Integer; const S: string);
begin
end;

procedure TStringList.Sort;
begin
end;

procedure TStringList.CustomSort(Compare: TStringListSortCompare);
begin
end;

{ TStream }

function TStream.GetPosition: Int64;
begin
  Result := 0;
end;

procedure TStream.SetPosition(const Pos: Int64);
begin
end;

function TStream.GetSize: Int64;
begin
  Result := 0;
end;

procedure TStream.SetSize64(const NewSize: Int64);
begin
end;

procedure TStream.SetSize(NewSize: Longint);
begin
end;

procedure TStream.SetSize(const NewSize: Int64);
begin
end;

function TStream.Seek(Offset: Longint; Origin: Word): Longint;
begin
  Result := 0;
end;

function TStream.Seek(const Offset: Int64; Origin: TSeekOrigin): Int64;
begin
  Result := 0;
end;

procedure TStream.ReadBuffer(var Buffer; Count: Longint);
begin
end;

procedure TStream.WriteBuffer(const Buffer; Count: Longint);
begin
end;

function TStream.CopyFrom(Source: TStream; Count: Int64): Int64;
begin
  Result := 0;
end;

function TStream.ReadByte: Byte;
begin
  Result := 0;
end;

procedure TStream.WriteByte(Value: Byte);
begin
end;

{ THandleStream }

constructor THandleStream.Create(AHandle: THandle);
begin
  inherited Create;
end;

function THandleStream.Read(var Buffer; Count: Longint): Longint;
begin
  Result := 0;
end;

function THandleStream.Write(const Buffer; Count: Longint): Longint;
begin
  Result := 0;
end;

function THandleStream.Seek(const Offset: Int64; Origin: TSeekOrigin): Int64;
begin
  Result := 0;
end;

{ TFileStream }

constructor TFileStream.Create(const FileName: string; Mode: Word);
begin
  inherited Create(0);
end;

constructor TFileStream.Create(const FileName: string; Mode: Word; Rights: Cardinal);
begin
  inherited Create(0);
end;

{ TCustomMemoryStream }

procedure TCustomMemoryStream.SetPointer(Ptr: Pointer; Size: NativeInt);
begin
end;

function TCustomMemoryStream.Read(var Buffer; Count: Longint): Longint;
begin
  Result := 0;
end;

function TCustomMemoryStream.Seek(const Offset: Int64; Origin: TSeekOrigin): Int64;
begin
  Result := 0;
end;

procedure TCustomMemoryStream.SaveToStream(Stream: TStream);
begin
end;

procedure TCustomMemoryStream.SaveToFile(const FileName: string);
begin
end;

{ TMemoryStream }

destructor TMemoryStream.Destroy;
begin
  inherited;
end;

procedure TMemoryStream.SetCapacity(NewCapacity: NativeInt);
begin
end;

function TMemoryStream.Realloc(var NewCapacity: NativeInt): Pointer;
begin
  Result := nil;
end;

procedure TMemoryStream.SetSize(const NewSize: Int64);
begin
end;

procedure TMemoryStream.Clear;
begin
end;

procedure TMemoryStream.LoadFromStream(Stream: TStream);
begin
end;

procedure TMemoryStream.LoadFromFile(const FileName: string);
begin
end;

function TMemoryStream.Write(const Buffer; Count: Longint): Longint;
begin
  Result := 0;
end;

{ TStringStream }

constructor TStringStream.Create(const AString: string);
begin
  inherited Create;
end;

constructor TStringStream.Create(const AString: string; AEncoding: TEncoding);
begin
  inherited Create;
end;

destructor TStringStream.Destroy;
begin
  inherited;
end;

procedure TStringStream.SetSize(const NewSize: Int64);
begin
end;

function TStringStream.Read(var Buffer; Count: Longint): Longint;
begin
  Result := 0;
end;

function TStringStream.Write(const Buffer; Count: Longint): Longint;
begin
  Result := 0;
end;

function TStringStream.Seek(const Offset: Int64; Origin: TSeekOrigin): Int64;
begin
  Result := 0;
end;

function TStringStream.ReadString(Count: Integer): string;
begin
  Result := '';
end;

procedure TStringStream.WriteString(const AString: string);
begin
end;

{ TBytesStream }

constructor TBytesStream.Create(const ABytes: TBytes);
begin
  inherited Create;
end;

function TBytesStream.Realloc(var NewCapacity: NativeInt): Pointer;
begin
  Result := nil;
end;

{ TResourceStream }

constructor TResourceStream.Create(Instance: THandle; const ResName: string;
  ResType: PChar);
begin
  inherited Create;
end;

constructor TResourceStream.CreateFromID(Instance: THandle; ResID: Integer;
  ResType: PChar);
begin
  inherited Create;
end;

destructor TResourceStream.Destroy;
begin
  inherited;
end;

function TResourceStream.Write(const Buffer; Count: Longint): Longint;
begin
  Result := 0;
end;

{ TThread }

constructor TThread.Create(CreateSuspended: Boolean);
begin
end;

destructor TThread.Destroy;
begin
  inherited;
end;

procedure TThread.Start;
begin
end;

procedure TThread.Resume;
begin
end;

procedure TThread.Suspend;
begin
end;

procedure TThread.Terminate;
begin
end;

function TThread.WaitFor: Cardinal;
begin
  Result := 0;
end;

{ TThreadList }

constructor TThreadList.Create;
begin
  inherited Create;
end;

destructor TThreadList.Destroy;
begin
  inherited;
end;

procedure TThreadList.Add(Item: Pointer);
begin
end;

procedure TThreadList.Clear;
begin
end;

function TThreadList.LockList: TList;
begin
  Result := FList;
end;

procedure TThreadList.Remove(Item: Pointer);
begin
end;

procedure TThreadList.UnlockList;
begin
end;

{ TStringsEnumerator }

constructor TStringsEnumerator.Create(AStrings: TStrings);
begin
  inherited Create;
end;

function TStringsEnumerator.GetCurrent: string;
begin
  Result := '';
end;

function TStringsEnumerator.MoveNext: Boolean;
begin
  Result := False;
end;

{ TStringReader }

constructor TStringReader.Create(const AString: string);
begin
  inherited Create;
end;

function TStringReader.Peek: Integer;
begin
  Result := -1;
end;

function TStringReader.Read: Integer;
begin
  Result := -1;
end;

function TStringReader.Read(var Buffer: array of Char;
  Index, Count: Integer): Integer;
begin
  Result := 0;
end;

function TStringReader.ReadLine: string;
begin
  Result := '';
end;

function TStringReader.ReadToEnd: string;
begin
  Result := '';
end;

{ TStringWriter }

constructor TStringWriter.Create;
begin
  inherited Create;
end;

constructor TStringWriter.Create(ABuilder: System.SysUtils.TStringBuilder);
begin
  inherited Create;
end;

procedure TStringWriter.Write(const Value: string);
begin
end;

procedure TStringWriter.Write(Value: Char);
begin
end;

procedure TStringWriter.WriteLine;
begin
end;

procedure TStringWriter.WriteLine(const Value: string);
begin
end;

function TStringWriter.ToString: string;
begin
  Result := '';
end;

{ TStreamReader }

constructor TStreamReader.Create(Stream: TStream);
begin
  inherited Create;
end;

constructor TStreamReader.Create(Stream: TStream; Encoding: TEncoding;
  DetectBOM: Boolean; BufferSize: Integer);
begin
  inherited Create;
end;

constructor TStreamReader.Create(const Filename: string);
begin
  inherited Create;
end;

constructor TStreamReader.Create(const Filename: string; Encoding: TEncoding;
  DetectBOM: Boolean; BufferSize: Integer);
begin
  inherited Create;
end;

destructor TStreamReader.Destroy;
begin
  inherited;
end;

procedure TStreamReader.Close;
begin
end;

function TStreamReader.GetEndOfStream: Boolean;
begin
  Result := False;
end;

function TStreamReader.Peek: Integer;
begin
  Result := -1;
end;

function TStreamReader.Read: Integer;
begin
  Result := -1;
end;

function TStreamReader.Read(var Buffer: array of Char;
  Index, Count: Integer): Integer;
begin
  Result := 0;
end;

function TStreamReader.ReadBlock(var Buffer: array of Char;
  Index, Count: Integer): Integer;
begin
  Result := 0;
end;

function TStreamReader.ReadLine: string;
begin
  Result := '';
end;

function TStreamReader.ReadToEnd: string;
begin
  Result := '';
end;

{ TStreamWriter }

constructor TStreamWriter.Create(Stream: TStream);
begin
  inherited Create;
end;

constructor TStreamWriter.Create(Stream: TStream; Encoding: TEncoding;
  BufferSize: Integer);
begin
  inherited Create;
end;

constructor TStreamWriter.Create(const Filename: string; Append: Boolean);
begin
  inherited Create;
end;

constructor TStreamWriter.Create(const Filename: string; Append: Boolean;
  Encoding: TEncoding; BufferSize: Integer);
begin
  inherited Create;
end;

destructor TStreamWriter.Destroy;
begin
  inherited;
end;

procedure TStreamWriter.Close;
begin
end;

procedure TStreamWriter.Flush;
begin
end;

procedure TStreamWriter.Write(const Value: string);
begin
end;

procedure TStreamWriter.Write(Value: Char);
begin
end;

procedure TStreamWriter.WriteLine;
begin
end;

procedure TStreamWriter.WriteLine(const Value: string);
begin
end;

{ TRecall }

constructor TRecall.Create(AStorage, AReference: TPersistent);
begin
  inherited Create;
end;

destructor TRecall.Destroy;
begin
  inherited;
end;

procedure TRecall.Forget;
begin
end;

procedure TRecall.Store;
begin
end;

{ TParser }

constructor TParser.Create(Stream: TStream);
begin
  inherited Create;
end;

procedure TParser.CheckToken(T: TToken);
begin
end;

procedure TParser.CheckTokenSymbol(const S: string);
begin
end;

procedure TParser.Error(const Ident: string);
begin
end;

procedure TParser.ErrorFmt(const Ident: string; const Args: array of const);
begin
end;

function TParser.NextToken: TToken;
begin
  Result := toEOF;
end;

function TParser.SourceLine: Integer;
begin
  Result := 0;
end;

function TParser.TokenComponentIdent: string;
begin
  Result := '';
end;

function TParser.TokenFloat: Extended;
begin
  Result := 0;
end;

function TParser.TokenInt: Int64;
begin
  Result := 0;
end;

function TParser.TokenString: string;
begin
  Result := '';
end;

function TParser.TokenSymbolIs(const S: string): Boolean;
begin
  Result := False;
end;

function TParser.TokenWideString: WideString;
begin
  Result := '';
end;

{ TBasicActionLink }

constructor TBasicActionLink.Create(AClient: TObject);
begin
  inherited Create;
end;

destructor TBasicActionLink.Destroy;
begin
  inherited;
end;

procedure TBasicActionLink.AssignClient(AClient: TObject);
begin
end;

function TBasicActionLink.IsGroupIndexLinked: Boolean;
begin
  Result := False;
end;

function TBasicActionLink.IsOnExecuteLinked: Boolean;
begin
  Result := False;
end;

procedure TBasicActionLink.SetGroupIndex(Value: Integer);
begin
end;

procedure TBasicActionLink.SetOnExecute(Value: TNotifyEvent);
begin
end;

procedure TBasicActionLink.Assign(Source: TObject);
begin
end;

function TBasicActionLink.Execute(AClient: TObject): Boolean;
begin
  Result := False;
end;

function TBasicActionLink.Update: Boolean;
begin
  Result := False;
end;

{ TComponentEnumerator }

constructor TComponentEnumerator.Create(AComponent: TComponent);
begin
  inherited Create;
end;

function TComponentEnumerator.GetCurrent: TComponent;
begin
  Result := nil;
end;

function TComponentEnumerator.MoveNext: Boolean;
begin
  Result := False;
end;

{ TBasicAction }

constructor TBasicAction.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
end;

destructor TBasicAction.Destroy;
begin
  inherited;
end;

procedure TBasicAction.Change;
begin
end;

function TBasicAction.HandlesTarget(Target: TObject): Boolean;
begin
  Result := False;
end;

procedure TBasicAction.SetAutoCheck(Value: Boolean);
begin
end;

procedure TBasicAction.SetCaption(const Value: string);
begin
end;

procedure TBasicAction.SetEnabled(Value: Boolean);
begin
end;

procedure TBasicAction.SetVisible(Value: Boolean);
begin
end;

function TBasicAction.Execute: Boolean;
begin
  Result := False;
end;

function TBasicAction.ExecuteTarget(Target: TObject): Boolean;
begin
  Result := False;
end;

function TBasicAction.Update: Boolean;
begin
  Result := False;
end;

function TBasicAction.UpdateTarget(Target: TObject): Boolean;
begin
  Result := False;
end;

{ TDataModule }

constructor TDataModule.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
end;

destructor TDataModule.Destroy;
begin
  inherited;
end;

procedure TDataModule.AfterConstruction;
begin
  inherited;
end;

procedure TDataModule.BeforeDestruction;
begin
  inherited;
end;

{ TTextReader }

function TTextReader.Read(var Buffer: array of Char;
  Index, Count: Integer): Integer;
begin
  Result := 0;
end;

function TTextReader.ReadBlock(var Buffer: array of Char;
  Index, Count: Integer): Integer;
begin
  Result := 0;
end;

function TTextReader.ReadLine: string;
begin
  Result := '';
end;

function TTextReader.ReadToEnd: string;
begin
  Result := '';
end;

function TTextReader.GetEnumerator: TTextReaderEnumerator;
begin
  Result := nil;
end;

{ TTextReaderEnumerator }

constructor TTextReaderEnumerator.Create(AReader: TTextReader);
begin
  inherited Create;
end;

function TTextReaderEnumerator.MoveNext: Boolean;
begin
  Result := False;
end;

{ TTextWriter }

constructor TTextWriter.Create;
begin
  inherited Create;
end;

procedure TTextWriter.Close;
begin
end;

procedure TTextWriter.Flush;
begin
end;

procedure TTextWriter.Write(Value: Boolean);
begin
end;

procedure TTextWriter.Write(Value: Char);
begin
end;

procedure TTextWriter.Write(Value: Integer);
begin
end;

procedure TTextWriter.Write(Value: Int64);
begin
end;

procedure TTextWriter.Write(Value: Single);
begin
end;

procedure TTextWriter.Write(Value: Double);
begin
end;

procedure TTextWriter.Write(const Value: string);
begin
end;

procedure TTextWriter.WriteLine;
begin
end;

procedure TTextWriter.WriteLine(const Value: string);
begin
end;

{ TBinaryReader }

constructor TBinaryReader.Create(Stream: TStream; AEncoding: TEncoding;
  AOwnsStream: Boolean);
begin
  inherited Create;
end;

constructor TBinaryReader.Create(const Filename: string; Encoding: TEncoding);
begin
  inherited Create;
end;

destructor TBinaryReader.Destroy;
begin
  inherited;
end;

procedure TBinaryReader.Close;
begin
end;

function TBinaryReader.ReadBoolean: Boolean;
begin
  Result := False;
end;

function TBinaryReader.ReadByte: Byte;
begin
  Result := 0;
end;

function TBinaryReader.ReadBytes(Count: Integer): TBytes;
begin
end;

function TBinaryReader.ReadChar: Char;
begin
  Result := #0;
end;

function TBinaryReader.ReadChars(Count: Integer): TCharArray;
begin
end;

function TBinaryReader.ReadDouble: Double;
begin
  Result := 0;
end;

function TBinaryReader.ReadInteger: Integer;
begin
  Result := 0;
end;

function TBinaryReader.ReadInt64: Int64;
begin
  Result := 0;
end;

function TBinaryReader.ReadShortInt: ShortInt;
begin
  Result := 0;
end;

function TBinaryReader.ReadSingle: Single;
begin
  Result := 0;
end;

function TBinaryReader.ReadSmallInt: SmallInt;
begin
  Result := 0;
end;

function TBinaryReader.ReadString: string;
begin
  Result := '';
end;

function TBinaryReader.ReadUInt64: UInt64;
begin
  Result := 0;
end;

function TBinaryReader.ReadWord: Word;
begin
  Result := 0;
end;

function TBinaryReader.ReadCardinal: Cardinal;
begin
  Result := 0;
end;

{ TBinaryWriter }

constructor TBinaryWriter.Create;
begin
  inherited Create;
end;

constructor TBinaryWriter.Create(Stream: TStream);
begin
  inherited Create;
end;

constructor TBinaryWriter.Create(Stream: TStream; Encoding: TEncoding);
begin
  inherited Create;
end;

constructor TBinaryWriter.Create(Stream: TStream; Encoding: TEncoding;
  AOwnsStream: Boolean);
begin
  inherited Create;
end;

constructor TBinaryWriter.Create(const Filename: string; Append: Boolean);
begin
  inherited Create;
end;

constructor TBinaryWriter.Create(const Filename: string; Append: Boolean;
  Encoding: TEncoding);
begin
  inherited Create;
end;

destructor TBinaryWriter.Destroy;
begin
  inherited;
end;

procedure TBinaryWriter.Close;
begin
end;

procedure TBinaryWriter.Flush;
begin
end;

procedure TBinaryWriter.Seek(Offset: Integer; Origin: TSeekOrigin);
begin
end;

procedure TBinaryWriter.Write(Value: Byte);
begin
end;

procedure TBinaryWriter.Write(Value: Boolean);
begin
end;

procedure TBinaryWriter.Write(Value: Char);
begin
end;

procedure TBinaryWriter.Write(const Value: TCharArray);
begin
end;

procedure TBinaryWriter.Write(const Value: TBytes);
begin
end;

procedure TBinaryWriter.Write(Value: Double);
begin
end;

procedure TBinaryWriter.Write(Value: Integer);
begin
end;

procedure TBinaryWriter.Write(Value: SmallInt);
begin
end;

procedure TBinaryWriter.Write(Value: ShortInt);
begin
end;

procedure TBinaryWriter.Write(Value: Word);
begin
end;

procedure TBinaryWriter.Write(Value: Cardinal);
begin
end;

procedure TBinaryWriter.Write(Value: Int64);
begin
end;

procedure TBinaryWriter.Write(Value: Single);
begin
end;

procedure TBinaryWriter.Write(const Value: string);
begin
end;

procedure TBinaryWriter.Write(Value: UInt64);
begin
end;

procedure TBinaryWriter.Write(const Value: TCharArray; Index, Count: Integer);
begin
end;

procedure TBinaryWriter.Write(const Value: TBytes; Index, Count: Integer);
begin
end;

{ TFiler }

constructor TFiler.Create(Stream: TStream; BufSize: Integer);
begin
  inherited Create;
end;

procedure TFiler.DefineProperty(const Name: string;
  ReadData: TReaderProc; WriteData: TWriterProc; HasData: Boolean);
begin
end;

procedure TFiler.DefineBinaryProperty(const Name: string;
  ReadData: TStreamProc; WriteData: TStreamProc; HasData: Boolean);
begin
end;

procedure TFiler.DefineProperties(Instance: TPersistent);
begin
end;

procedure TFiler.FlushBuffer;
begin
end;

{ TReader }

constructor TReader.Create(Stream: TStream; BufSize: Integer);
begin
  inherited Create(Stream, BufSize);
end;

procedure TReader.BeginReferences;
begin
end;

procedure TReader.CheckValue(Value: Byte);
begin
end;

procedure TReader.DefineProperties(Instance: TPersistent);
begin
end;

procedure TReader.EndReferences;
begin
end;

procedure TReader.FixupReferences;
begin
end;

function TReader.ReadBoolean: Boolean;
begin
  Result := False;
end;

function TReader.ReadChar: Char;
begin
  Result := #0;
end;

function TReader.ReadCollection(Collection: TCollection): TCollection;
begin
  Result := Collection;
end;

function TReader.ReadComponent(Component: TComponent): TComponent;
begin
  Result := Component;
end;

function TReader.ReadFloat: Extended;
begin
  Result := 0;
end;

function TReader.ReadIdent: string;
begin
  Result := '';
end;

function TReader.ReadInteger: Longint;
begin
  Result := 0;
end;

function TReader.ReadInt64: Int64;
begin
  Result := 0;
end;

function TReader.ReadListBegin: Boolean;
begin
  Result := False;
end;

procedure TReader.ReadListEnd;
begin
end;

function TReader.ReadRootComponent(Root: TComponent): TComponent;
begin
  Result := Root;
end;

function TReader.ReadString: string;
begin
  Result := '';
end;

function TReader.ReadVariant: Variant;
begin
end;

{ TWriter }

constructor TWriter.Create(Stream: TStream; BufSize: Integer);
begin
  inherited Create(Stream, BufSize);
end;

procedure TWriter.DefineProperties(Instance: TPersistent);
begin
end;

procedure TWriter.FlushBuffer;
begin
end;

procedure TWriter.WriteBoolean(Value: Boolean);
begin
end;

procedure TWriter.WriteChar(Value: Char);
begin
end;

procedure TWriter.WriteCollection(Value: TCollection);
begin
end;

procedure TWriter.WriteComponent(Component: TComponent);
begin
end;

procedure TWriter.WriteFloat(Value: Extended);
begin
end;

procedure TWriter.WriteIdent(const Ident: string);
begin
end;

procedure TWriter.WriteInteger(Value: Longint);
begin
end;

procedure TWriter.WriteInt64(Value: Int64);
begin
end;

procedure TWriter.WriteListBegin;
begin
end;

procedure TWriter.WriteListEnd;
begin
end;

procedure TWriter.WriteRootComponent(Root: TComponent);
begin
end;

procedure TWriter.WriteString(const Value: string);
begin
end;

procedure TWriter.WriteVariant(const Value: Variant);
begin
end;

{ TComponent }

constructor TComponent.Create(AOwner: TComponent);
begin
  inherited Create;
end;

destructor TComponent.Destroy;
begin
  inherited;
end;

function TComponent.GetComponent(Index: Integer): TComponent;
begin
  Result := nil;
end;

function TComponent.GetComponentCount: Integer;
begin
  Result := 0;
end;

function TComponent.GetComponentIndex: Integer;
begin
  Result := 0;
end;

procedure TComponent.SetComponentIndex(Value: Integer);
begin
end;

procedure TComponent.SetName(const NewName: string);
begin
end;

procedure TComponent.ChangeName(const NewName: string);
begin
end;

procedure TComponent.DefineProperties(Filer: TFiler);
begin
end;

procedure TComponent.GetChildren(Proc: TGetChildProc; Root: TComponent);
begin
end;

function TComponent.GetChildOwner: TComponent;
begin
  Result := nil;
end;

function TComponent.GetChildParent: TComponent;
begin
  Result := nil;
end;

function TComponent.GetNamePath: string;
begin
  Result := '';
end;

function TComponent.GetObservers: TObservers;
begin
  Result := FObservers;
end;

function TComponent.GetOwner: TPersistent;
begin
  Result := FOwner;
end;

procedure TComponent.Loaded;
begin
end;

procedure TComponent.Notification(AComponent: TComponent; Operation: TOperation);
begin
end;

function TComponent.CanObserve(const ID: Integer): Boolean;
begin
  Result := False;
end;

procedure TComponent.ObserverAdded(const ID: Integer;
  const Observer: IObserver);
begin
end;

procedure TComponent.ReadState(Reader: TReader);
begin
end;

procedure TComponent.SetAncestor(Value: Boolean);
begin
end;

procedure TComponent.SetDesigning(Value: Boolean; SetChildren: Boolean);
begin
end;

procedure TComponent.SetParentComponent(Value: TComponent);
begin
end;

procedure TComponent.SetSubComponent(IsSubComponent: Boolean);
begin
end;

procedure TComponent.Updating;
begin
end;

procedure TComponent.Updated;
begin
end;

procedure TComponent.ValidateContainer(AComponent: TComponent);
begin
end;

procedure TComponent.ValidateInsert(AComponent: TComponent);
begin
end;

procedure TComponent.WriteState(Writer: TWriter);
begin
end;

procedure TComponent.BeforeDestruction;
begin
  inherited;
end;

procedure TComponent.DestroyComponents;
begin
end;

procedure TComponent.Destroying;
begin
end;

function TComponent.FindComponent(const AName: string): TComponent;
begin
  Result := nil;
end;

function TComponent.GetEnumerator: TComponentEnumerator;
begin
  Result := nil;
end;

procedure TComponent.FreeNotification(AComponent: TComponent);
begin
end;

procedure TComponent.RemoveFreeNotification(AComponent: TComponent);
begin
end;

procedure TComponent.FreeOnRelease;
begin
end;

function TComponent.GetParentComponent: TComponent;
begin
  Result := nil;
end;

function TComponent.HasParent: Boolean;
begin
  Result := False;
end;

procedure TComponent.InsertComponent(AComponent: TComponent);
begin
end;

procedure TComponent.RemoveComponent(AComponent: TComponent);
begin
end;

function StreamOriginalFormat: Word;
begin
  Result := 0;
end;

function ObjectBinaryToText(Input, Output: TStream): Boolean;
begin
  Result := False;
end;

function ObjectTextToBinary(Input, Output: TStream): Boolean;
begin
  Result := False;
end;

procedure WriteComponentResFile(const FileName: string; Instance: TComponent);
begin
end;

function ReadComponentResFile(const FileName: string; Instance: TComponent): TComponent;
begin
  Result := Instance;
end;

end.
