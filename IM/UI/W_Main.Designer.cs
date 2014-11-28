namespace IM.UI
{
    partial class W_Main
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
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.pnl_userList = new System.Windows.Forms.Panel();
            this.btn_group = new System.Windows.Forms.Button();
            this.btn_addFrd = new System.Windows.Forms.Button();
            this.lbl_unRdMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(197, 557);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Location = new System.Drawing.Point(25, 13);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(0, 12);
            this.lbl_userName.TabIndex = 1;
            // 
            // pnl_userList
            // 
            this.pnl_userList.Location = new System.Drawing.Point(12, 82);
            this.pnl_userList.Name = "pnl_userList";
            this.pnl_userList.Size = new System.Drawing.Size(260, 468);
            this.pnl_userList.TabIndex = 2;
            // 
            // btn_group
            // 
            this.btn_group.Location = new System.Drawing.Point(12, 53);
            this.btn_group.Name = "btn_group";
            this.btn_group.Size = new System.Drawing.Size(260, 23);
            this.btn_group.TabIndex = 0;
            this.btn_group.Text = "群聊";
            this.btn_group.UseVisualStyleBackColor = true;
            this.btn_group.Click += new System.EventHandler(this.btn_group_Click);
            // 
            // btn_addFrd
            // 
            this.btn_addFrd.Location = new System.Drawing.Point(63, 556);
            this.btn_addFrd.Name = "btn_addFrd";
            this.btn_addFrd.Size = new System.Drawing.Size(75, 23);
            this.btn_addFrd.TabIndex = 3;
            this.btn_addFrd.Text = "添加好友";
            this.btn_addFrd.UseVisualStyleBackColor = true;
            this.btn_addFrd.Click += new System.EventHandler(this.btn_addFrd_Click);
            // 
            // lbl_unRdMsg
            // 
            this.lbl_unRdMsg.AutoSize = true;
            this.lbl_unRdMsg.Location = new System.Drawing.Point(12, 35);
            this.lbl_unRdMsg.Name = "lbl_unRdMsg";
            this.lbl_unRdMsg.Size = new System.Drawing.Size(41, 12);
            this.lbl_unRdMsg.TabIndex = 4;
            this.lbl_unRdMsg.Text = "label1";
            // 
            // W_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 601);
            this.Controls.Add(this.lbl_unRdMsg);
            this.Controls.Add(this.btn_addFrd);
            this.Controls.Add(this.btn_group);
            this.Controls.Add(this.pnl_userList);
            this.Controls.Add(this.lbl_userName);
            this.Controls.Add(this.btn_exit);
            this.Name = "W_Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.W_Main_FormClosed);
            this.Load += new System.EventHandler(this.W_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.Panel pnl_userList;
        private System.Windows.Forms.Button btn_group;
        private System.Windows.Forms.Button btn_addFrd;
        private System.Windows.Forms.Label lbl_unRdMsg;
    }
}