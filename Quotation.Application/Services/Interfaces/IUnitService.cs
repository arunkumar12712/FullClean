using Quotation.Application.ViewModel;
using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Services.Interfaces
{
    public interface IUnitService
    {
        List<UnitViewModel> GetAllUnits();
        UnitViewModel CreateUnit(UnitViewModel unit);
        UnitViewModel UpdateUnit(UnitViewModel unit);
        UnitViewModel GetUnitById(int id);
        bool DeleteUnit(int id);

    }
}
