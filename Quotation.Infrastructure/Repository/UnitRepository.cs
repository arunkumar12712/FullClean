using Microsoft.EntityFrameworkCore;
using Quotation.Application.Interface;
using Quotation.Domain.Entities;
using Quotation.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Repository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly QuotationDbContext _quotationDbContext;

        public UnitRepository(QuotationDbContext quotationDbContext)
        {
            _quotationDbContext = quotationDbContext;
        }

        public Unit CreateUnit(Unit unit)
        {
            _quotationDbContext.Add(unit);
            _quotationDbContext.SaveChanges();
            return unit;
        }

        public void DeleteUnitById(Unit unit)
        {
             _quotationDbContext.Remove(unit);
            //unit.State = EntityState.Deleted;
            _quotationDbContext.SaveChanges();
        }

        public List<Unit> GetAllUnits()
        {
            return _quotationDbContext.Units.ToList();
        }

        public Unit? GetUnitById(int id)
        {
            var sources =  _quotationDbContext.Units.Where(x => x.Id == id).SingleOrDefault();
            return sources;
        }

        public Unit UpdateUnit(Unit unit)
        {
            var result = _quotationDbContext.Update(unit);
            _quotationDbContext.SaveChanges();
            return result.Entity;
        }
    }
}
