using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using guzFlightsUltra.Data;
using guzFlightsUltra.Data.Enums;
using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Models;
using guzFlightsUltra.Services.Contracts;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace guzFlightsUltra.Services
{
    public class ReservationService : IReservationService
    {
        private guzFlightsUltraDbContext context;
        private IEmailSender emailSender;

        public ReservationService(guzFlightsUltraDbContext context, IEmailSender emailSender)
        {
            this.context = context;
            this.emailSender = emailSender;
        }

        public List<Reservation> GetAllByFlightId(string flightId)
        {
            return context.Reservations.Where(r => r.FlightId == flightId).ToList();
        }

        public void MakeReservation(ReservationServiceModel input)
        {
            if (input.TicketsCount <= 0)
            {
                return;
            }

            var flight = context.Flights.SingleOrDefault(f => f.FlightId == input.FlightId);

            if (input.TicketType == TicketType.BUSSINESS_CLASS && input.TicketsCount > flight.FreeSeatsBussiness)
            {
                return;
            }

            if (input.TicketType == TicketType.NORMAL && input.TicketsCount > flight.FreeSeatsPassanger)
            {
                return;
            }

            var reservation = new Reservation()
            {
                FirstName = input.FirstName,
                SecondName = input.SecondName,
                LastName = input.LastName,
                SSN = input.SSN,
                Email = input.Email,
                FlightId = input.FlightId,
                Confirmed = false,
                Nationality = input.Nationality,
                TicketsCount = input.TicketsCount,
                TicketType = input.TicketType,
                PhoneNumber = input.PhoneNumber
            };

            context.Reservations.Add(reservation);
            context.SaveChanges();

            var message = $@"Dear {reservation.FirstName} {reservation.LastName}, do you wish to confirm your reservation for {reservation.TicketsCount} {reservation.TicketType} Tickets from {flight.EndDestination} to {flight.StartDestination}?
              <br/>
               <a href='https://localhost:44322/Reservation/Confirm?id={reservation.Id}'>confirm</a>
                <br/>
                <a href='https://localhost:44322/Reservation/Delete?id={reservation.Id}'>delete</a>
            ";

            emailSender.SendEmailAsync(reservation.Email, "Confirm Your Reservation", message).GetAwaiter().GetResult();
        }

        public bool ExistsId(string id)
        {
            return context.Reservations.Any(r => r.Id == id);
        }

        public Reservation GetById(string id)
        {
            if (!ExistsId(id))
            {
                throw new ArgumentException("Invalid reservation id");
            }

            return context.Reservations.SingleOrDefault(r => r.Id == id);
        }

        public void ConfirmReservation(string id)
        {
            if (!ExistsId(id))
            {
                throw new ArgumentException("Invalid reservation id!");
            }

            var reservation = GetById(id);

            reservation.Confirmed = true;

            var flight = context.Flights.SingleOrDefault(f => f.FlightId == reservation.FlightId);

            if (reservation.TicketType == TicketType.BUSSINESS_CLASS)
            {
                flight.FreeSeatsBussiness -= reservation.TicketsCount;
            }

            if (reservation.TicketType == TicketType.NORMAL)
            {
                flight.FreeSeatsPassanger -= reservation.TicketsCount;
            }

            context.Flights.Update(flight);
            context.Reservations.Update(reservation);

            context.SaveChanges();
        }

        public void DeleteReservation(string id)
        {
            if (!ExistsId(id))
            {
                throw new ArgumentException("Invalid reservation id");
            }

            var reservation = GetById(id);

            if (reservation.Confirmed)
            {
                return;
            }

            context.Reservations.Remove(reservation);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Reservations.Count();
        }

        public List<Reservation> GetAll(int page)
        {
            return context.Reservations
                .OrderByDescending(r => r.Email)
                .Take(page * 8) // 8 reservations per page, external constant?
                .Skip((page - 1) * 8)
                .ToList();
        }
    }
}
