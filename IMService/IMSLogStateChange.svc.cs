// <copyright file="Contact.cs" company="TNT">
// Copyright (c) TNT. All rights reserved Contact.cs.
// </copyright>
// <author>Li Mingjian</author>
// <date> 2014-11-14 </date>
// <summary>网络服务实现类</summary
namespace IMService
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“IMSLogStateChange”。

    /// <summary>
    /// access sql server 2005
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// <c>创建人：Li 
    /// 创建日期：2014-11-14
    /// 版本：1.0</c>
    /// </remarks>
    public class IMSLogStateChange:IIMSLogStateChange
    {
        /// <summary>
        /// 改变登录状态
        /// </summary>
        /// <param name="userName">current user name</param>
        /// <param name="Pwd">user's password</param>
        /// <param name="logSate">login or logout</param>
        /// <returns></returns>
        public string changeLogState(string userName, string Pwd, bool logSate)
        {
            string procName = "";

            //如果是未登录状态，表示执行登录
            if (logSate == false)
            {
                procName = "LoginIm";
            } // if

            if (logSate == true)
            {
                procName = "LogoutIm";
            } // if

            /*数据库名 IM，服务名：TNT-PC 表：UserLogin 存储过程名：LoginIM 1代表登录成功 0代表登录失败  
             根据用户名和密码选择行数，行数必然小于等于1*/
            string strConn = "data source=TNT-PC; database=IM;Uid=sa;pwd=woquwanle123";//用户名密码验证模式
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();

            //定义command 使用存储过程
            SqlCommand cmd = new SqlCommand(procName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //添加参数
            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.Char));
            cmd.Parameters["@UserName"].Value = userName;
            cmd.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.Char));
            cmd.Parameters["@UserPassword"].Value = Pwd;

            //设置返回值参数
            cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Int));
            cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            conn.Close();

            return cmd.Parameters["@return"].Value.ToString();
        } // changeLogState

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="userName">current user</param>
        /// <returns></returns>
        public string getFrdList(string userName)
        {
            int i = 0;
            string userList="";
            string strConn = "data source=TNT-PC; database=IM;Uid=sa;pwd=woquwanle123";//用户名密码验证模式
            SqlConnection conn = new SqlConnection(strConn);
            string strSql = "select * from UserRelation where UserName ='" + userName + "'";

            conn.Open();

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                if (i != 0)
                {
                    userList += "|";//非第一个用户，就在其前面加入|用来区别
                }
                userList += reader["FrdName"].ToString();
                i++;
            } // while

            userList = userList.Replace(" ", "");

            conn.Close();

            return userList;   
        } // getFrdList

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="pwd">pass word</param>
        /// <param name="sex"> sex </param>
        /// <param name="age">age</param>
        /// <returns></returns>
        public string registUser(string userName, string pwd, string sex, string age)
        {
            string strConn = "data source=TNT-PC; database=IM;Uid=sa;pwd=woquwanle123";//用户名密码验证模式
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();

            //定义command 使用存储过程
            SqlCommand cmd = new SqlCommand("RegistUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //添加参数
            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.Char));
            cmd.Parameters["@UserName"].Value = userName;

            cmd.Parameters.Add(new SqlParameter("@UserPassword", SqlDbType.Char));
            cmd.Parameters["@UserPassword"].Value = pwd;

            cmd.Parameters.Add(new SqlParameter("@Sex", SqlDbType.Char));
            cmd.Parameters["@Sex"].Value = sex;

            cmd.Parameters.Add(new SqlParameter("@Age", SqlDbType.Char));
            cmd.Parameters["@Age"].Value = age;
        
            //设置返回值参数
            cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Int));
            cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            conn.Close();

            return cmd.Parameters["@return"].Value.ToString();
        } // registUser

        /// <summary>
        /// 获取所有的在线用户名
        /// </summary>
        /// <returns></returns>
        public string getOnlineList()
        {
            int i = 0;
            string userList = "";
            string strConn = "data source=TNT-PC; database=IM;Uid=sa;pwd=woquwanle123";//用户名密码验证模式
            SqlConnection conn = new SqlConnection(strConn);
            string strSql = "select * from UserInfo where LoginNum ='1'";

            conn.Open();

            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (i != 0)
                {
                    userList += "|";//非第一个用户，就在其前面加入|用来区别
                } // if

                userList += reader["UserName"].ToString();
                i++;
            } // while

            userList = userList.Replace(" ", "");

            conn.Close();

            return userList;   
        } // getOnlineList

        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="userName">current user name</param>
        /// <param name="destName">a user name is added</param>
        /// <returns></returns>
        public string addFrd(string userName, string destName)
        {
            string strConn = "data source=TNT-PC; database=IM;Uid=sa;pwd=woquwanle123";//用户名密码验证模式
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();

            //定义command 使用存储过程
            SqlCommand cmd = new SqlCommand("AddFrd", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //添加参数
            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.Char));
            cmd.Parameters["@UserName"].Value = userName;

            cmd.Parameters.Add(new SqlParameter("@DestName", SqlDbType.Char));
            cmd.Parameters["@DestName"].Value = destName;

            //设置返回值参数
            cmd.Parameters.Add(new SqlParameter("@return", SqlDbType.Int));
            cmd.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();

            conn.Close();

            return cmd.Parameters["@return"].Value.ToString();

            // 0 已经是好友 1 添加成功 -1 失败
        } // addFrd
    } // calss
} // namespace