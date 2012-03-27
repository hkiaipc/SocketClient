using System;
using System.Collections.Generic;
using System.Text;
//using SerialPortCommuni;
using System.Net.Sockets;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class SocketTransmitAdpater : ITransmit 
    {
        public SocketTransmitAdpater(SocketClient sc)
        {
            this.Source = sc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        public void Write(byte[] bytes)
        {
            SocketClient sc = this.Source as SocketClient;
            if (sc != null && sc.IsConnected)
            {
                sc.Send(bytes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Source
        {
            get { return _source; }
            set { _source = value; }
        }private object _source;

        public bool CanWrite()
        {
             return ((SocketClient)this.Source).IsConnected; 
        }
    }

}
