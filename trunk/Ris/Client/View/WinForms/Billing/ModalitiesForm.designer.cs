namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    partial class ModalitiesForm
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
            this.Modalities1 = new ClearCanvas.Ris.Client.View.WinForms.Billing.reports.Modalities();
            this.cmbModalities = new System.Windows.Forms.ComboBox();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.lbTo = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.buttonFacility = new System.Windows.Forms.Button();
            this.lbFacility = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.EnableDrillDown = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(796, 574);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // cmbModalities
            // 
            this.cmbModalities.FormattingEnabled = true;
            this.cmbModalities.Location = new System.Drawing.Point(303, 30);
            this.cmbModalities.Name = "cmbModalities";
            this.cmbModalities.Size = new System.Drawing.Size(121, 21);
            this.cmbModalities.TabIndex = 15;
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(728, 31);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(180, 20);
            this.toDate.TabIndex = 14;
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(491, 31);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(179, 20);
            this.fromDate.TabIndex = 13;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(675, 34);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(49, 13);
            this.lbTo.TabIndex = 12;
            this.lbTo.Text = "To Date:";
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(430, 34);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(59, 13);
            this.lbFrom.TabIndex = 11;
            this.lbFrom.Text = "From Date:";
            // 
            // buttonFacility
            // 
            this.buttonFacility.Location = new System.Drawing.Point(912, 29);
            this.buttonFacility.Name = "buttonFacility";
            this.buttonFacility.Size = new System.Drawing.Size(75, 23);
            this.buttonFacility.TabIndex = 10;
            this.buttonFacility.Text = "View Report";
            this.buttonFacility.UseVisualStyleBackColor = true;
            this.buttonFacility.Click += new System.EventHandler(this.buttonFacility_Click);
            // 
            // lbFacility
            // 
            this.lbFacility.AutoSize = true;
            this.lbFacility.Location = new System.Drawing.Point(248, 34);
            this.lbFacility.Name = "lbFacility";
            this.lbFacility.Size = new System.Drawing.Size(52, 13);
            this.lbFacility.TabIndex = 9;
            this.lbFacility.Text = "Modality :";
            // 
            // ModalitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 574);
            this.Controls.Add(this.cmbModalities);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.buttonFacility);
            this.Controls.Add(this.lbFacility);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "ModalitiesForm";
            this.Text = "ModalitiesForm";
            this.Load += new System.EventHandler(this.ModalitiesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private ClearCanvas.Ris.Client.View.WinForms.Billing.reports.Modalities Modalities1;
        private System.Windows.Forms.ComboBox cmbModalities;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Button buttonFacility;
        private System.Windows.Forms.Label lbFacility;
    }
}