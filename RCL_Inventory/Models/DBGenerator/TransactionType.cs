using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RCL_Inventory.Models
{
    public class TransactionType
    {
       [Key]
        [DisplayName("Transaction Type ID")]
        public int TransactionTypeId { get; set; }
        [Required(ErrorMessage = "Please, need to write Country Name.")]
        [DisplayName("Transaction Type")]
        public string Name { get; set; }

    }
}
