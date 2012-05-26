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
    partial class ProcedureTypeEditorComponentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcedureTypeEditorComponentControl));
            this._acceptButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._baseType = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._id = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._name = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._xmlEditorPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._totalPrice = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._itemTax = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._itemPrice = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._comboUnit = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._comboCategory = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this.chkIsRequired = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _acceptButton
            // 
            this._acceptButton.AccessibleDescription = null;
            this._acceptButton.AccessibleName = null;
            resources.ApplyResources(this._acceptButton, "_acceptButton");
            this._acceptButton.BackgroundImage = null;
            this._acceptButton.Font = null;
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this._acceptButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.AccessibleDescription = null;
            this._cancelButton.AccessibleName = null;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.BackgroundImage = null;
            this._cancelButton.Font = null;
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _baseType
            // 
            this._baseType.AccessibleDescription = null;
            this._baseType.AccessibleName = null;
            resources.ApplyResources(this._baseType, "_baseType");
            this._baseType.BackgroundImage = null;
            this._baseType.DataSource = null;
            this._baseType.DisplayMember = "";
            this._baseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._baseType.Font = null;
            this._baseType.Name = "_baseType";
            this._baseType.Value = null;
            // 
            // _id
            // 
            this._id.AccessibleDescription = null;
            this._id.AccessibleName = null;
            resources.ApplyResources(this._id, "_id");
            this._id.BackgroundImage = null;
            this._id.Font = null;
            this._id.Mask = "";
            this._id.Name = "_id";
            this._id.PasswordChar = '\0';
            this._id.ToolTip = null;
            this._id.Value = null;
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
            // _xmlEditorPanel
            // 
            this._xmlEditorPanel.AccessibleDescription = null;
            this._xmlEditorPanel.AccessibleName = null;
            resources.ApplyResources(this._xmlEditorPanel, "_xmlEditorPanel");
            this._xmlEditorPanel.BackgroundImage = null;
            this._xmlEditorPanel.Font = null;
            this._xmlEditorPanel.Name = "_xmlEditorPanel";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // _totalPrice
            // 
            this._totalPrice.AccessibleDescription = null;
            this._totalPrice.AccessibleName = null;
            resources.ApplyResources(this._totalPrice, "_totalPrice");
            this._totalPrice.BackgroundImage = null;
            this._totalPrice.Font = null;
            this._totalPrice.Mask = "";
            this._totalPrice.Name = "_totalPrice";
            this._totalPrice.PasswordChar = '\0';
            this._totalPrice.ReadOnly = true;
            this._totalPrice.ToolTip = null;
            this._totalPrice.Value = "0";
            // 
            // _itemTax
            // 
            this._itemTax.AccessibleDescription = null;
            this._itemTax.AccessibleName = null;
            resources.ApplyResources(this._itemTax, "_itemTax");
            this._itemTax.BackgroundImage = null;
            this._itemTax.Font = null;
            this._itemTax.Mask = "";
            this._itemTax.Name = "_itemTax";
            this._itemTax.PasswordChar = '\0';
            this._itemTax.ToolTip = null;
            this._itemTax.Value = null;
            this._itemTax.Load += new System.EventHandler(this._itemTax_Load);
            this._itemTax.ValueChanged += new System.EventHandler(this._itemTax_ValueChanged);
            this._itemTax.Leave += new System.EventHandler(this._itemTax_Leave);
            // 
            // _itemPrice
            // 
            this._itemPrice.AccessibleDescription = null;
            this._itemPrice.AccessibleName = null;
            resources.ApplyResources(this._itemPrice, "_itemPrice");
            this._itemPrice.BackgroundImage = null;
            this._itemPrice.Font = null;
            this._itemPrice.Mask = "";
            this._itemPrice.Name = "_itemPrice";
            this._itemPrice.PasswordChar = '\0';
            this._itemPrice.ToolTip = null;
            this._itemPrice.Value = "0";
            this._itemPrice.ValueChanged += new System.EventHandler(this._itemPrice_ValueChanged);
            this._itemPrice.Leave += new System.EventHandler(this._itemPrice_Leave);
            // 
            // _comboUnit
            // 
            this._comboUnit.AccessibleDescription = null;
            this._comboUnit.AccessibleName = null;
            resources.ApplyResources(this._comboUnit, "_comboUnit");
            this._comboUnit.BackgroundImage = null;
            this._comboUnit.DataSource = null;
            this._comboUnit.DisplayMember = "";
            this._comboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboUnit.Font = null;
            this._comboUnit.Name = "_comboUnit";
            this._comboUnit.Value = null;
            // 
            // _comboCategory
            // 
            this._comboCategory.AccessibleDescription = null;
            this._comboCategory.AccessibleName = null;
            resources.ApplyResources(this._comboCategory, "_comboCategory");
            this._comboCategory.BackgroundImage = null;
            this._comboCategory.DataSource = null;
            this._comboCategory.DisplayMember = "";
            this._comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboCategory.Font = null;
            this._comboCategory.Name = "_comboCategory";
            this._comboCategory.Value = null;
            // 
            // chkIsRequired
            // 
            this.chkIsRequired.AccessibleDescription = null;
            this.chkIsRequired.AccessibleName = null;
            resources.ApplyResources(this.chkIsRequired, "chkIsRequired");
            this.chkIsRequired.BackgroundImage = null;
            this.chkIsRequired.Font = null;
            this.chkIsRequired.Name = "chkIsRequired";
            this.chkIsRequired.UseVisualStyleBackColor = true;
            // 
            // ProcedureTypeEditorComponentControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.chkIsRequired);
            this.Controls.Add(this._comboCategory);
            this.Controls.Add(this._comboUnit);
            this.Controls.Add(this._totalPrice);
            this.Controls.Add(this._itemTax);
            this.Controls.Add(this._itemPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._xmlEditorPanel);
            this.Controls.Add(this._name);
            this.Controls.Add(this._id);
            this.Controls.Add(this._baseType);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._acceptButton);
            this.Font = null;
            this.Name = "ProcedureTypeEditorComponentControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button _acceptButton;
		private System.Windows.Forms.Button _cancelButton;
		private ClearCanvas.Desktop.View.WinForms.ComboBoxField _baseType;
		private ClearCanvas.Desktop.View.WinForms.TextField _id;
		private ClearCanvas.Desktop.View.WinForms.TextField _name;
		private System.Windows.Forms.Panel _xmlEditorPanel;
        private System.Windows.Forms.Label label1;
        private ClearCanvas.Desktop.View.WinForms.TextField _totalPrice;
        private ClearCanvas.Desktop.View.WinForms.TextField _itemTax;
        private ClearCanvas.Desktop.View.WinForms.TextField _itemPrice;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _comboUnit;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _comboCategory;
        private System.Windows.Forms.CheckBox chkIsRequired;
    }
}
