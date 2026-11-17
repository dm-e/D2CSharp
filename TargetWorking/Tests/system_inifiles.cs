using System.Classes;
using System.Inifiles;
using System.Sysutils;
using System;
using static System.Classes.ClassesInterface;
using static System.Inifiles.InifilesInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;
using static System_inifiles.System_inifilesImplementation;
using static System_inifiles.System_inifilesInterface;


namespace System_inifiles
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


    public class System_inifilesInterface
    {
        public static bool SIF_RunAllTests()
        {
            bool result = false;
            result = true;
            result = result & SIF_TestMemFileName();
            result = result & SIF_TestMemMissingString();
            result = result & SIF_TestMemMissingInteger();
            result = result & SIF_TestMemMissingBool();
            result = result & SIF_TestMemMissingFloat();
            result = result & SIF_TestMemMissingDate();
            result = result & SIF_TestMemMissingTime();
            result = result & SIF_TestMemMissingDateTime();
            result = result & SIF_TestMemReadString();
            result = result & SIF_TestMemWriteEmptyString();
            result = result & SIF_TestMemOverwriteString();
            result = result & SIF_TestMemDifferentKeys();
            result = result & SIF_TestMemDifferentSections();
            result = result & SIF_TestMemWriteIntegerPositive();
            result = result & SIF_TestMemWriteIntegerNegative();
            result = result & SIF_TestMemWriteIntegerZero();
            result = result & SIF_TestMemWriteIntegerMax();
            result = result & SIF_TestMemReadIntegerInvalid();
            result = result & SIF_TestMemWriteBoolTrue();
            result = result & SIF_TestMemWriteBoolFalse();
            result = result & SIF_TestMemWriteFloatPositive();
            result = result & SIF_TestMemWriteFloatNegative();
            result = result & SIF_TestMemWriteDate();
            result = result & SIF_TestMemWriteTime();
            result = result & SIF_TestMemWriteDateTime();
            result = result & SIF_TestMemSectionExists();
            result = result & SIF_TestMemSectionMissing();
            result = result & SIF_TestMemValueExists();
            result = result & SIF_TestMemValueMissing();
            result = result & SIF_TestMemReadSections();
            result = result & SIF_TestMemReadSectionsEmpty();
            result = result & SIF_TestMemReadSection();
            result = result & SIF_TestMemReadSectionMissing();
            result = result & SIF_TestMemReadSectionValues();
            result = result & SIF_TestMemReadSectionValuesMissing();
            result = result & SIF_TestMemDeleteKey();
            result = result & SIF_TestMemEraseSection();
            result = result & SIF_TestMemOverwriteType();
            result = result & SIF_TestMemUpdateFile();
            result = result & SIF_TestFileFileName();
            result = result & SIF_TestFileMissingString();
            result = result & SIF_TestFileMissingInteger();
            result = result & SIF_TestFileMissingBool();
            result = result & SIF_TestFileMissingFloat();
            result = result & SIF_TestFileMissingDate();
            result = result & SIF_TestFileMissingTime();
            result = result & SIF_TestFileMissingDateTime();
            result = result & SIF_TestFileReadString();
            result = result & SIF_TestFileWriteEmptyString();
            result = result & SIF_TestFileOverwriteString();
            result = result & SIF_TestFileDifferentKeys();
            result = result & SIF_TestFileDifferentSections();
            result = result & SIF_TestFileWriteIntegerPositive();
            result = result & SIF_TestFileWriteIntegerNegative();
            result = result & SIF_TestFileWriteIntegerZero();
            result = result & SIF_TestFileWriteIntegerMax();
            result = result & SIF_TestFileReadIntegerInvalid();
            result = result & SIF_TestFileWriteBoolTrue();
            result = result & SIF_TestFileWriteBoolFalse();
            result = result & SIF_TestFileWriteFloatPositive();
            result = result & SIF_TestFileWriteFloatNegative();
            result = result & SIF_TestFileWriteDate();
            result = result & SIF_TestFileWriteTime();
            result = result & SIF_TestFileWriteDateTime();
            result = result & SIF_TestFileSectionExists();
            result = result & SIF_TestFileSectionMissing();
            result = result & SIF_TestFileValueExists();
            result = result & SIF_TestFileValueMissing();
            result = result & SIF_TestFileReadSections();
            result = result & SIF_TestFileReadSectionsEmpty();
            result = result & SIF_TestFileReadSection();
            result = result & SIF_TestFileReadSectionMissing();
            result = result & SIF_TestFileReadSectionValues();
            result = result & SIF_TestFileReadSectionValuesMissing();
            result = result & SIF_TestFileDeleteKey();
            result = result & SIF_TestFileEraseSection();
            result = result & SIF_TestFileOverwriteType();
            result = result & SIF_TestFileUpdateFile();
            result = result & SIF_TestMemDefaultCaseInsensitive();
            result = result & SIF_TestMemCaseSensitiveKeys();
            result = result & SIF_TestMemCaseSensitiveSections();
            result = result & SIF_TestMemCaseSensitiveProperty();
            result = result & SIF_TestMemClear();
            result = result & SIF_TestMemGetStrings();
            result = result & SIF_TestMemSetStrings();
            result = result & SIF_TestMemValuesInMemoryBeforeSave();
            result = result & SIF_TestMemPersistence();
            result = result & SIF_TestMemSnapshotBeforeUpdate();
            result = result & SIF_TestMemNoImplicitSave();
            result = result & SIF_TestMemReloadFromDisk();
            result = result & SIF_TestMemUpdateOverwrite();
            result = result & SIF_TestMemDeletePersisted();
            result = result & SIF_TestMemErasePersisted();
            result = result & SIF_TestMemRenameNoReload();
            result = result & SIF_TestMemRenameReload();
            result = result & SIF_TestMemSetStringsComments();
            result = result & SIF_TestMemEncodingCreate();
            result = result & SIF_TestMemBinaryStream();
            result = result & SIF_TestMemBinaryStreamMissing();
            result = result & SIF_TestFileBinaryStream();
            result = result & SIF_TestFileBinaryStreamMissing();
            result = result & SIF_TestFileImmediatePersistence();
            result = result & SIF_TestFilePersistAfterDestroy();
            result = result & SIF_TestFileDeletePersisted();
            result = result & SIF_TestCustomMemDispatch();
            result = result & SIF_TestCustomFileDispatch();
            return result;
        }

    } // class System_inifilesInterface


    file class System_inifilesImplementation
    {


        // TCustomIniFile.ReadInt64/WriteInt64 first appeared in Delphi 10.4.
        // Delphi XE3: CompilerVersion = 24.0; Delphi 10.4: CompilerVersion = 34.0.


        // TMemIniFile.Modified and AutoSave were introduced in Delphi 10.1 Berlin.
        // Delphi 10.1 Berlin: CompilerVersion = 31.0.


        // Every test uses its own temporary files. No VCL dependency.
        // Only the common runner is declared in the interface section.

        public class TSIF_Workspace : TObject
        {
            private string FFileName = string.Empty;
            private string FOtherFileName = string.Empty;
            public TSIF_Workspace()
            {
                Guid G = new Guid();
                string P = string.Empty;
                string N = string.Empty;
                ;
                if (CreateGUID(out G) != 0)
                    throw new DException("SIF: Cannot create temporary file name");
                P = GetEnvironmentVariable("TEMP");
                if (P == "")
                    P = GetEnvironmentVariable("TMP");
                if (P == "")
                    P = GetCurrentDir();
                N = "d2c_sif_" + GUIDToString(G).Substring(2 - 1, MaxSubstringLength(GUIDToString(G), 2 - 1, 36));
                FFileName = IncludeTrailingPathDelimiter(P) + N + ".ini";
                FOtherFileName = IncludeTrailingPathDelimiter(P) + N + "_other.ini";
            }
            public override void Destroy()
            {
                if (!FDisposed)
                {
                    try
                    {
                        if ((FFileName != "") && FileExists(FFileName))
                            DeleteFile(FFileName);
                        if ((FOtherFileName != "") && FileExists(FOtherFileName))
                            DeleteFile(FOtherFileName);
                    }
                    finally
                    {
                        base.Destroy();
                    }
                }
            }
            /*property FileName : string read FFileName;*/
            public string FileName
            {
                get
                {
                    return FFileName;
                }
            }
            /*property OtherFileName : string read FOtherFileName;*/
            public string OtherFileName
            {
                get
                {
                    return FOtherFileName;
                }
            }
        }

        public static bool SIF_Close(double A, double B)
        {
            bool result = false;
            result = Abs(A - B) < 0.000001D;
            return result;
        }

        public static bool SIF_TestMemFileName()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        result = Ini.FileName == W.FileName;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemMissingString()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        result = Ini.ReadString("Unknown", ("X").ToString(), "fallback") == "fallback";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemMissingInteger()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        result = Ini.ReadInteger("Unknown", ("X").ToString(), 12345) == 12345;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemMissingBool()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        result = Ini.ReadBool("Unknown", ("X").ToString(), true);
                        result = result && (!Ini.ReadBool("Unknown", ("X").ToString(), false));
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemMissingFloat()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        result = SIF_Close(Ini.ReadFloat("Unknown", ("X").ToString(), 7.125D), 7.125D);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemMissingDate()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        D = EncodeDate(2021, 2, 3);
                        result = Ini.ReadDate("Unknown", ("X").ToString(), D) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemMissingTime()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        D = EncodeTime(11, 12, 13, 0);
                        result = Ini.ReadTime("Unknown", ("X").ToString(), D) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemMissingDateTime()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        D = EncodeDate(2021, 2, 3) + EncodeTime(11, 12, 13, 0);
                        result = Ini.ReadDateTime("Unknown", ("X").ToString(), D) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReadString()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("General", "Name", "Example");
                        result = Ini.ReadString("General", "Name", "") == "Example";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteEmptyString()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("General", "Blank", "");
                        result = Ini.ReadString("General", "Blank", "fallback") == "";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemOverwriteString()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("General", "Name", "First");
                        Ini.WriteString("General", "Name", "Second");
                        result = Ini.ReadString("General", "Name", "") == "Second";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemDifferentKeys()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("General", ("A").ToString(), "one");
                        Ini.WriteString("General", ("B").ToString(), "two");
                        result = Ini.ReadString("General", ("A").ToString(), "") == "one";
                        result = result && (Ini.ReadString("General", ("B").ToString(), "") == "two");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemDifferentSections()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("First", "Key", ("A").ToString());
                        Ini.WriteString("Second", "Key", ("B").ToString());
                        result = Ini.ReadString("First", "Key", "") == "A";
                        result = result && (Ini.ReadString("Second", "Key", "") == "B");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteIntegerPositive()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Numbers", "Count", 123456);
                        result = Ini.ReadInteger("Numbers", "Count", -1) == 123456;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteIntegerNegative()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Numbers", "Count", -32768);
                        result = Ini.ReadInteger("Numbers", "Count", 0) == -32768;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteIntegerZero()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Numbers", "Count", 0);
                        result = Ini.ReadInteger("Numbers", "Count", 100) == 0;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteIntegerMax()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Numbers", "Count", MaxInt);
                        result = Ini.ReadInteger("Numbers", "Count", 0) == MaxInt;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReadIntegerInvalid()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Numbers", "Count", "not_a_number");
                        result = Ini.ReadInteger("Numbers", "Count", 77) == 77;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteBoolTrue()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteBool("Flags", "Enabled", true);
                        result = Ini.ReadBool("Flags", "Enabled", false);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteBoolFalse()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteBool("Flags", "Enabled", false);
                        result = !Ini.ReadBool("Flags", "Enabled", true);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteFloatPositive()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteFloat("Numbers", "Rate", 12.375D);
                        result = SIF_Close(Ini.ReadFloat("Numbers", "Rate", 0.0F), 12.375D);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteFloatNegative()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteFloat("Numbers", "Rate", -0.125D);
                        result = SIF_Close(Ini.ReadFloat("Numbers", "Rate", 0.0F), -0.125D);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteDate()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        D = EncodeDate(2020, 5, 17);
                        Ini.WriteDate("Dates", ("D").ToString(), D);
                        result = Ini.ReadDate("Dates", ("D").ToString(), 0) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteTime()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        D = EncodeTime(13, 45, 20, 0);
                        Ini.WriteTime("Dates", ("T").ToString(), D);
                        result = Ini.ReadTime("Dates", ("T").ToString(), 0) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemWriteDateTime()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        D = EncodeDate(2020, 5, 17) + EncodeTime(13, 45, 20, 0);
                        Ini.WriteDateTime("Dates", "DT", D);
                        result = Ini.ReadDateTime("Dates", "DT", 0) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemSectionExists()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Present", "Key", "Value");
                        result = Ini.SectionExists("Present");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemSectionMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Present", "Key", "Value");
                        result = !Ini.SectionExists("Absent");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemValueExists()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Present", "Key", "Value");
                        result = Ini.ValueExists("Present", "Key");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemValueMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Present", "Key", "Value");
                        result = !Ini.ValueExists("Present", "Missing");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReadSections()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Alpha", ("A").ToString(), "one");
                        Ini.WriteString("Beta", ("B").ToString(), "two");
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSections(L);
                            result = (L.Count == 2) && (L.IndexOf("Alpha") >= 0) && (L.IndexOf("Beta") >= 0);
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReadSectionsEmpty()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSections(L);
                            result = L.Count == 0;
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReadSection()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Alpha", "One", ("a").ToString());
                        Ini.WriteString("Alpha", "Two", ("b").ToString());
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSection("Alpha", L);
                            result = (L.Count == 2) && (L.IndexOf("One") >= 0) && (L.IndexOf("Two") >= 0);
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReadSectionMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSection("Missing", L);
                            result = L.Count == 0;
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReadSectionValues()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Alpha", "One", ("a").ToString());
                        Ini.WriteString("Alpha", "Two", ("b").ToString());
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSectionValues("Alpha", L);
                            result = (L.Count == 2) && (L.ReadPropertyValues("One") == "a") && (L.ReadPropertyValues("Two") == "b");
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReadSectionValuesMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSectionValues("Missing", L);
                            result = L.Count == 0;
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemDeleteKey()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Group", "Keep", ("A").ToString());
                        Ini.WriteString("Group", "Remove", ("B").ToString());
                        Ini.DeleteKey("Group", "Remove");
                        result = !Ini.ValueExists("Group", "Remove");
                        result = result && (Ini.ReadString("Group", "Keep", "") == "A");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemEraseSection()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Keep", ("X").ToString(), ("1").ToString());
                        Ini.WriteString("Remove", ("X").ToString(), ("2").ToString());
                        Ini.EraseSection("Remove");
                        result = !Ini.SectionExists("Remove");
                        result = result && (Ini.ReadString("Keep", ("X").ToString(), "") == "1");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemOverwriteType()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Group", "Key", 100);
                        Ini.WriteString("Group", "Key", "Text");
                        result = Ini.ReadString("Group", "Key", "") == "Text";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemUpdateFile()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Persist", "Key", "Saved");
                        Ini.UpdateFile();
                        result = FileExists(W.FileName);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileFileName()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        result = Ini.FileName == W.FileName;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileMissingString()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        result = Ini.ReadString("Unknown", ("X").ToString(), "fallback") == "fallback";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileMissingInteger()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        result = Ini.ReadInteger("Unknown", ("X").ToString(), 12345) == 12345;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileMissingBool()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        result = Ini.ReadBool("Unknown", ("X").ToString(), true);
                        result = result && (!Ini.ReadBool("Unknown", ("X").ToString(), false));
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileMissingFloat()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        result = SIF_Close(Ini.ReadFloat("Unknown", ("X").ToString(), 7.125D), 7.125D);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileMissingDate()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        D = EncodeDate(2021, 2, 3);
                        result = Ini.ReadDate("Unknown", ("X").ToString(), D) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileMissingTime()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        D = EncodeTime(11, 12, 13, 0);
                        result = Ini.ReadTime("Unknown", ("X").ToString(), D) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileMissingDateTime()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        D = EncodeDate(2021, 2, 3) + EncodeTime(11, 12, 13, 0);
                        result = Ini.ReadDateTime("Unknown", ("X").ToString(), D) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileReadString()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("General", "Name", "Example");
                        result = Ini.ReadString("General", "Name", "") == "Example";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteEmptyString()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("General", "Blank", "");
                        result = Ini.ReadString("General", "Blank", "fallback") == "";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileOverwriteString()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("General", "Name", "First");
                        Ini.WriteString("General", "Name", "Second");
                        result = Ini.ReadString("General", "Name", "") == "Second";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileDifferentKeys()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("General", ("A").ToString(), "one");
                        Ini.WriteString("General", ("B").ToString(), "two");
                        result = Ini.ReadString("General", ("A").ToString(), "") == "one";
                        result = result && (Ini.ReadString("General", ("B").ToString(), "") == "two");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileDifferentSections()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("First", "Key", ("A").ToString());
                        Ini.WriteString("Second", "Key", ("B").ToString());
                        result = Ini.ReadString("First", "Key", "") == "A";
                        result = result && (Ini.ReadString("Second", "Key", "") == "B");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteIntegerPositive()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Numbers", "Count", 123456);
                        result = Ini.ReadInteger("Numbers", "Count", -1) == 123456;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteIntegerNegative()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Numbers", "Count", -32768);
                        result = Ini.ReadInteger("Numbers", "Count", 0) == -32768;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteIntegerZero()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Numbers", "Count", 0);
                        result = Ini.ReadInteger("Numbers", "Count", 100) == 0;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteIntegerMax()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Numbers", "Count", MaxInt);
                        result = Ini.ReadInteger("Numbers", "Count", 0) == MaxInt;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileReadIntegerInvalid()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Numbers", "Count", "not_a_number");
                        result = Ini.ReadInteger("Numbers", "Count", 77) == 77;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteBoolTrue()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteBool("Flags", "Enabled", true);
                        result = Ini.ReadBool("Flags", "Enabled", false);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteBoolFalse()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteBool("Flags", "Enabled", false);
                        result = !Ini.ReadBool("Flags", "Enabled", true);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteFloatPositive()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteFloat("Numbers", "Rate", 12.375D);
                        result = SIF_Close(Ini.ReadFloat("Numbers", "Rate", 0.0F), 12.375D);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteFloatNegative()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteFloat("Numbers", "Rate", -0.125D);
                        result = SIF_Close(Ini.ReadFloat("Numbers", "Rate", 0.0F), -0.125D);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteDate()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        D = EncodeDate(2020, 5, 17);
                        Ini.WriteDate("Dates", ("D").ToString(), D);
                        result = Ini.ReadDate("Dates", ("D").ToString(), 0) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteTime()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        D = EncodeTime(13, 45, 20, 0);
                        Ini.WriteTime("Dates", ("T").ToString(), D);
                        result = Ini.ReadTime("Dates", ("T").ToString(), 0) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileWriteDateTime()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TDateTime D = new TDateTime();
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        D = EncodeDate(2020, 5, 17) + EncodeTime(13, 45, 20, 0);
                        Ini.WriteDateTime("Dates", "DT", D);
                        result = Ini.ReadDateTime("Dates", "DT", 0) == D;
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileSectionExists()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Present", "Key", "Value");
                        result = Ini.SectionExists("Present");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileSectionMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Present", "Key", "Value");
                        result = !Ini.SectionExists("Absent");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileValueExists()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Present", "Key", "Value");
                        result = Ini.ValueExists("Present", "Key");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileValueMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Present", "Key", "Value");
                        result = !Ini.ValueExists("Present", "Missing");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileReadSections()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Alpha", ("A").ToString(), "one");
                        Ini.WriteString("Beta", ("B").ToString(), "two");
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSections(L);
                            result = (L.Count == 2) && (L.IndexOf("Alpha") >= 0) && (L.IndexOf("Beta") >= 0);
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileReadSectionsEmpty()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSections(L);
                            result = L.Count == 0;
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileReadSection()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Alpha", "One", ("a").ToString());
                        Ini.WriteString("Alpha", "Two", ("b").ToString());
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSection("Alpha", L);
                            result = (L.Count == 2) && (L.IndexOf("One") >= 0) && (L.IndexOf("Two") >= 0);
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileReadSectionMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSection("Missing", L);
                            result = L.Count == 0;
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileReadSectionValues()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Alpha", "One", ("a").ToString());
                        Ini.WriteString("Alpha", "Two", ("b").ToString());
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSectionValues("Alpha", L);
                            result = (L.Count == 2) && (L.ReadPropertyValues("One") == "a") && (L.ReadPropertyValues("Two") == "b");
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileReadSectionValuesMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        L = new TStringList();
                        try
                        {
                            Ini.ReadSectionValues("Missing", L);
                            result = L.Count == 0;
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileDeleteKey()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Group", "Keep", ("A").ToString());
                        Ini.WriteString("Group", "Remove", ("B").ToString());
                        Ini.DeleteKey("Group", "Remove");
                        result = !Ini.ValueExists("Group", "Remove");
                        result = result && (Ini.ReadString("Group", "Keep", "") == "A");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileEraseSection()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Keep", ("X").ToString(), ("1").ToString());
                        Ini.WriteString("Remove", ("X").ToString(), ("2").ToString());
                        Ini.EraseSection("Remove");
                        result = !Ini.SectionExists("Remove");
                        result = result && (Ini.ReadString("Keep", ("X").ToString(), "") == "1");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileOverwriteType()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteInteger("Group", "Key", 100);
                        Ini.WriteString("Group", "Key", "Text");
                        result = Ini.ReadString("Group", "Key", "") == "Text";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileUpdateFile()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Persist", "Key", "Saved");
                        Ini.UpdateFile();
                        result = FileExists(W.FileName);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemDefaultCaseInsensitive()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Section", "Name", "Value");
                        result = Ini.ReadString("section", "name", "") == "Value";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemCaseSensitiveKeys()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.CaseSensitive = true;
                        Ini.WriteString("Group", "Name", "Upper");
                        Ini.WriteString("Group", "name", "Lower");
                        result = Ini.ReadString("Group", "Name", "") == "Upper";
                        result = result && (Ini.ReadString("Group", "name", "") == "Lower");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemCaseSensitiveSections()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.CaseSensitive = true;
                        Ini.WriteString("Group", "Name", "Upper");
                        Ini.WriteString("group", "Name", "Lower");
                        result = Ini.ReadString("Group", "Name", "") == "Upper";
                        result = result && (Ini.ReadString("group", "Name", "") == "Lower");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemCaseSensitiveProperty()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.CaseSensitive = true;
                        result = Ini.CaseSensitive;
                        Ini.CaseSensitive = false;
                        result = result && (!Ini.CaseSensitive);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemClear()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Alpha", ("A").ToString(), ("1").ToString());
                        Ini.WriteString("Beta", ("B").ToString(), ("2").ToString());
                        Ini.Clear();
                        result = !Ini.SectionExists("Alpha");
                        result = result && (!Ini.SectionExists("Beta"));
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemGetStrings()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Alpha", ("A").ToString(), "one");
                        L = new TStringList();
                        try
                        {
                            Ini.GetStrings(L);
                            result = (L.IndexOf("[Alpha]") >= 0) && (L.IndexOf("A=one") >= 0);
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemSetStrings()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Old", "Key", "OldValue");
                        L = new TStringList();
                        try
                        {
                            L.Add("[New]");
                            L.Add("Key=NewValue");
                            Ini.SetStrings(L);
                            result = Ini.ReadString("New", "Key", "") == "NewValue";
                            result = result && (!Ini.SectionExists("Old"));
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemValuesInMemoryBeforeSave()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "Buffered");
                        result = Ini.ReadString("Main", "Key", "") == "Buffered";
                        result = result && (!FileExists(W.FileName));
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemPersistence()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "Persisted");
                        Ini.UpdateFile();
                        Other = new TMemIniFile(W.FileName);
                        try
                        {
                            result = Other.ReadString("Main", "Key", "") == "Persisted";
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemSnapshotBeforeUpdate()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "Original");
                        Ini.UpdateFile();
                        Ini.WriteString("Main", "Key", "Buffered");
                        Other = new TMemIniFile(W.FileName);
                        try
                        {
                            result = Other.ReadString("Main", "Key", "") == "Original";
                            result = result && (Ini.ReadString("Main", "Key", "") == "Buffered");
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemNoImplicitSave()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "OnlyMemory");
                        TObject.Free(Ini);
                        Ini = default;
                        result = !FileExists(W.FileName);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemReloadFromDisk()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "First");
                        Ini.UpdateFile();
                        TObject.Free(Ini);
                        Ini = default;
                        Ini = new TMemIniFile(W.FileName);
                        result = Ini.ReadString("Main", "Key", "") == "First";
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemUpdateOverwrite()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "First");
                        Ini.UpdateFile();
                        Ini.WriteString("Main", "Key", "Second");
                        Ini.UpdateFile();
                        Other = new TMemIniFile(W.FileName);
                        try
                        {
                            result = Other.ReadString("Main", "Key", "") == "Second";
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemDeletePersisted()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "First");
                        Ini.UpdateFile();
                        Ini.DeleteKey("Main", "Key");
                        Ini.UpdateFile();
                        Other = new TMemIniFile(W.FileName);
                        try
                        {
                            result = !Other.ValueExists("Main", "Key");
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemErasePersisted()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "First");
                        Ini.UpdateFile();
                        Ini.EraseSection("Main");
                        Ini.UpdateFile();
                        Other = new TMemIniFile(W.FileName);
                        try
                        {
                            result = !Other.SectionExists("Main");
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemRenameNoReload()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "Buffered");
                        Ini.Rename(W.OtherFileName, false);
                        result = Ini.FileName == W.OtherFileName;
                        result = result && (Ini.ReadString("Main", "Key", "") == "Buffered");
                        Ini.UpdateFile();
                        Other = new TMemIniFile(W.OtherFileName);
                        try
                        {
                            result = result && (Other.ReadString("Main", "Key", "") == "Buffered");
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemRenameReload()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "First");
                        Ini.UpdateFile();
                        Other = new TMemIniFile(W.OtherFileName);
                        try
                        {
                            Other.WriteString("Main", "Key", "Second");
                            Other.UpdateFile();
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                        Ini.Rename(W.OtherFileName, true);
                        result = Ini.FileName == W.OtherFileName;
                        result = result && (Ini.ReadString("Main", "Key", "") == "Second");
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemSetStringsComments()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TStringList L = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        L = new TStringList();
                        try
                        {
                            L.Add("; comment");
                            L.Add("[Section]");
                            L.Add("Key=Value");
                            Ini.SetStrings(L);
                            result = Ini.ReadString("Section", "Key", "") == "Value";
                        }
                        finally
                        {
                            TObject.Free(L);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemEncodingCreate()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        TObject.Free(Ini);
                        Ini = default;
                        Ini = new TMemIniFile(W.FileName, TEncoding.UTF8);
                        Ini.WriteString("Text", "Key", "Ascii");
                        Ini.UpdateFile();
                        Other = new TMemIniFile(W.FileName, TEncoding.UTF8);
                        try
                        {
                            result = Other.ReadString("Text", "Key", "") == "Ascii";
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemBinaryStream()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            byte[] Data = new byte[5/*# range 0..4*/];
            Ref<byte[]> __d2cArrayLocation_Data = new Ref<byte[]>(() => Data, __d2cArrayValue => Data = __d2cArrayValue);
            byte[] Got = new byte[5/*# range 0..4*/];
            Ref<byte[]> __d2cArrayLocation_Got = new Ref<byte[]>(() => Got, __d2cArrayValue => Got = __d2cArrayValue);
            TMemoryStream Src = default;
            TMemoryStream Dst = default;
            int I = 0;
            int N = 0;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Data[0] = 0;
                        Data[1] = 1;
                        Data[2] = 127;
                        Data[3] = 255;
                        Data[4] = 42;
                        Src = new TMemoryStream();
                        try
                        {
                            Src.WriteBuffer(Data, (5 * (int)DelphiTypeSize.Byte));
                            Src.Position = 0;
                            Ini.WriteBinaryStream("Data", "Bytes", Src);
                            Dst = new TMemoryStream();
                            try
                            {
                                N = Ini.ReadBinaryStream("Data", "Bytes", Dst);
                                result = (N == (5 * (int)DelphiTypeSize.Byte)) && (Dst.Size == (5 * (int)DelphiTypeSize.Byte));
                                if (result)
                                {
                                    Dst.Position = 0;
                                    Dst.ReadBuffer(ref Got, (5 * (int)DelphiTypeSize.Byte));
                                    for (I = 0; I <= 4 /*# High(Data) */; I++)
                                    {
                                        result = result && (Got[I] == Data[I]);
                                    }
                                }
                            }
                            finally
                            {
                                TObject.Free(Dst);
                            }
                        }
                        finally
                        {
                            TObject.Free(Src);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestMemBinaryStreamMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TMemIniFile Ini = default;
            TMemoryStream Dst = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Dst = new TMemoryStream();
                        try
                        {
                            result = Ini.ReadBinaryStream("Missing", "Bytes", Dst) == 0;
                            result = result && (Dst.Size == 0);
                        }
                        finally
                        {
                            TObject.Free(Dst);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileBinaryStream()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            byte[] Data = new byte[5/*# range 0..4*/];
            Ref<byte[]> __d2cArrayLocation_Data = new Ref<byte[]>(() => Data, __d2cArrayValue => Data = __d2cArrayValue);
            byte[] Got = new byte[5/*# range 0..4*/];
            Ref<byte[]> __d2cArrayLocation_Got = new Ref<byte[]>(() => Got, __d2cArrayValue => Got = __d2cArrayValue);
            TMemoryStream Src = default;
            TMemoryStream Dst = default;
            int I = 0;
            int N = 0;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Data[0] = 0;
                        Data[1] = 1;
                        Data[2] = 127;
                        Data[3] = 255;
                        Data[4] = 42;
                        Src = new TMemoryStream();
                        try
                        {
                            Src.WriteBuffer(Data, (5 * (int)DelphiTypeSize.Byte));
                            Src.Position = 0;
                            Ini.WriteBinaryStream("Data", "Bytes", Src);
                            Dst = new TMemoryStream();
                            try
                            {
                                N = Ini.ReadBinaryStream("Data", "Bytes", Dst);
                                result = (N == (5 * (int)DelphiTypeSize.Byte)) && (Dst.Size == (5 * (int)DelphiTypeSize.Byte));
                                if (result)
                                {
                                    Dst.Position = 0;
                                    Dst.ReadBuffer(ref Got, (5 * (int)DelphiTypeSize.Byte));
                                    for (I = 0; I <= 4 /*# High(Data) */; I++)
                                    {
                                        result = result && (Got[I] == Data[I]);
                                    }
                                }
                            }
                            finally
                            {
                                TObject.Free(Dst);
                            }
                        }
                        finally
                        {
                            TObject.Free(Src);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileBinaryStreamMissing()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TMemoryStream Dst = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Dst = new TMemoryStream();
                        try
                        {
                            result = Ini.ReadBinaryStream("Missing", "Bytes", Dst) == 0;
                            result = result && (Dst.Size == 0);
                        }
                        finally
                        {
                            TObject.Free(Dst);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileImmediatePersistence()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "Direct");
                        Other = new TIniFile(W.FileName);
                        try
                        {
                            result = Other.ReadString("Main", "Key", "") == "Direct";
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFilePersistAfterDestroy()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "Direct");
                        TObject.Free(Ini);
                        Ini = default;
                        Other = new TIniFile(W.FileName);
                        try
                        {
                            result = Other.ReadString("Main", "Key", "") == "Direct";
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestFileDeletePersisted()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TIniFile Ini = default;
            TIniFile Other = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Main", "Key", "Direct");
                        Ini.DeleteKey("Main", "Key");
                        Other = new TIniFile(W.FileName);
                        try
                        {
                            result = !Other.ValueExists("Main", "Key");
                        }
                        finally
                        {
                            TObject.Free(Other);
                        }
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestCustomMemDispatch()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TCustomIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TMemIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Virtual", "Name", "Works");
                        Ini.WriteInteger("Virtual", "Count", 10);
                        result = Ini.ReadString("Virtual", "Name", "") == "Works";
                        result = result && (Ini.ReadInteger("Virtual", "Count", 0) == 10);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SIF_TestCustomFileDispatch()
        {
            bool result = false;
            TSIF_Workspace W = default;
            TCustomIniFile Ini = default;
            result = false;
            try
            {
                W = new TSIF_Workspace();
                try
                {
                    Ini = new TIniFile(W.FileName);
                    try
                    {
                        Ini.WriteString("Virtual", "Name", "Works");
                        Ini.WriteInteger("Virtual", "Count", 10);
                        result = Ini.ReadString("Virtual", "Name", "") == "Works";
                        result = result && (Ini.ReadInteger("Virtual", "Count", 0) == 10);
                    }
                    finally
                    {
                        TObject.Free(Ini);
                    }
                }
                finally
                {
                    TObject.Free(W);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // Eager boolean evaluation is required so every test runs in order.
        // A C# translation must also preserve this behavior (boolean & rather than &&).
        /*$B+*/

        /*$B-*/
    } // class System_inifilesImplementation

}  // namespace System_inifiles

