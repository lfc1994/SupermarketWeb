using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//引入命名空间
using System.Data;
/*
 * 
 * 
 * 系统管理实体类
 * 
 */
namespace ProductManage
{
    public class AdUserInfo
    {
        //默认的构造函数 
        public AdUserInfo()
        {
        }
        //构造函数重载 
        public AdUserInfo(IDataReader reader)
        {
            this.adminUserId = reader["AdminUserId"].ToString();
            this.adminUserName = reader["AdminUserName"].ToString();
            this.adminUserPwd = reader["AdminUserPwd"].ToString();
            this.userStatus = Int32.Parse(reader["UserStatus"].ToString());
            this.mobilePhone = reader["MobilePhone"].ToString();

            if (!string.IsNullOrEmpty(reader["LastLoginDate"].ToString()))
            {
                this.lastLoginDate = DateTime.Parse(reader["LastLoginDate"].ToString());
            }
            this.inputer = reader["Inputer"].ToString();
            if (!string.IsNullOrEmpty(reader["InputDate"].ToString()))
            {
                this.inputDate = DateTime.Parse(reader["InputDate"].ToString());
            }
            this.updater = reader["Updater"].ToString();
            if (!string.IsNullOrEmpty(reader["UpdateDate"].ToString()))
            {
                this.updateDate = DateTime.Parse(reader["UpdateDate"].ToString());
            }
        }
        #region 声明字段
        private string adminUserId = string.Empty;
        private string adminUserName = string.Empty;
        private string adminUserPwd = string.Empty;
        private int userStatus = 0;  //0禁用  1启用
        private string mobilePhone = string.Empty;

        private DateTime lastLoginDate = DateTime.Now;
        //日期
        private DateTime inputDate = DateTime.Now;
        private string inputer = string.Empty;
        private DateTime updateDate = DateTime.Now;
        private string updater = string.Empty;
        #endregion
        #region 以下是属性
        public string AdminUserId
        {
            get { return adminUserId; }
            set { adminUserId = value; }
        }
        public string AdminUserName
        {
            get { return adminUserName; }
            set { adminUserName = value; }
        }
        public string AdminUserPwd
        {
            get { return adminUserPwd; }
            set { adminUserPwd = value; }
        }
        public int UserStatus
        {
            get { return userStatus; }
            set { userStatus = value; }
        }
        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }

        public DateTime LastLoginDate
        {
            get { return lastLoginDate; }
            set { lastLoginDate = value; }
        }
        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        public string Inputer
        {
            get { return inputer; }
            set { inputer = value; }
        }
        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }
        public string Updater
        {
            get { return updater; }
            set { updater = value; }
        }
        #endregion

    }
}