// <copyright file="AcceptCallBackParam.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>接受回调函数 中需要的函数</summary>
namespace IMServer.Entity
{
    using IMServer.Connection;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// A accept call back param
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class AcceptCallBackParam
    {
        /// <summary>
        /// Gets or sets listener
        /// </summary>
        public TcpListener listener { set; get; }

        /// <summary>
        /// Gets or sets IsStart
        /// </summary>
        public bool IsStart { set; get; }

        /// <summary>
        /// Gets or sets lstBox_statu
        /// </summary>
        public ListBox lstBox_statu { set; get; }

        /// <summary>
        /// Initializes AcceptCallBackParam
        /// </summary>
        /// <param name="listener">server's listener</param>
        /// <param name="IsStart">is start to listen</param>
        /// <param name="lstBox_statu">listbox to show information</param>
        public AcceptCallBackParam(TcpListener listener,bool IsStart, ListBox lstBox_statu)
        {
            this.listener = listener;
            this.IsStart = IsStart;
            this.lstBox_statu = lstBox_statu;
        } // AcceptCallBackParam
    } // class
} // namespace

