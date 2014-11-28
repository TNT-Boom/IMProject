// <copyright file="W_SingleChat.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统单聊界面</summary>
namespace IM.UI
{
    using IM.Connection;
    using IM.Entity;
    using IM.MsgHandler;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// A Main class that control W_SingleChat Windows of client
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    public partial class W_SingleChat : Form
    {
        // 当前用户名
        string userName;

        // 用来接受消息的缓存
        byte[] recvBuffer;

        // 发送出去的string
        string str_Send;

        // 接受消息的用户名
        string destName;

        // 用来遍历消息列表的变量
        Task pollMsgTask;

        // 取消task的标志
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        // 定义添加lstbox内容的方法，由于是异步，所以不在一个线程内，故需要用到委托
        DelegateMem.AppendDelegate appendString; 

       /// <summary>
        /// Initializes a single chat window
       /// </summary>
       /// <param name="userName">current userName</param>
       /// <param name="destName">destName who recieve message</param>
        public W_SingleChat(string userName, string destName)
        {
            InitializeComponent();

            this.userName = userName;
            this.destName = destName;
            this.lbl_userName.Text = destName;
        } // W_SingleChat

        /// <summary>
        /// 窗口载入之时
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void W_SingleChat_Load(object sender, EventArgs e)
        {
            appendString = new DelegateMem.AppendDelegate(DelegateMethod.appendMethod);

            // 从MsgList中轮询数据
            pollMsgTask = Task.Factory.StartNew(() => pollMsg(cancellationTokenSource.Token), cancellationTokenSource.Token);
        } // W_SingleChat_Load

       /// <summary>
        /// 从MsgList中找到有效的数据并且填入窗口
       /// </summary>
       /// <param name="cancellationToken">the symbol whether cancel task</param>
        private void pollMsg(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                MsgList msgList = MsgList.GetInstance();
                ArrayList indexList = new ArrayList();
                int i = 0;

                // 未读消息列表不为空时
                if (msgList.recvMsgList.Count != 0)
                {
                    foreach (RecvdMsg msg in msgList.recvMsgList)
                    {
                        if (msg.type == "offline" && msg.userName == userName && msg.destName == destName)
                        {
                            lstBox_recMsg.Invoke(appendString, lstBox_recMsg, msg.content);
                            indexList.Add(i);
                        } // if

                        if (msg.type == "client2client" && msg.userName == destName)
                        {
                            string finalStr = msg.userName + "发来:" + msg.content;
                            lstBox_recMsg.Invoke(appendString, lstBox_recMsg, finalStr);
                            indexList.Add(i);
                        } // if

                        i++;
                    } // foreach
                } // if

                // 删掉已经读取的消息
                foreach (int index in indexList)
                {
                    RecvdMsg msg = msgList.recvMsgList[index];
                    msgList.recvMsgList.Remove(msg);
                } // foreach
            } // while
        } // pollMsg

        /// <summary>
        /// 单击发送消息按钮
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_sendMsg_Click(object sender, EventArgs e)
        {
            User currentUser = User.GetInstance();

            if (txt_sendMsg.Text.Trim() == null)
            {
                lstBox_recMsg.Items.Add("不能发送空字符串");
                txt_sendMsg.Focus();
                return;
            } // if

            if (currentUser.socket == null)
            {
                lstBox_recMsg.Items.Add("尚未与服务器连接...");
                return;
            } // if

            if (!currentUser.socket.Connected)
            {
                lstBox_recMsg.Items.Add("尚未与服务器连接...");
                return;
            } // if

            str_Send = txt_sendMsg.Text;
            sendData();
        } // btn_sendMsg_Click


        /// <summary>
        /// 单聊通信
        /// </summary>
        private void sendData()
        {
            User currentUser = User.GetInstance();

            try
            {
                string finalStr = BuildMsg.buildSendMsg("client2client", userName, currentUser.socket.LocalEndPoint.ToString(), destName, str_Send);
                byte[] msg = Encoding.UTF8.GetBytes(finalStr);

                //始化需要传入的参数
                SendCallBackParam sendCallBackParam = new SendCallBackParam(
                                                          str_Send,
                                                          lstBox_recMsg,
                                                          appendString);
                // 定制并实例化回调方法
                AsyncCallback callBack = new AsyncCallback(CallBackFunc.sendCallBack);

                // 开始异步发送数据
                currentUser.socket.BeginSend(msg, 0, msg.Length, SocketFlags.None, callBack, sendCallBackParam);
            } // try
            catch (System.Exception ex)
            {
                SocketHandler.ShutDownConn(currentUser.socket);
                lstBox_recMsg.Invoke(appendString, lstBox_recMsg, "服务器断开了TCP连接");
            } // catch

        } // sendData

        /// <summary>
        /// 关闭窗口时
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void W_SingleChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        } // W_SingleChat_FormClosing
    } // class
} // namespace