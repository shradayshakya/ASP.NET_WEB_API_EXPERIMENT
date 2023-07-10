using cs_webapi_experiment.Core.Model.Hotel;

namespace cs_webapi_experiment.Core.Model.Country
{
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }
        public List<HotelDto> Hotels { get; set; }

    }
}

