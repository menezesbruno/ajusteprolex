using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;

namespace AjusteProlex_WPF.Download
{
    public class Download
    {
        public bool SilentInstallation { get; set; }
        public string ServicePath { get; set; }
        public string DownloadedFile { get; set; }
        public string OriginalHash { get; set; }

        // Link para o Firebird 3 x86 e seu verificador MD5
        public string Url_X86 = "https://ufpr.dl.sourceforge.net/project/firebird/firebird-win32/3.0.2-Release/Firebird-3.0.2.32703_0_Win32.exe";
        public string OriginalHash_X86 = "4302570b19bf9c313ec9182702df6683";

        // Link para o Firebird 3 x64 e seu verificador MD5
        public string Url_X64 = "http://ufpr.dl.sourceforge.net/project/firebird/firebird-win64/3.0.2-Release/Firebird-3.0.2.32703_0_x64.exe";
        public string OriginalHash_X64 = "059789514590bb351506c5721e3932d8";
        
        IProgress<DownloadProgressChangedEventArgs> Progress;
        DownloadWindow DownloadWindow;

        public void FirebirdDownload(string servicePath, bool silentInstallation)
        {
            DownloadWindow = new DownloadWindow(ServicePath);
            var progress = new Progress<DownloadProgressChangedEventArgs>(args =>
            {
                DownloadWindow.progressBar.Maximum = args.TotalBytesToReceive;
                DownloadWindow.progressBar.Value = args.BytesReceived;
            });

            DownloadWindow.Show();

            ServicePath = servicePath;
            SilentInstallation = silentInstallation;
            Progress = progress;
            var url = Url_X86;
            OriginalHash = OriginalHash_X86;

            var systemType = Environment.Is64BitOperatingSystem;
            if (systemType)
            {
                url = Url_X64;
                OriginalHash = OriginalHash_X64;
            }

            var downloadFileName = Path.GetFileName(url);
            DownloadedFile = Path.Combine(ServicePath, downloadFileName);
            if (File.Exists(DownloadedFile))
            {
                if (HashCheck.Check(DownloadedFile, OriginalHash))
                {
                    MessageBox.Show($"O {downloadFileName} foi localizado e está pronto para ser instalado.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    InstallFirebird();
                }
                else
                {
                    MessageBox.Show($"O arquivo {downloadFileName} anteriormente baixado não passou no teste. Um novo download será feito.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    DownloadFileInBackground(url, DownloadedFile);
                }
            }
            else
                DownloadFileInBackground(url, DownloadedFile);
        }

        public void InstallFirebird()
        {
            var installargsComponents = "/COMPONENTS=" + @"""ServerComponent,DevAdminComponent,ClientComponent""";
            var installargsTasks = " /TASKS=" + @"""UseSuperServerTask,UseServiceTask,AutoStartTask,MenuGroupTask,CopyFbClientToSysTask,CopyFbClientAsGds32Task,EnableLegacyClientAuth"""; //InstallCPLAppletTask
            var installargsSecurity = " /SYSDBAPASSWORD=masterkey";
            var installargsSilent = " /FORCE /SILENT /SP-";

            Process process = new Process();
            process.StartInfo.FileName = DownloadedFile;
            process.StartInfo.Arguments = installargsComponents;
            process.StartInfo.Arguments += installargsTasks;
            process.StartInfo.Arguments += installargsSecurity;
            if (SilentInstallation)
                process.StartInfo.Arguments += installargsSilent;

            process.Start();
            DownloadWindow.Close();
        }

        public void DownloadFileInBackground(string url, string path)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(url);

            client.DownloadFileCompleted += (sender, args) =>
            {
                if (HashCheck.Check(DownloadedFile, OriginalHash))
                {
                    var downloadFileName = Path.GetFileName(DownloadedFile);
                    MessageBox.Show($"Download do {downloadFileName} concluído sem erros.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    InstallFirebird();
                }
            };
            client.DownloadProgressChanged += (sender, args) => Progress.Report(args);
            client.DownloadFileAsync(uri, path);
        }
    }
}
