using System;
using System.Collections;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;
using System.Xml;
using System.IO.Ports;
using System.IO;

namespace SocketClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMain : Form
    {
        private const int ID_RECEIVEDBYTES = 0;
        private const int ID_SOCKETCLOSED = 1;
        private const int ID_SERIALPORT_RECEIVED = 3;

        #region frmMain
        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            InitControls();
            RegisterSocketClientEvents();
            this.dataGridView1.AutoGenerateColumns = false;
        }
        #endregion //

        #region RegisterSocketClientEvents
        /// <summary>
        /// 
        /// </summary>
        private void RegisterSocketClientEvents()
        {
            this.SocketClient.ConnectedEvent += new EventHandler(SocketClient_ConnectedEvent);
            this.SocketClient.ClosedEvent += new EventHandler(SocketClient_ClosedEvent);
            this.SocketClient.ReceivedEvent += new EventHandler(SocketClient_ReceivedEvent);

            this.SerialPortManager.ReceivedEvent += new EventHandler(SerialPortManager_ReceivedEvent);
        }
        #endregion //RegisterSocketClientEvents

        #region SerialPortManager_ReceivedEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SerialPortManager_ReceivedEvent(object sender, EventArgs e)
        {
            byte[] bs = this.SerialPortManager.ReceivedBytes;
            this.Post(ID_SERIALPORT_RECEIVED, bs);
            return;
        }
        #endregion //SerialPortManager_ReceivedEvent



        #region Transmit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="bs"></param>
        private void Transmit(object source, byte[] bs)
        {
            if (this.Transmitter.Enable &&
                this.Transmitter.CanTransmit())
            {
                ITransmit d = this.Transmitter.GetTo(source);
                if (d != null)
                {
                    d.Write(bs);

                    string from =string.Empty ; 
                    string to = string.Empty ;
                    if (source is SocketClient)
                    {
                        from = this.GetMe();
                        to = this.GetSerialPortName();
                    }

                    if (source is SerialPortManager)
                    {
                        from = this.GetLocalString();
                        to= this.GetRemoteString ();
                    }

                    this.AddSend(
                        from,
                        to,
                        bs);
                }
            }
        }
        #endregion //Transmit


        #region SocketClient_ReceivedEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SocketClient_ReceivedEvent(object sender, EventArgs e)
        {
            byte[] bs = this.SocketClient.ReceivedBytes;
            this.Post(ID_RECEIVEDBYTES, bs);
        }
        #endregion //SocketClient_ReceivedEvent

        #region SocketClient_ClosedEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SocketClient_ClosedEvent(object sender, EventArgs e)
        {
            this.OnSyncSocketClosed();
        }
        #endregion //SocketClient_ClosedEvent

        #region SocketClient_ConnectedEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SocketClient_ConnectedEvent(object sender, EventArgs e)
        {
            this.SetConnectState();
        }
        #endregion //SocketClient_ConnectedEvent

        #region
        Transmitter Transmitter
        {
            get { return App.Default.Transmitter; }
        }
        #endregion //

        #region Config
        private Config Config
        {
            get { return App.Default.Config; }
        }
        #endregion //Config

        #region InitControls
        /// <summary>
        /// 
        /// </summary>
        private void InitControls()
        {
            this.cmbPort.DataSource = Config.PortList;
            this.cmbPort.Text = Config.LastPort.ToString();

            this.cmbIPAddress.DataSource = Config.IPAddressList;
            this.cmbIPAddress.Text = Config.LastIPAddress;

            this.MinimumSize = new Size(400, 600);

            this.tssTransmitter.Text = "";
            this.tssSocket.Text = "";

            // socket
            //

            // serial port
            //
            RefreshSerialPortState();


            // reply
            //
            RefreshReplyState();

            // transmit
            //
            RefreshTransmitState();

            RefreshSocketState();

            // listview
            //
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].Width = this.ColumnWidths[i];
            }

            //
            int[] tssWidths = new int[] { 260, 250, 120, 120 };
            ToolStripLabel[] tsls = new ToolStripLabel[] { tssSocket, tssSerialPort, tssTransmitter, tssReply };
            for (int i = 0; i < tssWidths.Length; i++)
            {
                tsls[i].Width = tssWidths[i];
            }


            this.Size = Config.FormSize;
            this.Location = Config.Location;

            //
            //
            if (this.Config.LogDataMode == DataMode.Ascii)
            {
                this.rdoAsc.Checked = true;
                this.rdoHex.Checked = false;
            }
            else
            {
                this.rdoAsc.Checked = false;
                this.rdoHex.Checked = true;
            }

            RefreshLogDataGridView();

            //
            //
            if (this.Config.SendDataMode == DataMode.Ascii)
            {
                this.rbSendAsc.Checked = true;
                this.rbSendHex.Checked = false;
            }
            else
            {
                this.rbSendAsc.Checked = false;
                this.rbSendHex.Checked = true;
            }

            SetDisconnectState();

            // 
            //
            CreateContextMenu();
        }
        #endregion //InitControls

        #region CreateContextMenu
        /// <summary>
        /// 
        /// </summary>
        private void CreateContextMenu()
        {
            this.contextMenuStrip1.Items.Clear();

            ToolStripItem m = null;

            m = this.contextMenuStrip1.Items.Add(Strings.SendDataSave);
            m.Click += new EventHandler(SendAdd_Click);

            m = this.contextMenuStrip1.Items.Add(Strings.SendDataManage);
            m.Click += new EventHandler(SendManage_Click);

            m = new ToolStripSeparator();
            this.contextMenuStrip1.Items.Add(m);

            for (int i = 0; i < this.SendCollection.Count; i++)
            {
                SendItem si = this.SendCollection[i];
                this.AddSendItemToContextMenu(si, i+1);
            }
        }
        #endregion //CreateContextMenu

        #region SendManage_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SendManage_Click(object sender, EventArgs e)
        {
            frmSendDataManager f = new frmSendDataManager();
            if (f.ShowDialog() == DialogResult.OK)
            {
                SendItem selectedItem  = f.SelectedSendItem ;
                if (selectedItem != null)
                {
                    SetSendBytes(selectedItem.Bytes);
                }
            }

            CreateContextMenu();
        }
        #endregion //SendManage_Click



        #region SendAdd_Click
        void SendAdd_Click(object sender, EventArgs e)
        {
            byte[] bs ;
            if (this.GetSendBytes(out bs))
            {
                SendItem item = new SendItem();

                item.Name = HexStringConverter.Default.ConvertToObject(bs).ToString();
                item.Bytes = bs;

                frmSendData f = new frmSendData(item);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    this.SendCollection.Add(item);
                    CreateContextMenu();
                }
            }
        }
        #endregion //SendAdd_Click

        #region AddSendItemToContextMenu
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void AddSendItemToContextMenu(SendItem item, int no)
        {
            string s = string.Format(
                "{0}: {1}",
                GetNoMenuText(no), 
                item.Name);


            ToolStripMenuItem menuitem = new ToolStripMenuItem(s);
            menuitem.Tag = item;
            menuitem.Click += new EventHandler(menuitem_Click);

            this.contextMenuStrip1.Items.Add (menuitem);
        }
        #endregion //AddSendItemToContextMenu

        #region GetNoMenuText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private string GetNoMenuText(int no)
        {
            if (no < 10)
            {
                return "0&" + no.ToString();
            }
            else
            {
                return no.ToString();
            }
        }
        #endregion //GetNoMenuText

        #region menuitem_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuitem_Click(object sender, EventArgs e)
        {
            ToolStripItem item =  sender as ToolStripItem;
            SendItem senditem = (SendItem)item.Tag;
            SetSendBytes(senditem.Bytes); 
        }
        #endregion //menuitem_Click

        #region SendCollection
        /// <summary>
        /// 
        /// </summary>
        private SendCollection SendCollection
        {
            get
            {
                return App.Default.Config.SendCollection;
            }
        }
        #endregion //SendCollection

        #region ColumnWidths
        /// <summary>
        /// 
        /// </summary>
        private int[] ColumnWidths
        {
            get
            {
                int minWidth = 30;

                _columnWidths = Config.ListViewColumnWidths;
                if (_columnWidths.Length != this.dataGridView1.Columns.Count)
                {
                    _columnWidths = new int[this.dataGridView1.Columns.Count];
                }

                for (int i = 0; i < _columnWidths.Length; i++)
                {
                    if (_columnWidths[i] < minWidth)
                    {
                        _columnWidths[i] = minWidth;
                    }
                }
                return _columnWidths;
            }
        } private int[] _columnWidths;
        #endregion //ColumnWidths

        #region RefreshSocketState
        /// <summary>
        /// 
        /// </summary>
        private void RefreshSocketState()
        {
            string s = string.Empty;
            if (this.SocketClient.IsConnected)
            {
                s = string.Format(
                    Strings.ConnectdFromTo,
                    this.SocketClient.LocalEndPoint,
                    this.SocketClient.RemoteEndPoint
                    );
            }
            else
            {
                s = Strings.NotConnectdState;
            }
            this.tssSocket.Text = s;
        }
        #endregion //RefreshSocketState

        #region RefreshTransmitState
        private void RefreshTransmitState()
        {
            this.mnuEnableTransmit.Checked = this.Transmitter.Enable; ;

            string s = string.Format(
                Strings.TransmitState,
                this.Transmitter.Enable ? Strings.Enabled : Strings.Disabled
                );
            this.tssTransmitter.Text = s;
        }
        #endregion //RefreshTransmitState

        #region RefreshReplyState
        private void RefreshReplyState()
        {
            this.mnuEnableReply.Checked = this.ReplyCollection.Enabled;
            string s = string.Format(
                Strings.ReplyState,
                this.ReplyCollection.Enabled ? Strings.Enabled : Strings.Disabled
                );
            this.tssReply.Text = s;
        }
        #endregion //RefreshReplyState

        #region RefreshSerialPortState
        /// <summary>
        /// 
        /// </summary>
        private void RefreshSerialPortState()
        {
            this.mnuOpenSerialPort.Enabled = !this.SerialPortManager.IsOpen;
            this.mnuCloseSerialPort.Enabled = this.SerialPortManager.IsOpen;
            this.mnuSerialPortSetting.Enabled = !this.SerialPortManager.IsOpen;

            this.tssSerialPort.Text = string.Format(
                "{0} {1}",
                this.SerialPortManager.SerialPortSettings,
                this.SerialPortManager.IsOpen ? Strings.Opened : Strings.Closed);
        }
        #endregion //RefreshSerialPortState


        #region GetReceiveText
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetHexOrAscText(byte[] bs)
        {
            if (this.rdoHex.Checked)
            {
                string receStr = HexStringConverter.Default.ConvertToObject(bs).ToString();
                return receStr;
            }
            if (this.rdoAsc.Checked)
            {
                string s = ASCIIEncoding.ASCII.GetString(bs);
                return s;
            }

            return null;
        }
        #endregion //GetReceiveText

        #region IPAddress
        /// <summary>
        /// 
        /// </summary>
        private IPAddress IPAddress
        {
            get
            {
                return IPAddress.Parse(this.cmbIPAddress.Text);
            }
            set
            {
                this.cmbIPAddress.Text = value.ToString();
            }
        }
        #endregion //IPAddress

        #region Port
        private UInt16 Port
        {
            get
            {
                return UInt16.Parse(this.cmbPort.Text);
            }
            set
            {
                cmbPort.Text = value.ToString();
            }
        }
        #endregion //Port

        #region VerifyIPAddressAndPort
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool VerifyIPAddressAndPort()
        {
            IPAddress ipaddress = null;
            UInt16 port = 0;

            bool b = false;
            b = IPAddress.TryParse(this.cmbIPAddress.Text, out ipaddress);
            if (!b)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.InvalidIPAddress );
                return false;
            }
            b = UInt16.TryParse(this.cmbPort.Text, out port);
            if (!b)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.InvalidPort);
                return false;
            }

            return true;
        }
        #endregion //VerifyIPAddressAndPort

        #region SocketClient
        private SocketClient SocketClient
        {
            get
            {
                return App.Default.SocketClient;
            }
        }
        #endregion //SocketClient

        #region SerialPortManager
        private SerialPortManager SerialPortManager
        {
            get
            {
                return App.Default.SerialPortManager;
            }
        }
        #endregion //

        #region btnConnect_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.SocketClient.IsConnected)
            {
                Disconnect();
            }
            else
            {
                Connnect();
            }

            return;
        }
        #endregion //btnConnect_Click

        #region Disconnect
        /// <summary>
        /// 
        /// </summary>
        private void Disconnect()
        {
            this.SocketClient.Close();
            SetDisconnectState();
        }
        #endregion //Disconnect


        #region Connnect
        /// <summary>
        /// 
        /// </summary>
        private void Connnect()
        {
            if (!VerifyIPAddressAndPort())
                return;

            this.Config.MarkIPAddress(this.IPAddress);
            this.Config.MarkPort(this.Port);

            try
            {
                this.SocketClient.Connect(this.IPAddress, this.Port);
            }
            catch (SocketException socketEx)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(socketEx.Message);
                return;
            }
            SetConnectState();
            this.SocketClient.BeginReceive();
        }
        #endregion //Connnect

        #region OnSocketClosed
        /// <summary>
        /// 
        /// </summary>
        private void OnSocketClosed()
        {
            this.SetDisconnectState();
        }
        #endregion //OnSocketClosed

        #region SetConnectState
        /// <summary>
        /// 
        /// </summary>
        private void SetConnectState()
        {
            this.cmbIPAddress.Enabled = false;
            this.cmbPort.Enabled = false;
            this.btnConnect.Text = Strings.Disconnect;

            this.grpSend.Enabled = true;

            RefreshSocketState();
        }
        #endregion //SetConnectState

        #region SetDisConnectState
        /// <summary>
        /// 
        /// </summary>
        private void SetDisconnectState()
        {
            this.cmbIPAddress.Enabled = true;
            this.cmbPort.Enabled = true;
            this.btnConnect.Text = Strings.Connect;

            this.grpSend.Enabled = false;

            RefreshSocketState();
        }
        #endregion //SetDisConnectState

        #region btnSend_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!this.SocketClient.IsConnected)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.NotConnectdState);
                return;
            }

            byte[] buffer;
            bool success = GetSendBytes(out buffer);

            if (!success)
                return;

            try
            {
                this.SocketClient.Send(buffer);
            }
            catch (SocketException socketEx)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(socketEx.Message);
            }

            this.AddSend(this.GetLocalString(), this.GetRemoteString(), buffer);
        }
        #endregion //btnSend_Click

        #region GetSendBytes
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool GetSendBytes(out byte[] outBS)
        {
            outBS = null;
            byte[] buffer = null;
            if (this.rbSendHex.Checked)
            {
                try
                {
                    buffer = HexStringConverter.Default.ConvertToBytes(this.txtSend.Text.Trim());
                }
                catch (Exception ex)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                    return false;
                }

                if (buffer.Length == 0)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(Strings.SendCannotEmpty);
                    return false;
                }
            }

            if (this.rbSendAsc.Checked)
            {
                if (this.txtSend.Text.Length > 0)
                {
                    buffer = UTF8Encoding.UTF8.GetBytes(this.txtSend.Text);
                }
                else
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(Strings.SendCannotEmpty);
                    return false;
                }
            }

            outBS = buffer;

            return true;
        }
        #endregion //GetSendBytes

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        private void SetSendBytes(byte[] bytes)
        {
            string s = string.Empty;
            if (rbSendHex.Checked)
            {
                s = (string)HexStringConverter.Default.ConvertToObject(bytes);
            }

            if (rbSendAsc.Checked)
            {
                s = UTF8Encoding.UTF8.GetString(bytes);
            }
            this.txtSend.Text = s;
        }
        #endregion //


        #region btnClearReceived_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearReceived_Click(object sender, EventArgs e)
        {
            this.LogManager.Items.Clear();
            this.dataGridView1.Rows.Clear();
        }
        #endregion //btnClearReceived_Click

        #region LogManager
        /// <summary>
        /// 
        /// </summary>
        public LogManager LogManager
        {
            get { return App.Default.LogManager; }
        }
        #endregion //LogManager

        #region grpReceived_Enter
        private void grpReceived_Enter(object sender, EventArgs e)
        {

        }
        #endregion //grpReceived_Enter

        #region btnSendHistory_Click
        private void btnSendHistory_Click(object sender, EventArgs e)
        {
            Point pt = Form.MousePosition;
            this.contextMenuStrip1.Show(pt);
        }
        #endregion //btnSendHistory_Click


        #region toolStripButton1_Click
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmReplyManager f = new frmReplyManager(this.ReplyCollection);
            f.ShowDialog(this);
        }
        #endregion //toolStripButton1_Click

        #region ReplyCollection
        /// <summary>
        /// 
        /// </summary>
        private ReplyCollection ReplyCollection
        {
            get { return App.Default.ReplyManager.ReplyCollection; }
        }
        #endregion //ReplyCollection

        #region AddReceived
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bs"></param>
        public void AddReceived(string from, string to, byte[] bs)
        {
            AddLog(from, to, bs, DataDirection.In);
        }
        #endregion //AddReceived

        #region AddSend
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="bs"></param>
        public void AddSend(string from, string to, byte[] bs)
        {
            AddLog(from, to, bs, DataDirection.Out);
        }
        #endregion //AddSend


        #region AddLog
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void AddLog(LogItem item)
        {
            string datas = string.Empty;
            if (this.rdoAsc.Checked)
            {
                datas = Encoding.ASCII.GetString(item.Bytes);
            }
            if (rdoHex.Checked)
            {
                datas = (string)HexStringConverter.Default.ConvertToObject(item.Bytes);
            }

            int idx = this.dataGridView1.Rows.Add(item.DT, item.From, item.TO, item.Bytes.Length, datas);
            DataGridViewRow dgvRow = this.dataGridView1.Rows[idx];
            dgvRow.DefaultCellStyle = GetCellStyle(item.DataDirection);
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[idx].Cells[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        public void AddLog(string from, string to, byte[] bs, DataDirection dd)
        {
            LogItem item = this.LogManager.Add(from, to, bs, dd);
            this.AddLog(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dd"></param>
        /// <returns></returns>
        private DataGridViewCellStyle GetCellStyle(DataDirection dd)
        {
            DataGridViewCellStyle obj = _cellStyleHashTable[dd] as DataGridViewCellStyle;
            if (obj == null)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle(this.dataGridView1.DefaultCellStyle);
                style.BackColor = dd.BackColor;
                _cellStyleHashTable[dd] = style;
                return style;
            }
            else
            {
                return obj;
            }
        }

        private Hashtable _cellStyleHashTable = new Hashtable();
        #endregion //AddLog

        #region SyncContext
        /// <summary>
        /// 
        /// </summary>
        public SynchronizationContext SyncContext
        {
            get { return App.Default.SyncContext; }
        }
        #endregion //SyncContext

        #region Post
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        public void Post(int id, object state)
        {
            SendOrPostCallback d = GetSendOrPostCallback();
            PostStateObject stateObj = new PostStateObject(id, state);
            this.SyncContext.Post(d, stateObj);
        }
        #endregion //Post

        #region GetSendOrPostCallback
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SendOrPostCallback GetSendOrPostCallback()
        {
            if (_sendOrPostCallback == null)
            {
                _sendOrPostCallback = new SendOrPostCallback(SendOrPostCallbackTarget);
            }
            return _sendOrPostCallback;
        } private SendOrPostCallback _sendOrPostCallback;
        #endregion //GetSendOrPostCallback

        #region GetRemoteString
        private string GetRemoteString()
        {
            return  App.Default.SocketClient.RemoteEndPoint.ToString();
        }
        #endregion //GetRemoteString

        #region GetLocalString
        private string GetLocalString()
        {
            return App.Default.SocketClient.LocalEndPoint.ToString() + this.GetMe();
        }
        #endregion //GetLocalString

        #region GetSerialPortName
        private string GetSerialPortName()
        {
            return App.Default.SerialPortManager.SerialPortSettings.PortName;
        }
        #endregion //GetSerialPortName

        #region GetMe
        private string GetMe()
        {
            return "(me)";
        }
        #endregion //GetMe


        #region SendOrPostCallbackTarget
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void SendOrPostCallbackTarget(object state)
        {
            PostStateObject stateObj = state as PostStateObject;
            switch (stateObj.ID)
            {
                case ID_RECEIVEDBYTES:
                    byte[] bs = stateObj.State as byte[];
                    this.AddReceived( 
                        GetRemoteString(),
                        GetLocalString(),
                        bs);

                    if (this.ReplyCollection.Enabled)
                    {
                        byte[] bsr = this.ReplyCollection.GetSendBytes(bs);
                        if (bsr != null)
                        {
                            this.SocketClient.Send(bsr);
                            this.AddSend(
                                GetLocalString(),
                                GetRemoteString(),
                                bsr);
                        }
                    }

                    Transmit(this.SocketClient, bs);
                    break;

                case ID_SOCKETCLOSED:
                    this.OnSocketClosed();
                    break;

                case ID_SERIALPORT_RECEIVED:
                    byte[] bs2 = (byte[])stateObj.State;
                    this.AddReceived(
                        GetSerialPortName(),
                        this.GetMe(),
                        bs2);
                    Transmit(this.SerialPortManager, bs2);
                    break;

            }
        }
        #endregion //SendOrPostCallbackTarget

        #region OnSyncSocketClosed
        /// <summary>
        /// 
        /// </summary>
        public void OnSyncSocketClosed()
        {
            this.Post(ID_SOCKETCLOSED, null);
        }
        #endregion //OnSyncSocketClosed

        #region OnSyncSocketReceived
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        public void OnSyncSocketReceived(byte[] bs)
        {
            this.Post(ID_RECEIVEDBYTES, bs);
        }
        #endregion //OnSyncSocketReceived

        #region tsbSerialPort_Click
        private void tsbSerialPort_Click(object sender, EventArgs e)
        {
        }
        #endregion //tsbSerialPort_Click

        #region rbSendAsc_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSendAsc_Click(object sender, EventArgs e)
        {
            if (!rbSendAsc.Checked)
            {
                string s = null;
                try
                {
                    s = StringConverter.HexToUTF8(this.txtSend.Text);
                }
                catch (Exception ex)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(ex.GetType().Name +
                        ex.ToString());
                    SelectSendHexRadioButton();
                    return;
                }
                this.txtSend.Text = s;
                this.Config.SendDataMode = DataMode.Ascii;
                SelectSendAsciiRadioButton();
            }
        }
        #endregion //rbSendAsc_Click

        #region SelectSendAsciiRadioButton
        private void SelectSendAsciiRadioButton()
        {
            rbSendAsc.Checked = true;
            rbSendHex.Checked = false;
        }
        #endregion //SelectSendAsciiRadioButton

        #region SelectSendHexRadioButton
        private void SelectSendHexRadioButton()
        {
            rbSendAsc.Checked = false;
            rbSendHex.Checked = true;
        }
        #endregion //SelectSendHexRadioButton

        #region rbSendHex_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSendHex_Click(object sender, EventArgs e)
        {
            if (!rbSendHex.Checked)
            {
                this.txtSend.Text = StringConverter.UTF8ToHex(this.txtSend.Text);
                rbSendAsc.Checked = false;
                rbSendHex.Checked = true;
                this.Config.SendDataMode = DataMode.Hex;
            }
        }
        #endregion //rbSendHex_Click

        #region mnuEnableTransmit_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEnableTransmit_Click(object sender, EventArgs e)
        {
            this.Transmitter.Enable = !this.Transmitter.Enable;
            this.RefreshTransmitState();
        }
        #endregion //mnuEnableTransmit_Click

        #region mnuSerialPortSetting_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSerialPortSetting_Click(object sender, EventArgs e)
        {
            frmSerialPort f = new frmSerialPort();
            f.SerialPortSettings = this.SerialPortManager.SerialPortSettings;

            DialogResult dr = f.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                RefreshSerialPortState();
                //RefreshStatus();
            }
        }
        #endregion //mnuSerialPortSetting_Click

        #region mnuEnableReply_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuEnableReply_Click(object sender, EventArgs e)
        {
            this.ReplyCollection.Enabled = !this.ReplyCollection.Enabled;
            RefreshReplyState();

        }
        #endregion //mnuEnableReply_Click

        #region mnuReplySetting_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuReplySetting_Click(object sender, EventArgs e)
        {
            frmReplyManager f = new frmReplyManager(this.ReplyCollection);
            f.ShowDialog();
        }
        #endregion //mnuReplySetting_Click

        #region mnuOpenSerialPort_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpenSerialPort_Click(object sender, EventArgs e)
        {
            if (!this.SerialPortManager.IsOpen)
            {
                try
                {
                    this.SerialPortManager.Open();
                }
                catch (Exception ex)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                    return;
                }

                RefreshSerialPortState();
            }
        }

        #endregion //mnuOpenSerialPort_Click

        #region mnuCloseSerialPort_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCloseSerialPort_Click(object sender, EventArgs e)
        {
            if (this.SerialPortManager.IsOpen)
            {
                this.SerialPortManager.Close();
                RefreshSerialPortState();
            }
        }
        #endregion //mnuCloseSerialPort_Click


        #region frmMain_FormClosed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
            //
            int[] columnWidths = new int[this.dataGridView1.Columns.Count];
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                columnWidths[i] = this.dataGridView1.Columns[i].Width;
            }
            this.Config.ListViewColumnWidths = columnWidths;

            // 
            //
            Config.FormSize = this.Size;
            Config.Location = this.Location;
        }
        #endregion //frmMain_FormClosed

        #region rdoAsc_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoAsc_Click(object sender, EventArgs e)
        {
            this.Config.LogDataMode = DataMode.Ascii;
            RefreshLogDataGridView();
        }
        #endregion //rdoAsc_Click

        #region RefreshLogDataGridView
        /// <summary>
        /// 
        /// </summary>
        private void RefreshLogDataGridView()
        {
            this.dataGridView1.Rows.Clear();
            string dataHeader = Strings.DataHex;
            if (rdoAsc.Checked)
            {
                dataHeader = Strings.DataAscii;
            }

            this.dataGridView1.Columns["colDatas"].HeaderText = dataHeader;
            foreach (LogItem li in this.LogManager.Items)
            {
                this.AddLog(li);
            }
        }
        #endregion //RefreshLogDataGridView

        #region rdoHex_Click
        private void rdoHex_Click(object sender, EventArgs e)
        {
            this.Config.LogDataMode = DataMode.Hex;
            RefreshLogDataGridView();
        }
        #endregion //rdoHex_Click

        #region mnuExit_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion //mnuExit_Click

        #region mnuAbout_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            string text = string.Format(
                "{0}\r\n{1}\r\n\r\n{2}",
                Application.ProductName,
                Application.ProductVersion,
                "hkiaipc@163.com");

            MessageBox.Show(this, text, 
                Strings.About, 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
        #endregion //mnuAbout_Click

        #region txtSend_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbSendHex.Checked)
            {
                KeyPressHelper.Process(sender, e);
            }
        }
        #endregion //txtSend_KeyPress

        #region mnuSaveLog_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSaveLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                LogSaver saver = new LogSaver( this.LogManager );
                try
                {
                    saver.Save(path);
                }
                catch (Exception ex)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                }
            }
        }
        #endregion //mnuSaveLog_Click
    }
}
