using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models.DBGenerator
{
    public class TransactionHistory
    {

        [Key]
        [DisplayName("Transaction History ID")]
        public int TransactionHistoryId { get; set; }

        [DisplayName("Transaction ID")]
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        [DisplayName("Product ID")]
        public int ProductId { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Transaction Type ID")]
        public int TransactionTypeId { get; set; }
        [DisplayName("Supplier ID")]
        public int SupplierId { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }


        [DisplayName("Registered Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RegisteredDate { get; set; }






    }
}
