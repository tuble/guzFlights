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

    public class guzFlightsUltraDbContext : IdentityDbContext<User>
    {
        public guzFlightsUltraDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Flight>()
                .HasMany(f => f.Reservations)
                .WithOne(r => r.Flight)
                .HasForeignKey(f => f.FlightId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
