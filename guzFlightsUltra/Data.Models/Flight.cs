using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace guzFlightsUltra.Data.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
        public DateTime TakeOffTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string PlaneType { get; set; }
        public string PlaneId { get; set; }
        public string PilotName { get; set; }
        public int FreeSeats { get; set; } // count free places
        public int BussinessFreeSeats{ get; set; } // count free places

        public int ReservationId { get; set; }
        public Reservation FlightReservation { get; set; }


    }
}
