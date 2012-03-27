namespace SocketClient
{
    partial class frmReplyManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvReply = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chDescription = new System.Windows.Forms.ColumnHeader();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.txtReply = new System.Windows.Forms.TextBox();
            this.lblReply = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblReceived = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lvReply
            // 
            this.lvReply.CheckBoxes = true;
            this.lvReply.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chDescription});
            this.lvReply.FullRowSelect = true;
            this.lvReply.GridLines = true;
            this.lvReply.Location = new System.Drawing.Point(12, 12);
            this.lvReply.MultiSelect = false;
            this.lvReply.Name = "lvReply";
            this.lvReply.Size = new System.Drawing.Size(589, 151);
            this.lvReply.TabIndex = 0;
            this.lvReply.UseCompatibleStateImageBehavior = false;
            this.lvReply.View = System.Windows.Forms.View.Details;
            this.lvReply.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvReply_ItemChecked);
            this.lvReply.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "名称";
            this.chName.Width = 174;
            // 
            // chDescription
            // 
            this.chDescription.Text = "描述";
            this.chDescription.Width = 333;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(24, 233);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 12);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "描述:";
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(98, 257);
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.Size = new System.Drawing.Size(503, 21);
            this.txtReceived.TabIndex = 6;
            // 
            // txtReply
            // 
            this.txtReply.Location = new System.Drawing.Point(98, 284);
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(503, 21);
            this.txtReply.TabIndex = 8;
            this.txtReply.TextChanged += new System.EventHandler(this.txtBytes_TextChanged);
            // 
            // lblReply
            // 
            this.lblReply.AutoSize = true;
            this.lblReply.Location = new System.Drawing.Point(24, 287);
            this.lblReply.Name = "lblReply";
            this.lblReply.Size = new System.Drawing.Size(65, 12);
            this.lblReply.TabIndex = 7;
            this.lblReply.Text = "回复(Hex):";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(439, 312);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(98, 230);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(503, 21);
            this.txtDescription.TabIndex = 4;
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.Location = new System.Drawing.Point(24, 260);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(65, 12);
            this.lblReceived.TabIndex = 5;
            this.lblReceived.Text = "接收(Hex):";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 203);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(503, 21);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 206);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "名称:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(358, 312);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(520, 312);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmAutoSenderCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 347);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblReceived);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.lblReply);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lvReply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutoSenderCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "回复设置";
            this.Load += new System.EventHandler(this.frmAutoSenderCollection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvReply;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.TextBox txtReply;
        private System.Windows.Forms.Label lblReply;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}