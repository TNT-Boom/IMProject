// <copyright file="Friends.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>在线用户列表 单例</summary>
namespace IMServer.Entity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class includes online users list
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class Friends
    {
        // 本类实例
        private static Friends instance;

        // 锁标志
        private static object _lock = new object();

        // 在线用户列表
        private ArrayList _friendList = new ArrayList();

        /// <summary>
        /// Initializes a null friends
        /// </summary>
        private Friends()
        {
        } // Friends

        /// <summary>
        /// 获取一个Friends实例
        /// </summary>
        /// <returns></returns>
        public static Friends GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Friends();
                    }
                } // lock
            } // if
            return instance;
        } // GetInstance

        /// <summary>
        /// Gets or sets _friendList
        /// </summary>
        public ArrayList friendList
        {
            get { return _friendList; }
            set { _friendList = value; }
        }
    } // class
} // namespace
