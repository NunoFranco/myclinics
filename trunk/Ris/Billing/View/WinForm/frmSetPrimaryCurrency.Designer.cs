namespace ClearCanvas.Ris.Billing.View.WinForms
{
    partial class frmSetPrimaryCurrency
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbNewPrimary = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this.txtPrimaryCurrency = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtPrimaryCurrnecyRate = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtSelectedRateToPrimaryExrate = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtPrimaryExRateCurrency = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.txtRate = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.cmbNewPrimaryExRate = new ClearCanvas.Desktop.View.WinForms.ComboBoxField();
            this.txtSelectedPrimaryExrateToExRate = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.tableLayoutPanel1.Controls.Add(this.cmbNewPrimary, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPrimaryCurrency, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrimaryCurrnecyRate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSelectedRateToPrimaryExrate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPrimaryExRateCurrency, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbNewPrimaryExRate, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSelectedPrimaryExrateToExRate, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.82609F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.17391F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 223);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(289, 188);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 32);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(95, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbNewPrimary
            // 
            this.cmbNewPrimary.DataSource = null;
            this.cmbNewPrimary.DisplayMember = "";
            this.cmbNewPrimary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNewPrimary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewPrimary.LabelText = "New Primary Currency";
            this.cmbNewPrimary.Location = new System.Drawing.Point(2, 91);
            this.cmbNewPrimary.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNewPrimary.Name = "cmbNewPrimary";
            this.cmbNewPrimary.Size = new System.Drawing.Size(282, 42);
            this.cmbNewPrimary.TabIndex = 2;
            this.cmbNewPrimary.Value = null;
            this.cmbNewPrimary.ValueChanged += new System.EventHandler(this.cmbNewPrimary_ValueChanged);
            // 
            // txtPrimaryCurrency
            // 
            this.txtPrimaryCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrimaryCurrency.LabelText = "Current Primary Currency";
            this.txtPrimaryCurrency.Location = new System.Drawing.Point(2, 2);
            this.txtPrimaryCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrimaryCurrency.Mask = "";
            this.txtPrimaryCurrency.Name = "txtPrimaryCurrency";
            this.txtPrimaryCurrency.PasswordChar = '\0';
            this.txtPrimaryCurrency.ReadOnly = true;
            this.txtPrimaryCurrency.Size = new System.Drawing.Size(282, 38);
            this.txtPrimaryCurrency.TabIndex = 3;
            this.txtPrimaryCurrency.ToolTip = null;
            this.txtPrimaryCurrency.Value = null;
            // 
            // txtPrimaryCurrnecyRate
            // 
            this.txtPrimaryCurrnecyRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrimaryCurrnecyRate.LabelText = "Rate To Primary Ex-Rate Currency";
            this.txtPrimaryCurrnecyRate.Location = new System.Drawing.Point(288, 2);
            this.txtPrimaryCurrnecyRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrimaryCurrnecyRate.Mask = "";
            this.txtPrimaryCurrnecyRate.Name = "txtPrimaryCurrnecyRate";
            this.txtPrimaryCurrnecyRate.PasswordChar = '\0';
            this.txtPrimaryCurrnecyRate.ReadOnly = true;
            this.txtPrimaryCurrnecyRate.Size = new System.Drawing.Size(331, 38);
            this.txtPrimaryCurrnecyRate.TabIndex = 3;
            this.txtPrimaryCurrnecyRate.ToolTip = null;
            this.txtPrimaryCurrnecyRate.Value = null;
            // 
            // txtSelectedRateToPrimaryExrate
            // 
            this.txtSelectedRateToPrimaryExrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSelectedRateToPrimaryExrate.LabelText = "Rate To Currenct Primary Ex-Rate";
            this.txtSelectedRateToPrimaryExrate.Location = new System.Drawing.Point(288, 91);
            this.txtSelectedRateToPrimaryExrate.Margin = new System.Windows.Forms.Padding(2);
            this.txtSelectedRateToPrimaryExrate.Mask = "";
            this.txtSelectedRateToPrimaryExrate.Name = "txtSelectedRateToPrimaryExrate";
            this.txtSelectedRateToPrimaryExrate.PasswordChar = '\0';
            this.txtSelectedRateToPrimaryExrate.Size = new System.Drawing.Size(331, 42);
            this.txtSelectedRateToPrimaryExrate.TabIndex = 3;
            this.txtSelectedRateToPrimaryExrate.ToolTip = null;
            this.txtSelectedRateToPrimaryExrate.Value = null;
            // 
            // txtPrimaryExRateCurrency
            // 
            this.txtPrimaryExRateCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrimaryExRateCurrency.LabelText = "Currenct Primary Ex-Rate ";
            this.txtPrimaryExRateCurrency.Location = new System.Drawing.Point(2, 44);
            this.txtPrimaryExRateCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrimaryExRateCurrency.Mask = "";
            this.txtPrimaryExRateCurrency.Name = "txtPrimaryExRateCurrency";
            this.txtPrimaryExRateCurrency.PasswordChar = '\0';
            this.txtPrimaryExRateCurrency.ReadOnly = true;
            this.txtPrimaryExRateCurrency.Size = new System.Drawing.Size(282, 43);
            this.txtPrimaryExRateCurrency.TabIndex = 4;
            this.txtPrimaryExRateCurrency.ToolTip = null;
            this.txtPrimaryExRateCurrency.Value = null;
            // 
            // txtRate
            // 
            this.txtRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRate.LabelText = "Primary Ex-Rate Currency Owner Rate";
            this.txtRate.Location = new System.Drawing.Point(288, 44);
            this.txtRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtRate.Mask = "";
            this.txtRate.Name = "txtRate";
            this.txtRate.PasswordChar = '\0';
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(331, 43);
            this.txtRate.TabIndex = 3;
            this.txtRate.ToolTip = null;
            this.txtRate.Value = null;
            // 
            // cmbNewPrimaryExRate
            // 
            this.cmbNewPrimaryExRate.DataSource = null;
            this.cmbNewPrimaryExRate.DisplayMember = "";
            this.cmbNewPrimaryExRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNewPrimaryExRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewPrimaryExRate.LabelText = "New Primary Ex-Rate Currency";
            this.cmbNewPrimaryExRate.Location = new System.Drawing.Point(2, 137);
            this.cmbNewPrimaryExRate.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNewPrimaryExRate.Name = "cmbNewPrimaryExRate";
            this.cmbNewPrimaryExRate.Size = new System.Drawing.Size(282, 46);
            this.cmbNewPrimaryExRate.TabIndex = 2;
            this.cmbNewPrimaryExRate.Value = null;
            this.cmbNewPrimaryExRate.ValueChanged += new System.EventHandler(this.cmbNewPrimaryExRate_ValueChanged);
            // 
            // txtSelectedPrimaryExrateToExRate
            // 
            this.txtSelectedPrimaryExrateToExRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSelectedPrimaryExrateToExRate.LabelText = "Rate To Current Primary Ex-Rate";
            this.txtSelectedPrimaryExrateToExRate.Location = new System.Drawing.Point(288, 137);
            this.txtSelectedPrimaryExrateToExRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtSelectedPrimaryExrateToExRate.Mask = "";
            this.txtSelectedPrimaryExrateToExRate.Name = "txtSelectedPrimaryExrateToExRate";
            this.txtSelectedPrimaryExrateToExRate.PasswordChar = '\0';
            this.txtSelectedPrimaryExrateToExRate.ReadOnly = true;
            this.txtSelectedPrimaryExrateToExRate.Size = new System.Drawing.Size(331, 46);
            this.txtSelectedPrimaryExrateToExRate.TabIndex = 3;
            this.txtSelectedPrimaryExrateToExRate.ToolTip = null;
            this.txtSelectedPrimaryExrateToExRate.Value = null;
            // 
            // frmSetPrimaryCurrency
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 223);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetPrimaryCurrency";
            this.Text = "Set Primary Currency";
            this.Load += new System.EventHandler(this.frmSetPrimaryCurrency_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClearCanvas.Desktop.View.WinForms.ComboBoxField cmbNewPrimary;
        private ClearCanvas.Desktop.View.WinForms.ComboBoxField cmbNewPrimaryExRate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ClearCanvas.Desktop.View.WinForms.TextField txtPrimaryCurrency;
        private ClearCanvas.Desktop.View.WinForms.TextField txtPrimaryExRateCurrency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private ClearCanvas.Desktop.View.WinForms.TextField txtPrimaryCurrnecyRate;
        private ClearCanvas.Desktop.View.WinForms.TextField txtRate;
        private ClearCanvas.Desktop.View.WinForms.TextField txtSelectedPrimaryExrateToExRate;
        private ClearCanvas.Desktop.View.WinForms.TextField txtSelectedRateToPrimaryExrate;
    }
}