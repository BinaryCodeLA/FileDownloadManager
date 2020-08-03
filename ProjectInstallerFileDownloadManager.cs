using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace DownloadManager
{
    [RunInstaller(true)]
    public partial class ProjectInstallerFileDownloadManager : System.Configuration.Install.Installer
    {
        public ProjectInstallerFileDownloadManager()
        {
            InitializeComponent();
        }

        private void FileDownloadManager_AfterInstall(object sender, InstallEventArgs e)
        {
            new ServiceController(FileDownloadManager.ServiceName).Start();
        }
    }
}
