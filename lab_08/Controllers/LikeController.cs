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
    public class LikeController : Controller
    {
        private UserManager<User> _userManager;
        private IUserRepository _userRepository;
        private IVideoRepository _videoRepository;
        private ILikedVideoRepository _likedVideoRepository;
        public LikeController(IVideoRepository videoRepository, UserManager<User> userManager, IUserRepository userRepository, ILikedVideoRepository likedVideoRepository)
        {
            _likedVideoRepository = likedVideoRepository;
            _videoRepository = videoRepository;
            _userManager = userManager;
            _userRepository = userRepository;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveLike(int videoId, bool isLike, string returnUrl)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if(user == null)
            {
                return RedirectToAction("Index", "Account");
            }
            Video video = await _videoRepository.Videos.FirstOrDefaultAsync(el => el.VideoId == videoId);
            if(video == null)
            {
                return RedirectToAction("Index", "Home");
            }
            LikedVideo liked = await _likedVideoRepository.LikedVideos.FirstOrDefaultAsync(el => el.User == user && el.Video == video);
            if(liked == null)
            {
                liked = new LikedVideo { User = user, Video = video, IsLike = isLike };
            }
            else
            {
                liked.IsLike = isLike;
            }
            await _likedVideoRepository.SaveLikeAsync(liked);
            return Redirect(returnUrl ?? "/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveLike(int videoId, string returnUrl)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if(user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Video video = await _videoRepository.Videos.FirstOrDefaultAsync(el => el.VideoId == videoId);
            if (video == null)
            {
                return RedirectToAction("Index", "Home");
            }
            LikedVideo likedVideo = await _likedVideoRepository.LikedVideos.FirstOrDefaultAsync(el => el.User == user && el.Video == video);
            if (likedVideo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            await _likedVideoRepository.DeleteLikeAsync(likedVideo);
            return Redirect(returnUrl ?? "/");
        }
    }
}
