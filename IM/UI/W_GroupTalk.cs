// <copyright file="W_GroupTalk.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统群聊界面</summary>
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
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    /// <summary>
    /// A windows provding group talking
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    public partial class W_GroupTalk : Form
    {
        // 当前用户名
        string userName;

        // 用于接受消息的缓冲槽
        byte[] recvBuffer;

        // 用于发送的文本信息
        string str_Send;

        // 接受消息的用户名,群聊状态下为all
        string destName;

        // 用于遍历消息的task变量
        Task pollMsgTask;

        // 是否取消task的标志
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        // 定义添加lstbox内容的方法，由于是异步，所以不在一个线程内，故需要用到委托
        DelegateMem.AppendDelegate appendString;

        /// <summary>
        /// Initializes group talk window with userName 
        /// </summary>
        /// <param name="userName">current user name</param>
        public W_GroupTalk(string userName)
        {
            InitializeComponent();

            this.userName = userName;
            this.lbl_userName.Text = "群聊天中";
            this.destName = "all";
        } // W_GroupTalk

        /// <summary>
        /// 窗口载入时
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void GroupTalk_Load(object sender, EventArgs e)
        {
            appendString = new DelegateMem.AppendDelegate(DelegateMethod.appendMethod);

            // 开始遍历消息列表
            pollMsgTask = Task.Factory.StartNew(() => pollMsg(cancellationTokenSource.Token), cancellationTokenSource.Token);
        } // GroupTalk_Load

        /// <summary>
        /// 从MsgList中找到有效的数据并且填入窗口
        /// </summary>
        /// <param name="cancellationToken">a symbol of whether canceling task</param>
        private void pollMsg(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                MsgList msgList = MsgList.GetInstance();

                // 已提取到的消息的下标
                ArrayList indexList = new ArrayList();
                int i = 0;

                if (msgList.recvMsgList.Count != 0)
                {
                    foreach (RecvdMsg msg in msgList.recvMsgList)
                    {
                        if (msg.type == "group" && msg.destName == "all")
                        {
                            string finalStr = msg.userName + "发来:" + msg.content;
                            lstBox_recMsg.Invoke(appendString, lstBox_recMsg, finalStr);
                            indexList.Add(i); // 下标索引
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
        /// 群聊通信
        /// </summary>
        private void sendData()
        {
            User currentUser = User.GetInstance();

            try
            {
                string finalStr = BuildMsg.buildSendMsg("group", userName, currentUser.socket.LocalEndPoint.ToString(), destName, str_Send);
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
    } // class
} // namespace
