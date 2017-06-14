namespace Ajuste_Prolex
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radioServidor = new System.Windows.Forms.RadioButton();
            this.radioTerminal = new System.Windows.Forms.RadioButton();
            this.NomeServidor = new System.Windows.Forms.TextBox();
            this.NomeAliasProtesto = new System.Windows.Forms.TextBox();
            this.Salvar = new System.Windows.Forms.Button();
            this.painel = new System.Windows.Forms.Panel();
            this.botaoCorrigirRegistro = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.painelTDPJ = new System.Windows.Forms.Panel();
            this.checkboxXMLTDPJ = new System.Windows.Forms.CheckBox();
            this.labelCaminhoArquivoAliasProlexXML = new System.Windows.Forms.Label();
            this.painelAliasTDPJ = new System.Windows.Forms.Panel();
            this.labelAlias2 = new System.Windows.Forms.Label();
            this.labelNome2 = new System.Windows.Forms.Label();
            this.NomeAliasTDPJ = new System.Windows.Forms.TextBox();
            this.NomeServidorTDPJ = new System.Windows.Forms.TextBox();
            this.painelServidor = new System.Windows.Forms.Panel();
            this.labelCaminhoArquivoFirebird = new System.Windows.Forms.Label();
            this.painelFirebird = new System.Windows.Forms.Panel();
            this.BotaoRenomearBancoPR = new System.Windows.Forms.Button();
            this.BotaoRenomearBancoTDPJ = new System.Windows.Forms.Button();
            this.LocalBancoTDPJ = new System.Windows.Forms.TextBox();
            this.checkBoxTDPJ = new System.Windows.Forms.CheckBox();
            this.checkBoxProtesto = new System.Windows.Forms.CheckBox();
            this.LocalBancoProtesto = new System.Windows.Forms.TextBox();
            this.BotaoAbrirFirebirdCONF = new System.Windows.Forms.Button();
            this.labelVersao = new System.Windows.Forms.Label();
            this.painelProtesto = new System.Windows.Forms.Panel();
            this.checkboxINIPROTESTO = new System.Windows.Forms.CheckBox();
            this.labelCaminhoArquivoAliasProlex = new System.Windows.Forms.Label();
            this.painelAliasProtesto = new System.Windows.Forms.Panel();
            this.checkBoxEnviaInstrumento = new System.Windows.Forms.CheckBox();
            this.labelCaminhoArquivoProgInstrumento = new System.Windows.Forms.Label();
            this.checkBoxEnviaSelos = new System.Windows.Forms.CheckBox();
            this.labelCaminhoArquivoProgSelos = new System.Windows.Forms.Label();
            this.labelTerminal = new System.Windows.Forms.Label();
            this.NumeroTerminalProtesto = new System.Windows.Forms.TextBox();
            this.labelAlias = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.linha = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.logoAutomatiza = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.painel.SuspendLayout();
            this.painelTDPJ.SuspendLayout();
            this.painelAliasTDPJ.SuspendLayout();
            this.painelServidor.SuspendLayout();
            this.painelFirebird.SuspendLayout();
            this.painelProtesto.SuspendLayout();
            this.painelAliasProtesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoAutomatiza)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioServidor
            // 
            this.radioServidor.AutoSize = true;
            this.radioServidor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioServidor.Location = new System.Drawing.Point(226, 5);
            this.radioServidor.Name = "radioServidor";
            this.radioServidor.Size = new System.Drawing.Size(75, 21);
            this.radioServidor.TabIndex = 1;
            this.radioServidor.Text = "Servidor";
            this.radioServidor.UseVisualStyleBackColor = true;
            this.radioServidor.CheckedChanged += new System.EventHandler(this.RadioServidor_CheckedChanged);
            // 
            // radioTerminal
            // 
            this.radioTerminal.AutoSize = true;
            this.radioTerminal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTerminal.Location = new System.Drawing.Point(306, 5);
            this.radioTerminal.Name = "radioTerminal";
            this.radioTerminal.Size = new System.Drawing.Size(75, 21);
            this.radioTerminal.TabIndex = 2;
            this.radioTerminal.Text = "Terminal";
            this.radioTerminal.UseVisualStyleBackColor = true;
            this.radioTerminal.CheckedChanged += new System.EventHandler(this.RadioTerminal_CheckedChanged);
            // 
            // NomeServidor
            // 
            this.NomeServidor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.NomeServidor, 1);
            this.NomeServidor.Location = new System.Drawing.Point(70, 2);
            this.NomeServidor.Name = "NomeServidor";
            this.NomeServidor.Size = new System.Drawing.Size(193, 25);
            this.NomeServidor.TabIndex = 9;
            this.NomeServidor.Text = "localhost";
            this.NomeServidor.TextChanged += new System.EventHandler(this.NomeServidor_TextChanged);
            // 
            // NomeAliasProtesto
            // 
            this.NomeAliasProtesto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.NomeAliasProtesto, 1);
            this.NomeAliasProtesto.Location = new System.Drawing.Point(70, 41);
            this.NomeAliasProtesto.Name = "NomeAliasProtesto";
            this.NomeAliasProtesto.Size = new System.Drawing.Size(193, 25);
            this.NomeAliasProtesto.TabIndex = 10;
            this.NomeAliasProtesto.Text = "Prolex6";
            this.NomeAliasProtesto.TextChanged += new System.EventHandler(this.NomeAliasProtesto_TextChanged);
            // 
            // Salvar
            // 
            this.Salvar.Enabled = false;
            this.Salvar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salvar.Location = new System.Drawing.Point(307, 479);
            this.Salvar.Name = "Salvar";
            this.Salvar.Size = new System.Drawing.Size(120, 25);
            this.Salvar.TabIndex = 18;
            this.Salvar.Text = "Salvar";
            this.Salvar.UseVisualStyleBackColor = true;
            this.Salvar.Click += new System.EventHandler(this.Salvar_Click);
            // 
            // painel
            // 
            this.painel.Controls.Add(this.botaoCorrigirRegistro);
            this.painel.Controls.Add(this.panel1);
            this.painel.Controls.Add(this.painelTDPJ);
            this.painel.Controls.Add(this.painelServidor);
            this.painel.Controls.Add(this.labelVersao);
            this.painel.Controls.Add(this.Salvar);
            this.painel.Controls.Add(this.painelProtesto);
            this.painel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.painel.Location = new System.Drawing.Point(12, 92);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(610, 507);
            this.painel.TabIndex = 8;
            // 
            // botaoCorrigirRegistro
            // 
            this.botaoCorrigirRegistro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoCorrigirRegistro.Location = new System.Drawing.Point(181, 479);
            this.botaoCorrigirRegistro.Name = "botaoCorrigirRegistro";
            this.botaoCorrigirRegistro.Size = new System.Drawing.Size(120, 25);
            this.botaoCorrigirRegistro.TabIndex = 17;
            this.botaoCorrigirRegistro.Text = "Corrigir Registro";
            this.botaoCorrigirRegistro.UseVisualStyleBackColor = true;
            this.botaoCorrigirRegistro.Click += new System.EventHandler(this.BotaoCorrigirRegistro_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(303, 184);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 193);
            this.panel1.TabIndex = 10;
            // 
            // painelTDPJ
            // 
            this.painelTDPJ.BackColor = System.Drawing.Color.Transparent;
            this.painelTDPJ.Controls.Add(this.checkboxXMLTDPJ);
            this.painelTDPJ.Controls.Add(this.labelCaminhoArquivoAliasProlexXML);
            this.painelTDPJ.Controls.Add(this.painelAliasTDPJ);
            this.painelTDPJ.Enabled = false;
            this.painelTDPJ.Location = new System.Drawing.Point(305, 165);
            this.painelTDPJ.Name = "painelTDPJ";
            this.painelTDPJ.Size = new System.Drawing.Size(302, 308);
            this.painelTDPJ.TabIndex = 22;
            // 
            // checkboxXMLTDPJ
            // 
            this.checkboxXMLTDPJ.AutoSize = true;
            this.checkboxXMLTDPJ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxXMLTDPJ.Location = new System.Drawing.Point(123, 19);
            this.checkboxXMLTDPJ.Name = "checkboxXMLTDPJ";
            this.checkboxXMLTDPJ.Size = new System.Drawing.Size(62, 25);
            this.checkboxXMLTDPJ.TabIndex = 14;
            this.checkboxXMLTDPJ.Text = "TDPJ";
            this.checkboxXMLTDPJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkboxXMLTDPJ.UseVisualStyleBackColor = true;
            this.checkboxXMLTDPJ.CheckedChanged += new System.EventHandler(this.CheckboxXMLTDPJ_CheckedChanged);
            // 
            // labelCaminhoArquivoAliasProlexXML
            // 
            this.labelCaminhoArquivoAliasProlexXML.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaminhoArquivoAliasProlexXML.Location = new System.Drawing.Point(3, 43);
            this.labelCaminhoArquivoAliasProlexXML.Name = "labelCaminhoArquivoAliasProlexXML";
            this.labelCaminhoArquivoAliasProlexXML.Size = new System.Drawing.Size(296, 17);
            this.labelCaminhoArquivoAliasProlexXML.TabIndex = 21;
            this.labelCaminhoArquivoAliasProlexXML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // painelAliasTDPJ
            // 
            this.painelAliasTDPJ.Controls.Add(this.labelAlias2);
            this.painelAliasTDPJ.Controls.Add(this.labelNome2);
            this.painelAliasTDPJ.Controls.Add(this.NomeAliasTDPJ);
            this.painelAliasTDPJ.Controls.Add(this.NomeServidorTDPJ);
            this.painelAliasTDPJ.Enabled = false;
            this.painelAliasTDPJ.Location = new System.Drawing.Point(1, 69);
            this.painelAliasTDPJ.Name = "painelAliasTDPJ";
            this.painelAliasTDPJ.Size = new System.Drawing.Size(300, 237);
            this.painelAliasTDPJ.TabIndex = 17;
            // 
            // labelAlias2
            // 
            this.labelAlias2.AutoSize = true;
            this.labelAlias2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlias2.Location = new System.Drawing.Point(4, 44);
            this.labelAlias2.Name = "labelAlias2";
            this.labelAlias2.Size = new System.Drawing.Size(35, 17);
            this.labelAlias2.TabIndex = 15;
            this.labelAlias2.Text = "Alias";
            // 
            // labelNome2
            // 
            this.labelNome2.AutoSize = true;
            this.labelNome2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome2.Location = new System.Drawing.Point(4, 5);
            this.labelNome2.Name = "labelNome2";
            this.labelNome2.Size = new System.Drawing.Size(44, 17);
            this.labelNome2.TabIndex = 14;
            this.labelNome2.Text = "Nome";
            // 
            // NomeAliasTDPJ
            // 
            this.NomeAliasTDPJ.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.NomeAliasTDPJ, 1);
            this.NomeAliasTDPJ.Location = new System.Drawing.Point(70, 41);
            this.NomeAliasTDPJ.Name = "NomeAliasTDPJ";
            this.NomeAliasTDPJ.Size = new System.Drawing.Size(193, 25);
            this.NomeAliasTDPJ.TabIndex = 16;
            this.NomeAliasTDPJ.Text = "Prolex";
            this.NomeAliasTDPJ.TextChanged += new System.EventHandler(this.NomeAliasTDPJ_TextChanged);
            // 
            // NomeServidorTDPJ
            // 
            this.NomeServidorTDPJ.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.NomeServidorTDPJ, 1);
            this.NomeServidorTDPJ.Location = new System.Drawing.Point(70, 2);
            this.NomeServidorTDPJ.Name = "NomeServidorTDPJ";
            this.NomeServidorTDPJ.Size = new System.Drawing.Size(193, 25);
            this.NomeServidorTDPJ.TabIndex = 15;
            this.NomeServidorTDPJ.Text = "localhost";
            this.NomeServidorTDPJ.TextChanged += new System.EventHandler(this.NomeServidorTDPJ_TextChanged);
            // 
            // painelServidor
            // 
            this.painelServidor.BackColor = System.Drawing.Color.Transparent;
            this.painelServidor.Controls.Add(this.labelCaminhoArquivoFirebird);
            this.painelServidor.Controls.Add(this.painelFirebird);
            this.painelServidor.Controls.Add(this.BotaoAbrirFirebirdCONF);
            this.painelServidor.Controls.Add(this.radioTerminal);
            this.painelServidor.Controls.Add(this.radioServidor);
            this.painelServidor.Location = new System.Drawing.Point(3, 3);
            this.painelServidor.Name = "painelServidor";
            this.painelServidor.Size = new System.Drawing.Size(604, 160);
            this.painelServidor.TabIndex = 13;
            // 
            // labelCaminhoArquivoFirebird
            // 
            this.labelCaminhoArquivoFirebird.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaminhoArquivoFirebird.Location = new System.Drawing.Point(3, 64);
            this.labelCaminhoArquivoFirebird.Name = "labelCaminhoArquivoFirebird";
            this.labelCaminhoArquivoFirebird.Size = new System.Drawing.Size(594, 17);
            this.labelCaminhoArquivoFirebird.TabIndex = 15;
            this.labelCaminhoArquivoFirebird.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // painelFirebird
            // 
            this.painelFirebird.Controls.Add(this.BotaoRenomearBancoPR);
            this.painelFirebird.Controls.Add(this.BotaoRenomearBancoTDPJ);
            this.painelFirebird.Controls.Add(this.LocalBancoTDPJ);
            this.painelFirebird.Controls.Add(this.checkBoxTDPJ);
            this.painelFirebird.Controls.Add(this.checkBoxProtesto);
            this.painelFirebird.Controls.Add(this.LocalBancoProtesto);
            this.painelFirebird.Enabled = false;
            this.painelFirebird.Location = new System.Drawing.Point(3, 83);
            this.painelFirebird.Name = "painelFirebird";
            this.painelFirebird.Size = new System.Drawing.Size(601, 74);
            this.painelFirebird.TabIndex = 14;
            // 
            // BotaoRenomearBancoPR
            // 
            this.BotaoRenomearBancoPR.Enabled = false;
            this.BotaoRenomearBancoPR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.BotaoRenomearBancoPR, 1);
            this.BotaoRenomearBancoPR.Location = new System.Drawing.Point(470, 5);
            this.BotaoRenomearBancoPR.Name = "BotaoRenomearBancoPR";
            this.BotaoRenomearBancoPR.Size = new System.Drawing.Size(120, 25);
            this.BotaoRenomearBancoPR.TabIndex = 16;
            this.BotaoRenomearBancoPR.Text = "FDB -> PROLEX";
            this.BotaoRenomearBancoPR.UseVisualStyleBackColor = true;
            this.BotaoRenomearBancoPR.Click += new System.EventHandler(this.BotaoRenomearBancoProtesto_Click);
            // 
            // BotaoRenomearBancoTDPJ
            // 
            this.BotaoRenomearBancoTDPJ.Enabled = false;
            this.BotaoRenomearBancoTDPJ.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.BotaoRenomearBancoTDPJ, 1);
            this.BotaoRenomearBancoTDPJ.Location = new System.Drawing.Point(470, 44);
            this.BotaoRenomearBancoTDPJ.Name = "BotaoRenomearBancoTDPJ";
            this.BotaoRenomearBancoTDPJ.Size = new System.Drawing.Size(120, 25);
            this.BotaoRenomearBancoTDPJ.TabIndex = 17;
            this.BotaoRenomearBancoTDPJ.Text = "FDB -> PROLEX";
            this.BotaoRenomearBancoTDPJ.UseVisualStyleBackColor = true;
            this.BotaoRenomearBancoTDPJ.Click += new System.EventHandler(this.BotaoRenomearBancoTDPJ_Click);
            // 
            // LocalBancoTDPJ
            // 
            this.LocalBancoTDPJ.Enabled = false;
            this.LocalBancoTDPJ.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.LocalBancoTDPJ, 1);
            this.LocalBancoTDPJ.Location = new System.Drawing.Point(89, 44);
            this.LocalBancoTDPJ.Name = "LocalBancoTDPJ";
            this.LocalBancoTDPJ.Size = new System.Drawing.Size(345, 25);
            this.LocalBancoTDPJ.TabIndex = 7;
            this.LocalBancoTDPJ.Text = "Localização do banco de dados TDPJ";
            this.LocalBancoTDPJ.TextChanged += new System.EventHandler(this.LocalBancoTDPJ_TextChanged);
            // 
            // checkBoxTDPJ
            // 
            this.checkBoxTDPJ.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxTDPJ.Location = new System.Drawing.Point(1, 44);
            this.checkBoxTDPJ.Name = "checkBoxTDPJ";
            this.checkBoxTDPJ.Size = new System.Drawing.Size(78, 25);
            this.checkBoxTDPJ.TabIndex = 6;
            this.checkBoxTDPJ.Text = "TDPJ";
            this.checkBoxTDPJ.UseVisualStyleBackColor = true;
            this.checkBoxTDPJ.CheckedChanged += new System.EventHandler(this.CheckBoxTDPJ_CheckedChanged);
            // 
            // checkBoxProtesto
            // 
            this.checkBoxProtesto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxProtesto.Location = new System.Drawing.Point(1, 5);
            this.checkBoxProtesto.Name = "checkBoxProtesto";
            this.checkBoxProtesto.Size = new System.Drawing.Size(78, 25);
            this.checkBoxProtesto.TabIndex = 4;
            this.checkBoxProtesto.Text = "Protesto";
            this.checkBoxProtesto.UseVisualStyleBackColor = true;
            this.checkBoxProtesto.CheckedChanged += new System.EventHandler(this.CheckBoxProtesto_CheckedChanged);
            // 
            // LocalBancoProtesto
            // 
            this.LocalBancoProtesto.Enabled = false;
            this.LocalBancoProtesto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.LocalBancoProtesto, 1);
            this.LocalBancoProtesto.Location = new System.Drawing.Point(89, 5);
            this.LocalBancoProtesto.Name = "LocalBancoProtesto";
            this.LocalBancoProtesto.Size = new System.Drawing.Size(345, 25);
            this.LocalBancoProtesto.TabIndex = 5;
            this.LocalBancoProtesto.Text = "Localização do banco de dados Protesto";
            this.LocalBancoProtesto.TextChanged += new System.EventHandler(this.LocalBancoProtesto_TextChanged);
            // 
            // BotaoAbrirFirebirdCONF
            // 
            this.BotaoAbrirFirebirdCONF.Enabled = false;
            this.BotaoAbrirFirebirdCONF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.BotaoAbrirFirebirdCONF, 1);
            this.BotaoAbrirFirebirdCONF.Location = new System.Drawing.Point(240, 36);
            this.BotaoAbrirFirebirdCONF.Name = "BotaoAbrirFirebirdCONF";
            this.BotaoAbrirFirebirdCONF.Size = new System.Drawing.Size(120, 25);
            this.BotaoAbrirFirebirdCONF.TabIndex = 3;
            this.BotaoAbrirFirebirdCONF.Text = "Arquivo Firebird";
            this.BotaoAbrirFirebirdCONF.UseVisualStyleBackColor = true;
            this.BotaoAbrirFirebirdCONF.Click += new System.EventHandler(this.BotaoAbrirFirebirdCONF_Click);
            // 
            // labelVersao
            // 
            this.labelVersao.AutoSize = true;
            this.labelVersao.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersao.Location = new System.Drawing.Point(528, 486);
            this.labelVersao.Name = "labelVersao";
            this.labelVersao.Size = new System.Drawing.Size(41, 13);
            this.labelVersao.TabIndex = 10;
            this.labelVersao.Text = "Versao";
            // 
            // painelProtesto
            // 
            this.painelProtesto.BackColor = System.Drawing.Color.Transparent;
            this.painelProtesto.Controls.Add(this.checkboxINIPROTESTO);
            this.painelProtesto.Controls.Add(this.labelCaminhoArquivoAliasProlex);
            this.painelProtesto.Controls.Add(this.painelAliasProtesto);
            this.painelProtesto.Enabled = false;
            this.painelProtesto.Location = new System.Drawing.Point(3, 165);
            this.painelProtesto.Name = "painelProtesto";
            this.painelProtesto.Size = new System.Drawing.Size(299, 308);
            this.painelProtesto.TabIndex = 11;
            // 
            // checkboxINIPROTESTO
            // 
            this.checkboxINIPROTESTO.AutoSize = true;
            this.checkboxINIPROTESTO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxINIPROTESTO.Location = new System.Drawing.Point(103, 19);
            this.checkboxINIPROTESTO.Name = "checkboxINIPROTESTO";
            this.checkboxINIPROTESTO.Size = new System.Drawing.Size(87, 25);
            this.checkboxINIPROTESTO.TabIndex = 8;
            this.checkboxINIPROTESTO.Text = "Protesto";
            this.checkboxINIPROTESTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkboxINIPROTESTO.UseVisualStyleBackColor = true;
            this.checkboxINIPROTESTO.CheckedChanged += new System.EventHandler(this.CheckboxINIPROTESTO_CheckedChanged);
            // 
            // labelCaminhoArquivoAliasProlex
            // 
            this.labelCaminhoArquivoAliasProlex.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaminhoArquivoAliasProlex.Location = new System.Drawing.Point(1, 43);
            this.labelCaminhoArquivoAliasProlex.Name = "labelCaminhoArquivoAliasProlex";
            this.labelCaminhoArquivoAliasProlex.Size = new System.Drawing.Size(295, 17);
            this.labelCaminhoArquivoAliasProlex.TabIndex = 21;
            this.labelCaminhoArquivoAliasProlex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // painelAliasProtesto
            // 
            this.painelAliasProtesto.Controls.Add(this.checkBoxEnviaInstrumento);
            this.painelAliasProtesto.Controls.Add(this.labelCaminhoArquivoProgInstrumento);
            this.painelAliasProtesto.Controls.Add(this.checkBoxEnviaSelos);
            this.painelAliasProtesto.Controls.Add(this.labelCaminhoArquivoProgSelos);
            this.painelAliasProtesto.Controls.Add(this.labelTerminal);
            this.painelAliasProtesto.Controls.Add(this.NumeroTerminalProtesto);
            this.painelAliasProtesto.Controls.Add(this.labelAlias);
            this.painelAliasProtesto.Controls.Add(this.labelNome);
            this.painelAliasProtesto.Controls.Add(this.NomeAliasProtesto);
            this.painelAliasProtesto.Controls.Add(this.NomeServidor);
            this.painelAliasProtesto.Enabled = false;
            this.painelAliasProtesto.Location = new System.Drawing.Point(1, 69);
            this.painelAliasProtesto.Name = "painelAliasProtesto";
            this.painelAliasProtesto.Size = new System.Drawing.Size(297, 237);
            this.painelAliasProtesto.TabIndex = 17;
            // 
            // checkBoxEnviaInstrumento
            // 
            this.checkBoxEnviaInstrumento.AutoSize = true;
            this.checkBoxEnviaInstrumento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnviaInstrumento.Location = new System.Drawing.Point(7, 166);
            this.checkBoxEnviaInstrumento.Name = "checkBoxEnviaInstrumento";
            this.checkBoxEnviaInstrumento.Size = new System.Drawing.Size(124, 17);
            this.checkBoxEnviaInstrumento.TabIndex = 13;
            this.checkBoxEnviaInstrumento.Text = "Envia instrumento?";
            this.checkBoxEnviaInstrumento.UseVisualStyleBackColor = true;
            this.checkBoxEnviaInstrumento.CheckedChanged += new System.EventHandler(this.CheckBoxEnviaInstrumento_CheckedChanged);
            // 
            // labelCaminhoArquivoProgInstrumento
            // 
            this.labelCaminhoArquivoProgInstrumento.AutoSize = true;
            this.labelCaminhoArquivoProgInstrumento.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaminhoArquivoProgInstrumento.Location = new System.Drawing.Point(1, 186);
            this.labelCaminhoArquivoProgInstrumento.Name = "labelCaminhoArquivoProgInstrumento";
            this.labelCaminhoArquivoProgInstrumento.Size = new System.Drawing.Size(0, 12);
            this.labelCaminhoArquivoProgInstrumento.TabIndex = 25;
            this.labelCaminhoArquivoProgInstrumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCaminhoArquivoProgInstrumento.Visible = false;
            // 
            // checkBoxEnviaSelos
            // 
            this.checkBoxEnviaSelos.AutoSize = true;
            this.checkBoxEnviaSelos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnviaSelos.Location = new System.Drawing.Point(7, 111);
            this.checkBoxEnviaSelos.Name = "checkBoxEnviaSelos";
            this.checkBoxEnviaSelos.Size = new System.Drawing.Size(87, 17);
            this.checkBoxEnviaSelos.TabIndex = 12;
            this.checkBoxEnviaSelos.Text = "Envia selos?";
            this.checkBoxEnviaSelos.UseVisualStyleBackColor = true;
            this.checkBoxEnviaSelos.CheckedChanged += new System.EventHandler(this.CheckBoxEnviaSelos_CheckedChanged);
            // 
            // labelCaminhoArquivoProgSelos
            // 
            this.labelCaminhoArquivoProgSelos.AutoSize = true;
            this.labelCaminhoArquivoProgSelos.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaminhoArquivoProgSelos.Location = new System.Drawing.Point(1, 131);
            this.labelCaminhoArquivoProgSelos.Name = "labelCaminhoArquivoProgSelos";
            this.labelCaminhoArquivoProgSelos.Size = new System.Drawing.Size(0, 12);
            this.labelCaminhoArquivoProgSelos.TabIndex = 23;
            this.labelCaminhoArquivoProgSelos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCaminhoArquivoProgSelos.Visible = false;
            // 
            // labelTerminal
            // 
            this.labelTerminal.AutoSize = true;
            this.labelTerminal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTerminal.Location = new System.Drawing.Point(4, 84);
            this.labelTerminal.Name = "labelTerminal";
            this.labelTerminal.Size = new System.Drawing.Size(57, 17);
            this.labelTerminal.TabIndex = 17;
            this.labelTerminal.Text = "Terminal";
            // 
            // NumeroTerminalProtesto
            // 
            this.NumeroTerminalProtesto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider1.SetIconPadding(this.NumeroTerminalProtesto, 1);
            this.NumeroTerminalProtesto.Location = new System.Drawing.Point(70, 81);
            this.NumeroTerminalProtesto.Name = "NumeroTerminalProtesto";
            this.NumeroTerminalProtesto.Size = new System.Drawing.Size(193, 25);
            this.NumeroTerminalProtesto.TabIndex = 11;
            this.NumeroTerminalProtesto.Text = "1";
            this.NumeroTerminalProtesto.TextChanged += new System.EventHandler(this.NumeroTerminalProtesto_TextChanged);
            // 
            // labelAlias
            // 
            this.labelAlias.AutoSize = true;
            this.labelAlias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlias.Location = new System.Drawing.Point(4, 44);
            this.labelAlias.Name = "labelAlias";
            this.labelAlias.Size = new System.Drawing.Size(35, 17);
            this.labelAlias.TabIndex = 15;
            this.labelAlias.Text = "Alias";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(4, 5);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(44, 17);
            this.labelNome.TabIndex = 14;
            this.labelNome.Text = "Nome";
            // 
            // linha
            // 
            this.linha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.linha.BackColor = System.Drawing.SystemColors.ControlLight;
            this.linha.Location = new System.Drawing.Point(-5, 89);
            this.linha.Margin = new System.Windows.Forms.Padding(0);
            this.linha.Name = "linha";
            this.linha.Size = new System.Drawing.Size(640, 1);
            this.linha.TabIndex = 9;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 150;
            this.errorProvider1.ContainerControl = this;
            // 
            // logoAutomatiza
            // 
            this.logoAutomatiza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoAutomatiza.Image = ((System.Drawing.Image)(resources.GetObject("logoAutomatiza.Image")));
            this.logoAutomatiza.Location = new System.Drawing.Point(0, 0);
            this.logoAutomatiza.Name = "logoAutomatiza";
            this.logoAutomatiza.Size = new System.Drawing.Size(610, 85);
            this.logoAutomatiza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoAutomatiza.TabIndex = 11;
            this.logoAutomatiza.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.logoAutomatiza);
            this.panel2.Location = new System.Drawing.Point(12, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 85);
            this.panel2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 611);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.linha);
            this.Controls.Add(this.painel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurador: Prolex";
            this.painel.ResumeLayout(false);
            this.painel.PerformLayout();
            this.painelTDPJ.ResumeLayout(false);
            this.painelTDPJ.PerformLayout();
            this.painelAliasTDPJ.ResumeLayout(false);
            this.painelAliasTDPJ.PerformLayout();
            this.painelServidor.ResumeLayout(false);
            this.painelServidor.PerformLayout();
            this.painelFirebird.ResumeLayout(false);
            this.painelFirebird.PerformLayout();
            this.painelProtesto.ResumeLayout(false);
            this.painelProtesto.PerformLayout();
            this.painelAliasProtesto.ResumeLayout(false);
            this.painelAliasProtesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoAutomatiza)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radioServidor;
        private System.Windows.Forms.RadioButton radioTerminal;
        private System.Windows.Forms.TextBox NomeServidor;
        private System.Windows.Forms.TextBox NomeAliasProtesto;
        private System.Windows.Forms.Button Salvar;
        private System.Windows.Forms.Panel painel;
        private System.Windows.Forms.Panel linha;
        private System.Windows.Forms.Label labelVersao;
        private System.Windows.Forms.TextBox LocalBancoProtesto;
        private System.Windows.Forms.TextBox LocalBancoTDPJ;
        private System.Windows.Forms.Panel painelProtesto;
        private System.Windows.Forms.Panel painelServidor;
        private System.Windows.Forms.CheckBox checkBoxTDPJ;
        private System.Windows.Forms.CheckBox checkBoxProtesto;
        private System.Windows.Forms.Button BotaoAbrirFirebirdCONF;
        private System.Windows.Forms.Label labelAlias;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Panel painelFirebird;
        private System.Windows.Forms.Panel painelAliasProtesto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox logoAutomatiza;
        private System.Windows.Forms.Label labelCaminhoArquivoFirebird;
        private System.Windows.Forms.Label labelTerminal;
        private System.Windows.Forms.TextBox NumeroTerminalProtesto;
        private System.Windows.Forms.Label labelCaminhoArquivoAliasProlex;
        private System.Windows.Forms.Panel painelTDPJ;
        private System.Windows.Forms.Label labelCaminhoArquivoAliasProlexXML;
        private System.Windows.Forms.Panel painelAliasTDPJ;
        private System.Windows.Forms.Label labelAlias2;
        private System.Windows.Forms.Label labelNome2;
        private System.Windows.Forms.TextBox NomeAliasTDPJ;
        private System.Windows.Forms.TextBox NomeServidorTDPJ;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkboxXMLTDPJ;
        private System.Windows.Forms.CheckBox checkboxINIPROTESTO;
        private System.Windows.Forms.CheckBox checkBoxEnviaSelos;
        private System.Windows.Forms.Label labelCaminhoArquivoProgSelos;
        private System.Windows.Forms.Button botaoCorrigirRegistro;
        private System.Windows.Forms.CheckBox checkBoxEnviaInstrumento;
        private System.Windows.Forms.Label labelCaminhoArquivoProgInstrumento;
        private System.Windows.Forms.Button BotaoRenomearBancoPR;
        private System.Windows.Forms.Button BotaoRenomearBancoTDPJ;
    }
}

