{
  D2CSharp test file

  Original source language: Delphi (Pascal).
  The corresponding C# files are automatically translated from the
  Delphi source files by D2CSharp.
  This notice is retained unchanged in both versions.

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

unit system_inifiles;

interface

function SIF_RunAllTests: Boolean;

implementation

// TCustomIniFile.ReadInt64/WriteInt64 first appeared in Delphi 10.4.
// Delphi XE3: CompilerVersion = 24.0; Delphi 10.4: CompilerVersion = 34.0.
{$IF CompilerVersion >= 34.0}
  {$DEFINE SIF_HAS_INI_INT64}
{$IFEND}

// TMemIniFile.Modified and AutoSave were introduced in Delphi 10.1 Berlin.
// Delphi 10.1 Berlin: CompilerVersion = 31.0.
{$IF CompilerVersion >= 31.0}
  {$DEFINE SIF_HAS_MEM_MODIFIED_AUTOSAVE}
{$IFEND}

uses
  System.SysUtils,
  System.Classes,
  System.IniFiles;

// Every test uses its own temporary files. No VCL dependency.
// Only the common runner is declared in the interface section.

type
  TSIF_Workspace = class
  private
    FFileName: string;
    FOtherFileName: string;
  public
    constructor Create;
    destructor Destroy; override;
    property FileName: string read FFileName;
    property OtherFileName: string read FOtherFileName;
  end;

constructor TSIF_Workspace.Create;
var
  G: TGUID;
  P: string;
  N: string;
begin
  inherited Create;
  if CreateGUID(G) <> 0 then
    raise Exception.Create('SIF: Cannot create temporary file name');
  P := GetEnvironmentVariable('TEMP');
  if P = '' then
    P := GetEnvironmentVariable('TMP');
  if P = '' then
    P := GetCurrentDir;
  N := 'd2c_sif_' + Copy(GUIDToString(G), 2, 36);
  FFileName := IncludeTrailingPathDelimiter(P) + N + '.ini';
  FOtherFileName := IncludeTrailingPathDelimiter(P) + N + '_other.ini';
end;

destructor TSIF_Workspace.Destroy;
begin
  try
    if (FFileName <> '') and FileExists(FFileName) then
      DeleteFile(FFileName);
    if (FOtherFileName <> '') and FileExists(FOtherFileName) then
      DeleteFile(FOtherFileName);
  finally
    inherited Destroy;
  end;
end;

function SIF_Close(const A, B: Double): Boolean;
begin
  Result := Abs(A - B) < 0.000001;
end;

function SIF_TestMemFileName: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Result := Ini.FileName = W.FileName;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemMissingString: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Result := Ini.ReadString('Unknown', 'X', 'fallback') = 'fallback';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemMissingInteger: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Result := Ini.ReadInteger('Unknown', 'X', 12345) = 12345;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemMissingBool: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Result := Ini.ReadBool('Unknown', 'X', True);
        Result := Result and (not Ini.ReadBool('Unknown', 'X', False));
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemMissingFloat: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Result := SIF_Close(Ini.ReadFloat('Unknown', 'X', 7.125), 7.125);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestMemMissingInt64: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Result := Ini.ReadInt64('Unknown', 'X', Int64(9876543210)) = Int64(9876543210);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

function SIF_TestMemMissingDate: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        D := EncodeDate(2021, 2, 3);
        Result := Ini.ReadDate('Unknown', 'X', D) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemMissingTime: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        D := EncodeTime(11, 12, 13, 0);
        Result := Ini.ReadTime('Unknown', 'X', D) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemMissingDateTime: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        D := EncodeDate(2021, 2, 3) + EncodeTime(11, 12, 13, 0);
        Result := Ini.ReadDateTime('Unknown', 'X', D) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReadString: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('General', 'Name', 'Example');
        Result := Ini.ReadString('General', 'Name', '') = 'Example';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteEmptyString: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('General', 'Blank', '');
        Result := Ini.ReadString('General', 'Blank', 'fallback') = '';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemOverwriteString: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('General', 'Name', 'First');
        Ini.WriteString('General', 'Name', 'Second');
        Result := Ini.ReadString('General', 'Name', '') = 'Second';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemDifferentKeys: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('General', 'A', 'one');
        Ini.WriteString('General', 'B', 'two');
        Result := Ini.ReadString('General', 'A', '') = 'one';
        Result := Result and (Ini.ReadString('General', 'B', '') = 'two');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemDifferentSections: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('First', 'Key', 'A');
        Ini.WriteString('Second', 'Key', 'B');
        Result := Ini.ReadString('First', 'Key', '') = 'A';
        Result := Result and (Ini.ReadString('Second', 'Key', '') = 'B');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteIntegerPositive: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Numbers', 'Count', 123456);
        Result := Ini.ReadInteger('Numbers', 'Count', -1) = 123456;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteIntegerNegative: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Numbers', 'Count', -32768);
        Result := Ini.ReadInteger('Numbers', 'Count', 0) = -32768;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteIntegerZero: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Numbers', 'Count', 0);
        Result := Ini.ReadInteger('Numbers', 'Count', 100) = 0;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteIntegerMax: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Numbers', 'Count', MaxInt);
        Result := Ini.ReadInteger('Numbers', 'Count', 0) = MaxInt;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReadIntegerInvalid: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Numbers', 'Count', 'not_a_number');
        Result := Ini.ReadInteger('Numbers', 'Count', 77) = 77;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestMemWriteInt64Positive: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInt64('Numbers', 'Big', Int64(5000000000));
        Result := Ini.ReadInt64('Numbers', 'Big', 0) = Int64(5000000000);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestMemWriteInt64Negative: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInt64('Numbers', 'Big', -Int64(5000000000));
        Result := Ini.ReadInt64('Numbers', 'Big', 0) = -Int64(5000000000);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

function SIF_TestMemWriteBoolTrue: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteBool('Flags', 'Enabled', True);
        Result := Ini.ReadBool('Flags', 'Enabled', False);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteBoolFalse: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteBool('Flags', 'Enabled', False);
        Result := not Ini.ReadBool('Flags', 'Enabled', True);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteFloatPositive: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteFloat('Numbers', 'Rate', 12.375);
        Result := SIF_Close(Ini.ReadFloat('Numbers', 'Rate', 0), 12.375);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteFloatNegative: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteFloat('Numbers', 'Rate', -0.125);
        Result := SIF_Close(Ini.ReadFloat('Numbers', 'Rate', 0), -0.125);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteDate: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        D := EncodeDate(2020, 5, 17);
        Ini.WriteDate('Dates', 'D', D);
        Result := Ini.ReadDate('Dates', 'D', 0) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteTime: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        D := EncodeTime(13, 45, 20, 0);
        Ini.WriteTime('Dates', 'T', D);
        Result := Ini.ReadTime('Dates', 'T', 0) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemWriteDateTime: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        D := EncodeDate(2020, 5, 17) + EncodeTime(13, 45, 20, 0);
        Ini.WriteDateTime('Dates', 'DT', D);
        Result := Ini.ReadDateTime('Dates', 'DT', 0) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemSectionExists: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Present', 'Key', 'Value');
        Result := Ini.SectionExists('Present');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemSectionMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Present', 'Key', 'Value');
        Result := not Ini.SectionExists('Absent');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemValueExists: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Present', 'Key', 'Value');
        Result := Ini.ValueExists('Present', 'Key');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemValueMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Present', 'Key', 'Value');
        Result := not Ini.ValueExists('Present', 'Missing');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReadSections: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Alpha', 'A', 'one');
        Ini.WriteString('Beta', 'B', 'two');
        L := TStringList.Create;
        try
          Ini.ReadSections(L);
          Result := (L.Count = 2) and (L.IndexOf('Alpha') >= 0)
            and (L.IndexOf('Beta') >= 0);
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReadSectionsEmpty: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        L := TStringList.Create;
        try
          Ini.ReadSections(L);
          Result := L.Count = 0;
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReadSection: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Alpha', 'One', 'a');
        Ini.WriteString('Alpha', 'Two', 'b');
        L := TStringList.Create;
        try
          Ini.ReadSection('Alpha', L);
          Result := (L.Count = 2) and (L.IndexOf('One') >= 0)
            and (L.IndexOf('Two') >= 0);
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReadSectionMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        L := TStringList.Create;
        try
          Ini.ReadSection('Missing', L);
          Result := L.Count = 0;
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReadSectionValues: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Alpha', 'One', 'a');
        Ini.WriteString('Alpha', 'Two', 'b');
        L := TStringList.Create;
        try
          Ini.ReadSectionValues('Alpha', L);
          Result := (L.Count = 2) and (L.Values['One'] = 'a')
            and (L.Values['Two'] = 'b');
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReadSectionValuesMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        L := TStringList.Create;
        try
          Ini.ReadSectionValues('Missing', L);
          Result := L.Count = 0;
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemDeleteKey: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Group', 'Keep', 'A');
        Ini.WriteString('Group', 'Remove', 'B');
        Ini.DeleteKey('Group', 'Remove');
        Result := not Ini.ValueExists('Group', 'Remove');
        Result := Result and (Ini.ReadString('Group', 'Keep', '') = 'A');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemEraseSection: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Keep', 'X', '1');
        Ini.WriteString('Remove', 'X', '2');
        Ini.EraseSection('Remove');
        Result := not Ini.SectionExists('Remove');
        Result := Result and (Ini.ReadString('Keep', 'X', '') = '1');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemOverwriteType: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Group', 'Key', 100);
        Ini.WriteString('Group', 'Key', 'Text');
        Result := Ini.ReadString('Group', 'Key', '') = 'Text';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemUpdateFile: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Persist', 'Key', 'Saved');
        Ini.UpdateFile;
        Result := FileExists(W.FileName);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileFileName: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Result := Ini.FileName = W.FileName;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileMissingString: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Result := Ini.ReadString('Unknown', 'X', 'fallback') = 'fallback';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileMissingInteger: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Result := Ini.ReadInteger('Unknown', 'X', 12345) = 12345;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileMissingBool: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Result := Ini.ReadBool('Unknown', 'X', True);
        Result := Result and (not Ini.ReadBool('Unknown', 'X', False));
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileMissingFloat: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Result := SIF_Close(Ini.ReadFloat('Unknown', 'X', 7.125), 7.125);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestFileMissingInt64: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Result := Ini.ReadInt64('Unknown', 'X', Int64(9876543210)) = Int64(9876543210);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

function SIF_TestFileMissingDate: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        D := EncodeDate(2021, 2, 3);
        Result := Ini.ReadDate('Unknown', 'X', D) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileMissingTime: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        D := EncodeTime(11, 12, 13, 0);
        Result := Ini.ReadTime('Unknown', 'X', D) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileMissingDateTime: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        D := EncodeDate(2021, 2, 3) + EncodeTime(11, 12, 13, 0);
        Result := Ini.ReadDateTime('Unknown', 'X', D) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileReadString: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('General', 'Name', 'Example');
        Result := Ini.ReadString('General', 'Name', '') = 'Example';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteEmptyString: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('General', 'Blank', '');
        Result := Ini.ReadString('General', 'Blank', 'fallback') = '';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileOverwriteString: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('General', 'Name', 'First');
        Ini.WriteString('General', 'Name', 'Second');
        Result := Ini.ReadString('General', 'Name', '') = 'Second';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileDifferentKeys: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('General', 'A', 'one');
        Ini.WriteString('General', 'B', 'two');
        Result := Ini.ReadString('General', 'A', '') = 'one';
        Result := Result and (Ini.ReadString('General', 'B', '') = 'two');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileDifferentSections: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('First', 'Key', 'A');
        Ini.WriteString('Second', 'Key', 'B');
        Result := Ini.ReadString('First', 'Key', '') = 'A';
        Result := Result and (Ini.ReadString('Second', 'Key', '') = 'B');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteIntegerPositive: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Numbers', 'Count', 123456);
        Result := Ini.ReadInteger('Numbers', 'Count', -1) = 123456;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteIntegerNegative: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Numbers', 'Count', -32768);
        Result := Ini.ReadInteger('Numbers', 'Count', 0) = -32768;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteIntegerZero: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Numbers', 'Count', 0);
        Result := Ini.ReadInteger('Numbers', 'Count', 100) = 0;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteIntegerMax: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Numbers', 'Count', MaxInt);
        Result := Ini.ReadInteger('Numbers', 'Count', 0) = MaxInt;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileReadIntegerInvalid: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Numbers', 'Count', 'not_a_number');
        Result := Ini.ReadInteger('Numbers', 'Count', 77) = 77;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestFileWriteInt64Positive: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteInt64('Numbers', 'Big', Int64(5000000000));
        Result := Ini.ReadInt64('Numbers', 'Big', 0) = Int64(5000000000);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestFileWriteInt64Negative: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteInt64('Numbers', 'Big', -Int64(5000000000));
        Result := Ini.ReadInt64('Numbers', 'Big', 0) = -Int64(5000000000);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

function SIF_TestFileWriteBoolTrue: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteBool('Flags', 'Enabled', True);
        Result := Ini.ReadBool('Flags', 'Enabled', False);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteBoolFalse: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteBool('Flags', 'Enabled', False);
        Result := not Ini.ReadBool('Flags', 'Enabled', True);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteFloatPositive: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteFloat('Numbers', 'Rate', 12.375);
        Result := SIF_Close(Ini.ReadFloat('Numbers', 'Rate', 0), 12.375);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteFloatNegative: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteFloat('Numbers', 'Rate', -0.125);
        Result := SIF_Close(Ini.ReadFloat('Numbers', 'Rate', 0), -0.125);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteDate: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        D := EncodeDate(2020, 5, 17);
        Ini.WriteDate('Dates', 'D', D);
        Result := Ini.ReadDate('Dates', 'D', 0) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteTime: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        D := EncodeTime(13, 45, 20, 0);
        Ini.WriteTime('Dates', 'T', D);
        Result := Ini.ReadTime('Dates', 'T', 0) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileWriteDateTime: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  D: TDateTime;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        D := EncodeDate(2020, 5, 17) + EncodeTime(13, 45, 20, 0);
        Ini.WriteDateTime('Dates', 'DT', D);
        Result := Ini.ReadDateTime('Dates', 'DT', 0) = D;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileSectionExists: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Present', 'Key', 'Value');
        Result := Ini.SectionExists('Present');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileSectionMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Present', 'Key', 'Value');
        Result := not Ini.SectionExists('Absent');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileValueExists: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Present', 'Key', 'Value');
        Result := Ini.ValueExists('Present', 'Key');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileValueMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Present', 'Key', 'Value');
        Result := not Ini.ValueExists('Present', 'Missing');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileReadSections: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Alpha', 'A', 'one');
        Ini.WriteString('Beta', 'B', 'two');
        L := TStringList.Create;
        try
          Ini.ReadSections(L);
          Result := (L.Count = 2) and (L.IndexOf('Alpha') >= 0)
            and (L.IndexOf('Beta') >= 0);
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileReadSectionsEmpty: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        L := TStringList.Create;
        try
          Ini.ReadSections(L);
          Result := L.Count = 0;
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileReadSection: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Alpha', 'One', 'a');
        Ini.WriteString('Alpha', 'Two', 'b');
        L := TStringList.Create;
        try
          Ini.ReadSection('Alpha', L);
          Result := (L.Count = 2) and (L.IndexOf('One') >= 0)
            and (L.IndexOf('Two') >= 0);
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileReadSectionMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        L := TStringList.Create;
        try
          Ini.ReadSection('Missing', L);
          Result := L.Count = 0;
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileReadSectionValues: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Alpha', 'One', 'a');
        Ini.WriteString('Alpha', 'Two', 'b');
        L := TStringList.Create;
        try
          Ini.ReadSectionValues('Alpha', L);
          Result := (L.Count = 2) and (L.Values['One'] = 'a')
            and (L.Values['Two'] = 'b');
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileReadSectionValuesMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        L := TStringList.Create;
        try
          Ini.ReadSectionValues('Missing', L);
          Result := L.Count = 0;
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileDeleteKey: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Group', 'Keep', 'A');
        Ini.WriteString('Group', 'Remove', 'B');
        Ini.DeleteKey('Group', 'Remove');
        Result := not Ini.ValueExists('Group', 'Remove');
        Result := Result and (Ini.ReadString('Group', 'Keep', '') = 'A');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileEraseSection: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Keep', 'X', '1');
        Ini.WriteString('Remove', 'X', '2');
        Ini.EraseSection('Remove');
        Result := not Ini.SectionExists('Remove');
        Result := Result and (Ini.ReadString('Keep', 'X', '') = '1');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileOverwriteType: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteInteger('Group', 'Key', 100);
        Ini.WriteString('Group', 'Key', 'Text');
        Result := Ini.ReadString('Group', 'Key', '') = 'Text';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileUpdateFile: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Persist', 'Key', 'Saved');
        Ini.UpdateFile;
        Result := FileExists(W.FileName);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemDefaultCaseInsensitive: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Section', 'Name', 'Value');
        Result := Ini.ReadString('section', 'name', '') = 'Value';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemCaseSensitiveKeys: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.CaseSensitive := True;
        Ini.WriteString('Group', 'Name', 'Upper');
        Ini.WriteString('Group', 'name', 'Lower');
        Result := Ini.ReadString('Group', 'Name', '') = 'Upper';
        Result := Result and (Ini.ReadString('Group', 'name', '') = 'Lower');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemCaseSensitiveSections: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.CaseSensitive := True;
        Ini.WriteString('Group', 'Name', 'Upper');
        Ini.WriteString('group', 'Name', 'Lower');
        Result := Ini.ReadString('Group', 'Name', '') = 'Upper';
        Result := Result and (Ini.ReadString('group', 'Name', '') = 'Lower');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemCaseSensitiveProperty: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.CaseSensitive := True;
        Result := Ini.CaseSensitive;
        Ini.CaseSensitive := False;
        Result := Result and (not Ini.CaseSensitive);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$IFDEF SIF_HAS_MEM_MODIFIED_AUTOSAVE}
function SIF_TestMemModifiedInitially: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Result := not Ini.Modified;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemModifiedAfterWrite: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Test', 'Key', 'Value');
        Result := Ini.Modified;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemModifiedAfterUpdate: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Test', 'Key', 'Value');
        Ini.UpdateFile;
        Result := not Ini.Modified;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemAutoSaveProperty: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.AutoSave := True;
        Result := Ini.AutoSave;
        Ini.AutoSave := False;
        Result := Result and (not Ini.AutoSave);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$ENDIF}

function SIF_TestMemClear: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Alpha', 'A', '1');
        Ini.WriteString('Beta', 'B', '2');
        Ini.Clear;
        Result := not Ini.SectionExists('Alpha');
        Result := Result and (not Ini.SectionExists('Beta'));
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemGetStrings: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Alpha', 'A', 'one');
        L := TStringList.Create;
        try
          Ini.GetStrings(L);
          Result := (L.IndexOf('[Alpha]') >= 0) and (L.IndexOf('A=one') >= 0);
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemSetStrings: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Old', 'Key', 'OldValue');
        L := TStringList.Create;
        try
          L.Add('[New]');
          L.Add('Key=NewValue');
          Ini.SetStrings(L);
          Result := Ini.ReadString('New', 'Key', '') = 'NewValue';
          Result := Result and (not Ini.SectionExists('Old'));
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemValuesInMemoryBeforeSave: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'Buffered');
        Result := Ini.ReadString('Main', 'Key', '') = 'Buffered';
        Result := Result and (not FileExists(W.FileName));
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemPersistence: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'Persisted');
        Ini.UpdateFile;
        Other := TMemIniFile.Create(W.FileName);
        try
          Result := Other.ReadString('Main', 'Key', '') = 'Persisted';
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemSnapshotBeforeUpdate: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'Original');
        Ini.UpdateFile;
        Ini.WriteString('Main', 'Key', 'Buffered');
        Other := TMemIniFile.Create(W.FileName);
        try
          Result := Other.ReadString('Main', 'Key', '') = 'Original';
          Result := Result and (Ini.ReadString('Main', 'Key', '') = 'Buffered');
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$IFDEF SIF_HAS_MEM_MODIFIED_AUTOSAVE}
function SIF_TestMemAutoSave: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.AutoSave := True;
        Ini.WriteString('Main', 'Key', 'SavedOnFree');
        Ini.Free;
        Ini := nil;
        Other := TMemIniFile.Create(W.FileName);
        try
          Result := Other.ReadString('Main', 'Key', '') = 'SavedOnFree';
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$ENDIF}

function SIF_TestMemNoImplicitSave: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'OnlyMemory');
        Ini.Free;
        Ini := nil;
        Result := not FileExists(W.FileName);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemReloadFromDisk: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'First');
        Ini.UpdateFile;
        Ini.Free;
        Ini := nil;
        Ini := TMemIniFile.Create(W.FileName);
        Result := Ini.ReadString('Main', 'Key', '') = 'First';
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemUpdateOverwrite: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'First');
        Ini.UpdateFile;
        Ini.WriteString('Main', 'Key', 'Second');
        Ini.UpdateFile;
        Other := TMemIniFile.Create(W.FileName);
        try
          Result := Other.ReadString('Main', 'Key', '') = 'Second';
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemDeletePersisted: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'First');
        Ini.UpdateFile;
        Ini.DeleteKey('Main', 'Key');
        Ini.UpdateFile;
        Other := TMemIniFile.Create(W.FileName);
        try
          Result := not Other.ValueExists('Main', 'Key');
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemErasePersisted: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'First');
        Ini.UpdateFile;
        Ini.EraseSection('Main');
        Ini.UpdateFile;
        Other := TMemIniFile.Create(W.FileName);
        try
          Result := not Other.SectionExists('Main');
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemRenameNoReload: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'Buffered');
        Ini.Rename(W.OtherFileName, False);
        Result := Ini.FileName = W.OtherFileName;
        Result := Result and (Ini.ReadString('Main', 'Key', '') = 'Buffered');
        Ini.UpdateFile;
        Other := TMemIniFile.Create(W.OtherFileName);
        try
          Result := Result and (Other.ReadString('Main', 'Key', '') = 'Buffered');
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemRenameReload: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'First');
        Ini.UpdateFile;
        Other := TMemIniFile.Create(W.OtherFileName);
        try
          Other.WriteString('Main', 'Key', 'Second');
          Other.UpdateFile;
        finally
          Other.Free;
        end;
        Ini.Rename(W.OtherFileName, True);
        Result := Ini.FileName = W.OtherFileName;
        Result := Result and (Ini.ReadString('Main', 'Key', '') = 'Second');
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemSetStringsComments: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  L: TStringList;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        L := TStringList.Create;
        try
          L.Add('; comment');
          L.Add('[Section]');
          L.Add('Key=Value');
          Ini.SetStrings(L);
          Result := Ini.ReadString('Section', 'Key', '') = 'Value';
        finally
          L.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestMemWriteAndReadInt64Max: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInt64('Numbers', 'Big', High(Int64));
        Result := Ini.ReadInt64('Numbers', 'Big', 0) = High(Int64);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestMemWriteAndReadInt64Min: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteInt64('Numbers', 'Big', Low(Int64));
        Result := Ini.ReadInt64('Numbers', 'Big', 0) = Low(Int64);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

{$IFDEF SIF_HAS_INI_INT64}
function SIF_TestMemInvalidInt64: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Numbers', 'Big', 'invalid');
        Result := Ini.ReadInt64('Numbers', 'Big', 33) = 33;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;
{$ENDIF}

function SIF_TestMemEncodingCreate: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Other: TMemIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.Free;
        Ini := nil;
        Ini := TMemIniFile.Create(W.FileName, TEncoding.UTF8);
        Ini.WriteString('Text', 'Key', 'Ascii');
        Ini.UpdateFile;
        Other := TMemIniFile.Create(W.FileName, TEncoding.UTF8);
        try
          Result := Other.ReadString('Text', 'Key', '') = 'Ascii';
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemBinaryStream: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Data: array[0..4] of Byte;
  Got: array[0..4] of Byte;
  Src: TMemoryStream;
  Dst: TMemoryStream;
  I: Integer;
  N: Integer;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Data[0] := 0;
        Data[1] := 1;
        Data[2] := 127;
        Data[3] := 255;
        Data[4] := 42;
        Src := TMemoryStream.Create;
        try
          Src.WriteBuffer(Data, SizeOf(Data));
          Src.Position := 0;
          Ini.WriteBinaryStream('Data', 'Bytes', Src);
          Dst := TMemoryStream.Create;
          try
            N := Ini.ReadBinaryStream('Data', 'Bytes', Dst);
            Result := (N = SizeOf(Data)) and (Dst.Size = SizeOf(Data));
            if Result then
            begin
              Dst.Position := 0;
              Dst.ReadBuffer(Got, SizeOf(Got));
              for I := 0 to High(Data) do
                Result := Result and (Got[I] = Data[I]);
            end;
          finally
            Dst.Free;
          end;
        finally
          Src.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestMemBinaryStreamMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TMemIniFile;
  Dst: TMemoryStream;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Dst := TMemoryStream.Create;
        try
          Result := Ini.ReadBinaryStream('Missing', 'Bytes', Dst) = 0;
          Result := Result and (Dst.Size = 0);
        finally
          Dst.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileBinaryStream: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  Data: array[0..4] of Byte;
  Got: array[0..4] of Byte;
  Src: TMemoryStream;
  Dst: TMemoryStream;
  I: Integer;
  N: Integer;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Data[0] := 0;
        Data[1] := 1;
        Data[2] := 127;
        Data[3] := 255;
        Data[4] := 42;
        Src := TMemoryStream.Create;
        try
          Src.WriteBuffer(Data, SizeOf(Data));
          Src.Position := 0;
          Ini.WriteBinaryStream('Data', 'Bytes', Src);
          Dst := TMemoryStream.Create;
          try
            N := Ini.ReadBinaryStream('Data', 'Bytes', Dst);
            Result := (N = SizeOf(Data)) and (Dst.Size = SizeOf(Data));
            if Result then
            begin
              Dst.Position := 0;
              Dst.ReadBuffer(Got, SizeOf(Got));
              for I := 0 to High(Data) do
                Result := Result and (Got[I] = Data[I]);
            end;
          finally
            Dst.Free;
          end;
        finally
          Src.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileBinaryStreamMissing: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  Dst: TMemoryStream;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Dst := TMemoryStream.Create;
        try
          Result := Ini.ReadBinaryStream('Missing', 'Bytes', Dst) = 0;
          Result := Result and (Dst.Size = 0);
        finally
          Dst.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileImmediatePersistence: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  Other: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'Direct');
        Other := TIniFile.Create(W.FileName);
        try
          Result := Other.ReadString('Main', 'Key', '') = 'Direct';
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFilePersistAfterDestroy: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  Other: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'Direct');
        Ini.Free;
        Ini := nil;
        Other := TIniFile.Create(W.FileName);
        try
          Result := Other.ReadString('Main', 'Key', '') = 'Direct';
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestFileDeletePersisted: Boolean;
var
  W: TSIF_Workspace;
  Ini: TIniFile;
  Other: TIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Main', 'Key', 'Direct');
        Ini.DeleteKey('Main', 'Key');
        Other := TIniFile.Create(W.FileName);
        try
          Result := not Other.ValueExists('Main', 'Key');
        finally
          Other.Free;
        end;
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestCustomMemDispatch: Boolean;
var
  W: TSIF_Workspace;
  Ini: TCustomIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TMemIniFile.Create(W.FileName);
      try
        Ini.WriteString('Virtual', 'Name', 'Works');
        Ini.WriteInteger('Virtual', 'Count', 10);
        Result := Ini.ReadString('Virtual', 'Name', '') = 'Works';
        Result := Result and (Ini.ReadInteger('Virtual', 'Count', 0) = 10);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

function SIF_TestCustomFileDispatch: Boolean;
var
  W: TSIF_Workspace;
  Ini: TCustomIniFile;
begin
  Result := False;
  try
    W := TSIF_Workspace.Create;
    try
      Ini := TIniFile.Create(W.FileName);
      try
        Ini.WriteString('Virtual', 'Name', 'Works');
        Ini.WriteInteger('Virtual', 'Count', 10);
        Result := Ini.ReadString('Virtual', 'Name', '') = 'Works';
        Result := Result and (Ini.ReadInteger('Virtual', 'Count', 0) = 10);
      finally
        Ini.Free;
      end;
    finally
      W.Free;
    end;
  except
    Result := False;
  end;
end;

// Eager boolean evaluation is required so every test runs in order.
// A C# translation must also preserve this behavior (boolean & rather than &&).
{$B+}
function SIF_RunAllTests: Boolean;
begin
  Result := True;

  Result := Result and SIF_TestMemFileName;
  Result := Result and SIF_TestMemMissingString;
  Result := Result and SIF_TestMemMissingInteger;
  Result := Result and SIF_TestMemMissingBool;
  Result := Result and SIF_TestMemMissingFloat;
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestMemMissingInt64;
{$ENDIF}
  Result := Result and SIF_TestMemMissingDate;
  Result := Result and SIF_TestMemMissingTime;
  Result := Result and SIF_TestMemMissingDateTime;
  Result := Result and SIF_TestMemReadString;
  Result := Result and SIF_TestMemWriteEmptyString;
  Result := Result and SIF_TestMemOverwriteString;
  Result := Result and SIF_TestMemDifferentKeys;
  Result := Result and SIF_TestMemDifferentSections;
  Result := Result and SIF_TestMemWriteIntegerPositive;
  Result := Result and SIF_TestMemWriteIntegerNegative;
  Result := Result and SIF_TestMemWriteIntegerZero;
  Result := Result and SIF_TestMemWriteIntegerMax;
  Result := Result and SIF_TestMemReadIntegerInvalid;
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestMemWriteInt64Positive;
{$ENDIF}
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestMemWriteInt64Negative;
{$ENDIF}
  Result := Result and SIF_TestMemWriteBoolTrue;
  Result := Result and SIF_TestMemWriteBoolFalse;
  Result := Result and SIF_TestMemWriteFloatPositive;
  Result := Result and SIF_TestMemWriteFloatNegative;
  Result := Result and SIF_TestMemWriteDate;
  Result := Result and SIF_TestMemWriteTime;
  Result := Result and SIF_TestMemWriteDateTime;
  Result := Result and SIF_TestMemSectionExists;
  Result := Result and SIF_TestMemSectionMissing;
  Result := Result and SIF_TestMemValueExists;
  Result := Result and SIF_TestMemValueMissing;
  Result := Result and SIF_TestMemReadSections;
  Result := Result and SIF_TestMemReadSectionsEmpty;
  Result := Result and SIF_TestMemReadSection;
  Result := Result and SIF_TestMemReadSectionMissing;
  Result := Result and SIF_TestMemReadSectionValues;
  Result := Result and SIF_TestMemReadSectionValuesMissing;
  Result := Result and SIF_TestMemDeleteKey;
  Result := Result and SIF_TestMemEraseSection;
  Result := Result and SIF_TestMemOverwriteType;
  Result := Result and SIF_TestMemUpdateFile;
  Result := Result and SIF_TestFileFileName;
  Result := Result and SIF_TestFileMissingString;
  Result := Result and SIF_TestFileMissingInteger;
  Result := Result and SIF_TestFileMissingBool;
  Result := Result and SIF_TestFileMissingFloat;
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestFileMissingInt64;
{$ENDIF}
  Result := Result and SIF_TestFileMissingDate;
  Result := Result and SIF_TestFileMissingTime;
  Result := Result and SIF_TestFileMissingDateTime;
  Result := Result and SIF_TestFileReadString;
  Result := Result and SIF_TestFileWriteEmptyString;
  Result := Result and SIF_TestFileOverwriteString;
  Result := Result and SIF_TestFileDifferentKeys;
  Result := Result and SIF_TestFileDifferentSections;
  Result := Result and SIF_TestFileWriteIntegerPositive;
  Result := Result and SIF_TestFileWriteIntegerNegative;
  Result := Result and SIF_TestFileWriteIntegerZero;
  Result := Result and SIF_TestFileWriteIntegerMax;
  Result := Result and SIF_TestFileReadIntegerInvalid;
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestFileWriteInt64Positive;
{$ENDIF}
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestFileWriteInt64Negative;
{$ENDIF}
  Result := Result and SIF_TestFileWriteBoolTrue;
  Result := Result and SIF_TestFileWriteBoolFalse;
  Result := Result and SIF_TestFileWriteFloatPositive;
  Result := Result and SIF_TestFileWriteFloatNegative;
  Result := Result and SIF_TestFileWriteDate;
  Result := Result and SIF_TestFileWriteTime;
  Result := Result and SIF_TestFileWriteDateTime;
  Result := Result and SIF_TestFileSectionExists;
  Result := Result and SIF_TestFileSectionMissing;
  Result := Result and SIF_TestFileValueExists;
  Result := Result and SIF_TestFileValueMissing;
  Result := Result and SIF_TestFileReadSections;
  Result := Result and SIF_TestFileReadSectionsEmpty;
  Result := Result and SIF_TestFileReadSection;
  Result := Result and SIF_TestFileReadSectionMissing;
  Result := Result and SIF_TestFileReadSectionValues;
  Result := Result and SIF_TestFileReadSectionValuesMissing;
  Result := Result and SIF_TestFileDeleteKey;
  Result := Result and SIF_TestFileEraseSection;
  Result := Result and SIF_TestFileOverwriteType;
  Result := Result and SIF_TestFileUpdateFile;
  Result := Result and SIF_TestMemDefaultCaseInsensitive;
  Result := Result and SIF_TestMemCaseSensitiveKeys;
  Result := Result and SIF_TestMemCaseSensitiveSections;
  Result := Result and SIF_TestMemCaseSensitiveProperty;
{$IFDEF SIF_HAS_MEM_MODIFIED_AUTOSAVE}
  Result := Result and SIF_TestMemModifiedInitially;
{$ENDIF}
{$IFDEF SIF_HAS_MEM_MODIFIED_AUTOSAVE}
  Result := Result and SIF_TestMemModifiedAfterWrite;
{$ENDIF}
{$IFDEF SIF_HAS_MEM_MODIFIED_AUTOSAVE}
  Result := Result and SIF_TestMemModifiedAfterUpdate;
{$ENDIF}
{$IFDEF SIF_HAS_MEM_MODIFIED_AUTOSAVE}
  Result := Result and SIF_TestMemAutoSaveProperty;
{$ENDIF}
  Result := Result and SIF_TestMemClear;
  Result := Result and SIF_TestMemGetStrings;
  Result := Result and SIF_TestMemSetStrings;
  Result := Result and SIF_TestMemValuesInMemoryBeforeSave;
  Result := Result and SIF_TestMemPersistence;
  Result := Result and SIF_TestMemSnapshotBeforeUpdate;
{$IFDEF SIF_HAS_MEM_MODIFIED_AUTOSAVE}
  Result := Result and SIF_TestMemAutoSave;
{$ENDIF}
  Result := Result and SIF_TestMemNoImplicitSave;
  Result := Result and SIF_TestMemReloadFromDisk;
  Result := Result and SIF_TestMemUpdateOverwrite;
  Result := Result and SIF_TestMemDeletePersisted;
  Result := Result and SIF_TestMemErasePersisted;
  Result := Result and SIF_TestMemRenameNoReload;
  Result := Result and SIF_TestMemRenameReload;
  Result := Result and SIF_TestMemSetStringsComments;
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestMemWriteAndReadInt64Max;
{$ENDIF}
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestMemWriteAndReadInt64Min;
{$ENDIF}
{$IFDEF SIF_HAS_INI_INT64}
  Result := Result and SIF_TestMemInvalidInt64;
{$ENDIF}
  Result := Result and SIF_TestMemEncodingCreate;
  Result := Result and SIF_TestMemBinaryStream;
  Result := Result and SIF_TestMemBinaryStreamMissing;
  Result := Result and SIF_TestFileBinaryStream;
  Result := Result and SIF_TestFileBinaryStreamMissing;
  Result := Result and SIF_TestFileImmediatePersistence;
  Result := Result and SIF_TestFilePersistAfterDestroy;
  Result := Result and SIF_TestFileDeletePersisted;
  Result := Result and SIF_TestCustomMemDispatch;
  Result := Result and SIF_TestCustomFileDispatch;
end;
{$B-}

end.
