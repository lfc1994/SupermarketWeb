using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ProductManage.Admin
{
    public partial class OrderInfo : System.Web.UI.Page
    {
        SqlConnection sqlcon;
        //SqlCommand sqlcom;
        string strCon = "Data Source=(local);Database=ProductDB;Uid=laoxigua;Pwd=laoxigua";    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                bind();
            }  
        }
        public void bind() 
        {
            string sqlstr = "select * from Orders";     
            sqlcon = new SqlConnection(strCon);      
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
            DataSet myds = new DataSet();    
            sqlcon.Open();    
            myda.Fill(myds, "Orders");
            OrderInformation.DataSource = myds;
            OrderInformation.DataKeyNames = new string[] { "OrderId" };//主键
            OrderInformation.DataBind();     
            sqlcon.Close();   
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductManageList.aspx");
        }
    }
    
}