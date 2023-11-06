using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CartDAL
    {
        static string connectionstring = "Data Source=LAPTOP-3V1F4BD2\\SQLEXPRESS;Initial Catalog=PETSTORE;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionstring);
        SqlCommand cmd;
        SqlDataReader dr;

        public CartResponse InsertIntoCart(CartRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_INS_CART");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PRODUCTID", objReq.ProductId);
            cmd.Parameters.AddWithValue("@CUSTOMERID", objReq.CustomerId);
            cmd.Parameters.AddWithValue("@QUANTITY", objReq.Quantity);
            int count = cmd.ExecuteNonQuery();
            CartResponse objResponse = new CartResponse();
            objResponse.status = count;
            return (objResponse);
            con.Close();
        }
        public List<CartResponse> GetCartItems(CartRequest objRequest)
        {
             con.Open();
            cmd = new SqlCommand("USP_GET_CART_ITEMS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CUSTOMERID", objRequest.CustomerId);
            SqlParameter objParameter = cmd.Parameters.Add("ORDERAMOUNT",SqlDbType.Int);
            objParameter.Direction = ParameterDirection.Output;
            dr = cmd.ExecuteReader();
            List<CartResponse> objResponse = new List<CartResponse>();
            while (dr.Read())
            {
                CartResponse objGetProduct = new CartResponse();           
                objGetProduct.ProductName = dr["PRODUCTNAME"].ToString();
                objGetProduct.CartId = Convert.ToInt32(dr["CARTID"]);
                objGetProduct.ProductId = Convert.ToInt32(dr["PRODUCTID"]);
                objGetProduct.ProductPrice = Convert.ToInt32(dr["PRODUCTPRICE"]);
                objGetProduct.Quantity = Convert.ToInt32(dr["QUANTITY"]);
                objGetProduct.TotalAmount = Convert.ToInt32(dr["TOTAL"]);
                objGetProduct.ProductImage = dr["PRODUCTIMAGE"].ToString();
                objGetProduct.Stock = Convert.ToInt32(dr["STOCK"]);
                objResponse.Add(objGetProduct);
            }
            dr.Close();
           //int OdrAmt =Convert.ToInt32(cmd.Parameters["@ORDERAMOUNT"].Value);
            con.Close();
            return (objResponse);
        }
        public CartResponse DeleteProduct(CartRequest objRequest)
        {
            con.Open();
            cmd = new SqlCommand("USP_DELETE_FROM_CART");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CART_ID", objRequest.CartId);
            int count = cmd.ExecuteNonQuery();
            CartResponse objResponse = new CartResponse();
            objResponse.Status = count;
            return (objResponse);
        }
        public CartResponse UpdateCart(CartRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_UPDATE_QUANTITY");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CARTID", objReq.CartId);
            cmd.Parameters.AddWithValue("@QUANTITY", objReq.Quantity);
            int count = cmd.ExecuteNonQuery();
            CartResponse objResponse = new CartResponse();
            objResponse.status = count;
            return (objResponse);
            con.Close();
        }
        public CartResponse Count(CartRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_COUNT_CART_ITEMS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CUSTOMERTID", objReq.CartId);
            cmd.Parameters.Add(new SqlParameter("@ITEMCOUNT", SqlDbType.Int));
            cmd.Parameters["@ITEMCOUNT"].Direction = ParameterDirection.Output;
            int count = cmd.ExecuteNonQuery();
            CartResponse objResponse = new CartResponse();
            objResponse.status = count;
            return (objResponse);
            con.Close();
        }
    }
}
