using System;
using System.Collections.Generic;
using System.Text;

using System.IO.Ports;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class SerialPortManager
    {
        /// <summary>
        /// 
        /// </summary>
        public void Open()
        {
            this.SerialPort.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            this.SerialPort.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ReceivedEvent;

        /// <summary>
        /// 
        /// </summary>
        public SerialPort SerialPort
        {
            get 
            {
                if (_serialPort == null)
                {
                    _serialPort = new SerialPort();
                    _serialPort .DataReceived +=new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                }
                return _serialPort; 
            }
        } private SerialPort _serialPort;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //int count = this.SerialPort.BytesToRead;
            //if (count > 0)
            //{
            //    byte[] buffer = new byte[count];
            //    this.SerialPort.Read(buffer, 0, count);

            //    this.MainForm.OnSyncSerialPortReceived(buffer);
            //    this.ReceivedDelegate(this, buffer);
            //}
            if (this.ReceivedEvent != null)
            {
                ReceivedEvent(this, EventArgs.Empty);
            }
        }

        public byte[] ReceivedBytes
        {
            get
            {
                int count = this.SerialPort.BytesToRead;
                byte[] buffer = new byte[count];
                if (count > 0)
                {
                    this.SerialPort.Read(buffer, 0, count);
                }
                return buffer;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        public void Write(byte[] bs)
        {
            this.SerialPort.Write(bs, 0, bs.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpen
        {
            get { return this.SerialPort.IsOpen; }
        }
        public string Setting
        {
            get 
            {
                string s = string.Format(
                    "{0},{1},{2},{3}",
                    this.BaudRate, this.Parity, this.DataBits, this.StopBits 
                    );
                return s;
            }
            set 
            {
                string[] ss = value.Split(',');
                if (ss.Length == 4)
                {
                    int baudRate = int.Parse(ss[0]);
                    Parity parity = (Parity)Enum.Parse(typeof(Parity), ss[1]);
                    int dataBits = int.Parse(ss[2]);
                    StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), ss[3]);

                    this.BaudRate = baudRate;
                    this.Parity = parity;
                    this.DataBits = dataBits;
                    this.StopBits = stopBits;
                    
                }
                else
                {
                    throw new ArgumentException("setting");
                }
            }
        }

        public int BaudRate
        {
            get { return this.SerialPort.BaudRate; }
            set { this.SerialPort.BaudRate = value; }
        }

        public StopBits StopBits
        {
            get { return this.SerialPort.StopBits; }
            set { this.SerialPort.StopBits = value; }
        }
        public int DataBits 
        {
            get { return this.SerialPort.DataBits; }
            set { this.SerialPort.DataBits = value; }
        }

        public Parity Parity
        {
            get { return this.SerialPort.Parity; }
            set { this.SerialPort.Parity = value; }
        }

        public string PortName
        {
            get { return this.SerialPort.PortName; }
            set { this.SerialPort.PortName = value; }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public ReceivedDelegate ReceivedDelegate
        //{
        //    get { return _receivedDelegate; }
        //    set { _receivedDelegate = value; }
        //} private ReceivedDelegate _receivedDelegate;

        ///// <summary>
        ///// 
        ///// </summary>
        //public frmMain MainForm
        //{
        //    get { return App.Default.MainForm; }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public string GetStateText()
        //{
        //    if (this.SerialPort == null)
        //    {
        //        return "";
        //    }

        //    string s = string.Format("{0}({1},{2},{3},{4}) {5}",
        //        SerialPort.PortName,
        //        SerialPort.BaudRate, SerialPort.Parity, SerialPort.DataBits, SerialPort.StopBits,
        //        SerialPort.IsOpen ? "Opened" : "Closed");
        //    return s;
        //}
    }

}
