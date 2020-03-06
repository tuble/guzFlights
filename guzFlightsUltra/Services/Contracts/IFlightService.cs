using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Models;
using System.Collections.Generic;

namespace guzFlightsUltra.Services.Contracts
{
    public interface IFlightService
    {

        //При показване на запис относно полет да се изписват датата и час на излитане
        // и продължителността на полета(вместо дата и час на кацане)

        List<Flight> GetAll(int page); // (показване на 10, 25 или 50 записа на страница
        void CreateFlight(FlightServiceModel flight);
        void EditFlight(FlightServiceModel flight);

        void DeleteFlightById(string flightId);
        int Count();
        Flight GetFlight(string id);
        bool ExistsId(string id);

    }
}
