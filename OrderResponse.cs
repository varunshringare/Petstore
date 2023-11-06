using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class OrderResponse:BaseResponse
    {
        public int OrderID { get; set; }

    }
    public class OrderSResponse
    {
        public string ProductName{get;set;}
        public int ProductPrice{get;set;}
        public int Quantity{get;set;}
        public string OrderDate{get;set;}
        public string ProductImage { get; set; }
    }
}
