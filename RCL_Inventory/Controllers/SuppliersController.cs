using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCL_Inventory.Models;
using RCL_Inventory.Models.ViewModels.SupplierViewModel;


namespace RCL_Inventory.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SuppliersController : Controller
    {
        private readonly InventoryContext _context;

        public SuppliersController(InventoryContext context)
        {
            _context = context;
        }

        // Method Get to show Supplier Information.
        public async Task<IActionResult> Index()
        {
            var inventoryContext = _context.Suppliers.Include(s => s.Address);
            return View(await inventoryContext.ToListAsync());
        }

        // Method Get of Details Supplier
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .Include(s => s.Address)
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // Method Get of Create Supplier
        public IActionResult Create()
        {


            var suppliers = _context.Suppliers.ToList();
            var addresses = _context.Addresses.ToList();

            SupplierViewModel svm = new SupplierViewModel(){
            SuppliersList = suppliers,
            AddressesList = addresses
            };


            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City");
            return View(svm);
        }

        // Method Post of Create Supplier
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,Name,Telephone,AccountNumber,AddressId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                TempData["success"] = "Information added successfully.";
                return RedirectToAction(nameof(Index));
            }


            var suppliers = _context.Suppliers.ToList();
            var addresses = _context.Addresses.ToList();

            SupplierViewModel svm = new SupplierViewModel()
            {
                SuppliersList = suppliers,
                AddressesList = addresses
            };

            TempData["failed"] = "Failed. Please, select and fill all the fields.";
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", supplier.AddressId);
            return View(svm);
        }

        // Method Get of Edit Supplier
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliers = _context.Suppliers.ToList();
            var addresses = _context.Addresses.ToList();


            var supplier = await _context.Suppliers.FindAsync(id);
            int supplierId = supplier.SupplierId;

            var svm = new SupplierViewModel()
            {
                AddressesList = addresses,
                SuppliersList = suppliers,
                SupplierId = supplierId

            };


            if (svm == null)
            {
                return NotFound();
            }

            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", supplier.AddressId);
            return View(svm);
        }

        // Method Post of Edit Supplier
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,Name,Telephone,AccountNumber,AddressId")] Supplier supplier)
        {

            Supplier supplierContext = new Supplier() {
                SupplierId = id,
                Name = supplier.Name,
                Telephone = supplier.Telephone,
                AccountNumber = supplier.AccountNumber,
                AddressId = supplier.AddressId
            };


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierContext);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplierContext.SupplierId))
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


            var suppliers = _context.Suppliers.ToList();
            var addresses = _context.Addresses.ToList();

            int supplierId = supplier.SupplierId;

            var svm = new SupplierViewModel()
            {
                AddressesList = addresses,
                SuppliersList = suppliers,
                SupplierId = supplierId

            };
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", supplier.AddressId);
            TempData["failed"] = "Failed. Please, select and fill all the fields.";
            return View(svm);
        }

        // Method Get of Delete Supplier
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .Include(s => s.Address)
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // Method Post of Delete Supplier
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            TempData["success"] = "Information delited successfully.";
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        }
    }
}
