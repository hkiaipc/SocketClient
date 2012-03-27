//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Net.Sockets;
//using SocketRSLib;

//namespace SocketClient
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class SocketClientManager
//    {

//        private App _app;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="app"></param>
//        public SocketClientManager(App app)
//        {
//            this._app = app;
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        public frmMain MainForm
//        {
//            get { return App.Default.MainForm; }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public SocketClient SocketClient
//        {
//            get
//            {
//                //if (_socketClient == null)
//                //    _socketClient = new SocketClient();
//                return _socketClient;
//            }
//            set { _socketClient = value; }
//        } private SocketClient _socketClient;

//        /// <summary>
//        /// 
//        /// </summary>
//        public bool IsConnected
//        {
//            get 
//            {
//                if (_socketClient != null)
//                {
//                    return _socketClient.Socket.Connected;
//                }
//                return false;
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public void Connect(string ip, int port)
//        {
//            //if (this.SocketClient == null)
//            //    this.SocketClient = new SocketClient();
//            ////else
//            //    //throw new Exception("already connected");

//            //try
//            //{
//            //    this.SocketClient.Connect(ip, port);
//            //    // register events
//            //    //
//            //    this.SocketClient.SocketRS.ReceivedEvent += new EventHandler(SocketRS_ReceivedEvent);
//            //    this.SocketClient.SocketRS.ClosedEvent += new EventHandler(SocketRS_ClosedEvent);
//            //}
//            //catch (Exception ex)
//            //{
//            //    NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
//            //    this.SocketClient = null;
//            //    throw;
//            //}
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        void SocketRS_ClosedEvent(object sender, EventArgs e)
//        {
//            //this.Close();
//            //Post(ID_SOCKETCLOSED, null);
//            this.MainForm.OnSyncSocketClosed();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        void SocketRS_ReceivedEvent(object sender, EventArgs e)
//        {
//            SocketRSAPM rs = sender as SocketRSAPM;
//            byte[] bs = rs.ReceivedBytes;

//            //Post(ID_RECEIVEDBYTES, bs);
//            this.MainForm.OnSyncSocketReceived(bs);
//            this.ReceivedDelegate(this, bs);
////            byte[] buffer = new byte[] {
////0x03, 0x03, 0x50, 0x00, 0x00, 0x00, 0x00, 0xC2, 0xBB, 0x2F, 0x80, 0x42, 0xBE, 0x20, 0x00, 0x42, 0xCC, 0x4E, 0x00, 0x42, 0x62, 0x08, 0x00, 0x42, 0x41, 0xF8, 0x00, 0x42, 0xC1, 0x7A, 0x00, 0x42, 0x7F, 0x38, 0x00, 0x3D, 0x0C, 0xCC, 0xCD, 0x3C, 0x57, 0x0A, 0x3D, 0x40, 0x9B, 0xDC, 0x29, 0x40, 0x80, 0xF5, 0xC3, 0x3C, 0xE6, 0x66, 0x66, 0x40, 0x7C, 0x0A, 0x3D, 0xC1, 0xC7, 0xB8, 0x00, 0xBC, 0x69, 0x99, 0x9A, 0x3E, 0x44, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xBF, 0xE8
////            };
////            rs.Send(buffer);
//        }





//        /// <summary>
//        /// 
//        /// </summary>
//        public void Close()
//        {
//            //if (this.SocketClient != null)
//            //{
//            //    this.SocketClient.SocketRS.ReceivedEvent -= new EventHandler(SocketRS_ReceivedEvent);
//            //    this.SocketClient.SocketRS.ClosedEvent -= new EventHandler(SocketRS_ClosedEvent);
//            //    this.SocketClient.Close();
//            //    this.SocketClient = null;
//            //}
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public Socket Socket
//        {
//            get
//            {
//                if (this.SocketClient != null)
//                    return this.SocketClient.Socket;
//                return null;
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public ReceivedDelegate ReceivedDelegate
//        {
//            get { return _receivedDelegate; }
//            set { _receivedDelegate = value; }
//        } private ReceivedDelegate _receivedDelegate;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public string GetStateText()
//        {
//            if (this.Socket == null)
//            {
//                return "";
//            }
//            return this.Socket.RemoteEndPoint.ToString();
//        }
//    }
//}
