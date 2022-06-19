using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RCL_Inventory.Models
{
    public class Supplier
    {

        [Key]
        [DisplayName("Supplier ID")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Please, Supplier Name is required.")]
        [DisplayName("Supplier Name")]
        public string Name { get; set; }

        [Required]
        [Range(0000000000, 9999999999, ErrorMessage = "Please, write a number of 10 digits.")]
        [DisplayName("Supplier Telephone")]
        public string Telephone { get; set; }

        [Required]
        [Range(000000000, 999999999, ErrorMessage = "Please, write a number of 9 digits.")]
        [DisplayName("Supplier Account")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage ="Please, select an Address.")]
        [DisplayName("Address ID")]
        public int AddressId { get; set; }
        public Address Address { get; set; }


    }
}
