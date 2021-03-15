using LibraryMS.Data;
using LibraryMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly AppIdentityDbContext _context;


        public AdminController(UserManager<Account> userManager, AppIdentityDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            Address address = new Address
            {
                City = user.City,
                Street = user.Street,
                Zipcode = user.Zipcode,
                State = user.State
            };

            _context.Add(address);

            Person person = new Person
            {
                Email = user.Email,
                Name = user.Name,
                Address = address,

            };
            Account account = new Account
            {
                
            };
        }
    }
}
