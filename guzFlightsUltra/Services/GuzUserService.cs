using guzFlightsUltra.Data;
using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Models;
using guzFlightsUltra.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace guzFlightsUltra.Services
{
    public class GuzUserService : IGuzUserService
    {
        private guzFlightsUltraDbContext context;

        public GuzUserService(guzFlightsUltraDbContext context, UserManager<User> userManager)
        {
            this.context = context;
        }

        public int Count()
        {
            return context.Users.Count();
        }

        public List<User> GetAll(int page, int onPage, string orderBy)
        {
            //var role = context.Roles.SingleOrDefault(r => r.Name == "Employee");

            var users = context.Users.ToList();

            if (orderBy == "emailAscending")
            {
                users = users.OrderBy(u => u.Email).ToList();
            }
            else if (orderBy == "emailDescending")
            {
                users = users.OrderByDescending(u => u.Email).ToList();
            }
            else if (orderBy == "unameDescending")
            {
                users = users.OrderByDescending(u => u.UserName).ToList();
            }
            else if (orderBy == "firstNameAscending")
            {
                users = users.OrderBy(u => u.FirstName).ToList();
            }
            else if (orderBy == "firstNameDescending")
            {
                users = users.OrderByDescending(u => u.FirstName).ToList();
            }
            else if (orderBy == "lastNameAscending")
            {
                users = users.OrderBy(u => u.LastName).ToList();
            }
            else if (orderBy == "lastNameDescending")
            {
                users = users.OrderByDescending(u => u.LastName).ToList();
            }
            else // unameAscending
            {
                users = users.OrderBy(u => u.UserName).ToList();
            }

            var result = users
                .Take(page * onPage)
                .Skip((page - 1) * onPage)
                .ToList();

            return result;
        }

        public bool Contains(string id)
        {
            return context.Users.Any(u => u.Id == id);
        }

        public User GetById(string id)
        {
            if (!Contains(id))
            {
                throw new ArgumentException("Invalid user Id");
            }

            var user = context.Users.SingleOrDefault(u => u.Id == id);

            return user;
        }

        public void Edit(GuzUserServiceModel user)
        {
            if (!Contains(user.Id))
            {
                throw new ArgumentException("Invalid user id!");
            }

            var dbUser = context.Users.SingleOrDefault(u => u.Id == user.Id);

            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.SSN = user.SSN;
            dbUser.Address = user.Address;

            context.Users.Update(dbUser);
            context.SaveChanges();
        }

        public void DeleteById(string id)
        {
            var user = context.Users.SingleOrDefault(u => u.Id == id);

            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
