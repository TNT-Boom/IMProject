// <copyright file="MsgList.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>消息列表类</summary>
namespace IM.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class to store recieved message 单例
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class MsgList
    {
        // 静态的本类实例
        private static MsgList instance;

        // 存储收到的未读的消息
        private List<RecvdMsg> _recvMsgList = new List<RecvdMsg>();

        // 锁标志
        private static object _lock = new object();

        /// <summary>
        /// Initializes a null MsgList 
        /// </summary>
        private MsgList()
        {
        } // MsgList

        /// <summary>
        /// 获取该类的一个实例
        /// </summary>
        /// <returns></returns>
        public static MsgList GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new MsgList();
                    }
                } // lock
            } // if

            return instance;
        } // GetInstance

        /// <summary>
        /// Gets or sets recvMsgList
        /// </summary>
        public List<RecvdMsg> recvMsgList
        {
            get { return _recvMsgList; }
            set { _recvMsgList = value; }
        }
    } // class
} // namespace


