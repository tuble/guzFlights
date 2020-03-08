using guzFlightsUltra.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using guzFlightsUltra.BindingModels.Flight;
using System;
using guzFlightsUltra.Models;
using guzFlightsUltra.Models.ViewModels.Flight;
using System.Collections.Generic;
using guzFlightsUltra.Models.ViewModels.Reservation;
using guzFlightsUltra.Data.Enums;

namespace guzFlightsUltra.Controllers
{
    public class FlightController : Controller
    {
        private IFlightService flightService;
        private IReservationService reservationService;

        public FlightController(IFlightService flightService, IReservationService reservationService)
        {
            this.flightService = flightService;
            this.reservationService = reservationService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create(InputBindingModel input)
        {
            return View(input);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Create(CreateBindingModel input)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Flight/Create"); // do some error message
            }

            if(input.StartDestination == input.EndDestination)
            {
                return Redirect("/Flight/Create"); // do some error message
            }

            // parse string to DateTime Format

            var takeOffTime = new DateTime();

            if (!DateTime.TryParse(input.TakeOffTime, out takeOffTime))
            {
                return Redirect("/Flight/Create"); // do some error message
            }

            var arrivalTime = new DateTime();

            if (!DateTime.TryParse(input.ArrivalTime, out arrivalTime))
            {
                return Redirect("/Flight/Create"); // do some error message
            }

            if (arrivalTime <= takeOffTime) // check if flight times valid
            {
                return Redirect("/Flight/Create"); // do some error message
            } 

            var flight = new FlightServiceModel
            {
                StartDestination = input.StartDestination,
                EndDestination = input.EndDestination,
                TakeOffTime = takeOffTime,
                ArrivalTime = arrivalTime,
                PlaneType = input.PlaneType,
                PilotName = input.PilotName
            };

            switch (input.PlaneType)
            {
                case PlaneType.SMALL:
                    flight.FreeSeatsPassanger = 100;
                    flight.FreeSeatsBussiness = 50;
                    break;
                case PlaneType.MEDIUM:
                    flight.FreeSeatsPassanger = 200;
                    flight.FreeSeatsBussiness = 100;
                    break;
                case PlaneType.LARGE:
                    flight.FreeSeatsPassanger = 300;
                    flight.FreeSeatsBussiness = 150;
                    break;
                default:
                    break;
            }

            flightService.CreateFlight(flight);

            return Redirect("/Home/Index");
        }

        public IActionResult GetAll(int page)
        {
            if (page <= 0)
            {
                return Redirect("/Home/Index");
            }

            int flightsCount = flightService.Count();

            var lastPage = flightsCount / 8 + 1; // 8 flights per page

            if (flightsCount % 8 == 0 && lastPage > 1)
            {
                lastPage--;
            }

            if (page > lastPage)
            {
                return Redirect("/Home/Index");
            }

            var flights = flightService.GetAll(page);

            var viewModel = new Models.ViewModels.Flight.ListingPageViewModel
            {
                CurrentPage = page,
                AllFlights = flightsCount,
                LastPage = lastPage,
                Flights = new List<ListingViewModel>()
            };

            foreach (var flight in flights)
            {
                TimeSpan span = (flight.ArrivalTime - flight.TakeOffTime);

                var travelTime = String.Format("{0} days/{1} hours/{2} minutes",
                    span.Days, span.Hours, span.Minutes, span.Seconds);

                viewModel.Flights.Add(new ListingViewModel()
                {
                    StartDestination  = flight.StartDestination ,
                    EndDestination  = flight.EndDestination ,
                    TakeOffTime = flight.TakeOffTime.ToString("dd/MM/yyyy hh:mm tt"),
                    Id = flight.FlightId,
                    TravelTime = travelTime,
                    FreeSeatsPassanger = flight.FreeSeatsPassanger,
                    FreeSeatsBussiness = flight.FreeSeatsBussiness
                });
            }

            return View(viewModel);
        }

        public IActionResult Details(string id)
        {
            if (!flightService.ExistsId(id))
            {
                return Redirect("/Flight/GetAll?page=1");
            }

            var flight = flightService.GetFlight(id);
            var reservations = reservationService.GetAllByFlightId(flight.FlightId);

            var viewModel = new DetailsViewModel()
            {
                Id = flight.FlightId,
                ArrivalTime = flight.ArrivalTime.ToString("dd/MM/yyyy hh:mm tt"),
                TakeOffTime = flight.TakeOffTime.ToString("dd/MM/yyyy hh:mm tt"),
                FreeSeatsPassanger = flight.FreeSeatsPassanger,
                FreeSeatsBussiness = flight.FreeSeatsBussiness,
                StartDestination = flight.StartDestination,
                EndDestination = flight.EndDestination,
                PilotName = flight.PilotName,
                PlaneType = flight.PlaneType
            };

            foreach (var reservation in reservations)
            {
                viewModel.Passengers.Add(new ReservationViewModel
                {
                    SSN = reservation.SSN,
                    Email = reservation.Email,
                    FirstName = reservation.FirstName,
                    LastName = reservation.LastName,
                    Nationality = reservation.Nationality,
                    PhoneNumber = reservation.PhoneNumber,
                    SecondName = reservation.SecondName,
                    TicketType = reservation.TicketType.ToString(),
                    TicketsCount = reservation.TicketsCount
                });
            }

            return View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(string id)
        {
            if (!flightService.ExistsId(id))
            {
                return Redirect("/Flight/GetAll?page=1");
            }

            flightService.DeleteFlightById(id);

            return Redirect("/Flight/GetAll?page=1");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(string id)
        {
            if (!flightService.ExistsId(id))
            {
                return Redirect("/Flight/GetAll?page=1");
            }

            var flight = flightService.GetFlight(id);

            var viewModel = new DetailsViewModel()
            {
                Id = flight.FlightId,
                ArrivalTime = flight.ArrivalTime.ToString("dd/MM/yyyy hh:mm tt"),
                TakeOffTime = flight.TakeOffTime.ToString("dd/MM/yyyy hh:mm tt"),
                FreeSeatsPassanger = flight.FreeSeatsPassanger,
                FreeSeatsBussiness = flight.FreeSeatsBussiness,
                StartDestination = flight.StartDestination,
                EndDestination = flight.EndDestination,
                PilotName = flight.PilotName,
                PlaneType = flight.PlaneType
            };

            return View(viewModel);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Edit(InputBindingModel input)
        {
            if (!ModelState.IsValid)
            {
                return Redirect($"/Flight/Edit?id={input.Id}");
            }

            var takeOffTime = new DateTime();

            if (!DateTime.TryParse(input.TakeOffTime, out takeOffTime))
            {
                return Redirect($"/Flight/Edit?id={input.Id}");
            }

            var arrivalTime = new DateTime();

            if (!DateTime.TryParse(input.ArrivalTime, out arrivalTime))
            {
                return Redirect($"/Flight/Edit?id={input.Id}");
            }

            if (arrivalTime < takeOffTime)
            {
                return Redirect($"/Flight/Edit?id={input.Id}");
            }

            var flight = new FlightServiceModel
            {
                Id = input.Id,
                StartDestination = input.StartDestination,
                EndDestination = input.EndDestination,
                TakeOffTime = takeOffTime ,
                ArrivalTime = arrivalTime,
                FreeSeatsPassanger  = input.FreeSeatsPassanger ,
                FreeSeatsBussiness = input.FreeSeatsBussiness ,
                PlaneType = input.PlaneType,
                PilotName = input.PilotName
            };

            flightService.EditFlight(flight);

            return Redirect("/Flight/GetAll?page=1");
        }
    }
}
