using System.Sysutils;
using System;
using static System.Classes.ClassesImplementation;
using static System.Classes.ClassesInterface;
using static System.SystemInterface;
using static System.Sysutils.SysutilsInterface;

namespace System
{

namespace Classes
{

/*
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.Classes functionality required by D2CSharp.

  The file serves two purposes:
  - it provides symbols and routine signatures used while translating Delphi
    source code;
  - it provides the basis for generating the corresponding C# mock file.

  The routines below intentionally contain no RTL implementation. Functions
  return simple default values and procedures have empty bodies.

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


public class ClassesInterface
{

	public class TInterfacedPersistent : TPersistent, IInterface
	{


/* TInterfacedPersistent */
		protected virtual int QueryInterface(Guid IID, out object Obj)
		{
			int result = 0;
			result = E_NOINTERFACE;
			return result;
		}
		protected virtual int _AddRef()
		{
			int result = 0;
			result = -1;
			return result;
		}
		protected virtual int _Release()
		{
			int result = 0;
			result = -1;
			return result;
		}

		public TInterfacedPersistent() {}
	}	
	public interface IObserver : IInterface
	{
		bool GetActive();
		TObserverToggleEvent GetOnObserverToggle();
		void SetActive(bool Value);
		void SetOnObserverToggle(TObserverToggleEvent Value);
		/*property Active : bool read GetActive write SetActive;*/
		bool Active
		{
			get;
			set;
		}
		/*property OnObserverToggle : TObserverToggleEvent read GetOnObserverToggle write SetOnObserverToggle;*/
		TObserverToggleEvent OnObserverToggle
		{
			get;
			set;
		}
	}	
	public interface IObserverTrack : IInterface
	{
		bool GetTrack();
		/*property Track : bool read GetTrack;*/
		bool Track
		{
			get;
		}
	}	
	public interface IInterfaceList
	{
		int GetCapacity();
		int GetCount();
		IInterface GetItem(int Index);
		void SetCapacity(int NewCapacity);
		void SetItem(int Index, IInterface Item);
		int Add(IInterface Item);
		void Clear();
		void Delete(int Index);
		void Exchange(int Index1, int Index2);
		IInterface First();
		int IndexOf(IInterface Item);
		void Insert(int Index, IInterface Item);
		IInterface Last();
		int Remove(IInterface Item);
		/*property Capacity : int read GetCapacity write SetCapacity;*/
		int Capacity
		{
			get;
			set;
		}
		/*property Count : int read GetCount;*/
		int Count
		{
			get;
		}
		/*property Items [Index: integer]: IInterface read GetItem write SetItem default ;*/
		IInterface ReadPropertyItems(int Index);
		void WritePropertyItems(int Index, IInterface Item);
		IInterface this[int Index]
		{
			get;
			set;
		}
	}	
	public interface IInterfaceListEx : IInterfaceList
	{
		TInterfaceListEnumerator GetEnumerator();
	}	

	// ClassRef<TPersistent> TPersistentClass;

	// ClassRef<TComponent> TComponentClass;

	// ClassRef<TCollectionItem> TCollectionItemClass;

	public class TList : TObject
	{
		private Pointer[] FList = new Pointer[]{};
		private int FCount;
		private int FCapacity;
		private Pointer Get(int Index)
		{
			Pointer result = default;
			result = default;
			return result;
		}
		private void Put(int Index, Pointer Item)
		{
		}
		private void SetCapacity(int NewCapacity)
		{
		}
		private void SetCount(int NewCount)
		{
		}
		protected virtual void Notify(Pointer Ptr, TListNotification Action)
		{
		}

/* TList */
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public int Add(Pointer Item)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual void Clear()
		{
		}
		public void Delete(int Index)
		{
		}
		public static void Error(string Msg, int Data)
		{
		}
		public static void Error(Pointer<TResStringRec> Msg, int Data)
		{
		}
		public void Exchange(int Index1, int Index2)
		{
		}
		public Pointer Extract(Pointer Item)
		{
			Pointer result = default;
			result = default;
			return result;
		}
		public Pointer First()
		{
			Pointer result = default;
			result = default;
			return result;
		}
		public int IndexOf(Pointer Item)
		{
			int result = 0;
			result = -1;
			return result;
		}
		public void Insert(int Index, Pointer Item)
		{
		}
		public Pointer Last()
		{
			Pointer result = default;
			result = default;
			return result;
		}
		public TListEnumerator GetEnumerator()
		{
			TListEnumerator result = default;
			result = default;
			return result;
		}
		public void Move(int CurIndex, int NewIndex)
		{
		}
		public void Pack()
		{
		}
		public int Remove(Pointer Item)
		{
			int result = 0;
			result = -1;
			return result;
		}
		public void Sort(TListSortCompare Compare)
		{
		}
		/*property Capacity : int read FCapacity write SetCapacity;*/
		public int Capacity
		{
			get
			{
				return FCapacity;
			}
			set
			{
				SetCapacity(value);
			}
		}
		/*property Count : int read FCount write SetCount;*/
		public int Count
		{
			get
			{
				return FCount;
			}
			set
			{
				SetCount(value);
			}
		}
		/*property Items [Index: integer]: Pointer read Get write Put default ;*/
		public Pointer ReadPropertyItems(int Index) { return Get(Index);}
		public void WritePropertyItems(int Index, Pointer Item){Put(Index, Item);}
		public Pointer this[int Index]
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

		public TList() {}
	}	

	public class TListEnumerator : TObject
	{
		private TList FList;
		private int FIndex;
		private Pointer GetCurrent()
		{
			Pointer result = default;
			result = default;
			return result;
		}

/* TListEnumerator */
		public TListEnumerator(TList AList)
		{
			;
		}
		public bool MoveNext()
		{
			bool result = false;
			result = false;
			return result;
		}
		/*property Current : Pointer read GetCurrent;*/
		public Pointer Current
		{
			get
			{
				return GetCurrent();
			}
		}
	}	

	public class TBits : TObject
	{
		private int FSize;

/* TBits */
		private bool GetBit(int Index)
		{
			bool result = false;
			result = false;
			return result;
		}
		private void SetBit(int Index, bool Value)
		{
		}
		private void SetSize(int Value)
		{
		}
		public int OpenBit()
		{
			int result = 0;
			result = -1;
			return result;
		}
		/*property Bits [Index: integer]: bool read GetBit write SetBit default ;*/
		public bool ReadPropertyBits(int Index) { return GetBit(Index);}
		public void WritePropertyBits(int Index, bool Value){SetBit(Index, Value);}
		public bool this[int Index]
		{
			get
			{
				return GetBit(Index);
			}
			set
			{
				SetBit(Index, value);
			}
		}
		/*property Size : int read FSize write SetSize;*/
		public int Size
		{
			get
			{
				return FSize;
			}
			set
			{
				SetSize(value);
			}
		}

		public TBits() {}
	}	

	public class TInterfaceList : TInterfacedObject, IInterfaceList, IInterfaceListEx
	{
		private IInterface[] FItems = new IInterface[]{};
		private int FCount;
		private int FCapacity;

/* TInterfaceList */
		public int GetCapacity()
		{
			int result = 0;
			result = FCapacity;
			return result;
		}
		public int GetCount()
		{
			int result = 0;
			result = FCount;
			return result;
		}
		public IInterface GetItem(int Index)
		{
			IInterface result = default;
			result = default;
			return result;
		}
		public void SetCapacity(int NewCapacity)
		{
		}
		public void SetItem(int Index, IInterface Item)
		{
		}
		public int Add(IInterface Item)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public void Clear()
		{
		}
		public void Delete(int Index)
		{
		}
		public void Exchange(int Index1, int Index2)
		{
		}
		public TInterfaceList Expand()
		{
			TInterfaceList result = default;
			result = this;
			return result;
		}
		public IInterface First()
		{
			IInterface result = default;
			result = default;
			return result;
		}
		public TInterfaceListEnumerator GetEnumerator()
		{
			TInterfaceListEnumerator result = default;
			result = default;
			return result;
		}
		public int IndexOf(IInterface Item)
		{
			int result = 0;
			result = -1;
			return result;
		}
		public void Insert(int Index, IInterface Item)
		{
		}
		public IInterface Last()
		{
			IInterface result = default;
			result = default;
			return result;
		}
		public int Remove(IInterface Item)
		{
			int result = 0;
			result = -1;
			return result;
		}
		public void Lock()
		{
		}
		public void Unlock()
		{
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
		/*property Count : int read GetCount;*/
		public int Count
		{
			get
			{
				return GetCount();
			}
		}
		/*property Items [Index: integer]: IInterface read GetItem write SetItem default ;*/
		public IInterface ReadPropertyItems(int Index) { return GetItem(Index);}
		public void WritePropertyItems(int Index, IInterface Item){SetItem(Index, Item);}
		public IInterface this[int Index]
		{
			get
			{
				return GetItem(Index);
			}
			set
			{
				SetItem(Index, value);
			}
		}

		public TInterfaceList() {}
	}	

	public class TInterfaceListEnumerator : TObject
	{
		private TInterfaceList FList;
		private int FIndex;
		private IInterface GetCurrent()
		{
			IInterface result = default;
			result = default;
			return result;
		}

/* TInterfaceListEnumerator */
		public TInterfaceListEnumerator(TInterfaceList AList)
		{
			;
		}
		public bool MoveNext()
		{
			bool result = false;
			result = false;
			return result;
		}
		/*property Current : IInterface read GetCurrent;*/
		public IInterface Current
		{
			get
			{
				return GetCurrent();
			}
		}
	}	

	public class TObservers : TObject
	{
		private TCanObserveEvent FOnCanObserve;
		private TObserverAddedEvent FOnObserverAdded;

/* TObservers */
		public TObservers()
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public virtual void AddObserver(int ID, IInterface AIntf)
		{
		}
		public virtual void AddObserver(int[] IDs, IInterface AIntf)
		{
		}
		public virtual bool CanObserve(int ID)
		{
			bool result = false;
			result = true;
			return result;
		}
		public virtual bool IsObserving(int ID)
		{
			bool result = false;
			result = false;
			return result;
		}
		public virtual void RemoveObserver(int ID, IInterface AIntf)
		{
		}
		public virtual bool TryIsObserving(int ID, out IInterface AIntf)
		{
			AIntf = default; //# clear out parameter
			bool result = false;

			AIntf = default;
			result = false;
			return result;
		}
		/*property OnCanObserve : TCanObserveEvent read FOnCanObserve write FOnCanObserve;*/
		public TCanObserveEvent OnCanObserve
		{
			get
			{
				return FOnCanObserve;
			}
			set
			{
				FOnCanObserve = value;
			}
		}
		/*property OnObserverAdded : TObserverAddedEvent read FOnObserverAdded write FOnObserverAdded;*/
		public TObserverAddedEvent OnObserverAdded
		{
			get
			{
				return FOnObserverAdded;
			}
			set
			{
				FOnObserverAdded = value;
			}
		}
	}	

	public class TObserverMapping : TObject
	{
		protected static TObserverMapping Instance()
		{
			TObserverMapping result = default;
			result = default;
			return result;
		}

/* TObserverMapping */
		public TObserverMapping()
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public static void Clear()
		{
		}
		public static void EnableObservers(TClass AClass)
		{
		}
		public static void DisableObservers(TClass AClass)
		{
		}
	}	

	public class TLinkObservers : TObject
	{


/* TLinkObservers */
		public static bool IsObserving(TObservers AObservers, int ID)
		{
			bool result = false;
			result = false;
			return result;
		}

		public TLinkObservers() {}
	}	

	public class TPersistent : TObject
	{


/* TPersistent */
		protected void AssignError(TPersistent Source)
		{
		}
		protected virtual void AssignTo(TPersistent Dest)
		{
		}
		public virtual void Assign(TPersistent Source)
		{
		}
		public virtual string GetNamePath()
		{
			string result = string.Empty;
			result = "";
			return result;
		}

		public TPersistent() {}
	}	

	public class TCollectionItem : TPersistent
	{
		private TCollection FCollection;
		private int FID;
		private int GetIndex()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private void SetCollection(TCollection Value)
		{
		}
		private void SetIndex(int Value)
		{
		}
		protected virtual string GetDisplayName()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		protected virtual void SetDisplayName(string Value)
		{
		}
		protected virtual void SetItemName()
		{
		}

/* TCollectionItem */
		public TCollectionItem(TCollection Collection)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		/*property Collection : TCollection read FCollection write SetCollection;*/
		public TCollection Collection
		{
			get
			{
				return FCollection;
			}
			set
			{
				SetCollection(value);
			}
		}
		/*property ID : int read FID;*/
		public int ID
		{
			get
			{
				return FID;
			}
		}
		/*property Index : int read GetIndex write SetIndex;*/
		public int Index
		{
			get
			{
				return GetIndex();
			}
			set
			{
				SetIndex(value);
			}
		}
		/*property DisplayName : string read GetDisplayName write SetDisplayName;*/
		public string DisplayName
		{
			get
			{
				return GetDisplayName();
			}
			set
			{
				SetDisplayName(value);
			}
		}
	}	

	public class TCollection : TPersistent
	{
		private TClass FItemClass;
		private int GetCount()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private TCollectionItem GetItem(int Index)
		{
			TCollectionItem result = default;
			result = default;
			return result;
		}
		private void SetItem(int Index, TCollectionItem Value)
		{
		}
		protected TCollectionItem Add()
		{
			TCollectionItem result = default;
			result = default;
			return result;
		}
		protected virtual void Added(ref TCollectionItem Item)
		{
		}
		protected virtual void Deleting(TCollectionItem Item)
		{
		}
		protected virtual TClass GetItemClass()
		{
			TClass result = default;
			result = FItemClass;
			return result;
		}
		protected virtual string GetItemName()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		protected virtual TPersistent GetOwner()
		{
			TPersistent result = default;
			result = default;
			return result;
		}
		protected virtual void Notify(TCollectionItem Item, TCollectionNotification Action)
		{
		}
		protected virtual void PropertyNameChanged()
		{
		}
		protected virtual void SetItemName(TCollectionItem Item)
		{
		}
		protected virtual void Update(TCollectionItem Item)
		{
		}

/* TCollection */
		public TCollection(TClass ItemClass)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public override void Assign(TPersistent Source)
		{
		}
		public void BeginUpdate()
		{
		}
		public void Clear()
		{
		}
		public void Delete(int Index)
		{
		}
		public void EndUpdate()
		{
		}
		public TCollectionItem FindItemID(int ID)
		{
			TCollectionItem result = default;
			result = default;
			return result;
		}
		public TCollectionEnumerator GetEnumerator()
		{
			TCollectionEnumerator result = default;
			result = default;
			return result;
		}
		public int GetItemID()
		{
			int result = 0;
			result = 0;
			return result;
		}
		public TCollectionItem Insert(int Index)
		{
			TCollectionItem result = default;
			result = default;
			return result;
		}
		public TPersistent Owner()
		{
			TPersistent result = default;
			result = default;
			return result;
		}
		/*property Count : int read GetCount;*/
		public int Count
		{
			get
			{
				return GetCount();
			}
		}
		/*property ItemClass : TCollectionItemClass read FItemClass;*/
		public TClass ItemClass
		{
			get
			{
				return FItemClass;
			}
		}
		/*property Items [Index: integer]: TCollectionItem read GetItem write SetItem;*/
		public TCollectionItem ReadPropertyItems(int Index) { return GetItem(Index);}
		public void WritePropertyItems(int Index, TCollectionItem Value){SetItem(Index, Value);}
	}	

	public class TCollectionEnumerator : TObject
	{
		private TCollection FCollection;
		private int FIndex;
		private TCollectionItem GetCurrent()
		{
			TCollectionItem result = default;
			result = default;
			return result;
		}

/* TCollectionEnumerator */
		public TCollectionEnumerator(TCollection ACollection)
		{
			;
		}
		public bool MoveNext()
		{
			bool result = false;
			result = false;
			return result;
		}
		/*property Current : TCollectionItem read GetCurrent;*/
		public TCollectionItem Current
		{
			get
			{
				return GetCurrent();
			}
		}
	}	

	public class TOwnedCollection : TCollection
	{
		private TPersistent FOwner;
		protected override TPersistent GetOwner()
		{
			TPersistent result = default;
			result = FOwner;
			return result;
		}

/* TOwnedCollection */
		public TOwnedCollection(TPersistent AOwner, TClass ItemClass)
		:		base(ItemClass)
		{
			//# base.Create(ItemClass);
		}
	}	

	abstract public class TStrings : TPersistent
	{
		private char FDelimiter;
		private char FQuoteChar;
		private char FNameValueSeparator;
		private string FLineBreak = string.Empty;
		private bool FStrictDelimiter;
		private int FUpdateCount;
		private string GetCommaText()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		private string GetDelimitedText()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		private string GetName(int Index)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		private string GetValue(string Name)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		private string GetValueFromIndex(int Index)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		private string GetTextStr()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		private void SetCommaText(string Value)
		{
		}
		private void SetDelimitedText(string Value)
		{
		}
		private void SetValue(string Name, string Value)
		{
		}
		private void SetValueFromIndex(int Index, string Value)
		{
		}
		private void SetTextStr(string Value)
		{
		}
		protected virtual void DefineProperties(TFiler Filer)
		{
		}
		protected void Error(string Msg, int Data)
		{
		}
		abstract protected string Get(int Index);
		protected virtual int GetCapacity()
		{
			int result = 0;
			result = 0;
			return result;
		}
		abstract protected int GetCount();
		protected virtual TObject GetObject(int Index)
		{
			TObject result = default;
			result = default;
			return result;
		}
		protected virtual PChar GetText()
		{
			PChar result = default;
			result = default;
			return result;
		}
		protected virtual void Put(int Index, string S)
		{
		}
		protected virtual void PutObject(int Index, TObject AObject)
		{
		}
		protected virtual void SetCapacity(int NewCapacity)
		{
		}
		protected virtual void SetUpdateState(bool Updating)
		{
		}

/* TStrings */
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public virtual int Add(string S)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual int AddObject(string S, TObject AObject)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual void AddStrings(TStrings Strings)
		{
		}
		public virtual void AddStrings(string[] Strings)
		{
		}
		public void Append(string S)
		{
		}
		public override void Assign(TPersistent Source)
		{
		}
		public void BeginUpdate()
		{
		}
		abstract public void Clear();
		abstract public void Delete(int Index);
		public void EndUpdate()
		{
		}
		public bool Equals(TStrings Strings)/*# reintroduce */
		{
			bool result = false;
			result = false;
			return result;
		}
		public virtual void Exchange(int Index1, int Index2)
		{
		}
		public virtual int IndexOf(string S)
		{
			int result = 0;
			result = -1;
			return result;
		}
		public int IndexOfName(string Name)
		{
			int result = 0;
			result = -1;
			return result;
		}
		public int IndexOfObject(TObject AObject)
		{
			int result = 0;
			result = -1;
			return result;
		}
		abstract public void Insert(int Index, string S);
		public virtual void InsertObject(int Index, string S, TObject AObject)
		{
		}
		public virtual void LoadFromFile(string FileName)
		{
		}
		public virtual void LoadFromFile(string FileName, TEncoding Encoding)
		{
		}
		public virtual void LoadFromStream(TStream Stream)
		{
		}
		public virtual void LoadFromStream(TStream Stream, TEncoding Encoding)
		{
		}
		public virtual void Move(int CurIndex, int NewIndex)
		{
		}
		public virtual void SaveToFile(string FileName)
		{
		}
		public virtual void SaveToFile(string FileName, TEncoding Encoding)
		{
		}
		public virtual void SaveToStream(TStream Stream)
		{
		}
		public virtual void SaveToStream(TStream Stream, TEncoding Encoding)
		{
		}
		public virtual void SetText(PChar Text)
		{
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

		public TStrings() {}
	}	

	public class TStringList : TStrings
	{
		private bool FCaseSensitive;
		private TDuplicates FDuplicates;
		private bool FOwnsObjects;
		private bool FSorted;
		private TNotifyEvent FOnChange;
		private TNotifyEvent FOnChanging;
		protected virtual void Changed()
		{
		}
		protected virtual void Changing()
		{
		}
		protected virtual int CompareStrings(string S1, string S2)
		{
			int result = 0;
			result = 0;
			return result;
		}
		protected override string Get(int Index)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		protected override int GetCapacity()
		{
			int result = 0;
			result = 0;
			return result;
		}
		protected override int GetCount()
		{
			int result = 0;
			result = 0;
			return result;
		}
		protected override TObject GetObject(int Index)
		{
			TObject result = default;
			result = default;
			return result;
		}
		protected override void Put(int Index, string S)
		{
		}
		protected override void PutObject(int Index, TObject AObject)
		{
		}
		protected override void SetCapacity(int NewCapacity)
		{
		}
		protected override void SetUpdateState(bool Updating)
		{
		}

/* TStringList */
		public TStringList()
		{
			;
		}
		public TStringList(bool OwnsObjects)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public override int Add(string S)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public override void Clear()
		{
		}
		public override void Delete(int Index)
		{
		}
		public override void Exchange(int Index1, int Index2)
		{
		}
		public virtual bool Find(string S, ref int Index)
		{
			bool result = false;
			result = false;
			return result;
		}
		public override int IndexOf(string S)
		{
			int result = 0;
			result = -1;
			return result;
		}
		public override void Insert(int Index, string S)
		{
		}
		public virtual void Sort()
		{
		}
		public virtual void CustomSort(TStringListSortCompare Compare)
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
		/*property OwnsObjects : bool read FOwnsObjects write FOwnsObjects;*/
		public bool OwnsObjects
		{
			get
			{
				return FOwnsObjects;
			}
			set
			{
				FOwnsObjects = value;
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

	abstract public class TStream : TObject
	{


/* TStream */
		private long GetPosition()
		{
			long result = 0;
			result = 0;
			return result;
		}
		private void SetPosition(long Pos)
		{
		}
		private long GetSize()
		{
			long result = 0;
			result = 0;
			return result;
		}
		private void SetSize64(long NewSize)
		{
		}
		protected virtual void SetSize(int NewSize)
		{
		}
		protected virtual void SetSize(long NewSize)
		{
		}
		abstract public int Read(UntypedPointer Buffer, int Count);
		abstract public int Write(UntypedPointer Buffer, int Count);
		public virtual int Seek(int Offset, ushort Origin)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual long Seek(long Offset, TSeekOrigin Origin)
		{
			long result = 0;
			result = 0;
			return result;
		}
		public void ReadBuffer(UntypedPointer Buffer, int Count)
		{
		}
		public void WriteBuffer(UntypedPointer Buffer, int Count)
		{
		}
		public long CopyFrom(TStream Source, long Count)
		{
			long result = 0;
			result = 0;
			return result;
		}
		public byte ReadByte()
		{
			byte result = 0;
			result = 0;
			return result;
		}
		public void WriteByte(byte Value)
		{
		}
		/*property Position : long read GetPosition write SetPosition;*/
		public long Position
		{
			get
			{
				return GetPosition();
			}
			set
			{
				SetPosition(value);
			}
		}
		/*property Size : long read GetSize write SetSize64;*/
		public long Size
		{
			get
			{
				return GetSize();
			}
			set
			{
				SetSize64(value);
			}
		}

		public TStream() {}
	}	

	public class THandleStream : TStream
	{
		private uint FHandle;

/* THandleStream */
		public THandleStream(uint AHandle)
		{
			;
		}
		public override int Read(UntypedPointer Buffer, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public override int Write(UntypedPointer Buffer, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public override long Seek(long Offset, TSeekOrigin Origin)
		{
			long result = 0;
			result = 0;
			return result;
		}
		/*property Handle : THandle read FHandle;*/
		public uint Handle
		{
			get
			{
				return FHandle;
			}
		}
	}	

	public class TFileStream : THandleStream
	{
		private string FFileName = string.Empty;

/* TFileStream */
		public TFileStream(string FileName, ushort Mode)
		:		base(0)
		{
			//# base.Create(0);
		}
		public TFileStream(string FileName, ushort Mode, uint Rights)
		:		base(0)
		{
			//# base.Create(0);
		}
		/*property FileName : string read FFileName;*/
		public string FileName
		{
			get
			{
				return FFileName;
			}
		}

		public TFileStream(uint AHandle) : base(AHandle) {}
	}	

	public class TCustomMemoryStream : TStream
	{
		private Pointer FMemory;
		private long FSize;
		private long FPosition;

/* TCustomMemoryStream */
		protected void SetPointer(Pointer Ptr, int Size)
		{
		}
		public override int Read(UntypedPointer Buffer, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public override long Seek(long Offset, TSeekOrigin Origin)
		{
			long result = 0;
			result = 0;
			return result;
		}
		public void SaveToStream(TStream Stream)
		{
		}
		public void SaveToFile(string FileName)
		{
		}
		/*property Memory : Pointer read FMemory;*/
		public Pointer Memory
		{
			get
			{
				return FMemory;
			}
		}

		public TCustomMemoryStream() {}
		public override int Write(UntypedPointer Buffer, int Count)
		{
			throw new NotImplementedException();
			return 0;
		}
	}	

	public class TMemoryStream : TCustomMemoryStream
	{
		private int FCapacity;
		private void SetCapacity(int NewCapacity)
		{
		}
		protected virtual Pointer Realloc(ref int NewCapacity)
		{
			Pointer result = default;
			result = default;
			return result;
		}
		protected override void SetSize(long NewSize)
		{
		}

/* TMemoryStream */
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public void Clear()
		{
		}
		public void LoadFromStream(TStream Stream)
		{
		}
		public void LoadFromFile(string FileName)
		{
		}
		public override int Write(UntypedPointer Buffer, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		/*property Capacity : int read FCapacity write SetCapacity;*/
		public int Capacity
		{
			get
			{
				return FCapacity;
			}
			set
			{
				SetCapacity(value);
			}
		}

		public TMemoryStream() {}
	}	

	public class TStringStream : TStream
	{
		private string FDataString = string.Empty;
		private long FPosition;
		private TEncoding FEncoding;
		protected override void SetSize(long NewSize)
		{
		}

/* TStringStream */
		public TStringStream(string AString)
		{
			;
		}
		public TStringStream(string AString, TEncoding AEncoding)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public override int Read(UntypedPointer Buffer, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public override int Write(UntypedPointer Buffer, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public override long Seek(long Offset, TSeekOrigin Origin)
		{
			long result = 0;
			result = 0;
			return result;
		}
		public string ReadString(int Count)
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public void WriteString(string AString)
		{
		}
		/*property DataString : string read FDataString;*/
		public string DataString
		{
			get
			{
				return FDataString;
			}
		}
		/*property Encoding : TEncoding read FEncoding;*/
		public TEncoding Encoding
		{
			get
			{
				return FEncoding;
			}
		}

		public TStringStream() {}
	}	

	public class TBytesStream : TMemoryStream
	{
		private byte[] FBytes = new byte[]{};
		protected override Pointer Realloc(ref int NewCapacity)
		{
			Pointer result = default;
			result = default;
			return result;
		}

/* TBytesStream */
		public TBytesStream(byte[] ABytes)
		{
			;
		}
		/*property Bytes : TBytes read FBytes;*/
		public byte[] Bytes
		{
			get
			{
				return FBytes;
			}
		}
	}	

	public class TResourceStream : TCustomMemoryStream
	{


/* TResourceStream */
		public TResourceStream(uint Instance, string ResName, PChar ResType)
		{
			;
		}
		public TResourceStream(uint Instance, int ResID, PChar ResType)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public override int Write(UntypedPointer Buffer, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}

		public TResourceStream() {}
	}	

	abstract public class TThread : TObject
	{
		private bool FFreeOnTerminate;
		private bool FFinished;
		private bool FTerminated;
		abstract protected void Execute();

/* TThread */
		public TThread(bool CreateSuspended)
		{
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public void Start()
		{
		}
		public void Resume()
		{
		}
		public void Suspend()
		{
		}
		public void Terminate()
		{
		}
		public uint WaitFor()
		{
			uint result = 0;
			result = 0;
			return result;
		}
		/*property Finished : bool read FFinished;*/
		public bool Finished
		{
			get
			{
				return FFinished;
			}
		}
		/*property FreeOnTerminate : bool read FFreeOnTerminate write FFreeOnTerminate;*/
		public bool FreeOnTerminate
		{
			get
			{
				return FFreeOnTerminate;
			}
			set
			{
				FFreeOnTerminate = value;
			}
		}
		/*property Terminated : bool read FTerminated;*/
		public bool Terminated
		{
			get
			{
				return FTerminated;
			}
		}
	}	

	public class TThreadList : TObject
	{
		private TList FList;
		private TDuplicates FDuplicates;

/* TThreadList */
		public TThreadList()
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public void Add(Pointer Item)
		{
		}
		public void Clear()
		{
		}
		public TList LockList()
		{
			TList result = default;
			result = FList;
			return result;
		}
		public void Remove(Pointer Item)
		{
		}
		public void UnlockList()
		{
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
	}	

	public class TStringsEnumerator : TObject
	{
		private TStrings FStrings;
		private int FIndex;
		private string GetCurrent()
		{
			string result = string.Empty;
			result = "";
			return result;
		}

/* TStringsEnumerator */
		public TStringsEnumerator(TStrings AStrings)
		{
			;
		}
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
	}	

	public class TStringReader : TObject
	{
		private string FData = string.Empty;
		private int FPosition;

/* TStringReader */
		public TStringReader(string AString)
		{
			;
		}
		public int Peek()
		{
			int result = 0;
			result = -1;
			return result;
		}
		public int Read()
		{
			int result = 0;
			result = -1;
			return result;
		}
		public int Read(ref char[] Buffer, int Index, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public string ReadLine()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public string ReadToEnd()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
	}	

	public class TStringWriter : TObject
	{
		private TStringBuilder FBuilder;

/* TStringWriter */
		public TStringWriter()
		{
			;
		}
		public TStringWriter(TStringBuilder ABuilder)
		{
			;
		}
		public void Write(string Value)
		{
		}
		public void Write(char Value)
		{
		}
		public void WriteLine()
		{
		}
		public void WriteLine(string Value)
		{
		}
		public override string ToString()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		/*property Builder :  read FBuilder;*/
		public TStringBuilder Builder
		{
			get
			{
				return FBuilder;
			}
		}
	}	

	public class TStreamReader : TObject
	{
		private TStream FStream;
		private TEncoding FEncoding;
		private bool FOwnsStream;
		private bool GetEndOfStream()
		{
			bool result = false;
			result = false;
			return result;
		}

/* TStreamReader */
		public TStreamReader(TStream Stream)
		{
			;
		}
		public TStreamReader(TStream Stream, TEncoding Encoding, bool DetectBOM = true, int BufferSize = 1024)
		{
			;
		}
		public TStreamReader(string Filename)
		{
			;
		}
		public TStreamReader(string Filename, TEncoding Encoding, bool DetectBOM = true, int BufferSize = 1024)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public void Close()
		{
		}
		public int Peek()
		{
			int result = 0;
			result = -1;
			return result;
		}
		public int Read()
		{
			int result = 0;
			result = -1;
			return result;
		}
		public int Read(ref char[] Buffer, int Index, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public int ReadBlock(ref char[] Buffer, int Index, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public string ReadLine()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public string ReadToEnd()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		/*property BaseStream : TStream read FStream;*/
		public TStream BaseStream
		{
			get
			{
				return FStream;
			}
		}
		/*property CurrentEncoding : TEncoding read FEncoding;*/
		public TEncoding CurrentEncoding
		{
			get
			{
				return FEncoding;
			}
		}
		/*property EndOfStream : bool read GetEndOfStream;*/
		public bool EndOfStream
		{
			get
			{
				return GetEndOfStream();
			}
		}

		public TStreamReader() {}
	}	

	public class TStreamWriter : TObject
	{
		private TStream FStream;
		private TEncoding FEncoding;
		private bool FOwnsStream;
		private bool FAutoFlush;
		private string FNewLine = string.Empty;

/* TStreamWriter */
		public TStreamWriter(TStream Stream)
		{
			;
		}
		public TStreamWriter(TStream Stream, TEncoding Encoding, int BufferSize = 1024)
		{
			;
		}
		public TStreamWriter(string Filename, bool Append = false)
		{
			;
		}
		public TStreamWriter(string Filename, bool Append, TEncoding Encoding, int BufferSize = 1024)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public void Close()
		{
		}
		public void Flush()
		{
		}
		public void Write(string Value)
		{
		}
		public void Write(char Value)
		{
		}
		public void WriteLine()
		{
		}
		public void WriteLine(string Value)
		{
		}
		/*property AutoFlush : bool read FAutoFlush write FAutoFlush;*/
		public bool AutoFlush
		{
			get
			{
				return FAutoFlush;
			}
			set
			{
				FAutoFlush = value;
			}
		}
		/*property BaseStream : TStream read FStream;*/
		public TStream BaseStream
		{
			get
			{
				return FStream;
			}
		}
		/*property Encoding : TEncoding read FEncoding;*/
		public TEncoding Encoding
		{
			get
			{
				return FEncoding;
			}
		}
		/*property NewLine : string read FNewLine write FNewLine;*/
		public string NewLine
		{
			get
			{
				return FNewLine;
			}
			set
			{
				FNewLine = value;
			}
		}

		public TStreamWriter() {}
	}	

	public class TRecall : TObject
	{
		private TPersistent FStorage;
		private TPersistent FReference;

/* TRecall */
		public TRecall(TPersistent AStorage, TPersistent AReference)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public void Forget()
		{
		}
		public void Store()
		{
		}
		/*property Reference : TPersistent read FReference;*/
		public TPersistent Reference
		{
			get
			{
				return FReference;
			}
		}
	}	

	public class TParser : TObject
	{
		private TStream FStream;
		private TToken FToken;

/* TParser */
		public TParser(TStream Stream)
		{
			;
		}
		public void CheckToken(TToken T)
		{
		}
		public void CheckTokenSymbol(string S)
		{
		}
		public void Error(string Ident)
		{
		}
		public void ErrorFmt(string Ident, params TVarRec[] Args)
		{
		}
		public TToken NextToken()
		{
			TToken result = TToken.toEOF;
			result = TToken.toEOF;
			return result;
		}
		public int SourceLine()
		{
			int result = 0;
			result = 0;
			return result;
		}
		public string TokenComponentIdent()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public double TokenFloat()
		{
			double result = 0.0D;
			result = 0.0F;
			return result;
		}
		public long TokenInt()
		{
			long result = 0;
			result = 0;
			return result;
		}
		public string TokenString()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public bool TokenSymbolIs(string S)
		{
			bool result = false;
			result = false;
			return result;
		}
		public string TokenWideString()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		/*property Token : TToken read FToken;*/
		public TToken Token
		{
			get
			{
				return FToken;
			}
		}
	}	

	public class TBasicActionLink : TObject
	{
		private TBasicAction FAction;
		private TObject FClient;
		protected virtual void AssignClient(TObject AClient)
		{
		}
		protected virtual bool IsGroupIndexLinked()
		{
			bool result = false;
			result = false;
			return result;
		}
		protected virtual bool IsOnExecuteLinked()
		{
			bool result = false;
			result = false;
			return result;
		}
		protected virtual void SetGroupIndex(int Value)
		{
		}
		protected virtual void SetOnExecute(TNotifyEvent Value)
		{
		}

/* TBasicActionLink */
		public TBasicActionLink(TObject AClient)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public virtual void Assign(TObject Source)
		{
		}
		public virtual bool Execute(TObject AClient = default)
		{
			bool result = false;
			result = false;
			return result;
		}
		public virtual bool Update()
		{
			bool result = false;
			result = false;
			return result;
		}
		/*property Action : TBasicAction read FAction write FAction;*/
		public TBasicAction Action
		{
			get
			{
				return FAction;
			}
			set
			{
				FAction = value;
			}
		}
		/*property Client : TObject read FClient;*/
		public TObject Client
		{
			get
			{
				return FClient;
			}
		}
	}	

	abstract public class TTextReader : TObject
	{
		abstract public int Peek();

/* TTextReader */
		abstract public int Read();
		public virtual int Read(ref char[] Buffer, int Index, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual int ReadBlock(ref char[] Buffer, int Index, int Count)
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual string ReadLine()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public virtual string ReadToEnd()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public TTextReaderEnumerator GetEnumerator()
		{
			TTextReaderEnumerator result = default;
			result = default;
			return result;
		}

		public TTextReader() {}
	}	

	public class TTextReaderEnumerator : TObject
	{
		private TTextReader FReader;
		private string FCurrent = string.Empty;

/* TTextReaderEnumerator */
		public TTextReaderEnumerator(TTextReader AReader)
		{
			;
		}
		public bool MoveNext()
		{
			bool result = false;
			result = false;
			return result;
		}
		/*property Current : string read FCurrent;*/
		public string Current
		{
			get
			{
				return FCurrent;
			}
		}
	}	

	public class TTextWriter : TObject
	{
		private string FNewLine = string.Empty;

/* TTextWriter */
		public TTextWriter()
		{
			;
		}
		public virtual void Close()
		{
		}
		public virtual void Flush()
		{
		}
		public virtual void Write(bool Value)
		{
		}
		public virtual void Write(char Value)
		{
		}
		public virtual void Write(int Value)
		{
		}
		public virtual void Write(long Value)
		{
		}
		public virtual void Write(float Value)
		{
		}
		public virtual void Write(double Value)
		{
		}
		public virtual void Write(string Value)
		{
		}
		public virtual void WriteLine()
		{
		}
		public virtual void WriteLine(string Value)
		{
		}
		/*property NewLine : string read FNewLine write FNewLine;*/
		public string NewLine
		{
			get
			{
				return FNewLine;
			}
			set
			{
				FNewLine = value;
			}
		}
	}	

	public class TBinaryReader : TObject
	{
		private TStream FStream;
		private TEncoding FEncoding;
		private bool FOwnsStream;

/* TBinaryReader */
		public TBinaryReader(TStream Stream, TEncoding AEncoding = default, bool AOwnsStream = false)
		{
			;
		}
		public TBinaryReader(string Filename, TEncoding Encoding = default)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public virtual void Close()
		{
		}
		public virtual bool ReadBoolean()
		{
			bool result = false;
			result = false;
			return result;
		}
		public virtual byte ReadByte()
		{
			byte result = 0;
			result = 0;
			return result;
		}
		public virtual byte[] ReadBytes(int Count)
		{
			byte[] result = new byte[]{};
			return result;
		}
		public virtual char ReadChar()
		{
			char result = '\0';
			result = '\x00';
			return result;
		}
		public virtual char[] ReadChars(int Count)
		{
			char[] result = new char[]{};
			return result;
		}
		public virtual double ReadDouble()
		{
			double result = 0.0D;
			result = 0.0F;
			return result;
		}
		public virtual int ReadInteger()
		{
			int result = 0;
			result = 0;
			return result;
		}
		public virtual long ReadInt64()
		{
			long result = 0;
			result = 0;
			return result;
		}
		public virtual sbyte ReadShortInt()
		{
			sbyte result = 0;
			result = 0;
			return result;
		}
		public virtual float ReadSingle()
		{
			float result = 0.0F;
			result = 0.0F;
			return result;
		}
		public virtual short ReadSmallInt()
		{
			short result = 0;
			result = 0;
			return result;
		}
		public virtual string ReadString()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public virtual ulong ReadUInt64()
		{
			ulong result = 0;
			result = 0;
			return result;
		}
		public virtual ushort ReadWord()
		{
			ushort result = 0;
			result = 0;
			return result;
		}
		public virtual uint ReadCardinal()
		{
			uint result = 0;
			result = 0;
			return result;
		}
		/*property BaseStream : TStream read FStream;*/
		public TStream BaseStream
		{
			get
			{
				return FStream;
			}
		}

		public TBinaryReader() {}
	}	

	public class TBinaryWriter : TObject
	{
		private TStream FStream;
		private TEncoding FEncoding;
		private bool FOwnsStream;

/* TBinaryWriter */
		public TBinaryWriter()
		{
			;
		}
		public TBinaryWriter(TStream Stream)
		{
			;
		}
		public TBinaryWriter(TStream Stream, TEncoding Encoding)
		{
			;
		}
		public TBinaryWriter(TStream Stream, TEncoding Encoding, bool AOwnsStream)
		{
			;
		}
		public TBinaryWriter(string Filename, bool Append = false)
		{
			;
		}
		public TBinaryWriter(string Filename, bool Append, TEncoding Encoding)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public virtual void Close()
		{
		}
		public virtual void Flush()
		{
		}
		public virtual void Seek(int Offset, TSeekOrigin Origin)
		{
		}
		public virtual void Write(byte Value)
		{
		}
		public virtual void Write(bool Value)
		{
		}
		public virtual void Write(char Value)
		{
		}
		public virtual void Write(char[] Value)
		{
		}
		public virtual void Write(byte[] Value)
		{
		}
		public virtual void Write(double Value)
		{
		}
		public virtual void Write(int Value)
		{
		}
		public virtual void Write(short Value)
		{
		}
		public virtual void Write(sbyte Value)
		{
		}
		public virtual void Write(ushort Value)
		{
		}
		public virtual void Write(uint Value)
		{
		}
		public virtual void Write(long Value)
		{
		}
		public virtual void Write(float Value)
		{
		}
		public virtual void Write(string Value)
		{
		}
		public virtual void Write(ulong Value)
		{
		}
		public virtual void Write(char[] Value, int Index, int Count)
		{
		}
		public virtual void Write(byte[] Value, int Index, int Count)
		{
		}
		/*property BaseStream : TStream read FStream;*/
		public TStream BaseStream
		{
			get
			{
				return FStream;
			}
		}
	}	

	public class TFiler : TObject
	{
		private TComponent FRoot;
		protected void DefineProperty(string Name, TReaderProc ReadData, TWriterProc WriteData, bool HasData)
		{
		}
		protected void DefineBinaryProperty(string Name, TStreamProc ReadData, TStreamProc WriteData, bool HasData)
		{
		}

/* TFiler */
		public TFiler(TStream Stream, int BufSize)
		{
			;
		}
		public virtual void DefineProperties(TPersistent Instance)
		{
		}
		public virtual void FlushBuffer()
		{
		}
		/*property Root : TComponent read FRoot write FRoot;*/
		public TComponent Root
		{
			get
			{
				return FRoot;
			}
			set
			{
				FRoot = value;
			}
		}
	}	

	public class TReader : TFiler
	{


/* TReader */
		public TReader(TStream Stream, int BufSize)
		:		base(Stream, BufSize)
		{
			//# base.Create(Stream, BufSize);
		}
		public void BeginReferences()
		{
		}
		public void CheckValue(byte Value)
		{
		}
		public override void DefineProperties(TPersistent Instance)
		{
		}
		public void EndReferences()
		{
		}
		public void FixupReferences()
		{
		}
		public bool ReadBoolean()
		{
			bool result = false;
			result = false;
			return result;
		}
		public char ReadChar()
		{
			char result = '\0';
			result = '\x00';
			return result;
		}
		public TCollection ReadCollection(TCollection Collection)
		{
			TCollection result = default;
			result = Collection;
			return result;
		}
		public TComponent ReadComponent(TComponent Component)
		{
			TComponent result = default;
			result = Component;
			return result;
		}
		public double ReadFloat()
		{
			double result = 0.0D;
			result = 0.0F;
			return result;
		}
		public string ReadIdent()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public int ReadInteger()
		{
			int result = 0;
			result = 0;
			return result;
		}
		public long ReadInt64()
		{
			long result = 0;
			result = 0;
			return result;
		}
		public bool ReadListBegin()
		{
			bool result = false;
			result = false;
			return result;
		}
		public void ReadListEnd()
		{
		}
		public TComponent ReadRootComponent(TComponent Root)
		{
			TComponent result = default;
			result = Root;
			return result;
		}
		public string ReadString()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		public Variant ReadVariant()
		{
			Variant result = default(Variant);
			return result;
		}
	}	

	public class TWriter : TFiler
	{


/* TWriter */
		public TWriter(TStream Stream, int BufSize)
		:		base(Stream, BufSize)
		{
			//# base.Create(Stream, BufSize);
		}
		public override void DefineProperties(TPersistent Instance)
		{
		}
		public override void FlushBuffer()
		{
		}
		public void WriteBoolean(bool Value)
		{
		}
		public void WriteChar(char Value)
		{
		}
		public void WriteCollection(TCollection Value)
		{
		}
		public void WriteComponent(TComponent Component)
		{
		}
		public void WriteFloat(double Value)
		{
		}
		public void WriteIdent(string Ident)
		{
		}
		public void WriteInteger(int Value)
		{
		}
		public void WriteInt64(long Value)
		{
		}
		public void WriteListBegin()
		{
		}
		public void WriteListEnd()
		{
		}
		public void WriteRootComponent(TComponent Root)
		{
		}
		public void WriteString(string Value)
		{
		}
		public void WriteVariant(Variant Value)
		{
		}
	}	

	public class TComponent : TPersistent
	{
		private TComponent FOwner;
		private string FName = string.Empty;
		private int FTag;
		private TSet FComponentState = new TSet();
		private TSet FComponentStyle = new TSet();
		private TObservers FObservers;
		private TComponent GetComponent(int Index)
		{
			TComponent result = default;
			result = default;
			return result;
		}
		private int GetComponentCount()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private int GetComponentIndex()
		{
			int result = 0;
			result = 0;
			return result;
		}
		private void SetComponentIndex(int Value)
		{
		}
		private void SetName(string NewName)
		{
		}
		protected virtual void ChangeName(string NewName)
		{
		}
		protected virtual void DefineProperties(TFiler Filer)
		{
		}
		protected virtual void GetChildren(TGetChildProc Proc, TComponent Root)
		{
		}
		protected virtual TComponent GetChildOwner()
		{
			TComponent result = default;
			result = default;
			return result;
		}
		protected virtual TComponent GetChildParent()
		{
			TComponent result = default;
			result = default;
			return result;
		}
		/*protected  overrides: */public override string GetNamePath()
		{
			string result = string.Empty;
			result = "";
			return result;
		}
		protected virtual TObservers GetObservers()
		{
			TObservers result = default;
			result = FObservers;
			return result;
		}
		protected virtual TPersistent GetOwner()
		{
			TPersistent result = default;
			result = FOwner;
			return result;
		}
		protected virtual void Loaded()
		{
		}
		protected virtual void Notification(TComponent AComponent, TOperation Operation)
		{
		}
		protected virtual bool CanObserve(int ID)
		{
			bool result = false;
			result = false;
			return result;
		}
		protected virtual void ObserverAdded(int ID, IObserver Observer)
		{
		}
		protected virtual void ReadState(TReader Reader)
		{
		}
		protected void SetAncestor(bool Value)
		{
		}
		protected void SetDesigning(bool Value, bool SetChildren = true)
		{
		}
		protected virtual void SetParentComponent(TComponent Value)
		{
		}
		protected void SetSubComponent(bool IsSubComponent)
		{
		}
		protected virtual void Updating()
		{
		}
		protected virtual void Updated()
		{
		}
		protected virtual void ValidateContainer(TComponent AComponent)/*# dynamic */
		{
		}
		protected virtual void ValidateInsert(TComponent AComponent)/*# dynamic */
		{
		}
		protected virtual void WriteState(TWriter Writer)
		{
		}

/* TComponent */
		public TComponent(TComponent AOwner)
		{
			;
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public override void BeforeDestruction()
		{
			base.BeforeDestruction();
		}
		public void DestroyComponents()
		{
		}
		public void Destroying()
		{
		}
		public TComponent FindComponent(string AName)
		{
			TComponent result = default;
			result = default;
			return result;
		}
		public TComponentEnumerator GetEnumerator()
		{
			TComponentEnumerator result = default;
			result = default;
			return result;
		}
		public void FreeNotification(TComponent AComponent)
		{
		}
		public void RemoveFreeNotification(TComponent AComponent)
		{
		}
		public void FreeOnRelease()
		{
		}
		public virtual TComponent GetParentComponent()
		{
			TComponent result = default;
			result = default;
			return result;
		}
		public virtual bool HasParent()
		{
			bool result = false;
			result = false;
			return result;
		}
		public void InsertComponent(TComponent AComponent)
		{
		}
		public void RemoveComponent(TComponent AComponent)
		{
		}
		/*property ComponentCount : int read GetComponentCount;*/
		public int ComponentCount
		{
			get
			{
				return GetComponentCount();
			}
		}
		/*property ComponentIndex : int read GetComponentIndex write SetComponentIndex;*/
		public int ComponentIndex
		{
			get
			{
				return GetComponentIndex();
			}
			set
			{
				SetComponentIndex(value);
			}
		}
		/*property Components [Index: integer]: TComponent read GetComponent;*/
		public TComponent ReadPropertyComponents(int Index) { return GetComponent(Index);}
		/*property ComponentState : TComponentState read FComponentState;*/
		public TSet ComponentState
		{
			get
			{
				return FComponentState;
			}
		}
		/*property ComponentStyle : TComponentStyle read FComponentStyle;*/
		public TSet ComponentStyle
		{
			get
			{
				return FComponentStyle;
			}
		}
		/*property Owner : TComponent read FOwner;*/
		public TComponent Owner
		{
			get
			{
				return FOwner;
			}
		}
		/*property Observers : TObservers read GetObservers;*/
		public TObservers Observers
		{
			get
			{
				return GetObservers();
			}
		}
		/*property Name : string read FName write SetName;*/
		public string Name
		{
			get
			{
				return FName;
			}
			set
			{
				SetName(value);
			}
		}
		/*property Tag : int read FTag write FTag;*/
		public int Tag
		{
			get
			{
				return FTag;
			}
			set
			{
				FTag = value;
			}
		}
	}	

	public class TComponentEnumerator : TObject
	{
		private TComponent FComponent;
		private int FIndex;
		private TComponent GetCurrent()
		{
			TComponent result = default;
			result = default;
			return result;
		}

/* TComponentEnumerator */
		public TComponentEnumerator(TComponent AComponent)
		{
			;
		}
		public bool MoveNext()
		{
			bool result = false;
			result = false;
			return result;
		}
		/*property Current : TComponent read GetCurrent;*/
		public TComponent Current
		{
			get
			{
				return GetCurrent();
			}
		}
	}	

	public class TBasicAction : TComponent
	{
		private TComponent FActionComponent;
		private TNotifyEvent FOnExecute;
		private TNotifyEvent FOnUpdate;
		protected virtual void Change()
		{
		}
		protected virtual bool HandlesTarget(TObject Target)
		{
			bool result = false;
			result = false;
			return result;
		}
		protected virtual void SetAutoCheck(bool Value)
		{
		}
		protected virtual void SetCaption(string Value)
		{
		}
		protected virtual void SetEnabled(bool Value)
		{
		}
		protected virtual void SetVisible(bool Value)
		{
		}

/* TBasicAction */
		public TBasicAction(TComponent AOwner)
		:		base(AOwner)
		{
			//# base.Create(AOwner);
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public virtual bool Execute()/*# dynamic */
		{
			bool result = false;
			result = false;
			return result;
		}
		public virtual bool ExecuteTarget(TObject Target)
		{
			bool result = false;
			result = false;
			return result;
		}
		public virtual bool Update()/*# dynamic */
		{
			bool result = false;
			result = false;
			return result;
		}
		public virtual bool UpdateTarget(TObject Target)
		{
			bool result = false;
			result = false;
			return result;
		}
		/*property ActionComponent : TComponent read FActionComponent write FActionComponent;*/
		public TComponent ActionComponent
		{
			get
			{
				return FActionComponent;
			}
			set
			{
				FActionComponent = value;
			}
		}
		/*property OnExecute : TNotifyEvent read FOnExecute write FOnExecute;*/
		public TNotifyEvent OnExecute
		{
			get
			{
				return FOnExecute;
			}
			set
			{
				FOnExecute = value;
			}
		}
		/*property OnUpdate : TNotifyEvent read FOnUpdate write FOnUpdate;*/
		public TNotifyEvent OnUpdate
		{
			get
			{
				return FOnUpdate;
			}
			set
			{
				FOnUpdate = value;
			}
		}
	}	

	public class TDataModule : TComponent
	{
		private bool FOldCreateOrder;
		private TNotifyEvent FOnCreate;
		private TNotifyEvent FOnDestroy;

/* TDataModule */
		public TDataModule(TComponent AOwner)
		:		base(AOwner)
		{
			//# base.Create(AOwner);
		}
		public override void Destroy()
		{
			if(!FDisposed)
			{
				//# inherited;
			}
		}
		public override void AfterConstruction()
		{
			base.AfterConstruction();
		}
		public override void BeforeDestruction()
		{
			base.BeforeDestruction();
		}
		/*property OldCreateOrder : bool read FOldCreateOrder write FOldCreateOrder;*/
		public bool OldCreateOrder
		{
			get
			{
				return FOldCreateOrder;
			}
			set
			{
				FOldCreateOrder = value;
			}
		}
		/*property OnCreate : TNotifyEvent read FOnCreate write FOnCreate;*/
		public TNotifyEvent OnCreate
		{
			get
			{
				return FOnCreate;
			}
			set
			{
				FOnCreate = value;
			}
		}
		/*property OnDestroy : TNotifyEvent read FOnDestroy write FOnDestroy;*/
		public TNotifyEvent OnDestroy
		{
			get
			{
				return FOnDestroy;
			}
			set
			{
				FOnDestroy = value;
			}
		}
	}	
	public const int fmCreate = 0xFF00;
	public const int MaxListSize = 0x07FFFFFF;
	public enum TSeekOrigin {soBeginning,
                  soCurrent,
                  soEnd };
	public enum TStreamOwnership {soReference,
                       soOwned };
public delegate void TNotifyEvent(TObject Sender);
public delegate bool THelpEvent(ushort Command, int Data, ref bool CallHelp);
public delegate void TObserverToggleEvent(IInterface AObserver, bool Value);
public delegate bool TCanObserveEvent(int ID);
public delegate void TObserverAddedEvent(int ID, IObserver Observer);
public delegate void TGetStrProc(string S);
public delegate void TGetObjectProc(string S, TObject AObject);
public delegate void TReaderProc(TReader Reader);
public delegate void TWriterProc(TWriter Writer);
public delegate void TStreamProc(TStream Stream);
public delegate void TGetChildProc(TComponent Child);
public delegate int TListSortCompare(IntPtr Item1, IntPtr Item2);
public delegate int TStringListSortCompare(TStringList List, int Index1, int Index2);
	public enum TComponentStateItem {csLoading,
                          csReading,
                          csWriting,
                          csDestroying,
                          csDesigning,
                          csAncestor,
                          csUpdating,
                          csFixups,
                          csFreeNotification,
                          csInline,
                          csDesignInstance };
	public enum TComponentStyleItem {csInheritable,
                          csCheckPropAvail,
                          csSubComponent,
                          csTransient };
	public enum TOperation {opInsert,
                 opRemove };
	public enum TStringsDefinedItem {sdDelimiter,
                          sdQuoteChar,
                          sdNameValueSeparator,
                          sdLineBreak,
                          sdStrictDelimiter };
	public enum TDuplicates {dupIgnore,
                  dupAccept,
                  dupError };
	public enum TListNotification {lnAdded,
                        lnExtracted,
                        lnDeleted };
	public enum TCollectionNotification {cnAdded,
                              cnExtracting,
                              cnRemoved };
	public enum TAlignment {taLeftJustify,
                 taRightJustify,
                 taCenter };
	public enum TToken {toEOF,
             toSymbol,
             toString,
             toInteger,
             toFloat,
             toWString };
	public static ushort StreamOriginalFormat()
	{
		ushort result = 0;
		result = 0;
		return result;
	}
	public static bool ObjectBinaryToText(TStream Input, TStream Output)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static bool ObjectTextToBinary(TStream Input, TStream Output)
	{
		bool result = false;
		result = false;
		return result;
	}
	public static void WriteComponentResFile(string FileName, TComponent Instance)
	{
	}
	public static TComponent ReadComponentResFile(string FileName, TComponent Instance)
	{
		TComponent result = default;
		result = Instance;
		return result;
	}
	
} // class ClassesInterface


file class ClassesImplementation
{

} // class ClassesImplementation

}  // namespace Classes

}  // namespace System

