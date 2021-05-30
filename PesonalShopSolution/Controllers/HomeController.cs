using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PesonalShopSolution.Areas.Admin.Data;
using PesonalShopSolution.Areas.Admin.Models;
using PesonalShopSolution.Models;
using PesonalShopSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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

            var sum1 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct
                        select (y.Amount * x.Price)).Sum();

            var count = (from x in _context.Product
                         from y in _context.Cart
                         where x.Id == y.IdProduct && y.IdUser.ToString() == userId
                         select y.IdUser).Count();

            ViewBag.list = list.ToArray();
            ViewBag.list2 = list2.ToArray();
            ViewBag.sum1 = sum1.ToString();
            ViewBag.count = count.ToString();

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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = from x in _context.Brand
                       from y in _context.Product
                       from z in _context.Specification
                       where x.IdBrand == y.IdBrand && y.Id == z.IdProduct && y.Id == Id
                       select new { y.Id, y.Price, y.Image, y.ProductName,y.DetailDescription , z.Shape ,z.Material , z.Color , z.Gender ,z.Weight ,z.Warranty};

            var list1 = (from x in _context.Product
                       select x).Take(5);

            var sum1 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct
                        select (y.Amount * x.Price)).Sum();

            var count = (from x in _context.Product
                         from y in _context.Cart
                         where x.Id == y.IdProduct && y.IdUser.ToString() == userId
                         select y.IdUser).Count();

            ViewBag.list = list.ToArray();
            ViewBag.list1 = list1.ToArray();
            ViewBag.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.sum1 = sum1.ToString();
            ViewBag.count = count.ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sum1 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct
                        select (y.Amount * x.Price)).Sum();

            var count = (from x in _context.Product
                         from y in _context.Cart
                         where x.Id == y.IdProduct && y.IdUser.ToString() == userId
                         select y.IdUser).Count();
            ViewBag.sum1 = sum1.ToString();
            ViewBag.count = count.ToString();
            return View();
        }

        public IActionResult Erorr()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sum1 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct
                        select (y.Amount * x.Price)).Sum();

            var count = (from x in _context.Product
                         from y in _context.Cart
                         where x.Id == y.IdProduct && y.IdUser.ToString() == userId
                         select y.IdUser).Count();
            ViewBag.sum1 = sum1.ToString();
            ViewBag.count = count.ToString();
            return View();
        }

        public IActionResult Brands()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sum1 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct
                        select (y.Amount * x.Price)).Sum();

            var count = (from x in _context.Product
                         from y in _context.Cart
                         where x.Id == y.IdProduct && y.IdUser.ToString() == userId
                         select y.IdUser).Count();
            ViewBag.sum1 = sum1.ToString();
            ViewBag.count = count.ToString();
            return View();
        }

        public IActionResult Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = from x in _context.Product
                       from y in _context.Cart
                       from z in _context.Brand
                       where x.Id == y.IdProduct && y.IdUser.ToString() == userId && z.IdBrand == x.IdBrand 
                       select new { x.ProductName, x.Price,y.Amount,x.ProductCode, x.Image, z.BrandName , y.Id , Total = y.Amount * x.Price };

            var sum1 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct
                        select (y.Amount * x.Price)).Sum();

            var sum2 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct
                        select (y.Amount * x.Price)).Sum()+25000;

            var count = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct && y.IdUser.ToString() == userId 
                        select y.IdUser).Count();

            ViewBag.list = list.ToArray();
            ViewBag.sum1 = sum1.ToString();
            ViewBag.sum2 = sum2.ToString();
            ViewBag.count = count.ToString();
            return View();
        }

        public async Task<IActionResult> CreateCart( [Bind("Id,IdProduct,IdUser,Amount")] Cart cart, Cart cart1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var child = _context.Cart
                      .Where(p => p.IdProduct == cart.IdProduct) 
                      .Where(p => p.IdUser == cart.IdUser)
                      .FirstOrDefault();
            if (userId == null)
            {
                return RedirectToAction(nameof(Login));
            }

            else
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Checkout));
            }
            return View();
        }


 
        public async Task<IActionResult> DeleteProductCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Checkout));
        }



        public IActionResult Contact()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sum1 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct
                        select (y.Amount * x.Price)).Sum();

            var count = (from x in _context.Product
                         from y in _context.Cart
                         where x.Id == y.IdProduct && y.IdUser.ToString() == userId
                         select y.IdUser).Count();

            ViewBag.sum1 = sum1.ToString();
            ViewBag.count = count.ToString();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool CarttExists(int? id)
        {
            return _context.Cart.Any(e => e.IdProduct == id);
        }
    }
}
