// <copyright file="W_Main.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统客户端主界面</summary>
namespace IM.UI
{
    using IM.IMService;//应用网络服务
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
    /// A Main class that control Mian Windows of client
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    public partial class W_Main : Form
    {
        // 当前用户名
        string userName = "";

        // 当前用户密码
        string userPwd = ""; 

        // 用户列表字符串，需要解析
        string userList = "";

        // 未读消息用户列表
        string unReadMsg = "";

        // 初始化用户按钮
        DelegateMem.IniFrdList iniFrdList;

        // 重置label类型控件的文本
        DelegateMem.ResetText reset;

        // 查询是否有新好友加入
        Task findAddMsgTask;

        // Task下申请取消多线程的标志
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(); 
         
        /// <summary>
        /// Initializes a new instance of the W_Main class
        /// </summary>
        /// <param name="userName">current userName</param>
        /// <param name="userPwd">password of currentUser</param>
        public W_Main(string userName, string userPwd)
        {
            InitializeComponent();

            this.userName = userName;
            this.userPwd = userPwd;
            lbl_userName.Text = userName; 

            IMSLogStateChangeClient getUserList = new IMSLogStateChangeClient();

            userList = getUserList.getFrdList(userName);
            //根据用户列表添加按钮
            UIHandler.AddButton(userName, pnl_userList, userList);
        } // W_Main

        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void W_Main_Load(object sender, EventArgs e)
        {
            User currentUser = User.GetInstance();
            byte[] recvBuffer = new byte[currentUser.socket.SendBufferSize];
            AsyncCallback callBack = new AsyncCallback(CallBackFunc.recCallBack);

            // 开始从客户端异步接受数据
            currentUser.socket.BeginReceive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, callBack, recvBuffer);

            // 给服务器响应的空隙
            Thread.Sleep(1000);

            // 每20秒查询一下是否有新好友加入
            iniFrdList = new DelegateMem.IniFrdList(DelegateMethod.iniFrdListMethod);
            reset = new DelegateMem.ResetText(DelegateMethod.resetTextMethod);
            findAddMsgTask = Task.Factory.StartNew(
                             () => findAddMsg(cancellationTokenSource.Token),
                             cancellationTokenSource.Token);
        } // W_Main_Load

        /// <summary>
        /// 遍历消息列表，每20秒查询一下是否有新好友加入
        /// </summary>
        /// <param name="cancellationToken">the sing of cancel task</param>
        private void findAddMsg(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // 发现未读消息
                Thread.Sleep(1000);
                MsgList msgList = MsgList.GetInstance();
                ArrayList indexList = new ArrayList();
                int i = 0;
                unReadMsg = "";
                lbl_unRdMsg.Invoke(reset, "", lbl_unRdMsg);
                if (msgList.recvMsgList.Count != 0)
                {
                    foreach (RecvdMsg msg in msgList.recvMsgList)
                    {
                        if (msg.type == "addfrd")
                        {
                            pnl_userList.Invoke(iniFrdList, pnl_userList);
                            indexList.Add(i);
                        } // if

                        // 查看是否有未读消息
                        if (msg.type == "client2client")
                        {
                            unReadMsg += msg.userName+",";
                        }
                        i++;
                    } // foreach
                } // if

                unReadMsg.TrimEnd(',');
                if (unReadMsg != "")
                {
                    unReadMsg += "的消息未读";
                    lbl_unRdMsg.Invoke(reset, unReadMsg, lbl_unRdMsg);
                } // if
                
                // 删掉已经读取的消息
                foreach (int index in indexList)
                {
                    RecvdMsg msg = msgList.recvMsgList[index];
                    msgList.recvMsgList.Remove(msg);
                }
            } // while
        } // findAddMsg

        /// <summary>
        /// 单击退出按钮
        /// </summary>
        /// <param name="sender"> the sender</param>
        /// <param name="e"> the e</param>
        private void btn_exit_Click(object sender, EventArgs e)
        {
            IMSLogStateChangeClient IsLog = new IMSLogStateChangeClient();
            string loginResault = IsLog.changeLogState(userName, userPwd, true);
            User currentUser = User.GetInstance();

            try
            {
                if (loginResault == "1")
                {
                    // 断开连接
                    if (currentUser.socket == null)
                        return;
                    if (!currentUser.socket.Connected)
                        return;
                    CallBackFunc.noChatSendData("logout",userName,"",currentUser.socket);
                    Thread.Sleep(2000);
                    SocketHandler.ShutDownConn(currentUser.socket);
                    MessageBox.Show("成功退出");
                    Application.Exit();
                } // if
                else if (loginResault == "0")
                {
                    MessageBox.Show("未登录，无法退出");
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                } // else
            } // try
            catch (System.Exception ex)
            {
                // the last client will be wrong when exit
                Application.Exit();
            }
        } // btn_exit_Click

        /// <summary>
        /// 单击群聊
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_group_Click(object sender, EventArgs e)
        {
            W_GroupTalk w_singleChat = new W_GroupTalk(userName);
            w_singleChat.Show();
        } // btn_group_Click

        /// <summary>
        /// 单击添加好友
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void btn_addFrd_Click(object sender, EventArgs e)
        {
            W_AddFrd addFrd = new W_AddFrd(userName);

            if (addFrd.ShowDialog() == DialogResult.OK)
            {
                // 刷新好友列表
                pnl_userList.Controls.Clear();
                IMSLogStateChangeClient getUserList = new IMSLogStateChangeClient(); // 引用的网络服务（本地）
                userList = getUserList.getFrdList(userName);
                UIHandler.AddButton(userName, pnl_userList, userList);
            } // if
        } // btn_addFrd_Click

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the e</param>
        private void W_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            cancellationTokenSource.Cancel();
        } // W_Main_FormClosed
    } // class
} // namespace
