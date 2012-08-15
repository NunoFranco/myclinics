namespace ClearCanvas.Material.Client.View.WinForms
{
    partial class ContactSummaryComponentControl
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
            this._ContactTableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.SuspendLayout();
            // 
            // _ContactTableView
            // 
            this._ContactTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ContactTableView.Location = new System.Drawing.Point(0, 0);
            this._ContactTableView.Name = "_ContactTableView";
            this._ContactTableView.ReadOnly = false;
            this._ContactTableView.Size = new System.Drawing.Size(766, 423);
            this._ContactTableView.TabIndex = 0;
            this._ContactTableView.ItemDoubleClicked += new System.EventHandler(this._ContactTableView_ItemDoubleClicked);
            // 
            // ContactSummaryComponentControl
            // 
            this.Controls.Add(this._ContactTableView);
            this.Name = "ContactSummaryComponentControl";
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
        private ClearCanvas.Desktop.View.WinForms.TableView _ContactTableView;
    }
}
