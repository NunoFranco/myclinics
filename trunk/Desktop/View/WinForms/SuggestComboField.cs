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
using System.ComponentModel;
using ClearCanvas.Desktop;

namespace ClearCanvas.Desktop.View.WinForms
{
    /// <summary>
    /// A type of field that allows the user to select an item from a list of suggested items
    /// that is provided dynamically from a <see cref="ISuggestionProvider"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="SuggestionProvider"/> property must be set.  Also, the <see cref="Format"/> event
    /// should be handled to correctly format items for display.
    /// </remarks>
    public partial class SuggestComboField : UserControl
    {
        public SuggestComboField()
        {
            InitializeComponent();
        }

        #region Design-time properties and events

        /// <summary>
        /// Gets or sets the associated label text.
        /// </summary>
        /// 
        [Localizable(true)]
        public string LabelText
        {
            get { return _label.Text; }
            set { _label.Text = value; }
        }

        /// <summary>
        /// Occurs to allow formatting of the item for display in the user-interface.
        /// </summary>
        public event ListControlConvertEventHandler Format
        {
            add { _comboBox.Format += value; }
            remove { _comboBox.Format -= value; }
        }

        #endregion

        [Browsable(false)]
        public object Value
        {
            get { return _comboBox.Value; }
            set { _comboBox.Value = value; }
        }

        [Browsable(false)]
        public event EventHandler ValueChanged
        {
            // use pass through event subscription
            add { _comboBox.ValueChanged += value; }
            remove { _comboBox.ValueChanged -= value; }
        }

        /// <summary>
        /// Gets the current query text (the text that is in the edit portion of the control).
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string QueryText
        {
            get { return _comboBox.Text; }
        }

        /// <summary>
        /// Gets or sets the <see cref="ISuggestionProvider"/>.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISuggestionProvider SuggestionProvider
        {
            get { return _comboBox.SuggestionProvider; }
            set { _comboBox.SuggestionProvider = value; }
        }

    }
}