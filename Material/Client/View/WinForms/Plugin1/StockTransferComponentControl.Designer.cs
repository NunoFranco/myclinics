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
    partial class StockTransferComponentControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableView1 = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTransactionCode = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.lookupMaterialLot = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.lookupFromWareHouse = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.lookupToWareHouse = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lookupMedicines = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.txtUOM = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtMedicineDose = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtcurrentQuantity = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(743, 557);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail Information";
            // 
            // tableView1
            // 
            this.tableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableView1.Location = new System.Drawing.Point(3, 249);
            this.tableView1.Name = "tableView1";
            this.tableView1.ReadOnly = false;
            this.tableView1.Size = new System.Drawing.Size(737, 267);
            this.tableView1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 522);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(737, 32);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(578, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(659, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txtTransactionCode, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lookupMaterialLot, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lookupFromWareHouse, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lookupToWareHouse, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(731, 110);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txtTransactionCode
            // 
            this.txtTransactionCode.LabelText = "label";
            this.txtTransactionCode.Location = new System.Drawing.Point(2, 2);
            this.txtTransactionCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtTransactionCode.Mask = "";
            this.txtTransactionCode.Name = "txtTransactionCode";
            this.txtTransactionCode.PasswordChar = '\0';
            this.txtTransactionCode.Size = new System.Drawing.Size(150, 41);
            this.txtTransactionCode.TabIndex = 0;
            this.txtTransactionCode.ToolTip = null;
            this.txtTransactionCode.Value = null;
            // 
            // lookupMaterialLot
            // 
            this.lookupMaterialLot.LabelText = "label";
            this.lookupMaterialLot.Location = new System.Drawing.Point(367, 2);
            this.lookupMaterialLot.Margin = new System.Windows.Forms.Padding(2);
            this.lookupMaterialLot.Name = "lookupMaterialLot";
            this.lookupMaterialLot.Size = new System.Drawing.Size(176, 41);
            this.lookupMaterialLot.TabIndex = 1;
            this.lookupMaterialLot.Value = null;
            // 
            // lookupFromWareHouse
            // 
            this.lookupFromWareHouse.LabelText = "label";
            this.lookupFromWareHouse.Location = new System.Drawing.Point(2, 57);
            this.lookupFromWareHouse.Margin = new System.Windows.Forms.Padding(2);
            this.lookupFromWareHouse.Name = "lookupFromWareHouse";
            this.lookupFromWareHouse.Size = new System.Drawing.Size(176, 41);
            this.lookupFromWareHouse.TabIndex = 2;
            this.lookupFromWareHouse.Value = null;
            // 
            // lookupToWareHouse
            // 
            this.lookupToWareHouse.LabelText = "label";
            this.lookupToWareHouse.Location = new System.Drawing.Point(367, 57);
            this.lookupToWareHouse.Margin = new System.Windows.Forms.Padding(2);
            this.lookupToWareHouse.Name = "lookupToWareHouse";
            this.lookupToWareHouse.Size = new System.Drawing.Size(176, 41);
            this.lookupToWareHouse.TabIndex = 3;
            this.lookupToWareHouse.Value = null;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.91304F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.08696F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel4.Controls.Add(this.lookupMedicines, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtUOM, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtMedicineDose, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtcurrentQuantity, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(731, 86);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lookupMedicines
            // 
            this.lookupMedicines.LabelText = "label";
            this.lookupMedicines.Location = new System.Drawing.Point(2, 2);
            this.lookupMedicines.Margin = new System.Windows.Forms.Padding(2);
            this.lookupMedicines.Name = "lookupMedicines";
            this.lookupMedicines.Size = new System.Drawing.Size(176, 39);
            this.lookupMedicines.TabIndex = 0;
            this.lookupMedicines.Value = null;
            // 
            // txtUOM
            // 
            this.txtUOM.LabelText = "label";
            this.txtUOM.Location = new System.Drawing.Point(196, 2);
            this.txtUOM.Margin = new System.Windows.Forms.Padding(2);
            this.txtUOM.Mask = "";
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.PasswordChar = '\0';
            this.txtUOM.Size = new System.Drawing.Size(150, 39);
            this.txtUOM.TabIndex = 1;
            this.txtUOM.ToolTip = null;
            this.txtUOM.Value = null;
            // 
            // txtMedicineDose
            // 
            this.txtMedicineDose.LabelText = "label";
            this.txtMedicineDose.Location = new System.Drawing.Point(445, 2);
            this.txtMedicineDose.Margin = new System.Windows.Forms.Padding(2);
            this.txtMedicineDose.Mask = "";
            this.txtMedicineDose.Name = "txtMedicineDose";
            this.txtMedicineDose.PasswordChar = '\0';
            this.txtMedicineDose.Size = new System.Drawing.Size(144, 39);
            this.txtMedicineDose.TabIndex = 2;
            this.txtMedicineDose.ToolTip = null;
            this.txtMedicineDose.Value = null;
            // 
            // txtcurrentQuantity
            // 
            this.txtcurrentQuantity.LabelText = "label";
            this.txtcurrentQuantity.Location = new System.Drawing.Point(593, 2);
            this.txtcurrentQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtcurrentQuantity.Mask = "";
            this.txtcurrentQuantity.Name = "txtcurrentQuantity";
            this.txtcurrentQuantity.PasswordChar = '\0';
            this.txtcurrentQuantity.Size = new System.Drawing.Size(136, 39);
            this.txtcurrentQuantity.TabIndex = 3;
            this.txtcurrentQuantity.ToolTip = null;
            this.txtcurrentQuantity.Value = null;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // StockTransferComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StockTransferComponentControl";
            this.Size = new System.Drawing.Size(743, 557);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClearCanvas.Desktop.View.WinForms.TableView tableView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ClearCanvas.Desktop.View.WinForms.TextField txtTransactionCode;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupMaterialLot;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupFromWareHouse;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupToWareHouse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupMedicines;
        private ClearCanvas.Desktop.View.WinForms.TextField txtUOM;
        private ClearCanvas.Desktop.View.WinForms.TextField txtMedicineDose;
        private ClearCanvas.Desktop.View.WinForms.TextField txtcurrentQuantity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
