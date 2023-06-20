using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Users;
using TimedAssignment.Services.UserServices;

namespace TimedAssignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticationManager _authManager;

        public UsersController(IAuthenticationManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]UserEntityVM userEntityVM)
        {
            var errors = await _authManager.Register(userEntityVM);
            if(errors.Any())
            {
                foreach (IdentityError error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            return Ok("User Is Registered");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginVM loginVM)
        {
            var authResponse = await _authManager.Login(loginVM);
            if(authResponse is null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }
    }
}