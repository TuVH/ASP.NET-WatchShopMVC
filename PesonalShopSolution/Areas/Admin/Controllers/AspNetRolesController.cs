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
    public class AspNetRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AspNetRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AspNetRoles
        public async Task<IActionResult> Index()
        {
            var result = await _context.AspNetRoles
                .Include(a => a.AspNetUserRoles)
                .ThenInclude(b => b.User)
                .ToListAsync();
            return View(result);
        }

        // GET: Admin/AspNetRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AspNetRoles aspNetRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetRoles);
        }



        // GET: Admin/AspNetRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetRoles = await _context.AspNetRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            return View(aspNetRoles);
        }

        // POST: Admin/AspNetRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);
            _context.AspNetRoles.Remove(aspNetRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
