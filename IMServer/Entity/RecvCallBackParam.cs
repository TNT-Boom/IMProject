// <copyright file="RecvCallBackParam.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>接受信息回调函数的参数</summary>
namespace IMServer.Entity
{
    using IMServer.Connection;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// 接受信息回调函数的参数类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class RecvCallBackParam
    {
        /// <summary>
        /// Gets or sets lstBox_statu
        /// </summary>
        public ListBox lstBox_statu { set; get; }

        /// <summary>
        /// Gets or sets frd
        /// </summary>
        public MyFriend frd { set; get; }

        /// <summary>
        /// Gets or sets IsStart
        /// </summary>
        public bool IsStart { set; get; }

        /// <summary>
        /// Gets or sets appendString
        /// </summary>
        public DelegateMem.AppendDelegate appendString { set; get; }

        /// <summary>
        /// Initializes RecvCallBackParam
        /// </summary>
        /// <param name="lstBox_statu">a listbox that show information</param>
        /// <param name="frd">a online user</param>
        /// <param name="appendString">append string to listbox</param>
        /// <param name="IsStart">whether start listening</param>
        public RecvCallBackParam(ListBox lstBox_statu, MyFriend frd,
                DelegateMem.AppendDelegate appendString, bool IsStart)
        {
            this.lstBox_statu = lstBox_statu;
            this.frd = frd;
            this.appendString = appendString;
            this.IsStart = IsStart;
        } // RecvCallBackParam
    } // class
} // namespace
