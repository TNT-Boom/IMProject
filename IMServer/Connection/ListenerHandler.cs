// <copyright file="W_Main.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li ListenerHandler</author>
// <date> 2014-11-20 </date>
// <summary>处理Listener</summary>
namespace IMServer.Connection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    /// <summary>
    /// A class handling listener
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    static class ListenerHandler
    {
        /// <summary>
        /// 获取一个可用的Listener
        /// </summary>
        /// <returns></returns>
        public static TcpListener GetListener()
        {
            // 本地所有的IP
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
            int ip_index = 0;

            // 获取可用的IPV4
            foreach (IPAddress i in ip)
            {
                string strip = i.ToString();
                string[] temp = strip.Split('.');
                if (temp.Length == 4)
                    break;
                ip_index++; // 潜在bug
            } // foreach

            IPEndPoint localep = new IPEndPoint(ip[ip_index], 11000);//客户端也按这个规则，找到同一个IP
            TcpListener listener = new TcpListener(localep);

            return listener;
        } // GetListener
    } // class
} // namespace
