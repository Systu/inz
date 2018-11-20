using System;
using System.ComponentModel.DataAnnotations;

namespace inzynierka.Models
{
    public class DietForOneDay
    {
        public Guid DietForOneDayId { get; set; }
        [Display(Name = "Śniadanie")]
        public Meal Brekfast { get; set; }
        public DateTime BrekfastTime { get; set; }
        [Display(Name = "Drugie Śniadanie")]
        public Meal SecondBrekfast { get; set; }
        public DateTime SecondBrekfasTime { get; set; }
        [Display(Name = "Obiad")]
        public Meal Diner { get; set; }
        public DateTime DinerTime { get; set; }
        [Display(Name = "Podwieczorek")]
        public Meal Snack { get; set; }
        public DateTime SnackTime { get; set; }
        [Display(Name = "Kolacja")]
        public Meal Supper { get; set; }
        public DateTime SupperTime { get; set; }

    }
}