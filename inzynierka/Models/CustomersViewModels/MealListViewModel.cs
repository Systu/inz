using System;
using System.ComponentModel.DataAnnotations;

namespace inzynierka.Models.CustomersViewModels
{
    public class MealListViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        
        public string MealName { get; set; }

        [Required]
        
        public string MealType { get; set; }


    }
}