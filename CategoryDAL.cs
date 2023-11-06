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
   public class CategoryDAL
    {
        static string connectionstring = "Data Source=LAPTOP-3V1F4BD2\\SQLEXPRESS;Initial Catalog=PETSTORE;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionstring);
        SqlCommand cmd;
        SqlDataReader dr;

        public CategoryResponse InsertCategory(CategoryRequest objReq)
        {
            con.Open();
            cmd = new SqlCommand("USP_INS_CATEGORY");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CATEGORYNAME", objReq.CategoryName);
            cmd.Parameters.AddWithValue("@CATEGORYDESCRIPTION", objReq.Description);
            int count = cmd.ExecuteNonQuery();
            CategoryResponse objResponse = new CategoryResponse();
            objResponse.status = count;
            return (objResponse);
            con.Close();
        }
    }
}
