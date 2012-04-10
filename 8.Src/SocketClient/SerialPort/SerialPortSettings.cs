using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class SerialPortSettings
    {
        #region PortName
        /// <summary>
        /// 
        /// </summary>
        public string PortName
        {
            get
            {
                if (_portName == null)
                {
                    _portName = string.Empty;
                }
                return _portName;
            }
            set
            {
                _portName = value;
            }
        } private string _portName;
        #endregion //PortName

        #region BaudRate
        /// <summary>
        /// 
        /// </summary>
        public int BaudRate
        {
            get
            {
                return _baudRate;
            }
            set
            {
                _baudRate = value;
            }
        } private int _baudRate;
        #endregion //BaudRate

        #region Parity
        /// <summary>
        /// 
        /// </summary>
        public Parity Parity
        {
            get
            {
                if (_parity == null)
                {
                    _parity = new Parity();
                }
                return _parity;
            }
            set
            {
                _parity = value;
            }
        } private Parity _parity;
        #endregion //Parity

        #region DataBits
        /// <summary>
        /// 
        /// </summary>
        public int DataBits
        {
            get
            {
                return _dataBits;
            }
            set
            {
                _dataBits = value;
            }
        } private int _dataBits;
        #endregion //DataBits

        #region StopBits
        /// <summary>
        /// 
        /// </summary>
        public StopBits StopBits
        {
            get
            {
                if (_stopBits == null)
                {
                    _stopBits = new StopBits();
                }
                return _stopBits;
            }
            set
            {
                _stopBits = value;
            }
        } private StopBits _stopBits;
        #endregion //StopBits

        #region Default
        /// <summary>
        /// 
        /// </summary>
        static public SerialPortSettings Default
        {
            get
            {
                SerialPortSettings d = new SerialPortSettings();

                d._portName = "Com1";
                d._baudRate = 9600;
                d._dataBits = 8;
                d._parity = Parity.None;
                d._stopBits = StopBits.One;

                return d;
            }
        }
        #endregion //Default

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = string.Format(
                "{0}({1},{2},{3},{4})",
                this.PortName,
                this.BaudRate,
                this.Parity.ToString().Substring(0, 1),
                this.DataBits,
                GetStopBitString(this.StopBits)
                );
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stopBits"></param>
        /// <returns></returns>
        private string GetStopBitString(StopBits stopBits)
        {
            List<KeyValuePair<StopBits, string>> list = new List<KeyValuePair<StopBits, string>>();
            list.Add(new KeyValuePair<StopBits, string>(StopBits.One, "1"));
            list.Add(new KeyValuePair<StopBits, string>(StopBits.OnePointFive, "1.5"));
            list.Add(new KeyValuePair<StopBits, string>(StopBits.Two, "2"));

            foreach (KeyValuePair<StopBits, string> item in list)
            {
                if (item.Key == stopBits)
                {
                    return item.Value;
                }
            }

            throw new InvalidOperationException(
                string.Format(
                "not find stopBits '{0}'",
                stopBits));
        }
    }
}
