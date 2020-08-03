namespace DownloadManager
{
    partial class ProjectInstallerFileDownloadManager
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
            this.FileDownloadManagerProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.FileDownloadManager = new System.ServiceProcess.ServiceInstaller();
            // 
            // FileDownloadManagerProcessInstaller
            // 
            this.FileDownloadManagerProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.FileDownloadManagerProcessInstaller.Password = null;
            this.FileDownloadManagerProcessInstaller.Username = null;
            // 
            // FileDownloadManager
            // 
            this.FileDownloadManager.Description = "Manager Files Downloads";
            this.FileDownloadManager.ServiceName = "FileDownloadManager";
            this.FileDownloadManager.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.FileDownloadManager.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.FileDownloadManager_AfterInstall);
            // 
            // ProjectInstallerFileDownloadManager
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.FileDownloadManagerProcessInstaller,
            this.FileDownloadManager});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller FileDownloadManagerProcessInstaller;
        private System.ServiceProcess.ServiceInstaller FileDownloadManager;
    }
}