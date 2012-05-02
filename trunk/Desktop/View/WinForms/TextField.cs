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
using System.Windows.Forms;
using Clifton.Windows.Forms;
namespace ClearCanvas.Desktop.View.WinForms
{
    public partial class TextField : UserControl
    {
        private string _toolTip;

        public TextField()
        {
            InitializeComponent();
        }
        [Browsable(true)]
        [DefaultValue(false)]
        public bool IsPercentValidate { get; set; }

        /*
        public string Value
        {
            get { return NullIfEmpty(_textBox.Text); }
            set { _textBox.Text = value; }
        }
        */
        [Category("Text Field")]
        public string Value
        {
            get 
            {
                return _textBox.IsNull == false ? 
                    (string)_textBox.Value : 
                    _textBox.NullTextReturnValue; 
            } 
            set 
            { 
                _textBox.Value = 
                    value == string.Empty ? null : value; 
            }
        }

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get
            {
                return _textBox.ReadOnly;
            }
            set
            {
                _textBox.ReadOnly = value;
            }
        }
       
        public char PasswordChar
        {
            get { return _textBox.PasswordChar; }
            set { _textBox.PasswordChar = value; }
        }

        [DefaultValue("")]
        public string ToolTip
        {
            get
            {
                return _toolTip;
            }
            set
            {
                _toolTip = value;
            }
        }

        public event EventHandler ValueChanged
        {
            add { _textBox.TextChanged += value; }
            remove { _textBox.TextChanged -= value; }
        }
        [Localizable(true)]
        public string LabelText
        {
            get { return _label.Text; }
            set { _label.Text = value; }
        }
        
        /// <summary>
        /// Set/Get the text field mask.   See System.Windows.Forms.MaskedTextBox.Mask for details on setting the Mask value
        /// </summary>
        /// <seealso cref="System.Windows.Forms.MaskedTextBox.Mask"/>
        [Category("Masked Text Field")]
        [Description("See System.Windows.Forms.MaskedTextBox.Mask Property")]
        public string Mask
        {
            get { return _textBox.EditMask; }
            set { _textBox.EditMask = value; }
        }

        private void _textBox_MouseHover(object sender, EventArgs e)
        {
            ShowToolTip(true);
        }

        private void _textBox_MouseLeave(object sender, EventArgs e)
        {
            ShowToolTip(false);
        }

        // Hide the tooltip if the user starts typing again before the five-second display limit on the tooltip expires.
        private void _textBox_KeyDown(object sender, KeyEventArgs e)
        {
            ShowToolTip(false);
        }

        private void ShowToolTip(bool show)
        {
            if (show)
                _textFieldToolTip.Show(_toolTip, _textBox, _textBox.Location.X, _textBox.Location.Y, 5000);
            else
                _textFieldToolTip.Hide(_textBox);       
        }

		private void _textBox_DragEnter(object sender, DragEventArgs e)
		{
			if (_textBox.ReadOnly)
			{
				e.Effect = DragDropEffects.None;
				return;
			}

			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void _textBox_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				string dropString = (String)e.Data.GetData(typeof(String));

				// Insert string at the current keyboard cursor
				int currentIndex = _textBox.SelectionStart;
				_textBox.Text = string.Concat(
					_textBox.Text.Substring(0, currentIndex),
					dropString,
					_textBox.Text.Substring(currentIndex));
			}
		}

        private void _textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsPercentValidate)
            {
                if (!Char.IsNumber(e.KeyChar))
                {
                    e.Handled = !(_textBox.SelectionStart != 0 && (e.KeyChar.ToString() ==
                        System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator &&
                        (_textBox.Text.IndexOf(System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator) == -1)) &&
                        e.KeyChar != Convert.ToChar(8));
                }
                else
                {

                    try
                    {
                        decimal result = 0;
                        e.Handled = !decimal.TryParse(_textBox.Text + e.KeyChar, out result) && result < 100;
                        
                    }
                    catch
                    {
                    }


                }
            }
        }

        private void _textBox_Validating(object sender, CancelEventArgs e)
        {
            if (IsPercentValidate)
            {
                decimal isdecimal = 0;
                if (decimal.TryParse(_textBox.Text, out isdecimal))
                {
                    e.Cancel = Convert.ToDecimal(_textBox.Text) > 100;
                    _textBox.Text = "100";
                }
            }
        }

        // private static string NullIfEmpty(string value)
        // {
            // return (value != null && value.Length == 0) ? null : value;
        // }
    }
}
