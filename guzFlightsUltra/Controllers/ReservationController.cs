using guzFlightsUltra.BindingModels.Reservation;
using guzFlightsUltra.Models.ViewModels.Reservation;
using guzFlightsUltra.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services; // for email sender
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace guzFlightsUltra.Controllers
{
    public class ReservationController : Controller
    {
        private IFlightService flightService;
        private IReservationService reservationService;


        public ReservationController(IFlightService flightService, IReservationService reservationService, IEmailSender emailSender)
        {
            this.flightService = flightService;
            this.reservationService = reservationService;
        }

        public IActionResult Make(string id)
        {
            if (!flightService.ExistsId(id))
            {
                return Redirect("/Flight/GetAll");
            }

            var reservation = new CreateBindingModel { };
            reservation.FlightId = id;

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Make(CreateBindingModel input)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Flight/GetAll");
            }

            if(flightService.GetFlight(input.FlightId).FreeSeatsBussiness == 0 || flightService.GetFlight(input.FlightId).FreeSeatsPassanger == 0 || flightService.GetFlight(input.FlightId).FreeSeatsPassanger - input.TicketsCount < 0 || flightService.GetFlight(input.FlightId).FreeSeatsBussiness - input.TicketsCount < 0)
            {
                return Redirect("/Flight/GetAll");
            }

            // if(input.)

            var reservation = new Models.ReservationServiceModel
            {
                FirstName = input.FirstName,
                SecondName = input.SecondName,
                LastName = input.LastName,
                SSN = input.SSN,
                PhoneNumber = input.PhoneNumber,
                Nationality = input.Nationality,
                TicketType = input.TicketType,
                TicketsCount = input.TicketsCount,
                IsConfirmed = false,
                FlightId = input.FlightId,
                Email = input.Email
            };

            reservationService.MakeReservation(reservation);

            return Redirect("/Flight/GetAll");
        }

        public IActionResult Confirm(string id)
        {
            if (!reservationService.ExistsId(id))
            {
                return Redirect("/Flight/GetAll");
            }

            reservationService.ConfirmReservation(id);

            return Redirect("/Flight/GetAll");
            // specify reservation as completed
        }

        public IActionResult Delete(string id)
        {
            if (!reservationService.ExistsId(id))
            {
                return Redirect("/Reservation/All?page=1"); // display error msg?
            }

            reservationService.DeleteReservation(id);

            return Redirect("/Reservation/All?page=1");
        }

        [Authorize]
        public IActionResult All(int page)
        {
            if (page <= 0)
            {
                return Redirect("/Home/Index");
            }

            int reservationsCount = reservationService.Count();

            var lastPage = reservationsCount / 8 + 1; // 8 reservations per page

            if (reservationsCount % 8 == 0 && lastPage > 1) // 8 reservations per page
            {
                lastPage--;
            }

            if (page > lastPage)
            {
                return Redirect("/Home/Index");
            }

            var reservations = reservationService.GetAll(page);

            var viewModel = new ListingPageViewModel
            {
                CurrentPage = page,
                TotalReservationsCount = reservationsCount,
                LastPage = lastPage,
                Reservations = new List<ReservationViewModel>()
            };

            foreach (var reservation in reservations)
            {
                viewModel.Reservations.Add(new ReservationViewModel()
                {
                    FirstName = reservation.FirstName,
                    SecondName = reservation.SecondName,
                    LastName = reservation.LastName,
                    SSN = reservation.SSN,
                    Email = reservation.Email,
                    Id = reservation.Id,
                    Confirmed = reservation.Confirmed,
                    Nationality = reservation.Nationality,
                    PhoneNumber = reservation.PhoneNumber,
                    TicketType = reservation.TicketType.ToString(),
                    TicketsCount = reservation.TicketsCount
                });
            }

            return View(viewModel);
        }
    }
}
