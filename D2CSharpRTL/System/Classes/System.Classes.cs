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
			Obj = default;
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
		private readonly global::System.Collections.Generic.List<Pointer> FItems =
			new global::System.Collections.Generic.List<Pointer>();

		protected virtual void Notify(Pointer Ptr, TListNotification Action)
		{
		}

		private Pointer Get(int Index)
		{
			if ((uint)Index >= (uint)FItems.Count)
				throw new global::System.ArgumentOutOfRangeException(nameof(Index));
			return FItems[Index];
		}

		private void Put(int Index, Pointer Item)
		{
			if ((uint)Index >= (uint)FItems.Count)
				throw new global::System.ArgumentOutOfRangeException(nameof(Index));
			FItems[Index] = Item;
		}

		private void SetCapacity(int NewCapacity)
		{
			if (NewCapacity < FItems.Count)
				throw new global::System.ArgumentOutOfRangeException(nameof(NewCapacity));
			FItems.Capacity = NewCapacity;
		}

		private void SetCount(int NewCount)
		{
			if (NewCount < 0)
				throw new global::System.ArgumentOutOfRangeException(nameof(NewCount));
			while (FItems.Count < NewCount)
				FItems.Add(default);
			while (FItems.Count > NewCount)
				FItems.RemoveAt(FItems.Count - 1);
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				FItems.Clear();
				base.Destroy();
			}
		}

		public int Add(Pointer Item)
		{
			int Result = FItems.Count;
			FItems.Add(Item);
			Notify(Item, TListNotification.lnAdded);
			return Result;
		}

		public virtual void Clear()
		{
			for (int Index = FItems.Count - 1; Index >= 0; Index--)
				Notify(FItems[Index], TListNotification.lnDeleted);
			FItems.Clear();
		}

		public void Delete(int Index)
		{
			Pointer Item = Get(Index);
			FItems.RemoveAt(Index);
			Notify(Item, TListNotification.lnDeleted);
		}

		public static void Error(string Msg, int Data)
		{
			throw new global::System.ArgumentOutOfRangeException(nameof(Data), Data, Msg);
		}

		public static void Error(Pointer<TResStringRec> Msg, int Data)
		{
			throw new global::System.ArgumentOutOfRangeException(nameof(Data), Data, "TList error");
		}

		public void Exchange(int Index1, int Index2)
		{
			Pointer Temp = Get(Index1);
			FItems[Index1] = Get(Index2);
			FItems[Index2] = Temp;
		}

		public Pointer Extract(Pointer Item)
		{
			int Index = IndexOf(Item);
			if (Index < 0)
				return default;
			Pointer Result = FItems[Index];
			FItems.RemoveAt(Index);
			Notify(Result, TListNotification.lnExtracted);
			return Result;
		}

		public Pointer First() => FItems.Count == 0 ? default : FItems[0];

		public int IndexOf(Pointer Item) => FItems.IndexOf(Item);

		public void Insert(int Index, Pointer Item)
		{
			if ((uint)Index > (uint)FItems.Count)
				throw new global::System.ArgumentOutOfRangeException(nameof(Index));
			FItems.Insert(Index, Item);
			Notify(Item, TListNotification.lnAdded);
		}

		public Pointer Last() => FItems.Count == 0 ? default : FItems[FItems.Count - 1];

		public TListEnumerator GetEnumerator() => new TListEnumerator(this);

		public void Move(int CurIndex, int NewIndex)
		{
			Pointer Item = Get(CurIndex);
			FItems.RemoveAt(CurIndex);
			FItems.Insert(NewIndex, Item);
		}

		public void Pack()
		{
			for (int Index = FItems.Count - 1; Index >= 0; Index--)
				if (FItems[Index].Equals(default(Pointer)))
					FItems.RemoveAt(Index);
		}

		public int Remove(Pointer Item)
		{
			int Index = IndexOf(Item);
			if (Index >= 0)
				Delete(Index);
			return Index;
		}

		public void Sort(TListSortCompare Compare)
		{
			if (Compare == null)
				throw new global::System.ArgumentNullException(nameof(Compare));
			FItems.Sort((Left, Right) => Compare(Left, Right));
		}

		public int Capacity
		{
			get => FItems.Capacity;
			set => SetCapacity(value);
		}

		public int Count
		{
			get => FItems.Count;
			set => SetCount(value);
		}

		public Pointer ReadPropertyItems(int Index) => Get(Index);
		public void WritePropertyItems(int Index, Pointer Item) => Put(Index, Item);

		public Pointer this[int Index]
		{
			get => Get(Index);
			set => Put(Index, value);
		}

		public TList() {}
	}	

	public class TListEnumerator : TObject
	{
		private readonly TList FList;
		private int FIndex;

		private Pointer GetCurrent()
		{
			if (FIndex < 0 || FIndex >= FList.Count)
				return default;
			return FList[FIndex];
		}
		public TListEnumerator() : this(new TList()) { }


		public TListEnumerator(TList AList)
		{
			FList = AList ?? throw new global::System.ArgumentNullException(nameof(AList));
			FIndex = -1;
		}

		public bool MoveNext()
		{
			FIndex++;
			return FIndex < FList.Count;
		}

		public Pointer Current => GetCurrent();
	}	

	public class TBits : TObject
	{
		private bool[] FBits = global::System.Array.Empty<bool>();

		private bool GetBit(int Index)
		{
			if ((uint)Index >= (uint)FBits.Length)
				throw new global::System.ArgumentOutOfRangeException(nameof(Index));
			return FBits[Index];
		}

		private void SetBit(int Index, bool Value)
		{
			if (Index < 0)
				throw new global::System.ArgumentOutOfRangeException(nameof(Index));
			if (Index >= FBits.Length)
				SetSize(Index + 1);
			FBits[Index] = Value;
		}

		private void SetSize(int Value)
		{
			if (Value < 0)
				throw new global::System.ArgumentOutOfRangeException(nameof(Value));
			global::System.Array.Resize(ref FBits, Value);
		}

		public int OpenBit()
		{
			for (int Index = 0; Index < FBits.Length; Index++)
				if (!FBits[Index])
					return Index;
			return FBits.Length;
		}

		public bool ReadPropertyBits(int Index) => GetBit(Index);
		public void WritePropertyBits(int Index, bool Value) => SetBit(Index, Value);

		public bool this[int Index]
		{
			get => GetBit(Index);
			set => SetBit(Index, value);
		}

		public int Size
		{
			get => FBits.Length;
			set => SetSize(value);
		}

		public TBits() {}
	}	

	public class TInterfaceList : TInterfacedObject, IInterfaceList, IInterfaceListEx
	{
		private readonly global::System.Collections.Generic.List<IInterface> FItems =
			new global::System.Collections.Generic.List<IInterface>();
		private readonly object FLock = new object();

		public int GetCapacity() => FItems.Capacity;
		public int GetCount() => FItems.Count;
		public IInterface GetItem(int Index) => FItems[Index];

		public void SetCapacity(int NewCapacity)
		{
			if (NewCapacity < FItems.Count)
				throw new global::System.ArgumentOutOfRangeException(nameof(NewCapacity));
			FItems.Capacity = NewCapacity;
		}

		public void SetItem(int Index, IInterface Item) => FItems[Index] = Item;

		public int Add(IInterface Item)
		{
			int Result = FItems.Count;
			FItems.Add(Item);
			return Result;
		}

		public void Clear() => FItems.Clear();
		public void Delete(int Index) => FItems.RemoveAt(Index);

		public void Exchange(int Index1, int Index2)
		{
			IInterface Temp = FItems[Index1];
			FItems[Index1] = FItems[Index2];
			FItems[Index2] = Temp;
		}

		public TInterfaceList Expand()
		{
			if (FItems.Count == FItems.Capacity)
				FItems.Capacity = FItems.Capacity == 0 ? 4 : FItems.Capacity * 2;
			return this;
		}

		public IInterface First() => FItems.Count == 0 ? default : FItems[0];
		public TInterfaceListEnumerator GetEnumerator() => new TInterfaceListEnumerator(this);
		public int IndexOf(IInterface Item) => FItems.IndexOf(Item);
		public void Insert(int Index, IInterface Item) => FItems.Insert(Index, Item);
		public IInterface Last() => FItems.Count == 0 ? default : FItems[FItems.Count - 1];

		public int Remove(IInterface Item)
		{
			int Index = FItems.IndexOf(Item);
			if (Index >= 0)
				FItems.RemoveAt(Index);
			return Index;
		}

		public void Lock() => global::System.Threading.Monitor.Enter(FLock);
		public void Unlock() => global::System.Threading.Monitor.Exit(FLock);

		public int Capacity
		{
			get => GetCapacity();
			set => SetCapacity(value);
		}

		public int Count => GetCount();

		public IInterface ReadPropertyItems(int Index) => GetItem(Index);
		public void WritePropertyItems(int Index, IInterface Item) => SetItem(Index, Item);

		public IInterface this[int Index]
		{
			get => GetItem(Index);
			set => SetItem(Index, value);
		}

		public TInterfaceList() {}
	}	

	public class TInterfaceListEnumerator : TObject
	{
		private readonly TInterfaceList FList;
		private int FIndex;

		private IInterface GetCurrent()
		{
			if (FIndex < 0 || FIndex >= FList.Count)
				return default;
			return FList[FIndex];
		}
		public TInterfaceListEnumerator() : this(new TInterfaceList()) { }


		public TInterfaceListEnumerator(TInterfaceList AList)
		{
			FList = AList ?? throw new global::System.ArgumentNullException(nameof(AList));
			FIndex = -1;
		}

		public bool MoveNext()
		{
			FIndex++;
			return FIndex < FList.Count;
		}

		public IInterface Current => GetCurrent();
	}	

	public class TObservers : TObject
	{
		private TCanObserveEvent FOnCanObserve;
		private TObserverAddedEvent FOnObserverAdded;
		private readonly global::System.Collections.Generic.Dictionary<int,
			global::System.Collections.Generic.List<IInterface>> FObservers =
			new global::System.Collections.Generic.Dictionary<int,
				global::System.Collections.Generic.List<IInterface>>();

		public TObservers()
		{
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				FObservers.Clear();
				base.Destroy();
			}
		}

		public virtual void AddObserver(int ID, IInterface AIntf)
		{
			if (AIntf == null)
				throw new global::System.ArgumentNullException(nameof(AIntf));
			if (!CanObserve(ID))
				return;

			if (!FObservers.TryGetValue(ID, out var List))
			{
				List = new global::System.Collections.Generic.List<IInterface>();
				FObservers.Add(ID, List);
			}
			if (!List.Contains(AIntf))
			{
				List.Add(AIntf);
				FOnObserverAdded?.Invoke(ID, AIntf as IObserver);
			}
		}

		public virtual void AddObserver(int[] IDs, IInterface AIntf)
		{
			if (IDs == null)
				throw new global::System.ArgumentNullException(nameof(IDs));
			foreach (int ID in IDs)
				AddObserver(ID, AIntf);
		}

		public virtual bool CanObserve(int ID)
		{
			return FOnCanObserve == null || FOnCanObserve(ID);
		}

		public virtual bool IsObserving(int ID)
		{
			return FObservers.TryGetValue(ID, out var List) && List.Count != 0;
		}

		public virtual void RemoveObserver(int ID, IInterface AIntf)
		{
			if (!FObservers.TryGetValue(ID, out var List))
				return;
			List.Remove(AIntf);
			if (List.Count == 0)
				FObservers.Remove(ID);
		}

		public virtual bool TryIsObserving(int ID, out IInterface AIntf)
		{
			AIntf = default;
			if (!FObservers.TryGetValue(ID, out var List) || List.Count == 0)
				return false;
			AIntf = List[0];
			return true;
		}

		public TCanObserveEvent OnCanObserve
		{
			get => FOnCanObserve;
			set => FOnCanObserve = value;
		}

		public TObserverAddedEvent OnObserverAdded
		{
			get => FOnObserverAdded;
			set => FOnObserverAdded = value;
		}
	}	

	public class TObserverMapping : TObject
	{
		private static readonly object FSyncRoot = new object();
		private static readonly TObserverMapping FInstance = new TObserverMapping();
		private readonly global::System.Collections.Generic.HashSet<TClass> FEnabledClasses =
			new global::System.Collections.Generic.HashSet<TClass>();

		protected static TObserverMapping Instance()
		{
			return FInstance;
		}

/* TObserverMapping */
		public TObserverMapping()
		{
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				lock (FSyncRoot)
					FEnabledClasses.Clear();
				base.Destroy();
			}
		}

		public static void Clear()
		{
			lock (FSyncRoot)
				Instance().FEnabledClasses.Clear();
		}

		public static void EnableObservers(TClass AClass)
		{
			lock (FSyncRoot)
				Instance().FEnabledClasses.Add(AClass);
		}

		public static void DisableObservers(TClass AClass)
		{
			lock (FSyncRoot)
				Instance().FEnabledClasses.Remove(AClass);
		}
	}	

	public class TLinkObservers : TObject
	{


/* TLinkObservers */
		public static bool IsObserving(TObservers AObservers, int ID)
		{
			return AObservers != null && AObservers.IsObserving(ID);
		}

		public TLinkObservers() {}
	}	

	public class TPersistent : TObject
	{
		protected void AssignError(TPersistent Source)
		{
			throw new global::System.ArgumentException(
				"Cannot assign " +
				(Source == null ? "nil" : Source.GetType().FullName) +
				" to " + GetType().FullName + ".", nameof(Source));
		}

		protected virtual void AssignTo(TPersistent Dest)
		{
			Dest?.AssignError(this);
		}

		public virtual void Assign(TPersistent Source)
		{
			if (Source == null)
				AssignError(Source);
			else
				Source.AssignTo(this);
		}

		public virtual string GetNamePath()
		{
			return GetType().Name;
		}

		public TPersistent() {}
	}	

	public class TCollectionItem : TPersistent
	{
		private TCollection FCollection;
		private int FID;
		private string FDisplayName = string.Empty;

		private int GetIndex()
		{
			return FCollection == null ? -1 : FCollection.IndexOfItem(this);
		}

		private void SetCollection(TCollection Value)
		{
			if (global::System.Object.ReferenceEquals(FCollection, Value))
				return;
			FCollection?.RemoveItem(this);
			Value?.AddExistingItem(this);
		}

		private void SetIndex(int Value)
		{
			FCollection?.SetItemIndex(this, Value);
		}

		protected virtual string GetDisplayName()
		{
			return string.IsNullOrEmpty(FDisplayName) ? GetType().Name : FDisplayName;
		}

		protected virtual void SetDisplayName(string Value)
		{
			FDisplayName = Value ?? string.Empty;
		}

		protected virtual void SetItemName()
		{
		}

		internal void InvokeSetItemName() => SetItemName();
		internal void SetCollectionDirect(TCollection Value) => FCollection = Value;
		internal void SetIDDirect(int Value) => FID = Value;
		public TCollectionItem() : this(null) { }


		public TCollectionItem(TCollection Collection)
		{
			if (Collection != null)
				Collection.AddExistingItem(this);
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				FCollection?.RemoveItem(this);
				FCollection = null;
				base.Destroy();
			}
		}

		public TCollection Collection
		{
			get => FCollection;
			set => SetCollection(value);
		}

		public int ID => FID;

		public int Index
		{
			get => GetIndex();
			set => SetIndex(value);
		}

		public string DisplayName
		{
			get => GetDisplayName();
			set => SetDisplayName(value);
		}
	}	

	public class TCollection : TPersistent
	{
		private TClass FItemClass;
		private readonly global::System.Collections.Generic.List<TCollectionItem> FItems =
			new global::System.Collections.Generic.List<TCollectionItem>();
		private int FNextID;
		private int FUpdateCount;

		private int GetCount() => FItems.Count;
		private TCollectionItem GetItem(int Index) => FItems[Index];

		private void SetItem(int Index, TCollectionItem Value)
		{
			if (Value == null)
				throw new global::System.ArgumentNullException(nameof(Value));
			if (global::System.Object.ReferenceEquals(FItems[Index], Value))
				return;

			TCollectionItem Old = FItems[Index];
			Old.SetCollectionDirect(null);
			Value.Collection?.RemoveItem(Value);
			Value.SetCollectionDirect(this);
			if (Value.ID == 0)
				Value.SetIDDirect(GetItemID());
			FItems[Index] = Value;
			Update(Value);
		}

		protected TCollectionItem Add()
		{
			TCollectionItem Item = CreateItemInstance();
			AddExistingItem(Item);
			return Item;
		}

		private TCollectionItem CreateItemInstance()
		{
			global::System.Type ItemType = null;
			if (FItemClass != null)
			{
				object Boxed = FItemClass;
				ItemType = Boxed as global::System.Type;
			}
			if (ItemType == null || !typeof(TCollectionItem).IsAssignableFrom(ItemType))
				ItemType = typeof(TCollectionItem);

			try
			{
				return (TCollectionItem)global::System.Activator.CreateInstance(
					ItemType, new object[] { null });
			}
			catch
			{
				return new TCollectionItem(null);
			}
		}

		internal void AddExistingItem(TCollectionItem Item)
		{
			if (Item == null)
				throw new global::System.ArgumentNullException(nameof(Item));
			if (FItems.Contains(Item))
				return;
			Item.Collection?.RemoveItem(Item);
			Item.SetCollectionDirect(this);
			if (Item.ID == 0)
				Item.SetIDDirect(GetItemID());
			FItems.Add(Item);
			TCollectionItem Temp = Item;
			Added(ref Temp);
			Notify(Item, TCollectionNotification.cnAdded);
			Update(Item);
		}

		internal void RemoveItem(TCollectionItem Item)
		{
			int Index = FItems.IndexOf(Item);
			if (Index < 0)
				return;
			Deleting(Item);
			FItems.RemoveAt(Index);
			Item.SetCollectionDirect(null);
			Notify(Item, TCollectionNotification.cnRemoved);
			Update(null);
		}

		internal int IndexOfItem(TCollectionItem Item) => FItems.IndexOf(Item);

		internal void SetItemIndex(TCollectionItem Item, int NewIndex)
		{
			int OldIndex = FItems.IndexOf(Item);
			if (OldIndex < 0)
				return;
			NewIndex = global::System.Math.Max(0,
				global::System.Math.Min(NewIndex, FItems.Count - 1));
			if (OldIndex == NewIndex)
				return;
			FItems.RemoveAt(OldIndex);
			FItems.Insert(NewIndex, Item);
			Update(Item);
		}

		protected virtual void Added(ref TCollectionItem Item) {}
		protected virtual void Deleting(TCollectionItem Item) {}
		protected virtual TClass GetItemClass() => FItemClass;
		protected virtual string GetItemName() => string.Empty;
		protected virtual TPersistent GetOwner() => null;
		protected virtual void Notify(TCollectionItem Item, TCollectionNotification Action) {}
		protected virtual void PropertyNameChanged() {}
		protected virtual void SetItemName(TCollectionItem Item) => Item?.InvokeSetItemName();
		protected virtual void Update(TCollectionItem Item) {}
		public TCollection() : this(null) { }


		public TCollection(TClass ItemClass)
		{
			FItemClass = ItemClass;
			FNextID = 0;
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				Clear();
				base.Destroy();
			}
		}

		public override void Assign(TPersistent Source)
		{
			if (Source is TCollection Other)
			{
				BeginUpdate();
				try
				{
					Clear();
					foreach (TCollectionItem SourceItem in Other.FItems)
					{
						TCollectionItem Item = Add();
						Item.Assign(SourceItem);
					}
				}
				finally
				{
					EndUpdate();
				}
				return;
			}
			base.Assign(Source);
		}

		public void BeginUpdate() => FUpdateCount++;

		public void Clear()
		{
			while (FItems.Count != 0)
			{
				TCollectionItem Item = FItems[FItems.Count - 1];
				FItems.RemoveAt(FItems.Count - 1);
				Item.SetCollectionDirect(null);
				Item.Destroy();
			}
			Update(null);
		}

		public void Delete(int Index)
		{
			TCollectionItem Item = FItems[Index];
			FItems.RemoveAt(Index);
			Item.SetCollectionDirect(null);
			Item.Destroy();
			Update(null);
		}

		public void EndUpdate()
		{
			if (FUpdateCount > 0)
				FUpdateCount--;
			if (FUpdateCount == 0)
				Update(null);
		}

		public TCollectionItem FindItemID(int ID)
		{
			foreach (TCollectionItem Item in FItems)
				if (Item.ID == ID)
					return Item;
			return null;
		}

		public TCollectionEnumerator GetEnumerator() => new TCollectionEnumerator(this);

		public int GetItemID()
		{
			return ++FNextID;
		}

		public TCollectionItem Insert(int Index)
		{
			TCollectionItem Item = CreateItemInstance();
			AddExistingItem(Item);
			SetItemIndex(Item, Index);
			return Item;
		}

		public TPersistent Owner() => GetOwner();

		public int Count => GetCount();
		public TClass ItemClass => GetItemClass();

		public TCollectionItem ReadPropertyItems(int Index) => GetItem(Index);
		public void WritePropertyItems(int Index, TCollectionItem Value) => SetItem(Index, Value);
	}	

	public class TCollectionEnumerator : TObject
	{
		private readonly TCollection FCollection;
		private int FIndex;

		private TCollectionItem GetCurrent()
		{
			if (FIndex < 0 || FIndex >= FCollection.Count)
				return null;
			return FCollection.ReadPropertyItems(FIndex);
		}
		public TCollectionEnumerator() : this(new TCollection(null)) { }


		public TCollectionEnumerator(TCollection ACollection)
		{
			FCollection = ACollection ?? throw new global::System.ArgumentNullException(nameof(ACollection));
			FIndex = -1;
		}

		public bool MoveNext()
		{
			FIndex++;
			return FIndex < FCollection.Count;
		}

		public TCollectionItem Current => GetCurrent();
	}	

	public class TOwnedCollection : TCollection
	{
		private TPersistent FOwner;

		protected override TPersistent GetOwner() => FOwner;
		public TOwnedCollection() : this(null, null) { }


		public TOwnedCollection(TPersistent AOwner, TClass ItemClass)
			: base(ItemClass)
		{
			FOwner = AOwner;
		}
	}	

	abstract public class TStrings : TPersistent
	{
		private char FDelimiter = ',';
		private char FQuoteChar = '"';
		private char FNameValueSeparator = '=';
		private string FLineBreak = sLineBreak;
		private bool FStrictDelimiter;
		private int FUpdateCount;

		private string QuoteDelimited(string Value)
		{
			Value ??= string.Empty;
			bool NeedQuote = !FStrictDelimiter &&
				Value.IndexOfAny(new[] { FDelimiter, FQuoteChar, ' ', '\t', '\r', '\n' }) >= 0;
			if (!NeedQuote)
				return Value;
			return FQuoteChar + Value.Replace(
				FQuoteChar.ToString(),
				new string(FQuoteChar, 2)) + FQuoteChar;
		}

		private string GetCommaText()
		{
			char OldDelimiter = FDelimiter;
			char OldQuote = FQuoteChar;
			bool OldStrict = FStrictDelimiter;
			try
			{
				FDelimiter = ',';
				FQuoteChar = '"';
				FStrictDelimiter = false;
				return GetDelimitedText();
			}
			finally
			{
				FDelimiter = OldDelimiter;
				FQuoteChar = OldQuote;
				FStrictDelimiter = OldStrict;
			}
		}

		private string GetDelimitedText()
		{
			var Parts = new global::System.Collections.Generic.List<string>(Count);
			for (int I = 0; I < Count; I++)
				Parts.Add(QuoteDelimited(Get(I)));
			return string.Join(FDelimiter.ToString(), Parts);
		}

		private string GetName(int Index)
		{
			string S = Get(Index) ?? string.Empty;
			int P = S.IndexOf(FNameValueSeparator);
			return P < 0 ? string.Empty : S.Substring(0, P);
		}

		private string GetValue(string Name)
		{
			int I = IndexOfName(Name);
			return I < 0 ? string.Empty : GetValueFromIndex(I);
		}

		private string GetValueFromIndex(int Index)
		{
			string S = Get(Index) ?? string.Empty;
			int P = S.IndexOf(FNameValueSeparator);
			return P < 0 ? string.Empty : S.Substring(P + 1);
		}

		private string GetTextStr()
		{
			if (Count == 0)
				return string.Empty;
			var B = new global::System.Text.StringBuilder();
			for (int I = 0; I < Count; I++)
			{
				B.Append(Get(I) ?? string.Empty);
				B.Append(FLineBreak ?? sLineBreak);
			}
			return B.ToString();
		}

		private void SetCommaText(string Value)
		{
			char OldDelimiter = FDelimiter;
			char OldQuote = FQuoteChar;
			bool OldStrict = FStrictDelimiter;
			try
			{
				FDelimiter = ',';
				FQuoteChar = '"';
				FStrictDelimiter = false;
				SetDelimitedText(Value);
			}
			finally
			{
				FDelimiter = OldDelimiter;
				FQuoteChar = OldQuote;
				FStrictDelimiter = OldStrict;
			}
		}

		private void SetDelimitedText(string Value)
		{
			BeginUpdate();
			try
			{
				Clear();
				if (string.IsNullOrEmpty(Value))
					return;

				int I = 0;
				while (I < Value.Length)
				{
					if (!FStrictDelimiter)
						while (I < Value.Length && char.IsWhiteSpace(Value[I]) && Value[I] != FDelimiter)
							I++;

					var B = new global::System.Text.StringBuilder();
					bool Quoted = I < Value.Length && Value[I] == FQuoteChar;
					if (Quoted)
					{
						I++;
						while (I < Value.Length)
						{
							if (Value[I] == FQuoteChar)
							{
								if (I + 1 < Value.Length && Value[I + 1] == FQuoteChar)
								{
									B.Append(FQuoteChar);
									I += 2;
									continue;
								}
								I++;
								break;
							}
							B.Append(Value[I++]);
						}
					}
					else
					{
						while (I < Value.Length && Value[I] != FDelimiter)
							B.Append(Value[I++]);
					}

					Add(B.ToString());
					if (I < Value.Length && Value[I] == FDelimiter)
						I++;
				}
			}
			finally
			{
				EndUpdate();
			}
		}

		private void SetValue(string Name, string Value)
		{
			int I = IndexOfName(Name);
			if (I < 0)
				Add((Name ?? string.Empty) + FNameValueSeparator + (Value ?? string.Empty));
			else
				Put(I, (Name ?? string.Empty) + FNameValueSeparator + (Value ?? string.Empty));
		}

		private void SetValueFromIndex(int Index, string Value)
		{
			string Name = GetName(Index);
			Put(Index, Name + FNameValueSeparator + (Value ?? string.Empty));
		}

		private void SetTextStr(string Value)
		{
			BeginUpdate();
			try
			{
				Clear();
				if (string.IsNullOrEmpty(Value))
					return;

				int Start = 0;
				for (int I = 0; I < Value.Length; I++)
				{
					if (Value[I] == '\r' || Value[I] == '\n')
					{
						Add(Value.Substring(Start, I - Start));
						if (Value[I] == '\r' && I + 1 < Value.Length && Value[I + 1] == '\n')
							I++;
						Start = I + 1;
					}
				}
				if (Start < Value.Length)
					Add(Value.Substring(Start));
			}
			finally
			{
				EndUpdate();
			}
		}

		protected virtual void DefineProperties(TFiler Filer) {}

		protected void Error(string Msg, int Data)
		{
			throw new global::System.ArgumentOutOfRangeException(nameof(Data), Data, Msg);
		}

		abstract protected string Get(int Index);
		protected virtual int GetCapacity() => Count;
		abstract protected int GetCount();
		protected virtual TObject GetObject(int Index) => null;
		protected virtual PChar GetText() => new PChar(GetTextStr());
		protected virtual void Put(int Index, string S) =>
			throw new global::System.NotSupportedException("This TStrings descendant does not support item assignment.");
		protected virtual void PutObject(int Index, TObject AObject) {}
		protected virtual void SetCapacity(int NewCapacity) {}
		protected virtual void SetUpdateState(bool Updating) {}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				Clear();
				base.Destroy();
			}
		}

		public virtual int Add(string S)
		{
			Insert(Count, S);
			return Count - 1;
		}

		public virtual int AddObject(string S, TObject AObject)
		{
			int Result = Add(S);
			PutObject(Result, AObject);
			return Result;
		}

		public virtual void AddStrings(TStrings Strings)
		{
			if (Strings == null)
				return;
			for (int I = 0; I < Strings.Count; I++)
				AddObject(Strings[I], Strings.ReadPropertyObjects(I));
		}

		public virtual void AddStrings(string[] Strings)
		{
			if (Strings == null)
				return;
			foreach (string S in Strings)
				Add(S);
		}

		public void Append(string S) => Add(S);

		public override void Assign(TPersistent Source)
		{
			if (Source is TStrings Strings)
			{
				BeginUpdate();
				try
				{
					Clear();
					AddStrings(Strings);
				}
				finally
				{
					EndUpdate();
				}
				return;
			}
			base.Assign(Source);
		}

		public void BeginUpdate()
		{
			if (FUpdateCount++ == 0)
				SetUpdateState(true);
		}

		abstract public void Clear();
		abstract public void Delete(int Index);

		public void EndUpdate()
		{
			if (FUpdateCount == 0)
				return;
			if (--FUpdateCount == 0)
				SetUpdateState(false);
		}

		public bool Equals(TStrings Strings)
		{
			if (Strings == null || Strings.Count != Count)
				return false;
			for (int I = 0; I < Count; I++)
				if (!string.Equals(Get(I), Strings[I], global::System.StringComparison.Ordinal))
					return false;
			return true;
		}

		public virtual void Exchange(int Index1, int Index2)
		{
			string S1 = Get(Index1);
			TObject O1 = GetObject(Index1);
			string S2 = Get(Index2);
			TObject O2 = GetObject(Index2);
			Put(Index1, S2);
			PutObject(Index1, O2);
			Put(Index2, S1);
			PutObject(Index2, O1);
		}

		public virtual int IndexOf(string S)
		{
			for (int I = 0; I < Count; I++)
				if (string.Equals(Get(I), S, global::System.StringComparison.Ordinal))
					return I;
			return -1;
		}

		public int IndexOfName(string Name)
		{
			for (int I = 0; I < Count; I++)
				if (string.Equals(GetName(I), Name, global::System.StringComparison.OrdinalIgnoreCase))
					return I;
			return -1;
		}

		public int IndexOfObject(TObject AObject)
		{
			for (int I = 0; I < Count; I++)
				if (global::System.Object.ReferenceEquals(GetObject(I), AObject))
					return I;
			return -1;
		}

		abstract public void Insert(int Index, string S);

		public virtual void InsertObject(int Index, string S, TObject AObject)
		{
			Insert(Index, S);
			PutObject(Index, AObject);
		}

		public virtual void LoadFromFile(string FileName) =>
			LoadFromFile(FileName, TEncoding.UTF8);

		public virtual void LoadFromFile(string FileName, TEncoding Encoding)
		{
			byte[] Bytes = global::System.IO.File.ReadAllBytes(FileName);
			Text = (Encoding ?? TEncoding.UTF8).GetString(Bytes);
		}

		public virtual void LoadFromStream(TStream Stream) =>
			LoadFromStream(Stream, TEncoding.UTF8);

		public virtual void LoadFromStream(TStream Stream, TEncoding Encoding)
		{
			if (Stream == null)
				throw new global::System.ArgumentNullException(nameof(Stream));
			long Remaining = Stream.Size - Stream.Position;
			if (Remaining < 0 || Remaining > int.MaxValue)
				throw new global::System.IO.IOException("Invalid stream size.");
			byte[] Bytes = new byte[(int)Remaining];
			if (Bytes.Length != 0)
				Stream.ReadBuffer(new UntypedPointer(Bytes), Bytes.Length);
			Text = (Encoding ?? TEncoding.UTF8).GetString(Bytes);
		}

		public virtual void Move(int CurIndex, int NewIndex)
		{
			if (CurIndex == NewIndex)
				return;
			string S = Get(CurIndex);
			TObject O = GetObject(CurIndex);
			Delete(CurIndex);
			InsertObject(NewIndex, S, O);
		}

		public virtual void SaveToFile(string FileName) =>
			SaveToFile(FileName, TEncoding.UTF8);

		public virtual void SaveToFile(string FileName, TEncoding Encoding)
		{
			byte[] Bytes = (Encoding ?? TEncoding.UTF8).GetBytes(Text ?? string.Empty);
			global::System.IO.File.WriteAllBytes(FileName, Bytes);
		}

		public virtual void SaveToStream(TStream Stream) =>
			SaveToStream(Stream, TEncoding.UTF8);

		public virtual void SaveToStream(TStream Stream, TEncoding Encoding)
		{
			if (Stream == null)
				throw new global::System.ArgumentNullException(nameof(Stream));
			byte[] Bytes = (Encoding ?? TEncoding.UTF8).GetBytes(Text ?? string.Empty);
			if (Bytes.Length != 0)
				Stream.WriteBuffer(new UntypedPointer(Bytes), Bytes.Length);
		}

		public virtual void SetText(PChar Text)
		{
			this.Text = Text.IsNull() ? string.Empty : Text.ToString();
		}

		public int Capacity
		{
			get => GetCapacity();
			set => SetCapacity(value);
		}
		public string CommaText
		{
			get => GetCommaText();
			set => SetCommaText(value);
		}
		public int Count => GetCount();
		public char Delimiter { get => FDelimiter; set => FDelimiter = value; }
		public string DelimitedText
		{
			get => GetDelimitedText();
			set => SetDelimitedText(value);
		}
		public string LineBreak { get => FLineBreak; set => FLineBreak = value ?? sLineBreak; }
		public string ReadPropertyNames(int Index) => GetName(Index);
		public char NameValueSeparator { get => FNameValueSeparator; set => FNameValueSeparator = value; }
		public TObject ReadPropertyObjects(int Index) => GetObject(Index);
		public void WritePropertyObjects(int Index, TObject AObject) => PutObject(Index, AObject);
		public char QuoteChar { get => FQuoteChar; set => FQuoteChar = value; }
		public bool StrictDelimiter { get => FStrictDelimiter; set => FStrictDelimiter = value; }
		public string ReadPropertyStrings(int Index) => Get(Index);
		public void WritePropertyStrings(int Index, string S) => Put(Index, S);
		public string this[int Index] { get => Get(Index); set => Put(Index, value); }
		public string Text { get => GetTextStr(); set => SetTextStr(value); }
		public string ReadPropertyValueFromIndex(int Index) => GetValueFromIndex(Index);
		public void WritePropertyValueFromIndex(int Index, string Value) => SetValueFromIndex(Index, Value);
		public string ReadPropertyValues(string Name) => GetValue(Name);
		public void WritePropertyValues(string Name, string Value) => SetValue(Name, Value);

		public TStrings() {}
	}	

	public class TStringList : TStrings
	{
		private readonly global::System.Collections.Generic.List<string> FStrings =
			new global::System.Collections.Generic.List<string>();
		private readonly global::System.Collections.Generic.List<TObject> FObjects =
			new global::System.Collections.Generic.List<TObject>();
		private bool FCaseSensitive;
		private TDuplicates FDuplicates;
		private bool FOwnsObjects;
		private bool FSorted;
		private TNotifyEvent FOnChange;
		private TNotifyEvent FOnChanging;

		protected virtual void Changed() => FOnChange?.Invoke(this);
		protected virtual void Changing() => FOnChanging?.Invoke(this);

		protected virtual int CompareStrings(string S1, string S2)
		{
			return string.Compare(
				S1 ?? string.Empty,
				S2 ?? string.Empty,
				FCaseSensitive ? global::System.StringComparison.Ordinal :
					global::System.StringComparison.OrdinalIgnoreCase);
		}

		protected override string Get(int Index) => FStrings[Index];
		protected override int GetCapacity() => FStrings.Capacity;
		protected override int GetCount() => FStrings.Count;
		protected override TObject GetObject(int Index) => FObjects[Index];

		protected override void Put(int Index, string S)
		{
			Changing();
			FStrings[Index] = S ?? string.Empty;
			Changed();
		}

		protected override void PutObject(int Index, TObject AObject)
		{
			if (FOwnsObjects && !global::System.Object.ReferenceEquals(FObjects[Index], AObject))
				FObjects[Index]?.Destroy();
			FObjects[Index] = AObject;
		}

		protected override void SetCapacity(int NewCapacity)
		{
			if (NewCapacity < Count)
				throw new global::System.ArgumentOutOfRangeException(nameof(NewCapacity));
			FStrings.Capacity = NewCapacity;
			FObjects.Capacity = NewCapacity;
		}

		protected override void SetUpdateState(bool Updating)
		{
			if (Updating)
				Changing();
			else
				Changed();
		}

		public TStringList()
		{
			FDuplicates = TDuplicates.dupIgnore;
		}

		public TStringList(bool OwnsObjects)
		{
			FOwnsObjects = OwnsObjects;
			FDuplicates = TDuplicates.dupIgnore;
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				Clear();
				base.Destroy();
			}
		}

		public override int Add(string S)
		{
			S ??= string.Empty;
			if (!FSorted)
			{
				Changing();
				FStrings.Add(S);
				FObjects.Add(null);
				Changed();
				return FStrings.Count - 1;
			}

			int Index = 0;
			bool Found = Find(S, ref Index);
			if (Found)
			{
				if (FDuplicates == TDuplicates.dupIgnore)
					return Index;
				if (FDuplicates == TDuplicates.dupError)
					throw new global::System.InvalidOperationException("Duplicate string.");
				while (Index < Count && CompareStrings(FStrings[Index], S) == 0)
					Index++;
			}
			Insert(Index, S);
			return Index;
		}

		public override void Clear()
		{
			Changing();
			if (FOwnsObjects)
				foreach (TObject Obj in FObjects)
					Obj?.Destroy();
			FStrings.Clear();
			FObjects.Clear();
			Changed();
		}

		public override void Delete(int Index)
		{
			Changing();
			if (FOwnsObjects)
				FObjects[Index]?.Destroy();
			FStrings.RemoveAt(Index);
			FObjects.RemoveAt(Index);
			Changed();
		}

		public override void Exchange(int Index1, int Index2)
		{
			Changing();
			(FStrings[Index1], FStrings[Index2]) = (FStrings[Index2], FStrings[Index1]);
			(FObjects[Index1], FObjects[Index2]) = (FObjects[Index2], FObjects[Index1]);
			Changed();
		}

		public virtual bool Find(string S, ref int Index)
		{
			int Low = 0;
			int High = FStrings.Count - 1;
			while (Low <= High)
			{
				int Mid = Low + ((High - Low) >> 1);
				int C = CompareStrings(FStrings[Mid], S);
				if (C < 0)
					Low = Mid + 1;
				else
				{
					High = Mid - 1;
					if (C == 0)
					{
						Index = Mid;
						return true;
					}
				}
			}
			Index = Low;
			return false;
		}

		public override int IndexOf(string S)
		{
			if (FSorted)
			{
				int Index = 0;
				return Find(S, ref Index) ? Index : -1;
			}
			for (int I = 0; I < FStrings.Count; I++)
				if (CompareStrings(FStrings[I], S) == 0)
					return I;
			return -1;
		}

		public override void Insert(int Index, string S)
		{
			if (FSorted)
				throw new global::System.InvalidOperationException("Cannot insert into a sorted TStringList.");
			Changing();
			FStrings.Insert(Index, S ?? string.Empty);
			FObjects.Insert(Index, null);
			Changed();
		}

		public override void InsertObject(int Index, string S, TObject AObject)
		{
			Insert(Index, S);
			FObjects[Index] = AObject;
		}

		public virtual void Sort()
		{
			CustomSort((List, I1, I2) => CompareStrings(List[I1], List[I2]));
		}

		public virtual void CustomSort(TStringListSortCompare Compare)
		{
			if (Compare == null)
				throw new global::System.ArgumentNullException(nameof(Compare));
			var Indices = new global::System.Collections.Generic.List<int>(FStrings.Count);
			for (int I = 0; I < FStrings.Count; I++)
				Indices.Add(I);
			Indices.Sort((A, B) => Compare(this, A, B));

			var NewStrings = new global::System.Collections.Generic.List<string>(FStrings.Count);
			var NewObjects = new global::System.Collections.Generic.List<TObject>(FObjects.Count);
			foreach (int I in Indices)
			{
				NewStrings.Add(FStrings[I]);
				NewObjects.Add(FObjects[I]);
			}
			FStrings.Clear();
			FStrings.AddRange(NewStrings);
			FObjects.Clear();
			FObjects.AddRange(NewObjects);
			Changed();
		}

		public bool CaseSensitive { get => FCaseSensitive; set { if (FCaseSensitive != value) { FCaseSensitive = value; if (FSorted) Sort(); } } }
		public TDuplicates Duplicates { get => FDuplicates; set => FDuplicates = value; }
		public bool OwnsObjects { get => FOwnsObjects; set => FOwnsObjects = value; }
		public bool Sorted { get => FSorted; set { if (FSorted != value) { FSorted = value; if (value) Sort(); } } }
		public TNotifyEvent OnChange { get => FOnChange; set => FOnChange = value; }
		public TNotifyEvent OnChanging { get => FOnChanging; set => FOnChanging = value; }
	}	

	abstract public class TStream : TObject
	{
		private long GetPosition() => Seek(0, TSeekOrigin.soCurrent);
		private void SetPosition(long Pos) => Seek(Pos, TSeekOrigin.soBeginning);
		private long GetSize()
		{
			long Old = Position;
			long Result = Seek(0, TSeekOrigin.soEnd);
			Position = Old;
			return Result;
		}
		private void SetSize64(long NewSize) => SetSize(NewSize);

		protected virtual void SetSize(int NewSize) => SetSize((long)NewSize);
		protected virtual void SetSize(long NewSize) =>
			throw new global::System.NotSupportedException("This stream does not support resizing.");

		abstract public int Read(UntypedPointer Buffer, int Count);
		abstract public int Write(UntypedPointer Buffer, int Count);

		public virtual int Seek(int Offset, ushort Origin)
		{
			return checked((int)Seek((long)Offset, (TSeekOrigin)Origin));
		}

		public virtual long Seek(long Offset, TSeekOrigin Origin)
		{
			throw new global::System.NotSupportedException("This stream does not support seeking.");
		}

		public void ReadBuffer(UntypedPointer Buffer, int Count)
		{
			int Total = 0;
			while (Total < Count)
			{
				byte[] Chunk = new byte[Count - Total];
				int N = Read(new UntypedPointer(Chunk), Chunk.Length);
				if (N <= 0)
					throw new global::System.IO.EndOfStreamException();
				for (int I = 0; I < N; I++)
					Buffer.Assign(Chunk[I], Total + I);
				Total += N;
			}
		}

		public void WriteBuffer(UntypedPointer Buffer, int Count)
		{
			int Total = 0;
			while (Total < Count)
			{
				int Remaining = Count - Total;
				byte[] Chunk = new byte[Remaining];
				for (int I = 0; I < Remaining; I++)
					Chunk[I] = Buffer.Read<byte>(Total + I);
				int N = Write(new UntypedPointer(Chunk), Remaining);
				if (N <= 0)
					throw new global::System.IO.IOException("Unable to write to stream.");
				Total += N;
			}
		}

		public long CopyFrom(TStream Source, long Count)
		{
			if (Source == null)
				throw new global::System.ArgumentNullException(nameof(Source));

			if (Count == 0)
			{
				Source.Position = 0;
				Count = Source.Size;
			}

			long Remaining = Count;
			long Result = 0;
			byte[] Buffer = new byte[8192];

			while (Remaining > 0)
			{
				int Wanted = (int)global::System.Math.Min(Buffer.Length, Remaining);
				int ReadCount = Source.Read(new UntypedPointer(Buffer), Wanted);
				if (ReadCount <= 0)
					break;
				int Written = Write(new UntypedPointer(Buffer), ReadCount);
				if (Written != ReadCount)
					throw new global::System.IO.IOException("Short stream write.");
				Result += Written;
				Remaining -= Written;
			}
			return Result;
		}

		public byte ReadByte()
		{
			byte[] Value = new byte[1];
			return Read(new UntypedPointer(Value), 1) == 1 ? Value[0] : (byte)0;
		}

		public void WriteByte(byte Value)
		{
			byte[] Data = new[] { Value };
			WriteBuffer(new UntypedPointer(Data), 1);
		}

		public long Position
		{
			get => GetPosition();
			set => SetPosition(value);
		}

		public long Size
		{
			get => GetSize();
			set => SetSize64(value);
		}

		public TStream() {}
	}	

	public class THandleStream : TStream
	{
		private uint FHandle;
		protected global::System.IO.Stream FManagedStream;
		public THandleStream() : this((uint)0) { }


		public THandleStream(uint AHandle)
		{
			FHandle = AHandle;
		}

		protected THandleStream(global::System.IO.Stream AStream, uint AHandle = 0)
		{
			FManagedStream = AStream ?? throw new global::System.ArgumentNullException(nameof(AStream));
			FHandle = AHandle;
		}

		protected global::System.IO.Stream ManagedStream
		{
			get
			{
				if (FManagedStream == null)
					throw new global::System.NotSupportedException(
						"Native THandleStream handles are not directly supported by the managed D2CSharp RTL.");
				return FManagedStream;
			}
		}

		public override int Read(UntypedPointer Buffer, int Count)
		{
			if (Count <= 0)
				return 0;
			byte[] Temp = new byte[Count];
			int N = ManagedStream.Read(Temp, 0, Count);
			if (N > 0)
				DelphiMemory.Move(new UntypedPointer(Temp), Buffer, N);
			return N;
		}

		public override int Write(UntypedPointer Buffer, int Count)
		{
			if (Count <= 0)
				return 0;
			byte[] Temp = new byte[Count];
			DelphiMemory.Move(Buffer, new UntypedPointer(Temp), Count);
			ManagedStream.Write(Temp, 0, Count);
			return Count;
		}

		public override long Seek(long Offset, TSeekOrigin Origin)
		{
			global::System.IO.SeekOrigin ManagedOrigin = Origin switch
			{
				TSeekOrigin.soBeginning => global::System.IO.SeekOrigin.Begin,
				TSeekOrigin.soCurrent => global::System.IO.SeekOrigin.Current,
				TSeekOrigin.soEnd => global::System.IO.SeekOrigin.End,
				_ => throw new global::System.ArgumentOutOfRangeException(nameof(Origin))
			};
			return ManagedStream.Seek(Offset, ManagedOrigin);
		}

		protected override void SetSize(long NewSize)
		{
			ManagedStream.SetLength(NewSize);
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				FManagedStream?.Dispose();
				FManagedStream = null;
				base.Destroy();
			}
		}

		public uint Handle => FHandle;
	}	

	public class TFileStream : THandleStream
	{
		private string FFileName = string.Empty;

		private static global::System.IO.FileStream OpenFile(string FileName, ushort Mode)
		{
			if (FileName == null)
				throw new global::System.ArgumentNullException(nameof(FileName));

			if (Mode == fmCreate)
				return new global::System.IO.FileStream(
					FileName,
					global::System.IO.FileMode.Create,
					global::System.IO.FileAccess.ReadWrite,
					global::System.IO.FileShare.Read);

			int AccessMode = Mode & 3;
			global::System.IO.FileAccess Access = AccessMode switch
			{
				0 => global::System.IO.FileAccess.Read,
				1 => global::System.IO.FileAccess.Write,
				_ => global::System.IO.FileAccess.ReadWrite
			};

			global::System.IO.FileShare Share = global::System.IO.FileShare.ReadWrite;
			int ShareMode = Mode & 0xF0;
			if (ShareMode == 0x10)
				Share = global::System.IO.FileShare.None;
			else if (ShareMode == 0x20)
				Share = global::System.IO.FileShare.Read;
			else if (ShareMode == 0x30)
				Share = global::System.IO.FileShare.Write;

			return new global::System.IO.FileStream(
				FileName,
				global::System.IO.FileMode.Open,
				Access,
				Share);
		}
		public TFileStream() : this((uint)0) { }


		public TFileStream(string FileName, ushort Mode)
			: base(OpenFile(FileName, Mode))
		{
			FFileName = FileName ?? string.Empty;
		}

		public TFileStream(string FileName, ushort Mode, uint Rights)
			: this(FileName, Mode)
		{
			// Rights is meaningful on POSIX Delphi targets. The managed FileStream
			// creation above uses the process' normal filesystem permissions.
		}

		public string FileName => FFileName;

		public TFileStream(uint AHandle) : base(AHandle) {}
	}	

	public class TCustomMemoryStream : TStream
	{
		protected byte[] FBuffer = global::System.Array.Empty<byte>();
		protected long FPosition;

		protected void SetPointer(Pointer Ptr, int Size)
		{
			if (Size < 0)
				throw new global::System.ArgumentOutOfRangeException(nameof(Size));
			FBuffer = new byte[Size];
			if (!Ptr.IsNull() && Size != 0)
				DelphiMemory.Move(Ptr, new UntypedPointer(FBuffer), Size);
			FPosition = 0;
		}

		public override int Read(UntypedPointer Buffer, int Count)
		{
			if (Count <= 0)
				return 0;
			int Actual = (int)global::System.Math.Min(Count, FBuffer.Length - FPosition);
			if (Actual <= 0)
				return 0;
			byte[] Temp = new byte[Actual];
			global::System.Array.Copy(FBuffer, (int)FPosition, Temp, 0, Actual);
			DelphiMemory.Move(new UntypedPointer(Temp), Buffer, Actual);
			FPosition += Actual;
			return Actual;
		}

		public override long Seek(long Offset, TSeekOrigin Origin)
		{
			long Base = Origin switch
			{
				TSeekOrigin.soBeginning => 0,
				TSeekOrigin.soCurrent => FPosition,
				TSeekOrigin.soEnd => FBuffer.Length,
				_ => throw new global::System.ArgumentOutOfRangeException(nameof(Origin))
			};
			long NewPosition = checked(Base + Offset);
			if (NewPosition < 0)
				throw new global::System.IO.IOException("Negative stream position.");
			FPosition = NewPosition;
			return FPosition;
		}

		public void SaveToStream(TStream Stream)
		{
			if (Stream == null)
				throw new global::System.ArgumentNullException(nameof(Stream));
			if (FBuffer.Length != 0)
				Stream.WriteBuffer(new UntypedPointer(FBuffer), FBuffer.Length);
		}

		public void SaveToFile(string FileName)
		{
			global::System.IO.File.WriteAllBytes(FileName, FBuffer);
		}

		public Pointer Memory => FBuffer.Length == 0 ? default : new UntypedPointer(FBuffer);

		public TCustomMemoryStream() {}

		public override int Write(UntypedPointer Buffer, int Count)
		{
			throw new global::System.NotSupportedException("TCustomMemoryStream is read-only; use TMemoryStream.");
		}
	}	

	public class TMemoryStream : TCustomMemoryStream
	{
		private int FCapacity;

		private void SetCapacity(int NewCapacity)
		{
			if (NewCapacity < 0 || NewCapacity < FBuffer.Length)
				throw new global::System.ArgumentOutOfRangeException(nameof(NewCapacity));
			FCapacity = NewCapacity;
		}

		protected virtual Pointer Realloc(ref int NewCapacity)
		{
			if (NewCapacity < FBuffer.Length)
				NewCapacity = FBuffer.Length;
			FCapacity = NewCapacity;
			return FBuffer.Length == 0 ? default : new UntypedPointer(FBuffer);
		}

		protected override void SetSize(long NewSize)
		{
			if (NewSize < 0 || NewSize > int.MaxValue)
				throw new global::System.ArgumentOutOfRangeException(nameof(NewSize));
			int Size = (int)NewSize;
			if (Size > FCapacity)
				FCapacity = Size;
			global::System.Array.Resize(ref FBuffer, Size);
			if (FPosition > NewSize)
				FPosition = NewSize;
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				FBuffer = global::System.Array.Empty<byte>();
				FCapacity = 0;
				FPosition = 0;
				base.Destroy();
			}
		}

		public void Clear()
		{
			FBuffer = global::System.Array.Empty<byte>();
			FCapacity = 0;
			FPosition = 0;
		}

		public void LoadFromStream(TStream Stream)
		{
			if (Stream == null)
				throw new global::System.ArgumentNullException(nameof(Stream));
			Stream.Position = 0;
			long Size = Stream.Size;
			if (Size < 0 || Size > int.MaxValue)
				throw new global::System.IO.IOException("Stream too large.");
			FBuffer = new byte[(int)Size];
			if (FBuffer.Length != 0)
				Stream.ReadBuffer(new UntypedPointer(FBuffer), FBuffer.Length);
			FCapacity = FBuffer.Length;
			FPosition = 0;
		}

		public void LoadFromFile(string FileName)
		{
			FBuffer = global::System.IO.File.ReadAllBytes(FileName);
			FCapacity = FBuffer.Length;
			FPosition = 0;
		}

		public override int Write(UntypedPointer Buffer, int Count)
		{
			if (Count <= 0)
				return 0;
			long EndPosition = checked(FPosition + Count);
			if (EndPosition > int.MaxValue)
				throw new global::System.IO.IOException("Stream too large.");
			if (EndPosition > FBuffer.Length)
				SetSize(EndPosition);

			byte[] Temp = new byte[Count];
			DelphiMemory.Move(Buffer, new UntypedPointer(Temp), Count);
			global::System.Array.Copy(Temp, 0, FBuffer, (int)FPosition, Count);
			FPosition = EndPosition;
			return Count;
		}

		public int Capacity
		{
			get => global::System.Math.Max(FCapacity, FBuffer.Length);
			set => SetCapacity(value);
		}

		public TMemoryStream() {}
	}	

	public class TStringStream : TStream
	{
		private string FDataString = string.Empty;
		private long FPosition;
		private TEncoding FEncoding;

		private byte[] GetBytes() => (FEncoding ?? TEncoding.UTF8).GetBytes(FDataString ?? string.Empty);

		protected override void SetSize(long NewSize)
		{
			if (NewSize < 0 || NewSize > int.MaxValue)
				throw new global::System.ArgumentOutOfRangeException(nameof(NewSize));
			byte[] Bytes = GetBytes();
			global::System.Array.Resize(ref Bytes, (int)NewSize);
			FDataString = (FEncoding ?? TEncoding.UTF8).GetString(Bytes);
			if (FPosition > NewSize)
				FPosition = NewSize;
		}

		public TStringStream(string AString)
		{
			FEncoding = TEncoding.UTF8;
			FDataString = AString ?? string.Empty;
		}

		public TStringStream(string AString, TEncoding AEncoding)
		{
			FEncoding = AEncoding ?? TEncoding.UTF8;
			FDataString = AString ?? string.Empty;
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				FDataString = string.Empty;
				base.Destroy();
			}
		}

		public override int Read(UntypedPointer Buffer, int Count)
		{
			byte[] Bytes = GetBytes();
			int Actual = (int)global::System.Math.Min(Count, Bytes.Length - FPosition);
			if (Actual <= 0)
				return 0;
			byte[] Temp = new byte[Actual];
			global::System.Array.Copy(Bytes, (int)FPosition, Temp, 0, Actual);
			DelphiMemory.Move(new UntypedPointer(Temp), Buffer, Actual);
			FPosition += Actual;
			return Actual;
		}

		public override int Write(UntypedPointer Buffer, int Count)
		{
			if (Count <= 0)
				return 0;
			byte[] Bytes = GetBytes();
			long End = checked(FPosition + Count);
			if (End > int.MaxValue)
				throw new global::System.IO.IOException("Stream too large.");
			if (End > Bytes.Length)
				global::System.Array.Resize(ref Bytes, (int)End);
			byte[] Temp = new byte[Count];
			DelphiMemory.Move(Buffer, new UntypedPointer(Temp), Count);
			global::System.Array.Copy(Temp, 0, Bytes, (int)FPosition, Count);
			FPosition = End;
			FDataString = (FEncoding ?? TEncoding.UTF8).GetString(Bytes);
			return Count;
		}

		public override long Seek(long Offset, TSeekOrigin Origin)
		{
			long Size = GetBytes().LongLength;
			long Base = Origin switch
			{
				TSeekOrigin.soBeginning => 0,
				TSeekOrigin.soCurrent => FPosition,
				TSeekOrigin.soEnd => Size,
				_ => throw new global::System.ArgumentOutOfRangeException(nameof(Origin))
			};
			long P = checked(Base + Offset);
			if (P < 0)
				throw new global::System.IO.IOException("Negative stream position.");
			FPosition = P;
			return P;
		}

		public string ReadString(int Count)
		{
			if (Count <= 0)
				return string.Empty;
			byte[] Bytes = new byte[Count];
			int Actual = Read(new UntypedPointer(Bytes), Count);
			return (FEncoding ?? TEncoding.UTF8).GetString(Bytes, 0, Actual);
		}

		public void WriteString(string AString)
		{
			byte[] Bytes = (FEncoding ?? TEncoding.UTF8).GetBytes(AString ?? string.Empty);
			if (Bytes.Length != 0)
				WriteBuffer(new UntypedPointer(Bytes), Bytes.Length);
		}

		public string DataString => FDataString;
		public TEncoding Encoding => FEncoding;

		public TStringStream() : this(string.Empty) {}
	}	

	public class TBytesStream : TMemoryStream
	{
		private byte[] FBytes = global::System.Array.Empty<byte>();

		protected override Pointer Realloc(ref int NewCapacity)
		{
			Pointer Result = base.Realloc(ref NewCapacity);
			FBytes = ToArray();
			return Result;
		}

		private byte[] ToArray()
		{
			long Old = Position;
			Position = 0;
			byte[] Result = new byte[checked((int)Size)];
			if (Result.Length != 0)
				ReadBuffer(new UntypedPointer(Result), Result.Length);
			Position = Old;
			return Result;
		}
		public TBytesStream() : this(global::System.Array.Empty<byte>()) { }


		public TBytesStream(byte[] ABytes)
		{
			FBytes = ABytes == null ? global::System.Array.Empty<byte>() : (byte[])ABytes.Clone();
			if (FBytes.Length != 0)
				WriteBuffer(new UntypedPointer(FBytes), FBytes.Length);
			Position = 0;
		}

		public byte[] Bytes
		{
			get
			{
				FBytes = ToArray();
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
			throw new global::System.NotSupportedException("TResourceStream.Write is not implemented by the managed D2CSharp RTL.");
		}

		public TResourceStream() {}
	}	

	public abstract class TThread : TObject
	{
		private readonly global::System.Threading.Thread FThread;
		private bool FStarted;
		private volatile bool FFinished;
		private volatile bool FTerminated;

		// Keep default construction suspended until the caller explicitly starts the thread.
		public TThread() : this(true)
		{
		}

		public TThread(bool CreateSuspended)
		{
			FThread = new global::System.Threading.Thread(ThreadMain);
			FStarted = false;
			FFinished = false;
			FTerminated = false;

			if (!CreateSuspended)
				Start();
		}

		private void ThreadMain()
		{
			try
			{
				Execute();
			}
			finally
			{
				FFinished = true;
			}
		}

		protected abstract void Execute();

		public void Start()
		{
			if (FStarted)
				return;

			FStarted = true;
			FThread.Start();
		}

		public void Resume()
		{
			Start();
		}

		public void Suspend()
		{
			// There is no safe modern .NET equivalent for TThread.Suspend.
			throw new global::System.PlatformNotSupportedException(
				"TThread.Suspend is not supported by the D2CSharp RTL.");
		}

		public void Terminate()
		{
			FTerminated = true;
		}

		public uint WaitFor()
		{
			if (!FStarted)
				return 0;

			if (global::System.Threading.Thread.CurrentThread != FThread)
				FThread.Join();

			return 0;
		}

		public bool Finished
		{
			get { return FFinished; }
		}

		public bool FreeOnTerminate { get; set; }

		public bool Terminated
		{
			get { return FTerminated; }
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				Terminate();

				if (FStarted &&
					!FFinished &&
					global::System.Threading.Thread.CurrentThread != FThread)
				{
					FThread.Join();
				}

				base.Destroy();
			}
		}
	}	

	public class TThreadList : TObject
	{
		private readonly object FLock = new object();
		private TList FList;
		private TDuplicates FDuplicates;

		public TThreadList()
		{
			FList = new TList();
			FDuplicates = TDuplicates.dupIgnore;
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				FList?.Destroy();
				FList = null;
				base.Destroy();
			}
		}

		public void Add(Pointer Item)
		{
			lock (FLock)
			{
				int Existing = FList.IndexOf(Item);
				if (Existing >= 0 && FDuplicates == TDuplicates.dupIgnore)
					return;
				if (Existing >= 0 && FDuplicates == TDuplicates.dupError)
					throw new global::System.InvalidOperationException("Duplicate item.");
				FList.Add(Item);
			}
		}

		public void Clear()
		{
			lock (FLock)
				FList.Clear();
		}

		public TList LockList()
		{
			global::System.Threading.Monitor.Enter(FLock);
			return FList;
		}

		public void Remove(Pointer Item)
		{
			lock (FLock)
				FList.Remove(Item);
		}

		public void UnlockList() => global::System.Threading.Monitor.Exit(FLock);

		public TDuplicates Duplicates
		{
			get => FDuplicates;
			set => FDuplicates = value;
		}
	}	

	public class TStringsEnumerator : TObject
	{
		private readonly TStrings FStrings;
		private int FIndex;

		private string GetCurrent()
		{
			if (FIndex < 0 || FIndex >= FStrings.Count)
				return string.Empty;
			return FStrings[FIndex];
		}
		public TStringsEnumerator() : this(new TStringList()) { }


		public TStringsEnumerator(TStrings AStrings)
		{
			FStrings = AStrings ?? throw new global::System.ArgumentNullException(nameof(AStrings));
			FIndex = -1;
		}

		public bool MoveNext()
		{
			FIndex++;
			return FIndex < FStrings.Count;
		}

		public string Current => GetCurrent();
	}	

	public class TStringReader : TObject
	{
		private string FData = string.Empty;
		private int FPosition;
		public TStringReader() : this(string.Empty) { }


		public TStringReader(string AString)
		{
			FData = AString ?? string.Empty;
		}

		public int Peek() => FPosition >= FData.Length ? -1 : FData[FPosition];

		public int Read() => FPosition >= FData.Length ? -1 : FData[FPosition++];

		public int Read(ref char[] Buffer, int Index, int Count)
		{
			if (Buffer == null)
				throw new global::System.ArgumentNullException(nameof(Buffer));
			if (Index < 0 || Count < 0 || Index + Count > Buffer.Length)
				throw new global::System.ArgumentOutOfRangeException();

			int Actual = global::System.Math.Min(Count, FData.Length - FPosition);
			FData.CopyTo(FPosition, Buffer, Index, Actual);
			FPosition += Actual;
			return Actual;
		}

		public string ReadLine()
		{
			if (FPosition >= FData.Length)
				return null;

			int Start = FPosition;
			while (FPosition < FData.Length &&
				   FData[FPosition] != '\r' &&
				   FData[FPosition] != '\n')
				FPosition++;

			string Result = FData.Substring(Start, FPosition - Start);

			if (FPosition < FData.Length && FData[FPosition] == '\r')
				FPosition++;
			if (FPosition < FData.Length && FData[FPosition] == '\n')
				FPosition++;

			return Result;
		}

		public string ReadToEnd()
		{
			if (FPosition >= FData.Length)
				return string.Empty;

			string Result = FData.Substring(FPosition);
			FPosition = FData.Length;
			return Result;
		}
	}	

	public class TStringWriter : TObject
	{
		private TStringBuilder FBuilder;

		public TStringWriter()
		{
			FBuilder = new TStringBuilder();
		}

		public TStringWriter(TStringBuilder ABuilder)
		{
			FBuilder = ABuilder ?? throw new global::System.ArgumentNullException(nameof(ABuilder));
		}

		public void Write(string Value) => FBuilder.Append(Value ?? string.Empty);
		public void Write(char Value) => FBuilder.Append(Value);
		public void WriteLine() => FBuilder.AppendLine();
		public void WriteLine(string Value) => FBuilder.AppendLine(Value ?? string.Empty);
		public override string ToString() => FBuilder?.ToString() ?? string.Empty;
		public TStringBuilder Builder => FBuilder;
	}	

	public class TStreamReader : TObject
	{
		private TStream FStream;
		private TEncoding FEncoding;
		private bool FOwnsStream;
		private TStringReader FReader;

		private bool GetEndOfStream() => FReader == null || FReader.Peek() < 0;

		private void InitializeReader()
		{
			if (FStream == null)
				return;
			long Remaining = FStream.Size - FStream.Position;
			if (Remaining < 0 || Remaining > int.MaxValue)
				throw new global::System.IO.IOException("Invalid stream size.");
			byte[] Bytes = new byte[(int)Remaining];
			if (Bytes.Length != 0)
				FStream.ReadBuffer(new UntypedPointer(Bytes), Bytes.Length);
			FReader = new TStringReader((FEncoding ?? TEncoding.UTF8).GetString(Bytes));
		}

		public TStreamReader(TStream Stream)
			: this(Stream, TEncoding.UTF8, true, 1024)
		{
		}

		public TStreamReader(TStream Stream, TEncoding Encoding, bool DetectBOM = true, int BufferSize = 1024)
		{
			FStream = Stream ?? throw new global::System.ArgumentNullException(nameof(Stream));
			FEncoding = Encoding ?? TEncoding.UTF8;
			FOwnsStream = false;
			InitializeReader();
		}

		public TStreamReader(string Filename)
			: this(Filename, TEncoding.UTF8, true, 1024)
		{
		}

		public TStreamReader(string Filename, TEncoding Encoding, bool DetectBOM = true, int BufferSize = 1024)
		{
			FStream = new TFileStream(Filename, fmOpenRead);
			FEncoding = Encoding ?? TEncoding.UTF8;
			FOwnsStream = true;
			InitializeReader();
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				Close();
				base.Destroy();
			}
		}

		public void Close()
		{
			if (FOwnsStream)
				FStream?.Destroy();
			FStream = null;
			FReader = null;
		}

		public int Peek() => FReader?.Peek() ?? -1;
		public int Read() => FReader?.Read() ?? -1;

		public int Read(ref char[] Buffer, int Index, int Count)
		{
			return FReader == null ? 0 : FReader.Read(ref Buffer, Index, Count);
		}

		public int ReadBlock(ref char[] Buffer, int Index, int Count)
		{
			int Total = 0;
			while (Total < Count)
			{
				int N = Read(ref Buffer, Index + Total, Count - Total);
				if (N == 0)
					break;
				Total += N;
			}
			return Total;
		}

		public string ReadLine() => FReader?.ReadLine();
		public string ReadToEnd() => FReader?.ReadToEnd() ?? string.Empty;
		public TStream BaseStream => FStream;
		public TEncoding CurrentEncoding => FEncoding;
		public bool EndOfStream => GetEndOfStream();

		public TStreamReader() {}
	}	

	public class TStreamWriter : TObject
	{
		private TStream FStream;
		private TEncoding FEncoding;
		private bool FOwnsStream;
		private bool FAutoFlush;
		private string FNewLine = sLineBreak;

		public TStreamWriter(TStream Stream)
			: this(Stream, TEncoding.UTF8, 1024)
		{
		}

		public TStreamWriter(TStream Stream, TEncoding Encoding, int BufferSize = 1024)
		{
			FStream = Stream ?? throw new global::System.ArgumentNullException(nameof(Stream));
			FEncoding = Encoding ?? TEncoding.UTF8;
			FOwnsStream = false;
		}

		public TStreamWriter(string Filename, bool Append = false)
			: this(Filename, Append, TEncoding.UTF8, 1024)
		{
		}

		public TStreamWriter(string Filename, bool Append, TEncoding Encoding, int BufferSize = 1024)
		{
			FEncoding = Encoding ?? TEncoding.UTF8;
			FStream = new TFileStream(
				Filename,
				(ushort)(Append ? fmOpenReadWrite : fmCreate));
			FOwnsStream = true;
			if (Append)
				FStream.Position = FStream.Size;
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				Close();
				base.Destroy();
			}
		}

		public void Close()
		{
			Flush();
			if (FOwnsStream)
				FStream?.Destroy();
			FStream = null;
		}

		public void Flush()
		{
			// TStream has no generic Flush method. Managed TFileStream writes are
			// immediately forwarded to FileStream.Write; closing also flushes.
		}

		private void WriteBytes(byte[] Bytes)
		{
			if (Bytes != null && Bytes.Length != 0)
				FStream.WriteBuffer(new UntypedPointer(Bytes), Bytes.Length);
			if (FAutoFlush)
				Flush();
		}

		public void Write(string Value) =>
			WriteBytes((FEncoding ?? TEncoding.UTF8).GetBytes(Value ?? string.Empty));

		public void Write(char Value) =>
			WriteBytes((FEncoding ?? TEncoding.UTF8).GetBytes(new[] { Value }));

		public void WriteLine() => Write(FNewLine ?? sLineBreak);

		public void WriteLine(string Value)
		{
			Write(Value ?? string.Empty);
			WriteLine();
		}

		public bool AutoFlush
		{
			get => FAutoFlush;
			set
			{
				FAutoFlush = value;
				if (value)
					Flush();
			}
		}

		public TStream BaseStream => FStream;
		public TEncoding Encoding => FEncoding;
		public string NewLine { get => FNewLine; set => FNewLine = value ?? sLineBreak; }

		public TStreamWriter() {}
	}	

	public class TRecall : TObject
	{
		private TPersistent FStorage;
		private TPersistent FReference;
		public TRecall() { }


		public TRecall(TPersistent AStorage, TPersistent AReference)
		{
			FStorage = AStorage ?? throw new global::System.ArgumentNullException(nameof(AStorage));
			FReference = AReference ?? throw new global::System.ArgumentNullException(nameof(AReference));
			Store();
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				if (FStorage != null && FReference != null)
					FReference.Assign(FStorage);
				FStorage = null;
				FReference = null;
				base.Destroy();
			}
		}

		public void Forget()
		{
			FStorage = null;
			FReference = null;
		}

		public void Store()
		{
			if (FStorage == null || FReference == null)
				return;
			FStorage.Assign(FReference);
		}

		public TPersistent Reference => FReference;
	}	

	public class TParser : TObject
	{
		private TStream FStream;
		private TToken FToken;

/* TParser */
		public TParser() : this(null) { }

		public TParser(TStream Stream)
		{
			;
		}
		public void CheckToken(TToken T)
		{
			throw new global::System.NotSupportedException("TParser.CheckToken is not implemented by the managed D2CSharp RTL.");
		}
		public void CheckTokenSymbol(string S)
		{
			throw new global::System.NotSupportedException("TParser.CheckTokenSymbol is not implemented by the managed D2CSharp RTL.");
		}
		public void Error(string Ident)
		{
			throw new global::System.NotSupportedException("TParser.Error is not implemented by the managed D2CSharp RTL.");
		}
		public void ErrorFmt(string Ident, params TVarRec[] Args)
		{
			throw new global::System.NotSupportedException("TParser.ErrorFmt is not implemented by the managed D2CSharp RTL.");
		}
		public TToken NextToken()
		{
			throw new global::System.NotSupportedException("TParser.NextToken is not implemented by the managed D2CSharp RTL.");
		}
		public int SourceLine()
		{
			throw new global::System.NotSupportedException("TParser.SourceLine is not implemented by the managed D2CSharp RTL.");
		}
		public string TokenComponentIdent()
		{
			throw new global::System.NotSupportedException("TParser.TokenComponentIdent is not implemented by the managed D2CSharp RTL.");
		}
		public double TokenFloat()
		{
			throw new global::System.NotSupportedException("TParser.TokenFloat is not implemented by the managed D2CSharp RTL.");
		}
		public long TokenInt()
		{
			throw new global::System.NotSupportedException("TParser.TokenInt is not implemented by the managed D2CSharp RTL.");
		}
		public string TokenString()
		{
			throw new global::System.NotSupportedException("TParser.TokenString is not implemented by the managed D2CSharp RTL.");
		}
		public bool TokenSymbolIs(string S)
		{
			throw new global::System.NotSupportedException("TParser.TokenSymbolIs is not implemented by the managed D2CSharp RTL.");
		}
		public string TokenWideString()
		{
			throw new global::System.NotSupportedException("TParser.TokenWideString is not implemented by the managed D2CSharp RTL.");
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

		protected virtual void AssignClient(TObject AClient) => FClient = AClient;
		protected virtual bool IsGroupIndexLinked() => false;
		protected virtual bool IsOnExecuteLinked() => FAction != null;
		protected virtual void SetGroupIndex(int Value) {}
		protected virtual void SetOnExecute(TNotifyEvent Value)
		{
			if (FAction != null)
				FAction.OnExecute = Value;
		}
		public TBasicActionLink() : this(null) { }


		public TBasicActionLink(TObject AClient)
		{
			AssignClient(AClient);
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				FAction = null;
				FClient = null;
				base.Destroy();
			}
		}

		public virtual void Assign(TObject Source)
		{
			if (Source is TBasicActionLink Other)
			{
				Action = Other.Action;
				return;
			}
			if (Source is TBasicAction BasicAction)
			{
				Action = BasicAction;
				return;
			}
			throw new global::System.ArgumentException("Unsupported action-link source.", nameof(Source));
		}

		public virtual bool Execute(TObject AClient = default)
		{
			return FAction != null && FAction.Execute();
		}

		public virtual bool Update()
		{
			return FAction != null && FAction.Update();
		}

		public TBasicAction Action
		{
			get => FAction;
			set => FAction = value;
		}

		public TObject Client => FClient;
	}	

	abstract public class TTextReader : TObject
	{
		abstract public int Peek();
		abstract public int Read();

		public virtual int Read(ref char[] Buffer, int Index, int Count)
		{
			if (Buffer == null)
				throw new global::System.ArgumentNullException(nameof(Buffer));
			if (Index < 0 || Count < 0 || Index + Count > Buffer.Length)
				throw new global::System.ArgumentOutOfRangeException();

			int N = 0;
			while (N < Count)
			{
				int C = Read();
				if (C < 0)
					break;
				Buffer[Index + N] = (char)C;
				N++;
			}
			return N;
		}

		public virtual int ReadBlock(ref char[] Buffer, int Index, int Count)
		{
			int Total = 0;
			while (Total < Count)
			{
				int N = Read(ref Buffer, Index + Total, Count - Total);
				if (N == 0)
					break;
				Total += N;
			}
			return Total;
		}

		public virtual string ReadLine()
		{
			if (Peek() < 0)
				return null;
			var B = new global::System.Text.StringBuilder();
			while (true)
			{
				int C = Read();
				if (C < 0)
					break;
				if (C == '\r')
				{
					if (Peek() == '\n')
						Read();
					break;
				}
				if (C == '\n')
					break;
				B.Append((char)C);
			}
			return B.ToString();
		}

		public virtual string ReadToEnd()
		{
			var B = new global::System.Text.StringBuilder();
			int C;
			while ((C = Read()) >= 0)
				B.Append((char)C);
			return B.ToString();
		}

		public TTextReaderEnumerator GetEnumerator() => new TTextReaderEnumerator(this);

		public TTextReader() {}
	}	

	public class TTextReaderEnumerator : TObject
	{
		private readonly TTextReader FReader;
		private string FCurrent = string.Empty;
		public TTextReaderEnumerator() { }


		public TTextReaderEnumerator(TTextReader AReader)
		{
			FReader = AReader ?? throw new global::System.ArgumentNullException(nameof(AReader));
		}

		public bool MoveNext()
		{
			string Line = FReader.ReadLine();
			if (Line == null)
				return false;
			FCurrent = Line;
			return true;
		}

		public string Current => FCurrent;
	}	

	public class TTextWriter : TObject
	{
		private string FNewLine = sLineBreak;

		public TTextWriter() {}

		public virtual void Close() => Flush();
		public virtual void Flush() {}

		public virtual void Write(bool Value) => Write(Value.ToString());
		public virtual void Write(char Value) => Write(Value.ToString());
		public virtual void Write(int Value) => Write(Value.ToString(global::System.Globalization.CultureInfo.InvariantCulture));
		public virtual void Write(long Value) => Write(Value.ToString(global::System.Globalization.CultureInfo.InvariantCulture));
		public virtual void Write(float Value) => Write(Value.ToString(global::System.Globalization.CultureInfo.InvariantCulture));
		public virtual void Write(double Value) => Write(Value.ToString(global::System.Globalization.CultureInfo.InvariantCulture));

		public virtual void Write(string Value)
		{
			throw new global::System.NotSupportedException(
				"This TTextWriter descendant must override Write(string).");
		}

		public virtual void WriteLine()
		{
			Write(FNewLine ?? sLineBreak);
		}

		public virtual void WriteLine(string Value)
		{
			Write(Value ?? string.Empty);
			WriteLine();
		}

		public string NewLine
		{
			get => FNewLine;
			set => FNewLine = value ?? sLineBreak;
		}
	}	

	public class TBinaryReader : TObject
	{
		private TStream FStream;
		private TEncoding FEncoding;
		private bool FOwnsStream;

		public TBinaryReader(TStream Stream, TEncoding AEncoding = default, bool AOwnsStream = false)
		{
			FStream = Stream ?? throw new global::System.ArgumentNullException(nameof(Stream));
			FEncoding = AEncoding ?? TEncoding.UTF8;
			FOwnsStream = AOwnsStream;
		}

		public TBinaryReader(string Filename, TEncoding Encoding = default)
			: this(new TFileStream(Filename, fmOpenRead), Encoding, true)
		{
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				Close();
				base.Destroy();
			}
		}

		private byte[] ReadExact(int Count)
		{
			if (Count < 0)
				throw new global::System.ArgumentOutOfRangeException(nameof(Count));
			byte[] Result = new byte[Count];
			if (Count != 0)
				FStream.ReadBuffer(new UntypedPointer(Result), Count);
			return Result;
		}

		public virtual void Close()
		{
			if (FOwnsStream)
				FStream?.Destroy();
			FStream = null;
		}

		public virtual bool ReadBoolean() => ReadByte() != 0;
		public virtual byte ReadByte() => FStream.ReadByte();
		public virtual byte[] ReadBytes(int Count)
		{
			if (Count < 0)
				throw new global::System.ArgumentOutOfRangeException(nameof(Count));
			byte[] Result = new byte[Count];
			int ReadCount = FStream.Read(new UntypedPointer(Result), Count);
			if (ReadCount == Count)
				return Result;
			global::System.Array.Resize(ref Result, global::System.Math.Max(0, ReadCount));
			return Result;
		}

		public virtual char ReadChar()
		{
			byte[] Buffer = ReadBytes(FEncoding.GetMaxByteCount(1));
			string S = FEncoding.GetString(Buffer);
			return S.Length == 0 ? '\0' : S[0];
		}

		public virtual char[] ReadChars(int Count)
		{
			if (Count < 0)
				throw new global::System.ArgumentOutOfRangeException(nameof(Count));
			var Result = new global::System.Collections.Generic.List<char>(Count);
			for (int I = 0; I < Count; I++)
			{
				if (FStream.Position >= FStream.Size)
					break;
				Result.Add(ReadChar());
			}
			return Result.ToArray();
		}

		public virtual double ReadDouble() => global::System.BitConverter.ToDouble(ReadExact(8), 0);
		public virtual int ReadInteger() => global::System.BitConverter.ToInt32(ReadExact(4), 0);
		public virtual long ReadInt64() => global::System.BitConverter.ToInt64(ReadExact(8), 0);
		public virtual sbyte ReadShortInt() => unchecked((sbyte)ReadByte());
		public virtual float ReadSingle() => global::System.BitConverter.ToSingle(ReadExact(4), 0);
		public virtual short ReadSmallInt() => global::System.BitConverter.ToInt16(ReadExact(2), 0);

		public virtual string ReadString()
		{
			int Length = ReadInteger();
			if (Length < 0)
				throw new global::System.IO.InvalidDataException("Negative string length.");
			return FEncoding.GetString(ReadExact(Length));
		}

		public virtual ulong ReadUInt64() => global::System.BitConverter.ToUInt64(ReadExact(8), 0);
		public virtual ushort ReadWord() => global::System.BitConverter.ToUInt16(ReadExact(2), 0);
		public virtual uint ReadCardinal() => global::System.BitConverter.ToUInt32(ReadExact(4), 0);

		public TStream BaseStream => FStream;

		public TBinaryReader() {}
	}	

	public class TBinaryWriter : TObject
	{
		private TStream FStream;
		private TEncoding FEncoding;
		private bool FOwnsStream;

		public TBinaryWriter()
		{
		}

		public TBinaryWriter(TStream Stream)
			: this(Stream, TEncoding.UTF8, false)
		{
		}

		public TBinaryWriter(TStream Stream, TEncoding Encoding)
			: this(Stream, Encoding, false)
		{
		}

		public TBinaryWriter(TStream Stream, TEncoding Encoding, bool AOwnsStream)
		{
			FStream = Stream ?? throw new global::System.ArgumentNullException(nameof(Stream));
			FEncoding = Encoding ?? TEncoding.UTF8;
			FOwnsStream = AOwnsStream;
		}

		public TBinaryWriter(string Filename, bool Append = false)
			: this(Filename, Append, TEncoding.UTF8)
		{
		}

		public TBinaryWriter(string Filename, bool Append, TEncoding Encoding)
		{
			FEncoding = Encoding ?? TEncoding.UTF8;
			FStream = new TFileStream(
				Filename,
				(ushort)(Append ? fmOpenReadWrite : fmCreate));
			FOwnsStream = true;
			if (Append)
				FStream.Position = FStream.Size;
		}

		public override void Destroy()
		{
			if (!FDisposed)
			{
				Close();
				base.Destroy();
			}
		}

		private void WriteBytes(byte[] Bytes)
		{
			if (Bytes != null && Bytes.Length != 0)
				FStream.WriteBuffer(new UntypedPointer(Bytes), Bytes.Length);
		}

		public virtual void Close()
		{
			Flush();
			if (FOwnsStream)
				FStream?.Destroy();
			FStream = null;
		}

		public virtual void Flush()
		{
		}

		public virtual void Seek(int Offset, TSeekOrigin Origin)
		{
			FStream.Seek(Offset, Origin);
		}

		public virtual void Write(byte Value) => FStream.WriteByte(Value);
		public virtual void Write(bool Value) => Write((byte)(Value ? 1 : 0));
		public virtual void Write(char Value) => WriteBytes(FEncoding.GetBytes(new[] { Value }));
		public virtual void Write(char[] Value) => WriteBytes(FEncoding.GetBytes(Value ?? global::System.Array.Empty<char>()));
		public virtual void Write(byte[] Value) => WriteBytes(Value);
		public virtual void Write(double Value) => WriteBytes(global::System.BitConverter.GetBytes(Value));
		public virtual void Write(int Value) => WriteBytes(global::System.BitConverter.GetBytes(Value));
		public virtual void Write(short Value) => WriteBytes(global::System.BitConverter.GetBytes(Value));
		public virtual void Write(sbyte Value) => Write(unchecked((byte)Value));
		public virtual void Write(ushort Value) => WriteBytes(global::System.BitConverter.GetBytes(Value));
		public virtual void Write(uint Value) => WriteBytes(global::System.BitConverter.GetBytes(Value));
		public virtual void Write(long Value) => WriteBytes(global::System.BitConverter.GetBytes(Value));
		public virtual void Write(float Value) => WriteBytes(global::System.BitConverter.GetBytes(Value));

		public virtual void Write(string Value)
		{
			byte[] Bytes = FEncoding.GetBytes(Value ?? string.Empty);
			Write(Bytes.Length);
			WriteBytes(Bytes);
		}

		public virtual void Write(ulong Value) => WriteBytes(global::System.BitConverter.GetBytes(Value));

		public virtual void Write(char[] Value, int Index, int Count) =>
			WriteBytes(FEncoding.GetBytes(Value ?? global::System.Array.Empty<char>(), Index, Count));

		public virtual void Write(byte[] Value, int Index, int Count)
		{
			if (Value == null)
				throw new global::System.ArgumentNullException(nameof(Value));
			if (Index < 0 || Count < 0 || Index + Count > Value.Length)
				throw new global::System.ArgumentOutOfRangeException();
			byte[] Part = new byte[Count];
			global::System.Array.Copy(Value, Index, Part, 0, Count);
			WriteBytes(Part);
		}

		public TStream BaseStream => FStream;
	}	

	public class TFiler : TObject
	{
		private TComponent FRoot;
		protected void DefineProperty(string Name, TReaderProc ReadData, TWriterProc WriteData, bool HasData)
		{
			throw new global::System.NotSupportedException("TFiler.DefineProperty is not implemented by the managed D2CSharp RTL.");
		}
		protected void DefineBinaryProperty(string Name, TStreamProc ReadData, TStreamProc WriteData, bool HasData)
		{
			throw new global::System.NotSupportedException("TFiler.DefineBinaryProperty is not implemented by the managed D2CSharp RTL.");
		}

/* TFiler */
		public TFiler() : this(null, 0) { }

		public TFiler(TStream Stream, int BufSize)
		{
			;
		}
		public virtual void DefineProperties(TPersistent Instance)
		{
			throw new global::System.NotSupportedException("TFiler.DefineProperties is not implemented by the managed D2CSharp RTL.");
		}
		public virtual void FlushBuffer()
		{
			throw new global::System.NotSupportedException("TFiler.FlushBuffer is not implemented by the managed D2CSharp RTL.");
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
		public TReader() : this(null, 0) { }

		public TReader(TStream Stream, int BufSize)
		:		base(Stream, BufSize)
		{
			//# base.Create(Stream, BufSize);
		}
		public void BeginReferences()
		{
			throw new global::System.NotSupportedException("TReader.BeginReferences is not implemented by the managed D2CSharp RTL.");
		}
		public void CheckValue(byte Value)
		{
			throw new global::System.NotSupportedException("TReader.CheckValue is not implemented by the managed D2CSharp RTL.");
		}
		public override void DefineProperties(TPersistent Instance)
		{
			throw new global::System.NotSupportedException("TReader.DefineProperties is not implemented by the managed D2CSharp RTL.");
		}
		public void EndReferences()
		{
			throw new global::System.NotSupportedException("TReader.EndReferences is not implemented by the managed D2CSharp RTL.");
		}
		public void FixupReferences()
		{
			throw new global::System.NotSupportedException("TReader.FixupReferences is not implemented by the managed D2CSharp RTL.");
		}
		public bool ReadBoolean()
		{
			throw new global::System.NotSupportedException("TReader.ReadBoolean is not implemented by the managed D2CSharp RTL.");
		}
		public char ReadChar()
		{
			throw new global::System.NotSupportedException("TReader.ReadChar is not implemented by the managed D2CSharp RTL.");
		}
		public TCollection ReadCollection(TCollection Collection)
		{
			throw new global::System.NotSupportedException("TReader.ReadCollection is not implemented by the managed D2CSharp RTL.");
		}
		public TComponent ReadComponent(TComponent Component)
		{
			throw new global::System.NotSupportedException("TReader.ReadComponent is not implemented by the managed D2CSharp RTL.");
		}
		public double ReadFloat()
		{
			throw new global::System.NotSupportedException("TReader.ReadFloat is not implemented by the managed D2CSharp RTL.");
		}
		public string ReadIdent()
		{
			throw new global::System.NotSupportedException("TReader.ReadIdent is not implemented by the managed D2CSharp RTL.");
		}
		public int ReadInteger()
		{
			throw new global::System.NotSupportedException("TReader.ReadInteger is not implemented by the managed D2CSharp RTL.");
		}
		public long ReadInt64()
		{
			throw new global::System.NotSupportedException("TReader.ReadInt64 is not implemented by the managed D2CSharp RTL.");
		}
		public bool ReadListBegin()
		{
			throw new global::System.NotSupportedException("TReader.ReadListBegin is not implemented by the managed D2CSharp RTL.");
		}
		public void ReadListEnd()
		{
			throw new global::System.NotSupportedException("TReader.ReadListEnd is not implemented by the managed D2CSharp RTL.");
		}
		public TComponent ReadRootComponent(TComponent Root)
		{
			throw new global::System.NotSupportedException("TReader.ReadRootComponent is not implemented by the managed D2CSharp RTL.");
		}
		public string ReadString()
		{
			throw new global::System.NotSupportedException("TReader.ReadString is not implemented by the managed D2CSharp RTL.");
		}
		public object ReadVariant()
		{
			throw new global::System.NotSupportedException("TReader.ReadVariant is not implemented by the managed D2CSharp RTL.");
		}
	}	

	public class TWriter : TFiler
	{


/* TWriter */
		public TWriter() : this(null, 0) { }

		public TWriter(TStream Stream, int BufSize)
		:		base(Stream, BufSize)
		{
			//# base.Create(Stream, BufSize);
		}
		public override void DefineProperties(TPersistent Instance)
		{
			throw new global::System.NotSupportedException("TWriter.DefineProperties is not implemented by the managed D2CSharp RTL.");
		}
		public override void FlushBuffer()
		{
			throw new global::System.NotSupportedException("TWriter.FlushBuffer is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteBoolean(bool Value)
		{
			throw new global::System.NotSupportedException("TWriter.WriteBoolean is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteChar(char Value)
		{
			throw new global::System.NotSupportedException("TWriter.WriteChar is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteCollection(TCollection Value)
		{
			throw new global::System.NotSupportedException("TWriter.WriteCollection is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteComponent(TComponent Component)
		{
			throw new global::System.NotSupportedException("TWriter.WriteComponent is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteFloat(double Value)
		{
			throw new global::System.NotSupportedException("TWriter.WriteFloat is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteIdent(string Ident)
		{
			throw new global::System.NotSupportedException("TWriter.WriteIdent is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteInteger(int Value)
		{
			throw new global::System.NotSupportedException("TWriter.WriteInteger is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteInt64(long Value)
		{
			throw new global::System.NotSupportedException("TWriter.WriteInt64 is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteListBegin()
		{
			throw new global::System.NotSupportedException("TWriter.WriteListBegin is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteListEnd()
		{
			throw new global::System.NotSupportedException("TWriter.WriteListEnd is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteRootComponent(TComponent Root)
		{
			throw new global::System.NotSupportedException("TWriter.WriteRootComponent is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteString(string Value)
		{
			throw new global::System.NotSupportedException("TWriter.WriteString is not implemented by the managed D2CSharp RTL.");
		}
		public void WriteVariant(object Value)
		{
			throw new global::System.NotSupportedException("TWriter.WriteVariant is not implemented by the managed D2CSharp RTL.");
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
		private readonly global::System.Collections.Generic.List<TComponent> FComponents =
			new global::System.Collections.Generic.List<TComponent>();
		private TComponent GetComponent(int Index)
		{
			return FComponents[Index];
		}
		private int GetComponentCount()
		{
			return FComponents.Count;
		}
		private int GetComponentIndex()
		{
			return FOwner == null ? -1 : FOwner.FComponents.IndexOf(this);
		}
		private void SetComponentIndex(int Value)
		{
		}
		private void SetName(string NewName)
		{
			NewName ??= string.Empty;
			if (FName == NewName)
				return;
			ChangeName(NewName);
			FName = NewName;
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
			return this;
		}
		protected virtual TComponent GetChildParent()
		{
			return this;
		}
		/*protected overrides: */public override string GetNamePath()
		{
			if (FOwner == null || string.IsNullOrEmpty(FName))
				return string.IsNullOrEmpty(FName) ? base.GetNamePath() : FName;
			return FOwner.GetNamePath() + "." + FName;
		}
		protected virtual TObservers GetObservers()
		{
			return FObservers ??= new TObservers();
		}
		protected virtual TPersistent GetOwner()
		{
			return FOwner;
		}
		protected virtual void Loaded()
		{
		}
		protected virtual void Notification(TComponent AComponent, TOperation Operation)
		{
		}
		protected virtual bool CanObserve(int ID)
		{
			return GetObservers().CanObserve(ID);
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
		public TComponent() : this(null) { }

		public TComponent(TComponent AOwner)
		{
			FName = string.Empty;
			if (AOwner != null)
				AOwner.InsertComponent(this);
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
			while (FComponents.Count > 0)
			{
				TComponent Child = FComponents[FComponents.Count - 1];
				FComponents.RemoveAt(FComponents.Count - 1);
				Child.FOwner = null;
				Child.Destroy();
			}
		}
		public void Destroying()
		{
			DestroyComponents();
		}
		public TComponent FindComponent(string AName)
		{
			if (AName == null)
				return null;
			foreach (TComponent Component in FComponents)
				if (string.Equals(Component.Name, AName, global::System.StringComparison.OrdinalIgnoreCase))
					return Component;
			return null;
		}
		public TComponentEnumerator GetEnumerator()
		{
			return new TComponentEnumerator(this);
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
			return FOwner;
		}
		public virtual bool HasParent()
		{
			return FOwner != null;
		}
		public void InsertComponent(TComponent AComponent)
		{
			if (AComponent == null)
				throw new global::System.ArgumentNullException(nameof(AComponent));
			if (global::System.Object.ReferenceEquals(AComponent.FOwner, this))
				return;
			AComponent.FOwner?.RemoveComponent(AComponent);
			FComponents.Add(AComponent);
			AComponent.FOwner = this;
		}
		public void RemoveComponent(TComponent AComponent)
		{
			if (AComponent == null)
				return;
			if (FComponents.Remove(AComponent))
				AComponent.FOwner = null;
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
		private readonly TComponent FComponent;
		private int FIndex;

		private TComponent GetCurrent()
		{
			if (FIndex < 0 || FIndex >= FComponent.ComponentCount)
				return null;
			return FComponent.ReadPropertyComponents(FIndex);
		}
		public TComponentEnumerator() : this(new TComponent(null)) { }


		public TComponentEnumerator(TComponent AComponent)
		{
			FComponent = AComponent ?? throw new global::System.ArgumentNullException(nameof(AComponent));
			FIndex = -1;
		}

		public bool MoveNext()
		{
			FIndex++;
			return FIndex < FComponent.ComponentCount;
		}

		public TComponent Current => GetCurrent();
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
			return Target != null;
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
		public TBasicAction() : this(null) { }

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
			if (FOnExecute == null)
				return false;
			FOnExecute(this);
			return true;
		}
		public virtual bool ExecuteTarget(TObject Target)
		{
			return HandlesTarget(Target) && Execute();
		}
		public virtual bool Update()/*# dynamic */
		{
			if (FOnUpdate == null)
				return false;
			FOnUpdate(this);
			return true;
		}
		public virtual bool UpdateTarget(TObject Target)
		{
			return HandlesTarget(Target) && Update();
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
		public TDataModule() : this(null) { }

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
public delegate int TListSortCompare(Pointer Item1, Pointer Item2);
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
		// 0 corresponds to the "unknown/original format not determined" value.
		return 0;
	}
	public static bool ObjectBinaryToText(TStream Input, TStream Output)
	{
		throw new global::System.NotSupportedException(
			"Delphi component binary-to-text streaming is not implemented by the managed D2CSharp RTL.");
	}
	public static bool ObjectTextToBinary(TStream Input, TStream Output)
	{
		throw new global::System.NotSupportedException(
			"Delphi component text-to-binary streaming is not implemented by the managed D2CSharp RTL.");
	}
	public static void WriteComponentResFile(string FileName, TComponent Instance)
	{
		throw new global::System.NotSupportedException(
			"Delphi component resource streaming is not implemented by the managed D2CSharp RTL.");
	}
	public static TComponent ReadComponentResFile(string FileName, TComponent Instance)
	{
		throw new global::System.NotSupportedException(
			"Delphi component resource streaming is not implemented by the managed D2CSharp RTL.");
	}
	
} // class ClassesInterface


file class ClassesImplementation
{

} // class ClassesImplementation

}  // namespace Classes

}  // namespace System

