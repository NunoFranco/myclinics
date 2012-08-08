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

namespace ClearCanvas.Material.Client.View.Winforms
{
    partial class MedicineSoldOutNoOrderComponentControl
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
            this.txtOutTransactionCode = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtBuyerName = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lookupMedicine = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.cmbMaterialLot = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this.txtAmount = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddMedicine = new System.Windows.Forms.Button();
            this.btnDeleteMedicine = new System.Windows.Forms.Button();
            this.txtSubTotal = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtUnitPrice = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotal = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtTotalReceive = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtTotalChange = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this._tableView_Medicines = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this._tableView_Medicines, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(591, 517);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buyer Information";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtOutTransactionCode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBuyerName, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(579, 47);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtOutTransactionCode
            // 
            this.txtOutTransactionCode.LabelText = "Id";
            this.txtOutTransactionCode.Location = new System.Drawing.Point(2, 2);
            this.txtOutTransactionCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutTransactionCode.Mask = "";
            this.txtOutTransactionCode.Name = "txtOutTransactionCode";
            this.txtOutTransactionCode.PasswordChar = '\0';
            this.txtOutTransactionCode.Size = new System.Drawing.Size(150, 41);
            this.txtOutTransactionCode.TabIndex = 0;
            this.txtOutTransactionCode.ToolTip = null;
            this.txtOutTransactionCode.Value = null;
            // 
            // txtBuyerName
            // 
            this.txtBuyerName.LabelText = "Buyer Name";
            this.txtBuyerName.Location = new System.Drawing.Point(291, 2);
            this.txtBuyerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuyerName.Mask = "";
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.PasswordChar = '\0';
            this.txtBuyerName.Size = new System.Drawing.Size(150, 41);
            this.txtBuyerName.TabIndex = 1;
            this.txtBuyerName.ToolTip = null;
            this.txtBuyerName.Value = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Medicine Information";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.07235F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.92765F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel3.Controls.Add(this.lookupMedicine, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbMaterialLot, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtAmount, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtSubTotal, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtUnitPrice, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(579, 81);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lookupMedicine
            // 
            this.lookupMedicine.LabelText = "Medicine";
            this.lookupMedicine.Location = new System.Drawing.Point(2, 2);
            this.lookupMedicine.Margin = new System.Windows.Forms.Padding(2);
            this.lookupMedicine.Name = "lookupMedicine";
            this.lookupMedicine.Size = new System.Drawing.Size(176, 41);
            this.lookupMedicine.TabIndex = 0;
            this.lookupMedicine.Value = null;
            // 
            // cmbMaterialLot
            // 
            this.cmbMaterialLot.DataSource = null;
            this.cmbMaterialLot.DisplayMember = "";
            this.cmbMaterialLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterialLot.LabelText = "Material Lot";
            this.cmbMaterialLot.Location = new System.Drawing.Point(186, 2);
            this.cmbMaterialLot.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMaterialLot.Name = "cmbMaterialLot";
            this.cmbMaterialLot.Size = new System.Drawing.Size(140, 41);
            this.cmbMaterialLot.TabIndex = 1;
            this.cmbMaterialLot.Value = null;
            // 
            // txtAmount
            // 
            this.txtAmount.LabelText = "Amount";
            this.txtAmount.Location = new System.Drawing.Point(330, 2);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.Mask = "";
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.Size = new System.Drawing.Size(81, 41);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.ToolTip = null;
            this.txtAmount.Value = null;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel6, 5);
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel6.Controls.Add(this.btnAddMedicine, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnDeleteMedicine, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(573, 31);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // btnAddMedicine
            // 
            this.btnAddMedicine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMedicine.Location = new System.Drawing.Point(388, 3);
            this.btnAddMedicine.Name = "btnAddMedicine";
            this.btnAddMedicine.Size = new System.Drawing.Size(85, 23);
            this.btnAddMedicine.TabIndex = 0;
            this.btnAddMedicine.Text = "Save";
            this.btnAddMedicine.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMedicine
            // 
            this.btnDeleteMedicine.Location = new System.Drawing.Point(479, 3);
            this.btnDeleteMedicine.Name = "btnDeleteMedicine";
            this.btnDeleteMedicine.Size = new System.Drawing.Size(84, 23);
            this.btnDeleteMedicine.TabIndex = 1;
            this.btnDeleteMedicine.Text = "Delete";
            this.btnDeleteMedicine.UseVisualStyleBackColor = true;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.LabelText = "Sub Total";
            this.txtSubTotal.Location = new System.Drawing.Point(499, 2);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubTotal.Mask = "";
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.PasswordChar = '\0';
            this.txtSubTotal.Size = new System.Drawing.Size(77, 41);
            this.txtSubTotal.TabIndex = 4;
            this.txtSubTotal.ToolTip = null;
            this.txtSubTotal.Value = null;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.LabelText = "Unit Price";
            this.txtUnitPrice.Location = new System.Drawing.Point(415, 2);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitPrice.Mask = "";
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.PasswordChar = '\0';
            this.txtUnitPrice.Size = new System.Drawing.Size(80, 41);
            this.txtUnitPrice.TabIndex = 3;
            this.txtUnitPrice.ToolTip = null;
            this.txtUnitPrice.Value = null;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 413);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Billing Information";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel4.Controls.Add(this.txtTotal, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtTotalReceive, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtTotalChange, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(579, 45);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // txtTotal
            // 
            this.txtTotal.LabelText = "Total";
            this.txtTotal.Location = new System.Drawing.Point(2, 2);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Mask = "";
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.PasswordChar = '\0';
            this.txtTotal.Size = new System.Drawing.Size(150, 41);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.ToolTip = null;
            this.txtTotal.Value = null;
            // 
            // txtTotalReceive
            // 
            this.txtTotalReceive.LabelText = "Total Receive (Cash)";
            this.txtTotalReceive.Location = new System.Drawing.Point(239, 2);
            this.txtTotalReceive.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalReceive.Mask = "";
            this.txtTotalReceive.Name = "txtTotalReceive";
            this.txtTotalReceive.PasswordChar = '\0';
            this.txtTotalReceive.Size = new System.Drawing.Size(150, 41);
            this.txtTotalReceive.TabIndex = 1;
            this.txtTotalReceive.ToolTip = null;
            this.txtTotalReceive.Value = null;
            // 
            // txtTotalChange
            // 
            this.txtTotalChange.LabelText = "Total Change(Cash)";
            this.txtTotalChange.Location = new System.Drawing.Point(476, 2);
            this.txtTotalChange.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalChange.Mask = "";
            this.txtTotalChange.Name = "txtTotalChange";
            this.txtTotalChange.PasswordChar = '\0';
            this.txtTotalChange.Size = new System.Drawing.Size(101, 41);
            this.txtTotalChange.TabIndex = 2;
            this.txtTotalChange.ToolTip = null;
            this.txtTotalChange.Value = null;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnPrintInvoice, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 483);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(585, 31);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(426, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(507, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Location = new System.Drawing.Point(3, 3);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(75, 25);
            this.btnPrintInvoice.TabIndex = 2;
            this.btnPrintInvoice.Text = "&Print";
            this.btnPrintInvoice.UseVisualStyleBackColor = true;
            // 
            // _tableView_Medicines
            // 
            this._tableView_Medicines.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableView_Medicines.Location = new System.Drawing.Point(3, 181);
            this._tableView_Medicines.Name = "_tableView_Medicines";
            this._tableView_Medicines.ReadOnly = false;
            this._tableView_Medicines.Size = new System.Drawing.Size(585, 226);
            this._tableView_Medicines.TabIndex = 0;
            // 
            // MedicineSoldOutNoOrderComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MedicineSoldOutNoOrderComponentControl";
            this.Size = new System.Drawing.Size(591, 517);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private ClearCanvas.Desktop.View.WinForms.TextField txtOutTransactionCode;
        private ClearCanvas.Desktop.View.WinForms.TextField txtBuyerName;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupMedicine;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField cmbMaterialLot;
        private ClearCanvas.Desktop.View.WinForms.TextField txtAmount;
        private ClearCanvas.Desktop.View.WinForms.TextField txtUnitPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnAddMedicine;
        private System.Windows.Forms.Button btnDeleteMedicine;
        private ClearCanvas.Desktop.View.WinForms.TextField txtTotal;
        private ClearCanvas.Desktop.View.WinForms.TextField txtTotalReceive;
        private ClearCanvas.Desktop.View.WinForms.TextField txtTotalChange;
        private System.Windows.Forms.Button btnPrintInvoice;
        private ClearCanvas.Desktop.View.WinForms.TextField txtSubTotal;
        private ClearCanvas.Desktop.View.WinForms.TableView _tableView_Medicines;
    }
}
