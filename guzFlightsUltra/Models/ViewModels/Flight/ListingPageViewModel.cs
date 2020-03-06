using System.Collections.Generic;

namespace guzFlightsUltra.Models.ViewModels.Flight
{
    public class ListingPageViewModel
    {
        public List<ListingViewModel> Flights { get; set; }
        public int AllFlights { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
    }
}
