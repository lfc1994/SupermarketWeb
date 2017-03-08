using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProductManage
{
    public class ComUserInfoDAL
    {
        //检查用户登录账号和密码
        public static ComUserInfo CheckUserLogin(string userId, string pwd)
        {
            string sqlString = "select * from dbo.ComUserInfo where UserId=@UserId and LoginPwd=@LoginPwd";
            ComUserInfo item = null;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@UserId",userId),
                new SqlParameter("@LoginPwd",pwd)
            };
            try
            {
                using (SqlDataReader reader = SQLHelper.GetReader(sqlString, parms))
                {
                    if (reader.Read() && !reader.IsClosed)
                    {
                        item = new ComUserInfo(reader);
                    }
                    reader.Close();//关闭reader
                }
            }
            catch (Exception e)
            { }
            return item;
        }
        //登录成功后，更新用户的最近一次登录IP和登陆日期
        public static bool UpdateLatestIpDate(string userId, string lastLoginIp, DateTime lastLoginDate)
        {
            string sqlString = "update dbo.ComUserInfo set LastLoginIP=@LastLoginIP,";
            sqlString += "LastLoginDate=@LastLoginDate where UserId=@UserId";
            int rows = -1;
            SqlParameter[] parms = new SqlParameter[]
           {
               new SqlParameter("@LastLoginIP",lastLoginIp),
               new SqlParameter("@LastLoginDate",lastLoginDate),
               new SqlParameter("@UserId",userId)
           };
            try
            {
                rows = SQLHelper.ExcuteSQL(sqlString, parms);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('ComUserInfoDAL.UpdateLasetIpDate(...)出错，原因： '" + ex.Message + ");</script>");
            }
            return (rows > 0) ? true : false;
        }


    }
}