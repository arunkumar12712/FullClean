using Microsoft.EntityFrameworkCore;
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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly QuotationDbContext _quotationDbContext;

        public CompanyRepository(QuotationDbContext quotationDbContext)
        {
            _quotationDbContext = quotationDbContext;
        }

        public Company CreateCompany(Company company)
        {
            _quotationDbContext.Company.Add(company);
            _quotationDbContext.SaveChanges();
            return company;
        }

        public void DeleteCompanyById(Company company)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAllCompanies()
        {
            return _quotationDbContext.Company.Include(i => i.State).Include(i => i.City).ToList();
        }

        public Company GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public Company UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
