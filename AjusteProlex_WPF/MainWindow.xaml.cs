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
using System.Security.Cryptography;
using System.Text;

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
        public string ServicePath { get; set; }
        public string DownloadPath { get; set; }

        public object Versao = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public MainWindow()
        {
            InitializeComponent();

            ServicePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Automatiza", "Instalador");
            Directory.CreateDirectory(ServicePath);
        }

        private void BtnAbrirArqFirebird_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Arquivo Firebeird|databases.conf;aliases.conf"
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
            passo1.IsEnabled = true;
            passo2.IsEnabled = true;
            passo3.IsEnabled = true;
            passo4.IsEnabled = true;
            passo5.IsEnabled = true;
            passo6.IsEnabled = true;
        }

        private void CheckTerminal_Checked(object sender, RoutedEventArgs e)
        {
            PanelFirebird.IsEnabled = false;
            labelLocalizacaoArqFirebird.Content = "";
            TextBlockFirebird.Text = "";
            passo1.IsEnabled = false;
            passo2.IsEnabled = true;
            passo3.IsEnabled = true;
            passo4.IsEnabled = false;
            passo5.IsEnabled = false;
            passo6.IsEnabled = true;
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
                case "TabPreConversao":
                    color = "Green";
                    break;
            }
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(color);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }

        private void ButtonRemoverFirebird_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var firebird64Path = Directory.GetFiles("C:\\Program Files\\Firebird", "unins*.exe", SearchOption.AllDirectories);
                var firebird32Path = Directory.GetFiles("C:\\Program Files (x86)\\Firebird", "unins*.exe", SearchOption.AllDirectories);
                if (firebird64Path != null)
                {
                    foreach (string path in firebird64Path)
                    {
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = path;
                            process.StartInfo.Arguments = "/CLEAN";
                            process.Start();
                        }
                    }
                }

                if (firebird32Path != null)
                {
                    foreach (string path in firebird32Path)
                    {
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = path;
                            process.StartInfo.Arguments = "/CLEAN";
                            process.Start();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void ButtonRealizarBackup_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Arquivo Firebeird|databases.conf;aliases.conf"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var newFbConf = Path.GetFullPath(openFileDialog.FileName);
                var backupWindow = new BackupWindow(newFbConf, ServicePath);
                backupWindow.ShowDialog();
            }
        }

        private void ButtonRestaurarBackup_Click(object sender, RoutedEventArgs e)
        {
            var restoreWindow = new RestoreWindow();
            restoreWindow.ShowDialog();
        }

        private void ButtonAtualizarDLLs_Click(object sender, RoutedEventArgs e)
        {
            var updatedllsWindow = new ProlexDownloadWindow();
            updatedllsWindow.ShowDialog();
        }

        private void ButtonRestaurarAliases_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Arquivo Firebeird|databases.conf;aliases.conf"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var newFbConf = Path.GetFullPath(openFileDialog.FileName);
                using (StreamWriter writer = new StreamWriter(newFbConf, false))
                {
                    writer.WriteLine("# ------------------------------");
                    writer.WriteLine("# List of known databases");
                    writer.WriteLine("# ------------------------------");
                    writer.WriteLine("");
                    writer.WriteLine("#");
                    writer.WriteLine("# Makes it possible to specify per-database configuration parameters.");
                    writer.WriteLine("# See the list of them and description on file firebird.conf.");
                    writer.WriteLine("# To place that parameters in this file add them in curly braces");
                    writer.WriteLine("# after \"alias = / path / to / database.fdb\" line. Example:");
                    writer.WriteLine("#	big = /databases/bigdb.fdb");
                    writer.WriteLine("#	{");
                    writer.WriteLine("#		LockMemSize = 32M		# We know that bigdb needs a lot of locks");
                    writer.WriteLine("#		LockHashSlots = 19927	#	and big enough hash table for them");
                    writer.WriteLine("#	}");
                    writer.WriteLine("#");
                    writer.WriteLine("");
                    writer.WriteLine("#");
                    writer.WriteLine("# Example Database:");
                    writer.WriteLine("#");
                    writer.WriteLine("employee.fdb = $(dir_sampleDb)/employee.fdb");
                    writer.WriteLine("employee = $(dir_sampleDb)/employee.fdb");
                    writer.WriteLine("");
                    writer.WriteLine("#");
                    writer.WriteLine("# Master security database specific setup.");
                    writer.WriteLine("# Do not remove it until you understand well what are you doing!");
                    writer.WriteLine("#");
                    writer.WriteLine("security.db = $(dir_secDb)/security3.fdb");
                    writer.WriteLine("{");
                    writer.WriteLine("	RemoteAccess = false");
                    writer.WriteLine("	DefaultDbCachePages = 50");
                    writer.WriteLine("}");
                    writer.WriteLine("");
                    writer.WriteLine("#");
                    writer.WriteLine("# Live Databases:");
                    writer.WriteLine("#");
                    writer.WriteLine(@"Prolex6 C:\Automatiza\Banco de Dados\Prolex6.prolex");
                    writer.WriteLine(@"Prolex C:\Automatiza\Banco de Dados\Prolex.prolex");
                }
            }
        }

        private void ButtonInstalarFirebird_Click(object sender, RoutedEventArgs e)
        {
            var silentInstallation = checkboxSilentInstallation.IsChecked == true;
            var download = new Download.Download();
            download.FirebirdDownloadAsync(ServicePath, silentInstallation);
        }
    }
}