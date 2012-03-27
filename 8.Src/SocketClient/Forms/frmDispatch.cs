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
    public partial class frmDispatch : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmDispatch()
        {
            InitializeComponent();
            this.chkEnable.Checked = App.Default.Dispatcher.Enable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDispatch_Load(object sender, EventArgs e)
        {
            //this.txtPortName.Text = Config.Default.PortName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            App.Default.Dispatcher.Enable = this.chkEnable.Checked;

            if (App.Default.Dispatcher.Enable)
            {
                //App.Default.Dispatcher.D1 = new SocketDispatcherAdpater(
                //    App.Default.SocketClientManager);
                //App.Default.Dispatcher.D2 = new SerialPortDispatcherAdpater(
                //    App.Default.SerialPortManager);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EnableDispatcher
        {
            get { return this.chkEnable.Checked; }
        }

    }
}
