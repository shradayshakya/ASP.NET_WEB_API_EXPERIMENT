using System;
using Microsoft.AspNetCore.Identity;

namespace cs_webapi_experiment.Data
{
	public class ApiUser: IdentityUser
	{

		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
