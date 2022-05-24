using Microsoft.AspNetCore.Mvc;
using Lab_06.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Lab_06.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Lab_06.Components
{
    public class CommentCardViewComponent : ViewComponent
    {
        private UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        public CommentCardViewComponent(UserManager<User> userManager, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _httpContext = httpContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(Comment comment)
        {
            User user = await _userManager.GetUserAsync(_httpContext.HttpContext.User);
            return View(new CommentCardViewModel { Comment = comment, User = user});
        }
    }
}
