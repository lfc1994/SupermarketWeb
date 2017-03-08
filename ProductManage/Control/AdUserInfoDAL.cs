using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProductManage
{
    public class AdUserInfoDAL
    {
        //检查用户登录帐号和密码
        public static AdUserInfo CheckUserLogin(string userId, string pwd)
        {
            string sqlString = "select * from dbo.AdUserInfo where AdminUserId=@AdminUserId and AdminUserPwd=@AdminUserPwd";
            AdUserInfo item = null;
            //参数列表
            SqlParameter[] parms = new SqlParameter[]
            {
                 new SqlParameter("@AdminUserId",userId),
                 new SqlParameter("@AdminUserPwd",pwd)
            };
            try
            {
                using (SqlDataReader reader = SQLHelper.GetReader(sqlString, parms))
                {
                    if (reader.Read() && !reader.IsClosed)
                    {
                        item = new AdUserInfo(reader);
                    }
                    reader.Close();//关闭reader
                }
            }
            catch (Exception e)
            {
            }
            return item;
        }



    }
}