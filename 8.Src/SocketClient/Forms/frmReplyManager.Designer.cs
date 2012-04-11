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
            this.chReceived = new System.Windows.Forms.ColumnHeader();
            this.chReply = new System.Windows.Forms.ColumnHeader();
            this.chDescription = new System.Windows.Forms.ColumnHeader();
            this.btnModify = new System.Windows.Forms.Button();
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
            this.chReceived,
            this.chReply,
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
            this.lvReply.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvReply_KeyUp);
            // 
            // chName
            // 
            this.chName.Text = "名称";
            this.chName.Width = 90;
            // 
            // chReceived
            // 
            this.chReceived.Text = "接收(Hex)";
            this.chReceived.Width = 113;
            // 
            // chReply
            // 
            this.chReply.Text = "回复(Hex)";
            this.chReply.Width = 289;
            // 
            // chDescription
            // 
            this.chDescription.Text = "描述";
            this.chDescription.Width = 91;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(93, 169);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 169);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 169);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmReplyManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 203);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.lvReply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplyManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "回复设置";
            this.Load += new System.EventHandler(this.frmReplyManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvReply;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader chReceived;
        private System.Windows.Forms.ColumnHeader chReply;
    }
}