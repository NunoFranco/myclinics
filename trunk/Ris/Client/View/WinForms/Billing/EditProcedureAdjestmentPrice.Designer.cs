namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    partial class EditProcedureAdjestmentPrice
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProcedureCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcedureName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBasePrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPriceAfterDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdjestment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPendingInsuranceAmount = new System.Windows.Forms.TextBox();
            this.btnConfirmInsurance = new System.Windows.Forms.Button();
            this.btnRejectInsurance = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(420, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(339, 115);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProcedureCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProcedureName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBasePrice, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPriceAfterDiscount, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAdjestment, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPendingInsuranceAmount, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-1, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.0303F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.9697F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 99);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Procedure Type Code";
            // 
            // txtProcedureCode
            // 
            this.txtProcedureCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcedureCode.Location = new System.Drawing.Point(124, 3);
            this.txtProcedureCode.Name = "txtProcedureCode";
            this.txtProcedureCode.ReadOnly = true;
            this.txtProcedureCode.Size = new System.Drawing.Size(115, 20);
            this.txtProcedureCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Procedure Type Name";
            // 
            // txtProcedureName
            // 
            this.txtProcedureName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcedureName.Location = new System.Drawing.Point(375, 3);
            this.txtProcedureName.Name = "txtProcedureName";
            this.txtProcedureName.ReadOnly = true;
            this.txtProcedureName.Size = new System.Drawing.Size(125, 20);
            this.txtProcedureName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Original Price";
            // 
            // txtBasePrice
            // 
            this.txtBasePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBasePrice.Location = new System.Drawing.Point(124, 41);
            this.txtBasePrice.Name = "txtBasePrice";
            this.txtBasePrice.ReadOnly = true;
            this.txtBasePrice.Size = new System.Drawing.Size(115, 20);
            this.txtBasePrice.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price After discount";
            // 
            // txtPriceAfterDiscount
            // 
            this.txtPriceAfterDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPriceAfterDiscount.Location = new System.Drawing.Point(375, 41);
            this.txtPriceAfterDiscount.Name = "txtPriceAfterDiscount";
            this.txtPriceAfterDiscount.ReadOnly = true;
            this.txtPriceAfterDiscount.Size = new System.Drawing.Size(125, 20);
            this.txtPriceAfterDiscount.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Adjustment price";
            // 
            // txtAdjestment
            // 
            this.txtAdjestment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAdjestment.Location = new System.Drawing.Point(124, 74);
            this.txtAdjestment.MaxLength = 14;
            this.txtAdjestment.Name = "txtAdjestment";
            this.txtAdjestment.Size = new System.Drawing.Size(115, 20);
            this.txtAdjestment.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "Pending Insurance Amount";
            // 
            // txtPendingInsuranceAmount
            // 
            this.txtPendingInsuranceAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPendingInsuranceAmount.Location = new System.Drawing.Point(375, 74);
            this.txtPendingInsuranceAmount.MaxLength = 14;
            this.txtPendingInsuranceAmount.Name = "txtPendingInsuranceAmount";
            this.txtPendingInsuranceAmount.Size = new System.Drawing.Size(125, 20);
            this.txtPendingInsuranceAmount.TabIndex = 10;
            // 
            // btnConfirmInsurance
            // 
            this.btnConfirmInsurance.Location = new System.Drawing.Point(4, 117);
            this.btnConfirmInsurance.Name = "btnConfirmInsurance";
            this.btnConfirmInsurance.Size = new System.Drawing.Size(119, 23);
            this.btnConfirmInsurance.TabIndex = 2;
            this.btnConfirmInsurance.Text = "Confirm Insurance";
            this.btnConfirmInsurance.UseVisualStyleBackColor = true;
            this.btnConfirmInsurance.Visible = false;
            this.btnConfirmInsurance.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRejectInsurance
            // 
            this.btnRejectInsurance.Location = new System.Drawing.Point(128, 117);
            this.btnRejectInsurance.Name = "btnRejectInsurance";
            this.btnRejectInsurance.Size = new System.Drawing.Size(110, 23);
            this.btnRejectInsurance.TabIndex = 3;
            this.btnRejectInsurance.Text = "Reject Insurance";
            this.btnRejectInsurance.UseVisualStyleBackColor = true;
            this.btnRejectInsurance.Click += new System.EventHandler(this.btnRejectInsurance_Click);
            // 
            // EditProcedureAdjestmentPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 146);
            this.Controls.Add(this.btnRejectInsurance);
            this.Controls.Add(this.btnConfirmInsurance);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.MaximumSize = new System.Drawing.Size(519, 184);
            this.MinimumSize = new System.Drawing.Size(519, 184);
            this.Name = "EditProcedureAdjestmentPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditProcedureAdjestmentPrice_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProcedureCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProcedureName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBasePrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPriceAfterDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdjestment;
        private System.Windows.Forms.Button btnConfirmInsurance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPendingInsuranceAmount;
        private System.Windows.Forms.Button btnRejectInsurance;
    }
}