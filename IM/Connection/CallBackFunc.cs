// <copyright file="CallBackFunc.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统客户端主界面</summary>
namespace IM.Connection
{
    using IM.Entity;
    using IM.MsgHandler;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// A class contain all call back functions  and a function noChatSendData
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class CallBackFunc
    {
        /// <summary>
        /// 回调函数：接受消息
        /// </summary>
        /// <param name="ar">the ar</param>
        public static void recCallBack(IAsyncResult ar)
        {
            try
            {
                // 接受消息的缓冲槽
                byte[] recvBuffer = (byte[])ar.AsyncState;

                // 当前用户的实例
                User currentUser = User.GetInstance();

                // 接受到的每一条消息
                RecvdMsg recvMsg = new RecvdMsg();

                // 消息列表实例
                MsgList msgList = MsgList.GetInstance();

                try
                {
                    int i = currentUser.socket.EndReceive(ar);
                    string str_data = Encoding.UTF8.GetString(recvBuffer, 0, i);

                   // 解析数据
                    C2CAnayMsg c2cAnayMsg = new C2CAnayMsg(str_data);

                    // 初始化收到信息类
                    recvMsg.type = c2cAnayMsg.type;
                    recvMsg.userName = c2cAnayMsg.srcUser;
                    recvMsg.srcIP = c2cAnayMsg.srcIP;
                    recvMsg.destName = c2cAnayMsg.destName;
                    recvMsg.content = c2cAnayMsg.content;

                    if (recvMsg.type != null)
                    {
                        msgList.recvMsgList.Add(recvMsg);
                    } // if

                    recvBuffer = new byte[currentUser.socket.SendBufferSize];

                    //循环接收
                    AsyncCallback callBack = new AsyncCallback(recCallBack);

                    //异步调用
                    currentUser.socket.BeginReceive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, callBack, recvBuffer);//开始从连接的Socket中接收数据
                } // try

                catch (System.Exception ex)
                {
                    if (currentUser.socket != null)
                    {
                        SocketHandler.ShutDownConn(currentUser.socket);
                    } // if
                } /// catch
            } // try

            catch (System.Exception ex)
            {
                // 封装客户端停止连接时的异常	
            } // catch
           
        } // recCallBack

        /// <summary>
        /// 回调函数发:送数据
        /// </summary>
        /// <param name="ar">the ar</param>
        public static void sendCallBack(IAsyncResult ar)
        {
            // 当前用户实例
            User currentUser = User.GetInstance();

            SendCallBackParam sendCallBackParam = (SendCallBackParam)ar.AsyncState;
            ListBox lstBox_recMsg = sendCallBackParam.lstBox_recMsg;
            string strSend = sendCallBackParam.strSend;
            DelegateMem.AppendDelegate appendString = sendCallBackParam.appendString;

            try
            {
                //异步通信 结束数据的异步发送
                currentUser.socket.EndSend(ar);

                strSend = "发：" + strSend;

                // 在右侧显示
                string showStr = strSend.PadLeft(lstBox_recMsg.Width / 10, ' ');
                lstBox_recMsg.Invoke(appendString, lstBox_recMsg, showStr);
            } // try

            catch (System.Exception ex)
            {
                SocketHandler.ShutDownConn(currentUser.socket);
                lstBox_recMsg.Invoke(appendString, lstBox_recMsg, "服务器断开了TCP连接");
            } // catch
        } // sendCallBack

        /// <summary>
        /// 回调函数:连接服务器
        /// </summary>
        /// <param name="ar"></param>
        public static void connCallBack(IAsyncResult ar)
        {
            // 当前用户的实例
            User currentUser = User.GetInstance();

            try
            {
                currentUser.socket.EndConnect(ar);

                //连接后将自己的userNae发送至服务器
                noChatSendData("login",currentUser.userName, "", currentUser.socket);
                currentUser.Islogin = true;
            } // try

            catch (System.Exception ex)
            {
                MessageBox.Show("登录失败");
                currentUser.Islogin = false;
            } // catch
        } // connCallBack

        /// <summary>
        /// 回调函数：非群聊与单聊消息的发送
        /// </summary>
        /// <param name="ar">the ar</param>
        public static void NoChatSendCb(IAsyncResult ar)
        {
            Socket soc_Client = (Socket)ar.AsyncState;
            soc_Client.EndSend(ar);
        } // NoChatSendCb

        /// <summary>
        /// 发送非聊天信息
        /// </summary>
        /// <param name="userName">current user name</param>
        public static void noChatSendData(string type, string userName, string destNamem, Socket soc_Client)
        {

            string str_Send = BuildMsg.buildSendMsg(type, userName, soc_Client.LocalEndPoint.ToString(), destNamem, "");
            byte[] msg = Encoding.UTF8.GetBytes(str_Send);

            // 定制并实例化回调方法
            AsyncCallback callBack = new AsyncCallback(NoChatSendCb);

            // 开始异步发送数据
            soc_Client.BeginSend(msg, 0, msg.Length, SocketFlags.None, callBack, soc_Client);
        } // noChatSendData
    } // class
} // namespace
