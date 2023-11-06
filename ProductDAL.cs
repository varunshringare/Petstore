using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;
using System.Data;
using ELogging;

namespace DAL
{
   public class ProductDAL
    {
        static string connectionstring = "Data Source=LAPTOP-3V1F4BD2\\SQLEXPRESS;Initial Catalog=PETSTORE;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionstring);
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductResponse InsertProduct(productRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_INS_PRODUCTS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PRODUCTNAME", objReq.ProductName);
            cmd.Parameters.AddWithValue("@PRODUCTPRICE", objReq.Money);
            cmd.Parameters.AddWithValue("@PRODUCTDESCRIPTION", objReq.Description);
            cmd.Parameters.AddWithValue("@STOCK", objReq.stock);
            cmd.Parameters.AddWithValue("@PRODUCTIMAGE", objReq.Imagesrc);
            cmd.Parameters.AddWithValue("@CATEGORYID", objReq.CategoryId);
            cmd.Parameters.AddWithValue("@SUPPLIERID", objReq.SupplierId);
            int count = cmd.ExecuteNonQuery();
            ProductResponse objResponse = new ProductResponse();
            objResponse.status = count;
            return (objResponse);
            con.Close();
        }
        public ProductResponse UpdateSupplierProduct(productRequest objRequest)
        {
            con.Open();
            cmd = new SqlCommand("USP_UPDATE_SUPPLIER_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PRODUCTID", objRequest.ProductId);
            cmd.Parameters.AddWithValue("@PRODUCTNAME", objRequest.ProductName);
            cmd.Parameters.AddWithValue("@PRODUCTDESCRIPTION", objRequest.Description);
            cmd.Parameters.AddWithValue("@PRODUCTPRICE", objRequest.Money);
            cmd.Parameters.AddWithValue("@PRODUCTSTOCK", objRequest.stock);
            cmd.Parameters.AddWithValue("@PRODUCTIMAGE", objRequest.Imagesrc);
            cmd.Parameters.AddWithValue("@SUPPLIERID", objRequest.SupplierId);
            cmd.Parameters.AddWithValue("@CATEGORYID", objRequest.CategoryId);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            ProductResponse objResponse = new ProductResponse();
            objResponse.status = count;
            return (objResponse);

        }
        public List<ProductResponse> GetAll()
        {
            con.Open();
            cmd = new SqlCommand("USP_GET_ALLPRODUCTS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            List<ProductResponse> objResponse = new List<ProductResponse>();
            while (dr.Read())
            {
                ProductResponse objGetProduct = new ProductResponse();
                objGetProduct.ProductId = Convert.ToInt32(dr["PRODUCTID"]);
                objGetProduct.ProductName = dr["PRODUCTNAME"].ToString();
                objGetProduct.Money = Convert.ToInt32(dr["PRODUCTPRICE"]);
                objGetProduct.Description = dr["PRODUCTDESCRIPTION"].ToString();
                objGetProduct.stock = Convert.ToInt32(dr["STOCK"]);
                objGetProduct.Imagesrc = dr["PRODUCTIMAGE"].ToString();
                objGetProduct.CategoryId = Convert.ToInt32(dr["CATEGORYID"]);
                objGetProduct.SupplierId = Convert.ToInt32(dr["SUPPLIERID"]);
                objResponse.Add(objGetProduct);


            }
            dr.Close();
            con.Close();
            return (objResponse);
        }
       public decimal CalculateTotalPrice(int customerId)
{
    con.Open();
    cmd = new SqlCommand("SELECT SUM(P.PRODUCTPRICE * C.QUANTITY) AS TotalPrice " +
                         "FROM CART C " +
                         "INNER JOIN PRODUCTS P ON C.PRODUCTID = P.PRODUCTID " +
                         "WHERE C.CUSTOMERID = @CustomerId");
    cmd.Connection = con;
    cmd.Parameters.AddWithValue("@CustomerId", customerId);
    object result = cmd.ExecuteScalar();
    con.Close();

    if (result != null && result != DBNull.Value)
    {
        return Convert.ToDecimal(result);
    }

    return 0;
}

        public ProductResponse GetAllProductsBYID(productRequest objRequest)
        {
            ProductResponse objResponse = new ProductResponse();
            try
            {
                con.Open();
                cmd = new SqlCommand("USP_GET_PRODUCT_BYID");
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PRODUCTID", objRequest.ProductId);
                dr = cmd.ExecuteReader();             
                if (dr.Read())
                {
                    objResponse.ProductId = Convert.ToInt32(dr["PRODUCTID"]);
                    objResponse.ProductName = dr["PRODUCTNAME"].ToString();
                    objResponse.Money = Convert.ToInt32(dr["PRODUCTPRICE"]);
                    objResponse.Description = dr["PRODUCTDESCRIPTION"].ToString();
                    objResponse.stock = Convert.ToInt32(dr["STOCK"]);
                    objResponse.Imagesrc = dr["PRODUCTIMAGE"].ToString();
                    objResponse.CategoryId = Convert.ToInt32(dr["CATEGORYID"]);
                    objResponse.SupplierId = Convert.ToInt32(dr["SUPPLIERID"]);
                    objResponse.SupplierName = dr["SUPPLIERNAME"].ToString();
                }
                dr.Close();
                con.Close();
            }
            catch(Exception e)
                {
                    LogManager.Log(e);
                    throw;
                }
            return (objResponse);
        }
       public List<ProductResponse> GetSearchProduct(string SearchTerm)
        {
            con.Open();
            cmd = new SqlCommand("USP_SEARCH_PRODUCTS");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SEARCH_TERM", SearchTerm);
            dr = cmd.ExecuteReader();
            List<ProductResponse> objResponse = new List<ProductResponse>();
            while (dr.Read())
            {
                ProductResponse Product = new ProductResponse();
                {
                  Product.ProductId = Convert.ToInt32(dr["PRODUCTID"]);
                    Product.ProductName = dr["PRODUCTNAME"].ToString();
                   Product.Money = Convert.ToInt32(dr["PRODUCTPRICE"]);
                   Product.Description = dr["PRODUCTDESCRIPTION"].ToString();
                   Product.stock = Convert.ToInt32(dr["STOCK"]);
                    Product.Imagesrc = dr["PRODUCTIMAGE"].ToString();
                    Product.CategoryId = Convert.ToInt32(dr["CATEGORYID"]);
                    Product.SupplierId = Convert.ToInt32(dr["SUPPLIERID"]);
                    Product.SupplierName = dr["SUPPLIERNAME"].ToString();
                };
                objResponse.Add(Product);
            }
            return objResponse;
            dr.Close();
            con.Close();
        }
       
    }

}
