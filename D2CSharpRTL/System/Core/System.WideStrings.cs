using System.Classes;
using System.Sysutils;
using System;
using static System.Classes.ClassesInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;
using static System.Widestrings.WidestringsImplementation;
using static System.Widestrings.WidestringsInterface;

namespace System
{

namespace Widestrings
{

/*
  D2CSharp Runtime Library (RTL)

  Declaration-oriented mock of System.WideStrings.
  Independently authored interface skeleton for Delphi source translation.
  Methods intentionally do not implement string-list behavior.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0
*/


public class WidestringsInterface
{

	abstract public class TWideStrings : TPersistent
	{
		private char FDelimiter;
		private char FQuoteChar;
		private char FNameValueSeparator;
		private string FLineBreak = string.Empty;
		private bool FStrictDelimiter;
		private int FUpdateCount;

/* TWideStrings.GetCommaText */
		private string GetCommaText()
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TWideStrings.GetDelimitedText */
		private string GetDelimitedText()
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TWideStrings.GetName */
		private string GetName(int Index)
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TWideStrings.GetValue */
		private string GetValue(string Name)
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TWideStrings.GetValueFromIndex */
		private string GetValueFromIndex(int Index)
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TWideStrings.GetTextStr */
		private string GetTextStr()
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TWideStrings.SetCommaText */
		private void SetCommaText(string Value)
		{
		}

/* TWideStrings.SetDelimitedText */
		private void SetDelimitedText(string Value)
		{
		}

/* TWideStrings.SetValue */
		private void SetValue(string Name, string Value)
		{
		}

/* TWideStrings.SetValueFromIndex */
		private void SetValueFromIndex(int Index, string Value)
		{
		}

/* TWideStrings.SetTextStr */
		private void SetTextStr(string Value)
		{
		}

/* TWideStrings.DefineProperties */
		protected virtual void DefineProperties(TFiler Filer)
		{
		}

/* TWideStrings.Error */

/* TWideStrings.Error */
		protected void Error(string Msg, int Data)
		{
		}
		protected void Error(Pointer<TResStringRec> Msg, int Data)
		{
		}
		abstract protected string Get(int Index);

/* TWideStrings.GetCapacity */
		protected virtual int GetCapacity()
		{
			int result = 0;
			result = 0;
			return result;
		}
		abstract protected int GetCount();

/* TWideStrings.GetObject */
		protected virtual TObject GetObject(int Index)
		{
			TObject result = default;
			result = default;
			return result;
		}

/* TWideStrings.Put */
		protected virtual void Put(int Index, string S)
		{
		}

/* TWideStrings.PutObject */
		protected virtual void PutObject(int Index, TObject AObject)
		{
		}

/* TWideStrings.SetCapacity */
		protected virtual void SetCapacity(int NewCapacity)
		{
		}

/* TWideStrings.SetUpdateState */
		protected virtual void SetUpdateState(bool Updating)
		{
		}

/* TWideStrings.Destroy */
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}

/* TWideStrings.Add */
		public virtual int Add(string S)
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStrings.AddObject */
		public virtual int AddObject(string S, TObject AObject)
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStrings.AddStrings */

/* TWideStrings.AddStrings */
		public virtual void AddStrings(TWideStrings Strings)
		{
		}
		public virtual void AddStrings(string[] Strings)
		{
		}

/* TWideStrings.Append */
		public void Append(string S)
		{
		}

/* TWideStrings.Assign */
		public override void Assign(TPersistent Source)
		{
		}

/* TWideStrings.BeginUpdate */
		public void BeginUpdate()
		{
		}
		abstract public void Clear();
		abstract public void Delete(int Index);

/* TWideStrings.EndUpdate */
		public void EndUpdate()
		{
		}

/* TWideStrings.Equals */
		public bool Equals(TWideStrings Strings)/*# reintroduce */
		{
			bool result = false;
			result = false;
			return result;
		}

/* TWideStrings.Exchange */
		public virtual void Exchange(int Index1, int Index2)
		{
		}

/* TWideStrings.GetEnumerator */
		public TWideStringsEnumerator GetEnumerator()
		{
			TWideStringsEnumerator result = default;
			result = default;
			return result;
		}

/* TWideStrings.IndexOf */
		public virtual int IndexOf(string S)
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStrings.IndexOfName */
		public int IndexOfName(string Name)
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStrings.IndexOfObject */
		public int IndexOfObject(TObject AObject)
		{
			int result = 0;
			result = 0;
			return result;
		}
		abstract public void Insert(int Index, string S);

/* TWideStrings.InsertObject */
		public virtual void InsertObject(int Index, string S, TObject AObject)
		{
		}

/* TWideStrings.LoadFromFile */

/* TWideStrings.LoadFromFile */
		public virtual void LoadFromFile(string FileName)
		{
		}
		public virtual void LoadFromFile(string FileName, TEncoding Encoding)
		{
		}

/* TWideStrings.LoadFromStream */

/* TWideStrings.LoadFromStream */
		public virtual void LoadFromStream(TStream Stream)
		{
		}
		public virtual void LoadFromStream(TStream Stream, TEncoding Encoding)
		{
		}

/* TWideStrings.Move */
		public virtual void Move(int CurIndex, int NewIndex)
		{
		}

/* TWideStrings.SaveToFile */

/* TWideStrings.SaveToFile */
		public virtual void SaveToFile(string FileName)
		{
		}
		public virtual void SaveToFile(string FileName, TEncoding Encoding)
		{
		}

/* TWideStrings.SaveToStream */

/* TWideStrings.SaveToStream */
		public virtual void SaveToStream(TStream Stream)
		{
		}
		public virtual void SaveToStream(TStream Stream, TEncoding Encoding)
		{
		}

/* TWideStrings.SetText */
		public virtual void SetText(PChar Text)
		{
		}

/* TWideStrings.GetText */
		public virtual PChar GetText()
		{
			PChar result = default;
			result = default;
			return result;
		}
		/*property Capacity : int read GetCapacity write SetCapacity;*/
		public int Capacity
		{
			get
			{
				return GetCapacity();
			}
			set
			{
				SetCapacity(value);
			}
		}
		/*property CommaText : string read GetCommaText write SetCommaText;*/
		public string CommaText
		{
			get
			{
				return GetCommaText();
			}
			set
			{
				SetCommaText(value);
			}
		}
		/*property Count : int read GetCount;*/
		public int Count
		{
			get
			{
				return GetCount();
			}
		}
		/*property Delimiter : char read FDelimiter write FDelimiter;*/
		public char Delimiter
		{
			get
			{
				return FDelimiter;
			}
			set
			{
				FDelimiter = value;
			}
		}
		/*property DelimitedText : string read GetDelimitedText write SetDelimitedText;*/
		public string DelimitedText
		{
			get
			{
				return GetDelimitedText();
			}
			set
			{
				SetDelimitedText(value);
			}
		}
		/*property LineBreak : string read FLineBreak write FLineBreak;*/
		public string LineBreak
		{
			get
			{
				return FLineBreak;
			}
			set
			{
				FLineBreak = value;
			}
		}
		/*property Names [Index: integer]: string read GetName;*/
		public string ReadPropertyNames(int Index) { return GetName(Index);}
		/*property NameValueSeparator : char read FNameValueSeparator write FNameValueSeparator;*/
		public char NameValueSeparator
		{
			get
			{
				return FNameValueSeparator;
			}
			set
			{
				FNameValueSeparator = value;
			}
		}
		/*property Objects [Index: integer]: TObject read GetObject write PutObject;*/
		public TObject ReadPropertyObjects(int Index) { return GetObject(Index);}
		public void WritePropertyObjects(int Index, TObject AObject){PutObject(Index, AObject);}
		/*property QuoteChar : char read FQuoteChar write FQuoteChar;*/
		public char QuoteChar
		{
			get
			{
				return FQuoteChar;
			}
			set
			{
				FQuoteChar = value;
			}
		}
		/*property StrictDelimiter : bool read FStrictDelimiter write FStrictDelimiter;*/
		public bool StrictDelimiter
		{
			get
			{
				return FStrictDelimiter;
			}
			set
			{
				FStrictDelimiter = value;
			}
		}
		/*property Strings [Index: integer]: string read Get write Put default ;*/
		public string ReadPropertyStrings(int Index) { return Get(Index);}
		public void WritePropertyStrings(int Index, string S){Put(Index, S);}
		public string this[int Index]
		{
			get
			{
				return Get(Index);
			}
			set
			{
				Put(Index, value);
			}
		}
		/*property Text : string read GetTextStr write SetTextStr;*/
		public string Text
		{
			get
			{
				return GetTextStr();
			}
			set
			{
				SetTextStr(value);
			}
		}
		/*property ValueFromIndex [Index: integer]: string read GetValueFromIndex write SetValueFromIndex;*/
		public string ReadPropertyValueFromIndex(int Index) { return GetValueFromIndex(Index);}
		public void WritePropertyValueFromIndex(int Index, string Value){SetValueFromIndex(Index, Value);}
		/*property Values [Name: string]: string read GetValue write SetValue;*/
		public string ReadPropertyValues(string Name) { return GetValue(Name);}
		public void WritePropertyValues(string Name, string Value){SetValue(Name, Value);}

		public TWideStrings() {}
	}	

	public class TWideStringList : TWideStrings
	{
		private bool FCaseSensitive;
		private TDuplicates FDuplicates;
		private bool FSorted;
		private TNotifyEvent FOnChange;
		private TNotifyEvent FOnChanging;

/* TWideStringList.Changed */
		protected virtual void Changed()
		{
		}

/* TWideStringList.Changing */
		protected virtual void Changing()
		{
		}

/* TWideStringList.CompareStrings */
		protected virtual int CompareStrings(string S1, string S2)
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStringList.Get */
		protected override string Get(int Index)
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TWideStringList.GetCapacity */
		protected override int GetCapacity()
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStringList.GetCount */
		protected override int GetCount()
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStringList.GetObject */
		protected override TObject GetObject(int Index)
		{
			TObject result = default;
			result = default;
			return result;
		}

/* TWideStringList.Put */
		protected override void Put(int Index, string S)
		{
		}

/* TWideStringList.PutObject */
		protected override void PutObject(int Index, TObject AObject)
		{
		}

/* TWideStringList.SetCapacity */
		protected override void SetCapacity(int NewCapacity)
		{
		}

/* TWideStringList.SetUpdateState */
		protected override void SetUpdateState(bool Updating)
		{
		}

/* TWideStringList.Create */
		public TWideStringList()
		{
			;
		}

/* TWideStringList.Destroy */
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}

/* TWideStringList.Add */
		public override int Add(string S)
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStringList.Clear */
		public override void Clear()
		{
		}

/* TWideStringList.Delete */
		public override void Delete(int Index)
		{
		}

/* TWideStringList.Exchange */
		public override void Exchange(int Index1, int Index2)
		{
		}

/* TWideStringList.Find */
		public virtual bool Find(string S, ref int Index)
		{
			bool result = false;
			result = false;
			return result;
		}

/* TWideStringList.IndexOf */
		public override int IndexOf(string S)
		{
			int result = 0;
			result = 0;
			return result;
		}

/* TWideStringList.Insert */
		public override void Insert(int Index, string S)
		{
		}

/* TWideStringList.Sort */
		public virtual void Sort()
		{
		}

/* TWideStringList.CustomSort */
		public virtual void CustomSort(TWideStringListSortCompare Compare)
		{
		}
		/*property CaseSensitive : bool read FCaseSensitive write FCaseSensitive;*/
		public bool CaseSensitive
		{
			get
			{
				return FCaseSensitive;
			}
			set
			{
				FCaseSensitive = value;
			}
		}
		/*property Duplicates : TDuplicates read FDuplicates write FDuplicates;*/
		public TDuplicates Duplicates
		{
			get
			{
				return FDuplicates;
			}
			set
			{
				FDuplicates = value;
			}
		}
		/*property Sorted : bool read FSorted write FSorted;*/
		public bool Sorted
		{
			get
			{
				return FSorted;
			}
			set
			{
				FSorted = value;
			}
		}
		/*property OnChange : TNotifyEvent read FOnChange write FOnChange;*/
		public TNotifyEvent OnChange
		{
			get
			{
				return FOnChange;
			}
			set
			{
				FOnChange = value;
			}
		}
		/*property OnChanging : TNotifyEvent read FOnChanging write FOnChanging;*/
		public TNotifyEvent OnChanging
		{
			get
			{
				return FOnChanging;
			}
			set
			{
				FOnChanging = value;
			}
		}
	}	

	public class TWideStringsEnumerator : TObject
	{
		private TWideStrings FStrings;
		private int FIndex;

/* TWideStringsEnumerator.GetCurrent */
		private string GetCurrent()
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TWideStringsEnumerator.Create */
		public TWideStringsEnumerator(TWideStrings AStrings)
		{
			;
		}

/* TWideStringsEnumerator.MoveNext */
		public bool MoveNext()
		{
			bool result = false;
			result = false;
			return result;
		}
		/*property Current : string read GetCurrent;*/
		public string Current
		{
			get
			{
				return GetCurrent();
			}
		}

		public TWideStringsEnumerator() {}
	}	
public delegate int TWideStringListSortCompare(TWideStringList List, int Index1, int Index2);
	
} // class WidestringsInterface


file class WidestringsImplementation
{

} // class WidestringsImplementation

}  // namespace Widestrings

}  // namespace System

