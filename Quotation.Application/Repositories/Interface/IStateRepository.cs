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
        List<State> GetAllStates();
        State CreateState(State state);
        State UpdateState(State state);
        State GetStateById(int id);
        void DeleteStateById(State state);
    }
}

