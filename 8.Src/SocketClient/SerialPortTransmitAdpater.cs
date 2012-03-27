using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class SerialPortTransmitAdpater : ITransmit
    {
        /// <summary>
        /// 
        /// </summary>
        public SerialPortManager SerialPortManager
        {
            get { return this.Source as SerialPortManager; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        public SerialPortTransmitAdpater(SerialPortManager spm)
        {
            if (spm == null)
                throw new ArgumentNullException("spm");
            this.Source = spm;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        public void Write(byte[] bytes)
        {
            SerialPortManager spm = this.SerialPortManager;
            if (spm != null && spm.IsOpen)
            {
                spm.Write(bytes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Source
        {
            get { return _source; }
            set { _source = value; }
        } private object _source;

        public bool CanWrite()
        {
             return this.SerialPortManager.IsOpen; 
        }
    }
}
