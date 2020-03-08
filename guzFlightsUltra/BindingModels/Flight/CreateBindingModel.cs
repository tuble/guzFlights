using guzFlightsUltra.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace guzFlightsUltra.BindingModels.Flight
{
    public class CreateBindingModel
    {
        [Required]
        // [RegularExpression("/Guinea|Uganda|Zimbabwe/")] doesnt work???
        public string StartDestination { get; set; }

        [Required]
        //[RegularExpression("/Guinea|Uganda|Zimbabwe/")]
        public string EndDestination { get; set; }

        [Required]
        public string TakeOffTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        [Required]
        public PlaneType PlaneType { get; set; }

        [Required]
        public int PlaneNumber { get; set; }

        [Required]
        public string PilotName { get; set; }

        [Required]
        public int FreePassengersSeats { get; set; }

        [Required]
        public int FreeBusinessSeats { get; set; }

    }
}