using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace SerialPortCommuni
{

    //public interface SerialPortDispatch
    //{
    //    void Write(byte[] buffer);
    //}

    /// <summary>
    /// 
    /// </summary>
    public class SerialPortCommuni
    {
        private readonly TimeSpan MINREADTS = TimeSpan.Parse("0:0:0.500");
        private DateTime _writeDT;

        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ReceivedEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portname"></param>
        public SerialPortCommuni(string portname)
        {
            int baudRate = 19200;
            SerialPort sp = new SerialPort(portname, baudRate, Parity.None, 8, StopBits.One);
            sp.Open();
            this._serialPort = sp;
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        public SerialPortCommuni(SerialPort serialport)
        {
            if (serialport == null)
                throw new ArgumentNullException("serialport");
            this._serialPort = serialport;

            Init();
        }

        private void Init()
        {
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.timer1.Start();
        }

        void Receive()
        {
            byte[] bs = this.Read();
            cs("Read: " + bs.Length);
        }

        void cs(object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Receive();
        }
        /// <summary>
        /// 
        /// </summary>
        public SerialPort SerialPort
        {
            get { return _serialPort; }
        }
        private SerialPort _serialPort;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public void Write(byte[] buffer)
        {
            _serialPort.Write(buffer, 0, buffer.Length);
            this._writeDT = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] Read()
        {
            TimeSpan ts = DateTime.Now - _writeDT;
            if (ts > MINREADTS || ts < TimeSpan.Zero)
            {
                if (_serialPort.BytesToRead > 0)
                {
                    byte[] buffer = new byte[2048];
                    int n = _serialPort.Read(buffer, 0, 2048);
                    if (n > 0)
                    {
                        byte[] temp = new byte[n];
                        Array.Copy(buffer, temp, n);
                        this._receivedBytes = temp;

                        // on received event
                        //
                        if (this.ReceivedEvent != null)
                        {
                            ReceivedEvent(this, EventArgs.Empty);
                        }
                        return temp;
                    }
                }
            }
            return new byte[0];
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] ReceivedBytes
        {
            get { return _receivedBytes; }
        } private byte[] _receivedBytes;
        
    }
}
