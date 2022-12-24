using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Repositories.Interface
{
    public interface ICompanyRepository
    {
        List<Company> GetAllCompanies();
        Company CreateCompany(Company company);
        Company UpdateCompany(Company company);
        Company GetCompanyById(int id);
        void DeleteCompanyById(Company company);
    }
}
