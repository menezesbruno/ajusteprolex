using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;

namespace AjusteProlex_WPF
{
    /// <summary>
    /// Interaction logic for BackupWindow.xaml
    /// </summary>
    public partial class RestoreWindow : MetroWindow
    {
        public string DatabaseFile { get; set; }

        public RestoreWindow()
        {
            InitializeComponent();
        }

        private async Task RestoreAsync()
        {
            try
            {
                var databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Automatiza", "Instalador");
                Directory.CreateDirectory(databasePath);

                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Arquivo Firebird|databases.conf;aliases.conf"
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    List<string> aliases = new List<string>();
                    var firebirdConf = File.ReadAllLines(openFileDialog.FileName);

                    foreach (string line in firebirdConf)
                    {
                        if (line.Contains("Prolex"))
                        {
                            aliases.Add(line.Split(' ').FirstOrDefault());
                        }
                    }

                    foreach (string line in aliases)
                    {
                        try
                        {
                            var result = await Task.Run(() =>
                            {
                                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                                if (line.Equals("Prolex6", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    DatabaseFile = Directory.GetFiles(databasePath, "Prolex6.prolexbkp").FirstOrDefault();
                                }
                                else if (line.Equals("Prolex", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    DatabaseFile = Directory.GetFiles(databasePath, "Prolex.prolexbkp").FirstOrDefault();
                                }
                                cs.UserID = "SYSDBA";
                                cs.Password = "masterkey";
                                cs.Database = line;

                                FbRestore restoreSvc = new FbRestore();
                                restoreSvc.ConnectionString = cs.ToString();
                                restoreSvc.BackupFiles.Add(new FbBackupFile(DatabaseFile, 2048));
                                restoreSvc.Verbose = true;
                                restoreSvc.PageSize = 4096;
                                restoreSvc.Options = FbRestoreFlags.Create | FbRestoreFlags.Replace;
                                restoreSvc.ServiceOutput += RestoreSvc_ServiceOutput;

                                restoreSvc.Execute();
                                return true;
                            });
                            StatusLabel.Content = "";
                            progressBar.IsIndeterminate = false;

                            /*
                            var titulo = "Aviso";
                            var mensagem = $"Restauração do banco '{line}' concluído.";
                            var botoesConfig = MessageDialogStyle.Affirmative;
                            var dialogoConfig = new MetroDialogSettings()
                            {
                                AffirmativeButtonText = "OK"
                            };
                            await this.ShowMessageAsync(titulo, mensagem, botoesConfig, dialogoConfig);
                            */

                            MessageBox.Show($"Restauração do banco '{line}' concluído.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    //MessageBox.Show("Fase da restauração concluída","Aviso", MessageBoxButton.OK,MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RestoreSvc_ServiceOutput(object sender, ServiceOutputEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                StatusLabel.Content = "Restauração em andamento, aguarde...";
                progressBar.IsIndeterminate = true;
                StatusRestauracao.Content = e.Message;
            });
        }

        private void StatusRestauracao_Loaded(object sender, RoutedEventArgs e)
        {
            RestoreAsync();
        }
    }
}
