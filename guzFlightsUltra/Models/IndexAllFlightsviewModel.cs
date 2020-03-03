using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace guzFlightsUltra.Models
{
    public class IndexAllFlightsViewModel
    {
        public int Id { get; set; }
        public string StartDest { get; set; }
        public string EndDest { get; set; }

        // calculate flight duration
        public string PlaneType { get; set; }
        public string PilotName { get; set; }
        public int FreeSeats { get; set; }
        public int BussinessFreeFeats { get; set; }
        public List<int> ReservationsId { get; set; }
        public List<string> Reservations { get; set; }

        // list of all passangers for all reservations

    }
}
