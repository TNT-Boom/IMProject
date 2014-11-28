// <copyright file="SendCallBackParam.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>发送信息回调函数的参数</summary>
namespace IMServer.Entity
{
    using System.Net;
    using System.Net.Sockets;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// 发送信息回调函数的参数类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class SendCallBackParam
    {
        /// <summary>
        /// Gets or sets frd
        /// </summary>
        public MyFriend frd { get; set; }

        /// <summary>
        /// Initializes RecvCallBackParam
        /// </summary>
        /// <param name="frd">online user</param>
        public SendCallBackParam(MyFriend frd)
        {
            this.frd = frd;
        } // SendCallBackParam
    } // class
} // namespace
