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

        public object Versao = Assembly.GetExecutingAssembly().GetName().Version.ToString();

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
    }
}
