using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Services;
using Quotation.Application.Services.Interfaces;
using Quotation.Application.ViewModel;

namespace Quotation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<CityViewModel> Create(CityViewModel city)
        {
            var response = _cityService.Create(city);
            return Ok(response);
        }
    }
}
