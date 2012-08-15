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

namespace ClearCanvas.Material.Client.View.WinForms
{
    partial class MaterialLotEditorComponentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialLotEditorComponentControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtid = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.dtpInputDate = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this.lookupSupplier = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.txtDescription = new ClearCanvas.Desktop.View.WinForms.TextAreaField();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.txtid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpInputDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookupSupplier, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescription, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // txtid
            // 
            this.txtid.IsCurrencyTextBox = false;
            this.txtid.IsNumberOnly = false;
            resources.ApplyResources(this.txtid, "txtid");
            this.txtid.Mask = "";
            this.txtid.Name = "txtid";
            this.txtid.PasswordChar = '\0';
            this.txtid.ToolTip = null;
            this.txtid.Value = null;
            // 
            // dtpInputDate
            // 
            resources.ApplyResources(this.dtpInputDate, "dtpInputDate");
            this.dtpInputDate.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpInputDate.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpInputDate.Name = "dtpInputDate";
            this.dtpInputDate.Value = new System.DateTime(2012, 8, 7, 23, 43, 22, 334);
            // 
            // lookupSupplier
            // 
            resources.ApplyResources(this.lookupSupplier, "lookupSupplier");
            this.lookupSupplier.Name = "lookupSupplier";
            this.lookupSupplier.Value = null;
            // 
            // txtDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescription, 3);
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Value = null;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btnOk);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this._acceptButton_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // MaterialLotEditorComponentControl
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MaterialLotEditorComponentControl";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ClearCanvas.Desktop.View.WinForms.TextField txtid;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField dtpInputDate;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupSupplier;
        private ClearCanvas.Desktop.View.WinForms.TextAreaField txtDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

    }
}
