using Microsoft.AspNetCore.Mvc;
using Lab_06.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Lab_06.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _context;
        private UserManager<User> _userManager;
        private IUserRepository _userRepository;
        private Cart _cart;
        public OrderController(IOrderRepository orderRepository, UserManager<User> userManager, Cart cart, IUserRepository userRepository)
        {
            _context = orderRepository;
            _userManager = userManager;
            _cart = cart;
            _userRepository = userRepository;
        }
        [Authorize]
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout (Order order)
        {
            if(_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty");
            }
            if (ModelState.IsValid)
            {
                order.CartLines = _cart.Lines.ToArray();
                User user = await _userManager.GetUserAsync(HttpContext.User);
                if(user == null)
                {
                    return RedirectToAction("Index", "Account");
                }
                order.User = user;
                List<Video> ownedItems = await _userRepository.GetOwnedContentAsync(user.Id);
                List<Video> purchasingItems = _cart.Lines.Select(el => el.Video).ToList();
                foreach(Video video in ownedItems)
                {
                    foreach(Video purchase in purchasingItems)
                    {
                        if(video.VideoId == purchase.VideoId)
                        {
                            TempData["message"] = $"Your account already contains {video.Name}. Remove it and try again!";
                            _cart.ClearCart();
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                await _context.SaveOrderAsync(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed ()
        {
            _cart.ClearCart();
            return View();
        }

        //public async Task<ViewResult> OutstandingOrders ()
        //{
        //    return View(await _context.Orders.Where(el => el.IsShipped == false).ToListAsync());
        //} 
        
        //[HttpPost]
        //public async Task<RedirectToActionResult> OutstandingOrders(int orderId)
        //{
        //    Order order = await _context.Orders.FirstOrDefaultAsync(el => el.OrderId == orderId);
        //    if(order != null)
        //    {
        //        order.IsShipped = true;
        //        await _context.SaveOrder(order);
        //        TempData["message"] = "Order has been marked shipped";
        //    }
        //    return RedirectToAction("index", "Admin");
        //}
    }
}
