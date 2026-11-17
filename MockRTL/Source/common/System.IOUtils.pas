{
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.IOUtils.
  Independent skeleton for translation; methods have no file-system behavior.
  The public surface covers commonly used path, file and directory routines.
  Signatures are intended for Delphi XE3 and should be validated with that compiler.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
}

unit System.IOUtils;

interface

uses
  System.SysUtils,
  System.Classes;

type
  TSearchOption = (soTopDirectoryOnly, soAllDirectories);
  TFileMode = (fmCreateNew, fmCreate, fmOpen, fmOpenOrCreate, fmTruncate, fmAppend);
  TFileAccess = (faRead, faWrite, faReadWrite);
  TFileShare = (fsNone, fsRead, fsWrite, fsReadWrite);
  TFileAttribute = (faReadOnly, faHidden, faSystem, faDirectory, faArchive,
    faDevice, faNormal, faTemporary, faSparseFile, faReparsePoint,
    faCompressed, faOffline, faNotContentIndexed, faEncrypted, faSymLink);
  TFileAttributes = set of TFileAttribute;
  TIOStringArray = array of string;

  TPath = class
  public
    class function GetFileName(const Path: string): string; static;
    class function GetDirectoryName(const Path: string): string; static;
    class function GetFileNameWithoutExtension(const Path: string): string; static;
    class function GetExtension(const Path: string): string; static;
    class function ChangeExtension(const Path, Extension: string): string; static;
    class function Combine(const Path1, Path2: string): string; static;
    class function GetFullPath(const Path: string): string; static;
    class function GetPathRoot(const Path: string): string; static;
    class function GetTempPath: string; static;
    class function GetTempFileName: string; static;
    class function GetRandomFileName: string; static;
    class function GetDocumentsPath: string; static;
    class function GetHomePath: string; static;
    class function GetLibraryPath: string; static;
    class function GetCachePath: string; static;
    class function GetSharedDocumentsPath: string; static;
    class function IsValidPathChar(const AChar: Char): Boolean; static;
    class function IsValidFileNameChar(const AChar: Char): Boolean; static;
    class function HasValidPathChars(const Path: string; const UseWildcards: Boolean): Boolean; static;
    class function HasValidFileNameChars(const FileName: string; const UseWildcards: Boolean): Boolean; static;
    class function GetInvalidFileNameChars: TCharArray; static;
    class function GetInvalidPathChars: TCharArray; static;
    class function IsDriveRooted(const Path: string): Boolean; static;
    class function IsExtendedPrefixed(const Path: string): Boolean; static;
    class function IsUNCPath(const Path: string): Boolean; static;
    class function IsUNCRooted(const Path: string): Boolean; static;
    class function GetGUIDFileName(const UseSeparator: Boolean = False): string; static;
    class function IsPathRooted(const Path: string): Boolean; static;
    class function IsRelativePath(const Path: string): Boolean; static;
    class function HasExtension(const Path: string): Boolean; static;
    class function DriveExists(const Path: string): Boolean; static;
    class function MatchesPattern(const FileName, Pattern: string; const CaseSensitive: Boolean): Boolean; static;
    class function GetDirectorySeparator: Char; static;
    class function GetAltDirectorySeparator: Char; static;
    class function GetVolumeSeparator: Char; static;
    class function GetExtensionSeparator: Char; static;
    class function GetPathSeparator: Char; static;
    class property ExtensionSeparatorChar: Char read GetExtensionSeparator;
    class property DirectorySeparatorChar: Char read GetDirectorySeparator;
    class property AltDirectorySeparatorChar: Char read GetAltDirectorySeparator;
    class property PathSeparator: Char read GetPathSeparator;
    class property VolumeSeparatorChar: Char read GetVolumeSeparator;
    class function GetAttributes(const Path: string; FollowLink: Boolean = True): TFileAttributes; static;
    class procedure SetAttributes(const Path: string; const Attributes: TFileAttributes); static;
  end;

  TFile = class
  public
    class function Create(const Path: string): TFileStream; reintroduce; overload; static;
    class function Create(const Path: string; BufferSize: Integer): TFileStream; reintroduce; overload; static;
    class function Open(const Path: string; Mode: TFileMode): TFileStream; overload; static;
    class function Open(const Path: string; Mode: TFileMode; Access: TFileAccess): TFileStream; overload; static;
    class function Open(const Path: string; Mode: TFileMode; Access: TFileAccess; Share: TFileShare): TFileStream; overload; static;
    class function OpenRead(const Path: string): TFileStream; static;
    class function OpenWrite(const Path: string): TFileStream; static;
    class function CreateText(const Path: string): TStreamWriter; static;
    class function AppendText(const Path: string): TStreamWriter; static;
    class function OpenText(const Path: string): TStreamReader; static;
    class procedure WriteAllText(const Path, Contents: string; const Encoding: TEncoding); overload; static;
    class procedure WriteAllText(const Path, Contents: string); overload; static;
    class procedure AppendAllText(const Path, Contents: string); overload; static;
    class procedure AppendAllText(const Path, Contents: string; const Encoding: TEncoding); overload; static;
    class function ReadAllText(const Path: string): string; overload; static;
    class function ReadAllText(const Path: string; const Encoding: TEncoding): string; overload; static;
    class procedure WriteAllBytes(const Path: string; const Bytes: TBytes); static;
    class function ReadAllBytes(const Path: string): TBytes; static;
    class procedure WriteAllLines(const Path: string; const Contents: TIOStringArray); overload; static;
    class procedure WriteAllLines(const Path: string; const Contents: TIOStringArray; const Encoding: TEncoding); overload; static;
    class function ReadAllLines(const Path: string): TIOStringArray; overload; static;
    class function ReadAllLines(const Path: string; const Encoding: TEncoding): TIOStringArray; overload; static;
    class procedure AppendAllLines(const Path: string; const Contents: TIOStringArray); overload; static;
    class procedure AppendAllLines(const Path: string; const Contents: TIOStringArray; const Encoding: TEncoding); overload; static;
    class function Exists(const Path: string): Boolean; static;
    class procedure Delete(const Path: string); static;
    class procedure Copy(const SourceFileName, DestFileName: string); overload; static;
    class procedure Copy(const SourceFileName, DestFileName: string; Overwrite: Boolean); overload; static;
    class procedure Move(const SourceFileName, DestFileName: string); static;
    class procedure Replace(const SourceFileName, DestinationFileName, DestinationBackupFileName: string); static;
    class function GetAttributes(const Path: string; FollowLink: Boolean = True): TFileAttributes; static;
    class procedure SetAttributes(const Path: string; const Attributes: TFileAttributes); static;
    class function GetSize(const Path: string): Int64; static;
    class function GetCreationTime(const Path: string): TDateTime; static;
    class function GetCreationTimeUtc(const Path: string): TDateTime; static;
    class function GetLastAccessTime(const Path: string): TDateTime; static;
    class function GetLastAccessTimeUtc(const Path: string): TDateTime; static;
    class function GetLastWriteTime(const Path: string): TDateTime; static;
    class function GetLastWriteTimeUtc(const Path: string): TDateTime; static;
    class procedure SetCreationTime(const Path: string; CreationTime: TDateTime); static;
    class procedure SetCreationTimeUtc(const Path: string; CreationTime: TDateTime); static;
    class procedure SetLastAccessTime(const Path: string; LastAccessTime: TDateTime); static;
    class procedure SetLastAccessTimeUtc(const Path: string; LastAccessTime: TDateTime); static;
    class procedure SetLastWriteTime(const Path: string; LastWriteTime: TDateTime); static;
    class procedure SetLastWriteTimeUtc(const Path: string; LastWriteTime: TDateTime); static;
  end;

  TDirectory = class
  public type
    TFilterPredicate = reference to function(const Path: string;
      const SearchRec: TSearchRec): Boolean;
  public
    class function Exists(const Path: string): Boolean; static;
    class procedure CreateDirectory(const Path: string); static;
    class procedure Delete(const Path: string); overload; static;
    class procedure Delete(const Path: string; Recursive: Boolean); overload; static;
    class procedure Move(const SourceDirName, DestDirName: string); static;
    class procedure Copy(const SourceDirName, DestDirName: string); static;
    class function GetCurrentDirectory: string; static;
    class procedure SetCurrentDirectory(const Path: string); static;
    class function GetParent(const Path: string): string; static;
    class function GetDirectoryRoot(const Path: string): string; static;
    class function GetDirectories(const Path: string): TIOStringArray; overload; static;
    class function GetDirectories(const Path, SearchPattern: string): TIOStringArray; overload; static;
    class function GetDirectories(const Path, SearchPattern: string; SearchOption: TSearchOption): TIOStringArray; overload; static;
    class function GetFiles(const Path: string): TIOStringArray; overload; static;
    class function GetFiles(const Path, SearchPattern: string): TIOStringArray; overload; static;
    class function GetFiles(const Path, SearchPattern: string; SearchOption: TSearchOption): TIOStringArray; overload; static;
    class function GetFiles(const Path, SearchPattern: string;
      const Predicate: TFilterPredicate): TIOStringArray; overload; static;
    class function GetFileSystemEntries(const Path: string): TIOStringArray; overload; static;
    class function GetFileSystemEntries(const Path, SearchPattern: string): TIOStringArray; overload; static;
    class function GetFileSystemEntries(const Path, SearchPattern: string; SearchOption: TSearchOption): TIOStringArray; overload; static;
    class function GetLogicalDrives: TIOStringArray; static;
    class function IsRelativePath(const Path: string): Boolean; static;
    class function IsEmpty(const Path: string): Boolean; static;
    class function GetAttributes(const Path: string; FollowLink: Boolean = True): TFileAttributes; static;
    class procedure SetAttributes(const Path: string; const Attributes: TFileAttributes); static;
    class function GetCreationTime(const Path: string): TDateTime; static;
    class function GetCreationTimeUtc(const Path: string): TDateTime; static;
    class function GetLastAccessTime(const Path: string): TDateTime; static;
    class function GetLastAccessTimeUtc(const Path: string): TDateTime; static;
    class function GetLastWriteTime(const Path: string): TDateTime; static;
    class function GetLastWriteTimeUtc(const Path: string): TDateTime; static;
    class procedure SetCreationTime(const Path: string; CreationTime: TDateTime); static;
    class procedure SetCreationTimeUtc(const Path: string; CreationTime: TDateTime); static;
    class procedure SetLastAccessTime(const Path: string; LastAccessTime: TDateTime); static;
    class procedure SetLastAccessTimeUtc(const Path: string; LastAccessTime: TDateTime); static;
    class procedure SetLastWriteTime(const Path: string; LastWriteTime: TDateTime); static;
    class procedure SetLastWriteTimeUtc(const Path: string; LastWriteTime: TDateTime); static;
  end;

implementation

class function TPath.GetFileName(const Path: string): string;
begin
  Result := '';
end;

class function TPath.GetDirectoryName(const Path: string): string;
begin
  Result := '';
end;

class function TPath.GetFileNameWithoutExtension(const Path: string): string;
begin
  Result := '';
end;

class function TPath.GetExtension(const Path: string): string;
begin
  Result := '';
end;

class function TPath.ChangeExtension(const Path, Extension: string): string;
begin
  Result := '';
end;

class function TPath.Combine(const Path1, Path2: string): string;
begin
  Result := '';
end;

class function TPath.GetFullPath(const Path: string): string;
begin
  Result := '';
end;

class function TPath.GetPathRoot(const Path: string): string;
begin
  Result := '';
end;

class function TPath.GetTempPath: string;
begin
  Result := '';
end;

class function TPath.GetTempFileName: string;
begin
  Result := '';
end;

class function TPath.GetRandomFileName: string;
begin
  Result := '';
end;

class function TPath.GetDocumentsPath: string;
begin
  Result := '';
end;

class function TPath.GetHomePath: string;
begin
  Result := '';
end;

class function TPath.GetLibraryPath: string;
begin
  Result := '';
end;

class function TPath.GetCachePath: string;
begin
  Result := '';
end;

class function TPath.GetSharedDocumentsPath: string;
begin
  Result := '';
end;

class function TPath.IsValidPathChar(const AChar: Char): Boolean;
begin
  Result := False;
end;

class function TPath.IsValidFileNameChar(const AChar: Char): Boolean;
begin
  Result := False;
end;

class function TPath.HasValidPathChars(const Path: string; const UseWildcards: Boolean): Boolean;
begin
  Result := False;
end;

class function TPath.HasValidFileNameChars(const FileName: string; const UseWildcards: Boolean): Boolean;
begin
  Result := False;
end;

class function TPath.GetInvalidFileNameChars: TCharArray;
begin
  Result := nil;
end;

class function TPath.GetInvalidPathChars: TCharArray;
begin
  Result := nil;
end;

class function TPath.IsDriveRooted(const Path: string): Boolean;
begin
  Result := False;
end;

class function TPath.IsExtendedPrefixed(const Path: string): Boolean;
begin
  Result := False;
end;

class function TPath.IsUNCPath(const Path: string): Boolean;
begin
  Result := False;
end;

class function TPath.IsUNCRooted(const Path: string): Boolean;
begin
  Result := False;
end;

class function TPath.GetGUIDFileName(const UseSeparator: Boolean): string;
begin
  Result := '';
end;

class function TPath.IsPathRooted(const Path: string): Boolean;
begin
  Result := False;
end;

class function TPath.IsRelativePath(const Path: string): Boolean;
begin
  Result := False;
end;

class function TPath.HasExtension(const Path: string): Boolean;
begin
  Result := False;
end;

class function TPath.DriveExists(const Path: string): Boolean;
begin
  Result := False;
end;

class function TPath.MatchesPattern(const FileName, Pattern: string; const CaseSensitive: Boolean): Boolean;
begin
  Result := False;
end;

class function TPath.GetDirectorySeparator: Char;
begin
  Result := #0;
end;

class function TPath.GetAltDirectorySeparator: Char;
begin
  Result := #0;
end;

class function TPath.GetVolumeSeparator: Char;
begin
  Result := #0;
end;

class function TPath.GetExtensionSeparator: Char;
begin
  Result := #0;
end;

class function TPath.GetPathSeparator: Char;
begin
  Result := #0;
end;

class function TPath.GetAttributes(const Path: string; FollowLink: Boolean): TFileAttributes;
begin
  Result := [];
end;

class procedure TPath.SetAttributes(const Path: string; const Attributes: TFileAttributes);
begin
end;

class function TFile.Create(const Path: string): TFileStream;
begin
  Result := nil;
end;

class function TFile.Create(const Path: string; BufferSize: Integer): TFileStream;
begin
  Result := nil;
end;

class function TFile.Open(const Path: string; Mode: TFileMode): TFileStream;
begin
  Result := nil;
end;

class function TFile.Open(const Path: string; Mode: TFileMode; Access: TFileAccess): TFileStream;
begin
  Result := nil;
end;

class function TFile.Open(const Path: string; Mode: TFileMode; Access: TFileAccess; Share: TFileShare): TFileStream;
begin
  Result := nil;
end;

class function TFile.OpenRead(const Path: string): TFileStream;
begin
  Result := nil;
end;

class function TFile.OpenWrite(const Path: string): TFileStream;
begin
  Result := nil;
end;

class function TFile.CreateText(const Path: string): TStreamWriter;
begin
  Result := nil;
end;

class function TFile.AppendText(const Path: string): TStreamWriter;
begin
  Result := nil;
end;

class function TFile.OpenText(const Path: string): TStreamReader;
begin
  Result := nil;
end;

class procedure TFile.WriteAllText(const Path, Contents: string; const Encoding: TEncoding);
begin
end;

class procedure TFile.WriteAllText(const Path, Contents: string);
begin
end;

class procedure TFile.AppendAllText(const Path, Contents: string);
begin
end;

class procedure TFile.AppendAllText(const Path, Contents: string; const Encoding: TEncoding);
begin
end;

class function TFile.ReadAllText(const Path: string): string;
begin
  Result := '';
end;

class function TFile.ReadAllText(const Path: string; const Encoding: TEncoding): string;
begin
  Result := '';
end;

class procedure TFile.WriteAllBytes(const Path: string; const Bytes: TBytes);
begin
end;

class function TFile.ReadAllBytes(const Path: string): TBytes;
begin
  Result := nil;
end;

class procedure TFile.WriteAllLines(const Path: string; const Contents: TIOStringArray);
begin
end;

class procedure TFile.WriteAllLines(const Path: string; const Contents: TIOStringArray; const Encoding: TEncoding);
begin
end;

class function TFile.ReadAllLines(const Path: string): TIOStringArray;
begin
  Result := nil;
end;

class function TFile.ReadAllLines(const Path: string; const Encoding: TEncoding): TIOStringArray;
begin
  Result := nil;
end;

class procedure TFile.AppendAllLines(const Path: string; const Contents: TIOStringArray);
begin
end;

class procedure TFile.AppendAllLines(const Path: string; const Contents: TIOStringArray; const Encoding: TEncoding);
begin
end;

class function TFile.Exists(const Path: string): Boolean;
begin
  Result := False;
end;

class procedure TFile.Delete(const Path: string);
begin
end;

class procedure TFile.Copy(const SourceFileName, DestFileName: string);
begin
end;

class procedure TFile.Copy(const SourceFileName, DestFileName: string; Overwrite: Boolean);
begin
end;

class procedure TFile.Move(const SourceFileName, DestFileName: string);
begin
end;

class procedure TFile.Replace(const SourceFileName, DestinationFileName, DestinationBackupFileName: string);
begin
end;

class function TFile.GetAttributes(const Path: string; FollowLink: Boolean): TFileAttributes;
begin
  Result := [];
end;

class procedure TFile.SetAttributes(const Path: string; const Attributes: TFileAttributes);
begin
end;

class function TFile.GetSize(const Path: string): Int64;
begin
  Result := 0;
end;

class function TFile.GetCreationTimeUtc(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TFile.GetCreationTime(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TFile.GetLastAccessTimeUtc(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TFile.GetLastAccessTime(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TFile.GetLastWriteTimeUtc(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TFile.GetLastWriteTime(const Path: string): TDateTime;
begin
  Result := 0;
end;

class procedure TFile.SetCreationTimeUtc(const Path: string; CreationTime: TDateTime);
begin
end;

class procedure TFile.SetCreationTime(const Path: string; CreationTime: TDateTime);
begin
end;

class procedure TFile.SetLastAccessTimeUtc(const Path: string; LastAccessTime: TDateTime);
begin
end;

class procedure TFile.SetLastAccessTime(const Path: string; LastAccessTime: TDateTime);
begin
end;

class procedure TFile.SetLastWriteTimeUtc(const Path: string; LastWriteTime: TDateTime);
begin
end;

class procedure TFile.SetLastWriteTime(const Path: string; LastWriteTime: TDateTime);
begin
end;

class function TDirectory.Exists(const Path: string): Boolean;
begin
  Result := False;
end;

class procedure TDirectory.CreateDirectory(const Path: string);
begin
end;

class procedure TDirectory.Delete(const Path: string);
begin
end;

class procedure TDirectory.Delete(const Path: string; Recursive: Boolean);
begin
end;

class procedure TDirectory.Move(const SourceDirName, DestDirName: string);
begin
end;

class procedure TDirectory.Copy(const SourceDirName, DestDirName: string);
begin
end;

class function TDirectory.GetCurrentDirectory: string;
begin
  Result := '';
end;

class procedure TDirectory.SetCurrentDirectory(const Path: string);
begin
end;

class function TDirectory.GetParent(const Path: string): string;
begin
  Result := '';
end;

class function TDirectory.GetDirectoryRoot(const Path: string): string;
begin
  Result := '';
end;

class function TDirectory.GetDirectories(const Path: string): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetDirectories(const Path, SearchPattern: string): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetDirectories(const Path, SearchPattern: string; SearchOption: TSearchOption): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetFiles(const Path: string): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetFiles(const Path, SearchPattern: string): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetFiles(const Path, SearchPattern: string; SearchOption: TSearchOption): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetFiles(const Path, SearchPattern: string;
  const Predicate: TFilterPredicate): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetFileSystemEntries(const Path: string): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetFileSystemEntries(const Path, SearchPattern: string): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetFileSystemEntries(const Path, SearchPattern: string; SearchOption: TSearchOption): TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.GetLogicalDrives: TIOStringArray;
begin
  Result := nil;
end;

class function TDirectory.IsEmpty(const Path: string): Boolean;
begin
  Result := False;
end;

class function TDirectory.IsRelativePath(const Path: string): Boolean;
begin
  Result := False;
end;

class function TDirectory.GetAttributes(const Path: string; FollowLink: Boolean): TFileAttributes;
begin
  Result := [];
end;

class procedure TDirectory.SetAttributes(const Path: string; const Attributes: TFileAttributes);
begin
end;

class function TDirectory.GetCreationTime(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TDirectory.GetCreationTimeUtc(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TDirectory.GetLastAccessTime(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TDirectory.GetLastAccessTimeUtc(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TDirectory.GetLastWriteTime(const Path: string): TDateTime;
begin
  Result := 0;
end;

class function TDirectory.GetLastWriteTimeUtc(const Path: string): TDateTime;
begin
  Result := 0;
end;

class procedure TDirectory.SetCreationTime(const Path: string; CreationTime: TDateTime);
begin
end;

class procedure TDirectory.SetCreationTimeUtc(const Path: string; CreationTime: TDateTime);
begin
end;

class procedure TDirectory.SetLastAccessTime(const Path: string; LastAccessTime: TDateTime);
begin
end;

class procedure TDirectory.SetLastAccessTimeUtc(const Path: string; LastAccessTime: TDateTime);
begin
end;

class procedure TDirectory.SetLastWriteTime(const Path: string; LastWriteTime: TDateTime);
begin
end;

class procedure TDirectory.SetLastWriteTimeUtc(const Path: string; LastWriteTime: TDateTime);
begin
end;

end.
