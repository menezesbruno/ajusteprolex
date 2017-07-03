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
    public partial class BackupWindow : MetroWindow
    {
        public string NewFbConf { get; set; }
        public string ServicePath { get; set; }

        public BackupWindow(string newFbConf, string servicePath)
        {
            InitializeComponent();
            NewFbConf = newFbConf;
            ServicePath = servicePath;
        }

        private async Task BackupAsync()
        {
            try
            {
                if (NewFbConf != null)
                {
                    List<string> aliases = new List<string>();
                    var firebirdConf = File.ReadAllLines(NewFbConf);

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
                                var databaseFile = Path.Combine(ServicePath, $"{line}.prolexbkp");

                                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();

                                if (line.Equals("Prolex6",StringComparison.InvariantCultureIgnoreCase))
                                {
                                    cs.UserID = "sysdba";
                                    cs.Password = "masterkey";
                                }
                                else if (line.Equals("Prolex", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    cs.UserID = "sysdba";
                                    cs.Password = "masterkey";
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

                            MessageBox.Show($"Backup do banco '{line}' concluído.", "Aviso", MessageBoxButton.OK,MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
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
