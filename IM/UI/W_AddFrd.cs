// <copyright file="W_AddFrd.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统客户端主界面</summary>
namespace IM.UI
{
    using IM.Connection;
    using IM.Entity;
    using IM.IMService;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.Net.Sockets;


    /// <summary>
    /// A window of add online friend
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    public partial class W_AddFrd : Form
    {
        // 实例化网络服务
        IMSLogStateChangeClient addFrd = new IMSLogStateChangeClient();

        // 当前用户名
        string userName = string.Empty;

        /// <summary>
        /// Initializes a window to add online friend
        /// </summary>
        /// <param name="userName">current user name</param>
        public W_AddFrd(string userName)
        {
            InitializeComponent();

            this.userName = userName;

            // 调用网络服务获取在线列表
            string frdList = addFrd.getOnlineList();
            string[] frdArray = frdList.Split('|');

            foreach (string s in frdArray)
            { 
                cmBox_frdList.Items.Add(s);
            } // foreach
        } // W_AddFrd

        /// <summary>
        /// 单击添加按钮
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            // 将要被添加的用户名
            string destName = cmBox_frdList.SelectedItem.ToString();

            // 调用网络服务添加好友
            addFrd.addFrd(userName, destName);

            Thread.Sleep(500);

            User currentUser = User.GetInstance();
            CallBackFunc.noChatSendData("addfrd", userName, destName,currentUser.socket);
            
            this.DialogResult = DialogResult.OK;
        } // btn_add_Click
    }
}
