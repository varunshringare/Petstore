using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;
using System.Data;


namespace DAL
{
    public class AdminDAL
    {
        static string connectionstring = "Data Source=LAPTOP-3V1F4BD2\\SQLEXPRESS;Initial Catalog=PETSTORE;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionstring);
        SqlCommand cmd;
        SqlDataReader dr;

        public List<AdminResponse> GetCustomerDetails(AdminRequest objRequest)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_CUSTOMER_DETAILS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@EMAIL", objRequest.CustomerEmail);
            dr = cmd.ExecuteReader();
            List<AdminResponse> objResponse = new List<AdminResponse>();
            while (dr.Read())
            {
                AdminResponse objGetProduct = new AdminResponse();
                objGetProduct.CustomerName = dr["CUSTOMERNAME"].ToString();
                objGetProduct.CustomerAddress = dr["CUSTOMERADDRESS"].ToString();
                objGetProduct.CustomerEmail = dr["EMAIL"].ToString();
                objGetProduct.DOB =Convert.ToDateTime(dr["DOB"]).ToString("dd-MM-yyyy");
                objGetProduct.Contact = dr["CONTACT"].ToString();
                objGetProduct.CustomerID = Convert.ToInt32(dr["CUSTOMERID"]);
                objResponse.Add(objGetProduct);
            }
            dr.Close();
            con.Close();
            return (objResponse);
        }
        public List<AdminResponse> GetSearch(string SearchTerm)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_CUSTOMER_SEARCH_DETAILS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SEARCH", SearchTerm);
            dr = cmd.ExecuteReader();
            List<AdminResponse> objResponse = new List<AdminResponse>();
            while (dr.Read())
            {
                AdminResponse objGetProduct = new AdminResponse();
                objGetProduct.CustomerName = dr["CUSTOMERNAME"].ToString();
                objGetProduct.CustomerAddress = dr["CUSTOMERADDRESS"].ToString();
                objGetProduct.CustomerEmail = dr["EMAIL"].ToString();
                objGetProduct.DOB = Convert.ToDateTime(dr["DOB"]).ToString("dd-MM-yyyy");
                objGetProduct.Contact = dr["CONTACT"].ToString();
                objGetProduct.CustomerID = Convert.ToInt32(dr["CUSTOMERID"]);
                objResponse.Add(objGetProduct);
            }
            return objResponse;
            dr.Close();
            con.Close();
        }
        public List<AdminCustomerResponse> GetSupplierDetails(AdminCustomerRequest objRequest)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_SUPPLIER_DETAILS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@EMAIL", objRequest.CustomerEmail);
            dr = cmd.ExecuteReader();
            List<AdminCustomerResponse> objResponse = new List<AdminCustomerResponse>();
            while (dr.Read())
            {
                AdminCustomerResponse objGetProduct = new AdminCustomerResponse();
                objGetProduct.SupplierName = dr["SUPPLIERNAME"].ToString();
                objGetProduct.SupplierAddress = dr["SUPPLIERADDRESS"].ToString();
                objGetProduct.SupplierContact = dr["SUPPLIERCONTACT"].ToString();
                objGetProduct.SupplierEmail = dr["SUPPLIEREMAIL"].ToString();
                objGetProduct.supplierID = Convert.ToInt32(dr["SUPPLIERID"]);
                objResponse.Add(objGetProduct);
            }
            dr.Close();
            con.Close();
            return (objResponse);
        }
        public List<AdminProductResponse> GetProductDetails(AdminProductRequest objRequest)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_ALLPRODUCT_DETAILS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@EMAIL", objRequest.CustomerEmail);
            dr = cmd.ExecuteReader();
            List<AdminProductResponse> objResponse = new List<AdminProductResponse>();
            while (dr.Read())
            {
                AdminProductResponse objGetProduct = new AdminProductResponse();
                objGetProduct.ProductID = Convert.ToInt32(dr["PRODUCTID"]);
                objGetProduct.ProductName = dr["PRODUCTNAME"].ToString();
                objGetProduct.ProductPrice = Convert.ToInt32(dr["PRODUCTPRICE"]);
                objGetProduct.ProductStock = Convert.ToInt32(dr["STOCK"]);
                objGetProduct.ProductSID = Convert.ToInt32(dr["SUPPLIERID"]);
                objGetProduct.ProductCID = Convert.ToInt32(dr["CATEGORYID"]);
                objGetProduct.catogoryName = dr["CATEGORYNAME"].ToString();
                objResponse.Add(objGetProduct);
            }
            dr.Close();
            con.Close();
            return (objResponse);
        }
        public List<AdminCategoryResponse> GetCategoryDetails(AdminCategoryRequest objRequest)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_CATEGORY_DETAILS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@EMAIL", objRequest.CustomerEmail);
            dr = cmd.ExecuteReader();
            List<AdminCategoryResponse> objResponse = new List<AdminCategoryResponse>();
            while (dr.Read())
            {
                AdminCategoryResponse objGetProduct = new AdminCategoryResponse();
                objGetProduct.CategoryID = Convert.ToInt32(dr["CATEGORYID"]);
                objGetProduct.CategoryName = dr["CATEGORYNAME"].ToString();
                objGetProduct.CatDescription = dr["CATEGORYDESCRIPTION"].ToString();
                objResponse.Add(objGetProduct);
            }
            dr.Close();
            con.Close();
            return (objResponse);
        }
        public List<AdminOrderResponse> GetOrderDetails(AdminOrderRequest objRequest)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_ORDER_DETAILS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            List<AdminOrderResponse> objResponse = new List<AdminOrderResponse>();
            while (dr.Read())
            {
                AdminOrderResponse objGetProduct = new AdminOrderResponse();
                objGetProduct.orderID = Convert.ToInt32(dr["ORDERID"]);
                objGetProduct.CustomerID = Convert.ToInt32(dr["CUSTOMERID"]);
                objGetProduct.CustomerName = dr["CUSTOMERNAME"].ToString();
                objGetProduct.OrderDate = dr["ORDERDATE"].ToString();
                objResponse.Add(objGetProduct);
            }
            dr.Close();
            con.Close();
            return (objResponse);
        }
        public AdminLoginResponse GetAdminLogin(AdminLoginRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_ADMIN_LOGIN");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ADMINNAME", objReq.AdminName);
            cmd.Parameters.AddWithValue("@ADMINPASSWORD", objReq.AdminPassword);
            dr = cmd.ExecuteReader();
            AdminLoginResponse objResponse = new AdminLoginResponse();
            if (dr.Read())
            {
               
                objResponse.AdminID = Convert.ToInt32(dr["ADMINID"]);
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
    }
}
