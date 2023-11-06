using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BAL
{
    public class ProductBAL
    {
        ProductDAL objGetDAL = new ProductDAL();
        public ProductResponse InsertProduct(productRequest objReq)
        {
            ProductDAL objPDAL = new ProductDAL();
            ProductResponse objResponse = objPDAL.InsertProduct(objReq);
            return (objResponse);
        }
        public ProductResponse UpdateSupplierProduct(productRequest objReq)
        {
            ProductDAL objPDAL = new ProductDAL();
            ProductResponse objResponse = objPDAL.UpdateSupplierProduct(objReq);
            return (objResponse);
        }
        public List<ProductResponse> GetAll()
        {
            List<ProductResponse> objGetPdt = objGetDAL.GetAll();
            return (objGetPdt);
        }
        public List<ProductResponse> GetSearchProduct(string SearchTerm)
        {
            List<ProductResponse> objGetPdt = objGetDAL.GetSearchProduct(SearchTerm);
            return (objGetPdt);
        }
        public ProductResponse GetAllProductsBYID(productRequest objRequest)
        {
           
            ProductResponse objGetPdt;
            try
            {
                
                 objGetPdt = objGetDAL.GetAllProductsBYID(objRequest);
            }
            catch(Exception)
            {
                throw;
            }
            return (objGetPdt);
        }
        
    }
}
