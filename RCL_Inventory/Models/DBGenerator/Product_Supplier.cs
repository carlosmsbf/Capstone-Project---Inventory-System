using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models.DBGenerator
{
    public class Product_Supplier
    {
        public int Product_SupplierID { get; set; }

        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }


        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
