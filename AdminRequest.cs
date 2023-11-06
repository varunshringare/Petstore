using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AdminRequest:BaseRequest
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string Contact { get; set; }
        public string DOB { get; set; }
        public int CustomerID { get; set; }
  
    }

    public class AdminCustomerRequest:BaseRequest
    {
        public int supplierID { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierContact { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierName { get; set; }
    }
    public class AdminProductRequest:BaseRequest
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int ProductStock { get; set; }
        public int ProductSID { get; set; }
        public int ProductCID { get; set; }
        public string catogoryName { get; set; }
    }
    public class AdminCategoryRequest:BaseRequest
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CatDescription { get; set; }
    }
    public class AdminOrderRequest:BaseRequest
    {
        public int orderID { get; set; }
        public int CustomerID { get; set; }
        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
    }
    public class AdminLoginRequest:BaseRequest
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
    }
}
