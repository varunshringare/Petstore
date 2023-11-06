using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class CartRequest:BaseRequest
    {
       public int CartId { get; set; }
       public string ProductName { get; set; }
       public string ProductImage { get;set; }
       public int ProductPrice { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
        public int Stock { get; set; }
    }
}
