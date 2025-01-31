﻿using LivrariaOnline.Models;
using System.ComponentModel.DataAnnotations;

namespace LivrariaOnline.ViewModels
{
    public class EditDeliveryViewModel
    {
        public int BookBought { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }


        public string? BookCover { get; set; }

        public string? BookTitle { get; set; }
        public decimal? BookPrice { get; set; }
    }
}
