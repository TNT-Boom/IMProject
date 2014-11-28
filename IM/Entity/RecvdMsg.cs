// <copyright file="RecvdMsg.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>收到的消息</summary>
namespace IM.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class of recieved message (it will be contatined by MsgList.recvMsgList)
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class RecvdMsg
    {
        // 消息类型
        private string _type = "";

        // 发送者名字，为自己的时候证明收到的是 对方未在线信息
        private string _userName = "";

        // 发送者IP
        private string _srcIP = "";

        // 收消息的用户名，应是本地用户名
        private string _destName = "";

        // 发送的内容
        private string _content = ""; 

        /// <summary>
        /// Gets or sets _type
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets _userName
        /// </summary>
        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// Gets or sets _srcIP
        /// </summary>
        public string srcIP
        {
            get { return _srcIP; }
            set { _srcIP = value; }
        }

        /// <summary>
        /// Gets or sets _destName
        /// </summary>
        public string destName
        {
            get { return _destName; }
            set { _destName = value; }
        }

        /// <summary>
        /// Gets or sets _content
        /// </summary>
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
