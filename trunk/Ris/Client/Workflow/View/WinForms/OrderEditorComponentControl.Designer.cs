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

namespace ClearCanvas.Ris.Client.Workflow.View.WinForms
{
    partial class OrderEditorComponentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderEditorComponentControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._indication = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this._visit = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._visitSummaryButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._proceduresTableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this._orderNotesTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._consultantContactPoint = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._consultantLookup = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this._recipientsTableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this._addConsultantButton = new System.Windows.Forms.Button();
            this._DiagnosticResult = new System.Windows.Forms.TabPage();
            this._Prescription = new System.Windows.Forms.TabPage();
            this._prscriptionTableview = new ClearCanvas.Desktop.View.WinForms.TableView();
            this._schedulingRequestTime = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this._schedulingRequestDate = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this._orderingFacility = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.panel1 = new System.Windows.Forms.Panel();
            this._orderNumber = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._StaffGroup = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this._doctor = new ClearCanvas.Ris.Client.View.WinForms.LookupField();
            this._rightHandPanel = new System.Windows.Forms.Panel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._acceptButton = new System.Windows.Forms.Button();
            this._overviewLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._bannerPanel = new System.Windows.Forms.Panel();
            this._txtDiagnosticResult = new ClearCanvas.Desktop.View.WinForms.TextAreaField();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._DiagnosticResult.SuspendLayout();
            this._Prescription.SuspendLayout();
            this.panel1.SuspendLayout();
            this._overviewLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._rightHandPanel);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this._indication, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.tabControl1, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this._schedulingRequestTime, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this._schedulingRequestDate, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this._orderingFacility, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this._StaffGroup, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this._doctor, 1, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // _indication
            // 
            resources.ApplyResources(this._indication, "_indication");
            this.tableLayoutPanel3.SetColumnSpan(this._indication, 2);
            this._indication.Mask = "";
            this._indication.Name = "_indication";
            this._indication.PasswordChar = '\0';
            this._indication.ToolTip = null;
            this._indication.Value = null;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.Controls.Add(this._visit, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this._visitSummaryButton, 1, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // _visit
            // 
            this._visit.DataSource = null;
            this._visit.DisplayMember = "";
            resources.ApplyResources(this._visit, "_visit");
            this._visit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._visit.Name = "_visit";
            this._visit.Value = null;
            // 
            // _visitSummaryButton
            // 
            resources.ApplyResources(this._visitSummaryButton, "_visitSummaryButton");
            this._visitSummaryButton.Name = "_visitSummaryButton";
            this._visitSummaryButton.UseVisualStyleBackColor = true;
            this._visitSummaryButton.Click += new System.EventHandler(this._visitSummaryButton_Click);
            // 
            // tabControl1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this._orderNotesTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this._DiagnosticResult);
            this.tabControl1.Controls.Add(this._Prescription);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._proceduresTableView);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _proceduresTableView
            // 
            resources.ApplyResources(this._proceduresTableView, "_proceduresTableView");
            this._proceduresTableView.FilterTextBoxWidth = 132;
            this._proceduresTableView.MultiSelect = false;
            this._proceduresTableView.Name = "_proceduresTableView";
            this._proceduresTableView.ReadOnly = false;
            this._proceduresTableView.ShowToolbar = false;
            this._proceduresTableView.ItemDoubleClicked += new System.EventHandler(this._proceduresTableView_ItemDoubleClicked);
            // 
            // _orderNotesTab
            // 
            resources.ApplyResources(this._orderNotesTab, "_orderNotesTab");
            this._orderNotesTab.Name = "_orderNotesTab";
            this._orderNotesTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this._consultantContactPoint, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._consultantLookup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._recipientsTableView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._addConsultantButton, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // _consultantContactPoint
            // 
            resources.ApplyResources(this._consultantContactPoint, "_consultantContactPoint");
            this._consultantContactPoint.DataSource = null;
            this._consultantContactPoint.DisplayMember = "";
            this._consultantContactPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._consultantContactPoint.Name = "_consultantContactPoint";
            this._consultantContactPoint.Value = null;
            // 
            // _consultantLookup
            // 
            resources.ApplyResources(this._consultantLookup, "_consultantLookup");
            this._consultantLookup.Name = "_consultantLookup";
            this._consultantLookup.Value = null;
            // 
            // _recipientsTableView
            // 
            resources.ApplyResources(this._recipientsTableView, "_recipientsTableView");
            this.tableLayoutPanel1.SetColumnSpan(this._recipientsTableView, 2);
            this._recipientsTableView.FilterTextBoxWidth = 132;
            this._recipientsTableView.MultiSelect = false;
            this._recipientsTableView.Name = "_recipientsTableView";
            this._recipientsTableView.ReadOnly = false;
            this._recipientsTableView.ShowToolbar = false;
            // 
            // _addConsultantButton
            // 
            resources.ApplyResources(this._addConsultantButton, "_addConsultantButton");
            this._addConsultantButton.Name = "_addConsultantButton";
            this._addConsultantButton.UseVisualStyleBackColor = true;
            this._addConsultantButton.Click += new System.EventHandler(this._addConsultantButton_Click);
            // 
            // _DiagnosticResult
            // 
            this._DiagnosticResult.Controls.Add(this._txtDiagnosticResult);
            resources.ApplyResources(this._DiagnosticResult, "_DiagnosticResult");
            this._DiagnosticResult.Name = "_DiagnosticResult";
            this._DiagnosticResult.UseVisualStyleBackColor = true;
            // 
            // _Prescription
            // 
            this._Prescription.Controls.Add(this._prscriptionTableview);
            resources.ApplyResources(this._Prescription, "_Prescription");
            this._Prescription.Name = "_Prescription";
            this._Prescription.UseVisualStyleBackColor = true;
            // 
            // _prscriptionTableview
            // 
            resources.ApplyResources(this._prscriptionTableview, "_prscriptionTableview");
            this._prscriptionTableview.FilterTextBoxWidth = 132;
            this._prscriptionTableview.MultiSelect = false;
            this._prscriptionTableview.Name = "_prscriptionTableview";
            this._prscriptionTableview.ReadOnly = false;
            this._prscriptionTableview.ShowToolbar = false;
            // 
            // _schedulingRequestTime
            // 
            resources.ApplyResources(this._schedulingRequestTime, "_schedulingRequestTime");
            this._schedulingRequestTime.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._schedulingRequestTime.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._schedulingRequestTime.Name = "_schedulingRequestTime";
            this._schedulingRequestTime.Nullable = true;
            this._schedulingRequestTime.ShowDate = false;
            this._schedulingRequestTime.ShowTime = true;
            this._schedulingRequestTime.Value = null;
            // 
            // _schedulingRequestDate
            // 
            resources.ApplyResources(this._schedulingRequestDate, "_schedulingRequestDate");
            this._schedulingRequestDate.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._schedulingRequestDate.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._schedulingRequestDate.Name = "_schedulingRequestDate";
            this._schedulingRequestDate.Nullable = true;
            this._schedulingRequestDate.Value = null;
            // 
            // _orderingFacility
            // 
            resources.ApplyResources(this._orderingFacility, "_orderingFacility");
            this._orderingFacility.Mask = "";
            this._orderingFacility.Name = "_orderingFacility";
            this._orderingFacility.PasswordChar = '\0';
            this._orderingFacility.ReadOnly = true;
            this._orderingFacility.ToolTip = null;
            this._orderingFacility.Value = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._orderNumber);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // _orderNumber
            // 
            resources.ApplyResources(this._orderNumber, "_orderNumber");
            this._orderNumber.Mask = "";
            this._orderNumber.Name = "_orderNumber";
            this._orderNumber.PasswordChar = '\0';
            this._orderNumber.ReadOnly = true;
            this._orderNumber.ToolTip = null;
            this._orderNumber.Value = null;
            // 
            // _StaffGroup
            // 
            resources.ApplyResources(this._StaffGroup, "_StaffGroup");
            this._StaffGroup.Name = "_StaffGroup";
            this._StaffGroup.Value = null;
            // 
            // _doctor
            // 
            resources.ApplyResources(this._doctor, "_doctor");
            this._doctor.Name = "_doctor";
            this._doctor.Value = null;
            // 
            // _rightHandPanel
            // 
            resources.ApplyResources(this._rightHandPanel, "_rightHandPanel");
            this._rightHandPanel.Name = "_rightHandPanel";
            // 
            // _cancelButton
            // 
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _acceptButton
            // 
            resources.ApplyResources(this._acceptButton, "_acceptButton");
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this._placeOrderButton_Click);
            // 
            // _overviewLayoutPanel
            // 
            resources.ApplyResources(this._overviewLayoutPanel, "_overviewLayoutPanel");
            this._overviewLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this._overviewLayoutPanel.Controls.Add(this.splitContainer1, 0, 1);
            this._overviewLayoutPanel.Controls.Add(this._bannerPanel, 0, 0);
            this._overviewLayoutPanel.Name = "_overviewLayoutPanel";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this._cancelButton);
            this.flowLayoutPanel1.Controls.Add(this._acceptButton);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // _bannerPanel
            // 
            resources.ApplyResources(this._bannerPanel, "_bannerPanel");
            this._bannerPanel.Name = "_bannerPanel";
            // 
            // _txtDiagnosticResult
            // 
            resources.ApplyResources(this._txtDiagnosticResult, "_txtDiagnosticResult");
            this._txtDiagnosticResult.Name = "_txtDiagnosticResult";
            this._txtDiagnosticResult.Value = null;
            // 
            // OrderEditorComponentControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._overviewLayoutPanel);
            this.Name = "OrderEditorComponentControl";
            this.Load += new System.EventHandler(this.OrderEditorComponentControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this._DiagnosticResult.ResumeLayout(false);
            this._Prescription.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this._overviewLayoutPanel.ResumeLayout(false);
            this._overviewLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ClearCanvas.Desktop.View.WinForms.TableView _proceduresTableView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage _orderNotesTab;
        private System.Windows.Forms.TabPage tabPage2;
        private ClearCanvas.Desktop.View.WinForms.TableView _recipientsTableView;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _acceptButton;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField _StaffGroup;
        private System.Windows.Forms.Button _addConsultantButton;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField _consultantLookup;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _visit;
        private ClearCanvas.Ris.Client.View.WinForms.LookupField _doctor;
        private ClearCanvas.Desktop.View.WinForms.TextField _indication;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _schedulingRequestTime;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _schedulingRequestDate;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button _visitSummaryButton;
        private ClearCanvas.Desktop.View.WinForms.TextField _orderingFacility;
        private System.Windows.Forms.TableLayoutPanel _overviewLayoutPanel;
        private System.Windows.Forms.Panel _bannerPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel _rightHandPanel;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _consultantContactPoint;
        private System.Windows.Forms.Panel panel1;
        private ClearCanvas.Desktop.View.WinForms.TextField _orderNumber;
        private System.Windows.Forms.TabPage _DiagnosticResult;
        private System.Windows.Forms.TabPage _Prescription;
        private ClearCanvas.Desktop.View.WinForms.TableView _prscriptionTableview;
        private ClearCanvas.Desktop.View.WinForms.TextAreaField _txtDiagnosticResult;

    }
}
