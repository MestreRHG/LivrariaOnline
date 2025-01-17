using System.ComponentModel.DataAnnotations;

namespace LivrariaOnline.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author cannot exceed 100 characters")]
        public required string Author { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters")]
        public required string Genre { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public required string ISBN { get; set; }

        [Required(ErrorMessage = "Language is required")]
        [StringLength(50, ErrorMessage = "Language cannot exceed 50 characters")]
        public required string Language { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public required string Description { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Should be an URL to the image")]
        public string? CoverImageUrl { get; set; }

        [Required(ErrorMessage = "The price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be greater than zero.")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public string Price { get; set; }

        [Required]
        public required bool IsAvailable { get; set; } = true;
    }
}
