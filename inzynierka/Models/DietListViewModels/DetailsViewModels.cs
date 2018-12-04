using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inzynierka.Models.DietListViewModels
{
    public class DetailsViewModels
    {
        [Required]
        public Guid DietListId { get; set; }

        [Required]
        [Display(Name = "Nazwa diety")]
        public string DietName { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required]
        public List<MealInDiet> Meals { get; set; }
        [Display(Name = "Data dodania")]
        public DateTime AddedDataTime { get; set; }
        public class MealInDiet
        {
            public Guid MealId { get; set; }
            [Display(Name = "Nazwa Posiłku")]
            public string MealName { get; set; }
            [Display(Name = "Typ Posiłku")]
            public string MealType { get; set; }
            [Display(Name = "Składniki")]
            public string Components { get; set; }
        }
    }
}