// <copyright file="DelegateMem.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-20 </date>
// <summary>委托变量</summary>
namespace IM.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// A class with static delegate member
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-20
    /// 版本：1.0</c>
    /// </remarks>
    static class DelegateMem
    {
        // 为ListBox追加 item 的委托变量
        public delegate void AppendDelegate(ListBox lstBox_recMsg, string str);

        // 为pnl 添加按钮的委托变量
        public delegate void IniFrdList(Panel pnl);

        // 为Label 重新设置文本内容的委托变量
        public delegate void ResetText(string str, Label lbl);
    } // class
} // namespace
