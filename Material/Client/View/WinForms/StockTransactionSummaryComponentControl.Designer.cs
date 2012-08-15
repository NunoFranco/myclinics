namespace ClearCanvas.Material.Client.View.WinForms
{
    partial class StockTransactionSummaryComponentControl
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
            this._StockTransactionTableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.SuspendLayout();
            // 
            // _StockTransactionTableView
            // 
            this._StockTransactionTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._StockTransactionTableView.Location = new System.Drawing.Point(0, 0);
            this._StockTransactionTableView.Name = "_StockTransactionTableView";
            this._StockTransactionTableView.ReadOnly = false;
            this._StockTransactionTableView.Size = new System.Drawing.Size(766, 423);
            this._StockTransactionTableView.TabIndex = 0;
            this._StockTransactionTableView.DoubleClick += new System.EventHandler(this._StockTransactionTableView_ItemDoubleClicked);
            this._StockTransactionTableView.SelectionChanged += new System.EventHandler(this._StockTransactionTableView_SelectionChanged);
            // 
            // StockTransactionSummaryComponentControl
            // 
            this.Controls.Add(this._StockTransactionTableView);
            this.Name = "StockTransactionSummaryComponentControl";
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
        private ClearCanvas.Desktop.View.WinForms.TableView _StockTransactionTableView;
    }
}
