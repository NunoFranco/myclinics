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

using System;
using System.Windows.Forms;

namespace ClearCanvas.Desktop.View.WinForms
{
    partial class DesktopForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer _components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
				if (_mainMenu != null)
				{
					_mainMenu.Dispose();
					_mainMenu = null;
				}

				if (_toolbar != null)
				{
					_toolbar.Dispose();
					_toolbar = null;
				}

				if (_toolStripContainer != null)
				{
					ToolStripSettings.Default.PropertyChanged -= OnToolStripSettingsPropertyChanged;

					_toolStripContainer.Dispose();
					_toolStripContainer = null;
				}

				if (_dockingManager != null)
				{
					_dockingManager.TabControlCreated -= OnDockingManagerTabControlCreated;
					_dockingManager.InnerControl = null;
					_dockingManager.Dispose();
					_dockingManager = null;
				}

				if (_tabbedGroups != null)
				{
					_tabbedGroups.TabControlCreated -= OnTabbedGroupsTabControlCreated;
					_tabbedGroups.Dispose();
					_tabbedGroups = null;
				}
				
				if (_components != null)
					_components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesktopForm));
            this._mainMenu = new System.Windows.Forms.MenuStrip();
            this._toolbar = new System.Windows.Forms.ToolStrip();
            this._toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this._tabbedGroups = new Crownwood.DotNetMagic.Controls.TabbedGroups();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this._toolStripContainer.ContentPanel.SuspendLayout();
            this._toolStripContainer.TopToolStripPanel.SuspendLayout();
            this._toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tabbedGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // _mainMenu
            // 
            this._mainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this._mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._mainMenu.Location = new System.Drawing.Point(0, 0);
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Size = new System.Drawing.Size(792, 24);
            this._mainMenu.TabIndex = 4;
            this._mainMenu.Text = "menuStrip1";
            // 
            // _toolbar
            // 
            this._toolbar.AllowItemReorder = true;
            this._toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this._toolbar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this._toolbar.Location = new System.Drawing.Point(0, 24);
            this._toolbar.Name = "_toolbar";
            this._toolbar.Size = new System.Drawing.Size(792, 25);
            this._toolbar.Stretch = true;
            this._toolbar.TabIndex = 4;
            this._toolbar.Text = "toolStrip1";
            // 
            // _toolStripContainer
            // 
            // 
            // _toolStripContainer.ContentPanel
            // 
            this._toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this._toolStripContainer.ContentPanel.Controls.Add(this._tabbedGroups);
            this._toolStripContainer.ContentPanel.Size = new System.Drawing.Size(792, 512);
            this._toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this._toolStripContainer.Name = "_toolStripContainer";
            this._toolStripContainer.Size = new System.Drawing.Size(792, 561);
            this._toolStripContainer.TabIndex = 5;
            this._toolStripContainer.Text = "toolStripContainer1";
            // 
            // _toolStripContainer.TopToolStripPanel
            // 
            this._toolStripContainer.TopToolStripPanel.Controls.Add(this._mainMenu);
            this._toolStripContainer.TopToolStripPanel.Controls.Add(this._toolbar);
            // 
            // _tabbedGroups
            // 
            this._tabbedGroups.AllowDrop = true;
            this._tabbedGroups.AtLeastOneLeaf = true;
            this._tabbedGroups.BackColor = System.Drawing.Color.Black;
            this._tabbedGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._tabbedGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabbedGroups.Location = new System.Drawing.Point(0, 0);
            this._tabbedGroups.Name = "_tabbedGroups";
            this._tabbedGroups.OfficeStyleNormal = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;
            this._tabbedGroups.OfficeStyleProminent = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;
            this._tabbedGroups.OfficeStyleSelected = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;
            this._tabbedGroups.ProminentLeaf = null;
            this._tabbedGroups.ResizeBarColor = System.Drawing.SystemColors.Control;
            this._tabbedGroups.Size = new System.Drawing.Size(792, 512);
            this._tabbedGroups.Style = Crownwood.DotNetMagic.Common.VisualStyle.IDE2005;
            this._tabbedGroups.TabIndex = 0;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonText = null;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.Size = new System.Drawing.Size(792, 141);
            this.ribbonControl1.Visible = false;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // DesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 561);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this._toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this._mainMenu;
            this.Name = "DesktopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style = Crownwood.DotNetMagic.Common.VisualStyle.IDE2005;
            this._toolStripContainer.ContentPanel.ResumeLayout(false);
            this._toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this._toolStripContainer.TopToolStripPanel.PerformLayout();
            this._toolStripContainer.ResumeLayout(false);
            this._toolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tabbedGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private MenuStrip _mainMenu;
		private ToolStrip _toolbar;
		private ToolStripContainer _toolStripContainer;
		private Crownwood.DotNetMagic.Controls.TabbedGroups _tabbedGroups;
		private Crownwood.DotNetMagic.Docking.DockingManager _dockingManager;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
	}
}
