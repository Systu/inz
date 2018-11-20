﻿// <auto-generated />
using inzynierka.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace inzynierka.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181119164739_InitializeDb")]
    partial class InitializeDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("inzynierka.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime?>("AddeDateTime");

                    b.Property<int?>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("ConsultationCount");

                    b.Property<Guid?>("DietId");

                    b.Property<int?>("DietLenght");

                    b.Property<string>("DieticianId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("Height");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int?>("PlannedWeight");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Surname");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("inzynierka.Models.Diet", b =>
                {
                    b.Property<Guid>("DietId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DietName");

                    b.Property<Guid?>("FridayDietForOneDayId");

                    b.Property<Guid?>("MondayDietForOneDayId");

                    b.Property<Guid?>("SaturdayDietForOneDayId");

                    b.Property<Guid?>("SundayDietForOneDayId");

                    b.Property<Guid?>("ThesdayDietForOneDayId");

                    b.Property<Guid?>("ThursdayDietForOneDayId");

                    b.Property<Guid?>("WednesdayDietForOneDayId");

                    b.HasKey("DietId");

                    b.HasIndex("FridayDietForOneDayId");

                    b.HasIndex("MondayDietForOneDayId");

                    b.HasIndex("SaturdayDietForOneDayId");

                    b.HasIndex("SundayDietForOneDayId");

                    b.HasIndex("ThesdayDietForOneDayId");

                    b.HasIndex("ThursdayDietForOneDayId");

                    b.HasIndex("WednesdayDietForOneDayId");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("inzynierka.Models.DietForOneDay", b =>
                {
                    b.Property<Guid>("DietForOneDayId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BrekfastMealId");

                    b.Property<DateTime>("BrekfastTime");

                    b.Property<Guid?>("DinerMealId");

                    b.Property<DateTime>("DinerTime");

                    b.Property<DateTime>("SecondBrekfasTime");

                    b.Property<Guid?>("SecondBrekfastMealId");

                    b.Property<Guid?>("SnackMealId");

                    b.Property<DateTime>("SnackTime");

                    b.Property<Guid?>("SupperMealId");

                    b.Property<DateTime>("SupperTime");

                    b.HasKey("DietForOneDayId");

                    b.HasIndex("BrekfastMealId");

                    b.HasIndex("DinerMealId");

                    b.HasIndex("SecondBrekfastMealId");

                    b.HasIndex("SnackMealId");

                    b.HasIndex("SupperMealId");

                    b.ToTable("DietForOneDays");
                });

            modelBuilder.Entity("inzynierka.Models.DietList", b =>
                {
                    b.Property<Guid>("DietListId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDataTime");

                    b.Property<string>("DietName");

                    b.HasKey("DietListId");

                    b.ToTable("DietLists");
                });

            modelBuilder.Entity("inzynierka.Models.ForCustomerViewModels.DetailsViewModels", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddeDateTime")
                        .IsRequired();

                    b.Property<int?>("ConsultationCount")
                        .IsRequired();

                    b.Property<int?>("DietLenght")
                        .IsRequired();

                    b.Property<string>("Dieta")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("PlannedWeight")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DetailsViewModels");
                });

            modelBuilder.Entity("inzynierka.Models.Meal", b =>
                {
                    b.Property<Guid>("MealId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Components");

                    b.Property<Guid>("DietListId");

                    b.Property<string>("MealName");

                    b.Property<string>("MealType");

                    b.HasKey("MealId");

                    b.HasIndex("DietListId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("inzynierka.Models.WeightResult", b =>
                {
                    b.Property<int>("WeightResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<string>("DetailsViewModelsId");

                    b.Property<int>("Weight");

                    b.Property<DateTime>("WeightTime");

                    b.HasKey("WeightResultId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DetailsViewModelsId");

                    b.ToTable("WeightResults");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("inzynierka.Models.Diet", b =>
                {
                    b.HasOne("inzynierka.Models.DietForOneDay", "Friday")
                        .WithMany()
                        .HasForeignKey("FridayDietForOneDayId");

                    b.HasOne("inzynierka.Models.DietForOneDay", "Monday")
                        .WithMany()
                        .HasForeignKey("MondayDietForOneDayId");

                    b.HasOne("inzynierka.Models.DietForOneDay", "Saturday")
                        .WithMany()
                        .HasForeignKey("SaturdayDietForOneDayId");

                    b.HasOne("inzynierka.Models.DietForOneDay", "Sunday")
                        .WithMany()
                        .HasForeignKey("SundayDietForOneDayId");

                    b.HasOne("inzynierka.Models.DietForOneDay", "Thesday")
                        .WithMany()
                        .HasForeignKey("ThesdayDietForOneDayId");

                    b.HasOne("inzynierka.Models.DietForOneDay", "Thursday")
                        .WithMany()
                        .HasForeignKey("ThursdayDietForOneDayId");

                    b.HasOne("inzynierka.Models.DietForOneDay", "Wednesday")
                        .WithMany()
                        .HasForeignKey("WednesdayDietForOneDayId");
                });

            modelBuilder.Entity("inzynierka.Models.DietForOneDay", b =>
                {
                    b.HasOne("inzynierka.Models.Meal", "Brekfast")
                        .WithMany()
                        .HasForeignKey("BrekfastMealId");

                    b.HasOne("inzynierka.Models.Meal", "Diner")
                        .WithMany()
                        .HasForeignKey("DinerMealId");

                    b.HasOne("inzynierka.Models.Meal", "SecondBrekfast")
                        .WithMany()
                        .HasForeignKey("SecondBrekfastMealId");

                    b.HasOne("inzynierka.Models.Meal", "Snack")
                        .WithMany()
                        .HasForeignKey("SnackMealId");

                    b.HasOne("inzynierka.Models.Meal", "Supper")
                        .WithMany()
                        .HasForeignKey("SupperMealId");
                });

            modelBuilder.Entity("inzynierka.Models.Meal", b =>
                {
                    b.HasOne("inzynierka.Models.DietList")
                        .WithMany("MealId")
                        .HasForeignKey("DietListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("inzynierka.Models.WeightResult", b =>
                {
                    b.HasOne("inzynierka.Models.ApplicationUser", "Customer")
                        .WithMany("WeightResults")
                        .HasForeignKey("CustomerId");

                    b.HasOne("inzynierka.Models.ForCustomerViewModels.DetailsViewModels")
                        .WithMany("WeightResults")
                        .HasForeignKey("DetailsViewModelsId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("inzynierka.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("inzynierka.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("inzynierka.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("inzynierka.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
