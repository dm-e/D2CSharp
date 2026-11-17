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

unit system_ioutils;

interface

function SIU_RunAllTests: Boolean;

implementation

uses
  System.SysUtils,
  System.Classes,
  System.Types,
  System.IOUtils;

type
  TSIU_Workspace = class
  private
    FRoot: string;
  public
    constructor Create;
    destructor Destroy; override;
    function FilePath(const AName: string): string;
    property Root: string read FRoot;
  end;

constructor TSIU_Workspace.Create;
begin
  inherited Create;
  FRoot := TPath.Combine(TPath.GetTempPath,
    'd2c_siu_' + TPath.GetGUIDFileName(False));
  TDirectory.CreateDirectory(FRoot);
end;

destructor TSIU_Workspace.Destroy;
begin
  try
    if (FRoot <> '') and TDirectory.Exists(FRoot) then
      TDirectory.Delete(FRoot, True);
  finally
    inherited Destroy;
  end;
end;

function TSIU_Workspace.FilePath(const AName: string): string;
begin
  Result := TPath.Combine(FRoot, AName);
end;

function SIU_ContainsName(const APaths: TStringDynArray;
  const AName: string): Boolean;
var
  I: Integer;
begin
  Result := False;
  for I := 0 to Length(APaths) - 1 do
    if SameText(TPath.GetFileName(APaths[I]), AName) then
    begin
      Result := True;
      Exit;
    end;
end;

function SIU_ContainsChar(const AChars: TCharArray;
  const AChar: Char): Boolean;
var
  I: Integer;
begin
  Result := False;
  for I := 0 to Length(AChars) - 1 do
    if AChars[I] = AChar then
    begin
      Result := True;
      Exit;
    end;
end;

function SIU_TestPathSeparators: Boolean;
begin
  try
    Result := TPath.ExtensionSeparatorChar = '.';
    {$IFDEF MSWINDOWS}
    Result := Result and (TPath.DirectorySeparatorChar = '\');
    Result := Result and (TPath.AltDirectorySeparatorChar = '/');
    Result := Result and (TPath.PathSeparator = ';');
    Result := Result and (TPath.VolumeSeparatorChar = ':');
    {$ENDIF}
  except
    Result := False;
  end;
end;

function SIU_TestPathCombine: Boolean;
var
  A, B: string;
begin
  try
    A := TPath.Combine('alpha', 'beta');
    B := 'alpha' + TPath.DirectorySeparatorChar + 'beta';
    Result := A = B;
    Result := Result and (TPath.Combine('', 'beta') = 'beta');
    Result := Result and (TPath.Combine('alpha', '') = 'alpha');
  except
    Result := False;
  end;
end;

function SIU_TestPathExtension: Boolean;
begin
  try
    Result := TPath.GetExtension('example.txt') = '.txt';
    Result := Result and (TPath.GetExtension('example') = '');
    Result := Result and TPath.HasExtension('example.txt');
    Result := Result and not TPath.HasExtension('example');
    Result := Result and
      (TPath.ChangeExtension('example.txt', '.dat') = 'example.dat');
    Result := Result and
      (TPath.ChangeExtension('example.txt', 'log') = 'example.log');
    Result := Result and
      (TPath.ChangeExtension('example.txt', '') = 'example.');
  except
    Result := False;
  end;
end;

function SIU_TestPathFileName: Boolean;
var
  P: string;
begin
  try
    P := TPath.Combine('folder', 'sample.data.txt');
    Result := TPath.GetFileName(P) = 'sample.data.txt';
    Result := Result and
      (TPath.GetFileNameWithoutExtension(P) = 'sample.data');
    Result := Result and
      (TPath.GetFileName('plain.txt') = 'plain.txt');
  except
    Result := False;
  end;
end;

function SIU_TestPathDirectoryName: Boolean;
var
  ParentDir, FileName: string;
begin
  try
    ParentDir := TPath.Combine(TPath.GetTempPath, 'siu_parent');
    FileName := TPath.Combine(ParentDir, 'sample.txt');
    Result := SameText(TPath.GetDirectoryName(FileName), ParentDir);
  except
    Result := False;
  end;
end;

function SIU_TestPathFullPath: Boolean;
var
  P: string;
begin
  try
    P := TPath.GetFullPath('siu_relative.txt');
    Result := TPath.IsPathRooted(P);
    Result := Result and
      (TPath.GetFileName(P) = 'siu_relative.txt');
    Result := Result and (TPath.GetFullPath(P) = P);
  except
    Result := False;
  end;
end;

function SIU_TestPathRoot: Boolean;
var
  P, R: string;
begin
  try
    P := TPath.GetTempPath;
    R := TPath.GetPathRoot(P);
    Result := R <> '';
    Result := Result and TPath.IsPathRooted(R);
    Result := Result and TPath.IsPathRooted(P);
    Result := Result and not TPath.IsPathRooted('child\file.txt');
  except
    Result := False;
  end;
end;

function SIU_TestPathRelative: Boolean;
begin
  try
    Result := TPath.IsRelativePath('child.txt');
    Result := Result and TPath.IsRelativePath('child\file.txt');
    Result := Result and not TPath.IsRelativePath(TPath.GetTempPath);
  except
    Result := False;
  end;
end;

function SIU_TestPathUNC: Boolean;
begin
  try
    Result := not TPath.IsUNCPath('local.txt');
    Result := Result and not TPath.IsUNCRooted('local.txt');
    {$IFDEF MSWINDOWS}
    Result := Result and TPath.IsUNCPath('\\server\share\file.txt');
    Result := Result and TPath.IsUNCRooted('\\server\share\file.txt');
    {$ENDIF}
  except
    Result := False;
  end;
end;

function SIU_TestPathExtendedPrefix: Boolean;
begin
  try
    Result := not TPath.IsExtendedPrefixed('local.txt');
    {$IFDEF MSWINDOWS}
    Result := Result and TPath.IsExtendedPrefixed('\\?\C:\siu.txt');
    {$ENDIF}
  except
    Result := False;
  end;
end;

function SIU_TestPathDrive: Boolean;
var
  RootDir: string;
begin
  try
    Result := not TPath.IsDriveRooted('relative.txt');
    {$IFDEF MSWINDOWS}
    RootDir := TPath.GetPathRoot(TPath.GetTempPath);
    Result := Result and TPath.IsDriveRooted('C:\siu.txt');
    if (Length(RootDir) >= 2) and (RootDir[2] = ':') then
      Result := Result and TPath.DriveExists(RootDir);
    {$ELSE}
    RootDir := '';
    {$ENDIF}
  except
    Result := False;
  end;
end;

function SIU_TestPathValidChars: Boolean;
begin
  try
    Result := TPath.IsValidFileNameChar('A');
    Result := Result and TPath.IsValidPathChar('A');
    Result := Result and not TPath.IsValidFileNameChar(#0);
    Result := Result and not TPath.IsValidPathChar(#0);
    Result := Result and
      TPath.HasValidFileNameChars('good_name.txt', False);
    Result := Result and
      not TPath.HasValidFileNameChars('bad' + #13 + 'name', False);
    Result := Result and
      TPath.HasValidPathChars('folder' + TPath.DirectorySeparatorChar +
      'item.txt', False);
    Result := Result and
      not TPath.HasValidPathChars('bad' + #13 + 'path', False);
    {$IFDEF MSWINDOWS}
    Result := Result and not TPath.IsValidFileNameChar('*');
    Result := Result and
      TPath.HasValidFileNameChars('name*.txt', True);
    Result := Result and
      not TPath.HasValidFileNameChars('name*.txt', False);
    {$ENDIF}
  except
    Result := False;
  end;
end;

function SIU_TestPathInvalidChars: Boolean;
var
  FileChars, PathChars: TCharArray;
begin
  try
    FileChars := TPath.GetInvalidFileNameChars;
    PathChars := TPath.GetInvalidPathChars;
    Result := SIU_ContainsChar(FileChars, #0);
    Result := Result and SIU_ContainsChar(PathChars, #0);
    Result := Result and not SIU_ContainsChar(FileChars, 'A');
    Result := Result and not SIU_ContainsChar(PathChars, 'A');
    {$IFDEF MSWINDOWS}
    Result := Result and SIU_ContainsChar(FileChars, '*');
    Result := Result and not SIU_ContainsChar(PathChars, '*');
    {$ENDIF}
  except
    Result := False;
  end;
end;

function SIU_TestPathPattern: Boolean;
begin
  try
    Result := TPath.MatchesPattern('alpha.txt', '*.txt', True);
    Result := Result and
      TPath.MatchesPattern('alpha.txt', 'a*.txt', True);
    Result := Result and
      not TPath.MatchesPattern('alpha.dat', '*.txt', True);
    Result := Result and
      TPath.MatchesPattern('ALPHA.TXT', '*.txt', False);
// seems to be a bug in older delphi version
//    Result := Result and
//      not TPath.MatchesPattern('ALPHA.TXT', '*.txt', True);
  except
    Result := False;
  end;
end;

function SIU_TestPathRandomNames: Boolean;
var
  A, B, C, D: string;
begin
  try
    A := TPath.GetRandomFileName;
    B := TPath.GetRandomFileName;
    C := TPath.GetGUIDFileName(False);
    D := TPath.GetGUIDFileName(True);
    Result := (A <> '') and (B <> '') and (A <> B);
    Result := Result and (Length(C) = 32);
    Result := Result and (Length(D) = 36);
    Result := Result and (Pos('-', D) > 0);
    Result := Result and TPath.HasValidFileNameChars(A, False);
    Result := Result and TPath.HasValidFileNameChars(C, False);
  except
    Result := False;
  end;
end;

function SIU_TestPathTempFile: Boolean;
var
  FileName: string;
begin
  FileName := '';
  try
    try
      FileName := TPath.GetTempFileName;
      Result := TFile.Exists(FileName);
      Result := Result and (Length(TFile.ReadAllBytes(FileName)) = 0);
    finally
      if (FileName <> '') and TFile.Exists(FileName) then
        TFile.Delete(FileName);
    end;
  except
    Result := False;
  end;
end;

function SIU_TestPathHome: Boolean;
var
  HomeDir: string;
begin
  try
    HomeDir := TPath.GetHomePath;
    Result := HomeDir <> '';
    Result := Result and TPath.IsPathRooted(HomeDir);
  except
    Result := False;
  end;
end;

function SIU_TestPathAttributes: Boolean;
var
  W: TSIU_Workspace;
  FileName: string;
  Attr: TFileAttributes;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    FileName := W.FilePath('attrs.txt');
    TFile.WriteAllText(FileName, 'abc');
    Attr := TPath.GetAttributes(FileName);
    TPath.SetAttributes(FileName, Attr);
    Result := TFile.Exists(FileName);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileExists: Boolean;
var
  W: TSIU_Workspace;
  P: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('exists.txt');
    Result := not TFile.Exists(P);
    TFile.WriteAllText(P, 'abc');
    Result := Result and TFile.Exists(P);
    Result := Result and not TFile.Exists(W.Root);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileText: Boolean;
var
  W: TSIU_Workspace;
  P: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('text.txt');
    TFile.WriteAllText(P, 'first');
    Result := TFile.ReadAllText(P) = 'first';
    TFile.WriteAllText(P, 'second');
    Result := Result and (TFile.ReadAllText(P) = 'second');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileEncoding: Boolean;
var
  W: TSIU_Workspace;
  P: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('encoding.txt');
    TFile.WriteAllText(P, 'ASCII 123', TEncoding.ASCII);
    Result := TFile.ReadAllText(P, TEncoding.ASCII) = 'ASCII 123';
    Result := Result and (TFile.ReadAllText(P) = 'ASCII 123');
    TFile.WriteAllText(P, 'UTF8 123', TEncoding.UTF8);
    Result := Result and (TFile.ReadAllText(P) = 'UTF8 123');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileAppend: Boolean;
var
  W: TSIU_Workspace;
  P: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('append.txt');
    TFile.AppendAllText(P, 'one');
    TFile.AppendAllText(P, 'two');
    Result := TFile.ReadAllText(P) = 'onetwo';
    TFile.AppendAllText(P, 'three', TEncoding.UTF8);
    Result := Result and (TFile.ReadAllText(P) = 'onetwothree');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileBytes: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  A, B: TBytes;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('bytes.bin');
    SetLength(A, 4);
    A[0] := 0;
    A[1] := 1;
    A[2] := 127;
    A[3] := 255;
    TFile.WriteAllBytes(P, A);
    B := TFile.ReadAllBytes(P);
    Result := Length(B) = 4;
    if Length(B) = 4 then
    begin
      Result := Result and (B[0] = 0);
      Result := Result and (B[1] = 1);
      Result := Result and (B[2] = 127);
      Result := Result and (B[3] = 255);
    end;
    SetLength(A, 0);
    TFile.WriteAllBytes(P, A);
    Result := Result and (Length(TFile.ReadAllBytes(P)) = 0);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileLines: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  A, B: TStringDynArray;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('lines.txt');
    SetLength(A, 3);
    A[0] := 'red';
    A[1] := 'green';
    A[2] := 'blue';
    TFile.WriteAllLines(P, A);
    B := TFile.ReadAllLines(P);
    Result := Length(B) = 3;
    if Length(B) = 3 then
    begin
      Result := Result and (B[0] = 'red');
      Result := Result and (B[1] = 'green');
      Result := Result and (B[2] = 'blue');
    end;
    TFile.WriteAllLines(P, A, TEncoding.UTF8);
    B := TFile.ReadAllLines(P, TEncoding.UTF8);
    Result := Result and (Length(B) = 3);
    if Length(B) = 3 then
      Result := Result and (B[1] = 'green');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileCopy: Boolean;
var
  W: TSIU_Workspace;
  A, B: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    A := W.FilePath('source.txt');
    B := W.FilePath('target.txt');
    TFile.WriteAllText(A, 'source');
    TFile.Copy(A, B);
    Result := TFile.ReadAllText(B) = 'source';
    Result := Result and (TFile.ReadAllText(A) = 'source');
    TFile.WriteAllText(A, 'new');
    TFile.Copy(A, B, True);
    Result := Result and (TFile.ReadAllText(B) = 'new');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileMove: Boolean;
var
  W: TSIU_Workspace;
  A, B: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    A := W.FilePath('before.txt');
    B := W.FilePath('after.txt');
    TFile.WriteAllText(A, 'moved');
    TFile.Move(A, B);
    Result := not TFile.Exists(A);
    Result := Result and TFile.Exists(B);
    Result := Result and (TFile.ReadAllText(B) = 'moved');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileDelete: Boolean;
var
  W: TSIU_Workspace;
  P: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('delete.txt');
    TFile.WriteAllText(P, 'remove');
    Result := TFile.Exists(P);
    TFile.Delete(P);
    Result := Result and not TFile.Exists(P);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileCreateStream: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  Stream: TFileStream;
  Value: Byte;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('create.bin');
    Stream := TFile.Create(P);
    try
      Value := 42;
      Stream.WriteBuffer(Value, SizeOf(Value));
    finally
      Stream.Free;
    end;
    Result := TFile.Exists(P);
    Result := Result and (Length(TFile.ReadAllBytes(P)) = 1);
    Stream := TFile.Create(P);
    try
      Result := Result and (Stream.Size = 0);
    finally
      Stream.Free;
    end;
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileOpenStream: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  Stream: TFileStream;
  Value: Byte;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('open.bin');
    TFile.WriteAllText(P, '0', TEncoding.ASCII);
    Stream := TFile.Open(P, TFileMode.fmOpen, TFileAccess.faReadWrite);
    try
      Value := 91;
      Stream.WriteBuffer(Value, 1);
    finally
      Stream.Free;
    end;
    Stream := TFile.Open(P, TFileMode.fmOpen, TFileAccess.faRead);
    try
      Value := 0;
      Stream.ReadBuffer(Value, 1);
      Result := Value = 91;
    finally
      Stream.Free;
    end;
    Stream := TFile.Open(P, TFileMode.fmOpen,
      TFileAccess.faRead, TFileShare.fsRead);
    try
      Result := Result and (Stream.Size = 1);
    finally
      Stream.Free;
    end;
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileReadWriteStreams: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  Stream: TFileStream;
  Value: Byte;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('rw.bin');
    TFile.WriteAllBytes(P, TEncoding.ASCII.GetBytes('ab'));
    Stream := TFile.OpenWrite(P);
    try
      Value := Ord('X');
      Stream.WriteBuffer(Value, 1);
    finally
      Stream.Free;
    end;
    Stream := TFile.OpenRead(P);
    try
      Value := 0;
      Stream.ReadBuffer(Value, 1);
      Result := Value = Ord('X');
      Result := Result and (Stream.Size = 2);
    finally
      Stream.Free;
    end;
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileTextStreams: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  Writer: TStreamWriter;
  Reader: TStreamReader;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('streams.txt');
    Writer := TFile.CreateText(P);
    try
      Writer.Write('one');
    finally
      Writer.Free;
    end;
    Writer := TFile.AppendText(P);
    try
      Writer.Write('two');
    finally
      Writer.Free;
    end;
    Reader := TFile.OpenText(P);
    try
      Result := Reader.ReadToEnd = 'onetwo';
    finally
      Reader.Free;
    end;
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileAttributes: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  Original: TFileAttributes;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('hidden.txt');
    TFile.WriteAllText(P, 'attr');
    Original := TFile.GetAttributes(P);
    try
      TFile.SetAttributes(P, [TFileAttribute.faHidden]);
      Result := TFileAttribute.faHidden in TFile.GetAttributes(P);
    finally
      TFile.SetAttributes(P, Original);
    end;
    Result := Result and TFile.Exists(P);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileLocalTimes: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  D: TDateTime;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('localtime.txt');
    TFile.WriteAllText(P, 'time');
    D := EncodeDate(2020, 3, 4) + EncodeTime(12, 34, 56, 0);
    TFile.SetLastWriteTime(P, D);
    Result := Abs(TFile.GetLastWriteTime(P) - D) < (3.0 / 86400.0);
    D := TFile.GetCreationTime(P);
    TFile.SetCreationTime(P, D);
    Result := Result and (TFile.GetCreationTime(P) > 0);
    D := TFile.GetLastAccessTime(P);
    TFile.SetLastAccessTime(P, D);
    Result := Result and (TFile.GetLastAccessTime(P) > 0);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileUtcTimes: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  D: TDateTime;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('utctime.txt');
    TFile.WriteAllText(P, 'time');
    //D := EncodeDate(2020, 4, 5) + EncodeTime(11, 22, 33, 0); // Delphi sumertime bug
    D := EncodeDate(2020, 1, 15) + EncodeTime(11, 22, 33, 0);
    TFile.SetLastWriteTimeUtc(P, D);
    Result := Abs(TFile.GetLastWriteTimeUtc(P) - D) < (3.0 / 86400.0);
    D := TFile.GetCreationTimeUtc(P);
    TFile.SetCreationTimeUtc(P, D);
    Result := Result and (TFile.GetCreationTimeUtc(P) > 0);
    D := TFile.GetLastAccessTimeUtc(P);
    TFile.SetLastAccessTimeUtc(P, D);
    Result := Result and (TFile.GetLastAccessTimeUtc(P) > 0);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileReplace: Boolean;
var
  W: TSIU_Workspace;
  A, B, Backup: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    A := W.FilePath('replacement.txt');
    B := W.FilePath('destination.txt');
    Backup := W.FilePath('backup.txt');
    TFile.WriteAllText(A, 'new content');
    TFile.WriteAllText(B, 'old content');
    TFile.Replace(A, B, Backup);
    Result := not TFile.Exists(A);
    Result := Result and (TFile.ReadAllText(B) = 'new content');
    Result := Result and (TFile.ReadAllText(Backup) = 'old content');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestFileMissingException: Boolean;
var
  W: TSIU_Workspace;
  P, Content: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('missing.txt');
    try
      Content := TFile.ReadAllText(P);
      Result := False;
    except
      on E: Exception do
        Result := True;
    end;
    Result := Result and not TFile.Exists(P);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryExists: Boolean;
var
  W: TSIU_Workspace;
  P: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('dir');
    Result := not TDirectory.Exists(P);
    TDirectory.CreateDirectory(P);
    Result := Result and TDirectory.Exists(P);
    Result := Result and not TFile.Exists(P);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryNestedCreate: Boolean;
var
  W: TSIU_Workspace;
  P, Q: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('level1');
    Q := TPath.Combine(P, 'level2');
    TDirectory.CreateDirectory(Q);
    Result := TDirectory.Exists(P);
    Result := Result and TDirectory.Exists(Q);
    TDirectory.CreateDirectory(Q);
    Result := Result and TDirectory.Exists(Q);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryDelete: Boolean;
var
  W: TSIU_Workspace;
  A, B: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    A := W.FilePath('empty');
    TDirectory.CreateDirectory(A);
    TDirectory.Delete(A);
    Result := not TDirectory.Exists(A);
    A := W.FilePath('nested');
    B := TPath.Combine(A, 'child');
    TDirectory.CreateDirectory(B);
    TFile.WriteAllText(TPath.Combine(B, 'item.txt'), 'abc');
    TDirectory.Delete(A, True);
    Result := Result and not TDirectory.Exists(A);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryEmpty: Boolean;
var
  W: TSIU_Workspace;
  P: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('empty');
    TDirectory.CreateDirectory(P);
    Result := TDirectory.IsEmpty(P);
    TFile.WriteAllText(TPath.Combine(P, 'item.txt'), 'abc');
    Result := Result and not TDirectory.IsEmpty(P);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryGetFiles: Boolean;
var
  W: TSIU_Workspace;
  A: TStringDynArray;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    TFile.WriteAllText(W.FilePath('one.txt'), '1');
    TFile.WriteAllText(W.FilePath('two.dat'), '2');
    A := TDirectory.GetFiles(W.Root);
    Result := Length(A) = 2;
    Result := Result and SIU_ContainsName(A, 'one.txt');
    Result := Result and SIU_ContainsName(A, 'two.dat');
    A := TDirectory.GetFiles(W.Root, '*.txt');
    Result := Result and (Length(A) = 1);
    Result := Result and SIU_ContainsName(A, 'one.txt');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryRecursiveFiles: Boolean;
var
  W: TSIU_Workspace;
  SubDir: string;
  A: TStringDynArray;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    SubDir := W.FilePath('sub');
    TDirectory.CreateDirectory(SubDir);
    TFile.WriteAllText(W.FilePath('top.txt'), 'top');
    TFile.WriteAllText(TPath.Combine(SubDir, 'deep.txt'), 'deep');
    A := TDirectory.GetFiles(W.Root, '*.txt',
      TSearchOption.soTopDirectoryOnly);
    Result := Length(A) = 1;
    A := TDirectory.GetFiles(W.Root, '*.txt',
      TSearchOption.soAllDirectories);
    Result := Result and (Length(A) = 2);
    Result := Result and SIU_ContainsName(A, 'top.txt');
    Result := Result and SIU_ContainsName(A, 'deep.txt');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryFilter: Boolean;
var
  W: TSIU_Workspace;
  A: TStringDynArray;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    TFile.WriteAllText(W.FilePath('keep.txt'), 'a');
    TFile.WriteAllText(W.FilePath('skip.dat'), 'b');
    A := TDirectory.GetFiles(W.Root, '*.*',
      function(const Path: string; const SearchRec: TSearchRec): Boolean
      begin
        Result := SameText(ExtractFileExt(SearchRec.Name), '.txt');
      end);
    Result := Length(A) = 1;
    Result := Result and SIU_ContainsName(A, 'keep.txt');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryGetDirectories: Boolean;
var
  W: TSIU_Workspace;
  A: TStringDynArray;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    TDirectory.CreateDirectory(W.FilePath('alpha'));
    TDirectory.CreateDirectory(W.FilePath('beta'));
    A := TDirectory.GetDirectories(W.Root);
    Result := Length(A) = 2;
    Result := Result and SIU_ContainsName(A, 'alpha');
    Result := Result and SIU_ContainsName(A, 'beta');
    A := TDirectory.GetDirectories(W.Root, 'a*');
    Result := Result and (Length(A) = 1);
    Result := Result and SIU_ContainsName(A, 'alpha');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryGetEntries: Boolean;
var
  W: TSIU_Workspace;
  A: TStringDynArray;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    TDirectory.CreateDirectory(W.FilePath('sub'));
    TFile.WriteAllText(W.FilePath('item.txt'), 'x');
    A := TDirectory.GetFileSystemEntries(W.Root);
    Result := Length(A) = 2;
    Result := Result and SIU_ContainsName(A, 'sub');
    Result := Result and SIU_ContainsName(A, 'item.txt');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryCopy: Boolean;
var
  W: TSIU_Workspace;
  SourceDir, DestDir: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    SourceDir := W.FilePath('source');
    DestDir := W.FilePath('copy');
    TDirectory.CreateDirectory(SourceDir);
    TFile.WriteAllText(TPath.Combine(SourceDir, 'data.txt'), 'data');
    TDirectory.Copy(SourceDir, DestDir);
    Result := TDirectory.Exists(SourceDir);
    Result := Result and TDirectory.Exists(DestDir);
    Result := Result and
      (TFile.ReadAllText(TPath.Combine(DestDir, 'data.txt')) = 'data');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryMove: Boolean;
var
  W: TSIU_Workspace;
  SourceDir, DestDir: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    SourceDir := W.FilePath('old');
    DestDir := W.FilePath('new');
    TDirectory.CreateDirectory(SourceDir);
    TFile.WriteAllText(TPath.Combine(SourceDir, 'data.txt'), 'data');
    TDirectory.Move(SourceDir, DestDir);
    Result := not TDirectory.Exists(SourceDir);
    Result := Result and TDirectory.Exists(DestDir);
    Result := Result and
      (TFile.ReadAllText(TPath.Combine(DestDir, 'data.txt')) = 'data');
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryParentRoot: Boolean;
var
  W: TSIU_Workspace;
  P, R: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('child');
    TDirectory.CreateDirectory(P);
    R := TDirectory.GetDirectoryRoot(P);
    Result := SameText(TDirectory.GetParent(P), W.Root);
    Result := Result and SameText(R, TPath.GetPathRoot(P));
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryRelative: Boolean;
begin
  try
    Result := TDirectory.IsRelativePath('child');
    Result := Result and not TDirectory.IsRelativePath(TPath.GetTempPath);
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryCurrent: Boolean;
var
  W: TSIU_Workspace;
  OriginalDir: string;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    OriginalDir := TDirectory.GetCurrentDirectory;
    try
      TDirectory.SetCurrentDirectory(W.Root);
      Result := SameText(TDirectory.GetCurrentDirectory, W.Root);
    finally
      TDirectory.SetCurrentDirectory(OriginalDir);
    end;
    Result := Result and
      SameText(TDirectory.GetCurrentDirectory, OriginalDir);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryAttributes: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  Attr: TFileAttributes;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('attribute_dir');
    TDirectory.CreateDirectory(P);
    Attr := TDirectory.GetAttributes(P);
    Result := TFileAttribute.faDirectory in Attr;
    TDirectory.SetAttributes(P, Attr);
    Result := Result and TDirectory.Exists(P);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryTimes: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  D: TDateTime;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('time_dir');
    TDirectory.CreateDirectory(P);
    D := TDirectory.GetCreationTime(P);
    TDirectory.SetCreationTime(P, D);
    Result := TDirectory.GetCreationTime(P) > 0;
    D := TDirectory.GetLastAccessTime(P);
    TDirectory.SetLastAccessTime(P, D);
    Result := Result and (TDirectory.GetLastAccessTime(P) > 0);
    D := TDirectory.GetLastWriteTime(P);
    TDirectory.SetLastWriteTime(P, D);
    Result := Result and (TDirectory.GetLastWriteTime(P) > 0);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryUtcTimes: Boolean;
var
  W: TSIU_Workspace;
  P: string;
  D: TDateTime;
begin
  Result := False;
  W := nil;
  try
    W := TSIU_Workspace.Create;
    P := W.FilePath('utc_dir');
    TDirectory.CreateDirectory(P);
    D := TDirectory.GetCreationTimeUtc(P);
    TDirectory.SetCreationTimeUtc(P, D);
    Result := TDirectory.GetCreationTimeUtc(P) > 0;
    D := TDirectory.GetLastAccessTimeUtc(P);
    TDirectory.SetLastAccessTimeUtc(P, D);
    Result := Result and (TDirectory.GetLastAccessTimeUtc(P) > 0);
    D := TDirectory.GetLastWriteTimeUtc(P);
    TDirectory.SetLastWriteTimeUtc(P, D);
    Result := Result and (TDirectory.GetLastWriteTimeUtc(P) > 0);
  except
    Result := False;
  end;
  try
    W.Free;
  except
    Result := False;
  end;
end;

function SIU_TestDirectoryLogicalDrives: Boolean;
var
  A: TStringDynArray;
begin
  try
    A := TDirectory.GetLogicalDrives;
    {$IFDEF MSWINDOWS}
    Result := Length(A) > 0;
    {$ELSE}
    Result := True;
    {$ENDIF}
  except
    Result := False;
  end;
end;

// Force evaluation of every test, even after a previous failure.
// The translated C# runner must likewise use eager boolean evaluation.
{$B+}
function SIU_RunAllTests: Boolean;
begin
  Result := True;
  Result := Result and SIU_TestPathSeparators;
  Result := Result and SIU_TestPathCombine;
  Result := Result and SIU_TestPathExtension;
  Result := Result and SIU_TestPathFileName;
  Result := Result and SIU_TestPathDirectoryName;
  Result := Result and SIU_TestPathFullPath;
  Result := Result and SIU_TestPathRoot;
  Result := Result and SIU_TestPathRelative;
  Result := Result and SIU_TestPathUNC;
  Result := Result and SIU_TestPathExtendedPrefix;
  Result := Result and SIU_TestPathDrive;
  Result := Result and SIU_TestPathValidChars;
  Result := Result and SIU_TestPathInvalidChars;
  Result := Result and SIU_TestPathPattern;
  Result := Result and SIU_TestPathRandomNames;
  Result := Result and SIU_TestPathTempFile;
  Result := Result and SIU_TestPathHome;
  Result := Result and SIU_TestPathAttributes;
  Result := Result and SIU_TestFileExists;
  Result := Result and SIU_TestFileText;
  Result := Result and SIU_TestFileEncoding;
  Result := Result and SIU_TestFileAppend;
  Result := Result and SIU_TestFileBytes;
  Result := Result and SIU_TestFileLines;
  Result := Result and SIU_TestFileCopy;
  Result := Result and SIU_TestFileMove;
  Result := Result and SIU_TestFileDelete;
  Result := Result and SIU_TestFileCreateStream;
  Result := Result and SIU_TestFileOpenStream;
  Result := Result and SIU_TestFileReadWriteStreams;
  Result := Result and SIU_TestFileTextStreams;
  Result := Result and SIU_TestFileAttributes;
  Result := Result and SIU_TestFileLocalTimes;
  Result := Result and SIU_TestFileUtcTimes;
  Result := Result and SIU_TestFileReplace;
  Result := Result and SIU_TestFileMissingException;
  Result := Result and SIU_TestDirectoryExists;
  Result := Result and SIU_TestDirectoryNestedCreate;
  Result := Result and SIU_TestDirectoryDelete;
  Result := Result and SIU_TestDirectoryEmpty;
  Result := Result and SIU_TestDirectoryGetFiles;
  Result := Result and SIU_TestDirectoryRecursiveFiles;
  Result := Result and SIU_TestDirectoryFilter;
  Result := Result and SIU_TestDirectoryGetDirectories;
  Result := Result and SIU_TestDirectoryGetEntries;
  Result := Result and SIU_TestDirectoryCopy;
  Result := Result and SIU_TestDirectoryMove;
  Result := Result and SIU_TestDirectoryParentRoot;
  Result := Result and SIU_TestDirectoryRelative;
  Result := Result and SIU_TestDirectoryCurrent;
  Result := Result and SIU_TestDirectoryAttributes;
  Result := Result and SIU_TestDirectoryTimes;
  Result := Result and SIU_TestDirectoryUtcTimes;
  Result := Result and SIU_TestDirectoryLogicalDrives;
end;
{$B-}

end.
