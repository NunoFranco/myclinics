namespace ClearCanvas.Ris.Billing.View.WinForms
{
    partial class PrintDoctorForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Doctor1 = new ClearCanvas.Ris.Billing.View.WinForms.reports.Doctor();
            this.lbFamilyName = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.cmbPractitioner = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.EnableDrillDown = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 47);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.Doctor1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(796, 527);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // lbFamilyName
            // 
            this.lbFamilyName.AutoSize = true;
            this.lbFamilyName.Location = new System.Drawing.Point(12, 15);
            this.lbFamilyName.Name = "lbFamilyName";
            this.lbFamilyName.Size = new System.Drawing.Size(67, 13);
            this.lbFamilyName.TabIndex = 2;
            this.lbFamilyName.Text = "Family Name";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(217, 15);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(84, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "View Report";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // cmbPractitioner
            // 
            this.cmbPractitioner.FormattingEnabled = true;
            this.cmbPractitioner.Location = new System.Drawing.Point(85, 15);
            this.cmbPractitioner.Name = "cmbPractitioner";
            this.cmbPractitioner.Size = new System.Drawing.Size(126, 21);
            this.cmbPractitioner.TabIndex = 16;
            // 
            // PrintDoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 574);
            this.Controls.Add(this.cmbPractitioner);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.lbFamilyName);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "PrintDoctorForm";
            this.Text = "PrintDoctorForm";
            this.Load += new System.EventHandler(this.PrintDoctorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private ClearCanvas.Ris.Billing.View.WinForms.reports.Doctor Doctor1;
        private System.Windows.Forms.Label lbFamilyName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox cmbPractitioner;
    }
}