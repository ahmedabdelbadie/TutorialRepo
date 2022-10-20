using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppTutorial.Models;
using WebAppTutorial.ViewsModel;

namespace WebAppTutorial.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AcceptVerbs("GET","POST")]
        public async Task<IActionResult> isEmailUse(string email )
        {
            var user = await UserManager.FindByNameAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already use");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(loginView.Email);
                var result = 
                    await SignInManager.PasswordSignInAsync(
                        user.UserName,
                        loginView.Password,
                        loginView.RememberMe,
                        false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
            return View(loginView);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName=reg.UserName, Email = reg.Email, PasswordHash =reg.Password, city = reg.City};
                var result = await UserManager.CreateAsync(user, reg.Password);
                if (result.Succeeded)
                {
                    if(SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListRoles", "Administration");
                    }
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description); 
                }
            }
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout( )
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
