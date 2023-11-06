using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BAL
{
    public class CartBAL
    {
        public CartResponse InsertIntoCart(CartRequest objReq)
        {
            CartDAL objPDAL = new CartDAL();
            CartResponse objResponse = objPDAL.InsertIntoCart(objReq);
            return (objResponse);
        }
          public List<CartResponse> GetCartItems(CartRequest objReq)
        {
            CartDAL objPDAL = new CartDAL();
            List<CartResponse> objResponse = objPDAL.GetCartItems(objReq);
            return (objResponse);
        }
          public CartResponse DeleteProduct(CartRequest objReq)
          {
              CartDAL objDelDAL = new CartDAL();
              CartResponse objResponse = objDelDAL.DeleteProduct(objReq);
              return (objResponse);
          }
          public CartResponse UpdateCart(CartRequest objReq)
          {
              CartDAL objDelDAL = new CartDAL();
              CartResponse objResponse = objDelDAL.UpdateCart(objReq);
              return (objResponse);
          }
          public CartResponse Count(CartRequest objReq)
          {
              CartDAL objDelDAL = new CartDAL();
              CartResponse objResponse = objDelDAL.Count(objReq);
              return (objResponse);
          }
    }
}
