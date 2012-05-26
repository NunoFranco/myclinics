namespace ClearCanvas.Ris.Client.View.WinForms
{
    partial class ProcedureEditorComponentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcedureEditorComponentControl));
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._scheduledTime = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this._scheduledDate = new ClearCanvas.Desktop.View.WinForms.DateTimeField();
            this._procedureType = new ClearCanvas.Desktop.View.WinForms.SuggestComboField();
            this._performingFacility = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._laterality = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this._portable = new System.Windows.Forms.CheckBox();
            this._checkedIn = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.AccessibleDescription = null;
            this._okButton.AccessibleName = null;
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.BackgroundImage = null;
            this._okButton.Font = null;
            this._okButton.Name = "_okButton";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.AccessibleDescription = null;
            this._cancelButton.AccessibleName = null;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.BackgroundImage = null;
            this._cancelButton.Font = null;
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _scheduledTime
            // 
            this._scheduledTime.AccessibleDescription = null;
            this._scheduledTime.AccessibleName = null;
            resources.ApplyResources(this._scheduledTime, "_scheduledTime");
            this._scheduledTime.BackgroundImage = null;
            this._scheduledTime.Font = null;
            this._scheduledTime.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._scheduledTime.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._scheduledTime.Name = "_scheduledTime";
            this._scheduledTime.Nullable = true;
            this._scheduledTime.ShowDate = false;
            this._scheduledTime.ShowTime = true;
            this._scheduledTime.Value = null;
            // 
            // _scheduledDate
            // 
            this._scheduledDate.AccessibleDescription = null;
            this._scheduledDate.AccessibleName = null;
            resources.ApplyResources(this._scheduledDate, "_scheduledDate");
            this._scheduledDate.BackgroundImage = null;
            this._scheduledDate.Font = null;
            this._scheduledDate.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._scheduledDate.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._scheduledDate.Name = "_scheduledDate";
            this._scheduledDate.Nullable = true;
            this._scheduledDate.Value = null;
            // 
            // _procedureType
            // 
            this._procedureType.AccessibleDescription = null;
            this._procedureType.AccessibleName = null;
            resources.ApplyResources(this._procedureType, "_procedureType");
            this._procedureType.BackgroundImage = null;
            this._procedureType.Font = null;
            this._procedureType.Name = "_procedureType";
            this._procedureType.Value = null;
            // 
            // _performingFacility
            // 
            this._performingFacility.AccessibleDescription = null;
            this._performingFacility.AccessibleName = null;
            resources.ApplyResources(this._performingFacility, "_performingFacility");
            this._performingFacility.BackgroundImage = null;
            this._performingFacility.DataSource = null;
            this._performingFacility.DisplayMember = "";
            this._performingFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._performingFacility.Font = null;
            this._performingFacility.Name = "_performingFacility";
            this._performingFacility.Value = null;
            // 
            // _laterality
            // 
            this._laterality.AccessibleDescription = null;
            this._laterality.AccessibleName = null;
            resources.ApplyResources(this._laterality, "_laterality");
            this._laterality.BackgroundImage = null;
            this._laterality.DataSource = null;
            this._laterality.DisplayMember = "";
            this._laterality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._laterality.Font = null;
            this._laterality.Name = "_laterality";
            this._laterality.Value = null;
            // 
            // _portable
            // 
            this._portable.AccessibleDescription = null;
            this._portable.AccessibleName = null;
            resources.ApplyResources(this._portable, "_portable");
            this._portable.BackgroundImage = null;
            this._portable.Font = null;
            this._portable.Name = "_portable";
            this._portable.UseVisualStyleBackColor = true;
            // 
            // _checkedIn
            // 
            this._checkedIn.AccessibleDescription = null;
            this._checkedIn.AccessibleName = null;
            resources.ApplyResources(this._checkedIn, "_checkedIn");
            this._checkedIn.BackgroundImage = null;
            this._checkedIn.Font = null;
            this._checkedIn.Name = "_checkedIn";
            this._checkedIn.UseVisualStyleBackColor = true;
            // 
            // ProcedureEditorComponentControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this._checkedIn);
            this.Controls.Add(this._portable);
            this.Controls.Add(this._laterality);
            this.Controls.Add(this._performingFacility);
            this.Controls.Add(this._procedureType);
            this.Controls.Add(this._scheduledTime);
            this.Controls.Add(this._scheduledDate);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Font = null;
            this.Name = "ProcedureEditorComponentControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _scheduledTime;
        private ClearCanvas.Desktop.View.WinForms.DateTimeField _scheduledDate;
        private ClearCanvas.Desktop.View.WinForms.SuggestComboField _procedureType;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _performingFacility;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField _laterality;
        private System.Windows.Forms.CheckBox _portable;
		private System.Windows.Forms.CheckBox _checkedIn;
    }
}
