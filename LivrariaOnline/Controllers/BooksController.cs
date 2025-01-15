using LivrariaOnline.Controllers;
using LivrariaOnline.Data;
using LivrariaOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;
    private readonly ApplicationDbContext _context;

    public BooksController(ILogger<BooksController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult BookDetails(int id)
	{
		var book = _context.Books.FirstOrDefault(l => l.Id == id);

        ViewData["Title"] = "Edit a Book";
        return View(book);
	}

    // Function to save or edit the book
    [HttpPost]
    public IActionResult BookDetails(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Update(book);

            _context.SaveChanges();
        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Create a Book";
        return View("BookDetails");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Book book)
    {

        throw new Exception("Not implemented");
    }

}

