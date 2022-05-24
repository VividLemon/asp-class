using Lab_06.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab_06.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab_06.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private IUserRepository _userRepository;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, IUserRepository userRepository, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public IActionResult Index(string ReturnUrl)
        {
            return View(new LoginModel { UserName = "", Password = "", returnUrl = ReturnUrl});
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View(new CreateAccountViewModel { Password = "", Username = ""});
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountViewModel createAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = createAccountViewModel.Username };
                IdentityResult result = await _userManager.CreateAsync(user, createAccountViewModel.Password);
                if(result.Succeeded == false)
                {
                    return RedirectToAction("Index", "Home");
                }
                await _userManager.AddToRoleAsync(user, "Standard");
                await _signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult signIn = await _signInManager.PasswordSignInAsync(user, createAccountViewModel.Password, false, false);
                return RedirectToAction("Index", "Home");
            }
            return View("Create");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(loginModel.Password), "Invalid username/password");
            }
            return View("Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
