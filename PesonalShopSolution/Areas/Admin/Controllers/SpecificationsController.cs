using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PesonalShopSolution.Areas.Admin.Data;
using PesonalShopSolution.Areas.Admin.Models;

namespace PesonalShopSolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SpecificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Specifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Specification.Include(s => s.IdProducts);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Specifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await _context.Specification
                .Include(s => s.IdProducts)
                .FirstOrDefaultAsync(m => m.IdSpecifications == id);
            if (specification == null)
            {
                return NotFound();
            }
            ViewBag.specifications = _context.Product.ToList();
            return View(specification);
        }

        // GET: Admin/Specifications/Create
        public IActionResult Create()
        {
            ViewBag.specifications = _context.Product.ToList();
            return View();
        }

        // POST: Admin/Specifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSpecifications,IdProduct,Shape,Gender,Color,Material,Weight,Warranty")] Specification specification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.specifications = _context.Product.ToList();
            return View(specification);
        }

        // GET: Admin/Specifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await _context.Specification.FindAsync(id);
            if (specification == null)
            {
                return NotFound();
            }
            ViewBag.specifications = _context.Product.ToList();
            return View(specification);
        }

        // POST: Admin/Specifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSpecifications,IdProduct,Shape,Gender,Color,Material,Weight,Warranty")] Specification specification)
        {
            if (id != specification.IdSpecifications)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificationExists(specification.IdSpecifications))
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
            ViewData["IdProduct"] = new SelectList(_context.Product, "Id", "Id", specification.IdProduct);
            return View(specification);
        }

        // GET: Admin/Specifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await _context.Specification
                .Include(s => s.IdProducts)
                .FirstOrDefaultAsync(m => m.IdSpecifications == id);
            if (specification == null)
            {
                return NotFound();
            }

            return View(specification);
        }

        // POST: Admin/Specifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specification = await _context.Specification.FindAsync(id);
            _context.Specification.Remove(specification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecificationExists(int id)
        {
            return _context.Specification.Any(e => e.IdSpecifications == id);
        }
    }
}
