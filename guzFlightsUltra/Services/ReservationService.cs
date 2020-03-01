using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Services
{
    public class ReservationService : IReservationService
    {
        public int ConfirmReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        public int DeleteReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllMatchingEmail(string email)
        {
            throw new NotImplementedException();
        }

        public int ReserveFlight(int flightId, List<Passenger> passengers)
        {
            throw new NotImplementedException();
        }
    }
}
