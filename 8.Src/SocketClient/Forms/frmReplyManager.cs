using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SocketClient
{
    public partial class frmReplyManager : Form
    {
        public frmReplyManager( ReplyCollection asc)
        {
            InitializeComponent();
            this._asc = asc;
            RefreshListview(_asc);
            this.lvReply.ItemChecked += new ItemCheckedEventHandler(listView1_ItemChecked);
        }

        void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem lvi = e.Item;
            ReplyItem asi = lvi.Tag as ReplyItem;
            asi.Enabled = lvi.Checked;
        }

        private ReplyCollection _asc;
        private void frmAutoSenderCollection_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        void RefreshListview(ReplyCollection a)
        {
            this.lvReply.Items.Clear();
            foreach (ReplyItem item in a)
            {
                AddReplyItemToListView(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        private void AddReplyItemToListView(ReplyItem i)
        {
            ListViewItem lvi = new ListViewItem(i.Name);
            lvi.SubItems.Add(i.Description);
            lvi.Checked = i.Enabled;
            lvi.Tag = i;
            this.lvReply.Items.Add(lvi);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvReply.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvReply.SelectedItems[0];
                ReplyItem asi = lvi.Tag as ReplyItem;
                
                this.txtName.Text = asi.Name;
                this.txtDescription.Text = asi.Description;
                this.txtReceived.Text = asi.ReceivedPattern;
                this.txtReply.Text = HexStringConverter.Default.ConvertToObject(asi.ReplyBytes).ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.lvReply.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvReply.SelectedItems[0];
                ReplyItem asi = lvi.Tag as ReplyItem;
                string receivedPattern = string.Empty ;
                byte [] bytes = null ;
                try
                {
                    receivedPattern = (string)HexStringConverter.Default.ConvertToObject(
                        HexStringConverter.Default.ConvertToBytes(this.txtReceived.Text.Trim()));

                    bytes = HexStringConverter.Default.ConvertToBytes(this.txtReply.Text.Trim());
                }
                catch (Exception ex)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                    return;
                }

                asi.Name = this.txtName.Text.Trim();
                asi.Description = this.txtDescription.Text.Trim();
                asi.ReceivedPattern = receivedPattern;
                asi.ReplyBytes = bytes;

                lvi.SubItems[0].Text = asi.Name;
                lvi.SubItems[1].Text = asi.Description;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ReplyItem n = new ReplyItem(
                "name", 
                "description", 
                false, 
                "31 32 33",
                new byte[] { 0x34,0x35,0x36, 0x37, 0x38, 0x39 }
                );
            this._asc.Add(n);
            this.AddReplyItemToListView(n);

            this.lvReply.SelectedIndices.Clear();
            this.lvReply.SelectedIndices.Add(this.lvReply.Items.Count - 1);

        }

        private void txtBytes_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvReply_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem lvi = e.Item;
            ReplyItem item = lvi.Tag as ReplyItem;
            item.Enabled = lvi.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lvReply.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvReply.SelectedItems[0];
                int index = lvi.Index;
                ReplyItem item =  (ReplyItem)lvi.Tag;

                this._asc.Remove(item);
                lvi.Remove();

                if (this.lvReply.Items.Count > 0)
                {
                    if (index >= this.lvReply.Items.Count)
                    {
                        index = this.lvReply.Items.Count - 1;
                    }
                    this.lvReply.SelectedIndices.Clear();
                    this.lvReply.SelectedIndices.Add(index);
                }
                else
                {
                    this.txtName.Clear();
                    this.txtDescription.Clear();
                    this.txtReceived.Clear();
                    this.txtReply.Clear();
                }

                
            }
        }
    }
}
