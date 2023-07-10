using System;
using cs_webapi_experiment.Core.Model.Country;

namespace cs_webapi_experiment.Core.Model.Hotel
{
    public class HotelDto : BaseHotelDto
    {
        public int Id { get; set; }

        public GetCountryDto Country { get; set; }

    }
}
