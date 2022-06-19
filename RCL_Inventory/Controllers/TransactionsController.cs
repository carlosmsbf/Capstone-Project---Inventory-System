using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCL_Inventory.Models;
using RCL_Inventory.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace RCL_Inventory.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly InventoryContext _context;

        public TransactionsController(InventoryContext context)
        {
            _context = context;
        }



        // Method Get to show Transaction Information.
        [HttpGet]
        public async Task<IActionResult> Index()
        {


            var transaction = await _context.Transaction
                .Include(t => t.Product)
                 .Include(t => t.Product.Category)
                .Include(t => t.Supplier)
                .Include(t => t.TransactionType).ToListAsync();

            var products = _context.Products.Include(t => t.Category).ToList(); ;
            var suppliers = _context.Suppliers.Include(t => t.Address).ToList();
            var categories = _context.Categories.ToList();
            var transactions = _context.Transaction.Include(t=>t.TransactionType).ToList();

            PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                CategoriesList = categories,
                TransactionsList = transaction,
                
            };



            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name");

            return View(ppvw);
        }

        // Method Post to filter and show Transaction Information accourding with the Transaction Type.
        [HttpPost]
        public async Task<IActionResult> Index(int? id)
        { 

            var transaction = _context.Transaction
          .Include(t => t.Product)
           .Include(t => t.Product.Category)
          .Include(t => t.Supplier)
          .Include(t => t.TransactionType).Where(t => t.TransactionTypeId == id.Value).ToList();

            List<Transaction> transactionFilter = new List<Transaction>();
     

            var products = await _context.Products.Include(t => t.Category).ToListAsync();
            var suppliers = await _context.Suppliers.Include(t => t.Address).ToListAsync();
            var categories = await _context.Categories.ToListAsync();

           PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                CategoriesList = categories,
                TransactionsList = transaction,
                TransactionTypeId = id.Value
            };


            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name");

            return View("Index",ppvw);
        }


        // Method Get of Details Transaction
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Product)
                 .Include(t => t.Product.Category)
                .Include(t=>t.Supplier)
                .Include(t => t.TransactionType)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }


        // Method Get of Create a new Transaction
        [HttpGet]
        public IActionResult CreatePurchase(int? id)
        {
            var products = _context.Products.Include(t => t.Category).ToList(); ;
            var suppliers = _context.Suppliers.Include(t => t.Address).ToList();
            var categories = _context.Categories.ToList();



            PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                CategoriesList = categories,
                TransactionTypeId = id.Value

            };
            return View(ppvw);
        }


        // Method Post of Create a new Transaction
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePurchase(int id,[Bind("TransactionId,Date,ProductId,Quantity,TransactionTypeId,SupplierId")] Transaction transaction)
        {

            




            if (ModelState.IsValid)
            {
                var productId = transaction.ProductId;

                var productContext = _context.Products.Find(productId);

                int categoryInt = productContext.CategoryId;


                Transaction transactionContext = new Transaction()
                {
                    Date = transaction.Date,
                    ProductId = transaction.ProductId,
                    Quantity = transaction.Quantity,
                    TransactionTypeId = id,
                    SupplierId = transaction.SupplierId,
                    Submitted = false
                };



                _context.Add(transactionContext);
                await _context.SaveChangesAsync();
                TempData["success"] = "Information added successfully.";
                return RedirectToAction(nameof(Index));
            }

            var products = _context.Products.Include(t => t.Category).ToList(); ;
            var suppliers = _context.Suppliers.Include(t => t.Address).ToList();
            var categories = _context.Categories.ToList();



            PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                CategoriesList = categories,
                TransactionTypeId = id

            };


            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", transaction.ProductId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", transaction.TransactionTypeId);
            TempData["failed"] = "Failed. Please, select and fill all the fields.";
            return View(ppvw);
        }


        // Method Get of Edit a Transaction
        public async Task<IActionResult> Edit(int? id)
        {
            var products = await _context.Products.Include(t => t.Category).ToListAsync();
            var suppliers = await _context.Suppliers.Include(t => t.Address).ToListAsync();
            var transaction = await _context.Transaction.FindAsync(id);

            int transactionId = transaction.TransactionId;
            int transactionTypeId = transaction.TransactionTypeId;
            var ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                TransactionId = transactionId,
                TransactionTypeId = transactionTypeId

            };
            return View(ppvw);
           
        }

        // Method Post of Edit a Transaction
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,Date,ProductId,Quantity,TransactionTypeId,SupplierId")] Transaction transaction)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var productId = transaction.ProductId;

                    var productContext = _context.Products.Find(productId);

                    int categoryInt = productContext.CategoryId;

                    Transaction transactionContext = new Transaction()
                    {
                        Date = transaction.Date,
                        ProductId = transaction.ProductId,
                        Quantity = transaction.Quantity,
                        TransactionTypeId = transaction.TransactionTypeId,
                        SupplierId = transaction.SupplierId,
                        TransactionId = id

                    };

                    _context.Update(transactionContext);
                    await _context.SaveChangesAsync();          
                }
                catch (DbUpdateConcurrencyException)
                {

                    var productId = transaction.ProductId;

                    var productContext = _context.Products.Find(productId);

                    int categoryInt = productContext.CategoryId;

                    Transaction transactionContext = new Transaction()
                    {
                        Date = transaction.Date,
                        ProductId = transaction.ProductId,
                        Quantity = transaction.Quantity,
                        TransactionTypeId = transaction.TransactionTypeId,
                        SupplierId = transaction.SupplierId,
                        TransactionId = id

                    };


                    if (!TransactionExists(transactionContext.TransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "Information edited successfully.";
                return RedirectToAction(nameof(Index));
            }

            var products = await _context.Products.Include(t => t.Category).ToListAsync();
            var suppliers = await _context.Suppliers.Include(t => t.Address).ToListAsync();
            var transactionHolder = await _context.Transaction.FindAsync(id);

            int transactionId = transactionHolder.TransactionId;
            int transactionTypeId = transaction.TransactionTypeId;
            var ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                TransactionId = transactionId,
                TransactionTypeId = transactionTypeId

            };


            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", transaction.ProductId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", transaction.TransactionTypeId);
            return View(ppvw);
        }

        // 
        // Method Get of Delete a Transaction
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Product)
                .Include(t => t.Product.Category)
                .Include(t=>t.Supplier)
                .Include(t => t.TransactionType)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }


        // Method Post of Delete a Transaction
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            TempData["success"] = "Information deleted successfully.";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult SubmitTransactions(int id)
        {

            int tId;
            var transactions = _context.Transaction.ToList();

            foreach (var transaction in transactions)
            {
                tId = transaction.TransactionId;

                if (transaction.Submitted == false && transaction.TransactionTypeId == id)
                {

                    var transactionContext = _context.Transaction.Find(transaction.TransactionId);

                    Transaction transactionView = new Transaction()
                    {
                        TransactionId = 9999,
                        Date = transactionContext.Date,
                        Quantity = transactionContext.Quantity,
                        SupplierId = transactionContext.SupplierId,
                        ProductId = transactionContext.ProductId,
                        TransactionTypeId = transactionContext.TransactionTypeId,
                        Submitted = true
                    };
                    var nova = transactionView;

                            _context.Update(nova);



                    Transaction newTransaction = new Transaction()
                    {
                        TransactionId = tId,
                        Date = transactionContext.Date,
                        Quantity = transactionContext.Quantity,
                        SupplierId = transactionContext.SupplierId,
                        ProductId = transactionContext.ProductId,
                        TransactionTypeId = transactionContext.TransactionTypeId,
                        Submitted = true
                    };
                    _context.Update(newTransaction);
                    _context.SaveChanges();


                }
            }
            return RedirectToAction(nameof(Index), "TransactionHistories", id);
        }
        




        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}
