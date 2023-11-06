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
    public class SupplierDAL
    {
        static string connectionstring = "Data Source=LAPTOP-3V1F4BD2\\SQLEXPRESS;Initial Catalog=PETSTORE;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionstring);
        SqlCommand cmd;
        SqlDataReader dr;

        public SupplierResponse InsertSupplier(SupplierRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_INS_SUPPLIER");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUPPLIERNAME", objReq.SupplierName);
            cmd.Parameters.AddWithValue("@SUPPLIERADDRESS", objReq.SupplierAddress);
            cmd.Parameters.AddWithValue("@SUPPLIERCONTACT", objReq.SupplierContact);
            cmd.Parameters.AddWithValue("@SUPPLIEREMAIL", objReq.SupplierEmail);
            cmd.Parameters.AddWithValue("@SUPPLIERPASSWORD", objReq.SupplierPassword);
            int count = cmd.ExecuteNonQuery();
            SupplierResponse objResponse = new SupplierResponse();
            objResponse.status = count;
            return (objResponse);
            con.Close();
        }
        public SupplierResponse GetSupplierCredentials(SupplierRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_SUPPLIER_CREDENTIALS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUPPLIEREMAIL", objReq.SupplierEmail);
            cmd.Parameters.AddWithValue("@SUPPLIERPASSWORD", objReq.SupplierPassword);
            dr = cmd.ExecuteReader();
            SupplierResponse objResponse = new SupplierResponse();
            if (dr.Read())
            {
                objResponse.SupplierName = dr["SUPPLIERNAME"].ToString();
                objResponse.SupplierID = Convert.ToInt32(dr["SUPPLIERID"]);
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
        public List<SupplierOResponse> GetSupplierOrders(SupplierORequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_SUPPLIER_ORDERS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUPPLIERID", objReq.SupplierID);
            dr = cmd.ExecuteReader();
            List<SupplierOResponse> objResponse = new List<SupplierOResponse>();
            while (dr.Read())
            {
                SupplierOResponse objGetProduct = new SupplierOResponse();
                objGetProduct.productID = Convert.ToInt32(dr["PRODUCTID"]);
                objGetProduct.ProductName = dr["PRODUCTNAME"].ToString();
                objGetProduct.CustomerName = dr["CUSTOMERNAME"].ToString();
                objResponse.Add(objGetProduct);

            }
            dr.Close();
            con.Close();

            return (objResponse);
        }
        public List<SupplierRes> GetSupplierproducts(SupplierReq objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_PRODUCTS_BY_SUPPLIER");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUPPLIERID", objReq.ProductSID);
            dr = cmd.ExecuteReader();
            List<SupplierRes> objResponse = new List<SupplierRes>();
            while (dr.Read())
            {
                SupplierRes objGetProduct = new SupplierRes();
                objGetProduct.ProductID = Convert.ToInt32(dr["PRODUCTID"]);
                objGetProduct.ProductName = dr["PRODUCTNAME"].ToString();
                objGetProduct.SupplierName = dr["SUPPLIERNAME"].ToString();
                objGetProduct.ProductPrice = Convert.ToInt32(dr["PRODUCTPRICE"]);
                objGetProduct.ProductStock = Convert.ToInt32(dr["STOCK"]);
                objGetProduct.ProductSID = Convert.ToInt32(dr["SUPPLIERID"]);
                objGetProduct.ProductCID = Convert.ToInt32(dr["CATEGORYID"]);
                objGetProduct.Description = dr["PRODUCTDESCRIPTION"].ToString();
                objGetProduct.ProductImage = dr["PRODUCTIMAGE"].ToString();
                objResponse.Add(objGetProduct);

            }
            dr.Close();
            con.Close();

            return (objResponse);
        }

    }
}
