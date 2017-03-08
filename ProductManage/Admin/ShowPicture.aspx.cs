using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManage
{
    public partial class ShowPicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["fileName"] != null)
            {
                string fileName = Request.Params["fileName"].ToString();
                if (!string.IsNullOrEmpty(fileName))
                {
                    imgProduct.ImageUrl = "~/ProductImg/" + fileName.Substring(0, fileName.IndexOf('.')) + "/" + fileName;
                }
            }
        }
    }
}