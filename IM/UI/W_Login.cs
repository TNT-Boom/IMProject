// <copyright file="W_Login.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM登录界面</summary>
namespace IM.UI
{
    using IM.Entity;
    using IM.Connection;
    using IM.IMService;//引用的服务
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net.Sockets;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// A window to login
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    public partial class W_Login : Form
    {
        /// <summary>
        /// Initializes the login window
        /// </summary>
        public W_Login()
        {
            InitializeComponent();

        } // W_Login

        /// <summary>
        /// 单击登录按钮
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_logIn_Click(object sender, EventArgs e)
        {
            // 定义添加文本的委托变量
            DelegateMem.AppendDelegate appendString = new DelegateMem.AppendDelegate(DelegateMethod.appendMethod);

            // 获取当前用户的实例
            User currentUser = User.GetInstance();

            // 定义网络服务的一个实例
            IMSLogStateChangeClient logIM = new IMSLogStateChangeClient();

            string loginResault = logIM.changeLogState(txt_userName.Text, txt_userPwd.Text, false);

            if (loginResault == "1")
            {
                currentUser.userName = txt_userName.Text;

                #region 连接到服务器并接收消息
                if (currentUser.socket == null)
                {
                    currentUser.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                } // if
                if (!currentUser.socket.Connected)
                {
                    // 获得一个可用的IPV4地址
                    IPEndPoint remoteep = IPEndPointHandler.GetIPEndPoint();

                    AsyncCallback callBack = new AsyncCallback(CallBackFunc.connCallBack);
                    currentUser.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    currentUser.socket.BeginConnect(remoteep, callBack, currentUser);

                    Thread.Sleep(1000);

                    // Islogin 在 connCallBack中修改
                    if (currentUser.Islogin == true)
                    {
                        MessageBox.Show("登录成功");
                        this.DialogResult = DialogResult.OK;
                    } // if
                } // if
                #endregion
            } // if

            else if (loginResault == "0")
            {
                MessageBox.Show("已有账号登录");//在另一个客户端尝试登录的时候执行的到。
            } // else if

            else
            {
                MessageBox.Show("用户名或密码错误");
            } // else
        } // btn_logIn_Click

        /// <summary>
        /// 单击注册按钮
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_regist_Click(object sender, EventArgs e)
        {
            W_Regist regist = new W_Regist();
            regist.Show();
        } // btn_regist_Click
    } // class
} // namespace
