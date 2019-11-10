using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Booklovers.Models;
using Booklovers.Data;
using Booklovers.Service;
using PagedList;

namespace Booklovers.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookloverBookContext _context;
        private readonly BooksService _booksService;

        public BooksController(BookloverBookContext context)
        {
            _context = context;
            _booksService = new BooksService();
        }

        // GET: Books
        public ViewResult Index(string title, int? page)
        {
            // retrieve bookings with eager loaded Author
            var books = from b in _context.Book.Include(a => a.Author) select b;
            ViewData["Query"] = "";
            if (!String.IsNullOrEmpty(title))
            {
                ViewData["Query"] = title;
                // match title without case
                books = books.Where(t => t.Title.ToLower().Contains(title.ToLower()));
            }

            int pageSize = 9; // set default page size TODO: This should be a configuration.
            int pageNumber = (page ?? 1);
            var booksList = books.ToPagedList(pageNumber, pageSize);

            // retain page information to use in the View
            ViewData["Pages"] = (int) Math.Ceiling((books.Count() * 1.0 / pageSize));
            ViewData["CurrentPage"] = pageNumber;
            return View(booksList);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(a => a.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            // retrieve authors to display in a dropdown 
            // TODO: This should be a typeahead when more data are available
            ViewBag.Authors = _booksService.getAuthors(_context);
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Thumbnail,AuthorId")] Book book)
        {
            ViewBag.Authors = _booksService.getAuthors(_context);
            if (ModelState.IsValid)
            {
                var currentTime = DateTime.Now;
                book.CreatedTime = currentTime;
                book.ModifiedTime = currentTime;
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Authors = _booksService.getAuthors(_context);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,Thumbnail,Rating,AuthorId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    book.ModifiedTime = DateTime.Now;
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
