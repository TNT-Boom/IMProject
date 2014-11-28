using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IM.UI;
namespace IM
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            W_Login w_login = new W_Login();
            if (w_login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new W_Main(w_login.txt_userName.Text,w_login.txt_userPwd.Text));
            }
        }
    }
}
