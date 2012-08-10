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

namespace ClearCanvas.Desktop.View.WinForms
{
    partial class LookupEditField
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer _components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookupEditField ));
            this._label = new System.Windows.Forms.Label();
            this._LookupBox = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this._LookupBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.AccessibleDescription = null;
            this._label.AccessibleName = null;
            resources.ApplyResources(this._label, "_label");
            this._label.Font = null;
            this._label.Name = "_label";
            // 
            // _LookupBox
            // 
            resources.ApplyResources(this._LookupBox, "_LookupBox");
            this._LookupBox.BackgroundImage = null;
            this._LookupBox.EditValue = null;
            this._LookupBox.Name = "_LookupBox";
            this._LookupBox.Properties.AccessibleDescription = null;
            this._LookupBox.Properties.AccessibleName = null;
            this._LookupBox.Properties.AutoHeight = ((bool)(resources.GetObject("_LookupBox.Properties.AutoHeight")));
            this._LookupBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("_LookupBox.Properties.Buttons"))))});
            this._LookupBox.Properties.NullText = resources.GetString("_LookupBox.Properties.NullText");
            this._LookupBox.Properties.NullValuePrompt = resources.GetString("_LookupBox.Properties.NullValuePrompt");
            this._LookupBox.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("_LookupBox.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // ComboBoxField
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this._LookupBox);
            this.Controls.Add(this._label);
            this.Font = null;
            this.Name = "ComboBoxField";
            ((System.ComponentModel.ISupportInitialize)(this._LookupBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label;
        private DevExpress.XtraEditors.LookUpEdit _LookupBox;
    }
}
