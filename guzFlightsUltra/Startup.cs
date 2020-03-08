using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

using guzFlightsUltra.Data;
using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Services;
using guzFlightsUltra.Services.Contracts;
using Microsoft.AspNetCore.Identity.UI.Services;
using guzFlightsUltra.Services.EmailSender;

namespace guzFlightsUltra
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<guzFlightsUltraDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<guzFlightsUltraDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<IGuzUserService, GuzUserService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<guzFlightsUltraDbContext>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Roles.Any()) // add Roles
                    {
                        context.Roles.Add(new IdentityRole
                        {
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });

                        context.Roles.Add(new IdentityRole
                        {
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });

                        context.SaveChanges();
                    }
                }

                if (!userManager.Users.Any(x => x.Roles.Equals("Administrator"))) // add admin user on creation
                {
                    User adminUser = new User
                    {
                        UserName = "guzAdmin",
                        Email = "fustuci12@gmail.com",
                        FirstName = "Yana",
                        LastName = "Brat",
                        SSN = "0000000001",
                        Address = "Sofia, Bulgaria",
                        EmailConfirmed = true

                    };

                    var result = userManager.CreateAsync(adminUser, "admin"); // create user with pass "admin"

                    if (result.Result.Succeeded)
                    {
                        userManager.AddToRoleAsync(adminUser, "Administrator"); // add admin user to Administrator ASP Role
                        userManager.UpdateSecurityStampAsync(adminUser);
                        signInManager.SignInAsync(adminUser, isPersistent: false);
                    }
                }

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
            }
        }
    }
}
