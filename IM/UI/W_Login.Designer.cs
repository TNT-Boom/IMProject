namespace IM.UI
{
    partial class W_Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_logIn = new System.Windows.Forms.Button();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.txt_userPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_regist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_logIn
            // 
            this.btn_logIn.Location = new System.Drawing.Point(62, 131);
            this.btn_logIn.Name = "btn_logIn";
            this.btn_logIn.Size = new System.Drawing.Size(75, 23);
            this.btn_logIn.TabIndex = 1;
            this.btn_logIn.Text = "登录";
            this.btn_logIn.UseVisualStyleBackColor = true;
            this.btn_logIn.Click += new System.EventHandler(this.btn_logIn_Click);
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(76, 42);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(144, 21);
            this.txt_userName.TabIndex = 2;
            this.txt_userName.Text = "xiaoli";
            // 
            // txt_userPwd
            // 
            this.txt_userPwd.Location = new System.Drawing.Point(76, 94);
            this.txt_userPwd.Name = "txt_userPwd";
            this.txt_userPwd.Size = new System.Drawing.Size(144, 21);
            this.txt_userPwd.TabIndex = 3;
            this.txt_userPwd.Text = "123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "账号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码:";
            // 
            // btn_regist
            // 
            this.btn_regist.Location = new System.Drawing.Point(145, 131);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(75, 23);
            this.btn_regist.TabIndex = 6;
            this.btn_regist.Text = "注册";
            this.btn_regist.UseVisualStyleBackColor = true;
            this.btn_regist.Click += new System.EventHandler(this.btn_regist_Click);
            // 
            // W_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 183);
            this.Controls.Add(this.btn_regist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_userPwd);
            this.Controls.Add(this.txt_userName);
            this.Controls.Add(this.btn_logIn);
            this.Name = "W_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_logIn;

        //危险代码
        public System.Windows.Forms.TextBox txt_userName;
        public System.Windows.Forms.TextBox txt_userPwd;


        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_regist;
    }
}

