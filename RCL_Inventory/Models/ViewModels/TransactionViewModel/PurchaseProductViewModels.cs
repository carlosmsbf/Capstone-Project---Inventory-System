using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models.ViewModels
{
    public class PurchaseProductViewModels
    {
        //Helper to show on Transaction View
        [Required]
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public List<Product> ProductsList { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public List<Transaction> TransactionsList { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<Supplier> SuppliersList {get;set;}

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Category> CategoriesList { get; set; }

        public int TransactionTypeId { get; set; }


    }
}
