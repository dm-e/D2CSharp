{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.IniFiles.
  This file supplies Delphi API signatures for source translation.
  Method bodies intentionally do not implement INI file operations.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit System.IniFiles;

interface

uses
  System.SysUtils,
  System.Classes;

type
  TCustomIniFile = class(TObject)
  private
    FFileName: string;
  public
    constructor Create(const FileName: string); virtual;
    function ReadString(const Section, Ident, Default: string): string; virtual;
    procedure WriteString(const Section, Ident, Value: string); virtual;
    procedure ReadSection(const Section: string; Strings: TStrings); virtual;
    procedure ReadSections(Strings: TStrings); overload; virtual;
    procedure ReadSections(const Section: string; Strings: TStrings); overload; virtual;
    procedure ReadSectionValues(const Section: string; Strings: TStrings); virtual;
    procedure EraseSection(const Section: string); virtual;
    procedure DeleteKey(const Section, Ident: string); virtual;
    procedure UpdateFile; virtual;

    function ReadInteger(const Section, Ident: string; Default: Longint): Longint; virtual;
    function ReadInt64(const Section, Ident: string; Default: Int64): Int64; virtual;
    function ReadBool(const Section, Ident: string; Default: Boolean): Boolean; virtual;
    function ReadFloat(const Section, Ident: string; Default: Double): Double; virtual;
    function ReadDate(const Section, Ident: string; Default: TDateTime): TDateTime; virtual;
    function ReadTime(const Section, Ident: string; Default: TDateTime): TDateTime; virtual;
    function ReadDateTime(const Section, Ident: string; Default: TDateTime): TDateTime; virtual;
    function ReadBinaryStream(const Section, Name: string; Value: TStream): Integer; virtual;

    procedure WriteInteger(const Section, Ident: string; Value: Longint); virtual;
    procedure WriteInt64(const Section, Ident: string; Value: Int64); virtual;
    procedure WriteBool(const Section, Ident: string; Value: Boolean); virtual;
    procedure WriteFloat(const Section, Ident: string; Value: Double); virtual;
    procedure WriteDate(const Section, Ident: string; Value: TDateTime); virtual;
    procedure WriteTime(const Section, Ident: string; Value: TDateTime); virtual;
    procedure WriteDateTime(const Section, Ident: string; Value: TDateTime); virtual;
    procedure WriteBinaryStream(const Section, Name: string; Value: TStream); virtual;

    function SectionExists(const Section: string): Boolean; virtual;
    function ValueExists(const Section, Ident: string): Boolean; virtual;
    property FileName: string read FFileName;
  end;

  TIniFile = class(TCustomIniFile)
  public
    constructor Create(const FileName: string); override;
  end;

  TMemIniFile = class(TCustomIniFile)
  private
    FAutoSave: Boolean;
    FModified: Boolean;
    FCaseSensitive: Boolean;
    FEncoding: TEncoding;
  public
    constructor Create(const FileName: string); overload; override;
    constructor Create(const FileName: string; const Encoding: TEncoding); reintroduce; overload;
    constructor Create(const FileName: string; const Encoding: TEncoding;
      CaseSensitive: Boolean); reintroduce; overload;
    destructor Destroy; override;
    procedure Clear; virtual;
    procedure Rename(const FileName: string; Reload: Boolean); virtual;
    procedure GetStrings(List: TStrings); virtual;
    procedure SetStrings(List: TStrings); virtual;
    property AutoSave: Boolean read FAutoSave write FAutoSave;
    property Modified: Boolean read FModified write FModified;
    property CaseSensitive: Boolean read FCaseSensitive write FCaseSensitive;
    property Encoding: TEncoding read FEncoding;
  end;

implementation


constructor TCustomIniFile.Create(const FileName: string);
begin
  FFileName := FileName;
end;

function TCustomIniFile.ReadString(const Section, Ident, Default: string): string;
begin
  Result := Default;
end;

procedure TCustomIniFile.WriteString(const Section, Ident, Value: string);
begin
end;

procedure TCustomIniFile.ReadSection(const Section: string; Strings: TStrings);
begin
end;

procedure TCustomIniFile.ReadSections(Strings: TStrings);
begin
end;

procedure TCustomIniFile.ReadSections(const Section: string; Strings: TStrings);
begin
end;

procedure TCustomIniFile.ReadSectionValues(const Section: string; Strings: TStrings);
begin
end;

procedure TCustomIniFile.EraseSection(const Section: string);
begin
end;

procedure TCustomIniFile.DeleteKey(const Section, Ident: string);
begin
end;

procedure TCustomIniFile.UpdateFile;
begin
end;

function TCustomIniFile.ReadInteger(const Section, Ident: string; Default: Longint): Longint;
begin
  Result := Default;
end;

function TCustomIniFile.ReadInt64(const Section, Ident: string; Default: Int64): Int64;
begin
  Result := Default;
end;

function TCustomIniFile.ReadBool(const Section, Ident: string; Default: Boolean): Boolean;
begin
  Result := Default;
end;

function TCustomIniFile.ReadFloat(const Section, Ident: string; Default: Double): Double;
begin
  Result := Default;
end;

function TCustomIniFile.ReadDate(const Section, Ident: string; Default: TDateTime): TDateTime;
begin
  Result := Default;
end;

function TCustomIniFile.ReadTime(const Section, Ident: string; Default: TDateTime): TDateTime;
begin
  Result := Default;
end;

function TCustomIniFile.ReadDateTime(const Section, Ident: string; Default: TDateTime): TDateTime;
begin
  Result := Default;
end;

function TCustomIniFile.ReadBinaryStream(const Section, Name: string; Value: TStream): Integer;
begin
  Result := 0;
end;

procedure TCustomIniFile.WriteInteger(const Section, Ident: string; Value: Longint);
begin
end;

procedure TCustomIniFile.WriteInt64(const Section, Ident: string; Value: Int64);
begin
end;

procedure TCustomIniFile.WriteBool(const Section, Ident: string; Value: Boolean);
begin
end;

procedure TCustomIniFile.WriteFloat(const Section, Ident: string; Value: Double);
begin
end;

procedure TCustomIniFile.WriteDate(const Section, Ident: string; Value: TDateTime);
begin
end;

procedure TCustomIniFile.WriteTime(const Section, Ident: string; Value: TDateTime);
begin
end;

procedure TCustomIniFile.WriteDateTime(const Section, Ident: string; Value: TDateTime);
begin
end;

procedure TCustomIniFile.WriteBinaryStream(const Section, Name: string; Value: TStream);
begin
end;

function TCustomIniFile.SectionExists(const Section: string): Boolean;
begin
  Result := False;
end;

function TCustomIniFile.ValueExists(const Section, Ident: string): Boolean;
begin
  Result := False;
end;

constructor TIniFile.Create(const FileName: string);
begin
  inherited Create(FileName);
end;

constructor TMemIniFile.Create(const FileName: string);
begin
  inherited Create(FileName);
end;

constructor TMemIniFile.Create(const FileName: string; const Encoding: TEncoding);
begin
  inherited Create(FileName);
  FEncoding := Encoding;
end;

constructor TMemIniFile.Create(const FileName: string; const Encoding: TEncoding;
  CaseSensitive: Boolean);
begin
  inherited Create(FileName);
  FEncoding := Encoding;
  FCaseSensitive := CaseSensitive;
end;

destructor TMemIniFile.Destroy;
begin
  inherited Destroy;
end;

procedure TMemIniFile.Clear;
begin
end;

procedure TMemIniFile.Rename(const FileName: string; Reload: Boolean);
begin
  FFileName := FileName;
end;

procedure TMemIniFile.GetStrings(List: TStrings);
begin
end;

procedure TMemIniFile.SetStrings(List: TStrings);
begin
end;

end.
