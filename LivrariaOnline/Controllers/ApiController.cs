using System.ComponentModel.DataAnnotations;
using LivrariaOnline.Data;
using LivrariaOnline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrariaOnline.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("{id}/status")]
        public async Task<IActionResult> UpdateDeliveryStatus(int id, [FromBody] DeliveryStatusUpdateModel model)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            delivery.HasArrived = model.HasArrived;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return new JsonResult(books);
        }

        [HttpPost("makedelivery")]
        public async Task<IActionResult> CreateApiDelivery([FromQuery] int bookId, [FromQuery] string userName, [FromQuery] string address)
        {
            // Check if the data is valid
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(address))
            {
                return BadRequest(new { status = "error", message = "Invalid input data." });
            }

            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                return NotFound("Book not found");
            }

            var delivery = new Deliveries
            {
                BookBought = book,
                UserName = userName,
                Address = address
            };

            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();

            return Ok(new { status = "success", message = "Data processed successfully." });
        }
    }
}

public class DeliveryStatusUpdateModel
{
    public bool HasArrived { get; set; }
}