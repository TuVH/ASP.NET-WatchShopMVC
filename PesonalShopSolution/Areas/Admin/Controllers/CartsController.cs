using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PesonalShopSolution.Areas.Admin.Data;
using PesonalShopSolution.Areas.Admin.Models;

namespace PesonalShopSolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Carts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cart.Include(c => c.IdProductNavigation).Include(c => c.IdUserNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.IdProductNavigation)
                .Include(c => c.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Admin/Carts/Create
        public IActionResult Create()
        {
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id");
            ViewData["IdUser"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Admin/Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProduct,IdUser,Amount")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", cart.IdProduct);
            ViewData["IdUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", cart.IdUser);
            return View(cart);
        }

        // GET: Admin/Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", cart.IdProduct);
            ViewData["IdUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", cart.IdUser);
            return View(cart);
        }

        // POST: Admin/Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProduct,IdUser,Amount")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
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
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", cart.IdProduct);
            ViewData["IdUser"] = new SelectList(_context.AspNetUsers, "Id", "Id", cart.IdUser);
            return View(cart);
        }

        // GET: Admin/Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.IdProductNavigation)
                .Include(c => c.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Admin/Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }
}
