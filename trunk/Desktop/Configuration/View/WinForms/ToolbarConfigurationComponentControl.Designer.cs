namespace ClearCanvas.Desktop.Configuration.View.WinForms {
	partial class ToolbarConfigurationComponentControl {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolbarConfigurationComponentControl));
            this._flowToolbarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._toolStripSizePanel = new System.Windows.Forms.Panel();
            this._toolbarSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._wrapPanel = new System.Windows.Forms.Panel();
            this._wrapToolbars = new System.Windows.Forms.CheckBox();
            this._flowToolbarPanel.SuspendLayout();
            this._toolStripSizePanel.SuspendLayout();
            this._wrapPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _flowToolbarPanel
            // 
            this._flowToolbarPanel.AccessibleDescription = null;
            this._flowToolbarPanel.AccessibleName = null;
            resources.ApplyResources(this._flowToolbarPanel, "_flowToolbarPanel");
            this._flowToolbarPanel.BackgroundImage = null;
            this._flowToolbarPanel.Controls.Add(this._toolStripSizePanel);
            this._flowToolbarPanel.Controls.Add(this._wrapPanel);
            this._flowToolbarPanel.Font = null;
            this._flowToolbarPanel.Name = "_flowToolbarPanel";
            // 
            // _toolStripSizePanel
            // 
            this._toolStripSizePanel.AccessibleDescription = null;
            this._toolStripSizePanel.AccessibleName = null;
            resources.ApplyResources(this._toolStripSizePanel, "_toolStripSizePanel");
            this._toolStripSizePanel.BackgroundImage = null;
            this._toolStripSizePanel.Controls.Add(this._toolbarSize);
            this._toolStripSizePanel.Controls.Add(this.label1);
            this._toolStripSizePanel.Font = null;
            this._toolStripSizePanel.Name = "_toolStripSizePanel";
            // 
            // _toolbarSize
            // 
            this._toolbarSize.AccessibleDescription = null;
            this._toolbarSize.AccessibleName = null;
            resources.ApplyResources(this._toolbarSize, "_toolbarSize");
            this._toolbarSize.BackgroundImage = null;
            this._toolbarSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._toolbarSize.Font = null;
            this._toolbarSize.FormattingEnabled = true;
            this._toolbarSize.Items.AddRange(new object[] {
            resources.GetString("_toolbarSize.Items"),
            resources.GetString("_toolbarSize.Items1"),
            resources.GetString("_toolbarSize.Items2")});
            this._toolbarSize.Name = "_toolbarSize";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // _wrapPanel
            // 
            this._wrapPanel.AccessibleDescription = null;
            this._wrapPanel.AccessibleName = null;
            resources.ApplyResources(this._wrapPanel, "_wrapPanel");
            this._wrapPanel.BackgroundImage = null;
            this._wrapPanel.Controls.Add(this._wrapToolbars);
            this._wrapPanel.Font = null;
            this._wrapPanel.Name = "_wrapPanel";
            // 
            // _wrapToolbars
            // 
            this._wrapToolbars.AccessibleDescription = null;
            this._wrapToolbars.AccessibleName = null;
            resources.ApplyResources(this._wrapToolbars, "_wrapToolbars");
            this._wrapToolbars.BackgroundImage = null;
            this._wrapToolbars.Font = null;
            this._wrapToolbars.Name = "_wrapToolbars";
            this._wrapToolbars.UseVisualStyleBackColor = true;
            // 
            // ToolbarConfigurationComponentControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this._flowToolbarPanel);
            this.Font = null;
            this.Name = "ToolbarConfigurationComponentControl";
            this._flowToolbarPanel.ResumeLayout(false);
            this._toolStripSizePanel.ResumeLayout(false);
            this._toolStripSizePanel.PerformLayout();
            this._wrapPanel.ResumeLayout(false);
            this._wrapPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox _wrapToolbars;
		private System.Windows.Forms.Panel _wrapPanel;
		private System.Windows.Forms.Panel _toolStripSizePanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _toolbarSize;
		private System.Windows.Forms.FlowLayoutPanel _flowToolbarPanel;
	}
}
