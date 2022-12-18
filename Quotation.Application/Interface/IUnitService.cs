using Quotation.Application.DTO;
using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Interface
{
    public interface IUnitService
    {
        List<UnitDTO> GetAllUnits();
        UnitDTO CreateUnit(UnitDTO unit);
        UnitDTO UpdateUnit(UnitDTO unit);
        UnitDTO GetUnitById(int id);  
        bool DeleteUnit(int id);

    }
}
