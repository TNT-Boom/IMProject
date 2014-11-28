// <copyright file="DelegateMethod.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统客户端主界面</summary>
namespace IM.Connection
{
    using IM.Entity;
    using IM.IMService;
    using IM.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// A class contains all delegate method
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
   static  class DelegateMethod
    {
       /// <summary>
       /// 追加文本信息
       /// </summary>
       /// <param name="lstBox_recMsg">a ListBox</param>
       /// <param name="str">a string will be appended</param>
       public static void appendMethod(ListBox lstBox_recMsg, string str)
       {
           lstBox_recMsg.Items.Add(str);
       } // appendMethod

       /// <summary>
       /// 初始化用户好友列表
       /// </summary>
       /// <param name="pnl">a panel will contains many buttons</param>
       public static void iniFrdListMethod(Panel pnl)
       {
           pnl.Controls.Clear();

           // 获取新用户列表 
           // 引用的网络服务（本地）
           IMSLogStateChangeClient getUserList = new IMSLogStateChangeClient(); 

           // 获取用户实例
           User currentUser = User.GetInstance();
           string  userList = getUserList.getFrdList(currentUser.userName);

           //根据用户列表添加按钮
          UIHandler.AddButton(currentUser.userName, pnl, userList);
       } // iniFrdListMethod

       /// <summary>
       /// 重设Label的文本信息
       /// </summary>
       /// <param name="str">a string will be bind to label</param>
       /// <param name="lbl">a label what's text will be reset</param>
       public static void resetTextMethod(string str, Label lbl)
       {
           lbl.Text = str;
       } // resetTextMethod
    } // class
} // namespace
