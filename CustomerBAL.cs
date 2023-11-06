using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BAL
{
  public class CustomerBAL
    {
      public CustomerResponse InsertCustomer(CustomerRequest objReq)
      {
          CustomerDAL objCDAL = new CustomerDAL();
          CustomerResponse objResponse= objCDAL.InsertCustomer(objReq);
          return (objResponse);
      }
      public CustomerResponse GetLoginCredentials(CustomerRequest objReq)
      {
          CustomerDAL objCDAL = new CustomerDAL();
          CustomerResponse objResponse = objCDAL.GetLoginCredentials(objReq);
          return (objResponse);
      }
      public List<CustomerOResponse> GetOrderHistory(CustomerORequest objReq)
      {
          CustomerDAL objCDAL = new CustomerDAL();
          List<CustomerOResponse> objResponse = objCDAL.GetOrderHistory(objReq);
          return (objResponse);
      }
    }
}
