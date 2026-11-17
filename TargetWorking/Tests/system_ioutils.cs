using System.Classes;
using System.Ioutils;
using System.Sysutils;
using System.Types;
using System;
using static System.Classes.ClassesInterface;
using static System.Ioutils.IoutilsInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;
using static System.Types.TypesInterface;
using static System_ioutils.System_ioutilsImplementation;
using static System_ioutils.System_ioutilsInterface;


namespace System_ioutils
{

    /*
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
    */


    public class System_ioutilsInterface
    {
        public static bool SIU_RunAllTests()
        {
            bool result = false;
            result = true;
            result = result & SIU_TestPathSeparators();
            result = result & SIU_TestPathCombine();
            result = result & SIU_TestPathExtension();
            result = result & SIU_TestPathFileName();
            result = result & SIU_TestPathDirectoryName();
            result = result & SIU_TestPathFullPath();
            result = result & SIU_TestPathRoot();
            result = result & SIU_TestPathRelative();
            result = result & SIU_TestPathUNC();
            result = result & SIU_TestPathExtendedPrefix();
            result = result & SIU_TestPathDrive();
            result = result & SIU_TestPathValidChars();
            result = result & SIU_TestPathInvalidChars();
            result = result & SIU_TestPathPattern();
            result = result & SIU_TestPathRandomNames();
            result = result & SIU_TestPathTempFile();
            result = result & SIU_TestPathHome();
            result = result & SIU_TestPathAttributes();
            result = result & SIU_TestFileExists();
            result = result & SIU_TestFileText();
            result = result & SIU_TestFileEncoding();
            result = result & SIU_TestFileAppend();
            result = result & SIU_TestFileBytes();
            result = result & SIU_TestFileLines();
            result = result & SIU_TestFileCopy();
            result = result & SIU_TestFileMove();
            result = result & SIU_TestFileDelete();
            result = result & SIU_TestFileCreateStream();
            result = result & SIU_TestFileOpenStream();
            result = result & SIU_TestFileReadWriteStreams();
            result = result & SIU_TestFileTextStreams();
            result = result & SIU_TestFileAttributes();
            result = result & SIU_TestFileLocalTimes();
            result = result & SIU_TestFileUtcTimes();
            result = result & SIU_TestFileReplace();
            result = result & SIU_TestFileMissingException();
            result = result & SIU_TestDirectoryExists();
            result = result & SIU_TestDirectoryNestedCreate();
            result = result & SIU_TestDirectoryDelete();
            result = result & SIU_TestDirectoryEmpty();
            result = result & SIU_TestDirectoryGetFiles();
            result = result & SIU_TestDirectoryRecursiveFiles();
            result = result & SIU_TestDirectoryFilter();
            result = result & SIU_TestDirectoryGetDirectories();
            result = result & SIU_TestDirectoryGetEntries();
            result = result & SIU_TestDirectoryCopy();
            result = result & SIU_TestDirectoryMove();
            result = result & SIU_TestDirectoryParentRoot();
            result = result & SIU_TestDirectoryRelative();
            result = result & SIU_TestDirectoryCurrent();
            result = result & SIU_TestDirectoryAttributes();
            result = result & SIU_TestDirectoryTimes();
            result = result & SIU_TestDirectoryUtcTimes();
            result = result & SIU_TestDirectoryLogicalDrives();
            return result;
        }

    } // class System_ioutilsInterface


    file class System_ioutilsImplementation
    {


        public class TSIU_Workspace : TObject
        {
            private string FRoot = string.Empty;
            public TSIU_Workspace()
            {
                ;
                FRoot = TPath.Combine(TPath.GetTempPath(), "d2c_siu_" + TPath.GetGUIDFileName(false));
                TDirectory.CreateDirectory(FRoot);
            }
            public override void Destroy()
            {
                if (!FDisposed)
                {
                    try
                    {
                        if ((FRoot != "") && TDirectory.Exists(FRoot))
                            TDirectory.Delete(FRoot, true);
                    }
                    finally
                    {
                        base.Destroy();
                    }
                }
            }

            public string FilePath(string AName)
            {
                string result = string.Empty;
                result = TPath.Combine(FRoot, AName);
                return result;
            }
            /*property Root : string read FRoot;*/
            public string Root
            {
                get
                {
                    return FRoot;
                }
            }
        }

        public static bool SIU_ContainsName(string[] APaths, string AName)
        {
            bool result = false;
            int I = 0;
            result = false;
            for (I = 0; I <= Length(APaths) - 1; I++)
            {
                if (SameText(TPath.GetFileName(APaths[I]), AName))
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }

        public static bool SIU_ContainsChar(char[] AChars, char AChar)
        {
            bool result = false;
            int I = 0;
            result = false;
            for (I = 0; I <= Length(AChars) - 1; I++)
            {
                if (AChars[I] == AChar)
                {
                    result = true;
                    return result;
                }
            }
            return result;
        }

        public static bool SIU_TestPathSeparators()
        {
            bool result = false;
            try
            {
                result = TPath.ExtensionSeparatorChar == '.';
                result = result && (TPath.DirectorySeparatorChar == '\\');
                result = result && (TPath.AltDirectorySeparatorChar == '/');
                result = result && (TPath.PathSeparator == ';');
                result = result && (TPath.VolumeSeparatorChar == ':');
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathCombine()
        {
            bool result = false;
            string A = string.Empty;
            string B = string.Empty;
            try
            {
                A = TPath.Combine("alpha", "beta");
                B = "alpha" + TPath.DirectorySeparatorChar + "beta";
                result = A == B;
                result = result && (TPath.Combine("", "beta") == "beta");
                result = result && (TPath.Combine("alpha", "") == "alpha");
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathExtension()
        {
            bool result = false;
            try
            {
                result = TPath.GetExtension("example.txt") == ".txt";
                result = result && (TPath.GetExtension("example") == "");
                result = result && TPath.HasExtension("example.txt");
                result = result && !TPath.HasExtension("example");
                result = result && (TPath.ChangeExtension("example.txt", ".dat") == "example.dat");
                result = result && (TPath.ChangeExtension("example.txt", "log") == "example.log");
                result = result && (TPath.ChangeExtension("example.txt", "") == "example.");
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathFileName()
        {
            bool result = false;
            string P = string.Empty;
            try
            {
                P = TPath.Combine("folder", "sample.data.txt");
                result = TPath.GetFileName(P) == "sample.data.txt";
                result = result && (TPath.GetFileNameWithoutExtension(P) == "sample.data");
                result = result && (TPath.GetFileName("plain.txt") == "plain.txt");
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathDirectoryName()
        {
            bool result = false;
            string ParentDir = string.Empty;
            string FileName = string.Empty;
            try
            {
                ParentDir = TPath.Combine(TPath.GetTempPath(), "siu_parent");
                FileName = TPath.Combine(ParentDir, "sample.txt");
                result = SameText(TPath.GetDirectoryName(FileName), ParentDir);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathFullPath()
        {
            bool result = false;
            string P = string.Empty;
            try
            {
                P = TPath.GetFullPath("siu_relative.txt");
                result = TPath.IsPathRooted(P);
                result = result && (TPath.GetFileName(P) == "siu_relative.txt");
                result = result && (TPath.GetFullPath(P) == P);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathRoot()
        {
            bool result = false;
            string P = string.Empty;
            string R = string.Empty;
            try
            {
                P = TPath.GetTempPath();
                R = TPath.GetPathRoot(P);
                result = R != "";
                result = result && TPath.IsPathRooted(R);
                result = result && TPath.IsPathRooted(P);
                result = result && !TPath.IsPathRooted("child\\file.txt");
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathRelative()
        {
            bool result = false;
            try
            {
                result = TPath.IsRelativePath("child.txt");
                result = result && TPath.IsRelativePath("child\\file.txt");
                result = result && !TPath.IsRelativePath(TPath.GetTempPath());
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathUNC()
        {
            bool result = false;
            try
            {
                result = !TPath.IsUNCPath("local.txt");
                result = result && !TPath.IsUNCRooted("local.txt");
                result = result && TPath.IsUNCPath("\\\\server\\share\\file.txt");
                result = result && TPath.IsUNCRooted("\\\\server\\share\\file.txt");
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathExtendedPrefix()
        {
            bool result = false;
            try
            {
                result = !TPath.IsExtendedPrefixed("local.txt");
                result = result && TPath.IsExtendedPrefixed("\\\\?\\C:\\siu.txt");
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathDrive()
        {
            bool result = false;
            string RootDir = string.Empty;
            try
            {
                result = !TPath.IsDriveRooted("relative.txt");
                RootDir = TPath.GetPathRoot(TPath.GetTempPath());
                result = result && TPath.IsDriveRooted("C:\\siu.txt");
                if ((DelphiLength(RootDir) >= 2) && (RootDir[2 - 1] == ':'))
                    result = result && TPath.DriveExists(RootDir);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathValidChars()
        {
            bool result = false;
            try
            {
                result = TPath.IsValidFileNameChar('A');
                result = result && TPath.IsValidPathChar('A');
                result = result && !TPath.IsValidFileNameChar('\x00');
                result = result && !TPath.IsValidPathChar('\x00');
                result = result && TPath.HasValidFileNameChars("good_name.txt", false);
                result = result && !TPath.HasValidFileNameChars("bad" + "\x0d" + "name", false);
                result = result && TPath.HasValidPathChars("folder" + TPath.DirectorySeparatorChar + "item.txt", false);
                result = result && !TPath.HasValidPathChars("bad" + "\x0d" + "path", false);
                result = result && !TPath.IsValidFileNameChar('*');
                result = result && TPath.HasValidFileNameChars("name*.txt", true);
                result = result && !TPath.HasValidFileNameChars("name*.txt", false);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathInvalidChars()
        {
            bool result = false;
            char[] FileChars = null;
            char[] PathChars = null;
            try
            {
                FileChars = TPath.GetInvalidFileNameChars();
                PathChars = TPath.GetInvalidPathChars();
                result = SIU_ContainsChar(FileChars, '\x00');
                result = result && SIU_ContainsChar(PathChars, '\x00');
                result = result && !SIU_ContainsChar(FileChars, 'A');
                result = result && !SIU_ContainsChar(PathChars, 'A');
                result = result && SIU_ContainsChar(FileChars, '*');
                result = result && !SIU_ContainsChar(PathChars, '*');
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathPattern()
        {
            bool result = false;
            try
            {
                result = TPath.MatchesPattern("alpha.txt", "*.txt", true);
                result = result && TPath.MatchesPattern("alpha.txt", "a*.txt", true);
                result = result && !TPath.MatchesPattern("alpha.dat", "*.txt", true);
                result = result && TPath.MatchesPattern("ALPHA.TXT", "*.txt", false);
                // seems to be a bug in older delphi version
                //    Result := Result and
                //      not TPath.MatchesPattern('ALPHA.TXT', '*.txt', True);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathRandomNames()
        {
            bool result = false;
            string A = string.Empty;
            string B = string.Empty;
            string C = string.Empty;
            string D = string.Empty;
            try
            {
                A = TPath.GetRandomFileName();
                B = TPath.GetRandomFileName();
                C = TPath.GetGUIDFileName(false);
                D = TPath.GetGUIDFileName(true);
                result = (A != "") && (B != "") && (A != B);
                result = result && (DelphiLength(C) == 32);
                result = result && (DelphiLength(D) == 36);
                result = result && (DelphiPos(('-').ToString(), (D).ToString()) > 0);
                result = result && TPath.HasValidFileNameChars(A, false);
                result = result && TPath.HasValidFileNameChars(C, false);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathTempFile()
        {
            bool result = false;
            string FileName = string.Empty;
            FileName = "";
            try
            {
                try
                {
                    FileName = TPath.GetTempFileName();
                    result = TFile.Exists(FileName);
                    result = result && (Length(TFile.ReadAllBytes(FileName)) == 0);
                }
                finally
                {
                    if ((FileName != "") && TFile.Exists(FileName))
                        TFile.Delete(FileName);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathHome()
        {
            bool result = false;
            string HomeDir = string.Empty;
            try
            {
                HomeDir = TPath.GetHomePath();
                result = HomeDir != "";
                result = result && TPath.IsPathRooted(HomeDir);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestPathAttributes()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string FileName = string.Empty;
            TSet Attr = new TSet();
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                FileName = W.FilePath("attrs.txt");
                TFile.WriteAllText(FileName, "abc");
                Attr = TPath.GetAttributes(FileName);
                TPath.SetAttributes(FileName, Attr);
                result = TFile.Exists(FileName);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileExists()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("exists.txt");
                result = !TFile.Exists(P);
                TFile.WriteAllText(P, "abc");
                result = result && TFile.Exists(P);
                result = result && !TFile.Exists(W.Root);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileText()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("text.txt");
                TFile.WriteAllText(P, "first");
                result = TFile.ReadAllText(P) == "first";
                TFile.WriteAllText(P, "second");
                result = result && (TFile.ReadAllText(P) == "second");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileEncoding()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("encoding.txt");
                TFile.WriteAllText(P, "ASCII 123", TEncoding.ASCII);
                result = TFile.ReadAllText(P, TEncoding.ASCII) == "ASCII 123";
                result = result && (TFile.ReadAllText(P) == "ASCII 123");
                TFile.WriteAllText(P, "UTF8 123", TEncoding.UTF8);
                result = result && (TFile.ReadAllText(P) == "UTF8 123");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileAppend()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("append.txt");
                TFile.AppendAllText(P, "one");
                TFile.AppendAllText(P, "two");
                result = TFile.ReadAllText(P) == "onetwo";
                TFile.AppendAllText(P, "three", TEncoding.UTF8);
                result = result && (TFile.ReadAllText(P) == "onetwothree");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileBytes()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            byte[] A = null;
            byte[] B = null;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("bytes.bin");
                SetLength(ref A, 4);
                A[0] = 0;
                A[1] = 1;
                A[2] = 127;
                A[3] = 255;
                TFile.WriteAllBytes(P, A);
                B = TFile.ReadAllBytes(P);
                result = Length(B) == 4;
                if (Length(B) == 4)
                {
                    result = result && (B[0] == 0);
                    result = result && (B[1] == 1);
                    result = result && (B[2] == 127);
                    result = result && (B[3] == 255);
                }
                SetLength(ref A, 0);
                TFile.WriteAllBytes(P, A);
                result = result && (Length(TFile.ReadAllBytes(P)) == 0);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileLines()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            string[] A = null;
            string[] B = null;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("lines.txt");
                SetLength(ref A, 3);
                A[0] = "red";
                A[1] = "green";
                A[2] = "blue";
                TFile.WriteAllLines(P, A);
                B = TFile.ReadAllLines(P);
                result = Length(B) == 3;
                if (Length(B) == 3)
                {
                    result = result && (B[0] == "red");
                    result = result && (B[1] == "green");
                    result = result && (B[2] == "blue");
                }
                TFile.WriteAllLines(P, A, TEncoding.UTF8);
                B = TFile.ReadAllLines(P, TEncoding.UTF8);
                result = result && (Length(B) == 3);
                if (Length(B) == 3)
                    result = result && (B[1] == "green");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileCopy()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string A = string.Empty;
            string B = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                A = W.FilePath("source.txt");
                B = W.FilePath("target.txt");
                TFile.WriteAllText(A, "source");
                TFile.Copy(A, B);
                result = TFile.ReadAllText(B) == "source";
                result = result && (TFile.ReadAllText(A) == "source");
                TFile.WriteAllText(A, "new");
                TFile.Copy(A, B, true);
                result = result && (TFile.ReadAllText(B) == "new");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileMove()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string A = string.Empty;
            string B = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                A = W.FilePath("before.txt");
                B = W.FilePath("after.txt");
                TFile.WriteAllText(A, "moved");
                TFile.Move(A, B);
                result = !TFile.Exists(A);
                result = result && TFile.Exists(B);
                result = result && (TFile.ReadAllText(B) == "moved");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileDelete()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("delete.txt");
                TFile.WriteAllText(P, "remove");
                result = TFile.Exists(P);
                TFile.Delete(P);
                result = result && !TFile.Exists(P);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileCreateStream()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TFileStream Stream = default;
            byte Value = 0;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("create.bin");
                Stream = TFile.Create(P);
                try
                {
                    Value = 42;
                    Stream.WriteBuffer(UntypedPointer.FromValue(Value), (int)DelphiTypeSize.Byte);
                }
                finally
                {
                    TObject.Free(Stream);
                }
                result = TFile.Exists(P);
                result = result && (Length(TFile.ReadAllBytes(P)) == 1);
                Stream = TFile.Create(P);
                try
                {
                    result = result && (Stream.Size == 0);
                }
                finally
                {
                    TObject.Free(Stream);
                }
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileOpenStream()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TFileStream Stream = default;
            byte Value = 0;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("open.bin");
                TFile.WriteAllText(P, ("0").ToString(), TEncoding.ASCII);
                Stream = TFile.Open(P, TFileMode.fmOpen, TFileAccess.faReadWrite);
                try
                {
                    Value = 91;
                    Stream.WriteBuffer(UntypedPointer.FromValue(Value), 1);
                }
                finally
                {
                    TObject.Free(Stream);
                }
                Stream = TFile.Open(P, TFileMode.fmOpen, TFileAccess.faRead);
                try
                {
                    Value = 0;
                    Stream.ReadBuffer(Pointer<byte>.FromStorage(new Ref<byte>(() => Value, __d2cUntypedValue => Value = __d2cUntypedValue), DelphiTypeLayout.SizeOf<byte>()).ToUntypedPointer(), 1);
                    result = Value == 91;
                }
                finally
                {
                    TObject.Free(Stream);
                }
                Stream = TFile.Open(P, TFileMode.fmOpen, TFileAccess.faRead, TFileShare.fsRead);
                try
                {
                    result = result && (Stream.Size == 1);
                }
                finally
                {
                    TObject.Free(Stream);
                }
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileReadWriteStreams()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TFileStream Stream = default;
            byte Value = 0;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("rw.bin");
                TFile.WriteAllBytes(P, TEncoding.ASCII.GetBytes("ab"));
                Stream = TFile.OpenWrite(P);
                try
                {
                    Value = (byte)(int)('X');
                    Stream.WriteBuffer(UntypedPointer.FromValue(Value), 1);
                }
                finally
                {
                    TObject.Free(Stream);
                }
                Stream = TFile.OpenRead(P);
                try
                {
                    Value = 0;
                    Stream.ReadBuffer(Pointer<byte>.FromStorage(new Ref<byte>(() => Value, __d2cUntypedValue => Value = __d2cUntypedValue), DelphiTypeLayout.SizeOf<byte>()).ToUntypedPointer(), 1);
                    result = Value == (int)('X');
                    result = result && (Stream.Size == 2);
                }
                finally
                {
                    TObject.Free(Stream);
                }
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileTextStreams()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TStreamWriter Writer = default;
            TStreamReader Reader = default;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("streams.txt");
                Writer = TFile.CreateText(P);
                try
                {
                    Writer.Write("one");
                }
                finally
                {
                    TObject.Free(Writer);
                }
                Writer = TFile.AppendText(P);
                try
                {
                    Writer.Write("two");
                }
                finally
                {
                    TObject.Free(Writer);
                }
                Reader = TFile.OpenText(P);
                try
                {
                    result = Reader.ReadToEnd() == "onetwo";
                }
                finally
                {
                    TObject.Free(Reader);
                }
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileAttributes()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TSet Original = new TSet();
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("hidden.txt");
                TFile.WriteAllText(P, "attr");
                Original = TFile.GetAttributes(P);
                try
                {
                    TFile.SetAttributes(P, (new TSet() << (int)TFileAttribute.faHidden));
                    result = TFile.GetAttributes(P).Contains((int)(TFileAttribute.faHidden));
                }
                finally
                {
                    TFile.SetAttributes(P, Original);
                }
                result = result && TFile.Exists(P);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileLocalTimes()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TDateTime D = new TDateTime();
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("localtime.txt");
                TFile.WriteAllText(P, "time");
                D = EncodeDate(2020, 3, 4) + EncodeTime(12, 34, 56, 0);
                TFile.SetLastWriteTime(P, D);
                result = Abs(TFile.GetLastWriteTime(P) - D) < (3.0D / 86400.0D);
                D = TFile.GetCreationTime(P);
                TFile.SetCreationTime(P, D);
                result = result && (TFile.GetCreationTime(P) > 0);
                D = TFile.GetLastAccessTime(P);
                TFile.SetLastAccessTime(P, D);
                result = result && (TFile.GetLastAccessTime(P) > 0);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileUtcTimes()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TDateTime D = new TDateTime();
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("utctime.txt");
                TFile.WriteAllText(P, "time");
                //D := EncodeDate(2020, 4, 5) + EncodeTime(11, 22, 33, 0); // Delphi sumertime bug
                D = EncodeDate(2020, 1, 15) + EncodeTime(11, 22, 33, 0);
                TFile.SetLastWriteTimeUtc(P, D);
                result = Abs(TFile.GetLastWriteTimeUtc(P) - D) < (3.0D / 86400.0D);
                D = TFile.GetCreationTimeUtc(P);
                TFile.SetCreationTimeUtc(P, D);
                result = result && (TFile.GetCreationTimeUtc(P) > 0);
                D = TFile.GetLastAccessTimeUtc(P);
                TFile.SetLastAccessTimeUtc(P, D);
                result = result && (TFile.GetLastAccessTimeUtc(P) > 0);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileReplace()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string A = string.Empty;
            string B = string.Empty;
            string Backup = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                A = W.FilePath("replacement.txt");
                B = W.FilePath("destination.txt");
                Backup = W.FilePath("backup.txt");
                TFile.WriteAllText(A, "new content");
                TFile.WriteAllText(B, "old content");
                TFile.Replace(A, B, Backup);
                result = !TFile.Exists(A);
                result = result && (TFile.ReadAllText(B) == "new content");
                result = result && (TFile.ReadAllText(Backup) == "old content");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestFileMissingException()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            string Content = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("missing.txt");
                try
                {
                    Content = TFile.ReadAllText(P);
                    result = false;
                }
                catch (DException E)
                {
                    result = true;
                }
                result = result && !TFile.Exists(P);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryExists()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("dir");
                result = !TDirectory.Exists(P);
                TDirectory.CreateDirectory(P);
                result = result && TDirectory.Exists(P);
                result = result && !TFile.Exists(P);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryNestedCreate()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            string Q = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("level1");
                Q = TPath.Combine(P, "level2");
                TDirectory.CreateDirectory(Q);
                result = TDirectory.Exists(P);
                result = result && TDirectory.Exists(Q);
                TDirectory.CreateDirectory(Q);
                result = result && TDirectory.Exists(Q);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryDelete()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string A = string.Empty;
            string B = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                A = W.FilePath("empty");
                TDirectory.CreateDirectory(A);
                TDirectory.Delete(A);
                result = !TDirectory.Exists(A);
                A = W.FilePath("nested");
                B = TPath.Combine(A, "child");
                TDirectory.CreateDirectory(B);
                TFile.WriteAllText(TPath.Combine(B, "item.txt"), "abc");
                TDirectory.Delete(A, true);
                result = result && !TDirectory.Exists(A);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryEmpty()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("empty");
                TDirectory.CreateDirectory(P);
                result = TDirectory.IsEmpty(P);
                TFile.WriteAllText(TPath.Combine(P, "item.txt"), "abc");
                result = result && !TDirectory.IsEmpty(P);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryGetFiles()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string[] A = null;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                TFile.WriteAllText(W.FilePath("one.txt"), ("1").ToString());
                TFile.WriteAllText(W.FilePath("two.dat"), ("2").ToString());
                A = TDirectory.GetFiles(W.Root);
                result = Length(A) == 2;
                result = result && SIU_ContainsName(A, "one.txt");
                result = result && SIU_ContainsName(A, "two.dat");
                A = TDirectory.GetFiles(W.Root, "*.txt");
                result = result && (Length(A) == 1);
                result = result && SIU_ContainsName(A, "one.txt");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryRecursiveFiles()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string SubDir = string.Empty;
            string[] A = null;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                SubDir = W.FilePath("sub");
                TDirectory.CreateDirectory(SubDir);
                TFile.WriteAllText(W.FilePath("top.txt"), "top");
                TFile.WriteAllText(TPath.Combine(SubDir, "deep.txt"), "deep");
                A = TDirectory.GetFiles(W.Root, "*.txt", TSearchOption.soTopDirectoryOnly);
                result = Length(A) == 1;
                A = TDirectory.GetFiles(W.Root, "*.txt", TSearchOption.soAllDirectories);
                result = result && (Length(A) == 2);
                result = result && SIU_ContainsName(A, "top.txt");
                result = result && SIU_ContainsName(A, "deep.txt");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryFilter()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string[] A = null;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                TFile.WriteAllText(W.FilePath("keep.txt"), ("a").ToString());
                TFile.WriteAllText(W.FilePath("skip.dat"), ("b").ToString());
                A = TDirectory.GetFiles(W.Root, "*.*", (TDirectory.TFilterPredicate)delegate (string Path, TSearchRec SearchRec)
            {
                bool result_1 = false;
                result_1 = SameText(ExtractFileExt(SearchRec.Name), ".txt");
                return result_1;
            });
                result = Length(A) == 1;
                result = result && SIU_ContainsName(A, "keep.txt");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryGetDirectories()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string[] A = null;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                TDirectory.CreateDirectory(W.FilePath("alpha"));
                TDirectory.CreateDirectory(W.FilePath("beta"));
                A = TDirectory.GetDirectories(W.Root);
                result = Length(A) == 2;
                result = result && SIU_ContainsName(A, "alpha");
                result = result && SIU_ContainsName(A, "beta");
                A = TDirectory.GetDirectories(W.Root, "a*");
                result = result && (Length(A) == 1);
                result = result && SIU_ContainsName(A, "alpha");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryGetEntries()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string[] A = null;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                TDirectory.CreateDirectory(W.FilePath("sub"));
                TFile.WriteAllText(W.FilePath("item.txt"), ("x").ToString());
                A = TDirectory.GetFileSystemEntries(W.Root);
                result = Length(A) == 2;
                result = result && SIU_ContainsName(A, "sub");
                result = result && SIU_ContainsName(A, "item.txt");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryCopy()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string SourceDir = string.Empty;
            string DestDir = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                SourceDir = W.FilePath("source");
                DestDir = W.FilePath("copy");
                TDirectory.CreateDirectory(SourceDir);
                TFile.WriteAllText(TPath.Combine(SourceDir, "data.txt"), "data");
                TDirectory.Copy(SourceDir, DestDir);
                result = TDirectory.Exists(SourceDir);
                result = result && TDirectory.Exists(DestDir);
                result = result && (TFile.ReadAllText(TPath.Combine(DestDir, "data.txt")) == "data");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryMove()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string SourceDir = string.Empty;
            string DestDir = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                SourceDir = W.FilePath("old");
                DestDir = W.FilePath("new");
                TDirectory.CreateDirectory(SourceDir);
                TFile.WriteAllText(TPath.Combine(SourceDir, "data.txt"), "data");
                TDirectory.Move(SourceDir, DestDir);
                result = !TDirectory.Exists(SourceDir);
                result = result && TDirectory.Exists(DestDir);
                result = result && (TFile.ReadAllText(TPath.Combine(DestDir, "data.txt")) == "data");
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryParentRoot()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            string R = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("child");
                TDirectory.CreateDirectory(P);
                R = TDirectory.GetDirectoryRoot(P);
                result = SameText(TDirectory.GetParent(P), W.Root);
                result = result && SameText(R, TPath.GetPathRoot(P));
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryRelative()
        {
            bool result = false;
            try
            {
                result = TDirectory.IsRelativePath("child");
                result = result && !TDirectory.IsRelativePath(TPath.GetTempPath());
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryCurrent()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string OriginalDir = string.Empty;
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                OriginalDir = TDirectory.GetCurrentDirectory();
                try
                {
                    TDirectory.SetCurrentDirectory(W.Root);
                    result = SameText(TDirectory.GetCurrentDirectory(), W.Root);
                }
                finally
                {
                    TDirectory.SetCurrentDirectory(OriginalDir);
                }
                result = result && SameText(TDirectory.GetCurrentDirectory(), OriginalDir);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryAttributes()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TSet Attr = new TSet();
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("attribute_dir");
                TDirectory.CreateDirectory(P);
                Attr = TDirectory.GetAttributes(P);
                result = Attr.Contains((int)(TFileAttribute.faDirectory));
                TDirectory.SetAttributes(P, Attr);
                result = result && TDirectory.Exists(P);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryTimes()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TDateTime D = new TDateTime();
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("time_dir");
                TDirectory.CreateDirectory(P);
                D = TDirectory.GetCreationTime(P);
                TDirectory.SetCreationTime(P, D);
                result = TDirectory.GetCreationTime(P) > 0;
                D = TDirectory.GetLastAccessTime(P);
                TDirectory.SetLastAccessTime(P, D);
                result = result && (TDirectory.GetLastAccessTime(P) > 0);
                D = TDirectory.GetLastWriteTime(P);
                TDirectory.SetLastWriteTime(P, D);
                result = result && (TDirectory.GetLastWriteTime(P) > 0);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryUtcTimes()
        {
            bool result = false;
            TSIU_Workspace W = default;
            string P = string.Empty;
            TDateTime D = new TDateTime();
            result = false;
            W = default;
            try
            {
                W = new TSIU_Workspace();
                P = W.FilePath("utc_dir");
                TDirectory.CreateDirectory(P);
                D = TDirectory.GetCreationTimeUtc(P);
                TDirectory.SetCreationTimeUtc(P, D);
                result = TDirectory.GetCreationTimeUtc(P) > 0;
                D = TDirectory.GetLastAccessTimeUtc(P);
                TDirectory.SetLastAccessTimeUtc(P, D);
                result = result && (TDirectory.GetLastAccessTimeUtc(P) > 0);
                D = TDirectory.GetLastWriteTimeUtc(P);
                TDirectory.SetLastWriteTimeUtc(P, D);
                result = result && (TDirectory.GetLastWriteTimeUtc(P) > 0);
            }
            catch
            {
                result = false;
            }
            try
            {
                TObject.Free(W);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIU_TestDirectoryLogicalDrives()
        {
            bool result = false;
            string[] A = null;
            try
            {
                A = TDirectory.GetLogicalDrives();
                result = Length(A) > 0;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // Force evaluation of every test, even after a previous failure.
        // The translated C# runner must likewise use eager boolean evaluation.
        /*$B+*/

        /*$B-*/
    } // class System_ioutilsImplementation

}  // namespace System_ioutils

