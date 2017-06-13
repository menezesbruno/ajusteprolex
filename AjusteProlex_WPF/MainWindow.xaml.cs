using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.IO;
using Microsoft.Win32;

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
    }
}
