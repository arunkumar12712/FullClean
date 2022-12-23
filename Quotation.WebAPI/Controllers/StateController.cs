using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Services.Interfaces;
using Quotation.Application.ViewModel;

namespace Quotation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        [Route("GetAllState")]
        public ActionResult<List<StateViewModel>> GetAllState()
        {
            return Ok(_stateService.GetAllStates());
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<StateViewModel> PostCreate(StateViewModel state)
        {
            return Ok(_stateService.CreateState(state));
        }

    }
}
