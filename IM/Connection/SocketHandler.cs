// <copyright file="SocketHandler.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统客户端主界面</summary>
namespace IM.Connection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    /// <summary>
    /// A class about handling socket
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    static class SocketHandler
    {
        /// <summary>
        /// 关闭Socket
        /// </summary>
        /// <param name="socket">a socket will be shutdown</param>
        public static void ShutDownConn(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close(50);
            socket = null;
        } // ShutDownConn
    } // class
} // namespace
