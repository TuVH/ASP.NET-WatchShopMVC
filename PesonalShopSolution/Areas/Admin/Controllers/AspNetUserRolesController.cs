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
using PesonalShopSolution.ViewModels;

namespace PesonalShopSolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AspNetUserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AspNetUserRolesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Admin/AspNetUserRoles/Create
        public async Task<IActionResult> Create(int roleId)
        {
            var role = await _context.AspNetUsers.Select(x => x).ToListAsync();

            var create = new CreateRoleViewModel()
            {
                RoleId = roleId,
                AspNetUsers = role
            };

            return View(create);
        }

        // POST: Admin/AspNetUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] int roleId, int userId)
        {
            if (ModelState.IsValid)
            {
                var role = new AspNetUserRoles
                {
                    RoleId = roleId,
                    UserId = userId
                };
                var find = await _context.AspNetUserRoles.FirstOrDefaultAsync(x => x.RoleId == roleId && x.UserId == userId);
                if (find != null)
                {
                    return RedirectToAction("Index", "AspNetRoles");
                }
                await _context.AspNetUserRoles.AddAsync(role);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "AspNetRoles");
            }
            return NotFound();
        }


        // GET: Admin/AspNetUserRoles/Delete/5
        public async Task<IActionResult> Delete(int roleId, int userId)
        {
            var aspNetRoles = await _context.AspNetUserRoles
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.RoleId == roleId && m.UserId == userId);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            return View(aspNetRoles);
        }


        // POST: Admin/AspNetUserRoles/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int roleId, int userId)
        {
            var aspNetRoles = await _context.AspNetUserRoles
                .Where(x => x.RoleId == roleId && x.UserId == userId)
                .FirstOrDefaultAsync();
            _context.AspNetUserRoles.Remove(aspNetRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "AspNetRoles");
        }

    }
}
