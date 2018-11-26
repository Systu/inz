using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inzynierka.Models
{
    public class MealDietList
    {
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }

        public Guid DietListId { get; set; }
        public DietList DietList { get; set; }
    }
}
