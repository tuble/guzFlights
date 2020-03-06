using System;
using System.ComponentModel.DataAnnotations;

namespace guzFlightsUltra.BindingModels.Flight
{
    public class CreateBindingModel
    {
        [Required]
        [MaxLength(30)]
        [RegularExpression("/^Guinea/ | /^Uganda/ | /^Zimbabwe/")]

        public string From { get; set; }

        [Required]
        [MaxLength(30)]
        [RegularExpression("/^Guinea/ | /^Uganda/ | /^Zimbabwe/")]

        public string To { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        [Required]
        public string PlaneType { get; set; }

        [Required]
        public int PlaneNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string PilotName { get; set; }

        [Required]
        [Range(0, 250)]
        public int FreePassengersSeats { get; set; }

        [Required]
        [Range(0, 50)]
        public int FreeBusinessSeats { get; set; }

        public string Image { get; set; }
    }
}