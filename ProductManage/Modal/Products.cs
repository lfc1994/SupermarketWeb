using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/*
 * 
 * 
 * 产品的实体类
 * 
 */
namespace ProductManage
{
    public class Products
    {
        //构造
        public Products()
        {
        }
        //构造重载
        public Products(IDataReader reader)
        {
            this.productName = reader["ProductName"].ToString();
            this.productCategoryId = reader["ProductCategoryId"].ToString();
            this.productId = reader["ProductId"].ToString();
            this.productImgFile = reader["ProductImgFile"].ToString();
            this.productArgvs = reader["ProductArgvs"].ToString();
            this.productUnits = reader["ProductUnits"].ToString();
            this.inputer = reader["Inputer"].ToString();
            this.productCategoryName = reader["ProductCategoryName"].ToString();
            this.updater = reader["Updater"].ToString();
            this.remarks = reader["Remarks"].ToString();

            this.stockNotifyStatus = Int32.Parse(reader["StockNotifyStatus"].ToString());
            if (!string.IsNullOrEmpty(reader["InputDate"].ToString()))
            {
                this.inputDate = DateTime.Parse(reader["InputDate"].ToString());
            }
            if (!string.IsNullOrEmpty(reader["UpdateDate"].ToString()))
            {
                this.updateDate = DateTime.Parse(reader["UpdateDate"].ToString());
            }
            this.productCost = decimal.Parse(reader["ProductCost"].ToString());
            this.salePrice = decimal.Parse(reader["SalePrice"].ToString());
            this.currentstock = decimal.Parse(reader["Currentstock"].ToString());
        }


        //构造重载
        public Products(IDataReader reader,int status)
        {         
            this.productId = reader["ProductId"].ToString();
            this.productName = reader["ProductName"].ToString();
            this.productImgFile = reader["ProductImgFile"].ToString();          
            this.salePrice = decimal.Parse(reader["SalePrice"].ToString());           
        }

        #region 字段
        private string productName = string.Empty;
        private string productCategoryId = string.Empty;
        private string productId = string.Empty;
        private string productImgFile = string.Empty;

        private string productArgvs = string.Empty;
        private string productUnits = string.Empty;
        private string inputer = string.Empty;

        private int stockNotifyStatus = 0;//0是禁用，1是允许
        private DateTime inputDate = DateTime.Now;
        private string productCategoryName = string.Empty;
        private DateTime updateDate = DateTime.Now;
        private string updater = string.Empty;
        private string remarks = string.Empty;
        private decimal productCost = 0;
        private decimal salePrice = 0;
        private decimal currentstock = 0;

      
        #endregion

        #region 属性

        public string ProductImgFile
        {
            get { return productImgFile; }
            set { productImgFile = value; }
        }
        public decimal Currentstock
        {
            get { return currentstock; }
            set { currentstock = value; }
        }
        public decimal SalePrice
        {
            get { return salePrice; }
            set { salePrice = value; }
        }
        public decimal ProductCost
        {
            get { return productCost; }
            set { productCost = value; }
        }
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        public string Updater
        {
            get { return updater; }
            set { updater = value; }
        }
        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }
        public string ProductCategoryName
        {
            get { return productCategoryName; }
            set { productCategoryName = value; }
        }
        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        public int StockNotifyStatus
        {
            get { return stockNotifyStatus; }
            set { stockNotifyStatus = value; }
        }

        public string Inputer
        {
            get { return inputer; }
            set { inputer = value; }
        }
        public string ProductUnits
        {
            get { return productUnits; }
            set { productUnits = value; }
        }
        public string ProductArgvs
        {
            get { return productArgvs; }
            set { productArgvs = value; }
        }

        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        public string ProductCategoryId
        {
            get { return productCategoryId; }
            set { productCategoryId = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        #endregion




	
    }
}