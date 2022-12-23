using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Repositories.Interface
{
    public interface IUnitRepository
    {
        List<Unit> GetAllUnits();
        Unit CreateUnit(Unit unit);
        Unit UpdateUnit(Unit unit);
        Unit? GetUnitById(int id);
        void DeleteUnitById(Unit unit);
    }
}
