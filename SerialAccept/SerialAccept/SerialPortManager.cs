// SerialPortManager, adapted version for file transfer between Windows PC and DOS computers, July 2021
//
// from "Basic serial port listening application" by Amund Gjersoe
//
// 
// -http://www.codeproject.com/Articles/75770/Basic-serial-port-listening-application?msg=4305010#xx4305010xx



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace SerialPortListener.Serial
{
    /// <summary>
    /// Manager for serial port data
    /// </summary>
    public class SerialPortManager : IDisposable
    {

        System.Threading.Timer getHandShakeLines;
        
        // Constructor
        public SerialPortManager()
        {

             getHandShakeLines = new System.Threading.Timer(getHandShakeLinesCallback, this, 1000, 1000);

            // Finding installed serial ports on hardware

            string[] ComPorts = System.IO.Ports.SerialPort.GetPortNames();
        
            _currentSerialSettings.PortNameCollection = SerialPort.GetPortNames();

            string[] PortNameArrray = _currentSerialSettings.PortNameCollection;


            for (int i = 0; i < PortNameArrray.Length; i++ )
            {
                if (PortNameArrray[i].Length > 5)
                    PortNameArrray[i] = PortNameArrray[i].Substring(0, 5);
            }

            _currentSerialSettings.PortNameCollection = PortNameArrray;
                
            
            _currentSerialSettings.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_currentSerialSettings_PropertyChanged);

            // If serial ports is found, we select the first found
            if (_currentSerialSettings.PortNameCollection.Length > 0)
                _currentSerialSettings.PortName = _currentSerialSettings.PortNameCollection[0];


            // Closing serial port if it is open
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();

            _serialPort = new SerialPort(
            _currentSerialSettings.PortName,
            _currentSerialSettings.BaudRate,
            _currentSerialSettings.Parity,
            _currentSerialSettings.DataBits,
            _currentSerialSettings.StopBits);

            _serialPort.Open();
          
        }
        ~SerialPortManager()
        {
            Dispose(false);
        }


        #region Fields
        private SerialPort _serialPort;
        private SerialSettings _currentSerialSettings = new SerialSettings();
        private string _latestRecieved = String.Empty;


        #endregion

        #region Properties

        public enum HskState {Undefined, Positive, negative};

        HskState CD_State = HskState.Undefined;
        HskState Cts_State = HskState.Undefined;
        HskState Dsr_State = HskState.Undefined;

        /// <summary>
        /// Gets or sets the current serial port settings
        /// </summary>
        public SerialSettings CurrentSerialSettings
        {
            get { return _currentSerialSettings; }
            set { _currentSerialSettings = value; }
        }

        #endregion

        #region Event handlers

        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;
        public event EventHandler<DisplaySendDataEventArgs> DisplaySendData;
        public event EventHandler<WaitProgressBarEventArgs> ActualizeWaitProgressBar;
        public static event EventHandler<HandShakeEventArgs> NewHandShakeLinesStatesReceived;
        //public event EventHandler<HandShakeEventArgs> NewHandShakeLinesStatesReceived;

        public void setDtrEnable(bool state)
        {
            _serialPort.DtrEnable = state;
            setReceiveStates();
        }


        public void setRtsEnable(bool state)
        {
            _serialPort.RtsEnable = state;
    
            setReceiveStates();
        }

        public void setRTS_Handshake(bool state)
        {
            _serialPort.Handshake = state ? Handshake.RequestToSend : Handshake.None;

           //_serialPort.Handshake = _serialPort.Handshake == Handshake.RequestToSend ? Handshake.None : Handshake.RequestToSend;          
            setReceiveStates();
        }



        void getHandShakeLinesCallback(object state)
        {

            //NewHandShakeLinesStatesReceived(this, new HandShakeEventArgs(SerialPinChange.CDChanged, _serialPort.CDHolding == true ? HskState.Positive : HskState.negative));
            /*
            if (NewHandShakeLinesStatesReceived != null)
            {
                //NewHandShakeLinesStatesReceived(this, new HandShakeEventArgs(true));
                NewHandShakeLinesStatesReceived(this, new SerialPinChangedEventArgs(SerialPinChange.CDChanged));
            }
            */
        }

        void  _currentSerialSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
             // if serial port is changed, a new baud query is issued
            if (e.PropertyName.Equals("PortName"))
            UpdateBaudRateCollection();
        }
         
        void _waitProgressBar(int toDo, int done)
        {
            if (ActualizeWaitProgressBar != null)
                ActualizeWaitProgressBar(this, new WaitProgressBarEventArgs(toDo, done));
        }


        void _displaySendData(byte[] data, int dataLength, bool clrScreen = false)
        {
            if (DisplaySendData != null)
                DisplaySendData(this, new DisplaySendDataEventArgs(data, dataLength, clrScreen));
        }

        
        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLength = _serialPort.BytesToRead;
            byte[] data = new byte[dataLength];
            int nbrDataRead = _serialPort.Read(data, 0, dataLength);
            if (nbrDataRead == 0)
                return;
            
            // Send data to whom ever interested
            if (NewSerialDataRecieved != null)
                NewSerialDataRecieved(this, new SerialDataEventArgs(data));
        }

        #endregion

        #region Methods

        public void setReceiveStates()
        {
            NewHandShakeLinesStatesReceived(this, new HandShakeEventArgs(SerialPinChange.CDChanged, _serialPort.CDHolding == true ? HskState.Positive : HskState.negative));
            NewHandShakeLinesStatesReceived(this, new HandShakeEventArgs(SerialPinChange.CtsChanged, _serialPort.CtsHolding == true ? HskState.Positive : HskState.negative));
            NewHandShakeLinesStatesReceived(this, new HandShakeEventArgs(SerialPinChange.DsrChanged, _serialPort.DsrHolding == true ? HskState.Positive : HskState.negative));
        }
        

        public bool SendFile(string file, bool convertToHex, bool sendToCOM, bool makeCopyFile, string copyFilePath, bool DtrEnable, bool RtsEnable, bool RTS_Handshake, UInt16 sendDelay, int startDelay)
        {
            System.IO.FileStream _FileStream = null;
            try
            {
                _FileStream = new System.IO.FileStream(file, System.IO.FileMode.Open,
                                      System.IO.FileAccess.Read);
            }
            catch
            {
                MessageBox.Show("Please select file to transmit before starting");
                return false;
            }

            System.IO.FileStream _CopyFileStream = null;
            if (makeCopyFile)
            {
                try
                {
                    if (File.Exists(copyFilePath))
                    {
                        DialogResult IOresult =  MessageBox.Show("File " + copyFilePath + " exists!\r\n\r\n Overwrite?\r\n\r\n Path and Filename can be changed in Settings", "", MessageBoxButtons.OKCancel);
                        if (IOresult == DialogResult.OK)
                        {
                            File.Delete(copyFilePath);
                            _CopyFileStream = new System.IO.FileStream(copyFilePath, System.IO.FileMode.Create,
                                          System.IO.FileAccess.Write);
                        }
                        else
                        {
                            try
                            {
                                _FileStream.Close();
                                return false;
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        _CopyFileStream = new System.IO.FileStream(copyFilePath, System.IO.FileMode.Create,
                                          System.IO.FileAccess.Write);
                    }
                    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessageBox.Show("Please select Copy-Filename and -Folder in Settings");

                    return false;
                }
            }


            // Closing serial port if it is open
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();

            _serialPort = new SerialPort(
            _currentSerialSettings.PortName,
            _currentSerialSettings.BaudRate,
            _currentSerialSettings.Parity,
            _currentSerialSettings.DataBits,
            _currentSerialSettings.StopBits);

            _serialPort.DtrEnable = DtrEnable;
            _serialPort.RtsEnable = RtsEnable;
            _serialPort.Handshake = RTS_Handshake ? Handshake.RequestToSend : Handshake.None;


            _serialPort.Open();
            _serialPort.WriteTimeout = 10000;
            

            int msWaited = 0;
            DateTime startTime = DateTime.Now;
            while (((DateTime.Now.Ticks - startTime.Ticks) / TimeSpan.TicksPerSecond) < startDelay)
            {
                Thread.Sleep(200);
                msWaited += 200;
                _waitProgressBar(startDelay * 1000, msWaited);
            }
            _waitProgressBar(startDelay * 1000, startDelay * 1000);


            const int blklen = 16;
            int[] buff = new int[blklen];
            UInt32 readIndex = 0;


            //Int32 readValue = 0;
            byte[] outByte = new byte[1] {0};

            bool lastByteRead = false;

            _displaySendData(new byte[1] { 0x00 }, 1, true);

            while (!lastByteRead)
            {
                readIndex = 0;
                while (readIndex < blklen && !lastByteRead)
                {
                    buff[readIndex] = _FileStream.ReadByte();
                    if (buff[readIndex] == -1)
                    {
                        lastByteRead = true;
                    }
                    else
                    {
                        readIndex++;
                    }
                }

                if (convertToHex)
                {
                    if (sendToCOM)
                        _serialPort.Write(":");
                    if (makeCopyFile)
                        _CopyFileStream.Write(new byte[1] { 0x3A }, 0, 1);
                }

                for (int i = 0; i < readIndex; i++)
                {
                    byte[] theByte = new byte[1];
                    byte[] twoBytes = new byte[2];
                    theByte[0] = (byte)buff[i];
                    string hex;
                    if (convertToHex)
                    {
                        hex = BitConverter.ToString(theByte, 0, 1).Replace("-", string.Empty);
                        twoBytes = UTF8Encoding.UTF8.GetBytes(hex);
                        _displaySendData(twoBytes, 2);
                    }
                    else
                    {
                        hex = ((char)theByte[0]).ToString();
                        _displaySendData(theByte, 1);
                    }
                    if (convertToHex)
                    {
                        
                        if (sendToCOM)
                            _serialPort.Write(hex);
                        while (_serialPort.BytesToWrite > 20)
                        {
                            Thread.Sleep(5);
                        }
                        Thread.Sleep(sendDelay);
                        if (makeCopyFile)
                            _CopyFileStream.Write(new byte[2] { (byte)hex[0], (byte)hex[1] }, 0, 2);
                    }
                    else
                    {
                        if (sendToCOM)
                            _serialPort.Write(hex);
                        if (makeCopyFile)
                            _CopyFileStream.Write(new byte[1] { (byte)hex[0] }, 0, 1);
                    }
                }
                if (convertToHex)
                {
                    _displaySendData(new byte[2] { 0x0D, 0x0A }, 2);
                    if (sendToCOM)
                        _serialPort.Write("\r\n");
                    if (makeCopyFile)
                        _CopyFileStream.Write(new byte[2] { 0x0D, 0x0A }, 0, 2);
                }
            }

            if (convertToHex)
            {
                //if (sendToCOM)
                //    _serialPort.Write(new byte[1] { 0x1A }, 0, 1);
                //if (makeCopyFile)
                //    _CopyFileStream.Write(new byte[1] { 0x1A }, 0, 1);
            }

            
            // close file stream
            try
            {
                _FileStream.Close();
            }
            catch { }
            try
            {
               _CopyFileStream.Close();
            }
            catch { }

            // MessageBox.Show("Mission accomplished!");

            return true;
        }
       
        /// <summary>
        /// Connects to a serial port defined through the current settings
        /// </summary>
        public void StartListening()
        {
            // Closing serial port if it is open
            if (_serialPort != null && _serialPort.IsOpen)
                    _serialPort.Close();

            if (_currentSerialSettings.PortName.Length > 5)
                _currentSerialSettings.PortName = _currentSerialSettings.PortName.Substring(0, 5);
            // Setting serial port settings
            _serialPort = new SerialPort(
                _currentSerialSettings.PortName,
                _currentSerialSettings.BaudRate,
                _currentSerialSettings.Parity,
                _currentSerialSettings.DataBits,
                _currentSerialSettings.StopBits);

            // Subscribe to event and open serial port for data
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            _serialPort.PinChanged += _serialPort_PinChanged;

            // Important for C'T 86 DtrEnable must be true
            _serialPort.DtrEnable = true;

            _serialPort.Open();          
        }

        public void refreshSerialPort()
        {
            // Closing serial port if it is open
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();

            _serialPort = new SerialPort(
            _currentSerialSettings.PortName,
            _currentSerialSettings.BaudRate,
            _currentSerialSettings.Parity,
            _currentSerialSettings.DataBits,
            _currentSerialSettings.StopBits);

            _serialPort.Open();
        }

        private void _serialPort_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)        
        {

            SerialPinChange pinChange = e.EventType;
            HskState state = HskState.Undefined;

            switch (e.EventType)
            {
                case SerialPinChange.CDChanged:
                {
                        CD_State = _serialPort.CDHolding ? HskState.Positive : HskState.negative;
                        state = CD_State;
                        break;
                }
                case SerialPinChange.CtsChanged:
                {
                        Cts_State = _serialPort.CtsHolding ? HskState.Positive : HskState.negative;
                        state = Cts_State;
                        break;
                }
                case SerialPinChange.DsrChanged:
                {
                        Dsr_State = _serialPort.DsrHolding ? HskState.Positive : HskState.negative;
                        state = Dsr_State;
                        break;
                }
                default:
                    { }
                    break;
            }
                          
            if (NewHandShakeLinesStatesReceived != null)
            {           
                NewHandShakeLinesStatesReceived(this, new HandShakeEventArgs(e.EventType, state));
            }          
        }
       

        /// <summary>
        /// Closes the serial port
        /// </summary>
        public void StopListening()
        {
            _serialPort.Close();
        }


        /// <summary>
        /// Retrieves the current selected device's COMMPROP structure, and extracts the dwSettableBaud property
        /// </summary>
        private void UpdateBaudRateCollection()
        {
            if (_currentSerialSettings.PortName.Length > 5)
                _currentSerialSettings.PortName = _currentSerialSettings.PortName.Substring(0, 5);

            //_serialPort = new SerialPort(_currentSerialSettings.PortName);
            _serialPort = new SerialPort("COM1");
            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                int nons = 1;
                nons = nons + 1;
            }

            object p = _serialPort.BaseStream.GetType().GetField("commProp", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_serialPort.BaseStream);
            Int32 dwSettableBaud = (Int32)p.GetType().GetField("dwSettableBaud", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(p);

            _serialPort.Close();
            _currentSerialSettings.UpdateBaudRateCollection(dwSettableBaud);
        }

        // Call to release serial port
        public void Dispose()
        {
            Dispose(true);
        }

        // Part of basic design pattern for implementing Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serialPort.DataReceived -= new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            // Releasing serial port (and other unmanaged objects)
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.Dispose();
            }
        }
        #endregion
    }

    public class WaitProgressBarEventArgs : EventArgs
    {
        public WaitProgressBarEventArgs(int toDo, int done)
        {
            ToDo = toDo;
            Done = done;
        }
        /// <summary>
        /// Data to mangage waitProgressBar
        /// </summary>
        public int ToDo;
        public int Done;

    }

    /// <summary>
    /// EventArgs used to send bytes recieved on serial port
    /// </summary>
    public class SerialDataEventArgs : EventArgs
    {
        public SerialDataEventArgs(byte[] dataInByteArray)
        {
            Data = dataInByteArray;
        }

        /// <summary>
        /// Byte array containing data from serial port
        /// </summary>
        public byte[] Data;
    }

    /// <summary>
    /// EventArgs used to send states of handshakeLines
    /// </summary>
    public class SerialPinChangedEventArgs : EventArgs
    {
        public SerialPinChangedEventArgs(SerialPinChange pinChange)
        {
            SerialPinChange PinChange = pinChange;
        }

        /// <summary>
        /// States of handshake Lines
        /// </summary>
        public SerialPinChange PinChange;
    }

    /// <summary>
    /// EventArgs used to send states of handshakeLines
    /// </summary>
    public class HandShakeEventArgs : EventArgs
    {
        public HandShakeEventArgs(SerialPinChange pinChange, SerialPortManager.HskState state)
        {
            PinChange = pinChange;
            State = state;
        }

        /// <summary>
        /// States of handshake Lines
        /// </summary>
        public SerialPortManager.HskState State;
        public SerialPinChange PinChange;
    }


    /// <summary>
    /// EventArgs used send data to be displayed
    /// </summary>
    public class DisplaySendDataEventArgs : EventArgs
    {
        public DisplaySendDataEventArgs(byte[] data, int dataLength, bool clrScreen = false)
        {
            ClrScreen = clrScreen;
            Data = data;
            DataLength = dataLength;

        }
        /// <summary>
        /// Data to be displayed
        /// </summary>
        public byte[] Data;
        public int  DataLength;
        public bool ClrScreen;

    }
}
