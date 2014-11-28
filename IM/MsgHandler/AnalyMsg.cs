// <copyright file="AnalyMsg.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>分析收到的数据（基类）</summary>
namespace IM.MsgHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class to analysis msg
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class AnalyMsg
    {
        // 消息类型
        private string _type;

        // 发送消息者
        private string _srcUser;

        /// <summary>
        /// Gets or sets _type
        /// </summary>
        /// 
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets srcUser
        /// </summary>
        public string srcUser
        {
            get { return _srcUser; }
            set { _srcUser = value; }
        }

        /// <summary>
        /// Initializes type and srcUser
        /// </summary>
        /// <param name="recvMsg">a recivied string</param>
        public AnalyMsg(string recvMsg)
        {
           
            string[] s = recvMsg.Split('|');
            if (s.Length == 5)
            {
                type = s[0];
                srcUser = s[1];
            } // if
        } // AnalyMsg
    } // class
} // namespace
