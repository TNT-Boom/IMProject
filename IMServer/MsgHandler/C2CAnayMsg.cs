// <copyright file="C2CAnayMsg.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>分析收到的数据</summary>
namespace IMServer.MsgHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Analysis msg
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class C2CAnayMsg : AnalyMsg
    {
        // 收消息的用户名
        private string _destName;

        // 发送者IP
        private string _srcIP;

        // 发送或接受的内容
        private string _content;

        /// <summary>
        /// Initializes this
        /// </summary>
        /// <param name="recvStr">a recieved string</param>
        public C2CAnayMsg(string recvStr)
            : base(recvStr)
        {
            string[] s_temp = recvStr.Split('|');
            if (s_temp.Length == 5)
            {
                srcIP = s_temp[2];
                destName = s_temp[3];
                content = s_temp[4];
            } // if
        } // C2CAnayMsg

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
        /// </summary
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// Gets or sets _srcIP
        /// </summary>
        public string srcIP
        {
            get { return _srcIP; }
            set { _srcIP = value; }
        }
    } // class
} // namespace
