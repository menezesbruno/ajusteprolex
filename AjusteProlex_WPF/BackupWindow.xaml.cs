﻿using FirebirdSql.Data.FirebirdClient;
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
    public partial class BackupWindow : MetroWindow
    {
        public BackupWindow()
        {
            InitializeComponent();
        }

        private async Task BackupAsync()
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
                                var databaseFile = System.IO.Path.Combine(databasePath, $"{line}.prolexbkp");

                                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();

                                if (line.Equals("Prolex6",StringComparison.InvariantCultureIgnoreCase))
                                {
                                    cs.UserID = "sysdba";
                                    cs.Password = "masterkey";
                                }
                                else if (line.Equals("Prolex", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    cs.UserID = "prolex";
                                    cs.Password = "admprolex";
                                }
                                cs.Database = line;

                                FbBackup backupSvc = new FbBackup();
                                backupSvc.ConnectionString = cs.ToString();
                                backupSvc.BackupFiles.Add(new FbBackupFile(databaseFile, 2048));
                                backupSvc.Verbose = true;
                                backupSvc.Options = FbBackupFlags.IgnoreLimbo;
                                backupSvc.ServiceOutput += BackupSvc_ServiceOutputAsync;

                                backupSvc.Execute();
                                return true;
                            });
                            StatusLabel.Content = "";
                            progressBar.IsIndeterminate = false;

                            /*
                            var titulo = "Aviso";
                            var mensagem = $"Backup do banco '{line}' concluído.";
                            var botoesConfig = MessageDialogStyle.Affirmative;
                            var dialogoConfig = new MetroDialogSettings()
                            {
                                AffirmativeButtonText = "OK"
                            };
                            await this.ShowMessageAsync(titulo, mensagem, botoesConfig, dialogoConfig);
                            */

                            MessageBox.Show($"Backup do banco '{line}' concluído.", "Aviso", MessageBoxButton.OK,MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    //MessageBox.Show("Fase do backup concluída","Aviso", MessageBoxButton.OK,MessageBoxImage.Information);
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

        private void BackupSvc_ServiceOutputAsync(object sender, ServiceOutputEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                StatusLabel.Content = "Backup em andamento, aguarde...";
                progressBar.IsIndeterminate = true;
                StatusBackup.Content = e.Message;
            });
        }

        private void StatusBackup_Loaded(object sender, RoutedEventArgs e)
        {
            BackupAsync();      
        }
    }
}
