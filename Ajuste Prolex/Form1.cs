using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Ajuste_Prolex
{
    public partial class Form1 : Form
    {
        public string Versao { get; private set; } = "0.7a";
        
        public string CaminhoConfFirebird { get; set; }
        public string CaminhoAliasProtesto { get; set; }
        public string CaminhoAliasTDPJ { get; set; }
        public string CaminhoLocalBancoProtesto { get; set; }
        public string CaminhoLocalBancoTDPJ { get; set; }
        public string CaminhoConfigSelo { get; set; }
        public string CaminhoConfigInstrumento { get; set; }
        public string CaminhoRenomearBancoPR { get; set; }
        public string CaminhoRenomearBancoTDPJ { get; set; }
        public string CaminhoGlobalProtesto { get; set; }
        public string CaminhoGlobalTDPJ { get; set; }
        OpenFileDialog AliasesProlex = new OpenFileDialog();
        OpenFileDialog AliasesProlexTDPJ = new OpenFileDialog();
        OpenFileDialog BancoProtesto = new OpenFileDialog();
        OpenFileDialog BancoTDPJ = new OpenFileDialog();
        OpenFileDialog ConfigSelo = new OpenFileDialog();
        OpenFileDialog ConfigInstrumento = new OpenFileDialog();
        OpenFileDialog RenomearBancoPR = new OpenFileDialog();
        OpenFileDialog RenomearBancoTDPJ = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
            labelVersao.Text = "Versão: " + Versao;
        }

        private void RadioServidor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioServidor.Checked)
            {
                Salvar.Enabled = true;
                BotaoAbrirFirebirdCONF.Enabled = true;
                painelProtesto.Enabled = true;
                painelTDPJ.Enabled = true;
                errorProvider1.SetError(BotaoAbrirFirebirdCONF, "Selecione o arquivo de Aliases do Firebird");
            }
        }

        private void RadioTerminal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTerminal.Checked)
            {
                Salvar.Enabled = true;
                BotaoAbrirFirebirdCONF.Enabled = false;
                checkBoxProtesto.Checked = false;
                checkBoxTDPJ.Checked = false;
                painelFirebird.Enabled = false;
                painelProtesto.Enabled = true;
                painelTDPJ.Enabled = true;
                labelCaminhoArquivoFirebird.Text = "";
                LocalBancoProtesto.Text = "Localização do banco de dados Protesto";
                LocalBancoTDPJ.Text = "Localização do banco de dados TDPJ";
                errorProvider1.SetError(BotaoAbrirFirebirdCONF, "");
                errorProvider1.SetError(LocalBancoTDPJ, "");
                errorProvider1.SetError(LocalBancoProtesto, "");
            }
        }

        private void BotaoAbrirFirebirdCONF_Click(object sender, EventArgs e)
        {
            string Filtro = "";
            OpenFileDialog AliasesConf = new OpenFileDialog()
            {
                Filter = "Arq. de alias do Firebird|*.conf"
            };
            if (File.Exists(@"C:\Program Files\Firebird\Firebird_2_5\bin\fbserver.exe") && File.Exists(@"C:\Program Files\Firebird\Firebird_2_5\aliases.conf"))
            {
                Filtro = "aliases.conf";
                AliasesConf.Filter = "Arq. de alias do Firebird 2.5 x64|aliases.conf";
                AliasesConf.InitialDirectory = @"C:\Program Files\Firebird\Firebird_2_5\";
            }
            else if (File.Exists(@"C:\Program Files (x86)\Firebird\Firebird_2_5\bin\fbserver.exe") && File.Exists(@"C:\Program Files (x86)\Firebird\Firebird_2_5\aliases.conf"))
            {
                Filtro = "aliases.conf";
                AliasesConf.Filter = "Arq. de alias do Firebird 2.5 x86|aliases.conf";
                AliasesConf.InitialDirectory = @"C:\Program Files (x86)\Firebird\Firebird_2_5\";
            }
            else if (File.Exists(@"C:\Program Files\Firebird\Firebird_3_0\firebird.exe") && File.Exists(@"C:\Program Files\Firebird\Firebird_3_0\databases.conf"))
            {
                Filtro = "databases.conf";
                AliasesConf.Filter = "Arq. de alias do Firebird 3.0 x64|databases.conf";
                AliasesConf.InitialDirectory = @"C:\Program Files\Firebird\Firebird_3_0\";
            }
            else if (File.Exists(@"C:\Program Files (x86)\Firebird\Firebird_3_0\firebird.exe") && File.Exists(@"C:\Program Files (x86)\Firebird\Firebird_3_0\databases.conf"))
            {
                Filtro = "databases.conf";
                AliasesConf.Filter = "Arq. de alias do Firebird 3.0 x86|databases.conf";
                AliasesConf.InitialDirectory = @"C:\Program Files (x86)\Firebird\Firebird_3_0\";
            }
            else
            {
                AliasesConf.InitialDirectory = @"C:\";
            }

            if (AliasesConf.ShowDialog() == DialogResult.OK)
            {
                painelFirebird.Enabled = true;
                labelCaminhoArquivoFirebird.Text = AliasesConf.FileName;
                CaminhoConfFirebird = AliasesConf.FileName;
                if (AliasesConf.FileName.Contains(Filtro))
                {
                    errorProvider1.SetError(BotaoAbrirFirebirdCONF, "");
                }
                else
                {
                    errorProvider1.SetError(BotaoAbrirFirebirdCONF, "Selecione o arquivo de Aliases do Firebird");
                }
            }

        }

        private void CheckBoxProtesto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProtesto.Checked == true)
            {
                LocalBancoProtesto.Enabled = true;
                LocalBancoProtesto.Text = "";
                OpenFileDialog BancoProtesto = new OpenFileDialog()
                {
                    Filter = "Arquivo do banco de dados Protesto|PROLEX6.*"
                };
                if (File.Exists(@"C:\Automatiza\Prolex6\Prolex.exe"))
                {
                    BancoProtesto.InitialDirectory = @"C:\Automatiza\Prolex6\Dados\";
                }
                else
                {
                    BancoProtesto.InitialDirectory = @"C:\";
                }

                if (BancoProtesto.ShowDialog() == DialogResult.OK)
                {
                    CaminhoGlobalProtesto = BancoProtesto.FileName;
                    LocalBancoProtesto.Text = BancoProtesto.FileName;
                    CaminhoLocalBancoProtesto = BancoProtesto.FileName;
                    checkboxINIPROTESTO.Checked = true;
                    BotaoRenomearBancoPR.Enabled = true;
                }
                else
                {
                    checkBoxProtesto.Checked = false;
                    BotaoRenomearBancoPR.Enabled = false;
                }
            }
            else
            {
                checkboxINIPROTESTO.Checked = false;
                LocalBancoProtesto.Enabled = false;
                BotaoRenomearBancoPR.Enabled = false;
                LocalBancoProtesto.Text = "Localização do banco de dados Protesto";
                errorProvider1.SetError(LocalBancoProtesto, "");
            }
        }

        private void CheckBoxTDPJ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTDPJ.Checked == true)
            {
                LocalBancoTDPJ.Enabled = true;
                LocalBancoTDPJ.Text = "";
                OpenFileDialog BancoTDPJ = new OpenFileDialog()
                {
                    Filter = "Arquivo do banco de dados TDPJ|PROLEX.*"
                };
                if (File.Exists(@"C:\Automatiza\Prolex\Prolex.exe"))
                {
                    BancoTDPJ.InitialDirectory = @"C:\Automatiza\Prolex\Dados\";
                }

                else if (File.Exists(@"C:\Automatiza\ProlexRtd\Prolex.exe"))
                {
                    BancoTDPJ.InitialDirectory = @"C:\Automatiza\ProlexRtd\Dados\";
                }
                else
                {
                    BancoTDPJ.InitialDirectory = @"C:\";
                }

                if (BancoTDPJ.ShowDialog() == DialogResult.OK)
                {
                    CaminhoGlobalTDPJ = BancoTDPJ.FileName;
                    LocalBancoTDPJ.Text = BancoTDPJ.FileName;
                    CaminhoLocalBancoTDPJ = BancoTDPJ.FileName;
                    checkboxXMLTDPJ.Checked = true;
                    BotaoRenomearBancoTDPJ.Enabled = true;
                }
                else
                {
                    checkBoxTDPJ.Checked = false;
                    BotaoRenomearBancoTDPJ.Enabled = false;
                }
            }
            else
            {
                checkboxXMLTDPJ.Checked = false;
                LocalBancoTDPJ.Enabled = false;
                BotaoRenomearBancoTDPJ.Enabled = false;
                LocalBancoTDPJ.Text = "Localização do banco de dados TDPJ";
                errorProvider1.SetError(LocalBancoTDPJ, "");
            }
        }

        private void BotaoSelecionarBancoProtesto_Click(object sender, EventArgs e)
        {
            OpenFileDialog BancoProtesto = new OpenFileDialog()
            {
                Filter = "Arquivo do banco de dados Protesto|PROLEX6.*"
            };
            if (File.Exists(@"C:\Automatiza\Prolex6\Prolex.exe"))
            {
                BancoProtesto.InitialDirectory = @"C:\Automatiza\Prolex6\Dados\";
            }
            else
            {
                BancoProtesto.InitialDirectory = @"C:\";
            }

            if (BancoProtesto.ShowDialog() == DialogResult.OK)
            {
                LocalBancoProtesto.Text = BancoProtesto.FileName;
                CaminhoLocalBancoProtesto = BancoProtesto.FileName;
            }
        }

        private void BotaoSelecionarBancoTDPJ_Click(object sender, EventArgs e)
        {
            OpenFileDialog BancoTDPJ = new OpenFileDialog()
            {
                Filter = "Arquivo do banco de dados TDPJ|PROLEX.*"
            };
            if (File.Exists(@"C:\Automatiza\Prolex\Prolex.exe"))
            {
                BancoTDPJ.InitialDirectory = @"C:\Automatiza\Prolex\Dados\";
            }

            else if (File.Exists(@"C:\Automatiza\ProlexRtd\Prolex.exe"))
            {
                BancoTDPJ.InitialDirectory = @"C:\Automatiza\ProlexRtd\Dados\";
            }
            else
            {
                BancoTDPJ.InitialDirectory = @"C:\";
            }

            if (BancoTDPJ.ShowDialog() == DialogResult.OK)
            {
                LocalBancoTDPJ.Text = BancoTDPJ.FileName;
                CaminhoLocalBancoTDPJ = BancoTDPJ.FileName;
            }
        }

        private void LocalBancoProtesto_TextChanged(object sender, EventArgs e)
        {
            string Filtro1 = "PROLEX6.PROLEX";
            string Filtro2 = "PROLEX6.FDB";
            if (LocalBancoProtesto.Text.Contains(Filtro1))
            {
                errorProvider1.SetError(LocalBancoProtesto, "");
            }
            else if (LocalBancoProtesto.Text.Contains(Filtro2))
            {
                errorProvider1.SetError(LocalBancoProtesto, "");
            }
            else
            {
                errorProvider1.SetError(LocalBancoProtesto, "Selecione o arquivo do Banco de dados Protesto");
            }
        }

        private void LocalBancoTDPJ_TextChanged(object sender, EventArgs e)
        {
            string Filtro1 = "PROLEX.PROLEX";
            string Filtro2 = "PROLEX.FDB";
            if (LocalBancoTDPJ.Text.Contains(Filtro1))
            {
                errorProvider1.SetError(LocalBancoTDPJ, "");
            }
            else if (LocalBancoTDPJ.Text.Contains(Filtro2))
            {
                errorProvider1.SetError(LocalBancoTDPJ, "");
            }
            else
            {
                errorProvider1.SetError(LocalBancoTDPJ, "Selecione o arquivo do Banco de dados TDPJ");
            }
        }

        private void BotaoAbrirProlexINI_Click(object sender, EventArgs e)
        {
            OpenFileDialog AliasesProlex = new OpenFileDialog()
            {
                Filter = "Arquivo de Alias do Prolex|Prolex.ini"
            };
            if (File.Exists(@"C:\Automatiza\Prolex6\Prolex.exe") && File.Exists(@"C:\Automatiza\Prolex6\Prolex.ini"))
            {
                AliasesProlex.InitialDirectory = @"C:\Automatiza\Prolex6\";
            }
            else
            {
                AliasesProlex.InitialDirectory = @"C:\";
            }

            if (AliasesProlex.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                painelAliasProtesto.Enabled = true;
                CaminhoAliasProtesto = AliasesProlex.FileName;
                labelCaminhoArquivoAliasProlex.Text = AliasesProlex.FileName;
            }
        }

        private void NomeServidor_TextChanged(object sender, EventArgs e)
        {
            if (NomeServidor.Text.Length >= 1)
            {
                errorProvider1.SetError(NomeServidor, "");
            }
            else
            {
                errorProvider1.SetError(NomeServidor, "Informe o nome ou IP do Servidor");
            }
        }

        private void NomeAliasProtesto_TextChanged(object sender, EventArgs e)
        {
            if (NomeAliasProtesto.Text.Length >= 1)
            {
                errorProvider1.SetError(NomeAliasProtesto, "");
            }
            else
            {
                errorProvider1.SetError(NomeAliasProtesto, "Informe o Alias");
            }
        }

        private void NumeroTerminalProtesto_TextChanged(object sender, EventArgs e)
        {
            if (NumeroTerminalProtesto.Text.Length >= 1 && NumeroTerminalProtesto.Text.Length <= 2)
            {
                errorProvider1.SetError(NumeroTerminalProtesto, "");
            }
            else
            {
                errorProvider1.SetError(NumeroTerminalProtesto, "Informe o número do Terminal Protesto");
            }
        }

        private void NomeServidorTDPJ_TextChanged(object sender, EventArgs e)
        {
            if (NomeServidorTDPJ.Text.Length >= 1)
            {
                errorProvider1.SetError(NomeServidorTDPJ, "");
            }
            else
            {
                errorProvider1.SetError(NomeServidorTDPJ, "Informe o nome ou IP do Servidor");
            }
        }

        private void NomeAliasTDPJ_TextChanged(object sender, EventArgs e)
        {
            if (NomeAliasTDPJ.Text.Length >= 1)
            {
                errorProvider1.SetError(NomeAliasTDPJ, "");
            }
            else
            {
                errorProvider1.SetError(NomeAliasTDPJ, "Informe o Alias");
            }
        }

        private void CheckboxINIPROTESTO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxINIPROTESTO.Checked == true)
            {
                OpenFileDialog AliasesProlex = new OpenFileDialog()
                {
                    Filter = "Arquivo de Alias do Prolex|Prolex.ini"
                };
                if (File.Exists(@"C:\Automatiza\Prolex6\Prolex.exe") && File.Exists(@"C:\Automatiza\Prolex6\Prolex.ini"))
                {
                    AliasesProlex.InitialDirectory = @"C:\Automatiza\Prolex6\";
                }
                else
                {
                    AliasesProlex.InitialDirectory = @"C:\";
                }

                if (AliasesProlex.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    painelAliasProtesto.Enabled = true;
                    CaminhoAliasProtesto = AliasesProlex.FileName;
                    labelCaminhoArquivoAliasProlex.Text = AliasesProlex.FileName;
                    if (radioServidor.Checked == true && CaminhoConfFirebird != null)
                    {
                        checkBoxProtesto.Checked = true;
                    }

                    if (NomeServidor.Text.Length >= 1)
                    {
                        errorProvider1.SetError(NomeServidor, "");
                    }
                    else
                    {
                        errorProvider1.SetError(NomeServidor, "Informe o nome ou IP do Servidor");
                    }

                    if (NomeAliasProtesto.Text.Length >= 1)
                    {
                        errorProvider1.SetError(NomeAliasProtesto, "");
                    }
                    else
                    {
                        errorProvider1.SetError(NomeAliasProtesto, "Informe o Alias");
                    }

                    if (NumeroTerminalProtesto.Text.Length >= 1 && NumeroTerminalProtesto.Text.Length <= 2)
                    {
                        errorProvider1.SetError(NumeroTerminalProtesto, "");
                    }
                    else
                    {
                        errorProvider1.SetError(NumeroTerminalProtesto, "Informe o número do Terminal Protesto");
                    }
                }

                else
                {
                    checkboxINIPROTESTO.Checked = false;
                    checkBoxEnviaSelos.Checked = false;
                    checkBoxEnviaInstrumento.Checked = false;
                    errorProvider1.SetError(NomeServidor, "");
                    errorProvider1.SetError(NomeAliasProtesto, "");
                    errorProvider1.SetError(NumeroTerminalProtesto, "");
                }
                painelAliasProtesto.Enabled = true;
            }
            else
            {
                painelAliasProtesto.Enabled = false;
                if (radioServidor.Checked == true && CaminhoConfFirebird != null)
                {
                    checkBoxProtesto.Checked = false;
                }
                labelCaminhoArquivoAliasProlex.Text = null;
                checkboxINIPROTESTO.Checked = false;
                checkBoxEnviaSelos.Checked = false;
                checkBoxEnviaInstrumento.Checked = false;
                errorProvider1.SetError(NomeServidor, "");
                errorProvider1.SetError(NomeAliasProtesto, "");
                errorProvider1.SetError(NumeroTerminalProtesto, "");
            }
        }

        private void CheckboxXMLTDPJ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxXMLTDPJ.Checked == true)
            {
                OpenFileDialog AliasesProlexTDPJ = new OpenFileDialog()
                {
                    Filter = "Arquivo de Alias do Prolex|Prolex.exe.config"
                };
                if (File.Exists(@"C:\Automatiza\Prolex\Prolex.exe") && File.Exists(@"C:\Automatiza\Prolex\Prolex.exe.config"))
                {
                    AliasesProlexTDPJ.InitialDirectory = @"C:\Automatiza\Prolex\";
                }
                else if (File.Exists(@"C:\Automatiza\ProlexRtd\Prolex.exe") && File.Exists(@"C:\Automatiza\ProlexRtd\Prolex.exe.config"))
                {
                    AliasesProlexTDPJ.InitialDirectory = @"C:\Automatiza\ProlexRtd\";
                }
                else
                {
                    AliasesProlexTDPJ.InitialDirectory = @"C:\";
                }

                if (AliasesProlexTDPJ.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    painelAliasTDPJ.Enabled = true;
                    CaminhoAliasTDPJ = AliasesProlexTDPJ.FileName;
                    labelCaminhoArquivoAliasProlexXML.Text = AliasesProlexTDPJ.FileName;
                    if (radioServidor.Checked == true && CaminhoConfFirebird != null)
                    {
                        checkBoxTDPJ.Checked = true;
                    }

                    if (NomeServidorTDPJ.Text.Length >= 1)
                    {
                        errorProvider1.SetError(NomeServidorTDPJ, "");
                    }
                    else
                    {
                        errorProvider1.SetError(NomeServidorTDPJ, "Informe o nome ou IP do Servidor");
                    }

                    if (NomeAliasTDPJ.Text.Length >= 1)
                    {
                        errorProvider1.SetError(NomeAliasTDPJ, "");
                    }
                    else
                    {
                        errorProvider1.SetError(NomeAliasTDPJ, "Informe o Alias");
                    }
                }
                else
                {
                    checkboxXMLTDPJ.Checked = false;
                    errorProvider1.SetError(NomeServidorTDPJ, "");
                    errorProvider1.SetError(NomeAliasTDPJ, "");
                }
                painelAliasTDPJ.Enabled = true;
            }
            else
            {
                painelAliasTDPJ.Enabled = false;
                if (radioServidor.Checked == true && CaminhoConfFirebird != null)
                {
                    checkBoxTDPJ.Checked = false;
                }
                labelCaminhoArquivoAliasProlexXML.Text = null;
                checkboxXMLTDPJ.Checked = false;
                errorProvider1.SetError(NomeServidorTDPJ, "");
                errorProvider1.SetError(NomeAliasTDPJ, "");
            }
        }

        private void CheckBoxEnviaSelos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnviaSelos.Checked == true)
            {
                labelCaminhoArquivoProgSelos.Visible = true;
                OpenFileDialog ConfigSelo = new OpenFileDialog()
                {
                    Filter = "Arquivo de Config do Prog Selos|Prolex6ControleSelosMG.exe.config"
                };
                if (File.Exists(@"C:\Automatiza\Controle de Selos MG\Prolex6ControleSelosMG.exe"))
                {
                    ConfigSelo.InitialDirectory = @"C:\Automatiza\Controle de Selos MG\";
                }
                else if (File.Exists(@"C:\Automatiza\Prolex6\Controle de Selos MG\Prolex6ControleSelosMG.exe") )
                {
                    ConfigSelo.InitialDirectory = @"C:\Automatiza\Prolex6\Controle de Selos MG\";
                }
                else if (File.Exists(@"C:\Automatiza\Controle Selos MG\Prolex6ControleSelosMG.exe"))
                {
                    ConfigSelo.InitialDirectory = @"C:\Automatiza\Controle Selos MG\";
                }
                else if (File.Exists(@"C:\Automatiza\Prolex6\Controle Selos MG\Prolex6ControleSelosMG.exe"))
                {
                    ConfigSelo.InitialDirectory = @"C:\Automatiza\Prolex6\Controle Selos MG\";
                }
                else
                {
                    ConfigSelo.InitialDirectory = @"C:\";
                }

                if (ConfigSelo.ShowDialog() == DialogResult.OK)
                {
                    CaminhoConfigSelo = ConfigSelo.FileName;
                    labelCaminhoArquivoProgSelos.Text = ConfigSelo.FileName;
                }
                else
                {
                    checkBoxEnviaSelos.Checked = false;
                }
            }
            else
            {
                labelCaminhoArquivoProgSelos.Visible = false;
            }
        }

        private void CheckBoxEnviaInstrumento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnviaInstrumento.Checked == true)
            {
                labelCaminhoArquivoProgInstrumento.Visible = true;
                OpenFileDialog ConfigInstrumento = new OpenFileDialog()
                {
                    Filter = "Arquivo de Config do Prog Instrumento|Instrumento Eletronico.exe.config"
                };
                if (File.Exists(@"C:\Automatiza\Instrumento Eletrônico\Instrumento Eletronico.exe") && File.Exists(@"C:\Automatiza\Instrumento Eletrônico\Instrumento Eletronico.exe.config"))
                {
                    ConfigInstrumento.InitialDirectory = @"C:\Automatiza\Instrumento Eletrônico\";
                }
                else if (File.Exists(@"C:\Automatiza\Prolex6\Instrumento Eletrônico\Instrumento Eletronico.exe") && File.Exists(@"C:\Automatiza\Prolex6\Instrumento Eletrônico\Instrumento Eletronico.exe.config"))
                {
                    ConfigInstrumento.InitialDirectory = @"C:\Automatiza\Prolex6\Instrumento Eletrônico\";
                }
                else
                {
                    ConfigInstrumento.InitialDirectory = @"C:\";
                }

                if (ConfigInstrumento.ShowDialog() == DialogResult.OK)
                {
                    CaminhoConfigInstrumento = ConfigInstrumento.FileName;
                    labelCaminhoArquivoProgInstrumento.Text = ConfigInstrumento.FileName;
                }
                else
                {
                    checkBoxEnviaInstrumento.Checked = false;
                }
            }
            else
            {
                labelCaminhoArquivoProgInstrumento.Visible = false;
            }
        }

        private void Salvar_Click(object sender, EventArgs e)
        {

            DialogResult Salvar = MessageBox.Show("Deseja salvar as alterações?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Salvar == DialogResult.Yes)
            {

                if (radioServidor.Checked == true && checkBoxProtesto.Checked == true && checkBoxTDPJ.Checked == true && CaminhoConfFirebird != null)
                {
                    string[] SalvarConfFirebird = { "#", "# List of known database aliases", "# ------------------------------", "#", "# Examples:", "#", "#   dummy = c:\\data\\dummy.fdb", "#", NomeAliasProtesto.Text + " = " + LocalBancoProtesto.Text, NomeAliasTDPJ.Text + " = " + LocalBancoTDPJ.Text };
                    File.WriteAllLines(@CaminhoConfFirebird, SalvarConfFirebird);
                }

                else if (radioServidor.Checked == true && checkBoxProtesto.Checked == true && checkBoxTDPJ.Checked == false && CaminhoConfFirebird != null)
                {
                    string[] SalvarConfFirebird = { "#", "# List of known database aliases", "# ------------------------------", "#", "# Examples:", "#", "#   dummy = c:\\data\\dummy.fdb", "#", NomeAliasProtesto.Text + " = " + LocalBancoProtesto.Text };
                    File.WriteAllLines(@CaminhoConfFirebird, SalvarConfFirebird);
                }

                else if (radioServidor.Checked == true && checkBoxProtesto.Checked == false && checkBoxTDPJ.Checked == true && CaminhoConfFirebird != null)
                {
                    string[] SalvarConfFirebird = { "#", "# List of known database aliases", "# ------------------------------", "#", "# Examples:", "#", "#   dummy = c:\\data\\dummy.fdb", "#", NomeAliasTDPJ.Text + " = " + LocalBancoTDPJ.Text };
                    File.WriteAllLines(@CaminhoConfFirebird, SalvarConfFirebird);
                }

                if (checkboxINIPROTESTO.Checked == true && CaminhoAliasProtesto != null)
                {
                    string[] SalvarAliases = { "[Terminal]", "Numero=" + NumeroTerminalProtesto.Text, "[Servidor]", "Nome=" + NomeServidor.Text, "[Alias]", "Nome=" + NomeAliasProtesto.Text };
                    File.WriteAllLines(@CaminhoAliasProtesto, SalvarAliases);
                }

                if (checkBoxEnviaSelos.Checked == true && CaminhoConfigSelo != null)
                {
                    File.WriteAllText(@CaminhoConfigSelo, Regex.Replace(File.ReadAllText(@CaminhoConfigSelo), "source=(.*?);", "source=" + NomeServidor.Text + ";"));
                    File.WriteAllText(@CaminhoConfigSelo, Regex.Replace(File.ReadAllText(@CaminhoConfigSelo), "initial catalog=(.*?);", "initial catalog=" + NomeAliasProtesto.Text + ";"));
                }

                if (checkBoxEnviaInstrumento.Checked == true && CaminhoConfigInstrumento != null)
                {
                    File.WriteAllText(@CaminhoConfigInstrumento, Regex.Replace(File.ReadAllText(@CaminhoConfigInstrumento), "source=(.*?);", "source=" + NomeServidor.Text + ";"));
                    File.WriteAllText(@CaminhoConfigInstrumento, Regex.Replace(File.ReadAllText(@CaminhoConfigInstrumento), "initial catalog=(.*?);", "initial catalog=" + NomeAliasProtesto.Text + ";"));
                }

                if (checkboxXMLTDPJ.Checked == true && CaminhoAliasTDPJ != null)
                {
                    File.WriteAllText(@CaminhoAliasTDPJ, Regex.Replace(File.ReadAllText(@CaminhoAliasTDPJ), "datasource=(.*?);", "datasource=" + NomeServidorTDPJ.Text + ";"));
                    File.WriteAllText(@CaminhoAliasTDPJ, Regex.Replace(File.ReadAllText(@CaminhoAliasTDPJ), "database=(.*?);", "database=" + NomeAliasTDPJ.Text + ";"));
                }
                MessageBox.Show("As alterações foram salvas com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (Salvar == DialogResult.No)
            {
                
            }
        }

        private void BotaoCorrigirRegistro_Click(object sender, EventArgs e)
        {
            
            using (RegistryKey key = Registry.CurrentUser
                .OpenSubKey("SOFTWARE", true)
                .OpenSubKey("FIBC_Software", true))
            {
                if (key != null)
                    key.DeleteSubKeyTree("Aliases");
            }

            var OurKey = Registry.LocalMachine;
            OurKey = OurKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", true);

            var users = Registry.Users;
            foreach (string Keyname in OurKey.GetSubKeyNames())
            {
                RegistryKey key = users.OpenSubKey(Keyname, true);

                var software = key?.OpenSubKey("SOFTWARE", true);
                if (software == null)
                {
                    software = key?.OpenSubKey("Software", true);
                    if (software == null)
                        continue;
                }

                var fibc_software = software.OpenSubKey("FIBC_Software", true);
                if (fibc_software == null)
                    continue;

                var aliases = fibc_software.OpenSubKey("Aliases", true);
                if (aliases == null)
                    continue;

                foreach (var aliase in aliases.GetSubKeyNames())

                        aliases.DeleteSubKeyTree(aliase, false);
            }
            MessageBox.Show("Registro corrigido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BotaoRenomearBancoProtesto_Click(object sender, EventArgs e)
        {
            try
            {
                var renomeia = Path.ChangeExtension(LocalBancoProtesto.Text, "PROLEX");
                File.Move(LocalBancoProtesto.Text, renomeia);
                LocalBancoProtesto.Text = renomeia;
                MessageBox.Show("Extensão renomeada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoRenomearBancoTDPJ_Click(object sender, EventArgs e)
        {
            try
            {
                var renomeia = Path.ChangeExtension(LocalBancoTDPJ.Text, "PROLEX");
                File.Move(LocalBancoTDPJ.Text, renomeia);
                LocalBancoTDPJ.Text = renomeia;
                MessageBox.Show("Extensão renomeada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
