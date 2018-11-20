using System;

namespace inzynierka.Models
{
    public class WeightResult
    {
        public int WeightResultId { get; set; }
        public int Weight { get; set; }
        public DateTime WeightTime { get; set; }

        public ApplicationUser Customer { get; set; }
    }
}