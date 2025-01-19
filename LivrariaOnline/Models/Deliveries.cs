using System.ComponentModel.DataAnnotations;

namespace LivrariaOnline.Models
{
    public class Deliveries
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required Book BookBought { get; set; }

        [Required(ErrorMessage = "Username is required")] 
        public required string UserName{ get; set; }

        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }

        public bool HasArrived { get; set; } = false;
    }
}
