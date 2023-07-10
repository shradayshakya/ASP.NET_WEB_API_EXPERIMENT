using System;
using System.ComponentModel.DataAnnotations;

namespace cs_webapi_experiment.Core.Model.Country
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}

