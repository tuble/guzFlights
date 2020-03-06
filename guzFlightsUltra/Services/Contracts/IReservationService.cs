using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Services.Contracts
{
    public interface IReservationService
    {
        List<Reservation> GetAllByFlightId(string flightId);

        void MakeReservation(ReservationServiceModel input);

        bool ExistsId(string id);

        Reservation GetById(string id);

        void ConfirmReservation(string id);

        void DeleteReservation(string id);

        int Count();

        List<Reservation> GetAll(int page);
    }
}
