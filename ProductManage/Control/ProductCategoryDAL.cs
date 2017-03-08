using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//引入命名空间 
using System.Data;
namespace ProductManage
{
    public class ProductCategoryDAL
    {
        //查询所有产品分类数据
        public static DataSet SelectProductCategory()
        {
            string sqlString = "select ProductCategoryId,ProductCategoryName from ProductCategory";
            DataSet ds = null;
            try
            {
                ds = SQLHelper.GetDataSet(sqlString);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }
    }
}