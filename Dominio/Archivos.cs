using System;
using System.IO;
using System.Linq;
using System.Timers;
using System.Diagnostics;
namespace DownloadManager.Dominio
{
    public class Archivos
    {
        Timer FileInput;
        private string _extension { get; set; }
        private FileInfo[] _Files { get; set; }
        private string[] NameFiles { get; set; }
        private EventLog Evento;
        public Archivos()
        {
            this._extension = Properties.Settings.Default.extensionFile.ToString();
        }
        public void ConfigureDirectory()
        {
			try
			{
                var directoryResponse = Properties.Settings.Default.directoryBase.ToString();

                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = directoryResponse;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                //watcher.Filter = extensionFile;

                watcher.Created += new FileSystemEventHandler(Onchanged);
                watcher.EnableRaisingEvents = true;

                Log("ConfigureDirectory up", EventLogEntryType.Information);
            }
			catch (Exception)
			{

				throw;
			}
        }
        private void Onchanged(object source, FileSystemEventArgs e)
        {
            string filesToIgnore = ".tmp";
            FileInput = new System.Timers.Timer();
            try
            {
                if (!filesToIgnore.Contains(e.Name))
                {
                   
                    FileInput.Interval = 5000;
                    FileInput.Elapsed += FileInput_Elapsed;
                    FileInput.Enabled = true;
                }else
                {
                    FileInput.Enabled = false;
                }

                
            }
            catch (Exception ex)
            {

                Log(ex.Message, EventLogEntryType.Information);

            }

        }

        private void FileInput_Elapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            try 
	        {	        
		       var directoryResponse = Properties.Settings.Default.directoryBase.ToString();
                Procesingfiles(directoryResponse);
            }
	        catch (Exception ex)
	         {
                Log(ex.Message, EventLogEntryType.Information);

            }
        }


        public void Procesingfiles(string path)
        {
            try
            {
                string PathNew;
                string PathOrigin;
                string PathDestino;
                DirectoryInfo di = new DirectoryInfo(path);
                _Files = di.GetFiles();

                int NumArchivos = _Files.Length;

                if (NumArchivos > 0)
                {
                    foreach (var file in _Files)
                    {
                        PathNew = path;
                        bool booldirectory = false;
                        string extesion = file.Extension;
                        switch (extesion)
                        {
                            
                            case var s when new[] { ".pdf", ".epub", ".azw", ".ibook", ".pdc" }.Contains(s):
                                PathNew += @"Lectura\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                    {
                                    PathOrigin = path + file.Name;
                                       PathDestino = PathNew + file.Name;
                                       booldirectory = movefile(PathOrigin, PathDestino);
                                    }
                                break;

                            case var s when new[] { ".txt", ".doc", ".docx", ".pdc", ".ppt", ".pptx", ".xlsx", ".xls", ".csv" }.Contains(s):
                                PathNew += @"Documentos\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                {
                                    PathOrigin = path + file.Name;
                                    PathDestino = PathNew + file.Name;
                                    booldirectory = movefile(PathOrigin, PathDestino);
                                }
                                break;
                            
                            case var s when new[] { ".jpg", ".gif", ".bmp", ".png", ".jpeg", ".PNG",".JPG",".JPEG" }.Contains(s):
                                PathNew += @"Imagenes\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                {
                                    PathOrigin = path + file.Name;
                                    PathDestino = PathNew + file.Name;
                                    booldirectory = movefile(PathOrigin, PathDestino);
                                }
                                break;
                           
                            case var s when new[] { ".avi", ".mp4", ".mpeg", ".mwv" }.Contains(s):
                                PathNew += @"Videos\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                {
                                    PathOrigin = path + file.Name;
                                    PathDestino = PathNew + file.Name;
                                    booldirectory = movefile(PathOrigin, PathDestino);
                                }
                                break;
                            
                            case var s when new[] { ".exe", ".bat", ".dll", ".sys", ".msi" }.Contains(s):
                                PathNew += @"Programas\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                {
                                    PathOrigin = path + file.Name;
                                    PathDestino = PathNew + file.Name;
                                    booldirectory = movefile(PathOrigin, PathDestino);
                                }
                                break;
                            
                            case var s when new[] { ".mp3", ".wav", ".wma" }.Contains(s):
                                PathNew += @"Audios\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                {
                                    PathOrigin = path + file.Name;
                                    PathDestino = PathNew + file.Name;
                                    booldirectory = movefile(PathOrigin, PathDestino);
                                }
                                break;
                            
                            case var s when new[] { ".zip", ".rar", ".tar" }.Contains(s):
                                PathNew += @"Comprimidos\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                {
                                    PathOrigin = path + file.Name;
                                    PathDestino = PathNew + file.Name;
                                    booldirectory = movefile(PathOrigin, PathDestino);
                                }
                                break;
                            
                            case var s when new[] { ".iso", ".mds", ".img" }.Contains(s):
                                PathNew += @"ImagenesDiscos\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                {
                                    PathOrigin = path + file.Name;
                                    PathDestino = PathNew + file.Name;
                                    booldirectory = movefile(PathOrigin, PathDestino);
                                }
                                break;
                            case ".tmp":
                                 break;
                            default:
                                PathNew += @"Otros\";
                                booldirectory = createdirectory(PathNew);
                                if (booldirectory)
                                {
                                    PathOrigin = path + file.Name;
                                    PathDestino = PathNew + file.Name;
                                    booldirectory = movefile(PathOrigin, PathDestino);
                                }
                                break;
                        }

                       
                    }

                }
            }
            catch (Exception ex)
            {

                Log(ex.Message, EventLogEntryType.Information);

            }
        }

        public bool createdirectory(string path)
        {
            bool RCreate = false;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    if (Directory.Exists(path))
                    {
                        RCreate = true;
                    }
                    else
                    {
                        RCreate = false;
                    }

                }
                else
                {
                    RCreate = true;
                }
            }
            catch (Exception ex)
            {

                Log(ex.Message, EventLogEntryType.Information);

            }
           

            return RCreate;
        }

        private bool movefile(string origen, string destino)
        {
            bool retorno = false;
            try
            {
                if (File.Exists(origen))
                {
                    File.Move(origen, destino);
                    retorno = true;
                }else
                {
                    retorno = false;
                }
                    
            }
            catch (Exception ex)
            {

                Log(ex.Message, EventLogEntryType.Information);
            }
            return retorno;
        }


        public void Log( string e, EventLogEntryType ev)
        {
            Evento = new EventLog();
            Evento.Source = "FileDownloadManager";
            Evento.WriteEntry("DirectoryListening: " + e, ev);
        }
    }
}
