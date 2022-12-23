using Quotation.Application.Repositories.Interface;
using Quotation.Domain.Entities;
using Quotation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly QuotationDbContext _quotationDbContext;

        public StateRepository(QuotationDbContext quotationDbContext) 
        {
            _quotationDbContext = quotationDbContext;
        }

        public State CreateState(State state)
        {
            _quotationDbContext.Add(state);
            _quotationDbContext.SaveChanges();
            return state;
        }

        public void DeleteStateById(State state)
        {
            _quotationDbContext.Remove(state);
            _quotationDbContext.SaveChanges();  
        }

        public List<State> GetAllStates()
        {
           return _quotationDbContext.States.ToList();
        }

        public State GetStateById(int id)
        {
            var results = _quotationDbContext.States.Where(t => t.Id == id).SingleOrDefault();
            if(results != null)
            {
                return results;
            }
            return new State();
        }

        public State UpdateState(State state)
        {
            var result = _quotationDbContext.Update(state);
            _quotationDbContext.SaveChanges();
            return result.Entity;
        }
    }
}
