using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManage
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetVerifyCode();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == string.Empty)
            {
                lbltp.Text = "请输入帐号？";
                txtUserId.Focus();
            }
            else if (txtPwd.Text == string.Empty)
            {
                lbltp.Text = string.Empty;
                txtPwd.Focus();
                HttpContext.Current.Response.Write("<script language='javascript'>alert(' 请输入密码？ ');</script>");
            }
            else if (txtVerifycode.Text == string.Empty)
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert(' 请输入验证码？ ');</script>");
                txtVerifycode.Focus();
            }
            else
            {
                string verfiycode = string.Empty;
                if (Session["VerifyCodeAdmin"] != null)
                {
                    verfiycode = (string)Session["VerifyCodeAdmin"];
                    if (txtVerifycode.Text.ToLower() != verfiycode.ToLower())
                    {
                        HttpContext.Current.Response.Write("<script language='javascript'>alert(' 验证码输入错误！ ');</script>");
                    }
                    else
                    {
                        //查询数据校验帐号和密码   
                        //查询之前先加密密码再与数据库中的密码比对
                        string adminPwd = ComClass.TripleDESEncryptString(txtPwd.Text);
                        AdUserInfo item = AdUserInfoDAL.CheckUserLogin(
                            ComClass.NoHTML(txtUserId.Text), adminPwd);
                        if (item == null)
                        {
                            HttpContext.Current.Response.Write("<script language='javascript'>alert(' 输入错误，未通过验证！');</script>");
                        }
                        else
                        {
                            if (item.AdminUserId == txtUserId.Text)
                            {
                                Session["LoginedAdmin"] = item;

                                //发放令牌
                                System.Web.Security.FormsAuthentication.SetAuthCookie(item.AdminUserId, false);

                                //跳转页面
                                Response.Redirect("~/Admin/ProductManageList.aspx");
                            }
                            else
                            {
                                HttpContext.Current.Response.Write("<script language='javascript'>alert(' 注意大小写！');</script>");
                            }
                        }
                    }
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>alert(' 服务生成验证码出错！ ');</script>");
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
        }
        protected void lnkGetVerifyCode_Click(object sender, EventArgs e)
        {
            GetVerifyCode();
        }
        private void GetVerifyCode()
        {
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            this.imgValidateCode.ImageUrl = "~/VerifycodeAdmin.aspx?" + ran.Next();
        }


    }
}