using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Models
{
    public class FlightServiceModel
    {
        public string Id { get; set; }
        public string StartDestination { get; set; }

        public string EndDestination { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string PlaneType { get; set; }

        public string PilotName { get; set; }

        public int FreeSeatsPassanger { get; set; }

        public int FreeSeatsBussiness { get; set; }
    }
}
