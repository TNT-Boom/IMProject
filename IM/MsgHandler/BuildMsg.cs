// <copyright file="W_Main.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>构建发送数据格式</summary>
namespace IM.MsgHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// build message
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    static class BuildMsg
    {
        /// <summary>
        /// 根据参数构建符合格式的消息字符串
        /// </summary>
        /// <param name="type">a type</param>
        /// <param name="userName">who send msg</param>
        /// <param name="srctIP">IP of who send msg</param>
        /// <param name="destName">who recieves msg</param>
        /// <param name="content">content</param>
        /// <returns></returns>
        public static string buildSendMsg(string type, string userName, string srctIP, string destName, string content)
        {
            return type + "|" +
                   userName + "|" +
                   srctIP + "|" +
                   destName + "|" +
                   content;
        } // buildSendMsg
    } // class
} // namespace
