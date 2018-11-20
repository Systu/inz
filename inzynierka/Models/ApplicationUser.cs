using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace inzynierka.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        [Display(Name = "Data Rejestracji")]
        public DateTime? AddeDateTime { get; set; }

        [Display(Name = "Długość Diety")]
        public int? DietLenght { get; set; }
        [Display(Name = "Ilość Odbytych konsultacji")]
        public int? ConsultationCount { get; set; }
        [Display(Name = "Planowana Waga")]
        public int? PlannedWeight { get; set; }
        [Display(Name = "Wiek")]
        public int? Age { get; set; }
        [Display(Name = "Wzrost")]
        public int? Height { get; set; }

        public List<WeightResult> WeightResults { get; set; }
        public string DieticianId { get; set; }
        public Guid? DietId { get; set; }
    }
}
