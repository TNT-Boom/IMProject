// <copyright file="UIHandler.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>IM系统客户端主界面</summary>
namespace IM.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// A class to handle something about UI
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
   static class UIHandler
    {
        /// <summary>
        /// 根据用户名添加一个拥有单击事件的按钮
        /// </summary>
        /// <param name="pnl">panel that will contain many buttons</param>
        /// <param name="userName">current user name</param>
        public static void AddButton(string userName,Panel pnl,string userList)
        {
            // 统计按钮个数
            int i = 0;

            // 好友用户名
            string[] userArry = userList.Split('|');

            foreach (string s in userArry)
            {
                if (s != "")
                {
                    Button btn = new Button();
                    btn.Top = i * 30;
                    btn.Width = pnl.Width;
                    btn.Text = s;

                    btn.Click += new EventHandler((Object obj, EventArgs e) =>
                    {
                        Button btn_temp = (Button)obj;
                        W_SingleChat w_singleChat = new W_SingleChat(userName, btn_temp.Text);
                        w_singleChat.Show();
                    });
                    pnl.Controls.Add(btn);

                    i++;
                } // if
            } // foreach
        } // AddButton
    } // class
} // namespace
