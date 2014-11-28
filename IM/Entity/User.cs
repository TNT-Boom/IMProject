// <copyright file="User.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>当前用户类</summary>
namespace IM.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    /// A class about current user information 单例
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    class User
    {
        // 当前用户名
        private string _userName = "";

        // 当前客户端的Socket
        private Socket _socket = null;

        // 静态用户实例
        private static User instance;

        // 锁标志
        private static object _lock = new object();

        // 是否登录标志
        private bool _Islogin = false;

        /// <summary>
        /// Initializes null User
        /// </summary>
        private User()
        {
        } // User

        /// <summary>
        /// 获得用户实例
        /// </summary>
        /// <returns></returns>
        public static User GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new User();
                    }
                } // lock
            } // if

            return instance;
        } // GetInstance

        /// <summary>
        /// Gets or sets _socket
        /// </summary>
        public Socket socket
        {
            get { return _socket; }
            set { _socket = value; }
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
        /// Gets or sets _Islogin
        /// </summary>
        public bool Islogin
        {
            get { return _Islogin; }
            set { _Islogin = value; }
        }
    } // class
} // namespace
