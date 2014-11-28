// <copyright file="IIMSLogStateChange.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-14 </date>
// <summary>网络服务接口</summary>
namespace IMService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IIMSLogStateChange”。
    /// <summary>
    /// access sql server2005
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-14
    /// 版本：1.0</c>
    /// </remarks>
    [ServiceContract]
    public interface IIMSLogStateChange
    {
        // 改变登录状态：登录或退出
        [OperationContract]
        string changeLogState(string userName, string Pwd, bool logState);

        // 获取好友列表
        [OperationContract]
        string getFrdList(string userName);

        // 注册用户
        [OperationContract]
        string registUser(string userName, string pwd, string sex, string age);

        // 获取在线用户列表
        [OperationContract]
        string getOnlineList();

        // 添加好友
        [OperationContract]
        string addFrd(string userName, string destName);
    } // interface
} // namespace
