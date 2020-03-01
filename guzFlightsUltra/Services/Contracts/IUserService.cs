using guzFlightsUltra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Services.Contracts
{
    public interface IUserService
    {

        List<User> GetAll(); // (показване на 10, 25 или 50 записа на страница
        List<User> GetByEmail(string email);
        List<User> GetByUserName(string userName);
        List<User> GetByFirstName(string firstName);
        List<User> GetByLastName(string lastName);

    }
}
