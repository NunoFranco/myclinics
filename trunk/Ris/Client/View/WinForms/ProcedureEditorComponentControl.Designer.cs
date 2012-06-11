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
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.Name = "_okButton";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _scheduledTime
            // 
            resources.ApplyResources(this._scheduledTime, "_scheduledTime");
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
            resources.ApplyResources(this._scheduledDate, "_scheduledDate");
            this._scheduledDate.Maximum = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this._scheduledDate.Minimum = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this._scheduledDate.Name = "_scheduledDate";
            this._scheduledDate.Nullable = true;
            this._scheduledDate.Value = null;
            // 
            // _procedureType
            // 
            resources.ApplyResources(this._procedureType, "_procedureType");
            this._procedureType.Name = "_procedureType";
            this._procedureType.Value = null;
            // 
            // _performingFacility
            // 
            this._performingFacility.DataSource = null;
            this._performingFacility.DisplayMember = "";
            this._performingFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this._performingFacility, "_performingFacility");
            this._performingFacility.Name = "_performingFacility";
            this._performingFacility.Value = null;
            // 
            // _laterality
            // 
            this._laterality.DataSource = null;
            this._laterality.DisplayMember = "";
            this._laterality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this._laterality, "_laterality");
            this._laterality.Name = "_laterality";
            this._laterality.Value = null;
            // 
            // _portable
            // 
            resources.ApplyResources(this._portable, "_portable");
            this._portable.Name = "_portable";
            this._portable.UseVisualStyleBackColor = true;
            // 
            // _checkedIn
            // 
            resources.ApplyResources(this._checkedIn, "_checkedIn");
            this._checkedIn.Name = "_checkedIn";
            this._checkedIn.UseVisualStyleBackColor = true;
            // 
            // ProcedureEditorComponentControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._checkedIn);
            this.Controls.Add(this._portable);
            this.Controls.Add(this._laterality);
            this.Controls.Add(this._performingFacility);
            this.Controls.Add(this._procedureType);
            this.Controls.Add(this._scheduledTime);
            this.Controls.Add(this._scheduledDate);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
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
