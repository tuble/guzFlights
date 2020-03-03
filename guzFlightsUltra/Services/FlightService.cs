using guzFlightsUltra.Data;
using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Services
{
    // only ADMIN can CRUD
    public class FlightService : IFlightService
    {

        private guzFlightsUltraDbContext context;

        public FlightService(guzFlightsUltraDbContext context)
        {
            this.context = context;
        }
        public List<Flight> GetAll()
        {
            return this.context.Flights.ToList();
        }

        public List<Passenger> GetCurrentReservationAllPassangers(int thisReservationId)
        {
            return this.context.Reservations.First(x => x.ReservatoionId == thisReservationId).Passengers;
        }
    }
}
