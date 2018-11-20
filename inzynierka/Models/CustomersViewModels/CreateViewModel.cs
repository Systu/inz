using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace inzynierka.Models.CustomersViewModels
{
    public class CreateViewModel
    {
        public List<SelectListItem> DietLists { get; set; }
        [Required]
        public DietList DietList { get; set; }
        public Diet IndividualDiet { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? DietLenght { get; set; }
        public int? ConsultationCount { get; set; }
        public int? PlannedWeight { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
    }
}
