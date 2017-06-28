using System;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Input;
using MahApps.Metro;
using System.Diagnostics;
using System.Net;
using System.Windows.Controls;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;

namespace AjusteProlex_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //Variáveis globais
        public string LocalizacaoFirebird { get; set; }
        public string LocalizacaoBancoProtesto { get; set; }
        public string LocalizacaoBancoTDPJ { get; set; }
        public string LocalizacaoInstrumentoEletronico { get; set; }
        public string LocalizacaoSeloEletronico { get; set; }
        public string DownloadPath { get; set; }

        public object Versao = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        IProgress<DownloadProgressChangedEventArgs> progress;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAbrirArqFirebird_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Arquivo Firebird|databases.conf;aliases.conf"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                labelLocalizacaoArqFirebird.Content = System.IO.Path.GetFullPath(openFileDialog.FileName);
                LocalizacaoFirebird = System.IO.Path.GetFullPath(openFileDialog.FileName);
                TextBlockFirebird.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void CheckServidor_Checked(object sender, RoutedEventArgs e)
        {
            string file = "";
            try
            {
                var checkfile = Directory.GetFiles("C:\\Program Files\\Firebird", "databases.conf", SearchOption.AllDirectories).FirstOrDefault();
                if (checkfile != null)
                    file = checkfile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                var checkfile = Directory.GetFiles("C:\\Program Files\\Firebird", "aliases.conf", SearchOption.AllDirectories).FirstOrDefault();
                if (checkfile != null)
                    file = checkfile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PanelFirebird.IsEnabled = true;
            labelLocalizacaoArqFirebird.Content = file;
            TextBlockFirebird.Text = File.ReadAllText(file);
        }

        private void CheckTerminal_Checked(object sender, RoutedEventArgs e)
        {
            PanelFirebird.IsEnabled = false;
            labelLocalizacaoArqFirebird.Content = "";
            TextBlockFirebird.Text = "";
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            var titulo = "Aviso";
            var mensagem = "Deseja salvar as alterações?";
            var botoesConfig = MessageDialogStyle.AffirmativeAndNegative;
            var dialogoConfig = new MetroDialogSettings()
            {
                AffirmativeButtonText = "OK",
                NegativeButtonText = "Cancelar",
                AnimateHide = true,
                AnimateShow = true
            };
            this.ShowMessageAsync(titulo, mensagem, botoesConfig, dialogoConfig);
        }

        private void TabGeral_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var name = ((FrameworkElement)((object[])e.AddedItems)[0]).Name;
            var color = ""; 
            switch (name)
            {
                case "TabPlataforma":
                    color = "Blue";
                    break;
                case "TabProtesto":
                    color = "Yellow";
                    break;
                case "TabTDPJ":
                    color = "Indigo";
                    break;
                case "TabProlexNet":
                    color = "Cobalt";
                    break;
                case "TabOutrosAjustes":
                    color = "Green";
                    break;
            }
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(color);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }

        private void ButtonRealizarBackup_Click(object sender, RoutedEventArgs e)
        {
            var backupWindow = new BackupWindow();
            backupWindow.Show();
        }

        private void ButtonRemoverFirebird_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var firebird64Path = Directory.GetFiles("C:\\Program Files\\Firebird", "unins000.exe", SearchOption.AllDirectories);
                if (firebird64Path != null)
                {
                    foreach (string path in firebird64Path)
                    {
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = path;
                            process.Start();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Firebird 64 bits não encontrado.");
            }

            try
            {
                var firebird32Path = Directory.GetFiles("C:\\Program Files (x86)\\Firebird", "unins000.exe", SearchOption.AllDirectories);
                if (firebird32Path != null)
                {
                    foreach (string path in firebird32Path)
                    {
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = path;
                            process.Start();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Firebird 32 bits não encontrado.");
            }
        }

        private void ButtonInstalarFirebird_Click(object sender, RoutedEventArgs e)
        {
            var rootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Automatiza", "Instalador");
            Directory.CreateDirectory(rootPath);

            string url = "http://ufpr.dl.sourceforge.net/project/firebird/firebird-win64/3.0.2-Release/Firebird-3.0.2.32703_0_x64.exe";
            var downloadFileName = Path.GetFileName(url);
            DownloadPath = Path.Combine(rootPath, downloadFileName);

            progress = new Progress<DownloadProgressChangedEventArgs>(args =>
            {
                progressBar.Maximum = args.TotalBytesToReceive;
                progressBar.Value = args.BytesReceived;
            });

            DownloadFileInBackground(url, DownloadPath);
        }

        public void InstallFirebird()
        {
            var installargsComponents = "/COMPONENTS=" + "ServerComponent";
            var installargsTaks = " /TASKS=" + "UseSuperServerTask,UseServiceTask,AutoStartTask,MenuGroupTask,CopyFbClientToSysTask,CopyFbClientAsGds32Task,EnableLegacyClientAuth";
            var installargsSilent = " /SILENT /SP-";
            Process process = new Process();
            process.StartInfo.FileName = DownloadPath;
            process.StartInfo.Arguments = installargsComponents;
            process.StartInfo.Arguments += installargsTaks;
            if(checkboxInstalacaoSilenciosa.IsChecked == true)
                process.StartInfo.Arguments += installargsSilent;
            
            process.Start();
        }

        public void DownloadFileInBackground(string url, string path)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(url);

            client.DownloadFileCompleted += (sender, args) => InstallFirebird();

            client.DownloadProgressChanged += (sender, args) =>
            {
                progress.Report(args);
            };

            client.DownloadFileAsync(uri, path);
        }
    }
}
