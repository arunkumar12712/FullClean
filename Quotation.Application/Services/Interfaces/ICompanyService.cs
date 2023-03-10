using Quotation.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Services.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyViewModel> GetAllCompany();
        CompanyViewModel CreateCompany(CompanyViewModel company);
    }
}
