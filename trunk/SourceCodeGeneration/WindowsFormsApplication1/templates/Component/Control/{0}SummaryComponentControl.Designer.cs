namespace {$componentNS}.View.WinForms
{
    partial class {0}SummaryComponentControl
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
            this._{0}TableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.SuspendLayout();
            // 
            // _{0}TableView
            // 
            this._{0}TableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._{0}TableView.Location = new System.Drawing.Point(0, 0);
            this._{0}TableView.Name = "_{0}TableView";
            this._{0}TableView.ReadOnly = false;
            this._{0}TableView.Size = new System.Drawing.Size(766, 423);
            this._{0}TableView.TabIndex = 0;
            this._{0}TableView.DoubleClick += new System.EventHandler(this._{0}TableView_ItemDoubleClicked);
            this._{0}TableView.SelectionChanged += new System.EventHandler(this._{0}TableView_SelectionChanged);
            // 
            // {0}SummaryComponentControl
            // 
            this.Controls.Add(this._{0}TableView);
            this.Name = "{0}SummaryComponentControl";
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
        private ClearCanvas.Desktop.View.WinForms.TableView _{0}TableView;
    }
}
