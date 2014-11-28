namespace IM.UI
{
    partial class W_SingleChat
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
            this.button3 = new System.Windows.Forms.Button();
            this.txt_sendMsg = new System.Windows.Forms.TextBox();
            this.btn_sendMsg = new System.Windows.Forms.Button();
            this.lstBox_recMsg = new System.Windows.Forms.ListBox();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(378, 207);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "清空";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txt_sendMsg
            // 
            this.txt_sendMsg.Location = new System.Drawing.Point(21, 257);
            this.txt_sendMsg.Multiline = true;
            this.txt_sendMsg.Name = "txt_sendMsg";
            this.txt_sendMsg.Size = new System.Drawing.Size(351, 99);
            this.txt_sendMsg.TabIndex = 4;
            // 
            // btn_sendMsg
            // 
            this.btn_sendMsg.Location = new System.Drawing.Point(378, 333);
            this.btn_sendMsg.Name = "btn_sendMsg";
            this.btn_sendMsg.Size = new System.Drawing.Size(75, 23);
            this.btn_sendMsg.TabIndex = 5;
            this.btn_sendMsg.Text = "发送消息";
            this.btn_sendMsg.UseVisualStyleBackColor = true;
            this.btn_sendMsg.Click += new System.EventHandler(this.btn_sendMsg_Click);
            // 
            // lstBox_recMsg
            // 
            this.lstBox_recMsg.FormattingEnabled = true;
            this.lstBox_recMsg.ItemHeight = 12;
            this.lstBox_recMsg.Location = new System.Drawing.Point(21, 34);
            this.lstBox_recMsg.Name = "lstBox_recMsg";
            this.lstBox_recMsg.Size = new System.Drawing.Size(351, 196);
            this.lstBox_recMsg.TabIndex = 6;
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Location = new System.Drawing.Point(19, 9);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(77, 12);
            this.lbl_userName.TabIndex = 8;
            this.lbl_userName.Text = "lbl_userName";
            // 
            // W_SingleChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 368);
            this.Controls.Add(this.lbl_userName);
            this.Controls.Add(this.lstBox_recMsg);
            this.Controls.Add(this.btn_sendMsg);
            this.Controls.Add(this.txt_sendMsg);
            this.Controls.Add(this.button3);
            this.Name = "W_SingleChat";
            this.Text = "W_SingChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.W_SingleChat_FormClosing);
            this.Load += new System.EventHandler(this.W_SingleChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_sendMsg;
        private System.Windows.Forms.Button btn_sendMsg;
        private System.Windows.Forms.ListBox lstBox_recMsg;
        private System.Windows.Forms.Label lbl_userName;

    }
}