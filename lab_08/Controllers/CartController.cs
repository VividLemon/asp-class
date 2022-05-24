using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Lab_06.Infrastructure;
using Lab_06.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab_06.Models.ViewModels;
namespace Lab_06.Controllers
{
    public class CartController : Controller
    {
        private IVideoRepository _context;
        private Cart cart;
        public CartController(IVideoRepository context, Cart cartService)
        {
            _context = context;
            cart = cartService;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public async Task<RedirectToActionResult> AddCartItem(int videoId, string returnUrl)
        {
            Video video = await _context.Videos.FirstOrDefaultAsync(el => el.VideoId == videoId); 
            if(video != null)
            {
                cart.AddCartItem(video);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public async Task<RedirectToActionResult> DeleteCartItem(int videoId, string returnUrl)
        {
            Video video = await _context.Videos.FirstOrDefaultAsync(el => el.VideoId == videoId);
            if (video != null)
            {
                cart.RemoveCartItem(video);
            }
            return RedirectToAction("Index", new { returnUrl });
        }   
    }
}
