namespace SocketClient
{
    partial class frmReplyItem
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblReceived = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtReply = new System.Windows.Forms.TextBox();
            this.lblReply = new System.Windows.Forms.Label();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(83, 132);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(258, 63);
            this.txtDescription.TabIndex = 7;
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.Location = new System.Drawing.Point(9, 39);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(65, 12);
            this.lblReceived.TabIndex = 2;
            this.lblReceived.Text = "接收(Hex):";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(258, 21);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "名称:";
            // 
            // txtReply
            // 
            this.txtReply.Location = new System.Drawing.Point(83, 63);
            this.txtReply.Multiline = true;
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(258, 63);
            this.txtReply.TabIndex = 5;
            this.txtReply.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReply_KeyPress);
            // 
            // lblReply
            // 
            this.lblReply.AutoSize = true;
            this.lblReply.Location = new System.Drawing.Point(9, 66);
            this.lblReply.Name = "lblReply";
            this.lblReply.Size = new System.Drawing.Size(65, 12);
            this.lblReply.TabIndex = 4;
            this.lblReply.Text = "回复(Hex):";
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(83, 36);
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.Size = new System.Drawing.Size(258, 21);
            this.txtReceived.TabIndex = 3;
            this.txtReceived.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceived_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 135);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(35, 12);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "描述:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(185, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(266, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmReplyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 245);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblReceived);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.lblReply);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplyItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "回复";
            this.Load += new System.EventHandler(this.frmReplyItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtReply;
        private System.Windows.Forms.Label lblReply;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}