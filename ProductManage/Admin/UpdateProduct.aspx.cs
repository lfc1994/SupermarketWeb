using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace ProductManage
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["ProductId"] != null)
                {
                    string pId = Request.Params["ProductId"].ToString();
                    InitProduct(pId);
                }
            }
        }
        //初始化页面产品数据
        private void InitProduct(string producId)
        {
            Products item = ProductsDAL.SelectProductByProductId(producId);
            if (item != null)
            {
                txtProductId.Text = item.ProductId;
                txtProductName.Text = item.ProductName;
                txtProductCategoryId.Text = item.ProductCategoryId;
                txtProductCategoryName.Text = item.ProductCategoryName;
                txtProductCost.Text = item.ProductCost.ToString();
                txtSalePrice.Text = item.SalePrice.ToString();
                txtProductUnits.Text = item.ProductUnits;
                txtCurrentstock.Text = item.Currentstock.ToString();
                //是否库存提醒
                dwlStockNotifyStatus.Text = item.StockNotifyStatus.ToString();
                //是否发布

                txtRemarks.Text = item.Remarks;
                if (string.IsNullOrEmpty(item.ProductImgFile))
                {
                    imgProductImgFilebtn.AlternateText = "暂无图片";
                    this.imgdelbfbtn.Visible = false;
                }
                else
                {
                    imgProductImgFilebtn.ImageUrl = "~/ProductImg/" + item.ProductId + "/" + item.ProductImgFile;
                    imgProductImgFilebtn.ToolTip = item.ProductImgFile;
                }
            }
        }

        //修改
        protected void imgUpdatebtn_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductId.Text))
            {
                Products item = new Products();
                //修改条件  HttpContext.Current.Response.Write("<script language='javascript'>alert(' 请输入密码？ ');</script>");
                item.ProductId = txtProductId.Text;
                item.ProductName = txtProductName.Text;

                decimal result = 0;
                //成本价
                if (decimal.TryParse(txtProductCost.Text, out result))
                {
                    item.ProductCost = decimal.Parse(txtProductCost.Text);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>alert('产品成本价不符合要求！');</script>");
                }

                //销售价
                decimal result1 = 0;
                if (decimal.TryParse(txtSalePrice.Text, out result1))
                {
                    item.SalePrice = decimal.Parse(txtSalePrice.Text);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>alert('产品销售价不符合要求！');</script>");
                }

                //最低库存量
                decimal result2 = 0;
                if (decimal.TryParse(txtCurrentstock.Text, out result2))
                {
                    item.Currentstock = decimal.Parse(txtCurrentstock.Text);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>alert('最低库存量不符合要求！');</script>");
                }


                //是否要提醒
                item.StockNotifyStatus = int.Parse(dwlStockNotifyStatus.SelectedItem.Value);
                item.Remarks = txtRemarks.Text;
                item.UpdateDate = DateTime.Now;
                if (Session["LoginedAdmin"] != null)
                {
                    AdUserInfo adminUserObj = (AdUserInfo)Session["LoginedAdmin"];
                    item.Updater = adminUserObj.AdminUserId;
                }
                item.ProductUnits = txtProductUnits.Text;
                //更新产品信息
                if (ProductsDAL.UpdateProductInfo(item))
                {
                    InitProduct(item.ProductId);
                    HttpContext.Current.Response.Write("<script language='javascript'>alert('修改产品信息成功！');</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script language='javascript'>alert('修改产品信息失败！');</script>");
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('没有产品信息无法修改！');</script>");
            }
        }

        //上传图片文件
        protected void uploadbtn_Click(object sender, ImageClickEventArgs e)
        {
            //新图片名称
            string newProductImgFiles = string.Empty;
            uplblmsg.Text = string.Empty;
            uplblmsg.ForeColor = System.Drawing.Color.Red;
            //上传图片控件
            FileUpload fu = this.fuProductImgFile;
            if (!string.IsNullOrEmpty(txtProductId.Text))
            {
                if (!fu.HasFile)
                {
                    uplblmsg.Text = "请选择产品图片文件？";
                }
                else
                {
                    if (!CheckImgType(fu.PostedFile.ContentType))
                    {
                        uplblmsg.Text = "上传文件格式不支持！";
                    }
                    else if (!CheckImgFileByte(fu))
                    {
                        uplblmsg.Text = "文件大小不能超过 4096kb(4M) ！";
                    }
                    else
                    {
                        //取得上传路径
                        string upLoadFileOldPatch = Server.MapPath("~/ProductImg/" + txtProductId.Text);
                        if (!Directory.Exists(upLoadFileOldPatch))//没有文件夹就创建
                        {
                            Directory.CreateDirectory(upLoadFileOldPatch);
                        }
                        //取得已上传过的文件名
                        DirectoryInfo dir = new DirectoryInfo(upLoadFileOldPatch);
                        FileInfo[] finfo = dir.GetFiles();
                        //将原图删除(节约服务器空间) 
                        for (int i = 0; i < finfo.Length; i++)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(finfo[i].Name))
                                {
                                    if (finfo[i].Name.Substring(0, finfo[i].Name.IndexOf('.')) == txtProductId.Text)
                                    {
                                        File.Delete(upLoadFileOldPatch + "\\" + finfo[i].Name);
                                        break;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                        //有路径
                        if (upLoadFileOldPatch.Trim().Length > 0)
                        {
                            if (fu.PostedFile.ContentType == "image/pjpeg" || fu.PostedFile.ContentType == "image/jpeg")
                            {
                                newProductImgFiles = txtProductId.Text + ".jpg";
                            }
                            else if (fu.PostedFile.ContentType == "image/x-png")
                            {
                                newProductImgFiles = txtProductId.Text + ".png";
                            }
                            else if (fu.PostedFile.ContentType == "image/bmp")
                            {
                                newProductImgFiles = txtProductId.Text + ".bmp";
                            }
                            else if (fu.PostedFile.ContentType == "image/gif")
                            {
                                newProductImgFiles = txtProductId.Text + ".gif";
                            }
                            //上传
                            fu.PostedFile.SaveAs(upLoadFileOldPatch + "\\" + newProductImgFiles);
                            uplblmsg.Text = "上传产品图片成功！产品编号:" + txtProductId.Text;
                            //更新数据库
                            if (UpdateDbFilesName(newProductImgFiles))
                            {
                                uplblmsg.Text += "(更新产品图片成功！)";
                                uplblmsg.ForeColor = System.Drawing.Color.Green;
                                Response.AddHeader("Refresh", "0");
                            }
                            else
                            {
                                uplblmsg.Text += "(更新产品图片失败！)";
                            }
                        }
                        else
                        {
                            uplblmsg.Text = "找不到服务器上的文件路径！";
                        }
                        //将新文件名置空
                        newProductImgFiles = string.Empty;
                    }
                }
            }
        }
        //删除图片文件
        protected void imgdelbfbtn_Click(object sender, ImageClickEventArgs e)
        {
            uplblmsg.Text = string.Empty;
            uplblmsg.ForeColor = System.Drawing.Color.Red;
            string adminUserId = string.Empty;
            if (Session["LoginedAdmin"] != null)
            {
                AdUserInfo adminUserObj = (AdUserInfo)Session["LoginedAdmin"];
                adminUserId = adminUserObj.AdminUserId;
            }
            if (ProductsDAL.UpdateProductImgFilesByDelete(txtProductId.Text, adminUserId))
            {
                uplblmsg.ForeColor = System.Drawing.Color.Green;
                uplblmsg.Text = "删除产品图片成功！";
                //取得上传路径
                string upLoadFileOldPatch = Server.MapPath("~/ProductImg/" + txtProductId.Text);
                if (Directory.Exists(upLoadFileOldPatch))
                {
                    DirectoryInfo dir = new DirectoryInfo(upLoadFileOldPatch);
                    //删除目录及子目录和文件
                    try
                    {
                        dir.Delete(true);
                    }
                    catch (Exception)
                    {
                        uplblmsg.Text = "(删除产品图片文件失败！)";
                    }
                }
                HttpContext.Current.Response.Write("<script language='javascript'>alert('删除图片成功！');</script>");
            }
            else
            {
                lblmsg.Text = "删除产品图片失败！";
            }
        }
       //查检上传文件的类型
        private bool CheckImgType(string fileContentType)
        {
            if (fileContentType == "image/pjpeg" || fileContentType == "image/x-png" || fileContentType == "image/png" || fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/jpeg")
            { return true; }
            else { return false; }
        }

        //检查上传文件的大小
        private bool CheckImgFileByte(FileUpload fu)
        {
            //得到上传文件的实例
            HttpPostedFile myfile = fu.PostedFile;
            string fileName = fu.FileName;
            if (myfile.ContentLength <= 4000 * 1024) //4M
            { return true; }
            else { return false; }
        }

        //将上传成功的产品图片名称更新至数据库
        private bool UpdateDbFilesName(string fileName)
        {
            string adminUserId = string.Empty;
            if (Session["LoginedAdmin"] != null)
            {
                AdUserInfo adminUserObj = (AdUserInfo)Session["LoginedAdmin"];
                adminUserId = adminUserObj.AdminUserId;
            }
            return ProductsDAL.UpdateProductImgFiles(fileName, txtProductId.Text, adminUserId);
        }
    }
}