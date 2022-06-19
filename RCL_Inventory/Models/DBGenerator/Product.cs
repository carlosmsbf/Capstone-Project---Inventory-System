using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RCL_Inventory.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the Product Name.")]
        [DisplayName("Product Name")]
        [StringLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter the Product Description.")]
        [DisplayName("Product Description")]
        public string Description { get; set; }

        //.....
        [Required(ErrorMessage = "Please insert the Brand of the product.")]
        [DisplayName("Product Brand")]
        public string Brand { get; set; }
        //.....

        [Required(ErrorMessage = "Please choose the Category.")]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }    
        
        public Category Category { get; set; }
    }
}
