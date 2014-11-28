// <copyright file="CallBackFunc.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>包含了所有用到的回调函数</summary>
namespace IMServer.Connection
{
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
    /// it contains all of call back functions
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
        /// 开始监听
        /// </summary>
        /// <param name="ar"></param>
        public static void acceptCallBack(IAsyncResult ar)
        {
            // 初始化需要用的委托
            Friends friends = Friends.GetInstance();
            DelegateMem.AppendDelegate appendString;
            appendString = new DelegateMem.AppendDelegate(DelegateMethod.appendMethod);

            try
            {
                // 初始化关键参数
                AcceptCallBackParam acceptCallBackParam = (AcceptCallBackParam)ar.AsyncState;
                TcpListener listener = acceptCallBackParam.listener;
                bool IsStart = acceptCallBackParam.IsStart;
                ListBox lstBox_statu = acceptCallBackParam.lstBox_statu;

                try
                {
                    //完成异步接受连接请求的异步调用
                    //将连接信息添加到列表和下拉列表
                    Socket clientSocket = listener.EndAcceptSocket(ar);
                    MyFriend frd = new MyFriend(clientSocket);

                    // 加入好友
                    lock (friends.friendList)
                    {
                        friends.friendList.Add(frd);
                    }

                    string connMsg = clientSocket.RemoteEndPoint.ToString() + "已连接...";
                    lstBox_statu.Invoke(appendString, connMsg, lstBox_statu);
                    AsyncCallback callBack;

                    if (IsStart)
                    {
                        callBack = new AsyncCallback(acceptCallBack);
                        listener.BeginAcceptSocket(callBack, acceptCallBackParam);
                    } // if

                    //开始在连接上进行异步的数据接收
                    frd.clearBuffer();

                    // 初始化要传入的参数
                    RecvCallBackParam recvCallBackParam = new RecvCallBackParam(
                                                              lstBox_statu,
                                                              frd,
                                                              appendString,
                                                              IsStart
                                                              );
                    callBack = new AsyncCallback(CallBackFunc.recvCallBack);
                    frd.socket.BeginReceive(frd.recvBuffer, 0, frd.recvBuffer.Length, SocketFlags.None, callBack, recvCallBackParam);
                } // try

                catch (System.Exception ex)
                {
                    IsStart = false;
                    acceptCallBackParam.IsStart = false;
                } // catch
            } // try

            catch (System.Exception ex)
            {
                // 终于封装了这个异常！！ 即调用stop只会关闭监听，但是仍然会执行这个函数，前面会转型失败.....跳转到这
            } // catch

        } // acceptCallBack

        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="ar"></param>
        public static void recvCallBack(IAsyncResult ar)
        {
            try
            {
                // 初始化关键参数
                RecvCallBackParam recvCallBackParam = (RecvCallBackParam)ar.AsyncState;
                ListBox lstBox_statu = recvCallBackParam.lstBox_statu;
                MyFriend frd = recvCallBackParam.frd;
                DelegateMem.AppendDelegate appendString = recvCallBackParam.appendString;
                bool IsStart = recvCallBackParam.IsStart;
                Friends friends = Friends.GetInstance();

                try
                {
                    int i = frd.socket.EndReceive(ar);
                    if (i == 0)
                    {
                        lock (friends)
                        {
                            friends.friendList.Remove(frd);
                        }
                        frd.Dispose();
                        return;
                    } // if

                    else
                    {
                        string strData = Encoding.UTF8.GetString(frd.recvBuffer, 0, i);

                        // 解析收到的数据
                        C2CAnayMsg c2cAnayMsg = new C2CAnayMsg(strData);
                        #region 登录
                        if (c2cAnayMsg.type == "login")
                        {
                            frd.userName = c2cAnayMsg.srcUser;
                        } // if-login
                        #endregion
                        #region 群聊
                        if (c2cAnayMsg.type == "group")
                        {
                            string finalData = string.Format("收到来自：{0}，发送给：{1} 的消息： {2}", c2cAnayMsg.srcUser, c2cAnayMsg.destName, c2cAnayMsg.content);
                            lstBox_statu.Invoke(appendString, finalData, lstBox_statu);
                            foreach (MyFriend destFrd in friends.friendList)
                            {
                                if (destFrd.userName != c2cAnayMsg.srcUser)
                                {
                                    string groupMsg = BuildMsg.buildSendMsg("group", c2cAnayMsg.srcUser, c2cAnayMsg.srcIP, c2cAnayMsg.destName, c2cAnayMsg.content);
                                    sendData(destFrd, groupMsg);
                                }
                            }
                        }
                        #endregion
                        #region 点对点聊天
                        if (c2cAnayMsg.type == "client2client")
                        {
                            string finalData = string.Format("收到来自：{0}，发送给：{1} 的消息： {2}", c2cAnayMsg.srcUser, c2cAnayMsg.destName, c2cAnayMsg.content);

                            lstBox_statu.Invoke(appendString, finalData, lstBox_statu);

                            // 寻找目的frd
                            int destUserIndex = 0;
                            for (destUserIndex = 0; destUserIndex < friends.friendList.Count; destUserIndex++)
                            {
                                MyFriend destFrd = (MyFriend)friends.friendList[destUserIndex];
                                if (destFrd.userName == c2cAnayMsg.destName)
                                {
                                    break;
                                }
                            } // for

                            if (destUserIndex == friends.friendList.Count)
                            {
                                // TODO 通知发送方，对方不在线
                                int srcUserIndex = 0;
                                for (srcUserIndex = 0; srcUserIndex < friends.friendList.Count; srcUserIndex++)
                                {
                                    MyFriend destFrd = (MyFriend)friends.friendList[srcUserIndex];
                                    if (destFrd.userName == c2cAnayMsg.srcUser)
                                    {
                                        break;
                                    }
                                } // for

                                // 这种情况，客户端收到后，srcUser是自己的名字，而destName不是自己的名字
                                string offlineMsg = BuildMsg.buildSendMsg("offline", c2cAnayMsg.srcUser, c2cAnayMsg.srcIP, c2cAnayMsg.destName, "对方未在线");
                                sendData((MyFriend)friends.friendList[srcUserIndex], offlineMsg);
                            } // if

                            else
                            {
                                // 转发出去 这种情况，转发给另外一个用户，src是发送者的名字，destName是自己的名字
                                string onlineMsg = BuildMsg.buildSendMsg("client2client", c2cAnayMsg.srcUser, c2cAnayMsg.srcIP, c2cAnayMsg.destName, c2cAnayMsg.content);
                                sendData((MyFriend)friends.friendList[destUserIndex], onlineMsg);
                            } // else

                        } // if-lient2client
                        #endregion
                        #region 退出
                        if (c2cAnayMsg.type == "logout")
                        {
                            //  TDO 已处理
                            string quitMsg = frd.userName + "(" + frd.socket.LocalEndPoint + ")断开了连接";
                            lstBox_statu.Invoke(appendString, quitMsg, lstBox_statu);
                            lock (friends)
                            {
                                friends.friendList.Remove(frd);
                            }
                            frd.Dispose();
                        } // if
                        #endregion
                        #region 添加好友
                        if (c2cAnayMsg.type == "addfrd")
                        {
                            int destUserIndex = 0;
                            for (destUserIndex = 0; destUserIndex < friends.friendList.Count; destUserIndex++)
                            {
                                MyFriend destFrd = (MyFriend)friends.friendList[destUserIndex];
                                if (destFrd.userName == c2cAnayMsg.destName)
                                {
                                    break;
                                } // if
                            } // for

                            // 被添加的用户肯定存在
                            string onlineMsg = BuildMsg.buildSendMsg("addfrd", c2cAnayMsg.srcUser, c2cAnayMsg.srcIP, c2cAnayMsg.destName, c2cAnayMsg.content);
                            sendData((MyFriend)friends.friendList[destUserIndex], onlineMsg);
                        }
                        #endregion
                        frd.clearBuffer();
                        AsyncCallback callBack = new AsyncCallback(recvCallBack);
                        frd.socket.BeginReceive(frd.recvBuffer, 0, frd.recvBuffer.Length, SocketFlags.None, callBack, recvCallBackParam);
                    } // else
                } // try

                catch (System.Exception ex)
                {
                    lock (friends)
                    {
                        friends.friendList.Remove(frd);
                    }
                    frd.Dispose();

                } // catch
            } // try

            catch (System.Exception ex)
            {

            } // cath

        } // recvCallBack

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="frd"></param>
        /// <param name="strData"></param>
        private static void sendData(MyFriend frd, string strData)
        {
            // 获取在线用户列表的实例
            Friends friends = Friends.GetInstance();

            try
            {
                byte[] msg = Encoding.UTF8.GetBytes(strData);

                //初始化相关参数
                SendCallBackParam sendCallBackParam = new SendCallBackParam(frd);

                //异步调用
                AsyncCallback callBack = new AsyncCallback(CallBackFunc.sendCallBack);
                frd.socket.BeginSend(msg, 0, msg.Length, SocketFlags.None, callBack, sendCallBackParam);
            } // try

            catch (System.Exception ex)
            {
                lock (friends)
                {
                    friends.friendList.Remove(frd);
                }
                frd.Dispose();
            } // catch
        } // sendData

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="ar"></param>
        public static void sendCallBack(IAsyncResult ar)
        {
            // 初始化关键参数
            Friends friends = Friends.GetInstance();
            SendCallBackParam sendCallBackParam = (SendCallBackParam)ar.AsyncState;
            MyFriend frd = sendCallBackParam.frd;

            try
            {
                frd.socket.EndSend(ar);
            } // try

            catch (System.Exception ex)
            {
                lock (friends)
                {
                    friends.friendList.Remove(frd);
                }
                frd.Dispose();
            } // catch
        } // sendCallBac
    } // class
} // namespace IMServer.Connection
