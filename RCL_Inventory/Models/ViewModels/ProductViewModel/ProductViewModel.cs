using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models.ViewModels.ViewModelProduct
{
    public class ProductViewModel
    {

        //Helper to show on Product View
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Category> CategoriesList { get; set; }
       
        
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<Product> ProductsList {get;set;}


    }
}
