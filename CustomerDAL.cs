using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CustomerDAL
    {
        static string connectionstring = "Data Source=LAPTOP-3V1F4BD2\\SQLEXPRESS;Initial Catalog=PETSTORE;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionstring);
        SqlCommand cmd;
        SqlDataReader dr;
        public CustomerResponse InsertCustomer(CustomerRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_INS_CUSTOMER");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CUSTOMERNAME", objReq.CustomerName);
            cmd.Parameters.AddWithValue("@CUSTOMERADDRESS", objReq.CustomerAddress);
            cmd.Parameters.AddWithValue("@CONTACT", objReq.Contact);
            cmd.Parameters.AddWithValue("@EMAIL", objReq.CustomerEmail);
            cmd.Parameters.AddWithValue("@DOB", objReq.DOB);
            cmd.Parameters.AddWithValue("@CUSTOMERPASSWORD", objReq.CustomerPassword);
            int count = cmd.ExecuteNonQuery();
            CustomerResponse objResponse = new CustomerResponse();
            objResponse.status = count;
            return (objResponse);
            con.Close();
 
        }
                public CustomerResponse GetLoginCredentials(CustomerRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_LOGIN_CREDENTIALS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMAIL", objReq.CustomerEmail);
            cmd.Parameters.AddWithValue("@CUSTOMERPASSWORD", objReq.CustomerPassword);
            dr = cmd.ExecuteReader();
            CustomerResponse objResponse = new CustomerResponse();
            if (dr.Read())
            {
                objResponse.CustomerName = dr["CUSTOMERNAME"].ToString();
                objResponse.CustomerID = Convert.ToInt32(dr["CUSTOMERID"]);
                objResponse.status = 1;
            }
                    else
            {
                objResponse.status = -1;
            }
            dr.Close();
            con.Close();
            return (objResponse);
        }
                public List<CustomerOResponse> GetOrderHistory(CustomerORequest objReq)
                {
                    con.Open();
                    cmd = new SqlCommand("USP_GET_ORDER_HISTORY");
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CUSTOMERID", objReq.CustomerID);
                    dr = cmd.ExecuteReader();
                    List<CustomerOResponse> objResponse = new List<CustomerOResponse>();
                    while (dr.Read())
                    {
                        CustomerOResponse objRes = new CustomerOResponse();
                        objRes.OrderID =Convert.ToInt32(dr["ORDERID"]);
                        objRes.Orderdate = dr["ORDERDATE"].ToString();
                        objRes.ProductName = dr["PRODUCTNAME"].ToString();
                        objRes.ProductPrice = Convert.ToInt32(dr["PRODUCTPRICE"]);
                        objRes.Quantity = Convert.ToInt32(dr["QUANTITY"]);
                        objResponse.Add(objRes);
                      
                    }
          
                    dr.Close();
                    con.Close();
                    return (objResponse);
                }
               

    }
}
