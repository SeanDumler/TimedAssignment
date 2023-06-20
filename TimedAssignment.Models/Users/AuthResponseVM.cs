using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Users
{
    public class AuthResponseVM
    {
        public string UserName { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}