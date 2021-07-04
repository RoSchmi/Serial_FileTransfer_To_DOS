namespace SerialAccept
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbData = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxDsrState_Rec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCdState_Rec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCtsState_Rec = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxRTSHandshake_Rec = new System.Windows.Forms.CheckBox();
            this.checkBoxRtsEnable_Rec = new System.Windows.Forms.CheckBox();
            this.checkBoxDtrEnable_Rec = new System.Windows.Forms.CheckBox();
            this.textBoxSaveMessage = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButtonCRLF = new System.Windows.Forms.RadioButton();
            this.radioButtonCtrlZ = new System.Windows.Forms.RadioButton();
            this.radioButtonLF = new System.Windows.Forms.RadioButton();
            this.radioButtonHexChars = new System.Windows.Forms.RadioButton();
            this.radioButtonCR = new System.Windows.Forms.RadioButton();
            this.radioButtonNothing = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSendChars = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxDsrState = new System.Windows.Forms.TextBox();
            this.labelDSR = new System.Windows.Forms.Label();
            this.textBoxCdState = new System.Windows.Forms.TextBox();
            this.labelCD = new System.Windows.Forms.Label();
            this.textBoxCtsState = new System.Windows.Forms.TextBox();
            this.labelCTS = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBarWait = new System.Windows.Forms.ProgressBar();
            this.checkBoxSendToCOM = new System.Windows.Forms.CheckBox();
            this.checkBoxMakeCopyFile = new System.Windows.Forms.CheckBox();
            this.labelDelayToStartSend = new System.Windows.Forms.Label();
            this.numericUpDownBeforeStartSend = new System.Windows.Forms.NumericUpDown();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.checkBoxConvertToHex = new System.Windows.Forms.CheckBox();
            this.labelSendDelay = new System.Windows.Forms.Label();
            this.numericUpDownSendBetweenDelay = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxRTSHandshake = new System.Windows.Forms.CheckBox();
            this.checkBoxRtsEnable = new System.Windows.Forms.CheckBox();
            this.checkBoxDtrEnable = new System.Windows.Forms.CheckBox();
            this.tbDataSend = new System.Windows.Forms.TextBox();
            this.textBoxFileToBeSent = new System.Windows.Forms.TextBox();
            this.buttonSelectFileToSend = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSerialDatName = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSerialDatsFolderName = new System.Windows.Forms.TextBox();
            this.buttonSaveParameters = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stopBitsLabel = new System.Windows.Forms.Label();
            this.parityLabel = new System.Windows.Forms.Label();
            this.dataBitsLabel = new System.Windows.Forms.Label();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.portNameLable = new System.Windows.Forms.Label();
            this.stopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.parityComboBox = new System.Windows.Forms.ComboBox();
            this.dataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.baudRateComboBox = new System.Windows.Forms.ComboBox();
            this.portNameComboBox = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerSaveMessage = new System.Windows.Forms.Timer(this.components);
            this.serialSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeforeStartSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendBetweenDelay)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialSettingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(65, 467);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Listening";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(65, 188);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(600, 245);
            this.tbData.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(196, 467);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(113, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Write to File";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(843, 566);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.textBoxSaveMessage);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.tbData);
            this.tabPage1.Controls.Add(this.btnStop);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(835, 540);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Receive";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 493);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "(select file in Settings)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxDsrState_Rec);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.textBoxCdState_Rec);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.textBoxCtsState_Rec);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(310, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(312, 115);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Handshake Input States";
            // 
            // textBoxDsrState_Rec
            // 
            this.textBoxDsrState_Rec.Location = new System.Drawing.Point(6, 90);
            this.textBoxDsrState_Rec.Name = "textBoxDsrState_Rec";
            this.textBoxDsrState_Rec.Size = new System.Drawing.Size(100, 20);
            this.textBoxDsrState_Rec.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "WinPC input DSR (Datset ready)";
            // 
            // textBoxCdState_Rec
            // 
            this.textBoxCdState_Rec.Location = new System.Drawing.Point(6, 64);
            this.textBoxCdState_Rec.Name = "textBoxCdState_Rec";
            this.textBoxCdState_Rec.Size = new System.Drawing.Size(100, 20);
            this.textBoxCdState_Rec.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "WinPC input CD (Carrier detect)";
            // 
            // textBoxCtsState_Rec
            // 
            this.textBoxCtsState_Rec.Location = new System.Drawing.Point(6, 38);
            this.textBoxCtsState_Rec.Name = "textBoxCtsState_Rec";
            this.textBoxCtsState_Rec.Size = new System.Drawing.Size(100, 20);
            this.textBoxCtsState_Rec.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "WinPC Input CTS (Clear to send)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxRTSHandshake_Rec);
            this.groupBox4.Controls.Add(this.checkBoxRtsEnable_Rec);
            this.groupBox4.Controls.Add(this.checkBoxDtrEnable_Rec);
            this.groupBox4.Location = new System.Drawing.Point(65, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 101);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Handshake Output Settings";
            // 
            // checkBoxRTSHandshake_Rec
            // 
            this.checkBoxRTSHandshake_Rec.AutoSize = true;
            this.checkBoxRTSHandshake_Rec.Location = new System.Drawing.Point(26, 68);
            this.checkBoxRTSHandshake_Rec.Name = "checkBoxRTSHandshake_Rec";
            this.checkBoxRTSHandshake_Rec.Size = new System.Drawing.Size(106, 17);
            this.checkBoxRTSHandshake_Rec.TabIndex = 2;
            this.checkBoxRTSHandshake_Rec.Text = "RTS-Handshake";
            this.checkBoxRTSHandshake_Rec.UseVisualStyleBackColor = true;
            this.checkBoxRTSHandshake_Rec.CheckedChanged += new System.EventHandler(this.checkBoxRTSHandshake_Rec_CheckedChanged);
            this.checkBoxRTSHandshake_Rec.Click += new System.EventHandler(this.checkBoxRTSHandshake_Rec_Clicked);
            // 
            // checkBoxRtsEnable_Rec
            // 
            this.checkBoxRtsEnable_Rec.AutoSize = true;
            this.checkBoxRtsEnable_Rec.Location = new System.Drawing.Point(26, 44);
            this.checkBoxRtsEnable_Rec.Name = "checkBoxRtsEnable_Rec";
            this.checkBoxRtsEnable_Rec.Size = new System.Drawing.Size(75, 17);
            this.checkBoxRtsEnable_Rec.TabIndex = 1;
            this.checkBoxRtsEnable_Rec.Text = "RtsEnable";
            this.checkBoxRtsEnable_Rec.UseVisualStyleBackColor = true;
            this.checkBoxRtsEnable_Rec.CheckedChanged += new System.EventHandler(this.checkBoxRtsEnable_Rec_CheckedChanged);
            this.checkBoxRtsEnable_Rec.Click += new System.EventHandler(this.checkBoxRtsEnable_Rec_Clicked);
            // 
            // checkBoxDtrEnable_Rec
            // 
            this.checkBoxDtrEnable_Rec.AutoSize = true;
            this.checkBoxDtrEnable_Rec.Location = new System.Drawing.Point(26, 20);
            this.checkBoxDtrEnable_Rec.Name = "checkBoxDtrEnable_Rec";
            this.checkBoxDtrEnable_Rec.Size = new System.Drawing.Size(73, 17);
            this.checkBoxDtrEnable_Rec.TabIndex = 0;
            this.checkBoxDtrEnable_Rec.Text = "DtrEnable";
            this.checkBoxDtrEnable_Rec.UseVisualStyleBackColor = true;
            this.checkBoxDtrEnable_Rec.CheckedChanged += new System.EventHandler(this.checkBoxDtrEnable_Rec_CheckedChanged);
            // 
            // textBoxSaveMessage
            // 
            this.textBoxSaveMessage.Location = new System.Drawing.Point(437, 469);
            this.textBoxSaveMessage.Name = "textBoxSaveMessage";
            this.textBoxSaveMessage.ReadOnly = true;
            this.textBoxSaveMessage.Size = new System.Drawing.Size(228, 20);
            this.textBoxSaveMessage.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.textBoxSendChars);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.progressBar1);
            this.tabPage3.Controls.Add(this.progressBarWait);
            this.tabPage3.Controls.Add(this.checkBoxSendToCOM);
            this.tabPage3.Controls.Add(this.checkBoxMakeCopyFile);
            this.tabPage3.Controls.Add(this.labelDelayToStartSend);
            this.tabPage3.Controls.Add(this.numericUpDownBeforeStartSend);
            this.tabPage3.Controls.Add(this.buttonSendFile);
            this.tabPage3.Controls.Add(this.checkBoxConvertToHex);
            this.tabPage3.Controls.Add(this.labelSendDelay);
            this.tabPage3.Controls.Add(this.numericUpDownSendBetweenDelay);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.tbDataSend);
            this.tabPage3.Controls.Add(this.textBoxFileToBeSent);
            this.tabPage3.Controls.Add(this.buttonSelectFileToSend);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(835, 540);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Transmit";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioButtonCRLF);
            this.groupBox7.Controls.Add(this.radioButtonCtrlZ);
            this.groupBox7.Controls.Add(this.radioButtonLF);
            this.groupBox7.Controls.Add(this.radioButtonHexChars);
            this.groupBox7.Controls.Add(this.radioButtonCR);
            this.groupBox7.Controls.Add(this.radioButtonNothing);
            this.groupBox7.Location = new System.Drawing.Point(561, 163);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(107, 178);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            // 
            // radioButtonCRLF
            // 
            this.radioButtonCRLF.AutoSize = true;
            this.radioButtonCRLF.Location = new System.Drawing.Point(8, 85);
            this.radioButtonCRLF.Name = "radioButtonCRLF";
            this.radioButtonCRLF.Size = new System.Drawing.Size(52, 17);
            this.radioButtonCRLF.TabIndex = 1;
            this.radioButtonCRLF.Text = "CRLF";
            this.radioButtonCRLF.UseVisualStyleBackColor = true;
            // 
            // radioButtonCtrlZ
            // 
            this.radioButtonCtrlZ.AutoSize = true;
            this.radioButtonCtrlZ.Location = new System.Drawing.Point(8, 108);
            this.radioButtonCtrlZ.Name = "radioButtonCtrlZ";
            this.radioButtonCtrlZ.Size = new System.Drawing.Size(89, 17);
            this.radioButtonCtrlZ.TabIndex = 1;
            this.radioButtonCtrlZ.Text = "Ctrl-Z ( 0x1A )";
            this.radioButtonCtrlZ.UseVisualStyleBackColor = true;
            // 
            // radioButtonLF
            // 
            this.radioButtonLF.AutoSize = true;
            this.radioButtonLF.Location = new System.Drawing.Point(8, 61);
            this.radioButtonLF.Name = "radioButtonLF";
            this.radioButtonLF.Size = new System.Drawing.Size(37, 17);
            this.radioButtonLF.TabIndex = 1;
            this.radioButtonLF.Text = "LF";
            this.radioButtonLF.UseVisualStyleBackColor = true;
            // 
            // radioButtonHexChars
            // 
            this.radioButtonHexChars.AutoSize = true;
            this.radioButtonHexChars.Location = new System.Drawing.Point(8, 131);
            this.radioButtonHexChars.Name = "radioButtonHexChars";
            this.radioButtonHexChars.Size = new System.Drawing.Size(74, 17);
            this.radioButtonHexChars.TabIndex = 2;
            this.radioButtonHexChars.Text = "Hex-Chars";
            this.radioButtonHexChars.UseVisualStyleBackColor = true;
            // 
            // radioButtonCR
            // 
            this.radioButtonCR.AutoSize = true;
            this.radioButtonCR.Location = new System.Drawing.Point(8, 33);
            this.radioButtonCR.Name = "radioButtonCR";
            this.radioButtonCR.Size = new System.Drawing.Size(40, 17);
            this.radioButtonCR.TabIndex = 1;
            this.radioButtonCR.Text = "CR";
            this.radioButtonCR.UseVisualStyleBackColor = true;
            // 
            // radioButtonNothing
            // 
            this.radioButtonNothing.AutoSize = true;
            this.radioButtonNothing.Checked = true;
            this.radioButtonNothing.Location = new System.Drawing.Point(8, 10);
            this.radioButtonNothing.Name = "radioButtonNothing";
            this.radioButtonNothing.Size = new System.Drawing.Size(62, 17);
            this.radioButtonNothing.TabIndex = 0;
            this.radioButtonNothing.TabStop = true;
            this.radioButtonNothing.Text = "Nothing";
            this.radioButtonNothing.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(486, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Append:";
            // 
            // textBoxSendChars
            // 
            this.textBoxSendChars.Location = new System.Drawing.Point(674, 294);
            this.textBoxSendChars.Name = "textBoxSendChars";
            this.textBoxSendChars.Size = new System.Drawing.Size(139, 20);
            this.textBoxSendChars.TabIndex = 27;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxDsrState);
            this.groupBox6.Controls.Add(this.labelDSR);
            this.groupBox6.Controls.Add(this.textBoxCdState);
            this.groupBox6.Controls.Add(this.labelCD);
            this.groupBox6.Controls.Add(this.textBoxCtsState);
            this.groupBox6.Controls.Add(this.labelCTS);
            this.groupBox6.Location = new System.Drawing.Point(515, 43);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(298, 120);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Handshake Input States";
            // 
            // textBoxDsrState
            // 
            this.textBoxDsrState.Location = new System.Drawing.Point(6, 94);
            this.textBoxDsrState.Name = "textBoxDsrState";
            this.textBoxDsrState.Size = new System.Drawing.Size(100, 20);
            this.textBoxDsrState.TabIndex = 11;
            // 
            // labelDSR
            // 
            this.labelDSR.AutoSize = true;
            this.labelDSR.Location = new System.Drawing.Point(115, 97);
            this.labelDSR.Name = "labelDSR";
            this.labelDSR.Size = new System.Drawing.Size(161, 13);
            this.labelDSR.TabIndex = 14;
            this.labelDSR.Text = "WinPC input DSR (Datset ready)";
            // 
            // textBoxCdState
            // 
            this.textBoxCdState.Location = new System.Drawing.Point(6, 65);
            this.textBoxCdState.Name = "textBoxCdState";
            this.textBoxCdState.Size = new System.Drawing.Size(100, 20);
            this.textBoxCdState.TabIndex = 10;
            // 
            // labelCD
            // 
            this.labelCD.AutoSize = true;
            this.labelCD.Location = new System.Drawing.Point(112, 68);
            this.labelCD.Name = "labelCD";
            this.labelCD.Size = new System.Drawing.Size(156, 13);
            this.labelCD.TabIndex = 13;
            this.labelCD.Text = "WinPC input CD (Carrier detect)";
            // 
            // textBoxCtsState
            // 
            this.textBoxCtsState.Location = new System.Drawing.Point(6, 31);
            this.textBoxCtsState.Name = "textBoxCtsState";
            this.textBoxCtsState.Size = new System.Drawing.Size(100, 20);
            this.textBoxCtsState.TabIndex = 9;
            // 
            // labelCTS
            // 
            this.labelCTS.AutoSize = true;
            this.labelCTS.Location = new System.Drawing.Point(115, 38);
            this.labelCTS.Name = "labelCTS";
            this.labelCTS.Size = new System.Drawing.Size(162, 13);
            this.labelCTS.TabIndex = 12;
            this.labelCTS.Text = "WinPC Input CTS (Clear to send)";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(393, 231);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(71, 10);
            this.progressBar1.TabIndex = 20;
            // 
            // progressBarWait
            // 
            this.progressBarWait.Location = new System.Drawing.Point(317, 231);
            this.progressBarWait.Name = "progressBarWait";
            this.progressBarWait.Size = new System.Drawing.Size(71, 10);
            this.progressBarWait.TabIndex = 19;
            // 
            // checkBoxSendToCOM
            // 
            this.checkBoxSendToCOM.AutoSize = true;
            this.checkBoxSendToCOM.Location = new System.Drawing.Point(48, 77);
            this.checkBoxSendToCOM.Name = "checkBoxSendToCOM";
            this.checkBoxSendToCOM.Size = new System.Drawing.Size(112, 17);
            this.checkBoxSendToCOM.TabIndex = 18;
            this.checkBoxSendToCOM.Text = "Send to COM-Port";
            this.checkBoxSendToCOM.UseVisualStyleBackColor = true;
            // 
            // checkBoxMakeCopyFile
            // 
            this.checkBoxMakeCopyFile.AutoSize = true;
            this.checkBoxMakeCopyFile.Location = new System.Drawing.Point(48, 100);
            this.checkBoxMakeCopyFile.Name = "checkBoxMakeCopyFile";
            this.checkBoxMakeCopyFile.Size = new System.Drawing.Size(111, 17);
            this.checkBoxMakeCopyFile.TabIndex = 17;
            this.checkBoxMakeCopyFile.Text = "Save Copy as File";
            this.checkBoxMakeCopyFile.UseVisualStyleBackColor = true;
            // 
            // labelDelayToStartSend
            // 
            this.labelDelayToStartSend.AutoSize = true;
            this.labelDelayToStartSend.Location = new System.Drawing.Point(330, 119);
            this.labelDelayToStartSend.Name = "labelDelayToStartSend";
            this.labelDelayToStartSend.Size = new System.Drawing.Size(134, 13);
            this.labelDelayToStartSend.TabIndex = 16;
            this.labelDelayToStartSend.Text = "Wait seconds  before send";
            // 
            // numericUpDownBeforeStartSend
            // 
            this.numericUpDownBeforeStartSend.Location = new System.Drawing.Point(260, 112);
            this.numericUpDownBeforeStartSend.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownBeforeStartSend.Name = "numericUpDownBeforeStartSend";
            this.numericUpDownBeforeStartSend.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownBeforeStartSend.TabIndex = 15;
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.Location = new System.Drawing.Point(317, 170);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(147, 47);
            this.buttonSendFile.TabIndex = 7;
            this.buttonSendFile.Text = "Send File via COM-Port";
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonbuttonSendFile_Click);
            // 
            // checkBoxConvertToHex
            // 
            this.checkBoxConvertToHex.AutoSize = true;
            this.checkBoxConvertToHex.Location = new System.Drawing.Point(48, 52);
            this.checkBoxConvertToHex.Name = "checkBoxConvertToHex";
            this.checkBoxConvertToHex.Size = new System.Drawing.Size(127, 17);
            this.checkBoxConvertToHex.TabIndex = 6;
            this.checkBoxConvertToHex.Text = "ConvertToHexFormat";
            this.checkBoxConvertToHex.UseVisualStyleBackColor = true;
            // 
            // labelSendDelay
            // 
            this.labelSendDelay.AutoSize = true;
            this.labelSendDelay.Location = new System.Drawing.Point(330, 77);
            this.labelSendDelay.Name = "labelSendDelay";
            this.labelSendDelay.Size = new System.Drawing.Size(134, 13);
            this.labelSendDelay.TabIndex = 5;
            this.labelSendDelay.Text = "Delay in ms btw sent Chars";
            // 
            // numericUpDownSendBetweenDelay
            // 
            this.numericUpDownSendBetweenDelay.Location = new System.Drawing.Point(260, 70);
            this.numericUpDownSendBetweenDelay.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownSendBetweenDelay.Name = "numericUpDownSendBetweenDelay";
            this.numericUpDownSendBetweenDelay.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownSendBetweenDelay.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxRTSHandshake);
            this.groupBox3.Controls.Add(this.checkBoxRtsEnable);
            this.groupBox3.Controls.Add(this.checkBoxDtrEnable);
            this.groupBox3.Location = new System.Drawing.Point(48, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 101);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Handshake Output Settings";
            // 
            // checkBoxRTSHandshake
            // 
            this.checkBoxRTSHandshake.AutoSize = true;
            this.checkBoxRTSHandshake.Location = new System.Drawing.Point(26, 68);
            this.checkBoxRTSHandshake.Name = "checkBoxRTSHandshake";
            this.checkBoxRTSHandshake.Size = new System.Drawing.Size(106, 17);
            this.checkBoxRTSHandshake.TabIndex = 2;
            this.checkBoxRTSHandshake.Text = "RTS-Handshake";
            this.checkBoxRTSHandshake.UseVisualStyleBackColor = true;
            this.checkBoxRTSHandshake.CheckedChanged += new System.EventHandler(this.checkBoxRTSHandshake_CheckedChanged);
            this.checkBoxRTSHandshake.Click += new System.EventHandler(this.checkBoxRTSHandshake_Clicked);
            // 
            // checkBoxRtsEnable
            // 
            this.checkBoxRtsEnable.AutoSize = true;
            this.checkBoxRtsEnable.Location = new System.Drawing.Point(26, 44);
            this.checkBoxRtsEnable.Name = "checkBoxRtsEnable";
            this.checkBoxRtsEnable.Size = new System.Drawing.Size(75, 17);
            this.checkBoxRtsEnable.TabIndex = 1;
            this.checkBoxRtsEnable.Text = "RtsEnable";
            this.checkBoxRtsEnable.UseVisualStyleBackColor = true;
            this.checkBoxRtsEnable.CheckedChanged += new System.EventHandler(this.checkBoxRtsEnable_CheckedChanged);
            this.checkBoxRtsEnable.Click += new System.EventHandler(this.checkBoxRtsEnable_Clicked);
            // 
            // checkBoxDtrEnable
            // 
            this.checkBoxDtrEnable.AutoSize = true;
            this.checkBoxDtrEnable.Location = new System.Drawing.Point(26, 20);
            this.checkBoxDtrEnable.Name = "checkBoxDtrEnable";
            this.checkBoxDtrEnable.Size = new System.Drawing.Size(73, 17);
            this.checkBoxDtrEnable.TabIndex = 0;
            this.checkBoxDtrEnable.Text = "DtrEnable";
            this.checkBoxDtrEnable.UseVisualStyleBackColor = true;
            this.checkBoxDtrEnable.CheckedChanged += new System.EventHandler(this.checkBoxDtrEnable_CheckedChanged);
            // 
            // tbDataSend
            // 
            this.tbDataSend.Location = new System.Drawing.Point(48, 288);
            this.tbDataSend.Multiline = true;
            this.tbDataSend.Name = "tbDataSend";
            this.tbDataSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDataSend.Size = new System.Drawing.Size(447, 199);
            this.tbDataSend.TabIndex = 2;
            // 
            // textBoxFileToBeSent
            // 
            this.textBoxFileToBeSent.Location = new System.Drawing.Point(48, 14);
            this.textBoxFileToBeSent.Name = "textBoxFileToBeSent";
            this.textBoxFileToBeSent.Size = new System.Drawing.Size(402, 20);
            this.textBoxFileToBeSent.TabIndex = 1;
            // 
            // buttonSelectFileToSend
            // 
            this.buttonSelectFileToSend.Location = new System.Drawing.Point(456, 14);
            this.buttonSelectFileToSend.Name = "buttonSelectFileToSend";
            this.buttonSelectFileToSend.Size = new System.Drawing.Size(114, 23);
            this.buttonSelectFileToSend.TabIndex = 0;
            this.buttonSelectFileToSend.Text = "Select File to send";
            this.buttonSelectFileToSend.UseVisualStyleBackColor = true;
            this.buttonSelectFileToSend.Click += new System.EventHandler(this.buttonSelectFileToSend_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.buttonSaveParameters);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(835, 540);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSerialDatName);
            this.groupBox2.Controls.Add(this.buttonBrowse);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxSerialDatsFolderName);
            this.groupBox2.Location = new System.Drawing.Point(84, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(657, 128);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Path to store incoming data (Page Receive) and copy of sent data (Page Transmit)";
            // 
            // textBoxSerialDatName
            // 
            this.textBoxSerialDatName.Location = new System.Drawing.Point(9, 84);
            this.textBoxSerialDatName.Name = "textBoxSerialDatName";
            this.textBoxSerialDatName.Size = new System.Drawing.Size(285, 20);
            this.textBoxSerialDatName.TabIndex = 5;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(515, 45);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Folder Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "File Name";
            // 
            // textBoxSerialDatsFolderName
            // 
            this.textBoxSerialDatsFolderName.Location = new System.Drawing.Point(6, 45);
            this.textBoxSerialDatsFolderName.Name = "textBoxSerialDatsFolderName";
            this.textBoxSerialDatsFolderName.ReadOnly = true;
            this.textBoxSerialDatsFolderName.Size = new System.Drawing.Size(478, 20);
            this.textBoxSerialDatsFolderName.TabIndex = 3;
            // 
            // buttonSaveParameters
            // 
            this.buttonSaveParameters.Location = new System.Drawing.Point(338, 409);
            this.buttonSaveParameters.Name = "buttonSaveParameters";
            this.buttonSaveParameters.Size = new System.Drawing.Size(106, 37);
            this.buttonSaveParameters.TabIndex = 2;
            this.buttonSaveParameters.Text = "Save Settings";
            this.buttonSaveParameters.UseVisualStyleBackColor = true;
            this.buttonSaveParameters.Click += new System.EventHandler(this.buttonSaveParameters_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stopBitsLabel);
            this.groupBox1.Controls.Add(this.parityLabel);
            this.groupBox1.Controls.Add(this.dataBitsLabel);
            this.groupBox1.Controls.Add(this.baudRateLabel);
            this.groupBox1.Controls.Add(this.portNameLable);
            this.groupBox1.Controls.Add(this.stopBitsComboBox);
            this.groupBox1.Controls.Add(this.parityComboBox);
            this.groupBox1.Controls.Add(this.dataBitsComboBox);
            this.groupBox1.Controls.Add(this.baudRateComboBox);
            this.groupBox1.Controls.Add(this.portNameComboBox);
            this.groupBox1.Location = new System.Drawing.Point(84, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port Settings";
            // 
            // stopBitsLabel
            // 
            this.stopBitsLabel.AutoSize = true;
            this.stopBitsLabel.Location = new System.Drawing.Point(27, 192);
            this.stopBitsLabel.Name = "stopBitsLabel";
            this.stopBitsLabel.Size = new System.Drawing.Size(52, 13);
            this.stopBitsLabel.TabIndex = 9;
            this.stopBitsLabel.Text = "Stop Bits:";
            // 
            // parityLabel
            // 
            this.parityLabel.AutoSize = true;
            this.parityLabel.Location = new System.Drawing.Point(27, 155);
            this.parityLabel.Name = "parityLabel";
            this.parityLabel.Size = new System.Drawing.Size(36, 13);
            this.parityLabel.TabIndex = 8;
            this.parityLabel.Text = "Parity:";
            // 
            // dataBitsLabel
            // 
            this.dataBitsLabel.AutoSize = true;
            this.dataBitsLabel.Location = new System.Drawing.Point(27, 117);
            this.dataBitsLabel.Name = "dataBitsLabel";
            this.dataBitsLabel.Size = new System.Drawing.Size(53, 13);
            this.dataBitsLabel.TabIndex = 7;
            this.dataBitsLabel.Text = "Data Bits:";
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Location = new System.Drawing.Point(27, 77);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(61, 13);
            this.baudRateLabel.TabIndex = 6;
            this.baudRateLabel.Text = "Baud Rate:";
            // 
            // portNameLable
            // 
            this.portNameLable.AutoSize = true;
            this.portNameLable.Location = new System.Drawing.Point(27, 33);
            this.portNameLable.Name = "portNameLable";
            this.portNameLable.Size = new System.Drawing.Size(60, 13);
            this.portNameLable.TabIndex = 5;
            this.portNameLable.Text = "Port Name:";
            // 
            // stopBitsComboBox
            // 
            this.stopBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitsComboBox.FormattingEnabled = true;
            this.stopBitsComboBox.Location = new System.Drawing.Point(95, 184);
            this.stopBitsComboBox.Name = "stopBitsComboBox";
            this.stopBitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.stopBitsComboBox.TabIndex = 4;
            // 
            // parityComboBox
            // 
            this.parityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityComboBox.FormattingEnabled = true;
            this.parityComboBox.Location = new System.Drawing.Point(95, 147);
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(121, 21);
            this.parityComboBox.TabIndex = 3;
            // 
            // dataBitsComboBox
            // 
            this.dataBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBitsComboBox.FormattingEnabled = true;
            this.dataBitsComboBox.Location = new System.Drawing.Point(95, 109);
            this.dataBitsComboBox.Name = "dataBitsComboBox";
            this.dataBitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.dataBitsComboBox.TabIndex = 2;
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.serialSettingsBindingSource, "BaudRate", true));
            this.baudRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRateComboBox.FormattingEnabled = true;
            this.baudRateComboBox.Location = new System.Drawing.Point(95, 69);
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.baudRateComboBox.TabIndex = 1;
            // 
            // portNameComboBox
            // 
            this.portNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.serialSettingsBindingSource, "PortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.portNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portNameComboBox.FormattingEnabled = true;
            this.portNameComboBox.Location = new System.Drawing.Point(95, 30);
            this.portNameComboBox.Name = "portNameComboBox";
            this.portNameComboBox.Size = new System.Drawing.Size(121, 21);
            this.portNameComboBox.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // serialSettingsBindingSource
            // 
            this.serialSettingsBindingSource.DataSource = typeof(SerialPortListener.Serial.SerialSettings);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 571);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer File To/From COM-Port";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeforeStartSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendBetweenDelay)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serialSettingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbData;
       // private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox baudRateComboBox;
        private System.Windows.Forms.ComboBox portNameComboBox;
        private System.Windows.Forms.BindingSource serialSettingsBindingSource;
        private System.Windows.Forms.ComboBox stopBitsComboBox;
        private System.Windows.Forms.ComboBox parityComboBox;
        private System.Windows.Forms.ComboBox dataBitsComboBox;
        private System.Windows.Forms.Label stopBitsLabel;
        private System.Windows.Forms.Label parityLabel;
        private System.Windows.Forms.Label dataBitsLabel;
        private System.Windows.Forms.Label baudRateLabel;
        private System.Windows.Forms.Label portNameLable;
        private System.Windows.Forms.Button buttonSaveParameters;
        private System.Windows.Forms.TextBox textBoxSerialDatsFolderName;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBoxSerialDatName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSaveMessage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonSelectFileToSend;
        private System.Windows.Forms.TextBox textBoxFileToBeSent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxDtrEnable;
        private System.Windows.Forms.TextBox tbDataSend;
        private System.Windows.Forms.CheckBox checkBoxRtsEnable;
        private System.Windows.Forms.CheckBox checkBoxRTSHandshake;
        private System.Windows.Forms.CheckBox checkBoxConvertToHex;
        private System.Windows.Forms.Label labelSendDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownSendBetweenDelay;
        private System.Windows.Forms.Button buttonSendFile;
        private System.Windows.Forms.TextBox textBoxCtsState;
        private System.Windows.Forms.TextBox textBoxDsrState;
        private System.Windows.Forms.TextBox textBoxCdState;
        private System.Windows.Forms.Label labelDSR;
        private System.Windows.Forms.Label labelCD;
        private System.Windows.Forms.Label labelCTS;
        private System.Windows.Forms.Label labelDelayToStartSend;
        private System.Windows.Forms.NumericUpDown numericUpDownBeforeStartSend;
        private System.Windows.Forms.CheckBox checkBoxMakeCopyFile;
        private System.Windows.Forms.CheckBox checkBoxSendToCOM;
        private System.Windows.Forms.ProgressBar progressBarWait;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timerSaveMessage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxRTSHandshake_Rec;
        private System.Windows.Forms.CheckBox checkBoxRtsEnable_Rec;
        private System.Windows.Forms.CheckBox checkBoxDtrEnable_Rec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDsrState_Rec;
        private System.Windows.Forms.TextBox textBoxCdState_Rec;
        private System.Windows.Forms.TextBox textBoxCtsState_Rec;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSendChars;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonCtrlZ;
        private System.Windows.Forms.RadioButton radioButtonCRLF;
        private System.Windows.Forms.RadioButton radioButtonLF;
        private System.Windows.Forms.RadioButton radioButtonCR;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radioButtonHexChars;
        private System.Windows.Forms.RadioButton radioButtonNothing;
    }
}

