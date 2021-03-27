using LibraryMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
                Account account = await _userManager.GetUserAsync(User);
                
                return View(account);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
