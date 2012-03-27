using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SocketRSLib;

namespace SocketServer
{


    public partial class Form1 : Form
    {
        #region Members
        private SynchronizationContext _syn;
        private SocketServer _server;
        private SocketRSCollection _socketRSs = new SocketRSCollection();
        private ISocketRS _currentSocketRS;
        #endregion //

        #region Form1
        public Form1()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Socket Server " + Application.ProductVersion;
            SetDisListenState();
            this._syn = SynchronizationContext.Current;
        }
        #endregion //

        #region FormClosed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_server != null)
            {
                this._server.Close();
                this._server = null;
            }
        }
        
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        private SocketRS GetSocketRS(int idx)
        {
            //return this._server.SocketRSList[idx] as SocketRS;
            return null;
        }

        #region btnListen_Click 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnListen_Click(object sender, System.EventArgs e)
        {
            if (_server == null)
            {
                _server = new SocketServer();
                try
                {
                    _server.Listen(this.txtIP.Text, (int)this.numPort.Value);
                    _server.NewConnectEvent += new EventHandler(_server_NewConnectEvent);
                    SetListenState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _server = null;
                    return;
                }
            }
            else
            {
                _server.Close();
                _server = null;
                SetDisListenState();
            }
        } 
        #endregion

        #region _server_NewConnectEvent
        void _server_NewConnectEvent(object sender, EventArgs e)
        {
            ISocketRS rs = new SocketRSAPM(this._server.NewSocket);
            AddISocketRS(rs);
            // refresh connected socket list
            // 
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(DateTime.Now.ToString());
            rs.Send(buff);
        }
        #endregion //


        #region AddISocketRS       
        private void AddISocketRS( ISocketRS rs )
        {
            this._socketRSs.Add(rs);
            rs.ReceivedEvent += new EventHandler(rs_ReceivedEvent);
            rs.ClosedEvent += new EventHandler(rs_ClosedEvent);
            RefreshSocketList();
            if (_currentSocketRS == null)
            {
                SetCurrentSocketRS(rs);
            }
        }
        #endregion //AddISocketRS

        #region NoNameCallback
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void NoNameCallback(object state)
        {
            //int n = Convert.ToInt32(state);
            if( state is int )
            {
                this.listBox1.Items.Clear();
                //foreach (ISocketRS rs in this._socketRSs)
                for( int i=0; i<_socketRSs.Count; i++ )
                {
                    ISocketRS rs = _socketRSs[i];
                    string s = rs.Socket.LocalEndPoint.ToString() + " " + rs.Socket.RemoteEndPoint;
                    this.listBox1.Items.Add(s);
                }
            }

            // select socket client
            //
            //if (state != null && state is ISocketRS   )
            if(true)
            {
                ISocketRS rs = state as ISocketRS;
                this._currentSocketRS = rs;
                SetCurrentSocketRSHelper(rs);
            }
        }
        #endregion //


        #region SetCurrentSocketRSHelper
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rs"></param>
        private void SetCurrentSocketRSHelper(ISocketRS rs)
        {
            this._currentSocketRS = rs;
            if (rs != null)
            {
                this.txtReceived.Clear();
                foreach (RSRecord record in rs.RSRecords)
                {
                    string s = string.Format("{0} [{1}] {2}" + Environment.NewLine, record.dt, record.rsType, record.text);
                    this.txtReceived.AppendText(s);
                }
                SetRecieveSendEnable(true);
            }
            else
            {
                SetRecieveSendEnable(false); ;
            }
        }
        #endregion //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        private void SetRecieveSendEnable(bool b)
        {
            this.txtReceived.Enabled = b;
            this.btnClearReceived.Enabled = b;
            this.txtSend.Enabled = b;
            this.btnSend.Enabled = b;
            this.btnDisConnectCurrent.Enabled = b;
        }

        SendOrPostCallback _callback;

        private SendOrPostCallback GetSynCallback()
        { 
            if( this._callback == null )
                _callback = new SendOrPostCallback(NoNameCallback);
            return _callback;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void SyncExec(object state)
        {
            _syn.Post(GetSynCallback(), state);
        }

        #region
        private void RefreshSocketList()
        {
            SyncExec(0);
        }
        #endregion //


        #region rs_receivedEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rs_ReceivedEvent( object sender, EventArgs e )
        {
            ISocketRS rs = sender as ISocketRS;
            if( _currentSocketRS == rs )
            {
                // add received string to receivetextbox
                //
                string str = ASCIIEncoding.ASCII.GetString(rs.ReceivedBytes);
                string text = string.Format("{0} [{1}] {2}", DateTime.Now, "R", str);
                //txtReceived.AppendText(Text);
                _syn.Post(new SendOrPostCallback(AppendTextCallback), text);
            }
        }
        #endregion //

        #region AppendTextCallback
        private void AppendTextCallback(object state)
        {
            this.txtReceived.AppendText(state.ToString());
        }
        #endregion

        #region rs_ClosedEvent
        private void rs_ClosedEvent( object sender, EventArgs e )
        {
            ISocketRS rs = sender as ISocketRS;
            this._socketRSs.Remove(rs);
            if (rs == _currentSocketRS)
                //_currentSocketRS = null;
                SetCurrentSocketRS(null);
            RefreshSocketList();
        }
        #endregion //
 
        #region RemoveISocketRS       
        private void RemoveISocketRS( ISocketRS rs )
        {
            rs.ReceivedEvent -= new EventHandler(rs_ReceivedEvent); ;
            rs.ClosedEvent -= new EventHandler(rs_ClosedEvent);
            this._socketRSs.Remove(rs);
            RefreshSocketList();
        }
        #endregion //RemoveISocketRS

        #region SetListenState
        void SetListenState()
        {
            this.txtIP.Enabled = false;
            this.numPort.Enabled = false;
            this.grpListenOn.Text = "Listen On <" + txtIP.Text + " " + (int)this.numPort.Value + ">";
            this.btnListen.Text = "DisListen";
        }
        #endregion //

        #region SetDisListenState
        void SetDisListenState()
        {
            this.txtIP.Enabled = true;
            this.numPort.Enabled = true;

            this.btnSend.Enabled = false;
            this.txtSend.Enabled = false;

            this.txtReceived.Enabled = false;
            this.btnClearReceived.Enabled = false;

            //this.listBox1.Enabled = false;
            this.btnDisConnectCurrent.Enabled = false;

            this.grpListenOn.Text = "Listen On";
            this.btnListen.Text = "Listen";
        }
        #endregion //

        #region listBox1_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = this.listBox1.SelectedIndex;
            if (idx != -1)
            {
                ISocketRS rs = this._socketRSs[idx];
                SetCurrentSocketRSHelper(rs);
            }
        }

        #endregion //

        #region SetCurrentSocketRS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rs"></param>
        private void SetCurrentSocketRS( ISocketRS rs )
        {
            SyncExec(rs);
        }
        #endregion //

        #region btnSend_click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this._currentSocketRS != null)
            {
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(this.txtSend.Text);
                string s = string.Format("{0} {1}: {2}" + Environment.NewLine, DateTime.Now, "S", this.txtSend.Text );
                this.txtSend.Clear();
                this.txtReceived.AppendText(s);
                _currentSocketRS.Send(buffer);
            }
        }
        #endregion //

        #region btnClearReceived_Click
        private void btnClearReceived_Click(object sender, EventArgs e)
        {
            this.txtReceived.Clear();
        }
        #endregion //


        #region btnDisConnectCurrent_Click
        private void btnDisConnectCurrent_Click(object sender, EventArgs e)
        {
            if (this._currentSocketRS != null)
                this._currentSocketRS.Close();
        }
        #endregion //

    }
}
