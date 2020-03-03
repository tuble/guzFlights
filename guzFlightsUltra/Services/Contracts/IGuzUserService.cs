using guzFlightsUltra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guzFlightsUltra.Services.Contracts
{
    public interface IGuzUserService
    {

        List<GuzUser> GetAll(); // (показване на 10, 25 или 50 записа на страница
        List<GuzUser> GetByEmail(string email);
        List<GuzUser> GetByUserName(string userName);
        List<GuzUser> GetByFirstName(string firstName);
        List<GuzUser> GetByLastName(string lastName);

    }
}
