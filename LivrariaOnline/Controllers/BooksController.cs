using LivrariaOnline.Controllers;
using LivrariaOnline.Data;
using LivrariaOnline.Models;
using LivrariaOnline.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Backoffice()
    {
        var books = _context.Books.AsQueryable();

        var Backoffice = new BackofficeViewModel
        {
            Books = books.ToList(),
        };

        return View(Backoffice);
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

            return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
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

        if (book != null)
            _context.Books.Remove(book);

		return RedirectToAction("Index", "Home");
    }
}

