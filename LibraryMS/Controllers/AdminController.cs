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
            return View(_userManager.Users);
        }
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                Address address = new Address
                {
                    City = user.City,
                    Street = user.Street,
                    Zipcode = user.Zipcode,
                    State = user.State
                };

                //_context.Add(address);

                Person person = new Person
                {
                    Email = user.Email,
                    Name = user.Name,
                    Address = address,
                    Phone = user.Phone,
                };

                //_context.Add(person);

                Account account = new Account
                {
                    Status = AccountStatus.Active,
                    Person = person,
                    DateOfMembership = DateTime.Now,
                    TotalBooksCheckedout = 0,
                    LibraryCard = null,
                    UserName = user.Name,
                    Email = user.Email
                };
                IdentityResult result = await _userManager.CreateAsync(account, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }
        public async Task<ViewResult> Delete(string id)
        {
            Account account = await _userManager.FindByIdAsync(id);

            if (account != null)
            {
                return View(account);
            }
            else
            {
                ModelState.AddModelError("", "Account not found!");
                return View("Index", _userManager.Users);
            }
        }
    }
}
