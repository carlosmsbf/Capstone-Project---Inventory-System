using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCL_Inventory.Models;
using RCL_Inventory.Models.DBGenerator;
using RCL_Inventory.Models.ViewModels.TransactionViewModel;
using Microsoft.AspNetCore.Authorization;

namespace RCL_Inventory.Controllers
{
    [Authorize]
    public class TransactionHistoriesController : Controller
    {
        private readonly InventoryContext _context;

        public TransactionHistoriesController(InventoryContext context)
        {
            _context = context;
        }

        // GET: TransactionHistories
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                var transactions = await _context.Transaction.ToListAsync();
                int TransactionType = id.Value;

                foreach (var transaction in transactions)
                {
                    if (TransactionType == transaction.TransactionTypeId)
                    {
                        var tH = new TransactionHistory()
                        {
                            TransactionId = transaction.TransactionId,
                            TransactionTypeId = transaction.TransactionTypeId,
                            ProductId = transaction.ProductId,
                            Date = DateTime.Today,
                            RegisteredDate = transaction.Date,
                            Quantity = transaction.Quantity,
                            SupplierId = transaction.SupplierId
                        };
                        _context.TransactionHistories.Add(tH);

                        _context.SaveChanges();
                    }
                }
                return RedirectToAction(nameof(Index), "Transactions");
            }


            var transactionList = await _context.Transaction
                 .Include(t => t.Product)
                 .Include(t => t.Product.Category)
                 .Include(t => t.Supplier)
                 .Include(t => t.TransactionType).ToListAsync();

            var transactionHistoryList = await _context.TransactionHistories.ToListAsync();

            TransactionHistoryViewModel thvw = new TransactionHistoryViewModel() {
            
             
                TransactionsList = transactionList,
                TransactionsHistoryList = transactionHistoryList

            };

         
            return View(thvw);
        }

    }
}
