using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace guzFlightsUltra.Data
{
    using guzFlightsUltra.Configuration;
    using guzFlightsUltra.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class guzFlightsUltraDbContext : IdentityDbContext<GuzUser>
    {
        public guzFlightsUltraDbContext(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());


            // builder.ApplyConfiguration(new);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

    }
}
