using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Threading.Tasks;

namespace AjusteProlex_WPF.Download
{
    public class Download
    {
        IProgress<DownloadProgressChangedEventArgs> Progress;

        public async Task FirebirdDownloadAsync(string servicePath, bool silentInstallation)
        {
            FirebirdDownloadWindow DownloadWindow;
            var firebird_Url_X86 = DownloadParameters.Instance.Firebird_Url_X86;
            var firebird_Hash_X86 = DownloadParameters.Instance.Firebird_Hash_X86;
            var firebird_Url_X64 = DownloadParameters.Instance.Firebird_Url_X64;
            var firebird_Hash_X64 = DownloadParameters.Instance.Firebird_Hash_X64;

            DownloadWindow = new FirebirdDownloadWindow(servicePath);
            var progress = new Progress<DownloadProgressChangedEventArgs>(args =>
            {
                DownloadWindow.progressBar.Maximum = args.TotalBytesToReceive;
                DownloadWindow.progressBar.Value = args.BytesReceived;
            });

            DownloadWindow.Show();

            Progress = progress;

            var url = firebird_Url_X86;
            var hash = firebird_Hash_X86;
            var systemType = Environment.Is64BitOperatingSystem;
            if (systemType)
            {
                url = firebird_Url_X64;
                hash = firebird_Hash_X64;
            }

            var downloadFileName = Path.GetFileName(url);
            var path = Path.Combine(servicePath, downloadFileName);

            if (File.Exists(path))
            {
                if (HashCheck.Check(path, hash))
                {
                    MessageBox.Show($"O {downloadFileName} ", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    FirebirdInstallation.InstallFirebird(silentInstallation, path);
                }
                else
                {
                    MessageBox.Show($"O arquivo {downloadFileName} anteriormente baixado não passou no teste. Um novo download será feito.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    await DownloadFileInBackgroundAsync(url, path, hash);
                    FirebirdInstallation.InstallFirebird(silentInstallation, path);
                }
            }
            else
            {
                await DownloadFileInBackgroundAsync(url, path, hash);
                FirebirdInstallation.InstallFirebird(silentInstallation, path);
            }
        }

        public async Task ProlexDownloadAsync(string servicePath)
        {
            async Task Prolex6()
            {
            var url = DownloadParameters.Instance.Prolex6_Url;
            var hash = DownloadParameters.Instance.Prolex6_Hash;
            var downloadFileName = Path.GetFileName(url);
            var path = Path.Combine(servicePath, downloadFileName);
            await DownloadFileInBackgroundAsync(url, path, hash);
            }

            async Task ProlexTDPJ()
            {
            var url = DownloadParameters.Instance.ProlexTDPJ_Url;
            var hash = DownloadParameters.Instance.ProlexTDPJ_Hash;
            var downloadFileName = Path.GetFileName(url);
            var path = Path.Combine(servicePath, downloadFileName);
            await DownloadFileInBackgroundAsync(url, path, hash);
            }

            async Task ProlexNet()
            {
            var url = DownloadParameters.Instance.ProlexNet_Url;
            var hash = DownloadParameters.Instance.ProlexNet_Hash;
            var downloadFileName = Path.GetFileName(url);
            var path = Path.Combine(servicePath, downloadFileName);
            await DownloadFileInBackgroundAsync(url, path, hash);
            }
        }
        public async Task DownloadFileInBackgroundAsync(string url, string path, string hash)
        {
            WebClient client = new WebClient();

            client.DownloadFileCompleted += async (sender, args) =>
            {
                var downloadFileName = Path.GetFileName(url);
                if (HashCheck.Check(path, hash))
                {
                    MessageBox.Show($"O download do {downloadFileName} foi concluído sem erros.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var downloadError = MessageBox.Show($"O download do {downloadFileName} está corrompido ou o Hash MD5 fornecido pelo arquivo Json não confere. Deseja tentar fazer novamente o download?", "Erro!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (downloadError.Equals(MessageBoxResult.Yes))
                        await DownloadFileInBackgroundAsync(url, path, hash);
                    else
                        return;
                }
            };
            client.DownloadProgressChanged += (sender, args) => Progress.Report(args);
            await client.DownloadFileTaskAsync(url, path);
        }
    }
}
