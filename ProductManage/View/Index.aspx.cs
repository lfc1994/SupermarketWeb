using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
namespace ProductManage
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductCategory();//绑定产品分类数据到下拉菜单
            }
        }

        //用户登录
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblUserIdTip.Text = string.Empty;
            lblPwdTip.Text = string.Empty;
            lblmsg.Text = string.Empty;

            if (txtUserId.Text == string.Empty)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请输入用户名？');</script>");
               // lblUserIdTip.BackColor = System.Drawing.Color.FromArgb(255, 180, 180);
                lblUserIdTip.Text = "亲，没有输入帐号哟？ ";
                lblUserIdTip.Font.Name = "STHUPO";
                lblUserIdTip.Font.Size=15;
            }
            else if (txtPwd.Text == string.Empty)
            {
                lblPwdTip.Text = "=。=还没有密码呢 ";
                lblPwdTip.Font.Name = "STHUPO";
                lblPwdTip.Font.Size = 15;
            }
            else
            {
                ComUserInfo item = ComUserInfoDAL.CheckUserLogin(ComClass.NoHTML(txtUserId.Text), ComClass.NoHTML(txtPwd.Text));
                if (item == null)
                {
                    lblmsg.Text = "阿欧！账号或者密码不对哟";
                    lblmsg.Font.Name = "STHUPO";
                    lblmsg.Font.Size = 15;              
                }
                else
                {
                    if (item.UserId == txtUserId.Text && item.LoginPwd == txtPwd.Text)//通过等号表达式判断账号密码的大小写是否正确
                    {
                        Session["LoginedUser"] = item;//以键来存储当前已登录用户对象
                        //发放令牌
                        System.Web.Security.FormsAuthentication.SetAuthCookie(item.UserId, false);//在服务器端保存一个用户身份的凭证
                        //向日志数据库写入日志信息，当前用户的IP地址是哪里登录进来的（可用于用户验证自己的账号是否被盗用）
                        //更新当前登录用户最近一次登录IP和登录日期
                        bool flag = ComUserInfoDAL.UpdateLatestIpDate(item.UserId, Request.UserHostAddress, DateTime.Now);
                        lblUserId.Visible = false; txtUserId.Visible = false;
                        txtPwd.Visible = false; lblPwd.Visible = false;
                        lblUserIdTip.Text = "欢迎光临！！！";
                        lblUserIdTip.Font.Name = "STHUPO";
                        lblUserIdTip.Font.Size = 17;
                        lblPwdTip.Text = "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp亲爱的：" + item.UserName;
                        lblPwdTip.Font.Name = "STHUPO";
                        lblPwdTip.Font.Size = 17;
                        btnLogin.Visible = false; btnReset.Visible = false;
                       // lblmsg.Text = "真棒  = 。 =";
                    }
                    else
                    {
                        lblmsg.Text = "哎呀~大小写错咯！";
                        lblmsg.Font.Name = "STHUPO";
                        lblmsg.Font.Size = 15;
                    }
                }
            }
        }
        //按条件查询产品
        protected void imbSearch_Click(object sender, ImageClickEventArgs e)
        {
            SetAspNetPagerRecordCountByPro();//设置分页控件的总记录            
            BindProRepeaterData();//查询产品分页数据
        }
        private void BindProductCategory()//绑定产品分类数据到下拉菜单
        {
            DataSet ds = ProductCategoryDAL.SelectProductCategory();
            dwlProductCategory.DataSource = ds.Tables[0].DefaultView;
            dwlProductCategory.DataTextField = "ProductCategoryName";
            dwlProductCategory.DataValueField = "ProductCategoryId";
            dwlProductCategory.DataBind();
        }
        //设置分页控件的总记录方法
        private void SetAspNetPagerRecordCountByPro()
        {
            this.AspNetPagerByProducts.RecordCount = ProductsDAL.SelectProductByConditionRowsCount(dwlProductCategory.SelectedItem.Value,
                this.AspNetPagerByProducts.PageSize, this.AspNetPagerByProducts.CurrentPageIndex);
        }
        //查询产品分页数据方法
        protected void BindProRepeaterData()
        {
            this.RepeaterByProduct.DataSource = ProductsDAL.SelectProductByCondition(dwlProductCategory.SelectedItem.Value,
               this.AspNetPagerByProducts.PageSize, this.AspNetPagerByProducts.CurrentPageIndex);
            this.RepeaterByProduct.DataBind();
        }
        //分页控件索引改变事件
        protected void AspNetPagerByProducts_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPagerByProducts.CurrentPageIndex = e.NewPageIndex;
            BindProRepeaterData();
        }
        //处理图片路径
        protected string GetFullProimgFile(string productId)
        {
            string oldproductId = productId;
            if (!string.IsNullOrEmpty(productId))
            {
                productId = productId.Substring(0, productId.LastIndexOf(".")) + "/" + oldproductId;
            }
            return productId;
        }
        //处理销售价格
        protected string DoProSalePrice(decimal salcePrice)
        {
            string result = string.Empty;
            if (salcePrice == 0)
            {
                result = "面议";
            }
            else
            {
                CultureInfo bz = new CultureInfo("zh-cn");
                result = salcePrice.ToString("c", bz);
            }
            return result;
        }

        protected void RepeaterByProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="buyly")
            {
                string ProductId = (string)(e.CommandArgument);
                string sqlString = "update Products set Currentstock=Currentstock-1 where ProductId=@ProductId";
                int rows = -1;   
                SqlParameter[] parms = new SqlParameter[]
           {
               new SqlParameter("@ProductId",ProductId)
           };                             
                try
                {
                    rows = SQLHelper.ExcuteSQL(sqlString, parms);
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>alert('ComUserInfoDAL.UpdateLasetIpDate(...)出错，原因： '" + ex.Message + ");</script>");
                }
                Label lbl = e.Item.FindControl("yesBuy") as Label;
                lbl.Visible = true;
                return;
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUserId.Text = string.Empty;
            txtPwd.Text = string.Empty;
        }

        protected void imbManager_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
       
    }
}