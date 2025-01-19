using LivrariaOnline.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}

public class DeliveryStatusUpdateModel
{
    public bool HasArrived { get; set; }
}