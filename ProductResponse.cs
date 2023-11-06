﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductResponse:BaseResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Money { get; set; }
        public string Description { get; set; }
        public int stock { get; set; }
        public string Imagesrc { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }

    }
}
