using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models.ViewModels.SupplierViewModel
{
    public class SupplierViewModel
    {

        //Helper to show on Supplier View
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<Supplier> SuppliersList { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Address> AddressesList { get; set; }


    }
}
