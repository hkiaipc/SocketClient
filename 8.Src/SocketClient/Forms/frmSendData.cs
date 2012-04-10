using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class frmSendData : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmSendData()
        {
            InitializeComponent();
            this.SendItem = new SendItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendItem"></param>
        public frmSendData(SendItem sendItem)
        {
            if (sendItem == null)
            {
                throw new ArgumentNullException("sendItem");
            }

            InitializeComponent();

            this.SendItem = sendItem;
            this.IsEdit = true;

            this.txtName.Text = this.SendItem.Name;
            this.txtDatas.Text = HexStringConverter.Default.ConvertToObject(this.SendItem.Bytes).ToString();
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
            byte[] datas = null;
            try
            {
                datas = (byte[])HexStringConverter.Default.ConvertToBytes(this.txtDatas.Text);
            }
            catch (Exception ex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                return;
            }

            if (datas.Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.SendDataCannotEmpty);
                return;
            }

            string s = txtName.Text.Trim();
            if (s.Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.SendDataNameCannotEmpty);
                return;
            }

            this.SendItem.Name = s;
            this.SendItem.Bytes = datas;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public SendItem SendItem
        {
            get
            {
                return _sendItem;
            }
            set
            {
                _sendItem = value;
            }
        } private SendItem _sendItem;


        /// <summary>
        /// 
        /// </summary>
        public bool IsEdit
        {
            get
            {
                return _isEdit;
            }
            set
            {
                _isEdit = value;
            }
        } private bool _isEdit;

    }
}
