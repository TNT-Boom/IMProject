// <copyright file="MyFriend.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>在线用户类</summary>
namespace IMServer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    /// a online user
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class MyFriend
    {
        // 用户的用户名
        public string userName="";

        // 用户的Socket
        public Socket socket;

        // 接受消息的缓冲槽
        public byte[] recvBuffer;

        /// <summary>
        /// Initializes a online user
        /// </summary>
        /// <param name="s">accecpted socket</param>
        public MyFriend(Socket s)
        {
            socket = s;
        } // MyFriend

        /// <summary>
        /// 清空接受缓存，在每一次新的接收之前都需要调用该方法
        /// </summary>
        public void clearBuffer()
        {
            recvBuffer = new byte[1024];
        } // clearBuffer

        /// <summary>
        /// 释放一个在线用户
        /// </summary>
        public void Dispose()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            } //try

            catch (System.Exception ex)
            {
            	
            } // catch

            finally
            {
                socket = null;
                recvBuffer = null;
            } // finally
        } // Dispose
    } // class
} // namespace
