#region License

// Copyright (c) 2006-2008, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

namespace ClearCanvas.Desktop.View.WinForms
{
    partial class ExceptionHandlerComponentControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionHandlerComponentControl));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this._detailButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._description = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._warningIcon = new System.Windows.Forms.PictureBox();
            this._detailTree = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._warningIcon)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AccessibleDescription = null;
            this.flowLayoutPanel2.AccessibleName = null;
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.BackgroundImage = null;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this._detailButton);
            this.flowLayoutPanel2.Controls.Add(this._okButton);
            this.flowLayoutPanel2.Font = null;
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(432, 32);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // _detailButton
            // 
            this._detailButton.AccessibleDescription = null;
            this._detailButton.AccessibleName = null;
            resources.ApplyResources(this._detailButton, "_detailButton");
            this._detailButton.BackgroundImage = null;
            this._detailButton.Font = null;
            this._detailButton.Name = "_detailButton";
            this._detailButton.UseVisualStyleBackColor = true;
            this._detailButton.Click += new System.EventHandler(this._detailButton_Click);
            // 
            // _okButton
            // 
            this._okButton.AccessibleDescription = null;
            this._okButton.AccessibleName = null;
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.BackgroundImage = null;
            this._okButton.Font = null;
            this._okButton.Name = "_okButton";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _description
            // 
            this._description.AccessibleDescription = null;
            this._description.AccessibleName = null;
            resources.ApplyResources(this._description, "_description");
            this._description.BackgroundImage = null;
            this._description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._description.Font = null;
            this._description.MinimumSize = new System.Drawing.Size(394, 105);
            this._description.Name = "_description";
            this._description.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleDescription = null;
            this.tableLayoutPanel1.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackgroundImage = null;
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._warningIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._description, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._detailTree, 0, 2);
            this.tableLayoutPanel1.Font = null;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // _warningIcon
            // 
            this._warningIcon.AccessibleDescription = null;
            this._warningIcon.AccessibleName = null;
            resources.ApplyResources(this._warningIcon, "_warningIcon");
            this._warningIcon.BackgroundImage = null;
            this._warningIcon.Font = null;
            this._warningIcon.Image = global::ClearCanvas.Desktop.View.WinForms.SR.Stop;
            this._warningIcon.ImageLocation = null;
            this._warningIcon.Name = "_warningIcon";
            this._warningIcon.TabStop = false;
            // 
            // _detailTree
            // 
            this._detailTree.AccessibleDescription = null;
            this._detailTree.AccessibleName = null;
            resources.ApplyResources(this._detailTree, "_detailTree");
            this._detailTree.BackgroundImage = null;
            this.tableLayoutPanel1.SetColumnSpan(this._detailTree, 2);
            this._detailTree.Font = null;
            this._detailTree.Name = "_detailTree";
            this._detailTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this._detailTree_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AccessibleDescription = null;
            this.contextMenuStrip1.AccessibleName = null;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.BackgroundImage = null;
            this.contextMenuStrip1.Font = null;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.AccessibleDescription = null;
            this.copyToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.BackgroundImage = null;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // ExceptionHandlerComponentControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = null;
            this.MinimumSize = new System.Drawing.Size(440, 152);
            this.Name = "ExceptionHandlerComponentControl";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._warningIcon)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox _description;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button _detailButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.PictureBox _warningIcon;
        private System.Windows.Forms.TreeView _detailTree;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;


    }
}
