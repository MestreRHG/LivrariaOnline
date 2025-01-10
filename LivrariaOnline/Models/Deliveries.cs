using System.ComponentModel.DataAnnotations;

namespace LivrariaOnline.Models
{
    public class Deliveries
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required] 
        public required string UserName{ get; set; }

        [Required]
        public required string Address { get; set; }

        [Required]
        public bool HasArrived { get; set; }
    }
}
