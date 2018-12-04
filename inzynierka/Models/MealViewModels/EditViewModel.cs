using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inzynierka.Models.MealViewModels
{
    public class EditViewModel
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
