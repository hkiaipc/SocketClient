namespace SocketClient
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpConnectTo = new System.Windows.Forms.GroupBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbIPAddress = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpReceived = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoHex = new System.Windows.Forms.RadioButton();
            this.rdoAsc = new System.Windows.Forms.RadioButton();
            this.btnClearReceived = new System.Windows.Forms.Button();
            this.grpSend = new System.Windows.Forms.GroupBox();
            this.rbSendHex = new System.Windows.Forms.RadioButton();
            this.rbSendAsc = new System.Windows.Forms.RadioButton();
            this.btnSendHistory = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssSocket = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSerialPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTransmitter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssReply = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSerialPort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenSerialPort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseSerialPort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnableTransmit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSerialPortSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReply = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnableReply = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReplySetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.grpConnectTo.SuspendLayout();
            this.grpReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpSend.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnectTo
            // 
            this.grpConnectTo.Controls.Add(this.cmbPort);
            this.grpConnectTo.Controls.Add(this.cmbIPAddress);
            this.grpConnectTo.Controls.Add(this.lblPort);
            this.grpConnectTo.Controls.Add(this.lblIPAddress);
            this.grpConnectTo.Controls.Add(this.btnConnect);
            this.grpConnectTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConnectTo.Location = new System.Drawing.Point(0, 24);
            this.grpConnectTo.Name = "grpConnectTo";
            this.grpConnectTo.Size = new System.Drawing.Size(751, 75);
            this.grpConnectTo.TabIndex = 7;
            this.grpConnectTo.TabStop = false;
            this.grpConnectTo.Text = "连接";
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(83, 46);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(155, 20);
            this.cmbPort.TabIndex = 13;
            // 
            // cmbIPAddress
            // 
            this.cmbIPAddress.FormattingEnabled = true;
            this.cmbIPAddress.Location = new System.Drawing.Point(83, 20);
            this.cmbIPAddress.Name = "cmbIPAddress";
            this.cmbIPAddress.Size = new System.Drawing.Size(155, 20);
            this.cmbIPAddress.TabIndex = 12;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 49);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 12);
            this.lblPort.TabIndex = 11;
            this.lblPort.Text = "端口:";
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(6, 23);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(47, 12);
            this.lblIPAddress.TabIndex = 10;
            this.lblIPAddress.Text = "IP地址:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(244, 18);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpReceived
            // 
            this.grpReceived.Controls.Add(this.dataGridView1);
            this.grpReceived.Controls.Add(this.rdoHex);
            this.grpReceived.Controls.Add(this.rdoAsc);
            this.grpReceived.Controls.Add(this.btnClearReceived);
            this.grpReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceived.Location = new System.Drawing.Point(0, 99);
            this.grpReceived.Name = "grpReceived";
            this.grpReceived.Size = new System.Drawing.Size(751, 275);
            this.grpReceived.TabIndex = 8;
            this.grpReceived.TabStop = false;
            this.grpReceived.Text = "通讯记录";
            this.grpReceived.Enter += new System.EventHandler(this.grpReceived_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDT,
            this.colFrom,
            this.colTO,
            this.colLength,
            this.colDatas});
            this.dataGridView1.Location = new System.Drawing.Point(8, 20);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(656, 249);
            this.dataGridView1.TabIndex = 6;
            // 
            // colDT
            // 
            dataGridViewCellStyle2.Format = "yyyy-MM-dd hh:mm:ss.fff";
            dataGridViewCellStyle2.NullValue = null;
            this.colDT.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDT.HeaderText = "时间";
            this.colDT.Name = "colDT";
            this.colDT.ReadOnly = true;
            this.colDT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFrom
            // 
            this.colFrom.HeaderText = "从";
            this.colFrom.Name = "colFrom";
            this.colFrom.ReadOnly = true;
            this.colFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTO
            // 
            this.colTO.HeaderText = "到";
            this.colTO.Name = "colTO";
            this.colTO.ReadOnly = true;
            this.colTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colLength
            // 
            this.colLength.HeaderText = "长度";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDatas
            // 
            this.colDatas.HeaderText = "数据";
            this.colDatas.Name = "colDatas";
            this.colDatas.ReadOnly = true;
            this.colDatas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // rdoHex
            // 
            this.rdoHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoHex.AutoSize = true;
            this.rdoHex.Checked = true;
            this.rdoHex.Location = new System.Drawing.Point(670, 43);
            this.rdoHex.Name = "rdoHex";
            this.rdoHex.Size = new System.Drawing.Size(41, 16);
            this.rdoHex.TabIndex = 3;
            this.rdoHex.TabStop = true;
            this.rdoHex.Text = "Hex";
            this.rdoHex.UseVisualStyleBackColor = true;
            this.rdoHex.Click += new System.EventHandler(this.rdoHex_Click);
            // 
            // rdoAsc
            // 
            this.rdoAsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoAsc.AutoSize = true;
            this.rdoAsc.Location = new System.Drawing.Point(670, 21);
            this.rdoAsc.Name = "rdoAsc";
            this.rdoAsc.Size = new System.Drawing.Size(53, 16);
            this.rdoAsc.TabIndex = 2;
            this.rdoAsc.Text = "Ascii";
            this.rdoAsc.UseVisualStyleBackColor = true;
            this.rdoAsc.Click += new System.EventHandler(this.rdoAsc_Click);
            // 
            // btnClearReceived
            // 
            this.btnClearReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearReceived.Location = new System.Drawing.Point(670, 246);
            this.btnClearReceived.Name = "btnClearReceived";
            this.btnClearReceived.Size = new System.Drawing.Size(75, 23);
            this.btnClearReceived.TabIndex = 1;
            this.btnClearReceived.Text = "清除(&L)";
            this.btnClearReceived.UseVisualStyleBackColor = true;
            this.btnClearReceived.Click += new System.EventHandler(this.btnClearReceived_Click);
            // 
            // grpSend
            // 
            this.grpSend.Controls.Add(this.rbSendHex);
            this.grpSend.Controls.Add(this.rbSendAsc);
            this.grpSend.Controls.Add(this.btnSendHistory);
            this.grpSend.Controls.Add(this.btnSend);
            this.grpSend.Controls.Add(this.txtSend);
            this.grpSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpSend.Location = new System.Drawing.Point(0, 374);
            this.grpSend.Name = "grpSend";
            this.grpSend.Size = new System.Drawing.Size(751, 120);
            this.grpSend.TabIndex = 9;
            this.grpSend.TabStop = false;
            this.grpSend.Text = "发送";
            // 
            // rbSendHex
            // 
            this.rbSendHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSendHex.AutoCheck = false;
            this.rbSendHex.AutoSize = true;
            this.rbSendHex.Checked = true;
            this.rbSendHex.Location = new System.Drawing.Point(670, 42);
            this.rbSendHex.Name = "rbSendHex";
            this.rbSendHex.Size = new System.Drawing.Size(41, 16);
            this.rbSendHex.TabIndex = 6;
            this.rbSendHex.TabStop = true;
            this.rbSendHex.Text = "Hex";
            this.rbSendHex.UseVisualStyleBackColor = true;
            this.rbSendHex.Click += new System.EventHandler(this.rbSendHex_Click);
            // 
            // rbSendAsc
            // 
            this.rbSendAsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSendAsc.AutoCheck = false;
            this.rbSendAsc.AutoSize = true;
            this.rbSendAsc.Location = new System.Drawing.Point(670, 20);
            this.rbSendAsc.Name = "rbSendAsc";
            this.rbSendAsc.Size = new System.Drawing.Size(53, 16);
            this.rbSendAsc.TabIndex = 5;
            this.rbSendAsc.Text = "Ascii";
            this.rbSendAsc.UseVisualStyleBackColor = true;
            this.rbSendAsc.Click += new System.EventHandler(this.rbSendAsc_Click);
            // 
            // btnSendHistory
            // 
            this.btnSendHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.btnSendHistory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendHistory.Location = new System.Drawing.Point(670, 64);
            this.btnSendHistory.Name = "btnSendHistory";
            this.btnSendHistory.Size = new System.Drawing.Size(75, 23);
            this.btnSendHistory.TabIndex = 11;
            this.btnSendHistory.Text = "历史(&A)";
            this.btnSendHistory.UseVisualStyleBackColor = true;
            this.btnSendHistory.Click += new System.EventHandler(this.btnSendHistory_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(36, 4);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(670, 90);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSend.Location = new System.Drawing.Point(6, 20);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(658, 93);
            this.txtSend.TabIndex = 0;
            this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSend_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSocket,
            this.tssSerialPort,
            this.tssTransmitter,
            this.tssReply});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(751, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssSocket
            // 
            this.tssSocket.AutoSize = false;
            this.tssSocket.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssSocket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssSocket.Name = "tssSocket";
            this.tssSocket.Size = new System.Drawing.Size(63, 17);
            this.tssSocket.Text = "tssRemote";
            // 
            // tssSerialPort
            // 
            this.tssSerialPort.AutoSize = false;
            this.tssSerialPort.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssSerialPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssSerialPort.Name = "tssSerialPort";
            this.tssSerialPort.Size = new System.Drawing.Size(87, 17);
            this.tssSerialPort.Text = "tssSerialPort";
            // 
            // tssTransmitter
            // 
            this.tssTransmitter.AutoSize = false;
            this.tssTransmitter.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssTransmitter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssTransmitter.Name = "tssTransmitter";
            this.tssTransmitter.Size = new System.Drawing.Size(87, 17);
            this.tssTransmitter.Text = "tssTransmitter";
            // 
            // tssReply
            // 
            this.tssReply.AutoSize = false;
            this.tssReply.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssReply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssReply.Name = "tssReply";
            this.tssReply.Size = new System.Drawing.Size(200, 17);
            this.tssReply.Text = "tssReply";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.imageList1.Images.SetKeyName(0, "t.ico");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuSerialPort,
            this.mnuReply,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaveLog,
            this.toolStripSeparator3,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(59, 20);
            this.mnuFile.Text = "文件(&F)";
            // 
            // mnuSaveLog
            // 
            this.mnuSaveLog.Name = "mnuSaveLog";
            this.mnuSaveLog.Size = new System.Drawing.Size(130, 22);
            this.mnuSaveLog.Text = "保存(&S)...";
            this.mnuSaveLog.Click += new System.EventHandler(this.mnuSaveLog_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(127, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(130, 22);
            this.mnuExit.Text = "退出(&X)";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuSerialPort
            // 
            this.mnuSerialPort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenSerialPort,
            this.mnuCloseSerialPort,
            this.mnuEnableTransmit,
            this.toolStripSeparator1,
            this.mnuSerialPortSetting});
            this.mnuSerialPort.Name = "mnuSerialPort";
            this.mnuSerialPort.Size = new System.Drawing.Size(59, 20);
            this.mnuSerialPort.Text = "串口(&S)";
            // 
            // mnuOpenSerialPort
            // 
            this.mnuOpenSerialPort.Name = "mnuOpenSerialPort";
            this.mnuOpenSerialPort.Size = new System.Drawing.Size(130, 22);
            this.mnuOpenSerialPort.Text = "打开(&O)";
            this.mnuOpenSerialPort.Click += new System.EventHandler(this.mnuOpenSerialPort_Click);
            // 
            // mnuCloseSerialPort
            // 
            this.mnuCloseSerialPort.Name = "mnuCloseSerialPort";
            this.mnuCloseSerialPort.Size = new System.Drawing.Size(130, 22);
            this.mnuCloseSerialPort.Text = "关闭(&C)";
            this.mnuCloseSerialPort.Click += new System.EventHandler(this.mnuCloseSerialPort_Click);
            // 
            // mnuEnableTransmit
            // 
            this.mnuEnableTransmit.Name = "mnuEnableTransmit";
            this.mnuEnableTransmit.Size = new System.Drawing.Size(130, 22);
            this.mnuEnableTransmit.Text = "转发(&E)";
            this.mnuEnableTransmit.Click += new System.EventHandler(this.mnuEnableTransmit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // mnuSerialPortSetting
            // 
            this.mnuSerialPortSetting.Name = "mnuSerialPortSetting";
            this.mnuSerialPortSetting.Size = new System.Drawing.Size(130, 22);
            this.mnuSerialPortSetting.Text = "设置(&S)...";
            this.mnuSerialPortSetting.Click += new System.EventHandler(this.mnuSerialPortSetting_Click);
            // 
            // mnuReply
            // 
            this.mnuReply.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEnableReply,
            this.toolStripSeparator2,
            this.mnuReplySetting});
            this.mnuReply.Name = "mnuReply";
            this.mnuReply.Size = new System.Drawing.Size(59, 20);
            this.mnuReply.Text = "回复(&R)";
            // 
            // mnuEnableReply
            // 
            this.mnuEnableReply.Name = "mnuEnableReply";
            this.mnuEnableReply.Size = new System.Drawing.Size(136, 22);
            this.mnuEnableReply.Text = "启用回复(&A)";
            this.mnuEnableReply.Click += new System.EventHandler(this.mnuEnableReply_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuReplySetting
            // 
            this.mnuReplySetting.Name = "mnuReplySetting";
            this.mnuReplySetting.Size = new System.Drawing.Size(136, 22);
            this.mnuReplySetting.Text = "设置(&S)...";
            this.mnuReplySetting.Click += new System.EventHandler(this.mnuReplySetting_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(59, 20);
            this.mnuHelp.Text = "帮助(&H)";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(130, 22);
            this.mnuAbout.Text = "关于(&A)...";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 516);
            this.Controls.Add(this.grpReceived);
            this.Controls.Add(this.grpSend);
            this.Controls.Add(this.grpConnectTo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Socket Debugger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.grpConnectTo.ResumeLayout(false);
            this.grpConnectTo.PerformLayout();
            this.grpReceived.ResumeLayout(false);
            this.grpReceived.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpSend.ResumeLayout(false);
            this.grpSend.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnectTo;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpReceived;
        private System.Windows.Forms.Button btnClearReceived;
        private System.Windows.Forms.GroupBox grpSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.RadioButton rdoHex;
        private System.Windows.Forms.RadioButton rdoAsc;
        private System.Windows.Forms.Button btnSendHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssSocket;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripStatusLabel tssSerialPort;
        private System.Windows.Forms.ToolStripStatusLabel tssTransmitter;
        private System.Windows.Forms.ToolStripStatusLabel tssReply;
        private System.Windows.Forms.RadioButton rbSendHex;
        private System.Windows.Forms.RadioButton rbSendAsc;
        private System.Windows.Forms.ComboBox cmbIPAddress;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuSerialPort;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenSerialPort;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseSerialPort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSerialPortSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuReply;
        private System.Windows.Forms.ToolStripMenuItem mnuEnableReply;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuReplySetting;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem mnuEnableTransmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatas;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

