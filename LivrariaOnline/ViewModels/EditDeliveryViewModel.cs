using LivrariaOnline.Models;
using System.ComponentModel.DataAnnotations;

namespace LivrariaOnline.ViewModels
{
    public class EditDeliveryViewModel
    {
        public int BookBought { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
    }
}
