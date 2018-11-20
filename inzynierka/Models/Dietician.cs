using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace inzynierka.Models
{
    public class Dietician:ApplicationUser
    {

        public List<ApplicationUser> Customers { get; set; }
       
    }
}