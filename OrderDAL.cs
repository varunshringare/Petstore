using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;
using DAL;
using System.Configuration;

namespace DAL
{
    public class OrderDAL
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["petstoreConnectionString"].ToString();
        SqlConnection con = new SqlConnection(connectionstring);
        SqlCommand cmd;
        SqlDataReader dr;

        public OrderResponse PlaceOrder(Orderrequest objRequest)
        {
            con.Open();
            cmd = new SqlCommand("USP_PLACE_ORDER",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CUSTOMERID", objRequest.CustomerID);
            SqlParameter objParameter = cmd.Parameters.Add("@ORDERID", SqlDbType.Int);
            objParameter.Direction = ParameterDirection.Output;
            int count = cmd.ExecuteNonQuery();
            OrderResponse objResponse = new OrderResponse();
            objResponse.OrderID = Convert.ToInt32(cmd.Parameters["@ORDERID"].Value);
            objResponse.status = count;
            return (objResponse);
            con.Close();
        }
        public List<OrderSResponse> GetOrderSummary(OrderSRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_ORDER_SUMMARY");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ORDERID", objReq.OrderID);
            dr = cmd.ExecuteReader();
            List<OrderSResponse> objResponse = new List<OrderSResponse>();
            while (dr.Read())
            {
                OrderSResponse objRes = new OrderSResponse();
                objRes.OrderDate = dr["ORDERDATE"].ToString();
                objRes.ProductName = dr["PRODUCTNAME"].ToString();
                objRes.ProductPrice = Convert.ToInt32(dr["PRODUCTPRICE"]);
                objRes.Quantity = Convert.ToInt32(dr["QUANTITY"]);
                objRes.ProductImage = dr["PRODUCTIMAGE"].ToString();
                objResponse.Add(objRes);

            }

            dr.Close();
            con.Close();
            return (objResponse);
        }
    }
}
