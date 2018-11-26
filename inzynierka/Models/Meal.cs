using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inzynierka.Models
{
    public class Meal
    {
        public Guid MealId { get; set; }
        [Display(Name = "Nazwa Posiłku")]
        public string MealName { get; set; }
        [Display(Name = "Typ Posiłku")]
        public string MealType { get; set; }
        [Display(Name = "Składniki")]
        public string Components { get; set; }
        
        public List<MealDietList> MealDietList { get; set; }
    }
}