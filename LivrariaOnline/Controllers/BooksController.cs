using LivrariaOnline.Data;
using Microsoft.AspNetCore.Mvc;

public class BooksController : Controller
{
	private readonly ApplicationDbContext _context;

	public IActionResult Details(int id)
	{
		var book = _books.FirstOrDefault(l => l.Id == id);
		if (livro == null)
		{
			return NotFound();
		}

		var viewModel = new BookDetailsViewModel { Book = livro };
		return View(viewModel);
	}

}

