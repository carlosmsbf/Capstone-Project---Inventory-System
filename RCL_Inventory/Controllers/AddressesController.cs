using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCL_Inventory.Models;

namespace RCL_Inventory.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddressesController : Controller
    {
        private readonly InventoryContext _context;

        public AddressesController(InventoryContext context)
        {
            _context = context;
        }

        // Method Get to show Address Information.
        public async Task<IActionResult> Index()
        {
            return View(await _context.Addresses.ToListAsync());
        }


        // Method Get of Details Address.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }


        // Method Get of Create a new Address.
        public IActionResult Create()
        {
            return View();
        }

        // Method Post of Create a new Address.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressId,Country,City,Province,PostalCode,Street")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                TempData["success"] = "Information Added successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["failed"] = "Failed. Please, select and fill all the fields.";
            return View(address);
        }

        // Method Get of Edit Address.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // Method Post of Edit Address.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,Country,City,Province,PostalCode,Street")] Address address)
        {
            if (id != address.AddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.AddressId))
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
            TempData["failed"] = "Failed. Please, fill all the fields.";
            return View(address);
        }

        // Method Get of Delete Address.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // Method Post of Delete Address.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            TempData["success"] = "Information deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressId == id);
        }
    }
}
