using System.ComponentModel.DataAnnotations;

namespace LivrariaOnline.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int Year { get; set; }
        public required string Genre { get; set; }
        public required string Publisher { get; set; }
        public required string ISBN { get; set; }
        public required string Language { get; set; }
        public int Pages { get; set; }
        public required string Description { get; set; }
        public required string CoverImage { get; set; }
        public decimal Price { get; set; }
    }
}
