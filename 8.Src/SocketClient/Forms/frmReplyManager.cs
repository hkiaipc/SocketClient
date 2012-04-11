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
        public frmReplyManager(ReplyCollection replys)
        {
            InitializeComponent();
            this._replyCollection = replys;
            RefreshListview(_replyCollection);
            this.lvReply.ItemChecked += new ItemCheckedEventHandler(listView1_ItemChecked);
        }

        void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem lvi = e.Item;
            ReplyItem asi = lvi.Tag as ReplyItem;
            asi.Enabled = lvi.Checked;
        }

        private ReplyCollection _replyCollection;
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
        private void AddReplyItemToListView(ReplyItem ri)
        {
            ListViewItem lvi = new ListViewItem(ri.Name);

            string[] subItems = new string[] 
            { 
                ri.ReceivedPattern,
                HexStringConverter.Default.ConvertToObject(ri.ReplyBytes).ToString(),
                ri.Description 
            };

            lvi.SubItems.AddRange(subItems);
            lvi.Checked = ri.Enabled;
            lvi.Tag = ri;
            this.lvReply.Items.Add(lvi);
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
                ReplyItem ri = lvi.Tag as ReplyItem;

                frmReplyItem f = new frmReplyItem(ri);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    lvi.SubItems[0].Text = ri.Name;
                    lvi.SubItems[1].Text = ri.ReceivedPattern;
                    lvi.SubItems[2].Text = HexStringConverter.Default.ConvertToObject(ri.ReplyBytes).ToString();
                    lvi.SubItems[3].Text = ri.Description;
                }
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.SelectListViewItemFirst);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmReplyItem f = new frmReplyItem();
            if (f.ShowDialog() == DialogResult.OK)
            {
                ReplyItem ri = f.ReplyItem;
                this._replyCollection.Add(ri);
                this.AddReplyItemToListView(ri);
                this.lvReply.SelectedIndices.Add(this.lvReply.Items.Count - 1);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteListViewItem();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteListViewItem()
        {
            if (this.lvReply.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvReply.SelectedItems[0];
                int index = lvi.Index;
                ReplyItem item = (ReplyItem)lvi.Tag;

                string msg = Strings.AreYouSureDelete;
                if (NUnit.UiKit.UserMessage.Ask(msg) == DialogResult.Yes)
                {

                    this._replyCollection.Remove(item);
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
                }
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.SelectListViewItemFirst);
            }
        }

        private void lvReply_KeyUp(object sender, KeyEventArgs e)
        {
            DeleteListViewItem();
        }
    }
}
