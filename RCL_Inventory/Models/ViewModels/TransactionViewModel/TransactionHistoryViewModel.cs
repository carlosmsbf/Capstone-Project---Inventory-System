using RCL_Inventory.Models.DBGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models.ViewModels.TransactionViewModel
{
    public class TransactionHistoryViewModel
    {

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public List<Transaction> TransactionsList { get; set; }



        public int TransactionHistoryId { get; set; }
        public TransactionHistory TransactionHistory { get; set; }
        public List<TransactionHistory> TransactionsHistoryList { get; set; }



    }
}
