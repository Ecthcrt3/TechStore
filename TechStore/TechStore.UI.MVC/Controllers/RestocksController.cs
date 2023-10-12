using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechStore.DATA.EF.Models;

namespace TechStore.UI.MVC.Controllers
{
    public class RestocksController : Controller
    {
        private readonly StoreFrontContext _context;

        public RestocksController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: Restocks
        public async Task<IActionResult> Index()
        {
              return _context.Restocks != null ? 
                          View(await _context.Restocks.ToListAsync()) :
                          Problem("Entity set 'StoreFrontContext.Restocks'  is null.");
        }

        // GET: Restocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Restocks == null)
            {
                return NotFound();
            }

            var restock = await _context.Restocks
                .FirstOrDefaultAsync(m => m.RestockLevel == id);
            if (restock == null)
            {
                return NotFound();
            }

            return View(restock);
        }

        // GET: Restocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestockLevel,MinStock,MaxStock")] Restock restock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restock);
        }

        // GET: Restocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Restocks == null)
            {
                return NotFound();
            }

            var restock = await _context.Restocks.FindAsync(id);
            if (restock == null)
            {
                return NotFound();
            }
            return View(restock);
        }

        // POST: Restocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestockLevel,MinStock,MaxStock")] Restock restock)
        {
            if (id != restock.RestockLevel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestockExists(restock.RestockLevel))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restock);
        }

        // GET: Restocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Restocks == null)
            {
                return NotFound();
            }

            var restock = await _context.Restocks
                .FirstOrDefaultAsync(m => m.RestockLevel == id);
            if (restock == null)
            {
                return NotFound();
            }

            return View(restock);
        }

        // POST: Restocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Restocks == null)
            {
                return Problem("Entity set 'StoreFrontContext.Restocks'  is null.");
            }
            var restock = await _context.Restocks.FindAsync(id);
            if (restock != null)
            {
                _context.Restocks.Remove(restock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestockExists(int id)
        {
          return (_context.Restocks?.Any(e => e.RestockLevel == id)).GetValueOrDefault();
        }
    }
}
