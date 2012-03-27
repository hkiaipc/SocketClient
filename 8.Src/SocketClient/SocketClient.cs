using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO; 
namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public class SocketClient
    {

        /// <summary>
        /// 
        /// </summary>
        const int SIZE = 1024;


        #region Connect
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Connect(IPAddress ipAddress, UInt16 port)
        {
            if (this.IsConnected)
            {
                throw new InvalidOperationException("isconnected");
            }

            //if (_isClosed)
            //{
                _socket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream,
                        ProtocolType.Tcp);
            //}
            EndPoint ep = new IPEndPoint(ipAddress, port);
            Socket.Connect(ep);
        }
        #endregion //Connect

        //#region InitSocket
        ///// <summary>
        ///// 
        ///// </summary>
        //private void InitSocket()
        //{
        
        //}
        //#endregion //InitSocket

        //#region Close
        ///// <summary>
        ///// 
        ///// </summary>
        //public void Close()
        //{
        //    //if (_socketRS != null)
        //    //{
        //    //    _socketRS.Close();
        //    //    _socketRS = null;
        //    //}
        //}
        //#endregion //Close

        //#region SocketRS
        ///// <summary>
        ///// 
        ///// </summary>
        //public ISocketRS SocketRS
        //{
        //    get { return _socketRS; }
        //} private ISocketRS _socketRS;
        //#endregion //SocketRS

        #region Socket
        /// <summary>
        /// 
        /// </summary>
        private Socket Socket
        {
            get 
            {
                if (_socket == null)
                {
                    _socket = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream,
                            ProtocolType.Tcp);
                }
                return _socket; 
            }
        } private Socket _socket;
        #endregion //Socket

        #region Close
        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            //_socket.Shutdown(SocketShutdown.Both);
            //_socket.Close();
            //_socket = null;
            CloseHelper();
        }
        #endregion //Close

        #region IsConnected
        public bool IsConnected
        {
            get 
            {
                if (this._socket != null)
                {
                    return this._socket.Connected;
                }
                else
                {
                    return false;
                }
            
            }
        }
        #endregion //IsConnected

        #region Send
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public void Send( byte[] buffer )
        {
            this._socket.Send(buffer);
        }
        #endregion //Send

        #region RemoteEndPoint
        /// <summary>
        /// 
        /// </summary>
        public EndPoint RemoteEndPoint
        {
            get
            {
                return this.Socket.RemoteEndPoint;
            }
        }
        #endregion //RemoteEndPoint

        #region LocalEndPoint
        /// <summary>
        /// 
        /// </summary>
        public EndPoint LocalEndPoint
        {
            get
            {
                return this.Socket.LocalEndPoint;
            }
        }
        #endregion //LocalEndPoint

        #region ReceivedBytes
        public byte[] ReceivedBytes
        {
            get 
            {
                byte[] bs = _receivedBytes.ToArray();
                //_receivedBytes.Seek(0, SeekOrigin.Begin);
                _receivedBytes.SetLength(0);
                return bs;
            }
        } private MemoryStream _receivedBytes = new MemoryStream();
        #endregion //ReceivedBytes

       
        #region BeginReceive 
        /// <summary>
        /// 
        /// </summary>
        public void BeginReceive()
        {
            AsyncCallback cb = new AsyncCallback(ReceiveCallback);
            byte[] receiveBuffer = new byte[SIZE];
            IAsyncResult ia = _socket.BeginReceive(
                receiveBuffer, 
                0, 
                SIZE,
                SocketFlags.None, 
                cb, 
                receiveBuffer);
        }
        #endregion //BeginReceive

        #region ReceiveCallback
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ia"></param>
        void ReceiveCallback(IAsyncResult ia)
        {
            Console.WriteLine("ReceiveCallBack");
            byte[] receiveBuffer = (byte[])ia.AsyncState;
            int n = 0;
            try
            {
                // null ref ex
                //
                n = this._socket.EndReceive(ia);
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("object disposed exception");
                return;
            }
            catch (SocketException )
            {
                Console.WriteLine("socket exception");
                this.CloseHelper();
                return;
            }

            if (n > 0)
            {
                //_receivedBytes = new byte[n];
                //Array.Copy(receiveBuffer, _receivedBytes, n);
                //AddRSData(RSType.R, _receivedBytes);
                _receivedBytes.Write(receiveBuffer, 0, n);
                if (this.ReceivedEvent != null)
                {
                    ReceivedEvent(this, EventArgs.Empty);
                }

                BeginReceive();
            }
            else
            {
                CloseHelper();
            }
        }
        #endregion //ReceiveCallback

        //public void Shutdown()
        //{
        //    this._socket.Shutdown(SocketShutdown.Both);
        //}

        //private bool _isClosed;

        #region CloseHelper
        /// <summary>
        /// 
        /// </summary>
        private void CloseHelper()
        {
            //if( !_isClosed )
            //if (_socket != null)
            if( _socket.Connected )
            {
                Console.WriteLine("CloseHelper");

                _socket.Disconnect(false);
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
                if (this.ClosedEvent != null)
                {
                    this.ClosedEvent(this, EventArgs.Empty);
                }
                //_socket = null;
                //_isClosed = true;
            }
        }
        #endregion //CloseHelper

        #region Event
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ReceivedEvent;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ClosedEvent;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ConnectedEvent;
        #endregion //Event
    }
}
