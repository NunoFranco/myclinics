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
    partial class StockTransactionEditorComponentControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtInputCode = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.lkuMaterialLot = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.txtDescription = new ClearCanvas.Desktop.View.WinForms.TextAreaField();
            this.lookupFromWareHouse = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.lookupToWareHouse = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMedicineDose = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.lkuMedicine = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.txtCurrentQuantity = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.lblUOM = new System.Windows.Forms.Label();
            this.txtUOM = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtInputPrice = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtInputQuantity = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.dtpExpireDate = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnLineCancel = new System.Windows.Forms.Button();
            this.txtTaxRate = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableView_Medicines = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableView_Medicines, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1120, 546);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1114, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common Information";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtInputCode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lkuMaterialLot, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDescription, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lookupFromWareHouse, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lookupToWareHouse, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1108, 157);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtInputCode
            // 
            this.txtInputCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputCode.IsCurrencyTextBox = false;
            this.txtInputCode.IsNumberOnly = false;
            this.txtInputCode.LabelText = "Input Code";
            this.txtInputCode.Location = new System.Drawing.Point(2, 2);
            this.txtInputCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtInputCode.Mask = "";
            this.txtInputCode.Name = "txtInputCode";
            this.txtInputCode.PasswordChar = '\0';
            this.txtInputCode.Size = new System.Drawing.Size(550, 40);
            this.txtInputCode.TabIndex = 0;
            this.txtInputCode.ToolTip = null;
            this.txtInputCode.Value = null;
            // 
            // lkuMaterialLot
            // 
            this.lkuMaterialLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lkuMaterialLot.LabelText = "Material Lot";
            this.lkuMaterialLot.Location = new System.Drawing.Point(556, 2);
            this.lkuMaterialLot.Margin = new System.Windows.Forms.Padding(2);
            this.lkuMaterialLot.Name = "lkuMaterialLot";
            this.lkuMaterialLot.Size = new System.Drawing.Size(550, 40);
            this.lkuMaterialLot.TabIndex = 1;
            this.lkuMaterialLot.Value = null;
            // 
            // txtDescription
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtDescription, 2);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.LabelText = "Description";
            this.txtDescription.Location = new System.Drawing.Point(2, 91);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(1104, 64);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Value = null;
            // 
            // lookupFromWareHouse
            // 
            this.lookupFromWareHouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookupFromWareHouse.LabelText = "From WareHouse";
            this.lookupFromWareHouse.Location = new System.Drawing.Point(2, 46);
            this.lookupFromWareHouse.Margin = new System.Windows.Forms.Padding(2);
            this.lookupFromWareHouse.Name = "lookupFromWareHouse";
            this.lookupFromWareHouse.Size = new System.Drawing.Size(550, 41);
            this.lookupFromWareHouse.TabIndex = 2;
            this.lookupFromWareHouse.Value = null;
            // 
            // lookupToWareHouse
            // 
            this.lookupToWareHouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookupToWareHouse.LabelText = "To WareHouse";
            this.lookupToWareHouse.Location = new System.Drawing.Point(556, 46);
            this.lookupToWareHouse.Margin = new System.Windows.Forms.Padding(2);
            this.lookupToWareHouse.Name = "lookupToWareHouse";
            this.lookupToWareHouse.Size = new System.Drawing.Size(550, 41);
            this.lookupToWareHouse.TabIndex = 3;
            this.lookupToWareHouse.Value = null;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.txtMedicineDose, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lkuMedicine, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtCurrentQuantity, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblUOM, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtUOM, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 185);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1114, 49);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // txtMedicineDose
            // 
            this.txtMedicineDose.Enabled = false;
            this.txtMedicineDose.IsCurrencyTextBox = false;
            this.txtMedicineDose.IsNumberOnly = false;
            this.txtMedicineDose.LabelText = "Medicine Dose";
            this.txtMedicineDose.Location = new System.Drawing.Point(863, 2);
            this.txtMedicineDose.Margin = new System.Windows.Forms.Padding(2);
            this.txtMedicineDose.Mask = "";
            this.txtMedicineDose.Name = "txtMedicineDose";
            this.txtMedicineDose.PasswordChar = '\0';
            this.txtMedicineDose.ReadOnly = true;
            this.txtMedicineDose.Size = new System.Drawing.Size(89, 41);
            this.txtMedicineDose.TabIndex = 2;
            this.txtMedicineDose.ToolTip = null;
            this.txtMedicineDose.Value = null;
            // 
            // lkuMedicine
            // 
            this.lkuMedicine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lkuMedicine.LabelText = "Medicines";
            this.lkuMedicine.Location = new System.Drawing.Point(2, 2);
            this.lkuMedicine.Margin = new System.Windows.Forms.Padding(2);
            this.lkuMedicine.Name = "lkuMedicine";
            this.lkuMedicine.Size = new System.Drawing.Size(703, 45);
            this.lkuMedicine.TabIndex = 0;
            this.lkuMedicine.Value = null;
            // 
            // txtCurrentQuantity
            // 
            this.txtCurrentQuantity.Enabled = false;
            this.txtCurrentQuantity.IsCurrencyTextBox = false;
            this.txtCurrentQuantity.IsNumberOnly = true;
            this.txtCurrentQuantity.LabelText = "Current Quantity";
            this.txtCurrentQuantity.Location = new System.Drawing.Point(956, 2);
            this.txtCurrentQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtCurrentQuantity.Mask = "";
            this.txtCurrentQuantity.Name = "txtCurrentQuantity";
            this.txtCurrentQuantity.PasswordChar = '\0';
            this.txtCurrentQuantity.ReadOnly = true;
            this.txtCurrentQuantity.Size = new System.Drawing.Size(95, 41);
            this.txtCurrentQuantity.TabIndex = 3;
            this.txtCurrentQuantity.ToolTip = null;
            this.txtCurrentQuantity.Value = null;
            // 
            // lblUOM
            // 
            this.lblUOM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUOM.Location = new System.Drawing.Point(1056, 18);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(55, 31);
            this.lblUOM.TabIndex = 4;
            // 
            // txtUOM
            // 
            this.txtUOM.Enabled = false;
            this.txtUOM.IsCurrencyTextBox = false;
            this.txtUOM.IsNumberOnly = false;
            this.txtUOM.LabelText = "UOM";
            this.txtUOM.Location = new System.Drawing.Point(709, 2);
            this.txtUOM.Margin = new System.Windows.Forms.Padding(2);
            this.txtUOM.Mask = "";
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.PasswordChar = '\0';
            this.txtUOM.ReadOnly = true;
            this.txtUOM.Size = new System.Drawing.Size(150, 41);
            this.txtUOM.TabIndex = 1;
            this.txtUOM.ToolTip = null;
            this.txtUOM.Value = null;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 319F));
            this.tableLayoutPanel4.Controls.Add(this.txtInputPrice, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtInputQuantity, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtpExpireDate, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtTaxRate, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 240);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(864, 45);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // txtInputPrice
            // 
            this.txtInputPrice.IsCurrencyTextBox = true;
            this.txtInputPrice.IsNumberOnly = false;
            this.txtInputPrice.LabelText = "Input Price";
            this.txtInputPrice.Location = new System.Drawing.Point(2, 2);
            this.txtInputPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtInputPrice.Mask = "";
            this.txtInputPrice.Name = "txtInputPrice";
            this.txtInputPrice.PasswordChar = '\0';
            this.txtInputPrice.Size = new System.Drawing.Size(105, 41);
            this.txtInputPrice.TabIndex = 0;
            this.txtInputPrice.ToolTip = null;
            this.txtInputPrice.Value = null;
            // 
            // txtInputQuantity
            // 
            this.txtInputQuantity.IsCurrencyTextBox = false;
            this.txtInputQuantity.IsNumberOnly = true;
            this.txtInputQuantity.LabelText = "Amount";
            this.txtInputQuantity.Location = new System.Drawing.Point(111, 2);
            this.txtInputQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtInputQuantity.Mask = "";
            this.txtInputQuantity.Name = "txtInputQuantity";
            this.txtInputQuantity.PasswordChar = '\0';
            this.txtInputQuantity.Size = new System.Drawing.Size(105, 41);
            this.txtInputQuantity.TabIndex = 1;
            this.txtInputQuantity.ToolTip = null;
            this.txtInputQuantity.Value = null;
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.LabelText = "Expire Date";
            this.dtpExpireDate.Location = new System.Drawing.Point(327, 2);
            this.dtpExpireDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpExpireDate.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpExpireDate.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Nullable = true;
            this.dtpExpireDate.Size = new System.Drawing.Size(206, 41);
            this.dtpExpireDate.TabIndex = 3;
            this.dtpExpireDate.Value = new System.DateTime(2012, 8, 5, 13, 54, 7, 386);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.51007F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.48993F));
            this.tableLayoutPanel6.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnLineCancel, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnImportExcel, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(548, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(298, 36);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(3, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImportExcel.Location = new System.Drawing.Point(60, 9);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(75, 24);
            this.btnImportExcel.TabIndex = 1;
            this.btnImportExcel.Text = "Import Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            // 
            // btnLineCancel
            // 
            this.btnLineCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLineCancel.Location = new System.Drawing.Point(141, 8);
            this.btnLineCancel.Name = "btnLineCancel";
            this.btnLineCancel.Size = new System.Drawing.Size(69, 25);
            this.btnLineCancel.TabIndex = 2;
            this.btnLineCancel.Text = "Cancel Edit";
            this.btnLineCancel.UseVisualStyleBackColor = true;
            this.btnLineCancel.Visible = false;
            this.btnLineCancel.Click += new System.EventHandler(this.btnLineCancel_Click);
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.IsCurrencyTextBox = false;
            this.txtTaxRate.IsNumberOnly = true;
            this.txtTaxRate.LabelText = "Tax Rate (%)";
            this.txtTaxRate.Location = new System.Drawing.Point(220, 2);
            this.txtTaxRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaxRate.Mask = "";
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.PasswordChar = '\0';
            this.txtTaxRate.Size = new System.Drawing.Size(103, 41);
            this.txtTaxRate.TabIndex = 2;
            this.txtTaxRate.ToolTip = null;
            this.txtTaxRate.Value = null;
            // 
            // tableView_Medicines
            // 
            this.tableView_Medicines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableView_Medicines.Location = new System.Drawing.Point(3, 291);
            this.tableView_Medicines.Name = "tableView_Medicines";
            this.tableView_Medicines.ReadOnly = false;
            this.tableView_Medicines.Size = new System.Drawing.Size(1114, 214);
            this.tableView_Medicines.TabIndex = 0;
            this.tableView_Medicines.SelectionChanged += new System.EventHandler(this.tableView_Medicines_SelectionChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel5.Controls.Add(this.btnOK, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnExportExcel, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 511);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1114, 32);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(956, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1037, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(3, 3);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 26);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            // 
            // StockTransactionEditorComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StockTransactionEditorComponentControl";
            this.Size = new System.Drawing.Size(1120, 546);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ClearCanvas.Desktop.View.WinForms.TextField txtInputCode;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lkuMaterialLot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ClearCanvas.Desktop.View.WinForms.TextField txtMedicineDose;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lkuMedicine;
        private ClearCanvas.Desktop.View.WinForms.TextField txtCurrentQuantity;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ClearCanvas.Desktop.View.WinForms.TextField txtInputPrice;
        private ClearCanvas.Desktop.View.WinForms.TextField txtInputQuantity;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField dtpExpireDate;
        private ClearCanvas.Desktop.View.WinForms.TableView tableView_Medicines;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnExportExcel;
        private ClearCanvas.Desktop.View.WinForms.TextField txtTaxRate;
        private ClearCanvas.Desktop.View.WinForms.TextField txtUOM;
        private ClearCanvas.Desktop.View.WinForms.TextAreaField txtDescription;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupFromWareHouse;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupToWareHouse;
        private System.Windows.Forms.Button btnLineCancel;

    }
}
