using ASP.NETCoreD10.Models;
using ASP.NETCoreD10.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;

namespace ASP.NETCoreD10.Controllers
{
    public class AccountController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        /*------------------------------------------------------------------*/
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            // Map from RegisterVM to AppUser
            ApplicationUser applicationUser = new ApplicationUser
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
                //PasswordHash = registerVM.Password
            };

            IdentityResult result = await _userManager.CreateAsync(applicationUser, registerVM.Password);
            if (!result.Succeeded)
            {
                // Errors
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View(registerVM);
            }

            IdentityResult addToRoleResult = await _userManager.AddToRoleAsync(applicationUser, "User");
            if (!addToRoleResult.Succeeded)
            {
                // Errors
                foreach (var item in addToRoleResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View(registerVM);
            }

            return RedirectToAction("Login");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            ApplicationUser? applicationUser = await _userManager.FindByEmailAsync(loginVM.Email);
            if (applicationUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is wrong");
                return View(loginVM);
            }

            //bool result = await _userManager.CheckPasswordAsync(applicationUser, loginVM.Password);
            //if(!result)
            //{
            //    ModelState.AddModelError(string.Empty, "Email or Password is wrong");
            //    return View(loginVM);
            //}

            var signInResult = await _signInManager.PasswordSignInAsync(applicationUser, loginVM.Password, loginVM.RememberMe, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is wrong");
                return View(loginVM);
            }

            return RedirectToAction("Index", "Home");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        /*------------------------------------------------------------------*/
    }
}
