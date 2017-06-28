using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

                            if (line == "Prolex6")
                            {
                                cs.UserID = "SYSDBA";
                                cs.Password = "masterkey";
                            }
                            /*else if(line == "Prolex")
                            {
                                cs.UserID = "SYSDBA";
                                cs.Password = "masterkey";
                            }*/
                            cs.Database = line;

                            FbBackup backupSvc = new FbBackup();

                            backupSvc.ConnectionString = cs.ToString();
                            backupSvc.BackupFiles.Add(new FbBackupFile(databaseFile, 2048));
                            backupSvc.Verbose = true;
                            backupSvc.Options = FbBackupFlags.IgnoreLimbo;
                            backupSvc.ServiceOutput += BackupSvc_ServiceOutput;

                            
                                backupSvc.Execute();
                                return true;
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackupSvc_ServiceOutput(object sender, ServiceOutputEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                StatusBackup.Text += DateTime.Now + " - " + e.Message;
                StatusBackup.Text += Environment.NewLine;
                StatusBackup.ScrollToEnd();
            });          
            
        }

        private void StatusBackup_Loaded(object sender, RoutedEventArgs e)
        {
            BackupAsync();
        }

        private void StatusBackup_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            
        }
    }
}
