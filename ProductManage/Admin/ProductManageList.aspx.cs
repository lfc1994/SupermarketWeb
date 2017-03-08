using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ProductManage
{
    public partial class ProductManageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定产品分类数据到下拉菜单
                BindProductCategory();
            }
        }
        //绑定产品分类数据到下拉菜单
        private void BindProductCategory()
        {
            DataSet ds = ProductCategoryDAL.SelectProductCategory();
            dwlProductCategory.DataSource = ds.Tables[0].DefaultView;
            dwlProductCategory.DataTextField = "ProductCategoryName";
            dwlProductCategory.DataValueField = "ProductCategoryId";
            dwlProductCategory.DataBind();
            ListItem item = new ListItem("全部", "全部");
            dwlProductCategory.Items.Add(item);
            dwlProductCategory.SelectedIndex = dwlProductCategory.Items.Count - 1;
        }
        //查询产品数据
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProductMethod();
        }
        //查询的方法
        private void SearchProductMethod()
        {
            this.gdvProduct.DataSource = ProductsDAL.SearchProductByCondition(this.dwlProductCategory.SelectedItem.Value);
            this.gdvProduct.DataBind();
        }
        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {        
           //     string ProductId = (string)(e.);
           //     string sqlString = "update Products set Currentstock=Currentstock-1 where ProductId=@ProductId";
           //     int rows = -1;   
           //     SqlParameter[] parms = new SqlParameter[]
           //    new SqlParameter("@ProductId",ProductId)
           //};                             
           //     try
           //     {
           //         rows = SQLHelper.ExcuteSQL(sqlString, parms);
           //     }
           //     catch (Exception ex)
           //     {
           //         HttpContext.Current.Response.Write("<script language='javascript'>alert('ComUserInfoDAL.UpdateLasetIpDate(...)出错，原因： '" + ex.Message + ");</script>");
           //     }
           //     Label lbl = e.Item.FindControl("yesBuy") as Label;
           //     lbl.Visible = true;
           //     return;
            

        }

        
        //分页项索引改变事件
        protected void gdvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //设置当前页的索引
            this.gdvProduct.PageIndex = e.NewPageIndex;
            SearchProductMethod();
        }
        //选择行索引改变事件
        protected void gdvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gdvProduct.Rows[this.gdvProduct.SelectedIndex].Cells[2] != null)
            {
                lblStedProductId.Text = this.gdvProduct.Rows[this.gdvProduct.SelectedIndex].Cells[2].Text;
            }
        }
        //数据行绑定事件
        protected void gdvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            //1） 文本：vnd.ms-excel.numberformat:@
            //2）日期：vnd.ms-excel.numberformat:yyyy/mm/dd
            //3）数字：vnd.ms-excel.numberformat:#,##0.00
            //4）货币：vnd.ms-excel.numberformat:￥#,##0.00
            //5）百分比：vnd.ms-excel.numberformat: #0.00%
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff';this.style.borderColor='black'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;this.style.borderColor='black'");


                e.Row.Cells[2].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                e.Row.Cells[5].Attributes.Add("style", "vnd.ms-excel.numberformat:￥#,##0.000");
                e.Row.Cells[6].Attributes.Add("style", "vnd.ms-excel.numberformat:￥#,##0.000");
                if (e.Row.Cells[9].Text == "1")
                {
                    e.Row.Cells[9].Text = "是";
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                   e.Row.Cells[9].Text = "否 ";
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                }
                Products item = ProductsDAL.SelectProductByProductId(e.Row.Cells[2].Text);
                if (item != null)
                {
                    if (item.ProductImgFile != string.Empty)
                    {
                        LinkButton lkpimg = e.Row.FindControl("lkpimg") as LinkButton;
                        if (lkpimg != null)
                        {
                            lkpimg.Text = "查看";
                            lkpimg.ToolTip = item.ProductImgFile;
                        }
                    }
                }
            }
        }

        protected void btnLook_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderInfo.aspx");
        }


    }
}