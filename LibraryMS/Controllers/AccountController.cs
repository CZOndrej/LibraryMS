using LibraryMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<Account> _userManager;
        private SignInManager<Account> _signInManager;

        public AccountController(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnURL = returnUrl;
            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid) 
            {
                Account account = await _userManager.FindByEmailAsync(login.Email);
                if (account != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(account, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(login.ReturnURL ?? "/");
                    }
                    ModelState.AddModelError(nameof(login.Email), "Login failed, Invalid email or password");
                }
            }
            return View(login);
        }
    }
}
