using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quotation.Application.ViewModel;
using Quotation.Infrastructure.Identity;
using System.Net;
using System.Security.Claims;

namespace Quotation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel request)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var results = await _userManager.CreateAsync(user, request.Password);
            if (results.Succeeded)
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

        [HttpGet]
        [Route("AllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_mapper.Map<List<UserViewDetails>>(_userManager.Users.ToList()));
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleViewModel request)
        {
            IdentityResult result = new IdentityResult();
            IdentityError? error = new IdentityError();
            if (request != null)
            {
                 result = await _roleManager.CreateAsync(new IdentityRole() { Name = request.Name });
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    error = result.Errors.FirstOrDefault();
                    return new BadRequestObjectResult(new { Error = error });
                }
            }
            return new BadRequestResult();
        }
        

        [HttpGet]
        [Route("AllRoles")]
        public ActionResult<RoleViewModel> AllRoles()
        {
            return Ok(_mapper.Map<List<RoleViewModel>>(_roleManager.Roles));
        }


        [HttpPost]
        [Route("AssignRoles")]
        public async Task<IActionResult> AssignRoles(AssignRoleViewModel request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            var roles = await _userManager.AddToRoleAsync(user, request.Name);
            return Ok(roles);
        }
    }
}

