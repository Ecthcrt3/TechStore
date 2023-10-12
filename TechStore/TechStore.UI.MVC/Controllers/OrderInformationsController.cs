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
    public class OrderInformationsController : Controller
    {
        private readonly StoreFrontContext _context;

        public OrderInformationsController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: OrderInformations
        public async Task<IActionResult> Index()
        {
            var storeFrontContext = _context.OrderInformations.Include(o => o.Order);
            return View(await storeFrontContext.ToListAsync());
        }

        // GET: OrderInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderInformations == null)
            {
                return NotFound();
            }

            var orderInformation = await _context.OrderInformations
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderInformationId == id);
            if (orderInformation == null)
            {
                return NotFound();
            }

            return View(orderInformation);
        }

        // GET: OrderInformations/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: OrderInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderInformationId,ProductId,OrderId,Quantity")] OrderInformation orderInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderInformation.OrderId);
            return View(orderInformation);
        }

        // GET: OrderInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderInformations == null)
            {
                return NotFound();
            }

            var orderInformation = await _context.OrderInformations.FindAsync(id);
            if (orderInformation == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderInformation.OrderId);
            return View(orderInformation);
        }

        // POST: OrderInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderInformationId,ProductId,OrderId,Quantity")] OrderInformation orderInformation)
        {
            if (id != orderInformation.OrderInformationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderInformationExists(orderInformation.OrderInformationId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderInformation.OrderId);
            return View(orderInformation);
        }

        // GET: OrderInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderInformations == null)
            {
                return NotFound();
            }

            var orderInformation = await _context.OrderInformations
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderInformationId == id);
            if (orderInformation == null)
            {
                return NotFound();
            }

            return View(orderInformation);
        }

        // POST: OrderInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderInformations == null)
            {
                return Problem("Entity set 'StoreFrontContext.OrderInformations'  is null.");
            }
            var orderInformation = await _context.OrderInformations.FindAsync(id);
            if (orderInformation != null)
            {
                _context.OrderInformations.Remove(orderInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderInformationExists(int id)
        {
          return (_context.OrderInformations?.Any(e => e.OrderInformationId == id)).GetValueOrDefault();
        }
    }
}
