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
            var model = new IndexViewModel {
                Search = search ?? String.Empty,
                Books = books.Where(b => b.IsAvailable && b.Title.Contains(search ?? String.Empty)).ToList()
            };

            return View(model);
        }

        public IActionResult BookDetails(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateDelivery(int bookBoughtId)
        {
            var bookBought = _context.Books.FirstOrDefault(b => b.Id == bookBoughtId);

            ViewData["Title"] = "Create a Delivery";
            var deliveryModel = new EditDeliveryViewModel { 
                BookBought = bookBought.Id, 
                BookCover = bookBought.CoverImageUrl, 
                BookTitle = bookBought.Title, 
                BookPrice = bookBought.Price 
            };

            return View("EditDelivery", deliveryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDelivery(EditDeliveryViewModel editDeliveryViewModel)
        {
            if (ModelState.IsValid)
            {
                Book bookBought = _context.Books.FirstOrDefault(b => b.Id == editDeliveryViewModel.BookBought);

                var delivery = new Deliveries
                {
                    BookBought = bookBought,
                    UserName = editDeliveryViewModel.UserName,
                    Address = editDeliveryViewModel.Address,
                    HasArrived = false
                };

                _context.Deliveries.Add(delivery);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Log the model state errors to the console
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogError($"Property: {state.Key}, Error: {error.ErrorMessage}");
                }
            }

            return View("EditDelivery", editDeliveryViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
