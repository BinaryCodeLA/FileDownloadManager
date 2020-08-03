using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DownloadManager.Dominio;

namespace DownloadManager
{
    public partial class FileDownloadManager : ServiceBase
    {
        public FileDownloadManager()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Archivos configuraListen = new Archivos();
            configuraListen.ConfigureDirectory();
        }

        protected override void OnStop()
        {
        }
    }
}
