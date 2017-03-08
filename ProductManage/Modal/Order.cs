using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProductManage
{
    public class Order
    {
        #region 字段
        private string orderId = string.Empty;
        private string productId = string.Empty;
        private string productName = string.Empty;
        private string userId = string.Empty;
        private string inputer = string.Empty;
        private string updater = string.Empty;
        private string remarks = string.Empty;
        private string userName = string.Empty;
        private string customerName = string.Empty;
        private string customerPhone = string.Empty;
        private string customerAddress = string.Empty;
        private int orderStatus = 0;
        private DateTime orderDate = DateTime.Now;
        private DateTime inputDate = DateTime.Now;
        private DateTime updateDate = DateTime.Now;
        private decimal saleQuantity = 0;
        private decimal salePrice = 0;
        private decimal detailsAmount = 0; 
        #endregion

        #region 属性
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public decimal DetailsAmount
        {
            get { return detailsAmount; }
            set { detailsAmount = value; }
        }
        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
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
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string CustomerPhone
        {
            get { return customerPhone; }
            set { customerPhone = value; }
        }

        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }
        public int OrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
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

        public decimal SaleQuantity
        {
            get { return saleQuantity; }
            set { saleQuantity = value; }
        }
        public decimal SalePrice
        {
            get { return salePrice; }
            set { salePrice = value; }
        } 
        #endregion
        
        //默认构造 
        public Order() { }
        //重载构造函数
        public Order(IDataReader reader)
        {
            this.orderId = reader["OrderId"].ToString();
            this.productId = reader["ProductId"].ToString();
            this.productName = reader["ProductName"].ToString();
            this.userId = reader["UserId"].ToString();
            this.inputer = reader["Inputer"].ToString();
            this.updater = reader["Updater"].ToString();
            this.remarks = reader["Remarks"].ToString();
            this.userName = reader["UserName"].ToString();
            this.customerName = reader["CustomerName"].ToString();
            this.customerPhone = reader["CustomerPhone"].ToString();
            this.customerAddress = reader["CustomerAddress"].ToString();
            this.orderStatus = Int32.Parse(reader["OrderStatus"].ToString());
            this.saleQuantity = decimal.Parse(reader["SaleQuantity"].ToString());
            this.salePrice = decimal.Parse(reader["SalePrice"].ToString());
            this.detailsAmount = decimal.Parse(reader["DetailsAmount"].ToString());   
            if (!string.IsNullOrEmpty(reader["InputDate"].ToString()))
            {
                this.inputDate = DateTime.Parse(reader["InputDate"].ToString());
            }
            if (!string.IsNullOrEmpty(reader["UpdateDate"].ToString()))
            {
                this.updateDate = DateTime.Parse(reader["UpdateDate"].ToString());
            }
            if (!string.IsNullOrEmpty(reader["OrderDate"].ToString()))
            {
                this.updateDate = DateTime.Parse(reader["OrderDate"].ToString());
            }
        }
    }
}