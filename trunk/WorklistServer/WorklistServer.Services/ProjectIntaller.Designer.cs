namespace WorklistServer.Services
{
    partial class ProjectIntaller
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
            this._serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            this._serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // _serviceInstaller1
            // 
            this._serviceInstaller1.DisplayName = "Modality Worklist Service";
            this._serviceInstaller1.ServiceName = "MWL";
            // 
            // _serviceProcessInstaller1
            // 
            this._serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this._serviceProcessInstaller1.Password = null;
            this._serviceProcessInstaller1.Username = null;
            // 
            // ProjectIntaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this._serviceInstaller1,
            this._serviceProcessInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller _serviceInstaller1;
        private System.ServiceProcess.ServiceProcessInstaller _serviceProcessInstaller1;
    }
}