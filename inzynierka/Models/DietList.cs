﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inzynierka.Models
{
    public class DietList
    {
        public Guid DietListId { get; set; }
        [Display(Name = "Nazwa diety")]
        public string DietName { get; set; }
        
        public DateTime AddedDataTime { get; set; }
        public string Describe { get; set; }

        public List<MealDietList> MealDietList { get; set; }
    }
}