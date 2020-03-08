using guzFlightsUltra.Data.Enums;
using guzFlightsUltra.Models.ViewModels.Reservation;
using System.Collections.Generic;

namespace guzFlightsUltra.Models.ViewModels.Flight
{
    public class DetailsViewModel
    {
        public string Id { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
        public string TakeOffTime { get; set; }
        public string ArrivalTime { get; set; }
        public string PilotName { get; set; }
        public PlaneType PlaneType { get; set; }
        public int FreeSeatsPassanger { get; set; }
        public int FreeSeatsBussiness { get; set; }
        public List<ReservationViewModel> Passengers { get; set; } = new List<ReservationViewModel>();
    }
}
