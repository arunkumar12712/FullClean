using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quotation.Application.DTO;
using Quotation.Application.Interface;
using Quotation.Application.Services;
using Quotation.Domain.Entities;

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
        public IActionResult PostUnit(UnitDTO request)
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
        public ActionResult<UnitDTO> PutUnit(UnitDTO request)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { Message = "Bad Request" });
            }
            var result = _unitService.UpdateUnit(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<UnitDTO> GetUnitById(int id) 
        { 
            var result = _unitService.GetUnitById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteUnit(int id)
        {
            var result = _unitService.DeleteUnit(id);
            if (result)
            {
                return new BadRequestObjectResult(new  { Message = "Delete Successfully" });
            }
            return NotFound();
        }
    }
}
