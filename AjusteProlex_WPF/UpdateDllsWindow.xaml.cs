using System;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro;
using System.Diagnostics;
using System.Net;
using System.IO.Compression;
using System.Collections.Generic;

namespace AjusteProlex_WPF
{
    /// <summary>
    /// Interaction logic for UpdateDllsWindow.xaml
    /// </summary>
    public partial class UpdateDllsWindow : MetroWindow
    {
        public string ProlexPath { get; set; }
        public string AutomatizaPath { get; set; }
        public string UrlPath { get; set; }
        public string DownloadPath { get; set; }
        public string RootPath { get; set; }

        IProgress<DownloadProgressChangedEventArgs> progress;

        public UpdateDllsWindow()
        {
            InitializeComponent();
        }

        public void DownloadFileInBackground(string url, string path)
        {
            try
            {
                WebClient client = new WebClient();
                Uri uri = new Uri(url);

                client.DownloadFileCompleted += (sender, args) => UpdateDLLs();

                client.DownloadProgressChanged += (sender, args) =>
                {
                    progress.Report(args);
                };

                client.DownloadFileAsync(uri, path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DownloadDLLs()
        {
            RootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Automatiza", "Instalador");
            Directory.CreateDirectory(RootPath);

            var tempDebugDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Automatiza", "Instalador", "Debug");
            var tempReleaseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Automatiza", "Instalador", "Release");
            if (Directory.Exists(tempDebugDirectory))
            Directory.Delete(tempDebugDirectory,true);

            if (Directory.Exists(tempReleaseDirectory))
                Directory.Delete(tempReleaseDirectory,true);

            var downloadFileName = Path.GetFileName(UrlPath);
            DownloadPath = Path.Combine(RootPath, downloadFileName);

            progress = new Progress<DownloadProgressChangedEventArgs>(args =>
            {
                progressBar.Maximum = args.TotalBytesToReceive;
                progressBar.Value = args.BytesReceived;
            });

            DownloadFileInBackground(UrlPath, DownloadPath);
        }

        /*
        public void Backup()
        {
            var backupFolder = Path.Combine(RootPath, "BACKUP");
            Directory.CreateDirectory(backupFolder);
            var archiveName = "Backup.zip";

            List<string> exceptions = new List<string>();
            exceptions.Add(@"\Dados");

            int filesAdded = CreateArchive(backupFolder, exceptions, archiveName);
        }

        public static int CreateArchive(string folder, IList<string> exceptions, string archiveName)
        {
            int filesCount = 0;
            string folderFullPath = Path.GetFullPath(folder);
            string archivePath = Path.Combine(folderFullPath, archiveName);

            if (File.Exists(archiveName))
            {
                File.Delete(archivePath);
            }

            IEnumerable<string> files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories);
            using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Create))
            {
                foreach (string file in files)
                {
                    if (!Excluded(file, exceptions))
                    {
                        try
                        {
                            var addFile = Path.GetFullPath(file);
                            if (addFile != archivePath)
                            {
                                addFile = addFile.Substring(folderFullPath.Length + 1);
                                archive.CreateEntryFromFile(file, addFile);
                                filesCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            return filesCount;
        }

        public static bool Excluded(string file, IList<string> exceptions)
        {
            List<string> folderNames = (from folder in exceptions where folder.StartsWith(@"\") || folder.StartsWith(@"/") select folder).ToList<string>();
            if(!exceptions.Contains(Path.GetExtension(file)))
            {
                foreach (string folderException in folderNames)
                {
                    if(Path.GetDirectoryName(file).Contains(folderException))
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }
        */

        public void MoveToParent(string databaseFile)
        {
            AutomatizaPath = Path.GetDirectoryName(ProlexPath);
            var databaseNewFolder = Path.Combine(AutomatizaPath, "Banco de Dados");
            Directory.CreateDirectory(databaseNewFolder);
            var databaseNewLocation = Path.Combine(databaseNewFolder, databaseFile);
            var databaseOldLocation = Path.Combine(ProlexPath, $@"Dados\{databaseFile}");
            var databaseRescueFile = Path.Combine(databaseNewFolder, $"{databaseFile}.old");
            if (File.Exists(databaseNewLocation) && File.Exists(databaseOldLocation))
                File.Replace(databaseOldLocation, databaseNewLocation, databaseRescueFile, true);
            else if (File.Exists(databaseOldLocation))
                File.Move(databaseOldLocation, databaseNewLocation);
            else
                MessageBox.Show("Não há banco de dados para ser movido!", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Backup()
        {
            var timeStamp = DateTime.Now.ToString("yyyy.MM.dd.HH.mm");
            AutomatizaPath = Path.GetDirectoryName(ProlexPath);
            var backupFolder = Path.Combine(AutomatizaPath, "Backup");
            Directory.CreateDirectory(backupFolder);
            var backupDateTime = Path.Combine(backupFolder, timeStamp);

            Directory.Move(ProlexPath, backupDateTime);
        }

        public void UpdateDLLs()
        {
            try
            {
                MoveToParent("Prolex.fdb");

                Backup();

                ZipFile.ExtractToDirectory(DownloadPath, RootPath);
                if (Directory.Exists(ProlexPath))
                    Directory.Delete(ProlexPath);

                var directoryFileName = Path.GetFileNameWithoutExtension(DownloadPath);
                var directoryToMove = Path.Combine(RootPath, directoryFileName);
                Directory.Move(directoryToMove, ProlexPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ButtonUpdateProtesto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Prolex Protesto|Prolex.exe"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                ProlexPath = Path.GetDirectoryName(openFileDialog.FileName);
                UrlPath = @"";
                DownloadDLLs();
            }
        }

        public void ButtonUpdateTDPJ_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Prolex TDPJ|Prolex.exe"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                ProlexPath = Path.GetDirectoryName(openFileDialog.FileName);
                UrlPath = @"https://automatizasuporteftp.azurewebsites.net/files/prolexrtd/Debug.zip";
                DownloadDLLs();
            }
        }
    }
}
