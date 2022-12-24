using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Services.Interfaces;
using Quotation.Application.ViewModel;

namespace Quotation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("GetAllCompanies")]
        public ActionResult<List<CompanyViewModel>> GetAllCompanies()
        {
            return Ok(_companyService.GetAllCompany()); 
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<CompanyViewModel> Create(CompanyViewModel company)
        {
            return Ok(_companyService.CreateCompany(company));
        }
    }
}
