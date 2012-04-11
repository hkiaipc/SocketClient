using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class frmSendDataManager : Form
    {
        public frmSendDataManager()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        private void SelectListViewItemFirst()
        {
            NUnit.UiKit.UserMessage.DisplayFailure(Strings.SelectListViewItemFirst);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedListViewItem(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="displaySelectMessage"></param>
        private void DeleteSelectedListViewItem(bool displaySelectMessage)
        {
            ListViewItem lvi = GetSelectedListViewItem();
            if (lvi == null)
            {
                if (displaySelectMessage)
                {
                    SelectListViewItemFirst();
                }
                return;
            }

            DialogResult dr = NUnit.UiKit.UserMessage.Ask(Strings.AreYouSureDelete);
            if (dr == DialogResult.Yes)
            {
                int index = lvi.Index;

                SendItem item = lvi.Tag as SendItem;
                listView1.Items.Remove(lvi);
                App.Default.Config.SendCollection.Remove(item);

                if (this.listView1.Items.Count > 0)
                {
                    if (index >= this.listView1.Items.Count)
                    {
                        index = this.listView1.Items.Count - 1;
                    }
                    this.listView1.SelectedIndices.Clear();
                    this.listView1.SelectedIndices.Add(index);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSendData f = new frmSendData();
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                SendItem item = f.SendItem;
                App.Default.Config.SendCollection.Add(item);
                AddSendItemToListView(item);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = GetSelectedListViewItem();
            if (lvi == null)
            {
                SelectListViewItemFirst();
                return;
            }

            SendItem item = lvi.Tag as SendItem;
            frmSendData f = new frmSendData(item);
            DialogResult dr = f.ShowDialog();

            if (dr == DialogResult.OK)
            {
                lvi.Text = item.Name;
                string s = HexStringConverter.Default.ConvertToObject(item.Bytes).ToString();
                lvi.SubItems[1].Text = s;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ListViewItem GetSelectedListViewItem()
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                return listView1.SelectedItems[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSendDataManager_Load(object sender, EventArgs e)
        {
            foreach (SendItem item in App.Default.Config.SendCollection)
            {
                AddSendItemToListView(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void AddSendItemToListView(SendItem item)
        {
            ListViewItem lvi = this.listView1.Items.Add(item.Name);
            string s = HexStringConverter.Default.ConvertToObject(item.Bytes).ToString();
            lvi.SubItems.Add(s);
            lvi.Tag = item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectSendItem();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SelectSendItem()
        {
            ListViewItem lvi= GetSelectedListViewItem();
            if (lvi != null)
            {
                SendItem item = lvi.Tag as SendItem;
                this._selectedSendItem = item;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                SelectListViewItemFirst();
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SendItem SelectedSendItem
        {
            get
            {
                return _selectedSendItem;
            }
        } private SendItem _selectedSendItem;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            SelectSendItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedListViewItem(false);
            }
        }
    }
}
