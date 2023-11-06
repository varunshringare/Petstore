using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BAL
{
    public class CategoryBAL
    {
            public CategoryResponse InsertCategory(CategoryRequest objReq)
            {
                CategoryDAL objCatDAL = new CategoryDAL();
                CategoryResponse objResponse = objCatDAL.InsertCategory(objReq);
                return (objResponse);
            }
    }
}
