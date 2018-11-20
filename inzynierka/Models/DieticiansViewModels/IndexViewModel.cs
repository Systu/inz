﻿using System;
using System.ComponentModel.DataAnnotations;

namespace inzynierka.Models.DieticiansViewModels
{
    public class IndexViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(0,100,ErrorMessage = "Przedział wieku musi być między {1} a {2}")]
        [Display(Name = "Wiek")]
        public int? Age { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Przedział wieku musi być między {1} a {2}")]
        [Display(Name = "Data dodania")]
        public DateTime? AddeDateTime { get; set; }
    }
}