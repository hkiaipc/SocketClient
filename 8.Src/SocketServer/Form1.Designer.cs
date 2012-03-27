namespace SocketServer
{
    partial class Form1
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
            this.grpReceived = new System.Windows.Forms.GroupBox();
            this.btnClearReceived = new System.Windows.Forms.Button();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.grpSend = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.grpListenOn = new System.Windows.Forms.GroupBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisConnectCurrent = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.grpReceived.SuspendLayout();
            this.grpSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.grpListenOn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReceived
            // 
            this.grpReceived.Controls.Add(this.btnClearReceived);
            this.grpReceived.Controls.Add(this.txtReceived);
            this.grpReceived.Location = new System.Drawing.Point(12, 224);
            this.grpReceived.Name = "grpReceived";
            this.grpReceived.Size = new System.Drawing.Size(413, 193);
            this.grpReceived.TabIndex = 11;
            this.grpReceived.TabStop = false;
            this.grpReceived.Text = "Received Send";
            // 
            // btnClearReceived
            // 
            this.btnClearReceived.Location = new System.Drawing.Point(330, 163);
            this.btnClearReceived.Name = "btnClearReceived";
            this.btnClearReceived.Size = new System.Drawing.Size(75, 23);
            this.btnClearReceived.TabIndex = 1;
            this.btnClearReceived.Text = "Clear";
            this.btnClearReceived.UseVisualStyleBackColor = true;
            this.btnClearReceived.Click += new System.EventHandler(this.btnClearReceived_Click);
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(6, 20);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceived.Size = new System.Drawing.Size(318, 166);
            this.txtReceived.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(330, 18);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(330, 15);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.TabIndex = 7;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(6, 20);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(318, 21);
            this.txtSend.TabIndex = 0;
            // 
            // grpSend
            // 
            this.grpSend.Controls.Add(this.btnSend);
            this.grpSend.Controls.Add(this.txtSend);
            this.grpSend.Location = new System.Drawing.Point(12, 423);
            this.grpSend.Name = "grpSend";
            this.grpSend.Size = new System.Drawing.Size(413, 49);
            this.grpSend.TabIndex = 12;
            this.grpSend.TabStop = false;
            this.grpSend.Text = "Send";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(14, 49);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 12);
            this.lblPort.TabIndex = 11;
            this.lblPort.Text = "Port:";
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(14, 23);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(71, 12);
            this.lblIPAddress.TabIndex = 10;
            this.lblIPAddress.Text = "IP Address:";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(91, 44);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(233, 21);
            this.numPort.TabIndex = 9;
            this.numPort.Value = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            // 
            // grpListenOn
            // 
            this.grpListenOn.Controls.Add(this.lblPort);
            this.grpListenOn.Controls.Add(this.lblIPAddress);
            this.grpListenOn.Controls.Add(this.numPort);
            this.grpListenOn.Controls.Add(this.txtIP);
            this.grpListenOn.Controls.Add(this.btnListen);
            this.grpListenOn.Location = new System.Drawing.Point(12, 12);
            this.grpListenOn.Name = "grpListenOn";
            this.grpListenOn.Size = new System.Drawing.Size(413, 79);
            this.grpListenOn.TabIndex = 10;
            this.grpListenOn.TabStop = false;
            this.grpListenOn.Text = "Listen On";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(91, 17);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(233, 21);
            this.txtIP.TabIndex = 8;
            this.txtIP.Text = "127.0.0.1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisConnectCurrent);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 121);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clients";
            // 
            // btnDisConnectCurrent
            // 
            this.btnDisConnectCurrent.Location = new System.Drawing.Point(330, 20);
            this.btnDisConnectCurrent.Name = "btnDisConnectCurrent";
            this.btnDisConnectCurrent.Size = new System.Drawing.Size(75, 23);
            this.btnDisConnectCurrent.TabIndex = 14;
            this.btnDisConnectCurrent.Text = "DisConnect";
            this.btnDisConnectCurrent.UseVisualStyleBackColor = true;
            this.btnDisConnectCurrent.Click += new System.EventHandler(this.btnDisConnectCurrent_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(318, 88);
            this.listBox1.TabIndex = 15;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 486);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpReceived);
            this.Controls.Add(this.grpSend);
            this.Controls.Add(this.grpListenOn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "SocketServer 8.0.50727.762";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpReceived.ResumeLayout(false);
            this.grpReceived.PerformLayout();
            this.grpSend.ResumeLayout(false);
            this.grpSend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.grpListenOn.ResumeLayout(false);
            this.grpListenOn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.GroupBox grpReceived;
        private System.Windows.Forms.Button btnClearReceived;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.GroupBox grpSend;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.GroupBox grpListenOn;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisConnectCurrent;
        private System.Windows.Forms.ListBox listBox1;
    }
}

