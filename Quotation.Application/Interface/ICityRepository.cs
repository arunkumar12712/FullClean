using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Interface
{
    public interface ICityRepository
    {
        List<City> GetAllUnits();
        City CreateUnit(City city);
        City UpdateUnit(City city);
        City GetUnitById(int id);
        void DeleteUnitById(City city);
    }
}
