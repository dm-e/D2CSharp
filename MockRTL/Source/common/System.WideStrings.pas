{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.WideStrings.
  Independently authored interface skeleton for Delphi source translation.
  Methods intentionally do not implement string-list behavior.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit System.WideStrings;

interface

uses
  System.SysUtils,
  System.Classes;

type
  TWideStrings = class;
  TWideStringList = class;
  TWideStringsEnumerator = class;

  TWideStringListSortCompare = function(List: TWideStringList;
    Index1, Index2: Integer): Integer;

  TWideStrings = class(TPersistent)
  private
    FDelimiter: WideChar;
    FQuoteChar: WideChar;
    FNameValueSeparator: WideChar;
    FLineBreak: WideString;
    FStrictDelimiter: Boolean;
    FUpdateCount: Integer;
    function GetCommaText: WideString;
    function GetDelimitedText: WideString;
    function GetName(Index: Integer): WideString;
    function GetValue(const Name: WideString): WideString;
    function GetValueFromIndex(Index: Integer): WideString;
    function GetTextStr: WideString;
    procedure SetCommaText(const Value: WideString);
    procedure SetDelimitedText(const Value: WideString);
    procedure SetValue(const Name, Value: WideString);
    procedure SetValueFromIndex(Index: Integer; const Value: WideString);
    procedure SetTextStr(const Value: WideString);
  protected
    procedure DefineProperties(Filer: TFiler); virtual;
    procedure Error(const Msg: WideString; Data: Integer); overload;
    procedure Error(Msg: PResStringRec; Data: Integer); overload;
    function Get(Index: Integer): WideString; virtual; abstract;
    function GetCapacity: Integer; virtual;
    function GetCount: Integer; virtual; abstract;
    function GetObject(Index: Integer): TObject; virtual;
    procedure Put(Index: Integer; const S: WideString); virtual;
    procedure PutObject(Index: Integer; AObject: TObject); virtual;
    procedure SetCapacity(NewCapacity: Integer); virtual;
    procedure SetUpdateState(Updating: Boolean); virtual;
  public
    destructor Destroy; override;
    function Add(const S: WideString): Integer; virtual;
    function AddObject(const S: WideString; AObject: TObject): Integer; virtual;
    procedure AddStrings(Strings: TWideStrings); overload; virtual;
    procedure AddStrings(const Strings: array of WideString); overload; virtual;
    procedure Append(const S: WideString);
    procedure Assign(Source: TPersistent); override;
    procedure BeginUpdate;
    procedure Clear; virtual; abstract;
    procedure Delete(Index: Integer); virtual; abstract;
    procedure EndUpdate;
    function Equals(Strings: TWideStrings): Boolean; reintroduce;
    procedure Exchange(Index1, Index2: Integer); virtual;
    function GetEnumerator: TWideStringsEnumerator;
    function IndexOf(const S: WideString): Integer; virtual;
    function IndexOfName(const Name: WideString): Integer;
    function IndexOfObject(AObject: TObject): Integer;
    procedure Insert(Index: Integer; const S: WideString); virtual; abstract;
    procedure InsertObject(Index: Integer; const S: WideString;
      AObject: TObject); virtual;
    procedure LoadFromFile(const FileName: WideString); overload; virtual;
    procedure LoadFromFile(const FileName: WideString;
      Encoding: TEncoding); overload; virtual;
    procedure LoadFromStream(Stream: TStream); overload; virtual;
    procedure LoadFromStream(Stream: TStream;
      Encoding: TEncoding); overload; virtual;
    procedure Move(CurIndex, NewIndex: Integer); virtual;
    procedure SaveToFile(const FileName: WideString); overload; virtual;
    procedure SaveToFile(const FileName: WideString;
      Encoding: TEncoding); overload; virtual;
    procedure SaveToStream(Stream: TStream); overload; virtual;
    procedure SaveToStream(Stream: TStream;
      Encoding: TEncoding); overload; virtual;
    procedure SetText(Text: PWideChar); virtual;
    function GetText: PWideChar; virtual;
    property Capacity: Integer read GetCapacity write SetCapacity;
    property CommaText: WideString read GetCommaText write SetCommaText;
    property Count: Integer read GetCount;
    property Delimiter: WideChar read FDelimiter write FDelimiter;
    property DelimitedText: WideString read GetDelimitedText write SetDelimitedText;
    property LineBreak: WideString read FLineBreak write FLineBreak;
    property Names[Index: Integer]: WideString read GetName;
    property NameValueSeparator: WideChar read FNameValueSeparator
      write FNameValueSeparator;
    property Objects[Index: Integer]: TObject read GetObject write PutObject;
    property QuoteChar: WideChar read FQuoteChar write FQuoteChar;
    property StrictDelimiter: Boolean read FStrictDelimiter write FStrictDelimiter;
    property Strings[Index: Integer]: WideString read Get write Put; default;
    property Text: WideString read GetTextStr write SetTextStr;
    property ValueFromIndex[Index: Integer]: WideString read GetValueFromIndex
      write SetValueFromIndex;
    property Values[const Name: WideString]: WideString read GetValue write SetValue;
  end;

  TWideStringList = class(TWideStrings)
  private
    FCaseSensitive: Boolean;
    FDuplicates: TDuplicates;
    FSorted: Boolean;
    FOnChange: TNotifyEvent;
    FOnChanging: TNotifyEvent;
  protected
    procedure Changed; virtual;
    procedure Changing; virtual;
    function CompareStrings(const S1, S2: WideString): Integer; virtual;
    function Get(Index: Integer): WideString; override;
    function GetCapacity: Integer; override;
    function GetCount: Integer; override;
    function GetObject(Index: Integer): TObject; override;
    procedure Put(Index: Integer; const S: WideString); override;
    procedure PutObject(Index: Integer; AObject: TObject); override;
    procedure SetCapacity(NewCapacity: Integer); override;
    procedure SetUpdateState(Updating: Boolean); override;
  public
    constructor Create;
    destructor Destroy; override;
    function Add(const S: WideString): Integer; override;
    procedure Clear; override;
    procedure Delete(Index: Integer); override;
    procedure Exchange(Index1, Index2: Integer); override;
    function Find(const S: WideString; var Index: Integer): Boolean; virtual;
    function IndexOf(const S: WideString): Integer; override;
    procedure Insert(Index: Integer; const S: WideString); override;
    procedure Sort; virtual;
    procedure CustomSort(Compare: TWideStringListSortCompare); virtual;
    property CaseSensitive: Boolean read FCaseSensitive write FCaseSensitive;
    property Duplicates: TDuplicates read FDuplicates write FDuplicates;
    property Sorted: Boolean read FSorted write FSorted;
    property OnChange: TNotifyEvent read FOnChange write FOnChange;
    property OnChanging: TNotifyEvent read FOnChanging write FOnChanging;
  end;

  TWideStringsEnumerator = class(TObject)
  private
    FStrings: TWideStrings;
    FIndex: Integer;
    function GetCurrent: WideString;
  public
    constructor Create(AStrings: TWideStrings);
    function MoveNext: Boolean;
    property Current: WideString read GetCurrent;
  end;

implementation

{ TWideStrings.GetCommaText }
function TWideStrings.GetCommaText: WideString;
begin
  Result := '';
end;

{ TWideStrings.GetDelimitedText }
function TWideStrings.GetDelimitedText: WideString;
begin
  Result := '';
end;

{ TWideStrings.GetName }
function TWideStrings.GetName(Index: Integer): WideString;
begin
  Result := '';
end;

{ TWideStrings.GetValue }
function TWideStrings.GetValue(const Name: WideString): WideString;
begin
  Result := '';
end;

{ TWideStrings.GetValueFromIndex }
function TWideStrings.GetValueFromIndex(Index: Integer): WideString;
begin
  Result := '';
end;

{ TWideStrings.GetTextStr }
function TWideStrings.GetTextStr: WideString;
begin
  Result := '';
end;

{ TWideStrings.SetCommaText }
procedure TWideStrings.SetCommaText(const Value: WideString);
begin
end;

{ TWideStrings.SetDelimitedText }
procedure TWideStrings.SetDelimitedText(const Value: WideString);
begin
end;

{ TWideStrings.SetValue }
procedure TWideStrings.SetValue(const Name, Value: WideString);
begin
end;

{ TWideStrings.SetValueFromIndex }
procedure TWideStrings.SetValueFromIndex(Index: Integer; const Value: WideString);
begin
end;

{ TWideStrings.SetTextStr }
procedure TWideStrings.SetTextStr(const Value: WideString);
begin
end;

{ TWideStrings.DefineProperties }
procedure TWideStrings.DefineProperties(Filer: TFiler);
begin
end;

{ TWideStrings.Error }
procedure TWideStrings.Error(const Msg: WideString; Data: Integer);
begin
end;

{ TWideStrings.Error }
procedure TWideStrings.Error(Msg: PResStringRec; Data: Integer);
begin
end;

{ TWideStrings.GetCapacity }
function TWideStrings.GetCapacity: Integer;
begin
  Result := 0;
end;

{ TWideStrings.GetObject }
function TWideStrings.GetObject(Index: Integer): TObject;
begin
  Result := nil;
end;

{ TWideStrings.Put }
procedure TWideStrings.Put(Index: Integer; const S: WideString);
begin
end;

{ TWideStrings.PutObject }
procedure TWideStrings.PutObject(Index: Integer; AObject: TObject);
begin
end;

{ TWideStrings.SetCapacity }
procedure TWideStrings.SetCapacity(NewCapacity: Integer);
begin
end;

{ TWideStrings.SetUpdateState }
procedure TWideStrings.SetUpdateState(Updating: Boolean);
begin
end;

{ TWideStrings.Destroy }
destructor TWideStrings.Destroy;
begin
  inherited;
end;

{ TWideStrings.Add }
function TWideStrings.Add(const S: WideString): Integer;
begin
  Result := 0;
end;

{ TWideStrings.AddObject }
function TWideStrings.AddObject(const S: WideString; AObject: TObject): Integer;
begin
  Result := 0;
end;

{ TWideStrings.AddStrings }
procedure TWideStrings.AddStrings(Strings: TWideStrings);
begin
end;

{ TWideStrings.AddStrings }
procedure TWideStrings.AddStrings(const Strings: array of WideString);
begin
end;

{ TWideStrings.Append }
procedure TWideStrings.Append(const S: WideString);
begin
end;

{ TWideStrings.Assign }
procedure TWideStrings.Assign(Source: TPersistent);
begin
end;

{ TWideStrings.BeginUpdate }
procedure TWideStrings.BeginUpdate;
begin
end;

{ TWideStrings.EndUpdate }
procedure TWideStrings.EndUpdate;
begin
end;

{ TWideStrings.Equals }
function TWideStrings.Equals(Strings: TWideStrings): Boolean;
begin
  Result := False;
end;

{ TWideStrings.Exchange }
procedure TWideStrings.Exchange(Index1, Index2: Integer);
begin
end;

{ TWideStrings.GetEnumerator }
function TWideStrings.GetEnumerator: TWideStringsEnumerator;
begin
  Result := nil;
end;

{ TWideStrings.IndexOf }
function TWideStrings.IndexOf(const S: WideString): Integer;
begin
  Result := 0;
end;

{ TWideStrings.IndexOfName }
function TWideStrings.IndexOfName(const Name: WideString): Integer;
begin
  Result := 0;
end;

{ TWideStrings.IndexOfObject }
function TWideStrings.IndexOfObject(AObject: TObject): Integer;
begin
  Result := 0;
end;

{ TWideStrings.InsertObject }
procedure TWideStrings.InsertObject(Index: Integer; const S: WideString; AObject: TObject);
begin
end;

{ TWideStrings.LoadFromFile }
procedure TWideStrings.LoadFromFile(const FileName: WideString);
begin
end;

{ TWideStrings.LoadFromFile }
procedure TWideStrings.LoadFromFile(const FileName: WideString; Encoding: TEncoding);
begin
end;

{ TWideStrings.LoadFromStream }
procedure TWideStrings.LoadFromStream(Stream: TStream);
begin
end;

{ TWideStrings.LoadFromStream }
procedure TWideStrings.LoadFromStream(Stream: TStream; Encoding: TEncoding);
begin
end;

{ TWideStrings.Move }
procedure TWideStrings.Move(CurIndex, NewIndex: Integer);
begin
end;

{ TWideStrings.SaveToFile }
procedure TWideStrings.SaveToFile(const FileName: WideString);
begin
end;

{ TWideStrings.SaveToFile }
procedure TWideStrings.SaveToFile(const FileName: WideString; Encoding: TEncoding);
begin
end;

{ TWideStrings.SaveToStream }
procedure TWideStrings.SaveToStream(Stream: TStream);
begin
end;

{ TWideStrings.SaveToStream }
procedure TWideStrings.SaveToStream(Stream: TStream; Encoding: TEncoding);
begin
end;

{ TWideStrings.SetText }
procedure TWideStrings.SetText(Text: PWideChar);
begin
end;

{ TWideStrings.GetText }
function TWideStrings.GetText: PWideChar;
begin
  Result := nil;
end;

{ TWideStringList.Changed }
procedure TWideStringList.Changed;
begin
end;

{ TWideStringList.Changing }
procedure TWideStringList.Changing;
begin
end;

{ TWideStringList.CompareStrings }
function TWideStringList.CompareStrings(const S1, S2: WideString): Integer;
begin
  Result := 0;
end;

{ TWideStringList.Get }
function TWideStringList.Get(Index: Integer): WideString;
begin
  Result := '';
end;

{ TWideStringList.GetCapacity }
function TWideStringList.GetCapacity: Integer;
begin
  Result := 0;
end;

{ TWideStringList.GetCount }
function TWideStringList.GetCount: Integer;
begin
  Result := 0;
end;

{ TWideStringList.GetObject }
function TWideStringList.GetObject(Index: Integer): TObject;
begin
  Result := nil;
end;

{ TWideStringList.Put }
procedure TWideStringList.Put(Index: Integer; const S: WideString);
begin
end;

{ TWideStringList.PutObject }
procedure TWideStringList.PutObject(Index: Integer; AObject: TObject);
begin
end;

{ TWideStringList.SetCapacity }
procedure TWideStringList.SetCapacity(NewCapacity: Integer);
begin
end;

{ TWideStringList.SetUpdateState }
procedure TWideStringList.SetUpdateState(Updating: Boolean);
begin
end;

{ TWideStringList.Create }
constructor TWideStringList.Create;
begin
  inherited Create;
end;

{ TWideStringList.Destroy }
destructor TWideStringList.Destroy;
begin
  inherited;
end;

{ TWideStringList.Add }
function TWideStringList.Add(const S: WideString): Integer;
begin
  Result := 0;
end;

{ TWideStringList.Clear }
procedure TWideStringList.Clear;
begin
end;

{ TWideStringList.Delete }
procedure TWideStringList.Delete(Index: Integer);
begin
end;

{ TWideStringList.Exchange }
procedure TWideStringList.Exchange(Index1, Index2: Integer);
begin
end;

{ TWideStringList.Find }
function TWideStringList.Find(const S: WideString; var Index: Integer): Boolean;
begin
  Result := False;
end;

{ TWideStringList.IndexOf }
function TWideStringList.IndexOf(const S: WideString): Integer;
begin
  Result := 0;
end;

{ TWideStringList.Insert }
procedure TWideStringList.Insert(Index: Integer; const S: WideString);
begin
end;

{ TWideStringList.Sort }
procedure TWideStringList.Sort;
begin
end;

{ TWideStringList.CustomSort }
procedure TWideStringList.CustomSort(Compare: TWideStringListSortCompare);
begin
end;

{ TWideStringsEnumerator.GetCurrent }
function TWideStringsEnumerator.GetCurrent: WideString;
begin
  Result := '';
end;

{ TWideStringsEnumerator.Create }
constructor TWideStringsEnumerator.Create(AStrings: TWideStrings);
begin
  inherited Create;
end;

{ TWideStringsEnumerator.MoveNext }
function TWideStringsEnumerator.MoveNext: Boolean;
begin
  Result := False;
end;

end.
