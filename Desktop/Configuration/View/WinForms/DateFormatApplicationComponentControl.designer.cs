#region License

// Copyright (c) 2006-2008, ClearCanvas Inc.
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

namespace ClearCanvas.Desktop.Configuration.View.WinForms
{
    partial class DateFormatApplicationComponentControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateFormatApplicationComponentControl));
            this._dateSample = new System.Windows.Forms.TextBox();
            this._radioCustom = new System.Windows.Forms.RadioButton();
            this._comboCustomDateFormat = new System.Windows.Forms.ComboBox();
            this._radioSystemShortDate = new System.Windows.Forms.RadioButton();
            this._radioSystemLongDate = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // _dateSample
            // 
            this._dateSample.AccessibleDescription = null;
            this._dateSample.AccessibleName = null;
            resources.ApplyResources(this._dateSample, "_dateSample");
            this._dateSample.BackgroundImage = null;
            this._dateSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._dateSample.Font = null;
            this._dateSample.Name = "_dateSample";
            this._dateSample.ReadOnly = true;
            this._dateSample.TabStop = false;
            // 
            // _radioCustom
            // 
            this._radioCustom.AccessibleDescription = null;
            this._radioCustom.AccessibleName = null;
            resources.ApplyResources(this._radioCustom, "_radioCustom");
            this._radioCustom.BackgroundImage = null;
            this._radioCustom.Font = null;
            this._radioCustom.Name = "_radioCustom";
            this._radioCustom.UseVisualStyleBackColor = true;
            // 
            // _comboCustomDateFormat
            // 
            this._comboCustomDateFormat.AccessibleDescription = null;
            this._comboCustomDateFormat.AccessibleName = null;
            resources.ApplyResources(this._comboCustomDateFormat, "_comboCustomDateFormat");
            this._comboCustomDateFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._comboCustomDateFormat.BackgroundImage = null;
            this._comboCustomDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboCustomDateFormat.Font = null;
            this._comboCustomDateFormat.Name = "_comboCustomDateFormat";
            // 
            // _radioSystemShortDate
            // 
            this._radioSystemShortDate.AccessibleDescription = null;
            this._radioSystemShortDate.AccessibleName = null;
            resources.ApplyResources(this._radioSystemShortDate, "_radioSystemShortDate");
            this._radioSystemShortDate.BackgroundImage = null;
            this._radioSystemShortDate.Font = null;
            this._radioSystemShortDate.Name = "_radioSystemShortDate";
            this._radioSystemShortDate.UseVisualStyleBackColor = true;
            // 
            // _radioSystemLongDate
            // 
            this._radioSystemLongDate.AccessibleDescription = null;
            this._radioSystemLongDate.AccessibleName = null;
            resources.ApplyResources(this._radioSystemLongDate, "_radioSystemLongDate");
            this._radioSystemLongDate.BackgroundImage = null;
            this._radioSystemLongDate.Font = null;
            this._radioSystemLongDate.Name = "_radioSystemLongDate";
            this._radioSystemLongDate.UseVisualStyleBackColor = true;
            // 
            // DateFormatApplicationComponentControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this._comboCustomDateFormat);
            this.Controls.Add(this._radioCustom);
            this.Controls.Add(this._radioSystemLongDate);
            this.Controls.Add(this._radioSystemShortDate);
            this.Controls.Add(this._dateSample);
            this.Font = null;
            this.Name = "DateFormatApplicationComponentControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox _dateSample;
		private System.Windows.Forms.RadioButton _radioCustom;
		private ComboBox _comboCustomDateFormat;
		private RadioButton _radioSystemShortDate;
		private RadioButton _radioSystemLongDate;
    }
}
