namespace ClearCanvas.Ris.Billing.View.WinForms
{
    partial class FacilityForm
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
            this.Facility1 = new ClearCanvas.Ris.Billing.View.WinForms.reports.Facility();
            this.lbFacility = new System.Windows.Forms.Label();
            this.buttonFacility = new System.Windows.Forms.Button();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxFacility = new System.Windows.Forms.ComboBox();
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
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 44);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.Facility1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(796, 530);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // lbFacility
            // 
            this.lbFacility.AutoSize = true;
            this.lbFacility.Location = new System.Drawing.Point(18, 15);
            this.lbFacility.Name = "lbFacility";
            this.lbFacility.Size = new System.Drawing.Size(70, 13);
            this.lbFacility.TabIndex = 1;
            this.lbFacility.Text = "Facility Code:";
            // 
            // buttonFacility
            // 
            this.buttonFacility.Location = new System.Drawing.Point(728, 12);
            this.buttonFacility.Name = "buttonFacility";
            this.buttonFacility.Size = new System.Drawing.Size(75, 23);
            this.buttonFacility.TabIndex = 3;
            this.buttonFacility.Text = "View Report";
            this.buttonFacility.UseVisualStyleBackColor = true;
            this.buttonFacility.Click += new System.EventHandler(this.buttonFacility_Click);
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(218, 17);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(59, 13);
            this.lbFrom.TabIndex = 4;
            this.lbFrom.Text = "From Date:";
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(468, 17);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(49, 13);
            this.lbTo.TabIndex = 5;
            this.lbTo.Text = "To Date:";
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(275, 14);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(182, 20);
            this.fromDate.TabIndex = 6;
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(520, 14);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(181, 20);
            this.toDate.TabIndex = 7;
            // 
            // comboBoxFacility
            // 
            this.comboBoxFacility.FormattingEnabled = true;
            this.comboBoxFacility.Location = new System.Drawing.Point(91, 12);
            this.comboBoxFacility.Name = "comboBoxFacility";
            this.comboBoxFacility.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFacility.TabIndex = 8;
            // 
            // FacilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 574);
            this.Controls.Add(this.comboBoxFacility);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.buttonFacility);
            this.Controls.Add(this.lbFacility);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FacilityForm";
            this.Text = "FacilityForm";
            this.Load += new System.EventHandler(this.FacilityForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private ClearCanvas.Ris.Billing.View.WinForms.reports.Facility Facility1;
        private System.Windows.Forms.Label lbFacility;
        private System.Windows.Forms.Button buttonFacility;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.ComboBox comboBoxFacility;
    }
}