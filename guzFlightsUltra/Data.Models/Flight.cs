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
        public string FlightId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string StartDestination { get; set; }

        [Required]
        public string EndDestination { get; set; }

        [Required]
        public DateTime TakeOffTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [Range(0, 2)]
        public string PlaneType { get; set; }

        [Required]
        [MaxLength(30)]
        public string PilotName { get; set; }
        public int FreeSeatsPassanger { get; set; } // count free places
        public int FreeSeatsBussiness { get; set; } // count free places
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>(); // unique

    }
}
