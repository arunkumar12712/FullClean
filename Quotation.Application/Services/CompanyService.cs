using MapsterMapper;
using Quotation.Application.Repositories.Interface;
using Quotation.Application.Services.Interfaces;
using Quotation.Application.ViewModel;
using Quotation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper) 
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public CompanyViewModel CreateCompany(CompanyViewModel company)
        {
            var response = _companyRepository.CreateCompany(_mapper.Map<Company>(company));
            return _mapper.Map<CompanyViewModel>(response);
        }

        public List<CompanyViewModel> GetAllCompany()
        {
            return  _mapper.Map<List<CompanyViewModel>>(_companyRepository.GetAllCompanies());
        }
    }
}
