﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections;
using System.Collections.Generic;

namespace ClearCanvas.Common.Utilities
{
	/// <summary>
	/// A list class, changes to which can be observed via events.
	/// </summary>
	/// <remarks>
	/// Internally, a simple <see cref="List{T}"/> object is used.  
	/// For exception details on individual methods, see <see cref="List{T}"/>.
	/// </remarks>
	/// <typeparam name="TItem">The type of the objects stored in the list.</typeparam>
	public class ObservableList<TItem> : IObservableList<TItem>
	{
		private readonly List<TItem> _list;
		private bool _enableEvents = true;	// events are enabled by default
		
		private event EventHandler<ListEventArgs<TItem>> _itemAddedEvent;
		private event EventHandler<ListEventArgs<TItem>> _itemRemovedEvent;
		private event EventHandler<ListEventArgs<TItem>> _itemChanging; 
		private event EventHandler<ListEventArgs<TItem>> _itemChangedEvent;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ObservableList()
		{
			_list = new List<TItem>();
		}

		/// <summary>
		/// Copy constructor that takes a set of <typeparamref name="TItem"/>s and adds them to this list.
		/// </summary>
		public ObservableList(IEnumerable<TItem> values)
			: this()
		{
			foreach (TItem item in values)
				this.Add(item);
		}

		/// <summary>
		/// Gets or sets a value indicating whether <see cref="ItemAdded"/>, <see cref="ItemChanged"/>,
		/// <see cref="ItemChanging"/> and <see cref="ItemRemoved"/> events are raised.
		/// </summary>
		public bool EnableEvents
		{
			get { return _enableEvents; }
			set { _enableEvents = value; }
		}

		/// <summary>
		/// Sorts the list given the input <paramref name="sortComparer"/>.
		/// </summary>
		/// <param name="sortComparer">A comparer to be used to sort the list.</param>
		public virtual void Sort(IComparer<TItem> sortComparer)
		{
			Platform.CheckForNullReference(sortComparer, "sortComparer");

			_list.Sort(sortComparer);
		}

		#region IObservableList

		/// <summary>
		/// Fired when an item is added to the list.
		/// </summary>
		public event EventHandler<ListEventArgs<TItem>> ItemAdded
		{
			add { _itemAddedEvent += value; }
			remove { _itemAddedEvent -= value;	}
		}

		/// <summary>
		/// Fired when an item is removed from the list.
		/// </summary>
		public event EventHandler<ListEventArgs<TItem>> ItemRemoved
		{
			add { _itemRemovedEvent += value; }
			remove { _itemRemovedEvent -= value; }
		}

		/// <summary>
		/// Fired when an item in the list has changed.
		/// </summary>
		public event EventHandler<ListEventArgs<TItem>> ItemChanged
		{
			add { _itemChangedEvent += value; }
			remove { _itemChangedEvent -= value; }
		}

		/// <summary>
		/// Fires when an item in the list is about to change.
		/// </summary>
		public event EventHandler<ListEventArgs<TItem>> ItemChanging
		{
			add { _itemChanging += value; }
			remove { _itemChanging -= value; }
		}

		#endregion
		#region IList<T> Members

		/// <summary>
		/// Gets the index of <paramref name="item"/> in the list.
		/// </summary>
		/// <returns>The index of <paramref name="item"/>, or -1 if it is not in the list.</returns>
		public int IndexOf(TItem item)
		{
			Platform.CheckForNullReference(item, "item");

			return _list.IndexOf(item);
		}

		/// <summary>
		/// Inserts <paramref name="item"/> at the specified <paramref name="index"/>.
		/// </summary>
		public virtual void Insert(int index, TItem item)
		{
			Platform.CheckArgumentRange(index, 0, this.Count, "index");

			_list.Insert(index, item);
			OnItemAdded(new ListEventArgs<TItem>(item, index));
		}

		/// <summary>
		/// Removes the item at the specified <paramref name="index"/>.
		/// </summary>
		public virtual void RemoveAt(int index)
		{
			Platform.CheckArgumentRange(index, 0, this.Count - 1, "index");

			TItem itemToRemove = this[index];
			_list.RemoveAt(index);

			OnItemRemoved(new ListEventArgs<TItem>(itemToRemove, index));
		}

		/// <summary>
		/// Gets or sets the item at the specified index.
		/// </summary>
		public virtual TItem this[int index]
		{
			get
			{
				Platform.CheckIndexRange(index, 0, this.Count - 1, "index");
				return _list[index];
			}
			set
			{
				Platform.CheckIndexRange(index, 0, this.Count - 1, "index");

				ListEventArgs<TItem> args = new ListEventArgs<TItem>(_list[index], index);
				OnItemChanging(args);
				
				_list[index] = value;

				args = new ListEventArgs<TItem>(value, index);
				OnItemChanged(args);
			}
		}

		#endregion

		#region ICollection<TItem> Members

		/// <summary>
		/// Adds the specified item to the list.
		/// </summary>
		public virtual void Add(TItem item)
		{
			_list.Add(item);
			OnItemAdded(new ListEventArgs<TItem>(item, this.Count - 1));
		}

		/// <summary>
		/// Clears the list.
		/// </summary>
		public virtual void Clear()
		{
			// If we don't have any subscribers to the ItemRemovedEvent, then
			// make it faster and just call Clear().
			if (_itemRemovedEvent == null)
			{
				_list.Clear();
			}
			// But if we do, then we have to remove items one by one so that
			// subscribers are notified.
			else
			{
				while (this.Count > 0)
				{
					int lastIndex = this.Count - 1;
					RemoveAt(lastIndex);
				}
			}
		}

		/// <summary>
		/// Gets whether or not the list contains the specified item.
		/// </summary>
		public bool Contains(TItem item)
		{
			Platform.CheckForNullReference(item, "item");

			return _list.Contains(item);
		}

		/// <summary>
		/// Copies the entire contents of the list to the input <paramref name="array"/>, 
		/// starting at the specified <paramref name="arrayIndex"/>.
		/// </summary>
		public void CopyTo(TItem[] array, int arrayIndex)
		{
			_list.CopyTo(array, arrayIndex);
		}

		/// <summary>
		/// Gets the number of items in the list.
		/// </summary>
		public int Count
		{
			get { return _list.Count; }
		}

		/// <summary>
		/// returns false.
		/// </summary>
		public bool IsReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// Removes the specified <paramref name="item"/> from the list.
		/// </summary>
		/// <returns>True if the item was in the list and was removed.</returns>
		public virtual bool Remove(TItem item)
		{
			Platform.CheckForNullReference(item, "item");

			int index = _list.IndexOf(item);

			if (index >= 0)
			{
				_list.RemoveAt(index);
				// Only raise event if the item was actually removed
				OnItemRemoved(new ListEventArgs<TItem>(item, index));
				return true;
			}

			return false;
		}

		#endregion

		#region IEnumerable<TItem> Members

		/// <summary>
		/// Gets an <see cref="IEnumerator{T}"/> for the list.
		/// </summary>
		public IEnumerator<TItem> GetEnumerator()
		{
			return (_list as IEnumerable<TItem>).GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		/// <summary>
		/// Gets an <see cref="IEnumerator"/> for the list.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		#endregion

		/// <summary>
		/// Called internally when an item is added.
		/// </summary>
		protected virtual void OnItemAdded(ListEventArgs<TItem> e)
		{
			if(_enableEvents)
				EventsHelper.Fire(_itemAddedEvent, this, e);
		}

		/// <summary>
		/// Called internally when an item is removed.
		/// </summary>
		protected virtual void OnItemRemoved(ListEventArgs<TItem> e)
		{
			if (_enableEvents)
				EventsHelper.Fire(_itemRemovedEvent, this, e);
		}

		/// <summary>
		/// Called internally when an item is changing.
		/// </summary>
		protected virtual void OnItemChanging(ListEventArgs<TItem> e)
		{
			if (_enableEvents)
				EventsHelper.Fire(_itemChanging, this, e);
		}

		/// <summary>
		/// Called internally when an item has changed.
		/// </summary>
		protected virtual void OnItemChanged(ListEventArgs<TItem> e)
		{
			if (_enableEvents)
				EventsHelper.Fire(_itemChangedEvent, this, e);
		}
	}
}
