using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Services;
using Quotation.Application.Services.Interfaces;
using Quotation.Application.ViewModel;
using Quotation.Domain.Entities;
using System.Net;

namespace Quotation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        [Route("AllUnit")]
        public IActionResult GetAllUnits()
        {
            var results = _unitService.GetAllUnits().ToList();
            return Ok(results);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult PostUnit(UnitViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { Message = "Bad Request" });
            }
            var result = _unitService.CreateUnit(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<UnitViewModel> PutUnit(UnitViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { Message = "Bad Request" });
            }
            var result = _unitService.UpdateUnit(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<UnitViewModel> GetUnitById(int id) 
        { 
            var result = _unitService.GetUnitById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteUnit(int id)
        {
            var result = _unitService.DeleteUnit(id);
            if (result)
            {
                return Ok("Delete Successfully ");
            }
            return NotFound();
        }
    }
}
