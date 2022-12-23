using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Repositories.Interface
{
    public interface ICityRepository
    {
        List<City> GetAllCities();
        City CreateCity(City city);
        City UpdateCity(City city);
        City GetCityById(int id);
        void DeleteCityById(City city);
    }
}
