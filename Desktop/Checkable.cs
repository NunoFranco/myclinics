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

namespace ClearCanvas.Desktop
{
	/// <summary>
	/// Wrapper class for items that are "checkable".
	/// </summary>
	/// <typeparam name="TItem">The type of the checkable item.</typeparam>
    public class Checkable<TItem>
    {
        private bool _isChecked;
        private TItem _item;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="item">The checkable item.</param>
		/// <param name="isChecked">The initial check state of the item.</param>
        public Checkable(TItem item, bool isChecked)
        {
            _isChecked = isChecked;
            _item = item;
        }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks>
		/// The initial check state is false by default.
		/// </remarks>
		/// <param name="item">The checkable item.</param>
        public Checkable(TItem item)
            : this(item, false)
        {
        }

		/// <summary>
		/// Gets or sets the checkable item.
		/// </summary>
        public TItem Item
        {
            get { return _item; }
        }

		/// <summary>
		/// Gets or sets the check state of the item.
		/// </summary>
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }
    }
}