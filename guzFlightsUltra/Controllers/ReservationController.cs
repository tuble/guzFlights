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
    public class ReservationController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IReservationService _reservationService;
        public ReservationController(IFlightService flightService, IReservationService reservationService)
        {
            _flightService = flightService;
            _reservationService = reservationService;
        }

        public IActionResult ReserveAndConfirmReservationByEmail()
        {
            var viewModel = new ReserveAndConfirmReservationByEmailViewModel(); // IMPLEMENT

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult ReserveAndConfirmReservationByEmail(int flightId, List<guzFlightsUltra.Data.Models.Passenger> passengers, string email)
        {

            return this.RedirectToAction("ListAll");
        }

        public IActionResult ListAll()
        {
            var viewModel = new IndexAllReservationsViewModel();

            viewModel.Reservations = _reservationService.GetAll();

            return this.View(viewModel);
        }

        public IActionResult GetAllMatchingEmail(string email)
        {
            var viewModel = new GetAllReservationsMatchingEmail();

            viewModel.ReservationsMatchingMail = _reservationService.GetAllMatchingEmail(email);

            return this.View(viewModel);
        }

    }
}
*/