using System;
namespace cs_webapi_experiment.Core.Model.Users
{
    public class AuthResponseDto
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}

