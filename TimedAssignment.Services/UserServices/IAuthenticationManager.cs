using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TimedAssignment.Models.Users;

namespace TimedAssignment.Services.UserServices
{
    public interface IAuthenticationManager
    {
        Task<IEnumerable<IdentityError>> Register(UserEntityVM userEntity);
        Task<AuthResponseVM> Login(LoginVM loginVM);
    }
}