using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inzynierka.Models.DietListViewModels
{
    public class DetailsViewModels
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nazwa diety")]
        public string DietName { get; set; }

        [Required]
        public List<Meal> Meals { get; set; }
    }
}