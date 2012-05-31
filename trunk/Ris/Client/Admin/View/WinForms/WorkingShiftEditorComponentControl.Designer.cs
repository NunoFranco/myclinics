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

namespace ClearCanvas.Ris.Client.Admin.View.WinForms
{
    partial class WorkingShiftEditorComponentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkingShiftEditorComponentControl));
            this._txtName = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this._staffSelector = new ClearCanvas.Desktop.View.WinForms.ListItemSelector();
            this._dtpValidFrom = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this._dtpValidTo = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._chkSaturday = new System.Windows.Forms.CheckBox();
            this._chkFriday = new System.Windows.Forms.CheckBox();
            this._chkThursday = new System.Windows.Forms.CheckBox();
            this._chkWednesday = new System.Windows.Forms.CheckBox();
            this._chkTuesday = new System.Windows.Forms.CheckBox();
            this._chkMonday = new System.Windows.Forms.CheckBox();
            this._chkSunday = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this._dtpstartTime = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this._dtpEndTime = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this._cmbStartTimeType = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._cmbEndTimeType = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // _txtName
            // 
            resources.ApplyResources(this._txtName, "_txtName");
            this._txtName.Mask = "";
            this._txtName.Name = "_txtName";
            this._txtName.PasswordChar = '\0';
            this._txtName.ToolTip = null;
            this._txtName.Value = null;
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _staffSelector
            // 
            this._staffSelector.AvailableItemsTable = null;
            resources.ApplyResources(this._staffSelector, "_staffSelector");
            this._staffSelector.Name = "_staffSelector";
            this._staffSelector.ReadOnly = false;
            this._staffSelector.SelectedItemsTable = null;
            // 
            // _dtpValidFrom
            // 
            resources.ApplyResources(this._dtpValidFrom, "_dtpValidFrom");
            this._dtpValidFrom.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._dtpValidFrom.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._dtpValidFrom.Name = "_dtpValidFrom";
            this._dtpValidFrom.Nullable = true;
            this._dtpValidFrom.Value = new System.DateTime(2012, 5, 27, 14, 53, 30, 235);
            // 
            // _dtpValidTo
            // 
            resources.ApplyResources(this._dtpValidTo, "_dtpValidTo");
            this._dtpValidTo.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._dtpValidTo.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._dtpValidTo.Name = "_dtpValidTo";
            this._dtpValidTo.Nullable = true;
            this._dtpValidTo.Value = new System.DateTime(2012, 5, 27, 14, 53, 30, 235);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _chkSaturday
            // 
            resources.ApplyResources(this._chkSaturday, "_chkSaturday");
            this._chkSaturday.Name = "_chkSaturday";
            this._chkSaturday.UseVisualStyleBackColor = true;
            // 
            // _chkFriday
            // 
            resources.ApplyResources(this._chkFriday, "_chkFriday");
            this._chkFriday.Name = "_chkFriday";
            this._chkFriday.UseVisualStyleBackColor = true;
            // 
            // _chkThursday
            // 
            resources.ApplyResources(this._chkThursday, "_chkThursday");
            this._chkThursday.Name = "_chkThursday";
            this._chkThursday.UseVisualStyleBackColor = true;
            // 
            // _chkWednesday
            // 
            resources.ApplyResources(this._chkWednesday, "_chkWednesday");
            this._chkWednesday.Name = "_chkWednesday";
            this._chkWednesday.UseVisualStyleBackColor = true;
            // 
            // _chkTuesday
            // 
            resources.ApplyResources(this._chkTuesday, "_chkTuesday");
            this._chkTuesday.Name = "_chkTuesday";
            this._chkTuesday.UseVisualStyleBackColor = true;
            // 
            // _chkMonday
            // 
            resources.ApplyResources(this._chkMonday, "_chkMonday");
            this._chkMonday.Name = "_chkMonday";
            this._chkMonday.UseVisualStyleBackColor = true;
            // 
            // _chkSunday
            // 
            resources.ApplyResources(this._chkSunday, "_chkSunday");
            this._chkSunday.Name = "_chkSunday";
            this._chkSunday.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._staffSelector, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this._txtName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 2, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this._dtpValidFrom, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this._dtpValidTo, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnOk, 1, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this._chkSunday, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this._chkSaturday, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this._chkMonday, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this._chkFriday, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this._chkTuesday, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this._chkThursday, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this._chkWednesday, 3, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this._dtpstartTime, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this._cmbStartTimeType, 1, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // _dtpstartTime
            // 
            resources.ApplyResources(this._dtpstartTime, "_dtpstartTime");
            this._dtpstartTime.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._dtpstartTime.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._dtpstartTime.Name = "_dtpstartTime";
            this._dtpstartTime.ShowDate = false;
            this._dtpstartTime.ShowTime = true;
            this._dtpstartTime.Value = new System.DateTime(2012, 5, 27, 14, 53, 30, 235);
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this._dtpEndTime, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this._cmbEndTimeType, 1, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // _dtpEndTime
            // 
            resources.ApplyResources(this._dtpEndTime, "_dtpEndTime");
            this._dtpEndTime.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._dtpEndTime.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._dtpEndTime.Name = "_dtpEndTime";
            this._dtpEndTime.ShowDate = false;
            this._dtpEndTime.ShowTime = true;
            this._dtpEndTime.Value = new System.DateTime(2012, 5, 27, 14, 51, 20, 536);
            // 
            // _cmbStartTimeType
            // 
            this._cmbStartTimeType.DataSource = null;
            this._cmbStartTimeType.DisplayMember = "";
            resources.ApplyResources(this._cmbStartTimeType, "_cmbStartTimeType");
            this._cmbStartTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbStartTimeType.Name = "_cmbStartTimeType";
            this._cmbStartTimeType.Value = null;
            // 
            // _cmbEndTimeType
            // 
            this._cmbEndTimeType.DataSource = null;
            this._cmbEndTimeType.DisplayMember = "";
            resources.ApplyResources(this._cmbEndTimeType, "_cmbEndTimeType");
            this._cmbEndTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEndTimeType.Name = "_cmbEndTimeType";
            this._cmbEndTimeType.Value = null;
            // 
            // WorkingShiftEditorComponentControl
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WorkingShiftEditorComponentControl";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClearCanvas.Desktop.View.WinForms.TextField _txtName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private ClearCanvas.Desktop.View.WinForms.ListItemSelector _staffSelector;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _dtpValidFrom;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _dtpValidTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox _chkSaturday;
        private System.Windows.Forms.CheckBox _chkFriday;
        private System.Windows.Forms.CheckBox _chkThursday;
        private System.Windows.Forms.CheckBox _chkWednesday;
        private System.Windows.Forms.CheckBox _chkTuesday;
        private System.Windows.Forms.CheckBox _chkMonday;
        private System.Windows.Forms.CheckBox _chkSunday;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _dtpstartTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _dtpEndTime;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _cmbStartTimeType;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _cmbEndTimeType;
    }
}
