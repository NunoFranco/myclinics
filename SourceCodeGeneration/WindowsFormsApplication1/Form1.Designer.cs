namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddfiles = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEntityNS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCommonNS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServiceNS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComponentNS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComponentControlNS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProjectRoot = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Files";
            // 
            // lbFiles
            // 
            this.lbFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(12, 25);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFiles.Size = new System.Drawing.Size(412, 290);
            this.lbFiles.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnAddfiles
            // 
            this.btnAddfiles.Location = new System.Drawing.Point(196, 321);
            this.btnAddfiles.Name = "btnAddfiles";
            this.btnAddfiles.Size = new System.Drawing.Size(75, 23);
            this.btnAddfiles.TabIndex = 2;
            this.btnAddfiles.Text = "Add Files";
            this.btnAddfiles.UseVisualStyleBackColor = true;
            this.btnAddfiles.Click += new System.EventHandler(this.btnAddfiles_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(271, 321);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Suffix Namespace";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(590, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "File name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Entity Namespace";
            // 
            // txtEntityNS
            // 
            this.txtEntityNS.Location = new System.Drawing.Point(590, 25);
            this.txtEntityNS.Name = "txtEntityNS";
            this.txtEntityNS.Size = new System.Drawing.Size(226, 20);
            this.txtEntityNS.TabIndex = 5;
            this.txtEntityNS.Text = "ClearCanvas.Healthcare";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Common Namespace";
            // 
            // txtCommonNS
            // 
            this.txtCommonNS.Location = new System.Drawing.Point(590, 51);
            this.txtCommonNS.Name = "txtCommonNS";
            this.txtCommonNS.Size = new System.Drawing.Size(226, 20);
            this.txtCommonNS.TabIndex = 5;
            this.txtCommonNS.Text = "ClearCanvas.Ris.Application.Common";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Services Namespace";
            // 
            // txtServiceNS
            // 
            this.txtServiceNS.Location = new System.Drawing.Point(590, 77);
            this.txtServiceNS.Name = "txtServiceNS";
            this.txtServiceNS.Size = new System.Drawing.Size(226, 20);
            this.txtServiceNS.TabIndex = 5;
            this.txtServiceNS.Text = "ClearCanvas.Ris.Application.Services";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Component Namespace";
            // 
            // txtComponentNS
            // 
            this.txtComponentNS.Location = new System.Drawing.Point(590, 103);
            this.txtComponentNS.Name = "txtComponentNS";
            this.txtComponentNS.Size = new System.Drawing.Size(226, 20);
            this.txtComponentNS.TabIndex = 5;
            this.txtComponentNS.Text = "ClearCanvas.Ris.Client";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Component Control Namespace";
            // 
            // txtComponentControlNS
            // 
            this.txtComponentControlNS.Location = new System.Drawing.Point(590, 129);
            this.txtComponentControlNS.Name = "txtComponentControlNS";
            this.txtComponentControlNS.Size = new System.Drawing.Size(226, 20);
            this.txtComponentControlNS.TabIndex = 5;
            this.txtComponentControlNS.Text = "ClearCanvas.Ris.Client.View.Winforms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(430, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Project Root";
            // 
            // txtProjectRoot
            // 
            this.txtProjectRoot.Location = new System.Drawing.Point(590, 155);
            this.txtProjectRoot.Name = "txtProjectRoot";
            this.txtProjectRoot.Size = new System.Drawing.Size(226, 20);
            this.txtProjectRoot.TabIndex = 5;
            this.txtProjectRoot.Text = "D:\\Myprojects\\Ris2sp1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Copy to";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-1, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Generate Part";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(72, 321);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 21);
            this.cboType.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 347);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEntityNS);
            this.Controls.Add(this.txtCommonNS);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServiceNS);
            this.Controls.Add(this.txtComponentNS);
            this.Controls.Add(this.txtComponentControlNS);
            this.Controls.Add(this.txtProjectRoot);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.btnAddfiles);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(490, 385);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btnAddfiles;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEntityNS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCommonNS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServiceNS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComponentNS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtComponentControlNS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProjectRoot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboType;
    }
}

