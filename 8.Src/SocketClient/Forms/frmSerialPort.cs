using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SocketClient
{
    public partial class frmSerialPort : Form
    {
        public frmSerialPort()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                App.Default.SerialPortManager.PortName = this.txtSerialPortName.Text.Trim();
                App.Default.SerialPortManager.Setting = this.txtSetting.Text;
            }
            catch (Exception ex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSerialPort_Load(object sender, EventArgs e)
        {
            this.txtSerialPortName.Text = App.Default.SerialPortManager.PortName;
            this.txtSetting.Text = App.Default.SerialPortManager.Setting;
        }
    }
}
