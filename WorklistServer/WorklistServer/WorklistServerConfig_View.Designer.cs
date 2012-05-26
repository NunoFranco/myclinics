namespace WorklistServer
{
    partial class WorklistServerConfig_View
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
            this.txtAE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ntiWorklistIco = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctmShowConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmHideConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Entity (AE) Title";
            // 
            // txtAE
            // 
            this.txtAE.Location = new System.Drawing.Point(152, 31);
            this.txtAE.Name = "txtAE";
            this.txtAE.Size = new System.Drawing.Size(162, 20);
            this.txtAE.TabIndex = 1;
            this.txtAE.Text = "WORKLIST_SV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Listening Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(152, 68);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(44, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "105";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "case sensity";
            // 
            // ntiWorklistIco
            // 
            this.ntiWorklistIco.ContextMenuStrip = this.contextMenuStrip1;
            this.ntiWorklistIco.Text = "notifyIcon1";
            this.ntiWorklistIco.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctmShowConfig,
            this.ctmHideConfig,
            this.ctmStart,
            this.ctmStop});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 92);
            // 
            // ctmShowConfig
            // 
            this.ctmShowConfig.Name = "ctmShowConfig";
            this.ctmShowConfig.Size = new System.Drawing.Size(170, 22);
            this.ctmShowConfig.Text = "Show Config View";
            this.ctmShowConfig.Click += new System.EventHandler(this.shToolStripMenuItem_Click);
            // 
            // ctmHideConfig
            // 
            this.ctmHideConfig.Name = "ctmHideConfig";
            this.ctmHideConfig.Size = new System.Drawing.Size(170, 22);
            this.ctmHideConfig.Text = "Hide Config View";
            this.ctmHideConfig.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ctmStart
            // 
            this.ctmStart.Name = "ctmStart";
            this.ctmStart.Size = new System.Drawing.Size(170, 22);
            this.ctmStart.Text = "Start";
            this.ctmStart.Click += new System.EventHandler(this.owToolStripMenuItem_Click);
            // 
            // ctmStop
            // 
            this.ctmStop.Name = "ctmStop";
            this.ctmStop.Size = new System.Drawing.Size(170, 22);
            this.ctmStop.Text = "Stop";
            this.ctmStop.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hide";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(82, 111);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(167, 111);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // WorklistServerConfig_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 146);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAE);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(407, 184);
            this.MinimumSize = new System.Drawing.Size(407, 184);
            this.Name = "WorklistServerConfig_View";
            this.Text = "Worklist server configuration";
            this.Load += new System.EventHandler(this.WorklistServerConfig_View_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorklistServerConfig_View_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon ntiWorklistIco;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctmShowConfig;
        private System.Windows.Forms.ToolStripMenuItem ctmStart;
        private System.Windows.Forms.ToolStripMenuItem ctmStop;
        private System.Windows.Forms.ToolStripMenuItem ctmHideConfig;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
    }
}

