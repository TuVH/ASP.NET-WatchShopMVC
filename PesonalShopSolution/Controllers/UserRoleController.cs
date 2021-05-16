using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesonalShopSolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesonalShopSolution.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserRoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserRoleController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: UserRole
        public async Task<IActionResult> Index()
        {
            var role = await _context.UserRoles.ToListAsync();
            return View(role);
        }

    }
}
