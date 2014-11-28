namespace IM.UI
{
    partial class W_AddFrd
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
            this.cmBox_frdList = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmBox_frdList
            // 
            this.cmBox_frdList.FormattingEnabled = true;
            this.cmBox_frdList.Location = new System.Drawing.Point(33, 41);
            this.cmBox_frdList.Name = "cmBox_frdList";
            this.cmBox_frdList.Size = new System.Drawing.Size(121, 20);
            this.cmBox_frdList.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(193, 37);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // W_AddFrd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 90);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cmBox_frdList);
            this.Name = "W_AddFrd";
            this.Text = "W_AddFrd";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmBox_frdList;
        private System.Windows.Forms.Button btn_add;
    }
}