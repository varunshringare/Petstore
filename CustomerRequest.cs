﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class CustomerRequest:BaseRequest
    {
       public string CustomerName { get; set; }
       public string CustomerEmail { get; set; }
       public string CustomerAddress { get; set; }
       public string Contact { get; set; }
       public string DOB { get; set; }
       public int CustomerID { get; set; }
       public string CustomerPassword { get; set; }
    }
    public class CustomerORequest:BaseRequest
    {
        public int CustomerID { get; set; }
        public int OrderID{get;set;}
        public string Orderdate{get;set;}
        public string ProductName{get;set;}
        public int Quantity{get;set;}
        public int ProductPrice{get;set;}
    }
}
