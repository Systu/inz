using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using inzynierka.Models;
using inzynierka.Models.ForCustomerViewModels;

namespace inzynierka.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Meal> Meals { get; set; }
        public DbSet<DietForOneDay> DietForOneDays { get; set; }
        public DbSet<WeightResult> WeightResults { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<DietList> DietLists { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
        }
        

        public DbSet<inzynierka.Models.ApplicationUser> ApplicationUser { get; set; }
        

        public DbSet<inzynierka.Models.ForCustomerViewModels.DetailsViewModels> DetailsViewModels { get; set; }
    }
}
