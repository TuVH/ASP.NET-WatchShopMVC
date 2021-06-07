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
                       select new { x.ProductName,y.IdProduct, x.Price,y.Amount,x.ProductCode, x.Image, z.BrandName , y.Id , Total = y.Amount * x.Price };

            var sum1 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct && y.IdUser.ToString() == userId 
                        select (y.Amount * x.Price)).Sum();

            var sum2 = (from x in _context.Product
                        from y in _context.Cart
                        where x.Id == y.IdProduct && y.IdUser.ToString() == userId
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

        public async Task<IActionResult> CreateCart([Bind("Id,IdProduct,IdUser,Amount")] CreateCart createCart, Cart cart )
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var child = _context.Cart
                      .Where(p => p.IdProduct == createCart.IdProduct) 
                      .Where(p => p.IdUser == createCart.IdUser)
                      .FirstOrDefault();

            if (userId == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else if(child != null)
            {
                var cart1 = new Cart()
                {
                    Id = child.Id,
                    IdProduct = child.IdProduct,
                    IdUser = child.IdUser,
                    Amount = child.Amount+1
                };

                EditCart(child.Id, cart1);


                return RedirectToAction(nameof(Checkout));
            }
            else
            {
                var cart2 = new Cart()
                {
                    IdProduct = createCart.IdProduct,
                    IdUser = createCart.IdUser,
                    Amount = createCart.Amount
                };
                _context.Cart.Add(cart2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Checkout));
            }
            return View();
        }


        public async Task<IActionResult> EditCart(int id, [Bind("Id,IdProduct,IdUser,Amount")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cart1 = new Cart()
                    {
                        Id = cart.Id,
                        IdProduct = cart.IdProduct,
                        Amount = cart.Amount,
                        IdUser =cart.IdUser
                    };
                    
                    _context.Update(cart1);
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
                return RedirectToAction(nameof(Checkout));
            }
            return View(cart);
        }



        public async Task<IActionResult> CreateOrder([Bind("Id,OrderDate,IdUser,TotalMoney,IdOrder,Amount,DiscountCode,IdProduct")] CreateOrder createOrder, Order order ,OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var aspNetUsers = await _context.AspNetUsers
                            .FirstOrDefaultAsync(m => m.Id.ToString() == id);

                
                order = new Order
                {
                    IdUser = aspNetUsers.Id,
                    OrderDate = DateTime.Now,
                    TotalMoney = order.TotalMoney,
                };

                


                _context.Add(order);
               
                await _context.SaveChangesAsync();

                var child = _context.Order
                       .Where(p => p.IdUser.ToString() == id)
                       .Where(p => p.TotalMoney == order.TotalMoney)
                       .FirstOrDefault();


                orderDetails = new OrderDetails
                {
                    IdOrder = child.Id,
                    DiscountCode = "0",
                    Amount = createOrder.Amount,
                    IdProduct = createOrder.IdProduct
                };

                
                _context.Add(orderDetails);
                await _context.SaveChangesAsync();
                DeleteProductCart(order.IdUser);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }


        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteProductCart(int id)
        { 

            var child = _context.Cart
                     .Where(m => m.IdUser == id)
                     .FirstOrDefault();

            var cart = await _context.Cart.FindAsync(child.Id);
            _context.Remove(cart);
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

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }
}
