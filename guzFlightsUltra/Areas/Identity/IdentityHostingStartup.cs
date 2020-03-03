/*using System;
using guzFlights.Data;
using guzFlightsUltra.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(guzFlightsUltra.Areas.Identity.IdentityHostingStartup))]
namespace guzFlightsUltra.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<guzFlightsUltraDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("guzFlightsUltraDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<guzFlightsUltraDbContext>();
            });
        }
    }
}*/