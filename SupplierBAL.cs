using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BAL
{
    public class SupplierBAL
    {
        public SupplierResponse InsertSupplier(SupplierRequest objReq)
        {
            SupplierDAL objSDAL = new SupplierDAL();
            SupplierResponse objResponse = objSDAL.InsertSupplier(objReq);
            return (objResponse);
        }
        public SupplierResponse GetSupplierCredentials(SupplierRequest objReq)
        {
            SupplierDAL objCDAL = new SupplierDAL();
            SupplierResponse objResponse = objCDAL.GetSupplierCredentials(objReq);
            return (objResponse);
        }
        public List<SupplierOResponse> GetSupplierOrders(SupplierORequest objReq)
        {
            SupplierDAL objCDAL = new SupplierDAL();
            List<SupplierOResponse> objResponse = objCDAL.GetSupplierOrders(objReq);
            return (objResponse);
        }
        public List<SupplierRes> GetSupplierproducts(SupplierReq objReq)
        {
            SupplierDAL objCDAL = new SupplierDAL();
            List<SupplierRes> objResponse = objCDAL.GetSupplierproducts(objReq);
            return (objResponse);
        }
    }
}
