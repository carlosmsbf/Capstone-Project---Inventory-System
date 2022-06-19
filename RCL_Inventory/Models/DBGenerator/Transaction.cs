using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class Transaction
    {
        [Key]
        [DisplayName("Transaction ID")]
        public int TransactionId { get; set; }
        [DisplayName("Create Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Please, enter a date.")]
        public DateTime Date { get; set; }


        [Required(ErrorMessage ="Please, select product.")]
        [DisplayName("Product ID")]

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Please, enter the product quantity.")]
        public int Quantity { get; set; }
        [DisplayName("Transaction Type ID")]
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        [DisplayName("Supplier ID")]

        [Required(ErrorMessage = "Please, select supplier.")]
        public int SupplierId { get; set;}
        public Supplier Supplier { get; set; }

        public bool Submitted { get; set; }
        
    }
}
