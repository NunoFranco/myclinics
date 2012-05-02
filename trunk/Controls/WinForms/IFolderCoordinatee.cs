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
using System.ComponentModel;

namespace ClearCanvas.Controls.WinForms
{
	internal interface IFolderCoordinatee
	{
		/// <summary>
		/// Gets the <see cref="ClearCanvas.Controls.WinForms.Pidl"/> to which the coordinatee is synchronized.
		/// </summary>
		/// <remarks>
		/// Implementations should <b>NOT</b> return a new instance of a <see cref="ClearCanvas.Controls.WinForms.Pidl"/>,
		/// as consumers will not take over ownership and disposal responsibility of the returned object.
		/// </remarks>
		Pidl Pidl { get; }

		/// <summary>
		/// Fired before <see cref="Pidl"/> changes.
		/// </summary>
		event CancelEventHandler PidlChanging;

		/// <summary>
		/// Fired when <see cref="Pidl"/> changes.
		/// </summary>
		event EventHandler PidlChanged;

		/// <summary>
		/// Synchronizes the coordinatee to the specified <see cref="ClearCanvas.Controls.WinForms.Pidl"/>.
		/// </summary>
		/// <remarks>
		/// Implementations should <b>NOT</b> use the provided <paramref name="pidl"/> as is, but rather
		/// clone a new instance for which it will assume ownership and responsibility.
		/// </remarks>
		/// <param name="pidl">The <see cref="ClearCanvas.Controls.WinForms.Pidl"/> to which the coordinatee should be synchronized.</param>
		void BrowseTo(Pidl pidl);

		/// <summary>
		/// Reloads the coordinatee's view of the currently synchronized <see cref="Pidl"/>.
		/// </summary>
		void Reload();
	}
}