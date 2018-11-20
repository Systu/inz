using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inzynierka.Models.ForCustomerViewModels
{
    public class DetailsViewModels
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
        [Display(Name = "Data Dodania")]

        public DateTime? AddeDateTime { get; set; }


        [Required]
        [Display(Name = "Długość Diety")]
        public int? DietLenght { get; set; }


        [Required]
        [Display(Name = "Ilość odbytych konsultacji")]
        public int? ConsultationCount { get; set; }


        [Required]
        [Display(Name = "Planowana Waga")]
        public int? PlannedWeight { get; set; }

        [Required]
        [Display(Name = "Dieta")]
        public string Dieta  { get; set; }

        [Required]
        [Display(Name = "Dzisiejsza waga")]
        public List<WeightResult> WeightResults { get; set; }
    }
}
