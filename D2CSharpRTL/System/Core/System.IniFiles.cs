using System;
using System.Classes;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Sysutils;
using static System.Sysutils.SysutilsInterface;
using static System.Classes.ClassesInterface;

namespace System.Inifiles;

/*
  D2CSharp Runtime Library (RTL)
  Managed implementation of Delphi INI files.
  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/
public class InifilesInterface
{
    public class TCustomIniFile : TObject
    {
        protected string FFileName;
        public TCustomIniFile(string FileName) { FFileName = FileName ?? string.Empty; }
        public TCustomIniFile() : this(string.Empty) { }
        public string FileName => FFileName;
        internal ref string __D2CUnit_TCustomIniFile_FFileName => ref FFileName;
        public virtual string ReadString(string Section, string Ident, string Default) => Default;
        public virtual void WriteString(string Section, string Ident, string Value) { }
        public virtual void ReadSection(string Section, TStrings Strings) => Strings.Clear();
        public virtual void ReadSections(TStrings Strings) => Strings.Clear();
        public virtual void ReadSections(string Section, TStrings Strings)
        {
            var all = new TStringList();
            try
            {
                ReadSections(all);
                string prefix = Section;
                for (int i = 0; i < all.Count; ++i)
                    if (all[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) Strings.Add(all[i]);
            }
            finally { TObject.Free(all); }
        }
        public virtual void ReadSectionValues(string Section, TStrings Strings) => Strings.Clear();
        public virtual void EraseSection(string Section) { }
        public virtual void DeleteKey(string Section, string Ident) { }
        public virtual void UpdateFile() { }
        private static string IntegerText(string value) => value.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? "$" + value.Substring(2) : value;
        public virtual int ReadInteger(string Section, string Ident, int Default) => StrToIntDef(IntegerText(ReadString(Section, Ident, "")), Default);
        public virtual long ReadInt64(string Section, string Ident, long Default) => StrToInt64Def(IntegerText(ReadString(Section, Ident, "")), Default);
        public virtual bool ReadBool(string Section, string Ident, bool Default) => ReadInteger(Section, Ident, Default ? 1 : 0) != 0;
        public virtual double ReadFloat(string Section, string Ident, double Default) => StrToFloatDef(ReadString(Section, Ident, ""), Default);
        public virtual TDateTime ReadDate(string Section, string Ident, TDateTime Default) => StrToDateDef(ReadString(Section, Ident, ""), Default);
        public virtual TDateTime ReadTime(string Section, string Ident, TDateTime Default) => StrToTimeDef(ReadString(Section, Ident, ""), Default);
        public virtual TDateTime ReadDateTime(string Section, string Ident, TDateTime Default) => StrToDateTimeDef(ReadString(Section, Ident, ""), Default);
        public virtual void WriteInteger(string Section, string Ident, int Value) => WriteString(Section, Ident, Value.ToString(CultureInfo.InvariantCulture));
        public virtual void WriteInt64(string Section, string Ident, long Value) => WriteString(Section, Ident, Value.ToString(CultureInfo.InvariantCulture));
        public virtual void WriteBool(string Section, string Ident, bool Value) => WriteString(Section, Ident, Value ? "1" : "0");
        public virtual void WriteFloat(string Section, string Ident, double Value) => WriteString(Section, Ident, FloatToStr(Value));
        public virtual void WriteDate(string Section, string Ident, TDateTime Value) => WriteString(Section, Ident, DateToStr(Value));
        public virtual void WriteTime(string Section, string Ident, TDateTime Value) => WriteString(Section, Ident, TimeToStr(Value));
        public virtual void WriteDateTime(string Section, string Ident, TDateTime Value) => WriteString(Section, Ident, DateTimeToStr(Value));
        public virtual bool SectionExists(string Section)
        {
            var names = new TStringList();
            try { ReadSection(Section, names); return names.Count != 0; }
            finally { TObject.Free(names); }
        }
        public virtual bool ValueExists(string Section, string Ident)
        {
            var names = new TStringList();
            try { ReadSection(Section, names); return names.IndexOf(Ident) >= 0; }
            finally { TObject.Free(names); }
        }
        public virtual int ReadBinaryStream(string Section, string Name, TStream Value)
        {
            string text = ReadString(Section, Name, "");
            if (text.Length == 0) return 0;
            byte[] bytes = Convert.FromHexString(text);
            long position = Value.Position;
            Value.WriteBuffer(bytes, bytes.Length);
            Value.Position = position;
            return bytes.Length;
        }
        public virtual void WriteBinaryStream(string Section, string Name, TStream Value)
        {
            long position = Value.Position;
            byte[] bytes = new byte[checked((int)(Value.Size - position))];
            Value.ReadBuffer(bytes, bytes.Length);
            if (Value is TBytesStream || Value is TMemoryStream) Value.Position = position;
            WriteString(Section, Name, Convert.ToHexString(bytes));
        }
    }

    public class TMemIniFile : TCustomIniFile
    {
        private sealed class Entry
        {
            internal string Name, Value;
            internal Entry(string name, string value) { Name = name; Value = value; }
        }
        private sealed class SectionData
        {
            internal string Name;
            internal readonly List<Entry> Values = new();
            internal SectionData(string name) { Name = name; }
        }
        private readonly List<SectionData> sections = new();
        private TEncoding? encoding;
        public bool AutoSave { get; set; }
        public bool Modified { get; set; }
        public bool CaseSensitive { get; set; }
        public TEncoding Encoding => encoding!;
        public TMemIniFile(string FileName) : this(FileName, null, false) { }
        public TMemIniFile(string FileName, TEncoding? Encoding) : this(FileName, Encoding, false) { }
        public TMemIniFile(string FileName, TEncoding? Encoding, bool CaseSensitive) : base(FileName)
        {
            encoding = Encoding; this.CaseSensitive = CaseSensitive; Load();
        }
        public TMemIniFile() : this(string.Empty) { }
        private bool Equal(string left, string right) => string.Equals(left, right, CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
        private SectionData? FindSection(string name) => sections.Find(section => Equal(section.Name, name));
        private Entry? FindEntry(SectionData? section, string name) => section?.Values.Find(entry => Equal(entry.Name, name));
        public override string ReadString(string Section, string Ident, string Default) => FindEntry(FindSection(Section), Ident)?.Value ?? Default;
        public override void WriteString(string Section, string Ident, string Value)
        {
            var section = FindSection(Section);
            if (section == null) { section = new SectionData(Section); sections.Add(section); }
            var entry = FindEntry(section, Ident);
            if (entry == null) section.Values.Add(new Entry(Ident, Value)); else entry.Value = Value;
            Modified = true;
        }
        public override void ReadSections(TStrings Strings)
        {
            Strings.BeginUpdate();
            try { Strings.Clear(); foreach (var section in sections) Strings.Add(section.Name); }
            finally { Strings.EndUpdate(); }
        }
        public override void ReadSection(string Section, TStrings Strings)
        {
            Strings.BeginUpdate();
            try { Strings.Clear(); var section = FindSection(Section); if (section != null) foreach (var entry in section.Values) Strings.Add(entry.Name); }
            finally { Strings.EndUpdate(); }
        }
        public override void ReadSectionValues(string Section, TStrings Strings)
        {
            Strings.BeginUpdate();
            try { Strings.Clear(); var section = FindSection(Section); if (section != null) foreach (var entry in section.Values) Strings.Add(entry.Name + "=" + entry.Value); }
            finally { Strings.EndUpdate(); }
        }
        public override bool SectionExists(string Section) => FindSection(Section) != null;
        public override bool ValueExists(string Section, string Ident) => FindEntry(FindSection(Section), Ident) != null;
        public override void DeleteKey(string Section, string Ident)
        {
            var section = FindSection(Section); var entry = FindEntry(section, Ident);
            if (entry != null) { section!.Values.Remove(entry); Modified = true; }
        }
        public override void EraseSection(string Section)
        {
            var section = FindSection(Section);
            if (section != null) { sections.Remove(section); Modified = true; }
        }
        public virtual void Clear() { if (sections.Count != 0) { sections.Clear(); Modified = true; } }
        private void Parse(IEnumerable<string> lines)
        {
            sections.Clear(); SectionData? section = null;
            foreach (string raw in lines)
            {
                string line = raw.Trim();
                if (line.Length == 0 || line[0] == ';') continue;
                if (line[0] == '[' && line[line.Length - 1] == ']')
                {
                    string name = line.Substring(1, line.Length - 2).Trim();
                    section = FindSection(name);
                    if (section == null) { section = new SectionData(name); sections.Add(section); }
                }
                else if (section != null)
                {
                    int equals = line.IndexOf('=');
                    if (equals < 0) continue;
                    string name = line.Substring(0, equals).Trim(), value = line.Substring(equals + 1).Trim();
                    var entry = FindEntry(section, name);
                    if (entry == null) section.Values.Add(new Entry(name, value)); else entry.Value = value;
                }
            }
        }
        public virtual void SetStrings(TStrings List)
        {
            var lines = new List<string>();
            for (int i = 0; i < List.Count; ++i) lines.Add(List[i]);
            Parse(lines); Modified = true;
        }
        public virtual void GetStrings(TStrings List)
        {
            List.BeginUpdate();
            try
            {
                List.Clear();
                foreach (var section in sections)
                {
                    List.Add("[" + section.Name + "]");
                    foreach (var entry in section.Values) List.Add(entry.Name + "=" + entry.Value);
                    List.Add("");
                }
            }
            finally { List.EndUpdate(); }
        }
        private void Load()
        {
            sections.Clear();
            if (FFileName.Length != 0 && File.Exists(FFileName))
            {
                byte[] bytes = File.ReadAllBytes(FFileName); int skip = 0;
                if (bytes.Length >= 3 && bytes[0] == 239 && bytes[1] == 187 && bytes[2] == 191) { encoding = TEncoding.UTF8; skip = 3; }
                else if (bytes.Length >= 2 && bytes[0] == 255 && bytes[1] == 254) { encoding = TEncoding.Unicode; skip = 2; }
                else if (bytes.Length >= 2 && bytes[0] == 254 && bytes[1] == 255) { encoding = TEncoding.BigEndianUnicode; skip = 2; }
                encoding ??= TEncoding.Default;
                using var reader = new StringReader(encoding.GetString(bytes, skip, bytes.Length - skip));
                var lines = new List<string>(); string? line;
                while ((line = reader.ReadLine()) != null) lines.Add(line);
                Parse(lines);
            }
            Modified = false;
        }
        public virtual void Rename(string FileName, bool Reload)
        {
            string name = FileName ?? string.Empty;
            Modified |= !string.Equals(FFileName, name, StringComparison.Ordinal);
            FFileName = name;
            if (Reload) Load();
        }
        public override void UpdateFile()
        {
            var lines = new TStringList();
            try
            {
                GetStrings(lines); encoding ??= TEncoding.Default;
                byte[] bytes = encoding.GetBytes(lines.Text), preamble = encoding.GetPreamble();
                using (var output = File.Create(FFileName)) { output.Write(preamble); output.Write(bytes); }
                Modified = false;
            }
            finally { TObject.Free(lines); }
        }
        public override void Destroy()
        {
            if (FDisposed) return;
            try { if (AutoSave && Modified) UpdateFile(); }
            finally { base.Destroy(); }
        }
    }

    public class TIniFile : TCustomIniFile
    {
        private readonly TMemIniFile memory;
        public TIniFile(string FileName) : base(FileName) { memory = new TMemIniFile(FileName); }
        public TIniFile() : this(string.Empty) { }
        private void Refresh() => memory.Rename(FFileName, true);
        public override string ReadString(string Section, string Ident, string Default) { Refresh(); return memory.ReadString(Section, Ident, Default); }
        public override void WriteString(string Section, string Ident, string Value) { Refresh(); memory.WriteString(Section, Ident, Value); memory.UpdateFile(); }
        public override void ReadSection(string Section, TStrings Strings) { Refresh(); memory.ReadSection(Section, Strings); }
        public override void ReadSections(TStrings Strings) { Refresh(); memory.ReadSections(Strings); }
        public override void ReadSectionValues(string Section, TStrings Strings) { Refresh(); memory.ReadSectionValues(Section, Strings); }
        public override bool SectionExists(string Section) { Refresh(); return memory.SectionExists(Section); }
        public override bool ValueExists(string Section, string Ident) { Refresh(); return memory.ValueExists(Section, Ident); }
        public override void DeleteKey(string Section, string Ident) { Refresh(); memory.DeleteKey(Section, Ident); if (memory.Modified) memory.UpdateFile(); }
        public override void EraseSection(string Section) { Refresh(); memory.EraseSection(Section); if (memory.Modified) memory.UpdateFile(); }
        public override void UpdateFile() { if (memory.Modified) memory.UpdateFile(); }
        public override void Destroy()
        {
            if (FDisposed) return;
            try { TObject.Free(memory); }
            finally { base.Destroy(); }
        }
    }
}
file class InifilesImplementation { }