using System;
using System.ComponentModel.DataAnnotations;

namespace cs_webapi_experiment.Core.Model.Users
{
    public class LoginDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} charasters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

