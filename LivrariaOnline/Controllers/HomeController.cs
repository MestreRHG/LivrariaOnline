using LivrariaOnline.Data;
using LivrariaOnline.Models;
using LivrariaOnline.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LivrariaOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Database
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string? search)
        {
            // Get all books
            var books = _context.Books.AsQueryable();
            IndexViewModel model = new IndexViewModel
            {
                Books = books.ToList(),
                Search = search ?? String.Empty
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
