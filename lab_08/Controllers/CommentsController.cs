using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab_06.Data;
using Microsoft.AspNetCore.Identity;
using Lab_06.Models;
using Lab_06.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Lab_06.Controllers
{
    public class CommentsController : Controller
    {
        public int PageSize = 12;
        private readonly ICommentRepository _context;
        private UserManager<User> _userManager;
        private readonly IVideoRepository _videoContext;

        public CommentsController(ICommentRepository context, IVideoRepository videoContext, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _videoContext = videoContext;
        }

        // GET: Comments
        public async Task<IActionResult> Index(int page = 1)
        {
            List<Comment> items = await _context.Comments
                .Include(el => el.User)
                .OrderBy(el => el.CommentId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            return View(new CommentIndexViewModel
            {
                Comments = items,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = await _context.Comments.CountAsync()
                }
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(string text, int videoId, string returnUrl)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if(user == null)
            {
                return RedirectToAction("Index", "Account");
            }
            Video video = await _videoContext.Videos.FirstOrDefaultAsync(el => el.VideoId == videoId);
            if(video == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Comment comment = new Comment { Text = text, User = user, Video = video };
            await _context.SaveCommentAsync(comment);
            return Redirect(returnUrl ?? "/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Destroy(int commentId, string returnUrl)
        {
            Comment comment = await _context.Comments
                .Include(el => el.User)
                .FirstOrDefaultAsync(el => el.CommentId == commentId);
            if (comment == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (comment.User.Id != user.Id && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            await _context.DeleteCommentAsync(comment);
            return Redirect(returnUrl ?? "/");
        }
    }
}
