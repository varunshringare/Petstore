using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BAL
{
   public class OrderBAL
    {
       public OrderResponse PlaceOrder(Orderrequest objRequest)
       {
           OrderDAL objOrderDAL = new OrderDAL();
           OrderResponse objResponse = objOrderDAL.PlaceOrder(objRequest);
           return (objResponse);
       }
       public List<OrderSResponse> GetOrderSummary(OrderSRequest objRequest)
   {
       OrderDAL objOrderDAL = new OrderDAL();
       List<OrderSResponse> objResponse = objOrderDAL.GetOrderSummary(objRequest);
       return (objResponse);
   }
    }
}
