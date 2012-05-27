#region License

// Copyright (c) 2006-2007, ClearCanvas Inc.
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

namespace ClearCanvas.Ris.Client.Admin.View.WinForms
{
    partial class WorkingShiftEditorComponentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkingShiftEditorComponentControl));
            this._txtName = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._txtDescription = new ClearCanvas.Desktop.View.WinForms.TextAreaField();
            this._dtpstartTime = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this._dtpEndTime = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtName
            // 
            resources.ApplyResources(this._txtName, "_txtName");
            this._txtName.Mask = "";
            this._txtName.Name = "_txtName";
            this._txtName.PasswordChar = '\0';
            this._txtName.ToolTip = null;
            this._txtName.Value = null;
            // 
            // _txtDescription
            // 
            resources.ApplyResources(this._txtDescription, "_txtDescription");
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Value = null;
            // 
            // _dtpstartTime
            // 
            resources.ApplyResources(this._dtpstartTime, "_dtpstartTime");
            this._dtpstartTime.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._dtpstartTime.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._dtpstartTime.Name = "_dtpstartTime";
            this._dtpstartTime.ShowDate = false;
            this._dtpstartTime.ShowTime = true;
            this._dtpstartTime.Value = new System.DateTime(2012, 5, 27, 14, 53, 30, 235);
            // 
            // _dtpEndTime
            // 
            resources.ApplyResources(this._dtpEndTime, "_dtpEndTime");
            this._dtpEndTime.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._dtpEndTime.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._dtpEndTime.Name = "_dtpEndTime";
            this._dtpEndTime.ShowDate = false;
            this._dtpEndTime.ShowTime = true;
            this._dtpEndTime.Value = new System.DateTime(2012, 5, 27, 14, 51, 20, 536);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // WorkingShiftEditorComponentControl
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this._dtpEndTime);
            this.Controls.Add(this._dtpstartTime);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._txtName);
            this.Name = "WorkingShiftEditorComponentControl";
            this.ResumeLayout(false);

        }

        #endregion

        private ClearCanvas.Desktop.View.WinForms.TextField _txtName;
        private ClearCanvas.Desktop.View.WinForms.TextAreaField _txtDescription;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _dtpstartTime;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _dtpEndTime;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
