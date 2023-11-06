using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SupplierResponse : BaseResponse
    {
        public int status { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierContact { get; set; }
        public string SupplierPassword { get; set; }
        public string CustomerName { get; set; }
        public int productID { get; set; }
        public string ProductName { get; set; }
    }
    public class SupplierOResponse 
    {
        public int SupplierID { get; set; }
        public string CustomerName { get; set; }
        public int productID { get; set; }
        public string ProductName { get; set; }
    }
    public class SupplierRes
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int ProductStock { get; set; }
        public int ProductSID { get; set; }
        public int ProductCID { get; set; }
        public string Description { get; set; }
    }
}
