using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_06.Data;
using Lab_06.Models;
using Lab_06.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Lab_06.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;
        private int PageSize = 8;
        private readonly IVideoRepository _context;
        private IUserRepository _userRepository;

        public HomeController(IVideoRepository context, IUserRepository userRepository, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            List<Video> ownedVideos = new List<Video>();
            if(user != null)
            {
                ownedVideos = await _userRepository.GetOwnedContentAsync(user.Id);
            }
            return View(new VideosIndexViewModels
            {
                Videos = await _context.VideosWithUser
                .Where(el => search == null || el.Name.Contains(search.Trim()) || el.Description.Contains(search.Trim()))
                .OrderBy(el => el.VideoId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync(),
                // TODO owned items is fetched here as well. If there is no user, return empty list
                // Attach owned items into PagingInfo
                // On the page, determine if it is owned and pass that data down to Card component
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = await _context.VideosWithUser.CountAsync()
                },
                SearchQuery = search,
                OwnedVideos = ownedVideos
            });
        }
    }
}
