namespace guzFlightsUltra.Models.ViewModels.Flight
{
    public class ListingViewModel
    {
        public string Id { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
        public string TakeOffTime { get; set; }
        public string TravelTime { get; set; }
        public int FreeSeatsPassanger { get; set; }
        public int FreeSeatsBussiness { get; set; }
    }
}
