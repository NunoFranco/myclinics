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

namespace ClearCanvas.Ris.Client.View.WinForms
{
    partial class StaffGroupDetailsEditorComponentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffGroupDetailsEditorComponentControl));
            this._electiveCheckbox = new System.Windows.Forms.CheckBox();
            this._description = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._name = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.SuspendLayout();
            // 
            // _electiveCheckbox
            // 
            this._electiveCheckbox.AccessibleDescription = null;
            this._electiveCheckbox.AccessibleName = null;
            resources.ApplyResources(this._electiveCheckbox, "_electiveCheckbox");
            this._electiveCheckbox.BackgroundImage = null;
            this._electiveCheckbox.Font = null;
            this._electiveCheckbox.Name = "_electiveCheckbox";
            this._electiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // _description
            // 
            this._description.AccessibleDescription = null;
            this._description.AccessibleName = null;
            resources.ApplyResources(this._description, "_description");
            this._description.BackgroundImage = null;
            this._description.Font = null;
            this._description.Mask = "";
            this._description.Name = "_description";
            this._description.PasswordChar = '\0';
            this._description.ToolTip = null;
            this._description.Value = null;
            // 
            // _name
            // 
            this._name.AccessibleDescription = null;
            this._name.AccessibleName = null;
            resources.ApplyResources(this._name, "_name");
            this._name.BackgroundImage = null;
            this._name.Font = null;
            this._name.Mask = "";
            this._name.Name = "_name";
            this._name.PasswordChar = '\0';
            this._name.ToolTip = null;
            this._name.Value = null;
            // 
            // StaffGroupDetailsEditorComponentControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this._electiveCheckbox);
            this.Controls.Add(this._description);
            this.Controls.Add(this._name);
            this.Font = null;
            this.Name = "StaffGroupDetailsEditorComponentControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.CheckBox _electiveCheckbox;
		private ClearCanvas.Desktop.View.WinForms.TextField _description;
        private ClearCanvas.Desktop.View.WinForms.TextField _name;
    }
}
