using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Quatation.WebAPI.Model;
using System.Security.Claims;

namespace Quatation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]UserDetails userDetails)
        {
            if(!ModelState.IsValid || userDetails == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }

            var identityUser = new IdentityUser() { UserName = userDetails.Username, Email = userDetails.Email };
            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            return Ok(new { Message = "User Reigstration Successful" });
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            if(!ModelState.IsValid)
            {
                return new BadRequestObjectResult ( new { Message = "Data is not found" } );
            }
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user != null &&
               await _userManager.CheckPasswordAsync(user, login.Password))
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
