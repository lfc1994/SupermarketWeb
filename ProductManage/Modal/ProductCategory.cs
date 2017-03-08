using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//引入命名空间
using System.Data;
/***
 * 
 * 产品分类实体类  
 */
namespace ProductManage
{
    public class ProductCategory
    {
        //默认构造 
        public ProductCategory() { }
        //重载构造函数
        public ProductCategory(IDataReader reader)
        {
            this.productCategoryId = reader["ProductCategoryId"].ToString();
            this.productCategoryName = reader["ProductCategoryName"].ToString();
            this.parentId = reader["ParentId"].ToString();
            this.inputer = reader["Inputer"].ToString();
            this.updater = reader["Updater"].ToString();
            this.remarks = reader["Remarks"].ToString();
            this.parentName = reader["ParentName"].ToString();
            this.sortId = Int32.Parse(reader["SortId"].ToString());
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
        private string productCategoryId = string.Empty;
        private string productCategoryName = string.Empty;
        private string parentId = string.Empty;
        private string parentName = string.Empty;

        private string inputer = string.Empty;
        private string updater = string.Empty;
        private string remarks = string.Empty;
        private int sortId = 0;
        private DateTime inputDate = DateTime.Now;
        private DateTime updateDate = DateTime.Now;
        #endregion
        #region 属性

        public string ParentName
        {
            get { return parentName; }
            set { parentName = value; }
        }
        public string ProductCategoryId
        {
            get { return productCategoryId; }
            set { productCategoryId = value; }
        }
        public string ProductCategoryName
        {
            get { return productCategoryName; }
            set { productCategoryName = value; }
        }
        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }
        public string Inputer
        {
            get { return inputer; }
            set { inputer = value; }
        }
        public string Updater
        {
            get { return updater; }
            set { updater = value; }
        }
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        public int SortId
        {
            get { return sortId; }
            set { sortId = value; }
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