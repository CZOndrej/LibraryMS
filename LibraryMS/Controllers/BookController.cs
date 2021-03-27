using LibraryMS.Data;
using LibraryMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Controllers
{
    [Authorize]
    public class BookController : Controller
    {

        private readonly AppIdentityDbContext _context;

        public BookController(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = _context.Book
            .Include(b => b.Authors).AsNoTracking();
            return View(await books.ToListAsync());

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBook newBook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = new Author
                    {
                        Name = newBook.Name,
                        Description = newBook.Description
                    };

                    Book book = new Book
                    {
                        ISBN = newBook.ISBN,
                        Title = newBook.Title,
                        Language = newBook.Language,
                        NumberOfPages = newBook.NumberOfPages,
                        Authors = new List<Author>()
                    };

                    book.Authors.Add(author);

                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index" ,"Book");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator." + ex.Message);
            }
            return RedirectToAction("Index");
        }



    }
}
