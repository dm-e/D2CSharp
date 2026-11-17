using System.Classes;
using System.Sysutils;
using System;
using static System.Classes.ClassesInterface;
using static System.Ioutils.IoutilsImplementation;
using static System.Ioutils.IoutilsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;

namespace System
{

namespace Ioutils
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.IOUtils.
  Independent skeleton for translation; methods have no file-system behavior.
  The public surface covers commonly used path, file and directory routines.
  Signatures are intended for Delphi XE3 and should be validated with that compiler.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/


public class IoutilsInterface
{

	public class TPath : TObject
	{
		public static string GetFileName(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetDirectoryName(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetFileNameWithoutExtension(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetExtension(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string ChangeExtension(string Path, string Extension)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string Combine(string Path1, string Path2)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetFullPath(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetPathRoot(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetTempPath()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetTempFileName()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetRandomFileName()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetDocumentsPath()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetHomePath()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetLibraryPath()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetCachePath()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetSharedDocumentsPath()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static bool IsValidPathChar(char AChar)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool IsValidFileNameChar(char AChar)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool HasValidPathChars(string Path, bool UseWildcards)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool HasValidFileNameChars(string FileName, bool UseWildcards)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static char[] GetInvalidFileNameChars()
		{
			char[] result = null;
			result = default;
			return result;
		}
		public static char[] GetInvalidPathChars()
		{
			char[] result = null;
			result = default;
			return result;
		}
		public static bool IsDriveRooted(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool IsExtendedPrefixed(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool IsUNCPath(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool IsUNCRooted(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static string GetGUIDFileName(bool UseSeparator = false)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static bool IsPathRooted(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool IsRelativePath(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool HasExtension(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool DriveExists(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool MatchesPattern(string FileName, string Pattern, bool CaseSensitive)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static char GetDirectorySeparator()
		{
			char result = '\0';
			result = '\x00';
			return result;
		}
		public static char GetAltDirectorySeparator()
		{
			char result = '\0';
			result = '\x00';
			return result;
		}
		public static char GetVolumeSeparator()
		{
			char result = '\0';
			result = '\x00';
			return result;
		}
		public static char GetExtensionSeparator()
		{
			char result = '\0';
			result = '\x00';
			return result;
		}
		public static char GetPathSeparator()
		{
			char result = '\0';
			result = '\x00';
			return result;
		}
		/*property ExtensionSeparatorChar : char read GetExtensionSeparator;*/
		public static char ExtensionSeparatorChar
		{
			get
			{
				return GetExtensionSeparator();
			}
		}
		/*property DirectorySeparatorChar : char read GetDirectorySeparator;*/
		public static char DirectorySeparatorChar
		{
			get
			{
				return GetDirectorySeparator();
			}
		}
		/*property AltDirectorySeparatorChar : char read GetAltDirectorySeparator;*/
		public static char AltDirectorySeparatorChar
		{
			get
			{
				return GetAltDirectorySeparator();
			}
		}
		/*property PathSeparator : char read GetPathSeparator;*/
		public static char PathSeparator
		{
			get
			{
				return GetPathSeparator();
			}
		}
		/*property VolumeSeparatorChar : char read GetVolumeSeparator;*/
		public static char VolumeSeparatorChar
		{
			get
			{
				return GetVolumeSeparator();
			}
		}
		public static TSet GetAttributes(string Path, bool FollowLink = true)
		{
			TSet result = new TSet();
			result = (new TSet());
			return result;
		}
		public static void SetAttributes(string Path, TSet Attributes)
		{
		}

		public TPath() {}
	}	

	public class TFile : TObject
	{
		public static TFileStream Create(string Path)/*# reintroduce */
		{
			TFileStream result = default;
			result = default;
			return result;
		}
		public static TFileStream Create(string Path, int BufferSize)/*# reintroduce */
		{
			TFileStream result = default;
			result = default;
			return result;
		}
		public static TFileStream Open(string Path, TFileMode Mode)
		{
			TFileStream result = default;
			result = default;
			return result;
		}
		public static TFileStream Open(string Path, TFileMode Mode, TFileAccess Access)
		{
			TFileStream result = default;
			result = default;
			return result;
		}
		public static TFileStream Open(string Path, TFileMode Mode, TFileAccess Access, TFileShare Share)
		{
			TFileStream result = default;
			result = default;
			return result;
		}
		public static TFileStream OpenRead(string Path)
		{
			TFileStream result = default;
			result = default;
			return result;
		}
		public static TFileStream OpenWrite(string Path)
		{
			TFileStream result = default;
			result = default;
			return result;
		}
		public static TStreamWriter CreateText(string Path)
		{
			TStreamWriter result = default;
			result = default;
			return result;
		}
		public static TStreamWriter AppendText(string Path)
		{
			TStreamWriter result = default;
			result = default;
			return result;
		}
		public static TStreamReader OpenText(string Path)
		{
			TStreamReader result = default;
			result = default;
			return result;
		}
		public static void WriteAllText(string Path, string Contents, TEncoding Encoding)
		{
		}
		public static void WriteAllText(string Path, string Contents)
		{
		}
		public static void AppendAllText(string Path, string Contents)
		{
		}
		public static void AppendAllText(string Path, string Contents, TEncoding Encoding)
		{
		}
		public static string ReadAllText(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string ReadAllText(string Path, TEncoding Encoding)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static void WriteAllBytes(string Path, byte[] Bytes)
		{
		}
		public static byte[] ReadAllBytes(string Path)
		{
			byte[] result = null;
			result = default;
			return result;
		}
		public static void WriteAllLines(string Path, string[] Contents)
		{
		}
		public static void WriteAllLines(string Path, string[] Contents, TEncoding Encoding)
		{
		}
		public static string[] ReadAllLines(string Path)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] ReadAllLines(string Path, TEncoding Encoding)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static void AppendAllLines(string Path, string[] Contents)
		{
		}
		public static void AppendAllLines(string Path, string[] Contents, TEncoding Encoding)
		{
		}
		public static bool Exists(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static void Delete(string Path)
		{
		}
		public static void Copy(string SourceFileName, string DestFileName)
		{
		}
		public static void Copy(string SourceFileName, string DestFileName, bool Overwrite)
		{
		}
		public static void Move(string SourceFileName, string DestFileName)
		{
		}
		public static void Replace(string SourceFileName, string DestinationFileName, string DestinationBackupFileName)
		{
		}
		public static TSet GetAttributes(string Path, bool FollowLink = true)
		{
			TSet result = new TSet();
			result = (new TSet());
			return result;
		}
		public static void SetAttributes(string Path, TSet Attributes)
		{
		}
		public static long GetSize(string Path)
		{
			long result = 0;
			result = 0;
			return result;
		}
		public static TDateTime GetCreationTime(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetCreationTimeUtc(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetLastAccessTime(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetLastAccessTimeUtc(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetLastWriteTime(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetLastWriteTimeUtc(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static void SetCreationTime(string Path, TDateTime CreationTime)
		{
		}
		public static void SetCreationTimeUtc(string Path, TDateTime CreationTime)
		{
		}
		public static void SetLastAccessTime(string Path, TDateTime LastAccessTime)
		{
		}
		public static void SetLastAccessTimeUtc(string Path, TDateTime LastAccessTime)
		{
		}
		public static void SetLastWriteTime(string Path, TDateTime LastWriteTime)
		{
		}
		public static void SetLastWriteTimeUtc(string Path, TDateTime LastWriteTime)
		{
		}

		public TFile() {}
	}	

	public class TDirectory : TObject
	{
public delegate bool TDirectory.TFilterPredicate(string Path, TSearchRec SearchRec);
		public static bool Exists(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static void CreateDirectory(string Path)
		{
		}
		public static void Delete(string Path)
		{
		}
		public static void Delete(string Path, bool Recursive)
		{
		}
		public static void Move(string SourceDirName, string DestDirName)
		{
		}
		public static void Copy(string SourceDirName, string DestDirName)
		{
		}
		public static string GetCurrentDirectory()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static void SetCurrentDirectory(string Path)
		{
		}
		public static string GetParent(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string GetDirectoryRoot(string Path)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public static string[] GetDirectories(string Path)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetDirectories(string Path, string SearchPattern)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetDirectories(string Path, string SearchPattern, TSearchOption SearchOption)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetFiles(string Path)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetFiles(string Path, string SearchPattern)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetFiles(string Path, string SearchPattern, TSearchOption SearchOption)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetFiles(string Path, string SearchPattern, TDirectory.TFilterPredicate Predicate)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetFileSystemEntries(string Path)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetFileSystemEntries(string Path, string SearchPattern)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetFileSystemEntries(string Path, string SearchPattern, TSearchOption SearchOption)
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static string[] GetLogicalDrives()
		{
			string[] result = null;
			result = default;
			return result;
		}
		public static bool IsRelativePath(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static bool IsEmpty(string Path)
		{
			bool result = false;
			result = false;
			return result;
		}
		public static TSet GetAttributes(string Path, bool FollowLink = true)
		{
			TSet result = new TSet();
			result = (new TSet());
			return result;
		}
		public static void SetAttributes(string Path, TSet Attributes)
		{
		}
		public static TDateTime GetCreationTime(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetCreationTimeUtc(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetLastAccessTime(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetLastAccessTimeUtc(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetLastWriteTime(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static TDateTime GetLastWriteTimeUtc(string Path)
		{
			TDateTime result = new TDateTime();
			result = 0;
			return result;
		}
		public static void SetCreationTime(string Path, TDateTime CreationTime)
		{
		}
		public static void SetCreationTimeUtc(string Path, TDateTime CreationTime)
		{
		}
		public static void SetLastAccessTime(string Path, TDateTime LastAccessTime)
		{
		}
		public static void SetLastAccessTimeUtc(string Path, TDateTime LastAccessTime)
		{
		}
		public static void SetLastWriteTime(string Path, TDateTime LastWriteTime)
		{
		}
		public static void SetLastWriteTimeUtc(string Path, TDateTime LastWriteTime)
		{
		}

		public TDirectory() {}
	}	
	public enum TSearchOption : byte {soTopDirectoryOnly,
                    soAllDirectories };
	public enum TFileMode : byte {fmCreateNew,
                fmCreate,
                fmOpen,
                fmOpenOrCreate,
                fmTruncate,
                fmAppend };
	public enum TFileAccess : byte {faRead,
                  faWrite,
                  faReadWrite };
	public enum TFileShare : byte {fsNone,
                 fsRead,
                 fsWrite,
                 fsReadWrite };
	public enum TFileAttribute : byte {faReadOnly,
                     faHidden,
                     faSystem,
                     faDirectory,
                     faArchive,
                     faDevice,
                     faNormal,
                     faTemporary,
                     faSparseFile,
                     faReparsePoint,
                     faCompressed,
                     faOffline,
                     faNotContentIndexed,
                     faEncrypted,
                     faSymLink };

	
} // class IoutilsInterface


file class IoutilsImplementation
{

} // class IoutilsImplementation

}  // namespace Ioutils

}  // namespace System

