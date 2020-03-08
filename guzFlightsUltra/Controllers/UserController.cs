using System.Collections.Generic;
using guzFlightsUltra.BindingModels.User;
using guzFlightsUltra.Models;
using guzFlightsUltra.Models.ViewModels.User;
using guzFlightsUltra.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace guzFlightsUltra.Controllers
{
    public class UserController : Controller
    {
        private IGuzUserService userService;

        public UserController(IGuzUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult All(int page, int onPage, string orderBy)
        {
            if (page <= 0)
            {
                return Redirect("/Home/Index");
            }

            int usersCount = userService.Count();

            if (onPage <= 0)
            {
                return Redirect("/Home/Index");
            }

            var lastPage = usersCount / onPage + 1;

            if (usersCount % onPage == 0 && lastPage > 1)
            {
                lastPage--;
            }

            if (page > lastPage)
            {
                return Redirect("/Home/Index");
            }

            var users = userService.GetAll(page, onPage, orderBy);

            var viewModel = new ListingPageViewModel
            {
                CurrentPage = page,
                UsersCount = usersCount,
                UsersPerPage = onPage,
                LastPage = lastPage,
                OrderParam = "orderBy=" + orderBy,
                Users = new List<ListingViewModel>()
            };

            foreach (var u in users)
            {
                viewModel.Users.Add(new ListingViewModel()
                {
                    Username = u.UserName,
                    Address = u.Address,
                    SSN = u.SSN,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    Id = u.Id,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber
                });
            }

            return View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(string id)
        {
            if (!userService.Contains(id))
            {
                return Redirect("/User/All?page=1&showBy=10&orderBy=unameAscending");
            }

            var user = userService.GetById(id);

            var viewModel = new EditBindingModel
            {
                Address = user.Address,
                SSN = user.SSN,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Edit(EditBindingModel input)
        {
            if (!userService.Contains(input.Id))
            {
                return Redirect("/User/All?page=1&showBy=10&orderBy=unameAscending");
            }

            if (!ModelState.IsValid)
            {
                return Redirect("/User/All?page=1&showBy=10&orderBy=unameAscending");
            }

            var serviceModel = new GuzUserServiceModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                SSN = input.SSN,
                Address = input.Address
            };

            userService.Edit(serviceModel);

            return Redirect("/User/All?page=1&showBy=10&orderBy=unameAscending");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(string id)
        {
            if (!userService.Contains(id))
            {
                return Redirect("/User/All?page=1&showBy=10&orderBy=unameAscending");
            }

            userService.DeleteById(id);

            return Redirect("/User/All?page=1&showBy=10&orderBy=unameAscending");
        }

    }
}
