using LivrariaOnline.Controllers;
using LivrariaOnline.Data;
using LivrariaOnline.Models;
using LivrariaOnline.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


[Authorize]
public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;
    private readonly ApplicationDbContext _context;

    public BooksController(ILogger<BooksController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Books()
    {
        var books = _context.Books.AsQueryable();

		var booksViewModel = new BooksViewModel
        {
            Books = books.ToList(),
        };

        return View(booksViewModel);
    }

    public IActionResult Backoffice()
    {
        return View();
    }

    public IActionResult Edit(int id)
	{
		var book = _context.Books.FirstOrDefault(l => l.Id == id);

        ViewData["Title"] = "Edit a Book";
        return View("BookEdit", book);
	}

    // Function to save or edit the book
    [HttpPost]
    public IActionResult Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction("Books");
        }

        return View("BookEdit", book);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Create a Book";
        return View("BookEdit");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Books");
        }

        // Log the model state errors to the console
        foreach (var state in ModelState)
        {
            foreach (var error in state.Value.Errors)
            {
                _logger.LogError($"Property: {state.Key}, Error: {error.ErrorMessage}");
            }
        }

        return View("BookEdit", book);
    }

	public IActionResult Delete(int id)
    {
		var book = _context.Books.FirstOrDefault(l => l.Id == id);

        if (book != null) { 
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

		return RedirectToAction("Books");
    }

    public IActionResult Deliveries()
    {
        //var deliveries = _context.Deliveries.ToList();

        var deliveriesViewModel = new DeliveriesViewModel
        {
            Deliveries = _context.Deliveries.Include(d => d.BookBought).ToList()

        };

        return View(deliveriesViewModel);
    }
}

