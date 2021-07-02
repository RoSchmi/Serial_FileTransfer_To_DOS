using SerialPortListener.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialAccept
{
    public partial class ComPortSender : Form
    {
        SerialPortManager portManager;
        SerialPort serialPort;
        static System.Windows.Forms.Timer portSenderTimer_01 = new System.Windows.Forms.Timer();
        public ComPortSender(SerialPortManager  pPortManager)
        {
            InitializeComponent();
            portManager = pPortManager;        
            textBox1.BackColor = Color.Gray;
            portSenderTimer_01.Interval = 1000;
            portSenderTimer_01.Tick += PortSenderTimer_01_Tick;
            portSenderTimer_01.Start();
        }

        private void PortSenderTimer_01_Tick(object sender, EventArgs e)
        {
            textBox1.BackColor = textBox1.BackColor == Color.Gray ? Color.Green : Color.Gray;
        }

        private void buttonCloseComPortSender_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
