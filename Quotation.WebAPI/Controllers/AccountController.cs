using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quatation.WebAPI.Model;
using Quotation.Application.ViewModel;
using Quotation.Infrastructure.Identity;
using System.Security.Claims;

namespace Quotation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel request)
        {
            var user =_mapper.Map<ApplicationUser>(request);
            var results = await _userManager.CreateAsync(user, request.Password);
            if(results.Succeeded)
            {

            }
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { Message = "Data is not found" });
            }
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null &&
               await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));
                return Ok(new { Message = "Login Successfully" });
            }
            else
            {
                return new BadRequestObjectResult(new { Message = "Invalid UserName or Password" });
            }
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return new BadRequestObjectResult(new { Message = "Logout successfully" });
        }
    }
}
