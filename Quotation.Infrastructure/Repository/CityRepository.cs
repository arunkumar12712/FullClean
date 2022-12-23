using Quotation.Application.Repositories.Interface;
using Quotation.Domain.Entities;
using Quotation.Infrastructure.Data;
using Quotation.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly QuotationDbContext _quotationDbContext;
        public CityRepository(QuotationDbContext quotationDbContext) 
        { 
            _quotationDbContext = quotationDbContext;
        }

        public City CreateUnit(City city)
        {
            _quotationDbContext.Add(city);
            _quotationDbContext.SaveChanges();
            return city;
        }

        public void DeleteUnitById(City city)
        {
            _quotationDbContext.Remove(city);
            _quotationDbContext.SaveChanges();
        }

        public List<City> GetAllUnits()
        {
           return _quotationDbContext.Cities.ToList();
        }

        public City GetUnitById(int id)
        {
            var result = _quotationDbContext.Cities.Where(t => t.Id == id).FirstOrDefault();
            if(result != null)
            {
                return result;
            }
            return result = new City();
        }

        public City UpdateUnit(City city)
        {
            var result = _quotationDbContext.Update(city);
            _quotationDbContext.SaveChanges();
            return result.Entity;
        }
    }
}
