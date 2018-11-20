using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace inzynierka.Models.MealViewModels
{
    public class MealCreateGetViewModel
    {
        public Guid MealId { get; set; }
        public string MealName { get; set; }
        public string Components { get; set; }
        public string MealType { get; set; }

        public Guid DietListId { get; set; }
    }
}
