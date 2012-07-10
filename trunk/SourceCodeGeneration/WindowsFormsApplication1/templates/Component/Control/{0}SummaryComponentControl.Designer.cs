namespace {$componentNS}.Admin.View.WinForms
{
    partial class DoctorPrescriptionSummaryComponentControl
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
            this._DoctorPrescriptionTableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.SuspendLayout();
            // 
            // _DoctorPrescriptionTableView
            // 
            this._DoctorPrescriptionTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DoctorPrescriptionTableView.Location = new System.Drawing.Point(0, 0);
            this._DoctorPrescriptionTableView.Name = "_DoctorPrescriptionTableView";
            this._DoctorPrescriptionTableView.ReadOnly = false;
            this._DoctorPrescriptionTableView.Size = new System.Drawing.Size(766, 423);
            this._DoctorPrescriptionTableView.TabIndex = 0;
            this._DoctorPrescriptionTableView.DoubleClick += new System.EventHandler(this._DoctorPrescriptionTableView_ItemDoubleClicked);
            this._DoctorPrescriptionTableView.SelectionChanged += new System.EventHandler(this._DoctorPrescriptionTableView_SelectionChanged);
            // 
            // DoctorPrescriptionSummaryComponentControl
            // 
            this.Controls.Add(this._DoctorPrescriptionTableView);
            this.Name = "DoctorPrescriptionSummaryComponentControl";
            this.Size = new System.Drawing.Size(766, 423);
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Panel panel1;
		private ClearCanvas.Desktop.View.WinForms.ComboBoxField _category;
		private System.Windows.Forms.Button _clearButton;
		private System.Windows.Forms.Button _searchButton;
        private ClearCanvas.Desktop.View.WinForms.TableView _DoctorPrescriptionTableView;
    }
}
