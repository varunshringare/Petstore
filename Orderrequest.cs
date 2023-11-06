using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  public  class Orderrequest:BaseRequest
    {
      public int CustomerID { get; set; }
    }
  public class OrderSRequest:BaseRequest
  {

      public int OrderID { get; set; }
      public string ProductName { get; set; }
      public int ProductPrice { get; set; }
      public int Quantity { get; set; }
      public string OrderDate { get; set; }
      public string ProductImage { get; set; }
  }
}
