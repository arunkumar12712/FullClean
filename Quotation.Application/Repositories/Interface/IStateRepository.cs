using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Repositories.Interface
{
    public interface IStateRepository
    {
        List<State> GetAllUnits();
        State CreateUnit(State state);
        State UpdateUnit(State state);
        State GetUnitById(int id);
        void DeleteUnitById(State state);
    }
}
