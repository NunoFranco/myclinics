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

namespace ClearCanvas.Ris.Billing.View.WinForms
{
    partial class BillingCurrencyEditComponentControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCode = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtName = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtCustomFormat = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtRateToPrimary = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkPrimaryExRateCurrency = new System.Windows.Forms.CheckBox();
            this.chkPrimaryCurrency = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbDisplayLocal = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.21576F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.78424F));
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCustomFormat, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRateToPrimary, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbDisplayLocal, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(616, 175);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.LabelText = "Currency Code";
            this.txtCode.Location = new System.Drawing.Point(2, 2);
            this.txtCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtCode.Mask = "";
            this.txtCode.Name = "txtCode";
            this.txtCode.PasswordChar = '\0';
            this.txtCode.Size = new System.Drawing.Size(239, 40);
            this.txtCode.TabIndex = 0;
            this.txtCode.ToolTip = null;
            this.txtCode.Value = null;
            // 
            // txtName
            // 
            this.txtName.LabelText = "Currency Name";
            this.txtName.Location = new System.Drawing.Point(280, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Mask = "";
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.Size = new System.Drawing.Size(297, 40);
            this.txtName.TabIndex = 1;
            this.txtName.ToolTip = null;
            this.txtName.Value = null;
            // 
            // txtCustomFormat
            // 
            this.txtCustomFormat.LabelText = "Custom display format (#,###.##)";
            this.txtCustomFormat.Location = new System.Drawing.Point(280, 47);
            this.txtCustomFormat.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomFormat.Mask = "";
            this.txtCustomFormat.Name = "txtCustomFormat";
            this.txtCustomFormat.PasswordChar = '\0';
            this.txtCustomFormat.Size = new System.Drawing.Size(297, 40);
            this.txtCustomFormat.TabIndex = 0;
            this.txtCustomFormat.ToolTip = null;
            this.txtCustomFormat.Value = null;
            // 
            // txtRateToPrimary
            // 
            this.txtRateToPrimary.LabelText = "Rate To Primary Ex-Rate Currency";
            this.txtRateToPrimary.Location = new System.Drawing.Point(2, 92);
            this.txtRateToPrimary.Margin = new System.Windows.Forms.Padding(2);
            this.txtRateToPrimary.Mask = "";
            this.txtRateToPrimary.Name = "txtRateToPrimary";
            this.txtRateToPrimary.PasswordChar = '\0';
            this.txtRateToPrimary.Size = new System.Drawing.Size(239, 41);
            this.txtRateToPrimary.TabIndex = 0;
            this.txtRateToPrimary.ToolTip = null;
            this.txtRateToPrimary.Value = null;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.9759F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.0241F));
            this.tableLayoutPanel2.Controls.Add(this.chkPrimaryExRateCurrency, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkPrimaryCurrency, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(281, 93);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(332, 40);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // chkPrimaryExRateCurrency
            // 
            this.chkPrimaryExRateCurrency.AutoSize = true;
            this.chkPrimaryExRateCurrency.Enabled = false;
            this.chkPrimaryExRateCurrency.Location = new System.Drawing.Point(148, 3);
            this.chkPrimaryExRateCurrency.Name = "chkPrimaryExRateCurrency";
            this.chkPrimaryExRateCurrency.Size = new System.Drawing.Size(157, 17);
            this.chkPrimaryExRateCurrency.TabIndex = 2;
            this.chkPrimaryExRateCurrency.Text = "Is Primary Ex-Rate Currency";
            this.chkPrimaryExRateCurrency.UseVisualStyleBackColor = true;
            // 
            // chkPrimaryCurrency
            // 
            this.chkPrimaryCurrency.AutoSize = true;
            this.chkPrimaryCurrency.Enabled = false;
            this.chkPrimaryCurrency.Location = new System.Drawing.Point(3, 3);
            this.chkPrimaryCurrency.Name = "chkPrimaryCurrency";
            this.chkPrimaryCurrency.Size = new System.Drawing.Size(116, 17);
            this.chkPrimaryCurrency.TabIndex = 2;
            this.chkPrimaryCurrency.Text = "Is Primary Currency";
            this.chkPrimaryCurrency.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnOk, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(281, 139);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(184, 27);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(3, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 21);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(95, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbDisplayLocal
            // 
            this.cmbDisplayLocal.DataSource = null;
            this.cmbDisplayLocal.DisplayMember = "";
            this.cmbDisplayLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisplayLocal.LabelText = "Display Locale";
            this.cmbDisplayLocal.Location = new System.Drawing.Point(2, 47);
            this.cmbDisplayLocal.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDisplayLocal.Name = "cmbDisplayLocal";
            this.cmbDisplayLocal.Size = new System.Drawing.Size(239, 41);
            this.cmbDisplayLocal.TabIndex = 5;
            this.cmbDisplayLocal.Value = null;
            this.cmbDisplayLocal.ValueChanged += new System.EventHandler(this.cmbDisplayLocal_ValueChanged);
            // 
            // BillingCurrencyEditComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BillingCurrencyEditComponentControl";
            this.Size = new System.Drawing.Size(619, 191);
            this.Load += new System.EventHandler(this.BillingCurrencyEditComponentControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ClearCanvas.Desktop.View.WinForms.TextField txtCode;
        private ClearCanvas.Desktop.View.WinForms.TextField txtName;
        private ClearCanvas.Desktop.View.WinForms.TextField txtCustomFormat;
        private ClearCanvas.Desktop.View.WinForms.TextField txtRateToPrimary;
        private System.Windows.Forms.CheckBox chkPrimaryCurrency;
        private System.Windows.Forms.CheckBox chkPrimaryExRateCurrency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField cmbDisplayLocal;
    }
}
