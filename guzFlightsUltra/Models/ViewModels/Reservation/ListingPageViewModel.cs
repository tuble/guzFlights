using System.Collections.Generic;

namespace guzFlightsUltra.Models.ViewModels.Reservation
{
    public class ListingPageViewModel
    {
        public List<ReservationViewModel> Reservations { get; set; }

        public int TotalReservationsCount { get; set; }

        public int CurrentPage { get; set; }

        public int LastPage { get; set; }
    }
}
