// <copyright file="SendCallBackParam.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>发送回调函数的参数</summary>
namespace IM.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// A class that store information about send call back function
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
        /// Gets or sets strSend
        /// </summary>
        public string strSend { get; set; }

        /// <summary>
        /// Gets or sets lstBox_recMsg
        /// </summary>
        public ListBox lstBox_recMsg { get; set; }

        /// <summary>
        /// Gets or sets appendString
        /// </summary>
        public DelegateMem.AppendDelegate appendString { get; set; }

        /// <summary>
        /// Initializes SendCallBackParam
        /// </summary>
        /// <param name="strSend">message that will be send</param>
        /// <param name="lstBox_recMsg">chat window's listbox that show what be sended</param>
        /// <param name="appendString">a delegate member to append string</param>
        public SendCallBackParam(string strSend, ListBox lstBox_recMsg, DelegateMem.AppendDelegate appendString)
        {
            this.strSend = strSend;
            this.lstBox_recMsg = lstBox_recMsg;
            this.appendString = appendString;
        } // SendCallBackParam
    } // class
} // namespace
