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
            return global::System.IO.Path.GetFileName(Path);
		}
		public static string GetDirectoryName(string Path)
		{
            return global::System.IO.Path.GetDirectoryName(Path) ?? string.Empty;
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
			char[] result = new char[]{};
			result = default;
			return result;
		}
		public static char[] GetInvalidPathChars()
		{
			char[] result = new char[]{};
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
        // Delphi's overload without an explicit encoding writes UTF-8 without a BOM.
        public static void WriteAllText(string Path, string Contents)
        {
            global::System.IO.File.WriteAllText(
                Path, Contents ?? string.Empty,
                new global::System.Text.UTF8Encoding(false));
        }

        public static void WriteAllText(string Path, string Contents, TEncoding Encoding)
        {
            if (Encoding == null)
                throw new global::System.ArgumentNullException(nameof(Encoding));

            // The explicitly supplied TEncoding determines the preamble (BOM).
            byte[] preamble = Encoding.GetPreamble();
            byte[] data = Encoding.GetBytes(Contents ?? string.Empty);
            using (var stream = new global::System.IO.FileStream(
                Path, global::System.IO.FileMode.Create,
                global::System.IO.FileAccess.Write, global::System.IO.FileShare.Read))
            {
                if (preamble.Length != 0)
                    stream.Write(preamble, 0, preamble.Length);
                stream.Write(data, 0, data.Length);
            }
        }

        public static void AppendAllText(string Path, string Contents)
        {
            global::System.IO.File.AppendAllText(
                Path, Contents ?? string.Empty,
                new global::System.Text.UTF8Encoding(false));
        }

        public static void AppendAllText(string Path, string Contents, TEncoding Encoding)
        {
            if (Encoding == null)
                throw new global::System.ArgumentNullException(nameof(Encoding));

            byte[] preamble = Encoding.GetPreamble();
            byte[] data = Encoding.GetBytes(Contents ?? string.Empty);
            using (var stream = new global::System.IO.FileStream(
                Path, global::System.IO.FileMode.Append,
                global::System.IO.FileAccess.Write, global::System.IO.FileShare.Read))
            {
                // Only a newly created or empty file may receive a preamble.
                if (stream.Length == 0 && preamble.Length != 0)
                    stream.Write(preamble, 0, preamble.Length);
                stream.Write(data, 0, data.Length);
            }
        }

        public static string ReadAllText(string Path)
        {
            byte[] data = global::System.IO.File.ReadAllBytes(Path);
            // Detect BOMs before applying Delphi's default encoding.
            if (data.Length >= 4 && data[0] == 0x00 && data[1] == 0x00 &&
                data[2] == 0xFE && data[3] == 0xFF)
                return new global::System.Text.UTF32Encoding(true, false)
                    .GetString(data, 4, data.Length - 4);
            if (data.Length >= 4 && data[0] == 0xFF && data[1] == 0xFE &&
                data[2] == 0x00 && data[3] == 0x00)
                return new global::System.Text.UTF32Encoding(false, false)
                    .GetString(data, 4, data.Length - 4);
            if (data.Length >= 3 && data[0] == 0xEF && data[1] == 0xBB &&
                data[2] == 0xBF)
                return global::System.Text.Encoding.UTF8
                    .GetString(data, 3, data.Length - 3);
            if (data.Length >= 2 && data[0] == 0xFF && data[1] == 0xFE)
                return global::System.Text.Encoding.Unicode
                    .GetString(data, 2, data.Length - 2);
            if (data.Length >= 2 && data[0] == 0xFE && data[1] == 0xFF)
                return global::System.Text.Encoding.BigEndianUnicode
                    .GetString(data, 2, data.Length - 2);
            return TEncoding.Default.GetString(data);
        }

        public static string ReadAllText(string Path, TEncoding Encoding)
        {
            if (Encoding == null)
                throw new global::System.ArgumentNullException(nameof(Encoding));

            byte[] data = global::System.IO.File.ReadAllBytes(Path);
            byte[] preamble = Encoding.GetPreamble();
            int start = 0;
            if (preamble.Length > 0 && data.Length >= preamble.Length)
            {
                bool matches = true;
                for (int i = 0; i < preamble.Length; i++)
                {
                    if (data[i] != preamble[i])
                    {
                        matches = false;
                        break;
                    }
                }
                if (matches)
                    start = preamble.Length;
            }
            if (start == 0)
                return Encoding.GetString(data);

            byte[] textBytes = new byte[data.Length - start];
            global::System.Array.Copy(data, start, textBytes, 0, textBytes.Length);
            return Encoding.GetString(textBytes);
        }

		public static void WriteAllBytes(string Path, byte[] Bytes)
		{
			global::System.IO.File.WriteAllBytes(Path, Bytes);
		}
		public static byte[] ReadAllBytes(string Path)
		{
			return global::System.IO.File.ReadAllBytes(Path);
		}
        public static void WriteAllLines(string Path, string[] Contents)
        {
            global::System.IO.File.WriteAllLines(
                Path, Contents, new global::System.Text.UTF8Encoding(false));
        }

        public static void WriteAllLines(string Path, string[] Contents, TEncoding Encoding)
        {
            WriteAllText(Path, LinesToText(Contents), Encoding);
        }

        public static string[] ReadAllLines(string Path)
        {
            return TextToLines(ReadAllText(Path));
        }

        public static string[] ReadAllLines(string Path, TEncoding Encoding)
        {
            return TextToLines(ReadAllText(Path, Encoding));
        }

        private static string LinesToText(string[] contents)
        {
            if (contents == null)
                throw new global::System.ArgumentNullException(nameof(contents));

            var builder = new global::System.Text.StringBuilder();
            foreach (string line in contents)
            {
                builder.Append(line);
                builder.Append(global::System.Environment.NewLine);
            }
            return builder.ToString();
        }

        private static string[] TextToLines(string contents)
        {
            var lines = new global::System.Collections.Generic.List<string>();
            using (var reader = new global::System.IO.StringReader(contents))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    lines.Add(line);
            }
            return lines.ToArray();
        }
		public static void AppendAllLines(string Path, string[] Contents)
		{
			global::System.IO.File.AppendAllLines(Path, Contents);
		}
		public static void AppendAllLines(string Path, string[] Contents, TEncoding Encoding)
		{
			if (Encoding == null)
				throw new global::System.ArgumentNullException(nameof(Encoding));
			AppendAllText(Path, LinesToText(Contents), Encoding);
		}
		public static bool Exists(string Path)
		{
			return global::System.IO.File.Exists(Path);
		}
		public static void Delete(string Path)
		{
			global::System.IO.File.Delete(Path);
		}
		public static void Copy(string SourceFileName, string DestFileName)
		{
			global::System.IO.File.Copy(SourceFileName, DestFileName);
		}
		public static void Copy(string SourceFileName, string DestFileName, bool Overwrite)
		{
			global::System.IO.File.Copy(SourceFileName, DestFileName, Overwrite);
		}
		public static void Move(string SourceFileName, string DestFileName)
		{
			global::System.IO.File.Move(SourceFileName, DestFileName);
		}
		public static void Replace(string SourceFileName, string DestinationFileName, string DestinationBackupFileName)
		{
			global::System.IO.File.Replace(SourceFileName, DestinationFileName, DestinationBackupFileName);
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
			return new global::System.IO.FileInfo(Path).Length;
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
public delegate bool TFilterPredicate(string Path, TSearchRec SearchRec);
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
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetDirectories(string Path, string SearchPattern)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetDirectories(string Path, string SearchPattern, TSearchOption SearchOption)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetFiles(string Path)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetFiles(string Path, string SearchPattern)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetFiles(string Path, string SearchPattern, TSearchOption SearchOption)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetFiles(string Path, string SearchPattern, TFilterPredicate Predicate)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetFileSystemEntries(string Path)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetFileSystemEntries(string Path, string SearchPattern)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetFileSystemEntries(string Path, string SearchPattern, TSearchOption SearchOption)
		{
			string[] result = new string[]{};
			result = default;
			return result;
		}
		public static string[] GetLogicalDrives()
		{
			string[] result = new string[]{};
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

