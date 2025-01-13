using LivrariaOnline.Controllers;
using LivrariaOnline.Data;
using LivrariaOnline.Models;
using Microsoft.AspNetCore.Mvc;

public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;
    private readonly ApplicationDbContext _context;

    public BooksController(ILogger<BooksController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Details(int id)
	{
		var book = _context.Books.First(l => l.Id == id);
		if (book == null)
		{
            ViewData["Title"] = "Create a Book";
            return View();
		}

        ViewData["Title"] = "Edit a Book";
        return View(book);
	}

    // Function to save or edit the book
    [HttpPost]
    public IActionResult Save(Book book)
    {
        var bookInDb = _context.Books.First(l => l.Id == book.Id);

        if (bookInDb == null)
        {
            _context.Books.Add(book);
        }
        else
        {
            bookInDb = book;
        }

        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

}

