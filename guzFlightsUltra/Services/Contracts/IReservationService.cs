using guzFlightsUltra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Services.Contracts
{
    public interface IReservationService
    {
        // Всеки потребител(без вход) може да изпраща заявка за резервация за даден полет, 
        // като трябва да посочи за всеки пътник(за когото иска да закупи билет) 
        int ReserveFlight(int flightId, List<Passenger> passengers);

        // На детайлния изглед за резервация да се показва списък с всички пътници, които ще пътуват с нея.
        List<Reservation> GetAll();

        // Резервациите са видими за всички потребители, като след потвърждение дадена резервация не може да бъде изтрита
        // Can delete only if not confirmed
        int DeleteReservation(int reservationId);

        // освен това към заявката трябва да изпрати и имейл за обратна връзка
        // Ако има достатъчно места от посочения вид за всеки пътник, се изпраща потвърждение на посочения имейл
        // като имейла съдържа информация относно заетите билети.
        int ConfirmReservation(int reservationId);

        // Резервациите да могат да се страницират и филтрират по имейл. 
        List<Reservation> GetAllMatchingEmail(string email);

    }
}
