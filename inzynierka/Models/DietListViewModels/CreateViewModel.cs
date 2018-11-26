using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inzynierka.Models.DietListViewModels
{
    public class CreateViewModel
    {
        public Guid DietListId { get; set; }
        [Display(Name = "Nazwa diety")]
        public string DietName { get; set; }
        [Display(Name = "Opis")]
        public string Describe { get; set; }
        public DateTime AddeDateTime { get; set; }
    }
}
