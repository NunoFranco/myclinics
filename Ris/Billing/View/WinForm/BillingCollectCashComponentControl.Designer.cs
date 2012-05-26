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
    partial class BillingCollectCashComponentControl
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listPatientWaiting = new ClearCanvas.Ris.Billing.View.WinForms.ListPatientControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listPatientPending = new ClearCanvas.Ris.Billing.View.WinForms.ListPatientControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listPatientFinished = new ClearCanvas.Ris.Billing.View.WinForms.ListPatientControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnFinshed = new System.Windows.Forms.Button();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotalCollectAmount = new DevExpress.XtraEditors.TextEdit();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalAdjestment = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtReceiveCash = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalDiscountAmount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtChanges = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotalInsuranceAmount = new System.Windows.Forms.TextBox();
            this.btnCollected = new System.Windows.Forms.Button();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalWaitingInsurance = new System.Windows.Forms.TextBox();
            this.billingInfoUserControl1 = new ClearCanvas.Ris.Billing.View.WinForms.BillingInfoUserControl();
            this.btnRefreshData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCollectAmount.Properties)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAdjestment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiveCash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDiscountAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChanges.Properties)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitContainer1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(15);
            this.panelControl1.Size = new System.Drawing.Size(907, 639);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(17, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(873, 605);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(249, 601);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listPatientWaiting);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(241, 575);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Waiting List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listPatientWaiting
            // 
            this.listPatientWaiting.CurrentRowIndex = 0;
            this.listPatientWaiting.CurrentSelectedOrder = null;
            this.listPatientWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPatientWaiting.Location = new System.Drawing.Point(3, 3);
            this.listPatientWaiting.Name = "listPatientWaiting";
            this.listPatientWaiting.PatientBillingStatus = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.WAITING;
            this.listPatientWaiting.Size = new System.Drawing.Size(235, 569);
            this.listPatientWaiting.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listPatientPending);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(241, 575);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pending List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listPatientPending
            // 
            this.listPatientPending.CurrentRowIndex = 0;
            this.listPatientPending.CurrentSelectedOrder = null;
            this.listPatientPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPatientPending.Location = new System.Drawing.Point(3, 3);
            this.listPatientPending.Name = "listPatientPending";
            this.listPatientPending.PatientBillingStatus = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.PENDING;
            this.listPatientPending.Size = new System.Drawing.Size(235, 569);
            this.listPatientPending.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listPatientFinished);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(241, 575);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "History";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listPatientFinished
            // 
            this.listPatientFinished.CurrentRowIndex = 0;
            this.listPatientFinished.CurrentSelectedOrder = null;
            this.listPatientFinished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPatientFinished.Location = new System.Drawing.Point(0, 0);
            this.listPatientFinished.Name = "listPatientFinished";
            this.listPatientFinished.PatientBillingStatus = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED;
            this.listPatientFinished.Size = new System.Drawing.Size(241, 575);
            this.listPatientFinished.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.billingInfoUserControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRefreshData, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.23461F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.77371F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(612, 601);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.tableLayoutPanel2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(3, 388);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(606, 210);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Cash Collect";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.45161F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9433962F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.01075F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(602, 186);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.67797F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.32203F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnFinshed, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelControl14, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 108);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(596, 75);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnPrint, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.simpleButton2, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(349, 42);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(159, 30);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 20);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrint.Location = new System.Drawing.Point(56, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(47, 20);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.Visible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton2.Location = new System.Drawing.Point(109, 3);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(47, 20);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Cancel";
            this.simpleButton2.Visible = false;
            // 
            // btnFinshed
            // 
            this.btnFinshed.Enabled = false;
            this.btnFinshed.Location = new System.Drawing.Point(3, 42);
            this.btnFinshed.Name = "btnFinshed";
            this.btnFinshed.Size = new System.Drawing.Size(75, 23);
            this.btnFinshed.TabIndex = 12;
            this.btnFinshed.Text = "Finished";
            this.btnFinshed.UseVisualStyleBackColor = true;
            this.btnFinshed.Visible = false;
            this.btnFinshed.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // labelControl14
            // 
            this.labelControl14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl14.Appearance.Options.UseTextOptions = true;
            this.labelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl14.Location = new System.Drawing.Point(238, 3);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(99, 13);
            this.labelControl14.TabIndex = 1;
            this.labelControl14.Text = "Total Collect Amount";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.25F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.75F));
            this.tableLayoutPanel7.Controls.Add(this.txtTotalCollectAmount, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.lblCurrency, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(349, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(240, 33);
            this.tableLayoutPanel7.TabIndex = 13;
            // 
            // txtTotalCollectAmount
            // 
            this.txtTotalCollectAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCollectAmount.Location = new System.Drawing.Point(3, 3);
            this.txtTotalCollectAmount.Name = "txtTotalCollectAmount";
            this.txtTotalCollectAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.txtTotalCollectAmount.Properties.Appearance.Options.UseFont = true;
            this.txtTotalCollectAmount.Properties.ReadOnly = true;
            this.txtTotalCollectAmount.Size = new System.Drawing.Size(177, 31);
            this.txtTotalCollectAmount.TabIndex = 7;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrency.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblCurrency.Location = new System.Drawing.Point(186, 0);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(51, 33);
            this.lblCurrency.TabIndex = 8;
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl11.Appearance.BackColor = System.Drawing.Color.Black;
            this.labelControl11.Appearance.Options.UseBackColor = true;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Location = new System.Drawing.Point(3, 107);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(596, 1);
            this.labelControl11.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.08186F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.75092F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.57191F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.59532F));
            this.tableLayoutPanel5.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalAdjestment, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelControl12, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtReceiveCash, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalDiscountAmount, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.labelControl16, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.labelControl17, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtChanges, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.labelControl13, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtTotalWaitingInsurance, 3, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.23852F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.67347F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.7551F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(596, 98);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Total adjustment";
            // 
            // txtTotalAdjestment
            // 
            this.txtTotalAdjestment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAdjestment.Location = new System.Drawing.Point(122, 3);
            this.txtTotalAdjestment.Name = "txtTotalAdjestment";
            this.txtTotalAdjestment.Properties.ReadOnly = true;
            this.txtTotalAdjestment.Size = new System.Drawing.Size(171, 20);
            this.txtTotalAdjestment.TabIndex = 7;
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl12.Appearance.Options.UseTextOptions = true;
            this.labelControl12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl12.Location = new System.Drawing.Point(3, 31);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(98, 13);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Total Insurance Paid";
            // 
            // txtReceiveCash
            // 
            this.txtReceiveCash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceiveCash.Location = new System.Drawing.Point(122, 63);
            this.txtReceiveCash.Name = "txtReceiveCash";
            this.txtReceiveCash.Size = new System.Drawing.Size(171, 20);
            this.txtReceiveCash.TabIndex = 5;
            this.txtReceiveCash.EditValueChanged += new System.EventHandler(this.textEdit12_EditValueChanged);
            // 
            // txtTotalDiscountAmount
            // 
            this.txtTotalDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDiscountAmount.Location = new System.Drawing.Point(427, 31);
            this.txtTotalDiscountAmount.Name = "txtTotalDiscountAmount";
            this.txtTotalDiscountAmount.Properties.ReadOnly = true;
            this.txtTotalDiscountAmount.Size = new System.Drawing.Size(166, 20);
            this.txtTotalDiscountAmount.TabIndex = 7;
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl16.Appearance.Options.UseTextOptions = true;
            this.labelControl16.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl16.Location = new System.Drawing.Point(3, 63);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(106, 13);
            this.labelControl16.TabIndex = 8;
            this.labelControl16.Text = "Total Money Received";
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl17.Appearance.Options.UseTextOptions = true;
            this.labelControl17.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl17.Location = new System.Drawing.Point(299, 63);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(37, 13);
            this.labelControl17.TabIndex = 10;
            this.labelControl17.Text = "Change";
            // 
            // txtChanges
            // 
            this.txtChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChanges.Location = new System.Drawing.Point(427, 63);
            this.txtChanges.Name = "txtChanges";
            this.txtChanges.Properties.ReadOnly = true;
            this.txtChanges.Size = new System.Drawing.Size(166, 20);
            this.txtChanges.TabIndex = 11;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.65574F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.34426F));
            this.tableLayoutPanel6.Controls.Add(this.txtTotalInsuranceAmount, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnCollected, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(122, 31);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(171, 26);
            this.tableLayoutPanel6.TabIndex = 13;
            // 
            // txtTotalInsuranceAmount
            // 
            this.txtTotalInsuranceAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalInsuranceAmount.Location = new System.Drawing.Point(3, 3);
            this.txtTotalInsuranceAmount.Name = "txtTotalInsuranceAmount";
            this.txtTotalInsuranceAmount.ReadOnly = true;
            this.txtTotalInsuranceAmount.Size = new System.Drawing.Size(97, 20);
            this.txtTotalInsuranceAmount.TabIndex = 0;
            // 
            // btnCollected
            // 
            this.btnCollected.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCollected.Enabled = false;
            this.btnCollected.Location = new System.Drawing.Point(106, 3);
            this.btnCollected.Name = "btnCollected";
            this.btnCollected.Size = new System.Drawing.Size(62, 20);
            this.btnCollected.TabIndex = 1;
            this.btnCollected.Text = "Collected";
            this.btnCollected.UseVisualStyleBackColor = true;
            this.btnCollected.Visible = false;
            this.btnCollected.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl13.Appearance.Options.UseTextOptions = true;
            this.labelControl13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl13.Location = new System.Drawing.Point(299, 31);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(68, 13);
            this.labelControl13.TabIndex = 1;
            this.labelControl13.Text = "Total Discount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Total Pending insurance";
            // 
            // txtTotalWaitingInsurance
            // 
            this.txtTotalWaitingInsurance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalWaitingInsurance.Location = new System.Drawing.Point(427, 3);
            this.txtTotalWaitingInsurance.Name = "txtTotalWaitingInsurance";
            this.txtTotalWaitingInsurance.ReadOnly = true;
            this.txtTotalWaitingInsurance.Size = new System.Drawing.Size(166, 20);
            this.txtTotalWaitingInsurance.TabIndex = 15;
            // 
            // billingInfoUserControl1
            // 
            this.billingInfoUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.billingInfoUserControl1.CurrentOrderDetail = null;
            this.billingInfoUserControl1.CurrentSelectedOrder = null;
            this.billingInfoUserControl1.InvoiceNumber = "";
            this.billingInfoUserControl1.IsConfirmable = false;
            this.billingInfoUserControl1.IsEditable = false;
            this.billingInfoUserControl1.IsEditableInvoice = true;
            this.billingInfoUserControl1.IsHistoryOrder = false;
            this.billingInfoUserControl1.IsNewInvoice = false;
            this.billingInfoUserControl1.IsSelectableOrder = false;
            this.billingInfoUserControl1.ListOrderInvoiceHistoryProcedure = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfBindingGridColumns xmlns:xsi=\"ht" +
                "tp://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSc" +
                "hema\" />";
            this.billingInfoUserControl1.Location = new System.Drawing.Point(3, 33);
            this.billingInfoUserControl1.Name = "billingInfoUserControl1";
            this.billingInfoUserControl1.OrderNumber = null;
            this.billingInfoUserControl1.SelectedPatient = null;
            this.billingInfoUserControl1.Size = new System.Drawing.Size(606, 349);
            this.billingInfoUserControl1.TabIndex = 3;
            this.billingInfoUserControl1.TotalAdjestment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.billingInfoUserControl1.TotalChanges = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.billingInfoUserControl1.TotalCollect = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.billingInfoUserControl1.TotalDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.billingInfoUserControl1.TotalInsurance = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.billingInfoUserControl1.TotalReceived = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.billingInfoUserControl1.TotalWaitingInsurance = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.billingInfoUserControl1.OnBindingDataChanged += new System.EventHandler(this.billingInfoUserControl1_OnBindingDataChanged);
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshData.TabIndex = 4;
            this.btnRefreshData.Text = "Refresh";
            this.btnRefreshData.UseVisualStyleBackColor = true;
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // BillingCollectCashComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "BillingCollectCashComponentControl";
            this.Size = new System.Drawing.Size(907, 639);
            this.Load += new System.EventHandler(this.BillingCollectCashComponentControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCollectAmount.Properties)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAdjestment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiveCash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDiscountAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChanges.Properties)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ListPatientControl listPatientWaiting;
        private ListPatientControl listPatientPending;
        private ListPatientControl listPatientFinished;
        private BillingInfoUserControl billingInfoUserControl1;
        private System.Windows.Forms.Button btnRefreshData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Button btnFinshed;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.TextEdit txtTotalCollectAmount;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTotalAdjestment;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtReceiveCash;
        private DevExpress.XtraEditors.TextEdit txtTotalDiscountAmount;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit txtChanges;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox txtTotalInsuranceAmount;
        private System.Windows.Forms.Button btnCollected;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalWaitingInsurance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lblCurrency;
     
    }
}
