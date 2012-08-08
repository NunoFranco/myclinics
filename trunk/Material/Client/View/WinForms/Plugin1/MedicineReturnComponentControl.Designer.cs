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
    partial class MedicineReturnComponentControl
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
            this.lookupTransactionCode = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this.tableview_TransactionLine = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotal = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtTotalPaid = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtTotalRefund = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lookupTransactionCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableview_TransactionLine, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(676, 505);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lookupTransactionCode
            // 
            this.lookupTransactionCode.LabelText = "Transaction Code";
            this.lookupTransactionCode.Location = new System.Drawing.Point(2, 2);
            this.lookupTransactionCode.Margin = new System.Windows.Forms.Padding(2);
            this.lookupTransactionCode.Name = "lookupTransactionCode";
            this.lookupTransactionCode.Size = new System.Drawing.Size(256, 41);
            this.lookupTransactionCode.TabIndex = 0;
            this.lookupTransactionCode.Value = null;
            // 
            // tableview_TransactionLine
            // 
            this.tableview_TransactionLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableview_TransactionLine.Location = new System.Drawing.Point(3, 48);
            this.tableview_TransactionLine.Name = "tableview_TransactionLine";
            this.tableview_TransactionLine.ReadOnly = false;
            this.tableview_TransactionLine.Size = new System.Drawing.Size(670, 349);
            this.tableview_TransactionLine.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Refund Information";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(473, 474);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 28);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(22, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "Refund";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 22);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel3.Controls.Add(this.txtTotal, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTotalPaid, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTotalRefund, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(664, 46);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txtTotal
            // 
            this.txtTotal.LabelText = "Total Cost";
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
            // txtTotalPaid
            // 
            this.txtTotalPaid.LabelText = "Total Paid";
            this.txtTotalPaid.Location = new System.Drawing.Point(250, 2);
            this.txtTotalPaid.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalPaid.Mask = "";
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.PasswordChar = '\0';
            this.txtTotalPaid.Size = new System.Drawing.Size(150, 41);
            this.txtTotalPaid.TabIndex = 1;
            this.txtTotalPaid.ToolTip = null;
            this.txtTotalPaid.Value = null;
            // 
            // txtTotalRefund
            // 
            this.txtTotalRefund.LabelText = "Amount (Refund)";
            this.txtTotalRefund.Location = new System.Drawing.Point(498, 2);
            this.txtTotalRefund.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalRefund.Mask = "";
            this.txtTotalRefund.Name = "txtTotalRefund";
            this.txtTotalRefund.PasswordChar = '\0';
            this.txtTotalRefund.Size = new System.Drawing.Size(150, 41);
            this.txtTotalRefund.TabIndex = 2;
            this.txtTotalRefund.ToolTip = null;
            this.txtTotalRefund.Value = null;
            // 
            // MedicineReturnComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MedicineReturnComponentControl";
            this.Size = new System.Drawing.Size(676, 505);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField lookupTransactionCode;
        private ClearCanvas.Desktop.View.WinForms.TableView tableview_TransactionLine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ClearCanvas.Desktop.View.WinForms.TextField txtTotal;
        private ClearCanvas.Desktop.View.WinForms.TextField txtTotalPaid;
        private ClearCanvas.Desktop.View.WinForms.TextField txtTotalRefund;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;



    }
}
