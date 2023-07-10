using System;
using System.ComponentModel.DataAnnotations;

namespace cs_webapi_experiment.Core.Model.Users
{
    public class ApiUserDto : LoginDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}

