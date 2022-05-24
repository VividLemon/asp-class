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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Lab_06.Controllers
{
    public class VideosController : Controller
    {
        private readonly IVideoRepository _context;
        private IUserRepository _userRepository;
        private UserManager<User> _userManager;
        public int PageSize = 6;

        public VideosController(IVideoRepository context, IUserRepository userRepository, UserManager<User> userManager)
        {
            _context = context;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        // GET: Videos
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(new VideosIndexViewModels
            {
                Videos = await _context.VideosWithUser
                .OrderBy(el => el.VideoId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = await _context.Videos.CountAsync()
                }
            }); 
        }

        [Authorize]
        public async Task<IActionResult> Create(int videoId)
        {
            Video video = await _context.Videos
            .Include(el => el.User)
            .Include(el => el.Comments)
            .Include(el => el.VideoGenres)
            .FirstOrDefaultAsync(el => el.VideoId == videoId);
            return View(video ?? new Video());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Video video)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(HttpContext.User);
                if(user == null)
                {
                    return RedirectToAction("Index", "Account");
                }
                video.User = user;
                await _context.SaveVideoAsync(video);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Create");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Destroy(int videoId, string returnUrl)
        {
            await _context.DeleteVideoAsync(videoId);
            return Redirect(returnUrl ?? "/");
        }

        // GET: Videos/Play/{id}
        [Authorize]
        public async Task<IActionResult> Play(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }
            List<Video> ownedItems = await _userRepository.GetOwnedContentAsync(user.Id);
            if(!(ownedItems.Where(el => el.VideoId == id).Count() > 0))
            {
                TempData["message"] = "You do not have access to this content! Purchase it to continue";
                return RedirectToAction("Index", "Home");
            }
            Video video = await _context.VideosGetAll
                .Include(el => el.LikedVideo).ThenInclude(el => el.User)
                .FirstOrDefaultAsync(el => el.VideoId == id);
            return View(new PlayVideoViewModel
            {
                Video = video,
                User = await _userManager.GetUserAsync(HttpContext.User),
                IsLike = video.LikedVideo.SingleOrDefault(el => el.User == user)?.IsLike ?? null
            }) ;
        }
    }
}
