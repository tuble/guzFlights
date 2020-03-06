/*namespace guzFlightsUltra.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using guzFlightsUltra.Models;
    using guzFlightsUltra.Services.Contracts;
    using guzFlightsUltra.Services.EmailService;
    using Microsoft.AspNetCore.Authorization; // !!
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    // authorization !
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IReservationService _reservationService;
        public FlightController(IFlightService flightService, IReservationService reservationService)
        {
            _flightService = flightService;
            _reservationService = reservationService;

        }

        [Authorize(Roles = "Employee")]
        [Authorize(Roles = "Administrator")]
        public IActionResult ListAll()
        {
            var viewModel = new IndexAllFlightsViewModel();

            viewModel.Flights = _flightService.GetAll();

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateFlightViewModel(); // IMPLEMENT

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(string StartDestination, string EndDestination, DateTime TakeOffTime, DateTime ArrivalTime,
            string PlaneType, int PlaneId, string PilotName, int FreeSeats, int FreeBussinessSeats)
        {
            _flightService.CreateFlight(StartDestination, EndDestination, TakeOffTime, ArrivalTime,
                PlaneType, PilotName, FreeSeats, FreeBussinessSeats);

            return this.RedirectToAction("ListAll");
        }

        public IActionResult Delete()
        {
            var viewModel = new DeleteFlightViewModel();
            //viewModel.Flights = this._flightService.GetAll();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int flightId)
        {
            var viewModel = new DeleteFlightViewModel();
            _flightService.DeleteFlight(flightId);


            // viewModel.Albums = this.albumService.GetAll();
            // this.albumService.DeleteAlbum(albumId);
            return this.RedirectToAction("ListAll");
        }

        [Route("Flight/PassengersReserved/{id}")]
        public IActionResult GetCurrentReservationAllPassangers(int reservationId)
        {
            var viewModel = new GetCurrentReservationAllPassengersViewModel();
            viewModel.Passengers = this._flightService.GetCurrentReservationAllPassangers(reservationId);

            return this.View(viewModel);
        }
    }
}*/