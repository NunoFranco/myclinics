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
    partial class PatientProfileDetailsEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientProfileDetailsEditorControl));
            this._middleName = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._givenName = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._familyName = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._sex = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._dateOfDeath = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._dateOfBirth = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._healthcard = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._mrnAuthority = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._insurer = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._mrn = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._healthcardExpiry = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this._healthcardVersionCode = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this._inSuranceClass = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._discountClass = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // _middleName
            // 
            this._middleName.AccessibleDescription = null;
            this._middleName.AccessibleName = null;
            resources.ApplyResources(this._middleName, "_middleName");
            this._middleName.BackgroundImage = null;
            this._middleName.Font = null;
            this._middleName.Mask = "";
            this._middleName.Name = "_middleName";
            this._middleName.PasswordChar = '\0';
            this._middleName.ToolTip = null;
            this._middleName.Value = null;
            // 
            // _givenName
            // 
            this._givenName.AccessibleDescription = null;
            this._givenName.AccessibleName = null;
            resources.ApplyResources(this._givenName, "_givenName");
            this._givenName.BackgroundImage = null;
            this._givenName.Font = null;
            this._givenName.Mask = "";
            this._givenName.Name = "_givenName";
            this._givenName.PasswordChar = '\0';
            this._givenName.ToolTip = null;
            this._givenName.Value = null;
            // 
            // _familyName
            // 
            this._familyName.AccessibleDescription = null;
            this._familyName.AccessibleName = null;
            resources.ApplyResources(this._familyName, "_familyName");
            this._familyName.BackgroundImage = null;
            this._familyName.Font = null;
            this._familyName.Mask = "";
            this._familyName.Name = "_familyName";
            this._familyName.PasswordChar = '\0';
            this._familyName.ToolTip = null;
            this._familyName.Value = null;
            // 
            // _sex
            // 
            this._sex.AccessibleDescription = null;
            this._sex.AccessibleName = null;
            resources.ApplyResources(this._sex, "_sex");
            this._sex.BackgroundImage = null;
            this._sex.DataSource = null;
            this._sex.DisplayMember = "";
            this._sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._sex.Font = null;
            this._sex.Name = "_sex";
            this._sex.Value = null;
            // 
            // _dateOfDeath
            // 
            this._dateOfDeath.AccessibleDescription = null;
            this._dateOfDeath.AccessibleName = null;
            resources.ApplyResources(this._dateOfDeath, "_dateOfDeath");
            this._dateOfDeath.BackgroundImage = null;
            this._dateOfDeath.Font = null;
            this._dateOfDeath.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._dateOfDeath.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._dateOfDeath.Name = "_dateOfDeath";
            this._dateOfDeath.Nullable = true;
            this._dateOfDeath.Value = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleDescription = null;
            this.tableLayoutPanel1.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackgroundImage = null;
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Font = null;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AccessibleDescription = null;
            this.tableLayoutPanel2.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.BackgroundImage = null;
            this.tableLayoutPanel2.Controls.Add(this._dateOfDeath, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this._familyName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this._givenName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this._sex, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this._middleName, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this._dateOfBirth, 1, 1);
            this.tableLayoutPanel2.Font = null;
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // _dateOfBirth
            // 
            this._dateOfBirth.AccessibleDescription = null;
            this._dateOfBirth.AccessibleName = null;
            resources.ApplyResources(this._dateOfBirth, "_dateOfBirth");
            this._dateOfBirth.BackgroundImage = null;
            this._dateOfBirth.Font = null;
            this._dateOfBirth.Mask = "";
            this._dateOfBirth.Name = "_dateOfBirth";
            this._dateOfBirth.PasswordChar = '\0';
            this._dateOfBirth.ToolTip = null;
            this._dateOfBirth.Value = null;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AccessibleDescription = null;
            this.tableLayoutPanel3.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.BackgroundImage = null;
            this.tableLayoutPanel3.Controls.Add(this._healthcard, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this._mrnAuthority, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this._insurer, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this._mrn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this._healthcardExpiry, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this._healthcardVersionCode, 1, 3);
            this.tableLayoutPanel3.Font = null;
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // _healthcard
            // 
            this._healthcard.AccessibleDescription = null;
            this._healthcard.AccessibleName = null;
            resources.ApplyResources(this._healthcard, "_healthcard");
            this._healthcard.BackgroundImage = null;
            this._healthcard.Font = null;
            this._healthcard.Mask = "";
            this._healthcard.Name = "_healthcard";
            this._healthcard.PasswordChar = '\0';
            this._healthcard.ToolTip = null;
            this._healthcard.Value = null;
            // 
            // _mrnAuthority
            // 
            this._mrnAuthority.AccessibleDescription = null;
            this._mrnAuthority.AccessibleName = null;
            resources.ApplyResources(this._mrnAuthority, "_mrnAuthority");
            this._mrnAuthority.BackgroundImage = null;
            this._mrnAuthority.DataSource = null;
            this._mrnAuthority.DisplayMember = "";
            this._mrnAuthority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._mrnAuthority.Font = null;
            this._mrnAuthority.Name = "_mrnAuthority";
            this._mrnAuthority.Value = null;
            // 
            // _insurer
            // 
            this._insurer.AccessibleDescription = null;
            this._insurer.AccessibleName = null;
            resources.ApplyResources(this._insurer, "_insurer");
            this._insurer.BackgroundImage = null;
            this._insurer.DataSource = null;
            this._insurer.DisplayMember = "";
            this._insurer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._insurer.Font = null;
            this._insurer.Name = "_insurer";
            this._insurer.Value = null;
            // 
            // _mrn
            // 
            this._mrn.AccessibleDescription = null;
            this._mrn.AccessibleName = null;
            resources.ApplyResources(this._mrn, "_mrn");
            this._mrn.BackgroundImage = null;
            this._mrn.Font = null;
            this._mrn.Mask = "";
            this._mrn.Name = "_mrn";
            this._mrn.PasswordChar = '\0';
            this._mrn.ToolTip = null;
            this._mrn.Value = null;
            // 
            // _healthcardExpiry
            // 
            this._healthcardExpiry.AccessibleDescription = null;
            this._healthcardExpiry.AccessibleName = null;
            resources.ApplyResources(this._healthcardExpiry, "_healthcardExpiry");
            this._healthcardExpiry.BackgroundImage = null;
            this._healthcardExpiry.Font = null;
            this._healthcardExpiry.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._healthcardExpiry.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._healthcardExpiry.Name = "_healthcardExpiry";
            this._healthcardExpiry.Nullable = true;
            this._healthcardExpiry.Value = null;
            // 
            // _healthcardVersionCode
            // 
            this._healthcardVersionCode.AccessibleDescription = null;
            this._healthcardVersionCode.AccessibleName = null;
            resources.ApplyResources(this._healthcardVersionCode, "_healthcardVersionCode");
            this._healthcardVersionCode.BackgroundImage = null;
            this._healthcardVersionCode.Font = null;
            this._healthcardVersionCode.Mask = "";
            this._healthcardVersionCode.Name = "_healthcardVersionCode";
            this._healthcardVersionCode.PasswordChar = '\0';
            this._healthcardVersionCode.ToolTip = null;
            this._healthcardVersionCode.Value = null;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AccessibleDescription = null;
            this.tableLayoutPanel4.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.BackgroundImage = null;
            this.tableLayoutPanel4.Controls.Add(this._inSuranceClass, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this._discountClass, 0, 1);
            this.tableLayoutPanel4.Font = null;
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // _inSuranceClass
            // 
            this._inSuranceClass.AccessibleDescription = null;
            this._inSuranceClass.AccessibleName = null;
            resources.ApplyResources(this._inSuranceClass, "_inSuranceClass");
            this._inSuranceClass.BackgroundImage = null;
            this._inSuranceClass.DataSource = null;
            this._inSuranceClass.DisplayMember = "";
            this._inSuranceClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._inSuranceClass.Font = null;
            this._inSuranceClass.Name = "_inSuranceClass";
            this._inSuranceClass.Value = null;
            // 
            // _discountClass
            // 
            this._discountClass.AccessibleDescription = null;
            this._discountClass.AccessibleName = null;
            resources.ApplyResources(this._discountClass, "_discountClass");
            this._discountClass.BackgroundImage = null;
            this._discountClass.DataSource = null;
            this._discountClass.DisplayMember = "";
            this._discountClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._discountClass.Font = null;
            this._discountClass.Name = "_discountClass";
            this._discountClass.Value = null;
            this._discountClass.ValueChanged += new System.EventHandler(this._discountInsuranceClass_ValueChanged);
            // 
            // PatientProfileDetailsEditorControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = null;
            this.Name = "PatientProfileDetailsEditorControl";
            this.Load += new System.EventHandler(this.PatientEditorControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClearCanvas.Desktop.View.WinForms.TextField _familyName;
        private ClearCanvas.Desktop.View.WinForms.TextField _givenName;
        private ClearCanvas.Desktop.View.WinForms.TextField _middleName;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _sex;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _dateOfDeath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ClearCanvas.Desktop.View.WinForms.TextField _mrn;
        private ClearCanvas.Desktop.View.WinForms.TextField _healthcard;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _mrnAuthority;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _insurer;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _healthcardExpiry;
        private ClearCanvas.Desktop.View.WinForms.TextField _healthcardVersionCode;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ClearCanvas.Desktop.View.WinForms.TextField _dateOfBirth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _discountClass;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _inSuranceClass;
    }
}