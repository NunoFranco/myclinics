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

namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    partial class BillingDiscountEditComponentControl
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
            this.textFieldProcedureCode = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.textFieldProcedureName = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textFieldDiscountType = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.comboBoxEditAmountType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditAmount = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditAmountType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textFieldProcedureCode
            // 
            this.textFieldProcedureCode.LabelText = "Procedure Type Code";
            this.textFieldProcedureCode.Location = new System.Drawing.Point(25, 30);
            this.textFieldProcedureCode.Margin = new System.Windows.Forms.Padding(2);
            this.textFieldProcedureCode.Mask = "";
            this.textFieldProcedureCode.Name = "textFieldProcedureCode";
            this.textFieldProcedureCode.PasswordChar = '\0';
            this.textFieldProcedureCode.ReadOnly = true;
            this.textFieldProcedureCode.Size = new System.Drawing.Size(226, 41);
            this.textFieldProcedureCode.TabIndex = 0;
            this.textFieldProcedureCode.ToolTip = null;
            this.textFieldProcedureCode.Value = null;
            // 
            // textFieldProcedureName
            // 
            this.textFieldProcedureName.LabelText = "Procedure Type Name";
            this.textFieldProcedureName.Location = new System.Drawing.Point(270, 30);
            this.textFieldProcedureName.Margin = new System.Windows.Forms.Padding(2);
            this.textFieldProcedureName.Mask = "";
            this.textFieldProcedureName.Name = "textFieldProcedureName";
            this.textFieldProcedureName.PasswordChar = '\0';
            this.textFieldProcedureName.ReadOnly = true;
            this.textFieldProcedureName.Size = new System.Drawing.Size(329, 41);
            this.textFieldProcedureName.TabIndex = 4;
            this.textFieldProcedureName.ToolTip = null;
            this.textFieldProcedureName.Value = null;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(270, 168);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(25, 168);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(524, 168);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textFieldDiscountType
            // 
            this.textFieldDiscountType.LabelText = "Discount Type";
            this.textFieldDiscountType.Location = new System.Drawing.Point(25, 75);
            this.textFieldDiscountType.Margin = new System.Windows.Forms.Padding(2);
            this.textFieldDiscountType.Mask = "";
            this.textFieldDiscountType.Name = "textFieldDiscountType";
            this.textFieldDiscountType.PasswordChar = '\0';
            this.textFieldDiscountType.ReadOnly = true;
            this.textFieldDiscountType.Size = new System.Drawing.Size(226, 41);
            this.textFieldDiscountType.TabIndex = 8;
            this.textFieldDiscountType.ToolTip = null;
            this.textFieldDiscountType.Value = null;
            // 
            // comboBoxEditAmountType
            // 
            this.comboBoxEditAmountType.Location = new System.Drawing.Point(273, 94);
            this.comboBoxEditAmountType.Name = "comboBoxEditAmountType";
            this.comboBoxEditAmountType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditAmountType.Size = new System.Drawing.Size(326, 20);
            this.comboBoxEditAmountType.TabIndex = 9;
            this.comboBoxEditAmountType.SelectedIndexChanged += new System.EventHandler(this.comboBoxAmountType_SelectedIndexChanged);
           
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(277, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Amount Type";
            // 
            // textEditAmount
            // 
            this.textEditAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditAmount.EditValue = "";
            this.textEditAmount.EnterMoveNextControl = true;
            this.textEditAmount.Location = new System.Drawing.Point(28, 138);
            this.textEditAmount.Name = "textEditAmount";
            this.textEditAmount.Properties.MaxLength = 13;
            this.textEditAmount.Size = new System.Drawing.Size(220, 20);
            this.textEditAmount.TabIndex = 11;
            this.textEditAmount.Validating += new System.ComponentModel.CancelEventHandler(this.textEditAmount_Validating);
            this.textEditAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEditAmount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Amount";
            // 
            // BillingDiscountEditComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEditAmount);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.comboBoxEditAmountType);
            this.Controls.Add(this.textFieldDiscountType);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textFieldProcedureName);
            this.Controls.Add(this.textFieldProcedureCode);
            this.Name = "BillingDiscountEditComponentControl";
            this.Size = new System.Drawing.Size(625, 216);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditAmountType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAmount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClearCanvas.Desktop.View.WinForms.TextField textFieldProcedureCode;
        private ClearCanvas.Desktop.View.WinForms.TextField textFieldProcedureName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private ClearCanvas.Desktop.View.WinForms.TextField textFieldDiscountType;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditAmountType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditAmount;
        private System.Windows.Forms.Label label1;
    }
}
