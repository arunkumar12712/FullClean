using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Quatation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private List<string> employee = new List<string>() {"Lipsa","Arun" };
        private readonly UserManager<IdentityUser>  _userManager;
        public EmployeeController(UserManager<IdentityUser> userManager) 
        { 
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("AllEmployee")]
        public IActionResult AllEmployee()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            return Ok(employee);
        }
    }


}
