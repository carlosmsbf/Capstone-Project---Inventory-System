using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCL_Inventory.Models;
using RCL_Inventory.Models.ViewModels.ViewModelProduct;
using Microsoft.AspNetCore.Authorization;

namespace RCL_Inventory.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly InventoryContext _context;

        public ProductsController(InventoryContext context)
        {
            _context = context;
        }

        // Method Get of Products Information.
        public IActionResult Index()
        {
            var inventoryContext = _context.Products.Include(p => p.Category);
            return View(inventoryContext.ToList());
        }

        // Method Get of Products Details.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Method Get of Create a new Product.
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();

             ProductViewModel ppvw = new ProductViewModel()
            {
                CategoriesList = categories
            };
            return View(ppvw);
        }

        // Method Post of Create a new Product.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Description,Brand,CategoryId")] Product product)
        {

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["success"] = "Information Added successfully.";
                return RedirectToAction(nameof(Index));
            }

            var categories = _context.Categories.ToList();

            ProductViewModel ppvw = new ProductViewModel()
            {
                CategoriesList = categories
            };

            TempData["failed"] = "Failed. Please, select and fill all the fields.";
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(ppvw);
        }

        // Method Get of Edit a Product.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);

            int productId = product.ProductId;
            ProductViewModel pvm = new ProductViewModel()
            {
                CategoriesList = _context.Categories.ToList(),
                ProductId = productId
            };


            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);

            return View(pvm);
        }

        // Method Post of Edit a Product.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Description,Brand,CategoryId")] Product product)
        {

            if (ModelState.IsValid)
            {

                Product productClass = new Product()
                {
                    ProductId = id,
                    CategoryId = product.CategoryId,
                    Name = product.Name,
                    Brand = product.Brand,
                    Description = product.Description
                };


                try
                {
                    _context.Update(productClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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

            ProductViewModel pvm = new ProductViewModel()
            {
                CategoriesList = _context.Categories.ToList(),
                ProductId = id
            };
            TempData["failed"] = "Failed. Please, select and fill all the fields.";
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(pvm);
        }

        // Method Get of Delete a Product.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Method Post of Delete a Product.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            TempData["success"] = "Information deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
