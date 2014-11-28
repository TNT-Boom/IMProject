// <copyright file="W_Regist.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统注册界面</summary>
namespace IM.UI
{
    using IM.IMService;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// A Main class that control Regist Windows of client
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    public partial class W_Regist : Form
    {
        /// <summary>
        /// Initializes a regist window
        /// </summary>
        public W_Regist()
        {
            InitializeComponent();
        } // W_Regist

        /// <summary>
        /// 确认注册
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e"> the e</param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            // 未做其他验证
            IMSLogStateChangeClient registService = new IMSLogStateChangeClient();
            string registFlag = string.Empty; // 1 成功 0 存在相同用户名 -1 其他失败原因

            if (txtBox_pwd.Text == txtBox_rePwd.Text)
            {
                registFlag = registService.registUser(txtBox_userName.Text,
                                                      txtBox_pwd.Text,
                                                      txtBox_Sex.Text,
                                                      txtBox_age.Text);
                if (registFlag == "1")
                {
                    MessageBox.Show("注册成功！");
                    this.Hide();
                }
                else if (registFlag == "0")
                {
                    MessageBox.Show("已存在相同的用户名!");
                }
                else
                {
                    MessageBox.Show("注册失败，请稍后重试!");
                }
            } // if
            else 
            {
                MessageBox.Show("两次输入的密码不一致");
            } // else

           
        } // btn_ok_Click

        /// <summary>
        /// 返回，取消注册
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Hide();
        } // btn_return_Click
    } // class
} // namespace
