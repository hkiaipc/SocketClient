using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class frmReplyItem : Form
    {
        public frmReplyItem()
        {
            InitializeComponent();
        }

        public frmReplyItem(ReplyItem replyItem)
        {

            if (replyItem == null)
            {
                throw new ArgumentNullException("replyItem");
            }

            InitializeComponent();
            this.ReplyItem = replyItem;
            this.IsEdit = true;

            this.txtName.Text = this.ReplyItem.Name;
            this.txtReceived.Text = this.ReplyItem.ReceivedPattern;
            this.txtReply.Text = HexStringConverter.Default.ConvertToObject(this.ReplyItem.ReplyBytes).ToString();
            this.txtDescription.Text = this.ReplyItem.Description;
        }



        #region IsEdit
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
        #endregion //IsEdit

        #region ReplyItem
        /// <summary>
        /// 
        /// </summary>
        public ReplyItem ReplyItem
        {
            get
            {
                if (_replyItem == null)
                {
                    _replyItem = new ReplyItem();
                }
                return _replyItem;
            }
            set
            {
                _replyItem = value;
            }
        } private ReplyItem _replyItem;
        #endregion //ReplyItem

        private void frmReplyItem_Load(object sender, EventArgs e)
        {

        }

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressHelper.Process(sender, e);
        }

        private void txtReply_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressHelper.Process(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            byte[] received, reply;
            try
            {
                received = (byte[])HexStringConverter.Default.ConvertToBytes(txtReceived.Text);
                reply =(byte[])HexStringConverter.Default.ConvertToBytes(txtReply.Text);
            }
            catch (Exception ex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                return;
            }

            if (received.Length == 0 || reply.Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.ReceivedReplyLengthZero);
                return;
            }

            this.ReplyItem.Name = this.txtName.Text.Trim();
            this.ReplyItem.ReceivedPattern = HexStringConverter.Default.ConvertToObject(received).ToString();
            this.ReplyItem.ReplyBytes = reply;
            this.ReplyItem.Description = this.txtDescription.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
