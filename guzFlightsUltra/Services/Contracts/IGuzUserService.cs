using guzFlightsUltra.Data.Models;
using guzFlightsUltra.Models;
using System.Collections.Generic;

namespace guzFlightsUltra.Services.Contracts
{
    public interface IGuzUserService
    {
        int Count();
        List<User> GetAll(int page, int onPage, string orderBy); // (показване на 10, 25 или 50 записа на страница
        bool Contains(string id);
        User GetById(string id);
        void Edit(GuzUserServiceModel user);
        void DeleteById(string id);

    }
}
