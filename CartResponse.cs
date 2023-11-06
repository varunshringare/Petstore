using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class CartResponse:BaseResponse
    {
       public int Status { get; set; }
       public int CartId { get; set; }
       public string ProductName { get; set; }
       public string ProductImage { get;set; }
       public double ProductPrice { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
        public int Stock { get; set; }

    }
}
