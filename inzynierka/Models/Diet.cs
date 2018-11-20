using System;

namespace inzynierka.Models
{
    public class Diet
    {
        public Guid DietId { get; set; }
        public string DietName { get; set; }
        public DietForOneDay Monday { get; set; }
        public DietForOneDay Thesday { get; set; }
        public DietForOneDay Wednesday { get; set; }
        public DietForOneDay Thursday { get; set; }
        public DietForOneDay Friday { get; set; }
        public DietForOneDay Saturday { get; set; }
        public DietForOneDay Sunday { get; set; }
    }
}