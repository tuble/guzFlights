using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Data.Models
{
    public class Reservation // List of passangers 
    {
        // one to many
        // 1 reservation one flight many passangers
        // flight dependent entity
        // reservation principal
        public Reservation()
        { }

        [Key]
        public int ReservatoionId { get; set; }
        /*public ICollection<Flight> Flights { get; set; }*/

        public Flight ReservedFlight { get; set; }
        public ICollection<Passenger> Passengers { get; set; }


    }
}
