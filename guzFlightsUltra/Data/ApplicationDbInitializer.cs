using guzFlightsUltra.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("fustuci12@gmail.com").Result == null)
            {
                User adminUser = new User
                {
                    UserName = "guzAdmin",
                    Email = "fustuci12@gmail.com",
                    FirstName = "Yana",
                    LastName = "Brat",

                };

                IdentityResult result = userManager.CreateAsync(adminUser, "adminPass").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Administrator").Wait();
                }
            }
        }
    }
}