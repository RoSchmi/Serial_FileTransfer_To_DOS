// Copyright RoSchmi 2021, License Apache 2.0
// 
// This is a tool to transfer files from a Windows PC to DOS based retro computers
//
// Textfiles can be transfered as they are, binary files can be converted to a special 'hex format' before they are transferded.
// On the DOS side there is another special program needed to convert the received files from the 'hex format' back to the original binary format
//
// On the DOS side the GWBasic program 'COM1TOFI.BAS' (or for COM2 'COM2TOFI.BAS') is needed to receive the incomming data and store them into a file
// Important !!! : In GWBASIC a larger buffer of 2048 bytes for the COM-Port has to be reserved, so start with: GWBASIC COM1TOFI /c:2048 
//
// When the transfered file was sent converted into the special hex-format it has to be converted back to the original content using
// the GWBASIC program: 'HEXTOBIN.BAS'

// The GWBASIC programs can be found in the folder 'UtilityProgs' of this repository

// The program 'HEXTOBIN.BAS' is from here:
// -https://forum.classic-computing.de/forum/index.php?thread/9167-datei%C3%BCbetragung-%C3%BCber-com-port/&postID=90767&highlight=DOS%2BDatei%2Bbasic#post90767

// Some helpful and interesting links:
// -http://jcoppens.com/soft/howto/bootstrap/index.en.php
// -http://oldcomputers.dyndns.org/public/pub/rechner/eaca/common/User-Clubs/Club-80/Transfer_mit_pip_-_club80_netzwerk.pdf


// Parts of this application ar taken from
// "Basic serial port listening application" by Amund Gjersoe
//
// -http://www.codeproject.com/Articles/75770/Basic-serial-port-listening-application?msg=4305010#xx4305010xx




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Xml;

using SerialPortListener.Serial;
using System.Diagnostics;

namespace SerialAccept
{
    public partial class MainForm : Form
    {

        //#######  Fields specify the Folder Names and File Names (can be modified) #####
        const string prmSubfolderName = @"RoSchmi\PortParameter";
        const string prmDatName = "PortParameter.xml";

        string SerialDatName = "SerialDats.xml";
        //###############################################################################

        //###### Fields for processing of serial bytes to strings #######
        bool TakeOverPrepared = false;
        int ByteToSet = 0;
        byte FirstByte = 0x00;
        byte SecondByte = 0x00;
        string DisplayString = "";
        
        //################################################################
       
        bool DataReceived = false;
        
        string SerialDatsFolderName = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

        string FileToBeSentFolderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string FileToBeSentFilePath = "";

        // Received files can have a maximal size of 500000 bytes
        byte[] receivedBytes = new byte[500000];
        int byteCounter = 0;

        string akt_Path = "";
        string prm_Path = "";

        DataSet SerialDataSet = new DataSet("SerialDataSet");
        DataTable T = new DataTable("T");
        DataColumn B = new DataColumn("B", typeof(string));
        DataTable M = new DataTable("M");
        DataColumn S = new DataColumn("S",typeof(string));

        DataSet ParameterDataSet = new DataSet();
        

        string Form_PortName = "COM15";
        int Form_BaudRate = 9600;
        int Form_DataBits = 8;
        string Form_Parity = "None";
        string Form_StopBits = "One";

        SerialPortManager _spManager;

       
        public MainForm()
        {
            InitializeComponent();

            checkBoxConvertToHex.Checked = false;
            checkBoxDtrEnable.Checked = true;
            checkBoxDtrEnable_Rec.Checked = true;
            checkBoxRtsEnable.Checked = false;
            checkBoxRtsEnable_Rec.Checked = false;
            checkBoxRTSHandshake.Checked = false;
            checkBoxRTSHandshake_Rec.Checked = false;

            checkBoxSendToCOM.Checked = true;
            checkBoxConvertToHex.Checked = true;
            checkBoxMakeCopyFile.Checked = true;

            textBoxCdState.BackColor = Color.White;
            textBoxCdState_Rec.BackColor = Color.White;

            textBoxCtsState.BackColor = Color.White;
            textBoxCtsState_Rec.BackColor = Color.White;

            textBoxDsrState.BackColor = Color.White;
            textBoxDsrState_Rec.BackColor = Color.White;

            akt_Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            prm_Path = Path.Combine(akt_Path, @prmSubfolderName);

            textBoxSerialDatsFolderName.Text = SerialDatsFolderName;

            textBoxSerialDatName.Text = SerialDatName;

            numericUpDownBeforeStartSend.Value = 2;


            #region  Create directory and write / read parameter file for the serial port

            if (!Directory.Exists(prm_Path))
            {
                try
                {
                    Directory.CreateDirectory(prm_Path);
                }
                catch
                {
                    MessageBox.Show(@"Directory could not be created.");
                }
            }
            if (!File.Exists(Path.Combine(prm_Path, prmDatName)))
            {

               
                DialogResult key =
                   MessageBox.Show("File " + Path.Combine(prm_Path, prmDatName) + " does not exist. \n\n"
                                     + "The file will be created\n"
                                     + "Click >Abbrechen< if you do not want to create the file",
                   "Bestätigung",
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question);
                if (key == DialogResult.OK)
                {
                    MessageBox.Show("The file will be created");
                    XmlTextWriter writer1 = new XmlTextWriter(Path.Combine(prm_Path, prmDatName), null);
                    writer1.Formatting = Formatting.Indented;
                    writer1.WriteStartDocument();
                    writer1.WriteStartElement("Params");
                    writer1.WriteStartElement("Port");
                    writer1.WriteString("COM3");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("BaudRate");
                    writer1.WriteString("9600");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("DataBits");
                    writer1.WriteString("8");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("Parity");
                    writer1.WriteString("None");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("StopBits");
                    writer1.WriteString("One");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("FolderName");
                    writer1.WriteString(SerialDatsFolderName);
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("FileName");
                    writer1.WriteString(SerialDatName);
                    writer1.WriteEndElement();
                    writer1.WriteEndElement();
                    writer1.WriteEndDocument();
                    writer1.Close();
                }
            }
            try
            {
                ParameterDataSet.ReadXml(Path.Combine(prm_Path, prmDatName));
            }
            catch
            {
                MessageBox.Show("File with stored Serial Port Parameters could not be read.");
                return;
            }
           
            Form_PortName = ParameterDataSet.Tables[0].Rows[0]["Port"].ToString();
            if (Form_PortName.Length > 5)
                Form_PortName = Form_PortName.Substring(0, 5);



            try
            {
                Form_BaudRate = int.Parse(ParameterDataSet.Tables[0].Rows[0]["BaudRate"].ToString());
            }
            catch
            {
            }
            
            try
            {
            Form_DataBits = int.Parse(ParameterDataSet.Tables[0].Rows[0]["DataBits"].ToString());
            }
            catch
            {
            }
            Form_Parity = ParameterDataSet.Tables[0].Rows[0]["Parity"].ToString();
            Form_StopBits = ParameterDataSet.Tables[0].Rows[0]["StopBits"].ToString();
            SerialDatsFolderName = ParameterDataSet.Tables[0].Rows[0]["FolderName"].ToString();
            textBoxSerialDatsFolderName.Text = SerialDatsFolderName;
            SerialDatName = ParameterDataSet.Tables[0].Rows[0]["FileName"].ToString();
            textBoxSerialDatName.Text = SerialDatName;
            #endregion

           
            //Initialize 
            UserInitialization();

            SetSerialPortToSavedSettings(Form_PortName, Form_BaudRate, Form_DataBits, Form_Parity, Form_StopBits);

            //Start Listening on Serial Port
            buttonStart_Click_Do();
        
        }

     

        //########## Methods  ##############################################

        #region Method - Create or read DataSet for the incoming Data
        private void Create_Or_Read_SerialDataSet()
        {
            string YearPath = Path.Combine(SerialDatsFolderName, DateTime.Today.Year.ToString());
            //MessageBox.Show(YearPath);
            string MonthPath = Path.Combine(@YearPath,  X_Stellig.Zahl(DateTime.Today.Month.ToString(),2));
            //MessageBox.Show(MonthPath);

            if (!Directory.Exists(@MonthPath))
            {
                try
                {
                    Directory.CreateDirectory(@MonthPath);
                }
                catch
                {
                    MessageBox.Show(@"Directory could not be created.");
                }
            }
            string ActFileName = Path.Combine(@MonthPath, Path.GetFileNameWithoutExtension(SerialDatName) + "_" + DateTime.Today.Year.ToString() + "_" + X_Stellig.Zahl(DateTime.Today.Month.ToString(),2) + "_" + X_Stellig.Zahl(DateTime.Today.Day.ToString(),2) + ".xml");
            //MessageBox.Show(ActFileName);

            
            if (!File.Exists(@ActFileName))
            {
                    XmlTextWriter writer1 = new XmlTextWriter(ActFileName, null);
                    writer1.Formatting = Formatting.Indented;
                    writer1.WriteStartDocument();
                    writer1.WriteStartElement("SerialDataSet");
                    writer1.WriteStartElement("T");
                    writer1.WriteStartElement("B");
                    writer1.WriteString("00");
                    writer1.WriteEndElement();
                    writer1.WriteEndElement();
                    
                    writer1.WriteStartElement("M");
                    writer1.WriteStartElement("I");
                    writer1.WriteString("*");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("S");
                    writer1.WriteString("*");
                    writer1.WriteEndElement();
                    writer1.WriteEndElement();

                    writer1.WriteEndElement();
                    writer1.WriteEndDocument();
                    writer1.Close();
                 
                
            }
            try
            {
                SerialDataSet.ReadXml(ActFileName);
            }
            catch
            {
                MessageBox.Show("File with stored SerialDats could not be read.");
                return;
            }
        }
        #endregion

        #region Method - UserInitialization of Serial Port Settings
        private void UserInitialization()
        {
            _spManager = new SerialPortManager();
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;
            serialSettingsBindingSource.DataSource = mySerialSettings;
            portNameComboBox.DataSource = mySerialSettings.PortNameCollection;
            baudRateComboBox.DataSource = mySerialSettings.BaudRateCollection;
 
            dataBitsComboBox.DataSource = mySerialSettings.DataBitsCollection;
            parityComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            stopBitsComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));
            
            
            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
            _spManager.DisplaySendData += _spManager_DisplaySendData;
            _spManager.ActualizeWaitProgressBar += _spManager_ActualizeWaitProgressBar;

            timerSaveMessage.Interval = 3000;

            timerSaveMessage.Tick += TimerSaveMessage_Tick;
            timerSaveMessage.Stop();

            
            SerialPortManager.NewHandShakeLinesStatesReceived += SerialPortManager_NewHandShakeLinesStatesReceived;

            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }
      
        #endregion

        #region Method - SetSerialPortToSavedSettings

        void SetSerialPortToSavedSettings(string pPortName, int pBaudRate, int pDataBits, string pParity, string pStopBits)
        {
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;

            if (mySerialSettings.PortNameCollection.Contains(pPortName))
            {
                mySerialSettings.PortName = pPortName;
                portNameComboBox.Text = pPortName;
            }

            if (mySerialSettings.BaudRateCollection.Contains(pBaudRate))
            {
                mySerialSettings.BaudRate = pBaudRate;
                baudRateComboBox.Text = pBaudRate.ToString();
            }

            if (mySerialSettings.DataBitsCollection.Contains(pDataBits))
            {
                mySerialSettings.DataBits = pDataBits;
                dataBitsComboBox.Text = pDataBits.ToString();
            }
            if (Enum.GetNames(typeof(System.IO.Ports.Parity)).Contains(pParity))
            {
            mySerialSettings.Parity =  (Parity)Enum.Parse(typeof(System.IO.Ports.Parity), pParity);
            parityComboBox.Text = pParity;
            }
            if (Enum.GetNames(typeof(System.IO.Ports.StopBits)).Contains(pStopBits))
            {
                mySerialSettings.StopBits = (StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), pStopBits);
                stopBitsComboBox.Text = pStopBits;
            }          
        }

        #endregion

        #region Method - Start Listening on Serial Port
        void buttonStart_Click_Do()
        {
            tbData.Text = "";
            _spManager.StartListening();
            byteCounter = 0;
        }
        #endregion

        #region Method - Stop Listening on Serial Port
        // Stop Listening on Serial Port
        void btnStop_Click_Do()
        {
            string thePath = Path.GetFullPath(Path.Combine(@textBoxSerialDatsFolderName.Text, @textBoxSerialDatName.Text));

            if (File.Exists(thePath))
            {
                DialogResult IOresult = MessageBox.Show("File " + thePath + " exists!\r\n\r\n Overwrite?\r\n\r\n Path and Filename can be changed in Settings", "", MessageBoxButtons.OKCancel);
                if (IOresult == DialogResult.OK)
                {
                    File.Delete(thePath);              
                }
                else
                {
                    return;
                }
            }

            _spManager.StopListening();

            SaveReceivedBytesToFile();

            textBoxSaveMessage.Text = "Data written to File";

            timerSaveMessage.Start();
        }
        #endregion

        void SaveReceivedBytesToFile()
        {
            string thePath;
            try
            {
                thePath = Path.GetFullPath(Path.Combine(@textBoxSerialDatsFolderName.Text, @textBoxSerialDatName.Text));
            }
            catch
            {
                MessageBox.Show("Invalid Filename!");
                return;
            }

            if (File.Exists(thePath))
            {
                File.Delete(thePath);
            }

            System.IO.FileStream _FileStream = new System.IO.FileStream(thePath, System.IO.FileMode.Create,
                                  System.IO.FileAccess.Write);
            // Writes a block of bytes to this stream using data from
            // a byte array.
            _FileStream.Write(receivedBytes, 0, byteCounter);

            // close file stream
            _FileStream.Close();
            

        }

       
        //########## Events  ###############################################

        #region Event - MainForm Closing
        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult key =
                   MessageBox.Show("Really want to Close the Program",
                                     
                   "Confirm",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
            e.Cancel = (key == DialogResult.No);
            if (key == DialogResult.Yes)
            {
                
                _spManager.StopListening();
                
                _spManager.Dispose();
            }

        }
        #endregion

       

        #region Event - New NewHandShakeLinesStatesReceived
        //private void _spManager_NewHandShakeLinesStatesReceived(object sender, SerialPortListener.Serial.HandShakeEventArgs e)
        private void SerialPortManager_NewHandShakeLinesStatesReceived(object sender, HandShakeEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                //this.BeginInvoke(new EventHandler<SerialPortListener.Serial.HandShakeEventArgs>(_spManager_NewHandShakeLinesStatesReceived), new object[] { sender, e });
                this.BeginInvoke(new EventHandler<SerialPortListener.Serial.HandShakeEventArgs>(SerialPortManager_NewHandShakeLinesStatesReceived), new object[] { sender, e });
                return;
                
            }

            switch (e.PinChange)
            {
                case SerialPinChange.CDChanged:
                    {
                        //textBoxCtsState.BackColor = textBoxCtsState.BackColor == Color.LightGray ? textBoxCtsState.BackColor = Color.LightGreen : Color.LightGray;
                        
                        switch (e.State)
                        {
                            case SerialPortManager.HskState.Undefined:
                                {
                                    textBoxCdState.BackColor = Color.White;
                                    textBoxCdState_Rec.BackColor = Color.White;
                                }
                                break;

                            case SerialPortManager.HskState.Positive:
                                {
                                    textBoxCdState.BackColor = Color.OrangeRed;
                                    textBoxCdState_Rec.BackColor = Color.OrangeRed;
                                }
                                break;
                            case SerialPortManager.HskState.negative:
                                {
                                    textBoxCdState.BackColor = Color.LightBlue;
                                    textBoxCdState_Rec.BackColor = Color.LightBlue;
                                }
                                break;

                        }                                                    
                        Debug.WriteLine("Cd changed");                       
                        break;
                    };

                case SerialPinChange.CtsChanged:
                    {

                        switch (e.State)
                        {
                            case SerialPortManager.HskState.Undefined:
                                {
                                    textBoxCtsState.BackColor = Color.White;
                                    textBoxCtsState_Rec.BackColor = Color.White;
                                }
                                break;

                            case SerialPortManager.HskState.Positive:
                                {
                                    textBoxCtsState.BackColor = Color.OrangeRed;
                                    textBoxCtsState_Rec.BackColor = Color.OrangeRed;
                                }
                                break;
                            case SerialPortManager.HskState.negative:
                                {
                                    textBoxCtsState.BackColor = Color.LightBlue;
                                    textBoxCtsState_Rec.BackColor = Color.LightBlue;
                                }
                                break;

                        }                      
                        Debug.WriteLine("Cts changed");                       
                        break;
                    };
                case SerialPinChange.DsrChanged:
                    {

                        switch (e.State)
                        {
                            case SerialPortManager.HskState.Undefined:
                                {
                                    textBoxDsrState.BackColor = Color.White;
                                    textBoxDsrState_Rec.BackColor = Color.White;
                                }
                                break;

                            case SerialPortManager.HskState.Positive:
                                {
                                    textBoxDsrState.BackColor = Color.OrangeRed;
                                    textBoxDsrState_Rec.BackColor = Color.OrangeRed;
                                }
                                break;
                            case SerialPortManager.HskState.negative:
                                {
                                    textBoxDsrState.BackColor = Color.LightBlue;
                                    textBoxDsrState_Rec.BackColor = Color.LightBlue;
                                }
                                break;                            
                        }

                        textBoxDsrState.Refresh();
                        textBoxCdState.Refresh();
                        textBoxCtsState.Refresh();
                        textBoxDsrState_Rec.Refresh();
                        textBoxCdState_Rec.Refresh();
                        textBoxCtsState_Rec.Refresh();                     
                        Debug.WriteLine("Dsr changed");                       
                        break;
                    };
            }          
        }

        #endregion


        private void _spManager_ActualizeWaitProgressBar(object sender, WaitProgressBarEventArgs e)
        {
            double partDone = (double)e.Done / e.ToDo;
            progressBarWait.Value = (int)(progressBarWait.Maximum * partDone);
        }


        private void _spManager_DisplaySendData(object sender, DisplaySendDataEventArgs e)
        {
            if (this.InvokeRequired)
            {

                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<DisplaySendDataEventArgs>(_spManager_DisplaySendData), new object[] { sender, e });
                return;
            }

            if (e.ClrScreen)
            {
                tbDataSend.Text = String.Empty;
            }

            int maxTextLength = 1000; // maximum text length in text box
            if (tbDataSend.TextLength > maxTextLength)
            {
                int toDelete = tbDataSend.TextLength - maxTextLength;
                tbDataSend.Text = tbDataSend.Text.Remove(0, toDelete > 300 ? toDelete : 300);
            }

            string str = string.Empty;
            if (e.DataLength == 1)
            {
                if (e.Data[0] < 0x20 || e.Data[0] > 0x7E)
                {
                    str = " ";
                }
                else
                {
                    str = Encoding.ASCII.GetString(e.Data);
                }

            }
            else
            {
                str = Encoding.ASCII.GetString(e.Data);
            }          
            tbDataSend.AppendText(str);
            tbDataSend.ScrollToCaret();
        }

        #region Event - New serial Data received

        void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {

                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            int maxTextLength = 1000; // maximum text length in text box
            if (tbData.TextLength > maxTextLength)
                tbData.Text = tbData.Text.Remove(0, tbData.TextLength - maxTextLength);

            byte[] displayableBatch = new byte[e.Data.Length];
            for (int i = 0; i < e.Data.Length; i++)
            {
                displayableBatch[i] = GetChar.DisplayableByteFromOne(e.Data[i]);
                receivedBytes[byteCounter] = e.Data[i];
                byteCounter++;
            }

           string str = Encoding.ASCII.GetString(displayableBatch);
          
           tbData.AppendText(str);
           tbData.ScrollToCaret();

           DataReceived = true;          
        }
        #endregion

        #region Event - timerSaveMessage_Tick
        //This timer clears the Message that Data are saved to file after timer interval

        private void TimerSaveMessage_Tick(object sender, EventArgs e)
        {
            textBoxSaveMessage.Text = "";
            textBoxSaveMessage.BackColor = Color.WhiteSmoke;
            timerSaveMessage.Stop();
        }
        #endregion


        //######## Button Click Events  ####################################

        #region Button Click - Start Listening on Serial port
        // Handles the "Start Listening"-buttom click event
        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart_Click_Do();                                 
        }        
        #endregion


        #region Button Click - Stop Listening on serial port
        // Handles the "Stop Listening"-buttom click event
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop_Click_Do();
        }       
        #endregion


        #region Button Click - Write modified serial port Parameters to file
        //Write modified serial port Parameters to file
        private void buttonSaveParameters_Click(object sender, EventArgs e)
        {
            //Char[] Invalid;
            //Invalid = Path.GetInvalidFileNameChars();
            //MessageBox.Show(Invalid[0].ToString() + " " + Invalid[1].ToString());

            try
            {
                Path.GetFileName(Path.Combine(@textBoxSerialDatsFolderName.Text, @textBoxSerialDatName.Text));
            }
            catch
            {
                MessageBox.Show("Invalid Filename!");
                return;
            }

            ParameterDataSet.Tables[0].Rows[0]["Port"] = portNameComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["BaudRate"] = baudRateComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["DataBits"] = dataBitsComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["Parity"] = parityComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["StopBits"] = stopBitsComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["FolderName"] = textBoxSerialDatsFolderName.Text;
            ParameterDataSet.Tables[0].Rows[0]["FileName"] = textBoxSerialDatName.Text;
            ParameterDataSet.AcceptChanges();
            ParameterDataSet.WriteXml(Path.Combine(prm_Path, prmDatName));
            ParameterDataSet.Clear();
            ParameterDataSet.AcceptChanges();
            ParameterDataSet.ReadXml(Path.Combine(prm_Path, prmDatName));
            ParameterDataSet.AcceptChanges();
        }
        #endregion


        #region Button Click - Browse for new directory to save the incoming serial data
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBoxSerialDatsFolderName.Text;
            folderBrowserDialog1.ShowDialog();
            SerialDatsFolderName = folderBrowserDialog1.SelectedPath;
            
            textBoxSerialDatsFolderName.Text = folderBrowserDialog1.SelectedPath;          
        }

        #endregion

        #region Button Click - Browse for File to be sent
        private void buttonSelectFileToSend_Click(object sender, EventArgs e)
        {       
            openFileDialog1.InitialDirectory = FileToBeSentFolderName;
            if (!File.Exists(openFileDialog1.FileName))
            {
                openFileDialog1.FileName = "";
            }
            openFileDialog1.FileName = "";
            FileToBeSentFolderName = "";
            openFileDialog1.ShowDialog();
            FileToBeSentFolderName = Path.GetDirectoryName(openFileDialog1.FileName);
            textBoxFileToBeSent.Text = Path.GetFileName(openFileDialog1.FileName);
            FileToBeSentFilePath = Path.GetFullPath(openFileDialog1.FileName);    
        }

        #endregion

        #region Button Click - Send File
        private void buttonbuttonSendFile_Click(object sender, EventArgs e)
        {
            if (!checkBoxMakeCopyFile.Checked && !checkBoxSendToCOM.Checked)
            {
                MessageBox.Show("At least one of the options (Send to COM-Port or Save Copy as File) must be selected");
                return;
            }

            _spManager.SendFile(FileToBeSentFilePath, checkBoxConvertToHex.Checked, checkBoxSendToCOM.Checked, checkBoxMakeCopyFile.Checked, Path.Combine(textBoxSerialDatsFolderName.Text, textBoxSerialDatName.Text), checkBoxDtrEnable.Checked, checkBoxRtsEnable.Checked, checkBoxRTSHandshake.Checked, (ushort)numericUpDownSendBetweenDelay.Value, (int)numericUpDownBeforeStartSend.Value);
        }

        #endregion
      
        #region Button Clicks - Mangage Handshake Output signals

        private void checkBoxDtrEnable_CheckedChanged(object sender, EventArgs e)
        {

            if (_spManager != null)
            {
                _spManager.setDtrEnable(checkBoxDtrEnable.Checked);
                checkBoxDtrEnable_Rec.Checked = checkBoxDtrEnable.Checked;
            }

        }

        private void checkBoxRtsEnable_Clicked (object sender, EventArgs e)
        {
            if (_spManager != null)
            {
                if(checkBoxRtsEnable.Checked)
                {
                    if (checkBoxRTSHandshake.Checked)
                    {
                        checkBoxRtsEnable.Checked = false;
                        MessageBox.Show("Cannot be set when Handshake.RequestToSend is activated");
                    }
                    else
                    {
                        _spManager.setRtsEnable(checkBoxRtsEnable.Checked);
                        checkBoxRtsEnable_Rec.Checked = checkBoxRtsEnable.Checked;
                    }
                }
                else
                {
                    _spManager.setRtsEnable(checkBoxRtsEnable.Checked);
                    checkBoxRtsEnable_Rec.Checked = checkBoxRtsEnable.Checked;
                }
                
            }
        }

        private void checkBoxRTSHandshake_Clicked(object sender, EventArgs e)
        {
            if (_spManager != null)
            {

                if (checkBoxRTSHandshake.Checked)
                {
                    if (checkBoxRtsEnable.Checked)
                    {
                        checkBoxRTSHandshake.Checked = false;
                        MessageBox.Show("Cannot be set when RtsEnable is activated");
                    }
                    else
                    {
                        _spManager.setRTS_Handshake(checkBoxRTSHandshake.Checked);
                        checkBoxRTSHandshake_Rec.Checked = checkBoxRTSHandshake.Checked;
                    }

                }
                else
                {
                    _spManager.setRTS_Handshake(checkBoxRTSHandshake.Checked);
                    checkBoxRTSHandshake_Rec.Checked = checkBoxRTSHandshake.Checked;

                }

            }
        }

        private void checkBoxRtsEnable_CheckedChanged(object sender, EventArgs e)
        {}

        private void checkBoxRTSHandshake_CheckedChanged(object sender, EventArgs e)
        {}

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _spManager.refreshSerialPort();    
        }

        private void checkBoxDtrEnable_Rec_CheckedChanged(object sender, EventArgs e)
        {
            if (_spManager != null)
            {
                _spManager.setDtrEnable(checkBoxDtrEnable.Checked);
                checkBoxDtrEnable.Checked = checkBoxDtrEnable_Rec.Checked;
            }
        }

        private void checkBoxRtsEnable_Rec_Clicked(object sender, EventArgs e)
        {
            if (_spManager != null)
            {
                if (checkBoxRtsEnable_Rec.Checked)
                {
                    if (checkBoxRTSHandshake_Rec.Checked)
                    {
                        checkBoxRtsEnable_Rec.Checked = false;
                        MessageBox.Show("Cannot be set when Handshake.RequestToSend is activated");
                    }
                    else
                    {
                        _spManager.setRtsEnable(checkBoxRtsEnable_Rec.Checked);
                        checkBoxRtsEnable.Checked = checkBoxRtsEnable_Rec.Checked;
                    }
                }
                else
                {
                    _spManager.setRtsEnable(checkBoxRtsEnable_Rec.Checked);
                    checkBoxRtsEnable.Checked = checkBoxRtsEnable_Rec.Checked;
                }

            }
        }

        private void checkBoxRTSHandshake_Rec_Clicked(object sender, EventArgs e)
        {
            if (_spManager != null)
            {

                if (checkBoxRTSHandshake_Rec.Checked)
                {
                    if (checkBoxRtsEnable_Rec.Checked)
                    {
                        checkBoxRTSHandshake_Rec.Checked = false;
                        MessageBox.Show("Cannot be set when RtsEnable is activated");
                    }
                    else
                    {
                        _spManager.setRTS_Handshake(checkBoxRTSHandshake_Rec.Checked);
                        checkBoxRTSHandshake.Checked = checkBoxRTSHandshake_Rec.Checked;
                    }

                }
                else
                {
                    _spManager.setRTS_Handshake(checkBoxRTSHandshake_Rec.Checked);
                    checkBoxRTSHandshake.Checked = checkBoxRTSHandshake_Rec.Checked;

                }

            }
        }

        private void checkBoxRtsEnable_Rec_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxRTSHandshake_Rec_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion                             
    }
}









        
    

