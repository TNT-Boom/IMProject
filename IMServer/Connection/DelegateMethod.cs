// <copyright file="DelegateMethod.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>委托方法</summary>
namespace IMServer.Connection
{
    using IMServer.Entity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// all delegate methods are here
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    static class  DelegateMethod
    {
        /// <summary>
        ///  //委托方法 添加字符串 在列表中写字符串的委托方法
        /// </summary>
        /// <param name="str">string will be appended</param>
        /// <param name="lstBox_statu">it's text will be apened by string</param>
        public static void appendMethod(string str, ListBox lstBox_statu)
        {
            lstBox_statu.Items.Add(str);
            lstBox_statu.SelectedIndex = lstBox_statu.Items.Count - 1;
            lstBox_statu.ClearSelected();//清除选中状态
        } // appendMethod
    } // class
} // namespace
