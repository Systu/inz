using System;
using System.ComponentModel.DataAnnotations;

namespace inzynierka.Models.DietListViewModels
{
    public class IndexViewModel
    {
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nazwa diety")]
        public string DietName { get; set; }

        [Required]
        [Display(Name = "Ilość klientów")]
        public int CustomerCount { get; set; }

        [Required]
        [Display(Name = "Data dodania")]
        public DateTime AddedTime { get; set; }

        [Required]
        [Display(Name = "Ilość posiłków w diecie")]
        public int MealCount { get; set; }
    }
}