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
using System.Windows.Forms;
using ClearCanvas.Desktop.View.WinForms;

namespace ClearCanvas.Ris.Client.View.WinForms
{
    /// <summary>
	/// Provides a Windows Forms user-interface for <see cref="CannedTextSummaryComponent"/>
    /// </summary>
    public partial class CannedTextSummaryComponentControl : ApplicationComponentUserControl
    {
        private readonly CannedTextSummaryComponent _component;

        /// <summary>
        /// Constructor
        /// </summary>
        public CannedTextSummaryComponentControl(CannedTextSummaryComponent component)
            :base(component)
        {
            InitializeComponent();
            _component = component;

			_cannedTexts.Table = _component.SummaryTable;
			_cannedTexts.MenuModel = _component.SummaryTableActionModel;
			_cannedTexts.ToolbarModel = _component.SummaryTableActionModel;
			_cannedTexts.DataBindings.Add("Selection", _component, "SummarySelection", true, DataSourceUpdateMode.OnPropertyChanged);

			_component.CopyCannedTextRequested += _component_CopyCannedTextRequested;
		}

		private void _component_CopyCannedTextRequested(object sender, EventArgs e)
		{
			string fullCannedText = _component.GetFullCannedText();
			if (!string.IsNullOrEmpty(fullCannedText))
				Clipboard.SetDataObject(fullCannedText, true);
		}

		private void _cannedTexts_ItemDrag(object sender, ItemDragEventArgs e)
		{
			string fullCannedText = _component.GetFullCannedText();
			if (!string.IsNullOrEmpty(fullCannedText))
				_cannedTexts.DoDragDrop(fullCannedText, DragDropEffects.All);
		}

		private void _cannedTexts_ItemDoubleClicked(object sender, EventArgs e)
		{
			_component.EditSelectedItems();
		}
	}
}