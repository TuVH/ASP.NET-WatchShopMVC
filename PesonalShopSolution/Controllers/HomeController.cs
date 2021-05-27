using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PesonalShopSolution.Areas.Admin.Data;
using PesonalShopSolution.Areas.Admin.Models;
using PesonalShopSolution.Models;
using PesonalShopSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PesonalShopSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signInManager;
        private readonly ApplicationDbContext _context;

        public HomeController(UserManager<AspNetUsers> userManager,SignInManager<AspNetUsers> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var list = from x in _context.Brand
                       from y in _context.Product
                       from z in _context.Specification
                       where x.IdBrand == y.IdBrand && y.Id == z.IdProduct && z.Gender == "Male"
                       select new { y.Id , y.Price , y.Image ,y.ProductName};

            var list2 = from x in _context.Brand
                       from y in _context.Product
                       from z in _context.Specification
                       where x.IdBrand == y.IdBrand && y.Id == z.IdProduct && z.Gender == "Female"
                       select new { y.Id, y.Price, y.Image, y.ProductName };

            ViewBag.list = list.ToArray();
            ViewBag.list2 = list2.ToArray();

            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("CustomError", "Invalid Login Attempt");

            }
            return View(user);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        public IActionResult Men()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AspNetUsers
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("CustomError", error.Description);
                }

                ModelState.AddModelError("CustomError", "Invalid Login Attempt");

            }
            return View(model);
        }


      
        public IActionResult Single(int Id)
        {
            var list = from x in _context.Brand
                       from y in _context.Product
                       from z in _context.Specification
                       where x.IdBrand == y.IdBrand && y.Id == z.IdProduct && y.Id == Id
                       select new { y.Id, y.Price, y.Image, y.ProductName,y.DetailDescription , z.Shape ,z.Material , z.Color , z.Gender ,z.Weight ,z.Warranty};
            ViewBag.list = list.ToArray();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Erorr()
        {
            return View();
        }

        public IActionResult Brands()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
