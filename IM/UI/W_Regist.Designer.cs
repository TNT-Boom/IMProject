namespace IM.UI
{
    partial class W_Regist
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
            this.grpBox_regist = new System.Windows.Forms.GroupBox();
            this.txtBox_Sex = new System.Windows.Forms.TextBox();
            this.txtBox_age = new System.Windows.Forms.TextBox();
            this.txtBox_rePwd = new System.Windows.Forms.TextBox();
            this.txtBox_pwd = new System.Windows.Forms.TextBox();
            this.txtBox_userName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.grpBox_regist.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox_regist
            // 
            this.grpBox_regist.Controls.Add(this.txtBox_Sex);
            this.grpBox_regist.Controls.Add(this.txtBox_age);
            this.grpBox_regist.Controls.Add(this.txtBox_rePwd);
            this.grpBox_regist.Controls.Add(this.txtBox_pwd);
            this.grpBox_regist.Controls.Add(this.txtBox_userName);
            this.grpBox_regist.Controls.Add(this.label5);
            this.grpBox_regist.Controls.Add(this.label4);
            this.grpBox_regist.Controls.Add(this.label3);
            this.grpBox_regist.Controls.Add(this.label2);
            this.grpBox_regist.Controls.Add(this.label1);
            this.grpBox_regist.Location = new System.Drawing.Point(55, 25);
            this.grpBox_regist.Name = "grpBox_regist";
            this.grpBox_regist.Size = new System.Drawing.Size(352, 208);
            this.grpBox_regist.TabIndex = 0;
            this.grpBox_regist.TabStop = false;
            this.grpBox_regist.Text = "基本信息填写";
            // 
            // txtBox_Sex
            // 
            this.txtBox_Sex.Location = new System.Drawing.Point(140, 66);
            this.txtBox_Sex.Name = "txtBox_Sex";
            this.txtBox_Sex.Size = new System.Drawing.Size(163, 21);
            this.txtBox_Sex.TabIndex = 1;
            // 
            // txtBox_age
            // 
            this.txtBox_age.Location = new System.Drawing.Point(140, 95);
            this.txtBox_age.Name = "txtBox_age";
            this.txtBox_age.Size = new System.Drawing.Size(163, 21);
            this.txtBox_age.TabIndex = 2;
            // 
            // txtBox_rePwd
            // 
            this.txtBox_rePwd.Location = new System.Drawing.Point(140, 159);
            this.txtBox_rePwd.Name = "txtBox_rePwd";
            this.txtBox_rePwd.Size = new System.Drawing.Size(163, 21);
            this.txtBox_rePwd.TabIndex = 4;
            // 
            // txtBox_pwd
            // 
            this.txtBox_pwd.Location = new System.Drawing.Point(140, 122);
            this.txtBox_pwd.Name = "txtBox_pwd";
            this.txtBox_pwd.Size = new System.Drawing.Size(163, 21);
            this.txtBox_pwd.TabIndex = 3;
            // 
            // txtBox_userName
            // 
            this.txtBox_userName.Location = new System.Drawing.Point(140, 34);
            this.txtBox_userName.Name = "txtBox_userName";
            this.txtBox_userName.Size = new System.Drawing.Size(163, 21);
            this.txtBox_userName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "重复密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "年龄";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "性别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(104, 250);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_return
            // 
            this.btn_return.Location = new System.Drawing.Point(242, 250);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(75, 23);
            this.btn_return.TabIndex = 2;
            this.btn_return.Text = "返回";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // W_Regist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 290);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.grpBox_regist);
            this.Name = "W_Regist";
            this.Text = "Regist";
            this.grpBox_regist.ResumeLayout(false);
            this.grpBox_regist.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox_regist;
        private System.Windows.Forms.TextBox txtBox_Sex;
        private System.Windows.Forms.TextBox txtBox_age;
        private System.Windows.Forms.TextBox txtBox_rePwd;
        private System.Windows.Forms.TextBox txtBox_pwd;
        private System.Windows.Forms.TextBox txtBox_userName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_return;
    }
}