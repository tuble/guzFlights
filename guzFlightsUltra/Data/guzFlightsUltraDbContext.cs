namespace guzFlights.Data
{
    using guzFlightsUltra.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class guzFlightsUltraDbContext : DbContext //: IdentityDbContext
    {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        // public virtual DbSet<Passenger> Passengers { get; set; }

        public guzFlightsUltraDbContext(DbContextOptions<guzFlightsUltraDbContext> options) : base(options)
        {
        }

    }
}
