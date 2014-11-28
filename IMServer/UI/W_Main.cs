// <copyright file="W_Main.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统服务器主界面</summary>
namespace IMServer.UI
{
    using IMServer.Connection;
    using IMServer.Entity;
    using IMServer.MsgHandler;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;

    /// <summary>
    /// A Main class that control Mian Windows of server
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    public partial class W_Main : Form
    {
        // 追加文本的委托变量
        private DelegateMem.AppendDelegate appendString;

        //监听器
        private TcpListener listener;

        //指示是否已经启动了侦听
        bool IsStart = false;

        /// <summary>
        /// Initializes the window
        /// </summary>
        public W_Main()
        {
            InitializeComponent();
        } // W_Main

        /// <summary>
        /// 载入窗体
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void W_Main_Load(object sender, EventArgs e)
        {
            //实例化委托对象，绑定方法
            appendString = new DelegateMem.AppendDelegate(DelegateMethod.appendMethod);
        } // W_Main_Load

        /// <summary>
        /// 单击开始监听按钮
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_startListen_Click(object sender, EventArgs e)
        {
            //服务器已经其中监听，则返回
            if (IsStart)
                return;

            //启动侦听
            listener = ListenerHandler.GetListener();
            listener.Start(10);
            IsStart = true;
            lstBox_statu.Invoke(appendString, string.Format("服务器已经自动侦听！端点为{0}", 
                                                            listener.LocalEndpoint.ToString()), 
                                                            lstBox_statu);
            this.btn_startListen.Enabled = false;

            // 初始化要传入的数据
            AcceptCallBackParam acceptCallBackParam = new AcceptCallBackParam(listener, IsStart, lstBox_statu);

            AsyncCallback callBack = new AsyncCallback(CallBackFunc.acceptCallBack);
            listener.BeginAcceptSocket(callBack, acceptCallBackParam);  
        } // btn_startListen_Click

        /// <summary>
        /// 单击结束监听按钮
        /// </summary>
        /// <param name="sender">the sneder</param>
        /// <param name="e">the e</param>
        private void btn_endListen_Click(object sender, EventArgs e)
        {
            if (!IsStart)
                return;

            IsStart = false;
            listener.Stop();
            lstBox_statu.Invoke(appendString, "已结束服务器侦听", lstBox_statu);
            this.btn_startListen.Enabled = true;
        } // btn_endListen_Click

        /// <summary>
        /// 单击清空按钮
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.lstBox_statu.Items.Clear();
        } // btn_clear_Click
    } // class
} // namespace IMServer.UI
