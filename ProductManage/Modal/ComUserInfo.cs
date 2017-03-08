using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//引入命名空间
using System.Data;
/***
 * 普通用户实体类
 */
namespace ProductManage
{
    public class ComUserInfo
    {
        //默认的构造函数 
        public ComUserInfo()
        {
        }
        //构造函数重载 
        public ComUserInfo(IDataReader reader)
        {
            this.userId = reader["UserId"].ToString();
            this.userName = reader["UserName"].ToString();
            this.loginPwd = reader["LoginPwd"].ToString();
            this.sex = reader["Sex"].ToString();
            this.email = reader["Email"].ToString();
            this.mobilePhone = reader["MobilePhone"].ToString();
          
            this.remarks = reader["Remarks"].ToString();
            this.userStatus = Int32.Parse(reader["UserStatus"].ToString());
            
            this.updater = reader["Updater"].ToString();
            if (!string.IsNullOrEmpty(reader["RegDate"].ToString()))
            {
                this.regDate = DateTime.Parse(reader["RegDate"].ToString());
            }
            if (!string.IsNullOrEmpty(reader["LastLoginDate"].ToString()))
            {
                this.lastLoginDate = DateTime.Parse(reader["LastLoginDate"].ToString());
            }
            if (!string.IsNullOrEmpty(reader["InputDate"].ToString()))
            {
                this.inputDate = DateTime.Parse(reader["InputDate"].ToString());
            }
            if (!string.IsNullOrEmpty(reader["UpdateDate"].ToString()))
            {
                this.updateDate = DateTime.Parse(reader["UpdateDate"].ToString());
            }
        }
        #region 字段
        private string userId = string.Empty;
        private string userName = string.Empty;
        private string loginPwd = string.Empty;
        private string sex = string.Empty;
        private string email = string.Empty;
        private string mobilePhone = string.Empty;


        private string remarks = string.Empty;
        private int userStatus = 0; //管理员状态：0禁用 1启用

        private string updater = string.Empty;
        private DateTime regDate = DateTime.Now;
        private DateTime lastLoginDate = DateTime.Now;
        private DateTime inputDate = DateTime.Now;
        private DateTime updateDate = DateTime.Now;
        #endregion
        #region 属性
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string LoginPwd
        {
            get { return loginPwd; }
            set { loginPwd = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }


        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        public int UserStatus
        {
            get { return userStatus; }
            set { userStatus = value; }
        }


        public string Updater
        {
            get { return updater; }
            set { updater = value; }
        }
        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
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
        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }
        #endregion
       


    }
}