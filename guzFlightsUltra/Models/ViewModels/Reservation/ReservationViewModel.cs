﻿namespace guzFlightsUltra.Models.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string TicketType { get; set; }
        public int TicketsCount { get; set; }
        public bool Confirmed { get; set; }
    }
}
