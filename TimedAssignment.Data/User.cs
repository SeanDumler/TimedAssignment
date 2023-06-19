using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TimedAssignment.Data
{
    public class User : IdentityUser
    {
        [MaxLength(200,ErrorMessage = "Name cannot exceed 200 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(200,ErrorMessage = "Name cannot exceed 200 characters.")]
        public string LastName { get; set; } = string.Empty;

        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}