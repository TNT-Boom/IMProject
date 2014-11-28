// <copyright file="IPEndPointHandler.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统客户端主界面</summary>
namespace IM.Connection
{
    using System.Net;
    using System.Net.Sockets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class about handling IP
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    static class IPEndPointHandler
    {
        /// <summary>
        /// 获取一个可用的IPV4
        /// </summary>
        /// <returns></returns>
        public static IPEndPoint GetIPEndPoint()
        {
            // 获取本机所有IP
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
            int ip_index = 0;

            foreach (IPAddress i in ip)
            {
                string strip = i.ToString();
                string[] temp = strip.Split('.');

                if (temp.Length == 4)
                    break;

                ip_index++;
            } // foreach

            IPEndPoint remoteep = new IPEndPoint(ip[ip_index], 11000);

            return remoteep;
        } // GetIPEndPoint
    } // class
} // namespace
