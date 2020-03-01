using guzFlightsUltra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Services.Contracts
{
    public interface IFlightService
    {

        //При показване на запис относно полет да се изписват датата и час на излитане
        // и продължителността на полета(вместо дата и час на кацане)

        List<Flight> GetAll(); // (показване на 10, 25 или 50 записа на страница

        // списък на всички пътници, според резервациите направени за полета
        List<Passenger> GetCurrentReservationAllPassangers();

    }
}
