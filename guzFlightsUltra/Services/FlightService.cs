using guzFlightsUltra.Data;
using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Models;
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
        private readonly guzFlightsUltraDbContext context;

        public FlightService(guzFlightsUltraDbContext context)
        {
            this.context = context;
        }

        public void CreateFlight(FlightServiceModel input)
        {
            var flight = new Flight
            {
                StartDestination = input.StartDestination,
                EndDestination = input.EndDestination,
                TakeOffTime = input.TakeOffTime,
                ArrivalTime = input.ArrivalTime,
                FreeSeatsPassanger = input.FreeSeatsPassanger,
                FreeSeatsBussiness = input.FreeSeatsBussiness,
                PlaneType = input.PlaneType, // fix this
                PilotName = input.PilotName
            };

            context.Flights.Add(flight);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Flights.Count();
        }

        public List<Flight> GetAll(int page)
        {
            return context.Flights
                .OrderByDescending(f => f.TakeOffTime)
                .Take(page * 8) // times flights per page
                .Skip((page - 1) * 8)
                .ToList();
        }

        public void EditFlight(FlightServiceModel flight)
        {
            if (!ExistsId(flight.Id))
            {
                throw new ArgumentException("Invalid flight id!");
            }

            var dbFlight = context.Flights.SingleOrDefault(f => f.FlightId == flight.Id);

            dbFlight.StartDestination = flight.StartDestination ;
            dbFlight.EndDestination = flight.EndDestination ;
            dbFlight.TakeOffTime = flight.TakeOffTime;
            dbFlight.ArrivalTime = flight.ArrivalTime;
            dbFlight.FreeSeatsPassanger = flight.FreeSeatsPassanger ;
            dbFlight.FreeSeatsBussiness = flight.FreeSeatsBussiness ;
            dbFlight.PlaneType = flight.PlaneType; // fix 
            dbFlight.PilotName = flight.PilotName;

            context.Flights.Update(dbFlight);
            context.SaveChanges();
        }

        public Flight GetFlight(string id)
        {
            if (!ExistsId(id))
            {
                throw new ArgumentException("Invalid flight id!");
            }

            var flight = context.Flights.SingleOrDefault(f => f.FlightId  == id);

            return flight;
        }
        public void DeleteFlightById(string id)
        {
            if (!ExistsId(id))
            {
                throw new ArgumentException("Invalid flight id!");
            }

            var flight = context.Flights.SingleOrDefault(f => f.FlightId == id);

            context.Flights.Remove(flight);
            context.SaveChanges();
        }
        public bool ExistsId(string id)
        {
            return context.Flights.Any(f => f.FlightId == id);
        }
    }
}
