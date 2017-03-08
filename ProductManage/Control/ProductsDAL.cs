using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace ProductManage
{
    public class ProductsDAL
    {
        #region 前台
        //按条件查询产品信息(取分页数据)
        public static List<Products> SelectProductByCondition(string pCategoryId, int pagesize, int pageindex)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@docount",2),
                new SqlParameter("@productcategoryid",pCategoryId)
            };
            List<Products> lstProduct = new List<Products>();
            Products item = null;
            try
            {
                using (SqlDataReader reader = SQLHelper.GetReader("pro_selectProduct", parms, CommandType.StoredProcedure))
                {
                    while (reader.Read() && !reader.IsClosed)
                    {
                        item = new Products(reader, 1);
                        //将产品对象装到List
                        lstProduct.Add(item);
                    }
                    reader.Close();//关闭reader
                }
            }
            catch (Exception e)
            {
            }
            return lstProduct;
        }
        //查询产品分页数据的总记录
        public static int SelectProductByConditionRowsCount(string pCategoryId, int pagesize, int pageindex)
        {
            int rows = -1;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@pagesize",pagesize),
                new SqlParameter("@pageindex",pageindex),
                new SqlParameter("@docount",1), //过程中此值为1表示查询分页总记录
                new SqlParameter("@productcategoryid",pCategoryId)
            };
            Object obj = null;
            try
            {
                obj = SQLHelper.GetFirstFieldValue("pro_selectProduct", parms, CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw;
            }
            if (obj != null)
                rows = int.Parse(obj.ToString());
            else
                rows = 0;
            return rows;
        }
        #endregion



        #region 后台
        //查询产品列表页数据
        public static List<Products> SearchProductByCondition(string productCategoryId)
        {
            string sqlString = "select * from Products where 1=1 ";
            if (!string.IsNullOrEmpty(productCategoryId) && productCategoryId != "全部")
            {
                sqlString += " and productCategoryId='" + productCategoryId + "'";
            }
            List<Products> lstProduct = new List<Products>();
            Products item = null;
            try
            {
                using (SqlDataReader reader = SQLHelper.GetReader(sqlString))
                {
                    while (reader.Read() && !reader.IsClosed)
                    {
                        item = new Products(reader);
                        //将产品对象装到List
                        lstProduct.Add(item);
                    }
                    reader.Close();//关闭reader
                }
            }
            catch (Exception e)
            {
            }
            return lstProduct;
        }
        //根据产品编号查询产品
        public static Products SelectProductByProductId(string productId)
        {
            string sqlString = "select * from Products where ProductId = @ProductId";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ProductId",productId)
            };
            Products item = null;
            try
            {
                using (SqlDataReader reader = SQLHelper.GetReader(sqlString, parms))
                {
                    if (reader.Read() && !reader.IsClosed)
                    {
                        item = new Products(reader);
                    }
                    reader.Close();//关闭reader
                }
            }
            catch (Exception e)
            {
            }
            return item;
        }
        //修改产品信息
        public static bool UpdateProductInfo(Products item)
        {
            string sqlString = "update dbo.Products set ProductName=@ProductName,ProductCost=@ProductCost,";
            sqlString += " SalePrice=@SalePrice,Currentstock=@Currentstock,";
            sqlString += "StockNotifyStatus=@StockNotifyStatus,Remarks=@Remarks where ProductId = @ProductId ";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ProductName",item.ProductName),
                new SqlParameter("@ProductCost",item.ProductCost),
                new SqlParameter("@SalePrice",item.SalePrice),
                new SqlParameter("@Currentstock",item.Currentstock),
                new SqlParameter("@StockNotifyStatus",item.StockNotifyStatus),
                new SqlParameter("@Remarks",item.Remarks),
                new SqlParameter("@ProductId",item.ProductId)  //条件
            };
            int rows = -1;
            try
            {
                rows = SQLHelper.ExcuteSQL(sqlString,parms);
            }
            catch (Exception)
            {
                throw;
            }
            return (rows > 0) ? true : false;
        }
        //将上传成功的产品图片名称更新至数据库
        public static bool UpdateProductImgFiles(string productImgName, string productId, string adminUserId)
        {
            string sqlString = "update dbo.Products set ProductImgFile=@ProductImgFile,Updater=@Updater,UpdateDate=GETDATE() where ProductId=@ProductId";
            int rows = -1;
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@ProductImgFile",productImgName),       
                new SqlParameter("@Updater",adminUserId),
                new SqlParameter("@ProductId",productId),
            };
            try
            {
                rows = SQLHelper.ExcuteSQL(sqlString, parms);
            }
            catch (Exception)
            {
                throw;
            }
            return (rows > 0) ? true : false;
        }
        //删除图片时更新产品表里对应的产品的图片名称列的值 
        public static bool UpdateProductImgFilesByDelete(string productId, string adminUserId)
        {
            string sqlString = "update dbo.Products set ProductImgFile=NULL,Updater=@Updater,UpdateDate=GETDATE() where ProductId=@ProductId";
            int rows = -1;
            SqlParameter[] parms = new SqlParameter[]
            {               
                new SqlParameter("@Updater",adminUserId),
                new SqlParameter("@ProductId",productId),
            };
            try
            {
                rows = SQLHelper.ExcuteSQL(sqlString, parms);
            }
            catch (Exception)
            {
                throw;
            }
            return (rows > 0) ? true : false;
        }
        
              //删除图片时更新产品表里对应的产品信息的值 
        public static bool UpdateProductByDelete(string productId, string adminUserId)
        {
            string sqlString = "update dbo.Products set ProductImgFile=NULL,Updater=@Updater,UpdateDate=GETDATE() where ProductId=@ProductId";
            int rows = -1;
            SqlParameter[] parms = new SqlParameter[]
            {               
                new SqlParameter("@Updater",adminUserId),
                new SqlParameter("@ProductId",productId),
            };
            try
            {
                rows = SQLHelper.ExcuteSQL(sqlString, parms);
            }
            catch (Exception)
            {
                throw;
            }
            return (rows > 0) ? true : false;
        }
        #endregion
    }
}