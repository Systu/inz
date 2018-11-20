using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using inzynierka.Data;
using inzynierka.Models;
using inzynierka.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

namespace inzynierka
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        private static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleMenager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userMenager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            string[] roleNames = { "Admin", "Dietician", "Customers" };
            context.Database.EnsureCreated();
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleMenager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleMenager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var adminUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Hubert.syst@gmail.com"
            };
            const string userPwd = "Zaq!2wsx";
            var user = await userMenager.FindByEmailAsync("Hubert.syst@gmail.com");

            if (user == null)
            {
                var createAdminUser = await userMenager.CreateAsync(adminUser, userPwd);
                if (createAdminUser.Succeeded)
                {
                    await userMenager.AddToRoleAsync(adminUser, "Admin");

                }
            }

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();


            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireDieticianRole", policy => policy.RequireRole("Dietician"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireCustomersRole", policy => policy.RequireRole("Customers"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(LogLevel.Warning);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            CreateRoles(serviceProvider).Wait();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
