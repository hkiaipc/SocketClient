using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace SocketServer
{
    class SocketRS
    {
        public Socket Socket
        {
            get { return _socket; }
        } private Socket _socket;

        private Thread _thread;

        /// <summary>
        /// 
        /// </summary>
        private bool _threadStarted;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        public SocketRS(Socket socket)
        {
            _socket = socket;

            ThreadStart ts = new ThreadStart(doit);
            _thread = new Thread(ts);
            _threadStarted = true;
            _thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void doit()
        {
            while (_threadStarted)
            {
                byte[] buffer = new byte[RECEIVE_BUFFER_SIZE];
                int receivedCount = _socket.Receive(buffer);
                if (receivedCount > 0)
                {
                    if (this.ReceivedEvent != null)
                    {
                        this._receivedBytes = new byte[receivedCount];
                        Array.Copy(buffer, _receivedBytes, receivedCount);
                        this.ReceivedEvent(this, EventArgs.Empty);
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }
        private const int RECEIVE_BUFFER_SIZE = 1024;
        public event EventHandler ReceivedEvent;

        public byte[] ReceivedBytes
        {
            get { return _receivedBytes; }
        } private byte[] _receivedBytes;

        public void Close()
        {
            _threadStarted = false;
            if (this._thread != null &&
                this._thread.ThreadState != ThreadState.Aborted)
            {
                this._thread.Abort();
            }
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }
    }
}
