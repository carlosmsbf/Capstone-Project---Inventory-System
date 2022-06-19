using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter the Category Name.")]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write a Description for the Category.")]
        [DisplayName("Category Description")]
        public string Description { get; set; }


    }
}
