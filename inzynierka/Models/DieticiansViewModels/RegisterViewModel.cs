using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inzynierka.Models.DieticiansViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Przedział wieku musi być między {1} a {2}")]
        [Display(Name = "Wiek")]
        public int? Age { get; set; }
    }
}