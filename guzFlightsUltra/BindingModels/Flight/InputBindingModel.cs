using guzFlightsUltra.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace guzFlightsUltra.BindingModels.Flight
{
    public class InputBindingModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string StartDestination { get; set; }

        [Required]
        [MaxLength(10)]
        public string EndDestination { get; set; }

        [Required]
        public string TakeOffTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        [Required]
        public PlaneType PlaneType { get; set; }

        [Required]
        [MaxLength(30)]
        public string PilotName { get; set; }

        [Required]
        public int FreeSeatsPassanger { get; set; }

        [Required]
        public int FreeSeatsBussiness { get; set; }
    }
}
