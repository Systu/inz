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
        public DbSet<MealDietList> MealDietLists { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MealDietList>()
                .HasKey(t => new { t.MealId, t.DietListId });

            builder.Entity<MealDietList>()
                .HasOne(pt => pt.Meal)
                .WithMany(p => p.MealDietList)
                .HasForeignKey(pt => pt.MealId);

            builder.Entity<MealDietList>()
                .HasOne(pt => pt.DietList)
                .WithMany(t => t.MealDietList)
                .HasForeignKey(pt => pt.DietListId);
        }
        

        public DbSet<inzynierka.Models.ApplicationUser> ApplicationUser { get; set; }
        

        public DbSet<inzynierka.Models.ForCustomerViewModels.DetailsViewModels> DetailsViewModels { get; set; }
    }
}
