using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using DAL;
using System.Threading.Tasks;

namespace BAL
{
   public class AdminBAL
    {
       public List<AdminResponse> GetCustomerDetails(AdminRequest objReq)
       {
           AdminDAL objPDAL = new AdminDAL();
           List<AdminResponse> objResponse = objPDAL.GetCustomerDetails(objReq);
           return (objResponse);
       }
       public List<AdminCustomerResponse> GetSupplierDetails(AdminCustomerRequest objReq)
       {
           AdminDAL objPDAL = new AdminDAL();
           List<AdminCustomerResponse> objResponse = objPDAL.GetSupplierDetails(objReq);
           return (objResponse);
       }
       public List<AdminProductResponse> GetProductDetails(AdminProductRequest objReq)
       {
           AdminDAL objPDAL = new AdminDAL();
           List<AdminProductResponse> objResponse = objPDAL.GetProductDetails(objReq);
           return (objResponse);
       }
       public List<AdminCategoryResponse> GetCategoryDetails(AdminCategoryRequest objReq)
       {
           AdminDAL objPDAL = new AdminDAL();
           List<AdminCategoryResponse> objResponse = objPDAL.GetCategoryDetails(objReq);
           return (objResponse);
       }
       public List<AdminOrderResponse> GetOrderDetails(AdminOrderRequest objReq)
       {
           AdminDAL objPDAL = new AdminDAL();
           List<AdminOrderResponse> objResponse = objPDAL.GetOrderDetails(objReq);
           return (objResponse);
       }
       public List<AdminResponse> GetSearch(string SearchTerm)
       {
           AdminDAL objPDAL = new AdminDAL();
           List<AdminResponse> objGetPdt = objPDAL.GetSearch(SearchTerm);
           return (objGetPdt);
       }
       public AdminLoginResponse GetAdminLogin(AdminLoginRequest objReq)
       {
           AdminDAL objCDAL = new AdminDAL();
           AdminLoginResponse objResponse = objCDAL.GetAdminLogin(objReq);
           return (objResponse);
       }
    }
}
