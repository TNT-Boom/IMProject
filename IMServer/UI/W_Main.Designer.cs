namespace IMServer.UI
{
    partial class W_Main
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
            this.lstBox_statu = new System.Windows.Forms.ListBox();
            this.btn_startListen = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_endListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBox_statu
            // 
            this.lstBox_statu.FormattingEnabled = true;
            this.lstBox_statu.ItemHeight = 12;
            this.lstBox_statu.Location = new System.Drawing.Point(12, 53);
            this.lstBox_statu.Name = "lstBox_statu";
            this.lstBox_statu.Size = new System.Drawing.Size(362, 220);
            this.lstBox_statu.TabIndex = 0;
            // 
            // btn_startListen
            // 
            this.btn_startListen.Location = new System.Drawing.Point(35, 24);
            this.btn_startListen.Name = "btn_startListen";
            this.btn_startListen.Size = new System.Drawing.Size(75, 23);
            this.btn_startListen.TabIndex = 1;
            this.btn_startListen.Text = "开始监听";
            this.btn_startListen.UseVisualStyleBackColor = true;
            this.btn_startListen.Click += new System.EventHandler(this.btn_startListen_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(284, 24);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_endListen
            // 
            this.btn_endListen.Location = new System.Drawing.Point(154, 24);
            this.btn_endListen.Name = "btn_endListen";
            this.btn_endListen.Size = new System.Drawing.Size(75, 23);
            this.btn_endListen.TabIndex = 3;
            this.btn_endListen.Text = "结束监听";
            this.btn_endListen.UseVisualStyleBackColor = true;
            this.btn_endListen.Click += new System.EventHandler(this.btn_endListen_Click);
            // 
            // W_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 292);
            this.Controls.Add(this.btn_endListen);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_startListen);
            this.Controls.Add(this.lstBox_statu);
            this.Name = "W_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.W_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBox_statu;
        private System.Windows.Forms.Button btn_startListen;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_endListen;
    }
}

