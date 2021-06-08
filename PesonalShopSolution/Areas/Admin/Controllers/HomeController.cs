using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PesonalShopSolution.Areas.Admin.Data;
using PesonalShopSolution.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PesonalShopSolution.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<AspNetUsers> _signInManager;

        public HomeController( SignInManager<AspNetUsers> signInManager, ApplicationDbContext context)
        {    
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var CountUser = (from x in _context.AspNetUsers
                         select x).Count();

            var CountProduct = (from x in _context.Product
                             select x).Count();

            var CountBrand = (from x in _context.Brand
                                select x).Count();

            var CountOrder = (from x in _context.Order
                              select x).Count();

            var List5 = (from x in _context.Product
                         from y in _context.Brand
                         where x.IdBrand == y.IdBrand
                         select new { x.Id, x.ProductName, x.Price, y.BrandName }).Take(5);


            ViewBag.List1 = CountUser.ToString();
            ViewBag.List2 = CountProduct.ToString();
            ViewBag.List3 = CountBrand.ToString();
            ViewBag.List4 = CountOrder.ToString();
            ViewBag.List5 = List5.ToArray();


            return View();
        }
        public IActionResult UserProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = from x in _context.AspNetUsers
                       where x.Id.ToString() == userId
                       select x;
            ViewBag.list = list.ToArray(); 
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }

    }
}
