using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TimedAssignment.Data;
using TimedAssignment.Models.Users;

namespace TimedAssignment.Services.UserServices
{
    public class AuthenticationManager : IAuthenticationManager
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private string USERNAME = "";

        public AuthenticationManager(IConfiguration configuration, IMapper mapper, UserManager<User> userManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AuthResponseVM> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if(user is null||isValidUser == false)
            {
                return new AuthResponseVM();
            }
            var token = await GenerateToken(user);

        }

        private async Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        }

        public async Task<IEnumerable<IdentityError>> Register(UserEntityVM userEntity)
        {
            var user = _mapper.Map<User>(userEntity);
            user.UserName = userEntity.Email;
            var result = await _userManager.CreateAsync(user, userEntity.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }
    }
}